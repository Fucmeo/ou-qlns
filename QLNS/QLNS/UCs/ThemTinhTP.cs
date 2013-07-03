using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLNS.UCs
{
    public partial class ThemTinhTP : UserControl
    {
        Business.TinhTP oTinhTP ;
        Business.QuocGia oQuocGia;
        DataTable dtQuocGia;
        string UCCallerName;    // ten UC cha goi UC them tinh tp
        public ThemTinhTP()
        {
            InitializeComponent();
            oTinhTP = new Business.TinhTP();
            oQuocGia = new Business.QuocGia();
            dtQuocGia = new DataTable();
        }

        public ThemTinhTP(string m_Caller)
        {
            InitializeComponent();
            oTinhTP = new Business.TinhTP();
            oQuocGia = new Business.QuocGia();
            dtQuocGia = new DataTable();
            UCCallerName = m_Caller;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_Ten.Text))
            {
                oTinhTP.TenTinhTP = txt_Ten.Text;
                oTinhTP.MoTa = rTB_GhiChu.Text;
                if (Convert.ToInt32(comB_QuocGia.SelectedValue) != -1)
                    oTinhTP.QuocGiaID = Convert.ToInt32(comB_QuocGia.SelectedValue);
                else
                    oTinhTP.QuocGiaID = null;
                
                try
                {
                    int i = oTinhTP.AddWithReturnID();
                    MessageBox.Show("Thao tác thêm thành công.\r\n", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (i != 0) // them thanh cong
                    {
                        switch (UCCallerName)
                        {
                            case "QLNS_ThongTinNV":
                                QLNS.UCs.DanhMucThongTin.QLNS_ThongTinNV.nNewTinhTPID = i;
                                break;
                            case "QLNS_TrinhDo_ChuyenMon":
                                QLNS.UCs.DanhMucThongTin.QLNS_TrinhDo_ChuyenMon.nNewTinhTPID = i;
                                break;
                            case "QLNS_LichSuBanThan":
                                QLNS.UCs.DanhMucThongTin.QLNS_LichSuBanThan.nNewTinhTPID = i;
                                break;
                            case "QLNS_ThongTinNV_Phu":
                                QLNS.UCs.DanhMucThongTin.QLNS_ThongTinNV_Phu.nNewTinhTPID = i;
                                break;
                            case "QLNS_DaoTaoBoiDuong":
                                QLNS.UCs.DanhMucThongTin.QLNS_DaoTaoBoiDuong.nNewTinhTPID = i;
                                break;
                            default:
                                break;
                        }
                        ((Form)this.Parent.Parent).Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thao tác thêm không thành công.\r\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Xin vui lòng điền tên tỉnh thành phố.\r\n", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ThemTinhTP_Load(object sender, EventArgs e)
        {
            LoadQuocGiaData();
        }

        public void LoadQuocGiaData()
        {
            try
            {
                dtQuocGia = oQuocGia.GetData();
                //dtQuocGia = dtQuocGia.AsEnumerable().Where(a => a.Field<int>("id") != -1).CopyToDataTable();

                // comb
                comB_QuocGia.DataSource = dtQuocGia;
                comB_QuocGia.DisplayMember = "ten_quoc_gia";
                comB_QuocGia.ValueMember = "id";

                if (dtQuocGia.Rows.Count > 0)
                {
                    comB_QuocGia.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Chưa có quốc gia, xin vui lòng thêm quốc gia trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ((Form)this.Parent).Close();
                }
            }
            catch (Exception)
            {
                
            }
            

            
        }
    }
}
