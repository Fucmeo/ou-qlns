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
        DataTable dtDiDuongDetail;

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

        private void PrepTbl_DiDuongDetail()
        {
            dtDiDuongDetail = new DataTable();
            dtDiDuongDetail.Columns.Add("seq_id", typeof(int));
            dtDiDuongDetail.Columns.Add("ptdc_id", typeof(int));
            dtDiDuongDetail.Columns.Add("di_or_den", typeof(int));
            dtDiDuongDetail.Columns.Add("dia_diem", typeof(string));
            dtDiDuongDetail.Columns.Add("ngay_khoi_hanh", typeof(DateTime));
            dtDiDuongDetail.Columns.Add("so_ngay_cong_tac", typeof(double));
            dtDiDuongDetail.Columns.Add("ly_do_luu_tru", typeof(string));
            dtDiDuongDetail.Columns.Add("ghi_chu", typeof(string));

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
