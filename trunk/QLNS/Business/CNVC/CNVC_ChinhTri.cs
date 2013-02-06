using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Npgsql;
using DataProvider;

namespace Business.CNVC
{
    public class CNVC_ChinhTri
    {
        DataProvider.DataProvider dp;

        #region Init method

        public CNVC_ChinhTri()
        {
            dp = new DataProvider.DataProvider();
        }

        #endregion

        #region Properties

        private string manv;

        public string MaNV
        {
            get { return manv; }
            set { manv = value; }
        }

        private bool? dangvien;

        public bool? DangVien
        {
            get { return dangvien; }
            set { dangvien = value; }
        }

        private bool? doanvien;
            
        public bool? DoanVien
        {
            get { return doanvien; }
            set { doanvien = value; }
        }

        private DateTime? ngayvaodang;

        public DateTime? NgayVaoDang
        {
            get { return ngayvaodang; }
            set { ngayvaodang = value; }
        }


        private DateTime? ngayvaodoan;

        public DateTime? NgayVaoDoan
        {
            get { return ngayvaodoan; }
            set { ngayvaodoan = value; }
        }

        private DateTime? ngayradang;

        public DateTime? NgayRaDang
        {
            get { return ngayradang; }
            set { ngayradang = value; }
        }

        private DateTime? ngayradoan;

        public DateTime? NgayRaDoan
        {
            get { return ngayradoan; }
            set { ngayradoan = value; }
        }

        private DateTime? ngaytaivaodang;

        public DateTime? NgayTaiVaoDang
        {
            get { return ngaytaivaodang; }
            set { ngaytaivaodang = value; }
        }

        private DateTime? ngaytaivaodoan;

        public DateTime? NgayTaiVaoDoan
        {
            get { return ngaytaivaodoan; }
            set { ngaytaivaodoan = value; }
        }
        

        private DateTime? ngaychinhthuc;

        public DateTime? NgayChinhThuc
        {
            get { return ngaychinhthuc; }
            set { ngaychinhthuc = value; }
        }

        private string lyluanchinhtri;

        public string LyLuanChinhTri
        {
            get { return lyluanchinhtri; }
            set { lyluanchinhtri = value; }
        }

        private string quanlynhanuoc;

        public string QuanLyNhaNuoc
        {
            get { return quanlynhanuoc; }
            set { quanlynhanuoc = value; }
        }

        private DateTime? ngaynhapngu;

        public DateTime? NgayNhapNgu
        {
            get { return ngaynhapngu; }
            set { ngaynhapngu = value; }
        }

        private DateTime? ngayxuatngu;

        public DateTime? NgayXuatNgu
        {
            get { return ngayxuatngu; }
            set { ngayxuatngu = value; }
        }

        private string quanhamcaonhat;

        public string QuanHamCaoNhat
        {
            get { return quanhamcaonhat; }
            set { quanhamcaonhat = value; }
        }

        private string danhhieucaonhat;

        public string DanhHieuCaoNhat
        {
            get { return danhhieucaonhat; }
            set { danhhieucaonhat = value; }
        }

        private string thuongbinhhang;

        public string ThuongBinhHang
        {
            get { return thuongbinhhang; }
            set { thuongbinhhang = value; }
        }

        private string gdchinhsach;

        public string GDChinhSach
        {
            get { return gdchinhsach; }
            set { gdchinhsach = value; }
        }

        private string khenthuong;

        public string KhenThuong
        {
            get { return khenthuong; }
            set { khenthuong = value; }
        }

        private string kyluat;

        public string KyLuat
        {
            get { return kyluat; }
            set { kyluat = value; }
        }

        private bool? iscongdoanvien;

        public bool? IsCongDoanVien
        {
            get { return iscongdoanvien; }
            set { iscongdoanvien = value; }
        }
        

        #endregion

        #region Methods

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[21]{
                new NpgsqlParameter("ma_nv",manv), 
                new NpgsqlParameter("dang_vien",dangvien), 
                new NpgsqlParameter("doan_vien",doanvien), 
                new NpgsqlParameter("ngay_vao_dang",ngayvaodang), 
                new NpgsqlParameter("ngay_vao_doan",ngayvaodoan),
                new NpgsqlParameter("ngay_ra_khoi_dang",ngayradang),
                new NpgsqlParameter("ngay_ra_khoi_doan",ngayradoan),
                new NpgsqlParameter("ngay_tai_gia_nhap_dang",ngaytaivaodang),
                new NpgsqlParameter("ngay_tai_gia_nhap_doan",ngaytaivaodoan),
                                new NpgsqlParameter("ngay_chinh_thuc",ngaychinhthuc),
                new NpgsqlParameter("ly_luan_chinh_tri",lyluanchinhtri),
                new NpgsqlParameter("quan_ly_nha_nuoc",quanlynhanuoc),

                new NpgsqlParameter("ngay_nhap_ngu",ngaynhapngu),
                new NpgsqlParameter("ngay_xuat_ngu",ngayxuatngu),
                new NpgsqlParameter("quan_ham_cao_nhat",quanhamcaonhat),
                new NpgsqlParameter("danh_hieu_cao_nhat",danhhieucaonhat),
                new NpgsqlParameter("thuong_binh_hang",thuongbinhhang),
                new NpgsqlParameter("gia_dinh_chinh_sach",gdchinhsach),
                new NpgsqlParameter("khen_thuong",khenthuong),
                new NpgsqlParameter("ky_luat",kyluat),
                new NpgsqlParameter("is_cong_doan_vien",iscongdoanvien)
            };
            check = (int)dp.executeScalarProc("sp_insert_cnvc_chinh_tri", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }


        public bool Update()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[21]{
                new NpgsqlParameter("p_ma_nv",manv), 
                new NpgsqlParameter("p_dang_vien",dangvien), 
                new NpgsqlParameter("p_doan_vien",doanvien), 
                new NpgsqlParameter("p_ngay_vao_dang",ngayvaodang), 
                new NpgsqlParameter("p_ngay_vao_doan",ngayvaodoan),
                new NpgsqlParameter("p_ngay_ra_khoi_dang",ngayradang),
                new NpgsqlParameter("p_ngay_ra_khoi_doan",ngayradoan),
                new NpgsqlParameter("p_ngay_tai_gia_nhap_dang",ngaytaivaodang),
                new NpgsqlParameter("p_ngay_tai_gia_nhap_doan",ngaytaivaodoan),
                new NpgsqlParameter("p_ngay_chinh_thuc",ngaychinhthuc),
                new NpgsqlParameter("p_ly_luan_chinh_tri",lyluanchinhtri),
                new NpgsqlParameter("p_quan_ly_nha_nuoc",quanlynhanuoc),
                new NpgsqlParameter("p_ngay_nhap_ngu",ngaynhapngu),
                new NpgsqlParameter("p_ngay_xuat_ngu",ngayxuatngu),
                new NpgsqlParameter("p_quan_ham_cao_nhat",quanhamcaonhat),
                new NpgsqlParameter("p_danh_hieu_cao_nhat",danhhieucaonhat),
                new NpgsqlParameter("p_thuong_binh_hang",thuongbinhhang),
                new NpgsqlParameter("p_gia_dinh_chinh_sach",gdchinhsach),
                new NpgsqlParameter("p_khen_thuong",khenthuong),
                new NpgsqlParameter("p_ky_luat",kyluat),
                new NpgsqlParameter("p_is_cong_doan_vien",iscongdoanvien)
            };

            check = (int)dp.executeScalarProc("sp_update_cnvc_chinh_tri", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public DataTable GetData()
        {
            DataTable dt;

            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_ma_nv",manv)               
            };

            dt = dp.getDataTableProc("sp_select_cnvc_chinh_tri", paras);

            return dt;
        }
        
        #endregion
    }
}
