using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BaoCao
{
    public partial class Form1 : Form
    {
        UserControl oUC = new UserControl();
        public Form1(UserControl uc)
        {
            InitializeComponent();
            //this.Size = uc.Size;
            oUC = uc;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            oUC.Dock = DockStyle.Fill;
            this.Size = oUC.Size;
            this.Controls.Add(oUC);
           // this.MinimumSize = new Size(oUC.Width, oUC.Height);
            this.Size = new Size(oUC.Size.Width + 40, oUC.Size.Height + 100);

            oUC.Dock = DockStyle.Fill;
            this.AutoScrollMinSize = new Size(oUC.Size.Width, oUC.Size.Height);
        }
    }
}
