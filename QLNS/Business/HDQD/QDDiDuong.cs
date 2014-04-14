using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Npgsql;
using DataProvider;

namespace Business.HDQD
{
    public class QDDiDuong
    {
        DataProvider.DataProvider dp;

        #region Init Methods
        public QDDiDuong()
        {
            dp = new DataProvider.DataProvider();
        }

        #endregion

        #region Methods
        public DataTable GetList()
        {
            DataTable dt = new DataTable();

            dt = dp.getDataTable("select * from v_phuong_tien_di_chuyen");

            DataRow dr = dt.NewRow();
            dr["loai_phuong_tien"] = "";
            dr["id"] = -1;
            dt.Rows.InsertAt(dr, 0);

            return dt;
        }
        #endregion

        
    }
}
