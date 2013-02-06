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
    public class ChucDanhs
    {
        DataProvider.DataProvider dp;

        #region Init method

        public ChucDanh()
        {
            dp = new DataProvider.DataProvider();
        }
        

        #endregion

        #region Properties

        private int? id;

        public int? ID
        {
            get { return id; }
            set { id = value; }
        }

        private string tenchucdanh;

        public string TenChucDanh
        {
            get { return tenchucdanh; }
            set { tenchucdanh = value; }
        }

        #endregion

        #region Methods

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("ten_chuc_danh",tenchucdanh)
            };
            check = (int)dp.executeScalarProc("sp_insert_chuc_danh", paras);
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
            IDataParameter[] paras = new IDataParameter[2]{
                new NpgsqlParameter("id",id), 
                new NpgsqlParameter("ten_chuc_danh",tenchucdanh)
            };
            check = (int)dp.executeScalarProc("sp_update_chuc_danh", paras);
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
                new NpgsqlParameter("id",id)
            };
            check = (int)dp.executeScalarProc("sp_delete_chuc_danh", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public DataTable GetList()
        {
            DataTable dt = new DataTable();

            dt = dp.getDataTable("select * from v_chucdanh");

            return dt;
        }

        #endregion
    }
}
