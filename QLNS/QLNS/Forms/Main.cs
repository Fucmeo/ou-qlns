﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HDQD;
using LuongBH;
using BaoCao;

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

             ApplyFont(this);
             ApplyFontForMenuStript();
            
             tsmi_TrangChu.Font = SystemFonts.MessageBoxFont;
        }

        void ApplyFont(Control c_root)
        {
            c_root.Font = SystemFonts.MessageBoxFont;
            if (c_root.HasChildren)
            {
                foreach (Control c in c_root.Controls)
                {
                    ApplyFont(c);
                }
            }
        }

        private void tableLP_Main_ControlAdded(object sender, ControlEventArgs e)
        {
            ApplyFont((Control)sender);
        }

        void ApplyFontForMenuStript() // apply font cho rieng menu script
        {
            menuStrip1.Font = SystemFonts.MessageBoxFont;
            if (menuStrip1.Items.Count > 0)
            {
                foreach (ToolStripMenuItem c in menuStrip1.Items)
                {
                    c.Font = SystemFonts.MessageBoxFont;
                }
            }
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
            tsmi_TaiLieuHD.Image = ImageL_MenuStripItem.Images["Document-Zoom-In.png"];
            tsmi_QLHD_DSHD.Image = ImageL_MenuStripItem.Images["Contract.png"];
            tsmi_QLHD_DSQD.Image = ImageL_MenuStripItem.Images["Decision.png"];
            tsmi_QLHD_ThemHD.Image = ImageL_MenuStripItem.Images["Contract Add.png"];            
            tsmi_QLHD_ThemQD.Image = ImageL_MenuStripItem.Images["Document-Add.png"];

            // QL doi tuong
            tsmi_MoHinhDaoTao.Image = ImageL_MenuStripItem.Images["Diagram.png"];
            tsmi_HinhThucDaoTao.Image = ImageL_MenuStripItem.Images["Graduate Hat.png"];
            tsmi_VanBangChinhQuy.Image = ImageL_MenuStripItem.Images["Degree.png"];
            tsmi_ThongTinPM.Image = ImageL_MenuStripItem.Images["About.png"];
            tsmi_ChucDanh.Image = ImageL_MenuStripItem.Images["Text Edit.png"];
            tsmi_ChucVu.Image = ImageL_MenuStripItem.Images["Handle With Care.png"];
            tsmi_DonVi.Image = ImageL_MenuStripItem.Images["Myspace.png"];

            tsmi_BacHeSo.Image = ImageL_MenuStripItem.Images["He so.png"];
            tsmi_NhomNgach.Image = ImageL_MenuStripItem.Images["Cap bac.png"];
            tsmi_TrinhDo.Image = ImageL_MenuStripItem.Images["Trinh do.png"];
            tsmi_LuongToiThieu.Image = ImageL_MenuStripItem.Images["Luong Toi Thieu.png"];
            tsmi_LoaiHD.Image = ImageL_MenuStripItem.Images["Contract Type.png"];
            
            quyếtĐịnhĐơnVịToolStripMenuItem.Image = ImageL_MenuStripItem.Images["don vi.png"];
            quyếtĐịnhCôngNhậnChứcDanhGiảngViênToolStripMenuItem.Image = ImageL_MenuStripItem.Images["Chuc danh GV.png"];
            quyếtĐịnhThôiViệcNghỉHưuToolStripMenuItem.Image = ImageL_MenuStripItem.Images["nghi huu.png"];
            tsmi_QLHD_ThaiSan.Image = ImageL_MenuStripItem.Images["thai san.png"];
            tsmi_LoaiPC.Image = ImageL_MenuStripItem.Images["Vietnamese-Dong.png"];
            qĐChungToolStripMenuItem.Image = ImageL_MenuStripItem.Images["Decision.png"];
            qĐKhenThưởngNângLươngChuyểnNgạchToolStripMenuItem.Image = ImageL_MenuStripItem.Images["khen thuong.png"];
            tsmi_LoaiQD.Image = ImageL_MenuStripItem.Images["Decision.png"];

            quáTrìnhCôngTácToolStripMenuItem.Image = ImageL_MenuStripItem.Images["Qtr Ctac.png"];
            thâmNiênNhânViênToolStripMenuItem.Image = ImageL_MenuStripItem.Images["Tham Nien.png"];
            biểuĐồToolStripMenuItem.Image = ImageL_MenuStripItem.Images["bieu do.png"];
            tậpTinToolStripMenuItem.Image = ImageL_MenuStripItem.Images["Quan Ly File.png"];

            thànhPhốQuốcGiaToolStripMenuItem.Image = ImageL_MenuStripItem.Images["don vi.png"];
            qĐĐiềuĐộngToolStripMenuItem.Image = ImageL_MenuStripItem.Images["Myspace.png"];
           
            
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
                this.Text = "QUẢN LÝ NHÂN SỰ - HIỂN THỊ THÔNG TIN";
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
                this.Text = "QUẢN LÝ NHÂN SỰ - TÌM KIẾM";
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
            
        }

        private void tsmi_QLHD_DSHD_Click(object sender, EventArgs e)
        {
            if (this.tableLP_Main.Controls[0].Name != "DanhSachHopDong")
            {
                HDQD.UCs.DanhSachHopDong uc = new HDQD.UCs.DanhSachHopDong();
                uc.Dock = DockStyle.Fill;
                UC = uc;
                this.tableLP_Main.Controls.Clear();
                this.tableLP_Main.Controls.Add(UC, 0, 0);
                this.Text = "QUẢN LÝ NHÂN SỰ - DANH SÁCH HỢP ĐỒNG";
            }
        }

        private void tsmi_QLHD_DSQD_Click(object sender, EventArgs e)
        {
            if (this.tableLP_Main.Controls[0].Name != "DanhSachQuyetDinh")
            {
                HDQD.UCs.DanhSachQuyetDinh uc = new HDQD.UCs.DanhSachQuyetDinh();
                uc.Dock = DockStyle.Fill;
                UC = uc;
                this.tableLP_Main.Controls.Clear();
                this.tableLP_Main.Controls.Add(UC, 0, 0);
                this.Text = "QUẢN LÝ NHÂN SỰ - DANH SÁCH QUYẾT ĐỊNH";
            }
        }

        private void tsmi_QLHD_KiemNhiem_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Quyết định Bổ nhiệm / Kiệm nhiệm / Điều động", new HDQD.UCs.DieuDong());
            f.WindowState = FormWindowState.Maximized;
            f.ShowDialog();
        }

        private void tsmi_QLHD_ThoiBoNhiem_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Quyết định Thôi nhiệm / Thôi Kiêm nhiệm / Thôi điều động", new HDQD.UCs.ThoiBoNhiem());
            f.WindowState = FormWindowState.Maximized;
            f.ShowDialog();
        }

        private void tsmi_QLHD_DoiThongTInDV_Click(object sender, EventArgs e)
        {
            
        }

        private void tsmi_QLHD_TachDV_Click(object sender, EventArgs e)
        {
            
        }

        private void tsmi_QLHD_QDChung_Click(object sender, EventArgs e)
        {
            
        }

        private void tsmi_QLHD_GopDV_Click(object sender, EventArgs e)
        {
            
        }


        private void Main_KeyUp(object sender, KeyEventArgs e)
        {
            if (UC.Name == "QLNS_HienThiThongTin" && e.Alt)
            {
                ComboBox combo_DanhMuc = new ComboBox();
                TableLayoutPanel TLP = (TableLayoutPanel)(UC.Controls["tableLP_HienThiThongTin"]);
                TableLayoutPanel TLP_tableLP_DanhMucThongTin = (TableLayoutPanel)TLP.Controls["tableLP_DanhMucThongTin"];
                GroupBox GP = (GroupBox)TLP_tableLP_DanhMucThongTin.Controls["groupBox1"];
                TableLayoutPanel TLP_DanhMuc = (TableLayoutPanel)GP.Controls["tableLP_DanhMuc"];
                combo_DanhMuc = (ComboBox)TLP_DanhMuc.Controls["comB_DanhMuc"];

                UCs.QLNS_HienThiThongTin.nPreDanhMucIndex = combo_DanhMuc.SelectedIndex;
                switch (e.KeyCode)
                {
                    case Keys.D1:
                        combo_DanhMuc.SelectedIndex = 0;
                        break;
                    case Keys.D2:
                        combo_DanhMuc.SelectedIndex = 1;
                        break;
                    case Keys.D3:
                        combo_DanhMuc.SelectedIndex = 2;
                        break;
                    case Keys.D4:
                        combo_DanhMuc.SelectedIndex = 3;
                        break;
                    case Keys.D5:
                        combo_DanhMuc.SelectedIndex = 4;
                        break;
                    case Keys.D6:
                        combo_DanhMuc.SelectedIndex = 5;
                        break;
                    case Keys.D7:
                        combo_DanhMuc.SelectedIndex = 6;
                        break;
                    case Keys.D8:
                        combo_DanhMuc.SelectedIndex = 7;
                        break;
                    case Keys.D9:
                        combo_DanhMuc.SelectedIndex = 8;
                        break;
                    case Keys.D0:
                        combo_DanhMuc.SelectedIndex = 9;
                        break;

                    default:
                        break;
                }
                ((QLNS.UCs.QLNS_HienThiThongTin)(UC)).ChangeDanhMuc();
            }
        }

        private void tsmi_TrinhDo_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Quản lý trình độ", new QLNS.UCs.QLNS_TrinhDo());
            //f.WindowState = FormWindowState.Maximized;
            f.ShowDialog();
        }

        private void tsmi_NhomNgach_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Quản lý ngạch / nhóm ngạch", new LuongBH.UCs.Luong.Ngach_NhomNgach());
            //f.WindowState = FormWindowState.Maximized;
            f.ShowDialog();
        }

        private void tsmi_BacHeSo_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Quản lý bậc / hệ số", new LuongBH.UCs.Luong.BacHeSo());
            //f.WindowState = FormWindowState.Maximized;
            f.ShowDialog();
        }

        private void tsmi_LuongToiThieu_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Quản lý lương tối thiểu", new LuongBH.UCs.Luong.LuongToiThieu());
            //f.WindowState = FormWindowState.Maximized;
            f.ShowDialog();
        }

        private void tsmi_QLHD_ThemHD_Click(object sender, EventArgs e)
        {
            
        }

        private void tsmi_LoaiHD_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Quản lý loại hợp đồng", new HDQD.UCs.LoaiHopDong());
            f.ShowDialog();
        }

        private void tsmi_QLHD_HDMoi_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Thêm hợp đồng mới", new HDQD.UCs.HopDong());
            f.ShowDialog();
        }

        private void tsmi_QLHD_TiepNhan_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Quyết định tiếp nhận", new HDQD.UCs.TiepNhan());
            f.ShowDialog();
        }

        private void tsmi_QLHD_GiaHan_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Gia hạn hợp đồng", new HDQD.UCs.HopDong());
            f.ShowDialog();
        }

        private void qĐChungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Quyết định chung", new HDQD.UCs.QDChung());
            f.WindowState = FormWindowState.Maximized;
            f.ShowDialog();
        }

        private void táchĐơnVịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Quyết định tách đơn vị", new HDQD.UCs.M_A(true));
            f.WindowState = FormWindowState.Maximized;
            f.ShowDialog();
        }

        private void gộpĐơnVịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Quyết định gộp đơn vị", new HDQD.UCs.M_A(false));
            f.WindowState = FormWindowState.Maximized;
            f.ShowDialog();
        }

        private void đổiThôngTinĐơnVịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Quyết định đổi thông tin đơn vị", new HDQD.UCs.DoiThongTinDV());
            f.WindowState = FormWindowState.Maximized;
            f.ShowDialog();
        }

        private void tsmi_LoaiPC_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Quản lý loại phụ cấp", new HDQD.UCs.LoaiPhuCap());
            //f.WindowState = FormWindowState.Maximized;
            f.ShowDialog();
        }

        private void tsmi_QLHD_ThaiSan_Click(object sender, EventArgs e)
        {

        }

        private void quyếtĐịnhThôiViệcNghỉHưuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void qĐDuHocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HDQD.UCs.QDChung uc = new HDQD.UCs.QDChung("Đi du học");
            //uc.thongTinQuyetDinh1.comB_Loai.DataSource = null;
            //uc.thongTinQuyetDinh1.comB_Loai.Items.Add("Đi du học");
            //uc.thongTinQuyetDinh1.comB_Loai.SelectedIndex = 0;
            Forms.Popup f = new Popup("Quyết định đi du học", uc);
            f.ShowDialog();
        }

        private void qĐNghỉThaiSảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HDQD.UCs.QDChung uc = new HDQD.UCs.QDChung("Nghỉ thai sản");
            //uc.thongTinQuyetDinh1.comB_Loai.DataSource = null;
            //uc.thongTinQuyetDinh1.comB_Loai.Items.Add("Nghỉ thai sản");
            //uc.thongTinQuyetDinh1.comB_Loai.SelectedIndex = 0;
            Forms.Popup f = new Popup("Quyết định nghỉ thai sản", uc);
            f.ShowDialog();
        }

        private void qĐNghỉKhôngLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HDQD.UCs.QDChung uc = new HDQD.UCs.QDChung("Nghỉ không lương");
            //uc.thongTinQuyetDinh1.comB_Loai.DataSource = null;
            //uc.thongTinQuyetDinh1.comB_Loai.Items.Add("Nghỉ không lương");
            //uc.thongTinQuyetDinh1.comB_Loai.SelectedIndex = 0;
            //uc.gb_ThongTinLuong.Enabled = false;
            Forms.Popup f = new Popup("Quyết định nghỉ không lương", uc);
            f.ShowDialog();
        }

        private void qĐDuLịchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HDQD.UCs.QDChung uc = new HDQD.UCs.QDChung("Đi du lịch");
            //uc.thongTinQuyetDinh1.comB_Loai.DataSource = null;
            //uc.thongTinQuyetDinh1.comB_Loai.Items.Add("Đi du lịch");
            //uc.thongTinQuyetDinh1.comB_Loai.SelectedIndex = 0;
            Forms.Popup f = new Popup("Quyết định đi du lịch", uc);
            f.ShowDialog();
        }

        private void qĐThôiViệcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HDQD.UCs.QDDungHopDong uc = new HDQD.UCs.QDDungHopDong();
            //uc.thongTinQuyetDinh1.comB_Loai.DataSource = null;
            //uc.thongTinQuyetDinh1.comB_Loai.Items.Add("Thôi việc");
            //uc.thongTinQuyetDinh1.comB_Loai.SelectedIndex = 0;
            Forms.Popup f = new Popup("Quyết định thôi việc", uc);
            f.ShowDialog();


            //MessageBox.Show("Hiện quyết định này đang trong quá trình phát triển.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void qĐNghỉHưuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HDQD.UCs.QDChung uc = new HDQD.UCs.QDChung("Nghỉ hưu");
            //uc.thongTinQuyetDinh1.comB_Loai.DataSource = null;
            //uc.thongTinQuyetDinh1.comB_Loai.Items.Add("Nghỉ hưu");
            //uc.thongTinQuyetDinh1.comB_Loai.SelectedIndex = 0;
            Forms.Popup f = new Popup("Quyết định nghỉ hưu", uc);
            f.ShowDialog();
        }

        private void thànhLậpĐơnVịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HDQD.UCs.ThanhLapDonVi uc = new HDQD.UCs.ThanhLapDonVi();
            Forms.Popup f = new Popup("Quyết định thành lập đơn vị", uc);
            f.ShowDialog();
        }

        private void tsmi_LoaiQD_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Quản lý loại quyết định", new HDQD.UCs.LoaiQuyetDinh());
            //f.WindowState = FormWindowState.Maximized;
            f.ShowDialog();
        }

        private void quáTrìnhCôngTácToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Quá trình công tác", new QLNS.UCs.QLNS_QTrCTac_Chart());

            f.ShowDialog();
        }

        private void thâmNiênNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Thâm niên nhân viên", new QLNS.UCs.QLNS_ThamNien());
            f.ShowDialog();
        }

        private void tậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Quản lý tập tin", new QLNS.UCs.QLNS_TapTin());
            f.ShowDialog();
        }


        private void lươngPhụCấpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Tính lương", new LuongBH.UCs.Luong.TinhLuong());
            f.ShowDialog();
        }

        private void ngàyCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Quản lý ngày công", new LuongBH.UCs.Luong.NgayCong());
            f.ShowDialog();
        }

        private void chấmCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Chấm công", new LuongBH.UCs.Luong.ChamCong());
            f.ShowDialog();
        }

        private void ngàyPhépToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Ngày phép", new LuongBH.UCs.Luong.NgayPhep());
            f.ShowDialog();
        }

        private void tableLP_Main_Paint(object sender, PaintEventArgs e)
        {

        }

        private void hợpĐồngChoĐơnVịCũToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Hợp đồng cho đơn vị cũ", new HDQD.UCs.HopDongCu());
            f.ShowDialog();
        }

        private void nhânViênTheoLoạiHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Báo cáo nhân viên theo loại hợp đồng", new BaoCao.UCs.NVTheo_LoaiHD());
            f.ShowDialog();
        }

        private void nhânViênTheoĐơnVịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Báo cáo nhân viên theo đơn vị", new BaoCao.UCs.NVTheo_DV());
            f.ShowDialog();
        }

        private void nhânViênTheoChứcDanhChúcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Báo cáo nhân viên theo chức danh - chức vụ", new BaoCao.UCs.NVTheo_CD_CV());
            f.ShowDialog();
        }

        private void thànhPhốQuốcGiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Quản lý thành phố - quốc gia", new QLNS.UCs.QLNS_QuocGiaTP());
            f.ShowDialog();
        }

        private void nhânViênHọcTậpTạiNướcNgoàiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Báo cáo nhân viên học tập tại nước ngoài", new BaoCao.UCs.NV_MoHinh_HinhThuc());
            f.ShowDialog();
        }

        private void qĐKhenThưởngNângLươngChuyểnNgạchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Quyết định nâng bậc nhanh", new HDQD.UCs.ChuyenNgachNhanh());
            f.WindowState = FormWindowState.Maximized;
            f.ShowDialog();
        }

        private void qĐĐiềuĐộngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Quyết định điều động", new HDQD.UCs.DieuDong());
            f.WindowState = FormWindowState.Maximized;
            f.ShowDialog();
        }

        private void qĐKhenThưởngChuyểnNgạchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Quyết định khen thưởng/chuyển ngạch", new HDQD.UCs.QDKhenThuong_ChuyenNgach());
            f.WindowState = FormWindowState.Maximized;
            f.ShowDialog();
        }

        private void bộNộiVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Báo cáo bộ nội vụ", new BaoCao.UCs.NV_BoNoiVu());
            //f.WindowState = FormWindowState.Maximized;
            f.ShowDialog();
        }

        private void qĐThôiKiêmNhiệmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Quyết định thôi kiêm nhiệm", new HDQD.UCs.QDThoiKiemNhiem());
            f.WindowState = FormWindowState.Maximized;
            f.ShowDialog();
        }

        private void qĐBổNhiệmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Popup f = new Popup("Quyết định bổ nhiệm nhiệm", new HDQD.UCs.QDBoNhiem());
            f.WindowState = FormWindowState.Maximized;
            f.ShowDialog();
        }

        
    }
}
