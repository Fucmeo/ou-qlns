using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.CNVC;

namespace QLNS.UCs.DanhMucThongTin
{
    public partial class QLNS_ThongTinNV_Phu : UserControl
    {
        public CNVC_ThongTinPhu oCNVC_ThongTinPhu;
        public DataTable dtCNVC_InfoPhu, dtQuocGia, dtTinhTP, dtTinhTrangHN;
        Business.TinhTP oTinhTP;
        Business.QuocGia oQuocGia;
        Business.TinhTrangHonNhan oTinhTrangHonNhan;

        public static int nNewTinhTPID = 0;     // ID cua tinh thanh pho moi them vao

        public QLNS_ThongTinNV_Phu()
        {
            InitializeComponent();
            oCNVC_ThongTinPhu = new CNVC_ThongTinPhu();
            dtCNVC_InfoPhu = new DataTable();
            dtTinhTP = new DataTable();
            dtTinhTrangHN = new DataTable();
            oTinhTP = new Business.TinhTP();
            oQuocGia = new Business.QuocGia();
            oTinhTrangHonNhan = new Business.TinhTrangHonNhan();
        }

        private void QLNS_ThongTinNV_Phu_Load(object sender, EventArgs e)
        {
            dtTinhTP = oTinhTP.GetData();
            dtTinhTrangHN = oTinhTrangHonNhan.GetData();
            dtQuocGia = oQuocGia.GetData();

            FillComboData();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {

        }

        private void GetUserInputDat()
        {
            oCNVC_ThongTinPhu.MaNV = Program.selected_ma_nv;
            oCNVC_ThongTinPhu.TenGoiKhac = txt_TenGoiKhac.Text ;
            oCNVC_ThongTinPhu.DanToc = txt_DanToc.Text ;
            oCNVC_ThongTinPhu.ChieuCao = txt_ChieuCao.Text ;
            oCNVC_ThongTinPhu.TonGiao = txt_TonGiao.Text ;
            oCNVC_ThongTinPhu.NhomMau = txt_NhomMau.Text ;
            oCNVC_ThongTinPhu.QueQuanXa = txt_QueXa.Text ;
            oCNVC_ThongTinPhu.QueQuanHuyen = txt_QueHuyen.Text ;
            oCNVC_ThongTinPhu.NoiSinhXa = txt_NoiSinhXa.Text ;
            oCNVC_ThongTinPhu.NoiSinhHuyen = txt_NoiSinhHuyen.Text ;
            oCNVC_ThongTinPhu.HoKhauThuongTruXa = txt_HoKhau_Xa.Text ;
            oCNVC_ThongTinPhu.HoKhauThuongChu_Huyen = txt_HoKhau_Quan.Text ;

            // comb
            if (Convert.ToInt32(comB_QuocTich.SelectedValue) < 0)
                oCNVC_ThongTinPhu.QuocTinh = null;
            else
                oCNVC_ThongTinPhu.QuocTinh = Convert.ToInt32(comB_QuocTich.SelectedValue);

            if (Convert.ToInt32(comB_TinhTrangHonNhan.SelectedValue) < 0)
                oCNVC_ThongTinPhu.TinhTrangHonNhan = null;
            else
                oCNVC_ThongTinPhu.TinhTrangHonNhan = Convert.ToInt32(comB_TinhTrangHonNhan.SelectedValue);

            if (Convert.ToInt32(comB_QueTinh.SelectedValue) < 0)
                oCNVC_ThongTinPhu.QueQuanTinh = null;
            else
                oCNVC_ThongTinPhu.QueQuanTinh = Convert.ToInt32(comB_QueTinh.SelectedValue);

            if (Convert.ToInt32(comB_NoiSinhTinh.SelectedValue) < 0)
                oCNVC_ThongTinPhu.NoiSinhTinh = null;
            else
                oCNVC_ThongTinPhu.NoiSinhTinh = Convert.ToInt32(comB_NoiSinhTinh.SelectedValue);

            if (Convert.ToInt32(comB_HoKhauTinh.SelectedValue) < 0)
                oCNVC_ThongTinPhu.HoKhauThuongChu_Tinh = null;
            else
                oCNVC_ThongTinPhu.HoKhauThuongChu_Tinh = Convert.ToInt32(comB_HoKhauTinh.SelectedValue);

        }

        public void GetCNVCInfo_Phu(string m_MaNV)
        {
            oCNVC_ThongTinPhu.MaNV = m_MaNV;
            dtCNVC_InfoPhu = oCNVC_ThongTinPhu.GetData();
        }

        public void FillInfo()
        {
            if (dtCNVC_InfoPhu.Rows.Count > 0)
            {
                txt_TenGoiKhac.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0]["ten_goi_khac"]);
                txt_DanToc.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0]["dan_toc"]);
                txt_ChieuCao.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0]["chieu_cao"]);
                txt_TonGiao.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0]["ton_giao"]);
                txt_NhomMau.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0]["nhom_mau"]);
                txt_QueXa.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0]["que_quan_xa"]);
                txt_QueHuyen.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0]["que_quan_huyen"]);
                txt_NoiSinhXa.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0]["noi_sinh_xa"]);
                txt_NoiSinhHuyen.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0]["noi_sinh_huyen"]);
                txt_HoKhau_Xa.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0]["hokhau_thuongtru_xa"]);
                txt_HoKhau_Quan.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0]["hokhau_thuongtru_huyen"]);

                if (dtCNVC_InfoPhu.Rows[0]["hokhau_thuongtru_tinh"].ToString() != "")
                    comB_HoKhauTinh.SelectedValue = Convert.ToInt32(dtCNVC_InfoPhu.Rows[0]["hokhau_thuongtru_tinh"]);                 else                                                        comB_HoKhauTinh.SelectedValue = -1;

                if (dtCNVC_InfoPhu.Rows[0]["quoc_tich"].ToString() != "")
                    comB_QuocTich.SelectedValue = Convert.ToInt32(dtCNVC_InfoPhu.Rows[0]["quoc_tich"]);                                               else                                                       comB_QuocTich.SelectedValue = -1;                                if (dtCNVC_InfoPhu.Rows[0][""].ToString() != "")                      comB_TinhTrangHonNhan.SelectedValue = Convert.ToInt32(dtCNVC_InfoPhu.Rows[0][""]);                      else                                                       comB_TinhTrangHonNhan.SelectedValue = -1;

                if (dtCNVC_InfoPhu.Rows[0]["ttr_hon_nhan_id"].ToString() != "")
                    comB_QueTinh.SelectedValue = Convert.ToInt32(dtCNVC_InfoPhu.Rows[0]["ttr_hon_nhan_id"]);                                           else                                                       comB_QueTinh.SelectedValue = -1;

                if (dtCNVC_InfoPhu.Rows[0]["noi_sinh_tinh"].ToString() != "")
                    comB_NoiSinhTinh.SelectedValue = Convert.ToInt32(dtCNVC_InfoPhu.Rows[0]["noi_sinh_tinh"]);            
                else                                   
                    comB_NoiSinhTinh.SelectedValue = -1;                



            }
        }

        public void FillComboData()
        {
            #region Tinh TP
            DataTable dt = dtTinhTP.Copy();
            if (dt.AsEnumerable().Where(a => a.Field<int>("id") == -1).Count() <= 0)
            {
                DataRow dr = dt.NewRow();
                dr["ten_tinh_tp"] = "";
                dr["id"] = -1;
                dr["quoc_gia_id"] = -1;
                dt.Rows.Add(dr);
            }

            comB_HoKhauTinh.DataSource = dt;
            comB_HoKhauTinh.DisplayMember = "ten_tinh_tp";
            comB_HoKhauTinh.ValueMember = "id";

            DataTable dt2 = dt.Copy();
            comB_NoiSinhTinh.DataSource = dt;
            comB_NoiSinhTinh.DisplayMember = "ten_tinh_tp";
            comB_NoiSinhTinh.ValueMember = "id";

            DataTable dt3 = dt.Copy();
            comB_QueTinh.DataSource = dt;
            comB_QueTinh.DisplayMember = "ten_tinh_tp";
            comB_QueTinh.ValueMember = "id"; 
            #endregion

            comB_QuocTich.DataSource = dtQuocGia;
            comB_QuocTich.DisplayMember = "ten_quoc_gia";
            comB_QuocTich.ValueMember = "id";

            comB_TinhTrangHonNhan.DataSource = dtTinhTrangHN;
            comB_TinhTrangHonNhan.DisplayMember = "ten";
            comB_TinhTrangHonNhan.ValueMember = "id";

        }


    }
}
