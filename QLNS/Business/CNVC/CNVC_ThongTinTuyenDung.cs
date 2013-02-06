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
    public class CNVC_ThongTinTuyenDung
    {
        DataProvider.DataProvider dp;

        #region Init method

        public CNVC_ThongTinTuyenDung()
        {
            dp = new DataProvider.DataProvider();
        }

        #endregion

        #region Properties

        private string manv;

        public string MaNV
        {
            get { return manv; }
            set { manv = value; }
        }

        private string nghenghieptruocday;

        public string NgheNghiepTruocDay
        {
            get { return nghenghieptruocday; }
            set { nghenghieptruocday = value; }
        }

        private DateTime? ngaytuyendung;

        public DateTime? NgayTuyenDung
        {
            get { return ngaytuyendung; }
            set { ngaytuyendung = value; }
        }

        private string coquantuyendung;

        public string CoQuanTuyenDung
        {
            get { return coquantuyendung; }
            set { coquantuyendung = value; }
        }
        

        #endregion

        #region Methods

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[4]{
                new NpgsqlParameter("ma_nv",manv), 
                new NpgsqlParameter("nghe_nghiep_trc_day",nghenghieptruocday), 
                new NpgsqlParameter("ngay_tuyen_dung",ngaytuyendung), 
                new NpgsqlParameter("co_quan_tuyen_dung",coquantuyendung)
            };
            check = (int)dp.executeScalarProc("sp_insert_cnvc_thong_tin_tuyen_dung", paras);
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
           new NpgsqlParameter("ma_nv",manv), 
                new NpgsqlParameter("nghe_nghiep_trc_day",nghenghieptruocday), 
                new NpgsqlParameter("ngay_tuyen_dung",ngaytuyendung), 
                new NpgsqlParameter("co_quan_tuyen_dung",coquantuyendung)
            };
            check = (int)dp.executeScalarProc("sp_update_cnvc_thong_tin_tuyen_dung", paras);
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
           new NpgsqlParameter("p_ma_nv",manv)
            };
            check = (int)dp.executeScalarProc("sp_delete_cnvc_thong_tin_tuyen_dung", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public DataTable GetData()
        {
            DataTable dt;

            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_ma_nv",manv)               
            };

            dt = dp.getDataTableProc("sp_select_cnvc_thong_tin_tuyen_dung", paras);

            return dt;
        }

        #endregion
    }
}
