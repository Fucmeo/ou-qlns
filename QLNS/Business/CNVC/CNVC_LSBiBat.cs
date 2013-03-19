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
    public class CNVC_LSBiBat
    {
        DataProvider.DataProvider dp;

        #region Init method

        public CNVC_LSBiBat()
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

        public DateTime? TuThoiGian { get; set; }

        public DateTime? DenThoiGian { get; set; }

        public Boolean BiTu { get; set; }

        public string TaiNoi { get; set; }

        public string NguoiKhaiBao { get; set; }

        public string NoiDung { get; set; }

        #endregion

        #region Methods

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[7]{
                new NpgsqlParameter("p_ma_nv",manv), 
                new NpgsqlParameter("p_bi_bat_bi_tu",BiTu), 
                new NpgsqlParameter("p_tu_thoi_gian",TuThoiGian), 
                new NpgsqlParameter("p_den_thoi_gian",DenThoiGian),
                new NpgsqlParameter("p_tai_noi",TaiNoi), 
                new NpgsqlParameter("p_nguoi_khai_bao",NguoiKhaiBao), 
                new NpgsqlParameter("p_noi_dung",NoiDung)
            };
            check = (int)dp.executeScalarProc("sp_insert_cnvc_ls_bi_bat", paras);
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
            IDataParameter[] paras = new IDataParameter[7]{
                new NpgsqlParameter("p_id",id),
                new NpgsqlParameter("p_bi_bat_bi_tu",BiTu), 
                new NpgsqlParameter("p_tu_thoi_gian",TuThoiGian), 
                new NpgsqlParameter("p_den_thoi_gian",DenThoiGian),
                new NpgsqlParameter("p_tai_noi",TaiNoi), 
                new NpgsqlParameter("p_nguoi_khai_bao",NguoiKhaiBao), 
                new NpgsqlParameter("p_noi_dung",NoiDung)
            };
            check = (int)dp.executeScalarProc("sp_update_cnvc_ls_bi_bat", paras);
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
            check = (int)dp.executeScalarProc("sp_delete_cnvc_ls_bi_bat", paras);
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

            dt = dp.getDataTableProc("sp_select_cnvc_ls_bi_bat", paras);

            return dt;
        }

        #endregion
    }
}
