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
    public partial class DSCNVC : UserControl
    {
        DataTable dtDSCNVC;
        public enum ParentUC  { BoNhiem,ThoiBoNhiem,QuyetDinhChung };
        public static ParentUC eParentUC;
        public DSCNVC(DataTable _dtDSCNVC)
        {
            InitializeComponent();
            dtDSCNVC = _dtDSCNVC;
        }

        private void DSCNVC_Load(object sender, EventArgs e)
        {
            dtgv_DSCNVC.DataSource = dtDSCNVC;
            SetupDTGV();
        }

        private void dtgv_DSCNVC_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                switch (eParentUC)
                {
                    case ParentUC.BoNhiem:
                        HDQD.UCs.ThongTinCNVC.strMaNV = HDQD.UCs.BoNhiem.strMaNVOld = dtgv_DSCNVC.Rows[e.RowIndex].Cells["ma_nv"].Value.ToString();
                        HDQD.UCs.ThongTinCNVC.strHo = HDQD.UCs.BoNhiem.strHoOld = dtgv_DSCNVC.Rows[e.RowIndex].Cells["ho"].Value.ToString();
                        HDQD.UCs.ThongTinCNVC.strTen = HDQD.UCs.BoNhiem.strTenOld = dtgv_DSCNVC.Rows[e.RowIndex].Cells["ten"].Value.ToString();
                        break;

                    case ParentUC.ThoiBoNhiem:
                        HDQD.UCs.ThongTinCNVC.strMaNV = HDQD.UCs.ThoiBoNhiem.strMaNVOld = dtgv_DSCNVC.Rows[e.RowIndex].Cells["ma_nv"].Value.ToString();
                        HDQD.UCs.ThongTinCNVC.strHo = HDQD.UCs.ThoiBoNhiem.strHoOld = dtgv_DSCNVC.Rows[e.RowIndex].Cells["ho"].Value.ToString();
                        HDQD.UCs.ThongTinCNVC.strTen = HDQD.UCs.ThoiBoNhiem.strTenOld = dtgv_DSCNVC.Rows[e.RowIndex].Cells["ten"].Value.ToString();
                        break;

                    case ParentUC.QuyetDinhChung:
                        HDQD.UCs.ThongTinCNVC.strMaNV = HDQD.UCs.QuyetDinhChung.strMaNVOld = dtgv_DSCNVC.Rows[e.RowIndex].Cells["ma_nv"].Value.ToString();
                        HDQD.UCs.ThongTinCNVC.strHo = HDQD.UCs.QuyetDinhChung.strHoOld = dtgv_DSCNVC.Rows[e.RowIndex].Cells["ho"].Value.ToString();
                        HDQD.UCs.ThongTinCNVC.strTen = HDQD.UCs.QuyetDinhChung.strTenOld = dtgv_DSCNVC.Rows[e.RowIndex].Cells["ten"].Value.ToString();
                        break;

                    default:
                        break;
                }
                ((Form)this.Parent).Close();
            }
        }

        private void SetupDTGV()
        {
            dtgv_DSCNVC.Columns["ma_nv"].HeaderText = "Mã nhân viên";
            dtgv_DSCNVC.Columns["ma_nv"].Width = 150;
            dtgv_DSCNVC.Columns["ho"].HeaderText = "Họ";
            dtgv_DSCNVC.Columns["ho"].Width = 300;
            dtgv_DSCNVC.Columns["ten"].HeaderText = "Tên";
            dtgv_DSCNVC.Columns["ten"].Width = 200;
            dtgv_DSCNVC.Columns["dia_chi"].HeaderText = "Địa chỉ";
            dtgv_DSCNVC.Columns["dia_chi"].Width = 500;
            dtgv_DSCNVC.Columns["ngay_sinh"].HeaderText = "Ngày sinh";
            dtgv_DSCNVC.Columns["ngay_sinh"].Width = 150;
            dtgv_DSCNVC.Columns["gioi_tinh"].HeaderText = "Giới tính";
            dtgv_DSCNVC.Columns["gioi_tinh"].Width = 50;
        }
    }
}
