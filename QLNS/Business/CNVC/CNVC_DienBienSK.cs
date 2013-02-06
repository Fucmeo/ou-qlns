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

        public CNVC_DienBienSK(int p_id)
        {
            id = p_id;
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

        //private string tinhtrang;

        //public string TinhTrang
        //{
        //    get { return tinhtrang; }
        //    set { tinhtrang = value; }
        //}


        private string cannang;

        public string CanNang
        {
            get { return cannang; }
            set { cannang = value; }
        }

        private string bomo;

        public string BoMo
        {
            get { return bomo; }
            set { bomo = value; }
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

        private string viemgan_hcvab;

        public string ViemGan_HCVAB
        {
            get { return viemgan_hcvab; }
            set { viemgan_hcvab = value; }
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
                new NpgsqlParameter("p_ma_nv",manv), 
                new NpgsqlParameter("p_thoi_diem",thoidiem), 
                //new NpgsqlParameter("p_tinh_trang",tinhtrang), 
                new NpgsqlParameter("p_can_nang",cannang),
                new NpgsqlParameter("p_bo_mo",bomo),
                new NpgsqlParameter("p_que_qucngan_sgotan",cngan_sgot),
                new NpgsqlParameter("p_cngan_sgpt",cngan_sgpt),
                new NpgsqlParameter("p_viemgan_hbsag",viemgan_hbsag),
                new NpgsqlParameter("p_viemgan_hbsab",viemgan_hbsab),
                new NpgsqlParameter("p_viemgan_hcvab",viemgan_hcvab),
                new NpgsqlParameter("p_tsh",tsh),
                new NpgsqlParameter("p_ft4",ft4),
                new NpgsqlParameter("p_afp",afp),
                new NpgsqlParameter("p_cea",cea),
                new NpgsqlParameter("p_psa",psa),
                new NpgsqlParameter("p_hp_dinh_luong",hp_dinh_luong),
                new NpgsqlParameter("p_tptnt",tptnt),
                new NpgsqlParameter("p_phan_loai",phanloai),
                new NpgsqlParameter("p_ket_luan",ketluan),
                new NpgsqlParameter("p_de_nghi",denghi)
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
            IDataParameter[] paras = new IDataParameter[19]{
                new NpgsqlParameter("p_id",id),
                new NpgsqlParameter("p_thoi_diem",thoidiem), 
                //new NpgsqlParameter("p_tinh_trang",tinhtrang), 
                new NpgsqlParameter("p_can_nang",cannang),
                new NpgsqlParameter("p_bo_mo",bomo),
                new NpgsqlParameter("p_que_qucngan_sgotan",cngan_sgot),
                new NpgsqlParameter("p_cngan_sgpt",cngan_sgpt),
                new NpgsqlParameter("p_viemgan_hbsag",viemgan_hbsag),
                new NpgsqlParameter("p_viemgan_hbsab",viemgan_hbsab),
                new NpgsqlParameter("p_viemgan_hcvab",viemgan_hcvab),
                new NpgsqlParameter("p_tsh",tsh),
                new NpgsqlParameter("p_ft4",ft4),
                new NpgsqlParameter("p_afp",afp),
                new NpgsqlParameter("p_cea",cea),
                new NpgsqlParameter("p_psa",psa),
                new NpgsqlParameter("p_hp_dinh_luong",hp_dinh_luong),
                new NpgsqlParameter("p_tptnt",tptnt),
                new NpgsqlParameter("p_phan_loai",phanloai),
                new NpgsqlParameter("p_ket_luan",ketluan),
                new NpgsqlParameter("p_de_nghi",denghi)
            };

            check = (int)dp.executeScalarProc("sp_update_cnvc_dien_bien_suc_khoe", paras);
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
                new NpgsqlParameter("id",id)
            };
            check = (int)dp.executeScalarProc("sp_delete_cnvc_dien_bien_suc_khoe", paras);
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
            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_ma_nv", manv)
            };

            dt = dp.getDataTableProc("sp_select_cnvc_dien_bien_suc_khoe", paras);

            return dt;
        }

        #endregion
    }
}
