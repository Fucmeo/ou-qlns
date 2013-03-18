using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Npgsql;
using DataProvider;

namespace Business.CNVC
{
    public class CNVC_ChinhTriExt
    {
        DataProvider.DataProvider dp;

        #region Init method

        public CNVC_ChinhTriExt()
        {
            dp = new DataProvider.DataProvider();
        }

        #endregion

        #region Properties
        public int ID { get; set; }

        public string Ma_NV { get; set; }

        public int Loai_Chinh_tri_ID { get; set; }

        public string Ten_Loai_Chinh_tri { get; set; }

        public DateTime? Ngay_Vao { get; set; }

        public DateTime? Ngay_Chinh_Thuc { get; set; }

        public DateTime? Ngay_Ra { get; set; }

        public DateTime? Ngay_Tai_Ket_Nap { get; set; }

        public string Ten_To_Chuc { get; set; }

        public int[] Chuc_Vu_ID { get; set; }

        #endregion
    }
}
