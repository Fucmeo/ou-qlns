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
    public class QuocGia
    {
        DataProvider.DataProvider dp;

        #region Init method

        public QuocGia()
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
        

        private string tenquocgia;

        public string TenQuocGia
        {
            get { return tenquocgia; }
            set { tenquocgia = value; }
        }

   

        #endregion

        #region Methods

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_ten_quoc_gia",tenquocgia)
            };
            check = (int)dp.executeScalarProc("sp_insert_quoc_gia", paras);
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
                new NpgsqlParameter("p_ten_quoc_gia",tenquocgia)
            };
            check = (int)dp.executeScalarProc("sp_insert_quoc_gia", paras);
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

            check = (int)dp.executeScalarProc("sp_delete_quoc_gia", paras);
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
                new NpgsqlParameter("p_ten_quoc_gia",tenquocgia)
            };
            check = (int)dp.executeScalarProc("sp_update_quoc_gia", paras);
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


            dt = dp.getDataTable("select * from v_quoc_gia");
            DataRow dr = dt.NewRow();
            dr["ten_quoc_gia"] = "";
            dr["id"] = -1;
            dt.Rows.InsertAt(dr, 0);

            return dt;
        }

        public List<QuocGia> GetList()
        {
            DataTable dt = new DataTable();
            List<QuocGia> listDonVi = new List<QuocGia>();

            dt = dp.getDataTable("select * from v_quoc_gia");
            listDonVi = dt.AsEnumerable().Select(row =>
                 new QuocGia
                 {
                     ID = row.Field<int>("id"),
                     TenQuocGia = row.Field<string>("ten_quoc_gia")
                 }).ToList();

            return listDonVi;
        }


        #endregion
    }
}
