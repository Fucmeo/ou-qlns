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

        public int? QuocTinh { get; set; }

        private string hokhauthuongchu_xa;

        public string HoKhauThuongTruXa
        {
            get { return hokhauthuongchu_xa; }
            set { hokhauthuongchu_xa = value; }
        }

        public string HoKhauThuongChu_Huyen { get; set; }

        public int? HoKhauThuongChu_Tinh { get; set; }

        public int QueQuan_QuocGia { get; set; }

        public int HoKhauThuongTru_QuocGia { get; set; }

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
            IDataParameter[] paras = new IDataParameter[19]{
                new NpgsqlParameter("p_ma_nv",manv), 
                new NpgsqlParameter("p_ten_goi_khac",tengoikhac), 
                new NpgsqlParameter("p_noi_sinh_xa",noisinhxa), 
                new NpgsqlParameter("p_noi_sinh_huyen",noisinhhuyen),
                new NpgsqlParameter("p_noi_sinh_tinh",noisinhtinh),
                new NpgsqlParameter("p_que_quan_xa",quequanxa),
                new NpgsqlParameter("p_que_quan_huyen",quequanhuyen),
                new NpgsqlParameter("p_que_quan_tinh",quequantinh),
                new NpgsqlParameter("p_dan_toc",dantoc),
                new NpgsqlParameter("p_ton_giao",tongiao),
                new NpgsqlParameter("p_chieu_cao",chieucao),
                new NpgsqlParameter("p_nhom_mau",nhommau),
                new NpgsqlParameter("p_ttr_hon_nhan_id",tinhtranghonhan),
                new NpgsqlParameter("p_quoc_tich",QuocTinh),
                new NpgsqlParameter("p_hokhau_thuongtru_xa",HoKhauThuongTruXa),
                new NpgsqlParameter("p_hokhau_thuongtru_huyen",HoKhauThuongChu_Huyen),
                new NpgsqlParameter("p_hokhau_thuongtru_tinh",HoKhauThuongChu_Tinh),
                new NpgsqlParameter("p_que_quan_quoc_gia",QueQuan_QuocGia),
                new NpgsqlParameter("p_hokhau_thuongtru_quoc_gia",HoKhauThuongTru_QuocGia)
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
            IDataParameter[] paras = new IDataParameter[19]{
           new NpgsqlParameter("p_ma_nv",manv), 
                new NpgsqlParameter("p_ten_goi_khac",tengoikhac), 
                new NpgsqlParameter("p_noi_sinh_xa",noisinhxa), 
                new NpgsqlParameter("p_noi_sinh_huyen",noisinhhuyen),
                new NpgsqlParameter("p_noi_sinh_tinh",noisinhtinh),
                new NpgsqlParameter("p_que_quan_xa",quequanxa),
                new NpgsqlParameter("p_que_quan_huyen",quequanhuyen),
                new NpgsqlParameter("p_que_quan_tinh",quequantinh),
                new NpgsqlParameter("p_dan_toc",dantoc),
                new NpgsqlParameter("p_ton_giao",tongiao),
                new NpgsqlParameter("p_chieu_cao",chieucao),
                new NpgsqlParameter("p_nhom_mau",nhommau),
                new NpgsqlParameter("p_ttr_hon_nhan_id",tinhtranghonhan),
                new NpgsqlParameter("p_quoc_tich",QuocTinh),
                new NpgsqlParameter("p_hokhau_thuongtru_xa",HoKhauThuongTruXa),
                new NpgsqlParameter("p_hokhau_thuongtru_huyen",HoKhauThuongChu_Huyen),
                new NpgsqlParameter("p_hokhau_thuongtru_tinh",HoKhauThuongChu_Tinh),
                new NpgsqlParameter("p_que_quan_quoc_gia",QueQuan_QuocGia),
                new NpgsqlParameter("p_hokhau_thuongtru_quoc_gia",HoKhauThuongTru_QuocGia)
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
