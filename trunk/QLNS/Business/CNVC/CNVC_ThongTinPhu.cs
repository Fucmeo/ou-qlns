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
    public class CNVC_ThongTinPhu
    {
        DataProvider.DataProvider dp;

        #region Init method

        public CNVC_ThongTinPhu()
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

        private string tengoikhac;

        public string TenGoiKhac
        {
            get { return tengoikhac; }
            set { tengoikhac = value; }
        }

        private string noisinhxa;

        public string NoiSinhXa
        {
            get { return noisinhxa; }
            set { noisinhxa = value; }
        }

        private string noisinhhuyen;

        public string NoiSinhHuyen
        {
            get { return noisinhhuyen; }
            set { noisinhhuyen = value; }
        }

        private int? noisinhtinh;

        public int? NoiSinhTinh
        {
            get { return noisinhtinh; }
            set { noisinhtinh = value; }
        }

        private string quequanxa;

        public string QueQuanXa
        {
            get { return quequanxa; }
            set { quequanxa = value; }
        }

        private string quequanhuyen;

        public string QueQuanHuyen
        {
            get { return quequanhuyen; }
            set { quequanhuyen = value; }
        }

        private int? quequantinh;

        public int? QueQuanTinh
        {
            get { return quequantinh; }
            set { quequantinh = value; }
        }

        private string dantoc;

        public string DanToc
        {
            get { return dantoc; }
            set { dantoc = value; }
        }

        private string tongiao;

        public string TonGiao
        {
            get { return tongiao; }
            set { tongiao = value; }
        }

        private string hokhauthuongchu;

        public string HoKhauThuongTru
        {
            get { return hokhauthuongchu; }
            set { hokhauthuongchu = value; }
        }

        private string chieucao;

        public string ChieuCao
        {
            get { return chieucao; }
            set { chieucao = value; }
        }

        private string nhommau;

        public string NhomMau
        {
            get { return nhommau; }
            set { nhommau = value; }
        }

        private int? tinhtranghonhan;

        public int? TinhTrangHonNhan
        {
            get { return tinhtranghonhan; }
            set { tinhtranghonhan = value; }
        }
        

        #endregion

        #region Methods

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[13]{
                new NpgsqlParameter("ma_nv",manv), 
                new NpgsqlParameter("ten_goi_khac",tengoikhac), 
                new NpgsqlParameter("noi_sinh_xa",noisinhxa), 
                new NpgsqlParameter("noi_sinh_huyen",noisinhhuyen),
                new NpgsqlParameter("noi_sinh_huyen",noisinhtinh),
                new NpgsqlParameter("noi_sinh_huyen",quequanxa),
                new NpgsqlParameter("noi_sinh_huyen",quequanhuyen),
                new NpgsqlParameter("noi_sinh_huyen",quequantinh),
                new NpgsqlParameter("noi_sinh_huyen",dantoc),
                new NpgsqlParameter("noi_sinh_huyen",tongiao),
                new NpgsqlParameter("noi_sinh_huyen",hokhauthuongchu),
                new NpgsqlParameter("noi_sinh_huyen",chieucao),
                new NpgsqlParameter("noi_sinh_huyen",tinhtranghonhan)
            };
            check = (int)dp.executeScalarProc("sp_insert_cnvc_thong_tin_phu", paras);
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
            IDataParameter[] paras = new IDataParameter[13]{
           new NpgsqlParameter("ma_nv",manv), 
                new NpgsqlParameter("ten_goi_khac",tengoikhac), 
                new NpgsqlParameter("noi_sinh_xa",noisinhxa), 
                new NpgsqlParameter("noi_sinh_huyen",noisinhhuyen),
                new NpgsqlParameter("noi_sinh_huyen",noisinhtinh),
                new NpgsqlParameter("noi_sinh_huyen",quequanxa),
                new NpgsqlParameter("noi_sinh_huyen",quequanhuyen),
                new NpgsqlParameter("noi_sinh_huyen",quequantinh),
                new NpgsqlParameter("noi_sinh_huyen",dantoc),
                new NpgsqlParameter("noi_sinh_huyen",tongiao),
                new NpgsqlParameter("noi_sinh_huyen",hokhauthuongchu),
                new NpgsqlParameter("noi_sinh_huyen",chieucao),
                new NpgsqlParameter("noi_sinh_huyen",tinhtranghonhan)
            };
            check = (int)dp.executeScalarProc("sp_update_cnvc_thong_tin_phu", paras);
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

            dt = dp.getDataTableProc("sp_select_cnvc_info_phu", paras);

            return dt;
        }

        #endregion
    }
}
