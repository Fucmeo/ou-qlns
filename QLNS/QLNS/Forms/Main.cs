﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HDQD;

namespace QLNS.Forms
{
    public partial class Main : Form
    {
        UserControl UC;
        public Main(UserControl _UC)
        {
            InitializeComponent();
            UC = _UC;
            UC.Dock = DockStyle.Fill;
            this.tableLP_Main.Controls.Add(UC, 0, 0);
        }

        private void Main_Load(object sender, EventArgs e)
         {
             LoadImageToMenuStrip();

        }

        private void LoadImageToMenuStrip()
        {
            // menu cap 1
            tsmi_TrangChu.Image = ImageL_MenuStrip.Images["Home.png"];
            tsmi_QLDD.Image = ImageL_MenuStrip.Images["Path.png"];
            tsmi_QLNS.Image = ImageL_MenuStrip.Images["Business card 1.png"];
            tsmi_QLHD.Image = ImageL_MenuStrip.Images["Documents.png"];
            tsmi_QLDT.Image = ImageL_MenuStrip.Images["Object.png"];
            tsmi_QLL.Image = ImageL_MenuStrip.Images["Cash.png"];
            tsmi_BaoCao.Image = ImageL_MenuStrip.Images["Report.png"];
            tsmi_ThongTinTK.Image = ImageL_MenuStrip.Images["Settings.png"];
            tsmi_GiupDo.Image = ImageL_MenuStrip.Images["Help.png"];

            // menu cap 2
            tsmi_QLNSHienThiThongTin.Image = ImageL_MenuStripItem.Images["User-Information2.png"];
            tsmi_QLNSTimKiem.Image = ImageL_MenuStripItem.Images["Business Man Find.png"];
            tsmi_ThongTin.Image = ImageL_MenuStripItem.Images["User-Information.png"];
            tsmi_DangXuat.Image = ImageL_MenuStripItem.Images["Logout.png"];
            tsmi_ThongTinPM.Image = ImageL_MenuStripItem.Images["About.png"];
            tsmi_TaiLieuHD.Image = ImageL_MenuStripItem.Images[""];

            // QL doi tuong
            tsmi_MoHinhDaoTao.Image = ImageL_MenuStripItem.Images["Diagram.png"];
            tsmi_HinhThucDaoTao.Image = ImageL_MenuStripItem.Images["Graduate Hat.png"];
            tsmi_VanBangChinhQuy.Image = ImageL_MenuStripItem.Images["Degree.png"];
            tsmi_ThongTinPM.Image = ImageL_MenuStripItem.Images["About.png"];
            tsmi_ChucDanh.Image = ImageL_MenuStripItem.Images["Text Edit.png"];
            tsmi_ChucVu.Image = ImageL_MenuStripItem.Images["Handle With Care.png"];
            tsmi_DonVi.Image = ImageL_MenuStripItem.Images["Myspace.png"];
            
        }

        private void tsmi_QLNSHienThiThongTin_Click(object sender, EventArgs e)
        {
            if (this.tableLP_Main.Controls[0].Name != "QLNS_HienThiThongTin")
            {
                UCs.QLNS_HienThiThongTin uc = new UCs.QLNS_HienThiThongTin();
                uc.Dock = DockStyle.Fill;
                UC = uc;
                this.tableLP_Main.Controls.Clear();
                this.tableLP_Main.Controls.Add(UC, 0, 0);
            }
            
        }

        private void tsmi_QLNSTimKiem_Click(object sender, EventArgs e)
        {
            if (this.tableLP_Main.Controls[0].Name != "QLNS_TimKiem")
            {
                UCs.QLNS_TimKiem uc = new UCs.QLNS_TimKiem();
                uc.Dock = DockStyle.Fill;
                UC = uc;
                this.tableLP_Main.Controls.Clear();
                this.tableLP_Main.Controls.Add(UC, 0, 0);
            }
        }

        private void tsmi_DonVi_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Quản lý đơn vị", new UCs.QLNS_DonVi());
            f.ShowDialog();
        }

        private void tsmi_ChucDanh_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Quản lý chức danh", new UCs.QLNS_ChucDanh());
            f.ShowDialog();
        }

        private void tsmi_ChucVu_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Quản lý chức vụ", new UCs.QLNS_ChucVu());
            f.ShowDialog();
        }

        private void tsmi_HinhThucDaoTao_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Quản lý hình thức đào tạo", new UCs.QLNS_HinhThucDaoTao());
            f.ShowDialog();
        }

        private void tsmi_MoHinhDaoTao_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Quản lý mô hình đào tạo", new UCs.MoHinhDaoTao());
            f.ShowDialog();
        }

        private void tsmi_TinhTP_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Quản lý tỉnh thành phố", new UCs.QLNS_DSTinh());
            f.ShowDialog();
        }

        private void tsmi_VanBangChinhQuy_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Quản lý văn bằng", new UCs.QLNS_VanBang());
            f.ShowDialog();
        }

        private void tsmi_QLHD_Click(object sender, EventArgs e)
        {
            if (this.tableLP_Main.Controls[0].Name != "HopDong")
            {
                //HDQD.UCs.HopDong ucHopDong = new HDQD.UCs.HopDong();
                //ucHopDong.Dock = DockStyle.Fill;
                //UC = ucHopDong;

                HDQD.UCs.BoNhiem ucBoNhiem = new HDQD.UCs.BoNhiem();
                ucBoNhiem.Dock = DockStyle.Fill;
                UC = ucBoNhiem;
                this.tableLP_Main.Controls.Clear();
                this.tableLP_Main.Controls.Add(UC, 0, 0);
            }
        }
    }
}
