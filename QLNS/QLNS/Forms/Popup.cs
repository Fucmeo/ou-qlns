using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLNS.Forms
{
    public partial class Popup : Form
    {

        public Popup(string title , UserControl uc)
        {
            InitializeComponent();

            this.Text = title;
            this.Size = uc.Size;
            uc.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.Controls.Add(uc,0,0);
            
            //this.Height += 100;
            //this.Width += 100;
        }

        private void Popup_Load(object sender, EventArgs e)
        {

        }
    }
}
