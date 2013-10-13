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
    public partial class ChamCong : UserControl
    {
        HDQD.UCs.ThongTinCNVC oThongTinCNVC;
        public ChamCong()
        {
            InitializeComponent();
            oThongTinCNVC = new HDQD.UCs.ThongTinCNVC();
            oThongTinCNVC.Dock = DockStyle.Fill;
        }

        private void ChamCong_Load(object sender, EventArgs e)
        {
            gb_TimKiem.Controls.Add(oThongTinCNVC);
        }
    }
}
