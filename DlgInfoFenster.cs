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
  public partial class DlgInfoFenster : Form
  {
    public DlgInfoFenster()
    {
      InitializeComponent();
    }

    public void ShowWindow(string messageText)
    {
      label1.Text = messageText;
      this.StartPosition = FormStartPosition.CenterScreen;
      
      this.Show();
    }

    public void HideWindow()
    {
      label1.ResetText();
      this.Hide();
    }


 
  }
}
