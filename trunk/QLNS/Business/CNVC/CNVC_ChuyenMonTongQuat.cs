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
    public class CNVC_ChuyenMonTongQuat
    {
        DataProvider.DataProvider dp;

        #region Init method

        public CNVC_ChuyenMonTongQuat()
        {
            dp = new DataProvider.DataProvider();
        }
        

        #endregion

        #region Properties

        private string manv;

        public string MaNV
        {
            get { return manv; }
            set { manv = value; }
        }

        private string ngoaingu;

        public string NgoaiNgu
        {
            get { return ngoaingu; }
            set { ngoaingu = value; }
        }

        private string tinhoc;

        public string TinHoc
        {
            get { return tinhoc; }
            set { tinhoc = value; }
        }

        private string sotruongctac;

        public string SoTruongCTac
        {
            get { return sotruongctac; }
            set { sotruongctac = value; }
        }

        private string trdochuyenmon;

        public string TrinhDoChuyenMon
        {
            get { return trdochuyenmon; }
            set { trdochuyenmon = value; }
        }

        private int mohinhdaotaoid;

        public int MoHinhDaoTaoID
        {
            get { return mohinhdaotaoid; }
            set { mohinhdaotaoid = value; }
        }

        #endregion

        #region Methods

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[6]{
                new NpgsqlParameter("ma_nv",manv),
                new NpgsqlParameter("ngoai_ngu",ngoaingu),
                new NpgsqlParameter("tin_hoc",tinhoc),
                new NpgsqlParameter("so_truong_cong_tac",sotruongctac),
                new NpgsqlParameter("trinh_do_chuyen_mon",trdochuyenmon),
                new NpgsqlParameter("mo_hinh_dao_tao_id",mohinhdaotaoid)
            };
            check = (int)dp.executeScalarProc("sp_insert_cnvc_chuyen_mon_tong_quat", paras);
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
            IDataParameter[] paras = new IDataParameter[6]{
                new NpgsqlParameter("p_ma_nv",manv),
                new NpgsqlParameter("p_ngoai_ngu",ngoaingu),
                new NpgsqlParameter("p_tin_hoc",tinhoc),
                new NpgsqlParameter("p_so_truong_cong_tac",sotruongctac),
                new NpgsqlParameter("p_trinh_do_chuyen_mon",trdochuyenmon),
                new NpgsqlParameter("p_mo_hinh_dao_tao_id",mohinhdaotaoid)
            };
            check = (int)dp.executeScalarProc("sp_update_cnvc_chuyen_mon_tong_quat", paras);
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
                new NpgsqlParameter("ma_nv",manv)
            };
            check = (int)dp.executeScalarProc("sp_delete_chuyen_mon_tong_quat", paras);
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
                new NpgsqlParameter("p_ma_nv",manv)               
            };

            dt = dp.getDataTableProc("sp_select_cnvc_chuyen_mon_tong_quat", paras);

            return dt;
        }

        #endregion
    }
}
