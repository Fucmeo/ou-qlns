using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Npgsql;
using DataProvider;
using System.Globalization;

namespace Business.Luong
{


    public class TinhLuong
    {
        private DataProvider.DataProvider dp = new DataProvider.DataProvider();

        public DataTable GetThongTinLuong_ByNV(string ma_nv)
        {
            DataTable table = new DataTable();
            IDataParameter[] commandParameters = new IDataParameter[] { new NpgsqlParameter("p_ma_nv", ma_nv) };
            return this.dp.getDataTableProc("sp1_select_thong_tin_luong_by_nv", commandParameters);
        }

        public DataTable GetThongTinPC_ByNV(string ma_nv)
        {
            DataTable table = new DataTable();
            IDataParameter[] commandParameters = new IDataParameter[] { new NpgsqlParameter("p_ma_nv", ma_nv) };
            return this.dp.getDataTableProc("sp1_select_thong_tin_pc_by_nv", commandParameters);
        }

        public DataTable TinhLuongByListDV(List<int> DV_ID, DateTime tu_ngay, DateTime den_ngay, int nam_thang)
        {
            DataTable table = new DataTable();
            IDataParameter[] commandParameters = new IDataParameter[] { new NpgsqlParameter("p_ma_nv", DV_ID.ToArray()), new NpgsqlParameter("p_tu_ngay", tu_ngay), new NpgsqlParameter("p_den_ngay", den_ngay), new NpgsqlParameter("p_thang_nam_int", nam_thang) };
            return this.dp.getDataTableProc("sp2_cal_luong_by_dv", commandParameters);
        }

        public DataTable TinhLuongByListNV(List<string> lstNV, DateTime tu_ngay, DateTime den_ngay, int nam_thang)
        {
            DataTable table = new DataTable();
            IDataParameter[] commandParameters = new IDataParameter[] { new NpgsqlParameter("p_ma_nv", lstNV.ToArray()), new NpgsqlParameter("p_tu_ngay", tu_ngay), new NpgsqlParameter("p_den_ngay", den_ngay), new NpgsqlParameter("p_thang_nam_int", nam_thang) };
            return this.dp.getDataTableProc("sp2_cal_luong_by_nv", commandParameters);
        }

        public DataTable TinhPhuCapByListDV(List<int> DV_ID, DateTime tu_ngay, DateTime den_ngay, int nam_thang)
        {
            DataTable table = new DataTable();
            IDataParameter[] commandParameters = new IDataParameter[] { new NpgsqlParameter("p_ma_nv", DV_ID.ToArray()), new NpgsqlParameter("p_tu_ngay", tu_ngay), new NpgsqlParameter("p_den_ngay", den_ngay), new NpgsqlParameter("p_thang_nam_int", nam_thang) };
            return this.dp.getDataTableProc("sp2_cal_phucap_by_dv", commandParameters);
        }

        public DataTable TinhPhuCapByListNV(List<string> lstNV, DateTime tu_ngay, DateTime den_ngay, int nam_thang)
        {
            DataTable table = new DataTable();
            IDataParameter[] commandParameters = new IDataParameter[] { new NpgsqlParameter("p_ma_nv", lstNV.ToArray()), new NpgsqlParameter("p_tu_ngay", tu_ngay), new NpgsqlParameter("p_den_ngay", den_ngay), new NpgsqlParameter("p_thang_nam_int", nam_thang) };
            return this.dp.getDataTableProc("sp2_cal_phucap_by_nv", commandParameters);
        }

        public bool UpdateLuong_PC(string ma_nv, int[] luong_id, int[] tuyen_dung_id, string[] khoan_hs,
                        string[] luong_khoan, string[] ngach_bac_hs_id,
                        string[] phan_tram_huong_luong, DateTime[] tu_ngay_luong, DateTime[] den_ngay_luong, 
                        bool[] den_ngay_adj_luong_is_null, int[] pc_id, int[] tuyen_dung_pc_id,
                        string[] value_khoan_pc, string[] value_he_so_pc, string[] value_phan_tram_pc,
                        string[] phan_tram_huong_pc, int[] loai_pc_id, DateTime[] tu_ngay_pc, DateTime[] den_ngay_pc, 
                        bool[] den_ngay_adj_is_null, string[] ghi_chu_pc,
                        string ma_qd, string ten_qd , int loai_qd_id , DateTime tu_ngay_qd ,
                        DateTime den_ngay_qd , DateTime ngay_ky, string mo_ta_qd )
        {
            IDataParameter[] commandParameters = new IDataParameter[] 
            { 
                new NpgsqlParameter("p_ma_nv", ma_nv), 
                new NpgsqlParameter("p_luong_id", luong_id), 
                new NpgsqlParameter("p_tuyen_dung_luong_id", tuyen_dung_id), 
                new NpgsqlParameter("p_khoan_or_heso_luong", khoan_hs), 
                new NpgsqlParameter("p_luong_khoan", luong_khoan), 
                new NpgsqlParameter("p_ngach_bac_heso_luong_id", ngach_bac_hs_id), 
                new NpgsqlParameter("p_phan_tram_huong_luong", phan_tram_huong_luong), 
                new NpgsqlParameter("p_tu_ngay_luong", tu_ngay_luong),
                new NpgsqlParameter("p_den_ngay_luong", den_ngay_luong) ,
                new NpgsqlParameter("p_den_ngay_adj_luong_is_null", den_ngay_adj_luong_is_null), 
                new NpgsqlParameter("pc_id", pc_id), 
                new NpgsqlParameter("p_tuyen_dung_pc_id", tuyen_dung_pc_id), 
                new NpgsqlParameter("p_value_khoan_pc", value_khoan_pc), 
                new NpgsqlParameter("p_value_he_so_pc", value_he_so_pc), 
                new NpgsqlParameter("p_value_phan_tram_pc", value_phan_tram_pc), 
                new NpgsqlParameter("p_phan_tram_huong_pc", phan_tram_huong_pc), 
                new NpgsqlParameter("p_loai_pc_id", loai_pc_id), 
                new NpgsqlParameter("p_tu_ngay_pc", tu_ngay_pc), 
                new NpgsqlParameter("p_den_ngay_pc", den_ngay_pc), 
                new NpgsqlParameter("p_den_ngay_adj_pc_is_null", den_ngay_adj_is_null), 
                new NpgsqlParameter("p_ghi_chu_pc", ghi_chu_pc),
                new NpgsqlParameter("p_ma_qd", ma_qd), 
                new NpgsqlParameter("p_ten_qd", ten_qd), 
                new NpgsqlParameter("p_loai_qd_id", loai_qd_id), 
                new NpgsqlParameter("p_tu_ngay_qd", tu_ngay_qd),
                new NpgsqlParameter("p_den_ngay_qd", den_ngay_qd), 
                new NpgsqlParameter("p_ngay_ky_qd", ngay_ky), 
                new NpgsqlParameter("p_mo_ta_qd", mo_ta_qd)
             };

            
            int num = (int) this.dp.executeScalarProc("sp1_update_luong_pc", commandParameters);
            return (num > 0);
        }


    }
}
