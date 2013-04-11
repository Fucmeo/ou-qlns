using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LuongBH
{
    public partial class Form1 : Form
    {
        UserControl oUC;
        public Form1(UserControl UC)
        {
            InitializeComponent();
            InitializeComponent();
            oUC = UC;
            this.Size = oUC.Size;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            oUC.Dock = DockStyle.Fill;
            this.Controls.Add(oUC);
        }
    }
}
