namespace HDQD.UCs
{
    partial class DinhNghiaCT
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
            this.TLP_DinhNghiaCT = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Input = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstb_ToanTu = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstb_PhanTu = new System.Windows.Forms.ListBox();
            this.btn_Luu = new System.Windows.Forms.Button();
            this.btn_Del = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rtb_CongThuc = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.TLP_DinhNghiaCT.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TLP_DinhNghiaCT);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(983, 500);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Công thức";
            // 
            // TLP_DinhNghiaCT
            // 
            this.TLP_DinhNghiaCT.ColumnCount = 3;
            this.TLP_DinhNghiaCT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLP_DinhNghiaCT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.54404F));
            this.TLP_DinhNghiaCT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.29534F));
            this.TLP_DinhNghiaCT.Controls.Add(this.btn_Input, 1, 0);
            this.TLP_DinhNghiaCT.Controls.Add(this.groupBox3, 0, 1);
            this.TLP_DinhNghiaCT.Controls.Add(this.groupBox2, 0, 0);
            this.TLP_DinhNghiaCT.Controls.Add(this.btn_Luu, 1, 2);
            this.TLP_DinhNghiaCT.Controls.Add(this.btn_Del, 1, 1);
            this.TLP_DinhNghiaCT.Controls.Add(this.groupBox4, 2, 0);
            this.TLP_DinhNghiaCT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_DinhNghiaCT.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TLP_DinhNghiaCT.ForeColor = System.Drawing.Color.Black;
            this.TLP_DinhNghiaCT.Location = new System.Drawing.Point(3, 26);
            this.TLP_DinhNghiaCT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TLP_DinhNghiaCT.Name = "TLP_DinhNghiaCT";
            this.TLP_DinhNghiaCT.RowCount = 3;
            this.TLP_DinhNghiaCT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.80467F));
            this.TLP_DinhNghiaCT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.81953F));
            this.TLP_DinhNghiaCT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.06715F));
            this.TLP_DinhNghiaCT.Size = new System.Drawing.Size(977, 470);
            this.TLP_DinhNghiaCT.TabIndex = 1;
            // 
            // btn_Input
            // 
            this.btn_Input.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Input.Location = new System.Drawing.Point(359, 96);
            this.btn_Input.Name = "btn_Input";
            this.btn_Input.Size = new System.Drawing.Size(83, 52);
            this.btn_Input.TabIndex = 3;
            this.btn_Input.Text = ">";
            this.btn_Input.UseVisualStyleBackColor = true;
            this.btn_Input.Click += new System.EventHandler(this.btn_Input_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstb_ToanTu);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 247);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(319, 158);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Toán tử";
            // 
            // lstb_ToanTu
            // 
            this.lstb_ToanTu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstb_ToanTu.FormattingEnabled = true;
            this.lstb_ToanTu.ItemHeight = 21;
            this.lstb_ToanTu.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/",
            "(",
            ")"});
            this.lstb_ToanTu.Location = new System.Drawing.Point(3, 24);
            this.lstb_ToanTu.Name = "lstb_ToanTu";
            this.lstb_ToanTu.Size = new System.Drawing.Size(313, 131);
            this.lstb_ToanTu.TabIndex = 0;
            this.lstb_ToanTu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstb_ToanTu_MouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstb_PhanTu);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(319, 238);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Phần tử";
            // 
            // lstb_PhanTu
            // 
            this.lstb_PhanTu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstb_PhanTu.FormattingEnabled = true;
            this.lstb_PhanTu.ItemHeight = 21;
            this.lstb_PhanTu.Location = new System.Drawing.Point(3, 24);
            this.lstb_PhanTu.Name = "lstb_PhanTu";
            this.lstb_PhanTu.Size = new System.Drawing.Size(313, 211);
            this.lstb_PhanTu.TabIndex = 1;
            this.lstb_PhanTu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstb_PhanTu_MouseClick);
            // 
            // btn_Luu
            // 
            this.btn_Luu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Luu.Location = new System.Drawing.Point(359, 416);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(83, 46);
            this.btn_Luu.TabIndex = 2;
            this.btn_Luu.Text = "Lưu";
            this.btn_Luu.UseVisualStyleBackColor = true;
            // 
            // btn_Del
            // 
            this.btn_Del.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Del.Location = new System.Drawing.Point(359, 300);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(83, 52);
            this.btn_Del.TabIndex = 4;
            this.btn_Del.Text = "<";
            this.btn_Del.UseVisualStyleBackColor = true;
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rtb_CongThuc);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(479, 3);
            this.groupBox4.Name = "groupBox4";
            this.TLP_DinhNghiaCT.SetRowSpan(this.groupBox4, 2);
            this.groupBox4.Size = new System.Drawing.Size(495, 402);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Công thức định nghĩa";
            // 
            // rtb_CongThuc
            // 
            this.rtb_CongThuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_CongThuc.Location = new System.Drawing.Point(3, 24);
            this.rtb_CongThuc.Name = "rtb_CongThuc";
            this.rtb_CongThuc.Size = new System.Drawing.Size(489, 375);
            this.rtb_CongThuc.TabIndex = 0;
            this.rtb_CongThuc.Text = "";
            this.rtb_CongThuc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtb_CongThuc_KeyPress);
            this.rtb_CongThuc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rtb_CongThuc_MouseDown);
            // 
            // DinhNghiaCT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DinhNghiaCT";
            this.Size = new System.Drawing.Size(983, 500);
            this.Load += new System.EventHandler(this.DinhNghiaCT_Load);
            this.groupBox1.ResumeLayout(false);
            this.TLP_DinhNghiaCT.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel TLP_DinhNghiaCT;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstb_ToanTu;
        private System.Windows.Forms.ListBox lstb_PhanTu;
        private System.Windows.Forms.Button btn_Luu;
        private System.Windows.Forms.Button btn_Input;
        private System.Windows.Forms.Button btn_Del;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox rtb_CongThuc;

    }
}
