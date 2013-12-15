using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using DataProvider;
using System.Data;

namespace Business.Luong
{
    

    public class TinhLuong
    {
        DataProvider.DataProvider dp;

        public TinhLuong()
        {
            dp = new DataProvider.DataProvider();
        }

        public DataTable TinhLuongByListNV(List<string> lstNV,DateTime tu_ngay, DateTime den_ngay, int nam_thang)
        {
            DataTable dt = new DataTable();

            IDataParameter[] paras = new IDataParameter[4]{
                new NpgsqlParameter("p_ma_nv",lstNV.ToArray()),
                new NpgsqlParameter("p_tu_ngay",tu_ngay),
                new NpgsqlParameter("p_den_ngay",den_ngay),
                new NpgsqlParameter("p_thang_nam_int",nam_thang)
            };

            dt = dp.getDataTableProc("sp2_cal_luong_by_nv", paras);

            return dt;
        }

        public DataTable TinhLuongByListDV(List<int> DV_ID, DateTime tu_ngay, DateTime den_ngay, int nam_thang)
        {
            DataTable dt = new DataTable();

            IDataParameter[] paras = new IDataParameter[4]{
                new NpgsqlParameter("p_ma_nv",DV_ID.ToArray()),
                new NpgsqlParameter("p_tu_ngay",tu_ngay),
                new NpgsqlParameter("p_den_ngay",den_ngay),
                new NpgsqlParameter("p_thang_nam_int",nam_thang)
            };

            dt = dp.getDataTableProc("sp2_cal_luong_by_dv", paras);

            return dt;
        }

        public DataTable TinhPhuCapByListNV(List<string> lstNV, DateTime tu_ngay, DateTime den_ngay, int nam_thang)
        {
            DataTable dt = new DataTable();

            IDataParameter[] paras = new IDataParameter[4]{
                new NpgsqlParameter("p_ma_nv",lstNV.ToArray()),
                new NpgsqlParameter("p_tu_ngay",tu_ngay),
                new NpgsqlParameter("p_den_ngay",den_ngay),
                new NpgsqlParameter("p_thang_nam_int",nam_thang)
            };

            dt = dp.getDataTableProc("sp2_cal_phucap_by_nv", paras);

            return dt;
        }

        public DataTable TinhPhuCapByListDV(List<int> DV_ID, DateTime tu_ngay, DateTime den_ngay, int nam_thang)
        {
            DataTable dt = new DataTable();

            IDataParameter[] paras = new IDataParameter[4]{
                new NpgsqlParameter("p_ma_nv",DV_ID.ToArray()),
                new NpgsqlParameter("p_tu_ngay",tu_ngay),
                new NpgsqlParameter("p_den_ngay",den_ngay),
                new NpgsqlParameter("p_thang_nam_int",nam_thang)
            };

            dt = dp.getDataTableProc("sp2_cal_phucap_by_dv", paras);

            return dt;
        }
    }
}
