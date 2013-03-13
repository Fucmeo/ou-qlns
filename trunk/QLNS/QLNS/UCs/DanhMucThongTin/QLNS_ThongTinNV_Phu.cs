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
        public DataTable dtCNVC_InfoPhu, dtQuocGia, dtTinhTP;
        Business.TinhTP oTinhTP;
        Business.QuocGia oQuocGia;

        public static int nNewTinhTPID = 0;     // ID cua tinh thanh pho moi them vao

        public QLNS_ThongTinNV_Phu()
        {
            InitializeComponent();
            oCNVC_ThongTinPhu = new CNVC_ThongTinPhu();
            dtCNVC_InfoPhu = new DataTable();
            dtTinhTP = new DataTable();
            oTinhTP = new Business.TinhTP();
        }

        private void QLNS_ThongTinNV_Phu_Load(object sender, EventArgs e)
        {
            dtTinhTP = oTinhTP.GetData();
            if (dtTinhTP != null && dtTinhTP.Rows.Count > 0)
            {
                LoadTinhData(dtTinhTP);    
            }

            dtQuocGia = oQuocGia.GetData();
            
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {

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
                txt_TenGoiKhac.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0][""]);
                txt_DanToc.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0][""]);
                txt_ChieuCao.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0][""]);
                txt_TonGiao.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0][""]);
                txt_NhomMau.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0][""]);
                txt_QueXa.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0][""]);
                txt_QueHuyen.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0][""]);
                txt_NoiSinhXa.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0][""]);
                txt_NoiSinhHuyen.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0][""]);
                txt_HoKhau_Xa.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0][""]);
                txt_HoKhau_Quan.Text = Convert.ToString(dtCNVC_InfoPhu.Rows[0][""]);


            }
        }

        public void LoadTinhData(DataTable _dt)
        {
            DataTable dt = _dt.Copy();
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

        }


    }
}
