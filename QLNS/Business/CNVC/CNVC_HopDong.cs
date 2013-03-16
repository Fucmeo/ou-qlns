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
    public class CNVC_HopDong
    {
        DataProvider.DataProvider dp;

        #region Init method

        public CNVC_HopDong()
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

        private string manv;

        public string MaNV
        {
            get { return manv; }
            set { manv = value; }
        }

        private int? maloaihd;

        public int? MaLoaiHD
        {
            get { return maloaihd; }
            set { maloaihd = value; }
        }

        private bool? thuviec_chinhthuc;

        public bool? ThuViec_ChinhThuc
        {
            get { return thuviec_chinhthuc; }
            set { thuviec_chinhthuc = value; }
        }

        private DateTime? ngayky;

        public DateTime? NgayKy
        {
            get { return ngayky; }
            set { ngayky = value; }
        }

        private DateTime? ngayhieuluc;

        public DateTime? NgayHieuLuc
        {
            get { return ngayhieuluc; }
            set { ngayhieuluc = value; }
        }

        private int? thoihan;

        public int? ThoiHan
        {
            get { return thoihan; }
            set { thoihan = value; }
        }

        private string donvithoigian;

        public string DonViThoiGian
        {
            get { return donvithoigian; }
            set { donvithoigian = value; }
        }

        private DateTime? ngayhethan;

        public DateTime? NgayHetHan
        {
            get { return ngayhethan; }
            set { ngayhethan = value; }
        }

        private string cnvcphutrach;

        public string CNVCPhuTrach
        {
            get { return cnvcphutrach; }
            set { cnvcphutrach = value; }
        }

        private int? chucvuchinhid;

        public int? ChucVuChinhID
        {
            get { return chucvuchinhid; }
            set { chucvuchinhid = value; }
        }

        private int? donvichinhid;

        public int? DonViChinhID
        {
            get { return donvichinhid; }
            set { donvichinhid = value; }
        }

        private bool? tinhtrang;

        public bool? TrinhTrang
        {
            get { return tinhtrang; }
            set { tinhtrang = value; }
        }

        private string ghichu;

        public string GhiChu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }

        #endregion

        #region Methods

        public bool Add()
        {
            int check;
            IDataParameter[] paras = new IDataParameter[13]{
                new NpgsqlParameter("ma_nv",manv),
                new NpgsqlParameter("ma_loai_hd",maloaihd),
                new NpgsqlParameter("thuviec_chinhthuc",thuviec_chinhthuc),
                new NpgsqlParameter("ngay_ky",ngayky),
                new NpgsqlParameter("ngay_hieu_luc",ngayhieuluc),
                new NpgsqlParameter("thoi_han",thoihan),
                new NpgsqlParameter("don_vi_thoi_gian",donvithoigian),
                new NpgsqlParameter("ngay_het_han",ngayhethan),
                new NpgsqlParameter("cnvc_phu_trach",cnvcphutrach),
                new NpgsqlParameter("chuc_vu_chinh_id",chucvuchinhid),
                new NpgsqlParameter("don_vi_chinh_id",donvichinhid),
                new NpgsqlParameter("tinh_trang",tinhtrang),
                new NpgsqlParameter("ghi_chu",ghichu)
            };
            check = (int)dp.executeScalarProc("sp_insert_cnvc_hop_dong", paras);
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
            IDataParameter[] paras = new IDataParameter[14]{
                new NpgsqlParameter("id",id),
                new NpgsqlParameter("ma_nv",manv),
                new NpgsqlParameter("ma_loai_hd",maloaihd),
                new NpgsqlParameter("thuviec_chinhthuc",thuviec_chinhthuc),
                new NpgsqlParameter("ngay_ky",ngayky),
                new NpgsqlParameter("ngay_hieu_luc",ngayhieuluc),
                new NpgsqlParameter("thoi_han",thoihan),
                new NpgsqlParameter("don_vi_thoi_gian",donvithoigian),
                new NpgsqlParameter("ngay_het_han",ngayhethan),
                new NpgsqlParameter("cnvc_phu_trach",cnvcphutrach),
                new NpgsqlParameter("chuc_vu_chinh_id",chucvuchinhid),
                new NpgsqlParameter("don_vi_chinh_id",donvichinhid),
                new NpgsqlParameter("tinh_trang",tinhtrang),
                new NpgsqlParameter("ghi_chu",ghichu)
            };
            check = (int)dp.executeScalarProc("sp_update_cnvc_hop_dong", paras);
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
            check = (int)dp.executeScalarProc("sp_delete_cnvc_hop_dong", paras);
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

            dt = dp.getDataTableProc("sp_select_cnvc_hop_dong", paras);

            return dt;
        }

        #endregion
    }
}
