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
    public class CNVC
    {
        DataProvider.DataProvider dp;

        #region Init method

        public CNVC()
        {
            dp = new DataProvider.DataProvider();
        }
        

        #endregion

        #region Properties

        private string mahoso;

        public string MaHoSo
        {
            get { return mahoso; }
            set { mahoso = value; }
        }

        private string manv;

        public string MaNV
        {
            get { return manv; }
            set { manv = value; }
        }

        private string ho;

        public string Ho
        {
            get { return ho; }
            set { ho = value; }
        }

        private string ten;

        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }

        private string diachi;

        public string DiaChi
        {
            get { return diachi; }
            set { diachi = value; }
        }

        private string sonha;

        public string SoNha
        {
            get { return sonha; }
            set { sonha = value; }
        }

        private string duong;

        public string Duong
        {
            get { return duong; }
            set { duong = value; }
        }

        private string phuong;

        public string Phuong
        {
            get { return phuong; }
            set { phuong = value; }
        }

        private string quan;

        public string Quan
        {
            get { return quan; }
            set { quan = value; }
        }

        private int? tinh;

        public int? Tinh
        {
            get { return tinh; }
            set { tinh = value; }
        }

        private int? quocgia;

        public int? QuocGia
        {
            get { return quocgia; }
            set { quocgia = value; }
        }
        
        private string sobhxh;

        public string SoBHXH
        {
            get { return sobhxh; }
            set { sobhxh = value; }
        }

        private string masothue;

        public string MaSoThue
        {
            get { return masothue; }
            set { masothue = value; }
        }

        private DateTime? ngaysinh;

        public DateTime? NgaySinh
        {
            get { return ngaysinh; }
            set { ngaysinh = value; }
        }

        private bool? gioitinh;

        public bool? GioiTinh
        {
            get { return gioitinh; }
            set { gioitinh = value; }
        }
        

        #endregion

        #region Methods

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[14]{
                new NpgsqlParameter("p_ma_nv",manv), 
                new NpgsqlParameter("p_ho",ho), 
                new NpgsqlParameter("p_ten",ten), 
                new NpgsqlParameter("p_ma_ho_so",mahoso), 
                new NpgsqlParameter("p_so_so_bhxh",sobhxh), 
                new NpgsqlParameter("p_ma_so_thue",masothue), 
                new NpgsqlParameter("p_ngay_sinh",ngaysinh),
                new NpgsqlParameter("p_gioi_tinh",gioitinh),
                new NpgsqlParameter("p_so_nha",sonha), 
                new NpgsqlParameter("p_duong",duong), 
                new NpgsqlParameter("p_phuong_xa",phuong), 
                new NpgsqlParameter("p_quan_huyen",quan),
                new NpgsqlParameter("p_tinh_thanhpho",tinh),
                new NpgsqlParameter("p_quoc_gia",quocgia)
            };
            check = (int)dp.executeScalarProc("sp_insert_cnvc", paras);
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
                new NpgsqlParameter("p_ma_nv",manv)
            };

            check = (int)dp.executeScalarProc("sp_delete_cnvc", paras);
            if (check > 0)
                return true;
            else
                return false;

        }

        public bool Update(string ma_nv_old)
        {
            int check;
            IDataParameter[] paras = new IDataParameter[14]{
                new NpgsqlParameter("p_ma_nv_old",ma_nv_old), 
                new NpgsqlParameter("p_ma_nv",manv), 
                new NpgsqlParameter("p_ho",ho), 
                new NpgsqlParameter("p_ten",ten), 
                new NpgsqlParameter("p_ma_ho_so_goc",mahoso), 
                new NpgsqlParameter("p_so_so_bhxh",sobhxh), 
                new NpgsqlParameter("p_ma_so_thue",masothue), 
                new NpgsqlParameter("p_gioi_tinh",gioitinh),
                new NpgsqlParameter("p_so_nha",sonha), 
                new NpgsqlParameter("p_duong",duong), 
                new NpgsqlParameter("p_phuong_xa",phuong), 
                new NpgsqlParameter("p_quan_huyen",quan),
                new NpgsqlParameter("p_tinh_thanhpho",tinh),
                new NpgsqlParameter("p_quoc_gia",quocgia)
            };
            check = (int)dp.executeScalarProc("sp_update_cnvc", paras);
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

            dt = dp.getDataTableProc("sp_select_cnvc", paras);

            return dt;
        }

        public DataTable SearchDataForQD(bool bIngoreQTCT)
        {
            DataTable dt;

            IDataParameter[] paras = new IDataParameter[3]{
                new NpgsqlParameter("p_ma_nv",manv),               
                new NpgsqlParameter("p_ho",ho),
                new NpgsqlParameter("p_ten",ten)
            };
            if (bIngoreQTCT)
            {
                dt = dp.getDataTableProc("sp1_qsearch_nv_basic_info_ingore_qtct", paras);  
            }
            else
            {
                dt = dp.getDataTableProc("sp1_qsearch_nv_basic_info", paras);
            }
            

            return dt;
        }

        public DataTable GetDonViChucVuForQD()
        {
            DataTable dt;

            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_ma_nv",manv)               
            };

            dt = dp.getDataTableProc("sp1_qsearch_nv_qtrctac_info", paras);

            return dt;
        }

        public DataTable Search_Ho_Ten()
        {
            DataTable dt;

            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_ma_nv",manv)               
            };

            dt = dp.getDataTableProc("sp1_qsearch_hoten_nv", paras);

            return dt;
        }

        public DataTable Search_CNVC_by_DonVi(int p_don_vi_id)
        {
            DataTable dt;

            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_ma_don_vi",p_don_vi_id)               
            };

            dt = dp.getDataTableProc("sp1_qsearch_nv_by_donvi", paras);

            return dt;
        }

        #endregion


    }
}
