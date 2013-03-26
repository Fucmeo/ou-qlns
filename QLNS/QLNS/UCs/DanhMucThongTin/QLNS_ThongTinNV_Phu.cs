﻿using System;
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
    public partial class QLNS_ThongTinNV_Phu : UserControl
    {
        public CNVC_ThongTinPhu oCNVC_ThongTinPhu;
        public DataTable dtCNVC_InfoPhu, dtQuocGia, dtTinhTP, dtTinhTrangHN;
        Business.TinhTP oTinhTP;
        Business.QuocGia oQuocGia;
        Business.TinhTrangHonNhan oTinhTrangHonNhan;

        public static int nNewTinhTPID = 0;     // ID cua tinh thanh pho moi them vao
        public static int nNewQuocGiaID = 0;     // ID cua quoc gia moi them vao

        public QLNS_ThongTinNV_Phu()
        {
            InitializeComponent();
            oCNVC_ThongTinPhu = new CNVC_ThongTinPhu();
            dtCNVC_InfoPhu = new DataTable();
            dtTinhTP = new DataTable();
            dtTinhTrangHN = new DataTable();
            oTinhTP = new Business.TinhTP();
            oQuocGia = new Business.QuocGia();
            oTinhTrangHonNhan = new Business.TinhTrangHonNhan();
        }

        private void QLNS_ThongTinNV_Phu_Load(object sender, EventArgs e)
        {
            GetComboData();

            SetupComboDS();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {

            if (Program.selected_ma_nv != "")
            {
                if ((MessageBox.Show("Thêm / cập nhật thông tin nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    try
                    {
                        GetUserInputDat();
                        if (QLNS_HienThiThongTin.bAddFlag)
                        {
                            oCNVC_ThongTinPhu.Add();
                        }
                        else
                        {
                            oCNVC_ThongTinPhu.Update();
                        }
                        MessageBox.Show("Thêm / cập nhật thông tin nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Thêm / cập nhật thông tin nhân viên không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        throw;
                    }

                }
            }
            else
            {
                MessageBox.Show("Chưa có thông tin về nhân viên, xin vui lòng thêm thông tin nhân viên trước hoặc chọn một nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
            
        }

        private void GetUserInputDat()
        {
            #region TextBox
            oCNVC_ThongTinPhu.MaNV = Program.selected_ma_nv;
            oCNVC_ThongTinPhu.TenGoiKhac = txt_TenGoiKhac.Text;
            oCNVC_ThongTinPhu.DanToc = txt_DanToc.Text;
            oCNVC_ThongTinPhu.ChieuCao = txt_ChieuCao.Text;
            oCNVC_ThongTinPhu.TonGiao = txt_TonGiao.Text;
            oCNVC_ThongTinPhu.NhomMau = txt_NhomMau.Text;
            oCNVC_ThongTinPhu.QueQuanXa = txt_QueXa.Text;
            oCNVC_ThongTinPhu.QueQuanHuyen = txt_QueHuyen.Text;
            oCNVC_ThongTinPhu.NoiSinhXa = txt_NoiSinhXa.Text;
            oCNVC_ThongTinPhu.NoiSinhHuyen = txt_NoiSinhHuyen.Text;
            oCNVC_ThongTinPhu.HoKhauThuongTruXa = txt_HoKhau_Xa.Text;
            oCNVC_ThongTinPhu.HoKhauThuongChu_Huyen = txt_HoKhau_Quan.Text; 
            #endregion

            #region Combo
            if (Convert.ToInt32(comB_QuocTich.SelectedValue) < 0)
                oCNVC_ThongTinPhu.QuocTinh = null;
            else
                oCNVC_ThongTinPhu.QuocTinh = Convert.ToInt32(comB_QuocTich.SelectedValue);

            if (Convert.ToInt32(comB_TinhTrangHonNhan.SelectedValue) < 0)
                oCNVC_ThongTinPhu.TinhTrangHonNhan = null;
            else
                oCNVC_ThongTinPhu.TinhTrangHonNhan = Convert.ToInt32(comB_TinhTrangHonNhan.SelectedValue);

            if (Convert.ToInt32(comB_QueTinh.SelectedValue) < 0)
                oCNVC_ThongTinPhu.QueQuanTinh = null;
            else
                oCNVC_ThongTinPhu.QueQuanTinh = Convert.ToInt32(comB_QueTinh.SelectedValue);

            if (Convert.ToInt32(comB_NoiSinhTinh.SelectedValue) < 0)
                oCNVC_ThongTinPhu.NoiSinhTinh = null;
            else
                oCNVC_ThongTinPhu.NoiSinhTinh = Convert.ToInt32(comB_NoiSinhTinh.SelectedValue);

            if (Convert.ToInt32(comB_HoKhauTinh.SelectedValue) < 0)
                oCNVC_ThongTinPhu.HoKhauThuongChu_Tinh = null;
            else
                oCNVC_ThongTinPhu.HoKhauThuongChu_Tinh = Convert.ToInt32(comB_HoKhauTinh.SelectedValue);

            if (Convert.ToInt32(comB_QueQuan_QuocGia.SelectedValue) < 0)
                oCNVC_ThongTinPhu.QueQuan_QuocGia = null;
            else
                oCNVC_ThongTinPhu.QueQuan_QuocGia = Convert.ToInt32(comB_QueQuan_QuocGia.SelectedValue);

            if (Convert.ToInt32(comB_HoKhau_QuocGia.SelectedValue) < 0)
                oCNVC_ThongTinPhu.HoKhauThuongTru_QuocGia = null;
            else
                oCNVC_ThongTinPhu.HoKhauThuongTru_QuocGia = Convert.ToInt32(comB_HoKhau_QuocGia.SelectedValue);


            #endregion

        }

        public void GetCNVCInfo_Phu(string m_MaNV)
        {
            oCNVC_ThongTinPhu.MaNV = m_MaNV;
            dtCNVC_InfoPhu = oCNVC_ThongTinPhu.GetData();
        }

        public void FillInfo()
        {
            if (dtCNVC_InfoPhu.Rows.Count > 0)
            {
                #region TextBox
                txt_TenGoiKhac.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0]["ten_goi_khac"]);
                txt_DanToc.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0]["dan_toc"]);
                txt_ChieuCao.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0]["chieu_cao"]);
                txt_TonGiao.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0]["ton_giao"]);
                txt_NhomMau.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0]["nhom_mau"]);
                txt_QueXa.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0]["que_quan_xa"]);
                txt_QueHuyen.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0]["que_quan_huyen"]);
                txt_NoiSinhXa.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0]["noi_sinh_xa"]);
                txt_NoiSinhHuyen.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0]["noi_sinh_huyen"]);
                txt_HoKhau_Xa.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0]["hokhau_thuongtru_xa"]);
                txt_HoKhau_Quan.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0]["hokhau_thuongtru_huyen"]); 
                #endregion

                #region Combo
                if (dtCNVC_InfoPhu.Rows[0]["hokhau_thuongtru_tinh"].ToString() != "")
                    comB_HoKhauTinh.SelectedValue = Convert.ToInt32(dtCNVC_InfoPhu.Rows[0]["hokhau_thuongtru_tinh"]);
                else
                    comB_HoKhauTinh.SelectedValue = -1;

                if (dtCNVC_InfoPhu.Rows[0]["quoc_tich"].ToString() != "")
                    comB_QuocTich.SelectedValue = Convert.ToInt32(dtCNVC_InfoPhu.Rows[0]["quoc_tich"]);
                else
                    comB_QuocTich.SelectedValue = -1;

                if (dtCNVC_InfoPhu.Rows[0]["que_quan_tinh"].ToString() != "")
                    comB_QueTinh.SelectedValue = Convert.ToInt32(dtCNVC_InfoPhu.Rows[0]["que_quan_tinh"]);
                else
                    comB_QueTinh.SelectedValue = -1;

                if (dtCNVC_InfoPhu.Rows[0]["ttr_hon_nhan_id"].ToString() != "")
                    comB_TinhTrangHonNhan.SelectedValue = Convert.ToInt32(dtCNVC_InfoPhu.Rows[0]["ttr_hon_nhan_id"]);
                else
                    comB_TinhTrangHonNhan.SelectedValue = -1;

                if (dtCNVC_InfoPhu.Rows[0]["noi_sinh_tinh"].ToString() != "")
                    comB_NoiSinhTinh.SelectedValue = Convert.ToInt32(dtCNVC_InfoPhu.Rows[0]["noi_sinh_tinh"]);
                else
                    comB_NoiSinhTinh.SelectedValue = -1;

                if (dtCNVC_InfoPhu.Rows[0]["que_quan_quoc_gia"].ToString() != "")
                    comB_QueQuan_QuocGia.SelectedValue = Convert.ToInt32(dtCNVC_InfoPhu.Rows[0]["que_quan_quoc_gia"]);
                else
                    comB_QueQuan_QuocGia.SelectedValue = -1;

                if (dtCNVC_InfoPhu.Rows[0]["hokhau_thuongtru_quoc_gia"].ToString() != "")
                    comB_HoKhau_QuocGia.SelectedValue = Convert.ToInt32(dtCNVC_InfoPhu.Rows[0]["hokhau_thuongtru_quoc_gia"]);
                else
                    comB_HoKhau_QuocGia.SelectedValue = -1;

                #endregion           
            }
        }

        public void GetComboData()
        {
            dtTinhTP = oTinhTP.GetData();
            dtTinhTrangHN = oTinhTrangHonNhan.GetData();
            dtQuocGia = oQuocGia.GetData();
        }

        public void SetupComboDS()
        {
            SetupTinhDS();

            #region Quoc Gia
            DataTable dt4 = dtQuocGia.Copy();
            if (dt4.AsEnumerable().Where(a => a.Field<int>("id") == -1).Count() <= 0)
            {
                DataRow dr = dt4.NewRow();
                dr["ten_quoc_gia"] = "";
                dr["id"] = -1;
                dt4.Rows.Add(dr);
            }
            comB_HoKhau_QuocGia.DataSource = dt4;
            comB_HoKhau_QuocGia.DisplayMember = "ten_quoc_gia";
            comB_HoKhau_QuocGia.ValueMember = "id";

            DataTable dt5 = dt4.Copy();

            comB_NoiSinh_QuocGia.DataSource = dt5;
            comB_NoiSinh_QuocGia.DisplayMember = "ten_quoc_gia";
            comB_NoiSinh_QuocGia.ValueMember = "id";

            DataTable dt6 = dt4.Copy();

            comB_QueQuan_QuocGia.DataSource = dt6;
            comB_QueQuan_QuocGia.DisplayMember = "ten_quoc_gia";
            comB_QueQuan_QuocGia.ValueMember = "id"; 

            #endregion


            comB_QuocTich.DataSource = dtQuocGia;
            comB_QuocTich.DisplayMember = "ten_quoc_gia";
            comB_QuocTich.ValueMember = "id";

            comB_TinhTrangHonNhan.DataSource = dtTinhTrangHN;
            comB_TinhTrangHonNhan.DisplayMember = "ten";
            comB_TinhTrangHonNhan.ValueMember = "id";

        }

        public void SetupTinhDS()
        {
            #region Tinh TP
            DataTable dt = dtTinhTP.Copy();
            if (dt.AsEnumerable().Where(a => a.Field<int>("id") == -1).Count() <= 0)
            {
                DataRow dr = dt.NewRow();
                dr["ten_tinh_tp"] = "";
                dr["id"] = -1;
                dr["quoc_gia_id"] = -1;
                dt.Rows.Add(dr);
            }

            comB_HoKhauTinh.DataSource = dt;
            comB_HoKhauTinh.DisplayMember = "ten_tinh_tp";
            comB_HoKhauTinh.ValueMember = "id";

            DataTable dt2 = dt.Copy();
            comB_NoiSinhTinh.DataSource = dt2;
            comB_NoiSinhTinh.DisplayMember = "ten_tinh_tp";
            comB_NoiSinhTinh.ValueMember = "id";

            DataTable dt3 = dt.Copy();
            comB_QueTinh.DataSource = dt3;
            comB_QueTinh.DisplayMember = "ten_tinh_tp";
            comB_QueTinh.ValueMember = "id";
            #endregion
        }

        private void comB_QuocGia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (((ComboBox)sender).Name)
            {
                case "comB_QueQuan_QuocGia":
                    ChangeTinhCombByQuocGia(comB_QueQuan_QuocGia,comB_QueTinh);
                    break;

                case "comB_NoiSinh_QuocGia":
                    ChangeTinhCombByQuocGia(comB_NoiSinh_QuocGia,comB_NoiSinhTinh);
                    break;

                case "comB_HoKhau_QuocGia":
                    ChangeTinhCombByQuocGia(comB_HoKhau_QuocGia,comB_HoKhauTinh);
                    break;

                default:
                    break;
            }
        }

        private void ChangeTinhCombByQuocGia(ComboBox Comb_QuocGia, ComboBox Comb_Tinh)
        {
            int v = Convert.ToInt32(Comb_QuocGia.SelectedValue);

            if (v == -1)    // combo quoc gia rong
            {
                LoadTinhData(dtTinhTP, Comb_Tinh);
            }
            else
            {
                var dt = dtTinhTP.AsEnumerable().Where(a => a.Field<int>("quoc_gia_id") == v);
                if (dt != null && dt.Count() > 0)
                {
                    LoadTinhData(dt.CopyToDataTable(), Comb_Tinh);
                }
                else
                {
                    LoadTinhData(null, Comb_Tinh);
                }
            }
        }

        public void LoadTinhData(DataTable dt, ComboBox Comb_Tinh)
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
            Comb_Tinh.DataSource = dt;
            Comb_Tinh.DisplayMember = "ten_tinh_tp";
            Comb_Tinh.ValueMember = "id";

        }

        private void comB_Tinh_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int v = Convert.ToInt32(((ComboBox)sender).SelectedValue);

            if (v != -1)    // combo tinh khac rong
            {
                var ids = from c in dtTinhTP.AsEnumerable()
                          where c.Field<int>("id") == v
                          select c.Field<int>("quoc_gia_id");

                int quoc_gia_id = ids.ElementAt<int>(0);

                switch (((ComboBox)sender).Name)
                {
                    case "comB_QueTinh":
                        comB_QueQuan_QuocGia.SelectedValue = quoc_gia_id;
                        ExcludeTinhData(comB_QueTinh,quoc_gia_id, v);
                        break;

                    case "comB_NoiSinhTinh":
                        comB_NoiSinh_QuocGia.SelectedValue = quoc_gia_id;
                        ExcludeTinhData(comB_NoiSinhTinh, quoc_gia_id, v);
                        break;

                    case "comB_HoKhauTinh":
                        comB_HoKhau_QuocGia.SelectedValue = quoc_gia_id;
                        ExcludeTinhData(comB_HoKhauTinh, quoc_gia_id, v);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// khi do full tinh vao combo, sau do chon 1 tinh, can phai exclude cac tinh o thuoc quoc gia do
        /// ==> loai bo nhung value tinh ra khoi combo
        /// </summary>
        /// <param name="Comb_Tinh"></param>
        /// <param name="quoc_gia_id"></param>
        /// <param name="SelectedValue">tinh mà ng dung da chon</param>
        private void ExcludeTinhData(ComboBox Comb_Tinh, int quoc_gia_id, int SelectedValue)
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
            Comb_Tinh.DataSource = dt2;
            Comb_Tinh.DisplayMember = "ten_tinh_tp";
            Comb_Tinh.ValueMember = "id";

            Comb_Tinh.SelectedValue = SelectedValue;
        }

        private void lbl_ThemTinh_Click(object sender, EventArgs e)
        {
            UCs.ThemTinhTP oThemTinhTP = new ThemTinhTP("QLNS_ThongTinNV_Phu");
            oThemTinhTP.Dock = DockStyle.Fill;
            Forms.Popup fPopup = new Forms.Popup("Thêm tỉnh thành phố", oThemTinhTP);
            fPopup.ShowDialog();
            if (nNewTinhTPID > 0)
            {
                int? v_Que = null, v_NoiSinh = null, v_HoKhau = null;

                if (comB_QueTinh.SelectedValue != Convert.DBNull && comB_QueTinh.SelectedValue != null)
                {
                    v_Que = Convert.ToInt16(comB_QueTinh.SelectedValue);
                }

                if (comB_HoKhauTinh.SelectedValue != Convert.DBNull && comB_HoKhauTinh.SelectedValue != null)
                {
                    v_HoKhau = Convert.ToInt16(comB_HoKhauTinh.SelectedValue);
                }

                if (comB_NoiSinhTinh.SelectedValue != Convert.DBNull && comB_NoiSinhTinh.SelectedValue != null)
                {
                    v_NoiSinh = Convert.ToInt16(comB_NoiSinhTinh.SelectedValue);
                }

                dtTinhTP = oTinhTP.GetData();

                SetupTinhDS();

                if (v_Que != null) comB_QueTinh.SelectedValue = v_Que;
                if (v_NoiSinh != null) comB_NoiSinhTinh.SelectedValue = v_NoiSinh;
                if (v_HoKhau != null) comB_HoKhauTinh.SelectedValue = v_HoKhau;

                nNewTinhTPID = 0;
            }
        }

        private void lbl_ThemQuocGia_Click(object sender, EventArgs e)
        {
            UCs.ThemQuocGia oThemQuocGia = new ThemQuocGia("QLNS_ThongTinNV_Phu");
            oThemQuocGia.Dock = DockStyle.Fill;
            Forms.Popup fPopup = new Forms.Popup("Thêm quốc gia", oThemQuocGia);
            fPopup.ShowDialog();
            if (nNewQuocGiaID > 0)
            {
                Label lbl = ((Label)sender);
                ComboBox com = null;
                switch (lbl.Name)
                {
                    case "lbl_ThemQueQuan_QuocGia":
                        com = comB_QueQuan_QuocGia;
                        break;

                    case "lbl_ThemNoiSinh_QuocGia":
                        com = comB_NoiSinh_QuocGia;
                        break;

                    case "lbl_ThemQuocGia_HoKhau":
                        com = comB_HoKhau_QuocGia;
                        break;

                    default:
                        break;
                }
                int? x = null;

                if (com.SelectedValue != Convert.DBNull && com.SelectedValue != null)
                    x = Convert.ToInt16(com.SelectedValue);

                dtQuocGia = oQuocGia.GetData();

                com.DataSource = dtQuocGia;
                com.DisplayMember = "ten_quoc_gia";
                com.ValueMember = "id";

                if (x != null)
                {
                    com.SelectedValue = x;
                }
                nNewQuocGiaID = 0;
            }
        }



    }
}
