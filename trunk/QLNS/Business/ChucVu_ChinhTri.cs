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
    public class ChucVu_ChinhTri
    {
        DataProvider.DataProvider dp;

        #region Init methods
        public ChucVu_ChinhTri()
        {
            dp = new DataProvider.DataProvider();    
        }

        #endregion

        #region Properties
        public int ID { get; set; }

        public string Ten { get; set; }

        public int LoaiChinhTri_ID { get; set; }

        public string TenLoaiChinhTri { get; set; }

        #endregion

        #region Methods
        public DataTable GetData()
        {
            DataTable dt = new DataTable();

            dt = dp.getDataTable("select * from v_chucvu_chinhtri");

            return dt;
        }

        #endregion
    }
}
