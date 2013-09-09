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
        public enum ParentUC { BoNhiem, ThoiBoNhiem, QuyetDinhChung, MA, HopDong, TiepNhan};
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
                        HDQD.UCs.ThongTinCNVC.strMaNV = HDQD.UCs.QuyetDinhPhuCap.strMaNVOld = dtgv_DSCNVC.Rows[e.RowIndex].Cells["ma_nv"].Value.ToString();
                        HDQD.UCs.ThongTinCNVC.strHo = HDQD.UCs.QuyetDinhPhuCap.strHoOld = dtgv_DSCNVC.Rows[e.RowIndex].Cells["ho"].Value.ToString();
                        HDQD.UCs.ThongTinCNVC.strTen = HDQD.UCs.QuyetDinhPhuCap.strTenOld = dtgv_DSCNVC.Rows[e.RowIndex].Cells["ten"].Value.ToString();
                        break;


                    case ParentUC.HopDong:
                        HDQD.UCs.ThongTinCNVC.strMaNV 
                            //= HDQD.UCs.HopDong.strMaNVOld 
                            = dtgv_DSCNVC.Rows[e.RowIndex].Cells["ma_nv"].Value.ToString();
                        HDQD.UCs.ThongTinCNVC.strHo 
                            //= HDQD.UCs.HopDong.strHoOld 
                            = dtgv_DSCNVC.Rows[e.RowIndex].Cells["ho"].Value.ToString();
                        HDQD.UCs.ThongTinCNVC.strTen 
                            //= HDQD.UCs.HopDong.strTenOld 
                            = dtgv_DSCNVC.Rows[e.RowIndex].Cells["ten"].Value.ToString();
                        break;

                    case ParentUC.TiepNhan:
                        HDQD.UCs.ThongTinCNVC.strMaNV
                            //= HDQD.UCs.HopDong.strMaNVOld 
                            = dtgv_DSCNVC.Rows[e.RowIndex].Cells["ma_nv"].Value.ToString();
                        HDQD.UCs.ThongTinCNVC.strHo
                            //= HDQD.UCs.HopDong.strHoOld 
                            = dtgv_DSCNVC.Rows[e.RowIndex].Cells["ho"].Value.ToString();
                        HDQD.UCs.ThongTinCNVC.strTen
                            //= HDQD.UCs.HopDong.strTenOld 
                            = dtgv_DSCNVC.Rows[e.RowIndex].Cells["ten"].Value.ToString();
                        break;

                    default:
                        break;
                }
                Program.ma_nv = dtgv_DSCNVC.SelectedRows[0].Cells["ma_nv"].Value.ToString();
                Program.ten = dtgv_DSCNVC.SelectedRows[0].Cells["ten"].Value.ToString();
                Program.ho = dtgv_DSCNVC.SelectedRows[0].Cells["ho"].Value.ToString();
                ((Form)this.Parent.Parent).Close();
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

        private void btn_Chon_Click(object sender, EventArgs e)
        {
            switch (eParentUC)
            {
                case ParentUC.MA:
                    int row_count = dtgv_DSCNVC.SelectedRows.Count;
                    string[] ma_nv = new string[row_count];
                    string[] ho_ten = new string[row_count];
                    int i = 0;
                    foreach (DataGridViewRow item in dtgv_DSCNVC.SelectedRows)
                    {
                        ma_nv[i] = item.Cells["ma_nv"].Value.ToString();
                        ho_ten[i] = item.Cells["ho"].Value.ToString() + " " + item.Cells["ten"].Value.ToString();

                        i++;
                    }
                    HDQD.UCs.M_A.m_ma_nv = ma_nv;
                    HDQD.UCs.M_A.m_ho_ten = ho_ten;
                    HDQD.UCs.M_A.row_count = row_count;
                    HDQD.UCs.M_A.hitOK = true;

                    break;

                case ParentUC.BoNhiem:
                    HDQD.UCs.ThongTinCNVC.strMaNV = HDQD.UCs.BoNhiem.strMaNVOld = dtgv_DSCNVC.SelectedRows[0].Cells["ma_nv"].Value.ToString();
                    HDQD.UCs.ThongTinCNVC.strHo = HDQD.UCs.BoNhiem.strHoOld = dtgv_DSCNVC.SelectedRows[0].Cells["ho"].Value.ToString();
                    HDQD.UCs.ThongTinCNVC.strTen = HDQD.UCs.BoNhiem.strTenOld = dtgv_DSCNVC.SelectedRows[0].Cells["ten"].Value.ToString();
                    break;

                case ParentUC.ThoiBoNhiem:
                    HDQD.UCs.ThongTinCNVC.strMaNV = HDQD.UCs.ThoiBoNhiem.strMaNVOld = dtgv_DSCNVC.SelectedRows[0].Cells["ma_nv"].Value.ToString();
                    HDQD.UCs.ThongTinCNVC.strHo = HDQD.UCs.ThoiBoNhiem.strHoOld = dtgv_DSCNVC.SelectedRows[0].Cells["ho"].Value.ToString();
                    HDQD.UCs.ThongTinCNVC.strTen = HDQD.UCs.ThoiBoNhiem.strTenOld = dtgv_DSCNVC.SelectedRows[0].Cells["ten"].Value.ToString();
                    break;

                case ParentUC.QuyetDinhChung:
                    HDQD.UCs.ThongTinCNVC.strMaNV = HDQD.UCs.QuyetDinhPhuCap.strMaNVOld = dtgv_DSCNVC.SelectedRows[0].Cells["ma_nv"].Value.ToString();
                    HDQD.UCs.ThongTinCNVC.strHo = HDQD.UCs.QuyetDinhPhuCap.strHoOld = dtgv_DSCNVC.SelectedRows[0].Cells["ho"].Value.ToString();
                    HDQD.UCs.ThongTinCNVC.strTen = HDQD.UCs.QuyetDinhPhuCap.strTenOld = dtgv_DSCNVC.SelectedRows[0].Cells["ten"].Value.ToString();
                    break;

                case ParentUC.HopDong:
                    HDQD.UCs.ThongTinCNVC.strMaNV
                        //= HDQD.UCs.HopDong.strMaNVOld 
                        = dtgv_DSCNVC.SelectedRows[0].Cells["ma_nv"].Value.ToString();
                    HDQD.UCs.ThongTinCNVC.strHo
                        //= HDQD.UCs.HopDong.strHoOld 
                        = dtgv_DSCNVC.SelectedRows[0].Cells["ho"].Value.ToString();
                    HDQD.UCs.ThongTinCNVC.strTen
                        //= HDQD.UCs.HopDong.strTenOld 
                        = dtgv_DSCNVC.SelectedRows[0].Cells["ten"].Value.ToString();
                    break;

                case ParentUC.TiepNhan:
                    HDQD.UCs.ThongTinCNVC.strMaNV
                        //= HDQD.UCs.HopDong.strMaNVOld 
                        = dtgv_DSCNVC.SelectedRows[0].Cells["ma_nv"].Value.ToString();
                    HDQD.UCs.ThongTinCNVC.strHo
                        //= HDQD.UCs.HopDong.strHoOld 
                        = dtgv_DSCNVC.SelectedRows[0].Cells["ho"].Value.ToString();
                    HDQD.UCs.ThongTinCNVC.strTen
                        //= HDQD.UCs.HopDong.strTenOld 
                        = dtgv_DSCNVC.SelectedRows[0].Cells["ten"].Value.ToString();
                    break;

                default:
                    break;
            }
            Program.ma_nv = dtgv_DSCNVC.SelectedRows[0].Cells["ma_nv"].Value.ToString();
            Program.ten = dtgv_DSCNVC.SelectedRows[0].Cells["ten"].Value.ToString();
            Program.ho = dtgv_DSCNVC.SelectedRows[0].Cells["ho"].Value.ToString();
            ((Form)this.Parent.Parent).Close();
        }
    }
}
