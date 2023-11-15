namespace ProjektXLSDatenbank
{
  partial class CProjektInkonsitenzen
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
      this.LBX_DoppelteProjekte = new System.Windows.Forms.ListBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.LBX_LückenProjekte = new System.Windows.Forms.ListBox();
      this.BTN_Ol = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // LBX_DoppelteProjekte
      // 
      this.LBX_DoppelteProjekte.FormattingEnabled = true;
      this.LBX_DoppelteProjekte.Location = new System.Drawing.Point(18, 54);
      this.LBX_DoppelteProjekte.Name = "LBX_DoppelteProjekte";
      this.LBX_DoppelteProjekte.Size = new System.Drawing.Size(120, 95);
      this.LBX_DoppelteProjekte.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(17, 39);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(129, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Doppelte Projektnummern";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(157, 38);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(133, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Lücken in Projektnummern";
      // 
      // LBX_LückenProjekte
      // 
      this.LBX_LückenProjekte.FormattingEnabled = true;
      this.LBX_LückenProjekte.Location = new System.Drawing.Point(160, 54);
      this.LBX_LückenProjekte.Name = "LBX_LückenProjekte";
      this.LBX_LückenProjekte.Size = new System.Drawing.Size(120, 95);
      this.LBX_LückenProjekte.TabIndex = 3;
      // 
      // BTN_Ol
      // 
      this.BTN_Ol.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.BTN_Ol.Location = new System.Drawing.Point(462, 12);
      this.BTN_Ol.Name = "BTN_Ol";
      this.BTN_Ol.Size = new System.Drawing.Size(75, 23);
      this.BTN_Ol.TabIndex = 4;
      this.BTN_Ol.Text = "Ok";
      this.BTN_Ol.UseVisualStyleBackColor = true;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.LBX_DoppelteProjekte);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.LBX_LückenProjekte);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Location = new System.Drawing.Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(433, 231);
      this.groupBox1.TabIndex = 5;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Information aus der Projektanalyse";
      // 
      // CProjektInkonsitenzen
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(549, 255);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.BTN_Ol);
      this.Name = "CProjektInfo";
      this.Text = "CProjektInfo";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListBox LBX_DoppelteProjekte;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ListBox LBX_LückenProjekte;
    private System.Windows.Forms.Button BTN_Ol;
    private System.Windows.Forms.GroupBox groupBox1;
  }
}