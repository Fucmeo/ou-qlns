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
    public class Ngach
    {
        DataProvider.DataProvider dp;

        #region Init method

        public Ngach()
        {
            dp = new DataProvider.DataProvider();
        }

        #endregion

        #region Properties

        public string MaNgach { get; set; }

        public string TenNgach { get; set; }

        public int NhomNgachID { get; set; }


        #endregion

        #region Methods

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[3]{
                new NpgsqlParameter("p_ma_ngach",MaNgach),
                new NpgsqlParameter("p_ten_ngach",TenNgach),
                new NpgsqlParameter("p_nhom_ngach_id",NhomNgachID)
            };
            check = (int)dp.executeScalarProc("sp2_insert_ngach", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool Update(string MaNgachMoi)
        {
            int check;
            IDataParameter[] paras = new IDataParameter[4]{
                new NpgsqlParameter("p_ma_ngach_old",MaNgach), 
                new NpgsqlParameter("p_ma_ngach_new",MaNgachMoi), 
                new NpgsqlParameter("p_ten_ngach",TenNgach),
                new NpgsqlParameter("p_nhom_ngach_id",NhomNgachID)
            };
            check = (int)dp.executeScalarProc("sp2_update_ngach", paras);
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
                new NpgsqlParameter("p_ma_ngach",MaNgach)
            };
            check = (int)dp.executeScalarProc("sp2_delete_ngach", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public List<Ngach> GetList()
        {
            DataTable dt = new DataTable();
            List<Ngach> listDonVi = new List<Ngach>();

            dt = dp.getDataTable("select * from v_ngach");
            listDonVi = dt.AsEnumerable().Select(row =>
                 new Ngach
                 {
                     MaNgach = row.Field<string>("ma_ngach"),
                     TenNgach = row.Field<string>("ten_ngach"),
                     NhomNgachID = row.Field<int>("nhom_ngach_id")
                 }).ToList();

            return listDonVi;
        }
        
        #endregion
    }
}
