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
    public class MoHinhDaoTao
    {
        DataProvider.DataProvider dp;

        #region Init method

        public MoHinhDaoTao()
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

        private string tenmohinh;

        public string TenMoHinh
        {
            get { return tenmohinh; }
            set { tenmohinh = value; }
        }

        private string mota;

        public string MoTa
        {
            get { return mota; }
            set { mota = value; }
        }

        #endregion

        #region Methods

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[2]{
                new NpgsqlParameter("ten_mo_hinh",tenmohinh), 
                new NpgsqlParameter("mo_ta",mota)
            };
            check = (int)dp.executeScalarProc("sp_insert_mo_hinh_dao_tao", paras);
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
                new NpgsqlParameter("id",id), 
                new NpgsqlParameter("ten_mo_hinh",tenmohinh), 
                new NpgsqlParameter("mo_ta",mota)
            };
            check = (int)dp.executeScalarProc("sp_update_mo_hinh_dao_tao", paras);
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
            check = (int)dp.executeScalarProc("sp_delete_mo_hinh_dao_tao", paras);
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

            dt = dp.getDataTable("select * from v_mohinhdaotao");

            return dt;
        }

        #endregion
    }
}
