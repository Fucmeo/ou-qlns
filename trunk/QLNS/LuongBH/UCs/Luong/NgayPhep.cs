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
    public partial class NgayPhep : UserControl
    {
        Business.ChucDanh oChucDanh;
        Business.ChucVu oChucVu;
        Business.DonVi oDonVi;
        Business.CNVC.CNVC oCNCV;
        DataTable dtChucDanh, dtDonVi, dtChucVu , dtNV ,dtSelectedNV ;
        public NgayPhep()
        {
            InitializeComponent();
            oDonVi = new Business.DonVi();
            oCNCV = new Business.CNVC.CNVC();
            oChucDanh = new Business.ChucDanh();
            oChucVu = new Business.ChucVu();
            dtChucDanh = new DataTable();
            dtDonVi = new DataTable();
            dtChucVu = new DataTable();
            dtNV = new DataTable();
            dtSelectedNV = new DataTable();
            dtSelectedNV.Columns.Add("ma_nv", typeof(string));
        }

        private void NgayPhep_Load(object sender, EventArgs e)
        {
            LoadBindCBFilter();
        }

        private void LoadBindCBFilter()
        {
            try
            {
                dtChucVu = oChucVu.GetList();
                dtChucDanh = oChucDanh.GetList();

                dtDonVi = oDonVi.GetActiveDonVi();
                DataRow dr = dtDonVi.NewRow();
                dr["ten_don_vi"] = "";
                dr["id"] = -1;
                dtDonVi.Rows.InsertAt(dr, 0);

                comB_DonVi.DataSource = dtDonVi;
                comB_DonVi.DisplayMember = "ten_don_vi";
                comB_DonVi.ValueMember = "id";
                comB_DonVi.SelectedValue = -1;

                comB_ChucDanh.DataSource = dtChucDanh;
                comB_ChucDanh.DisplayMember = "ten_chuc_danh";
                comB_ChucDanh.ValueMember = "id";
                comB_ChucDanh.SelectedValue = -1;

                comB_ChucVu.DataSource = dtChucVu;
                comB_ChucVu.DisplayMember = "ten_chuc_vu";
                comB_ChucVu.ValueMember = "id";
                comB_ChucVu.SelectedValue = -1;
            }
            catch (Exception)
            {
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(comB_DonVi.SelectedValue) == -1 && Convert.ToInt32(comB_ChucVu.SelectedValue) == -1 && Convert.ToInt32(comB_ChucDanh.SelectedValue) == -1
                    && txt_Ho.Text == "" && txt_MaNV.Text == "" && txt_Ten.Text == "" )
            {
                MessageBox.Show("Xin vui lòng điền thông tin tìm kiếm. ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    lsb_KQ.Items.Clear();
                    lsb_DSNV.Items.Clear();

                    dtNV = oCNCV.SearchNVForNgayPhep(Convert.ToInt32(comB_DonVi.SelectedValue), Convert.ToInt32(comB_ChucVu.SelectedValue), Convert.ToInt32(comB_ChucDanh.SelectedValue),
                                                        txt_Ho.Text, txt_Ten.Text, txt_MaNV.Text);

                    for (int i = 0; i < dtNV.Rows.Count; i++)
                    {
                        if(!lsb_KQ.Items.Contains(dtNV.Rows[i]["ho_ten_ma"]))
                            lsb_KQ.Items.Add(dtNV.Rows[i]["ho_ten_ma"]);
                    }

                    //lsb_KQ.DataSource = dtNV;
                    //lsb_KQ.DisplayMember = "ho_ten_ma";
                    //lsb_KQ.ValueMember = "ma_nv";
                }
                catch (Exception)
                {

                }
            }
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            if (lsb_KQ.SelectedItems != null && lsb_KQ.SelectedItems.Count >0)
            {
                for (int i = 0; i < lsb_KQ.SelectedItems.Count; i++)
                {
                    if (!lsb_DSNV.Items.Contains(lsb_KQ.SelectedItems[i]))
                    {
                        lsb_DSNV.Items.Add(lsb_KQ.SelectedItems[i]);
                    }
                }
                lsb_KQ.SelectedItems.Clear();
            }

            if (lsb_DSNV.Items.Count > 0)
            {
                dtp_DenNam.Enabled = dtp_TuNam.Enabled
                    = txt_SoNP.Enabled = btn_Them.Enabled = true;
            }
        }

        private void btn_SelectAll_Click(object sender, EventArgs e)
        {
            if (lsb_KQ.Items.Count >0)
            {
                for (int i = 0; i < lsb_KQ.Items.Count; i++)
                {
                    if (!lsb_DSNV.Items.Contains(lsb_KQ.Items[i]))
                        lsb_DSNV.Items.Add(lsb_KQ.Items[i]);
                }
                lsb_KQ.SelectedItems.Clear();
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (lsb_DSNV.SelectedItems != null && lsb_DSNV.SelectedItems.Count > 0)
            {
                for (int i = 0; i < lsb_DSNV.SelectedItems.Count; i++)
                {
                    lsb_DSNV.Items.RemoveAt(lsb_DSNV.Items.IndexOf(lsb_DSNV.SelectedItems[i]));
                }
            }

            if (lsb_DSNV.Items.Count <= 0)
            {
                dtp_DenNam.Enabled = dtp_TuNam.Enabled
                    = txt_SoNP.Enabled = btn_Them.Enabled = false;
            }
        }

        private void dtp_TuNam_ValueChanged(object sender, EventArgs e)
        {

            dtp_DenNam.Value = dtp_TuNam.Value;
        }

        private void dtp_DenNam_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lsb_DSNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsb_DSNV.SelectedItems.Count == 1)
            {
                try
                {
                    string ho_ten_ma = lsb_DSNV.SelectedItem.ToString();
                    string ma_nv = ho_ten_ma.Substring(ho_ten_ma.LastIndexOf(" - ") + 3, ho_ten_ma.Length - ho_ten_ma.LastIndexOf(" - ") - 3);

                    DataTable dt = (from r in dtNV.AsEnumerable()
                                   where r.Field<string>("ma_nv") == ma_nv
                                   select r).CopyToDataTable();

                    dtgv_ThongTinNP.DataSource = dt;
                    SetupDTGV();
                }
                catch (Exception)
                {
                    
                }
               

            }
            
        }

        private void SetupDTGV()
        {
            dtgv_ThongTinNP.Columns["ma_nv"].Width = 100;
            dtgv_ThongTinNP.Columns["ma_nv"].HeaderText = "Mã nhân viên";
            dtgv_ThongTinNP.Columns["ho"].Width = 200;
            dtgv_ThongTinNP.Columns["ho"].HeaderText = "Họ";
            dtgv_ThongTinNP.Columns["ten"].Width = 150;
            dtgv_ThongTinNP.Columns["ten"].HeaderText = "Tên";
            dtgv_ThongTinNP.Columns["thoi_gian"].Width = 100;
            dtgv_ThongTinNP.Columns["thoi_gian"].HeaderText = "Năm";
            dtgv_ThongTinNP.Columns["so_ngay_phep"].Width = 100;
            dtgv_ThongTinNP.Columns["so_ngay_phep"].HeaderText = "Số ngày phép";

            dtgv_ThongTinNP.Columns["ho_ten_ma"].Visible = false;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (lsb_DSNV.Items.Count >0 && MessageBox.Show("Bạn muốn lưu số ngày nghỉ cho các nhân viên trên ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string[] ma_nv = new string[lsb_DSNV.Items.Count];

                for (int i = 0; i < lsb_DSNV.Items.Count; i++)
                {
                    string ho_ten_ma = lsb_DSNV.SelectedItem.ToString();
                    ma_nv[i]  = ho_ten_ma.Substring(ho_ten_ma.LastIndexOf(" - ") + 3, ho_ten_ma.Length - ho_ten_ma.LastIndexOf(" - ") - 3);
                }

                try
                {
                    oCNCV.AddNgayPhep(ma_nv,dtp_TuNam.Value.Year,dtp_DenNam.Value.Year,Convert.ToDouble(txt_SoNP.Text));
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtgv_ThongTinNP.DataSource = null;
                    lsb_KQ.Items.Clear();
                    lsb_DSNV.Items.Clear();
                }
                catch (Exception)
                {
                    MessageBox.Show("Thêm không thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txt_SoNP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

    }
}
