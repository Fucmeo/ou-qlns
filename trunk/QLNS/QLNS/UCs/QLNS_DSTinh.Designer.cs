namespace QLNS.UCs
{
    partial class QLNS_DSTinh
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
            this.tableLP_TinhTP = new System.Windows.Forms.TableLayoutPanel();
            this.cLB_TinhTP = new System.Windows.Forms.CheckedListBox();
            this.tableLP_NutThaoTac = new System.Windows.Forms.TableLayoutPanel();
            this.btn_XacNhan = new System.Windows.Forms.Button();
            this.btn_ChonTatCa = new System.Windows.Forms.Button();
            this.tableLP_TinhTP.SuspendLayout();
            this.tableLP_NutThaoTac.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLP_TinhTP
            // 
            this.tableLP_TinhTP.ColumnCount = 1;
            this.tableLP_TinhTP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLP_TinhTP.Controls.Add(this.cLB_TinhTP, 0, 0);
            this.tableLP_TinhTP.Controls.Add(this.tableLP_NutThaoTac, 0, 1);
            this.tableLP_TinhTP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLP_TinhTP.Location = new System.Drawing.Point(0, 0);
            this.tableLP_TinhTP.Name = "tableLP_TinhTP";
            this.tableLP_TinhTP.RowCount = 2;
            this.tableLP_TinhTP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLP_TinhTP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLP_TinhTP.Size = new System.Drawing.Size(250, 650);
            this.tableLP_TinhTP.TabIndex = 0;
            // 
            // cLB_TinhTP
            // 
            this.cLB_TinhTP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cLB_TinhTP.FormattingEnabled = true;
            this.cLB_TinhTP.Items.AddRange(new object[] {
            "TPHCM",
            "HN"});
            this.cLB_TinhTP.Location = new System.Drawing.Point(3, 3);
            this.cLB_TinhTP.Name = "cLB_TinhTP";
            this.cLB_TinhTP.Size = new System.Drawing.Size(244, 546);
            this.cLB_TinhTP.TabIndex = 0;
            // 
            // tableLP_NutThaoTac
            // 
            this.tableLP_NutThaoTac.ColumnCount = 2;
            this.tableLP_NutThaoTac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLP_NutThaoTac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLP_NutThaoTac.Controls.Add(this.btn_ChonTatCa, 1, 0);
            this.tableLP_NutThaoTac.Controls.Add(this.btn_XacNhan, 0, 0);
            this.tableLP_NutThaoTac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLP_NutThaoTac.Location = new System.Drawing.Point(3, 555);
            this.tableLP_NutThaoTac.Name = "tableLP_NutThaoTac";
            this.tableLP_NutThaoTac.RowCount = 1;
            this.tableLP_NutThaoTac.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLP_NutThaoTac.Size = new System.Drawing.Size(244, 92);
            this.tableLP_NutThaoTac.TabIndex = 1;
            // 
            // btn_XacNhan
            // 
            this.btn_XacNhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_XacNhan.Location = new System.Drawing.Point(3, 3);
            this.btn_XacNhan.Name = "btn_XacNhan";
            this.btn_XacNhan.Size = new System.Drawing.Size(116, 86);
            this.btn_XacNhan.TabIndex = 0;
            this.btn_XacNhan.Text = "Xác nhận";
            this.btn_XacNhan.UseVisualStyleBackColor = true;
            // 
            // btn_ChonTatCa
            // 
            this.btn_ChonTatCa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ChonTatCa.Location = new System.Drawing.Point(125, 3);
            this.btn_ChonTatCa.Name = "btn_ChonTatCa";
            this.btn_ChonTatCa.Size = new System.Drawing.Size(116, 86);
            this.btn_ChonTatCa.TabIndex = 1;
            this.btn_ChonTatCa.Text = "Chọn / Bỏ chọn tất cả";
            this.btn_ChonTatCa.UseVisualStyleBackColor = true;
            // 
            // QLNS_DSTinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.tableLP_TinhTP);
            this.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "QLNS_DSTinh";
            this.Size = new System.Drawing.Size(250, 650);
            this.tableLP_TinhTP.ResumeLayout(false);
            this.tableLP_NutThaoTac.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLP_TinhTP;
        private System.Windows.Forms.CheckedListBox cLB_TinhTP;
        private System.Windows.Forms.TableLayoutPanel tableLP_NutThaoTac;
        private System.Windows.Forms.Button btn_ChonTatCa;
        private System.Windows.Forms.Button btn_XacNhan;
    }
}
