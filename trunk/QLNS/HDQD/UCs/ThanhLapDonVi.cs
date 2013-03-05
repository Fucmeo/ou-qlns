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
    public partial class ThanhLapDonVi : UserControl
    {
        Business.DonVi oDonvi;
        DataTable dtDonVi;
        List<Business.DonVi> dsDonVi_new;
        public ThanhLapDonVi()
        {
            InitializeComponent();
            oDonvi = new DonVi();
            dtDonVi = new DataTable();
            dsDonVi_new = new List<DonVi>();
        }

        private void ThanhLapDonVi_Load(object sender, EventArgs e)
        {
            PrepareSourceLoaiQuyetDinh();
            PreapreDataSource();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            EnableControls(false);
        }

        private void btn_LuuThongTin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_TenDV.Text) && dTP_NgayHieuLuc.Checked)
            {
                DonVi dv = new DonVi();
                dv.TenDonVi = txt_TenDV.Text;
                dv.TenDVVietTat = txt_TenDVTat.Text;
                if (comb_DVTrucThuoc.Text != "")
                    dv.DVChaID = Convert.ToInt16(comb_DVTrucThuoc.SelectedValue);
                else
                    dv.DVChaID = null;

                dv.TuNgay = dTP_NgayHieuLuc.Value;
                dv.GhiChu = rTB_GhiChu.Text;
          
                int i = lstb_DSDV.Items.Count;
                dsDonVi_new.Insert(i, dv);

                lstb_DSDV.Items.Add(txt_TenDV.Text);

                EnableControls(true);
            }
            else
            {
                MessageBox.Show("Tên đơn vị và ngày hiệu lực không được bỏ trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_HuyThongTin_Click(object sender, EventArgs e)
        {
            EnableControls(true);
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            int index = lstb_DSDV.SelectedIndex;
            if (index != -1)
            {
                dsDonVi_new.RemoveAt(index);
                lstb_DSDV.Items.RemoveAt(index);
                txt_TenDV.Text = txt_TenDVTat.Text = rTB_GhiChu.Text = "";
                dTP_NgayHieuLuc.Checked = false;
                comb_DVTrucThuoc.SelectedIndex = 0;
            }
            
        }

        private void btn_Nhap_Click(object sender, EventArgs e)
        {
            if (VerifyData())
            {
                Business.HDQD.QuyetDinh quyetdinh = new Business.HDQD.QuyetDinh();
                quyetdinh.Ma_Quyet_Dinh = thongTinQuyetDinh1.txt_MaQD.Text;
                quyetdinh.Ten_Quyet_Dinh = thongTinQuyetDinh1.txt_TenQD.Text;
                quyetdinh.Loai_QuyetDinh_ID = Convert.ToInt16(thongTinQuyetDinh1.comB_Loai.SelectedValue);
                quyetdinh.Ngay_Ky = thongTinQuyetDinh1.dTP_NgayKy.Value;
                quyetdinh.Ngay_Hieu_Luc = thongTinQuyetDinh1.dTP_NgayHieuLuc.Value;
                if (thongTinQuyetDinh1.dTP_NgayHetHan.Checked == true)
                    quyetdinh.Ngay_Het_Han = thongTinQuyetDinh1.dTP_NgayHetHan.Value;
                else
                    quyetdinh.Ngay_Het_Han = null;
                quyetdinh.MoTa = thongTinQuyetDinh1.rTB_MoTa.Text;

                try
                {
                    int count = dsDonVi_new.Count;
                    string[] ten_don_vi_moi = new string[count];
                    string[] ten_dv_viet_tat = new string[count];
                    int[] dv_cha_id = new int[count];
                    DateTime[] tu_ngay = new DateTime[count];
                    string[] ghi_chu = new string[count];

                    for (int i = 0; i < dsDonVi_new.Count; i++)
                    {
                        DonVi dv = new DonVi();
                        dv = dsDonVi_new[i];

                        ten_don_vi_moi[i] = dv.TenDonVi;
                        ten_dv_viet_tat[i] = dv.TenDVVietTat;
                        if (dv.DVChaID != null)
                            dv_cha_id[i] = dv.DVChaID.Value;
                        else
                            dv_cha_id[i] = 0;
                        tu_ngay[i] = dv.TuNgay.Value;
                    }

                    quyetdinh.Add_ThanhLapDV(ten_don_vi_moi,ten_dv_viet_tat,dv_cha_id,ghi_chu,tu_ngay);
                    MessageBox.Show("Thành lập đơn vị thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    EnableControls(true);
                    lstb_DSDV.Items.Clear();
                    dsDonVi_new.Clear();
                    thongTinQuyetDinh1.txt_TenQD.Text = thongTinQuyetDinh1.txt_MaQD.Text = "";
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thành lập đơn vị không thành công.\r\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin của quyết định.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private bool VerifyData()
        {
            if (string.IsNullOrWhiteSpace(thongTinQuyetDinh1.txt_MaQD.Text) || string.IsNullOrWhiteSpace(thongTinQuyetDinh1.txt_TenQD.Text))
                return false;

            if (lstb_DSDV.Items.Count == 0)
            {
                return false;
            }

            return true;
        }

        private void PrepareSourceLoaiQuyetDinh()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("loai_quyet_dinh_id", typeof(int));
            dt.Columns.Add("ten_loai_quyet_dinh", typeof(string));

            dt.Rows.Add(new object[2] { 5, "Thành lập đơn vị" });


            thongTinQuyetDinh1.comB_Loai.DataSource = dt;
            thongTinQuyetDinh1.comB_Loai.DisplayMember = "ten_loai_quyet_dinh";
            thongTinQuyetDinh1.comB_Loai.ValueMember = "loai_quyet_dinh_id";
        }

        private void PreapreDataSource()
        {
            dtDonVi = oDonvi.GetDonViList();
            DataRow row = dtDonVi.NewRow();
            dtDonVi.Rows.InsertAt(row, 0);

            comb_DVTrucThuoc.DataSource = dtDonVi;
            comb_DVTrucThuoc.DisplayMember = "ten_don_vi";
            comb_DVTrucThuoc.ValueMember = "id";
        }

        private void lstb_DSDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstb_DSDV.SelectedIndex != -1)
            {
                int index = lstb_DSDV.SelectedIndex;
                DonVi dv = new DonVi();
                dv = dsDonVi_new[index];
                txt_TenDV.Text = dv.TenDonVi;
                txt_TenDVTat.Text = dv.TenDVVietTat;
                if (dv.DVChaID != null)
                    comb_DVTrucThuoc.SelectedValue = dv.DVChaID;
                else
                    comb_DVTrucThuoc.SelectedValue = 0;
                if (dv.TuNgay != null)
                    dTP_NgayHieuLuc.Value = dv.TuNgay.Value;
                else
                    dTP_NgayHieuLuc.Checked = false;
                rTB_GhiChu.Text = dv.GhiChu;

            }
        }

        private void EnableControls(bool p_value)
        {
            if (p_value == false)
            {
                gb_ThongTinDV.Enabled = true;

                gb_DSDVMoi.Enabled = thongTinQuyetDinh1.Enabled  = false;
                txt_TenDV.Focus();
            }
            else
            {
                gb_ThongTinDV.Enabled = false;
                gb_DSDVMoi.Enabled =thongTinQuyetDinh1.Enabled = true; 
            }
            txt_TenDV.Text = txt_TenDVTat.Text = rTB_GhiChu.Text = "";
            dTP_NgayHieuLuc.Checked = false;
            comb_DVTrucThuoc.SelectedIndex = 0;
        }

        
    }
}
