namespace ProjektXLSDatenbank
{
  partial class DlgProjektDatensatzAnzeige
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.BTN_Ok = new System.Windows.Forms.Button();
      this.BTN_Abbruch = new System.Windows.Forms.Button();
      this.EDT_Sachmerkmal1 = new System.Windows.Forms.TextBox();
      this.EDT_Sachmerkmal2 = new System.Windows.Forms.TextBox();
      this.EDT_Sachmerkmal3 = new System.Windows.Forms.TextBox();
      this.CBX_PersonObjekt = new System.Windows.Forms.ComboBox();
      this.CHK_Archiviert = new System.Windows.Forms.CheckBox();
      this.datumPickerAnlage = new System.Windows.Forms.DateTimePicker();
      this.EDT_AnlagerName = new System.Windows.Forms.TextBox();
      this.EDT_Projektnummer = new System.Windows.Forms.TextBox();
      this.datumPickerArchiv = new System.Windows.Forms.DateTimePicker();
      this.EDT_Ablageort = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.LBL_Ablageort = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // BTN_Ok
      // 
      this.BTN_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.BTN_Ok.Location = new System.Drawing.Point(624, 12);
      this.BTN_Ok.Name = "BTN_Ok";
      this.BTN_Ok.Size = new System.Drawing.Size(75, 23);
      this.BTN_Ok.TabIndex = 5;
      this.BTN_Ok.Text = "Ok";
      this.BTN_Ok.UseVisualStyleBackColor = true;
      this.BTN_Ok.Click += new System.EventHandler(this.BTN_Ok_Click);
      // 
      // BTN_Abbruch
      // 
      this.BTN_Abbruch.Location = new System.Drawing.Point(624, 41);
      this.BTN_Abbruch.Name = "BTN_Abbruch";
      this.BTN_Abbruch.Size = new System.Drawing.Size(75, 23);
      this.BTN_Abbruch.TabIndex = 6;
      this.BTN_Abbruch.Text = "abbrechen";
      this.BTN_Abbruch.UseVisualStyleBackColor = true;
      this.BTN_Abbruch.Click += new System.EventHandler(this.BTN_Abbruch_Click);
      // 
      // EDT_Sachmerkmal1
      // 
      this.EDT_Sachmerkmal1.Location = new System.Drawing.Point(100, 96);
      this.EDT_Sachmerkmal1.Name = "EDT_Sachmerkmal1";
      this.EDT_Sachmerkmal1.Size = new System.Drawing.Size(508, 20);
      this.EDT_Sachmerkmal1.TabIndex = 1;
      // 
      // EDT_Sachmerkmal2
      // 
      this.EDT_Sachmerkmal2.Location = new System.Drawing.Point(100, 122);
      this.EDT_Sachmerkmal2.Name = "EDT_Sachmerkmal2";
      this.EDT_Sachmerkmal2.Size = new System.Drawing.Size(508, 20);
      this.EDT_Sachmerkmal2.TabIndex = 2;
      // 
      // EDT_Sachmerkmal3
      // 
      this.EDT_Sachmerkmal3.Location = new System.Drawing.Point(100, 148);
      this.EDT_Sachmerkmal3.Name = "EDT_Sachmerkmal3";
      this.EDT_Sachmerkmal3.Size = new System.Drawing.Size(508, 20);
      this.EDT_Sachmerkmal3.TabIndex = 3;
      // 
      // CBX_PersonObjekt
      // 
      this.CBX_PersonObjekt.FormattingEnabled = true;
      this.CBX_PersonObjekt.Location = new System.Drawing.Point(100, 59);
      this.CBX_PersonObjekt.Name = "CBX_PersonObjekt";
      this.CBX_PersonObjekt.Size = new System.Drawing.Size(171, 21);
      this.CBX_PersonObjekt.TabIndex = 0;
      // 
      // CHK_Archiviert
      // 
      this.CHK_Archiviert.AutoSize = true;
      this.CHK_Archiviert.Location = new System.Drawing.Point(9, 251);
      this.CHK_Archiviert.Name = "CHK_Archiviert";
      this.CHK_Archiviert.Size = new System.Drawing.Size(87, 17);
      this.CHK_Archiviert.TabIndex = 10;
      this.CHK_Archiviert.Text = "Archiviert am";
      this.CHK_Archiviert.UseVisualStyleBackColor = true;
      this.CHK_Archiviert.CheckedChanged += new System.EventHandler(this.CHK_Archiviert_CheckedChanged);
      // 
      // datumPickerAnlage
      // 
      this.datumPickerAnlage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.datumPickerAnlage.Location = new System.Drawing.Point(100, 197);
      this.datumPickerAnlage.Name = "datumPickerAnlage";
      this.datumPickerAnlage.Size = new System.Drawing.Size(200, 20);
      this.datumPickerAnlage.TabIndex = 9;
      // 
      // EDT_AnlagerName
      // 
      this.EDT_AnlagerName.Location = new System.Drawing.Point(364, 197);
      this.EDT_AnlagerName.Name = "EDT_AnlagerName";
      this.EDT_AnlagerName.Size = new System.Drawing.Size(181, 20);
      this.EDT_AnlagerName.TabIndex = 4;
      // 
      // EDT_Projektnummer
      // 
      this.EDT_Projektnummer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.EDT_Projektnummer.Location = new System.Drawing.Point(100, 15);
      this.EDT_Projektnummer.Name = "EDT_Projektnummer";
      this.EDT_Projektnummer.ReadOnly = true;
      this.EDT_Projektnummer.Size = new System.Drawing.Size(73, 29);
      this.EDT_Projektnummer.TabIndex = 12;
      this.EDT_Projektnummer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // datumPickerArchiv
      // 
      this.datumPickerArchiv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.datumPickerArchiv.Enabled = false;
      this.datumPickerArchiv.Location = new System.Drawing.Point(103, 248);
      this.datumPickerArchiv.Name = "datumPickerArchiv";
      this.datumPickerArchiv.Size = new System.Drawing.Size(197, 20);
      this.datumPickerArchiv.TabIndex = 7;
      // 
      // EDT_Ablageort
      // 
      this.EDT_Ablageort.Location = new System.Drawing.Point(364, 248);
      this.EDT_Ablageort.Name = "EDT_Ablageort";
      this.EDT_Ablageort.Size = new System.Drawing.Size(181, 20);
      this.EDT_Ablageort.TabIndex = 8;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(30, 201);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(66, 13);
      this.label1.TabIndex = 15;
      this.label1.Text = "Angelegt am";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(333, 200);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(25, 13);
      this.label2.TabIndex = 16;
      this.label2.Text = "von";
      // 
      // LBL_Ablageort
      // 
      this.LBL_Ablageort.AutoSize = true;
      this.LBL_Ablageort.Location = new System.Drawing.Point(306, 252);
      this.LBL_Ablageort.Name = "LBL_Ablageort";
      this.LBL_Ablageort.Size = new System.Drawing.Size(52, 13);
      this.LBL_Ablageort.TabIndex = 17;
      this.LBL_Ablageort.Text = "Abalgeort";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(19, 23);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(77, 13);
      this.label4.TabIndex = 18;
      this.label4.Text = "Projektnummer";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.BackColor = System.Drawing.SystemColors.Control;
      this.label5.Location = new System.Drawing.Point(20, 63);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(76, 13);
      this.label5.TabIndex = 19;
      this.label5.Text = "Person/Objekt";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(16, 100);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(80, 13);
      this.label6.TabIndex = 20;
      this.label6.Text = "Sachmerkmal 1";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(16, 126);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(80, 13);
      this.label7.TabIndex = 21;
      this.label7.Text = "Sachmerkmal 2";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(16, 152);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(80, 13);
      this.label8.TabIndex = 22;
      this.label8.Text = "Sachmerkmal 3";
      // 
      // DlgProjektDatensatzAnzeige
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(711, 301);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.LBL_Ablageort);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.EDT_Ablageort);
      this.Controls.Add(this.datumPickerArchiv);
      this.Controls.Add(this.EDT_Projektnummer);
      this.Controls.Add(this.EDT_AnlagerName);
      this.Controls.Add(this.CHK_Archiviert);
      this.Controls.Add(this.datumPickerAnlage);
      this.Controls.Add(this.CBX_PersonObjekt);
      this.Controls.Add(this.EDT_Sachmerkmal3);
      this.Controls.Add(this.EDT_Sachmerkmal2);
      this.Controls.Add(this.EDT_Sachmerkmal1);
      this.Controls.Add(this.BTN_Abbruch);
      this.Controls.Add(this.BTN_Ok);
      this.Name = "DlgProjektDatensatzAnzeige";
      this.Text = "CProjektDatensatzAnzeige";
      this.Load += new System.EventHandler(this.CProjektDatensatzAnzeige_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button BTN_Ok;
    private System.Windows.Forms.Button BTN_Abbruch;
    private System.Windows.Forms.TextBox EDT_Sachmerkmal1;
    private System.Windows.Forms.TextBox EDT_Sachmerkmal2;
    private System.Windows.Forms.TextBox EDT_Sachmerkmal3;
    private System.Windows.Forms.ComboBox CBX_PersonObjekt;
    private System.Windows.Forms.CheckBox CHK_Archiviert;
    private System.Windows.Forms.DateTimePicker datumPickerAnlage;
    private System.Windows.Forms.TextBox EDT_AnlagerName;
    private System.Windows.Forms.TextBox EDT_Projektnummer;
    private System.Windows.Forms.DateTimePicker datumPickerArchiv;
    private System.Windows.Forms.TextBox EDT_Ablageort;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label LBL_Ablageort;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
  }
}