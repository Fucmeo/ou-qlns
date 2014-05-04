using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Npgsql;
using DataProvider;

namespace Business.HDQD
{
    public class QDDiDuong
    {
        DataProvider.DataProvider dp;

        #region Init Methods
        public QDDiDuong()
        {
            dp = new DataProvider.DataProvider();
        }

        #endregion

        #region Properties
        public int id { get; set; }
        public string Ma_Quyet_Dinh { get; set; }
        public string Ma_NV { get; set; }
        public int CNVC_QD_ID { get; set; }
        public int? ChucVu_ID { get; set; }
        public string ChucVu { get; set; }
        public string NoiCongTac { get; set; }
        public string CongVanSo { get; set; }
        public DateTime? CongVanNgay { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public double TienLuong { get; set; }
        public double CongTacPhi { get; set; }
        public string GhiChu { get; set; }
        public string Path { get; set; }

        public int[] SEQ_ID { get; set; }
        public int[] PTDC_ID { get; set; }
        public string[] PTDC { get; set; }
        public int[] Di_Or_Den { get; set; } //0 == Di; 1 == Den
        public string[] DiaDiem { get; set; }
        public DateTime[] NgayKhoiHanh { get; set; }
        public double[] SoNgayCT { get; set; }
        public string[] LyDoLuuTru { get; set; }
        public string[] GhiChu_Detail { get; set; }

        #endregion

        #region Methods
        public DataTable GetList()
        {
            DataTable dt = new DataTable();

            dt = dp.getDataTable("select * from v_phuong_tien_di_chuyen");

            DataRow dr = dt.NewRow();
            //dr["loai_phuong_tien"] = "";
            //dr["id"] = -1;
            //dt.Rows.InsertAt(dr, 0);

            return dt;
        }

        public bool Add_Giay_Di_Duong()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[20]{
                new NpgsqlParameter("p_ma_quyet_dinh",Ma_Quyet_Dinh + "_" + TuNgay.ToString("ddMMyyyy")),
                new NpgsqlParameter("p_ma_nv",Ma_NV),
                new NpgsqlParameter("p_chuc_vu_id",ChucVu_ID),
                new NpgsqlParameter("p_noi_cong_tac",NoiCongTac),
                new NpgsqlParameter("p_ma_so_cong_van",CongVanSo),
                new NpgsqlParameter("p_ngay_cong_van",CongVanNgay),
                new NpgsqlParameter("p_tu_ngay",TuNgay),
                new NpgsqlParameter("p_den_ngay",DenNgay),
                new NpgsqlParameter("p_tien_luong",TienLuong),
                new NpgsqlParameter("p_cong_tac_phi",CongTacPhi),
                new NpgsqlParameter("p_ghi_chu",GhiChu),
                new NpgsqlParameter("p_path",Path),
                new NpgsqlParameter("p_seq_id",SEQ_ID),
                new NpgsqlParameter("p_ptdc_id",PTDC_ID),
                new NpgsqlParameter("p_di_or_den",Di_Or_Den),
                new NpgsqlParameter("p_dia_diem",DiaDiem),
                new NpgsqlParameter("p_ngay_khoi_hanh",NgayKhoiHanh),
                new NpgsqlParameter("p_so_ngay_cong_tac",SoNgayCT),
                new NpgsqlParameter("p_ly_do_luu_tru",LyDoLuuTru),
                new NpgsqlParameter("p_ghi_chu_detail",GhiChu_Detail)
            };
            check = (int)dp.executeScalarProc("sp3_insert_giay_di_duong", paras);
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
