namespace HDQD.UCs
{
    partial class DonViCu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DonViCu));
            this.TLP_DonViCu = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Date_DonVi = new System.Windows.Forms.Label();
            this.comB_DonVi = new System.Windows.Forms.ComboBox();
            this.comB_ChucVu = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lsb_DonVi = new System.Windows.Forms.ListBox();
            this.comB_ChucDanh = new System.Windows.Forms.ComboBox();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Them = new System.Windows.Forms.Button();
            this.lbl_DenNgayHD = new System.Windows.Forms.Label();
            this.TLP_DonViCu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLP_DonViCu
            // 
            this.TLP_DonViCu.ColumnCount = 4;
            this.TLP_DonViCu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.80435F));
            this.TLP_DonViCu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.11001F));
            this.TLP_DonViCu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66109F));
            this.TLP_DonViCu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.42455F));
            this.TLP_DonViCu.Controls.Add(this.button1, 2, 0);
            this.TLP_DonViCu.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.TLP_DonViCu.Controls.Add(this.comB_ChucVu, 1, 1);
            this.TLP_DonViCu.Controls.Add(this.label5, 0, 0);
            this.TLP_DonViCu.Controls.Add(this.label1, 0, 1);
            this.TLP_DonViCu.Controls.Add(this.label2, 0, 2);
            this.TLP_DonViCu.Controls.Add(this.lsb_DonVi, 3, 0);
            this.TLP_DonViCu.Controls.Add(this.comB_ChucDanh, 1, 2);
            this.TLP_DonViCu.Controls.Add(this.btn_Xoa, 2, 1);
            this.TLP_DonViCu.Controls.Add(this.btn_Them, 2, 2);
            this.TLP_DonViCu.Controls.Add(this.lbl_DenNgayHD, 0, 3);
            this.TLP_DonViCu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_DonViCu.Location = new System.Drawing.Point(0, 0);
            this.TLP_DonViCu.Name = "TLP_DonViCu";
            this.TLP_DonViCu.RowCount = 4;
            this.TLP_DonViCu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.57554F));
            this.TLP_DonViCu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.38129F));
            this.TLP_DonViCu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.5036F));
            this.TLP_DonViCu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLP_DonViCu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP_DonViCu.Size = new System.Drawing.Size(650, 278);
            this.TLP_DonViCu.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.ImageKey = "Add.png";
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(369, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 52);
            this.button1.TabIndex = 23;
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Save.png");
            this.imageList1.Images.SetKeyName(1, "Document-Add.png");
            this.imageList1.Images.SetKeyName(2, "Remove Avatar.png");
            this.imageList1.Images.SetKeyName(3, "Add.png");
            this.imageList1.Images.SetKeyName(4, "Cancel.png");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_Date_DonVi, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comB_DonVi, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(86, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(254, 79);
            this.tableLayoutPanel1.TabIndex = 22;
            // 
            // lbl_Date_DonVi
            // 
            this.lbl_Date_DonVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Date_DonVi.Enabled = false;
            this.lbl_Date_DonVi.Location = new System.Drawing.Point(3, 39);
            this.lbl_Date_DonVi.Name = "lbl_Date_DonVi";
            this.lbl_Date_DonVi.Size = new System.Drawing.Size(248, 40);
            this.lbl_Date_DonVi.TabIndex = 17;
            this.lbl_Date_DonVi.Text = "Từ ngày";
            // 
            // comB_DonVi
            // 
            this.comB_DonVi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comB_DonVi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_DonVi.FormattingEnabled = true;
            this.comB_DonVi.Location = new System.Drawing.Point(3, 9);
            this.comB_DonVi.Name = "comB_DonVi";
            this.comB_DonVi.Size = new System.Drawing.Size(245, 25);
            this.comB_DonVi.TabIndex = 10;
            this.comB_DonVi.SelectionChangeCommitted += new System.EventHandler(this.comB_DonVi_SelectionChangeCommitted);
            // 
            // comB_ChucVu
            // 
            this.comB_ChucVu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comB_ChucVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_ChucVu.FormattingEnabled = true;
            this.comB_ChucVu.Location = new System.Drawing.Point(86, 107);
            this.comB_ChucVu.Name = "comB_ChucVu";
            this.comB_ChucVu.Size = new System.Drawing.Size(216, 25);
            this.comB_ChucVu.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Đơn vị";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "Chức vụ";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "Chức danh";
            // 
            // lsb_DonVi
            // 
            this.lsb_DonVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsb_DonVi.FormattingEnabled = true;
            this.lsb_DonVi.ItemHeight = 17;
            this.lsb_DonVi.Location = new System.Drawing.Point(454, 3);
            this.lsb_DonVi.Name = "lsb_DonVi";
            this.TLP_DonViCu.SetRowSpan(this.lsb_DonVi, 3);
            this.lsb_DonVi.Size = new System.Drawing.Size(193, 201);
            this.lsb_DonVi.TabIndex = 16;
            // 
            // comB_ChucDanh
            // 
            this.comB_ChucDanh.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comB_ChucDanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_ChucDanh.FormattingEnabled = true;
            this.comB_ChucDanh.Location = new System.Drawing.Point(86, 168);
            this.comB_ChucDanh.Name = "comB_ChucDanh";
            this.comB_ChucDanh.Size = new System.Drawing.Size(216, 25);
            this.comB_ChucDanh.TabIndex = 19;
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Xoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Xoa.ImageKey = "Remove Avatar.png";
            this.btn_Xoa.ImageList = this.imageList1;
            this.btn_Xoa.Location = new System.Drawing.Point(373, 93);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(48, 48);
            this.btn_Xoa.TabIndex = 20;
            this.btn_Xoa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_Them
            // 
            this.btn_Them.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Them.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Them.ImageKey = "Save.png";
            this.btn_Them.ImageList = this.imageList1;
            this.btn_Them.Location = new System.Drawing.Point(369, 153);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(56, 51);
            this.btn_Them.TabIndex = 13;
            this.btn_Them.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // lbl_DenNgayHD
            // 
            this.lbl_DenNgayHD.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_DenNgayHD.AutoSize = true;
            this.TLP_DonViCu.SetColumnSpan(this.lbl_DenNgayHD, 4);
            this.lbl_DenNgayHD.Location = new System.Drawing.Point(3, 233);
            this.lbl_DenNgayHD.Name = "lbl_DenNgayHD";
            this.lbl_DenNgayHD.Size = new System.Drawing.Size(46, 18);
            this.lbl_DenNgayHD.TabIndex = 24;
            this.lbl_DenNgayHD.Text = "label4";
            // 
            // DonViCu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.TLP_DonViCu);
            this.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DonViCu";
            this.Size = new System.Drawing.Size(650, 278);
            this.Load += new System.EventHandler(this.DonViCu_Load);
            this.TLP_DonViCu.ResumeLayout(false);
            this.TLP_DonViCu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLP_DonViCu;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox comB_DonVi;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lsb_DonVi;
        private System.Windows.Forms.Label lbl_Date_DonVi;
        public System.Windows.Forms.ComboBox comB_ChucVu;
        public System.Windows.Forms.ComboBox comB_ChucDanh;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_DenNgayHD;
    }
}
