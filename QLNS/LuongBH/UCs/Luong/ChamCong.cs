using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LuongBH.UCs.Luong
{
    public partial class ChamCong : UserControl
    {
        HDQD.UCs.ThongTinCNVC oThongTinCNVC;
        DataTable dtNgayNghi , dtLoaiNgayPhep;
        Business.Luong.ChamCong oChamCong;
        Business.Luong.LoaiNgayPhep oLoaiNgayPhep;
        public ChamCong()
        {
            InitializeComponent();
            oThongTinCNVC = new HDQD.UCs.ThongTinCNVC();
            dtNgayNghi = new DataTable();
            oChamCong = new Business.Luong.ChamCong();
            oLoaiNgayPhep = new Business.Luong.LoaiNgayPhep();


            oThongTinCNVC.btn_Tim.Click += new EventHandler(btn_Tim_Click);
            oThongTinCNVC.Dock = DockStyle.Fill;
        }

        void btn_Tim_Click(object sender, EventArgs e)
        {

            GetAndBindMonthCalendar();
        }

        private void GetAndBindMonthCalendar()
        {
            try
            {
                monthCalendar1.Dates.Clear();
                dtNgayNghi = oChamCong.GetNgayNghiByNV(oThongTinCNVC.txt_MaNV.Text);
                if (dtNgayNghi.Rows.Count>0)
                {
                    foreach (DataRow r in dtNgayNghi.Rows)
                    {
                        DateTime tu_ngay = Convert.ToDateTime(r["tu_ngay"]);
                        int n = (Convert.ToDateTime(r["den_ngay"]).Date.Subtract(tu_ngay)).Days;

                        Pabo.Calendar.DateItem[] di = new Pabo.Calendar.DateItem[n + 1];

                        for (int i = 0; i < n + 1; i++)
                        {
                            di[i] = new Pabo.Calendar.DateItem();
                            di[i].Date = tu_ngay.AddDays(i);
                            di[i].BackColor1 = Color.IndianRed;
                            di[i].BoldedDate = true;
                        }
                        monthCalendar1.AddDateInfo(di);
                    }

                    if (dtNgayNghi.Rows.Count > 0)
                    {
                        var dt = (from row in dtNgayNghi.AsEnumerable()
                                  select row.Field<DateTime>("tu_ngay")).Max();

                        monthCalendar1.SelectDate(Convert.ToDateTime(dt));
                    }

                    UIControls(true);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin ngày nghỉ của nhân viên " + oThongTinCNVC.txt_HoTen.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch (Exception)
            {


            }
        }

        private void ChamCong_Load(object sender, EventArgs e)
        {
            gb_TimKiem.Controls.Add(oThongTinCNVC);

            GetandBindLoaiNP();
        }

        private void GetandBindLoaiNP()
        {
            try
            {
                dtLoaiNgayPhep = oLoaiNgayPhep.GetData();
                cb_LoaiNgayPhep.DataSource = dtLoaiNgayPhep;
                cb_LoaiNgayPhep.DisplayMember = "ten";
                cb_LoaiNgayPhep.ValueMember = "id";
            }
            catch (Exception)
            {
                
            }
        }

        private void monthCalendar1_DayClick(object sender, Pabo.Calendar.DayClickEventArgs e)
        {
            int n = (from r in dtNgayNghi.AsEnumerable()
                     where r.Field<DateTime>("tu_ngay")<= Convert.ToDateTime(e.Date) && r.Field<DateTime>("den_ngay") >= Convert.ToDateTime(e.Date)
                     select r.Field<string>("ghi_chu")).Count();

            if (n >0)
            {
                var ghichu = (from r in dtNgayNghi.AsEnumerable()
                              where r.Field<DateTime>("tu_ngay") <= Convert.ToDateTime(e.Date) && r.Field<DateTime>("den_ngay") >= Convert.ToDateTime(e.Date)
                              select r.Field<string>("ghi_chu")).First();

                var loainpid = (from r in dtNgayNghi.AsEnumerable()
                                where r.Field<DateTime>("tu_ngay") <= Convert.ToDateTime(e.Date) && r.Field<DateTime>("den_ngay") >= Convert.ToDateTime(e.Date)
                                select r.Field<int>("loai_ngay_phep_id")).First();
                var tungay = (from r in dtNgayNghi.AsEnumerable()
                              where r.Field<DateTime>("tu_ngay") <= Convert.ToDateTime(e.Date) && r.Field<DateTime>("den_ngay") >= Convert.ToDateTime(e.Date)
                              select r.Field<DateTime>("tu_ngay")).First();

                var denngay = (from r in dtNgayNghi.AsEnumerable()
                               where r.Field<DateTime>("tu_ngay") <= Convert.ToDateTime(e.Date) && r.Field<DateTime>("den_ngay") >= Convert.ToDateTime(e.Date)
                               select r.Field<DateTime>("den_ngay")).First();
                var isungtruoc = (from r in dtNgayNghi.AsEnumerable()
                                  where r.Field<DateTime>("tu_ngay") <= Convert.ToDateTime(e.Date) && r.Field<DateTime>("den_ngay") >= Convert.ToDateTime(e.Date)
                                  select r.Field<Boolean>("is_ung_truoc")).First();


                dtp_TuNGay.Value = Convert.ToDateTime(tungay);
                dtp_DenNgay.Value = Convert.ToDateTime(denngay);
                cb_LoaiNgayPhep.SelectedValue = Convert.ToInt16(loainpid);
                cb_UngNP.Checked = Convert.ToBoolean(isungtruoc);
                rTB_GhiChu.Text = ghichu.ToString();
            }
            else
            {
                rTB_GhiChu.Text = "";
                cb_UngNP.Checked = false;
            }
            
           
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            UIControls(false);
            ClearInfo();
        }

        private void ClearInfo()
        {
            rTB_GhiChu.Text = "";
            cb_UngNP.Checked = false;
        }

        private void UIControls(bool init)
        {
            btn_Them.Visible = btn_Xoa.Visible = init;
            btn_Huy.Visible = btn_Luu.Visible = !init;

            cb_LoaiNgayPhep.Enabled = cb_UngNP.Enabled = dtp_DenNgay.Enabled = dtp_TuNGay.Enabled = rTB_GhiChu.Enabled = !init;
            monthCalendar1.Enabled = oThongTinCNVC.Enabled = init;

        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thêm ngày nghỉ cho nhân viên " + oThongTinCNVC.txt_MaNV.Text, "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                oChamCong.LoaiNgayPhepID = Convert.ToInt16(cb_LoaiNgayPhep.SelectedValue);
                oChamCong.TuNgay = dtp_TuNGay.Value;
                oChamCong.DenNgay = dtp_DenNgay.Value;
                oChamCong.IsUngTruoc = cb_UngNP.Checked;
                oChamCong.GhiChu = rTB_GhiChu.Text;

                try
                {
                    oChamCong.Add(oThongTinCNVC.txt_MaNV.Text);
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UIControls(true);
                    GetAndBindMonthCalendar();
                }
                catch (Exception)
                {
                    MessageBox.Show("Thêm không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        private void dtp_TuNGay_ValueChanged(object sender, EventArgs e)
        {
            dtp_DenNgay.Value = dtp_TuNGay.Value;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (monthCalendar1.SelectedDates.Count > 0 && IsNgayPhep(monthCalendar1.SelectedDates))
            {

                if (MessageBox.Show("Bạn muốn xoá ngày nghỉ phép cho nhân viên " + oThongTinCNVC.txt_MaNV.Text + " ?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        Pabo.Calendar.SelectedDatesCollection c = new Pabo.Calendar.SelectedDatesCollection(monthCalendar1);
                        c = monthCalendar1.SelectedDates;
                        List<string> delDates = new List<string>();
                        for (int i = 0; i < c.Count; i++)
                        {
                            Pabo.Calendar.DateItem[] dt = monthCalendar1.GetDateInfo(c[i]);
                            if (dt.Count() > 0 && dt[0].BackColor1 == Color.IndianRed)
                                delDates.Add(dt[0].Date.ToShortDateString());
                        }
                        oChamCong.Delete(oThongTinCNVC.txt_MaNV.Text, delDates.ToArray());
                        GetAndBindMonthCalendar();
                        MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Xoá không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            
        }

        // kiem tra xem co ngay nghi phep trong cac ngay chon tren calendar o ?
        private bool IsNgayPhep(Pabo.Calendar.SelectedDatesCollection c)
        {
            for (int i = 0; i < c.Count; i++)
            {
                Pabo.Calendar.DateItem[] dt = monthCalendar1.GetDateInfo(c[i]);
                if(dt.Count() >0 && dt[0].BackColor1== Color.IndianRed)
                    return true;
            }

            return false;
        }
    }
}
