namespace ProjektXLSDatenbank
{
  partial class Form1
  {
    /// <summary>
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Windows Form-Designer generierter Code

    /// <summary>
    /// Erforderliche Methode für die Designerunterstützung.
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
      this.BTN_Ok = new System.Windows.Forms.Button();
      this.BTN_Abbruch = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label2 = new System.Windows.Forms.Label();
      this.BTN_ResetSuchen = new System.Windows.Forms.Button();
      this.BTN_Suchen = new System.Windows.Forms.Button();
      this.EDT_SuchString = new System.Windows.Forms.TextBox();
      this.CBX_PersonObjekt = new System.Windows.Forms.ComboBox();
      this.LBL_PersonObjekt = new System.Windows.Forms.Label();
      this.LVW_Exceldaten = new System.Windows.Forms.ListView();
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.Projektnummer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.PersonObjekt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.Sachmerkmal1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.Sachmerkmal2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.Sachmerkmal3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.Anleger = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.Anlagedatum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ArchivDatum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.Ablageort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
      this.BTN_Neu = new System.Windows.Forms.Button();
      this.EDT_AnzahlProjekte = new System.Windows.Forms.TextBox();
      this.BTN_ProjektInfo = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.EDT_LfdProjekte = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.EDT_ArchProjekte = new System.Windows.Forms.TextBox();
      this.excelThread = new System.ComponentModel.BackgroundWorker();
      this.groupBox1.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // BTN_Ok
      // 
      this.BTN_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.BTN_Ok.Location = new System.Drawing.Point(1365, 12);
      this.BTN_Ok.Name = "BTN_Ok";
      this.BTN_Ok.Size = new System.Drawing.Size(75, 23);
      this.BTN_Ok.TabIndex = 0;
      this.BTN_Ok.Text = "Ok";
      this.BTN_Ok.UseVisualStyleBackColor = true;
      this.BTN_Ok.Click += new System.EventHandler(this.BTN_OK_Click);
      // 
      // BTN_Abbruch
      // 
      this.BTN_Abbruch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.BTN_Abbruch.Location = new System.Drawing.Point(1365, 41);
      this.BTN_Abbruch.Name = "BTN_Abbruch";
      this.BTN_Abbruch.Size = new System.Drawing.Size(75, 23);
      this.BTN_Abbruch.TabIndex = 1;
      this.BTN_Abbruch.Text = "Abbruch";
      this.BTN_Abbruch.UseVisualStyleBackColor = true;
      this.BTN_Abbruch.Click += new System.EventHandler(this.BTN_Abbruch_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.BTN_ResetSuchen);
      this.groupBox1.Controls.Add(this.BTN_Suchen);
      this.groupBox1.Controls.Add(this.EDT_SuchString);
      this.groupBox1.Controls.Add(this.CBX_PersonObjekt);
      this.groupBox1.Controls.Add(this.LBL_PersonObjekt);
      this.groupBox1.Controls.Add(this.LVW_Exceldaten);
      this.groupBox1.Location = new System.Drawing.Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(1347, 445);
      this.groupBox1.TabIndex = 2;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Datenbestand";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(303, 16);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(49, 13);
      this.label2.TabIndex = 6;
      this.label2.Text = "Suchtext";
      // 
      // BTN_ResetSuchen
      // 
      this.BTN_ResetSuchen.Location = new System.Drawing.Point(701, 31);
      this.BTN_ResetSuchen.Name = "BTN_ResetSuchen";
      this.BTN_ResetSuchen.Size = new System.Drawing.Size(78, 23);
      this.BTN_ResetSuchen.TabIndex = 5;
      this.BTN_ResetSuchen.Text = "zurücksetzen";
      this.BTN_ResetSuchen.UseVisualStyleBackColor = true;
      this.BTN_ResetSuchen.Click += new System.EventHandler(this.BTN_ResetSuchen_Click);
      // 
      // BTN_Suchen
      // 
      this.BTN_Suchen.Location = new System.Drawing.Point(620, 31);
      this.BTN_Suchen.Name = "BTN_Suchen";
      this.BTN_Suchen.Size = new System.Drawing.Size(75, 23);
      this.BTN_Suchen.TabIndex = 4;
      this.BTN_Suchen.Text = "Suchen";
      this.BTN_Suchen.UseVisualStyleBackColor = true;
      this.BTN_Suchen.Click += new System.EventHandler(this.BTN_Suchen_Click);
      // 
      // EDT_SuchString
      // 
      this.EDT_SuchString.Location = new System.Drawing.Point(306, 31);
      this.EDT_SuchString.Name = "EDT_SuchString";
      this.EDT_SuchString.Size = new System.Drawing.Size(308, 20);
      this.EDT_SuchString.TabIndex = 3;
      this.EDT_SuchString.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EDT_SuchString_KeyPress);
      // 
      // CBX_PersonObjekt
      // 
      this.CBX_PersonObjekt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.CBX_PersonObjekt.FormattingEnabled = true;
      this.CBX_PersonObjekt.Location = new System.Drawing.Point(6, 31);
      this.CBX_PersonObjekt.Name = "CBX_PersonObjekt";
      this.CBX_PersonObjekt.Size = new System.Drawing.Size(200, 21);
      this.CBX_PersonObjekt.TabIndex = 2;
      this.CBX_PersonObjekt.SelectedIndexChanged += new System.EventHandler(this.CBX_PersonObjekt_SelectedIndexChanged);
      // 
      // LBL_PersonObjekt
      // 
      this.LBL_PersonObjekt.AutoSize = true;
      this.LBL_PersonObjekt.Location = new System.Drawing.Point(6, 16);
      this.LBL_PersonObjekt.Name = "LBL_PersonObjekt";
      this.LBL_PersonObjekt.Size = new System.Drawing.Size(98, 13);
      this.LBL_PersonObjekt.TabIndex = 1;
      this.LBL_PersonObjekt.Text = "Person oder Objekt";
      // 
      // LVW_Exceldaten
      // 
      this.LVW_Exceldaten.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.LVW_Exceldaten.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.Projektnummer,
            this.PersonObjekt,
            this.Sachmerkmal1,
            this.Sachmerkmal2,
            this.Sachmerkmal3,
            this.Anleger,
            this.Anlagedatum,
            this.ArchivDatum,
            this.Ablageort});
      this.LVW_Exceldaten.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.LVW_Exceldaten.FullRowSelect = true;
      this.LVW_Exceldaten.GridLines = true;
      this.LVW_Exceldaten.Location = new System.Drawing.Point(6, 71);
      this.LVW_Exceldaten.Name = "LVW_Exceldaten";
      this.LVW_Exceldaten.Size = new System.Drawing.Size(1335, 368);
      this.LVW_Exceldaten.TabIndex = 0;
      this.LVW_Exceldaten.UseCompatibleStateImageBehavior = false;
      this.LVW_Exceldaten.View = System.Windows.Forms.View.Details;
      this.LVW_Exceldaten.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LVW_Exceldaten_ColumnClick);
      this.LVW_Exceldaten.DoubleClick += new System.EventHandler(this.LVW_Exceldaten_DoubleClick);
      // 
      // columnHeader1
      // 
      this.columnHeader1.Width = 0;
      // 
      // Projektnummer
      // 
      this.Projektnummer.Text = "Projekt";
      // 
      // PersonObjekt
      // 
      this.PersonObjekt.Text = "Person/Objekt";
      // 
      // Sachmerkmal1
      // 
      this.Sachmerkmal1.Text = "Sachmerkmal1";
      this.Sachmerkmal1.Width = 150;
      // 
      // Sachmerkmal2
      // 
      this.Sachmerkmal2.Text = "Sachmerkmal2";
      this.Sachmerkmal2.Width = 150;
      // 
      // Sachmerkmal3
      // 
      this.Sachmerkmal3.Text = "Sachmerkmal3";
      this.Sachmerkmal3.Width = 150;
      // 
      // Anleger
      // 
      this.Anleger.DisplayIndex = 7;
      this.Anleger.Text = "Anleger";
      this.Anleger.Width = 90;
      // 
      // Anlagedatum
      // 
      this.Anlagedatum.DisplayIndex = 6;
      this.Anlagedatum.Text = "Anlagedatum";
      this.Anlagedatum.Width = 90;
      // 
      // ArchivDatum
      // 
      this.ArchivDatum.Text = "ArchivDatum";
      this.ArchivDatum.Width = 90;
      // 
      // Ablageort
      // 
      this.Ablageort.Text = "Ablageort";
      this.Ablageort.Width = 150;
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
      this.statusStrip1.Location = new System.Drawing.Point(0, 506);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(1451, 22);
      this.statusStrip1.TabIndex = 3;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // toolStripStatusLabel1
      // 
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
      this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
      // 
      // BTN_Neu
      // 
      this.BTN_Neu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.BTN_Neu.Location = new System.Drawing.Point(1365, 142);
      this.BTN_Neu.Name = "BTN_Neu";
      this.BTN_Neu.Size = new System.Drawing.Size(75, 23);
      this.BTN_Neu.TabIndex = 4;
      this.BTN_Neu.Text = "neu";
      this.BTN_Neu.UseVisualStyleBackColor = true;
      this.BTN_Neu.Click += new System.EventHandler(this.BTN_Neu_Click);
      // 
      // EDT_AnzahlProjekte
      // 
      this.EDT_AnzahlProjekte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.EDT_AnzahlProjekte.Location = new System.Drawing.Point(105, 472);
      this.EDT_AnzahlProjekte.Name = "EDT_AnzahlProjekte";
      this.EDT_AnzahlProjekte.ReadOnly = true;
      this.EDT_AnzahlProjekte.Size = new System.Drawing.Size(60, 20);
      this.EDT_AnzahlProjekte.TabIndex = 6;
      this.EDT_AnzahlProjekte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // BTN_ProjektInfo
      // 
      this.BTN_ProjektInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.BTN_ProjektInfo.Location = new System.Drawing.Point(1366, 113);
      this.BTN_ProjektInfo.Name = "BTN_ProjektInfo";
      this.BTN_ProjektInfo.Size = new System.Drawing.Size(75, 23);
      this.BTN_ProjektInfo.TabIndex = 10;
      this.BTN_ProjektInfo.Text = "Projekt Info";
      this.BTN_ProjektInfo.UseVisualStyleBackColor = true;
      this.BTN_ProjektInfo.Click += new System.EventHandler(this.BTN_ProjektInfo_Click);
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(18, 476);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(81, 13);
      this.label1.TabIndex = 11;
      this.label1.Text = "Anzahl Projekte";
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(186, 476);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(90, 13);
      this.label3.TabIndex = 13;
      this.label3.Text = "laufende Projekte";
      // 
      // EDT_LfdProjekte
      // 
      this.EDT_LfdProjekte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.EDT_LfdProjekte.Location = new System.Drawing.Point(282, 472);
      this.EDT_LfdProjekte.Name = "EDT_LfdProjekte";
      this.EDT_LfdProjekte.ReadOnly = true;
      this.EDT_LfdProjekte.Size = new System.Drawing.Size(60, 20);
      this.EDT_LfdProjekte.TabIndex = 12;
      this.EDT_LfdProjekte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label4
      // 
      this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(362, 476);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(98, 13);
      this.label4.TabIndex = 15;
      this.label4.Text = "archivierte Projekte";
      // 
      // EDT_ArchProjekte
      // 
      this.EDT_ArchProjekte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.EDT_ArchProjekte.Location = new System.Drawing.Point(464, 472);
      this.EDT_ArchProjekte.Name = "EDT_ArchProjekte";
      this.EDT_ArchProjekte.ReadOnly = true;
      this.EDT_ArchProjekte.Size = new System.Drawing.Size(60, 20);
      this.EDT_ArchProjekte.TabIndex = 14;
      this.EDT_ArchProjekte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // excelThread
      // 
      this.excelThread.WorkerReportsProgress = true;
      this.excelThread.WorkerSupportsCancellation = true;
      this.excelThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.excelThread_DoWork);
      this.excelThread.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.excelThread_ProgressChanged);
      this.excelThread.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.excelThread_RunWorkerCompleted);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1451, 528);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.EDT_ArchProjekte);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.EDT_LfdProjekte);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.BTN_ProjektInfo);
      this.Controls.Add(this.EDT_AnzahlProjekte);
      this.Controls.Add(this.BTN_Neu);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.BTN_Abbruch);
      this.Controls.Add(this.BTN_Ok);
      this.MinimumSize = new System.Drawing.Size(917, 566);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Shown += new System.EventHandler(this.Form1_Shown);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button BTN_Ok;
    private System.Windows.Forms.Button BTN_Abbruch;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.ListView LVW_Exceldaten;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader Projektnummer;
    private System.Windows.Forms.ColumnHeader Sachmerkmal1;
    private System.Windows.Forms.ColumnHeader Sachmerkmal2;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.Button BTN_Neu;
    private System.Windows.Forms.TextBox EDT_AnzahlProjekte;
    private System.Windows.Forms.ColumnHeader Sachmerkmal3;
    private System.Windows.Forms.ColumnHeader Anlagedatum;
    private System.Windows.Forms.ColumnHeader Anleger;
    private System.Windows.Forms.ColumnHeader ArchivDatum;
    private System.Windows.Forms.ColumnHeader Ablageort;
    private System.Windows.Forms.ComboBox CBX_PersonObjekt;
    private System.Windows.Forms.Label LBL_PersonObjekt;
    private System.Windows.Forms.Button BTN_Suchen;
    private System.Windows.Forms.TextBox EDT_SuchString;
    private System.Windows.Forms.Button BTN_ResetSuchen;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    private System.Windows.Forms.Button BTN_ProjektInfo;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox EDT_LfdProjekte;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox EDT_ArchProjekte;
    private System.Windows.Forms.ColumnHeader PersonObjekt;
    private System.ComponentModel.BackgroundWorker excelThread;
  }
}

