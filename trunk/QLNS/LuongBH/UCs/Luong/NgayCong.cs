using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace LuongBH.UCs.Luong
{
    public partial class NgayCong : UserControl
    {
        Business.ChucDanh oChucDanh;
        Business.ChucVu oChucVu;
        Business.DonVi oDonVi;
        Business.CNVC.CNVC oCNCV;
        DataTable dtNgayCong, dtChucDanh, dtDonVi, dtChucVu, dtNV, dtSelectedNV;

        public NgayCong()
        {
            InitializeComponent();
            oDonVi = new Business.DonVi();
            oCNCV = new Business.CNVC.CNVC();
            oChucDanh = new Business.ChucDanh();
            oChucVu = new Business.ChucVu();
            dtChucDanh = new DataTable();
            dtDonVi = new DataTable();
            dtChucVu = new DataTable();
            dtNgayCong = new DataTable();
            dtNV = new DataTable();
        }

        private void NgayCong_Load(object sender, EventArgs e)
        {
            //LoadBindCBFilter();

            GetBindNgayCongInfo();
        }

        private void GetBindNgayCongInfo()
        {
            try
            {
                dtNgayCong = oCNCV.GetNgayCong();
                dtgv_ThongTinNP.DataSource = dtNgayCong;

                SetupDTGV();
            }
            catch (Exception)
            {
            }
        }

        private void LoadBindCBFilter()
        {
            //try
            //{
            //    dtChucVu = oChucVu.GetList();
            //    dtChucDanh = oChucDanh.GetList();

            //    dtDonVi = oDonVi.GetActiveDonVi();
            //    DataRow dr = dtDonVi.NewRow();
            //    dr["ten_don_vi"] = "";
            //    dr["id"] = -1;
            //    dtDonVi.Rows.InsertAt(dr, 0);

            //    comB_DonVi.DataSource = dtDonVi;
            //    comB_DonVi.DisplayMember = "ten_don_vi";
            //    comB_DonVi.ValueMember = "id";
            //    comB_DonVi.SelectedValue = -1;

            //    comB_ChucDanh.DataSource = dtChucDanh;
            //    comB_ChucDanh.DisplayMember = "ten_chuc_danh";
            //    comB_ChucDanh.ValueMember = "id";
            //    comB_ChucDanh.SelectedValue = -1;

            //    comB_ChucVu.DataSource = dtChucVu;
            //    comB_ChucVu.DisplayMember = "ten_chuc_vu";
            //    comB_ChucVu.ValueMember = "id";
            //    comB_ChucVu.SelectedValue = -1;
            //}
            //catch (Exception)
            //{

            //}
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(comB_DonVi.SelectedValue) == -1 && Convert.ToInt32(comB_ChucVu.SelectedValue) == -1 && Convert.ToInt32(comB_ChucDanh.SelectedValue) == -1
            //        && txt_Ho.Text == "" && txt_MaNV.Text == "" && txt_Ten.Text == "")
            //{
            //    MessageBox.Show("Xin vui lòng điền thông tin tìm kiếm. ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    try
            //    {
            //        lsb_KQ.Items.Clear();
            //        lsb_DSNV.Items.Clear();

            //        dtNV = oCNCV.SearchNVForNgayPhep(Convert.ToInt32(comB_DonVi.SelectedValue), Convert.ToInt32(comB_ChucVu.SelectedValue), Convert.ToInt32(comB_ChucDanh.SelectedValue),
            //                                            txt_Ho.Text, txt_Ten.Text, txt_MaNV.Text);

            //        for (int i = 0; i < dtNV.Rows.Count; i++)
            //        {
            //            if (!lsb_KQ.Items.Contains(dtNV.Rows[i]["ho_ten_ma"]))
            //                lsb_KQ.Items.Add(dtNV.Rows[i]["ho_ten_ma"]);
            //        }

            //        //lsb_KQ.DataSource = dtNV;
            //        //lsb_KQ.DisplayMember = "ho_ten_ma";
            //        //lsb_KQ.ValueMember = "ma_nv";
            //    }
            //    catch (Exception)
            //    {

            //    }
            //}
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            //if (lsb_KQ.SelectedItems != null && lsb_KQ.SelectedItems.Count > 0)
            //{
            //    for (int i = 0; i < lsb_KQ.SelectedItems.Count; i++)
            //    {
            //        if (!lsb_DSNV.Items.Contains(lsb_KQ.SelectedItems[i]))
            //        {
            //            lsb_DSNV.Items.Add(lsb_KQ.SelectedItems[i]);
            //        }
            //    }
            //    lsb_KQ.SelectedItems.Clear();
            //}

            //if (lsb_DSNV.Items.Count > 0)
            //{
            //    dtp_DenThang.Enabled = dtp_TuThang.Enabled
            //        = txt_SoNgayCong.Enabled = btn_Them.Enabled = true;
            //}
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            //if (lsb_DSNV.SelectedItems != null && lsb_DSNV.SelectedItems.Count > 0)
            //{
            //    for (int i = 0; i < lsb_DSNV.SelectedItems.Count; i++)
            //    {
            //        lsb_DSNV.Items.RemoveAt(lsb_DSNV.Items.IndexOf(lsb_DSNV.SelectedItems[i]));
            //    }
            //}

            //if (lsb_DSNV.Items.Count <= 0)
            //{
            //    dtp_DenThang.Enabled = dtp_TuThang.Enabled
            //        = txt_SoNgayCong.Enabled = btn_Them.Enabled = false;
            //}
        }

        private void dtp_TuThang_ValueChanged(object sender, EventArgs e)
        {
            dtp_DenThang.Value = dtp_TuThang.Value;
        }

        private void lsb_DSNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (lsb_DSNV.SelectedItems.Count == 1)
            //{
            //    try
            //    {
            //        string ho_ten_ma = lsb_DSNV.SelectedItem.ToString();
            //        string ma_nv = ho_ten_ma.Substring(ho_ten_ma.LastIndexOf(" - ") + 3, ho_ten_ma.Length - ho_ten_ma.LastIndexOf(" - ") - 3);

            //        DataTable dt = (from r in dtNV.AsEnumerable()
            //                        where r.Field<string>("ma_nv") == ma_nv
            //                        select r).CopyToDataTable();

            //        dtgv_ThongTinNP.DataSource = dt;
            //        SetupDTGV();
            //    }
            //    catch (Exception)
            //    {

            //    }


            //}
        }

        private void SetupDTGV()
        {
            dtgv_ThongTinNP.Columns["tu_thoi_gian_format"].Width = 100;
            dtgv_ThongTinNP.Columns["tu_thoi_gian_format"].HeaderText = "Từ tháng";
            dtgv_ThongTinNP.Columns["den_thoi_gian_format"].Width = 100;
            dtgv_ThongTinNP.Columns["den_thoi_gian_format"].HeaderText = "Đến tháng";
            dtgv_ThongTinNP.Columns["so_ngay_lam_viec"].Width = 100;
            dtgv_ThongTinNP.Columns["so_ngay_lam_viec"].HeaderText = "Số ngày làm việc";
            dtgv_ThongTinNP.Columns["ghi_chu"].Width = 200;
            dtgv_ThongTinNP.Columns["ghi_chu"].HeaderText = "Ghi chú";

            dtgv_ThongTinNP.Columns["id"].Visible =
                 dtgv_ThongTinNP.Columns["tu_thoi_gian"].Visible =
                  dtgv_ThongTinNP.Columns["den_thoi_gian"].Visible = false;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            #region MyRegion
            //if (lsb_DSNV.Items.Count > 0 && MessageBox.Show("Bạn muốn lưu số ngày nghỉ cho các nhân viên trên ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    string[] ma_nv = new string[lsb_DSNV.Items.Count];

            //    for (int i = 0; i < lsb_DSNV.Items.Count; i++)
            //    {
            //        string ho_ten_ma = lsb_DSNV.SelectedItem.ToString();
            //        ma_nv[i] = ho_ten_ma.Substring(ho_ten_ma.LastIndexOf(" - ") + 3, ho_ten_ma.Length - ho_ten_ma.LastIndexOf(" - ") - 3);
            //    }

            //    try
            //    {
            //        oCNCV.AddNgayPhep(ma_nv, dtp_TuThang.Value.Year, dtp_DenThang.Value.Year, Convert.ToDouble(txt_SoNgayCong.Text));
            //        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        dtgv_ThongTinNP.DataSource = null;
            //        lsb_KQ.Items.Clear();
            //        lsb_DSNV.Items.Clear();
            //    }
            //    catch (Exception)
            //    {
            //        MessageBox.Show("Thêm không thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //} 
            #endregion

            if (txt_SoNgayCong.Text.Length > 0 && MessageBox.Show("Bạn muốn lưu " + txt_SoNgayCong.Text + " ngày công từ tháng " + dtp_TuThang.Value.Month + "/" + dtp_TuThang.Value.Year + " đến tháng " + dtp_DenThang.Value.Month + "/" + dtp_DenThang.Value.Year + " ? ", "Hỏi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int tu = Convert.ToInt32(dtp_TuThang.Value.Year.ToString() + dtp_TuThang.Value.Month.ToString() );
                    int den = Convert.ToInt32(dtp_DenThang.Value.Year.ToString() + dtp_DenThang.Value.Month.ToString());
                    oCNCV.AddNgayCong(Convert.ToInt16(txt_SoNgayCong.Text.Trim()),tu,den,rtb_GhiChu.Text);
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetBindNgayCongInfo();
                }
                catch (Exception)
                {
                    MessageBox.Show("Thêm không thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
            }
        }

        private void txt_SoNgayCong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void dtgv_ThongTinNP_SelectionChanged(object sender, EventArgs e)
        {
           
            try
            {
                if (dtgv_ThongTinNP.SelectedRows.Count >0)
                {
                    DataGridViewRow r = dtgv_ThongTinNP.SelectedRows[0];
                    int m_idx = (r.Cells["tu_thoi_gian"].Value.ToString().Length == 6) ? 2 : 1;
                    DateTime t = new DateTime(Convert.ToInt16(r.Cells["tu_thoi_gian"].Value.ToString().Substring(m_idx, 4)),
                                                    Convert.ToInt16(r.Cells["tu_thoi_gian"].Value.ToString().Substring(0, m_idx)), 1);
                    dtp_TuThang.Value = t;

                    t = new DateTime(Convert.ToInt16(r.Cells["den_thoi_gian"].Value.ToString().Substring(m_idx, 4)),
                                                    Convert.ToInt16(r.Cells["den_thoi_gian"].Value.ToString().Substring(0, m_idx)), 1);
                    dtp_DenThang.Value = t;
                    txt_SoNgayCong.Text = Convert.ToString(r.Cells["so_ngay_lam_viec"].Value);
                    rtb_GhiChu.Text = Convert.ToString(r.Cells["ghi_chu"].Value);
                }
                
            }
            catch (Exception)
            {
                
            }
        }


    }
}
