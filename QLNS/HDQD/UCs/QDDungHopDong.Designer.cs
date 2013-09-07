namespace HDQD.UCs
{
    partial class QDDungHopDong
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QDDungHopDong));
            this.bw_download = new System.ComponentModel.BackgroundWorker();
            this.bw_upload = new System.ComponentModel.BackgroundWorker();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.TLP_QDDungHD = new System.Windows.Forms.TableLayoutPanel();
            this.TLP_ProgressBar = new System.Windows.Forms.TableLayoutPanel();
            this.pb_Status = new System.Windows.Forms.ProgressBar();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TLP_THongTinHD = new System.Windows.Forms.TableLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_ChucVu = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_ChucDanh = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_HoTenNV = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_MaNV_2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_DenNgay = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_TuNgay = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_NgayKy = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_LoaiHD = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_MaHD_2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TLP_ThongTinTimKiem = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_MaNV = new System.Windows.Forms.TextBox();
            this.btn_Tim = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_MaHD = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Ho = new System.Windows.Forms.TextBox();
            this.txt_Ten = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_NhapFile = new System.Windows.Forms.Button();
            this.btn_DeleteQD = new System.Windows.Forms.Button();
            this.btn_Them = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TLP_ThongTinQD = new System.Windows.Forms.TableLayoutPanel();
            this.thongTinQuyetDinh1 = new HDQD.UCs.ThongTinQuyetDinh();
            this.TLP_QDDungHD.SuspendLayout();
            this.TLP_ProgressBar.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.TLP_THongTinHD.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.TLP_ThongTinTimKiem.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.TLP_ThongTinQD.SuspendLayout();
            this.SuspendLayout();
            // 
            // bw_download
            // 
            this.bw_download.WorkerReportsProgress = true;
            // 
            // bw_upload
            // 
            this.bw_upload.WorkerReportsProgress = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Save.png");
            this.imageList1.Images.SetKeyName(1, "Document-Add.png");
            this.imageList1.Images.SetKeyName(2, "Remove Avatar.png");
            this.imageList1.Images.SetKeyName(3, "Add.png");
            this.imageList1.Images.SetKeyName(4, "Cancel.png");
            this.imageList1.Images.SetKeyName(5, "Business Man Find.png");
            // 
            // TLP_QDDungHD
            // 
            this.TLP_QDDungHD.ColumnCount = 1;
            this.TLP_QDDungHD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_QDDungHD.Controls.Add(this.TLP_ProgressBar, 0, 4);
            this.TLP_QDDungHD.Controls.Add(this.groupBox3, 0, 1);
            this.TLP_QDDungHD.Controls.Add(this.groupBox1, 0, 0);
            this.TLP_QDDungHD.Controls.Add(this.tableLayoutPanel4, 0, 3);
            this.TLP_QDDungHD.Controls.Add(this.groupBox2, 0, 2);
            this.TLP_QDDungHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_QDDungHD.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.TLP_QDDungHD.Location = new System.Drawing.Point(0, 0);
            this.TLP_QDDungHD.Name = "TLP_QDDungHD";
            this.TLP_QDDungHD.RowCount = 5;
            this.TLP_QDDungHD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.85714F));
            this.TLP_QDDungHD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.14286F));
            this.TLP_QDDungHD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.TLP_QDDungHD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.14286F));
            this.TLP_QDDungHD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.571429F));
            this.TLP_QDDungHD.Size = new System.Drawing.Size(1000, 700);
            this.TLP_QDDungHD.TabIndex = 0;
            // 
            // TLP_ProgressBar
            // 
            this.TLP_ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TLP_ProgressBar.ColumnCount = 2;
            this.TLP_ProgressBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.75453F));
            this.TLP_ProgressBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.24548F));
            this.TLP_ProgressBar.Controls.Add(this.pb_Status, 0, 0);
            this.TLP_ProgressBar.Controls.Add(this.lbl_Status, 1, 0);
            this.TLP_ProgressBar.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.TLP_ProgressBar.Location = new System.Drawing.Point(3, 662);
            this.TLP_ProgressBar.Name = "TLP_ProgressBar";
            this.TLP_ProgressBar.RowCount = 1;
            this.TLP_ProgressBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_ProgressBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_ProgressBar.Size = new System.Drawing.Size(994, 35);
            this.TLP_ProgressBar.TabIndex = 10;
            // 
            // pb_Status
            // 
            this.pb_Status.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pb_Status.Location = new System.Drawing.Point(3, 3);
            this.pb_Status.Name = "pb_Status";
            this.pb_Status.Size = new System.Drawing.Size(207, 20);
            this.pb_Status.TabIndex = 0;
            // 
            // lbl_Status
            // 
            this.lbl_Status.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.Location = new System.Drawing.Point(258, 8);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(0, 18);
            this.lbl_Status.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TLP_THongTinHD);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBox3.Location = new System.Drawing.Point(3, 170);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(994, 205);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin hợp đồng";
            // 
            // TLP_THongTinHD
            // 
            this.TLP_THongTinHD.ColumnCount = 6;
            this.TLP_THongTinHD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.05668F));
            this.TLP_THongTinHD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.1417F));
            this.TLP_THongTinHD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.85425F));
            this.TLP_THongTinHD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.34413F));
            this.TLP_THongTinHD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.8421F));
            this.TLP_THongTinHD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.16599F));
            this.TLP_THongTinHD.Controls.Add(this.label13, 4, 2);
            this.TLP_THongTinHD.Controls.Add(this.txt_ChucVu, 5, 2);
            this.TLP_THongTinHD.Controls.Add(this.label12, 2, 2);
            this.TLP_THongTinHD.Controls.Add(this.txt_ChucDanh, 3, 2);
            this.TLP_THongTinHD.Controls.Add(this.label11, 0, 2);
            this.TLP_THongTinHD.Controls.Add(this.txt_HoTenNV, 1, 2);
            this.TLP_THongTinHD.Controls.Add(this.label10, 4, 1);
            this.TLP_THongTinHD.Controls.Add(this.txt_MaNV_2, 5, 1);
            this.TLP_THongTinHD.Controls.Add(this.label9, 2, 1);
            this.TLP_THongTinHD.Controls.Add(this.txt_DenNgay, 3, 1);
            this.TLP_THongTinHD.Controls.Add(this.label8, 0, 1);
            this.TLP_THongTinHD.Controls.Add(this.txt_TuNgay, 1, 1);
            this.TLP_THongTinHD.Controls.Add(this.label7, 4, 0);
            this.TLP_THongTinHD.Controls.Add(this.txt_NgayKy, 5, 0);
            this.TLP_THongTinHD.Controls.Add(this.label6, 2, 0);
            this.TLP_THongTinHD.Controls.Add(this.txt_LoaiHD, 3, 0);
            this.TLP_THongTinHD.Controls.Add(this.label4, 0, 0);
            this.TLP_THongTinHD.Controls.Add(this.txt_MaHD_2, 1, 0);
            this.TLP_THongTinHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_THongTinHD.Enabled = false;
            this.TLP_THongTinHD.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TLP_THongTinHD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TLP_THongTinHD.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.TLP_THongTinHD.Location = new System.Drawing.Point(3, 20);
            this.TLP_THongTinHD.Name = "TLP_THongTinHD";
            this.TLP_THongTinHD.RowCount = 3;
            this.TLP_THongTinHD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLP_THongTinHD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLP_THongTinHD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLP_THongTinHD.Size = new System.Drawing.Size(988, 182);
            this.TLP_THongTinHD.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(684, 142);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 17);
            this.label13.TabIndex = 32;
            this.label13.Text = "Chức vụ";
            // 
            // txt_ChucVu
            // 
            this.txt_ChucVu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_ChucVu.Location = new System.Drawing.Point(771, 139);
            this.txt_ChucVu.Name = "txt_ChucVu";
            this.txt_ChucVu.Size = new System.Drawing.Size(214, 24);
            this.txt_ChucVu.TabIndex = 33;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(355, 142);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 17);
            this.label12.TabIndex = 30;
            this.label12.Text = "Chức danh";
            // 
            // txt_ChucDanh
            // 
            this.txt_ChucDanh.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_ChucDanh.Location = new System.Drawing.Point(455, 139);
            this.txt_ChucDanh.Name = "txt_ChucDanh";
            this.txt_ChucDanh.Size = new System.Drawing.Size(194, 24);
            this.txt_ChucDanh.TabIndex = 31;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(41, 142);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 17);
            this.label11.TabIndex = 28;
            this.label11.Text = "Họ tên";
            // 
            // txt_HoTenNV
            // 
            this.txt_HoTenNV.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_HoTenNV.Location = new System.Drawing.Point(131, 139);
            this.txt_HoTenNV.Name = "txt_HoTenNV";
            this.txt_HoTenNV.Size = new System.Drawing.Size(192, 24);
            this.txt_HoTenNV.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(668, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 17);
            this.label10.TabIndex = 26;
            this.label10.Text = "Mã nhân viên";
            // 
            // txt_MaNV_2
            // 
            this.txt_MaNV_2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_MaNV_2.Location = new System.Drawing.Point(771, 78);
            this.txt_MaNV_2.Name = "txt_MaNV_2";
            this.txt_MaNV_2.Size = new System.Drawing.Size(214, 24);
            this.txt_MaNV_2.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(358, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 17);
            this.label9.TabIndex = 24;
            this.label9.Text = "Đến ngày";
            // 
            // txt_DenNgay
            // 
            this.txt_DenNgay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_DenNgay.Location = new System.Drawing.Point(455, 78);
            this.txt_DenNgay.Name = "txt_DenNgay";
            this.txt_DenNgay.Size = new System.Drawing.Size(194, 24);
            this.txt_DenNgay.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "Từ ngày";
            // 
            // txt_TuNgay
            // 
            this.txt_TuNgay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_TuNgay.Location = new System.Drawing.Point(131, 78);
            this.txt_TuNgay.Name = "txt_TuNgay";
            this.txt_TuNgay.Size = new System.Drawing.Size(192, 24);
            this.txt_TuNgay.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(684, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "Ngày ký";
            // 
            // txt_NgayKy
            // 
            this.txt_NgayKy.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_NgayKy.Location = new System.Drawing.Point(771, 18);
            this.txt_NgayKy.Name = "txt_NgayKy";
            this.txt_NgayKy.Size = new System.Drawing.Size(214, 24);
            this.txt_NgayKy.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(345, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Loại hợp đồng";
            // 
            // txt_LoaiHD
            // 
            this.txt_LoaiHD.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_LoaiHD.Location = new System.Drawing.Point(455, 18);
            this.txt_LoaiHD.Name = "txt_LoaiHD";
            this.txt_LoaiHD.Size = new System.Drawing.Size(194, 24);
            this.txt_LoaiHD.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Mã Hợp đồng";
            // 
            // txt_MaHD_2
            // 
            this.txt_MaHD_2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_MaHD_2.Location = new System.Drawing.Point(131, 18);
            this.txt_MaHD_2.Name = "txt_MaHD_2";
            this.txt_MaHD_2.Size = new System.Drawing.Size(192, 24);
            this.txt_MaHD_2.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TLP_ThongTinTimKiem);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(994, 161);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin tìm kiếm";
            // 
            // TLP_ThongTinTimKiem
            // 
            this.TLP_ThongTinTimKiem.ColumnCount = 5;
            this.TLP_ThongTinTimKiem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.95547F));
            this.TLP_ThongTinTimKiem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.92308F));
            this.TLP_ThongTinTimKiem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.19433F));
            this.TLP_ThongTinTimKiem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.68421F));
            this.TLP_ThongTinTimKiem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLP_ThongTinTimKiem.Controls.Add(this.label3, 2, 0);
            this.TLP_ThongTinTimKiem.Controls.Add(this.txt_MaNV, 3, 0);
            this.TLP_ThongTinTimKiem.Controls.Add(this.btn_Tim, 4, 1);
            this.TLP_ThongTinTimKiem.Controls.Add(this.label1, 0, 0);
            this.TLP_ThongTinTimKiem.Controls.Add(this.txt_MaHD, 1, 0);
            this.TLP_ThongTinTimKiem.Controls.Add(this.label5, 0, 1);
            this.TLP_ThongTinTimKiem.Controls.Add(this.label2, 2, 1);
            this.TLP_ThongTinTimKiem.Controls.Add(this.txt_Ho, 1, 1);
            this.TLP_ThongTinTimKiem.Controls.Add(this.txt_Ten, 3, 1);
            this.TLP_ThongTinTimKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_ThongTinTimKiem.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TLP_ThongTinTimKiem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TLP_ThongTinTimKiem.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.TLP_ThongTinTimKiem.Location = new System.Drawing.Point(3, 20);
            this.TLP_ThongTinTimKiem.Name = "TLP_ThongTinTimKiem";
            this.TLP_ThongTinTimKiem.RowCount = 2;
            this.TLP_ThongTinTimKiem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_ThongTinTimKiem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_ThongTinTimKiem.Size = new System.Drawing.Size(988, 138);
            this.TLP_ThongTinTimKiem.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(432, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Mã nhân viên";
            // 
            // txt_MaNV
            // 
            this.txt_MaNV.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_MaNV.Location = new System.Drawing.Point(557, 22);
            this.txt_MaNV.Name = "txt_MaNV";
            this.txt_MaNV.Size = new System.Drawing.Size(228, 24);
            this.txt_MaNV.TabIndex = 19;
            // 
            // btn_Tim
            // 
            this.btn_Tim.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Tim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Tim.ImageKey = "Business Man Find.png";
            this.btn_Tim.ImageList = this.imageList1;
            this.btn_Tim.Location = new System.Drawing.Point(864, 80);
            this.btn_Tim.Name = "btn_Tim";
            this.btn_Tim.Size = new System.Drawing.Size(48, 47);
            this.btn_Tim.TabIndex = 17;
            this.btn_Tim.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Tim.UseVisualStyleBackColor = true;
            this.btn_Tim.Click += new System.EventHandler(this.btn_Tim_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Mã Hợp đồng";
            // 
            // txt_MaHD
            // 
            this.txt_MaHD.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_MaHD.Location = new System.Drawing.Point(131, 22);
            this.txt_MaHD.Name = "txt_MaHD";
            this.txt_MaHD.Size = new System.Drawing.Size(260, 24);
            this.txt_MaHD.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Họ";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(460, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Tên";
            // 
            // txt_Ho
            // 
            this.txt_Ho.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_Ho.Location = new System.Drawing.Point(131, 91);
            this.txt_Ho.Name = "txt_Ho";
            this.txt_Ho.Size = new System.Drawing.Size(260, 24);
            this.txt_Ho.TabIndex = 12;
            // 
            // txt_Ten
            // 
            this.txt_Ten.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_Ten.Location = new System.Drawing.Point(557, 91);
            this.txt_Ten.Name = "txt_Ten";
            this.txt_Ten.Size = new System.Drawing.Size(228, 24);
            this.txt_Ten.TabIndex = 13;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Controls.Add(this.btn_NhapFile, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btn_DeleteQD, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.btn_Them, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tableLayoutPanel4.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 591);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(994, 65);
            this.tableLayoutPanel4.TabIndex = 7;
            // 
            // btn_NhapFile
            // 
            this.btn_NhapFile.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_NhapFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_NhapFile.ImageKey = "Document-Add.png";
            this.btn_NhapFile.ImageList = this.imageList1;
            this.btn_NhapFile.Location = new System.Drawing.Point(272, 5);
            this.btn_NhapFile.Name = "btn_NhapFile";
            this.btn_NhapFile.Size = new System.Drawing.Size(56, 55);
            this.btn_NhapFile.TabIndex = 18;
            this.btn_NhapFile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_NhapFile.UseVisualStyleBackColor = true;
            // 
            // btn_DeleteQD
            // 
            this.btn_DeleteQD.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_DeleteQD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DeleteQD.ImageKey = "Remove Avatar.png";
            this.btn_DeleteQD.ImageList = this.imageList1;
            this.btn_DeleteQD.Location = new System.Drawing.Point(665, 5);
            this.btn_DeleteQD.Name = "btn_DeleteQD";
            this.btn_DeleteQD.Size = new System.Drawing.Size(56, 55);
            this.btn_DeleteQD.TabIndex = 17;
            this.btn_DeleteQD.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_DeleteQD.UseVisualStyleBackColor = true;
            // 
            // btn_Them
            // 
            this.btn_Them.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_Them.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Them.ImageKey = "Save.png";
            this.btn_Them.ImageList = this.imageList1;
            this.btn_Them.Location = new System.Drawing.Point(603, 5);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(56, 55);
            this.btn_Them.TabIndex = 16;
            this.btn_Them.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Them.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TLP_ThongTinQD);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBox2.Location = new System.Drawing.Point(3, 381);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(994, 204);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin quyết định";
            // 
            // TLP_ThongTinQD
            // 
            this.TLP_ThongTinQD.ColumnCount = 1;
            this.TLP_ThongTinQD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_ThongTinQD.Controls.Add(this.thongTinQuyetDinh1, 0, 0);
            this.TLP_ThongTinQD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_ThongTinQD.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TLP_ThongTinQD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TLP_ThongTinQD.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.TLP_ThongTinQD.Location = new System.Drawing.Point(3, 20);
            this.TLP_ThongTinQD.Name = "TLP_ThongTinQD";
            this.TLP_ThongTinQD.RowCount = 1;
            this.TLP_ThongTinQD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.17323F));
            this.TLP_ThongTinQD.Size = new System.Drawing.Size(988, 181);
            this.TLP_ThongTinQD.TabIndex = 0;
            // 
            // thongTinQuyetDinh1
            // 
            this.thongTinQuyetDinh1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.thongTinQuyetDinh1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thongTinQuyetDinh1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thongTinQuyetDinh1.Location = new System.Drawing.Point(3, 4);
            this.thongTinQuyetDinh1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.thongTinQuyetDinh1.Name = "thongTinQuyetDinh1";
            this.thongTinQuyetDinh1.Size = new System.Drawing.Size(982, 173);
            this.thongTinQuyetDinh1.TabIndex = 0;
            // 
            // QDDungHopDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.TLP_QDDungHD);
            this.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "QDDungHopDong";
            this.Size = new System.Drawing.Size(1000, 700);
            this.TLP_QDDungHD.ResumeLayout(false);
            this.TLP_ProgressBar.ResumeLayout(false);
            this.TLP_ProgressBar.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.TLP_THongTinHD.ResumeLayout(false);
            this.TLP_THongTinHD.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.TLP_ThongTinTimKiem.ResumeLayout(false);
            this.TLP_ThongTinTimKiem.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.TLP_ThongTinQD.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bw_download;
        private System.ComponentModel.BackgroundWorker bw_upload;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TableLayoutPanel TLP_QDDungHD;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel TLP_ThongTinQD;
        public ThongTinQuyetDinh thongTinQuyetDinh1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btn_NhapFile;
        private System.Windows.Forms.Button btn_DeleteQD;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel TLP_THongTinHD;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel TLP_ThongTinTimKiem;
        public System.Windows.Forms.TextBox txt_Ten;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txt_Ho;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txt_MaHD;
        private System.Windows.Forms.Button btn_Tim;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txt_MaNV;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox txt_ChucVu;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox txt_ChucDanh;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox txt_HoTenNV;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox txt_MaNV_2;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txt_DenNgay;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txt_TuNgay;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txt_NgayKy;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txt_LoaiHD;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txt_MaHD_2;
        private System.Windows.Forms.TableLayoutPanel TLP_ProgressBar;
        public System.Windows.Forms.ProgressBar pb_Status;
        public System.Windows.Forms.Label lbl_Status;
    }
}
