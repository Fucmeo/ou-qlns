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
    public class LuongToiThieu
    {
        DataProvider.DataProvider dp;

        #region Init methods
        public LuongToiThieu()
        {
            dp = new DataProvider.DataProvider();
        }
        #endregion

        #region Properties
        public int ID { get; set; }

        public double TienLuong { get; set; }

        public DateTime? TuNgay { get; set; }

        public DateTime? DenNgay { get; set; }

        public bool TinhTrang { get; set; }

        #endregion

        #region Methods
        public bool Delete()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_id",ID)
            };
            check = (int)dp.executeScalarProc("sp2_delete_luong_toi_thieu", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[3]{
                new NpgsqlParameter("p_tien_luong",TienLuong),
                new NpgsqlParameter("p_tu_ngay",TuNgay),
                new NpgsqlParameter("p_den_ngay",DenNgay)
            };
            check = (int)dp.executeScalarProc("sp2_insert_luong_toi_thieu", paras);
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
            IDataParameter[] paras = new IDataParameter[4]{
                new NpgsqlParameter("p_id",ID),
                new NpgsqlParameter("p_tien_luong",TienLuong),
                new NpgsqlParameter("p_tu_ngay",TuNgay),
                new NpgsqlParameter("p_den_ngay",DenNgay)
            };
            check = (int)dp.executeScalarProc("sp2_update_luong_toi_thieu", paras);
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

            dt = dp.getDataTable("select * from v_luong_toi_thieu");

            return dt;
        }
        #endregion
    }
}
