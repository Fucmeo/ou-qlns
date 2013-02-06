using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Npgsql;
using DataProvider;

namespace Business
{
    public class HinhThucDaoTao
    {
        DataProvider.DataProvider dp;

        #region Init method

        public HinhThucDaoTao()
        {
            dp = new DataProvider.DataProvider();
        }

        public HinhThucDaoTao(int? p_id, string p_tenhinhthuc, bool? p_saudh, string p_mota)
        {
            id = p_id;
            tenhinhthuc = p_tenhinhthuc;
            saudaihoc = p_saudh;
            mota = p_mota;
            dp = new DataProvider.DataProvider();
        }

        public HinhThucDaoTao(int p_id)
        {
            id = p_id;
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

        private string tenhinhthuc;

        public string TenHinhThuc
        {
            get { return tenhinhthuc; }
            set { tenhinhthuc = value; }
        }

        private bool? saudaihoc;

        public bool? SauDaiHoc
        {
            get { return saudaihoc; }
            set { saudaihoc = value; }
        }

        private string mota;

        public string MoTa
        {
            get { return mota; }
            set { mota = value; }
        }

        #endregion

        #region Methods

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[3]{
                new NpgsqlParameter("ten_hinh_thuc",tenhinhthuc), 
                new NpgsqlParameter("sau_dai_hoc",saudaihoc),
                new NpgsqlParameter("mo_ta",mota)
            };
            check = (int)dp.executeScalarProc("sp_insert_hinh_thuc_dao_tao", paras);
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
                new NpgsqlParameter("id",id), 
                new NpgsqlParameter("ten_hinh_thuc",tenhinhthuc), 
                new NpgsqlParameter("sau_dai_hoc",saudaihoc),
                new NpgsqlParameter("mo_ta",mota)
            };
            check = (int)dp.executeScalarProc("sp_update_hinh_thuc_dao_tao", paras);
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
            check = (int)dp.executeScalarProc("sp_delete_hinh_thuc_dao_tao", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public DataTable GetHinhThucList()
        {
            DataTable dt = new DataTable();
            dt = dp.getDataTable("select * from v_hinhthucdaotao");

            return dt;
        }

        public DataTable GetData()
        {
            DataTable dt = new DataTable();

            dt = dp.getDataTable("select * from v_hinhthucdaotao");

            return dt;
        }

        #endregion
    }
}
