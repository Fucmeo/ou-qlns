namespace HDQD.UCs
{
    partial class ChuyenNgachNhanh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChuyenNgachNhanh));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bw_upload = new System.ComponentModel.BackgroundWorker();
            this.TLP_KhenThuong_ChuyenNgach = new System.Windows.Forms.TableLayoutPanel();
            this.thongTinCNVC1 = new HDQD.UCs.ThongTinCNVC();
            this.thongTinQuyetDinh1 = new HDQD.UCs.ThongTinQuyetDinh();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pb_Status = new System.Windows.Forms.ProgressBar();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.btn_Them = new System.Windows.Forms.Button();
            this.btn_NhapFile = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Edit_Luong = new System.Windows.Forms.Button();
            this.btn_Del_Luong = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dtp_NgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.comb_NgachMoi = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_HeSoMoi = new System.Windows.Forms.TextBox();
            this.comb_BacMoi = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dtp_NgayCu = new System.Windows.Forms.DateTimePicker();
            this.txt_DV = new System.Windows.Forms.TextBox();
            this.lbl_SoTien = new System.Windows.Forms.Label();
            this.txt_CV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_NgachCu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_BacCu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_HeSoCu = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_DelNV = new System.Windows.Forms.Button();
            this.lb_DSCNVC = new System.Windows.Forms.ListBox();
            this.TLP_KhenThuong_ChuyenNgach.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Add.png");
            this.imageList1.Images.SetKeyName(1, "Cancel.png");
            this.imageList1.Images.SetKeyName(2, "Edit Data.png");
            this.imageList1.Images.SetKeyName(3, "Garbage.png");
            this.imageList1.Images.SetKeyName(4, "Save.png");
            this.imageList1.Images.SetKeyName(5, "Document-Add.png");
            // 
            // bw_upload
            // 
            this.bw_upload.WorkerReportsProgress = true;
            this.bw_upload.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_upload_DoWork);
            this.bw_upload.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_upload_ProgressChanged);
            this.bw_upload.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_upload_RunWorkerCompleted);
            // 
            // TLP_KhenThuong_ChuyenNgach
            // 
            this.TLP_KhenThuong_ChuyenNgach.ColumnCount = 1;
            this.TLP_KhenThuong_ChuyenNgach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_KhenThuong_ChuyenNgach.Controls.Add(this.thongTinCNVC1, 0, 0);
            this.TLP_KhenThuong_ChuyenNgach.Controls.Add(this.thongTinQuyetDinh1, 0, 2);
            this.TLP_KhenThuong_ChuyenNgach.Controls.Add(this.tableLayoutPanel1, 0, 3);
            this.TLP_KhenThuong_ChuyenNgach.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.TLP_KhenThuong_ChuyenNgach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_KhenThuong_ChuyenNgach.Location = new System.Drawing.Point(0, 0);
            this.TLP_KhenThuong_ChuyenNgach.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TLP_KhenThuong_ChuyenNgach.Name = "TLP_KhenThuong_ChuyenNgach";
            this.TLP_KhenThuong_ChuyenNgach.RowCount = 4;
            this.TLP_KhenThuong_ChuyenNgach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.91074F));
            this.TLP_KhenThuong_ChuyenNgach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.12708F));
            this.TLP_KhenThuong_ChuyenNgach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.96218F));
            this.TLP_KhenThuong_ChuyenNgach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.TLP_KhenThuong_ChuyenNgach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP_KhenThuong_ChuyenNgach.Size = new System.Drawing.Size(1000, 800);
            this.TLP_KhenThuong_ChuyenNgach.TabIndex = 1;
            // 
            // thongTinCNVC1
            // 
            this.thongTinCNVC1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.thongTinCNVC1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.thongTinCNVC1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thongTinCNVC1.Location = new System.Drawing.Point(3, 6);
            this.thongTinCNVC1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.thongTinCNVC1.Name = "thongTinCNVC1";
            this.thongTinCNVC1.Size = new System.Drawing.Size(994, 122);
            this.thongTinCNVC1.TabIndex = 0;
            // 
            // thongTinQuyetDinh1
            // 
            this.thongTinQuyetDinh1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.thongTinQuyetDinh1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.thongTinQuyetDinh1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thongTinQuyetDinh1.Location = new System.Drawing.Point(3, 537);
            this.thongTinQuyetDinh1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.thongTinQuyetDinh1.Name = "thongTinQuyetDinh1";
            this.thongTinQuyetDinh1.Size = new System.Drawing.Size(994, 164);
            this.thongTinQuyetDinh1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.pb_Status, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Status, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_Them, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_NhapFile, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 711);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.2381F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.76191F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(994, 85);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // pb_Status
            // 
            this.pb_Status.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pb_Status.Location = new System.Drawing.Point(3, 62);
            this.pb_Status.Name = "pb_Status";
            this.pb_Status.Size = new System.Drawing.Size(207, 19);
            this.pb_Status.TabIndex = 15;
            // 
            // lbl_Status
            // 
            this.lbl_Status.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.Location = new System.Drawing.Point(334, 60);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(0, 23);
            this.lbl_Status.TabIndex = 16;
            // 
            // btn_Them
            // 
            this.btn_Them.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_Them.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Them.ImageKey = "Save.png";
            this.btn_Them.ImageList = this.imageList1;
            this.btn_Them.Location = new System.Drawing.Point(334, 4);
            this.btn_Them.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(63, 50);
            this.btn_Them.TabIndex = 14;
            this.btn_Them.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // btn_NhapFile
            // 
            this.btn_NhapFile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_NhapFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_NhapFile.ImageKey = "Document-Add.png";
            this.btn_NhapFile.ImageList = this.imageList1;
            this.btn_NhapFile.Location = new System.Drawing.Point(134, 4);
            this.btn_NhapFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_NhapFile.Name = "btn_NhapFile";
            this.btn_NhapFile.Size = new System.Drawing.Size(63, 50);
            this.btn_NhapFile.TabIndex = 13;
            this.btn_NhapFile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_NhapFile.UseVisualStyleBackColor = true;
            this.btn_NhapFile.Click += new System.EventHandler(this.btn_NhapFile_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.3132F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.87919F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.69575F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 137);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 391F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(994, 391);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tableLayoutPanel4);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.SkyBlue;
            this.groupBox3.Location = new System.Drawing.Point(621, 4);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(370, 383);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin ngạch mới";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.68712F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.31288F));
            this.tableLayoutPanel4.Controls.Add(this.btn_Edit_Luong, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.btn_Del_Luong, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.dtp_NgayBatDau, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.comb_NgachMoi, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label9, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.txt_HeSoMoi, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.comb_BacMoi, 1, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tableLayoutPanel4.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 26);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(364, 353);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // btn_Edit_Luong
            // 
            this.btn_Edit_Luong.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Edit_Luong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Edit_Luong.ImageKey = "Edit Data.png";
            this.btn_Edit_Luong.ImageList = this.imageList1;
            this.btn_Edit_Luong.Location = new System.Drawing.Point(23, 293);
            this.btn_Edit_Luong.Name = "btn_Edit_Luong";
            this.btn_Edit_Luong.Size = new System.Drawing.Size(50, 46);
            this.btn_Edit_Luong.TabIndex = 59;
            this.btn_Edit_Luong.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Edit_Luong.UseVisualStyleBackColor = true;
            this.btn_Edit_Luong.Click += new System.EventHandler(this.btn_Edit_Luong_Click);
            // 
            // btn_Del_Luong
            // 
            this.btn_Del_Luong.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Del_Luong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Del_Luong.ImageKey = "Cancel.png";
            this.btn_Del_Luong.ImageList = this.imageList1;
            this.btn_Del_Luong.Location = new System.Drawing.Point(205, 293);
            this.btn_Del_Luong.Name = "btn_Del_Luong";
            this.btn_Del_Luong.Size = new System.Drawing.Size(50, 46);
            this.btn_Del_Luong.TabIndex = 58;
            this.btn_Del_Luong.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Del_Luong.UseVisualStyleBackColor = true;
            this.btn_Del_Luong.Visible = false;
            this.btn_Del_Luong.Click += new System.EventHandler(this.btn_Del_Luong_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 46);
            this.label7.TabIndex = 34;
            this.label7.Text = "Ngày bắt đầu";
            // 
            // dtp_NgayBatDau
            // 
            this.dtp_NgayBatDau.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtp_NgayBatDau.Checked = false;
            this.dtp_NgayBatDau.CustomFormat = "dd/MM/yyyy";
            this.dtp_NgayBatDau.Enabled = false;
            this.dtp_NgayBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_NgayBatDau.Location = new System.Drawing.Point(100, 20);
            this.dtp_NgayBatDau.Name = "dtp_NgayBatDau";
            this.dtp_NgayBatDau.Size = new System.Drawing.Size(164, 29);
            this.dtp_NgayBatDau.TabIndex = 57;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 23);
            this.label5.TabIndex = 30;
            this.label5.Text = "Ngạch";
            // 
            // comb_NgachMoi
            // 
            this.comb_NgachMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comb_NgachMoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comb_NgachMoi.Enabled = false;
            this.comb_NgachMoi.FormattingEnabled = true;
            this.comb_NgachMoi.Location = new System.Drawing.Point(100, 90);
            this.comb_NgachMoi.Name = "comb_NgachMoi";
            this.comb_NgachMoi.Size = new System.Drawing.Size(261, 30);
            this.comb_NgachMoi.TabIndex = 31;
            this.comb_NgachMoi.SelectedIndexChanged += new System.EventHandler(this.comb_NgachMoi_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 233);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 23);
            this.label9.TabIndex = 61;
            this.label9.Text = "Hệ số";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 23);
            this.label6.TabIndex = 32;
            this.label6.Text = "Bậc";
            // 
            // txt_HeSoMoi
            // 
            this.txt_HeSoMoi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_HeSoMoi.Enabled = false;
            this.txt_HeSoMoi.Location = new System.Drawing.Point(100, 230);
            this.txt_HeSoMoi.Name = "txt_HeSoMoi";
            this.txt_HeSoMoi.Size = new System.Drawing.Size(190, 29);
            this.txt_HeSoMoi.TabIndex = 60;
            // 
            // comb_BacMoi
            // 
            this.comb_BacMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comb_BacMoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comb_BacMoi.Enabled = false;
            this.comb_BacMoi.FormattingEnabled = true;
            this.comb_BacMoi.Location = new System.Drawing.Point(100, 160);
            this.comb_BacMoi.Name = "comb_BacMoi";
            this.comb_BacMoi.Size = new System.Drawing.Size(261, 30);
            this.comb_BacMoi.TabIndex = 33;
            this.comb_BacMoi.SelectedIndexChanged += new System.EventHandler(this.comb_BacMoi_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.SkyBlue;
            this.groupBox2.Location = new System.Drawing.Point(304, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(311, 383);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin ngạch cũ";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.83607F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.16393F));
            this.tableLayoutPanel3.Controls.Add(this.dtp_NgayCu, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.txt_DV, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbl_SoTien, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txt_CV, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txt_NgachCu, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.txt_BacCu, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.txt_HeSoCu, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tableLayoutPanel3.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 26);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 6;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(305, 353);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // dtp_NgayCu
            // 
            this.dtp_NgayCu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtp_NgayCu.Checked = false;
            this.dtp_NgayCu.CustomFormat = "dd/MM/yyyy";
            this.dtp_NgayCu.Enabled = false;
            this.dtp_NgayCu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_NgayCu.Location = new System.Drawing.Point(94, 307);
            this.dtp_NgayCu.Name = "dtp_NgayCu";
            this.dtp_NgayCu.Size = new System.Drawing.Size(164, 29);
            this.dtp_NgayCu.TabIndex = 58;
            // 
            // txt_DV
            // 
            this.txt_DV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_DV.Enabled = false;
            this.txt_DV.Location = new System.Drawing.Point(94, 14);
            this.txt_DV.Name = "txt_DV";
            this.txt_DV.Size = new System.Drawing.Size(208, 29);
            this.txt_DV.TabIndex = 36;
            // 
            // lbl_SoTien
            // 
            this.lbl_SoTien.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_SoTien.AutoSize = true;
            this.lbl_SoTien.Location = new System.Drawing.Point(3, 17);
            this.lbl_SoTien.Name = "lbl_SoTien";
            this.lbl_SoTien.Size = new System.Drawing.Size(60, 23);
            this.lbl_SoTien.TabIndex = 37;
            this.lbl_SoTien.Text = "Đơn vị";
            // 
            // txt_CV
            // 
            this.txt_CV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_CV.Enabled = false;
            this.txt_CV.Location = new System.Drawing.Point(94, 72);
            this.txt_CV.Name = "txt_CV";
            this.txt_CV.Size = new System.Drawing.Size(208, 29);
            this.txt_CV.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 39;
            this.label1.Text = "Chức vụ";
            // 
            // txt_NgachCu
            // 
            this.txt_NgachCu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_NgachCu.Enabled = false;
            this.txt_NgachCu.Location = new System.Drawing.Point(94, 130);
            this.txt_NgachCu.Name = "txt_NgachCu";
            this.txt_NgachCu.Size = new System.Drawing.Size(208, 29);
            this.txt_NgachCu.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 23);
            this.label2.TabIndex = 41;
            this.label2.Text = "Ngạch";
            // 
            // txt_BacCu
            // 
            this.txt_BacCu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_BacCu.Enabled = false;
            this.txt_BacCu.Location = new System.Drawing.Point(94, 188);
            this.txt_BacCu.Name = "txt_BacCu";
            this.txt_BacCu.Size = new System.Drawing.Size(208, 29);
            this.txt_BacCu.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 23);
            this.label3.TabIndex = 43;
            this.label3.Text = "Bậc";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 63);
            this.label4.TabIndex = 45;
            this.label4.Text = "Ngày được hưởng";
            // 
            // txt_HeSoCu
            // 
            this.txt_HeSoCu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_HeSoCu.Enabled = false;
            this.txt_HeSoCu.Location = new System.Drawing.Point(94, 246);
            this.txt_HeSoCu.Name = "txt_HeSoCu";
            this.txt_HeSoCu.Size = new System.Drawing.Size(208, 29);
            this.txt_HeSoCu.TabIndex = 46;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 249);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 23);
            this.label8.TabIndex = 47;
            this.label8.Text = "Hệ số";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tableLayoutPanel5);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.SkyBlue;
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(295, 383);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách CNVC";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.btn_DelNV, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.lb_DSCNVC, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 26);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.79205F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.20795F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(289, 353);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // btn_DelNV
            // 
            this.btn_DelNV.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_DelNV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DelNV.ImageKey = "Garbage.png";
            this.btn_DelNV.ImageList = this.imageList1;
            this.btn_DelNV.Location = new System.Drawing.Point(119, 301);
            this.btn_DelNV.Name = "btn_DelNV";
            this.btn_DelNV.Size = new System.Drawing.Size(50, 46);
            this.btn_DelNV.TabIndex = 59;
            this.btn_DelNV.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_DelNV.UseVisualStyleBackColor = true;
            this.btn_DelNV.Click += new System.EventHandler(this.btn_DelNV_Click);
            // 
            // lb_DSCNVC
            // 
            this.lb_DSCNVC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_DSCNVC.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_DSCNVC.FormattingEnabled = true;
            this.lb_DSCNVC.ItemHeight = 22;
            this.lb_DSCNVC.Location = new System.Drawing.Point(3, 3);
            this.lb_DSCNVC.Name = "lb_DSCNVC";
            this.lb_DSCNVC.Size = new System.Drawing.Size(283, 289);
            this.lb_DSCNVC.TabIndex = 1;
            this.lb_DSCNVC.SelectedIndexChanged += new System.EventHandler(this.lb_DSCNVC_SelectedIndexChanged);
            // 
            // ChuyenNgachNhanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.TLP_KhenThuong_ChuyenNgach);
            this.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1000, 800);
            this.Name = "ChuyenNgachNhanh";
            this.Size = new System.Drawing.Size(1000, 800);
            this.Load += new System.EventHandler(this.ChuyenNgachNhanh_Load);
            this.TLP_KhenThuong_ChuyenNgach.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.ComponentModel.BackgroundWorker bw_upload;
        private System.Windows.Forms.TableLayoutPanel TLP_KhenThuong_ChuyenNgach;
        private ThongTinCNVC thongTinCNVC1;
        private ThongTinQuyetDinh thongTinQuyetDinh1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.ProgressBar pb_Status;
        public System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Button btn_NhapFile;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TextBox txt_DV;
        private System.Windows.Forms.Label lbl_SoTien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_BacCu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_NgachCu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_CV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comb_BacMoi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comb_NgachMoi;
        public System.Windows.Forms.DateTimePicker dtp_NgayBatDau;
        private System.Windows.Forms.Button btn_Edit_Luong;
        private System.Windows.Forms.Button btn_Del_Luong;
        private System.Windows.Forms.TextBox txt_HeSoCu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_HeSoMoi;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.DateTimePicker dtp_NgayCu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button btn_DelNV;
        private System.Windows.Forms.ListBox lb_DSCNVC;
    }
}
