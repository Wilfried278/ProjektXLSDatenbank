using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ProjektXLSDatenbank
{
    /// <summary>
    /// Dies Klasse repräsentiert einen Projektdatensatz
    /// </summary>
    public class CProjektdatensatz : IComparable<CProjektdatensatz>
    {
        #region Datenelemente

        /// <summary>
        /// Projektnummer
        /// </summary>
        private int projektnummer;

        /// <summary>
        /// Person oder Objektbezeichnung
        /// </summary>
        private string personObjekt;


        /// <summary>
        /// Sachmerkmal 1
        /// </summary>
        private string sachmerkmal1;

        /// <summary>
        /// Sachmerkmal 2
        /// </summary>
        private string sachmerkmal2;

        /// <summary>
        /// Sachmerkmal 3
        /// </summary>
        private string sachmerkmal3;

        /// <summary>
        /// Anlagendatum
        /// </summary>
        private DateTime anlagedatum;

        /// <summary>
        /// AnlegerName
        /// </summary>
        private string anlegerName;

        /// <summary>
        /// Archiverungsdatum
        /// </summary>
        private DateTime archivDatum;

        /// <summary>
        /// Ablageort
        /// </summary>
        private string ablageort;
        /// <summary>
        /// Zeigt an, ob das Anlagedatum ein gültiges Datum ist. Wenn in der Excel-Arbeitsmappe
        /// Kein Datum eingetragen ist so hat  die variable Anlagedatumn den Wert null
        /// </summary>
        private bool anlagedatumOk;

        /// <summary>
        /// Zeigt an, ob das Archivdatum ein gültiges Datum ist. Wenn in der Excel-Arbeitsmappe
        /// kein Datum eingetragen ist, wenn das Projekt also nicht archiviert ist, so hat  
        /// die variable Archivdatum den Wert null
        /// </summary>
        private bool archivdatumOk;
        #endregion // Datenelemente 

        #region Konstruktion

        /// <summary>
        /// Standardkontruktor
        /// </summary>
        public CProjektdatensatz()
        {
            projektnummer = -1;
            personObjekt    = String.Empty;
            sachmerkmal1    = String.Empty;
            sachmerkmal2    = String.Empty;
            sachmerkmal3    = String.Empty;
            anlagedatum     = DateTime.MinValue;
            archivDatum     = DateTime.MinValue;    
            ablageort       = String.Empty;
            anlagedatum     = DateTime.MinValue; 
            archivDatum     = DateTime.MinValue;



        }

        /// <summary>
        /// Aus dem übergebene Straing Array die Spalten in separate Felder packen
        /// </summary>
        /// <param name="excelZeile"></param>
        public CProjektdatensatz(string[] excelZeile)
        {
            splittArray(excelZeile);
        }

        #endregion // Konstruktion

        #region Eigenschaften

        /// <summary>
        /// Setzte die Projektnummer oder liefert diese zurück
        /// </summary>
        public int Projektnummer
        {
            get { return projektnummer; }
            set { projektnummer = value; }
        }

        /// <summary>
        /// Setzt das erste Sachmerkmal oder liefert dieses zurück
        /// </summary>
        public string Sachmerkmal1
        {
            get { return sachmerkmal1; }
            set { sachmerkmal1 = value; }
        }

        /// <summary>
        /// Setzt das zweite Sachmerkmal oder liefert dieses zurück
        /// </summary>
        public string Sachmerkmal2
        {
            get { return sachmerkmal2; }
            set { sachmerkmal2 = value; }
        }

        /// <summary>
        /// Setzt das dritte Sachmerkmal oder liefert dieses zurück
        /// </summary>
        public string Sachmerkmal3
        {
            get { return sachmerkmal3; }
            set { sachmerkmal3 = value; }
        }

        /// <summary>
        /// Setzt das Anlagedatum oder liefert diese zurück
        /// </summary>
        public DateTime Anlagedatum
        {
            get { return anlagedatum; }
            set { anlagedatum = value; }
        }

        /// <summary>
        /// Setzt den Anlegernamen oder liefert diesen zurück
        /// </summary>
        public string AnlegerName
        {
            get { return anlegerName; }
            set { anlegerName = value; }
        }

        /// <summary>
        /// Setzt das Archivierungsdatum oder liefert dieses zurück
        /// </summary>
        public DateTime Archiverungsdatum
        {
            get { return archivDatum; }
            set { archivDatum = value; }
        }

        /// <summary>
        /// Setzt den Ablageort oder liefert diesen zurück
        /// </summary>
        public string Ablageort
        {
            get { return ablageort; }
            set { ablageort = value; }
        }

        /// <summary>
        /// Setzt die PersonObjekt (bzw. die Kategorie) oder liefert diese zurück
        /// </summary>
        public string PersonObjekt
        {
            get { return personObjekt; }
            set { personObjekt = value; }
        }

        /// <summary>
        /// Setzt die Aussage, ob das Archivdatum in Ordnung ist oder liefert diese zurück
        /// </summary>
        public bool ArchivdatumOk
        {
            get { return archivdatumOk; }
            set { archivdatumOk = value; }
        }

        /// <summary>
        /// Setzt die Aussage, ob das Anlagedatum In Ordnung ist oder liefert diese zurück
        /// </summary>
        public bool AnlagedatumOk
        {
            get { return anlagedatumOk; }
            set { anlagedatumOk = value; }
        }
        #endregion // Eigenschaften 

        #region Methoden

        #region Methoden privat 

        /// <summary>
        ///  aus einer Zeile die als String-Array aus Excel kommt, die einzelnen Zellenwerte extrahieren
        ///  und über die Eigenschaften in das eigene Objekt speichern.
        /// </summary>
        /// <param name="excelZeile"></param>
        private void splittArray(string[] excelZeile)
        {
            try
            {
                Projektnummer = Convert.ToInt32(excelZeile[0]);
                PersonObjekt = excelZeile[1];
                Sachmerkmal1 = excelZeile[2];
                Sachmerkmal2 = excelZeile[3];
                Sachmerkmal3 = excelZeile[4];

                bool check;
                DateTime datum = new DateTime();

                check = DateTime.TryParse(excelZeile[5], out datum);

                if (check == false)
                {
                    anlagedatumOk = false;
                }
                else
                {
                    Anlagedatum = datum;
                    anlagedatumOk = true;
                }

                AnlegerName = excelZeile[6];

                check = DateTime.TryParse(excelZeile[7], out datum);

                if (check == false)
                {
                    archivdatumOk = false;
                }
                else
                {
                    //Archiverungsdatum = DateTime.FromOADate(Convert.ToDouble(excelZeile[7]));
                    Archiverungsdatum = datum;
                    archivdatumOk = true;
                }

                Ablageort = excelZeile[8];
            }
            catch (Exception)
            {
                throw new Exception("Fehler bei der Konvertierung (Methode: splittArray())");
            }
        }

        #endregion // Methoden privat 

        #region Methoden öffentlich

        /// <summary>
        /// Vergleicht ein übergebenes Objekt (CProjektdatensatz) mit dem eigenen Objekt
        /// </summary>
        /// <param name="a">Das übergebenen Objekt vom Typ CProjektdatensatz</param>
        /// <returns>1/0/-1</returns>
        public int CompareTo(CProjektdatensatz? a)
        {
           if (a is null) return 0;

            if (this.Projektnummer > a.Projektnummer) return 1;
            else if (this.Projektnummer < a.Projektnummer) return -1;
            else return 0;
        }

        #endregion // Methoden öffentlich

        #endregion // Methoden 

    } // CProjektdatensatz

}
