using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.CNVC;
using System.IO;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace QLNS.UCs.DanhMucThongTin
{
    public partial class QLNS_ThongTinNV : UserControl
    {
        public CNVC oCNVC ;
        public CNVC_CMND_HoChieu oCMND_HoChieu;
        public CNVC_File oFile ;
        public DataTable dtCNVC , dtCMND , dtTinhTP, dtQuocGia , dtAvatar;
        Business.TinhTP oTinhTP;
        Business.QuocGia oQuocGia;
        Business.FTP oFTP;
        bool bAddCNVCFlag = false , bAddCMNDFlag = false ;
        string[] AvatarPath ;

        public static int nNewTinhTPID = 0;     // ID cua tinh thanh pho moi them vao
        public static int nNewQuocGiaID = 0;     // ID cua quoc gia moi them vao

        public QLNS_ThongTinNV()
        {
            InitializeComponent();
            oCNVC = new CNVC();
            dtCNVC = new DataTable();
            dtAvatar = new DataTable();
            dtCMND = new DataTable();
            dtTinhTP = new DataTable();
            dtQuocGia = new DataTable();
            oTinhTP = new Business.TinhTP();
            oQuocGia = new Business.QuocGia();
            oCMND_HoChieu = new CNVC_CMND_HoChieu();
            oFile = new CNVC_File();
            oFTP = new Business.FTP();
            AvatarPath = new string[1];
        }

        public void GetCNVC_CMNDInfo(string m_MaNV)
        {

            Get_CNVC_Info(m_MaNV);
            try
            {
                oCMND_HoChieu.MaNV = m_MaNV;
                dtCMND = oCMND_HoChieu.GetData();
            }
            catch (Exception)
            {
                
            }
        }

        private void Get_CNVC_Info(string m_MaNV)
        {
            try
            {
                oCNVC.MaNV = m_MaNV;
                dtCNVC = oCNVC.GetData();
            }
            catch (Exception)
            {

            }
        }

        private void QLNS_ThongTinNV_Load(object sender, EventArgs e)
        {
            LoadQuocGiaData();
            if (comB_QuocGia.Items.Count > 0)
                comB_QuocGia.SelectedIndex = 0;

            
                LoadTinhData(dtTinhTP.Copy());
            
            comB_CMND_HoChieu.SelectedIndex = comB_TinhTrang.SelectedIndex = 0;
            Init_dtgv_CMNDHoChieu();

        }

        public void FillInfo()
        {
            Fill_CNVC_Info();

            ClearCMNDData();
            dtgv_CMNDHoChieu.DataSource = null;
            dtgv_CMNDHoChieu.Columns.Clear();
            if (dtCMND.Rows.Count > 0)
            {
                DataTable dt = dtCMND.Copy();
                dtgv_CMNDHoChieu.DataSource = dt;
                Setup_dtgv_CMNDHoChieu();
                
            }

        }

        private void Fill_CNVC_Info()
        {
            if (dtCNVC.Rows.Count > 0)
            {
                txt_MaHoSo.Text = Convert.ToString(dtCNVC.Rows[0]["ma_ho_so_goc"]);
                txt_MaNV.Text = Convert.ToString(dtCNVC.Rows[0]["ma_nv"]);
                txt_Ho.Text = Convert.ToString(dtCNVC.Rows[0]["ho"]);
                txt_Ten.Text = Convert.ToString(dtCNVC.Rows[0]["ten"]);
                txt_SoSoBHXH.Text = Convert.ToString(dtCNVC.Rows[0]["so_so_bhxh"]);
                txt_MaSoThue.Text = Convert.ToString(dtCNVC.Rows[0]["ma_so_thue"]);
                txt_SoNha.Text = Convert.ToString(dtCNVC.Rows[0]["so_nha"]);
                txt_Duong.Text = Convert.ToString(dtCNVC.Rows[0]["duong"]);
                txt_PhuongXa.Text = Convert.ToString(dtCNVC.Rows[0]["phuong_xa"]);
                txt_QuanHuyen.Text = Convert.ToString(dtCNVC.Rows[0]["quan_huyen"]);
                txt_DTDD.Text = Convert.ToString(dtCNVC.Rows[0]["p_dt_di_dong"]);
                txt_DTNha.Text = Convert.ToString(dtCNVC.Rows[0]["p_dt_nha_rieng"]);
                txt_Email.Text = Convert.ToString(dtCNVC.Rows[0]["p_email"]);
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
        }

        public void FillAvatar()
        {
            if (AvatarPath[0]!= null && AvatarPath[0] != "")
            {
                try
                {
                    picB_HinhDaiDien.Image = Image.FromFile(AvatarPath[0]);
                    picB_HinhDaiDien.ImageLocation = AvatarPath[0];
                    //btn_DelAvatar.Enabled = true;
                }
                catch (Exception )
                {
                    MessageBox.Show("Quá trình nạp hình không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                RemoveAvatar();
            }
        }

        private void btn_LuuCNVC_Click(object sender, EventArgs e)
        {
            #region Thong Tin NV

            if (btn_LuuCNVC.ImageKey == "Edit Data.png")
            {
                EnableCNVCControl(true);
            }
            else
            {
                bool bUploadInfoSuccess = false;
                bool Yes = MessageBox.Show("Thêm / cập nhật nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                if (VerifyCNVCData())
                {
                    if (Yes)
                    {
                        try
                        {
                            GetCNVCInfoData();
                            if (QLNS_HienThiThongTin.bAddFlag)
                            {
                                oCNVC.Add();
                                Program.selected_ma_nv = oCNVC.MaNV;
                                MessageBox.Show("Thêm nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                oCNVC.Update(Program.selected_ma_nv);
                                MessageBox.Show("Cập nhật nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            bUploadInfoSuccess = true;
                            EnableCNVCControl(false);
                            Get_CNVC_Info(Program.selected_ma_nv);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Thông tin nhân viên không phù hợp, xin vui lòng xem lại thông tin nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        if (bUploadInfoSuccess)
                        {
                            UploadAvatar();
                        }
                    }
                    bUploadInfoSuccess = false;
                }
                else
                {
                    MessageBox.Show("Thông tin không đầy đủ hoặc chưa chính xác, xin vui lòng xem lại thông tin nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } 
            }

            
            #endregion

            
        }

        private void UploadAvatar()
        {
            #region Avatar

                if (picB_HinhDaiDien.ImageLocation != "" && AvatarPath[0] != picB_HinhDaiDien.ImageLocation)
                {
                    string[] ServerPath = new string[1];

                    try
                    {
                        ServerPath = oFTP.UploadFile(new string[1] { picB_HinhDaiDien.ImageLocation },
                                                    new string[1] { picB_HinhDaiDien.ImageLocation.Split('\\').Last() }, oFile.MaNV);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Quá trình tải hình lên server không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (Program.selected_ma_nv != "")
                        oFile.MaNV = Program.selected_ma_nv;
                    else
                        oFile.MaNV = txt_MaNV.Text.Trim();

                    oFile.FileType = CNVC_File.eFileType.Avatar;

                    try
                    {
                        oFile.AddFileArray(ServerPath);

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Quá trình lưu hình không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else if (picB_HinhDaiDien.ImageLocation == "" && AvatarPath[0] != "")
                {
                    if (Program.selected_ma_nv != "")
                        oFile.MaNV = Program.selected_ma_nv;
                    else
                        oFile.MaNV = txt_MaNV.Text.Trim();

                    oFile.FileType = CNVC_File.eFileType.Avatar;
                    oFile.DeleteAvatar();
                }
            


            #endregion
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
                dt.Rows.InsertAt(dr,0);
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
            if (string.IsNullOrWhiteSpace(txt_MaHoSo.Text) || string.IsNullOrWhiteSpace(txt_MaNV.Text)
                || string.IsNullOrWhiteSpace(txt_Ho.Text) || string.IsNullOrWhiteSpace(txt_Ten.Text))
            {
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txt_Email.Text.Trim()))
            {
                Regex reg = new Regex(@"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$"); ///Object initialization for Regex 
                if (!reg.IsMatch(txt_Email.Text.Trim()))
                    return false;
            }
            

            //try
            //{
            //     MailAddress ma = new MailAddress(txt_Email.Text.Trim());
            //}
            //catch (Exception)
            //{
            //    return false;
            //}

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
            oCNVC.DTBan = txt_DTNha.Text;
            oCNVC.DTDD = txt_DTDD.Text;
            oCNVC.Email = txt_Email.Text;
            if (comB_GioiTinh.SelectedIndex == 0)
                oCNVC.GioiTinh = true;
            else if (comB_GioiTinh.SelectedIndex == 1)
                oCNVC.GioiTinh = false;
            else if (comB_GioiTinh.SelectedIndex == 2)
                oCNVC.GioiTinh = null;

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

            if (dTP_NgaySinh.Checked)
                oCNVC.NgaySinh = dTP_NgaySinh.Value;
            else
                oCNVC.NgaySinh = null;
            
        }

        private void GetCMNDInputData()
        {
            if (VerifyCMNDData())
            {
                if(bAddCMNDFlag == false)
                    oCMND_HoChieu.ID = Convert.ToInt32(dtgv_CMNDHoChieu.SelectedRows[0].Cells[6].Value);

                oCMND_HoChieu.MaNV = Program.selected_ma_nv;
                
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

        public void GetAvatar(string m_MaNV)
        {
            AvatarPath[0] = null;
            oFile.MaNV = m_MaNV;
            oFile.FileType = CNVC_File.eFileType.Avatar;
            dtAvatar = oFile.GetData();
            if (dtAvatar != null && dtAvatar.Rows.Count > 0)
            {
                // Download 
                string[] Paths = new string[1];
                Paths[0] = dtAvatar.Rows[0]["path"].ToString();
                if (Paths[0].ToString() != "")
                {
                    try
                    {
                        RemoveAvatar();
                        AvatarPath = oFTP.DownloadFile(Paths);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Quá trình tải hình đại diện không thành công \r\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                
                
            }
            else
            {
                RemoveAvatar();
            }
        }

        private void RemoveAvatar()
        {
            btn_DelAvatar.Enabled = false;
            if (picB_HinhDaiDien.Image != null)
            {
                
                picB_HinhDaiDien.Image.Dispose();
                picB_HinhDaiDien.Image = null;
                picB_HinhDaiDien.ImageLocation = "";
                
            }
            openFileDialog1.FileName = null;
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

                if (x != null)
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

                if (x!= null)
                {
                    comB_QuocGia.SelectedValue = x;
                }
                nNewQuocGiaID = 0;


            }
        }

        private void lbl_ThemCMND_Click(object sender, EventArgs e)
        {
            #region MyRegion

            if (Program.selected_ma_nv != "")
            {
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
                                    try
                                    {
                                        dtCMND = oCMND_HoChieu.GetData();
                                        dtgv_CMNDHoChieu.Columns.Clear();
                                        dtgv_CMNDHoChieu.DataSource = dtCMND;
                                        Setup_dtgv_CMNDHoChieu();
                                    }
                                    catch (Exception)
                                    {
                                    }


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
                                    try
                                    {
                                        dtCMND = oCMND_HoChieu.GetData();
                                        dtgv_CMNDHoChieu.Columns.Clear();
                                        dtgv_CMNDHoChieu.DataSource = dtCMND;
                                        Setup_dtgv_CMNDHoChieu();
                                    }
                                    catch (Exception)
                                    {
                                    }

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
            }
            else
            {
                MessageBox.Show("Chưa có thông tin về nhân viên, xin vui lòng thêm thông tin nhân viên trước hoặc chọn một nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            #endregion
            
        }

        private void lbl_SuaCMND_Click(object sender, EventArgs e)
        {
            if (lbl_SuaCMND.Text == "Sửa")  
            {
                if (dtgv_CMNDHoChieu.SelectedRows.Count  != 0)
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
                if (dtgv_CMNDHoChieu.SelectedRows.Count > 0) dtgv_CMNDHoChieu.SelectedRows[0].Selected = false;
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
            txt_NoiCap.Enabled = txt_MaSo.Enabled = dTP_NgayCap.Enabled = comB_CMND_HoChieu.Enabled = comB_TinhTrang.Enabled = Add;
            dtgv_CMNDHoChieu.Enabled = lbl_XoaCMND.Enabled = !Add;

            if (Add)
            {
                lbl_SuaCMND.Text = "Huỷ";
                lbl_ThemCMND.Text = "Lưu";
                
            }
            else
            {
                lbl_SuaCMND.Text = "Sửa";
                lbl_ThemCMND.Text = "Thêm";
            }
        }

        public void EnableCNVCControl(bool bEnable)
        {
            picB_HinhDaiDien.Enabled = btn_DelAvatar.Enabled  = txt_DTDD.Enabled = txt_DTNha.Enabled = txt_MaHoSo.Enabled
                = txt_MaNV.Enabled = txt_Ho.Enabled = txt_Ten.Enabled = txt_Email.Enabled
                = txt_MaSoThue.Enabled = dTP_NgaySinh.Enabled = comB_GioiTinh.Enabled
                = tableLP_DiaChi.Enabled = tableLP_QuocGia.Enabled  = bEnable;
            btn_Huy.Visible = bEnable;

            if (bEnable)
            {
                btn_LuuCNVC.ImageKey = "Save.png";
            }
            else
            {
                btn_LuuCNVC.ImageKey = "Edit Data.png";
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
            if (dtgv_CMNDHoChieu.Rows.Count > 0) 
                dtgv_CMNDHoChieu.Rows[0].Selected = false;

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

        private void comB_Tinh_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int v = Convert.ToInt32(comB_Tinh.SelectedValue);

            if (v != -1)    // combo tinh rong
            {
                var ids = from c in dtTinhTP.AsEnumerable()
                          where c.Field<int>("id") == v
                          select c.Field<int>("quoc_gia_id");

                int quoc_gia_id = ids.ElementAt<int>(0);

                comB_QuocGia.SelectedValue = quoc_gia_id;
                ExcludeTinhData(quoc_gia_id, v);
            }
        }

        /// <summary>
        /// khi do full tinh vao combo, sau do chon 1 tinh, can phai exclude cac tinh o thuoc quoc gia do
        /// ==> loai bo nhung value tinh ra khoi combo
        /// </summary>
        /// <param name="quoc_gia_id"></param>
        /// <param name="SelectedValue">tinh mà ng dung da chon</param>
        private void ExcludeTinhData( int quoc_gia_id, int SelectedValue)
        {
            var dt = dtTinhTP.AsEnumerable().Where(a => a.Field<int>("quoc_gia_id") == quoc_gia_id);
            DataTable dt2 = dt.CopyToDataTable();
            if (dt2.AsEnumerable().Where(a => a.Field<int>("id") == -1).Count() <= 0)
            {
                DataRow dr = dt2.NewRow();
                dr["ten_tinh_tp"] = "";
                dr["id"] = -1;
                dr["quoc_gia_id"] = -1;
                dt2.Rows.Add(dr);
            }

            // comb
            comB_Tinh.DataSource = dt2;
            comB_Tinh.DisplayMember = "ten_tinh_tp";
            comB_Tinh.ValueMember = "id";

            comB_Tinh.SelectedValue = SelectedValue;
        }

        private void lbl_XoaCMND_Click(object sender, EventArgs e)
        {
            if (dtgv_CMNDHoChieu.SelectedRows.Count != 0 &&
                (MessageBox.Show("Xoá dòng dữ liệu CMND / Hộ chiếu của nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                DataGridViewRow r = dtgv_CMNDHoChieu.SelectedRows[0];
                oCMND_HoChieu.ID = Convert.ToInt32(r.Cells[6].Value);

                try
                {
                    oCMND_HoChieu.Delete();
                    // load lai dtgv_CMND
                    //oCMND_HoChieu.MaNV = Program.selected_ma_nv;
                    dtCMND = oCMND_HoChieu.GetData();
                    dtgv_CMNDHoChieu.DataSource = dtCMND;
                    Setup_dtgv_CMNDHoChieu();
                    ClearCMNDData();

                    MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                catch (Exception)
                {
                    MessageBox.Show("Xoá không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }

        private void picB_HinhDaiDien_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (oFTP.ChecFileSize(new string[]{openFileDialog1.FileName}))
                {
                    try
                    {
                        picB_HinhDaiDien.Image = Image.FromFile(openFileDialog1.FileName);
                        picB_HinhDaiDien.ImageLocation = openFileDialog1.FileName;
                        btn_DelAvatar.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Quá trình nạp hình thất bại" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Tập tin không được lớn hơn 2,5 MB.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
        }

        private void btn_DelAvatar_Click(object sender, EventArgs e)
        {
            if (picB_HinhDaiDien.Image != null && MessageBox.Show("Bạn muốn xoá hình đại diện này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //oFile.MaNV = Program.selected_ma_nv;
                //oFile.DeleteAvatar();

                RemoveAvatar();
            }
        }

        private void txt_DTDD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            EnableCNVCControl(false);
            Fill_CNVC_Info();
        }
    }
}
