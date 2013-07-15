using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HDQD.Forms
{
    public partial class Popup : Form
    {
        UserControl oUC;
        string sTitle;
        public Popup(UserControl _oUC, string _title)
        {
            InitializeComponent();
            oUC = _oUC;
            sTitle = _title;
        }

        public Popup()
        {
            UCs.TiepNhan ucHopDong = new UCs.TiepNhan();            
            ucHopDong.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.Controls.Add(oUC);
        }

        private void Popup_Load(object sender, EventArgs e)
        {
            this.tableLayoutPanel1.AutoScrollMinSize = new Size(oUC.Size.Width, oUC.Size.Height);
            //this.MinimumSize = new Size(oUC.Width, oUC.Height);
            //this.Size = new Size(oUC.Size.Width + 40, oUC.Size.Height + 20);
            this.Size = new Size(oUC.Size.Width + 40, oUC.Size.Height + 50);
            this.tableLayoutPanel1.Controls.Add(oUC);
            
            this.Text = sTitle;
            oUC.Dock = DockStyle.Fill;
            
        }

    }
}
