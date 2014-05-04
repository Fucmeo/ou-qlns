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

        #region Properties
        public int id { get; set; }
        public string Ma_Quyet_Dinh { get; set; }
        public string Ma_NV { get; set; }
        public int CNVC_QD_ID { get; set; }
        public int ChucVu_ID { get; set; }
        public string ChucVu { get; set; }
        public string NoiCongTac { get; set; }
        public string CongVanSo { get; set; }
        public DateTime CongVanNgay { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public double TienLuong { get; set; }
        public double CongTacPhi { get; set; }
        public string GhiChu { get; set; }

        public int SEQ_ID { get; set; }
        public int PTDC_ID { get; set; }
        public string PTDC { get; set; }
        public int Di_Or_Den { get; set; }
        public string DiaDiem { get; set; }
        public DateTime NgayKhoiHanh { get; set; }
        public double SoNgayCT { get; set; }
        public string LyDoLuuTru { get; set; }
        public string GhiChu_Detail { get; set; }

        #endregion

        #region Methods
        public DataTable GetList()
        {
            DataTable dt = new DataTable();

            dt = dp.getDataTable("select * from v_phuong_tien_di_chuyen");

            DataRow dr = dt.NewRow();
            //dr["loai_phuong_tien"] = "";
            //dr["id"] = -1;
            //dt.Rows.InsertAt(dr, 0);

            return dt;
        }
        #endregion

        
    }
}
