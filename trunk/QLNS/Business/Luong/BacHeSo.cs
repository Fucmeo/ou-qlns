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
    public class BacHeSo
    {
        DataProvider.DataProvider dp;

        public BacHeSo()
        {
            dp = new DataProvider.DataProvider();
        }

        #region Properties

        public int ID { get; set; }

        public string MaNgach { get; set; }

        public string TenNgach { get; set; }

        public int Bac { get; set; }

        public double HeSo { get; set; }

        public bool IsVuotKhung { get; set; }

        public DateTime? TuNgay { get; set; }

        public DateTime? DenNgay { get; set; }

        public bool TinhTrang { get; set; }
        #endregion

        #region Methods
        public bool Delete()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_id",ID)
            };
            check = (int)dp.executeScalarProc("sp2_delete_ngach_bac_heso", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[6]{
                new NpgsqlParameter("p_ma_ngach",MaNgach),
                new NpgsqlParameter("p_bac",Bac),
                new NpgsqlParameter("p_he_so",HeSo),
                new NpgsqlParameter("p_is_vuot_khung",IsVuotKhung),
                new NpgsqlParameter("p_tu_ngay",TuNgay),
                new NpgsqlParameter("p_den_ngay",DenNgay)
            };
            check = (int)dp.executeScalarProc("sp2_insert_ngach_bac_heso", paras);
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
            IDataParameter[] paras = new IDataParameter[7]{
                new NpgsqlParameter("p_id",ID),
                new NpgsqlParameter("p_ma_ngach",MaNgach),
                new NpgsqlParameter("p_bac",Bac),
                new NpgsqlParameter("p_he_so",HeSo),
                new NpgsqlParameter("p_is_vuot_khung",IsVuotKhung),
                new NpgsqlParameter("p_tu_ngay",TuNgay),
                new NpgsqlParameter("p_den_ngay",DenNgay)
            };
            check = (int)dp.executeScalarProc("sp2_update_ngach_bac_heso", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public DataTable GetData()
        {
            DataTable dt = new DataTable();

            dt = dp.getDataTable("select * from v_ngach_bac_heso");

            return dt;
        }

        #endregion
    }
}
