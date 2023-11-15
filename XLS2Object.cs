

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Threading;

using Microsoft.Win32.SafeHandles;

using Microsoft.Office.Interop.Excel;
using ExcelApp = Microsoft.Office.Interop.Excel;
//using ExcelTools = Microsoft.Office.Tools.Excel;

using System.Runtime.InteropServices;
using xlsRange = Microsoft.Office.Interop.Excel.Range;

/*
 * Merke:   ExcelApplication immer als var deklarieren  (geht nur in Methoden)
 *          Starten und schliessen der Excelapplication immer in ein und der gleichen Methode
 * 

*/

namespace ProjektXLSDatenbank
{
    /// <summary>
    /// Diese Klasse liest die erste Tabelle einer Excel-Arbeitsmappe ein und liefert ein Array
    /// vom Typ object zurück. Informationen über die Anzahl eingelesenen Spalten und Zeilen
    /// werden in den Eigenschaften zur Verfügung gestellt    .
    /// </summary>
    public class XLS2Object
    {
        #region Datenelemente

        /// <summary>
        /// Arbeitsmappe mit den Equipmentnummern
        /// </summary>
        private string excelDateinameArbeitsMappe;
        /// <summary>
        /// Arbeitsblattnummer die geöffnet werden soll
        /// </summary>
        private int excelArbeitsblattNummer = -1;
        /// <summary>
        /// alle eingelesenen Zelleninhalte
        /// </summary>
        object[,] ExcelZellenInhalte;
        /// <summary>
        /// Liste aller Excelobjekte (Zeilen in der Exceltabelle)
        /// </summary>
        List<object[]> objektListe;
        /// <summary>
        /// Anzahl der Zeilen in der Tabelle einer Arbeitsmappe
        /// </summary>
        int anzXLSZeilen = -1;
        /// <summary>
        /// Anzahl der Spalten in der Tabelle eine Arbeitsmappe
        /// </summary>
        int anzXLSSpalten = -1;
        /// <summary>
        /// Zeile ab der die Tabelle eingelesen wird 
        /// (diese wird in initialisiereDatenelemente() initialisiert)
        /// </summary>
        int startZeile = -1;
        /// <summary>
        /// Spalte ab der die Tabelle eingelesen wird 
        /// (diese wird in initialisiereDatenelemente() initialisiert)
        /// </summary>
        int startSpalte = -1;
        #endregion // Datenelemente 

        #region Konstruktion

        /// <summary>
        /// Kontruktion mit Einlesen der ExcelDaten
        /// </summary>
        /// <param name="excelDateinameArbeitsMappe"></param>
        public XLS2Object(string excelDateinameArbeitsMappe, int arbeitsblattNummer)
        {
            ExcelZellenInhalte = new Object[0,0];
            objektListe = new List<object[]>(0);

            this.excelDateinameArbeitsMappe = excelDateinameArbeitsMappe;
            this.excelArbeitsblattNummer = arbeitsblattNummer;
            initialisiereDatenelemente();
        }

        #endregion // Konstruktion

        #region Initialisierung

        /// <summary>
        /// Initialisierung der internen Datenelemete
        /// </summary>
        private void initialisiereDatenelemente()
        {
            //  Starte-Zeile und Spalte für den Lesebeginn definieren
            //
            startZeile = 1;
            startSpalte = 1;

            objektListe = new List<object[]>(500);
        }

        #endregion // Initialisierung 

        #region Eigenschaften

        public List<object[]> ObjektListe
        {
            get { return objektListe; }
        }


        public int AnzahlXLSSpalten
        {
            get { return anzXLSSpalten; }
            set { anzXLSSpalten = value; }
        }

        public int AnzahlXLSZeilen
        {
            get { return anzXLSZeilen; }
            set { anzXLSZeilen = value; }
        }


        #endregion // Eigenschaften 

        #region Methoden

        #region Methoden privat 

        /// <summary>
        /// Überträgt die Inhalt der Excelzellen einer Zeile in ein Array
        /// vom Typ Objekt und legt dieses Array in einer Liste vom Typ
        /// Object ab
        /// </summary>
        private List<object[]> convert2ListNeu(object[,] objArray)
        {
            int anzZeilen = objArray.GetLength(0);
            int anzSpalten = objArray.GetUpperBound(1);

            List<object[]> objListe = new List<object[]>(anzZeilen);
            //  
            //  22.05.2019  07:05:25 (W.Zilger)
            //  AnzahlXLSZeilen und AnzahlXLSSpalten werden in der Methode
            //  einlesenExcelDatenbereich(...) berechnet
            //
            for (int i = 0; i < anzZeilen; i++)
            {
                object[] a = new object[anzSpalten];
                for (int j = 0; j < anzSpalten; j++)
                {
                    a[j] = objArray[i + 1, j + 1];

                }
                objListe.Add(a);
            }

            return objListe;
        }

        /// <summary>
        /// Überträgt die Inhalt der Excelzellen einer Zeile in ein Array
        /// vom Typ Objekt und legt dieses Array in einer Liste vom Typ
        /// Object ab
        /// </summary>
        private void convert2List()
        {
            //  
            //  22.05.2019  07:05:25 (W.Zilger)
            //  AnzahlXLSZeilen und AnzahlXLSSpalten werden in der Methode
            //  einlesenExcelDatenbereich(...) berechnet
            //
            for (int i = 0; i < AnzahlXLSZeilen; i++)
            {
                object[] a = new object[AnzahlXLSSpalten];
                for (int j = 0; j < AnzahlXLSSpalten; j++)
                {
                    a[j] = ExcelZellenInhalte[i + 1, j + 1];

                }
                objektListe.Add(a);
            }
        }

        /// <summary>
        /// Einlesen des Datenbereiches 
        /// </summary>
        /// <param name="startzeile"></param>
        /// <param name="startSpalte"></param>
        /// <returns></returns>
        private object[,] einlesenExcelDatenbereich(int startzeile, int startSpalte)
        {
            //  
            //  Excel-Anwendung öffnen. Wichtog ist hierbei das der Datentyp variant (var) verwendet wird.
            //  
            var myExcel = new ExcelApp.Application();
            ExcelApp.Workbooks myWorkbooks = myExcel.Workbooks;
            ExcelApp.Workbook myWorkbook = myWorkbooks.Open(excelDateinameArbeitsMappe, Type.Missing, true, Type.Missing, Type.Missing,
                                                                  Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                                  Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            ExcelApp.Worksheet arbeitsblatt = (ExcelApp.Worksheet)myWorkbook.Sheets[excelArbeitsblattNummer];
            //
            //  Benutzen Zellenbereich ermitteln und Datenbereich einlesen
            //
            xlsRange usedRange = arbeitsblatt.UsedRange;
            int letzteZeile = usedRange.Rows.Count;
            int letzteSpalte = usedRange.Columns.Count;

            xlsRange? datenBereich = null;
            object[,] datenmatrix = new object[0,0];
            try
            {
                //
                //  Berechnung vorhandene Zeilen für den Datenbereich
                //
                int startZeileDatenbereich = startzeile;
                int endZeileDatenbereich = letzteZeile;
                int startSpalteDatenbereich = startSpalte;
                int endSpalteDatenbereich = letzteSpalte;
                ////  
                ////  --- 22.05.2019 07:46:33 (W.Zilger) --- 
                //// AnzahlXLSZeilen und AnzahlXLSSpalten zuweisung über Eigenschaft  
                //// 
                //AnzahlXLSZeilen = endZeileDatenbereich - startZeileDatenbereich + 1;
                //AnzahlXLSSpalten = startSpalteDatenbereich + letzteSpalte - 1;
                //
                // Achtung: dieses Aray startet bei eins und nicht bei null! 
                //
                int matrixIndexX = letzteSpalte - startSpalte + 1;
                int matrixIndexY = letzteZeile - startZeile;

                datenmatrix = new object[matrixIndexX, matrixIndexY];
                //  
                //  Datenbereich (Range) zum Einlesen der Daten definieren
                //  
                datenBereich = arbeitsblatt.Range[arbeitsblatt.Cells[startZeileDatenbereich, startSpalteDatenbereich], arbeitsblatt.Cells[endZeileDatenbereich, endSpalteDatenbereich]];
                //  
                //  Einlesen des Darebereichs
                //  
                datenmatrix = datenBereich.Value;
                myExcel.Quit();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, e1.Source!.ToString()); 
            }

           return datenmatrix;
        }

        /// <summary>
        /// Konvertiert die Projektdatensätze in Datenarrays vom Typ object als
        /// Vorfbereitung zuj speuchrn der Daten in die Excel-ARbeotsmappe
        /// </summary>
        /// <param name="projektdaten">Liste der Projektdatensätze</param>
        /// <param name="zeilen">Anzahl Zeilen, die es zu konvertieren gilt</param>
        /// <param name="spalten">Anzahl Spalten, die es zu konvertieren gilt</param>
        /// <returns>Ibject-Arrray mit den Daten</returns>
        private object[,] convert2objDaten(CProjektDatenListe projektdaten, int zeilen, int spalten)
        {


            object[,] objDaten = new object[zeilen, spalten];


            for (int i = 0; i < zeilen; i++)
            {
                ProjektXLSDatenbank.CProjektdatensatz pds = projektdaten[i];

                objDaten[i, 0] = pds.Projektnummer.ToString();
                objDaten[i, 1] = pds.PersonObjekt;
                objDaten[i, 2] = pds.Sachmerkmal1;
                objDaten[i, 3] = pds.Sachmerkmal2;
                objDaten[i, 4] = pds.Sachmerkmal3;
                objDaten[i, 5] = pds.Anlagedatum.ToShortDateString();
                objDaten[i, 6] = pds.AnlegerName;

                if (pds.ArchivdatumOk == false)
                    objDaten[i, 7] = "";
                else
                    objDaten[i, 7] = pds.Archiverungsdatum.ToShortDateString();

                objDaten[i, 8] = pds.Ablageort;
            }

            return objDaten;

        }

        #endregion // Methoden privat 

        #region Methoden öffentlich
        /// <summary>
        /// Einlesen eines Datenbereiches aus einer Excel-Arbeitsmappe, beginnend mit der 
        /// StartZeile und endent mit der letzten Zeile des Arbeitsblattes aus dem Bereiche
        /// 'UsedRange'. Hierbei ist zu beachten dass die Eigenschaft UsedRange den Zellenbereich
        /// Liefert bis zu der Zelle, die, auch wenn sie keinen Inhalt hat, bereits zuvor einmal 
        /// beschrieben wurde!
        /// </summary>
        /// <param name="startZeile">Zeile (incl.) ab der der Einlesevorgang startet</param>
        /// <param name="startSpalte">Spalte (incl.) ab der der Einlesevorgang startet</param>
        /// <returns>Array vom Typ Object</returns>
        public List<object[]> einlesenExcelDaten(int startZeile, int startSpalte)
        {
            //  
            //  Stellt eine Array mit den Werten eine Zeile dar
            //  
            object[,]? objektArray = null;
            //  
            //  Stellt eine Liste mit allen Zeilen einer Excelarbeitsmappe dar
            //  
            List<object[]>? objectListe = null;
            objektArray = einlesenExcelDatenbereich(startZeile, startSpalte);
            objectListe = convert2ListNeu(objektArray);
            return objectListe;
        }

        /// <summary>
        /// Einlesen der Spaltenköpfe aus der angegeben Zeile 'zeileNr'
        /// </summary>
        /// <param name="zeileNr">Nummer der Zeile im Arbeitsblatt, in der sich die Spaltenköpfe befinden</param>
        /// <returns></returns>
        public List<object[]> einlesenSpaltenköpfe(int zeileNr)
        {
            //  
            //  Stellt eine Array mit den Werten eine Zeile dar
            //  
            object[,]? objektArray = null;
            //  
            //  Stllet eine Liste mit allen Zeilen einer Excelarbeitsmappe dar
            //  
            List<object[]>? objectListe = null;
            //
            int startSpalte = 1;
            objektArray = einlesenExcelDatenbereich(zeileNr, startSpalte);
            objectListe = convert2ListNeu(objektArray);
            return objectListe;
        }

        /// <summary>
        /// Speichern der Daten aus der Klasse CProjektDatenListe in die Excel-Arbeitsmappe
        /// </summary>
        /// <param name="projektdaten">Daten aus der Klasse CProjektDatenListe</param>
        /// <param name="anzahlEingeleseneXLSSpalten">Anzahl der Spalten aus dem Einlesenvorgang </param>
        /// <param name="xlsDateiname">Datei unte dem die Arbeitsmappe abgespeichert wird</param>
        /// <param name="startZeileDatenbereich">Ab dieser Zeule wird die Arbeitsmappe beschrieben</param>
        public void speichernExcelDaten(CProjektDatenListe projektdaten, int anzahlEingeleseneXLSSpalten, string xlsDateiname, int startZeileDatenbereich)
        {
            //  
            //  Excel-Anwendung öffnen. Wichtog ist hierbei das der Datentyp variant (var) verwendet wird.
            //  
            var myExcel = new ExcelApp.Application();
            myExcel.DisplayAlerts = false;
            ExcelApp.Workbooks myWorkbooks = myExcel.Workbooks;
            ExcelApp.Workbook myWorkbook = myWorkbooks.Open(excelDateinameArbeitsMappe, Type.Missing, false, Type.Missing, Type.Missing,
                                                                  Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                                  Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            ExcelApp.Worksheet arbeitsblatt = (ExcelApp.Worksheet)myWorkbook.Sheets[excelArbeitsblattNummer];
            //
            //  Benutzen Zellenbereich ermitteln und Datenbereich einlesen
            //
            object[,]? objDaten = null;
            int anzahlProjekte = projektdaten.Count();
            int anzahlSpalten = anzahlEingeleseneXLSSpalten;

            objDaten = convert2objDaten(projektdaten, anzahlProjekte, anzahlSpalten);




            object missing = Type.Missing;
            try
            {
                int xlsStartZeile = startZeileDatenbereich; // Spaltenkopf nicht überschreiben
                int xlsEndZeile = xlsStartZeile + anzahlProjekte - 1;

                xlsRange datenBereich = arbeitsblatt.Range[arbeitsblatt.Cells[xlsStartZeile, 1], arbeitsblatt.Cells[xlsEndZeile, anzahlSpalten]];
                datenBereich.Value2 = objDaten;
                myWorkbook.SaveAs(xlsDateiname);
                myWorkbook.Close(true, missing, missing);
                //
                //  Da das Objekt zerstört wird, führt excel.Quit() Sehr wahrscheinlich zu einer Fehlermeldung " Excel funktioniert nicht mehr"
                //  Deshalb wird hier auf die Beendigung bzw. auf quit verzichtet!
                myExcel.Quit();
            }
            catch (Exception e1)
            {
                string message = "Fehler in Methode speichernExcelDaten(...)";
                MessageBox.Show(message, e1.Source!.ToString());
                #region")
            }

        }

        #endregion // Methoden öffentlich

    #endregion // Methoden 

    }
    #endregion // 
}
