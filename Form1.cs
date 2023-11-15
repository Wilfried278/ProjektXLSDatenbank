using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Office.Interop.Excel;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;

namespace ProjektXLSDatenbank
{
    #region Datenelemente im Namespace

    /// <summary>
    /// Bestimmt die Sortierrichtung und das Sortierfeld
    /// </summary>
    public enum SortierFeld { AnlagdatumProjektASC, AnlagdatumProjektDES, ProjekNrASC, ProjekNrDES };

    #endregion // Datenelemente im Namespace 



    /// <summary>
    /// Hauptformular der Anwendung
    /// </summary>
    public partial class Form1 : Form
    {
        #region Datenelemente


        /// <summary>
        /// Bestimmt das Format des Zeitstempels, der für die Erweiterung von Dateinamen verwandt wird
        /// </summary>
        enum zeitStempelFormat { Zeit, Datum, DatumZeit };
        /// <summary>
        ///  Spaltenindex für das ListView Steuerelement 
        /// </summary>
        enum LVWSpaltenIndex { ProjektNummer = 0, PersonObjekt, Sachmerkmal1, Sachmerkmal2, Sachmerkmal3, Anlagedatum, Anleger, Archivdatum, Ablageort };

        /// <summary>
        /// Liste mit den Eintragen dioe zur Suche von Container zur Suche von Projekten
        /// </summary>
        private List<string> suchListe;

        /// <summary>
        /// List mit den Projektnummer, die aus einer Suche resultieren
        /// </summary>
        private List<int> suchProjektnummern;

        //private readonly DateTime startDatum = new DateTime(2000, 1, 1);
        /// <summary>
        ///  Feldtrenner zum erzeugen der Suchliste
        /// </summary>
        private const char separator = '|';

        /// <summary>
        ///  repräsentiert die Liste mit Projektdatensätzen
        /// </summary>
        CProjektDatenListe projektdaten;

        /// <summary>
        /// Repräsentiert die Liste mit den eindeutigen Person/Objekt bzw. Kategorien
        /// </summary>
        List<string> personObjektDistinct;


        /// <summary>
        /// Liste in der die fehlenden Prohektnummern, die beim Einlesen festgestellt wurden gespeichert werden
        /// </summary>
        List<int> fehlendeProjektNummern;
        /// <summary>
        /// Liste in der doppelten Prohektnummern, die beim Einlesen festgestellt wurden gespeichert werden
        /// </summary>
        List<int> doppelteprojektnummern;
        /// <summary>
        /// Statistische Variable, die einen 
        /// </summary>
        private int anzahlArchivprojekte = 0;
        private int anzahlLaufendeProjekte = 0;
        double anzalArchivprojekteProzent = 0;

        CProgrammEinstellungen programmEinstellungen;

        private const string Xmldateiname = "ProjektXLSDatenbank.xml";
        private const string xmlPfadErweiterung = "\\ProjektXLSDatenbank";

        private string XmlDateipfad;
        private string xmldateinamePfad;

        /// <summary>
        /// Kenner der angibtm, ob das Programm sich im Suchmodus befindet
        /// </summary>
        private bool suchenAktiviert = false;
        /// <summary>
        /// Speichert den Änderungszustand
        /// </summary>
        private bool speichernErforderlich = false;

        // private string MessageBackgroundworker = "";

        private DlgInfoFenster dialogInfoFenster;

        public delegate void delegateMethode();
        public delegateMethode mydelegate;

        #endregion // Datenelemente 

        #region Konstruktion

        public Form1()
        {
            InitializeComponent();

            dialogInfoFenster = new DlgInfoFenster();

            bool initOk = false;

            initOk = initialisiereDatenelemente();

            //  Schlug die Initialisierung fehl, konnten also die Programmeinstellung nicht geladen werden
            //  dann wurde die XML-Datei mit Standardwerten erzeugt. Dem User wird dann die Information zurückgegeben
            //  dass er die XML-Datei pflegen muss
            //  Daraufhin wird die Weiterverarbeitung abgebrochen
            //
            if (initOk == false)
            {
                ausgebenWarnung("Programmeinstellungen!", "Die Programnmeinstellungen wurde nicht gefunden!");
                ausgebenWarnung("Programmeinstellungen!", "Die Programnmeinstellungen wurden auf Standardwerte initialisiert!");
                ausgebenWarnung("Programmeinstellungen!", "Bitte pflegen sie die Datei " + Xmldateiname + " im Pfad " + XmlDateipfad + "!");
                throw new Exception("Die Anwendung konnte nicht gestartet werden!");
            }

            // Diese Aufgabe erledigt der Backgroungworker, siehe Methode Form1_Shown
            //einlesenExceldaten();

        }

        #endregion // Konstruktion  

        #region Initialisierung

        private bool initialisiereDatenelemente()
        {
            BTN_Neu.Visible = true;

            

            bool xmlWarVorhanden = false;
            //  
            //  Anpassung (25.05.2019  08:42:43): Diesrn Block in die Methode  ladeProgrammEinstellungen() verlegen
            //  
            XmlDateipfad = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            XmlDateipfad += xmlPfadErweiterung;
            if (Directory.Exists(XmlDateipfad) == false)
                Directory.CreateDirectory(XmlDateipfad);

            xmlWarVorhanden = ladeProgrammEinstellungen();
            if (xmlWarVorhanden == false)
                return false;
            //  
            //  Anpassung der Darstellung
            //  
            if (programmEinstellungen.FensterMaximiertAnzeigen == true)
                this.WindowState = FormWindowState.Maximized;

            LVW_Exceldaten.Font = new System.Drawing.Font(LVW_Exceldaten.Font.Name, (float)programmEinstellungen.Schriftgröße, FontStyle.Regular);
            //  
            //  Liste zur Aufnahme der Suchkriterien für die Projekt zu erzeugen
            //  
            suchListe = new List<string>(500);
            //  
            //  Liste mit den möglich Projektnummer initialisieren
            //  
            suchProjektnummern = new List<int>(500);


            toolStripStatusLabel1.Text = "......";
            this.Text = "Projektjektverwaltung auf Basis einer Excel-Arbeitsmappe";
            this.StartPosition = FormStartPosition.CenterScreen;

            return true;
        }

        #endregion // Initialisierung 

        #region Eigenschaften

        #endregion // Eigenschaften 

        #region Methoden

        #region Methoden privat 
        /// <summary>
        /// Laden der Programeinstellungen aus einer XML Datei die im Pfad
        /// %programdata%\RWE Power\_Name_der_Anwendung abgelegt ist (sein sollte).
        /// </summary>
        /// <returns></returns>
        private bool ladeProgrammEinstellungen()
        {
            xmldateinamePfad = Path.Combine(XmlDateipfad, Xmldateiname);
            //  
            //  Anpassung (25.05.2019  08:39:37): Datenpfad an dieser Stelle erzeugen,
            //  falls es nicht existiert
            //  
            if (File.Exists(xmldateinamePfad) == true)
                ladeXMLDatei();
            else
            {
                programmEinstellungen = new ProjektXLSDatenbank.CProgrammEinstellungen();
                speichereXMLDatei();
                return false;
            }

            return true;

        }

        /// <summary>
        /// Speichern der Programmeinstellungen in die XML Datei, die im Pfad
        /// %programdata%\RWE Power\_Name_der_Anwendung abgelegt ist.
        /// </summary>
        private void speichereXMLDatei()
        {

            XmlSerializer writer = new XmlSerializer(typeof(ProjektXLSDatenbank.CProgrammEinstellungen));
            StreamWriter wfile = new StreamWriter(xmldateinamePfad);
            writer.Serialize(wfile, programmEinstellungen);
            wfile.Close();
        }

        private void ladeXMLDatei()
        {
            // Now we can read the serialized book ...  
            XmlSerializer reader = new XmlSerializer(typeof(ProjektXLSDatenbank.CProgrammEinstellungen));
            StreamReader file = new StreamReader(xmldateinamePfad);

            object? x = reader.Deserialize(file);
            if (x is not null)
            {
                programmEinstellungen = (CProgrammEinstellungen)x;
            }


            file.Close();
        }

        /// <summary>
        /// Erstellt eine kopie der Quelldatei zu Datensicherungszwekem
        /// </summary>
        /// <param name="quellDatei">Ursprungsdatei</param>
        /// <param name="zieldatei">Sicherungsdatei</param>
        private void copyBackupFile(string quellDatei)
        {
            string neuerName = gibZielDateinamen(quellDatei);

            FileInfo fi = new FileInfo(quellDatei);

            fi.CopyTo(neuerName);

        }

        /// <summary>
        /// Erweitern eines Dateinamens um einen Zeitstempel (Datum und Uhrzeit)
        /// </summary>
        /// <param name="quelldatei">Die Ursprungsdatei</param>
        /// <returns>Der neu Dateinamen inklusive des Zeitstempel</returns>
        private string gibZielDateinamen(string quelldatei)
        {

            string pfad = string.Empty;
            string dateiname;
            string extension;
            string zeitStempel;
            string neuerName;

            object? checkPfadNull = Path.GetDirectoryName(quelldatei);

            if (checkPfadNull is not null)
                pfad = (string)checkPfadNull;

            dateiname = Path.GetFileNameWithoutExtension(quelldatei);
            extension = Path.GetExtension(quelldatei);
            zeitStempel = gibZeitstempel(zeitStempelFormat.DatumZeit);
            neuerName = Path.Combine(pfad, dateiname);
            neuerName += "_" + zeitStempel + extension;

            return neuerName;

        }


        private string gibZeitstempel(zeitStempelFormat format1)
        {
            DateTime jetzt = DateTime.Now;
            string zeit = jetzt.Hour.ToString("00") + jetzt.Minute.ToString("00") + jetzt.Second.ToString("00");
            string datum = jetzt.Year.ToString("0000") + jetzt.Month.ToString("00") + jetzt.Day.ToString("00");
            string stempel;

            switch (format1)
            {
                case zeitStempelFormat.Zeit:
                    stempel = zeit;
                    break;
                case zeitStempelFormat.Datum:
                    stempel = datum;
                    break;
                case zeitStempelFormat.DatumZeit:
                    stempel = datum + "_" + zeit;
                    break;
                default:
                    stempel = zeit;
                    break;
            }

            return stempel;
        }
        #endregion // Methoden privat 

        #region Methoden öffentlich

        #endregion // Methoden öffentlich

        #endregion // Methoden 

        #region Serialisierung

        #endregion // Serialisierung 

        #region Schaltblächen (Button)

        /// <summary>
        /// Mit einem Klick auf den Ok-Nutton soll die Anwendung beendet werden. Eventuell, dann wenn Änderungen 
        /// am Datenbestand vorgenommern wurden, muss der Datenbestang gespeichert werden 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_OK_Click(object sender, EventArgs e)
        {
            //
            if (speichernErforderlich == true)
            {
                copyBackupFile(programmEinstellungen.XlsFullFilename);
                //
                toolStripStatusLabel1.Text = "Speichern der Exceldaten in " + programmEinstellungen.XlsFullFilename;
                speichernXLSDaten();
            }

            this.Close();
        }

        /// <summary>
        /// Speichern der Projektdaten, wieder zurück in die Exceltabelle
        /// </summary>
        private void speichernXLSDaten()
        {
            this.Cursor = Cursors.WaitCursor;
            string excelDatei = programmEinstellungen.XlsFullFilename;
            int arbeitsBlatt = 1;
            XLS2Object daten = new XLS2Object(excelDatei, arbeitsBlatt);
            daten.speichernExcelDaten(projektdaten, programmEinstellungen.AnzahlExcelSpalten, excelDatei, programmEinstellungen.ErsteZeileDatenbereich);
            toolStripStatusLabel1.Text = "Exceldaten sind gespeichert!";
            this.Cursor = Cursors.Default;
            Thread.Sleep(1000);
        }


        /// <summary>
        /// Ein neues Projekt anlegen. Wird ein neues Projekt angelegt, so wird der Anlegername
        /// mit dem Standardwert aus dem  Programmeinstellungen vor besetzt. Bei der Neuanlage eines Projektes
        /// wird der gleiche Dialog verwendet wie beim Anzeigen eines vorhandenen Projektes. Der Unterschied liegt darin,
        /// dass bei der Neuanlage die Höchste vorhandene Projektnummer ermittelt wird, dann ein leerer Projektdatensatz erzeugt wird,
        /// die entsprechenden Voreinstellungen vorgenommen werden (Eingabefelder sind mit Leerstring vorbesetzt) und der Datensatz dann
        /// zum editieren angezeigt wird. Die Speicherung des neuen Datensatz erfolgt nur im RAM. Die Daten werden  erst dann
        /// auf die Platte gespeichert, wenn das Programm mit  der Schaltfläche o. k. beendet wird.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_Neu_Click(object sender, EventArgs e)
        {
            int projektnummerNeu = projektdaten.maxPojektNummer() + 1;
            ProjektXLSDatenbank.CProjektdatensatz pds = new ProjektXLSDatenbank.CProjektdatensatz();
            //
            //  Leeren Projektdatensatz mit der neuen Projektnummer vor besetzen
            //
            pds.Projektnummer = projektnummerNeu;
            pds.PersonObjekt = "alle";
            //
            //  Den Ablageort mit dem Standardwert aus der XML-Datei vor besetzen
            //
            pds.AnlegerName = programmEinstellungen.AnlegerNameStandard;
            //
            //  Mögliche Kategorien (hier Person/Objekt) ermitteln, damit der Datensatz dieser Kategorie zugeordnet werden kann
            //
            List<string> personObjekt = gibPersonenObjekte();
            //
            //  Datensatz für die Dateneingabe im Dialog anzeigen
            //
            DlgProjektDatensatzAnzeige pda = new DlgProjektDatensatzAnzeige(pds, personObjekt, programmEinstellungen);

            DialogResult status;
            status = pda.ShowDialog();
            //
            //  Wird der Dialog mit o. k. verlassen, so wird der zuvor editiert Datensatz in die
            //  Datensatzliste aufgenommen, jedoch noch nicht auf die Platte gespeichert
            //
            if (status == DialogResult.OK)
            {
                ProjektXLSDatenbank.CProjektdatensatz pdsNeu = pda.gibProjektdatensatz();
                projektdaten.addProjekt2List(pdsNeu);
                // 
                // Liste, die zu suchen von Projekten erzeugt wird neu aufbauen
                //
                suchListeErzeugen();
                anzeigenProjekte(CBX_PersonObjekt.Text);
            }
        }

        #endregion // Schaltblächen (Button) 



        ///// <summary>
        ///// Daten aus der Excel-Arbeitsmappe einlesen
        ///// </summary>
        //private void einlesenExceldaten()
        //{



        //  anzeigenEingeleseneXLSDaten();

        //}

        private void anzeigenEingeleseneXLSDaten()
        {
            this.Cursor = Cursors.Default;

            dialogInfoFenster.HideWindow();
            toolStripStatusLabel1.Text = "fertig...";
            //
            // Projekte aufsteigend nach Projektnummer sortieren
            //
            projektdaten.sortiereProjekte(SortierFeld.ProjekNrASC);
            //
            //  Spaltenköpfe aus der Excel Tabelle in die ListView eintragen
            //
            aktualisiereSplatenköpfe();
            //
            //  Projekte auf doppelte und fehlende Projekte hin überprüfen
            //
            püfeProjekte();
            //
            //  Eine Liste erzeugen in der die  Spalten auf der die Suche angewandt wird 
            //  
            //toolStripStatusLabel1.Text = "Suchcontainer erzeugen";
            suchListeErzeugen();

            //toolStripStatusLabel1.Text = "Personen/Obejekt ermitteln";
            //
            //  diese Methode löst ein Change-Item-Ereignis der Combobox CBX_PersonObjekt
            //  aus. Dies hat zur Folgen, das die Projekte automatisch angezeigt werden
            //
            zeigePersonObjekt();

            //toolStripStatusLabel1.Text = "Datensätze anzeigen";
        }

        private void einlesenXLSBackground()
        {
            //  
            //  Projektdaten-Objekt zur Aufnahme der Daten aus der
            //  Arbeitsmappe instanziieren
            //  
            projektdaten = new CProjektDatenListe();

            string excelDatei = programmEinstellungen.XlsFullFilename;

            // toolStripStatusLabel1.Text = "Einlesen der Daten aus " + excelDatei;

            //
            //  Spaltenkopfe, deren Zeilennummer in der Excelarbeitsmappe aus 
            //  den Programmeinstellungen kommt einlesen und in den projektdaten
            //  ablegen
            //
            int arbeitsblatt = 1;
            XLS2Object daten = new XLS2Object(excelDatei, arbeitsblatt);
            List<object[]> spaltenkopfliste;
            spaltenkopfliste = daten.einlesenSpaltenköpfe(programmEinstellungen.ZeilenNrSpaltenköpfe);
            projektdaten.addProjektSpaltenköpfe(spaltenkopfliste[0]);
            //  
            //  Datenbereich, dessen Anfangzeile ebenfalls aus den Prorammeinstelungen
            //  kommt, einlesen.
            //  
            List<object[]> excelDatenListe;
            int ersteSpalteDatenbereich = 1;
            excelDatenListe = daten.einlesenExcelDaten(programmEinstellungen.ErsteZeileDatenbereich, ersteSpalteDatenbereich);

            foreach (object[] o in excelDatenListe)
                projektdaten.addProjekt2List(o);
            //
            //  Daten, insbesondere die Daten für die eingelesenen Spalten merken
            //  damit später beim Wegschreiben der Daten nach Excel ein Objekt-Array
            //  mit der entsprechenden Anzahl an Spalten erzeugt werden kann
            //
            //anzahlEingeleseneXLSSpalten = daten.AnzahlXLSSpalten;
            //anzahlEingeleseneXLSZeilen = daten.AnzahlXLSZeilen;
            //
            //    Datenmatrix in eine Liste überführen
            //

            // toolStripStatusLabel1.Text = "Exceldatenmatrix in Liste überführen...";

            List<object[]> objListe = daten.ObjektListe;
            int zeilen = daten.AnzahlXLSZeilen - 1;
            int spalten = daten.AnzahlXLSSpalten - 1;
            //
            //  Aus der List mit den Objektdaten Projektdaten erzeugen und
            //  in Datenklasse CProjektDatenListe anlegen
            //
            //toolStripStatusLabel1.Text = "Exceldaten in Projekte konvertieren...";
        }





        /// <summary>
        /// Spaltenköpfe, wie sie in der Excel Tabelle angegeben sind werden hier in die Spaltenköpfe
        /// der ListView eingetragen
        /// </summary>
        private void aktualisiereSplatenköpfe()
        {
            List<string> spaltenköpfe = projektdaten.SpaltenkopfListe;

            LBL_PersonObjekt.Text = spaltenköpfe[1];
            LVW_Exceldaten.Columns[1].Text = spaltenköpfe[(int)LVWSpaltenIndex.ProjektNummer];
            LVW_Exceldaten.Columns[2].Text = spaltenköpfe[(int)LVWSpaltenIndex.PersonObjekt];
            LVW_Exceldaten.Columns[3].Text = spaltenköpfe[(int)LVWSpaltenIndex.Sachmerkmal1];
            LVW_Exceldaten.Columns[4].Text = spaltenköpfe[(int)LVWSpaltenIndex.Sachmerkmal2];
            LVW_Exceldaten.Columns[5].Text = spaltenköpfe[(int)LVWSpaltenIndex.Sachmerkmal3];
            LVW_Exceldaten.Columns[6].Text = spaltenköpfe[(int)LVWSpaltenIndex.Anleger];
            LVW_Exceldaten.Columns[7].Text = spaltenköpfe[(int)LVWSpaltenIndex.Anlagedatum];
            LVW_Exceldaten.Columns[8].Text = spaltenköpfe[(int)LVWSpaltenIndex.Archivdatum];
            LVW_Exceldaten.Columns[9].Text = spaltenköpfe[(int)LVWSpaltenIndex.Ablageort];
        }




        /// <summary>
        /// Projekte auf fehlende Projektnummern und auf doppelte Rechnungen hin überprüfen und
        /// der prozentuale Anteil der erledigten Projekte berechnen. Diese Prozentzahl wird später hinter
        /// der Anzahl der erledigten Projekten angezeigt
        /// </summary>
        private void püfeProjekte()
        {
            berechneProjektStatistik();

            fehlendeProjektNummern = projektLücken();

            doppelteprojektnummern = ermittleDoppleteProjektznummern();
        }




        /// <summary>
        /// Berechnung der laufenden und archivierten Projekte und  prozentualen Anteils der erledigten Projekte
        /// </summary>
        private void berechneProjektStatistik()
        {
            int anzahlProjekte = Anzahlprojekte;
            anzahlArchivprojekte = gibAnzahlArchivprojekte();
            anzahlLaufendeProjekte = anzahlProjekte - anzahlArchivprojekte;
            anzalArchivprojekteProzent = Convert.ToDouble(anzahlArchivprojekte) * 100.0 / Convert.ToDouble(anzahlProjekte);
        }




        /// <summary>
        /// Projektliste mit den Projektdatensätzen durchlaufen und ermitteln, welche Projekte archiviert sind
        /// </summary>
        /// <returns></returns>
        private int gibAnzahlArchivprojekte()
        {
            int archivierteProjekte = 0;

            foreach (ProjektXLSDatenbank.CProjektdatensatz pds in projektdaten)
                if (pds.ArchivdatumOk == true)
                    archivierteProjekte++;

            return archivierteProjekte;
        }



        /// <summary>
        /// Liefert als Eigenschaft der Anzahl an Projekten zurück
        /// </summary>
        /// <returns></returns>
        private int Anzahlprojekte
        {
            get { return projektdaten.Count(); }
        }




        /// <summary>
        /// Ermittelt aus der Projektliste (Projektdaten) ob Projektnummern doppelt vergeben wurden
        /// Das Ergebnis wird in einer Liste gespeichert und zurückgegeben.
        /// </summary>
        /// <returns></returns>
        private List<int> ermittleDoppleteProjektznummern()
        {
            List<int> projektnummernListe = new List<int>(10);
            List<int> doppelteProjektnummern = new List<int>(10);

            foreach (ProjektXLSDatenbank.CProjektdatensatz eq in projektdaten)
                projektnummernListe.Add(eq.Projektnummer);


            var duplicateItems = projektnummernListe.GroupBy(x => x)
                                   .Where(g => g.Count() > 1)
                                   .Select(g => g.Key)
                                   .ToList();

            doppelteProjektnummern = duplicateItems.ToList();


            string message = "Projekt-Duplikate: ";
            foreach (int pNr in duplicateItems)
                message += pNr.ToString() + "; ";


            return doppelteProjektnummern;
        }




        /// <summary>
        /// Ermittelt ob zwischen zwei Projekten eine Lücke besteht und liefert die Projektnummer zurück
        /// nach der die Lücke beginnt. Das Ergebnis wird in einer Liste gespeichert und zurückgegeben.
        /// </summary>
        /// <returns></returns>
        private List<int> projektLücken()
        {

            List<int> projektLücke = new List<int>(50);
            int anzahlProjekte = projektdaten.AnzahlProjekte;

            for (int i = 1; i < anzahlProjekte; i++)
            {
                ProjektXLSDatenbank.CProjektdatensatz aktuellesProjekt = projektdaten[i - 1];
                ProjektXLSDatenbank.CProjektdatensatz folgeProjekt = projektdaten[i];

                int projektNummeraktuell = aktuellesProjekt.Projektnummer;
                int projektNummerFolge = folgeProjekt.Projektnummer;

                if ((projektNummerFolge - projektNummeraktuell) > 1)
                    projektLücke.Add(projektNummeraktuell + 1);
            }

            return projektLücke;
        }



        /// <summary>
        /// Erzeugt für jedes Projekt einen String Mit den unten angegebenen Feldern, in dem gesucht werden kann
        /// </summary>
        private void suchListeErzeugen()
        {
            if (suchListe is not null)
            {
                suchListe.Clear();

                foreach (CProjektdatensatz euipment in projektdaten)
                {
                    string suchString = euipment.Projektnummer.ToString();
                    suchString += separator + euipment.PersonObjekt;
                    suchString += separator + euipment.Sachmerkmal1;
                    suchString += separator + euipment.Sachmerkmal2;
                    suchString += separator + euipment.Sachmerkmal3;
                    suchString += separator + euipment.Ablageort;

                    suchListe.Add(suchString);
                }
            }
        }

        private void zeigePersonObjekt()
        {

            personObjektDistinct = gibPersonenObjekte();
            personObjektDistinct.Add("alle");

            personObjektDistinct.Sort();

            CBX_PersonObjekt.Items.Clear();


            foreach (string s in personObjektDistinct)
            {
                CBX_PersonObjekt.Items.Add(s);
            }
            CBX_PersonObjekt.SelectedIndex = 0;

            int index = CBX_PersonObjekt.SelectedIndex;

            int anSpalten = LVW_Exceldaten.Columns.Count;
            //
            LVW_Exceldaten.BeginUpdate();

            //
            //  Spalet 0 ist ausgeblendet
            //
            for (int i = 1; i < anSpalten; i++)
                LVW_Exceldaten.Columns[i].Width = -1;

            LVW_Exceldaten.EndUpdate();
        }






        private List<string> gibPersonenObjekte()
        {
            List<string> personObjektListe = new List<string>();
            List<string> personObjektListeDistinct = new List<string>();


            foreach (ProjektXLSDatenbank.CProjektdatensatz euipment in projektdaten)
            {
                personObjektListe.Add(euipment.PersonObjekt);
            }

            personObjektListeDistinct.Clear();
            personObjektListeDistinct = personObjektListe.Distinct().ToList();
            personObjektListeDistinct.Sort();

            return personObjektListeDistinct;


        }

        private void anpsassenSpaltenbreite()
        {
            int anzahlSpalten = LVW_Exceldaten.Columns.Count;

            for (int i = 1; i < anzahlSpalten; i++)
                LVW_Exceldaten.Columns[i].Width = -1;
        }


        /// <summary>
        /// alle Projekte anzeigen
        /// </summary>
        private void zeigeProjekte()
        {
            LVW_Exceldaten.Items.Clear();

            foreach (ProjektXLSDatenbank.CProjektdatensatz euipment in projektdaten)
            {
                LVW_Exceldaten.Items.Add(createListViewItem(euipment));
            }

            aktualisiereStatistik();

        }


        /// <summary>
        /// Berechnet die Statistik über die erledigten Projekte neu und zeigt diese an
        /// </summary>
        private void aktualisiereStatistik()
        {
            berechneProjektStatistik();
            anzeigenStatistik();
        }



        /// <summary>
        /// Anzeigen der Statistik über die Projekte
        /// </summary>
        private void anzeigenStatistik()
        {
            EDT_AnzahlProjekte.Text = Anzahlprojekte.ToString();
            EDT_LfdProjekte.Text = anzahlLaufendeProjekte.ToString();
            EDT_ArchProjekte.Text = anzahlArchivprojekte.ToString() + " (" + anzalArchivprojekteProzent.ToString("0.0") + "%)";
        }




        /// <summary>
        /// Anzeigen aller Projekte in der ListView
        /// </summary>
        /// <param name="projektnummern"></param>
        private void zeigeProjekte(List<int> projektnummern)
        {
            LVW_Exceldaten.Items.Clear();

            foreach (ProjektXLSDatenbank.CProjektdatensatz euipment in projektdaten)
            {
                if (projektnummern.Contains(euipment.Projektnummer))
                {
                    LVW_Exceldaten.Items.Add(createListViewItem(euipment));
                }
            }
        }



        /// <summary>
        /// Anzeigen von Projekten die  einer bestimmten Kategorie entsprechen
        /// </summary>
        /// <param name="personObjekt"></param>
        private void zeigeProjekte(string personObjekt)
        {
            LVW_Exceldaten.Items.Clear();

            foreach (ProjektXLSDatenbank.CProjektdatensatz euipment in projektdaten)
            {
                if (euipment.PersonObjekt == personObjekt)
                    LVW_Exceldaten.Items.Add(createListViewItem(euipment));
            }

            aktualisiereStatistik();
        }




        /// <summary>
        /// Aus einem Projektdatensatz ein ListViewItem erzeugen um dieses in der
        /// ListView anzeigen zu können
        /// </summary>
        /// <param name="euipment"></param>
        /// <returns></returns>
        private ListViewItem createListViewItem(ProjektXLSDatenbank.CProjektdatensatz euipment)
        {

            ListViewItem item1 = new ListViewItem(euipment.Projektnummer.ToString());
            item1.SubItems.Add(euipment.Projektnummer.ToString());
            item1.SubItems.Add(euipment.PersonObjekt);
            item1.SubItems.Add(euipment.Sachmerkmal1);
            item1.SubItems.Add(euipment.Sachmerkmal2);
            item1.SubItems.Add(euipment.Sachmerkmal3);
            item1.SubItems.Add(euipment.AnlegerName);

            if (euipment.AnlagedatumOk == true)
                item1.SubItems.Add(euipment.Anlagedatum.ToString("dd.MM.yyyy"));
            else
                item1.SubItems.Add("");
            //
            // ist das Datum kleiner als der 01.01.2000, so steht es auf 01.01.1900.
            //  der 01.01.1900 Zeit an, dass das Archivierungdatum in der Excel-Tablle 
            //  nicht vorhanden war, als das Projekt noch nicht archiviert ist 
            //
            if (euipment.ArchivdatumOk == true)
                item1.SubItems.Add(euipment.Archiverungsdatum.ToString("dd.MM.yyyy"));
            else
                item1.SubItems.Add("");

            item1.SubItems.Add(euipment.Ablageort);


            return item1;
        }




        /// <summary>
        /// Die Auswahl in der Combobox hat sich geändert, daher ListView aktualisieren
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CBX_PersonObjekt_SelectedIndexChanged(object sender, EventArgs e)
        {
            EDT_SuchString.Clear();
            BTN_ResetSuchen.PerformClick();

            string? stringnullcheck = CBX_PersonObjekt.SelectedItem.ToString();
            string personObjekt;
            if (stringnullcheck is not null)
            {
                personObjekt = stringnullcheck;

                anzeigenProjekte(personObjekt);


                LVW_Exceldaten.Focus();
            }
        }


        /// <summary>
        /// Anzeigen aller Projekte oder Anzeigen bestimmte Projekte einer Kategorie. Eine Kategorie
        /// "alle" gibt es nicht, diese wird beim einlesen der Kategorien zusätzlich erzeugt, um
        /// die Möglichkeit zu erhalten, alle Projekte anzeigen zu können. Sonst könnte man nur die Projekte
        /// einer vorhandenen Kategorie anzeigen
        /// </summary>
        /// <param name="personObjekt"></param>
        private void anzeigenProjekte(string personObjekt)
        {
            //  
            //  Ist als Personobjekt das (künstlich eingeführte) Sprachwort alle gesetzt
            //  und die Suche (über das Textfeld Suche) nicht aktiviert, so werden alle
            //  Projekte angezeigt. Ist jedoch im Textfeld Suche etwas eingegeben worden und mit
            //  der Schaltfläche "suchen" ausgeführt worden So werden nur die Projekte angezeigt
            //  die die ausgewertet Person/Objekt betreffen
            //  
            if (personObjekt == "alle" && suchenAktiviert == false)
                zeigeProjekte();
            else
                zeigeProjekte(personObjekt);
        }





        /// <summary>
        /// Ein ListView-Eintrag wurde doppelt gecklickt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LVW_Exceldaten_DoubleClick(object sender, EventArgs e)
        {
            //
            //   Projektnummer aus dem angekündigten Datensatz isolieren
            //
            if (LVW_Exceldaten.SelectedItems.Count > 0)
            {
                string projektNummerText = LVW_Exceldaten.SelectedItems[0].SubItems[1].Text;
                int projektNummer = 0;
                bool convertSuccess = false;

                convertSuccess = int.TryParse(projektNummerText, out projektNummer);

                if (convertSuccess == false)
                {
                    ausgebenWarnung("Projektnummer falsch!", "Die Projektnummer ist nicht numerisch! ");
                    return;
                }
                //
                //   Anzeige des Datensatzes zum editieren
                //
                List<string> persObj = gibPersonenObjekte();
                aendereProjektdatensatz(projektNummer, persObj);

                BTN_Suchen.PerformClick();
            }
        }





        /// <summary>
        /// Projektdaten zu einer Projektnummer zum editieren anzeigen. Wird dieser Dialog mit
        /// O. k. beendet, so werden die Daten in der Datensatzliste ersetzt
        /// </summary>
        /// <param name="projektNummer"></param>
        private void aendereProjektdatensatz(int projektNummer, List<string> perObjekt)
        {
            CProjektdatensatz? myPrjDatensatz = null ;
                                             //
                                             //  Projektdaten zu der Projektnummer in der Projektdatenliste suchen und
                                             //  zur Anzeige vorbereiten
                                             //
            foreach (ProjektXLSDatenbank.CProjektdatensatz prjDs in projektdaten)
            if (prjDs.Projektnummer == projektNummer)
                {
                    myPrjDatensatz = prjDs;
                    break;
                }

            if (myPrjDatensatz is null)
                throw new Exception("Projektdatensatz wurd nicht im atenbestand gefunden!");
            //
            //  Anzeige des Projektdatensatzes zum editieren
            //
            DlgProjektDatensatzAnzeige pda = new ProjektXLSDatenbank.DlgProjektDatensatzAnzeige(myPrjDatensatz, perObjekt, programmEinstellungen);

            DialogResult result = pda.ShowDialog();

            CProjektdatensatz projekDatensatzGeändert;// = null;
                                                      //
                                                      //   wird der Dialog mit o. k. beendet,so den Projektdatensatz der soeben editiert wurde als Kopie
                                                      //  Aus dem Dialog holen und diesen Datensatz in der Datensatzliste ersetzen
                                                      //
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                speichernErforderlich = true;
                projekDatensatzGeändert = pda.gibProjektdatensatz();
                ersetzeDatensatz(myPrjDatensatz, projekDatensatzGeändert);

                anzeigenProjekte(CBX_PersonObjekt.Text);
                aktualisiereStatistik();
            }


        }

        /// <summary>
        ///  Einen Datensatz, der in der Projektdatensatzliste vorhanden ist (dies wird über die Projektnummer ermittelt), 
        ///  durch einen neuen Datensatz setzen
        /// </summary>
        /// <param name="projekDatensatzAlt"></param>
        /// <param name="projekDatensatzGeändert"></param>
        private void ersetzeDatensatz(ProjektXLSDatenbank.CProjektdatensatz projekDatensatzAlt, ProjektXLSDatenbank.CProjektdatensatz projekDatensatzGeändert)
        {

            int index = projektdaten.IndexOf(projekDatensatzAlt);
            if (index != -1)
                projektdaten[index] = projekDatensatzGeändert;

        }


        /// <summary>
        /// Ausgeben ein er Warnung an den Benutzer
        /// </summary>
        /// <param name="titel"></param>
        /// <param name="nachricht"></param>
        private void ausgebenWarnung(string titel, string nachricht)
        {
            // Mesagebox wz_msgBox mit Titel und Text parametriert
            //
            MessageBoxButtons button = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Warning;

            string überschrift = titel;
            string meldung = nachricht;

            MessageBox.Show(meldung, überschrift, button, icon);

        }

        /// <summary>
        /// Ausgeben ein er Warnung an den Benutzer
        /// </summary>
        /// <param name="titel"></param>
        /// <param name="nachricht"></param>
        private DialogResult benutzerAntwort(string titel, string nachricht)
        {
            // Mesagebox wz_msgBox mit Titel und Text parametriert
            //
            MessageBoxButtons button = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Stop;

            string überschrift = titel;
            string meldung = nachricht;

            DialogResult result;

            result = MessageBox.Show(meldung, überschrift, button, icon);

            return result;
        }




        /// <summary>
        /// Es wurde Die Schaltfläche zum Suchen von Projekten betätigt. Die Datensatzliste  bzw. die Projektdaten
        /// Der Douglas Liste werden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_Suchen_Click(object sender, EventArgs e)
        {
            string suchText = EDT_SuchString.Text.ToUpper();

   
            string personObjekt="unbekannt";
            object obj = CBX_PersonObjekt.SelectedItem;
            if (obj is not null)
                personObjekt = obj.ToString()!.ToUpper();

            
            suchenAktiviert = true;

           //if (suchProjektnummern is not null)
                
           suchProjektnummern.Clear();

            if (CBX_PersonObjekt.SelectedItem.ToString() == "alle")
            {
                foreach (string prjStr in suchListe)
                {
                    string projektStr = prjStr.ToUpper();
                    if (projektStr.IndexOf(suchText.ToUpper()) > -1)
                        suchProjektnummern.Add(selektiereProjektnummer(projektStr));
                }
            }
            else
            {
                foreach (string prjStr in suchListe)
                {
                    string projektStr = prjStr.ToUpper();
                    if (projektStr.IndexOf(suchText) > -1 && projektStr.IndexOf(personObjekt) > -1)
                        suchProjektnummern.Add(selektiereProjektnummer(projektStr));
                }
            }

            zeigeProjekte(suchProjektnummern);
        }

        private int selektiereProjektnummer(string projektStr)
        {
            string[] items = projektStr.Split(separator);
            return Convert.ToInt32(items[0]);
        }

        private void BTN_ResetSuchen_Click(object sender, EventArgs e)
        {

            //CBX_PersonObjekt.SelectedIndex = CBX_PersonObjekt.Items.IndexOf("alle");
            EDT_SuchString.Clear();
            suchenAktiviert = false;
            anzeigenProjekte(CBX_PersonObjekt.Text);
        }

        private void EDT_SuchString_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BTN_Suchen.PerformClick();
            }
        }

        private void BTN_ProjektInfo_Click(object sender, EventArgs e)
        {
            CProjektInkonsitenzen prjInfo = new CProjektInkonsitenzen(doppelteprojektnummern, fehlendeProjektNummern);
            prjInfo.StartPosition = FormStartPosition.CenterParent;
            prjInfo.ShowDialog();
        }



        private void BTN_Abbruch_Click(object sender, EventArgs e)
        {

            //
            //  Wurde der Datenbestand geändert, so muss der Benutzer entscheiden
            //  ob die Daten gespeichert werden sollen oder nicht
            //
            if (speichernErforderlich == true)
            {
                DialogResult status;

                status = benutzerAntwort("Der Datenbestand wurde geändert!", "Soll der Datenbestand nun gespeichert werden?");
                if (status == DialogResult.Yes)
                {
                    BTN_Ok.PerformClick();
                    return;
                }
            }

            this.Close();

        }


        private void LVW_Exceldaten_ColumnClick(object sender, ColumnClickEventArgs e)
        {

        }

        private void excelThread_DoWork(object sender, DoWorkEventArgs e)
        {
            mydelegate();

        }

        private void excelThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled 
                // the operation.
                // Note that due to a race condition in 
                // the DoWork event handler, the Cancelled
                // flag may not have been set, even though
                // CancelAsync was called.
                //toolStripStatusLabel1.Text = "Operation wurde durch einen Fehler abgebrochen!";

            }
            else
            {
                // Finally, handle the case where the operation 
                // succeeded.
                //toolStripStatusLabel1.Text = e.Result.ToString();
            }


            anzeigenEingeleseneXLSDaten();
            //zeigePersonObjekt();

            //toolStripStatusLabel1.Text = "Daten wurden erfolgreich geladen!";

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //
            //  Die wiederherstellung des Cursors erfolgt in de Methode : anzeigenEingeleseneXLSDaten
            //
            string messagetext = "Daten werden aus der Exceltabelle gelesen ...";
            toolStripStatusLabel1.Text = messagetext;

            dialogInfoFenster.ShowWindow(messagetext);
            mydelegate = einlesenXLSBackground;

            if (excelThread.IsBusy != true)
                excelThread.RunWorkerAsync();

        }

        private void excelThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

    }
}