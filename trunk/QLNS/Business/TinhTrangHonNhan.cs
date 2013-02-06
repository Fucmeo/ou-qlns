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
    public class TinhTrangHonNhan
    {
        DataProvider.DataProvider dp;
        public TinhTrangHonNhan()
        {
            dp = new DataProvider.DataProvider();
        }

        public DataTable GetData()
        {
            DataTable dt = new DataTable();

            dt = dp.getDataTable("select * from v_tinh_trang_hon_nhan");

            DataRow dr = dt.NewRow();
            dr["ten"] = "";
            dr["id"] = -1;
            dt.Rows.Add(dr);

            return dt;
        }
    }
}
