namespace HDQD.UCs.Luong
{
    partial class NhomNgach
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NhomNgach));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLP_ChucDanh = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLP_DSChucDanh = new System.Windows.Forms.TableLayoutPanel();
            this.dtgv_DSNhomNgach = new System.Windows.Forms.DataGridView();
            this.tableLP_ChiTietChucDanh = new System.Windows.Forms.TableLayoutPanel();
            this.txt_NhomNgach = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLP_ThaoTac = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Huy = new System.Windows.Forms.Button();
            this.btn_Them = new System.Windows.Forms.Button();
            this.btn_Luu = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.tableLP_ChucDanh.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLP_DSChucDanh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_DSNhomNgach)).BeginInit();
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
            this.tableLP_ChucDanh.TabIndex = 1;
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
            this.groupBox1.Text = "Danh sách nhóm ngạch";
            // 
            // tableLP_DSChucDanh
            // 
            this.tableLP_DSChucDanh.ColumnCount = 2;
            this.tableLP_DSChucDanh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.63953F));
            this.tableLP_DSChucDanh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.36047F));
            this.tableLP_DSChucDanh.Controls.Add(this.dtgv_DSNhomNgach, 0, 0);
            this.tableLP_DSChucDanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLP_DSChucDanh.Location = new System.Drawing.Point(3, 24);
            this.tableLP_DSChucDanh.Name = "tableLP_DSChucDanh";
            this.tableLP_DSChucDanh.RowCount = 1;
            this.tableLP_DSChucDanh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.9624F));
            this.tableLP_DSChucDanh.Size = new System.Drawing.Size(638, 267);
            this.tableLP_DSChucDanh.TabIndex = 0;
            // 
            // dtgv_DSNhomNgach
            // 
            this.dtgv_DSNhomNgach.AllowUserToAddRows = false;
            this.dtgv_DSNhomNgach.AllowUserToDeleteRows = false;
            this.dtgv_DSNhomNgach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLP_DSChucDanh.SetColumnSpan(this.dtgv_DSNhomNgach, 2);
            this.dtgv_DSNhomNgach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgv_DSNhomNgach.Location = new System.Drawing.Point(3, 3);
            this.dtgv_DSNhomNgach.Name = "dtgv_DSNhomNgach";
            this.dtgv_DSNhomNgach.ReadOnly = true;
            this.dtgv_DSNhomNgach.RowTemplate.Height = 24;
            this.dtgv_DSNhomNgach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgv_DSNhomNgach.Size = new System.Drawing.Size(632, 261);
            this.dtgv_DSNhomNgach.TabIndex = 0;
            // 
            // tableLP_ChiTietChucDanh
            // 
            this.tableLP_ChiTietChucDanh.ColumnCount = 2;
            this.tableLP_ChiTietChucDanh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLP_ChiTietChucDanh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 451F));
            this.tableLP_ChiTietChucDanh.Controls.Add(this.txt_NhomNgach, 1, 0);
            this.tableLP_ChiTietChucDanh.Controls.Add(this.label2, 0, 0);
            this.tableLP_ChiTietChucDanh.Controls.Add(this.groupBox2, 0, 1);
            this.tableLP_ChiTietChucDanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLP_ChiTietChucDanh.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLP_ChiTietChucDanh.Location = new System.Drawing.Point(3, 3);
            this.tableLP_ChiTietChucDanh.Name = "tableLP_ChiTietChucDanh";
            this.tableLP_ChiTietChucDanh.RowCount = 2;
            this.tableLP_ChiTietChucDanh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.32787F));
            this.tableLP_ChiTietChucDanh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.67213F));
            this.tableLP_ChiTietChucDanh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLP_ChiTietChucDanh.Size = new System.Drawing.Size(644, 294);
            this.tableLP_ChiTietChucDanh.TabIndex = 1;
            // 
            // txt_NhomNgach
            // 
            this.txt_NhomNgach.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_NhomNgach.Enabled = false;
            this.txt_NhomNgach.Location = new System.Drawing.Point(196, 30);
            this.txt_NhomNgach.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txt_NhomNgach.Name = "txt_NhomNgach";
            this.txt_NhomNgach.Size = new System.Drawing.Size(360, 28);
            this.txt_NhomNgach.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên nhóm ngạch";
            // 
            // groupBox2
            // 
            this.tableLP_ChiTietChucDanh.SetColumnSpan(this.groupBox2, 2);
            this.groupBox2.Controls.Add(this.tableLP_ThaoTac);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 94);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox2.Size = new System.Drawing.Size(638, 195);
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
            this.tableLP_ThaoTac.Size = new System.Drawing.Size(632, 164);
            this.tableLP_ThaoTac.TabIndex = 0;
            // 
            // btn_Huy
            // 
            this.btn_Huy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Huy.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Huy.ImageKey = "Cancel.png";
            this.btn_Huy.ImageList = this.imageList1;
            this.btn_Huy.Location = new System.Drawing.Point(409, 49);
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(63, 65);
            this.btn_Huy.TabIndex = 3;
            this.btn_Huy.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Huy.UseVisualStyleBackColor = true;
            this.btn_Huy.Visible = false;
            // 
            // btn_Them
            // 
            this.btn_Them.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Them.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Them.ImageKey = "Add.png";
            this.btn_Them.ImageList = this.imageList1;
            this.btn_Them.Location = new System.Drawing.Point(31, 49);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(63, 65);
            this.btn_Them.TabIndex = 0;
            this.btn_Them.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Them.UseVisualStyleBackColor = true;
            // 
            // btn_Luu
            // 
            this.btn_Luu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Luu.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Luu.ImageKey = "Save.png";
            this.btn_Luu.ImageList = this.imageList1;
            this.btn_Luu.Location = new System.Drawing.Point(283, 49);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(63, 65);
            this.btn_Luu.TabIndex = 2;
            this.btn_Luu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Luu.UseVisualStyleBackColor = true;
            this.btn_Luu.Visible = false;
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Xoa.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Xoa.ImageKey = "Garbage.png";
            this.btn_Xoa.ImageList = this.imageList1;
            this.btn_Xoa.Location = new System.Drawing.Point(536, 49);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(63, 65);
            this.btn_Xoa.TabIndex = 4;
            this.btn_Xoa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Xoa.UseVisualStyleBackColor = true;
            // 
            // btn_Sua
            // 
            this.btn_Sua.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Sua.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Sua.ImageKey = "Edit Data.png";
            this.btn_Sua.ImageList = this.imageList1;
            this.btn_Sua.Location = new System.Drawing.Point(157, 49);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(63, 65);
            this.btn_Sua.TabIndex = 1;
            this.btn_Sua.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Sua.UseVisualStyleBackColor = true;
            // 
            // NhomNgach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.tableLP_ChucDanh);
            this.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "NhomNgach";
            this.Size = new System.Drawing.Size(650, 600);
            this.tableLP_ChucDanh.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLP_DSChucDanh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_DSNhomNgach)).EndInit();
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
        private System.Windows.Forms.DataGridView dtgv_DSNhomNgach;
        private System.Windows.Forms.TableLayoutPanel tableLP_ChiTietChucDanh;
        private System.Windows.Forms.TextBox txt_NhomNgach;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLP_ThaoTac;
        private System.Windows.Forms.Button btn_Huy;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Button btn_Luu;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Sua;

    }
}
