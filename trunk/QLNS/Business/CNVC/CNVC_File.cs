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
    public class CNVC_File
    {
        DataProvider.DataProvider dp;

        #region Init method

        public CNVC_File()
        {
            dp = new DataProvider.DataProvider();
        }
        

        #endregion

        #region Properties

        private int? id;

        public int? ID
        {
            get { return id; }
            set { id = value; }
        }

        private string manv;

        public string MaNV
        {
            get { return manv; }
            set { manv = value; }
        }

        private string mota;

        public string MoTa
        {
            get { return mota; }
            set { mota = value; }
        }

        private string path;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        private bool? isavatar;

        public bool? IsAvatar
        {
            get { return isavatar; }
            set { isavatar = value; }
        }


        #endregion

        #region Methods

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[4]{
                new NpgsqlParameter("ma_nv",manv), 
                new NpgsqlParameter("path",path), 
                new NpgsqlParameter("mo_ta",mota), 
                new NpgsqlParameter("is_avatar",isavatar)
            };
            check = (int)dp.executeScalarProc("sp_insert_cnvc_file", paras);
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
            IDataParameter[] paras = new IDataParameter[5]{
                new NpgsqlParameter("id",id), 
                new NpgsqlParameter("ma_nv",manv), 
                new NpgsqlParameter("path",path), 
                new NpgsqlParameter("mo_ta",mota), 
                new NpgsqlParameter("is_avatar",isavatar)
            };
            check = (int)dp.executeScalarProc("sp_update_cnvc", paras);
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

            dt = dp.getDataTableProc("sp_select_cnvc_file", paras);

            return dt;
        }

        #endregion
    }
}
