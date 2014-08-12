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
        DataTable dtCNVC;
        bool b_SearchQtrCtacOu = false;
        Business.CNVC.CNVC_QTr_CongTac_OU oQtrCtacOU;
        public DataTable dtDSQtrCTac;
        HDQD.UCs.DieuDong oDieuDong;

        public ThongTinCNVC()
        {
            InitializeComponent();
            oCNVC = new Business.CNVC.CNVC();
            dtCNVC = new DataTable();
        }

        public void Set_IsSearchQtrCtac(bool p_IsSearchQtrCtac, HDQD.UCs.DieuDong p_DieuDong)
        {
            oQtrCtacOU = new Business.CNVC.CNVC_QTr_CongTac_OU();
            oDieuDong = p_DieuDong;
            dtDSQtrCTac = new DataTable();
            b_SearchQtrCtacOu = p_IsSearchQtrCtac;
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {

            if (b_SearchQtrCtacOu == true && oQtrCtacOU != null)
            {
                try
                {
                    oQtrCtacOU.MaNV = txt_MaNV.Text;
                    dtDSQtrCTac = oQtrCtacOU.GetData();
                    oDieuDong.Fill_QtrCtacGridview(dtDSQtrCTac);

                    //if (dtDSQtrCTac.Rows.Count > 0)
                    //{
                    //    //fill data into Qtr Ctac gridview
                    //    oDieuDong.Fill_QtrCtacGridview(dtDSQtrCTac);
                    //}
                    //else
                    //{ 
                    //    //Not found data
                    //    MessageBox.Show("Không tìm thấy quá trình công tác cho nhân viên được chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra.\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //if (!string.IsNullOrWhiteSpace(txt_Ho.Text) && !string.IsNullOrWhiteSpace(txt_Ten.Text))
            //{
            //    oCNVC.Ho = txt_Ho.Text.Trim();
            //    oCNVC.Ten = txt_Ten.Text.Trim();
            //    oCNVC.MaNV = string.IsNullOrWhiteSpace(txt_MaNV.Text.Trim()) ? null : txt_MaNV.Text.Trim();
            //    strMaNV = null;
            //    DataTable dt;

            //    // neu dang o UC HopDong thi search nv - khong can quan tam qua trinh cong tac
            //    if (this.Parent.Parent.Name == "HopDong" || this.Parent.Parent.Name == "TiepNhan")
            //    {
            //        dt = oCNVC.SearchDataForQD(true);
            //    }
            //    else
            //    {
            //        dt = oCNVC.SearchDataForQD(false);
            //    }

            //    if (dt.Rows.Count > 0)
            //    {
            //        switch (this.Parent.Parent.Name)
            //        {
            //            case "BoNhiem":
            //                UCs.DSCNVC.eParentUC = DSCNVC.ParentUC.BoNhiem;
            //                break;
            //            case "QuyetDinhChung":
            //                UCs.DSCNVC.eParentUC = DSCNVC.ParentUC.QuyetDinhChung;
            //                break;
            //            case "ThoiBoNhiem":
            //                UCs.DSCNVC.eParentUC = DSCNVC.ParentUC.ThoiBoNhiem;
            //                break;
            //            case "HopDong":
            //                UCs.DSCNVC.eParentUC = DSCNVC.ParentUC.HopDong;
            //                break;
            //            case "TiepNhan":
            //                UCs.DSCNVC.eParentUC = DSCNVC.ParentUC.TiepNhan;
            //                break;

            //            default:
            //                break;
            //        }
            //        Forms.Popup frPopup = new Forms.Popup(new UCs.DSCNVC(dt), "QUẢN LÝ NHÂN SỰ - DANH SÁCH CNVC");
            //        frPopup.ShowDialog();
            //        if (strMaNV != null)
            //        {
                        
            //            txt_MaNV.Text = strMaNV;
            //            txt_Ho.Text = strHo;
            //            txt_Ten.Text = strTen;

            //            if ( UCs.DSCNVC.eParentUC != DSCNVC.ParentUC.HopDong 
            //                    && UCs.DSCNVC.eParentUC != DSCNVC.ParentUC.TiepNhan)
            //            {
            //                dtDonViChucVu = oCNVC.GetDonViChucVuForQD();

            //                if (dtDonViChucVu.Rows.Count > 0)
            //                {
            //                    // xu ly LINQ
            //                    var dsDonVi = (from dsDonViChucVu in dtDonViChucVu.AsEnumerable()
            //                                   select new
            //                                   {
            //                                       don_vi_id = dsDonViChucVu.Field<int>("don_vi_id"),
            //                                       ten_don_vi = dsDonViChucVu.Field<string>("ten_don_vi")
            //                                   }).Distinct();

            //                    comB_DonVi.DataSource = dsDonVi.ToList();
            //                    comB_DonVi.DisplayMember = "ten_don_vi";
            //                    comB_DonVi.ValueMember = "don_vi_id";
            //                    //comB_DonVi.Enabled = true;
            //                    comB_DonVi.SelectedIndex = 0;
            //                    GetValueForChucVuComb();
            //                }
            //                else
            //                {
            //                    MessageBox.Show("Nhân viên này khòng còn hợp đồng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                    comB_DonVi.Enabled = comB_ChucVu.Enabled = false;
            //                } 
            //            }
            //            else
            //            {
            //                comB_DonVi.Enabled = comB_ChucVu.Enabled = false;
            //            }

            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Nhân viên này khòng còn hợp đồng hoặc không tồn tại trong hệ thống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Xin vui lòng cung cấp họ và tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
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

        private void cb_HoTen_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void ThongTinCNVC_Load(object sender, EventArgs e)
        {
            try
            {
                dtCNVC =  oCNVC.GetAllCNVC();

                var source = new AutoCompleteStringCollection();
                var hoten = from row in dtCNVC.AsEnumerable()
                            select row.Field<string>("ho") + " " + row.Field<string>("ten")
                             + " - " + row.Field<string>("ma_nv");

                source.AddRange(hoten.ToArray());

                txt_HoTen.AutoCompleteCustomSource = source;
                txt_HoTen.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt_HoTen.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            catch (Exception)
            {
                
            }        
            
        }



        private void txt_HoTen_TextChanged(object sender, EventArgs e)
        {
            if (txt_HoTen.Text.Contains(" - "))
            {
                string t = txt_HoTen.Text;
                string ma_nv = t.Substring(t.IndexOf(" - "));
                txt_MaNV.Text = ma_nv.Remove(0,3);
                if ((from row in dtCNVC.AsEnumerable()
                     where row.Field<string>("ma_nv") == txt_MaNV.Text
                     select row.Field<string>("ho")).Count() > 0)
                {
                    string ho = (from row in dtCNVC.AsEnumerable()
                                 where row.Field<string>("ma_nv") == txt_MaNV.Text
                                 select row.Field<string>("ho")).First();
                    txt_Ho.Text = ho;
                }
                else txt_Ho.Text = "";

                if ((from row in dtCNVC.AsEnumerable()
                     where row.Field<string>("ma_nv") == txt_MaNV.Text
                     select row.Field<string>("ten")).Count() > 0)
                {
                    string ten = (from row in dtCNVC.AsEnumerable()
                                  where row.Field<string>("ma_nv") == txt_MaNV.Text
                                  select row.Field<string>("ten")).First();

                    txt_Ten.Text = ten;
                }
                else txt_Ten.Text = "";
                
            }
            else
            {
                txt_Ho.Text =  txt_Ten.Text =txt_MaNV.Text = "";
            }
        }
    }

    public class ComboBoxItem
    {
        public string Value;
        public string Text;

        public ComboBoxItem(string val, string text)
        {
            Value = val;
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
