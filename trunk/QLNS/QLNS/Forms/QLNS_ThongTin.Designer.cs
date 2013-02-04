namespace QLNS.Forms
{
    partial class QLNS_ThongTin
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLP_HienThiTT = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.qlnS_HienThiThongTin1 = new QLNS.UCs.QLNS_HienThiThongTin();
            this.tableLP_HienThiTT.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLP_HienThiTT
            // 
            this.tableLP_HienThiTT.ColumnCount = 1;
            this.tableLP_HienThiTT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLP_HienThiTT.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLP_HienThiTT.Controls.Add(this.qlnS_HienThiThongTin1, 0, 1);
            this.tableLP_HienThiTT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLP_HienThiTT.Location = new System.Drawing.Point(0, 0);
            this.tableLP_HienThiTT.Name = "tableLP_HienThiTT";
            this.tableLP_HienThiTT.RowCount = 3;
            this.tableLP_HienThiTT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.771574F));
            this.tableLP_HienThiTT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.22842F));
            this.tableLP_HienThiTT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLP_HienThiTT.Size = new System.Drawing.Size(1105, 985);
            this.tableLP_HienThiTT.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1105, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // qlnS_HienThiThongTin1
            // 
            this.qlnS_HienThiThongTin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qlnS_HienThiThongTin1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qlnS_HienThiThongTin1.Location = new System.Drawing.Point(3, 49);
            this.qlnS_HienThiThongTin1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.qlnS_HienThiThongTin1.Name = "qlnS_HienThiThongTin1";
            this.qlnS_HienThiThongTin1.Size = new System.Drawing.Size(1099, 901);
            this.qlnS_HienThiThongTin1.TabIndex = 3;
            // 
            // QLNS_ThongTin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 985);
            this.Controls.Add(this.tableLP_HienThiTT);
            this.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1000, 800);
            this.Name = "QLNS_ThongTin";
            this.Text = "QLNS_HienThiThongTin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.QLNS_ThongTin_Load);
            this.tableLP_HienThiTT.ResumeLayout(false);
            this.tableLP_HienThiTT.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLP_HienThiTT;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private UCs.QLNS_HienThiThongTin qlnS_HienThiThongTin1;

    }
}