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
    public class CNVC_PhuCap
    {
        DataProvider.DataProvider dp;

        #region Init Methods
        public CNVC_PhuCap()
        {
            dp = new DataProvider.DataProvider();
        }

        #endregion

        #region Methods
        public DataTable GetList_PhuCap_byCNVC(string p_ma_hop_dong, string p_ma_nv)
        {
            IDataParameter[] paras = new IDataParameter[2]{
                new NpgsqlParameter("p_ma_hop_dong",p_ma_hop_dong),
                new NpgsqlParameter("p_ma_nv",p_ma_nv)
            };
            return dp.getDataTableProc("sp_select_cnvc_phu_cap", paras);
        }
        #endregion
    }
}
