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
    public class ChamCong
    {
        DataProvider.DataProvider dp;

        public ChamCong()
        {
            dp = new DataProvider.DataProvider();
        }


        #region Properties

        public int LoaiNgayPhepID { get; set; }

        public DateTime TuNgay { get; set; }

        public DateTime DenNgay { get; set; }

        public bool IsUngTruoc { get; set; }

        public string GhiChu { get; set; } 
	#endregion

        public DataTable GetNgayNghiByNV(string pMaNV)
        {
            DataTable dt;

            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("manv",pMaNV)               
            };

            dt = dp.getDataTableProc("sp2_select_ngay_phep_by_nv", paras);

            return dt;
        }

        public bool Add(string pMaNV,List<string> lFrom,List<string> lTo,List<int> pWorkingDay)
        {
            int check;
            IDataParameter[] paras = new IDataParameter[7]{
                new NpgsqlParameter("p_manv",pMaNV),
                new NpgsqlParameter("p_loai_ngay_phep_id",LoaiNgayPhepID),
                new NpgsqlParameter("p_tu_ngay",lFrom.ToArray()),
                new NpgsqlParameter("p_den_ngay",lTo.ToArray()),
                new NpgsqlParameter("pWorkingDay",pWorkingDay.ToArray()),
                new NpgsqlParameter("p_is_ung_truoc",IsUngTruoc),
                new NpgsqlParameter("p_ghi_chu",GhiChu)
            };
            check = (int)dp.executeScalarProc("sp2_insert_ngay_phep", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool Delete(string pMaNV,string[] pDate)
        {
            int check;
            IDataParameter[] paras = new IDataParameter[2]{
                new NpgsqlParameter("p_manv",pMaNV),
                new NpgsqlParameter("p_date",pDate)
            };
            check = (int)dp.executeScalarProc("sp2_delete_ngay_nghi_by_nv", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }
    }

    


    
}
