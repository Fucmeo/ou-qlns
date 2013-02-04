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

        private bool cmndhochieu;

        public bool CMNDHoChieu
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

        private string maso;

        public string MaSo
        {
            get { return maso; }
            set { maso = value; }
        }

        private DateTime? ngaycap;

        public DateTime? NgayCap
        {
            get { return ngaycap; }
            set { ngaycap = value; }
        }

        private bool? isactive;

        public bool? IsActive
        {
            get { return isactive; }
            set { isactive = value; }
        }
        
        
        

        #endregion

        #region Methods

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[5]{
                new NpgsqlParameter("ma_nv",manv), 
                new NpgsqlParameter("thong_tin_ls",cmndhochieu), 
                new NpgsqlParameter("quan_he_to_chuc_ctr_xh",maso), 
                new NpgsqlParameter("than_nhan_nuoc_ngoai",ngaycap),
                new NpgsqlParameter("than_nhan_nuoc_ngoai",isactive)
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
            IDataParameter[] paras = new IDataParameter[5]{
           new NpgsqlParameter("p_id",id), 
                new NpgsqlParameter("thong_tin_ls",cmndhochieu), 
                new NpgsqlParameter("quan_he_to_chuc_ctr_xh",maso), 
                new NpgsqlParameter("than_nhan_nuoc_ngoai",ngaycap),
                new NpgsqlParameter("than_nhan_nuoc_ngoai",isactive)
            };
            check = (int)dp.executeScalarProc("sp_update_cnvc_cmnd_hochieu", paras);
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
