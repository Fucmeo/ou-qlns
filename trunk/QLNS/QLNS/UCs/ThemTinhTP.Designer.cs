namespace QLNS.UCs
{
    partial class ThemTinhTP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemTinhTP));
            this.tLP_ThemTinhTP = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Them = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Ten = new System.Windows.Forms.TextBox();
            this.rTB_GhiChu = new System.Windows.Forms.RichTextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tLP_ThemTinhTP.SuspendLayout();
            this.SuspendLayout();
            // 
            // tLP_ThemTinhTP
            // 
            this.tLP_ThemTinhTP.ColumnCount = 2;
            this.tLP_ThemTinhTP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.75F));
            this.tLP_ThemTinhTP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.25F));
            this.tLP_ThemTinhTP.Controls.Add(this.label3, 0, 1);
            this.tLP_ThemTinhTP.Controls.Add(this.btn_Them, 0, 2);
            this.tLP_ThemTinhTP.Controls.Add(this.label1, 0, 0);
            this.tLP_ThemTinhTP.Controls.Add(this.txt_Ten, 1, 0);
            this.tLP_ThemTinhTP.Controls.Add(this.rTB_GhiChu, 1, 1);
            this.tLP_ThemTinhTP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tLP_ThemTinhTP.Location = new System.Drawing.Point(0, 0);
            this.tLP_ThemTinhTP.Name = "tLP_ThemTinhTP";
            this.tLP_ThemTinhTP.RowCount = 3;
            this.tLP_ThemTinhTP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tLP_ThemTinhTP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tLP_ThemTinhTP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tLP_ThemTinhTP.Size = new System.Drawing.Size(400, 300);
            this.tLP_ThemTinhTP.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ghi Chú";
            // 
            // btn_Them
            // 
            this.btn_Them.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tLP_ThemTinhTP.SetColumnSpan(this.btn_Them, 2);
            this.btn_Them.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Them.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Them.ImageKey = "Add.png";
            this.btn_Them.ImageList = this.imageList1;
            this.btn_Them.Location = new System.Drawing.Point(150, 190);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(100, 100);
            this.btn_Them.TabIndex = 0;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 48);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên tỉnh / thành phố";
            // 
            // txt_Ten
            // 
            this.txt_Ten.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_Ten.Location = new System.Drawing.Point(122, 14);
            this.txt_Ten.MaxLength = 30;
            this.txt_Ten.Name = "txt_Ten";
            this.txt_Ten.Size = new System.Drawing.Size(275, 32);
            this.txt_Ten.TabIndex = 4;
            // 
            // rTB_GhiChu
            // 
            this.rTB_GhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTB_GhiChu.Location = new System.Drawing.Point(122, 63);
            this.rTB_GhiChu.MaxLength = 50;
            this.rTB_GhiChu.Name = "rTB_GhiChu";
            this.rTB_GhiChu.Size = new System.Drawing.Size(275, 114);
            this.rTB_GhiChu.TabIndex = 5;
            this.rTB_GhiChu.Text = "";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Add.png");
            // 
            // ThemTinhTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.tLP_ThemTinhTP);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ThemTinhTP";
            this.Size = new System.Drawing.Size(400, 300);
            this.tLP_ThemTinhTP.ResumeLayout(false);
            this.tLP_ThemTinhTP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tLP_ThemTinhTP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Ten;
        private System.Windows.Forms.RichTextBox rTB_GhiChu;
        private System.Windows.Forms.ImageList imageList1;
    }
}
