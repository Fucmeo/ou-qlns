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
    public class CNVC_ChinhTri
    {
        DataProvider.DataProvider dp;

        #region Init method

        public CNVC_ChinhTri()
        {
            dp = new DataProvider.DataProvider();
        }

        #endregion

        
        #region Properties

        public string MaNV { get; set; }

        public int LoaiChinhTriID { get; set; }

        public string TenLoaiChinhTri { get; set; }

        #region CNVC_CHINH_TRI

        public string GiaDinhChinhSach { get; set; }
        public string KhenThuong { get; set; }
        public string KyLuat { get; set; }

        #endregion

        #region CNVC_CHINH_TRI_HCCB
        public string QuanHamCaoNhat { get; set; }
        public string DanhHieuCaoNhat { get; set; }
        public string ThuongBinhHang { get; set; }
        public DateTime? NgayNhapNgu { get; set; }
        public DateTime? NgayXuatNgu { get; set; }
        public bool ThamGiaChienDau { get; set; }
        public string CapKhenThuongNVQS { get; set; }
        #endregion

        #region CNVC_CHINH_TRI_LOAI_CT_BASIC
        public string[] NgayDuBi_1 { get; set; }
        public string[] NgayChinhThuc_1 { get; set; }
        public string[] NgayDuBi_2 { get; set; }
        public string[] NgayChinhThuc_2 { get; set; }
        public string[] NgayRa { get; set; }
        
        #endregion

        #region CNVC_CHINH_TRI_LCT_TO_CHUC
        public int ToChuc_ID { get; set; }
        public string TenToChuc { get; set; }
        public DateTime? BatDauSinhHoat { get; set; }
        public DateTime? KetThucSinhHoat { get; set; }
        public string GhiChu_ToChuc { get; set; }
        #endregion

        #endregion

        #region Method

        #region CNVC_CHINH_TRI
        public bool Save_Chinh_Tri_Info()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[4]{
                new NpgsqlParameter("p_ma_nv",MaNV), 
                new NpgsqlParameter("p_gia_dinh_chinh_sach",GiaDinhChinhSach), 
                new NpgsqlParameter("p_khen_thuong",KhenThuong), 
                new NpgsqlParameter("p_ky_luat",KyLuat)
            };
            check = (int)dp.executeScalarProc("sp_update_cnvc_chinh_tri", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public DataTable Get_Chinh_Tri_Info()
        {
            DataTable dt;

            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_ma_nv",MaNV)               
            };

            dt = dp.getDataTableProc("sp_select_cnvc_chinh_tri", paras);

            return dt;
        }
        #endregion

        #region CNVC_CHINH_TRI_HCCB
        public bool Save_Chinh_Tri_HCCB()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[8]{
                new NpgsqlParameter("p_ma_nv",MaNV), 
                new NpgsqlParameter("p_quan_ham_cao_nhat",QuanHamCaoNhat), 
                new NpgsqlParameter("p_danh_hieu_cao_nhat ",DanhHieuCaoNhat), 
                new NpgsqlParameter("p_thuong_binh_hang",ThuongBinhHang),
                new NpgsqlParameter("p_ngay_nhap_ngu",NgayNhapNgu),
                new NpgsqlParameter("p_ngay_xuat_ngu",NgayXuatNgu),
                new NpgsqlParameter("p_tham_gia_chien_dau",ThamGiaChienDau),
                new NpgsqlParameter("p_cap_khen_thuong_nvqs",CapKhenThuongNVQS)
            };
            check = (int)dp.executeScalarProc("sp_update_cnvc_chinh_tri_hccb", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public DataTable Get_Chinh_Tri_HCCB()
        {
            DataTable dt;

            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_ma_nv",MaNV)               
            };

            dt = dp.getDataTableProc("sp_select_cnvc_chinh_tri_hccb", paras);

            return dt;
        }
        #endregion

        #region CNVC_CHINH_TRI_LOAI_CT_BASIC
        public bool Save_Loai_Chinh_Tri_Basic(int[] p_loai_ctr)
        {
            int check;
            IDataParameter[] paras = new IDataParameter[7]{
                new NpgsqlParameter("p_ma_nv",MaNV), 
                new NpgsqlParameter("p_loai_ctr_id",p_loai_ctr), 
                new NpgsqlParameter("p_ngay_du_bi_1",NgayDuBi_1), 
                new NpgsqlParameter("p_ngay_chinh_thuc_1",NgayChinhThuc_1),
                new NpgsqlParameter("p_ngay_du_bi_2",NgayDuBi_2),
                new NpgsqlParameter("p_ngay_chinh_thuc_2",NgayChinhThuc_2),
                new NpgsqlParameter("p_ngay_ra",NgayRa)
            };
            check = (int)dp.executeScalarProc("sp_update_cnvc_chinh_tri_loai_ct_basic", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public DataTable Get_Loai_Ctr_Basic()
        {
            DataTable dt;

            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_ma_nv",MaNV)               
            };

            dt = dp.getDataTableProc("sp_select_cnvc_chinh_tri_loai_ct_basic", paras);

            return dt;
        }
        #endregion

        #region CNVC_CHINH_TRI_LCT_TO_CHUC
        public bool Add_To_Chuc()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[6]{
                new NpgsqlParameter("ma_nv",MaNV), 
                new NpgsqlParameter("loai_ctr_id",LoaiChinhTriID), 
                new NpgsqlParameter("ten_to_chuc",TenToChuc), 
                new NpgsqlParameter("tu_ngay",BatDauSinhHoat), 
                new NpgsqlParameter("den_ngay",KetThucSinhHoat), 
                new NpgsqlParameter("ghi_chu",GhiChu_ToChuc) 
            };
            check = (int)dp.executeScalarProc("sp_insert_cnvc_chinh_tri_lct_to_chuc", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool Update_To_Chuc()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[6]{
                new NpgsqlParameter("p_id",ToChuc_ID), 
                new NpgsqlParameter("loai_ctr_id",LoaiChinhTriID), 
                new NpgsqlParameter("ten_to_chuc",TenToChuc), 
                new NpgsqlParameter("tu_ngay",BatDauSinhHoat), 
                new NpgsqlParameter("den_ngay",KetThucSinhHoat), 
                new NpgsqlParameter("ghi_chu",GhiChu_ToChuc) 
            };
            check = (int)dp.executeScalarProc("sp_update_cnvc_chinh_tri_lct_to_chuc", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool Delete_To_Chuc()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_id",ToChuc_ID)
            };
            check = (int)dp.executeScalarProc("sp_delete_cnvc_chinh_tri_lct_to_chuc", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        public DataTable Get_Chinh_Tri_To_Chuc()
        {
            DataTable dt;

            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_ma_nv",MaNV)               
            };

            dt = dp.getDataTableProc("sp_select_cnvc_chinh_tri_lct_to_chuc", paras);

            return dt;
        }
        #endregion

        #endregion
    }
}
