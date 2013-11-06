namespace LuongBH.UCs.Luong
{
    partial class NgayCong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NgayCong));
            this.TLP_NgayCong = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dtgv_ThongTinNP = new System.Windows.Forms.DataGridView();
            this.btn_Them = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dtp_DenThang = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_SoNgayCong = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtp_TuThang = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.rtb_GhiChu = new System.Windows.Forms.RichTextBox();
            this.TLP_NgayCong.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_ThongTinNP)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLP_NgayCong
            // 
            this.TLP_NgayCong.ColumnCount = 1;
            this.TLP_NgayCong.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_NgayCong.Controls.Add(this.groupBox4, 0, 0);
            this.TLP_NgayCong.Controls.Add(this.btn_Them, 0, 2);
            this.TLP_NgayCong.Controls.Add(this.groupBox1, 0, 1);
            this.TLP_NgayCong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_NgayCong.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.TLP_NgayCong.Location = new System.Drawing.Point(0, 0);
            this.TLP_NgayCong.Name = "TLP_NgayCong";
            this.TLP_NgayCong.RowCount = 3;
            this.TLP_NgayCong.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.74263F));
            this.TLP_NgayCong.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.05894F));
            this.TLP_NgayCong.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.19843F));
            this.TLP_NgayCong.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP_NgayCong.Size = new System.Drawing.Size(718, 509);
            this.TLP_NgayCong.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dtgv_ThongTinNP);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(712, 293);
            this.groupBox4.TabIndex = 63;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thông tin ngày công nhân viên";
            // 
            // dtgv_ThongTinNP
            // 
            this.dtgv_ThongTinNP.AllowUserToAddRows = false;
            this.dtgv_ThongTinNP.AllowUserToDeleteRows = false;
            this.dtgv_ThongTinNP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_ThongTinNP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgv_ThongTinNP.Location = new System.Drawing.Point(3, 24);
            this.dtgv_ThongTinNP.Name = "dtgv_ThongTinNP";
            this.dtgv_ThongTinNP.ReadOnly = true;
            this.dtgv_ThongTinNP.RowTemplate.Height = 24;
            this.dtgv_ThongTinNP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgv_ThongTinNP.Size = new System.Drawing.Size(706, 266);
            this.dtgv_ThongTinNP.TabIndex = 0;
            this.dtgv_ThongTinNP.SelectionChanged += new System.EventHandler(this.dtgv_ThongTinNP_SelectionChanged);
            // 
            // btn_Them
            // 
            this.btn_Them.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Them.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Them.ImageKey = "Save.png";
            this.btn_Them.ImageList = this.imageList1;
            this.btn_Them.Location = new System.Drawing.Point(331, 454);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(56, 52);
            this.btn_Them.TabIndex = 61;
            this.btn_Them.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Save.png");
            this.imageList1.Images.SetKeyName(1, "Document-Add.png");
            this.imageList1.Images.SetKeyName(2, "ArrowHead-Right.png");
            this.imageList1.Images.SetKeyName(3, "Follow Right.png");
            this.imageList1.Images.SetKeyName(4, "Search.png");
            this.imageList1.Images.SetKeyName(5, "Remove Avatar.png");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBox1.Location = new System.Drawing.Point(3, 302);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(712, 146);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin ngày công";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.74788F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.39377F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.dtp_DenThang, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txt_SoNgayCong, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label7, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtp_TuThang, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.rtb_GhiChu, 3, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 24);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(706, 119);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dtp_DenThang
            // 
            this.dtp_DenThang.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtp_DenThang.CustomFormat = "MM/yyyy";
            this.dtp_DenThang.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_DenThang.Location = new System.Drawing.Point(444, 15);
            this.dtp_DenThang.Name = "dtp_DenThang";
            this.dtp_DenThang.Size = new System.Drawing.Size(200, 28);
            this.dtp_DenThang.TabIndex = 60;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 21);
            this.label3.TabIndex = 47;
            this.label3.Text = "Từ tháng";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 21);
            this.label8.TabIndex = 49;
            this.label8.Text = "Số ngày công";
            // 
            // txt_SoNgayCong
            // 
            this.txt_SoNgayCong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_SoNgayCong.Location = new System.Drawing.Point(179, 75);
            this.txt_SoNgayCong.Name = "txt_SoNgayCong";
            this.txt_SoNgayCong.Size = new System.Drawing.Size(170, 28);
            this.txt_SoNgayCong.TabIndex = 58;
            this.txt_SoNgayCong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_SoNgayCong_KeyPress);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(355, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 21);
            this.label7.TabIndex = 48;
            this.label7.Text = "Đến tháng";
            // 
            // dtp_TuThang
            // 
            this.dtp_TuThang.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtp_TuThang.CustomFormat = "MM/yyyy";
            this.dtp_TuThang.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_TuThang.Location = new System.Drawing.Point(179, 15);
            this.dtp_TuThang.Name = "dtp_TuThang";
            this.dtp_TuThang.Size = new System.Drawing.Size(170, 28);
            this.dtp_TuThang.TabIndex = 59;
            this.dtp_TuThang.ValueChanged += new System.EventHandler(this.dtp_TuThang_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(364, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 21);
            this.label1.TabIndex = 61;
            this.label1.Text = "Ghi Chú";
            // 
            // rtb_GhiChu
            // 
            this.rtb_GhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_GhiChu.Location = new System.Drawing.Point(444, 62);
            this.rtb_GhiChu.Name = "rtb_GhiChu";
            this.rtb_GhiChu.Size = new System.Drawing.Size(259, 54);
            this.rtb_GhiChu.TabIndex = 62;
            this.rtb_GhiChu.Text = "";
            // 
            // NgayCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.TLP_NgayCong);
            this.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "NgayCong";
            this.Size = new System.Drawing.Size(718, 509);
            this.Load += new System.EventHandler(this.NgayCong_Load);
            this.TLP_NgayCong.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_ThongTinNP)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLP_NgayCong;
        public System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_SoNgayCong;
        private System.Windows.Forms.DateTimePicker dtp_TuThang;
        private System.Windows.Forms.DateTimePicker dtp_DenThang;
        public System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dtgv_ThongTinNP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtb_GhiChu;
    }
}
