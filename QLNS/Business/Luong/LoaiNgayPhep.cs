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
    public class LoaiNgayPhep
    {
        DataProvider.DataProvider dp;

        public LoaiNgayPhep()
        {
            dp = new DataProvider.DataProvider();
        }

        public DataTable GetData()
        {
            DataTable dt = new DataTable();

            dt = dp.getDataTable("select * from v_loai_ngay_phep");

            return dt;
        }
    }
}
