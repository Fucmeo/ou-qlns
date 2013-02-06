using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Npgsql;
using DataProvider;

namespace Business.HDQD
{
    public class LoaiQuyetDinh
    {
        DataProvider.DataProvider dp;

        #region Init Method
        public LoaiQuyetDinh()
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

        private string ten;

        public string TenLoaiQuyetDinh
        {
            get { return ten; }
            set { ten = value; }
        }

        private string tenviettat;

        public string TenLoaiQD_Viettat
        {
            get { return tenviettat; }
            set { tenviettat = value; }
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
                new NpgsqlParameter("p_ten_loai",ten),
                new NpgsqlParameter("p_ten_viet_tat",tenviettat),
                new NpgsqlParameter("p_mo_ta",mota)
            };
            check = (int)dp.executeScalarProc("sp1_insert_loai_quyet_dinh", paras);
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
                new NpgsqlParameter("p_ten_loai",ten),
                new NpgsqlParameter("p_ten_viet_tat",tenviettat),
                new NpgsqlParameter("p_mo_ta",mota)
            };
            check = (int)dp.executeScalarProc("sp1_update_loai_quyet_dinh", paras);
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
            check = (int)dp.executeScalarProc("sp1_delete_loai_quyet_dinh", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public DataTable GetList()
        {
            DataTable dt = new DataTable();

            dt = dp.getDataTable("select * from v_loai_quyet_dinh");

            return dt;
        }

        public DataTable GetList_Compact()
        {
            DataTable dt = new DataTable();

            dt = dp.getDataTable("select * from v_loai_quyet_dinh_compact");

            return dt;
        }
        #endregion
    }
}
