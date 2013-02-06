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

        private string diachi;

        public string DiaChi
        {
            get { return diachi; }
            set { diachi = value; }
        }

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
        

        #endregion

        #region Methods

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[13]{
                new NpgsqlParameter("ma_nv",manv), 
                new NpgsqlParameter("moi_quan_he",moiquanhe), 
                new NpgsqlParameter("ho",ho), 
                new NpgsqlParameter("ten",ten),
                new NpgsqlParameter("nam_sinh",namsinh),
                new NpgsqlParameter("que_quan",quequan),
                new NpgsqlParameter("nghe_nghiep",nghenghiep),
                new NpgsqlParameter("chuc_danh_chuc_vu",chucdanh),
                new NpgsqlParameter("don_vi_cong_tac",dvcongtac),
                new NpgsqlParameter("dia_chi",diachi),
                new NpgsqlParameter("thanh_vien_to_chuc_ctr_xh",thanhvientochucxh),
                new NpgsqlParameter("hoc_tap",hoctap),
                new NpgsqlParameter("ghi_chu",ghichu)
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
            IDataParameter[] paras = new IDataParameter[14]{
                new NpgsqlParameter("p_id",id),
                new NpgsqlParameter("ma_nv",manv), 
                new NpgsqlParameter("moi_quan_he",moiquanhe), 
                new NpgsqlParameter("ho",ho), 
                new NpgsqlParameter("ten",ten),
                new NpgsqlParameter("nam_sinh",namsinh),
                new NpgsqlParameter("que_quan",quequan),
                new NpgsqlParameter("nghe_nghiep",nghenghiep),
                new NpgsqlParameter("chuc_danh_chuc_vu",chucdanh),
                new NpgsqlParameter("don_vi_cong_tac",dvcongtac),
                new NpgsqlParameter("dia_chi",diachi),
                new NpgsqlParameter("thanh_vien_to_chuc_ctr_xh",thanhvientochucxh),
                new NpgsqlParameter("hoc_tap",hoctap),
                new NpgsqlParameter("ghi_chu",ghichu)
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
                new NpgsqlParameter("p_ma_nv",manv)
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
