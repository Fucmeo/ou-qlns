namespace QLNS.UCs
{
    partial class QLNS_ChucVu_ChinhTri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QLNS_ChucVu_ChinhTri));
            this.tableLP_ChucVu_ChinhTri = new System.Windows.Forms.TableLayoutPanel();
            this.comB_Loai = new System.Windows.Forms.ComboBox();
            this.txt_Ten = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLP_DSVanBang = new System.Windows.Forms.TableLayoutPanel();
            this.dtgv_DSChucVuDonVi = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLP_ThaoTac = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Huy = new System.Windows.Forms.Button();
            this.btn_Them = new System.Windows.Forms.Button();
            this.btn_Luu = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.tableLP_ChucVu_ChinhTri.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLP_DSVanBang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_DSChucVuDonVi)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLP_ThaoTac.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLP_ChucVu_ChinhTri
            // 
            this.tableLP_ChucVu_ChinhTri.ColumnCount = 4;
            this.tableLP_ChucVu_ChinhTri.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.36364F));
            this.tableLP_ChucVu_ChinhTri.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLP_ChucVu_ChinhTri.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.18182F));
            this.tableLP_ChucVu_ChinhTri.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.27273F));
            this.tableLP_ChucVu_ChinhTri.Controls.Add(this.comB_Loai, 3, 0);
            this.tableLP_ChucVu_ChinhTri.Controls.Add(this.txt_Ten, 1, 0);
            this.tableLP_ChucVu_ChinhTri.Controls.Add(this.groupBox1, 0, 2);
            this.tableLP_ChucVu_ChinhTri.Controls.Add(this.groupBox2, 0, 1);
            this.tableLP_ChucVu_ChinhTri.Controls.Add(this.label1, 0, 0);
            this.tableLP_ChucVu_ChinhTri.Controls.Add(this.label2, 2, 0);
            this.tableLP_ChucVu_ChinhTri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLP_ChucVu_ChinhTri.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLP_ChucVu_ChinhTri.Location = new System.Drawing.Point(0, 0);
            this.tableLP_ChucVu_ChinhTri.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLP_ChucVu_ChinhTri.Name = "tableLP_ChucVu_ChinhTri";
            this.tableLP_ChucVu_ChinhTri.RowCount = 3;
            this.tableLP_ChucVu_ChinhTri.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.4F));
            this.tableLP_ChucVu_ChinhTri.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.4F));
            this.tableLP_ChucVu_ChinhTri.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLP_ChucVu_ChinhTri.Size = new System.Drawing.Size(600, 500);
            this.tableLP_ChucVu_ChinhTri.TabIndex = 0;
            // 
            // comB_Loai
            // 
            this.comB_Loai.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comB_Loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_Loai.FormattingEnabled = true;
            this.comB_Loai.Items.AddRange(new object[] {
            "Đoàn viên",
            "Đảng viên",
            "Dân quân tự vệ",
            "Công đoàn viên"});
            this.comB_Loai.Location = new System.Drawing.Point(402, 51);
            this.comB_Loai.Name = "comB_Loai";
            this.comB_Loai.Size = new System.Drawing.Size(195, 31);
            this.comB_Loai.TabIndex = 8;
            // 
            // txt_Ten
            // 
            this.txt_Ten.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_Ten.Location = new System.Drawing.Point(125, 48);
            this.txt_Ten.MaxLength = 30;
            this.txt_Ten.Name = "txt_Ten";
            this.txt_Ten.Size = new System.Drawing.Size(198, 30);
            this.txt_Ten.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.tableLP_ChucVu_ChinhTri.SetColumnSpan(this.groupBox1, 4);
            this.groupBox1.Controls.Add(this.tableLP_DSVanBang);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 302);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 195);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách chức vụ - chính trị";
            // 
            // tableLP_DSVanBang
            // 
            this.tableLP_DSVanBang.ColumnCount = 2;
            this.tableLP_DSVanBang.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.31395F));
            this.tableLP_DSVanBang.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.68604F));
            this.tableLP_DSVanBang.Controls.Add(this.dtgv_DSChucVuDonVi, 0, 0);
            this.tableLP_DSVanBang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLP_DSVanBang.Location = new System.Drawing.Point(3, 26);
            this.tableLP_DSVanBang.Name = "tableLP_DSVanBang";
            this.tableLP_DSVanBang.RowCount = 1;
            this.tableLP_DSVanBang.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLP_DSVanBang.Size = new System.Drawing.Size(588, 166);
            this.tableLP_DSVanBang.TabIndex = 0;
            // 
            // dtgv_DSChucVuDonVi
            // 
            this.dtgv_DSChucVuDonVi.AllowUserToAddRows = false;
            this.dtgv_DSChucVuDonVi.AllowUserToDeleteRows = false;
            this.dtgv_DSChucVuDonVi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLP_DSVanBang.SetColumnSpan(this.dtgv_DSChucVuDonVi, 2);
            this.dtgv_DSChucVuDonVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgv_DSChucVuDonVi.Location = new System.Drawing.Point(3, 3);
            this.dtgv_DSChucVuDonVi.MultiSelect = false;
            this.dtgv_DSChucVuDonVi.Name = "dtgv_DSChucVuDonVi";
            this.dtgv_DSChucVuDonVi.ReadOnly = true;
            this.dtgv_DSChucVuDonVi.RowTemplate.Height = 24;
            this.dtgv_DSChucVuDonVi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgv_DSChucVuDonVi.Size = new System.Drawing.Size(582, 160);
            this.dtgv_DSChucVuDonVi.TabIndex = 1;
            this.dtgv_DSChucVuDonVi.SelectionChanged += new System.EventHandler(this.dtgv_DSChucVuDonVi_SelectionChanged);
            // 
            // groupBox2
            // 
            this.tableLP_ChucVu_ChinhTri.SetColumnSpan(this.groupBox2, 4);
            this.groupBox2.Controls.Add(this.tableLP_ThaoTac);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 131);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(594, 164);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thao tác";
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
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên chức vụ";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(329, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Loại";
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
            this.tableLP_ThaoTac.Location = new System.Drawing.Point(3, 27);
            this.tableLP_ThaoTac.Name = "tableLP_ThaoTac";
            this.tableLP_ThaoTac.RowCount = 1;
            this.tableLP_ThaoTac.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLP_ThaoTac.Size = new System.Drawing.Size(588, 133);
            this.tableLP_ThaoTac.TabIndex = 1;
            // 
            // btn_Huy
            // 
            this.btn_Huy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Huy.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Huy.ImageKey = "Cancel.png";
            this.btn_Huy.ImageList = this.imageList1;
            this.btn_Huy.Location = new System.Drawing.Point(381, 38);
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(56, 56);
            this.btn_Huy.TabIndex = 5;
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
            this.btn_Them.Location = new System.Drawing.Point(30, 38);
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
            this.btn_Luu.Location = new System.Drawing.Point(264, 38);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(56, 56);
            this.btn_Luu.TabIndex = 4;
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
            this.btn_Xoa.Location = new System.Drawing.Point(500, 38);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(56, 56);
            this.btn_Xoa.TabIndex = 2;
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
            this.btn_Sua.Location = new System.Drawing.Point(147, 38);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(56, 56);
            this.btn_Sua.TabIndex = 3;
            this.btn_Sua.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Sua.UseVisualStyleBackColor = true;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // QLNS_ChucVu_ChinhTri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.tableLP_ChucVu_ChinhTri);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "QLNS_ChucVu_ChinhTri";
            this.Size = new System.Drawing.Size(600, 500);
            this.Load += new System.EventHandler(this.QLNS_ChucVu_ChinhTri_Load);
            this.tableLP_ChucVu_ChinhTri.ResumeLayout(false);
            this.tableLP_ChucVu_ChinhTri.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLP_DSVanBang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_DSChucVuDonVi)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLP_ThaoTac.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLP_ChucVu_ChinhTri;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLP_DSVanBang;
        private System.Windows.Forms.DataGridView dtgv_DSChucVuDonVi;
        private System.Windows.Forms.TextBox txt_Ten;
        private System.Windows.Forms.ComboBox comB_Loai;
        private System.Windows.Forms.TableLayoutPanel tableLP_ThaoTac;
        private System.Windows.Forms.Button btn_Huy;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Button btn_Luu;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Sua;
    }
}
