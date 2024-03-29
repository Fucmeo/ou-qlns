﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Npgsql;
using DataProvider;
using NpgsqlTypes;

namespace Business.CNVC
{
    public class CNVC
    {
        DataProvider.DataProvider dp;

        #region Init method

        public CNVC()
        {
            dp = new DataProvider.DataProvider();
        }
        

        #endregion

        #region Properties

        private string mahoso;

        public string MaHoSo
        {
            get { return mahoso; }
            set { mahoso = value; }
        }

        private string manv;

        public string MaNV
        {
            get { return manv; }
            set { manv = value; }
        }

        private string ho;

        public string Ho
        {
            get { return ho; }
            set { ho = value; }
        }

        private string ten;

        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }

        private string diachi;

        public string DiaChi
        {
            get { return diachi; }
            set { diachi = value; }
        }

        private string sonha;

        public string SoNha
        {
            get { return sonha; }
            set { sonha = value; }
        }

        private string duong;

        public string Duong
        {
            get { return duong; }
            set { duong = value; }
        }

        private string phuong;

        public string Phuong
        {
            get { return phuong; }
            set { phuong = value; }
        }

        private string quan;

        public string Quan
        {
            get { return quan; }
            set { quan = value; }
        }

        private int? tinh;

        public int? Tinh
        {
            get { return tinh; }
            set { tinh = value; }
        }

        private int? quocgia;

        public int? QuocGia
        {
            get { return quocgia; }
            set { quocgia = value; }
        }
        
        private string sobhxh;

        public string SoBHXH
        {
            get { return sobhxh; }
            set { sobhxh = value; }
        }

        private string masothue;

        public string MaSoThue
        {
            get { return masothue; }
            set { masothue = value; }
        }

        private DateTime? ngaysinh;

        public DateTime? NgaySinh
        {
            get { return ngaysinh; }
            set { ngaysinh = value; }
        }

        private bool? gioitinh;

        public bool? GioiTinh
        {
            get { return gioitinh; }
            set { gioitinh = value; }
        }

        public string Email { get; set; }

        public string DTDD { get; set; }

        public string DTBan { get; set; }
        

        #endregion

        #region Methods

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[17]{
                new NpgsqlParameter("p_ma_nv",manv), 
                new NpgsqlParameter("p_ho",ho), 
                new NpgsqlParameter("p_ten",ten), 
                new NpgsqlParameter("p_ma_ho_so",mahoso), 
                new NpgsqlParameter("p_so_so_bhxh",sobhxh), 
                new NpgsqlParameter("p_ma_so_thue",masothue), 
                new NpgsqlParameter("p_ngay_sinh",ngaysinh),
                new NpgsqlParameter("p_gioi_tinh",gioitinh),
                new NpgsqlParameter("p_so_nha",sonha), 
                new NpgsqlParameter("p_duong",duong), 
                new NpgsqlParameter("p_phuong_xa",phuong), 
                new NpgsqlParameter("p_quan_huyen",quan),
                new NpgsqlParameter("p_tinh_thanhpho",tinh),
                new NpgsqlParameter("p_quoc_gia",quocgia),
                new NpgsqlParameter("p_dt_di_dong",DTDD),
                new NpgsqlParameter("p_dt_nha_rieng",DTBan),
                new NpgsqlParameter("p_email",Email)
            };
            check = (int)dp.executeScalarProc("sp_insert_cnvc", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool Delete()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_ma_nv",manv)
            };

            check = (int)dp.executeScalarProc("sp_delete_cnvc", paras);
            if (check > 0)
                return true;
            else
                return false;

        }

        public bool Update(string ma_nv_old)
        {
            int check;
            IDataParameter[] paras = new IDataParameter[18]{
                new NpgsqlParameter("p_ma_nv_old",ma_nv_old), 
                new NpgsqlParameter("p_ma_nv",manv), 
                new NpgsqlParameter("p_ho",ho), 
                new NpgsqlParameter("p_ten",ten), 
                new NpgsqlParameter("p_ma_ho_so_goc",mahoso), 
                new NpgsqlParameter("p_so_so_bhxh",sobhxh), 
                new NpgsqlParameter("p_ma_so_thue",masothue), 
                new NpgsqlParameter("p_ngay_sinh",ngaysinh), 
                new NpgsqlParameter("p_gioi_tinh",gioitinh),
                new NpgsqlParameter("p_so_nha",sonha), 
                new NpgsqlParameter("p_duong",duong), 
                new NpgsqlParameter("p_phuong_xa",phuong), 
                new NpgsqlParameter("p_quan_huyen",quan),
                new NpgsqlParameter("p_tinh_thanhpho",tinh),
                new NpgsqlParameter("p_quoc_gia",quocgia),
                new NpgsqlParameter("p_dt_di_dong",DTDD),
                new NpgsqlParameter("p_dt_nha_rieng",DTBan),
                new NpgsqlParameter("p_email",Email)
            };
            check = (int)dp.executeScalarProc("sp_update_cnvc", paras);
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

            dt = dp.getDataTableProc("sp_select_cnvc", paras);

            return dt;
        }

        public DataTable GetAllCNVC()
        {
            DataTable dt;



            dt = dp.getDataTable("select * from v_cnvc");

            return dt;
        }

        public DataTable SearchDataForQD(bool bIngoreQTCT)
        {
            DataTable dt;

            IDataParameter[] paras = new IDataParameter[3]{
                new NpgsqlParameter("p_ma_nv",manv),               
                new NpgsqlParameter("p_ho",ho),
                new NpgsqlParameter("p_ten",ten)
            };
            if (bIngoreQTCT)
            {
                dt = dp.getDataTableProc("sp1_qsearch_nv_basic_info_ingore_qtct", paras);  
            }
            else
            {
                dt = dp.getDataTableProc("sp1_qsearch_nv_basic_info", paras);
            }
            

            return dt;
        }

        public DataTable GetDonViChucVuForQD()
        {
            DataTable dt;

            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_ma_nv",manv)               
            };

            dt = dp.getDataTableProc("sp1_qsearch_nv_qtrctac_info", paras);

            return dt;
        }

        public DataTable Search_Ho_Ten()
        {
            DataTable dt;

            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_ma_nv",manv)               
            };

            dt = dp.getDataTableProc("sp1_qsearch_hoten_nv", paras);

            return dt;
        }

        public DataTable Search_CNVC_by_DonVi(int p_don_vi_id)
        {
            DataTable dt;

            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_ma_don_vi",p_don_vi_id)               
            };

            dt = dp.getDataTableProc("sp1_qsearch_nv_by_donvi", paras);

            return dt;
        }

        public DataTable GetThamNienDT()
        {
            DataTable dt;

            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_ma_nv",manv)               
            };

            dt = dp.getDataTableProc("sp1_select_cnvc_tham_nien", paras);

            return dt;
        }

        public bool AddQtrCTacOU_FromChart(int p_don_vi_id, int? p_chuc_danh_id, int? p_chuc_vu_id,
            DateTime p_tu_thoi_gian, DateTime? p_den_thoi_gian, bool p_tinh_trang, bool p_tinh_tham_nien_nha_giao,
            bool p_tinh_tham_nien_nang_bac, bool p_trong_nganh_giao_duc)
        {
            int check;
            IDataParameter[] paras = new IDataParameter[10]{
                new NpgsqlParameter("p_ma_nv",manv), 
                new NpgsqlParameter("p_don_vi_id",p_don_vi_id), 
                new NpgsqlParameter("p_chuc_danh_id",p_chuc_danh_id), 
                new NpgsqlParameter("p_chuc_vu_id",p_chuc_vu_id), 
                new NpgsqlParameter("p_tu_thoi_gian",p_tu_thoi_gian), 
                new NpgsqlParameter("p_den_thoi_gian",p_den_thoi_gian), 
                new NpgsqlParameter("p_tinh_trang",p_tinh_trang),
                new NpgsqlParameter("p_tinh_tham_nien_nha_giao",p_tinh_tham_nien_nha_giao),
                new NpgsqlParameter("p_tinh_tham_nien_nang_bac",p_tinh_tham_nien_nang_bac),
                new NpgsqlParameter("p_trong_nganh_giao_duc",p_trong_nganh_giao_duc)
                
            };
            check = (int)dp.executeScalarProc("sp_insert_cnvc_qtr_ctac_ou_from_chart", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool UpdateQtrCTacOU_Chart(int id, int p_don_vi_id, int? p_chuc_danh_id, int? p_chuc_vu_id,
            DateTime p_tu_thoi_gian, DateTime? p_den_thoi_gian, bool p_tinh_trang, bool p_thay_doi_dv,bool p_tham_nien_nang_bac , bool p_trong_nganh_gd , bool p_tham_nien_nha_giao)
        {
            int check;
            IDataParameter[] paras = new IDataParameter[12]{
                new NpgsqlParameter("p_id",id), 
                new NpgsqlParameter("p_ma_nv",manv), 
                new NpgsqlParameter("p_don_vi_id",p_don_vi_id), 
                new NpgsqlParameter("p_chuc_danh_id",p_chuc_danh_id), 
                new NpgsqlParameter("p_chuc_vu_id",p_chuc_vu_id), 
                new NpgsqlParameter("p_tu_thoi_gian",p_tu_thoi_gian), 
                new NpgsqlParameter("p_den_thoi_gian",p_den_thoi_gian), 
                new NpgsqlParameter("p_tinh_trang",p_tinh_trang),
                new NpgsqlParameter("p_thay_doi_dv",p_thay_doi_dv),
                new NpgsqlParameter("p_trong_nganh_gd",p_trong_nganh_gd),
                new NpgsqlParameter("p_tham_nien_nha_giao",p_tham_nien_nha_giao),
                new NpgsqlParameter("p_tham_nien_nang_bac",p_tham_nien_nang_bac)

                
            };
            check = (int)dp.executeScalarProc("sp_update_cnvc_qtr_ctac_ou_from_chart", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        } 



        public bool AddThamNien(int? qtr_ctac_nonou_gd_id, int? qtr_ctac_ou_id, int? cnvc_qd_id,
           bool trong_nganh_gd, bool tham_nien_nha_giao, bool tham_nien_nang_bac ,
            bool tham_nien_cong_tac_ou, DateTime tu_ngay, DateTime? den_ngay, string ghi_chu)
        {
            int check;
            IDataParameter[] paras = new IDataParameter[11]{
                new NpgsqlParameter("p_ma_nv",manv), 
                new NpgsqlParameter("qtr_ctac_nonou_gd_id",qtr_ctac_nonou_gd_id), 
                new NpgsqlParameter("qtr_ctac_ou_id",qtr_ctac_ou_id), 
                new NpgsqlParameter("cnvc_qd_id",cnvc_qd_id), 
                new NpgsqlParameter("trong_nganh_gd",trong_nganh_gd), 
                new NpgsqlParameter("tham_nien_nha_giao",tham_nien_nha_giao), 
                new NpgsqlParameter("tham_nien_nang_bac",tham_nien_nang_bac),
                new NpgsqlParameter("tham_nien_cong_tac_ou",tham_nien_cong_tac_ou),
                new NpgsqlParameter("tu_ngay",tu_ngay),
                new NpgsqlParameter("den_ngay",den_ngay),
                new NpgsqlParameter("ghi_chu",ghi_chu)
            };
            check = (int)dp.executeScalarProc("sp_insert_cnvc_tham_nien", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool UpdateThamNien(int id, bool trong_nganh_gd, bool tham_nien_nha_giao, bool tham_nien_nang_bac,
            bool tham_nien_cong_tac_ou, DateTime tu_ngay, DateTime? den_ngay, string ghi_chu)
        {
            int check;
            IDataParameter[] paras = new IDataParameter[9]{
                new NpgsqlParameter("p_id",id), 
                new NpgsqlParameter("p_ma_nv",manv), 
                new NpgsqlParameter("p_trong_nganh_gd",trong_nganh_gd), 
                new NpgsqlParameter("p_tham_nien_nha_giao",tham_nien_nha_giao), 
                new NpgsqlParameter("p_tham_nien_nang_bac",tham_nien_nang_bac),
                new NpgsqlParameter("p_tham_nien_cong_tac_ou",tham_nien_cong_tac_ou),
                new NpgsqlParameter("p_tu_ngay",tu_ngay),
                new NpgsqlParameter("p_den_ngay",den_ngay),
                new NpgsqlParameter("p_ghi_chu",ghi_chu)
            };
            check = (int)dp.executeScalarProc("sp_update_cnvc_tham_nien", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool DeleteThamNien(int id)
        {
            int check;
            IDataParameter[] paras = new IDataParameter[2]{
                new NpgsqlParameter("p_id",id), 
                new NpgsqlParameter("p_ma_nv",manv)
            };
            check = (int)dp.executeScalarProc("sp_delete_cnvc_tham_nien", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public DataTable GetQtrCtacOUDT()
        {
            DataTable dt;

            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_ma_nv",manv)               
            };

            dt = dp.getDataTableProc("sp1_select_cnvc_qtr_ctac_ou_chart", paras);

            return dt;
        }

        public DataTable SearchNVForNgayPhep(int DV_ID,int CV_ID , int CD_ID , string Ho, string Ten , string MaNV)
        {
            DataTable dt;

            IDataParameter[] paras = new IDataParameter[6]{
                new NpgsqlParameter("p_donvi_id",DV_ID) ,              
                new NpgsqlParameter("p_chucvu_id",CV_ID) ,
                new NpgsqlParameter("p_chucdanh_id",CD_ID) ,
                new NpgsqlParameter("p_ma_nv",Ho) ,
                new NpgsqlParameter("p_ho",Ten) ,
                new NpgsqlParameter("p_ten",MaNV) 
            };

            dt = dp.getDataTableProc("sp1_search_nv_for_ngayphep", paras);

            return dt;
        }

        public bool AddNgayPhep(string[] p_ma_nv, int p_from, int p_to, double so_ngay)
        {
            int check;
            IDataParameter[] paras = new IDataParameter[4]{
                new NpgsqlParameter("p_manv",p_ma_nv), 
                new NpgsqlParameter("p_tu_nam",p_from), 
                new NpgsqlParameter("p_den_nam",p_to), 
                new NpgsqlParameter("p_so_ngay",so_ngay)
            };
            check = (int)dp.executeScalarProc("sp2_insert_so_ngay_phep", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public DataTable GetNgayCong()
        {
            DataTable dt = new DataTable();



            dt = dp.getDataTable("select * from v_ngaycong");

            return dt;
        }

        public bool AddNgayCong(int so_ngay, int tu_thang,int den_thang,string ghi_chu)
        {
            int check;
            IDataParameter[] paras = new IDataParameter[4]{
                new NpgsqlParameter("p_so_ngay",so_ngay), 
                new NpgsqlParameter("p_tu_thoi_gian",tu_thang), 
                new NpgsqlParameter("p_den_thoi_gian",den_thang), 
                new NpgsqlParameter("p_ghi_chu",ghi_chu) 
               
            };
            check = (int)dp.executeScalarProc("sp1_insert_ngay_cong", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }


        #endregion


    }
}
