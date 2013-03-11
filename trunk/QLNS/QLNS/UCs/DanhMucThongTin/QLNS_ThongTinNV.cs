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
        bool bAddCNVCFlag = false , bAddCMNDFlag = false ;

        public static int nNewTinhTPID = 0;     // ID cua tinh thanh pho moi them vao

        public QLNS_ThongTinNV()
        {
            InitializeComponent();
            oCNVC = new CNVC();
            dtCNVC = new DataTable();
            dtTinhTP = new DataTable();
            oTinhTP = new Business.TinhTP();
            oQuocGia = new Business.QuocGia();
            oCMND_HoChieu = new CNVC_CMND_HoChieu();
        }

        public void GetCNVCInfo(string m_MaNV)
        {
            oCNVC.MaNV = m_MaNV;
            dtCNVC = oCNVC.GetData();
        }

        private void QLNS_ThongTinNV_Load(object sender, EventArgs e)
        {
            LoadQuocGiaData();
            DataTable dt = dtTinhTP.AsEnumerable().Where(a => a.Field<int>("quoc_gia_id") == Convert.ToInt32(comB_QuocGia.SelectedValue)).CopyToDataTable();
            LoadTinhData(dt);

            if (comB_QuocGia.Items.Count > 0)
                comB_QuocGia.SelectedIndex = 0;

            Setup_dtgv_CMNDHoChieu();

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
            if (VerifyData())
            {
                if ((MessageBox.Show("Thêm nhân viên này vào hệ thống?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    try
                    {
                        GetCNVCInfoData();
                        GetCMNDInputData();

                        oCNVC.Add();
                        oCMND_HoChieu.Add();

                        MessageBox.Show("Thêm nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Thông tin nhân viên không phù hợp, xin vui lòng xem lại thông tin nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Thông tin không đầy đủ, xin vui lòng xem lại thông tin nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }
        }

        public void LoadTinhData(DataTable dt)
        {
            DataRow dr = dt.NewRow();
            dr["ten_tinh_tp"] = "";
            dr["id"] = -1;
            dr["quoc_gia_id"] = -1;
            dt.Rows.Add(dr);
            // comb
            comB_Tinh.DataSource = dt;
            comB_Tinh.DisplayMember = "ten_tinh_tp";
            comB_Tinh.ValueMember = "id";    
        }

        public void LoadQuocGiaData()
        {
            dtQuocGia = oQuocGia.GetData();
            dtTinhTP = oTinhTP.GetData();

            // comb
            comB_QuocGia.DataSource = dtQuocGia;
            comB_QuocGia.DisplayMember = "ten_quoc_gia";
            comB_QuocGia.ValueMember = "id";   
        }

        private void comB_QuocGia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int v = Convert.ToInt32(comB_QuocGia.SelectedValue);

            DataTable dt = dtTinhTP.AsEnumerable().Where(a => a.Field<int>("quoc_gia_id") == v).CopyToDataTable();
            LoadTinhData(dt);
        }

        private bool VerifyData()
        {
            if (string.IsNullOrWhiteSpace(txt_MaHoSo.Text) || string.IsNullOrWhiteSpace(txt_MaNV.Text) || string.IsNullOrWhiteSpace(txt_MaHoSo.Text))
            {
                return false;
            }

            return true;
        }

        private void GetCNVCInfoData()
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
            int v = Convert.ToInt16(comB_Tinh.SelectedValue);
            if (v == -1)    // -1 là rỗng
            {
                oCNVC.Tinh = null;
            }
            else
                oCNVC.Tinh = v;

            v = Convert.ToInt16(comB_QuocGia.SelectedValue);
            if (v == -1) oCNVC.QuocGia = null;
            else oCNVC.QuocGia = v;
            
        }

        private void GetCMNDInputData()
        {
            int count = dtgv_CMNDHoChieu.Rows.Count;
            if (count > 0)
            {
                oCMND_HoChieu.CMNDHoChieu = new bool[count];
                oCMND_HoChieu.NgayCap = new DateTime?[count];
                oCMND_HoChieu.NoiCap = new string[count];
                oCMND_HoChieu.MaSo = new string[count];
                oCMND_HoChieu.IsActive = new bool[count];

                oCMND_HoChieu.MaNV = txt_MaNV.Text.Trim();
                for (int i = 0; i < count; i++)
                {
                    DataGridViewRow r = dtgv_CMNDHoChieu.Rows[i];

                    oCMND_HoChieu.CMNDHoChieu[i] = r.Cells[0].ToString() == "CMND" ? true : false;
                    oCMND_HoChieu.MaSo[i] = r.Cells[2].ToString();
                    if (r.Cells[3].Value.ToString() != "")
                        oCMND_HoChieu.NgayCap[i] = Convert.ToDateTime(r.Cells[3].Value.ToString());
                    else
                        oCMND_HoChieu.NgayCap[i] = DateTime.MinValue;

                    oCMND_HoChieu.NoiCap[i] = r.Cells[4].ToString();
                    oCMND_HoChieu.IsActive[i] = r.Cells[5].ToString() == "Còn hiệu lực" ? true : false;
                }
            }
           
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
            if (lbl_ThemCMND.Text == "Thêm")
            {
                bAddCMNDFlag = true;
                ControlCMND(true);    
            }
            else        // LƯU
            {
                if (VerifyCMNDData())
                {
                    if (bAddCMNDFlag)   // Thêm mới
                    {
                        string d;
                        if (dTP_NgayCap.Checked)
                        {
                            d = dTP_NgayCap.Value.ToShortDateString();
                        }
                        else d = "";
                        dtgv_CMNDHoChieu.Rows.Add(new string[] { comB_CMND_HoChieu.Text, "", txt_MaSo.Text, d, txt_NoiCap.Text, comB_TinhTrang.Text });
                    }
                    else        // Sửa
                    {
                        int idx = dtgv_CMNDHoChieu.Rows.IndexOf(dtgv_CMNDHoChieu.SelectedRows[0]);
                        dtgv_CMNDHoChieu.Rows[idx].Cells[0].Value = comB_CMND_HoChieu.Text;
                        dtgv_CMNDHoChieu.Rows[idx].Cells[1].Value = "";
                        dtgv_CMNDHoChieu.Rows[idx].Cells[2].Value = txt_MaSo.Text;
                        dtgv_CMNDHoChieu.Rows[idx].Cells[3].Value = dTP_NgayCap.Value.ToShortDateString();
                        dtgv_CMNDHoChieu.Rows[idx].Cells[4].Value = txt_NoiCap.Text;
                        dtgv_CMNDHoChieu.Rows[idx].Cells[5].Value = comB_TinhTrang.Text;
                    }
                    
                    ControlCMND(false);
                }
                else
                {
                    MessageBox.Show("Thông tin CMND / Hộ chiếu không phù hợp, xin vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
        }

        private void lbl_SuaCMND_Click(object sender, EventArgs e)
        {
            if (lbl_SuaCMND.Text == "Sửa")  
            {
                if (dtgv_CMNDHoChieu.Rows.Count > 0 && dtgv_CMNDHoChieu.SelectedRows != null)
                {
                    txt_MaSo.Focus();
                    bAddCMNDFlag = false;
                    ControlCMND(true);    
                }
                else
                {
                    MessageBox.Show("Chưa có thông tin về CMND / Hộ chiếu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else        // HUỶ
            {
                    ControlCMND(false);
             
            }
        }

        private void ControlCMND(bool Add)
        {
            
            if (Add)
            {
                lbl_SuaCMND.Text = "Huỷ";
                lbl_ThemCMND.Text = "Lưu";
                txt_NoiCap.Enabled = txt_MaSo.Enabled = dTP_NgayCap.Enabled = comB_CMND_HoChieu.Enabled = comB_TinhTrang.Enabled = true;
                dtgv_CMNDHoChieu.Enabled = false;
            }
            else
            {
                lbl_SuaCMND.Text = "Sửa";
                lbl_ThemCMND.Text = "Thêm";
                txt_NoiCap.Enabled = txt_MaSo.Enabled = dTP_NgayCap.Enabled = comB_CMND_HoChieu.Enabled = comB_TinhTrang.Enabled = false;
                dtgv_CMNDHoChieu.Enabled = true;
                txt_NoiCap.Text = txt_MaSo.Text = "";
                comB_CMND_HoChieu.SelectedIndex = comB_TinhTrang.SelectedIndex = 0;
                dTP_NgayCap.Checked = false;
            }
        }

        private bool VerifyCMNDData()
        {
            if (string.IsNullOrWhiteSpace(txt_MaSo.Text))
            {
                return false;
            }

            return true;
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

        private void dtgv_CMNDHoChieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_CMNDHoChieu.Rows.Count > 0 && dtgv_CMNDHoChieu.SelectedRows != null)
            {
                DataGridViewRow r = dtgv_CMNDHoChieu.SelectedRows[0];

                if (r.Cells[0].Value.ToString() == "CMND")
                {
                    comB_CMND_HoChieu.Text = "CMND";
                }
                else
                {
                    comB_CMND_HoChieu.Text = "Hộ chiếu";
                }
                txt_MaSo.Text = r.Cells[2].Value.ToString();
                if (r.Cells[3].Value.ToString() != "")
                    dTP_NgayCap.Value = Convert.ToDateTime(r.Cells[3].Value);
                else
                    dTP_NgayCap.Checked = false;

                txt_NoiCap.Text = r.Cells[4].Value.ToString();
                if (r.Cells[4].Value.ToString() == "Còn hiệu lực")
                {
                    comB_TinhTrang.Text = "Còn hiệu lực";
                }
                else
                {
                    comB_TinhTrang.Text = "Hết hiệu lực";
                }

            }
        }
    }
}
