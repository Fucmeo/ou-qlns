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
        public Form1(UserControl uc)
        {
            InitializeComponent();
            uc.Dock = DockStyle.Fill;
            this.Controls.Add(uc);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
