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
    public class CNVC_DienBienSK
    {
        DataProvider.DataProvider dp;

        #region Init method

        public CNVC_DienBienSK()
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

        private DateTime? thoidiem;

        public DateTime? ThoiDiem
        {
            get { return thoidiem; }
            set { thoidiem = value; }
        }

        private string tinhtrang;

        public string TinhTrang
        {
            get { return tinhtrang; }
            set { tinhtrang = value; }
        }
        

        private string cannang;

        public string CanNang
        {
            get { return cannang; }
            set { cannang = value; }
        }

        private string domo;

        public string DoMo
        {
            get { return domo; }
            set { domo = value; }
        }


        private string cngan_sgot;

        public string CNGAN_SGOT
        {
            get { return cngan_sgot; }
            set { cngan_sgot = value; }
        }

        private string cngan_sgpt;

        public string CNGAN_SGPT
        {
            get { return cngan_sgpt; }
            set { cngan_sgpt = value; }
        }

        private string viemgan_hbsag;

        public string ViemGan_HBSAG
        {
            get { return viemgan_hbsag; }
            set { viemgan_hbsag = value; }
        }

        private string viemgan_hbsab;

        public string ViemGan_HBSAB
        {
            get { return viemgan_hbsab; }
            set { viemgan_hbsab = value; }
        }

        private string tsh;

        public string TSH
        {
            get { return tsh; }
            set { tsh = value; }
        }

        private string ft4;

        public string FT4
        {
            get { return ft4; }
            set { ft4 = value; }
        }

        private string afp;

        public string AFP
        {
            get { return afp; }
            set { afp = value; }
        }

        private string cea;

        public string CEA
        {
            get { return cea; }
            set { cea = value; }
        }

        private string psa;

        public string PSA
        {
            get { return psa; }
            set { psa = value; }
        }

        private string hp_dinh_luong;

        public string HP_Dinh_Luong
        {
            get { return hp_dinh_luong; }
            set { hp_dinh_luong = value; }
        }

        private string tptnt;

        public string TPTNT
        {
            get { return tptnt; }
            set { tptnt = value; }
        }

        private string phanloai;

        public string PhanLoai
        {
            get { return phanloai; }
            set { phanloai = value; }
        }

        private string ketluan;

        public string KetLuan
        {
            get { return ketluan; }
            set { ketluan = value; }
        }

        private string denghi;

        public string DeNghi
        {
            get { return denghi; }
            set { denghi = value; }
        }
        

        #endregion

        #region Methods

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[19]{
                new NpgsqlParameter("ma_nv",manv), 
                new NpgsqlParameter("thoi_diem",thoidiem), 
                new NpgsqlParameter("tinh_trang",tinhtrang), 
                new NpgsqlParameter("can_nang",cannang),
                new NpgsqlParameter("do_mo",domo),
                new NpgsqlParameter("que_qucngan_sgotan",cngan_sgot),
                new NpgsqlParameter("cngan_sgpt",cngan_sgpt),
                new NpgsqlParameter("viemgan_hbsag",viemgan_hbsag),
                new NpgsqlParameter("viemgan_hbsab",viemgan_hbsab),
                new NpgsqlParameter("tsh",tsh),
                new NpgsqlParameter("ft4",ft4),
                new NpgsqlParameter("afp",afp),
                new NpgsqlParameter("cea",cea),
                new NpgsqlParameter("psa",psa),
                new NpgsqlParameter("hp_dinh_luong",hp_dinh_luong),
                new NpgsqlParameter("tptnt",tptnt),
                new NpgsqlParameter("phan_loai",phanloai),
                new NpgsqlParameter("ket_luan",ketluan),
                new NpgsqlParameter("de_nghi",denghi)
            };
            check = (int)dp.executeScalarProc("sp_insert_cnvc_dien_bien_suc_khoe", paras);
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
            IDataParameter[] paras = new IDataParameter[20]{
                new NpgsqlParameter("p_id",id),
                new NpgsqlParameter("ma_nv",manv), 
                new NpgsqlParameter("moi_quan_he",thoidiem), 
                new NpgsqlParameter("ho",tinhtrang), 
                new NpgsqlParameter("ten",cannang),
                new NpgsqlParameter("nam_sinh",domo),
                new NpgsqlParameter("que_quan",cngan_sgot),
                new NpgsqlParameter("nghe_nghiep",cngan_sgpt),
                new NpgsqlParameter("chuc_danh_chuc_vu",viemgan_hbsag),
                new NpgsqlParameter("don_vi_cong_tac",viemgan_hbsab),
                new NpgsqlParameter("dia_chi",tsh),
                new NpgsqlParameter("thanh_vien_to_chuc_ctr_xh",ft4),
                new NpgsqlParameter("hoc_tap",afp),
                new NpgsqlParameter("ghi_chu",cea),
                new NpgsqlParameter("ghi_chu",psa),
                new NpgsqlParameter("ghi_chu",hp_dinh_luong),
                new NpgsqlParameter("ghi_chu",tptnt),
                new NpgsqlParameter("ghi_chu",phanloai),
                new NpgsqlParameter("ghi_chu",ketluan),
                new NpgsqlParameter("ghi_chu",denghi)
            };

            check = (int)dp.executeScalarProc("sp_update_cnvc_dien_bien_suc_khoe", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }


        #endregion
    }
}
