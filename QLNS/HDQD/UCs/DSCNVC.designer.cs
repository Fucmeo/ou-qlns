namespace HDQD.UCs
{
    partial class DSCNVC
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_ChonTatCa = new System.Windows.Forms.Button();
            this.btn_HuyTatCa = new System.Windows.Forms.Button();
            this.btn_Chon = new System.Windows.Forms.Button();
            this.dtgv_DSCNVC = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_DSCNVC)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 300);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kết quả";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.btn_ChonTatCa, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_HuyTatCa, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_Chon, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtgv_DSCNVC, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(794, 273);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btn_ChonTatCa
            // 
            this.btn_ChonTatCa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_ChonTatCa.Location = new System.Drawing.Point(77, 207);
            this.btn_ChonTatCa.Name = "btn_ChonTatCa";
            this.btn_ChonTatCa.Size = new System.Drawing.Size(109, 63);
            this.btn_ChonTatCa.TabIndex = 7;
            this.btn_ChonTatCa.Text = "Chọn tất cả";
            this.btn_ChonTatCa.UseVisualStyleBackColor = true;
            // 
            // btn_HuyTatCa
            // 
            this.btn_HuyTatCa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_HuyTatCa.Location = new System.Drawing.Point(606, 207);
            this.btn_HuyTatCa.Name = "btn_HuyTatCa";
            this.btn_HuyTatCa.Size = new System.Drawing.Size(109, 63);
            this.btn_HuyTatCa.TabIndex = 6;
            this.btn_HuyTatCa.Text = "Huỷ tất cả";
            this.btn_HuyTatCa.UseVisualStyleBackColor = true;
            // 
            // btn_Chon
            // 
            this.btn_Chon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Chon.Location = new System.Drawing.Point(341, 207);
            this.btn_Chon.Name = "btn_Chon";
            this.btn_Chon.Size = new System.Drawing.Size(109, 63);
            this.btn_Chon.TabIndex = 4;
            this.btn_Chon.Text = "Chọn";
            this.btn_Chon.UseVisualStyleBackColor = true;
            this.btn_Chon.Click += new System.EventHandler(this.btn_Chon_Click);
            // 
            // dtgv_DSCNVC
            // 
            this.dtgv_DSCNVC.AllowUserToAddRows = false;
            this.dtgv_DSCNVC.AllowUserToDeleteRows = false;
            this.dtgv_DSCNVC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dtgv_DSCNVC, 3);
            this.dtgv_DSCNVC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgv_DSCNVC.Location = new System.Drawing.Point(3, 3);
            this.dtgv_DSCNVC.Name = "dtgv_DSCNVC";
            this.dtgv_DSCNVC.ReadOnly = true;
            this.dtgv_DSCNVC.RowTemplate.Height = 24;
            this.dtgv_DSCNVC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgv_DSCNVC.Size = new System.Drawing.Size(788, 198);
            this.dtgv_DSCNVC.TabIndex = 1;
            this.dtgv_DSCNVC.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgv_DSCNVC_CellMouseDoubleClick);
            // 
            // DSCNVC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DSCNVC";
            this.Size = new System.Drawing.Size(800, 300);
            this.Load += new System.EventHandler(this.DSCNVC_Load);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_DSCNVC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dtgv_DSCNVC;
        private System.Windows.Forms.Button btn_ChonTatCa;
        private System.Windows.Forms.Button btn_HuyTatCa;
        private System.Windows.Forms.Button btn_Chon;
    }
}
