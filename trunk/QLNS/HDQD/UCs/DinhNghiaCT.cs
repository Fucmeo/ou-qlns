using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HDQD.UCs
{
    public partial class DinhNghiaCT : UserControl
    {
        public DinhNghiaCT()
        {
            InitializeComponent();
        }

        private void rtb_CongThuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
