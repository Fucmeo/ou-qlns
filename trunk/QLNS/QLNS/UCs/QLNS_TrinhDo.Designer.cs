namespace QLNS.UCs
{
    partial class QLNS_TrinhDo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QLNS_TrinhDo));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLP_VanBang = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLP_ThaoTac = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Huy = new System.Windows.Forms.Button();
            this.btn_Them = new System.Windows.Forms.Button();
            this.btn_Luu = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLP_DSVanBang = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_SoVanBang = new System.Windows.Forms.Label();
            this.dtgv_DSTrinhDo = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Ten = new System.Windows.Forms.TextBox();
            this.tableLP_VanBang.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLP_ThaoTac.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLP_DSVanBang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_DSTrinhDo)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
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
            // tableLP_VanBang
            // 
            this.tableLP_VanBang.ColumnCount = 2;
            this.tableLP_VanBang.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLP_VanBang.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLP_VanBang.Controls.Add(this.groupBox2, 0, 1);
            this.tableLP_VanBang.Controls.Add(this.groupBox1, 0, 2);
            this.tableLP_VanBang.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLP_VanBang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLP_VanBang.Location = new System.Drawing.Point(0, 0);
            this.tableLP_VanBang.Name = "tableLP_VanBang";
            this.tableLP_VanBang.RowCount = 3;
            this.tableLP_VanBang.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLP_VanBang.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLP_VanBang.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLP_VanBang.Size = new System.Drawing.Size(550, 400);
            this.tableLP_VanBang.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.tableLP_VanBang.SetColumnSpan(this.groupBox2, 2);
            this.groupBox2.Controls.Add(this.tableLP_ThaoTac);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 84);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(544, 112);
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
            this.tableLP_ThaoTac.Location = new System.Drawing.Point(3, 21);
            this.tableLP_ThaoTac.Name = "tableLP_ThaoTac";
            this.tableLP_ThaoTac.RowCount = 1;
            this.tableLP_ThaoTac.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLP_ThaoTac.Size = new System.Drawing.Size(538, 87);
            this.tableLP_ThaoTac.TabIndex = 1;
            // 
            // btn_Huy
            // 
            this.btn_Huy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Huy.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Huy.ImageKey = "Cancel.png";
            this.btn_Huy.ImageList = this.imageList1;
            this.btn_Huy.Location = new System.Drawing.Point(346, 16);
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(56, 55);
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
            this.btn_Them.Location = new System.Drawing.Point(25, 16);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(56, 55);
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
            this.btn_Luu.Location = new System.Drawing.Point(239, 16);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(56, 55);
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
            this.btn_Xoa.Location = new System.Drawing.Point(455, 16);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(56, 55);
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
            this.btn_Sua.Location = new System.Drawing.Point(132, 16);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(56, 55);
            this.btn_Sua.TabIndex = 1;
            this.btn_Sua.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Sua.UseVisualStyleBackColor = true;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // groupBox1
            // 
            this.tableLP_VanBang.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.tableLP_DSVanBang);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 203);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(544, 194);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách trình độ";
            // 
            // tableLP_DSVanBang
            // 
            this.tableLP_DSVanBang.ColumnCount = 2;
            this.tableLP_DSVanBang.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.0223F));
            this.tableLP_DSVanBang.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.97769F));
            this.tableLP_DSVanBang.Controls.Add(this.lbl_SoVanBang, 1, 1);
            this.tableLP_DSVanBang.Controls.Add(this.dtgv_DSTrinhDo, 0, 0);
            this.tableLP_DSVanBang.Controls.Add(this.label2, 0, 1);
            this.tableLP_DSVanBang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLP_DSVanBang.Location = new System.Drawing.Point(3, 20);
            this.tableLP_DSVanBang.Name = "tableLP_DSVanBang";
            this.tableLP_DSVanBang.RowCount = 2;
            this.tableLP_DSVanBang.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLP_DSVanBang.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLP_DSVanBang.Size = new System.Drawing.Size(538, 171);
            this.tableLP_DSVanBang.TabIndex = 0;
            // 
            // lbl_SoVanBang
            // 
            this.lbl_SoVanBang.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_SoVanBang.AutoSize = true;
            this.lbl_SoVanBang.Location = new System.Drawing.Point(142, 153);
            this.lbl_SoVanBang.Name = "lbl_SoVanBang";
            this.lbl_SoVanBang.Size = new System.Drawing.Size(42, 17);
            this.lbl_SoVanBang.TabIndex = 3;
            this.lbl_SoVanBang.Text = "label4";
            this.lbl_SoVanBang.Visible = false;
            // 
            // dtgv_DSTrinhDo
            // 
            this.dtgv_DSTrinhDo.AllowUserToAddRows = false;
            this.dtgv_DSTrinhDo.AllowUserToDeleteRows = false;
            this.dtgv_DSTrinhDo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLP_DSVanBang.SetColumnSpan(this.dtgv_DSTrinhDo, 2);
            this.dtgv_DSTrinhDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgv_DSTrinhDo.Location = new System.Drawing.Point(3, 3);
            this.dtgv_DSTrinhDo.MultiSelect = false;
            this.dtgv_DSTrinhDo.Name = "dtgv_DSTrinhDo";
            this.dtgv_DSTrinhDo.ReadOnly = true;
            this.dtgv_DSTrinhDo.RowTemplate.Height = 24;
            this.dtgv_DSTrinhDo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgv_DSTrinhDo.Size = new System.Drawing.Size(532, 147);
            this.dtgv_DSTrinhDo.TabIndex = 0;
            this.dtgv_DSTrinhDo.SelectionChanged += new System.EventHandler(this.dtgv_DSTrinhDo_SelectionChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số trình độ";
            this.label2.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLP_VanBang.SetColumnSpan(this.tableLayoutPanel1, 2);
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txt_Ten, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(544, 74);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên";
            // 
            // txt_Ten
            // 
            this.txt_Ten.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_Ten.Location = new System.Drawing.Point(166, 25);
            this.txt_Ten.MaxLength = 20;
            this.txt_Ten.Name = "txt_Ten";
            this.txt_Ten.Size = new System.Drawing.Size(348, 24);
            this.txt_Ten.TabIndex = 0;
            // 
            // QLNS_TrinhDo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.tableLP_VanBang);
            this.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "QLNS_TrinhDo";
            this.Size = new System.Drawing.Size(550, 400);
            this.Load += new System.EventHandler(this.QLNS_TrinhDo_Load);
            this.tableLP_VanBang.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLP_ThaoTac.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLP_DSVanBang.ResumeLayout(false);
            this.tableLP_DSVanBang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_DSTrinhDo)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TableLayoutPanel tableLP_VanBang;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLP_ThaoTac;
        private System.Windows.Forms.Button btn_Huy;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Button btn_Luu;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLP_DSVanBang;
        private System.Windows.Forms.Label lbl_SoVanBang;
        private System.Windows.Forms.DataGridView dtgv_DSTrinhDo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Ten;
    }
}
