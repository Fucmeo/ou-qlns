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

        public string Ma_NV { get; set; }

        public string Ly_Luan_Chinh_Tri { get; set; }

        public string Quan_Ly_Nha_Nuoc { get; set; }

        public DateTime? Ngay_Nhap_Ngu { get; set; }

        public DateTime? Ngay_Xuat_Ngu { get; set; }

        public string Quan_Ham_Cao_Nhat { get; set; }

        public string Danh_Hieu_Cao_Nhat { get; set; }

        public string Thuong_Binh_Hang { get; set; }

        public string Gia_Dinh_Chinh_Sach { get; set; }

        public string Khen_Thuong { get; set; }

        public string Ky_Luat { get; set; }

        #endregion

        #region Methods

        
        public DataTable GetData()
        {
            DataTable dt;

            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_ma_nv",Ma_NV)               
            };

            dt = dp.getDataTableProc("sp_select_cnvc_chinh_tri", paras);

            return dt;
        }

        public bool Save()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[11]{
                new NpgsqlParameter("p_ma_nv",Ma_NV), 
                new NpgsqlParameter("p_ly_luan_chinh_tri",Ly_Luan_Chinh_Tri), 
                new NpgsqlParameter("p_quan_ly_nha_nuoc",Quan_Ly_Nha_Nuoc), 
                new NpgsqlParameter("p_ngay_nhap_ngu",Ngay_Nhap_Ngu),
                new NpgsqlParameter("p_ngay_xuat_ngu",Ngay_Xuat_Ngu), 
                new NpgsqlParameter("p_quan_ham_cao_nhat",Quan_Ham_Cao_Nhat), 
                new NpgsqlParameter("p_danh_hieu_cao_nhat",Danh_Hieu_Cao_Nhat), 
                new NpgsqlParameter("p_thuong_binh_hang",Thuong_Binh_Hang),
                new NpgsqlParameter("p_gia_dinh_chinh_sach",Gia_Dinh_Chinh_Sach), 
                new NpgsqlParameter("p_khen_thuong",Khen_Thuong), 
                new NpgsqlParameter("p_ky_luat",Ky_Luat),
            };
            check = (int)dp.executeScalarProc("sp_update_cnvc_chinh_tri", paras);
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
