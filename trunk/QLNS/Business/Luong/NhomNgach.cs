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
    
    public class NhomNgach
    {
        DataProvider.DataProvider dp;

        #region Init method

        public NhomNgach()
        {
            dp = new DataProvider.DataProvider();
        }

        #endregion

        #region Properties

        public string TenNhomNgach { get; set; }

        public int ID { get; set; }

        #endregion

        #region Methods

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_ten_nhom",TenNhomNgach)
            };
            check = (int)dp.executeScalarProc("sp2_insert_nhom_ngach", paras);
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
                new NpgsqlParameter("p_id",ID), 
                new NpgsqlParameter("p_ten_nhom",TenNhomNgach)
            };
            check = (int)dp.executeScalarProc("sp2_update_nhom_ngach", paras);
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
            check = (int)dp.executeScalarProc("sp2_delete_nhom_ngach", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public List<NhomNgach> GetList()
        {
            DataTable dt = new DataTable();
            List<NhomNgach> listDonVi = new List<NhomNgach>();

            dt = dp.getDataTable("select * from v_nhom_ngach");
            listDonVi = dt.AsEnumerable().Select(row =>
                 new NhomNgach
                 {
                     ID = row.Field<int>("id"),
                     TenNhomNgach = row.Field<string>("ten_nhom")
                 }).ToList();

            return listDonVi;
        }
        
        #endregion
    }
}
