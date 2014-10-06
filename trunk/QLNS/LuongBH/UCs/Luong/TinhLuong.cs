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
    public partial class TinhLuong : UserControl
    {
        HDQD.UCs.ThongTinCNVC oThongTinCNVC;
        List<string> lstNV;
        List<string> lstDV;
        List<int> lstDV_ID;
        List<string> lstMaNV;
        Business.DonVi oDonVi;
        Business.Luong.TinhLuong oTinhLuong;
        DataTable dtDonVi,dtLuong,dtPhuCap;
        public TinhLuong()
        {
            InitializeComponent();
            oThongTinCNVC = new HDQD.UCs.ThongTinCNVC();
            lstNV = new List<string>();
            lstDV = new List<string>();
            oDonVi = new Business.DonVi();
            oTinhLuong = new Business.Luong.TinhLuong();
            dtDonVi = new DataTable();
            lstDV_ID = new List<int>();
            lstMaNV = new List<string>();
            dtLuong = new DataTable();
            dtPhuCap = new DataTable();
        }

        private void rdb_DonVi_CheckedChanged(object sender, EventArgs e)
        {
            lsb_DanhSach.Items.Clear();
            for (int i = 0; i < lstDV.Count; i++)
            {
                lsb_DanhSach.Items.Add(lstDV[i]);
            }
            ChangeDTTinhInterface();
        }



        private void rdb_NV_CheckedChanged(object sender, EventArgs e)
        {
            lsb_DanhSach.Items.Clear();
            for (int i = 0; i < lstNV.Count; i++)
            {
                lsb_DanhSach.Items.Add(lstNV[i]);
            }
            
            ChangeDTTinhInterface();
        }

        private void ChangeDTTinhInterface()
        {

            if (rdb_NV.Checked)
            {
                TLP_ThongTinTimKiem.RowStyles[1].SizeType = TLP_ThongTinTimKiem.RowStyles[0].SizeType = SizeType.Percent;
                TLP_ThongTinTimKiem.RowStyles[1].Height = 1;
                TLP_ThongTinTimKiem.RowStyles[0].Height = 99;
            }
            else
            {
                TLP_ThongTinTimKiem.RowStyles[1].SizeType = TLP_ThongTinTimKiem.RowStyles[0].SizeType = SizeType.Percent;
                TLP_ThongTinTimKiem.RowStyles[0].Height = 1;
                TLP_ThongTinTimKiem.RowStyles[1].Height = 99;
            }
            
        }

        private void TinhLuong_Load(object sender, EventArgs e)
        {
            TLP_TheoNV.Controls.Add(oThongTinCNVC);
            ChangeDTTinhInterface();

            oThongTinCNVC.btn_Tim.Click += new EventHandler(btn_Tim_Click);
            oThongTinCNVC.Dock = DockStyle.Fill;

            dtDonVi = oDonVi.GetActiveDonVi();
            BindDVCombo();
        }

        void BindDVCombo()
        {
            comb_DonVi.DataSource = dtDonVi;
            comb_DonVi.DisplayMember = "ten_don_vi";
            comb_DonVi.ValueMember = "id";
        }

        void btn_Tim_Click(object sender, EventArgs e)
        {

        }

        private void btn_AddNV_Click(object sender, EventArgs e)
        {
            lstNV.Add(oThongTinCNVC.txt_HoTen.Text.Trim());
            lstMaNV.Add(oThongTinCNVC.txt_MaNV.Text.Trim());
            lsb_DanhSach.Items.Add(oThongTinCNVC.txt_HoTen.Text.Trim());

        }

        private void btn_RemoveList_Click(object sender, EventArgs e)
        {
            if (lsb_DanhSach.SelectedItems.Count > 0)
            {
                for (int i = 0; i < lsb_DanhSach.SelectedItems.Count; i++)
                {
                    if (rdb_DonVi.Checked)
                    {
                        lstDV.Remove(lsb_DanhSach.SelectedItems[i].ToString());
                        lstDV_ID.RemoveAt(lsb_DanhSach.Items.IndexOf(lsb_DanhSach.SelectedItems[i]));
                    }
                    else if (rdb_NV.Checked)
                    {
                        lstNV.Remove(lsb_DanhSach.SelectedItems[i].ToString());
                        lstMaNV.RemoveAt(lsb_DanhSach.Items.IndexOf(lsb_DanhSach.SelectedItems[i]));
                    }
                    
                    lsb_DanhSach.Items.Remove(lsb_DanhSach.SelectedItems[i].ToString());
                }
               
            }
        }

        private void btn_AddDonVi_Click(object sender, EventArgs e)
        {
            lstDV.Add(comb_DonVi.Text.ToString());
            lstDV_ID.Add(Convert.ToInt16(comb_DonVi.SelectedValue));
            lsb_DanhSach.Items.Add(comb_DonVi.Text.ToString());
        }

        void SetupDTGV_Luong()
        {
            dtgv_Luong.Columns["dv_id"].Visible = dtgv_Luong.Columns["td_id"].Visible
                = dtgv_Luong.Columns["tien_luong"].Visible = false;

            dtgv_Luong.Columns["thang_nam"].HeaderText = "Tháng-Năm";
            dtgv_Luong.Columns["thang_nam"].Width = 100;
            dtgv_Luong.Columns["ma_nv"].HeaderText = "Mã nhân viên";
            dtgv_Luong.Columns["ma_nv"].Width = 200;
            dtgv_Luong.Columns["ho"].HeaderText = "Họ";
            dtgv_Luong.Columns["ho"].Width = 200;
            dtgv_Luong.Columns["ten"].HeaderText = "Tên";
            dtgv_Luong.Columns["ten"].Width = 150;
            dtgv_Luong.Columns["ten_dv_viet_tat"].HeaderText = "Tên đơn vị viết tắt";
            dtgv_Luong.Columns["ten_dv_viet_tat"].Width = 200;
            dtgv_Luong.Columns["ten_dv"].HeaderText = "Tên đơn vị";
            dtgv_Luong.Columns["ten_dv"].Width = 300;
            dtgv_Luong.Columns["ma_tuyen_dung"].HeaderText = "Mã tuyển dụng";
            dtgv_Luong.Columns["ma_tuyen_dung"].Width = 200;
            dtgv_Luong.Columns["khoan_or_heso"].HeaderText = "Khoán/hệ số";
            dtgv_Luong.Columns["khoan_or_heso"].Width = 100;
            dtgv_Luong.Columns["tien_khoan"].HeaderText = "Tiền khoán";
            dtgv_Luong.Columns["tien_khoan"].Width = 200;
            dtgv_Luong.Columns["he_so"].HeaderText = "Hệ số";
            dtgv_Luong.Columns["he_so"].Width = 100;
            dtgv_Luong.Columns["luong_toi_thieu"].HeaderText = "Lương tối thiểu";
            dtgv_Luong.Columns["luong_toi_thieu"].Width = 300;
            dtgv_Luong.Columns["phan_tram_huong"].HeaderText = "Phần trăm hưởng";
            dtgv_Luong.Columns["phan_tram_huong"].Width = 200;
            dtgv_Luong.Columns["so_ngay_phep"].HeaderText = "Số ngày phép";
            dtgv_Luong.Columns["so_ngay_phep"].Width = 200;
            dtgv_Luong.Columns["so_ngay_phep_koluong"].HeaderText = "Nghỉ phép không lương";
            dtgv_Luong.Columns["so_ngay_phep_koluong"].Width = 200;
            dtgv_Luong.Columns["so_ngay_cong"].HeaderText = "Ngày công";
            dtgv_Luong.Columns["so_ngay_cong"].Width = 100;
            dtgv_Luong.Columns["tien_luong_format"].HeaderText = "Tiền lương";
            dtgv_Luong.Columns["tien_luong_format"].Width = 250;
        }

        void SetupDTGV_PhuCap()
        {
            dtgv_PhuCap.Columns["cach_tinh"].Visible =
                dtgv_PhuCap.Columns["cach_tinh_txt"].Visible = dtgv_PhuCap.Columns["value_khoan"].Visible =
                 dtgv_PhuCap.Columns["value_he_so"].Visible = dtgv_PhuCap.Columns["value_phan_tram"].Visible =
                  dtgv_PhuCap.Columns["value_khoan"].Visible = dtgv_PhuCap.Columns["value_khoan"].Visible =
                  dtgv_PhuCap.Columns["tien_phu_cap"].Visible = false;

            dtgv_PhuCap.Columns["thang_nam"].HeaderText = "Tháng-Năm";
            dtgv_PhuCap.Columns["thang_nam"].Width = 100;
            dtgv_PhuCap.Columns["ma_nv"].HeaderText = "Mã nhân viên";
            dtgv_PhuCap.Columns["ma_nv"].Width = 200;
            dtgv_PhuCap.Columns["ho"].HeaderText = "Họ";
            dtgv_PhuCap.Columns["ho"].Width = 250;
            dtgv_PhuCap.Columns["ten"].HeaderText = "Tên";
            dtgv_PhuCap.Columns["ten"].Width = 150;
            dtgv_PhuCap.Columns["phan_tram_huong"].HeaderText = "Phần trăm hưởng";
            dtgv_PhuCap.Columns["phan_tram_huong"].Width = 200;
            dtgv_PhuCap.Columns["loai_phu_cap"].HeaderText = "Loại phụ cấp";
            dtgv_PhuCap.Columns["loai_phu_cap"].Width = 300;
            dtgv_PhuCap.Columns["tien_phu_cap_format"].HeaderText = "Phụ cấp";
            dtgv_PhuCap.Columns["tien_phu_cap_format"].Width = 250;
            
        }

        void AddLuongFormatCol()
        {
            dtLuong.Columns.Add("tien_luong_format", typeof(string));
            //dtLuong.AsEnumerable().Select(p => p.SetField("tien_luong_format",Convert.ToDouble(p.Field<double>("tien_luong")).ToString("#,#")));

            foreach (DataRow r in dtLuong.Rows)
            {
                r["tien_luong_format"] = (Convert.ToDouble(r["tien_luong"]).ToString("#,#")).ToString();
            }

            dtPhuCap.Columns.Add("tien_phu_cap_format", typeof(string));

            foreach (DataRow r in dtPhuCap.Rows)
            {
                r["tien_phu_cap_format"] = (Convert.ToDouble(r["tien_phu_cap"]).ToString("#,#")).ToString();
            }

        }

        private void btn_TinhLuong_Click(object sender, EventArgs e)
        {
            if (lsb_DanhSach.Items.Count >0 && mtx_Thang.MaskCompleted)
            {
                string thangnam = mtx_Thang.Text;
                try
                {
                    int nam = Convert.ToInt16(thangnam.Substring(3, 4));
                    int thang = Convert.ToInt16(thangnam.Substring(0, 2));
                
                    DateTime tu_ngay = new DateTime(nam,thang, 1);
                    DateTime den_ngay = new DateTime(nam, thang,DateTime.DaysInMonth(nam,thang));
                    if (rdb_NV.Checked)
                    {
                        dtLuong = oTinhLuong.TinhLuongByListNV(lstMaNV, tu_ngay, den_ngay, Convert.ToInt32(nam.ToString() + thang.ToString("D2")));
                        dtPhuCap = oTinhLuong.TinhPhuCapByListNV(lstMaNV, tu_ngay, den_ngay, Convert.ToInt32(nam.ToString() + thang.ToString("D2")));
                        
                    }
                    else if (rdb_DonVi.Checked)
                    {
                        dtLuong = oTinhLuong.TinhLuongByListDV(lstDV_ID, tu_ngay, den_ngay, Convert.ToInt32(nam.ToString() + thang.ToString("D2")));
                        dtPhuCap = oTinhLuong.TinhPhuCapByListDV(lstDV_ID, tu_ngay, den_ngay, Convert.ToInt32(nam.ToString() + thang.ToString("D2")));
                        
                    }
                    dtgv_Luong.DataSource = null;
                    dtgv_PhuCap.DataSource = null;

                    AddLuongFormatCol();

                    dtgv_Luong.DataSource = dtLuong;
                    dtgv_PhuCap.DataSource = dtPhuCap;



                    SetupDTGV_Luong();
                    SetupDTGV_PhuCap();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra!\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            else
            {
                MessageBox.Show("Xin vui lòng chọn nhân viên / đơn vị và tháng cần tính lương. " , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
