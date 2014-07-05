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
    public partial class DanhSachQuyetDinh : UserControl
    {
        Business.HDQD.QuyetDinh oQuyetDinh;
        DataTable dtDSQuyetDinh;
        Business.HDQD.LoaiQuyetDinh oLoaiQuyetDinh;
        DataTable dtDSLoaiQuyetDinh;

        public DanhSachQuyetDinh()
        {
            InitializeComponent();
            oQuyetDinh = new Business.HDQD.QuyetDinh();
            oLoaiQuyetDinh = new Business.HDQD.LoaiQuyetDinh();
        }

        private void DanhSachQuyetDinh_Load(object sender, EventArgs e)
        {
            dtDSLoaiQuyetDinh = oLoaiQuyetDinh.GetList_Compact();
            PrepareCboLoaiQD();
        }
        #region Methods
        private void PrepareCboLoaiQD()
        {
            DataRow row = dtDSLoaiQuyetDinh.NewRow();
            dtDSLoaiQuyetDinh.Rows.InsertAt(row, 0);
            //BindingSource bs = new BindingSource();
            //bs.DataSource = dtDSLoaiQuyetDinh;
            comB_Loai.DataSource = dtDSLoaiQuyetDinh;
            comB_Loai.DisplayMember = "ten_loai";
            comB_Loai.ValueMember = "id";

        }

        private void PrepareDataSource()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dtDSQuyetDinh;
            dtgv_DSQD.DataSource = bs;
            //lbl_SoLoaiPC.Text = dtgv_DSLoaiPC.Rows.Count.ToString();
            if (dtDSQuyetDinh != null)
            {
                btn_TaiFile.Visible = btn_Xoa.Visible = true;
            }
        }

        /// <summary>
        /// Sua ten, an  cac cot cua dtg cho phu hop
        /// </summary>
        private void EditDtgInterface()
        {
            // Dat ten cho cac cot
            dtgv_DSQD.Columns["ma_qd_display"].HeaderText = "Mã quyết định";
            dtgv_DSQD.Columns["ma_qd_display"].Width = 100;
            dtgv_DSQD.Columns["ten"].HeaderText = "Tên quyết định";
            dtgv_DSQD.Columns["ten"].Width = 200;
            dtgv_DSQD.Columns["loai_qd_id"].HeaderText = "Loại qd ID";
            dtgv_DSQD.Columns["ten_loai_qd"].HeaderText = "Tên loại quyết định";
            dtgv_DSQD.Columns["ten_loai_qd"].Width = 200;
            dtgv_DSQD.Columns["mo_ta"].HeaderText = "Mô tả";
            dtgv_DSQD.Columns["mo_ta"].Width = 300;
            dtgv_DSQD.Columns["path"].HeaderText = "Path";
            dtgv_DSQD.Columns["ngay_ky"].HeaderText = "Ngày ký";
            dtgv_DSQD.Columns["ngay_ky"].Width = 100;
            dtgv_DSQD.Columns["ngay_hieu_luc"].HeaderText = "Ngày hiệu lực";
            dtgv_DSQD.Columns["ngay_hieu_luc"].Width = 100;
            dtgv_DSQD.Columns["ngay_het_han"].HeaderText = "Ngày hết hạn";
            dtgv_DSQD.Columns["ngay_het_han"].Width = 100;
            // An cot ID
            dtgv_DSQD.Columns["ma_quyet_dinh"].Visible = false;
            dtgv_DSQD.Columns["loai_qd_id"].Visible = false;
            dtgv_DSQD.Columns["path"].Visible = false;
        }

        /// <summary>
        /// Su dung thong tin row dang chon de hien thi len txt, comb,..
        /// </summary>
        /// <param name="row"></param>
        private void DisplayInfo(DataGridViewRow row)
        {
            if (row != null)
            {
                txt_Ma2.Text = row.Cells["ma_qd_display"].Value.ToString();
                txt_Ten2.Text = row.Cells["ten"].Value.ToString();
                txt_Loai.Text = row.Cells["ten_loai_qd"].Value.ToString();
                txt_NgayKy.Text = row.Cells["ngay_ky"].Value.ToString() == "" ? "" : Convert.ToDateTime(row.Cells["ngay_ky"].Value.ToString()).ToShortDateString();
                txt_NgayHieuLuc.Text = row.Cells["ngay_hieu_luc"].Value.ToString() == "" ? "" : Convert.ToDateTime(row.Cells["ngay_hieu_luc"].Value.ToString()).ToShortDateString();
                txt_NgayHetHan.Text = row.Cells["ngay_het_han"].Value.ToString() == "" ? "" : Convert.ToDateTime(row.Cells["ngay_het_han"].Value.ToString()).ToShortDateString();
            }
        }

        private void ResetInterface(bool init)
        {
            btn_Xoa.Enabled = init;
            btn_TaiFile.Enabled = init;
        }

        /// <summary>
        /// Refresh Data Source cho dtg sau moi lan thao tac
        /// </summary>
        private void RefreshDataSource()
        {
            Business.HDQD.QuyetDinh quyetdinh = new Business.HDQD.QuyetDinh();    // khong dung chung oChucVu duoc ???
            dtDSQuyetDinh = quyetdinh.Search_QD();
            PrepareDataSource();

        }
        #endregion

        private void dTP_TuNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dTP_TuNgay.Checked == true)
            {
                dTP_DenNgay.Enabled = true;
            }
            else
                dTP_DenNgay.Enabled = false;
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            oQuyetDinh.Ma_Quyet_Dinh = txt_Ma.Text == "" ? null : txt_Ma.Text;
            oQuyetDinh.Ten_Quyet_Dinh = txt_Ten.Text == "" ? null : txt_Ten.Text;
            
            oQuyetDinh.Loai_QuyetDinh_ID = null;
            if (comB_Loai.Text != "")
                oQuyetDinh.Loai_QuyetDinh_ID = Convert.ToInt16(comB_Loai.SelectedValue);

            oQuyetDinh.Ngay_Ky_Tu = null;
            oQuyetDinh.Ngay_Ky_Den = null;
            if (dTP_TuNgay.Checked == true)
            {
                oQuyetDinh.Ngay_Ky_Tu = dTP_TuNgay.Value;
                oQuyetDinh.Ngay_Ky_Den = dTP_DenNgay.Value;
            }
            try
            {
                dtDSQuyetDinh = oQuyetDinh.Search_QD();
                //dtgv_DSQD.DataSource = dtDSQuyetDinh;
                if (dtDSQuyetDinh != null)
                {
                    PrepareDataSource();
                    EditDtgInterface();
                    if (dtDSQuyetDinh.Rows.Count != 0)
                        ResetInterface(true);
                    else
                        ResetInterface(false);
                }
            }
            catch { }
        }

        private void dtgv_DSQD_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgv_DSQD.CurrentRow != null)
            {
                DisplayInfo(dtgv_DSQD.CurrentRow);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (dtgv_DSQD.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn thực sự muốn xoá quyết định này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        oQuyetDinh.Ma_Quyet_Dinh = dtgv_DSQD.CurrentRow.Cells[0].Value.ToString();
                        if (oQuyetDinh.Delete())
                        {
                            MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        RefreshDataSource();

                    }
                    catch (Exception )
                    {
                        MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (comB_Loai.Text != "")
            {

                #region comment do o su dung index nua
                //int index = Convert.ToInt16(comB_Loai.SelectedValue);
                //HDQD.Forms.Popup f;
                //switch (index)
                //{
                //    case 5: //tách đơn vị
                //        f = new Forms.Popup(new HDQD.UCs.M_A(true), "QUẢN LÝ NHÂN SỰ - QUYẾT ĐỊNH TÁCH ĐƠN VỊ");
                //        f.ShowDialog();
                //        break;
                //    case 9: //gộp đơn vị
                //        f = new Forms.Popup(new HDQD.UCs.M_A(false), "QUẢN LÝ NHÂN SỰ - QUYẾT ĐỊNH GỘP ĐƠN VỊ");
                //        f.ShowDialog();
                //        break;
                //    case 1:
                //    case 2:
                //    case 3:
                //        f = new Forms.Popup(new HDQD.UCs.BoNhiem(), "QUẢN LÝ NHÂN SỰ - QUYẾT ĐỊNH BỔ NHIỆM");
                //        f.ShowDialog();
                //        break;
                //    case 4:
                //        f = new Forms.Popup(new HDQD.UCs.DoiThongTinDV(), "QUẢN LÝ NHÂN SỰ - QUYẾT ĐỊNH ĐỔI THÔNG TIN ĐƠN VỊ");
                //        f.ShowDialog();
                //        break;
                //    case 6:
                //    case 7:
                //        f = new Forms.Popup(new HDQD.UCs.ThoiBoNhiem(), "QUẢN LÝ NHÂN SỰ - QUYẾT ĐỊNH THÔI BỔ NHIỆM");
                //        f.ShowDialog();
                //        break;
                //    case 8:
                //        f = new Forms.Popup(new HDQD.UCs.QuyetDinhPhuCap(), "QUẢN LÝ NHÂN SỰ - QUYẾT ĐỊNH CHUNG");
                //        f.ShowDialog();
                //        break;

                //    default:
                //        break;
                //} 
                #endregion

                string SelectedText = Convert.ToString(comB_Loai.SelectedText);
                HDQD.Forms.Popup f;
                if (SelectedText == "Kiêm nhiệm" || SelectedText == "Bổ nhiệm" || SelectedText == "Điều động" || SelectedText == "Quyết định chung")
                {
                    f = new Forms.Popup(new HDQD.UCs.QDChung(), "QUẢN LÝ NHÂN SỰ - QUYẾT ĐỊNH KIÊM NHIỆM - ĐIỀU ĐỘNG");
                    f.ShowDialog();
                }
                else if (SelectedText == "Đổi thông tin đơn vị")
                {
                    f = new Forms.Popup(new HDQD.UCs.DoiThongTinDV(), "QUẢN LÝ NHÂN SỰ - QUYẾT ĐỊNH ĐỔI THÔNG TIN ĐƠN VỊ");
                    f.ShowDialog();
                }
                else if (SelectedText == "Tách đơn vị") 
                {
                    f = new Forms.Popup(new HDQD.UCs.M_A(true), "QUẢN LÝ NHÂN SỰ - QUYẾT ĐỊNH TÁCH ĐƠN VỊ");
                    f.ShowDialog();
                }
                else if (SelectedText == "Gộp đơn vị")
                {
                    f = new Forms.Popup(new HDQD.UCs.M_A(false), "QUẢN LÝ NHÂN SỰ - QUYẾT ĐỊNH GỘP ĐƠN VỊ");
                    f.ShowDialog();
                }
                else if (SelectedText == "Tiếp nhận")
                {
                    f = new Forms.Popup(new HDQD.UCs.TiepNhan(), "QUẢN LÝ NHÂN SỰ - QUYẾT ĐỊNH TIẾP NHẬN");
                    f.ShowDialog();
                }

            }
            else
                MessageBox.Show("Vui lòng chọn một loại quyết định", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dtgv_DSQD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_DSQD.CurrentRow != null)
            {
                DataGridViewRow row = dtgv_DSQD.CurrentRow;
                int loai_qd = Convert.ToInt16(row.Cells["loai_qd_id"].Value.ToString());
                switch (loai_qd)
                {
                    case 10: //QĐ Tiếp nhận
                        Show_QD_TiepNhan(row);
                        break;
                    case 14: //QĐ THÔI VIỆC
                        break;
                    case 16: //QĐ THÀNH LẬP ĐƠN VỊ
                        break;
                    case 2: //QĐ BỔ NHIỆM
                        break;
                    case 1: //QĐ KIÊM NHIỆM
                        break;
                    case 3: //QĐ ĐIỀU ĐỘNG
                        break;
                    case 4: //QĐ ĐỔI THÔNG TIN ĐƠN VỊ
                        break;
                    case 5: //QĐ TÁCH ĐƠN VỊ
                        break;
                    case 9: //QĐ GỘP ĐƠN VỊ
                        break;
                    default:
                        Show_QD_Chung(row);
                        break;
                }
            }
        }

        private void Show_QD_TiepNhan(DataGridViewRow p_row)
        {
            try
            {
                string ma_qd = p_row.Cells["ma_quyet_dinh"].Value.ToString();
                Business.HDQD.CNVC_HopDong oHopDong = new Business.HDQD.CNVC_HopDong();
                DataTable dt = oHopDong.Search_QD_TiepNhan(ma_qd);

                if (dt.Rows.Count > 0)
                {
                    oHopDong.ID = Convert.ToInt16(dt.Rows[0]["id"].ToString());
                    oHopDong.Ma_NV = dt.Rows[0]["ma_nv"].ToString();
                    string cnvc_ho = dt.Rows[0]["ho"].ToString();
                    string cnvc_ten = dt.Rows[0]["ten"].ToString();

                    oHopDong.Ma_Tuyen_Dung = dt.Rows[0]["ma_hop_dong"].ToString();
                    oHopDong.La_QD_Tiep_Nhan = true;
                    oHopDong.Ten_Quyet_Dinh = p_row.Cells["ten"].Value.ToString();
                    oHopDong.Loai_QD_ID = Convert.ToInt16(p_row.Cells["loai_qd_id"].Value.ToString());
                    if (p_row.Cells["ngay_ky"].Value.ToString() != "")
                        oHopDong.Ngay_Ky = Convert.ToDateTime(p_row.Cells["ngay_ky"].Value.ToString());
                    if (p_row.Cells["ngay_hieu_luc"].Value.ToString() != "")
                        oHopDong.Ngay_Hieu_Luc = Convert.ToDateTime(p_row.Cells["ngay_hieu_luc"].Value.ToString());
                    if (p_row.Cells["ngay_het_han"].Value.ToString() != "")
                        oHopDong.Ngay_Het_Han = Convert.ToDateTime(p_row.Cells["ngay_het_han"].Value.ToString());
                    oHopDong.MoTa_QD = p_row.Cells["mo_ta"].Value.ToString();

                    oHopDong.Co_Thoi_Han = Convert.ToBoolean(dt.Rows[0]["co_thoi_han"].ToString());
                    
                    if (dt.Rows[0]["chuc_vu_chinh_id"].ToString() != "")
                        oHopDong.Chuc_Vu_ID = Convert.ToInt16(dt.Rows[0]["chuc_vu_chinh_id"].ToString());
                    oHopDong.Chuc_Vu = dt.Rows[0]["ten_chuc_vu"].ToString();

                    if (dt.Rows[0]["chuc_danh_chinh_id"].ToString() != "")
                        oHopDong.Chuc_Danh_ID = Convert.ToInt16(dt.Rows[0]["chuc_danh_chinh_id"].ToString());
                    oHopDong.Chuc_Danh = dt.Rows[0]["ten_chuc_danh"].ToString();

                    if (dt.Rows[0]["don_vi_chinh_id"].ToString() != "")
                        oHopDong.Don_Vi_ID = Convert.ToInt16(dt.Rows[0]["don_vi_chinh_id"].ToString());
                    oHopDong.Don_Vi = dt.Rows[0]["ten_don_vi"].ToString();
                    oHopDong.Tinh_Trang = Convert.ToBoolean(dt.Rows[0]["tinh_trang"].ToString());
                    oHopDong.Ghi_Chu = dt.Rows[0]["ghi_chu"].ToString();

                    if (dt.Rows[0]["tham_nien_nang_bac"].ToString() != "")
                        oHopDong.Tham_nien_nang_bac = Convert.ToBoolean(dt.Rows[0]["tham_nien_nang_bac"].ToString());
                    else
                        oHopDong.Tham_nien_nang_bac = false;

                    if (dt.Rows[0]["tham_nien_gd"].ToString() != "")
                        oHopDong.Tham_nien_nha_giao = Convert.ToBoolean(dt.Rows[0]["tham_nien_gd"].ToString());
                    else
                        oHopDong.Tham_nien_nha_giao = false;

                    #region Luong Info
                    oHopDong.Khoan_or_HeSo = Convert.ToBoolean(dt.Rows[0]["tinh_trang"].ToString());
                    if (dt.Rows[0]["luong_khoan"].ToString() != "")
                        oHopDong.Luong_Khoan = Convert.ToDouble(dt.Rows[0]["luong_khoan"].ToString());
                    if (dt.Rows[0]["ngach_bac_heso_id"].ToString() != "")
                        oHopDong.BacHeSo_ID = Convert.ToInt16(dt.Rows[0]["ngach_bac_heso_id"].ToString());
                    if (dt.Rows[0]["phan_tram_huong"].ToString() != "")
                        oHopDong.PhanTramHuong = Convert.ToDouble(dt.Rows[0]["phan_tram_huong"].ToString());
                    #endregion

                    oHopDong.Co_Phu_Cap = Convert.ToBoolean(dt.Rows[0]["co_phu_cap"].ToString());

                    UCs.TiepNhan tiepnhan = new TiepNhan(oHopDong, cnvc_ho, cnvc_ten);
                    Forms.Popup popup = new Forms.Popup(tiepnhan, "QUẢN LÝ NHÂN SỰ - QUYẾT ĐỊNH TIẾP NHẬN");
                    popup.Show();
                }
            }
            catch { }
            


        }

        private void Show_QD_Chung(DataGridViewRow p_row)
        {
            try
            {
                string ma_qd = p_row.Cells["ma_quyet_dinh"].Value.ToString();
                
                UCs.QDChung qdchung = new QDChung(ma_qd, true);
                Forms.Popup popup = new Forms.Popup(qdchung, "QUẢN LÝ NHÂN SỰ - QUYẾT ĐỊNH CHUNG");
                popup.Show();
                
            }
            catch { }



        }

    }
}
