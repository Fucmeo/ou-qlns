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
            this.tableLP_DSTapTin = new System.Windows.Forms.TableLayoutPanel();
            this.tableLP_ChiTietFile = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Nhap = new System.Windows.Forms.Button();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.tableLP_DSTapTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLP_DSTapTin
            // 
            this.tableLP_DSTapTin.ColumnCount = 2;
            this.tableLP_DSTapTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLP_DSTapTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLP_DSTapTin.Controls.Add(this.btn_Nhap, 0, 1);
            this.tableLP_DSTapTin.Controls.Add(this.tableLP_ChiTietFile, 0, 0);
            this.tableLP_DSTapTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLP_DSTapTin.Location = new System.Drawing.Point(0, 0);
            this.tableLP_DSTapTin.Name = "tableLP_DSTapTin";
            this.tableLP_DSTapTin.RowCount = 2;
            this.tableLP_DSTapTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLP_DSTapTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLP_DSTapTin.Size = new System.Drawing.Size(850, 700);
            this.tableLP_DSTapTin.TabIndex = 0;
            // 
            // tableLP_ChiTietFile
            // 
            this.tableLP_ChiTietFile.ColumnCount = 4;
            this.tableLP_DSTapTin.SetColumnSpan(this.tableLP_ChiTietFile, 2);
            this.tableLP_ChiTietFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLP_ChiTietFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLP_ChiTietFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLP_ChiTietFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLP_ChiTietFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLP_ChiTietFile.Location = new System.Drawing.Point(3, 3);
            this.tableLP_ChiTietFile.Name = "tableLP_ChiTietFile";
            this.tableLP_ChiTietFile.RowCount = 2;
            this.tableLP_ChiTietFile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tableLP_ChiTietFile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tableLP_ChiTietFile.Size = new System.Drawing.Size(844, 484);
            this.tableLP_ChiTietFile.TabIndex = 0;
            // 
            // btn_Nhap
            // 
            this.btn_Nhap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLP_DSTapTin.SetColumnSpan(this.btn_Nhap, 2);
            this.btn_Nhap.Location = new System.Drawing.Point(370, 563);
            this.btn_Nhap.Name = "btn_Nhap";
            this.btn_Nhap.Size = new System.Drawing.Size(109, 63);
            this.btn_Nhap.TabIndex = 8;
            this.btn_Nhap.Text = "Nhập";
            this.btn_Nhap.UseVisualStyleBackColor = true;
            // 
            // OFD
            // 
            this.OFD.Filter = "All files|*.*|PDF File|*.pfd|PNG File|*.png|BITMAP|*.bitmap|JPEG|*.jpeg;*.jpg|GIF" +
    "|*.gif";
            this.OFD.Title = "Chọn tập tin để tải lên...";
            // 
            // DSTapTin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.tableLP_DSTapTin);
            this.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(700, 700);
            this.Name = "DSTapTin";
            this.Size = new System.Drawing.Size(850, 700);
            this.Load += new System.EventHandler(this.DSTapTin_Load);
            this.tableLP_DSTapTin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLP_DSTapTin;
        private System.Windows.Forms.TableLayoutPanel tableLP_ChiTietFile;
        private System.Windows.Forms.Button btn_Nhap;
        private System.Windows.Forms.OpenFileDialog OFD;
    }
}
