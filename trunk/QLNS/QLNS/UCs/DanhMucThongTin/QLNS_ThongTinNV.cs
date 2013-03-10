using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.CNVC;

namespace QLNS.UCs.DanhMucThongTin
{
    public partial class QLNS_ThongTinNV : UserControl
    {
        public CNVC oCNVC ;
        public CNVC_CMND_HoChieu oCMND_HoChieu;
        public DataTable dtCNVC , dtTinhTP, dtQuocGia;
        Business.TinhTP oTinhTP;
        Business.QuocGia oQuocGia;
        bool bAddFlag = false;

        public static int nNewTinhTPID = 0;     // ID cua tinh thanh pho moi them vao

        public QLNS_ThongTinNV()
        {
            InitializeComponent();
            oCNVC = new CNVC();
            dtCNVC = new DataTable();
            dtTinhTP = new DataTable();
            oTinhTP = new Business.TinhTP();
            oCMND_HoChieu = new CNVC_CMND_HoChieu();
        }

        public void GetCNVCInfo(string m_MaNV)
        {
            oCNVC.MaNV = m_MaNV;
            dtCNVC = oCNVC.GetData();
        }

        public void FillInfo()
        {    
  
            if (dtCNVC != null && dtCNVC.Rows.Count > 0)
            {
                txt_MaHoSo.Text = Convert.ToString(dtCNVC.Rows[0]["ma_ho_so_goc"]);
                txt_MaNV.Text = Convert.ToString(dtCNVC.Rows[0]["ma_nv"]);
                txt_Ho.Text =  Convert.ToString(dtCNVC.Rows[0]["ho"]);
                txt_Ten.Text = Convert.ToString(dtCNVC.Rows[0]["ten"]);
                txt_SoSoBHXH.Text = Convert.ToString(dtCNVC.Rows[0]["so_so_bhxh"]);
                txt_MaSoThue.Text = Convert.ToString(dtCNVC.Rows[0]["ma_so_thue"]);
                txt_SoNha.Text = Convert.ToString(dtCNVC.Rows[0]["so_nha"]);
                txt_Duong.Text = Convert.ToString(dtCNVC.Rows[0]["duong"]);
                txt_PhuongXa.Text = Convert.ToString(dtCNVC.Rows[0]["phuong_xa"]);
                txt_QuanHuyen.Text = Convert.ToString(dtCNVC.Rows[0]["quan_huyen"]);
                string gioitinh = dtCNVC.Rows[0]["gioi_tinh"].ToString();
                switch (gioitinh)
                {
                    case "True":
                        comB_GioiTinh.SelectedIndex = 0;
                        break;
                    case "False":
                        comB_GioiTinh.SelectedIndex = 1;
                        break;
                    default:
                        comB_GioiTinh.SelectedIndex = 2;
                        break;
                }
            }
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (VerifyData() 
                && (MessageBox.Show("Thêm nhân viên này vào hệ thống?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                GetUserInputData();
                oCNVC.Add();
            }
            else
            {

            }
        }

        public void LoadTinhData()
        {
            DataTable dtTinhTP2 = new DataTable();
            dtTinhTP = oTinhTP.GetData();

            // comb
            comB_Tinh.DataSource = dtTinhTP;
            comB_Tinh.DisplayMember = "ten_tinh_tp";
            comB_Tinh.ValueMember = "id";    
        }

        public void LoadQuocGiaData()
        {

        }

        private void QLNS_ThongTinNV_Load(object sender, EventArgs e)
        {
            LoadTinhData();
            if(comB_Tinh.Items.Count > 0)
                comB_Tinh.SelectedIndex = 0;

        }

        private void comB_QuocGia_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private bool VerifyData()
        {
            if (string.IsNullOrWhiteSpace(txt_MaHoSo.Text) || string.IsNullOrWhiteSpace(txt_MaNV.Text) || string.IsNullOrWhiteSpace(txt_MaHoSo.Text))
            {
                return false;
            }

            return true;
        }

        private void GetUserInputData()
        {
            oCNVC.MaNV = txt_MaNV.Text.Trim();
            oCNVC.Ho = txt_Ho.Text.Trim();
            oCNVC.Ten = txt_Ten.Text.Trim();
            oCNVC.SoBHXH = txt_SoSoBHXH.Text.Trim();
            oCNVC.MaSoThue = txt_MaSoThue.Text.Trim();
            oCNVC.SoNha = txt_SoNha.Text;
            oCNVC.Duong = txt_Duong.Text;
            oCNVC.Phuong = txt_PhuongXa.Text;
            oCNVC.Quan = txt_QuanHuyen.Text;
            oCNVC.Tinh = Convert.ToInt16(comB_Tinh.SelectedValue);
            oCNVC.QuocGia = Convert.ToInt16(comB_QuocGia.SelectedValue);

            GetCMNDInputData();
        }

        private void GetCMNDInputData()
        {

        }

        private void lbl_ThemTinh_Click(object sender, EventArgs e)
        {
            UCs.ThemTinhTP oThemTinhTP = new ThemTinhTP("QLNS_ThongTinNV");
            oThemTinhTP.Dock = DockStyle.Fill;
            Forms.Popup fPopup = new Forms.Popup("Thêm tỉnh thành phố", oThemTinhTP);
            fPopup.ShowDialog();
            if (nNewTinhTPID > 0)
            {
                int? x = null;

                if (comB_Tinh.SelectedValue != Convert.DBNull && comB_Tinh.SelectedValue != null)
                    x = Convert.ToInt16(comB_Tinh.SelectedValue);
                 
                dtTinhTP = oTinhTP.GetData();

                comB_Tinh.DataSource = dtTinhTP;
                comB_Tinh.DisplayMember = "ten_tinh_tp";
                comB_Tinh.ValueMember = "id";

                if (QLNS_HienThiThongTin.bAddFlag)  // dang them thi chi can load vao thoi
                {
                    comB_Tinh.SelectedValue = nNewTinhTPID;
                }
                else
                {
                    comB_Tinh.SelectedValue = x;
                }
                nNewTinhTPID = 0;


            }
        }

        private void lbl_ThemQuocGia_Click(object sender, EventArgs e)
        {
            UCs.ThemTinhTP oThemTinhTP = new ThemTinhTP("QLNS_ThongTinNV");
            oThemTinhTP.Dock = DockStyle.Fill;
            Forms.Popup fPopup = new Forms.Popup("Thêm tỉnh thành phố", oThemTinhTP);
            fPopup.ShowDialog();
            if (nNewTinhTPID > 0)
            {
                int? x = null;

                if (comB_Tinh.SelectedValue != Convert.DBNull && comB_Tinh.SelectedValue != null)
                    x = Convert.ToInt16(comB_Tinh.SelectedValue);

                dtTinhTP = oTinhTP.GetData();

                comB_Tinh.DataSource = dtTinhTP;
                comB_Tinh.DisplayMember = "ten_tinh_tp";
                comB_Tinh.ValueMember = "id";

                if (QLNS_HienThiThongTin.bAddFlag)  // dang them thi chi can load vao thoi
                {
                    comB_Tinh.SelectedValue = nNewTinhTPID;
                }
                else
                {
                    comB_Tinh.SelectedValue = x;
                }
                nNewTinhTPID = 0;


            }
        }

        private void lbl_ThemCMND_Click(object sender, EventArgs e)
        {
            ControlCMND(true);
        }

        private void lbl_SuaCMND_Click(object sender, EventArgs e)
        {
            ControlCMND(false);
        }

        private void ControlCMND(bool Add)
        {
            if (Add)
            {
                lbl_SuaCMND.Text = "Huỷ";
                lbl_ThemCMND.Text = "Lưu";
                txt_NoiCap.Text = txt_MaSo.Text = "";
                dTP_NgayCap.Checked = false;
            }
            else
            {
                lbl_SuaCMND.Text = "Sửa";
                lbl_ThemCMND.Text = "Thêm";
            }
        }

        private void Setup_dtgv_CMNDHoChieu()
        {
            dtgv_CMNDHoChieu.Columns.Clear();
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();

            col.HeaderText = "CMND / Hộ chiếu";
            col.Width = 150;
            dtgv_CMNDHoChieu.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Mã NV";
            col.Width = 200;
            col.Visible = false;
            dtgv_CMNDHoChieu.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Mã số";
            col.Width = 200;
            dtgv_CMNDHoChieu.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Ngày cấp";
            col.Width = 200;
            dtgv_CMNDHoChieu.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Nơi cấp";
            col.Width = 200;
            dtgv_CMNDHoChieu.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Tình trạng";
            col.Width = 150;
            dtgv_CMNDHoChieu.Columns.Add(col);

            //dtgv_CMNDHoChieu.Rows.Add(1);
        }
    }
}
