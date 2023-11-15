using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjektXLSDatenbank
{
  /// <summary>
  /// Klasse, die die Programmeinstellungen zur Verfügung stellt
  /// </summary>
  public class CProgrammEinstellungen
  {

    #region Datenelemente
    
    /// <summary>
    /// Repräsentiert den Dateinamen für die Exceltabelle, in der die
    /// Projekte abgelegt sind
    /// </summary>
    private string xlsFullFilename = string.Empty;

    /// <summary>
    /// Repräsentiert den Anlegernamen (Standard-Anlegername)
    /// </summary>
    private string anlegeNamestandard = string.Empty;

    /// <summary>
    /// Repräsentiert den Ablageort bei der Archivierung eines Projektes
    /// </summary>
    private string ablageortstandard = string.Empty;

    /// <summary>
    /// Repräsentiert die Zeilennummer der sich die Spaltenköpfe in der Excel-Arbeitsmappe findet
    /// </summary>
    private int zeilenNrSpaltenköpfe = 0;

    /// <summary>
    /// Repräsentiert die Zeilennummer, ab der sich der Datenbereich in der Excel-Arbeitsmappe definiert
    /// </summary>
    private int ersteZeileDatenbereich = 0;

    /// <summary>
    /// Anzahl der Spalten in der Exceltabelle, die von diesem 
    /// Programm verarbeitet werden
    /// </summary>
    private int anzahlExcelSpalten = 9;

    /// <summary>
    /// Schriftgröße, in der XML-Datei änderbar
    /// </summary>
    private double schriftgröße = 8.25;

    /// <summary>
    /// Mit diesem Parameter kann gesteuert werden, ob das Fenster beim Start
    /// maximiert angezeigt werden soll
    /// </summary>
    private bool fensterMaximiertAnzeigen = false;

    #endregion // Datenelemente 

    #region Konstruktion

    /// <summary>
    ///  Konstruktion des Objekts CProgrammeinstellungen mit der Initialisierung von
    ///  Standardwerten
    /// </summary>
    public CProgrammEinstellungen()
    {
      xlsFullFilename = "C:\\Projekte.xlsx";
      anlegeNamestandard = "mein Name";
      ablageortstandard = "ArchivBox 01";
      ZeilenNrSpaltenköpfe = 2;
      ErsteZeileDatenbereich = 3;
      AnzahlExcelSpalten = 9;
    }
    
	  #endregion // Konstruktion
    
	#region Eigenschaften



    /// <summary>
    /// Setzt den Dateinamen (voll qualifiziert) der Excel-Arbeitsmappe
    /// mit den enthaltenen Projektdatensätzen oder liefert ihn zurück
    /// </summary>
    public string XlsFullFilename
    {
      get { return xlsFullFilename; }
      set { xlsFullFilename = value; }
    }

    /// <summary>
    /// Setzt den (Standard-) Namen der beim Anlegen eines neuen Projektes verwendet wird oder liefert diesen zurück.
    /// Dieser Name wird verwendet um bei der Neuanlage eines Projektes, den Anlegernamen vorzubesetzen
    /// </summary>
    public string AnlegerNameStandard
    {
      get { return anlegeNamestandard; }
      set { anlegeNamestandard = value; }
    }

    /// <summary>
    /// Setzt den Ablageort für ein archiviertes Projekt oder liefert diesen zurück.
    /// Bei einer Archivierung eines Projektes wird diese Bezeichnung des Ablageortes als
    /// Standardort eingetragen
    /// </summary>
    public string Ablageortstandard
    {
      get { return ablageortstandard; }
      set { ablageortstandard = value; }
    }

    /// <summary>
    /// Setzt die Zeilennummer in der sich die Spaltenköpfe in der Excel-Arbeitsmappe
    /// befinden oder liefert diese zurück
    /// </summary>
    public int ZeilenNrSpaltenköpfe
    {
      get { return zeilenNrSpaltenköpfe; }
      set { zeilenNrSpaltenköpfe = value; }
    }
    
    /// <summary>
    /// Setzt Zeilennummer, an der der Datenbereich Projektdatensätzen der Excel-Arbeitsmappe beginnt
    /// oder liefert diese zurück.
    /// </summary>
    public int ErsteZeileDatenbereich
    {
      get { return ersteZeileDatenbereich; }
      set { ersteZeileDatenbereich = value; }
    }

    /// <summary>
    /// Setzt die Anzahk Spalten die von diesem Programm verarebitet werden 
    /// oder liefert diese zurück
    /// </summary>
    public int AnzahlExcelSpalten
    {
      get { return anzahlExcelSpalten; }
      set { anzahlExcelSpalten = value; }
    }

    /// <summary>
    /// Setzt den Wert der Schriftgröße oder gibt diesen zurück
    /// </summary>
    public double Schriftgröße
    {
      get { return schriftgröße; }
      set { schriftgröße = value; }
    }

    /// <summary>
    /// Setzt den Wert für die maximierte Anzeige des Fensters oder 
    /// liefert diesen zurück
    /// </summary>
    public bool FensterMaximiertAnzeigen
    {
      get { return fensterMaximiertAnzeigen; }
      set { fensterMaximiertAnzeigen = value; }
    } 

    #endregion // Eigenschaften 
  
  }
}
