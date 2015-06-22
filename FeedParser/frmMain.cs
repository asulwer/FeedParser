using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FeedParser
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //textbox has to cannot be empty
            if (!String.IsNullOrEmpty(tbSymbolList.Text))
            {
                //split comma separated symbols and create a data form for each
                foreach (string item in tbSymbolList.Text.Split(','))
                {
                    //prevents child from being created again
                    if (!this.MdiChildren.Any(i => i.Text.Equals(item)))
                    {
                        frmData frm = new frmData();
                        frm.Text = item.ToUpper();
                        frm.Symbol = item.ToUpper();
                        frm.MdiParent = this;
                        frm.WindowState = FormWindowState.Maximized;
                        frm.Show();
                    }
                }
            }
        }
    }    
}
