using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business;
using System.Globalization;

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
            PrepTbl_DiDuongDetail();
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
            dtDiDuongDetail.Columns.Add("di_or_den", typeof(int));
            dtDiDuongDetail.Columns.Add("di_or_den_txt", typeof(string));
            dtDiDuongDetail.Columns.Add("dia_diem", typeof(string));
            dtDiDuongDetail.Columns.Add("ptdc_id", typeof(int));
            dtDiDuongDetail.Columns.Add("ptdc_txt", typeof(string));
            dtDiDuongDetail.Columns.Add("ngay_khoi_hanh", typeof(string));
            dtDiDuongDetail.Columns.Add("so_ngay_cong_tac", typeof(double));
            dtDiDuongDetail.Columns.Add("ly_do_luu_tru", typeof(string));
            dtDiDuongDetail.Columns.Add("ghi_chu", typeof(string));

        }

        private void Prepare_dtgv_DSDiDuongDetail(DataTable p_data)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = p_data;
            dtgv_DSDiDuongDetail.DataSource = bs;
            EditDtgInterface_DSDiDuongDetail();
        }

        private void EditDtgInterface_DSDiDuongDetail()
        {
            dtgv_DSDiDuongDetail.Columns["seq_id"].HeaderText = "Thứ tự";
            dtgv_DSDiDuongDetail.Columns["di_or_den_txt"].HeaderText = "Nơi đi/đến";
            dtgv_DSDiDuongDetail.Columns["dia_diem"].HeaderText = "Địa chỉ";
            dtgv_DSDiDuongDetail.Columns["ptdc_txt"].HeaderText = "Phương tiện";
            dtgv_DSDiDuongDetail.Columns["ngay_khoi_hanh"].HeaderText = "Ngày khởi hành";
            dtgv_DSDiDuongDetail.Columns["so_ngay_cong_tac"].HeaderText = "Số ngày CT";
            dtgv_DSDiDuongDetail.Columns["ly_do_luu_tru"].HeaderText = "Lý do lưu trú";

            // An cac cot ID
            dtgv_DSDiDuongDetail.Columns["ptdc_id"].Visible = false;
            dtgv_DSDiDuongDetail.Columns["di_or_den"].Visible = false;
            dtgv_DSDiDuongDetail.Columns["ghi_chu"].Visible = false;
        }

        private double TinhTongTien()
        {
            double m_sum = 0;
            m_sum = Convert.ToDouble(txt_Luong.Text == "" ? "0" : txt_Luong.Text) + Convert.ToDouble(txt_CongTacPhi.Text == "" ? "0" : txt_CongTacPhi.Text);

            return m_sum;
        }

        #endregion


        private void btn_Them_Click(object sender, EventArgs e)
        {

        }

        private void QDDiDuong_Load(object sender, EventArgs e)
        {
            PreapreDataSource();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                int mlast_di_den = -1;
                int mcurr_di_den = -1;
                if (dtDiDuongDetail.Rows.Count > 0)
                    mlast_di_den = Convert.ToInt32(dtDiDuongDetail.Rows[dtDiDuongDetail.Rows.Count - 1]["di_or_den"].ToString());

                if (comB_NoiDiNoiDen.Text == "Nơi đi")
                {
                    mcurr_di_den = 0;
                }
                else
                {
                    mcurr_di_den = 1;
                }

                if (comB_NoiDiNoiDen.Text != "" && (dtDiDuongDetail.Rows.Count == 0 || (mlast_di_den != mcurr_di_den)))
                {
                    DataRow dr = dtDiDuongDetail.NewRow();
                    dr["seq_id"] = dtDiDuongDetail.Rows.Count + 1;
                    dr["ptdc_id"] = Convert.ToInt32(comB_PhuongTien.SelectedValue.ToString());
                    dr["ptdc_txt"] = comB_PhuongTien.Text;

                    if (comB_NoiDiNoiDen.Text == "Nơi đi")
                    {
                        dr["di_or_den"] = 0;
                        dr["di_or_den_txt"] = "Nơi đi";
                    }
                    else
                    {
                        dr["di_or_den"] = 1;
                        dr["di_or_den_txt"] = "Nơi đến";
                    }

                    dr["dia_diem"] = txt_DiaChi.Text.Trim();
                    dr["ngay_khoi_hanh"] = dtp_Ngay.Value.ToString("d", CultureInfo.CreateSpecificCulture("vi-VN"));
                    dr["so_ngay_cong_tac"] = Convert.ToDouble(txt_SoNgayCongTac.Text);
                    dr["ly_do_luu_tru"] = rtB_LyDoLuuTru.Text;
                    dr["ghi_chu"] = null;

                    dtDiDuongDetail.Rows.Add(dr);
                    Prepare_dtgv_DSDiDuongDetail(dtDiDuongDetail);
                }
                else
                    MessageBox.Show("Thứ tự Nơi đi/đến không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi trong quá trình nhập liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            try
            {
                int select_row = Convert.ToInt32(dtgv_DSDiDuongDetail.CurrentRow.Cells["seq_id"].Value.ToString());
                if (select_row == dtDiDuongDetail.Rows.Count)
                {
                    DataRow[] drr = dtDiDuongDetail.Select("seq_id=" + select_row);
                    foreach (DataRow row in drr)
                        row.Delete();

                    dtDiDuongDetail.AcceptChanges();
                    Prepare_dtgv_DSDiDuongDetail(dtDiDuongDetail);
                }
                else
                    MessageBox.Show("Không thể xóa dữ liệu được chọn. Vui lòng xóa từ dữ liệu mới nhất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn dòng dữ liệu cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_Luong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txt_Luong_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_Luong.Text) &&
                e.KeyCode != Keys.Left && e.KeyCode != Keys.Right &&
                e.KeyCode != Keys.Up && e.KeyCode != Keys.Down)
            {
                txt_Luong.Text = Convert.ToDouble(txt_Luong.Text).ToString("#,#");
                txt_Luong.SelectionStart = txt_Luong.TextLength;
            }
        }

        private void txt_CongTacPhi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txt_CongTacPhi_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_CongTacPhi.Text) &&
                e.KeyCode != Keys.Left && e.KeyCode != Keys.Right &&
                e.KeyCode != Keys.Up && e.KeyCode != Keys.Down)
            {
                txt_CongTacPhi.Text = Convert.ToDouble(txt_CongTacPhi.Text).ToString("#,#");
                txt_CongTacPhi.SelectionStart = txt_CongTacPhi.TextLength;
            }
        }

        private void txt_Luong_Leave(object sender, EventArgs e)
        {
            txt_TongCong.Text = TinhTongTien().ToString("#,#");
        }

        private void txt_CongTacPhi_Leave(object sender, EventArgs e)
        {
            txt_TongCong.Text = TinhTongTien().ToString("#,#");
        }
    }
}
