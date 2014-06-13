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
    public class LoaiDonVi
    {
        DataProvider.DataProvider dp;

        public LoaiDonVi()
        {
            dp = new DataProvider.DataProvider();
        }

        public int ID { get; set; }

        public string TenLoai { get; set; }

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_ten_loai_don_vi",TenLoai)
            };
            check = (int)dp.executeScalarProc("sp_insert_loai_don_vi", paras);
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
                new NpgsqlParameter("p_ten_loai_don_vi",TenLoai)
            };
            check = (int)dp.executeScalarProc("sp_update_loai_don_vi", paras);
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
            check = (int)dp.executeScalarProc("sp_delete_loai_don_vi", paras);
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

            dt = dp.getDataTable("select * from v_loai_don_vi");

            return dt;
        }
    }
}
