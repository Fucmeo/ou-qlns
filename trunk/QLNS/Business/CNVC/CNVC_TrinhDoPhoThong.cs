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
    public class CNVC_TrinhDoPhoThong
    {
        DataProvider.DataProvider dp;

        #region Init method

        public CNVC_TrinhDoPhoThong()
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

        private string truongcap1;

        public string TruongCap1
        {
            get { return truongcap1; }
            set { truongcap1 = value; }
        }

        private string truongcap2;

        public string TruongCap2
        {
            get { return truongcap2; }
            set { truongcap2 = value; }
        }

        private string truongcap3;

        public string TruongCap3
        {
            get { return truongcap3; }
            set { truongcap3 = value; }
        }

        #endregion

        #region Methods

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[4]{
                new NpgsqlParameter("ma_nv",manv),
                new NpgsqlParameter("truong_cap_1",truongcap1),
                new NpgsqlParameter("truong_cap_2",truongcap2),
                new NpgsqlParameter("truong_cap_3",truongcap3)
            };
            check = (int)dp.executeScalarProc("sp_insert_cnvc_trinh_do_pho_thong", paras);
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
                new NpgsqlParameter("truong_cap_1",truongcap1),
                new NpgsqlParameter("truong_cap_2",truongcap2),
                new NpgsqlParameter("truong_cap_3",truongcap3)
            };
            check = (int)dp.executeScalarProc("sp_update_cnvc_trinh_do_pho_thong", paras);
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
                new NpgsqlParameter("id",id)
            };
            check = (int)dp.executeScalarProc("sp_delete_cnvc_trinh_do_pho_thong", paras);
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

            dt = dp.getDataTableProc("sp_select_trinh_do_pho_thong", paras);

            return dt;
        }

        #endregion
    }
}
