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
    public class VanBangChinhQuy
    {
        DataProvider.DataProvider dp;

        #region Init method

        public VanBangChinhQuy()
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

        private string tenvanbang;

        public string TenVanBang
        {
            get { return tenvanbang; }
            set { tenvanbang = value; }
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
                new NpgsqlParameter("ten_van_bang",tenvanbang), 
                new NpgsqlParameter("sau_dai_hoc",saudaihoc),
                new NpgsqlParameter("mo_ta",mota)
            };
            check = (int)dp.executeScalarProc("sp_insert_van_bang_chinh_quy", paras);
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
                new NpgsqlParameter("ten_van_bang",tenvanbang), 
                new NpgsqlParameter("sau_dai_hoc",saudaihoc),
                new NpgsqlParameter("mo_ta",mota)
            };
            check = (int)dp.executeScalarProc("sp_update_van_bang_chinh_quy", paras);
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
            check = (int)dp.executeScalarProc("sp_delete_van_bang_chinh_quy", paras);
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
