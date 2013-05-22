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
    public class DanToc
    {
        DataProvider.DataProvider dp;

        #region Init method

        public DanToc()
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
        

        private string tendantoc;

        public string TenDanToc
        {
            get { return tendantoc; }
            set { tendantoc = value; }
        }

   

        #endregion

        #region Methods

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_ten_dan_toc",tendantoc)
            };
            check = (int)dp.executeScalarProc("sp_insert_dan_toc", paras);
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
            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_ten_dan_toc",tendantoc)
            };
            check = (int)dp.executeScalarProc("sp_insert_dan_toc", paras);
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

            check = (int)dp.executeScalarProc("sp_delete_dan_toc", paras);
            if (check > 0)
                return true;
            else
                return false;

        }

        public bool Update()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[2]{
                new NpgsqlParameter("p_id",id),
                new NpgsqlParameter("p_ten_dan_toc",tendantoc)
            };
            check = (int)dp.executeScalarProc("sp_update_dan_toc", paras);
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


            dt = dp.getDataTable("select * from v_dan_toc");
            DataRow dr = dt.NewRow();
            dr["ten_dan_toc"] = "";
            dr["id"] = -1;
            dt.Rows.InsertAt(dr, 0);

            return dt;
        }

        #endregion
    }
}
