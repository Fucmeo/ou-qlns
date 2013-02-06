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
    public class QuyetDinh
    {
        DataProvider.DataProvider dp;
        #region Inits Methods
        public QuyetDinh()
        {
            dp = new DataProvider.DataProvider();
        }
        #endregion

        #region Properties
        
        private string ma_qd;

        public string Ma_Quyet_Dinh
        {
            get { return ma_qd; }
            set { ma_qd = value; }
        }

        private string ten_qd;

        public string Ten_Quyet_Dinh
        {
            get { return ten_qd; }
            set { ten_qd = value; }
        }

        private int? loai_qd_id;

        public int? Loai_QuyetDinh_ID
        {
            get { return loai_qd_id; }
            set { loai_qd_id = value; }
        }

        private DateTime? ngay_ky_tu;

        public DateTime? Ngay_Ky_Tu
        {
            get { return ngay_ky_tu; }
            set { ngay_ky_tu = value; }
        }

        private DateTime? ngay_ky_den;

        public DateTime? Ngay_Ky_Den
        {
            get { return ngay_ky_den; }
            set { ngay_ky_den = value; }
        }
        #endregion

        #region Methods
        public DataTable Search_QD()
        {
            DataTable dt;

            IDataParameter[] paras = new IDataParameter[5]{
                new NpgsqlParameter("p_ma_quyet_dinh",ma_qd),
                new NpgsqlParameter("p_ten",ten_qd),
                new NpgsqlParameter("p_loai_qd",loai_qd_id),
                new NpgsqlParameter("p_ngay_ky_tu",ngay_ky_tu),
                new NpgsqlParameter("p_ngay_ky_den",ngay_ky_den)
            };

            dt = dp.getDataTableProc("sp1_qsearch_quyet_dinh", paras);

            return dt;
        }

        public bool Delete()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_ma_quyet_dinh",ma_qd)
            };
            check = (int)dp.executeScalarProc("sp1_delete_quyet_dinh", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }
        #endregion
    }
}
