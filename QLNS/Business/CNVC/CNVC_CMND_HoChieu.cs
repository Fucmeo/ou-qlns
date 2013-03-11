using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Npgsql;
using DataProvider;
using System.Globalization;

namespace Business.CNVC
{
    public class CNVC_CMND_HoChieu
    {
        DataProvider.DataProvider dp;

        #region Init method

        public CNVC_CMND_HoChieu()
        {
            dp = new DataProvider.DataProvider();
        }

        #endregion

        #region Properties

        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private bool[] cmndhochieu;

        public bool[] CMNDHoChieu
        {
            get { return cmndhochieu; }
            set { cmndhochieu = value; }
        }

        private string manv;

        public string MaNV
        {
            get { return manv; }
            set { manv = value; }
        }

        private string[] maso;

        public string[] MaSo
        {
            get { return maso; }
            set { maso = value; }
        }

        private DateTime?[] ngaycap;

        public DateTime?[] NgayCap
        {
            get { return ngaycap; }
            set { ngaycap = value; }
        }

        private string[] noicap;

        public string[] NoiCap
        {
            get { return noicap; }
            set { noicap = value; }
        }
        

        private bool[] isactive;

        public bool[] IsActive
        {
            get { return isactive; }
            set { isactive = value; }
        }
        
        
        

        #endregion

        #region Methods

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[6]{
                new NpgsqlParameter("ma_nv",manv), 
                new NpgsqlParameter("cmnd_hochieu",cmndhochieu), 
                new NpgsqlParameter("ma_so",maso), 
                new NpgsqlParameter("is_active",isactive),
                new NpgsqlParameter("ngay_cap",ngaycap.Select( a => a.Value.ToString("d", CultureInfo.CreateSpecificCulture("en-NZ"))).ToArray()),  // format : mm/dd/yyyy                
                new NpgsqlParameter("noi_cap",noicap)
            };
            check = (int)dp.executeScalarProc("sp_insert_cnvc_cmnd_hochieu", paras);
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
            IDataParameter[] paras = new IDataParameter[7]{
           new NpgsqlParameter("p_id",id), 
                new NpgsqlParameter("ma_nv",manv), 
                new NpgsqlParameter("p_cmnd_hochieu",cmndhochieu), 
                new NpgsqlParameter("p_ma_so",maso), 
                new NpgsqlParameter("p_ngay_cap",ngaycap),
                new NpgsqlParameter("p_is_active",isactive),
                new NpgsqlParameter("p_noi_cap",noicap)
            };
            check = (int)dp.executeScalarProc("sp_update_cnvc_cmnd_hochieu", paras);
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
            check = (int)dp.executeScalarProc("sp_delete_cnvc_cmnd_hochieu", paras);
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

            dt = dp.getDataTableProc("sp_select_cnvc_cmnd_hochieu", paras);

            return dt;
        }


        #endregion
    }
}
