﻿namespace QLNS.UCs
{
    partial class QLNS_LoaiDonVi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QLNS_LoaiDonVi));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLP_DonVi = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLP_ThaoTac = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Huy = new System.Windows.Forms.Button();
            this.btn_Them = new System.Windows.Forms.Button();
            this.btn_Luu = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLP_DSVanBang = new System.Windows.Forms.TableLayoutPanel();
            this.dtgv_DSLoaiDonVi = new System.Windows.Forms.DataGridView();
            this.tableLP_ChiTietDonVi = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Ten = new System.Windows.Forms.TextBox();
            this.tableLP_DonVi.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLP_ThaoTac.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLP_DSVanBang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_DSLoaiDonVi)).BeginInit();
            this.tableLP_ChiTietDonVi.SuspendLayout();
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
            // tableLP_DonVi
            // 
            this.tableLP_DonVi.ColumnCount = 2;
            this.tableLP_DonVi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLP_DonVi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLP_DonVi.Controls.Add(this.groupBox2, 0, 1);
            this.tableLP_DonVi.Controls.Add(this.groupBox1, 0, 2);
            this.tableLP_DonVi.Controls.Add(this.tableLP_ChiTietDonVi, 0, 0);
            this.tableLP_DonVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLP_DonVi.Location = new System.Drawing.Point(0, 0);
            this.tableLP_DonVi.Name = "tableLP_DonVi";
            this.tableLP_DonVi.RowCount = 3;
            this.tableLP_DonVi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.92523F));
            this.tableLP_DonVi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.60748F));
            this.tableLP_DonVi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.46729F));
            this.tableLP_DonVi.Size = new System.Drawing.Size(797, 428);
            this.tableLP_DonVi.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.tableLP_DonVi.SetColumnSpan(this.groupBox2, 2);
            this.groupBox2.Controls.Add(this.tableLP_ThaoTac);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 84);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(791, 123);
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
            this.tableLP_ThaoTac.Location = new System.Drawing.Point(3, 26);
            this.tableLP_ThaoTac.Name = "tableLP_ThaoTac";
            this.tableLP_ThaoTac.RowCount = 1;
            this.tableLP_ThaoTac.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLP_ThaoTac.Size = new System.Drawing.Size(785, 93);
            this.tableLP_ThaoTac.TabIndex = 1;
            // 
            // btn_Huy
            // 
            this.btn_Huy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Huy.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Huy.ImageKey = "Cancel.png";
            this.btn_Huy.ImageList = this.imageList1;
            this.btn_Huy.Location = new System.Drawing.Point(521, 18);
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
            this.btn_Them.Location = new System.Drawing.Point(50, 18);
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
            this.btn_Luu.Location = new System.Drawing.Point(364, 18);
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
            this.btn_Xoa.Location = new System.Drawing.Point(678, 18);
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
            this.btn_Sua.Location = new System.Drawing.Point(207, 18);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(56, 56);
            this.btn_Sua.TabIndex = 1;
            this.btn_Sua.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Sua.UseVisualStyleBackColor = true;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // groupBox1
            // 
            this.tableLP_DonVi.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.tableLP_DSVanBang);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 214);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(791, 211);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách loại đơn vị";
            // 
            // tableLP_DSVanBang
            // 
            this.tableLP_DSVanBang.ColumnCount = 2;
            this.tableLP_DSVanBang.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.31395F));
            this.tableLP_DSVanBang.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.68604F));
            this.tableLP_DSVanBang.Controls.Add(this.dtgv_DSLoaiDonVi, 0, 0);
            this.tableLP_DSVanBang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLP_DSVanBang.Location = new System.Drawing.Point(3, 25);
            this.tableLP_DSVanBang.Name = "tableLP_DSVanBang";
            this.tableLP_DSVanBang.RowCount = 2;
            this.tableLP_DSVanBang.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLP_DSVanBang.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLP_DSVanBang.Size = new System.Drawing.Size(785, 183);
            this.tableLP_DSVanBang.TabIndex = 0;
            // 
            // dtgv_DSLoaiDonVi
            // 
            this.dtgv_DSLoaiDonVi.AllowUserToAddRows = false;
            this.dtgv_DSLoaiDonVi.AllowUserToDeleteRows = false;
            this.dtgv_DSLoaiDonVi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLP_DSVanBang.SetColumnSpan(this.dtgv_DSLoaiDonVi, 2);
            this.dtgv_DSLoaiDonVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgv_DSLoaiDonVi.Location = new System.Drawing.Point(3, 3);
            this.dtgv_DSLoaiDonVi.MultiSelect = false;
            this.dtgv_DSLoaiDonVi.Name = "dtgv_DSLoaiDonVi";
            this.dtgv_DSLoaiDonVi.ReadOnly = true;
            this.dtgv_DSLoaiDonVi.RowTemplate.Height = 24;
            this.dtgv_DSLoaiDonVi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgv_DSLoaiDonVi.Size = new System.Drawing.Size(779, 158);
            this.dtgv_DSLoaiDonVi.TabIndex = 0;
            this.dtgv_DSLoaiDonVi.SelectionChanged += new System.EventHandler(this.dtgv_DSLoaiDonVi_SelectionChanged);
            // 
            // tableLP_ChiTietDonVi
            // 
            this.tableLP_ChiTietDonVi.ColumnCount = 2;
            this.tableLP_DonVi.SetColumnSpan(this.tableLP_ChiTietDonVi, 2);
            this.tableLP_ChiTietDonVi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.12121F));
            this.tableLP_ChiTietDonVi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.21212F));
            this.tableLP_ChiTietDonVi.Controls.Add(this.label1, 0, 0);
            this.tableLP_ChiTietDonVi.Controls.Add(this.txt_Ten, 1, 0);
            this.tableLP_ChiTietDonVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLP_ChiTietDonVi.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLP_ChiTietDonVi.Location = new System.Drawing.Point(3, 3);
            this.tableLP_ChiTietDonVi.Name = "tableLP_ChiTietDonVi";
            this.tableLP_ChiTietDonVi.RowCount = 1;
            this.tableLP_ChiTietDonVi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.91667F));
            this.tableLP_ChiTietDonVi.Size = new System.Drawing.Size(791, 74);
            this.tableLP_ChiTietDonVi.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên loại";
            // 
            // txt_Ten
            // 
            this.txt_Ten.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_Ten.Enabled = false;
            this.txt_Ten.Location = new System.Drawing.Point(290, 22);
            this.txt_Ten.MaxLength = 100;
            this.txt_Ten.Name = "txt_Ten";
            this.txt_Ten.Size = new System.Drawing.Size(348, 29);
            this.txt_Ten.TabIndex = 0;
            // 
            // QLNS_LoaiDonVi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.tableLP_DonVi);
            this.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "QLNS_LoaiDonVi";
            this.Size = new System.Drawing.Size(797, 428);
            this.Load += new System.EventHandler(this.QLNS_LoaiLoaiDonVi_Load);
            this.tableLP_DonVi.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLP_ThaoTac.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLP_DSVanBang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_DSLoaiDonVi)).EndInit();
            this.tableLP_ChiTietDonVi.ResumeLayout(false);
            this.tableLP_ChiTietDonVi.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TableLayoutPanel tableLP_DonVi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLP_ThaoTac;
        private System.Windows.Forms.Button btn_Huy;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Button btn_Luu;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLP_DSVanBang;
        private System.Windows.Forms.DataGridView dtgv_DSLoaiDonVi;
        private System.Windows.Forms.TableLayoutPanel tableLP_ChiTietDonVi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Ten;
    }
}
