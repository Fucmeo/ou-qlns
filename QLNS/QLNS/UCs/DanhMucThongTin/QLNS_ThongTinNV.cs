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
        public DataTable dtCNVC , dtCMND , dtTinhTP, dtQuocGia;
        Business.TinhTP oTinhTP;
        Business.QuocGia oQuocGia;
        bool bAddCNVCFlag = false , bAddCMNDFlag = false ;

        public static int nNewTinhTPID = 0;     // ID cua tinh thanh pho moi them vao
        public static int nNewQuocGiaID = 0;     // ID cua quoc gia moi them vao

        public QLNS_ThongTinNV()
        {
            InitializeComponent();
            oCNVC = new CNVC();
            dtCNVC = new DataTable();
            dtCMND = new DataTable();
            dtTinhTP = new DataTable();
            oTinhTP = new Business.TinhTP();
            oQuocGia = new Business.QuocGia();
            oCMND_HoChieu = new CNVC_CMND_HoChieu();
        }

        public void GetCNVCInfo(string m_MaNV)
        {
            oCNVC.MaNV = m_MaNV;
            dtCNVC = oCNVC.GetData();

            oCMND_HoChieu.MaNV = m_MaNV;
            dtCMND = oCMND_HoChieu.GetData();
        }

        private void QLNS_ThongTinNV_Load(object sender, EventArgs e)
        {
            LoadQuocGiaData();
            if (comB_QuocGia.Items.Count > 0)
                comB_QuocGia.SelectedIndex = 0;

            var dt = dtTinhTP.AsEnumerable().Where(a => a.Field<int>("quoc_gia_id") == Convert.ToInt32(comB_QuocGia.SelectedValue));
            if (dt != null && dt.Count() > 0)
            {
                LoadTinhData(dt.CopyToDataTable());
            }
            else
            {
                LoadTinhData(null);
            }

            comB_CMND_HoChieu.SelectedIndex = comB_TinhTrang.SelectedIndex = 0;
            Init_dtgv_CMNDHoChieu();

        }

        public void FillInfo()
        {    
  
            if (dtCNVC.Rows.Count > 0)
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
                if (dtCNVC.Rows[0]["quoc_gia"].ToString() != "")
                {
                    comB_QuocGia.SelectedValue = Convert.ToInt32(dtCNVC.Rows[0]["quoc_gia"]);
                }
                else
                {
                    comB_QuocGia.SelectedValue = -1;
                }

                if (dtCNVC.Rows[0]["tinh_thanhpho"].ToString() != "")
                {
                    comB_Tinh.SelectedValue = Convert.ToInt32(dtCNVC.Rows[0]["tinh_thanhpho"]);
                }
                else
                {
                    ChangeTinhCombByQuocGia();  // neu data cua nv o co tinh tp, thi chi do ~ tp thuoc quoc gia
                    comB_Tinh.SelectedValue = -1;
                }
                
            }

            
            if (dtCMND.Rows.Count > 0)
            {
                DataTable dt = dtCMND.Copy();
                dtgv_CMNDHoChieu.Columns.Clear();
                dtgv_CMNDHoChieu.DataSource = dt;
                Setup_dtgv_CMNDHoChieu();
                
            }
        }

        private void btn_LuuCNVC_Click(object sender, EventArgs e)
        {
            if (VerifyCNVCData())
            {
                if ((MessageBox.Show("Thêm / cập nhật nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    try
                    {
                        GetCNVCInfoData();
                        if (QLNS_HienThiThongTin.bAddFlag)
                        {
                            oCNVC.Add();
                            MessageBox.Show("Thêm nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);    
                        }
                        else
                        {
                            oCNVC.Update(Program.selected_ma_nv);

                            MessageBox.Show("Cập nhật nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        
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
            if (dt == null || dt.Rows.Count == 0)        // de phong TH quoc gia dang chon khong co tp
            {
                dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("id", typeof(int)), new DataColumn("ten_tinh_tp", typeof(string)), 
                                                        new DataColumn("quoc_gia_id", typeof(int)) });
            }
            if (dt.AsEnumerable().Where(a => a.Field<int>("id") == -1).Count() <= 0)
            {
                DataRow dr = dt.NewRow();
                dr["ten_tinh_tp"] = "";
                dr["id"] = -1;
                dr["quoc_gia_id"] = -1;
                dt.Rows.Add(dr);
            }
            
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
            ChangeTinhCombByQuocGia();
        }

        private void ChangeTinhCombByQuocGia()
        {
            int v = Convert.ToInt32(comB_QuocGia.SelectedValue);

            if (v == -1)    // combo quoc gia rong
            {
                LoadTinhData(dtTinhTP);
            }
            else
            {
                var dt = dtTinhTP.AsEnumerable().Where(a => a.Field<int>("quoc_gia_id") == v);
                if (dt != null && dt.Count() > 0)
                {
                    LoadTinhData(dt.CopyToDataTable());
                }
                else
                {
                    LoadTinhData(null);
                }
            }
        }

        private bool VerifyCNVCData()
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
            oCNVC.MaHoSo = txt_MaHoSo.Text.Trim();
            oCNVC.SoBHXH = txt_SoSoBHXH.Text.Trim();
            oCNVC.MaSoThue = txt_MaSoThue.Text.Trim();
            oCNVC.SoNha = txt_SoNha.Text;
            oCNVC.Duong = txt_Duong.Text;
            oCNVC.Phuong = txt_PhuongXa.Text;
            oCNVC.Quan = txt_QuanHuyen.Text;
            int v = Convert.ToInt16(comB_Tinh.SelectedValue);
            if (v <= 0) 
            {
                oCNVC.Tinh = null;
            }
            else
                oCNVC.Tinh = v;

            v = Convert.ToInt16(comB_QuocGia.SelectedValue);
            if (v <= 0) oCNVC.QuocGia = null;
            else oCNVC.QuocGia = v;
            
        }

        private void GetCMNDInputData()
        {
            if (VerifyCMNDData())
            {
                oCMND_HoChieu.MaNV = Program.selected_ma_nv;
                oCMND_HoChieu.ID = Convert.ToInt32(dtgv_CMNDHoChieu.SelectedRows[0].Cells[6].Value);
                oCMND_HoChieu.CMNDHoChieu = comB_CMND_HoChieu.SelectedItem.ToString() == "CMND" ? true : false;
                oCMND_HoChieu.MaSo = txt_MaSo.Text;
                if (dTP_NgayCap.Checked)
                    oCMND_HoChieu.NgayCap = dTP_NgayCap.Value;
                else
                    oCMND_HoChieu.NgayCap = null;

                oCMND_HoChieu.NoiCap = txt_NoiCap.Text;
                oCMND_HoChieu.IsActive = comB_TinhTrang.SelectedItem.ToString() == "Còn hiệu lực" ? true : false;
                
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
            UCs.ThemQuocGia oThemQuocGia = new ThemQuocGia("QLNS_ThongTinNV");
            oThemQuocGia.Dock = DockStyle.Fill;
            Forms.Popup fPopup = new Forms.Popup("Thêm quốc gia", oThemQuocGia);
            fPopup.ShowDialog();
            if (nNewQuocGiaID > 0)
            {
                int? x = null;

                if (comB_Tinh.SelectedValue != Convert.DBNull && comB_Tinh.SelectedValue != null)
                    x = Convert.ToInt16(comB_Tinh.SelectedValue);

                dtQuocGia = oQuocGia.GetData();

                comB_QuocGia.DataSource = dtQuocGia;
                comB_QuocGia.DisplayMember = "ten_quoc_gia";
                comB_QuocGia.ValueMember = "id";

                if (QLNS_HienThiThongTin.bAddFlag)  // dang them thi chi can load vao thoi
                {
                    comB_QuocGia.SelectedValue = nNewQuocGiaID;
                }
                else
                {
                    comB_QuocGia.SelectedValue = x;
                }
                nNewQuocGiaID = 0;


            }
        }

        private void lbl_ThemCMND_Click(object sender, EventArgs e)
        {
            #region MyRegion

            if (lbl_ThemCMND.Text == "Thêm")
            {
                bAddCMNDFlag = true;
                ControlCMND(true);
                ClearCMNDData();
            }
            else        // LƯU
            {
                if (VerifyCMNDData())
                {
                    if (bAddCMNDFlag)   // Thêm mới
                    {
                        if ((MessageBox.Show("Thêm thông tin về CMND / Hộ chiếu của nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {
                            try
                            {
                                GetCMNDInputData();
                                oCMND_HoChieu.Add();

                                // load lai dtgv_CMND
                                dtCMND = oCMND_HoChieu.GetData();
                                dtgv_CMNDHoChieu.DataSource = dtCMND;
                                Setup_dtgv_CMNDHoChieu();

                                MessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Thông tin không phù hợp, xin vui lòng xem lại thông tin CMND/ Hộ chiếu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else        // Sửa
                    {
                        if ((MessageBox.Show("Sửa thông tin về CMND / Hộ chiếu của nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {
                            try
                            {
                                GetCMNDInputData();
                                oCMND_HoChieu.Update();

                                // load lai dtgv_CMND
                                dtCMND = oCMND_HoChieu.GetData();
                                dtgv_CMNDHoChieu.DataSource = dtCMND;
                                Setup_dtgv_CMNDHoChieu();

                                MessageBox.Show("Sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Thông tin không phù hợp, xin vui lòng xem lại thông tin CMND/ Hộ chiếu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }

                    

                    ControlCMND(false);
                    ClearCMNDData();
                }
                else
                {
                    MessageBox.Show("Thông tin CMND / Hộ chiếu không phù hợp, xin vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } 
            #endregion
            
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
                bAddCMNDFlag = false;
                    ControlCMND(false);
                    ClearCMNDData();
             
            }
        }

        private void ClearCMNDData()
        {
            txt_NoiCap.Text = txt_MaSo.Text = "";
            comB_CMND_HoChieu.SelectedIndex = comB_TinhTrang.SelectedIndex = 0;
            dTP_NgayCap.Checked = false;
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

        private void Init_dtgv_CMNDHoChieu()
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

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Id";
            col.Width = 10;
            col.Visible = false;
            dtgv_CMNDHoChieu.Columns.Add(col);

            //dtgv_CMNDHoChieu.Rows.Add(1);
        }

        private void Setup_dtgv_CMNDHoChieu()
        {
            dtgv_CMNDHoChieu.Columns[0].HeaderText = "CMND / Hộ chiếu";
            dtgv_CMNDHoChieu.Columns[0].Width = 150;

            dtgv_CMNDHoChieu.Columns[1].Visible = dtgv_CMNDHoChieu.Columns[6].Visible = false; // id va ma nv

            dtgv_CMNDHoChieu.Columns[2].HeaderText = "Mã số";
            dtgv_CMNDHoChieu.Columns[2].Width = 200;
            dtgv_CMNDHoChieu.Columns[3].HeaderText = "Ngày cấp";
            dtgv_CMNDHoChieu.Columns[3].Width = 200;
            dtgv_CMNDHoChieu.Columns[4].HeaderText = "Nơi cấp";
            dtgv_CMNDHoChieu.Columns[4].Width = 200;
            dtgv_CMNDHoChieu.Columns[5].HeaderText = "Tình trạng";
            dtgv_CMNDHoChieu.Columns[5].Width = 150;


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
                if (r.Cells[3].Value.ToString() != "" && r.Cells[3].Value.ToString() != DateTime.MinValue.ToString())
                {
                    dTP_NgayCap.Checked = true;
                    dTP_NgayCap.Value = Convert.ToDateTime(r.Cells[3].Value);
                }
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

        private void btn_LuuCMND_Click(object sender, EventArgs e)
        {
            if (VerifyCNVCData() && dtgv_CMNDHoChieu.Rows.Count > 0)
            {
                if ((MessageBox.Show("Thêm thông tin về CMND / Hộ chiếu của nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    try
                    {
                        GetCMNDInputData();
                        oCMND_HoChieu.Add();

                        MessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Thông tin không phù hợp, xin vui lòng xem lại thông tin CMND/ Hộ chiếu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Thông tin không đầy đủ, xin vui lòng xem lại thông tin nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void comB_Tinh_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int v = Convert.ToInt32(comB_Tinh.SelectedValue);

            if (v != -1)    // combo quoc gia rong
            {
                var ids = from c in dtTinhTP.AsEnumerable()
                          where c.Field<int>("id") == v
                          select c.Field<int>("quoc_gia_id");

                int quoc_gia_id = ids.ElementAt<int>(0);

                comB_QuocGia.SelectedValue = quoc_gia_id;
            }
        }
    }
}
