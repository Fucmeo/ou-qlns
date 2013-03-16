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

            bool? thuviec_chinhthuc = null;
            if (comB_ThuviecChinhthuc.Text == "Chính thức")
                thuviec_chinhthuc = true;
            else if (comB_ThuviecChinhthuc.Text == "Thử việc")
                thuviec_chinhthuc = false;
            else
                thuviec_chinhthuc = null;
            
            DateTime? ngay_ky_tu = null;
            DateTime? ngay_ky_den = null;
            if (dTP_TuNgay.Checked == true)
            {
                ngay_ky_tu = dTP_TuNgay.Value;
                ngay_ky_den = dTP_DenNgay.Value;
            }

            try
            {
                dtDSHopDong = oHopDong.Search_HD(ma_nv, ma_hd, ma_loai_hd, thuviec_chinhthuc, ngay_ky_tu, ngay_ky_den);
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
            dtgv_DSHD.Columns[0].HeaderText = "ID";
            dtgv_DSHD.Columns[1].HeaderText = "Mã nhân viên";
            dtgv_DSHD.Columns[1].Width = 200;
            dtgv_DSHD.Columns[2].HeaderText = "Mã hợp đồng";
            dtgv_DSHD.Columns[2].Width = 200;
            dtgv_DSHD.Columns[3].HeaderText = "Mã loại Hợp đồng";
            dtgv_DSHD.Columns[4].HeaderText = "Loại hợp đồng";
            dtgv_DSHD.Columns[4].Width = 200;
            dtgv_DSHD.Columns[5].HeaderText = "Thử việc/Chính thức";
            dtgv_DSHD.Columns[5].Width = 100;
            dtgv_DSHD.Columns[6].HeaderText = "Ngày ký";
            dtgv_DSHD.Columns[6].Width = 100;
            dtgv_DSHD.Columns[7].HeaderText = "Ngày hiệu lực";
            dtgv_DSHD.Columns[7].Width = 100;
            dtgv_DSHD.Columns[8].HeaderText = "Ngày hết hạn";
            dtgv_DSHD.Columns[8].Width = 100;
            dtgv_DSHD.Columns[9].HeaderText = "Chức vụ ID";
            dtgv_DSHD.Columns[10].HeaderText = "Tên chức vụ";
            dtgv_DSHD.Columns[10].Width = 100;
            dtgv_DSHD.Columns[11].HeaderText = "Chức danh ID";
            dtgv_DSHD.Columns[12].HeaderText = "Tên chức danh";
            dtgv_DSHD.Columns[12].Width = 100;
            dtgv_DSHD.Columns[13].HeaderText = "Đơn vị ID";
            dtgv_DSHD.Columns[14].HeaderText = "Tên đơn vị";
            dtgv_DSHD.Columns[14].Width = 100;
            dtgv_DSHD.Columns[15].HeaderText = "Tình trạng";
            dtgv_DSHD.Columns[15].Width = 100;
            dtgv_DSHD.Columns[16].HeaderText = "Ghi chú";
            //dtgv_DSHD.Columns[17].HeaderText = "Ngày hết hạn ADJ";
            // An cot ID
            dtgv_DSHD.Columns[0].Visible = false;
            dtgv_DSHD.Columns[3].Visible = false;
            dtgv_DSHD.Columns[9].Visible = false;
            dtgv_DSHD.Columns[11].Visible = false;
            dtgv_DSHD.Columns[13].Visible = false;
            dtgv_DSHD.Columns[16].Visible = false;
            //dtgv_DSHD.Columns[17].Visible = false;
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

            bool? thuviec_chinhthuc = null;
            if (comB_ThuviecChinhthuc.Text == "Chính thức")
                thuviec_chinhthuc = true;
            else if (comB_ThuviecChinhthuc.Text == "Thử việc")
                thuviec_chinhthuc = false;
            else
                thuviec_chinhthuc = null;
            
            DateTime? ngay_ky_tu = null;
            DateTime? ngay_ky_den = null;
            if (dTP_TuNgay.Checked == true)
            {
                ngay_ky_tu = dTP_TuNgay.Value;
                ngay_ky_den = dTP_DenNgay.Value;
            }

            dtDSHopDong = hopdong.Search_HD(ma_nv, ma_hd, ma_loai_hd, thuviec_chinhthuc, ngay_ky_tu, ngay_ky_den);
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
            popup.Show();
        }

        private void dtgv_DSHD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_DSHD.CurrentRow != null)
            {
                DataGridViewRow row = dtgv_DSHD.CurrentRow;
                oHopDong = new Business.HDQD.CNVC_HopDong();
                oHopDong.ID = Convert.ToInt16(row.Cells[0].Value.ToString());
                oHopDong.Ma_NV = row.Cells[1].Value.ToString();
                oHopDong.Ma_Hop_Dong = row.Cells[2].Value.ToString();
                oHopDong.Ma_Loai_HD = Convert.ToInt16(row.Cells[3].Value.ToString());
                oHopDong.Loai_Hop_Dong = row.Cells[4].Value.ToString();
                oHopDong.ThuViec_ChinhThuc = Convert.ToBoolean(row.Cells[5].Value.ToString());
                if (row.Cells[6].Value.ToString() != "")
                    oHopDong.Ngay_Ky = Convert.ToDateTime(row.Cells[6].Value.ToString());
                if (row.Cells[7].Value.ToString() != "")
                    oHopDong.Ngay_Hieu_Luc = Convert.ToDateTime(row.Cells[7].Value.ToString());
                if (row.Cells[8].Value.ToString() != "")
                    oHopDong.Ngay_Het_Han = Convert.ToDateTime(row.Cells[8].Value.ToString());
                if (row.Cells[9].Value.ToString() != "")
                    oHopDong.Chuc_Vu_ID = Convert.ToInt16(row.Cells[9].Value.ToString());
                oHopDong.Chuc_Vu = row.Cells[10].Value.ToString();
                if (row.Cells[11].Value.ToString() != "")
                    oHopDong.Chuc_Danh_ID = Convert.ToInt16(row.Cells[11].Value.ToString());
                oHopDong.Chuc_Danh = row.Cells[12].Value.ToString();
                if (row.Cells[13].Value.ToString() != "")
                    oHopDong.Don_Vi_ID = Convert.ToInt16(row.Cells[13].Value.ToString());
                oHopDong.Don_Vi = row.Cells[14].Value.ToString();
                oHopDong.Tinh_Trang = Convert.ToBoolean(row.Cells[15].Value.ToString());
                oHopDong.Ghi_Chu = row.Cells[16].Value.ToString();

                UCs.HopDong hopdong = new HopDong(oHopDong);
                Forms.Popup popup = new Forms.Popup(hopdong, "QUẢN LÝ NHÂN SỰ - HỢP ĐỒNG");
                popup.Show();
            }
        }
    }
}
