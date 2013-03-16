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

        public int CapHoc{ get; set; }

        public string TenTruong { get; set; }

        public string Phuong { get; set; }

        public string Quan { get; set; }

        public int? Tinh { get; set; }

        public string NamHoc { get; set; } 


        #endregion

        #region Methods

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[7]{
                new NpgsqlParameter("ma_nv",manv),
                new NpgsqlParameter("cap_hoc",CapHoc),
                new NpgsqlParameter("ten_truong",TenTruong),
                new NpgsqlParameter("phuong_xa",Phuong),
                new NpgsqlParameter("quan_huyen",Quan),
                new NpgsqlParameter("tinh_thanhpho",Tinh),
                new NpgsqlParameter("nam_hoc",NamHoc)
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
            IDataParameter[] paras = new IDataParameter[7]{
                new NpgsqlParameter("p_id",id),
                new NpgsqlParameter("p_cap_hoc",CapHoc),
                new NpgsqlParameter("p_ten_truong",TenTruong),
                new NpgsqlParameter("p_phuong_xa",Phuong),
                new NpgsqlParameter("p_quan_huyen",Quan),
                new NpgsqlParameter("p_tinh_thanhpho",Tinh),
                new NpgsqlParameter("p_nam_hoc",NamHoc)
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
                new NpgsqlParameter("p_id",id)
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
