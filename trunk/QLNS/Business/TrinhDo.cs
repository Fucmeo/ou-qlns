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
    public class TrinhDo
    {
        DataProvider.DataProvider dp;

        public TrinhDo()
        {
            dp = new DataProvider.DataProvider();
        }

        #region Properties
        public int ID { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }
        #endregion

        #region Methods
        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[2]{
                new NpgsqlParameter("p_ten",Ten),
                new NpgsqlParameter("p_mo_ta",MoTa),
            };
            check = (int)dp.executeScalarProc("sp_insert_trinh_do", paras);
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
            IDataParameter[] paras = new IDataParameter[3]{
                new NpgsqlParameter("p_id",ID),
                new NpgsqlParameter("p_ten",Ten),
                new NpgsqlParameter("p_mo_ta",MoTa),
            };
            check = (int)dp.executeScalarProc("sp_update_trinh_do", paras);
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
                new NpgsqlParameter("p_id",ID)
            };
            check = (int)dp.executeScalarProc("sp_delete_trinh_do", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public DataTable GetTrinhDoList()
        {
            DataTable dt = new DataTable();

            dt = dp.getDataTable("select * from v_trinh_do");

            return dt;
        }

        #endregion
    }
}
