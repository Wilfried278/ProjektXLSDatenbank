using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjektXLSDatenbank
{
  /// <summary>
  /// Stellt Informationen über die Projekte im Hinblick auf doppelte Projekte 
  /// und fehlende Projekte für den Anwender bereit
  /// </summary>
  public partial class CProjektInkonsitenzen : Form
  {
        #region Datenelemente

        private List<int> dubletten;
        private List<int> lücken;

    #endregion // Datenelemente 

    #region Konstruktion
    /// <summary>
    /// Konstruiertes Objekt (als privat deklariert)
    /// </summary>
    private  CProjektInkonsitenzen()
    {
      InitializeComponent();
    }

    /// <summary>
    ///  konstruiert das Objekt mit Übergabe der Generischen Listen für die doppelten Projektnummer
    ///  und für die Projektnummerlücken
    /// </summary>
    /// <param name="doppelteProjektnummer">Generische Liste mit den doppelten Projektnummer</param>
    /// <param name="projektlücken">Generische Listen mit den Projektnummer die fehlen</param>
    public CProjektInkonsitenzen(List<int> doppelteProjektnummer, List<int> projektlücken)
    {
      InitializeComponent();

      this.dubletten = doppelteProjektnummer;
      this.lücken = projektlücken;

      anzeigen();
    }
    #endregion // Konstruktion  
 

    #region Methoden
	
	    #region Methoden privat 
	
	    #endregion // Methoden privat 
    
    /// <summary>
    /// Anzeige der Daten aus den Feldern der doppelten Projektnummer 
    /// und der Lücken in den Projektnummern
    /// </summary>
    private void anzeigen()
    {
      LBX_DoppelteProjekte.Items.Clear();

      foreach (int pNr in dubletten)
        LBX_DoppelteProjekte.Items.Add(pNr.ToString());

      LBX_LückenProjekte.Items.Clear();

      foreach (int pNr in lücken)
        LBX_LückenProjekte.Items.Add(pNr.ToString());
    }

		  #region Methoden öffentlich
	
	    #endregion // Methoden öffentlich
    
	  #endregion // Methoden 














  }
}
