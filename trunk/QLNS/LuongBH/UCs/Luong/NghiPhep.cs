using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LuongBH.UCs.Luong
{
    public partial class NghiPhep : UserControl
    {
        HDQD.UCs.ThongTinCNVC oThongTinCNVC;

        public NghiPhep()
        {
            InitializeComponent();
            oThongTinCNVC = new HDQD.UCs.ThongTinCNVC();
            oThongTinCNVC.Dock = DockStyle.Fill;
        }

        private void NgayPhep_Load(object sender, EventArgs e)
        {
            gb_TimKiem.Controls.Add(oThongTinCNVC);
        }
    }
}
