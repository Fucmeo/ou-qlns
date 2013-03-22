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
    public class CNVC_ChinhTriExt
    {
        DataProvider.DataProvider dp;

        #region Init method

        public CNVC_ChinhTriExt()
        {
            dp = new DataProvider.DataProvider();
        }

        #endregion

        #region Properties
        public int ID { get; set; }

        public string Ma_NV { get; set; }

        public int Loai_Chinh_tri_ID { get; set; }

        public string Ten_Loai_Chinh_tri { get; set; }

        public DateTime? Ngay_Vao { get; set; }

        public DateTime? Ngay_Chinh_Thuc { get; set; }

        public DateTime? Ngay_Ra { get; set; }

        public DateTime? Ngay_Tai_Ket_Nap { get; set; }

        public string Ten_To_Chuc { get; set; }

        public int[] Chuc_Vu_ID { get; set; }

        #endregion

        #region Methods
        public bool Delete()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("id",ID)
            };
            check = (int)dp.executeScalarProc("sp_delete_cnvc_chinh_tri_ext", paras);
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
                new NpgsqlParameter("p_ma_nv",Ma_NV)               
            };

            dt = dp.getDataTableProc("sp_select_cnvc_chinh_tri_ext", paras);

            return dt;
        }

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[8]{
                new NpgsqlParameter("p_ma_nv",Ma_NV), 
                new NpgsqlParameter("p_loai_chinh_tri_id",Loai_Chinh_tri_ID), 
                new NpgsqlParameter("p_ngay_vao",Ngay_Vao), 
                new NpgsqlParameter("p_ngay_chinh_thuc",Ngay_Chinh_Thuc),
                new NpgsqlParameter("p_ngay_ra",Ngay_Ra),
                new NpgsqlParameter("p_ngay_tai_ket_nap",Ngay_Tai_Ket_Nap),
                new NpgsqlParameter("p_ten_to_chuc",Ten_To_Chuc),
                new NpgsqlParameter("p_chuc_vu_id_arr",Chuc_Vu_ID)
            };
            check = (int)dp.executeScalarProc("sp_insert_cnvc_chinh_tri_ext", paras);
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
            IDataParameter[] paras = new IDataParameter[8]{
                new NpgsqlParameter("p_id",ID), 
                new NpgsqlParameter("p_loai_chinh_tri_id",Loai_Chinh_tri_ID), 
                new NpgsqlParameter("p_ngay_vao",Ngay_Vao), 
                new NpgsqlParameter("p_ngay_chinh_thuc",Ngay_Chinh_Thuc),
                new NpgsqlParameter("p_ngay_ra",Ngay_Ra),
                new NpgsqlParameter("p_ngay_tai_ket_nap",Ngay_Tai_Ket_Nap),
                new NpgsqlParameter("p_ten_to_chuc",Ten_To_Chuc),
                new NpgsqlParameter("p_chuc_vu_id_arr",Chuc_Vu_ID)
            };
            check = (int)dp.executeScalarProc("sp_update_cnvc_chinh_tri_ext", paras);
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
