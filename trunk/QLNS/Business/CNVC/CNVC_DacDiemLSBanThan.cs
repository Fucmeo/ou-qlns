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
    public class CNVC_DacDiemLSBanThan
    {
        DataProvider.DataProvider dp;

        #region Init method

        public CNVC_DacDiemLSBanThan()
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
        

        private string manv;

        public string MaNV
        {
            get { return manv; }
            set { manv = value; }
        }

        private string thongtinls;

        public string ThongTinLS
        {
            get { return thongtinls; }
            set { thongtinls = value; }
        }

        private string qhtochucxh;

        public string QHToChucXH
        {
            get { return qhtochucxh; }
            set { qhtochucxh = value; }
        }

        private string thannhannuocngoai;

        public string ThanNhanNuocNgoai
        {
            get { return thannhannuocngoai; }
            set { thannhannuocngoai = value; }
        }

        #endregion

        #region Methods

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[4]{
                new NpgsqlParameter("ma_nv",manv), 
                new NpgsqlParameter("thong_tin_ls",thongtinls), 
                new NpgsqlParameter("quan_he_to_chuc_ctr_xh",qhtochucxh), 
                new NpgsqlParameter("than_nhan_nuoc_ngoai",thannhannuocngoai)
            };
            check = (int)dp.executeScalarProc("sp_insert_cnvc_ls_ban_than", paras);
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
           new NpgsqlParameter("p_id",id), 
                new NpgsqlParameter("thong_tin_ls",thongtinls), 
                new NpgsqlParameter("quan_he_to_chuc_ctr_xh",qhtochucxh), 
                new NpgsqlParameter("than_nhan_nuoc_ngoai",thannhannuocngoai)
            };
            check = (int)dp.executeScalarProc("sp_update_cnvc_ls_ban_than", paras);
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

            dt = dp.getDataTableProc("sp_select_ls_ban_than", paras);

            return dt;
        }

        #endregion
    }
}
