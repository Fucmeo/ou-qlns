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
    public partial class ThongTinBoNhiem : UserControl
    {
        DonVi oDonVi;
        ChucVu oChucVu;
        Business.HDQD.LoaiPhuCap oLoaiPhuCap;
        public ThongTinBoNhiem()
        {
            InitializeComponent();
            oDonVi = new DonVi();
            oChucVu = new ChucVu();
            oLoaiPhuCap = new Business.HDQD.LoaiPhuCap();
        }

        private void ThongTinBoNhiem_Load(object sender, EventArgs e)
        {
            PrepareSourceDonViCombo();
            PrepareSourceChucVuCombo();
            PrepareSourceLoaiPhuCapCombo();
        }

        private void PrepareSourceDonViCombo()
        {
            DataTable dtDonVi = oDonVi.GetActiveDonVi();
            if (dtDonVi.Rows.Count > 0)
            {
                comB_DonVi.DataSource = dtDonVi;
                comB_DonVi.DisplayMember = "ten_don_vi";
                comB_DonVi.ValueMember = "id";
            }
            else
            {
                MessageBox.Show("Không có đơn vị nào tồn tại trong hệ thống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void PrepareSourceChucVuCombo()
        {
            DataTable dtChucVu = oChucVu.GetList();
            if (dtChucVu.Rows.Count > 0)
            {
                comB_ChucVu.DataSource = dtChucVu;
                comB_ChucVu.DisplayMember = "ten_chuc_vu";
                comB_ChucVu.ValueMember = "id";
            }
            else
            {
                MessageBox.Show("Không có chức vụ nào tồn tại trong hệ thống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void PrepareSourceLoaiPhuCapCombo()
        {
            DataTable dtLoaiPhuCap = oLoaiPhuCap.GetList();
            if (dtLoaiPhuCap.Rows.Count > 0)
            {
                comB_LoaiPhuCap.DataSource = dtLoaiPhuCap;
                comB_LoaiPhuCap.DisplayMember = "ten_loai";
                comB_LoaiPhuCap.ValueMember = "id";
            }
            else
            {
                MessageBox.Show("Không có loại phụ cấp nào tồn tại trong hệ thống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void cb_CoPhuCap_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_CoPhuCap.Checked)
            {
                comB_HeSoTienMat.Enabled = comB_LoaiPhuCap.Enabled = txt_PhuCap.Enabled = dTP_NgayBatDau.Enabled = dTP_NgayHetHan.Enabled
                    = rTB_GhiChu.Enabled = false;
            }
            else
            {
                comB_HeSoTienMat.Enabled = comB_LoaiPhuCap.Enabled = txt_PhuCap.Enabled = dTP_NgayBatDau.Enabled = dTP_NgayHetHan.Enabled
                    = rTB_GhiChu.Enabled = true;
            }
        }
    }
}
