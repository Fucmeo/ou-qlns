namespace QLNS.UCs
{
    partial class QLNS_DSTinhTrangHN
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
            this.tableLP_TinhTrangHN = new System.Windows.Forms.TableLayoutPanel();
            this.cLB_TinhTrangHN = new System.Windows.Forms.CheckedListBox();
            this.tableLP_NutThaoTac = new System.Windows.Forms.TableLayoutPanel();
            this.btn_ChonTatCa = new System.Windows.Forms.Button();
            this.btn_XacNhan = new System.Windows.Forms.Button();
            this.tableLP_TinhTrangHN.SuspendLayout();
            this.tableLP_NutThaoTac.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLP_TinhTrangHN
            // 
            this.tableLP_TinhTrangHN.ColumnCount = 1;
            this.tableLP_TinhTrangHN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLP_TinhTrangHN.Controls.Add(this.cLB_TinhTrangHN, 0, 0);
            this.tableLP_TinhTrangHN.Controls.Add(this.tableLP_NutThaoTac, 0, 1);
            this.tableLP_TinhTrangHN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLP_TinhTrangHN.Location = new System.Drawing.Point(0, 0);
            this.tableLP_TinhTrangHN.Name = "tableLP_TinhTrangHN";
            this.tableLP_TinhTrangHN.RowCount = 2;
            this.tableLP_TinhTrangHN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLP_TinhTrangHN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLP_TinhTrangHN.Size = new System.Drawing.Size(250, 350);
            this.tableLP_TinhTrangHN.TabIndex = 1;
            // 
            // cLB_TinhTrangHN
            // 
            this.cLB_TinhTrangHN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cLB_TinhTrangHN.FormattingEnabled = true;
            this.cLB_TinhTrangHN.Items.AddRange(new object[] {
            "Độc thân",
            "Ly hôn"});
            this.cLB_TinhTrangHN.Location = new System.Drawing.Point(3, 3);
            this.cLB_TinhTrangHN.Name = "cLB_TinhTrangHN";
            this.cLB_TinhTrangHN.Size = new System.Drawing.Size(244, 274);
            this.cLB_TinhTrangHN.TabIndex = 0;
            // 
            // tableLP_NutThaoTac
            // 
            this.tableLP_NutThaoTac.ColumnCount = 2;
            this.tableLP_NutThaoTac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLP_NutThaoTac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLP_NutThaoTac.Controls.Add(this.btn_ChonTatCa, 1, 0);
            this.tableLP_NutThaoTac.Controls.Add(this.btn_XacNhan, 0, 0);
            this.tableLP_NutThaoTac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLP_NutThaoTac.Location = new System.Drawing.Point(3, 283);
            this.tableLP_NutThaoTac.Name = "tableLP_NutThaoTac";
            this.tableLP_NutThaoTac.RowCount = 1;
            this.tableLP_NutThaoTac.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLP_NutThaoTac.Size = new System.Drawing.Size(244, 64);
            this.tableLP_NutThaoTac.TabIndex = 1;
            // 
            // btn_ChonTatCa
            // 
            this.btn_ChonTatCa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ChonTatCa.Location = new System.Drawing.Point(125, 3);
            this.btn_ChonTatCa.Name = "btn_ChonTatCa";
            this.btn_ChonTatCa.Size = new System.Drawing.Size(116, 58);
            this.btn_ChonTatCa.TabIndex = 1;
            this.btn_ChonTatCa.Text = "Chọn / Bỏ chọn tất cả";
            this.btn_ChonTatCa.UseVisualStyleBackColor = true;
            // 
            // btn_XacNhan
            // 
            this.btn_XacNhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_XacNhan.Location = new System.Drawing.Point(3, 3);
            this.btn_XacNhan.Name = "btn_XacNhan";
            this.btn_XacNhan.Size = new System.Drawing.Size(116, 58);
            this.btn_XacNhan.TabIndex = 0;
            this.btn_XacNhan.Text = "Xác nhận";
            this.btn_XacNhan.UseVisualStyleBackColor = true;
            // 
            // QLNS_DSTinhTrangHN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.tableLP_TinhTrangHN);
            this.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "QLNS_DSTinhTrangHN";
            this.Size = new System.Drawing.Size(250, 350);
            this.tableLP_TinhTrangHN.ResumeLayout(false);
            this.tableLP_NutThaoTac.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLP_TinhTrangHN;
        private System.Windows.Forms.CheckedListBox cLB_TinhTrangHN;
        private System.Windows.Forms.TableLayoutPanel tableLP_NutThaoTac;
        private System.Windows.Forms.Button btn_ChonTatCa;
        private System.Windows.Forms.Button btn_XacNhan;
    }
}
