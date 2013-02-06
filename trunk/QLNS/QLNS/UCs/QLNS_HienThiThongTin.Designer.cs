namespace QLNS.UCs
{
    partial class QLNS_HienThiThongTin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QLNS_HienThiThongTin));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLP_ThaoTac = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btn_Huy = new System.Windows.Forms.Button();
            this.btn_Luu = new System.Windows.Forms.Button();
            this.btn_Them = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLP_ThaoTac.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.75F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(900, 800);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLP_ThaoTac);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(273, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(624, 132);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thao tác";
            // 
            // tableLP_ThaoTac
            // 
            this.tableLP_ThaoTac.ColumnCount = 5;
            this.tableLP_ThaoTac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLP_ThaoTac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLP_ThaoTac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLP_ThaoTac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.53398F));
            this.tableLP_ThaoTac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.93204F));
            this.tableLP_ThaoTac.Controls.Add(this.btn_Xoa, 4, 0);
            this.tableLP_ThaoTac.Controls.Add(this.btn_Huy, 2, 0);
            this.tableLP_ThaoTac.Controls.Add(this.btn_Luu, 1, 0);
            this.tableLP_ThaoTac.Controls.Add(this.btn_Them, 0, 0);
            this.tableLP_ThaoTac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLP_ThaoTac.Location = new System.Drawing.Point(3, 25);
            this.tableLP_ThaoTac.Name = "tableLP_ThaoTac";
            this.tableLP_ThaoTac.RowCount = 1;
            this.tableLP_ThaoTac.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLP_ThaoTac.Size = new System.Drawing.Size(618, 104);
            this.tableLP_ThaoTac.TabIndex = 0;
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Xoa.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Xoa.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Xoa.ImageKey = "Garbage.png";
            this.btn_Xoa.ImageList = this.imageList2;
            this.btn_Xoa.Location = new System.Drawing.Point(509, 3);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(100, 98);
            this.btn_Xoa.TabIndex = 3;
            this.btn_Xoa.Text = "Xoá";
            this.btn_Xoa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Add.png");
            this.imageList2.Images.SetKeyName(1, "Cancel.png");
            this.imageList2.Images.SetKeyName(2, "Edit Data.png");
            this.imageList2.Images.SetKeyName(3, "Garbage.png");
            this.imageList2.Images.SetKeyName(4, "Save.png");
            // 
            // btn_Huy
            // 
            this.btn_Huy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Huy.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Huy.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Huy.ImageKey = "Cancel.png";
            this.btn_Huy.ImageList = this.imageList2;
            this.btn_Huy.Location = new System.Drawing.Point(287, 3);
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(100, 98);
            this.btn_Huy.TabIndex = 2;
            this.btn_Huy.Text = "Huỷ";
            this.btn_Huy.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Huy.UseVisualStyleBackColor = true;
            this.btn_Huy.Visible = false;
            this.btn_Huy.Click += new System.EventHandler(this.btn_Huy_Click);
            // 
            // btn_Luu
            // 
            this.btn_Luu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Luu.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Luu.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Luu.ImageKey = "Save.png";
            this.btn_Luu.ImageList = this.imageList2;
            this.btn_Luu.Location = new System.Drawing.Point(152, 3);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(100, 98);
            this.btn_Luu.TabIndex = 1;
            this.btn_Luu.Text = "Lưu";
            this.btn_Luu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Luu.UseVisualStyleBackColor = true;
            this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);
            // 
            // btn_Them
            // 
            this.btn_Them.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Them.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Them.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Them.ImageKey = "Add.png";
            this.btn_Them.ImageList = this.imageList2;
            this.btn_Them.Location = new System.Drawing.Point(17, 3);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(100, 98);
            this.btn_Them.TabIndex = 0;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // QLNS_HienThiThongTin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "QLNS_HienThiThongTin";
            this.Size = new System.Drawing.Size(900, 800);
            this.Load += new System.EventHandler(this.QLNS_HienThiThongTin_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLP_ThaoTac.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLP_ThaoTac;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Huy;
        private System.Windows.Forms.Button btn_Luu;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.ImageList imageList2;
    }
}
