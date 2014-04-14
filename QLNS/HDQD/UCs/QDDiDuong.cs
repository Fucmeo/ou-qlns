using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business;

namespace HDQD.UCs
{
    public partial class QDDiDuong : UserControl
    {
        Business.ChucVu oChucvu;
        Business.HDQD.QDDiDuong oQDDiDuong;

        public QDDiDuong()
        {
            InitializeComponent();

            oChucvu = new ChucVu();
            oQDDiDuong = new Business.HDQD.QDDiDuong();
        }

        #region Private Methods
        private void PreapreDataSource()
        {
            try
            {
                comB_ChucVu.DataSource = oChucvu.GetList();
                comB_ChucVu.DisplayMember = "ten_chuc_vu";
                comB_ChucVu.ValueMember = "id";

                comB_PhuongTien.DataSource = oQDDiDuong.GetList();
                comB_PhuongTien.DisplayMember = "loai_phuong_tien";
                comB_PhuongTien.ValueMember = "id";

            }
            catch (Exception)
            {

            }

        }
        #endregion


        private void btn_Them_Click(object sender, EventArgs e)
        {

        }

        private void QDDiDuong_Load(object sender, EventArgs e)
        {
            PreapreDataSource();
        }
    }
}
