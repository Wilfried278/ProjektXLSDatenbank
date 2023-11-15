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
    /// Hauptformualr der Anwendung
    /// </summary>
    public partial class DlgProjektDatensatzAnzeige : Form
    {
        private CProjektdatensatz projektdatensatz;
        private List<string> personenObjekte;
        CProgrammEinstellungen prgEinstellungen;

        public DlgProjektDatensatzAnzeige(ProjektXLSDatenbank.CProjektdatensatz pda, List<string> personenObjekte, ProjektXLSDatenbank.CProgrammEinstellungen prgEinstellungen)
        {
            InitializeComponent();
            initialisiereSteuerelemente();

            this.StartPosition = FormStartPosition.CenterScreen;

            this.personenObjekte = personenObjekte;
            this.prgEinstellungen = prgEinstellungen;

            projektdatensatz = pda;


            anzeigenPersonenObjekte();
            anzeigenDaten();

            aktualisiereSteuerelemente();
        }



        private void initialisiereSteuerelemente()
        {
            eieinbelendenArchivfelder(false);
        }

        private void aktualisiereSteuerelemente()
        {
            if (projektdatensatz.ArchivdatumOk == true)
                CHK_Archiviert.Checked = true;
        }


        private void anzeigenPersonenObjekte()
        {
            CBX_PersonObjekt.Items.Clear();

            foreach (string persObj in personenObjekte)
                CBX_PersonObjekt.Items.Add(persObj);

            //
            //  aktuell übergebene Person/Objekt selektieren
            //
            CBX_PersonObjekt.SelectedIndex = CBX_PersonObjekt.Items.IndexOf(projektdatensatz.PersonObjekt);
        }


        private void anzeigenDaten()
        {
            EDT_Projektnummer.Text = projektdatensatz.Projektnummer.ToString();
            EDT_Sachmerkmal1.Text = projektdatensatz.Sachmerkmal1;
            EDT_Sachmerkmal2.Text = projektdatensatz.Sachmerkmal2;
            EDT_Sachmerkmal3.Text = projektdatensatz.Sachmerkmal3;

            datumPickerAnlage.Enabled = false;
            if (projektdatensatz.Anlagedatum == DateTime.MinValue)
                datumPickerAnlage.Value = DateTime.Now;
            else
                datumPickerAnlage.Value = projektdatensatz.Anlagedatum;
            //
            //
            //
            EDT_AnlagerName.Text = projektdatensatz.AnlegerName;

            datumPickerArchiv.Enabled = true;
            if (projektdatensatz.Archiverungsdatum == DateTime.MinValue)
                datumPickerArchiv.Value = DateTime.Now;
            else
                datumPickerArchiv.Value = projektdatensatz.Archiverungsdatum;

            EDT_Ablageort.Text = projektdatensatz.Ablageort;
        }

        private void CProjektDatensatzAnzeige_Load(object sender, EventArgs e)
        {

        }

        private void CHK_Archiviert_CheckedChanged(object sender, EventArgs e)
        {
            eieinbelendenArchivfelder(CHK_Archiviert.Checked);
        }

        private void eieinbelendenArchivfelder(bool status)
        {
            if (status == true)
            {
                CHK_Archiviert.Text = "Archiviert am";
                datumPickerArchiv.Visible = status;
                EDT_Ablageort.Visible = status;
                LBL_Ablageort.Visible = status;
                EDT_Ablageort.Text = prgEinstellungen.Ablageortstandard;
            }
            else
            {
                CHK_Archiviert.Text = "archivieren";
                datumPickerArchiv.Visible = status;
                EDT_Ablageort.Visible = status;
                LBL_Ablageort.Visible = status;
            }


        }

        private void BTN_Ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public ProjektXLSDatenbank.CProjektdatensatz gibProjektdatensatz()
        {
            string[] strArray = new string[9];


            strArray[0] = projektdatensatz.Projektnummer.ToString();
            strArray[1] = CBX_PersonObjekt.Text;
            strArray[2] = EDT_Sachmerkmal1.Text;
            strArray[3] = EDT_Sachmerkmal2.Text;
            strArray[4] = EDT_Sachmerkmal3.Text;

            strArray[6] = EDT_AnlagerName.Text;
            strArray[5] = datumPickerAnlage.Value.ToString();

            if (CHK_Archiviert.Checked == true)
            {
                strArray[7] = datumPickerArchiv.Value.ToString();
                strArray[8] = EDT_Ablageort.Text;
            }
            else
            {
                strArray[7] = "";
                strArray[8] = "";
            }



            ProjektXLSDatenbank.CProjektdatensatz p = new ProjektXLSDatenbank.CProjektdatensatz(strArray);

            return p;

        }

        private void BTN_Abbruch_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
