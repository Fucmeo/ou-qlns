using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Npgsql;
using DataProvider;

namespace Business.Luong
{
    public class BaoHiem
    {
        DataProvider.DataProvider dp;

        #region Init method
        public BaoHiem()
        {
            dp = new DataProvider.DataProvider();
        }
        #endregion

        #region Properties
        public int Loai_BH_ID { get; set; }

        public string Ten_Loai_BH { get; set; }

        public int BH_ID { get; set; }

        public double Nhan_Vien_Dong { get; set; }

        public double Nha_Truong_Dong { get; set; }

        public DateTime Tu_Thoi_gian { get; set; }

        public DateTime? Den_Thoi_Gian { get; set; }

        public string Ghi_Chu { get; set; }
        
        #endregion

        #region Methods

        public bool Add_LoaiBH()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_ten_loai",Ten_Loai_BH)
            };
            check = (int)dp.executeScalarProc("sp2_insert_loai_bao_hiem", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool Update_LoaiBH()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[2]{
                new NpgsqlParameter("p_id",Loai_BH_ID), 
                new NpgsqlParameter("p_ten_loai",Ten_Loai_BH)
            };
            check = (int)dp.executeScalarProc("sp2_update_loai_bao_hiem", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool Delete_LoaiBH()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_id",Loai_BH_ID)
            };
            check = (int)dp.executeScalarProc("sp2_delete_loai_bao_hiem", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public DataTable GetList_LoaiBH()
        {
            DataTable dt = new DataTable();

            dt = dp.getDataTable("select * from v_loai_bao_hiem");

            return dt;
        }

        public bool Add_LoaiBH_Detail()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[6]{
                new NpgsqlParameter("p_loai_bh_id",Loai_BH_ID),
                new NpgsqlParameter("p_nhan_vien_dong",Nhan_Vien_Dong),
                new NpgsqlParameter("p_nha_truong_dong",Nha_Truong_Dong),
                new NpgsqlParameter("p_tu_thoi_gian",Tu_Thoi_gian),
                new NpgsqlParameter("p_den_thoi_gian",Den_Thoi_Gian),
                new NpgsqlParameter("p_ghi_chu",Ghi_Chu)
            };
            check = (int)dp.executeScalarProc("sp2_insert_loai_bao_hiem_detail", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool Update_LoaiBH_Detail()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[7]{
                new NpgsqlParameter("p_id",BH_ID), 
                new NpgsqlParameter("p_loai_bh_id",Loai_BH_ID),
                new NpgsqlParameter("p_nhan_vien_dong",Nhan_Vien_Dong),
                new NpgsqlParameter("p_nha_truong_dong",Nha_Truong_Dong),
                new NpgsqlParameter("p_tu_thoi_gian",Tu_Thoi_gian),
                new NpgsqlParameter("p_den_thoi_gian",Den_Thoi_Gian),
                new NpgsqlParameter("p_ghi_chu",Ghi_Chu)
            };
            check = (int)dp.executeScalarProc("sp2_update_loai_bao_hiem_detail", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool Delete_LoaiBH_Detail()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_id",BH_ID)
            };
            check = (int)dp.executeScalarProc("sp2_delete_loai_bao_hiem_detail", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public DataTable GetList_LoaiBH_Detail()
        {
            DataTable dt = new DataTable();

            dt = dp.getDataTable("select * from v_loai_bao_hiem_detail");

            return dt;
        }

        #endregion
    }
}
