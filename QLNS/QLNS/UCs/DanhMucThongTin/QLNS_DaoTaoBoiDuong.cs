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
    public partial class QLNS_DaoTaoBoiDuong : UserControl
    {
        public CNVC_DaoTaoBoiDuong oCNVC_DaoTaoBoiDuong;
        public Business.HinhThucDaoTao oHinhThucDaoTao;
        public Business.VanBangChinhQuy oVanBangChinhQuy;
        public DataTable dtDaoTaoBoiDuong , dtDaoTao , dtBoiDuong , dtHinhThuc, dtVanBang;

        bool bAddDaoTaoFlag = false;
        bool bAddBoiDuongFlag = false;

        public QLNS_DaoTaoBoiDuong()
        {
            InitializeComponent();
            oCNVC_DaoTaoBoiDuong = new CNVC_DaoTaoBoiDuong();
            oHinhThucDaoTao = new Business.HinhThucDaoTao();
            oVanBangChinhQuy = new Business.VanBangChinhQuy();
            dtDaoTaoBoiDuong = new DataTable();
            dtHinhThuc = new DataTable();
            dtDaoTao = new DataTable();
            dtBoiDuong = new DataTable();
            dtVanBang = new DataTable();
        }

        public void GetDaoTaoBoiDuongInfo(string m_MaNV)
        {
            oCNVC_DaoTaoBoiDuong.MaNV = m_MaNV;
            dtDaoTaoBoiDuong = oCNVC_DaoTaoBoiDuong.GetData();
            if (dtDaoTaoBoiDuong.Rows.Count > 0)
            {
                dtDaoTao = dtDaoTaoBoiDuong.AsEnumerable().Where(a => a.Field<int?>("hinh_thuc_dao_tao_id").ToString() != "").CopyToDataTable();
                dtBoiDuong = dtDaoTaoBoiDuong.AsEnumerable().Where(a => a.Field<int?>("hinh_thuc_dao_tao_id").ToString() == "").CopyToDataTable();
                
            }
        }

        private void QLNS_DaoTaoBoiDuong_Load(object sender, EventArgs e)
        {
            LoadHinhThucData();
            LoadVanBangData();
        }

        private void LoadHinhThucData()
        {
            dtHinhThuc = oHinhThucDaoTao.GetData();

            DataTable dt = dtHinhThuc.Copy();

            if (dt.AsEnumerable().Where(a => a.Field<int>("id") == -1).Count() <= 0)
            {
                DataRow dr = dt.NewRow();
                dr["ten_hinh_thuc"] = "";
                dr["id"] = -1;
                dt.Rows.InsertAt(dr, 0);
            }
            
            // comb
            comB_HinhThuc.DataSource = dt;
            comB_HinhThuc.DisplayMember = "ten_hinh_thuc";
            comB_HinhThuc.ValueMember = "id";

            comB_HinhThuc.SelectedIndex = 0;
        }

        private void LoadVanBangData()
        {
            dtVanBang = oVanBangChinhQuy.GetData();

            DataTable dt = dtVanBang.Copy();

            if (dt.AsEnumerable().Where(a => a.Field<int>("id") == -1).Count() <= 0)
            {
                DataRow dr = dt.NewRow();
                dr["ten_van_bang"] = "";
                dr["id"] = -1;
                dt.Rows.InsertAt(dr, 0);
            }

            // comb
            comB_VanBang.DataSource = dt;
            comB_VanBang.DisplayMember = "ten_van_bang";
            comB_VanBang.ValueMember = "id";

            comB_VanBang.SelectedIndex = 0;
        }

        public void FillDaoTaoData()
        {
            if (dtDaoTao.Rows.Count > 0)
            {
                DataTable dt = dtDaoTao.Copy();
                dtgv_DaoTao.Columns.Clear();
                dtgv_DaoTao.DataSource = dt;
                Setup_dtgv_DaoTao();
            }
        }

        public void FillBoiDuongData()
        {
            if (dtBoiDuong.Rows.Count > 0)
            {
                DataTable dt = dtBoiDuong.Copy();
                dtgv_BoiDuong.Columns.Clear();
                dtgv_BoiDuong.DataSource = dt;
                Setup_dtgv_BoiDuong();
            }
        }

        #region Init Gridview

        private void Init_dtgv_DaoTao()
        {
            dtgv_DaoTao.Columns.Clear();
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();

            col = new DataGridViewTextBoxColumn();
            col.Name = "id";
            col.Visible = false;
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Tên trường";
            col.Name = "ten_truong";
            col.Width = 350;
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Chuyên ngành";
            col.Name = "chuyen_nganh_dao_tao";
            col.Width = 250;
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Từ ngày";
            col.Name = "tu_ngay";
            col.Width = 100;
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Đến ngày";
            col.Name = "den_ngay";
            col.Width = 100;
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.Name = "hinh_thuc_dao_tao_id";
            col.Visible = false;
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Hình thức";
            col.Name = "ten_hinh_thuc";
            col.Width = 200;
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Xếp loại";
            col.Name = "xep_loai";
            col.Width = 150;
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.Name = "cq_van_bang_id";
            col.Visible = false;
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Văn bằng";
            col.Name = "ten_van_bang";
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Tên luận văn";
            col.Name = "cq_ten_luan_van";
            dtgv_DaoTao.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Hội đồng chấm";
            col.Name = "cq_hoi_dong_cham";
            dtgv_DaoTao.Columns.Add(col);
        }

        private void Init_dtgv_BoiDuong()
        {
            dtgv_BoiDuong.Columns.Clear();
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();

            col = new DataGridViewTextBoxColumn();
            col.Name = "id";
            col.Visible = false;
            dtgv_BoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Tên trường";
            col.Name = "ten_truong";
            col.Width = 350;
            dtgv_BoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Chuyên ngành";
            col.Name = "chuyen_nganh_dao_tao";
            col.Width = 250;
            dtgv_BoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Từ ngày";
            col.Name = "tu_ngay";
            col.Width = 100;
            dtgv_BoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Đến ngày";
            col.Name = "den_ngay";
            col.Width = 100;
            dtgv_BoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Xếp loại";
            col.Name = "xep_loai";
            col.Width = 150;
            dtgv_BoiDuong.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Tên chứng chỉ";
            col.Name = "bd_ten_chung_chi";
            dtgv_BoiDuong.Columns.Add(col);


        } 
        #endregion

        private void Setup_dtgv_DaoTao()
        {
            dtgv_DaoTao.Columns["id"].Visible = dtgv_DaoTao.Columns["hinh_thuc_dao_tao_id"].Visible =
                dtgv_DaoTao.Columns["cq_van_bang_id"].Visible = dtgv_BoiDuong.Columns["bd_ten_chung_chi"].Visible = false; 

            //  
            dtgv_DaoTao.Columns["ten_truong"].HeaderText = "Tên trường";
            dtgv_DaoTao.Columns["ten_truong"].Width = 350;
            dtgv_DaoTao.Columns["chuyen_nganh_dao_tao"].HeaderText = "Chuyên ngành";
            dtgv_DaoTao.Columns["chuyen_nganh_dao_tao"].Width = 250;
            dtgv_DaoTao.Columns["tu_ngay"].HeaderText = "Từ ngày";
            dtgv_DaoTao.Columns["tu_ngay"].Width = 100;
            dtgv_DaoTao.Columns["den_ngay"].HeaderText = "Đến ngày";
            dtgv_DaoTao.Columns["den_ngay"].Width = 100;
            dtgv_DaoTao.Columns["ten_hinh_thuc"].HeaderText = "Hình thức";
            dtgv_DaoTao.Columns["ten_hinh_thuc"].Width = 200;
            dtgv_DaoTao.Columns["xep_loai"].HeaderText = "Xếp loại";
            dtgv_DaoTao.Columns["xep_loai"].Width = 150;
            dtgv_DaoTao.Columns["ten_van_bang"].HeaderText = "Văn bằng";
            dtgv_DaoTao.Columns["ten_van_bang"].Width = 200;
            dtgv_DaoTao.Columns["cq_ten_luan_van"].HeaderText = "Tên luận văn";
            dtgv_DaoTao.Columns["cq_ten_luan_van"].Width = 150;
            dtgv_DaoTao.Columns["cq_hoi_dong_cham"].HeaderText = "Hội đồng chấm";
            dtgv_DaoTao.Columns["cq_hoi_dong_cham"].Width = 150;
        }

        private void Setup_dtgv_BoiDuong()
        {
            dtgv_BoiDuong.Columns["id"].Visible = dtgv_DaoTao.Columns["hinh_thuc_dao_tao_id"].Visible =
                dtgv_DaoTao.Columns["cq_van_bang_id"].Visible = dtgv_DaoTao.Columns["ten_hinh_thuc"].Visible =
               dtgv_DaoTao.Columns["ten_van_bang"].Visible = dtgv_DaoTao.Columns["cq_ten_luan_van"].Visible =
               dtgv_DaoTao.Columns["cq_hoi_dong_cham"].Visible = false;

            //  
            dtgv_BoiDuong.Columns["ten_truong"].HeaderText = "Tên trường";
            dtgv_BoiDuong.Columns["ten_truong"].Width = 350;
            dtgv_BoiDuong.Columns["chuyen_nganh_dao_tao"].HeaderText = "Chuyên ngành";
            dtgv_BoiDuong.Columns["chuyen_nganh_dao_tao"].Width = 250;
            dtgv_BoiDuong.Columns["tu_ngay"].HeaderText = "Từ ngày";
            dtgv_BoiDuong.Columns["tu_ngay"].Width = 100;
            dtgv_BoiDuong.Columns["den_ngay"].HeaderText = "Đến ngày";
            dtgv_BoiDuong.Columns["den_ngay"].Width = 100;
            dtgv_BoiDuong.Columns["xep_loai"].HeaderText = "Xếp loại";
            dtgv_BoiDuong.Columns["xep_loai"].Width = 150;
            dtgv_BoiDuong.Columns["bd_ten_chung_chi"].HeaderText = "Tên chứng chỉ";
            dtgv_BoiDuong.Columns["bd_ten_chung_chi"].Width = 150;
        }

        private void dtgv_DaoTao_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgv_BoiDuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ControlDaoTao(bool Add)
        {

            if (Add)
            {
                lbl_SuaDaoTao.Text = "Huỷ";
                lbl_ThemDaoTao.Text = "Lưu";
                txt_TenTruong_DaoTao.Enabled = txt_ChuyenNganh_DaoTao.Enabled = txt_XepLoai_DaoTao.Enabled
                    = txt_TenLuanVan.Enabled = txt_HoiDong.Enabled = dTP_DenNgay_DaoTao.Enabled =
                    dTP_TuNgay_DaoTao.Enabled = comB_HinhThuc.Enabled = comB_VanBang.Enabled = true;
                dtgv_DaoTao.Enabled = lbl_XoaDaoTao.Enabled = false;
            }
            else
            {
                lbl_SuaDaoTao.Text = "Sửa";
                lbl_ThemDaoTao.Text = "Thêm";
                txt_TenTruong_DaoTao.Enabled = txt_ChuyenNganh_DaoTao.Enabled = txt_XepLoai_DaoTao.Enabled
                    = txt_TenLuanVan.Enabled = txt_HoiDong.Enabled = dTP_DenNgay_DaoTao.Enabled =
                    dTP_TuNgay_DaoTao.Enabled = comB_HinhThuc.Enabled = comB_VanBang.Enabled = false;
                dtgv_DaoTao.Enabled = lbl_XoaDaoTao.Enabled = true;

            }
        }

        private void ControlBoiDuong(bool Add)
        {

            if (Add)
            {
                lbl_SuaBoiDuong.Text = "Huỷ";
                lbl_ThemBoiDuong.Text = "Lưu";
                txt_TenTruong_BoiDuong.Enabled = txt_ChuyenNganh_BoiDuong.Enabled = txt_XepLoai_BoiDuong.Enabled
                    = txt_TenChungChi.Enabled =  dTP_DenNgay_DaoTao.Enabled =
                    dTP_TuNgay_DaoTao.Enabled =  true;
                dtgv_BoiDuong.Enabled = lbl_XoaBoiDuong.Enabled = false;
            }
            else
            {
                lbl_SuaBoiDuong.Text = "Sửa";
                lbl_ThemBoiDuong.Text = "Thêm";
                txt_TenTruong_BoiDuong.Enabled = txt_ChuyenNganh_BoiDuong.Enabled = txt_XepLoai_BoiDuong.Enabled
                    = txt_TenChungChi.Enabled = dTP_DenNgay_DaoTao.Enabled =
                    dTP_TuNgay_DaoTao.Enabled = false;
                dtgv_BoiDuong.Enabled = lbl_XoaBoiDuong.Enabled = true;

            }
        }
    }
}

