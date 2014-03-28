namespace BaoCao.UCs
{
    partial class NVTheo_LoaiHD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NVTheo_LoaiHD));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.gp_ThongTinFilter = new System.Windows.Forms.GroupBox();
            this.TLP_ThongTinBH = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.clb_LoaiHD = new System.Windows.Forms.CheckedListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp_DenNgay = new System.Windows.Forms.DateTimePicker();
            this.dtp_TuNgay = new System.Windows.Forms.DateTimePicker();
            this.btn_BaoCao = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gp_ThongTinFilter.SuspendLayout();
            this.TLP_ThongTinBH.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Report.png");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00001F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.277831F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.79353F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.gp_ThongTinFilter, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.23844F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.76156F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1051, 822);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.crystalReportViewer1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBox1.Location = new System.Drawing.Point(351, 3);
            this.groupBox1.Name = "groupBox1";
            this.tableLayoutPanel1.SetRowSpan(this.groupBox1, 2);
            this.groupBox1.Size = new System.Drawing.Size(697, 816);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Báo cáo";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(3, 25);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ShowCloseButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(691, 788);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // gp_ThongTinFilter
            // 
            this.gp_ThongTinFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.gp_ThongTinFilter, 2);
            this.gp_ThongTinFilter.Controls.Add(this.TLP_ThongTinBH);
            this.gp_ThongTinFilter.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gp_ThongTinFilter.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.gp_ThongTinFilter.Location = new System.Drawing.Point(3, 3);
            this.gp_ThongTinFilter.Name = "gp_ThongTinFilter";
            this.tableLayoutPanel1.SetRowSpan(this.gp_ThongTinFilter, 2);
            this.gp_ThongTinFilter.Size = new System.Drawing.Size(342, 686);
            this.gp_ThongTinFilter.TabIndex = 15;
            this.gp_ThongTinFilter.TabStop = false;
            this.gp_ThongTinFilter.Text = "Thông tin loại hợp đồng";
            // 
            // TLP_ThongTinBH
            // 
            this.TLP_ThongTinBH.ColumnCount = 3;
            this.TLP_ThongTinBH.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.6398F));
            this.TLP_ThongTinBH.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.4534F));
            this.TLP_ThongTinBH.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.15869F));
            this.TLP_ThongTinBH.Controls.Add(this.label5, 0, 0);
            this.TLP_ThongTinBH.Controls.Add(this.clb_LoaiHD, 1, 0);
            this.TLP_ThongTinBH.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.TLP_ThongTinBH.Controls.Add(this.btn_BaoCao, 2, 0);
            this.TLP_ThongTinBH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_ThongTinBH.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TLP_ThongTinBH.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TLP_ThongTinBH.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.TLP_ThongTinBH.Location = new System.Drawing.Point(3, 25);
            this.TLP_ThongTinBH.Name = "TLP_ThongTinBH";
            this.TLP_ThongTinBH.RowCount = 2;
            this.TLP_ThongTinBH.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.47059F));
            this.TLP_ThongTinBH.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.52941F));
            this.TLP_ThongTinBH.Size = new System.Drawing.Size(336, 658);
            this.TLP_ThongTinBH.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 69);
            this.label5.TabIndex = 15;
            this.label5.Text = "Loại hợp đồng";
            // 
            // clb_LoaiHD
            // 
            this.clb_LoaiHD.CheckOnClick = true;
            this.clb_LoaiHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clb_LoaiHD.FormattingEnabled = true;
            this.clb_LoaiHD.HorizontalScrollbar = true;
            this.clb_LoaiHD.Location = new System.Drawing.Point(65, 3);
            this.clb_LoaiHD.Name = "clb_LoaiHD";
            this.clb_LoaiHD.Size = new System.Drawing.Size(196, 365);
            this.clb_LoaiHD.TabIndex = 23;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.TLP_ThongTinBH.SetColumnSpan(this.tableLayoutPanel2, 3);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.85166F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.14834F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.dtp_DenNgay, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.dtp_TuNgay, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 374);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(330, 281);
            this.tableLayoutPanel2.TabIndex = 67;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 23);
            this.label1.TabIndex = 62;
            this.label1.Text = "Từ ngày";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 23);
            this.label3.TabIndex = 63;
            this.label3.Text = "Đến ngày";
            // 
            // dtp_DenNgay
            // 
            this.dtp_DenNgay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtp_DenNgay.Checked = false;
            this.dtp_DenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtp_DenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_DenNgay.Location = new System.Drawing.Point(127, 196);
            this.dtp_DenNgay.Name = "dtp_DenNgay";
            this.dtp_DenNgay.ShowCheckBox = true;
            this.dtp_DenNgay.Size = new System.Drawing.Size(140, 29);
            this.dtp_DenNgay.TabIndex = 65;
            // 
            // dtp_TuNgay
            // 
            this.dtp_TuNgay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtp_TuNgay.Checked = false;
            this.dtp_TuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtp_TuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_TuNgay.Location = new System.Drawing.Point(127, 55);
            this.dtp_TuNgay.Name = "dtp_TuNgay";
            this.dtp_TuNgay.ShowCheckBox = true;
            this.dtp_TuNgay.Size = new System.Drawing.Size(140, 29);
            this.dtp_TuNgay.TabIndex = 64;
            // 
            // btn_BaoCao
            // 
            this.btn_BaoCao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_BaoCao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_BaoCao.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_BaoCao.ImageKey = "Report.png";
            this.btn_BaoCao.ImageList = this.imageList1;
            this.btn_BaoCao.Location = new System.Drawing.Point(267, 153);
            this.btn_BaoCao.Name = "btn_BaoCao";
            this.btn_BaoCao.Size = new System.Drawing.Size(65, 65);
            this.btn_BaoCao.TabIndex = 66;
            this.btn_BaoCao.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_BaoCao.UseVisualStyleBackColor = true;
            this.btn_BaoCao.Click += new System.EventHandler(this.btn_BaoCao_Click);
            // 
            // NVTheo_LoaiHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "NVTheo_LoaiHD";
            this.Size = new System.Drawing.Size(1051, 822);
            this.Load += new System.EventHandler(this.NVTheo_LoaiHD_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.gp_ThongTinFilter.ResumeLayout(false);
            this.TLP_ThongTinBH.ResumeLayout(false);
            this.TLP_ThongTinBH.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.GroupBox gp_ThongTinFilter;
        private System.Windows.Forms.TableLayoutPanel TLP_ThongTinBH;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox clb_LoaiHD;
        private System.Windows.Forms.DateTimePicker dtp_DenNgay;
        private System.Windows.Forms.DateTimePicker dtp_TuNgay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_BaoCao;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
