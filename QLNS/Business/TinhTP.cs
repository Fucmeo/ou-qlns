using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Npgsql;
using DataProvider;

namespace Business
{
    public class TinhTP
    {
        DataProvider.DataProvider dp;

        #region Init method

        public TinhTP()
        {
            dp = new DataProvider.DataProvider();
        }

        public TinhTP(string p_tentinhtp, string p_mota)
        {
            tentinhtp = p_tentinhtp;
            mota = p_mota;
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
        

        private string tentinhtp;

        public string TenTinhTP
        {
            get { return tentinhtp; }
            set { tentinhtp = value; }
        }

        private string mota;

        public string MoTa
        {
            get { return mota; }
            set { mota = value; }
        }

        private int quoc_gia_id;

        public int QuocGiaID
        {
            get { return quoc_gia_id; }
            set { quoc_gia_id = value; }
        }
        

        #endregion

        #region Methods

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[3]{
                new NpgsqlParameter("ten_tinh_tp",tentinhtp), 
                new NpgsqlParameter("mo_ta",mota),
                new NpgsqlParameter("quoc_gia_id",quoc_gia_id)
            };
            check = (int)dp.executeScalarProc("sp_insert_tinh_tp", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public int AddWithReturnID()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[3]{
                new NpgsqlParameter("ten_tinh_tp",tentinhtp), 
                new NpgsqlParameter("mo_ta",mota),
                new NpgsqlParameter("quoc_gia_id",quoc_gia_id)
            };
            check = (int)dp.executeScalarProc("sp_insert_tinh_tp", paras);
            if (check > 0)
            {
                return check;
            }
            else
                return 0;
        }

        public bool Delete()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_id",id)
            };

            check = (int)dp.executeScalarProc("sp_delete_tinhtp", paras);
            if (check > 0)
                return true;
            else
                return false;

        }

        public bool Update()
        {
            int check; 
            IDataParameter[] paras = new IDataParameter[4]{
                new NpgsqlParameter("p_id",id),
                new NpgsqlParameter("p_ten_tinh_tp",tentinhtp), 
                new NpgsqlParameter("p_mo_ta",mota),
                new NpgsqlParameter("p_quoc_gia_id",quoc_gia_id)
            };
            check = (int)dp.executeScalarProc("sp_update_tinhtp", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public DataTable GetData()
        {
            DataTable dt = new DataTable();


            dt = dp.getDataTable("select * from v_tinhtp");
            DataRow dr = dt.NewRow();
            dr["ten_tinh_tp"] = "";
            dr["id"] = -1;
            dr["quoc_gia_id"] = -1;
            dt.Rows.InsertAt(dr, 0);

            return dt;
        }

        public DataTable GetData_Compact()
        {
            DataTable dt = new DataTable();
            dt = dp.getDataTable("select * from v_tinhtp_compact");

            return dt;
        }

        #endregion
    }
}
