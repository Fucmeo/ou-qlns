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
    public partial class DanhSachHopDong : UserControl
    {
        Business.HDQD.CNVC_HopDong oHopDong;
        DataTable dtDSHopDong;
        Business.HDQD.LoaiHopDong oLoaiHopDong;
        DataTable dtDSLoaiHopDong;

        public DanhSachHopDong()
        {
            InitializeComponent();
            oHopDong = new Business.HDQD.CNVC_HopDong();
            oLoaiHopDong = new Business.HDQD.LoaiHopDong();

        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            string ma_nv = txt_MaNV.Text == "" ? null : txt_MaNV.Text;
            string ma_hd = txt_MaHD.Text == "" ? null : txt_MaHD.Text;
            int? ma_loai_hd = null;
            if (comB_Loai.Text != "")
                ma_loai_hd = Convert.ToInt16(comB_Loai.SelectedValue);

            bool? co_thoi_han = null;
            if (comB_CoThoiHan.Text == "Có thời hạn")
                co_thoi_han = true;
            else if (comB_CoThoiHan.Text == "Không thời hạn")
                co_thoi_han = false;
            else
                co_thoi_han = null;
            
            DateTime? ngay_ky_tu = null;
            DateTime? ngay_ky_den = null;
            if (dTP_TuNgay.Checked == true)
            {
                ngay_ky_tu = dTP_TuNgay.Value;
                ngay_ky_den = dTP_DenNgay.Value;
            }

            try
            {
                dtDSHopDong = oHopDong.Search_HD(ma_nv, ma_hd, ma_loai_hd, co_thoi_han, ngay_ky_tu, ngay_ky_den);
                //dtDSHopDong = oHopDong.Search_HD(ma_nv, ma_hd, ma_loai_hd, ngay_ky_tu, ngay_ky_den);
                if (dtDSHopDong != null)
                {
                    PrepareDataSource();
                    EditDtgInterface();
                    if (dtDSHopDong.Rows.Count != 0)
                        ResetInterface(true);
                    else
                        ResetInterface(false);
                }
            }
            catch { }
        }

        private void DanhSachHopDong_Load(object sender, EventArgs e)
        {
            dtDSLoaiHopDong = oLoaiHopDong.GetList_Compact();
            PrepareCboLoaiHD();
        }

        #region Private Methods
        private void PrepareCboLoaiHD()
        {
            DataRow row = dtDSLoaiHopDong.NewRow();
            dtDSLoaiHopDong.Rows.InsertAt(row, 0);
            //BindingSource bs = new BindingSource();
            //bs.DataSource = dtDSLoaiQuyetDinh;
            comB_Loai.DataSource = dtDSLoaiHopDong;
            comB_Loai.DisplayMember = "loai_hop_dong";
            comB_Loai.ValueMember = "id";

        }

        private void PrepareDataSource()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dtDSHopDong;
            dtgv_DSHD.DataSource = bs;
            //lbl_SoLoaiPC.Text = dtgv_DSLoaiPC.Rows.Count.ToString();
            if (dtDSHopDong != null)
            {
                btn_Xoa.Enabled = true;
            }
        }

        /// <summary>
        /// Sua ten, an  cac cot cua dtg cho phu hop
        /// </summary>
        private void EditDtgInterface()
        {
            // Dat ten cho cac cot
            dtgv_DSHD.Columns["id"].HeaderText = "ID";
            dtgv_DSHD.Columns["ma_nv"].HeaderText = "Mã nhân viên";
            dtgv_DSHD.Columns["ma_nv"].Width = 200;
            dtgv_DSHD.Columns["ma_hop_dong"].HeaderText = "Mã hợp đồng";
            dtgv_DSHD.Columns["ma_hop_dong"].Width = 200;
            dtgv_DSHD.Columns["ma_loai_hd"].HeaderText = "Mã loại Hợp đồng";
            dtgv_DSHD.Columns["loai_hop_dong"].HeaderText = "Loại hợp đồng";
            dtgv_DSHD.Columns["loai_hop_dong"].Width = 200;
            dtgv_DSHD.Columns["co_thoi_han"].HeaderText = "Có thời hạn";
            dtgv_DSHD.Columns["co_thoi_han"].Width = 100;
            dtgv_DSHD.Columns["ngay_ky"].HeaderText = "Ngày ký";
            dtgv_DSHD.Columns["ngay_ky"].Width = 100;
            dtgv_DSHD.Columns["ngay_hieu_luc"].HeaderText = "Ngày hiệu lực";
            dtgv_DSHD.Columns["ngay_hieu_luc"].Width = 100;
            dtgv_DSHD.Columns["ngay_het_han"].HeaderText = "Ngày hết hạn";
            dtgv_DSHD.Columns["ngay_het_han"].Width = 100;
            dtgv_DSHD.Columns["chuc_vu_chinh_id"].HeaderText = "Chức vụ ID";
            dtgv_DSHD.Columns["ten_chuc_vu"].HeaderText = "Tên chức vụ";
            dtgv_DSHD.Columns["ten_chuc_vu"].Width = 100;
            dtgv_DSHD.Columns["chuc_danh_chinh_id"].HeaderText = "Chức danh ID";
            dtgv_DSHD.Columns["ten_chuc_danh"].HeaderText = "Tên chức danh";
            dtgv_DSHD.Columns["ten_chuc_danh"].Width = 100;
            dtgv_DSHD.Columns["don_vi_chinh_id"].HeaderText = "Đơn vị ID";
            dtgv_DSHD.Columns["ten_don_vi"].HeaderText = "Tên đơn vị";
            dtgv_DSHD.Columns["ten_don_vi"].Width = 100;
            dtgv_DSHD.Columns["tinh_trang"].HeaderText = "Tình trạng";
            dtgv_DSHD.Columns["tinh_trang"].Width = 100;
            dtgv_DSHD.Columns["ghi_chu"].HeaderText = "Ghi chú";
            //dtgv_DSHD.Columns[17].HeaderText = "Ngày hết hạn ADJ";
            // An cot ID
            dtgv_DSHD.Columns["id"].Visible = false;
            dtgv_DSHD.Columns["ma_loai_hd"].Visible = false;
            dtgv_DSHD.Columns["chuc_vu_chinh_id"].Visible = false;
            dtgv_DSHD.Columns["chuc_danh_chinh_id"].Visible = false;
            dtgv_DSHD.Columns["don_vi_chinh_id"].Visible = false;
            dtgv_DSHD.Columns["ghi_chu"].Visible = false;
            //dtgv_DSHD.Columns[17].Visible = false;
            dtgv_DSHD.Columns["khoan_or_heso"].Visible = false;
            dtgv_DSHD.Columns["luong_khoan"].Visible = false;
            dtgv_DSHD.Columns["ngach_bac_heso_id"].Visible = false;
            dtgv_DSHD.Columns["phan_tram_huong"].Visible = false;
            dtgv_DSHD.Columns["tham_nien_nang_bac"].Visible = false;
            dtgv_DSHD.Columns["tham_nien_gd"].Visible = false;

        }

        private void ResetInterface(bool init)
        {
            btn_Xoa.Enabled = init;
            //btn_TaiFile.Enabled = init;
        }

        /// <summary>
        /// Su dung thong tin row dang chon de hien thi len txt, comb,..
        /// </summary>
        /// <param name="row"></param>
        private void DisplayInfo(DataGridViewRow row)
        {
            if (row != null)
            {
                txt_MaNV2.Text = row.Cells[1].Value.ToString();
                txt_MaHD2.Text = row.Cells[2].Value.ToString();
                txt_Loai.Text = row.Cells[4].Value.ToString();
                txt_NgayKy.Text = row.Cells[6].Value.ToString() == "" ? "" : Convert.ToDateTime(row.Cells[6].Value.ToString()).ToShortDateString();
                txt_NgayHieuLuc.Text = row.Cells[7].Value.ToString() == "" ? "" : Convert.ToDateTime(row.Cells[7].Value.ToString()).ToShortDateString();
                txt_NgayHetHan.Text = row.Cells[8].Value.ToString() == "" ? "" : Convert.ToDateTime(row.Cells[8].Value.ToString()).ToShortDateString();
            }
        }

        /// <summary>
        /// Refresh Data Source cho dtg sau moi lan thao tac
        /// </summary>
        private void RefreshDataSource()
        {
            Business.HDQD.CNVC_HopDong hopdong = new Business.HDQD.CNVC_HopDong();    // khong dung chung oChucVu duoc ???
            
            string ma_nv = txt_MaNV.Text == "" ? null : txt_MaNV.Text;
            string ma_hd = txt_MaHD.Text == "" ? null : txt_MaHD.Text;
            int? ma_loai_hd = null;
            if (comB_Loai.Text != "")
                ma_loai_hd = Convert.ToInt16(comB_Loai.SelectedValue);

            bool? co_thoi_han = null;
            if (comB_CoThoiHan.Text == "Có thời hạn")
                co_thoi_han = true;
            else if (comB_CoThoiHan.Text == "Không thời hạn")
                co_thoi_han = false;
            else
                co_thoi_han = null;
            
            DateTime? ngay_ky_tu = null;
            DateTime? ngay_ky_den = null;
            if (dTP_TuNgay.Checked == true)
            {
                ngay_ky_tu = dTP_TuNgay.Value;
                ngay_ky_den = dTP_DenNgay.Value;
            }

            dtDSHopDong = hopdong.Search_HD(ma_nv, ma_hd, ma_loai_hd, co_thoi_han, ngay_ky_tu, ngay_ky_den);
            //dtDSHopDong = hopdong.Search_HD(ma_nv, ma_hd, ma_loai_hd, ngay_ky_tu, ngay_ky_den);
            PrepareDataSource();

        }
        #endregion

        private void dTP_TuNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dTP_TuNgay.Checked == true)
                dTP_DenNgay.Enabled = true;
            else
                dTP_DenNgay.Enabled = false;
        }

        private void dtgv_DSHD_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgv_DSHD.CurrentRow != null)
            {
                DisplayInfo(dtgv_DSHD.CurrentRow);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (dtgv_DSHD.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn thực sự muốn xoá quyết định này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        oHopDong.Ma_NV = dtgv_DSHD.CurrentRow.Cells[1].Value.ToString();
                        oHopDong.Ma_Hop_Dong = dtgv_DSHD.CurrentRow.Cells[2].Value.ToString();
                        if (oHopDong.Delete())
                        {
                            MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        RefreshDataSource();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            UCs.HopDong hopdong = new HopDong();
            Forms.Popup popup = new Forms.Popup(hopdong, "QUẢN LÝ NHÂN SỰ - HỢP ĐỒNG");
            popup.ShowDialog();
        }

        private void dtgv_DSHD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_DSHD.CurrentRow != null)
            {
                DataGridViewRow row = dtgv_DSHD.CurrentRow;
                oHopDong = new Business.HDQD.CNVC_HopDong();
                oHopDong.ID = Convert.ToInt16(row.Cells["id"].Value.ToString());
                oHopDong.Ma_NV = row.Cells["ma_nv"].Value.ToString();
                oHopDong.Ma_Tuyen_Dung = row.Cells["ma_hop_dong"].Value.ToString();
                oHopDong.La_QD_Tiep_Nhan = false;
                oHopDong.Ma_Loai_HD = Convert.ToInt16(row.Cells["ma_loai_hd"].Value.ToString());
                oHopDong.Loai_Hop_Dong = row.Cells["loai_hop_dong"].Value.ToString();
                oHopDong.Co_Thoi_Han = Convert.ToBoolean(row.Cells["co_thoi_han"].Value.ToString());
                if (row.Cells["ngay_ky"].Value.ToString() != "")
                    oHopDong.Ngay_Ky = Convert.ToDateTime(row.Cells["ngay_ky"].Value.ToString());
                if (row.Cells["ngay_hieu_luc"].Value.ToString() != "")
                    oHopDong.Ngay_Hieu_Luc = Convert.ToDateTime(row.Cells["ngay_hieu_luc"].Value.ToString());
                if (row.Cells["ngay_het_han"].Value.ToString() != "")
                    oHopDong.Ngay_Het_Han = Convert.ToDateTime(row.Cells["ngay_het_han"].Value.ToString());
                if (row.Cells["chuc_vu_chinh_id"].Value.ToString() != "")
                    oHopDong.Chuc_Vu_ID = Convert.ToInt16(row.Cells["chuc_vu_chinh_id"].Value.ToString());
                oHopDong.Chuc_Vu = row.Cells["ten_chuc_vu"].Value.ToString();

                if (row.Cells["chuc_danh_chinh_id"].Value.ToString() != "")
                    oHopDong.Chuc_Danh_ID = Convert.ToInt16(row.Cells["chuc_danh_chinh_id"].Value.ToString());
                oHopDong.Chuc_Danh = row.Cells["ten_chuc_danh"].Value.ToString();

                if (row.Cells["don_vi_chinh_id"].Value.ToString() != "")
                    oHopDong.Don_Vi_ID = Convert.ToInt16(row.Cells["don_vi_chinh_id"].Value.ToString());
                oHopDong.Don_Vi = row.Cells["ten_don_vi"].Value.ToString();
                oHopDong.Tinh_Trang = Convert.ToBoolean(row.Cells["tinh_trang"].Value.ToString());
                oHopDong.Ghi_Chu = row.Cells["ghi_chu"].Value.ToString();

                if (row.Cells["tham_nien_nang_bac"].Value.ToString() != "")
                    oHopDong.Tham_nien_nang_bac = Convert.ToBoolean(row.Cells["tham_nien_nang_bac"].Value.ToString());
                else
                    oHopDong.Tham_nien_nang_bac = false;
                if (row.Cells["tham_nien_gd"].Value.ToString() != "")
                    oHopDong.Tham_nien_nha_giao = Convert.ToBoolean(row.Cells["tham_nien_gd"].Value.ToString());
                else
                    oHopDong.Tham_nien_nha_giao = false;

                #region Luong Info
                oHopDong.Khoan_or_HeSo = Convert.ToBoolean(row.Cells["tinh_trang"].Value.ToString());
                if (row.Cells["luong_khoan"].Value.ToString() != "")
                    oHopDong.Luong_Khoan = Convert.ToDouble(row.Cells["luong_khoan"].Value.ToString());
                if (row.Cells["ngach_bac_heso_id"].Value.ToString() != "")
                    oHopDong.BacHeSo_ID = Convert.ToInt16(row.Cells["ngach_bac_heso_id"].Value.ToString());
                if (row.Cells["phan_tram_huong"].Value.ToString() != "")
                    oHopDong.PhanTramHuong = Convert.ToDouble(row.Cells["phan_tram_huong"].Value.ToString());
                #endregion

                UCs.HopDong hopdong = new HopDong(oHopDong);
                Forms.Popup popup = new Forms.Popup(hopdong, "QUẢN LÝ NHÂN SỰ - HỢP ĐỒNG");
                popup.Show();
            }
        }
    }
}
