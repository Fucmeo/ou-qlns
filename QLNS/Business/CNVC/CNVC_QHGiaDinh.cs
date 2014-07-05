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
    public class CNVC_QHGiaDinh
    {
        DataProvider.DataProvider dp;

        #region Init method

        public CNVC_QHGiaDinh()
        {
            dp = new DataProvider.DataProvider();
        }

        #endregion

        #region Properties

        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string manv;

        public string MaNV
        {
            get { return manv; }
            set { manv = value; }
        }

        private string moiquanhe;

        public string MoiQuanHe
        {
            get { return moiquanhe; }
            set { moiquanhe = value; }
        }

        public bool ThanNhanNuocNgoai { get; set; }

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

        private string namsinh;

        public string NamSinh
        {
            get { return namsinh; }
            set { namsinh = value; }
        }

        private string quequan;

        public string QueQuan
        {
            get { return quequan; }
            set { quequan = value; }
        }

        private string nghenghiep;

        public string NgheNghiep
        {
            get { return nghenghiep; }
            set { nghenghiep = value; }
        }

        private string chucdanh;

        public string ChucDanh
        {
            get { return chucdanh; }
            set { chucdanh = value; }
        }

        private string dvcongtac;

        public string DVCongTac
        {
            get { return dvcongtac; }
            set { dvcongtac = value; }
        }

        //private string diachi;

        //public string DiaChi
        //{
        //    get { return diachi; }
        //    set { diachi = value; }
        //}

        public string So_Nha { get; set; }

        public string Duong { get; set; }

        public string Phuong_Xa { get; set; }

        public string Quan_Huyen { get; set; }

        public int? Tinh_ThanhPho { get; set; }

        public int? Quoc_Gia { get; set; }

        private string thanhvientochucxh;

        public string ThanhVienToChucXH
        {
            get { return thanhvientochucxh; }
            set { thanhvientochucxh = value; }
        }

        private string hoctap;

        public string HocTap
        {
            get { return hoctap; }
            set { hoctap = value; }
        }

        private string ghichu;

        public string GhiChu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }

        public bool Is_Dang_vien { get; set; }
      

        #endregion

        #region Methods

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[20]{
                new NpgsqlParameter("ma_nv",manv), 
                new NpgsqlParameter("moi_quan_he",moiquanhe), 
                new NpgsqlParameter("than_nhan_nuoc_ngoai", ThanNhanNuocNgoai),
                new NpgsqlParameter("ho",ho), 
                new NpgsqlParameter("ten",ten),
                new NpgsqlParameter("nam_sinh",namsinh),
                new NpgsqlParameter("que_quan",quequan),
                new NpgsqlParameter("nghe_nghiep",nghenghiep),
                new NpgsqlParameter("chuc_danh_chuc_vu",chucdanh),
                new NpgsqlParameter("don_vi_cong_tac",dvcongtac),
                new NpgsqlParameter("so_nha",So_Nha),
                new NpgsqlParameter("duong",Duong),
                new NpgsqlParameter("phuong_xa",Phuong_Xa),
                new NpgsqlParameter("quan_huyen",Quan_Huyen),
                new NpgsqlParameter("tinh_thanhpho",Tinh_ThanhPho),
                new NpgsqlParameter("quoc_gia",Quoc_Gia),
                new NpgsqlParameter("thanh_vien_to_chuc_ctr_xh",thanhvientochucxh),
                new NpgsqlParameter("hoc_tap",hoctap),
                new NpgsqlParameter("ghi_chu",ghichu),
                new NpgsqlParameter("is_dang_vien",Is_Dang_vien),
            };
            check = (int)dp.executeScalarProc("sp_insert_cnvc_gia_dinh", paras);
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
            IDataParameter[] paras = new IDataParameter[20]{
                new NpgsqlParameter("p_id",id),
                //new NpgsqlParameter("ma_nv",manv), 
                new NpgsqlParameter("p_moi_quan_he",moiquanhe), 
                new NpgsqlParameter("p_than_nhan_nuoc_ngoai", ThanNhanNuocNgoai), 
                new NpgsqlParameter("p_ho",ho), 
                new NpgsqlParameter("p_ten",ten),
                new NpgsqlParameter("p_nam_sinh",namsinh),
                new NpgsqlParameter("p_que_quan",quequan),
                new NpgsqlParameter("p_nghe_nghiep",nghenghiep),
                new NpgsqlParameter("p_chuc_danh_chuc_vu",chucdanh),
                new NpgsqlParameter("p_don_vi_cong_tac",dvcongtac),
                new NpgsqlParameter("p_so_nha",So_Nha),
                new NpgsqlParameter("p_duong",Duong),
                new NpgsqlParameter("p_phuong_xa",Phuong_Xa),
                new NpgsqlParameter("p_quan_huyen",Quan_Huyen),
                new NpgsqlParameter("p_tinh_thanhpho",Tinh_ThanhPho),
                new NpgsqlParameter("p_thanh_vien_to_chuc_ctr_xh",thanhvientochucxh),
                new NpgsqlParameter("p_hoc_tap",hoctap),
                new NpgsqlParameter("p_ghi_chu",ghichu),
                new NpgsqlParameter("p_quoc_gia",Quoc_Gia),
                new NpgsqlParameter("p_is_dang_vien",Is_Dang_vien),
            };

            check = (int)dp.executeScalarProc("sp_update_cnvc_gia_dinh", paras);
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
                new NpgsqlParameter("p_id",id)
            };
            check = (int)dp.executeScalarProc("sp_delete_cnvc_quan_he_gia_dinh", paras);
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

            dt = dp.getDataTableProc("sp_select_cnvc_gia_dinh", paras);

            return dt;
        }

        #endregion

    }
}
