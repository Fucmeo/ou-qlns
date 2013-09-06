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
        ExpressionTree ET;

        #region Inits Methods
        public QuyetDinh()
        {
            dp = new DataProvider.DataProvider();
            ET = new ExpressionTree();
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
                new NpgsqlParameter("id_dv_chucvu",m_IDDV_CD),
                new NpgsqlParameter("id_cd_cu",m_IDCu_CD),
                new NpgsqlParameter("id_cd_moi",m_IDMoi_CD),
                new NpgsqlParameter("id_dv_capbac",m_IDDV_CapBac),
                new NpgsqlParameter("id_dv_cha",m_IDDVCha_CapBac),
                new NpgsqlParameter("ma_qd",ma_qd + "_" + ngay_ky_tu.Value.ToString("ddMMyyyy")),
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
                m_ngay_het_han = ngay_het_han.Value.ToString("d", CultureInfo.CreateSpecificCulture("vi-VN"));

            IDataParameter[] paras = new IDataParameter[15]{
                new NpgsqlParameter("p_ma_qd",ma_qd + "_" + ngay_hieu_luc.Value.ToString("ddMMyyyy")),
                new NpgsqlParameter("p_ten_qd",ten_qd),
                new NpgsqlParameter("p_ma_loai_qd",loai_qd_id),
                new NpgsqlParameter("p_path",path),
                new NpgsqlParameter("p_ngay_ky",ngay_ky.Value.ToString("d", CultureInfo.CreateSpecificCulture("vi-VN"))),
                new NpgsqlParameter("p_ngay_hieu_luc",ngay_hieu_luc.Value.ToString("d", CultureInfo.CreateSpecificCulture("vi-VN"))),
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

        public bool MA_Gop_DonVi(int[] p_tu_don_vi_id, string p_ten_don_vi_moi, string p_ten_dv_moi_viet_tat, int? p_truc_thuoc_don_vi,
                                    string p_tu_ngay, string p_ghi_chu)
        {
            //string vi_VN = dt.ToString("d", CultureInfo.CreateSpecificCulture("vi-VN"));

            string m_ngay_het_han = null;
            if (ngay_het_han != null)
                m_ngay_het_han = ngay_het_han.Value.ToString("d", CultureInfo.CreateSpecificCulture("vi-VN"));

            IDataParameter[] paras = new IDataParameter[14]{
                new NpgsqlParameter("p_ma_qd",ma_qd + "_" + ngay_hieu_luc.Value.ToString("ddMMyyyy")),
                new NpgsqlParameter("p_ten_qd",ten_qd),
                new NpgsqlParameter("p_ma_loai_qd",loai_qd_id),
                new NpgsqlParameter("p_path",path),
                new NpgsqlParameter("p_ngay_ky", ngay_ky.Value.ToString("d", CultureInfo.CreateSpecificCulture("vi-VN"))),
                new NpgsqlParameter("p_ngay_hieu_luc",ngay_hieu_luc.Value.ToString("d", CultureInfo.CreateSpecificCulture("vi-VN"))),
                new NpgsqlParameter("p_ngay_het_han",m_ngay_het_han),
                new NpgsqlParameter("p_mo_ta",mota),
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


        public bool Add_ThanhLapDV(string[] m_TenDV_Ten, string[] m_TenDVTat_Ten,
                                                int[] m_IDDVCha, string[] m_GhiChu, DateTime[] m_NgayHieuLuc)
        {
            IDataParameter[] paras = new IDataParameter[13]{
                new NpgsqlParameter("p_ma_qd",ma_qd + "_" + ngay_hieu_luc.Value.ToString("ddMMyyyy")),
                new NpgsqlParameter("p_ten_qd",ten_qd),
                new NpgsqlParameter("path",path),
                new NpgsqlParameter("path_mo_ta",pathmota),
                new NpgsqlParameter("p_ngay_ky",ngay_ky),
                new NpgsqlParameter("p_ngay_hieu_luc",ngay_hieu_luc),
                new NpgsqlParameter("p_ngay_het_han",ngay_het_han),
                new NpgsqlParameter("p_mo_ta",mota),
                new NpgsqlParameter("p_ten_don_vi_moi",m_TenDV_Ten),
                new NpgsqlParameter("p_ten_dv_moi_viet_tat",m_TenDVTat_Ten),
                new NpgsqlParameter("p_truc_thuoc_don_vi",m_IDDVCha),
                new NpgsqlParameter("p_tu_ngay",m_NgayHieuLuc.Select( a => a.ToString("d", CultureInfo.CreateSpecificCulture("vi-VN"))).ToArray()),  // format : mm/dd/yyyy),
                new NpgsqlParameter("p_ghi_chu",m_GhiChu)
            };
            try
            {
                dp.executeScalarProc("sp1_insert_thanh_lap_dv", paras);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Add_QuyetDinhChung(bool p_tham_nien_nang_bac, bool p_tham_nien_gd, bool p_define_cthuc, string p_cthuc, string p_cthuc_value, 
                            double? p_cthuc_phantram, bool p_khong_tinh_luong, string[] p_ma_nv, bool[] p_ins_qtr_ctac, int[] p_don_vi_id, int[] p_chuc_vu_id, int[] p_chuc_danh_id,
                            bool[] p_co_phu_cap, int[] p_loai_phu_cap_id, double[] p_value_khoan, double[] p_value_he_so, double[] p_value_phan_tram,
                            double[] p_phan_tram_huong_pc, DateTime[] p_tu_ngay_pc, DateTime[] p_den_ngay_pc, string[] p_ghi_chu_pc)
        {
            //string vi_VN = dt.ToString("d", CultureInfo.CreateSpecificCulture("vi-VN"));

            string m_ngay_het_han = null;
            if (ngay_het_han != null)
                m_ngay_het_han = ngay_het_han.Value.ToString("d", CultureInfo.CreateSpecificCulture("vi-VN"));

            List<string> lstValue = new List<string>();
            List<Boolean> lstIsLeaf = new List<Boolean>();
            List<Boolean> lstIsRoot = new List<Boolean>();
            List<string> lstLeftNode = new List<string>();
            List<string> lstRightNode = new List<string>();

            if (p_define_cthuc == true)
            {
                ET.GetExpressionTreeData(ET.Infix2ExpressionTree(p_cthuc_value));
                lstValue = ET.lstValue;
                lstIsLeaf = ET.lstIsLeaf;
                lstIsRoot = ET.lstIsRoot;
                lstLeftNode = ET.lstLeftNode;
                lstRightNode = ET.lstRightNode;
            }
            else
            {
                lstValue = null;
                lstIsLeaf = null;
                lstIsRoot = null;
                lstLeftNode = null;
                lstRightNode = null;
            }

            IDataParameter[] paras = new IDataParameter[34]{
                new NpgsqlParameter("p_ma_quyet_dinh",ma_qd + "_" + ngay_hieu_luc.Value.ToString("ddMMyyyy")),
                new NpgsqlParameter("p_ten_quyet_dinh",ten_qd),
                new NpgsqlParameter("p_loai_qd",loai_qd_id),
                new NpgsqlParameter("p_ngay_ky", ngay_ky.Value),
                new NpgsqlParameter("p_ngay_hieu_luc",ngay_hieu_luc.Value),
                new NpgsqlParameter("p_ngay_het_han",m_ngay_het_han),
                new NpgsqlParameter("p_mo_ta",mota),
                new NpgsqlParameter("p_path",path),
                new NpgsqlParameter("p_tham_nien_nang_bac",p_tham_nien_nang_bac),
                new NpgsqlParameter("p_tham_nien_gd",p_tham_nien_gd),
                new NpgsqlParameter("p_define_cthuc",p_define_cthuc),
                new NpgsqlParameter("p_cthuc",p_cthuc),
                new NpgsqlParameter("p_cthuc",p_cthuc_value),
                new NpgsqlParameter("p_cthuc_phantram",p_cthuc_phantram),
                new NpgsqlParameter("p_khong_tinh_luong",p_khong_tinh_luong),
                new NpgsqlParameter("p_ma_nv",p_ma_nv),
                new NpgsqlParameter("p_ins_qtr_ctac",p_ins_qtr_ctac),
                new NpgsqlParameter("p_don_vi_id",p_don_vi_id),
                new NpgsqlParameter("p_chuc_vu_id",p_chuc_vu_id),
                new NpgsqlParameter("p_chuc_danh_id",p_chuc_danh_id),
                new NpgsqlParameter("p_co_phu_cap",p_co_phu_cap),
                new NpgsqlParameter("p_loai_phu_cap_id",p_loai_phu_cap_id),
                new NpgsqlParameter("p_value_khoan",p_value_khoan),
                new NpgsqlParameter("p_value_he_so",p_value_he_so),
                new NpgsqlParameter("p_value_phan_tram",p_value_phan_tram),
                new NpgsqlParameter("p_phan_tram_huong_pc",p_phan_tram_huong_pc),
                new NpgsqlParameter("p_tu_ngay_pc",p_tu_ngay_pc),
                new NpgsqlParameter("p_den_ngay_pc",p_den_ngay_pc),
                new NpgsqlParameter("p_ghi_chu_pc",p_ghi_chu_pc),
                new NpgsqlParameter("m_value",(lstValue == null) ? null : lstValue.ToArray()),
                new NpgsqlParameter("m_is_leaf",(lstValue == null) ? null :lstIsLeaf.ToArray()),
                new NpgsqlParameter("m_is_root",(lstValue == null) ? null :lstIsRoot.ToArray()),
                new NpgsqlParameter("m_left_node",(lstValue == null) ? null :lstLeftNode.ToArray()),
                new NpgsqlParameter("m_right_node",(lstValue == null) ? null :lstRightNode.ToArray())
            };
            try
            {
                dp.executeScalarProc("sp1_insert_quyet_dinh_chung", paras);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update_QuyetDinhChung(string p_ma_qd_old, bool p_tham_nien_nang_bac, bool p_tham_nien_gd, bool p_define_cthuc, string p_cthuc, string p_cthuc_value,
                            double? p_cthuc_phantram, bool p_khong_tinh_luong, string[] p_ma_nv, bool[] p_ins_qtr_ctac, int[] p_don_vi_id, int[] p_chuc_vu_id, int[] p_chuc_danh_id,
                            bool[] p_co_phu_cap, int[] p_loai_phu_cap_id, double[] p_value_khoan, double[] p_value_he_so, double[] p_value_phan_tram,
                            double[] p_phan_tram_huong_pc, DateTime[] p_tu_ngay_pc, DateTime[] p_den_ngay_pc, string[] p_ghi_chu_pc)
        {
            //string vi_VN = dt.ToString("d", CultureInfo.CreateSpecificCulture("vi-VN"));

            string m_ngay_het_han = null;
            if (ngay_het_han != null)
                m_ngay_het_han = ngay_het_han.Value.ToString("d", CultureInfo.CreateSpecificCulture("vi-VN"));

            List<string> lstValue = new List<string>();
            List<Boolean> lstIsLeaf = new List<Boolean>();
            List<Boolean> lstIsRoot = new List<Boolean>();
            List<string> lstLeftNode = new List<string>();
            List<string> lstRightNode = new List<string>();

            if (p_define_cthuc == true)
            {
                ET.GetExpressionTreeData(ET.Infix2ExpressionTree(p_cthuc_value));
                lstValue = ET.lstValue;
                lstIsLeaf = ET.lstIsLeaf;
                lstIsRoot = ET.lstIsRoot;
                lstLeftNode = ET.lstLeftNode;
                lstRightNode = ET.lstRightNode;
            }
            else
            {
                lstValue = null;
                lstIsLeaf = null;
                lstIsRoot = null;
                lstLeftNode = null;
                lstRightNode = null;
            }

            IDataParameter[] paras = new IDataParameter[35]{
                new NpgsqlParameter("p_ma_quyet_dinh_old",p_ma_qd_old),
                new NpgsqlParameter("p_ma_quyet_dinh_new",ma_qd + "_" + ngay_hieu_luc.Value.ToString("ddMMyyyy")),
                new NpgsqlParameter("p_ten_quyet_dinh",ten_qd),
                new NpgsqlParameter("p_loai_qd",loai_qd_id),
                new NpgsqlParameter("p_ngay_ky", ngay_ky.Value),
                new NpgsqlParameter("p_ngay_hieu_luc",ngay_hieu_luc.Value),
                new NpgsqlParameter("p_ngay_het_han",m_ngay_het_han),
                new NpgsqlParameter("p_mo_ta",mota),
                new NpgsqlParameter("p_path",path),
                new NpgsqlParameter("p_tham_nien_nang_bac",p_tham_nien_nang_bac),
                new NpgsqlParameter("p_tham_nien_gd",p_tham_nien_gd),
                new NpgsqlParameter("p_define_cthuc",p_define_cthuc),
                new NpgsqlParameter("p_cthuc",p_cthuc),
                new NpgsqlParameter("p_cthuc",p_cthuc_value),
                new NpgsqlParameter("p_cthuc_phantram",p_cthuc_phantram),
                new NpgsqlParameter("p_khong_tinh_luong",p_khong_tinh_luong),
                new NpgsqlParameter("p_ma_nv",p_ma_nv),
                new NpgsqlParameter("p_ins_qtr_ctac",p_ins_qtr_ctac),
                new NpgsqlParameter("p_don_vi_id",p_don_vi_id),
                new NpgsqlParameter("p_chuc_vu_id",p_chuc_vu_id),
                new NpgsqlParameter("p_chuc_danh_id",p_chuc_danh_id),
                new NpgsqlParameter("p_co_phu_cap",p_co_phu_cap),
                new NpgsqlParameter("p_loai_phu_cap_id",p_loai_phu_cap_id),
                new NpgsqlParameter("p_value_khoan",p_value_khoan),
                new NpgsqlParameter("p_value_he_so",p_value_he_so),
                new NpgsqlParameter("p_value_phan_tram",p_value_phan_tram),
                new NpgsqlParameter("p_phan_tram_huong_pc",p_phan_tram_huong_pc),
                new NpgsqlParameter("p_tu_ngay_pc",p_tu_ngay_pc),
                new NpgsqlParameter("p_den_ngay_pc",p_den_ngay_pc),
                new NpgsqlParameter("p_ghi_chu_pc",p_ghi_chu_pc),
                new NpgsqlParameter("m_value",(lstValue == null) ? null : lstValue.ToArray()),
                new NpgsqlParameter("m_is_leaf",(lstValue == null) ? null :lstIsLeaf.ToArray()),
                new NpgsqlParameter("m_is_root",(lstValue == null) ? null :lstIsRoot.ToArray()),
                new NpgsqlParameter("m_left_node",(lstValue == null) ? null :lstLeftNode.ToArray()),
                new NpgsqlParameter("m_right_node",(lstValue == null) ? null :lstRightNode.ToArray())
            };
            try
            {
                dp.executeScalarProc("sp1_update_quyet_dinh_chung", paras);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(string[] p_ma_nv)
        {
            int check;
            IDataParameter[] paras = new IDataParameter[2]{
                new NpgsqlParameter("p_ma_quyet_dinh",ma_qd),
                new NpgsqlParameter("p_ma_nv",p_ma_nv)
            };
            check = (int)dp.executeScalarProc("sp1_delete_quyet_dinh_chung", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public DataTable Search_QD_Chung(string p_ma_qd)
        {
            DataTable dt;

            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_ma_qd",p_ma_qd)
            };

            dt = dp.getDataTableProc("sp1_select_qd_chung", paras);

            return dt;
        }

        public DataTable Search_QD_Chung_Detail(string p_ma_qd)
        {
            DataTable dt;

            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_ma_qd",p_ma_qd)
            };

            dt = dp.getDataTableProc("sp1_select_qd_chung_detail", paras);

            return dt;
        }
        #endregion
    }
}
