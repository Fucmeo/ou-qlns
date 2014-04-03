namespace LuongBH.UCs.Luong
{
    partial class TinhBaoHiem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TinhBaoHiem));
            this.TLP_TinhLuong = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tp_BH = new System.Windows.Forms.TabPage();
            this.dtgv_BH = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.TLP_DoiTuongTInh = new System.Windows.Forms.TableLayoutPanel();
            this.rdb_NV = new System.Windows.Forms.RadioButton();
            this.rdb_DonVi = new System.Windows.Forms.RadioButton();
            this.TLP_LoaiDTTinh = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TLP_ThongTinTimKiem = new System.Windows.Forms.TableLayoutPanel();
            this.TLP_TheoNV = new System.Windows.Forms.TableLayoutPanel();
            this.btn_AddNV = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.TLP_TheoDV = new System.Windows.Forms.TableLayoutPanel();
            this.comb_DonVi = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_AddDonVi = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pb_BH = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.mtx_Thang = new System.Windows.Forms.MaskedTextBox();
            this.btn_XuatExcel = new System.Windows.Forms.Button();
            this.btn_TinhBaoHiem = new System.Windows.Forms.Button();
            this.TLP_DanhSach = new System.Windows.Forms.TableLayoutPanel();
            this.btn_RemoveList = new System.Windows.Forms.Button();
            this.lsb_DanhSach = new System.Windows.Forms.ListBox();
            this.TLP_TinhLuong.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tp_BH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_BH)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.TLP_DoiTuongTInh.SuspendLayout();
            this.TLP_LoaiDTTinh.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.TLP_ThongTinTimKiem.SuspendLayout();
            this.TLP_TheoNV.SuspendLayout();
            this.TLP_TheoDV.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.TLP_DanhSach.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLP_TinhLuong
            // 
            this.TLP_TinhLuong.ColumnCount = 1;
            this.TLP_TinhLuong.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_TinhLuong.Controls.Add(this.groupBox1, 0, 1);
            this.TLP_TinhLuong.Controls.Add(this.groupBox6, 0, 0);
            this.TLP_TinhLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_TinhLuong.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.TLP_TinhLuong.Location = new System.Drawing.Point(0, 0);
            this.TLP_TinhLuong.Name = "TLP_TinhLuong";
            this.TLP_TinhLuong.RowCount = 2;
            this.TLP_TinhLuong.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.69784F));
            this.TLP_TinhLuong.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.30216F));
            this.TLP_TinhLuong.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP_TinhLuong.Size = new System.Drawing.Size(987, 791);
            this.TLP_TinhLuong.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBox1.Location = new System.Drawing.Point(3, 459);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(981, 329);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kết quả";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tp_BH);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(975, 301);
            this.tabControl1.TabIndex = 0;
            // 
            // tp_BH
            // 
            this.tp_BH.Controls.Add(this.dtgv_BH);
            this.tp_BH.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tp_BH.Location = new System.Drawing.Point(4, 31);
            this.tp_BH.Name = "tp_BH";
            this.tp_BH.Padding = new System.Windows.Forms.Padding(3);
            this.tp_BH.Size = new System.Drawing.Size(967, 266);
            this.tp_BH.TabIndex = 1;
            this.tp_BH.Text = "Bảo hiểm";
            this.tp_BH.UseVisualStyleBackColor = true;
            // 
            // dtgv_BH
            // 
            this.dtgv_BH.AllowUserToAddRows = false;
            this.dtgv_BH.AllowUserToDeleteRows = false;
            this.dtgv_BH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_BH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgv_BH.Location = new System.Drawing.Point(3, 3);
            this.dtgv_BH.Name = "dtgv_BH";
            this.dtgv_BH.ReadOnly = true;
            this.dtgv_BH.RowTemplate.Height = 24;
            this.dtgv_BH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgv_BH.Size = new System.Drawing.Size(961, 260);
            this.dtgv_BH.TabIndex = 2;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.TLP_DoiTuongTInh);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBox6.Location = new System.Drawing.Point(3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(981, 450);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Đối tượng tính bảo hiểm";
            // 
            // TLP_DoiTuongTInh
            // 
            this.TLP_DoiTuongTInh.ColumnCount = 3;
            this.TLP_DoiTuongTInh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLP_DoiTuongTInh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLP_DoiTuongTInh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLP_DoiTuongTInh.Controls.Add(this.rdb_NV, 0, 0);
            this.TLP_DoiTuongTInh.Controls.Add(this.rdb_DonVi, 1, 0);
            this.TLP_DoiTuongTInh.Controls.Add(this.TLP_LoaiDTTinh, 0, 1);
            this.TLP_DoiTuongTInh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_DoiTuongTInh.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TLP_DoiTuongTInh.ForeColor = System.Drawing.Color.Black;
            this.TLP_DoiTuongTInh.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.TLP_DoiTuongTInh.Location = new System.Drawing.Point(3, 25);
            this.TLP_DoiTuongTInh.Name = "TLP_DoiTuongTInh";
            this.TLP_DoiTuongTInh.RowCount = 2;
            this.TLP_DoiTuongTInh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.77251F));
            this.TLP_DoiTuongTInh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.24644F));
            this.TLP_DoiTuongTInh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP_DoiTuongTInh.Size = new System.Drawing.Size(975, 422);
            this.TLP_DoiTuongTInh.TabIndex = 0;
            // 
            // rdb_NV
            // 
            this.rdb_NV.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rdb_NV.AutoSize = true;
            this.rdb_NV.Checked = true;
            this.rdb_NV.Location = new System.Drawing.Point(88, 30);
            this.rdb_NV.Name = "rdb_NV";
            this.rdb_NV.Size = new System.Drawing.Size(148, 27);
            this.rdb_NV.TabIndex = 9;
            this.rdb_NV.TabStop = true;
            this.rdb_NV.Text = "Theo nhân viên";
            this.rdb_NV.UseVisualStyleBackColor = true;
            // 
            // rdb_DonVi
            // 
            this.rdb_DonVi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rdb_DonVi.AutoSize = true;
            this.rdb_DonVi.Location = new System.Drawing.Point(427, 30);
            this.rdb_DonVi.Name = "rdb_DonVi";
            this.rdb_DonVi.Size = new System.Drawing.Size(121, 27);
            this.rdb_DonVi.TabIndex = 10;
            this.rdb_DonVi.Text = "Theo đơn vị";
            this.rdb_DonVi.UseVisualStyleBackColor = true;
            // 
            // TLP_LoaiDTTinh
            // 
            this.TLP_LoaiDTTinh.ColumnCount = 2;
            this.TLP_DoiTuongTInh.SetColumnSpan(this.TLP_LoaiDTTinh, 3);
            this.TLP_LoaiDTTinh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.74097F));
            this.TLP_LoaiDTTinh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.25903F));
            this.TLP_LoaiDTTinh.Controls.Add(this.groupBox2, 0, 0);
            this.TLP_LoaiDTTinh.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.TLP_LoaiDTTinh.Controls.Add(this.TLP_DanhSach, 1, 0);
            this.TLP_LoaiDTTinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_LoaiDTTinh.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.TLP_LoaiDTTinh.Location = new System.Drawing.Point(3, 90);
            this.TLP_LoaiDTTinh.Name = "TLP_LoaiDTTinh";
            this.TLP_LoaiDTTinh.RowCount = 3;
            this.TLP_LoaiDTTinh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.71186F));
            this.TLP_LoaiDTTinh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.9661F));
            this.TLP_LoaiDTTinh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.32203F));
            this.TLP_LoaiDTTinh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP_LoaiDTTinh.Size = new System.Drawing.Size(969, 329);
            this.TLP_LoaiDTTinh.TabIndex = 39;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TLP_ThongTinTimKiem);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.TLP_LoaiDTTinh.SetRowSpan(this.groupBox2, 2);
            this.groupBox2.Size = new System.Drawing.Size(756, 258);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin tìm kiếm";
            // 
            // TLP_ThongTinTimKiem
            // 
            this.TLP_ThongTinTimKiem.ColumnCount = 1;
            this.TLP_ThongTinTimKiem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_ThongTinTimKiem.Controls.Add(this.TLP_TheoNV, 0, 0);
            this.TLP_ThongTinTimKiem.Controls.Add(this.TLP_TheoDV, 0, 1);
            this.TLP_ThongTinTimKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_ThongTinTimKiem.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.TLP_ThongTinTimKiem.Location = new System.Drawing.Point(3, 25);
            this.TLP_ThongTinTimKiem.Name = "TLP_ThongTinTimKiem";
            this.TLP_ThongTinTimKiem.RowCount = 2;
            this.TLP_ThongTinTimKiem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_ThongTinTimKiem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_ThongTinTimKiem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP_ThongTinTimKiem.Size = new System.Drawing.Size(750, 230);
            this.TLP_ThongTinTimKiem.TabIndex = 0;
            // 
            // TLP_TheoNV
            // 
            this.TLP_TheoNV.ColumnCount = 2;
            this.TLP_TheoNV.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.36559F));
            this.TLP_TheoNV.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.63441F));
            this.TLP_TheoNV.Controls.Add(this.btn_AddNV, 1, 0);
            this.TLP_TheoNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_TheoNV.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TLP_TheoNV.ForeColor = System.Drawing.Color.Black;
            this.TLP_TheoNV.Location = new System.Drawing.Point(3, 3);
            this.TLP_TheoNV.Name = "TLP_TheoNV";
            this.TLP_TheoNV.RowCount = 1;
            this.TLP_TheoNV.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_TheoNV.Size = new System.Drawing.Size(744, 109);
            this.TLP_TheoNV.TabIndex = 42;
            // 
            // btn_AddNV
            // 
            this.btn_AddNV.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_AddNV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AddNV.ImageKey = "ArrowHead-Right.png";
            this.btn_AddNV.ImageList = this.imageList1;
            this.btn_AddNV.Location = new System.Drawing.Point(669, 26);
            this.btn_AddNV.Name = "btn_AddNV";
            this.btn_AddNV.Size = new System.Drawing.Size(56, 56);
            this.btn_AddNV.TabIndex = 6;
            this.btn_AddNV.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_AddNV.UseVisualStyleBackColor = true;
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
            this.imageList1.Images.SetKeyName(5, "Business Man Find.png");
            this.imageList1.Images.SetKeyName(6, "ArrowHead-Right.png");
            // 
            // TLP_TheoDV
            // 
            this.TLP_TheoDV.ColumnCount = 4;
            this.TLP_TheoDV.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.12903F));
            this.TLP_TheoDV.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.39247F));
            this.TLP_TheoDV.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.97849F));
            this.TLP_TheoDV.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.36559F));
            this.TLP_TheoDV.Controls.Add(this.comb_DonVi, 0, 0);
            this.TLP_TheoDV.Controls.Add(this.label3, 0, 0);
            this.TLP_TheoDV.Controls.Add(this.btn_AddDonVi, 3, 0);
            this.TLP_TheoDV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_TheoDV.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TLP_TheoDV.ForeColor = System.Drawing.Color.Black;
            this.TLP_TheoDV.Location = new System.Drawing.Point(3, 118);
            this.TLP_TheoDV.Name = "TLP_TheoDV";
            this.TLP_TheoDV.RowCount = 1;
            this.TLP_TheoDV.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.TLP_TheoDV.Size = new System.Drawing.Size(744, 109);
            this.TLP_TheoDV.TabIndex = 41;
            // 
            // comb_DonVi
            // 
            this.comb_DonVi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comb_DonVi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comb_DonVi.FormattingEnabled = true;
            this.comb_DonVi.Items.AddRange(new object[] {
            "Lương cơ bản",
            "Lương tối thiểu"});
            this.comb_DonVi.Location = new System.Drawing.Point(123, 42);
            this.comb_DonVi.Name = "comb_DonVi";
            this.comb_DonVi.Size = new System.Drawing.Size(235, 30);
            this.comb_DonVi.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 23);
            this.label3.TabIndex = 10;
            this.label3.Text = "Đơn vị";
            // 
            // btn_AddDonVi
            // 
            this.btn_AddDonVi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_AddDonVi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AddDonVi.ImageKey = "ArrowHead-Right.png";
            this.btn_AddDonVi.ImageList = this.imageList1;
            this.btn_AddDonVi.Location = new System.Drawing.Point(669, 26);
            this.btn_AddDonVi.Name = "btn_AddDonVi";
            this.btn_AddDonVi.Size = new System.Drawing.Size(56, 56);
            this.btn_AddDonVi.TabIndex = 5;
            this.btn_AddDonVi.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_AddDonVi.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.TLP_LoaiDTTinh.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.pb_BH, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.mtx_Thang, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_XuatExcel, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_TinhBaoHiem, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 267);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(963, 59);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // pb_BH
            // 
            this.pb_BH.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pb_BH.Location = new System.Drawing.Point(779, 18);
            this.pb_BH.Name = "pb_BH";
            this.pb_BH.Size = new System.Drawing.Size(172, 23);
            this.pb_BH.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 23);
            this.label1.TabIndex = 38;
            this.label1.Text = "Tháng";
            // 
            // mtx_Thang
            // 
            this.mtx_Thang.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.mtx_Thang.Location = new System.Drawing.Point(195, 15);
            this.mtx_Thang.Mask = "00/0000";
            this.mtx_Thang.Name = "mtx_Thang";
            this.mtx_Thang.Size = new System.Drawing.Size(98, 29);
            this.mtx_Thang.TabIndex = 39;
            // 
            // btn_XuatExcel
            // 
            this.btn_XuatExcel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_XuatExcel.Location = new System.Drawing.Point(579, 9);
            this.btn_XuatExcel.Name = "btn_XuatExcel";
            this.btn_XuatExcel.Size = new System.Drawing.Size(186, 40);
            this.btn_XuatExcel.TabIndex = 38;
            this.btn_XuatExcel.Text = "Xuất Excel";
            this.btn_XuatExcel.UseVisualStyleBackColor = true;
            // 
            // btn_TinhBaoHiem
            // 
            this.btn_TinhBaoHiem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_TinhBaoHiem.Location = new System.Drawing.Point(387, 9);
            this.btn_TinhBaoHiem.Name = "btn_TinhBaoHiem";
            this.btn_TinhBaoHiem.Size = new System.Drawing.Size(186, 40);
            this.btn_TinhBaoHiem.TabIndex = 37;
            this.btn_TinhBaoHiem.Text = "Tính bảo hiểm";
            this.btn_TinhBaoHiem.UseVisualStyleBackColor = true;
            // 
            // TLP_DanhSach
            // 
            this.TLP_DanhSach.ColumnCount = 2;
            this.TLP_DanhSach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_DanhSach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_DanhSach.Controls.Add(this.btn_RemoveList, 0, 1);
            this.TLP_DanhSach.Controls.Add(this.lsb_DanhSach, 0, 0);
            this.TLP_DanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_DanhSach.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.TLP_DanhSach.Location = new System.Drawing.Point(765, 3);
            this.TLP_DanhSach.Name = "TLP_DanhSach";
            this.TLP_DanhSach.RowCount = 2;
            this.TLP_LoaiDTTinh.SetRowSpan(this.TLP_DanhSach, 2);
            this.TLP_DanhSach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.23715F));
            this.TLP_DanhSach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.76285F));
            this.TLP_DanhSach.Size = new System.Drawing.Size(201, 258);
            this.TLP_DanhSach.TabIndex = 4;
            // 
            // btn_RemoveList
            // 
            this.btn_RemoveList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_RemoveList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_RemoveList.ImageKey = "Cancel.png";
            this.btn_RemoveList.ImageList = this.imageList1;
            this.btn_RemoveList.Location = new System.Drawing.Point(26, 211);
            this.btn_RemoveList.Name = "btn_RemoveList";
            this.btn_RemoveList.Size = new System.Drawing.Size(48, 43);
            this.btn_RemoveList.TabIndex = 6;
            this.btn_RemoveList.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_RemoveList.UseVisualStyleBackColor = true;
            // 
            // lsb_DanhSach
            // 
            this.TLP_DanhSach.SetColumnSpan(this.lsb_DanhSach, 2);
            this.lsb_DanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsb_DanhSach.FormattingEnabled = true;
            this.lsb_DanhSach.ItemHeight = 22;
            this.lsb_DanhSach.Location = new System.Drawing.Point(3, 3);
            this.lsb_DanhSach.Name = "lsb_DanhSach";
            this.lsb_DanhSach.Size = new System.Drawing.Size(195, 201);
            this.lsb_DanhSach.TabIndex = 3;
            // 
            // TinhBaoHiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.TLP_TinhLuong);
            this.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TinhBaoHiem";
            this.Size = new System.Drawing.Size(987, 791);
            this.Load += new System.EventHandler(this.TinhBaoHiem_Load);
            this.TLP_TinhLuong.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tp_BH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_BH)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.TLP_DoiTuongTInh.ResumeLayout(false);
            this.TLP_DoiTuongTInh.PerformLayout();
            this.TLP_LoaiDTTinh.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.TLP_ThongTinTimKiem.ResumeLayout(false);
            this.TLP_TheoNV.ResumeLayout(false);
            this.TLP_TheoDV.ResumeLayout(false);
            this.TLP_TheoDV.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.TLP_DanhSach.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLP_TinhLuong;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tp_BH;
        private System.Windows.Forms.DataGridView dtgv_BH;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TableLayoutPanel TLP_DoiTuongTInh;
        private System.Windows.Forms.RadioButton rdb_NV;
        private System.Windows.Forms.RadioButton rdb_DonVi;
        private System.Windows.Forms.TableLayoutPanel TLP_LoaiDTTinh;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel TLP_ThongTinTimKiem;
        private System.Windows.Forms.TableLayoutPanel TLP_TheoNV;
        private System.Windows.Forms.Button btn_AddNV;
        private System.Windows.Forms.TableLayoutPanel TLP_TheoDV;
        public System.Windows.Forms.ComboBox comb_DonVi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_AddDonVi;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ProgressBar pb_BH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mtx_Thang;
        private System.Windows.Forms.Button btn_XuatExcel;
        private System.Windows.Forms.Button btn_TinhBaoHiem;
        private System.Windows.Forms.TableLayoutPanel TLP_DanhSach;
        private System.Windows.Forms.Button btn_RemoveList;
        private System.Windows.Forms.ListBox lsb_DanhSach;
        private System.Windows.Forms.ImageList imageList1;
    }
}
