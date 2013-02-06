using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business;

namespace HDQD.UCs
{
    public partial class ThongTinCNVC : UserControl
    {
        Business.CNVC.CNVC oCNVC;
        public static string strMaNV;
        public static string strHo, strTen;
        DataTable dtDonViChucVu;
        public ThongTinCNVC()
        {
            InitializeComponent();
            oCNVC = new Business.CNVC.CNVC();
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(txt_Ho.Text) && !string.IsNullOrWhiteSpace(txt_Ten.Text))
            {
                oCNVC.Ho = txt_Ho.Text.Trim();
                oCNVC.Ten = txt_Ten.Text.Trim();
                oCNVC.MaNV = string.IsNullOrWhiteSpace(txt_MaNV.Text.Trim()) ? null : txt_MaNV.Text.Trim();
                strMaNV = null;

                DataTable dt = oCNVC.SearchDataForQD();
                if (dt.Rows.Count > 0)
                {
                    switch (this.Parent.Parent.Name)
                    {
                        case "BoNhiem":
                            UCs.DSCNVC.eParentUC = DSCNVC.ParentUC.BoNhiem;
                            break;
                        case "QuyetDinhChung":
                            UCs.DSCNVC.eParentUC = DSCNVC.ParentUC.QuyetDinhChung;
                            break;
                        case "ThoiBoNhiem":
                            UCs.DSCNVC.eParentUC = DSCNVC.ParentUC.ThoiBoNhiem;
                            break;

                        default:
                            break;
                    }
                    Forms.Popup frPopup = new Forms.Popup(new UCs.DSCNVC(dt));
                    frPopup.ShowDialog();
                    if (strMaNV != null)
                    {
                        oCNVC.MaNV = strMaNV;
                        txt_MaNV.Text = strMaNV;
                        txt_Ho.Text = strHo;
                        txt_Ten.Text = strTen;

                        dtDonViChucVu = oCNVC.GetDonViChucVuForQD();

                        if (dtDonViChucVu.Rows.Count > 0)
                        {
                            // xu ly LINQ
                            var dsDonVi = (from dsDonViChucVu in dtDonViChucVu.AsEnumerable()
                                           select new
                                           {
                                               don_vi_id = dsDonViChucVu.Field<int>("don_vi_id"),
                                               ten_don_vi = dsDonViChucVu.Field<string>("ten_don_vi")
                                           }).Distinct();

                            comB_DonVi.DataSource = dsDonVi.ToList();
                            comB_DonVi.DisplayMember = "ten_don_vi";
                            comB_DonVi.ValueMember = "don_vi_id";
                            //comB_DonVi.Enabled = true;
                            comB_DonVi.SelectedIndex = 0;
                            GetValueForChucVuComb();
                        }
                        else
                        {
                            MessageBox.Show("Nhân viên này khòng còn hợp đồng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            comB_DonVi.Enabled = comB_ChucVu.Enabled = false;
                        }


                    }
                }
                else
                {
                    MessageBox.Show("Nhân viên này khòng còn hợp đồng hoặc không tồn tại trong hệ thống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Xin vui lòng cung cấp họ và tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void comB_DonVi_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetValueForChucVuComb();
        }

        private void GetValueForChucVuComb()
        {
            int i = Convert.ToInt32(comB_DonVi.SelectedValue);
            // xu ly LINQ
            var dsChucVu = (from dsDonViChucVu in dtDonViChucVu.AsEnumerable()
                            where dsDonViChucVu.Field<int>("don_vi_id") == i
                            select new
                            {
                                chuc_vu_id = dsDonViChucVu.Field<int>("chuc_vu_id"),
                                ten_chuc_vu = dsDonViChucVu.Field<string>("ten_chuc_vu")
                            });

            comB_ChucVu.DataSource = dsChucVu.ToList();
            comB_ChucVu.DisplayMember = "ten_chuc_vu";
            comB_ChucVu.ValueMember = "chuc_vu_id";
            //comB_ChucVu.Enabled = true;
        }
    }
}
