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
    public partial class TinhBaoHiem : UserControl
    {
        HDQD.UCs.ThongTinCNVC oThongTinCNVC;

        public TinhBaoHiem()
        {
            InitializeComponent();
        }

        private void TinhBaoHiem_Load(object sender, EventArgs e)
        {
            TLP_TheoNV.Controls.Add(oThongTinCNVC);
            ChangeDTTinhInterface();

            oThongTinCNVC.btn_Tim.Click += new EventHandler(btn_Tim_Click);
            oThongTinCNVC.Dock = DockStyle.Fill;
        }

        private void ChangeDTTinhInterface()
        {

            if (rdb_NV.Checked)
            {
                TLP_ThongTinTimKiem.RowStyles[1].SizeType = TLP_ThongTinTimKiem.RowStyles[0].SizeType = SizeType.Percent;
                TLP_ThongTinTimKiem.RowStyles[1].Height = 1;
                TLP_ThongTinTimKiem.RowStyles[0].Height = 99;
            }
            else
            {
                TLP_ThongTinTimKiem.RowStyles[1].SizeType = TLP_ThongTinTimKiem.RowStyles[0].SizeType = SizeType.Percent;
                TLP_ThongTinTimKiem.RowStyles[0].Height = 1;
                TLP_ThongTinTimKiem.RowStyles[1].Height = 99;
            }

        }

        void btn_Tim_Click(object sender, EventArgs e)
        {

        }

    }
}
