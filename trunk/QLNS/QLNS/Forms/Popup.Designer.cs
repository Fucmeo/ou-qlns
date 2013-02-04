namespace QLNS.Forms
{
    partial class Popup
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
            this.tableLP_Popup = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_TenPopup = new System.Windows.Forms.Label();
            this.txt_TenPopup = new System.Windows.Forms.TextBox();
            this.btn_Popup = new System.Windows.Forms.Button();
            this.tableLP_Popup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLP_Popup
            // 
            this.tableLP_Popup.ColumnCount = 2;
            this.tableLP_Popup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.52482F));
            this.tableLP_Popup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.47518F));
            this.tableLP_Popup.Controls.Add(this.lbl_TenPopup, 0, 0);
            this.tableLP_Popup.Controls.Add(this.txt_TenPopup, 1, 0);
            this.tableLP_Popup.Controls.Add(this.btn_Popup, 0, 1);
            this.tableLP_Popup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLP_Popup.Location = new System.Drawing.Point(0, 0);
            this.tableLP_Popup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLP_Popup.Name = "tableLP_Popup";
            this.tableLP_Popup.RowCount = 2;
            this.tableLP_Popup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLP_Popup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLP_Popup.Size = new System.Drawing.Size(382, 155);
            this.tableLP_Popup.TabIndex = 0;
            // 
            // lbl_TenPopup
            // 
            this.lbl_TenPopup.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_TenPopup.AutoSize = true;
            this.lbl_TenPopup.Location = new System.Drawing.Point(3, 27);
            this.lbl_TenPopup.Name = "lbl_TenPopup";
            this.lbl_TenPopup.Size = new System.Drawing.Size(56, 23);
            this.lbl_TenPopup.TabIndex = 0;
            this.lbl_TenPopup.Text = "label1";
            // 
            // txt_TenPopup
            // 
            this.txt_TenPopup.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_TenPopup.Location = new System.Drawing.Point(142, 24);
            this.txt_TenPopup.Name = "txt_TenPopup";
            this.txt_TenPopup.Size = new System.Drawing.Size(237, 29);
            this.txt_TenPopup.TabIndex = 1;
            // 
            // btn_Popup
            // 
            this.btn_Popup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLP_Popup.SetColumnSpan(this.btn_Popup, 2);
            this.btn_Popup.Location = new System.Drawing.Point(147, 92);
            this.btn_Popup.Name = "btn_Popup";
            this.btn_Popup.Size = new System.Drawing.Size(88, 47);
            this.btn_Popup.TabIndex = 2;
            this.btn_Popup.Text = "Thêm";
            this.btn_Popup.UseVisualStyleBackColor = true;
            // 
            // Popup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(382, 155);
            this.Controls.Add(this.tableLP_Popup);
            this.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 200);
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "Popup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Popup";
            this.tableLP_Popup.ResumeLayout(false);
            this.tableLP_Popup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLP_Popup;
        private System.Windows.Forms.Label lbl_TenPopup;
        private System.Windows.Forms.TextBox txt_TenPopup;
        private System.Windows.Forms.Button btn_Popup;
    }
}