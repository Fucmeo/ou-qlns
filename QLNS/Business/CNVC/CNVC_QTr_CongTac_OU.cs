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
    public class CNVC_QTr_CongTac_OU
    {
        DataProvider.DataProvider dp;

        #region Init method

        public CNVC_QTr_CongTac_OU()
        {
            dp = new DataProvider.DataProvider();
        }
        

        #endregion

        #region Properties

        private int? id;

        public int? ID
        {
            get { return id; }
            set { id = value; }
        }

        private int? hopdongid;

        public int? HopDongID
        {
            get { return hopdongid; }
            set { hopdongid = value; }
        }

        private int? maquyetdinh;

        public int? MaQuyetDinh
        {
            get { return maquyetdinh; }
            set { maquyetdinh = value; }
        }

        private string manv;

        public string MaNV
        {
            get { return manv; }
            set { manv = value; }
        }

        private int? donviid;

        public int? DonViID
        {
            get { return donviid; }
            set { donviid = value; }
        }

        private int? chucdanhid;

        public int? ChucDanhID
        {
            get { return chucdanhid; }
            set { chucdanhid = value; }
        }

        private int? chucvuid;

        public int? ChucVuID
        {
            get { return chucvuid; }
            set { chucvuid = value; }
        }

        private DateTime? tuthoigian;

        public DateTime? TuThoiGian
        {
            get { return tuthoigian; }
            set { tuthoigian = value; }
        }

        private DateTime? denthoigian;

        public DateTime? DenThoiGian
        {
            get { return denthoigian; }
            set { denthoigian = value; }
        }

        private bool? tinhtrang;

        public bool? TinhTrang
        {
            get { return tinhtrang; }
            set { tinhtrang = value; }
        }

        #endregion

        #region Methods

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[9]{
                new NpgsqlParameter("hop_dong_id",hopdongid),
                new NpgsqlParameter("ma_quyet_dinh",maquyetdinh),
                new NpgsqlParameter("ma_nv",manv),
                new NpgsqlParameter("don_vi_id",donviid),
                new NpgsqlParameter("chuc_danh_id",chucdanhid),
                new NpgsqlParameter("chuc_vu_id",chucvuid),
                new NpgsqlParameter("tu_thoi_gian",tuthoigian),
                new NpgsqlParameter("den_thoi_gian",denthoigian),
                new NpgsqlParameter("tinh_trang",tinhtrang)
            };
            check = (int)dp.executeScalarProc("sp_insert_cnvc_qtr_ctac_ou", paras);
            if (check > 0)
            {
                return true;
            }
            else
                return false;
        }

        //public bool Update()
        //{
        //    int check;
        //    IDataParameter[] paras = new IDataParameter[10]{
        //        new NpgsqlParameter("id",id),
        //        new NpgsqlParameter("hop_dong_id",hopdongid),
        //        new NpgsqlParameter("ma_quyet_dinh",maquyetdinh),
        //        new NpgsqlParameter("ma_nv",manv),
        //        new NpgsqlParameter("don_vi_id",donviid),
        //        new NpgsqlParameter("chuc_danh_id",chucdanhid),
        //        new NpgsqlParameter("chuc_vu_id",chucvuid),
        //        new NpgsqlParameter("tu_thoi_gian",tuthoigian),
        //        new NpgsqlParameter("den_thoi_gian",denthoigian),
        //        new NpgsqlParameter("tinh_trang",tinhtrang)
        //    };
        //    check = (int)dp.executeScalarProc("sp_update_cnvc_qtr_ctac_ou", paras);
        //    if (check > 0)
        //    {
        //        return true;
        //    }
        //    else
        //        return false;
        //}

        public bool Update_MaNV(string ma_nv_old)
        {
            int check;
            IDataParameter[] paras = new IDataParameter[2]{
                new NpgsqlParameter("p_ma_nv_old",ma_nv_old),
                new NpgsqlParameter("p_ma_nv",manv)                
            };
            check = (int)dp.executeScalarProc("sp_update_cnvc_qtr_ctac_ou_temp", paras);
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
            check = (int)dp.executeScalarProc("sp_delete_cnvc_qtr_ctac_ou", paras);
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

            dt = dp.getDataTableProc("sp_select_trongou", paras);

            return dt;
        }

        public bool CheckLatestQtrCtac()
        {
            bool check;
            IDataParameter[] paras = new IDataParameter[1]{
                new NpgsqlParameter("p_id",id)                
            };
            check = (bool)dp.executeScalarProc("sp1_check_if_lastest_qtrctac", paras);

            return check;
        }

        public bool DeleteFromChart()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[2]{
                new NpgsqlParameter("p_id",id),
                new NpgsqlParameter("p_id",manv)
            };
            check = (int)dp.executeScalarProc("sp_delete_cnvc_qtr_ctac_ou_from_chart", paras);
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
