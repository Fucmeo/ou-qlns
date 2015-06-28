using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Npgsql;
using DataProvider;

namespace Business.Luong
{
    public class NghiPhep
    {
        DataProvider.DataProvider dp;

        public NghiPhep()
        {
            dp = new DataProvider.DataProvider();
        }

        #region Properties
        public string Ma_NV { get; set; }
        public DateTime Tu_Ngay { get; set; }
        public DateTime Den_Ngay { get; set; }
        public int So_Ngay { get; set; }
        public bool Is_Ung_Truoc { get; set; }
        public string Ghi_Chu { get; set; }
        public int Loai_Ngay_Phep_ID { get; set; }
        #endregion

        #region Methods
        public DataTable GetLoaiNgayPhep()
        {
            DataTable dt = new DataTable();

            dt = dp.getDataTable("select * from v_loai_ngay_phep_compact");

            return dt;
        }

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[7]{
                new NpgsqlParameter("p_manv",Ma_NV),
                new NpgsqlParameter("p_loai_ngay_phep_id",Loai_Ngay_Phep_ID),
                new NpgsqlParameter("p_tu_ngay",Tu_Ngay),
                new NpgsqlParameter("p_den_ngay",Den_Ngay),
                new NpgsqlParameter("pworkingday",So_Ngay),
                new NpgsqlParameter("p_is_ung_truoc",Is_Ung_Truoc),
                new NpgsqlParameter("p_ghi_chu",Ghi_Chu)
            };
            check = (int)dp.executeScalarProc("sp2_insert_ngay_phep", paras);
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
