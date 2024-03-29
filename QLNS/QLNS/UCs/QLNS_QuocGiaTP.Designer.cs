﻿namespace QLNS.UCs
{
    partial class QLNS_QuocGiaTP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QLNS_QuocGiaTP));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMI_ThemQuocGia = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_ThemTP = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLP_Ngach_NhomNgach = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TreeV_QuocGiaTP = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLP_ThongTin = new System.Windows.Forms.TableLayoutPanel();
            this.txt_Ten = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comB_QuocGia = new System.Windows.Forms.ComboBox();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Luu = new System.Windows.Forms.Button();
            this.btn_Huy = new System.Windows.Forms.Button();
            this.btn_Them = new wyDay.Controls.SplitButton();
            this.contextMenuStrip1.SuspendLayout();
            this.tableLP_Ngach_NhomNgach.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLP_ThongTin.SuspendLayout();
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_ThemQuocGia,
            this.TSMI_ThemTP});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(187, 52);
            // 
            // TSMI_ThemQuocGia
            // 
            this.TSMI_ThemQuocGia.Name = "TSMI_ThemQuocGia";
            this.TSMI_ThemQuocGia.Size = new System.Drawing.Size(186, 24);
            this.TSMI_ThemQuocGia.Text = "Thêm quốc gia";
            this.TSMI_ThemQuocGia.Click += new System.EventHandler(this.TSMI_ThemQuocGia_Click);
            // 
            // TSMI_ThemTP
            // 
            this.TSMI_ThemTP.Name = "TSMI_ThemTP";
            this.TSMI_ThemTP.Size = new System.Drawing.Size(186, 24);
            this.TSMI_ThemTP.Text = "Thêm thành phố";
            this.TSMI_ThemTP.Click += new System.EventHandler(this.TSMI_ThemTP_Click);
            // 
            // tableLP_Ngach_NhomNgach
            // 
            this.tableLP_Ngach_NhomNgach.ColumnCount = 4;
            this.tableLP_Ngach_NhomNgach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLP_Ngach_NhomNgach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLP_Ngach_NhomNgach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLP_Ngach_NhomNgach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLP_Ngach_NhomNgach.Controls.Add(this.groupBox1, 0, 0);
            this.tableLP_Ngach_NhomNgach.Controls.Add(this.groupBox2, 1, 0);
            this.tableLP_Ngach_NhomNgach.Controls.Add(this.btn_Sua, 2, 3);
            this.tableLP_Ngach_NhomNgach.Controls.Add(this.btn_Xoa, 3, 3);
            this.tableLP_Ngach_NhomNgach.Controls.Add(this.btn_Luu, 1, 4);
            this.tableLP_Ngach_NhomNgach.Controls.Add(this.btn_Huy, 3, 4);
            this.tableLP_Ngach_NhomNgach.Controls.Add(this.btn_Them, 1, 3);
            this.tableLP_Ngach_NhomNgach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLP_Ngach_NhomNgach.Location = new System.Drawing.Point(0, 0);
            this.tableLP_Ngach_NhomNgach.Name = "tableLP_Ngach_NhomNgach";
            this.tableLP_Ngach_NhomNgach.RowCount = 5;
            this.tableLP_Ngach_NhomNgach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.89362F));
            this.tableLP_Ngach_NhomNgach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.89362F));
            this.tableLP_Ngach_NhomNgach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.89362F));
            this.tableLP_Ngach_NhomNgach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.65957F));
            this.tableLP_Ngach_NhomNgach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.65957F));
            this.tableLP_Ngach_NhomNgach.Size = new System.Drawing.Size(782, 425);
            this.tableLP_Ngach_NhomNgach.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TreeV_QuocGiaTP);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Turquoise;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.tableLP_Ngach_NhomNgach.SetRowSpan(this.groupBox1, 5);
            this.groupBox1.Size = new System.Drawing.Size(306, 419);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quốc gia - Thành phố";
            // 
            // TreeV_QuocGiaTP
            // 
            this.TreeV_QuocGiaTP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeV_QuocGiaTP.Location = new System.Drawing.Point(3, 25);
            this.TreeV_QuocGiaTP.Name = "TreeV_QuocGiaTP";
            this.TreeV_QuocGiaTP.Size = new System.Drawing.Size(300, 391);
            this.TreeV_QuocGiaTP.TabIndex = 1;
            this.TreeV_QuocGiaTP.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeV_QuocGiaTP_NodeMouseDoubleClick);
            // 
            // groupBox2
            // 
            this.tableLP_Ngach_NhomNgach.SetColumnSpan(this.groupBox2, 3);
            this.groupBox2.Controls.Add(this.tableLP_ThongTin);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Turquoise;
            this.groupBox2.Location = new System.Drawing.Point(315, 3);
            this.groupBox2.Name = "groupBox2";
            this.tableLP_Ngach_NhomNgach.SetRowSpan(this.groupBox2, 3);
            this.groupBox2.Size = new System.Drawing.Size(464, 183);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin";
            // 
            // tableLP_ThongTin
            // 
            this.tableLP_ThongTin.ColumnCount = 2;
            this.tableLP_ThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.74603F));
            this.tableLP_ThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.25397F));
            this.tableLP_ThongTin.Controls.Add(this.txt_Ten, 1, 0);
            this.tableLP_ThongTin.Controls.Add(this.label3, 0, 1);
            this.tableLP_ThongTin.Controls.Add(this.label1, 0, 0);
            this.tableLP_ThongTin.Controls.Add(this.comB_QuocGia, 1, 1);
            this.tableLP_ThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLP_ThongTin.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLP_ThongTin.Location = new System.Drawing.Point(3, 25);
            this.tableLP_ThongTin.Name = "tableLP_ThongTin";
            this.tableLP_ThongTin.RowCount = 2;
            this.tableLP_ThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLP_ThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLP_ThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLP_ThongTin.Size = new System.Drawing.Size(458, 155);
            this.tableLP_ThongTin.TabIndex = 0;
            // 
            // txt_Ten
            // 
            this.txt_Ten.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_Ten.Enabled = false;
            this.txt_Ten.Location = new System.Drawing.Point(148, 24);
            this.txt_Ten.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txt_Ten.Name = "txt_Ten";
            this.txt_Ten.Size = new System.Drawing.Size(253, 29);
            this.txt_Ten.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(3, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Quốc gia";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(3, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tên";
            // 
            // comB_QuocGia
            // 
            this.comB_QuocGia.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comB_QuocGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_QuocGia.Enabled = false;
            this.comB_QuocGia.FormattingEnabled = true;
            this.comB_QuocGia.Items.AddRange(new object[] {
            "Biên chế",
            "Hợp đồng"});
            this.comB_QuocGia.Location = new System.Drawing.Point(148, 103);
            this.comB_QuocGia.Name = "comB_QuocGia";
            this.comB_QuocGia.Size = new System.Drawing.Size(253, 30);
            this.comB_QuocGia.TabIndex = 7;
            // 
            // btn_Sua
            // 
            this.btn_Sua.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Sua.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Sua.ImageKey = "Edit Data.png";
            this.btn_Sua.ImageList = this.imageList1;
            this.btn_Sua.Location = new System.Drawing.Point(514, 215);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(63, 65);
            this.btn_Sua.TabIndex = 4;
            this.btn_Sua.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Sua.UseVisualStyleBackColor = true;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Xoa.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Xoa.ImageKey = "Garbage.png";
            this.btn_Xoa.ImageList = this.imageList1;
            this.btn_Xoa.Location = new System.Drawing.Point(671, 215);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(63, 65);
            this.btn_Xoa.TabIndex = 7;
            this.btn_Xoa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_Luu
            // 
            this.btn_Luu.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_Luu.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Luu.ImageKey = "Save.png";
            this.btn_Luu.ImageList = this.imageList1;
            this.btn_Luu.Location = new System.Drawing.Point(402, 333);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(63, 65);
            this.btn_Luu.TabIndex = 5;
            this.btn_Luu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Luu.UseVisualStyleBackColor = true;
            this.btn_Luu.Visible = false;
            this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);
            // 
            // btn_Huy
            // 
            this.btn_Huy.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_Huy.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Huy.ImageKey = "Cancel.png";
            this.btn_Huy.ImageList = this.imageList1;
            this.btn_Huy.Location = new System.Drawing.Point(627, 333);
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(63, 65);
            this.btn_Huy.TabIndex = 6;
            this.btn_Huy.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Huy.UseVisualStyleBackColor = true;
            this.btn_Huy.Visible = false;
            this.btn_Huy.Click += new System.EventHandler(this.btn_Huy_Click);
            // 
            // btn_Them
            // 
            this.btn_Them.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Them.AutoSize = true;
            this.btn_Them.ContextMenuStrip = this.contextMenuStrip1;
            this.btn_Them.ImageKey = "Add.png";
            this.btn_Them.ImageList = this.imageList1;
            this.btn_Them.Location = new System.Drawing.Point(350, 216);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(80, 62);
            this.btn_Them.SplitMenuStrip = this.contextMenuStrip1;
            this.btn_Them.TabIndex = 8;
            this.btn_Them.UseVisualStyleBackColor = true;
            // 
            // QLNS_QuocGiaTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.tableLP_Ngach_NhomNgach);
            this.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "QLNS_QuocGiaTP";
            this.Size = new System.Drawing.Size(782, 425);
            this.Load += new System.EventHandler(this.QLNS_QuocGiaTP_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tableLP_Ngach_NhomNgach.ResumeLayout(false);
            this.tableLP_Ngach_NhomNgach.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLP_ThongTin.ResumeLayout(false);
            this.tableLP_ThongTin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TSMI_ThemQuocGia;
        private System.Windows.Forms.ToolStripMenuItem TSMI_ThemTP;
        private System.Windows.Forms.TableLayoutPanel tableLP_Ngach_NhomNgach;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView TreeV_QuocGiaTP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLP_ThongTin;
        private System.Windows.Forms.TextBox txt_Ten;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comB_QuocGia;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Luu;
        private System.Windows.Forms.Button btn_Huy;
        private wyDay.Controls.SplitButton btn_Them;
    }
}
