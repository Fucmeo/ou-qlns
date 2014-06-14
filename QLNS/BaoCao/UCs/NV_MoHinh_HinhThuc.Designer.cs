namespace BaoCao.UCs
{
    partial class NV_MoHinh_HinhThuc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NV_MoHinh_HinhThuc));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.gp_ThongTinFilter = new System.Windows.Forms.GroupBox();
            this.TLP_ThongTinBH = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.clb_MoHinh = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.clb_HinhThuc = new System.Windows.Forms.CheckedListBox();
            this.btn_BaoCao = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gp_ThongTinFilter.SuspendLayout();
            this.TLP_ThongTinBH.SuspendLayout();
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.63354F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.521739F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.94824F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.gp_ThongTinFilter, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_BaoCao, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.80991F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.19009F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(966, 747);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.crystalReportViewer1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBox1.Location = new System.Drawing.Point(244, 3);
            this.groupBox1.Name = "groupBox1";
            this.tableLayoutPanel1.SetRowSpan(this.groupBox1, 2);
            this.groupBox1.Size = new System.Drawing.Size(719, 741);
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
            this.crystalReportViewer1.Size = new System.Drawing.Size(713, 713);
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
            this.gp_ThongTinFilter.Size = new System.Drawing.Size(235, 634);
            this.gp_ThongTinFilter.TabIndex = 15;
            this.gp_ThongTinFilter.TabStop = false;
            this.gp_ThongTinFilter.Text = "Thông tin mô hình đào tạo - hình thức đào tạo";
            // 
            // TLP_ThongTinBH
            // 
            this.TLP_ThongTinBH.ColumnCount = 2;
            this.TLP_ThongTinBH.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.99127F));
            this.TLP_ThongTinBH.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.00873F));
            this.TLP_ThongTinBH.Controls.Add(this.label5, 0, 0);
            this.TLP_ThongTinBH.Controls.Add(this.clb_MoHinh, 1, 0);
            this.TLP_ThongTinBH.Controls.Add(this.label2, 0, 1);
            this.TLP_ThongTinBH.Controls.Add(this.clb_HinhThuc, 1, 1);
            this.TLP_ThongTinBH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_ThongTinBH.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TLP_ThongTinBH.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TLP_ThongTinBH.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.TLP_ThongTinBH.Location = new System.Drawing.Point(3, 25);
            this.TLP_ThongTinBH.Name = "TLP_ThongTinBH";
            this.TLP_ThongTinBH.RowCount = 2;
            this.TLP_ThongTinBH.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_ThongTinBH.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_ThongTinBH.Size = new System.Drawing.Size(229, 606);
            this.TLP_ThongTinBH.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 46);
            this.label5.TabIndex = 15;
            this.label5.Text = "Mô hình đào tạo";
            // 
            // clb_MoHinh
            // 
            this.clb_MoHinh.CheckOnClick = true;
            this.clb_MoHinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clb_MoHinh.FormattingEnabled = true;
            this.clb_MoHinh.HorizontalScrollbar = true;
            this.clb_MoHinh.Location = new System.Drawing.Point(90, 3);
            this.clb_MoHinh.Name = "clb_MoHinh";
            this.clb_MoHinh.Size = new System.Drawing.Size(136, 297);
            this.clb_MoHinh.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 420);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 69);
            this.label2.TabIndex = 17;
            this.label2.Text = "Hình thức đào tạo";
            // 
            // clb_HinhThuc
            // 
            this.clb_HinhThuc.CheckOnClick = true;
            this.clb_HinhThuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clb_HinhThuc.FormattingEnabled = true;
            this.clb_HinhThuc.HorizontalScrollbar = true;
            this.clb_HinhThuc.Location = new System.Drawing.Point(90, 306);
            this.clb_HinhThuc.Name = "clb_HinhThuc";
            this.clb_HinhThuc.Size = new System.Drawing.Size(136, 297);
            this.clb_HinhThuc.TabIndex = 24;
            // 
            // btn_BaoCao
            // 
            this.btn_BaoCao.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableLayoutPanel1.SetColumnSpan(this.btn_BaoCao, 2);
            this.btn_BaoCao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_BaoCao.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_BaoCao.ImageKey = "Report.png";
            this.btn_BaoCao.ImageList = this.imageList1;
            this.btn_BaoCao.Location = new System.Drawing.Point(95, 644);
            this.btn_BaoCao.Name = "btn_BaoCao";
            this.btn_BaoCao.Size = new System.Drawing.Size(50, 50);
            this.btn_BaoCao.TabIndex = 21;
            this.btn_BaoCao.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_BaoCao.UseVisualStyleBackColor = true;
            this.btn_BaoCao.Click += new System.EventHandler(this.btn_BaoCao_Click);
            // 
            // NV_MoHinh_HinhThuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "NV_MoHinh_HinhThuc";
            this.Size = new System.Drawing.Size(966, 747);
            this.Load += new System.EventHandler(this.NV_MoHinh_HinhThuc_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.gp_ThongTinFilter.ResumeLayout(false);
            this.TLP_ThongTinBH.ResumeLayout(false);
            this.TLP_ThongTinBH.PerformLayout();
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
        private System.Windows.Forms.CheckedListBox clb_MoHinh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox clb_HinhThuc;
        private System.Windows.Forms.Button btn_BaoCao;
    }
}
