using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;

namespace LuongBH.UCs.Luong
{
    public partial class NghiPhep : UserControl
    {
        HDQD.UCs.ThongTinCNVC oThongTinCNVC;
        Business.Luong.NghiPhep oNghiPhep;

        DataTable dtLoaiNgayPhep;

        public NghiPhep()
        {
            InitializeComponent();
            oThongTinCNVC = new HDQD.UCs.ThongTinCNVC();
            oThongTinCNVC.Dock = DockStyle.Fill;

            oNghiPhep = new Business.Luong.NghiPhep();
            dtLoaiNgayPhep = new DataTable();
        }

        private void NgayPhep_Load(object sender, EventArgs e)
        {
            gb_TimKiem.Controls.Add(oThongTinCNVC);

            dtLoaiNgayPhep = oNghiPhep.GetLoaiNgayPhep();
            BindLoaiNgayPhepCbo();
        }

        #region Private Methods
        private int GetBusinessDays(DateTime start, DateTime end)
        {
            if (start.DayOfWeek == DayOfWeek.Saturday)
            {
                start = start.AddDays(2);
            }
            else if (start.DayOfWeek == DayOfWeek.Sunday)
            {
                start = start.AddDays(1);
            }

            if (end.DayOfWeek == DayOfWeek.Saturday)
            {
                end = end.AddDays(-1);
            }
            else if (end.DayOfWeek == DayOfWeek.Sunday)
            {
                end = end.AddDays(-2);
            }

            int diff = (int)end.Subtract(start).TotalDays + 1;

            int result = diff / 7 * 5 + diff % 7;

            if (end.DayOfWeek < start.DayOfWeek)
            {
                return result - 2;
            }
            else
            {
                return result;
            }
        }
        #endregion

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn thực sự muốn thêm ngày phép này ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (oThongTinCNVC.txt_MaNV.Text != "")
                {
                    oNghiPhep.Ma_NV = oThongTinCNVC.txt_MaNV.Text;
                    oNghiPhep.Loai_Ngay_Phep_ID = Convert.ToInt32(comB_LoaiNgayPhep.SelectedValue.ToString());
                    oNghiPhep.Tu_Ngay = dTP_TuNgay.Value;
                    oNghiPhep.Den_Ngay = dtp_DenNgay.Value;
                    oNghiPhep.So_Ngay = GetBusinessDays(oNghiPhep.Tu_Ngay, oNghiPhep.Den_Ngay);
                    oNghiPhep.Is_Ung_Truoc = false;
                    oNghiPhep.Ghi_Chu = rTB_GhiChu.Text;

                    try
                    {
                        if (oNghiPhep.Add())
                        {
                            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thao tác thêm thất bại.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Vui lòng chọn nhân viên để nhập ngày phép", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindLoaiNgayPhepCbo()
        {
            comB_LoaiNgayPhep.DataSource = dtLoaiNgayPhep;
            comB_LoaiNgayPhep.DisplayMember = "ten_loai_ngay_phep";
            comB_LoaiNgayPhep.ValueMember = "id_loai_ngay_phep";
        }
    }
}
