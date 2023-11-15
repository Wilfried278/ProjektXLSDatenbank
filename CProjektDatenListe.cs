using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ProjektXLSDatenbank
{
    public class CProjektDatenListe : IEnumerable<CProjektdatensatz>
    {
        #region Datenelemente

        /// <summary>
        ///  generische Liste für die Projektdatensätze
        /// </summary>
        List<CProjektdatensatz> projektListe;

        /// <summary>
        ///  generische Liste für die Spaltenköpfe
        /// </summary>
        List<string> spaltenköpfe;

        /// <summary>
        /// Generische Liste für die aufgetretenen Fehler innerhalb der Verarbeitung
        /// </summary>
        List<string> fehlerListe = new List<string>(10);


        #endregion // Datenelemente 

        #region Konstruktion

        /// <summary>
        ///  Konstruktor und Initialisierung der Generische Liste für Projekte und für Spaltenköpfe
        /// </summary>
        public CProjektDatenListe()
        {
            projektListe = new List<CProjektdatensatz>(500);
            spaltenköpfe = new List<string>(10);
        }

        #endregion // Konstruktion

        #region Eigenschaften

        /// <summary>
        /// Stellt eine Kopie der Liste mit den Spaltenköpfen bereit
        /// </summary>
        public List<string> SpaltenkopfListe
        {
            get
            {
                List<string> kopie = new List<string>(spaltenköpfe);
                return kopie;

            }
        }

        /// <summary>
        /// Liefert die Anzahl der eingelesen Projekte zurück
        /// </summary>
        public int AnzahlProjekte
        {
            get { return projektListe.Count(); }
        }


        #endregion // Eigenschaften 

        #region Methoden

        #region Methoden privat 

        /// <summary>
        /// Ersatz der null -Werte durch leere Zeichenketten, um Probleme bei der Konvertierung
        /// Insbesondere beim Datum zu vermeiden
        /// </summary>
        /// <param name="excelZeile"></param>
        /// <returns>Objekt-Array</returns>
        private object[] checkForNull(object[] excelZeile)
        {
            object[] objOhneNullwerte = new object[excelZeile.Length];

            for (int i = 0; i < excelZeile.Length; i++)
                if (excelZeile[i] == null)
                    objOhneNullwerte[i] = "";
                else
                    objOhneNullwerte[i] = excelZeile[i];

            return objOhneNullwerte;

        }

        /// <summary>
        /// Bereitstellen einer Methode die den Vergleich zweier Objekte zur Sortierung der Elemete durchführt
        /// </summary>
        /// <param name="a">Objekt 1</param>
        /// <param name="b">Objekt 2</param>
        /// <returns>-1/0/+1 je nach Vergleich</returns>
        private int SortProjektnummerAufsteigend(ProjektXLSDatenbank.CProjektdatensatz a, ProjektXLSDatenbank.CProjektdatensatz b)
        {
            if (a.Projektnummer < b.Projektnummer) return -1;
            if (a.Projektnummer > b.Projektnummer) return 1;
            return 0;
        }

        /// <summary>
        /// Bereitstellen einer Methode die den Vergleich zweier Objekte zur Sortierung der Elemete durchführt
        /// </summary>
        /// <param name="a">Objekt 1</param>
        /// <param name="b">Objekt 2</param>
        /// <returns>-1/0/+1 je nach Vergleich</returns>
        private static int SortProjektnummerAbsteigend(ProjektXLSDatenbank.CProjektdatensatz a, ProjektXLSDatenbank.CProjektdatensatz b)
        {
            if (a.Projektnummer > b.Projektnummer) return -1;
            if (a.Projektnummer < b.Projektnummer) return 1;
            return 0;
        }

        /// <summary>
        /// Bereitstellen einer Methode die den Vergleich zweier Objekte zur Sortierung der Elemete durchführt
        /// </summary>
        /// <param name="a">Objekt 1</param>
        /// <param name="b">Objekt 2</param>
        /// <returns>-1/0/+1 je nach Vergleich</returns>
        private static int SortAnlagedatumAufsteigend(ProjektXLSDatenbank.CProjektdatensatz a, ProjektXLSDatenbank.CProjektdatensatz b)
        {
            if (a.Anlagedatum > b.Anlagedatum) return 1;
            if (a.Anlagedatum < b.Anlagedatum) return -1;
            return 0;
        }

        /// <summary>
        /// Bereitstellen einer Methode die den Vergleich zweier Objekte zur Sortierung der Elemete durchführt
        /// </summary>
        /// <param name="a">Objekt 1</param>
        /// <param name="b">Objekt 2</param>
        /// <returns>-1/0/+1 je nach Vergleich</returns>
        private void Sort2(ProjektXLSDatenbank.CProjektdatensatz a, ProjektXLSDatenbank.CProjektdatensatz b)
        {

        }

        /// <summary>
        /// Liefert die letzte (numerisch größte) Projektnummer
        /// </summary>
        /// <returns>numerisch größte Projektnummer</returns>
        public int maxPojektNummer()
        {
            int max = -1;
            foreach (ProjektXLSDatenbank.CProjektdatensatz pds in projektListe)
            {
                int prjNraktuell = pds.Projektnummer;
                max = prjNraktuell > max ? prjNraktuell : max;
            }

            return max;

        }


        #endregion // Methoden privat 

        #region Methoden öffentlich

        /// <summary>
        /// Erzeugt aus einer Zeile aus der Exceltabelle (Datetyp 'Object') eine
        /// Liste vomn Type 'Object'
        /// </summary>
        /// <param name="excelZeile">Zeile aus der Exceltabelle</param>
        public void addProjektSpaltenköpfe(object[] excelZeile)
        {
            //spaltenköpfe = new List<string>(2);

            excelZeile = checkForNull(excelZeile);

            foreach (object o in excelZeile)
                spaltenköpfe.Add(o.ToString());
        }

        /// <summary>
        /// Einfügen eines Projektdatensatzes in die Liste (generische) mit allen
        /// Projektdatensätzen
        /// </summary>
        /// <param name="pdsNeu">Ein Projektdatensatz</param>
        public void addProjekt2List(CProjektdatensatz pdsNeu)
        {
            projektListe.Add(pdsNeu);
        }

        /// <summary>
        /// Erzeugt aus einer eingelesenen Zeile der Excel-Arbeitsmappe einen Projektdatensatz
        /// und legt diesen in die generische Liste ab.
        /// </summary>
        /// <param name="excelZeile">Eine Zeile aus der Excel-Arbeitsmappe</param>
        /// <returns>Anzahl der Elemente in der Liste</returns>
        public int addProjekt2List(object[] excelZeile)
        {
            if (excelZeile is null)
                return projektListe.Count;

            ProjektXLSDatenbank.CProjektdatensatz prjDatensatz = new ProjektXLSDatenbank.CProjektdatensatz();

            try
            {
                // Nullwerte gehen Leerzeichenketten ersetzen um Problemen bei der
                //  Datum-Konvertierung zu vermeiden
                //
                excelZeile = checkForNull(excelZeile);
                //
                if (excelZeile is not null)
                {
                    prjDatensatz.Projektnummer = Convert.ToInt32(excelZeile[0]);
                    prjDatensatz.PersonObjekt = excelZeile[1].ToString() ?? ""; // myObj ?? String.Empty).ToString();
                    prjDatensatz.Sachmerkmal1 = excelZeile[2].ToString() ?? "";
                    prjDatensatz.Sachmerkmal2 = excelZeile[3].ToString() ?? ""; 
                    prjDatensatz.Sachmerkmal3 = excelZeile[4].ToString() ?? "";
                }

                bool check;
                DateTime datum = new DateTime();

                string excelListenDatum = (excelZeile[5].ToString() ?? String.Empty).ToString();

                check = DateTime.TryParse(excelListenDatum, out datum);

                if (check == false)
                    prjDatensatz.AnlagedatumOk = false;
                else
                {
                    prjDatensatz.AnlagedatumOk = true;
                    prjDatensatz.Anlagedatum = datum;
                }
                prjDatensatz.AnlegerName = excelZeile[6].ToString() ?? "Anleger unbekannt";


                check = DateTime.TryParse(excelZeile[7].ToString(), out datum);

                if (check == false)
                    prjDatensatz.ArchivdatumOk = false;
                else
                {
                    //Archiverungsdatum = DateTime.FromOADate(Convert.ToDouble(excelZeile[7]));
                    prjDatensatz.Archiverungsdatum = datum;
                    prjDatensatz.ArchivdatumOk = true;
                }

                prjDatensatz.Ablageort = excelZeile[8].ToString() ??  "";
                //
                //  projekt in projektliste ablegen
                //
                projektListe.Add(prjDatensatz);

                return projektListe.Count;
            }
            catch (Exception)
            {
                string message = "";
                for (int i = 0; i < excelZeile.Length; i++)
                    message += excelZeile[i] + ";";
                fehlerListe.Add(message);

                return projektListe.Count;

                //throw new Exception("Fehler beim Anlegen des Projektes!");
            }
        }
        /// <summary>
        /// Iterator zum Durchlaufen der Aufzählung 'projektListe'
        /// </summary>
        /// <returns>Enumerator</returns>
        public IEnumerator<CProjektdatensatz> GetEnumerator()
        {
            return projektListe.GetEnumerator();

        }

        /// <summary>
        /// Implementiert den Enumrator zum Durchlaufen der Aufzählung 'projektListe' 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return projektListe.GetEnumerator();
        }

        /// <summary>
        /// Liefert einen Projektdatensatz aus der generischen Liste zurück der über einen Index
        /// identifiziert wird
        /// </summary>
        /// <param name="i">Index des Listeneintrages</param>
        /// <returns>Objekt vom Typ CProjektdatensatz</returns>
        public CProjektdatensatz this[int i]
        {
            get { return projektListe[i]; }
            set { projektListe[i] = value; }
        }

        /// <summary>
        /// Liefert den Index eines Elemnets mit einer Projektnummer
        /// </summary>
        /// <param name="p"></param>
        /// <returns>Index des gesuchten Datensatzes (-1 wenn nicht vorhanden)</returns>
        public int IndexOf(ProjektXLSDatenbank.CProjektdatensatz p)
        {
            for (int i = 0; i < projektListe.Count; i++)
                if (projektListe[i].Projektnummer == p.Projektnummer)
                    return i;

            return -1;
        }

        /// <summary>
        /// Führt die Sortierung der generischen Liste durch
        /// </summary>
        /// <param name="sortOption">Aufzählung der Sortieroptionen</param>
        public void sortiereProjekte(SortierFeld sortOption)
        {

            switch (sortOption)
            {
                case SortierFeld.AnlagdatumProjektASC:
                    projektListe = (List<ProjektXLSDatenbank.CProjektdatensatz>)projektListe.OrderBy(a => a.Anlagedatum).ThenBy(b => b.Projektnummer).ToList();
                    break;
                case SortierFeld.AnlagdatumProjektDES:
                    projektListe = (List<ProjektXLSDatenbank.CProjektdatensatz>)projektListe.OrderByDescending(a => a.Anlagedatum).ThenBy(b => b.Projektnummer).ToList();
                    break;
                case SortierFeld.ProjekNrASC:
                    projektListe.Sort(SortProjektnummerAufsteigend);
                    break;
                case SortierFeld.ProjekNrDES:
                    projektListe.Sort(SortProjektnummerAbsteigend);
                    break;
                default:
                    break;
            }
        }

        #endregion // Methoden öffentlich

        #endregion // Methoden 
    }
}


