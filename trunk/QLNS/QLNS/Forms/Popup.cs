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
        UserControl oUC;
        public Popup(string title , UserControl uc)
        {
            InitializeComponent();

            this.Text = title;
            oUC = uc;
            
            //this.Height += 100;
            //this.Width += 100;
        }

        private void Popup_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(oUC.Width, oUC.Height);
            this.Size = new Size(oUC.Size.Width + 40, oUC.Size.Height + 20);
            this.tableLayoutPanel1.Controls.Add(oUC);

            oUC.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.AutoScrollMinSize = new Size(oUC.Size.Width, oUC.Size.Height);

            ApplyFont(this);
        }

        void ApplyFont(Control c_root)
        {
            c_root.Font = SystemFonts.MessageBoxFont;
            if (c_root.HasChildren)
            {
                foreach (Control c in c_root.Controls)
                {
                    ApplyFont(c);
                }
            }


        }
    }
}
