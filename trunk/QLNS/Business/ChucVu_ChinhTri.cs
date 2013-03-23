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
    public class ChucVu_ChinhTri
    {
        DataProvider.DataProvider dp;

        #region Init methods
        public ChucVu_ChinhTri()
        {
            dp = new DataProvider.DataProvider();    
        }

        #endregion

        #region Properties
        public int ID { get; set; }

        public string Ten { get; set; }

        public int LoaiChinhTri_ID { get; set; }

        public string TenLoaiChinhTri { get; set; }

        #endregion

        #region Methods
        public DataTable GetData()
        {
            DataTable dt = new DataTable();

            dt = dp.getDataTable("select * from v_chucvu_chinhtri");

            return dt;
        }

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[2]{
                new NpgsqlParameter("p_ten_chuc_vu",Ten),
                new NpgsqlParameter("p_loai_chinh_tri_id",LoaiChinhTri_ID)
            };
            check = (int)dp.executeScalarProc("sp_insert_chuc_vu_chinh_tri", paras);
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
            IDataParameter[] paras = new IDataParameter[3]{
                new NpgsqlParameter("p_id",ID), 
                new NpgsqlParameter("p_ten_chuc_vu",Ten),
                new NpgsqlParameter("p_loai_chinh_tri_id",LoaiChinhTri_ID)
            };
            check = (int)dp.executeScalarProc("sp_update_chuc_vu_chinh_tri", paras);
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
                new NpgsqlParameter("p_id",ID)
            };
            check = (int)dp.executeScalarProc("sp_delete_chuc_vu_chinh_tri", paras);
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
