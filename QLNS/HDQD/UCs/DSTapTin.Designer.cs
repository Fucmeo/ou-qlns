namespace HDQD.UCs
{
    partial class DSTapTin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DSTapTin));
            this.tableLP_DSTapTin = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Luu = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLP_ChiTietFile = new System.Windows.Forms.TableLayoutPanel();
            this.pb_Preview = new System.Windows.Forms.PictureBox();
            this.tableLP_ThaoTac = new System.Windows.Forms.TableLayoutPanel();
            this.btn_DownLoad = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Them = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtb_MoTa = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lsb_DSFile = new System.Windows.Forms.ListBox();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.FBD = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLP_DSTapTin.SuspendLayout();
            this.tableLP_ChiTietFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Preview)).BeginInit();
            this.tableLP_ThaoTac.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLP_DSTapTin
            // 
            this.tableLP_DSTapTin.ColumnCount = 2;
            this.tableLP_DSTapTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLP_DSTapTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLP_DSTapTin.Controls.Add(this.btn_Luu, 0, 1);
            this.tableLP_DSTapTin.Controls.Add(this.tableLP_ChiTietFile, 0, 0);
            this.tableLP_DSTapTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLP_DSTapTin.Location = new System.Drawing.Point(0, 0);
            this.tableLP_DSTapTin.Name = "tableLP_DSTapTin";
            this.tableLP_DSTapTin.RowCount = 2;
            this.tableLP_DSTapTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLP_DSTapTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLP_DSTapTin.Size = new System.Drawing.Size(850, 550);
            this.tableLP_DSTapTin.TabIndex = 0;
            // 
            // btn_Luu
            // 
            this.btn_Luu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLP_DSTapTin.SetColumnSpan(this.btn_Luu, 2);
            this.btn_Luu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Luu.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Luu.ImageKey = "Save.png";
            this.btn_Luu.ImageList = this.imageList1;
            this.btn_Luu.Location = new System.Drawing.Point(397, 467);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(56, 56);
            this.btn_Luu.TabIndex = 3;
            this.btn_Luu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Luu.UseVisualStyleBackColor = true;
            this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);
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
            this.imageList1.Images.SetKeyName(5, "Download.png");
            // 
            // tableLP_ChiTietFile
            // 
            this.tableLP_ChiTietFile.ColumnCount = 2;
            this.tableLP_DSTapTin.SetColumnSpan(this.tableLP_ChiTietFile, 2);
            this.tableLP_ChiTietFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLP_ChiTietFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLP_ChiTietFile.Controls.Add(this.pb_Preview, 1, 1);
            this.tableLP_ChiTietFile.Controls.Add(this.tableLP_ThaoTac, 0, 2);
            this.tableLP_ChiTietFile.Controls.Add(this.groupBox1, 1, 0);
            this.tableLP_ChiTietFile.Controls.Add(this.groupBox2, 0, 0);
            this.tableLP_ChiTietFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLP_ChiTietFile.Location = new System.Drawing.Point(3, 3);
            this.tableLP_ChiTietFile.Name = "tableLP_ChiTietFile";
            this.tableLP_ChiTietFile.RowCount = 3;
            this.tableLP_ChiTietFile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLP_ChiTietFile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLP_ChiTietFile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLP_ChiTietFile.Size = new System.Drawing.Size(844, 434);
            this.tableLP_ChiTietFile.TabIndex = 0;
            // 
            // pb_Preview
            // 
            this.pb_Preview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_Preview.Location = new System.Drawing.Point(425, 133);
            this.pb_Preview.Name = "pb_Preview";
            this.tableLP_ChiTietFile.SetRowSpan(this.pb_Preview, 2);
            this.pb_Preview.Size = new System.Drawing.Size(416, 298);
            this.pb_Preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Preview.TabIndex = 2;
            this.pb_Preview.TabStop = false;
            // 
            // tableLP_ThaoTac
            // 
            this.tableLP_ThaoTac.ColumnCount = 3;
            this.tableLP_ThaoTac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLP_ThaoTac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLP_ThaoTac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLP_ThaoTac.Controls.Add(this.btn_DownLoad, 0, 0);
            this.tableLP_ThaoTac.Controls.Add(this.btn_Xoa, 0, 0);
            this.tableLP_ThaoTac.Controls.Add(this.btn_Them, 0, 0);
            this.tableLP_ThaoTac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLP_ThaoTac.Location = new System.Drawing.Point(3, 350);
            this.tableLP_ThaoTac.Name = "tableLP_ThaoTac";
            this.tableLP_ThaoTac.RowCount = 1;
            this.tableLP_ThaoTac.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLP_ThaoTac.Size = new System.Drawing.Size(416, 81);
            this.tableLP_ThaoTac.TabIndex = 3;
            // 
            // btn_DownLoad
            // 
            this.btn_DownLoad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_DownLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DownLoad.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_DownLoad.ImageKey = "Download.png";
            this.btn_DownLoad.ImageList = this.imageList1;
            this.btn_DownLoad.Location = new System.Drawing.Point(318, 12);
            this.btn_DownLoad.Name = "btn_DownLoad";
            this.btn_DownLoad.Size = new System.Drawing.Size(56, 56);
            this.btn_DownLoad.TabIndex = 6;
            this.btn_DownLoad.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_DownLoad.UseVisualStyleBackColor = true;
            this.btn_DownLoad.Click += new System.EventHandler(this.btn_DownLoad_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Xoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Xoa.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Xoa.ImageKey = "Garbage.png";
            this.btn_Xoa.ImageList = this.imageList1;
            this.btn_Xoa.Location = new System.Drawing.Point(179, 12);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(56, 56);
            this.btn_Xoa.TabIndex = 5;
            this.btn_Xoa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_Them
            // 
            this.btn_Them.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Them.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Them.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Them.ImageKey = "Add.png";
            this.btn_Them.ImageList = this.imageList1;
            this.btn_Them.Location = new System.Drawing.Point(41, 12);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(56, 56);
            this.btn_Them.TabIndex = 1;
            this.btn_Them.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtb_MoTa);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(425, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 124);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mô tả";
            // 
            // rtb_MoTa
            // 
            this.rtb_MoTa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_MoTa.Location = new System.Drawing.Point(3, 24);
            this.rtb_MoTa.Name = "rtb_MoTa";
            this.rtb_MoTa.Size = new System.Drawing.Size(410, 97);
            this.rtb_MoTa.TabIndex = 2;
            this.rtb_MoTa.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lsb_DSFile);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.tableLP_ChiTietFile.SetRowSpan(this.groupBox2, 2);
            this.groupBox2.Size = new System.Drawing.Size(416, 341);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách tập tin";
            // 
            // lsb_DSFile
            // 
            this.lsb_DSFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsb_DSFile.FormattingEnabled = true;
            this.lsb_DSFile.ItemHeight = 21;
            this.lsb_DSFile.Location = new System.Drawing.Point(3, 24);
            this.lsb_DSFile.Name = "lsb_DSFile";
            this.lsb_DSFile.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsb_DSFile.Size = new System.Drawing.Size(410, 314);
            this.lsb_DSFile.TabIndex = 1;
            this.lsb_DSFile.SelectedIndexChanged += new System.EventHandler(this.lsb_DSFile_SelectedIndexChanged);
            // 
            // OFD
            // 
            this.OFD.Filter = "PNG|*.PNG|GIF|*.GIF|JPEG|*.JPEG|JPG|*.JPG|Pictures Format|*.JPEG;*.PNG;*.GIF;*.JP" +
    "G";
            this.OFD.FilterIndex = 5;
            this.OFD.Multiselect = true;
            this.OFD.Title = "Chọn tập tin để tải lên...";
            // 
            // FBD
            // 
            this.FBD.Description = "Chọn đường dẫn lưu tập tin ...";
            // 
            // DSTapTin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.tableLP_DSTapTin);
            this.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(850, 550);
            this.Name = "DSTapTin";
            this.Size = new System.Drawing.Size(850, 550);
            this.Load += new System.EventHandler(this.DSTapTin_Load);
            this.tableLP_DSTapTin.ResumeLayout(false);
            this.tableLP_ChiTietFile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Preview)).EndInit();
            this.tableLP_ThaoTac.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLP_DSTapTin;
        private System.Windows.Forms.TableLayoutPanel tableLP_ChiTietFile;
        public System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.PictureBox pb_Preview;
        private System.Windows.Forms.TableLayoutPanel tableLP_ThaoTac;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Luu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtb_MoTa;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lsb_DSFile;
        private System.Windows.Forms.Button btn_DownLoad;
        private System.Windows.Forms.FolderBrowserDialog FBD;
    }
}
