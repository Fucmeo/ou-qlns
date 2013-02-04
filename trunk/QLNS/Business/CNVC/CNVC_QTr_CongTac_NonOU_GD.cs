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
    public class CNVC_QTr_CongTac_NonOU_GD
    {
        DataProvider.DataProvider dp;

        #region Init method

        public CNVC_QTr_CongTac_NonOU_GD()
        {
            dp = new DataProvider.DataProvider();
        }

        #endregion

        #region Properties

        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string manv;

        public string MaNV
        {
            get { return manv; }
            set { manv = value; }
        }

        private string tendonvi;

        public string TenDonVi
        {
            get { return tendonvi; }
            set { tendonvi = value; }
        }


        private string chucdanh;

        public string ChucDanh
        {
            get { return chucdanh; }
            set { chucdanh = value; }
        }

        private string chucvu;

        public string ChucVu
        {
            get { return chucvu; }
            set { chucvu = value; }
        }

        private DateTime? tungay;

        public DateTime? TuNgay
        {
            get { return tungay; }
            set { tungay = value; }
        }

        private DateTime? denngay;

        public DateTime? DenNgay
        {
            get { return denngay; }
            set { denngay = value; }
        }

        private string congviecchinh;

        public string CongViecChinh
        {
            get { return congviecchinh; }
            set { congviecchinh = value; }
        }
        
        
        #endregion

        #region Methods

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[7]{
                new NpgsqlParameter("ma_nv",manv), 
                new NpgsqlParameter("ten_don_vi",tendonvi), 
                new NpgsqlParameter("chuc_danh",chucdanh), 
                new NpgsqlParameter("chuc_vu",chucvu), 
                new NpgsqlParameter("tu_ngay",tungay), 
                new NpgsqlParameter("den_ngay",denngay), 
                new NpgsqlParameter("cong_viec_chinh",congviecchinh)
            };
            check = (int)dp.executeScalarProc("sp_insert_cnvc_nonou_gd", paras);
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
            check = (int)dp.executeScalarProc("sp_delete_cnvc_qtr_congtac_nonou_gd", paras);
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
           new NpgsqlParameter("p_id",id), 
                new NpgsqlParameter("p_ten_don_vi",tendonvi), 
                new NpgsqlParameter("p_chuc_danh",chucdanh), 
                new NpgsqlParameter("p_chuc_vu",chucvu), 
                new NpgsqlParameter("p_tu_ngay",tungay), 
                new NpgsqlParameter("p_den_ngay",denngay), 
                new NpgsqlParameter("p_cong_viec_chinh",congviecchinh)
            };
            check = (int)dp.executeScalarProc("sp_update_cnvc_nonou_gd", paras);
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

            dt = dp.getDataTableProc("sp_select_nonou_gd", paras);

            return dt;
        }

        #endregion
    }
}
