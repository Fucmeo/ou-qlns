using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business;

namespace HDQD.UCs
{
    public partial class DoiThongTinDV : UserControl
    {
        public DoiThongTinDV()
        {
            InitializeComponent();
        }

        private void DoiThongTinDV_Load(object sender, EventArgs e)
        {
            SetupDTGV_Ten();
            SetupDTGV_ChucDanh();
            SetupDTGV_CapBac();
        }

        private void SetupDTGV_Ten()
        {
            dtgv_DSTen.Columns.Add("tu_dv_id", "");
            dtgv_DSTen.Columns.Add("tu_dv", "Từ");
            dtgv_DSTen.Columns.Add("sang_dv", "Sang");

            dtgv_DSTen.Columns["tu_dv_id"].Visible = false;

            dtgv_DSTen.Columns["tu_dv"].Width = 300;
            dtgv_DSTen.Columns["sang_dv"].Width = 300;
        }

        private void SetupDTGV_ChucDanh()
        {
            dtgv_DSChucDanh.Columns.Add("dv_id", "");
            dtgv_DSChucDanh.Columns.Add("dv", "Đơn vị");
            dtgv_DSChucDanh.Columns.Add("tu_chuc_danh_id", "");
            dtgv_DSChucDanh.Columns.Add("tu_chuc_danh", "Từ");
            dtgv_DSChucDanh.Columns.Add("sang_chuc_danh", "Sang");

            dtgv_DSChucDanh.Columns["dv_id"].Visible = dtgv_DSChucDanh.Columns["tu_chuc_danh_id"].Visible = false;

            dtgv_DSChucDanh.Columns["dv"].Width = dtgv_DSChucDanh.Columns["tu_chuc_danh"].Width = dtgv_DSChucDanh.Columns["sang_chuc_danh"].Width = 300;
        }

        private void SetupDTGV_CapBac()
        {
            dtgv_DSCapBac.Columns.Add("dv_id", "");
            dtgv_DSCapBac.Columns.Add("dv", "Đơn vị");
            dtgv_DSCapBac.Columns.Add("tu_cap_bac_id", "");
            dtgv_DSCapBac.Columns.Add("tu_cap_bac", "Từ");
            dtgv_DSCapBac.Columns.Add("sang_cap_bac", "Sang");

            dtgv_DSCapBac.Columns["dv_id"].Visible = dtgv_DSCapBac.Columns["tu_cap_bac_id"].Visible = false;

            dtgv_DSCapBac.Columns["dv"].Width = dtgv_DSCapBac.Columns["tu_cap_bac"].Width = dtgv_DSCapBac.Columns["sang_cap_bac"].Width = 300;
        }

    }
}
