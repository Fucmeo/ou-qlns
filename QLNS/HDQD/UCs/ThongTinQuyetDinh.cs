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
    public partial class ThongTinQuyetDinh : UserControl
    {
        public ThongTinQuyetDinh()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lb_ChonTapTin_Click(object sender, EventArgs e)
        {
            HDQD.Forms.Popup f = new Forms.Popup(new HDQD.UCs.DSTapTin(), "QUẢN LÝ NHÂN SỰ - DANH SÁCH TẬP TIN");
            f.ShowDialog();
        }
    }
}
