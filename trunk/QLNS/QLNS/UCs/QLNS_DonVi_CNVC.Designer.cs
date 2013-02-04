namespace QLNS.UCs
{
    partial class QLNS_DonVi_CNVC
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.TreeV_CNVC = new System.Windows.Forms.TreeView();
            this.btn_TimCNVC = new System.Windows.Forms.Button();
            this.txt_TimCNVC = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_TimDonVi = new System.Windows.Forms.Button();
            this.txt_TimDonVi = new System.Windows.Forms.TextBox();
            this.TreeV_DonVi = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(700, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(353, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(344, 444);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Công nhân viên chức";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel4.Controls.Add(this.TreeV_CNVC, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btn_TimCNVC, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.txt_TimCNVC, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 25);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(338, 416);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // TreeV_CNVC
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.TreeV_CNVC, 2);
            this.TreeV_CNVC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeV_CNVC.Location = new System.Drawing.Point(3, 6);
            this.TreeV_CNVC.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.TreeV_CNVC.Name = "TreeV_CNVC";
            this.TreeV_CNVC.Size = new System.Drawing.Size(332, 341);
            this.TreeV_CNVC.TabIndex = 1;
            this.TreeV_CNVC.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeV_CNVC_NodeMouseDoubleClick);
            // 
            // btn_TimCNVC
            // 
            this.btn_TimCNVC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_TimCNVC.Location = new System.Drawing.Point(239, 360);
            this.btn_TimCNVC.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btn_TimCNVC.Name = "btn_TimCNVC";
            this.btn_TimCNVC.Size = new System.Drawing.Size(95, 48);
            this.btn_TimCNVC.TabIndex = 3;
            this.btn_TimCNVC.Text = "Tìm";
            this.btn_TimCNVC.UseVisualStyleBackColor = true;
            this.btn_TimCNVC.Click += new System.EventHandler(this.btn_TimCNVC_Click);
            // 
            // txt_TimCNVC
            // 
            this.txt_TimCNVC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_TimCNVC.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TimCNVC.Location = new System.Drawing.Point(22, 370);
            this.txt_TimCNVC.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txt_TimCNVC.Name = "txt_TimCNVC";
            this.txt_TimCNVC.Size = new System.Drawing.Size(192, 29);
            this.txt_TimCNVC.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 444);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Đơn vị";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.Controls.Add(this.btn_TimDonVi, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txt_TimDonVi, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.TreeV_DonVi, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 25);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(338, 416);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btn_TimDonVi
            // 
            this.btn_TimDonVi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_TimDonVi.Location = new System.Drawing.Point(239, 360);
            this.btn_TimDonVi.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btn_TimDonVi.Name = "btn_TimDonVi";
            this.btn_TimDonVi.Size = new System.Drawing.Size(95, 48);
            this.btn_TimDonVi.TabIndex = 4;
            this.btn_TimDonVi.Text = "Tìm";
            this.btn_TimDonVi.UseVisualStyleBackColor = true;
            this.btn_TimDonVi.Click += new System.EventHandler(this.btn_TimDonVi_Click);
            // 
            // txt_TimDonVi
            // 
            this.txt_TimDonVi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_TimDonVi.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TimDonVi.Location = new System.Drawing.Point(22, 370);
            this.txt_TimDonVi.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txt_TimDonVi.Name = "txt_TimDonVi";
            this.txt_TimDonVi.Size = new System.Drawing.Size(192, 29);
            this.txt_TimDonVi.TabIndex = 3;
            // 
            // TreeV_DonVi
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.TreeV_DonVi, 2);
            this.TreeV_DonVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeV_DonVi.Location = new System.Drawing.Point(3, 3);
            this.TreeV_DonVi.Name = "TreeV_DonVi";
            this.TreeV_DonVi.Size = new System.Drawing.Size(332, 347);
            this.TreeV_DonVi.TabIndex = 0;
            this.TreeV_DonVi.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeV_DonVi_NodeMouseDoubleClick);
            // 
            // QLNS_DonVi_CNVC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "QLNS_DonVi_CNVC";
            this.Size = new System.Drawing.Size(700, 450);
            this.Load += new System.EventHandler(this.QLNS_DonVi_CNVC_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TreeView TreeV_CNVC;
        private System.Windows.Forms.Button btn_TimCNVC;
        private System.Windows.Forms.TextBox txt_TimCNVC;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TreeView TreeV_DonVi;
        private System.Windows.Forms.Button btn_TimDonVi;
        private System.Windows.Forms.TextBox txt_TimDonVi;

    }
}
