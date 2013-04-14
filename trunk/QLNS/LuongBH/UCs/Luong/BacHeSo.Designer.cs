namespace LuongBH.UCs.Luong
{
    partial class BacHeSo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BacHeSo));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLP_ChucDanh = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLP_DSChucDanh = new System.Windows.Forms.TableLayoutPanel();
            this.dtgv_DSBacHeSo = new System.Windows.Forms.DataGridView();
            this.tableLP_ChiTietChucDanh = new System.Windows.Forms.TableLayoutPanel();
            this.txt_NhomNgach = new System.Windows.Forms.TextBox();
            this.txt_MaNgach = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comB_TenNgach = new System.Windows.Forms.ComboBox();
            this.txt_HeSo = new System.Windows.Forms.TextBox();
            this.txt_Bac = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLP_ThaoTac = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Huy = new System.Windows.Forms.Button();
            this.btn_Them = new System.Windows.Forms.Button();
            this.btn_Luu = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_VuotKhung = new System.Windows.Forms.CheckBox();
            this.dtp_DenNgay = new System.Windows.Forms.DateTimePicker();
            this.dtp_TuNgay = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLP_ChucDanh.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLP_DSChucDanh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_DSBacHeSo)).BeginInit();
            this.tableLP_ChiTietChucDanh.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLP_ThaoTac.SuspendLayout();
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
            // 
            // tableLP_ChucDanh
            // 
            this.tableLP_ChucDanh.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tableLP_ChucDanh.ColumnCount = 1;
            this.tableLP_ChucDanh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLP_ChucDanh.Controls.Add(this.groupBox1, 0, 1);
            this.tableLP_ChucDanh.Controls.Add(this.tableLP_ChiTietChucDanh, 0, 0);
            this.tableLP_ChucDanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLP_ChucDanh.Location = new System.Drawing.Point(0, 0);
            this.tableLP_ChucDanh.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tableLP_ChucDanh.Name = "tableLP_ChucDanh";
            this.tableLP_ChucDanh.RowCount = 2;
            this.tableLP_ChucDanh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLP_ChucDanh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLP_ChucDanh.Size = new System.Drawing.Size(650, 600);
            this.tableLP_ChucDanh.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLP_DSChucDanh);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 303);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(644, 294);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách bậc / hệ số";
            // 
            // tableLP_DSChucDanh
            // 
            this.tableLP_DSChucDanh.ColumnCount = 2;
            this.tableLP_DSChucDanh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.63953F));
            this.tableLP_DSChucDanh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.36047F));
            this.tableLP_DSChucDanh.Controls.Add(this.dtgv_DSBacHeSo, 0, 0);
            this.tableLP_DSChucDanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLP_DSChucDanh.Location = new System.Drawing.Point(3, 20);
            this.tableLP_DSChucDanh.Name = "tableLP_DSChucDanh";
            this.tableLP_DSChucDanh.RowCount = 1;
            this.tableLP_DSChucDanh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.9624F));
            this.tableLP_DSChucDanh.Size = new System.Drawing.Size(638, 271);
            this.tableLP_DSChucDanh.TabIndex = 0;
            // 
            // dtgv_DSBacHeSo
            // 
            this.dtgv_DSBacHeSo.AllowUserToAddRows = false;
            this.dtgv_DSBacHeSo.AllowUserToDeleteRows = false;
            this.dtgv_DSBacHeSo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLP_DSChucDanh.SetColumnSpan(this.dtgv_DSBacHeSo, 2);
            this.dtgv_DSBacHeSo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgv_DSBacHeSo.Location = new System.Drawing.Point(3, 3);
            this.dtgv_DSBacHeSo.Name = "dtgv_DSBacHeSo";
            this.dtgv_DSBacHeSo.ReadOnly = true;
            this.dtgv_DSBacHeSo.RowTemplate.Height = 24;
            this.dtgv_DSBacHeSo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgv_DSBacHeSo.Size = new System.Drawing.Size(632, 265);
            this.dtgv_DSBacHeSo.TabIndex = 0;
            this.dtgv_DSBacHeSo.SelectionChanged += new System.EventHandler(this.dtgv_DSBacHeSo_SelectionChanged);
            // 
            // tableLP_ChiTietChucDanh
            // 
            this.tableLP_ChiTietChucDanh.ColumnCount = 4;
            this.tableLP_ChiTietChucDanh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLP_ChiTietChucDanh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLP_ChiTietChucDanh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLP_ChiTietChucDanh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLP_ChiTietChucDanh.Controls.Add(this.txt_NhomNgach, 3, 1);
            this.tableLP_ChiTietChucDanh.Controls.Add(this.txt_MaNgach, 1, 2);
            this.tableLP_ChiTietChucDanh.Controls.Add(this.label7, 0, 2);
            this.tableLP_ChiTietChucDanh.Controls.Add(this.comB_TenNgach, 1, 1);
            this.tableLP_ChiTietChucDanh.Controls.Add(this.txt_HeSo, 3, 0);
            this.tableLP_ChiTietChucDanh.Controls.Add(this.txt_Bac, 1, 0);
            this.tableLP_ChiTietChucDanh.Controls.Add(this.groupBox2, 0, 4);
            this.tableLP_ChiTietChucDanh.Controls.Add(this.label3, 0, 0);
            this.tableLP_ChiTietChucDanh.Controls.Add(this.label2, 0, 1);
            this.tableLP_ChiTietChucDanh.Controls.Add(this.label1, 2, 1);
            this.tableLP_ChiTietChucDanh.Controls.Add(this.label4, 2, 0);
            this.tableLP_ChiTietChucDanh.Controls.Add(this.label6, 2, 3);
            this.tableLP_ChiTietChucDanh.Controls.Add(this.cb_VuotKhung, 2, 2);
            this.tableLP_ChiTietChucDanh.Controls.Add(this.dtp_DenNgay, 3, 3);
            this.tableLP_ChiTietChucDanh.Controls.Add(this.dtp_TuNgay, 1, 3);
            this.tableLP_ChiTietChucDanh.Controls.Add(this.label5, 0, 3);
            this.tableLP_ChiTietChucDanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLP_ChiTietChucDanh.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLP_ChiTietChucDanh.Location = new System.Drawing.Point(3, 3);
            this.tableLP_ChiTietChucDanh.Name = "tableLP_ChiTietChucDanh";
            this.tableLP_ChiTietChucDanh.RowCount = 5;
            this.tableLP_ChiTietChucDanh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLP_ChiTietChucDanh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLP_ChiTietChucDanh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLP_ChiTietChucDanh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLP_ChiTietChucDanh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLP_ChiTietChucDanh.Size = new System.Drawing.Size(644, 294);
            this.tableLP_ChiTietChucDanh.TabIndex = 1;
            // 
            // txt_NhomNgach
            // 
            this.txt_NhomNgach.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_NhomNgach.Enabled = false;
            this.txt_NhomNgach.Location = new System.Drawing.Point(420, 54);
            this.txt_NhomNgach.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txt_NhomNgach.Name = "txt_NhomNgach";
            this.txt_NhomNgach.Size = new System.Drawing.Size(218, 24);
            this.txt_NhomNgach.TabIndex = 15;
            // 
            // txt_MaNgach
            // 
            this.txt_MaNgach.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_MaNgach.Enabled = false;
            this.txt_MaNgach.Location = new System.Drawing.Point(99, 98);
            this.txt_MaNgach.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txt_MaNgach.Name = "txt_MaNgach";
            this.txt_MaNgach.Size = new System.Drawing.Size(208, 24);
            this.txt_MaNgach.TabIndex = 14;
            this.txt_MaNgach.TextChanged += new System.EventHandler(this.txt_MaNgach_TextChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Mã ngạch";
            // 
            // comB_TenNgach
            // 
            this.comB_TenNgach.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comB_TenNgach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_TenNgach.Enabled = false;
            this.comB_TenNgach.FormattingEnabled = true;
            this.comB_TenNgach.Items.AddRange(new object[] {
            "Biên chế",
            "Hợp đồng"});
            this.comB_TenNgach.Location = new System.Drawing.Point(99, 53);
            this.comB_TenNgach.Name = "comB_TenNgach";
            this.comB_TenNgach.Size = new System.Drawing.Size(208, 25);
            this.comB_TenNgach.TabIndex = 2;
            this.comB_TenNgach.SelectionChangeCommitted += new System.EventHandler(this.comB_TenNgach_SelectionChangeCommitted);
            // 
            // txt_HeSo
            // 
            this.txt_HeSo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_HeSo.Enabled = false;
            this.txt_HeSo.Location = new System.Drawing.Point(420, 10);
            this.txt_HeSo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txt_HeSo.Name = "txt_HeSo";
            this.txt_HeSo.Size = new System.Drawing.Size(218, 24);
            this.txt_HeSo.TabIndex = 1;
            // 
            // txt_Bac
            // 
            this.txt_Bac.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_Bac.Enabled = false;
            this.txt_Bac.Location = new System.Drawing.Point(99, 10);
            this.txt_Bac.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txt_Bac.Name = "txt_Bac";
            this.txt_Bac.Size = new System.Drawing.Size(208, 24);
            this.txt_Bac.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.tableLP_ChiTietChucDanh.SetColumnSpan(this.groupBox2, 4);
            this.groupBox2.Controls.Add(this.tableLP_ThaoTac);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 181);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox2.Size = new System.Drawing.Size(638, 108);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thao tác";
            // 
            // tableLP_ThaoTac
            // 
            this.tableLP_ThaoTac.ColumnCount = 5;
            this.tableLP_ThaoTac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLP_ThaoTac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLP_ThaoTac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLP_ThaoTac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLP_ThaoTac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLP_ThaoTac.Controls.Add(this.btn_Huy, 3, 0);
            this.tableLP_ThaoTac.Controls.Add(this.btn_Them, 0, 0);
            this.tableLP_ThaoTac.Controls.Add(this.btn_Luu, 2, 0);
            this.tableLP_ThaoTac.Controls.Add(this.btn_Xoa, 4, 0);
            this.tableLP_ThaoTac.Controls.Add(this.btn_Sua, 1, 0);
            this.tableLP_ThaoTac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLP_ThaoTac.Location = new System.Drawing.Point(3, 22);
            this.tableLP_ThaoTac.Name = "tableLP_ThaoTac";
            this.tableLP_ThaoTac.RowCount = 1;
            this.tableLP_ThaoTac.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLP_ThaoTac.Size = new System.Drawing.Size(632, 81);
            this.tableLP_ThaoTac.TabIndex = 0;
            // 
            // btn_Huy
            // 
            this.btn_Huy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Huy.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Huy.ImageKey = "Cancel.png";
            this.btn_Huy.ImageList = this.imageList1;
            this.btn_Huy.Location = new System.Drawing.Point(413, 12);
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(56, 56);
            this.btn_Huy.TabIndex = 3;
            this.btn_Huy.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Huy.UseVisualStyleBackColor = true;
            this.btn_Huy.Visible = false;
            this.btn_Huy.Click += new System.EventHandler(this.btn_Huy_Click);
            // 
            // btn_Them
            // 
            this.btn_Them.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Them.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Them.ImageKey = "Add.png";
            this.btn_Them.ImageList = this.imageList1;
            this.btn_Them.Location = new System.Drawing.Point(35, 12);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(56, 56);
            this.btn_Them.TabIndex = 0;
            this.btn_Them.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // btn_Luu
            // 
            this.btn_Luu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Luu.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Luu.ImageKey = "Save.png";
            this.btn_Luu.ImageList = this.imageList1;
            this.btn_Luu.Location = new System.Drawing.Point(287, 12);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(56, 56);
            this.btn_Luu.TabIndex = 2;
            this.btn_Luu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Luu.UseVisualStyleBackColor = true;
            this.btn_Luu.Visible = false;
            this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Xoa.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Xoa.ImageKey = "Garbage.png";
            this.btn_Xoa.ImageList = this.imageList1;
            this.btn_Xoa.Location = new System.Drawing.Point(540, 12);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(56, 56);
            this.btn_Xoa.TabIndex = 4;
            this.btn_Xoa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_Sua
            // 
            this.btn_Sua.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Sua.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Sua.ImageKey = "Edit Data.png";
            this.btn_Sua.ImageList = this.imageList1;
            this.btn_Sua.Location = new System.Drawing.Point(161, 12);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(56, 56);
            this.btn_Sua.TabIndex = 1;
            this.btn_Sua.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Sua.UseVisualStyleBackColor = true;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bậc";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên ngạch";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(324, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nhóm ngạch";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(324, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Hệ số";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(324, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Đến ngày";
            // 
            // cb_VuotKhung
            // 
            this.cb_VuotKhung.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cb_VuotKhung.AutoSize = true;
            this.tableLP_ChiTietChucDanh.SetColumnSpan(this.cb_VuotKhung, 2);
            this.cb_VuotKhung.Location = new System.Drawing.Point(324, 99);
            this.cb_VuotKhung.Name = "cb_VuotKhung";
            this.cb_VuotKhung.Size = new System.Drawing.Size(93, 21);
            this.cb_VuotKhung.TabIndex = 7;
            this.cb_VuotKhung.Text = "Vượt khung";
            this.cb_VuotKhung.UseVisualStyleBackColor = true;
            // 
            // dtp_DenNgay
            // 
            this.dtp_DenNgay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtp_DenNgay.Checked = false;
            this.dtp_DenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtp_DenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_DenNgay.Location = new System.Drawing.Point(420, 142);
            this.dtp_DenNgay.Name = "dtp_DenNgay";
            this.dtp_DenNgay.ShowCheckBox = true;
            this.dtp_DenNgay.Size = new System.Drawing.Size(221, 24);
            this.dtp_DenNgay.TabIndex = 5;
            // 
            // dtp_TuNgay
            // 
            this.dtp_TuNgay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtp_TuNgay.Checked = false;
            this.dtp_TuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtp_TuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_TuNgay.Location = new System.Drawing.Point(99, 142);
            this.dtp_TuNgay.Name = "dtp_TuNgay";
            this.dtp_TuNgay.ShowCheckBox = true;
            this.dtp_TuNgay.Size = new System.Drawing.Size(219, 24);
            this.dtp_TuNgay.TabIndex = 4;
            this.dtp_TuNgay.ValueChanged += new System.EventHandler(this.dtp_TuNgay_ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Từ ngày";
            // 
            // BacHeSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.tableLP_ChucDanh);
            this.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BacHeSo";
            this.Size = new System.Drawing.Size(650, 600);
            this.Load += new System.EventHandler(this.BacHeSo_Load);
            this.tableLP_ChucDanh.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLP_DSChucDanh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_DSBacHeSo)).EndInit();
            this.tableLP_ChiTietChucDanh.ResumeLayout(false);
            this.tableLP_ChiTietChucDanh.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLP_ThaoTac.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TableLayoutPanel tableLP_ChucDanh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLP_DSChucDanh;
        private System.Windows.Forms.DataGridView dtgv_DSBacHeSo;
        private System.Windows.Forms.TableLayoutPanel tableLP_ChiTietChucDanh;
        private System.Windows.Forms.ComboBox comB_TenNgach;
        private System.Windows.Forms.TextBox txt_HeSo;
        private System.Windows.Forms.TextBox txt_Bac;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLP_ThaoTac;
        private System.Windows.Forms.Button btn_Huy;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Button btn_Luu;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.DateTimePicker dtp_DenNgay;
        public System.Windows.Forms.DateTimePicker dtp_TuNgay;
        private System.Windows.Forms.CheckBox cb_VuotKhung;
        private System.Windows.Forms.TextBox txt_MaNgach;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_NhomNgach;
    }
}
