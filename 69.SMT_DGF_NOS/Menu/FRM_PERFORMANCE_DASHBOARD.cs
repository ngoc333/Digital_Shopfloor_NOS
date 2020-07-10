using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FORM
{
    public partial class FRM_PERFORMANCE_DASHBOARD : Form
    {
        public FRM_PERFORMANCE_DASHBOARD()
        {
            InitializeComponent();
        }
        
        private readonly string line;
        private readonly string Mline;
        private readonly string Lang;
       // readonly Form[] arrForm = new Form[3];
        public FRM_PERFORMANCE_DASHBOARD(string Title, string _Line, string _Mline, string _Lang)
        {
            InitializeComponent();
           
            Mline = _Mline;
            line = _Line;
            Lang = _Lang;
            tmrDate.Stop();
            lblTitle.Text = Title;

        }

        #region UserControl
        readonly UC.UC_GRID_PERFORMANCE_DASHBOARD UC_PRODUCTION = new UC.UC_GRID_PERFORMANCE_DASHBOARD("Production");
        readonly UC.UC_GRID_PERFORMANCE_DASHBOARD UC_PRODUCTIVE = new UC.UC_GRID_PERFORMANCE_DASHBOARD("Productivity");
        readonly UC.UC_GRID_PERFORMANCE_DASHBOARD UC_INTERNAL = new UC.UC_GRID_PERFORMANCE_DASHBOARD("Internal Defective Return");
        readonly UC.UC_GRID_PERFORMANCE_DASHBOARD UC_EXTERNAL = new UC.UC_GRID_PERFORMANCE_DASHBOARD("External Defective Return");
        readonly UC.UC_GRID_PERFORMANCE_DASHBOARD UC_BTS = new UC.UC_GRID_PERFORMANCE_DASHBOARD("BTS");
        readonly UC.UC_GRID_PERFORMANCE_DASHBOARD UC_LEADTIME_FG = new UC.UC_GRID_PERFORMANCE_DASHBOARD("Lead time (F/G)");
        readonly UC.UC_GRID_PERFORMANCE_DASHBOARD UC_DOWNTIME = new UC.UC_GRID_PERFORMANCE_DASHBOARD("Downtime");
        readonly UC.UC_GRID_PERFORMANCE_DASHBOARD UC_ABSENT = new UC.UC_GRID_PERFORMANCE_DASHBOARD("Absenteeism");
        readonly UC.UC_GRID_PERFORMANCE_DASHBOARD UC_TURNOVER = new UC.UC_GRID_PERFORMANCE_DASHBOARD("Turnover");
        #endregion
        #region UserControl_vn
        readonly UC.UC_GRID_PERFORMANCE_DASHBOARD UC_PRODUCTION_VN = new UC.UC_GRID_PERFORMANCE_DASHBOARD("Sản xuất");
        readonly UC.UC_GRID_PERFORMANCE_DASHBOARD UC_PRODUCTIVE_VN = new UC.UC_GRID_PERFORMANCE_DASHBOARD("Năng suất");
        readonly UC.UC_GRID_PERFORMANCE_DASHBOARD UC_INTERNAL_VN = new UC.UC_GRID_PERFORMANCE_DASHBOARD("Hàng hư nội bộ trả về");
        readonly UC.UC_GRID_PERFORMANCE_DASHBOARD UC_EXTERNAL_VN = new UC.UC_GRID_PERFORMANCE_DASHBOARD("Hàng hư xuởng trả về");
        readonly UC.UC_GRID_PERFORMANCE_DASHBOARD UC_BTS_VN = new UC.UC_GRID_PERFORMANCE_DASHBOARD("BTS");
        readonly UC.UC_GRID_PERFORMANCE_DASHBOARD UC_LEADTIME_FG_VN = new UC.UC_GRID_PERFORMANCE_DASHBOARD("Doanh thu");
        readonly UC.UC_GRID_PERFORMANCE_DASHBOARD UC_DOWNTIME_VN = new UC.UC_GRID_PERFORMANCE_DASHBOARD("Downtime");
        readonly UC.UC_GRID_PERFORMANCE_DASHBOARD UC_ABSENT_VN = new UC.UC_GRID_PERFORMANCE_DASHBOARD("Vắng mặt");
        readonly UC.UC_GRID_PERFORMANCE_DASHBOARD UC_TURNOVER_VN = new UC.UC_GRID_PERFORMANCE_DASHBOARD("Turnover");
        #endregion
        private void GoFullscreen(bool fullscreen)
        {
            if (fullscreen)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
        }

        private void FRM_PERFORMANCE_DASHBOARD_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            GoFullscreen(true);
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));

            switch (Lang)
            {
                case "Vn":
                    this.tableLayoutPanel1.Controls.Add(UC_PRODUCTION_VN, 0, 0);
                    this.tableLayoutPanel1.Controls.Add(UC_PRODUCTIVE_VN, 1, 0);
                    this.tableLayoutPanel1.Controls.Add(UC_INTERNAL_VN, 2, 0);

                    this.tableLayoutPanel1.Controls.Add(UC_EXTERNAL_VN, 0, 1);
                    this.tableLayoutPanel1.Controls.Add(UC_BTS_VN, 1, 1);
                    this.tableLayoutPanel1.Controls.Add(UC_LEADTIME_FG_VN, 2, 1);

                    this.tableLayoutPanel1.Controls.Add(UC_DOWNTIME_VN, 0, 2);
                    this.tableLayoutPanel1.Controls.Add(UC_ABSENT_VN, 1, 2);
                    this.tableLayoutPanel1.Controls.Add(UC_TURNOVER_VN, 2, 2);

                    break;
                case "En":
                    this.tableLayoutPanel1.Controls.Add(UC_PRODUCTION, 0, 0);
                    this.tableLayoutPanel1.Controls.Add(UC_PRODUCTIVE, 1, 0);
                    this.tableLayoutPanel1.Controls.Add(UC_INTERNAL, 2, 0);

                    this.tableLayoutPanel1.Controls.Add(UC_EXTERNAL, 0, 1);
                    this.tableLayoutPanel1.Controls.Add(UC_BTS, 1, 1);
                    this.tableLayoutPanel1.Controls.Add(UC_LEADTIME_FG, 2, 1);

                    this.tableLayoutPanel1.Controls.Add(UC_DOWNTIME, 0, 2);
                    this.tableLayoutPanel1.Controls.Add(UC_ABSENT, 1, 2);
                    this.tableLayoutPanel1.Controls.Add(UC_TURNOVER, 2, 2);

                    break;
            }








            this.Cursor = Cursors.Default;
            //  UC_PRODUCTIVE.ClearGird();
            //  UC_QUALITY.ClearGird();
        }
        int cCount = 0;
        private void tmrDate_Tick(object sender, EventArgs e)
        {
            cCount++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));

            if (cCount >= 30)
            {
                switch (Lang)
                {
                    case "Vn":
                        UC_PRODUCTION_VN.BindingData("PRODUCTION", line, Mline);
                        UC_PRODUCTIVE_VN.BindingData("PRODUCTIVITY", line, Mline);
                        UC_INTERNAL_VN.BindingData("Internal Defective Return", line, Mline);
                        UC_EXTERNAL_VN.BindingData("External Defective Return", line, Mline);
                        UC_BTS_VN.BindingData("BTS", line, Mline);
                        UC_LEADTIME_FG_VN.BindingData("LEADTIME_FG", line, Mline);
                        UC_DOWNTIME_VN.BindingData("DOWNTIME", line, Mline);
                        UC_ABSENT_VN.BindingData("ABSENT", line, Mline);
                        UC_TURNOVER_VN.BindingData("TURNOVER", line, Mline);
                        break;
                    case "En":
                        UC_PRODUCTION.BindingData("PRODUCTION", line, Mline);
                        UC_PRODUCTIVE.BindingData("PRODUCTIVITY", line, Mline);
                        UC_INTERNAL.BindingData("Internal Defective Return", line, Mline);
                        UC_EXTERNAL.BindingData("External Defective Return", line, Mline);
                        UC_BTS.BindingData("BTS", line, Mline);
                        UC_LEADTIME_FG.BindingData("LEADTIME_FG", line, Mline);
                        UC_DOWNTIME.BindingData("DOWNTIME", line, Mline);
                        UC_ABSENT.BindingData("ABSENT", line, Mline);
                        UC_TURNOVER.BindingData("TURNOVER", line, Mline);
                        break;
                }






                cCount = 0;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FRM_PERFORMANCE_DASHBOARD_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                cCount = 29;
                tmrDate.Start();
            }
            else
                tmrDate.Stop();
        }
    }
}
