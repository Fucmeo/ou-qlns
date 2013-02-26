using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Npgsql;
using DataProvider;
using System.Globalization;

namespace Business.HDQD
{
    public class QuyetDinh
    {
        DataProvider.DataProvider dp;
        #region Inits Methods
        public QuyetDinh()
        {
            dp = new DataProvider.DataProvider();
        }
        #endregion

        #region Properties
        
        private string ma_qd;

        public string Ma_Quyet_Dinh
        {
            get { return ma_qd; }
            set { ma_qd = value; }
        }

        private string ten_qd;

        public string Ten_Quyet_Dinh
        {
            get { return ten_qd; }
            set { ten_qd = value; }
        }

        private int? loai_qd_id;

        public int? Loai_QuyetDinh_ID
        {
            get { return loai_qd_id; }
            set { loai_qd_id = value; }
        }

        private DateTime? ngay_ky_tu;

        public DateTime? Ngay_Ky_Tu
        {
            get { return ngay_ky_tu; }
            set { ngay_ky_tu = value; }
        }

        private DateTime? ngay_ky_den;

        public DateTime? Ngay_Ky_Den
        {
            get { return ngay_ky_den; }
            set { ngay_ky_den = value; }
        }

        private DateTime? ngay_ky;

        public DateTime? Ngay_Ky
        {
            get { return ngay_ky; }
            set { ngay_ky = value; }
        }

        private DateTime? ngay_hieu_luc;

        public DateTime? Ngay_Hieu_Luc
        {
            get { return ngay_hieu_luc; }
            set { ngay_hieu_luc = value; }
        }

        private DateTime? ngay_het_han;

        public DateTime? Ngay_Het_Han
        {
            get { return ngay_het_han; }
            set { ngay_het_han = value; }
        }

        private string mota;

        public string MoTa
        {
            get { return mota; }
            set { mota = value; }
        }

        private string[] path;

        public string[] Path
        {
            get { return path; }
            set { path = value; }
        }

        private string[] pathmota;

        public string[] PathMoTa
        {
            get { return pathmota; }
            set { pathmota = value; }
        }

        #endregion

        #region Methods
        public DataTable Search_QD()
        {
            DataTable dt;

            IDataParameter[] paras = new IDataParameter[5]{
                new NpgsqlParameter("p_ma_quyet_dinh",ma_qd),
                new NpgsqlParameter("p_ten",ten_qd),
                new NpgsqlParameter("p_loai_qd",loai_qd_id),
                new NpgsqlParameter("p_ngay_ky_tu",ngay_ky_tu),
                new NpgsqlParameter("p_ngay_ky_den",ngay_ky_den)
            };

            dt = dp.getDataTableProc("sp1_qsearch_quyet_dinh", paras);

            return dt;
        }

        public bool Delete()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_ma_quyet_dinh",ma_qd)
            };
            check = (int)dp.executeScalarProc("sp1_delete_quyet_dinh", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool Add_ThayDoiThongTinDV(int[] m_IDDV_Ten, string[] m_TenDV_Ten, string[] m_TenDVTat_Ten,
                                                int[] m_IDDV_CD , int[] m_IDCu_CD , int[] m_IDMoi_CD,
                                                int [] m_IDDV_CapBac , int[] m_IDDVCha_CapBac)
        {
            IDataParameter[] paras = new IDataParameter[17]{
                new NpgsqlParameter("id_dv_doiten",m_IDDV_Ten),
                new NpgsqlParameter("ten_dv_moi",m_TenDV_Ten),
                new NpgsqlParameter("ten_dv_tat_moi",m_TenDVTat_Ten),
                new NpgsqlParameter("id_dv_chucdanh",m_IDDV_CD),
                new NpgsqlParameter("id_cd_cu",m_IDCu_CD),
                new NpgsqlParameter("id_cd_moi",m_IDMoi_CD),
                new NpgsqlParameter("id_dv_capbac",m_IDDV_CapBac),
                new NpgsqlParameter("id_dv_cha",m_IDDVCha_CapBac),
                new NpgsqlParameter("ma_qd",ma_qd),
                new NpgsqlParameter("ten_qd",ten_qd),
                new NpgsqlParameter("ngay_ky",ngay_ky),
                new NpgsqlParameter("ngay_het_han",ngay_ky_den),
                new NpgsqlParameter("loai_qd_id",loai_qd_id),
                new NpgsqlParameter("ngay_hieu_luc",ngay_ky_tu),
                new NpgsqlParameter("path",path),
                new NpgsqlParameter("path_mo_ta",pathmota),
                new NpgsqlParameter("mo_ta",mota)
            };
            try
            {
                dp.executeScalarProc("sp1_insert_qd_thaydoi_dv", paras);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
                      
        }

        public bool MA_Tach_DonVi(int[] p_tu_don_vi_id, string[] p_ten_don_vi_moi, string[] p_ten_dv_moi_viet_tat, int[] p_truc_thuoc_don_vi,
                                    string[] p_tu_ngay, string[] p_ghi_chu, string[] p_ma_nhan_vien)
        {
            string m_ngay_het_han = null;
            if (ngay_het_han != null)
                m_ngay_het_han = ngay_het_han.Value.ToShortDateString();

            IDataParameter[] paras = new IDataParameter[15]{
                new NpgsqlParameter("p_ma_qd",ma_qd),
                new NpgsqlParameter("p_ten_qd",ten_qd),
                new NpgsqlParameter("p_ma_loai_qd",loai_qd_id),
                new NpgsqlParameter("p_path",path),
                new NpgsqlParameter("p_ngay_ky",ngay_ky.Value.ToShortDateString()),
                new NpgsqlParameter("p_ngay_hieu_luc",ngay_hieu_luc.Value.ToShortDateString()),
                new NpgsqlParameter("p_ngay_het_han",m_ngay_het_han),
                new NpgsqlParameter("p_mo_ta",mota),
                new NpgsqlParameter("p_tu_don_vi_id",p_tu_don_vi_id),
                new NpgsqlParameter("p_ten_don_vi_moi",p_ten_don_vi_moi),
                new NpgsqlParameter("p_ten_dv_moi_viet_tat",p_ten_dv_moi_viet_tat),
                new NpgsqlParameter("p_truc_thuoc_don_vi",p_truc_thuoc_don_vi),
                new NpgsqlParameter("p_tu_ngay",p_tu_ngay),  // format : mm/dd/yyyy
                new NpgsqlParameter("p_ghi_chu",p_ghi_chu),
                new NpgsqlParameter("p_ma_nhan_vien",p_ma_nhan_vien)
            };
            try
            {
                dp.executeScalarProc("sp1_insert_qdma_tach_don_vi", paras);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message) ;
            }
        }

        public bool MA_Gop_DonVi(int[] p_tu_don_vi_id, string p_ten_don_vi_moi, string p_ten_dv_moi_viet_tat, int p_truc_thuoc_don_vi,
                                    DateTime p_tu_ngay, string p_ghi_chu)
        {
            IDataParameter[] paras = new IDataParameter[14]{
                new NpgsqlParameter("p_ma_qd",ma_qd.ToString()),
                new NpgsqlParameter("p_ten_qd",ten_qd.ToString()),
                new NpgsqlParameter("p_ma_loai_qd",loai_qd_id),
                new NpgsqlParameter("p_path",path.ToString()),
                new NpgsqlParameter("p_ngay_ky", ngay_ky.Value),
                new NpgsqlParameter("p_ngay_hieu_luc",ngay_hieu_luc.Value),
                new NpgsqlParameter("p_ngay_het_han",ngay_het_han.Value),
                new NpgsqlParameter("p_mo_ta",mota.ToString()),
                new NpgsqlParameter("p_tu_don_vi_id",p_tu_don_vi_id),
                new NpgsqlParameter("p_ten_don_vi_moi",p_ten_don_vi_moi),
                new NpgsqlParameter("p_ten_dv_moi_viet_tat",p_ten_dv_moi_viet_tat),
                new NpgsqlParameter("p_truc_thuoc_don_vi",p_truc_thuoc_don_vi),
                new NpgsqlParameter("p_tu_ngay",p_tu_ngay),
                new NpgsqlParameter("p_ghi_chu",p_ghi_chu)
            };
            try
            {
                dp.executeScalarProc("sp1_insert_qdma_gop_don_vi", paras);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
