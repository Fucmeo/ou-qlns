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

        public VanBangChinhQuy(int? p_id, string p_tenvb, int? p_trinhdoid, string p_mota)
        {
            id = p_id;
            tenvanbang = p_tenvb;
            TrinhDoID = p_trinhdoid;
            mota = p_mota;
            dp = new DataProvider.DataProvider();
        }

        public VanBangChinhQuy(int p_id)
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

        private string tenvanbang;

        public string TenVanBang
        {
            get { return tenvanbang; }
            set { tenvanbang = value; }
        }

        private string mota;

        public string MoTa
        {
            get { return mota; }
            set { mota = value; }
        }

        public int? TrinhDoID { get; set; }

        #endregion

        #region Methods

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[3]{
                new NpgsqlParameter("ten_van_bang",tenvanbang), 
                new NpgsqlParameter("trinh_do_id",TrinhDoID),
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
                new NpgsqlParameter("p_id",id), 
                new NpgsqlParameter("p_ten_van_bang",tenvanbang), 
                new NpgsqlParameter("p_trinh_do_id",TrinhDoID),
                new NpgsqlParameter("p_mo_ta",mota)
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

        public DataTable GetVanBangList()
        {
            DataTable dt = new DataTable();
            dt = dp.getDataTable("select * from v_vanbangchinhquy");

            return dt;
        }

        public DataTable GetData()
        {
            DataTable dt = new DataTable();


            dt = dp.getDataTable("select * from v_vanbangchinhquy");
            DataRow dr = dt.NewRow();
            dr["ten_van_bang"] = "";
            dr["id"] = -1;
            dt.Rows.Add(dr);

            return dt;
        }

        #endregion
    }
}
