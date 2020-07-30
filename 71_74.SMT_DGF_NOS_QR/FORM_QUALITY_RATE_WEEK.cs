using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using System.Data.OracleClient;

namespace FORM
{
    public partial class FORM_QUALITY_RATE_WEEK : Form
    {
        public FORM_QUALITY_RATE_WEEK()
        {
            InitializeComponent();
        }
        
         int int_count = 0;
         string line, mline,Lang;
         public FORM_QUALITY_RATE_WEEK(string Title, int _indexScreen, string _line, string _mline,string _Lang)
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        private void initForm()
        {
            line =  ComVar.Var._strValue1;
            mline =  ComVar.Var._strValue2;
            Lang = ComVar.Var._strValue3;
            if (ComVar.Var._strValue3 == "Vn")
                lblTitle.Text = "Tỉ lệ chất lượng theo tuần";
            else
                lblTitle.Text = "QR Status by Week";
        }

        private void FRM_SMT_WEEKLY_FTT_Load(object sender, EventArgs e)
        {
           // ClassLib.ComCtl.Form_Maximized(this, indexScreen); //2 man hinh tro len
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            switch (Lang)
            {
                case "Vn":
                    btnDay.Text = "Ngày";
                    btnMonth.Text = "Tháng";
                    btnWeek.Text = "Tuần";
                    btnYear.Text = "Năm";
                    break;
                case "En":
                    btnDay.Text = "Day";
                    btnMonth.Text = "Month";
                    btnWeek.Text = "Week";
                    btnYear.Text = "Year";
                    break;
            }
          
            //load_data();
        }

        private void load_data()
        {
            try
            {
                DataTable dt = SEL_SMT_WEEK_FTT("Q", line, mline, "");
                DataTable dt_rework = new DataTable();
                DataTable dt_HI = new DataTable();
                dt_rework.Columns.Add("DIV_NAME");
                dt_rework.Columns.Add("QTY", typeof(double));
                dt_HI.Columns.Add("DIV_NAME");
                dt_HI.Columns.Add("QTY", typeof(double));
                double t_rework = 0, t_HI = 0;
                //axfpSpread.set_RowHeight(2, 640);
                //load header
                for (int i_col = 4; i_col < dt.Columns.Count; i_col++)
                {
                    axfpSpread.SetText(i_col + 1, 1, dt.Columns[i_col].ColumnName.Replace("'", ""));
                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    axfpSpread.Enabled = false;
                    axfpSpread.Visible = false;
                    for(int i_row = 0; i_row<dt.Rows.Count;i_row++)
                    {

                        if (dt.Rows[i_row]["DIV"].ToString() == "Reason" && dt.Rows[i_row]["DIV_NAME"].ToString() != "TOTAL" && dt.Rows[i_row]["TYPE"].ToString() == "Rework")
                        {
                            dt_rework.Rows.Add();
                            dt_rework.Rows[dt_rework.Rows.Count - 1]["DIV_NAME"] = dt.Rows[i_row]["DIV_NAME"].ToString();
                            dt_rework.Rows[dt_rework.Rows.Count - 1]["QTY"] = t_rework > 0 ? (Convert.ToDouble(dt.Rows[i_row][dt.Columns.Count - 1].ToString())/t_rework*100).ToString("#,0.0") : "0";
                        }
                        else if (dt.Rows[i_row]["DIV"].ToString() == "Reason" && dt.Rows[i_row]["DIV_NAME"].ToString() == "TOTAL" && dt.Rows[i_row]["TYPE"].ToString() == "Rework")
                        {
                            t_rework = Convert.ToDouble(dt.Rows[i_row][dt.Columns.Count - 1].ToString());
                        }

                        if (dt.Rows[i_row]["DIV"].ToString() == "Reason" && dt.Rows[i_row]["DIV_NAME"].ToString() != "TOTAL" && dt.Rows[i_row]["TYPE"].ToString() == "HI")
                        {
                            dt_HI.Rows.Add();
                            dt_HI.Rows[dt_HI.Rows.Count - 1]["DIV_NAME"] = dt.Rows[i_row]["DIV_NAME"].ToString();
                            dt_HI.Rows[dt_HI.Rows.Count - 1]["QTY"] = t_HI > 0 ? (Convert.ToDouble(dt.Rows[i_row][dt.Columns.Count - 1].ToString()) / t_HI * 100).ToString("#,0.0") : "0";
                        }
                        else if (dt.Rows[i_row]["DIV"].ToString() == "Reason" && dt.Rows[i_row]["DIV_NAME"].ToString() == "TOTAL" && dt.Rows[i_row]["TYPE"].ToString() == "HI")
                        {
                            t_HI = Convert.ToDouble(dt.Rows[i_row][dt.Columns.Count - 1].ToString());
                        }
                        
                        axfpSpread.AddCellSpan(0, i_row + 2, 1, 1);
                        axfpSpread.AddCellSpan(1, i_row + 2, 1, 1);
                        axfpSpread.AddCellSpan(2, i_row + 2, 1, 1);
                        for(int i_col =0; i_col<dt.Columns.Count;i_col++)
                        {
                            if (i_col > 3 && dt.Rows[i_row][3].ToString() != "%" && dt.Rows[i_row][i_col].ToString() != "")
                            {
                                axfpSpread.SetText(i_col + 1, i_row + 2, Convert.ToDouble(dt.Rows[i_row][i_col]).ToString("#,#"));
                            }
                            else if (i_col > 3 && dt.Rows[i_row][3].ToString().Equals("%") && dt.Rows[i_row][i_col].ToString() != "")
                            {
                                axfpSpread.SetText(i_col + 1, i_row + 2, Convert.ToDouble(dt.Rows[i_row][i_col]).ToString("#,0.#"));
                            }
                            else
                            {
                                axfpSpread.SetText(i_col + 1, i_row + 2, dt.Rows[i_row][i_col].ToString());
                            }

                            if (dt.Rows[i_row][3].ToString() == "TOTAL" && i_col>=3)
                            {
                                axfpSpread.Row = i_row + 2;
                                axfpSpread.Col = i_col + 1;
                                axfpSpread.BackColor = Color.Yellow;
                            }
                            else if (dt.Rows[i_row][3].ToString() == "%" && i_col >= 2)
                            {
                                axfpSpread.Row = i_row + 2;
                                axfpSpread.Col = i_col + 1;
                                axfpSpread.BackColor = Color.Orange;
                            }
                            else
                            {
                                axfpSpread.Row = i_row + 2;
                                axfpSpread.Col = i_col + 1;
                                axfpSpread.BackColor = Color.White;
                            }

                        }
                        axfpSpread.set_RowHeight(i_row + 2, 620d/(dt.Rows.Count));
                    }
                    for (int i_row = dt.Rows.Count; i_row < axfpSpread.MaxRows; i_row++)
                    {
                        axfpSpread.set_RowHeight(i_row + 2, 0);
                    }
                    string value = GetText(axfpSpread,1,2);
                    int i_cnt = 0;
                    int i_row_cur = 2;
                    for (int i_row = 0; i_row < dt.Rows.Count; i_row++)
                    {
                        if (GetText(axfpSpread,1,i_row + 2) == value)
                        {
                            i_cnt++;
                        }
                        else
                        {                            
                            axfpSpread.AddCellSpan(1, i_row_cur, 1, i_cnt);
                            value = GetText(axfpSpread, 1, i_row + 2);
                            i_row_cur = i_row + 2;
                            i_cnt = 1;
                        }
                        if(i_row == dt.Rows.Count-1)
                        {
                            axfpSpread.AddCellSpan(1, i_row_cur, 1, i_cnt);
                        }
                    }
                    
                    value = GetText(axfpSpread, 2, 2);
                    i_cnt = 0;
                    i_row_cur = 2;
                    for (int i_row = 0; i_row < dt.Rows.Count; i_row++)
                    {
                        if (GetText(axfpSpread, 2, i_row + 2) == value)
                        {
                            i_cnt++;
                        }
                        else
                        {
                            axfpSpread.AddCellSpan(2, i_row_cur, 1, i_cnt);
                            value = GetText(axfpSpread, 2, i_row + 2);
                            i_row_cur = i_row + 2;
                            i_cnt = 1;
                        }
                        if (i_row == dt.Rows.Count - 1)
                        {
                            axfpSpread.AddCellSpan(2, i_row_cur, 1, i_cnt);
                        }
                    }

                    value = GetText(axfpSpread, 3, 2);
                    i_cnt = 0;
                    i_row_cur = 2;
                    for (int i_row = 0; i_row < dt.Rows.Count; i_row++)
                    {
                        if (GetText(axfpSpread, 3, i_row + 2) == value)
                        {
                            i_cnt++;
                        }
                        else
                        {
                            axfpSpread.AddCellSpan(3, i_row_cur, 1, i_cnt);
                            value = GetText(axfpSpread,3, i_row + 2);
                            i_row_cur = i_row + 2;
                            i_cnt = 1;
                        }
                        if (i_row == dt.Rows.Count - 1)
                        {
                            axfpSpread.AddCellSpan(3, i_row_cur, 1, i_cnt);
                        }
                    }
                    axfpSpread.Enabled = true;
                    axfpSpread.Visible = true;
                }
                CreateChart(chartRework, dt_rework);
                CreateChart(chartHI, dt_HI);
            }
            catch
            {
            }
        }

        private string GetText(AxFPSpreadADO.AxfpSpread spread, int col, int row)
        {
            try
            {
                object data = null;
                spread.GetText(col, row, ref data);
                return data.ToString();
            }
            catch 
            {
                //return "";
                //log.Error(ex);
                return null;
            }

        }


        private void CreateChart(DevExpress.XtraCharts.ChartControl _chart, DataTable dt)
        {
            try
            {
                _chart.DataSource = dt;
                _chart.Series[0].ArgumentDataMember = "DIV_NAME";
                _chart.Series[0].ValueDataMembers.AddRange(new string[] { "QTY" });

            }
            catch 
            {
            }
        }

        private void CreateChart1(DevExpress.XtraCharts.ChartControl Chart, DataTable dt, string v_p, string v_r, string v_b, string v_c)
        {
            try
            {
                Chart.Series.Clear();
                Chart.Titles.Clear();
                //ChartControl PieChart3D = new ChartControl();
                Chart.AppearanceNameSerializable = "Chameleon";
                Chart.PaletteName = "Slipstream";
                DevExpress.XtraCharts.DoughnutSeriesView doughnutSeriesView1 = new DevExpress.XtraCharts.DoughnutSeriesView();

                //Animation
                DevExpress.XtraCharts.PieFlyInAnimation anitemp1 = new DevExpress.XtraCharts.PieFlyInAnimation();
                DevExpress.XtraCharts.PieFanGrowUpAnimation anitemp2 = new DevExpress.XtraCharts.PieFanGrowUpAnimation(); //PieDropInAnimation();
                DevExpress.XtraCharts.PieFanAnimation anitemp3 = new DevExpress.XtraCharts.PieFanAnimation();
                DevExpress.XtraCharts.PieGrowUpAnimation anitemp4 = new DevExpress.XtraCharts.PieGrowUpAnimation();

                DevExpress.XtraCharts.DoughnutSeriesLabel doughnutSeriesLabel1 = new DevExpress.XtraCharts.DoughnutSeriesLabel();
                // Create a pie series.
                Series series1 = new Series("", ViewType.Doughnut);

                // Populate the series with points.
                series1.Points.Add(new SeriesPoint("Prod", v_p));
                series1.Points.Add(new SeriesPoint("Rework", v_r));
                series1.Points.Add(new SeriesPoint("B", v_b));
                series1.Points.Add(new SeriesPoint("C", v_c));

                // Add the series to the chart.
                Chart.Series.Add(series1);

                // Adjust the value numeric options of the series.
                series1.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
                series1.PointOptions.ValueNumericOptions.Precision = 0;

                // Adjust the view-type-specific options of the series.
                //((DoughnutSeriesView)series1.View).Depth = 20;
                //((DoughnutSeriesView)series1.View).ExplodedPoints.Add(series1.Points[0]);
                //((DoughnutSeriesView)series1.View).ExplodedDistancePercentage = 30;

                // Access the diagram's options.

                switch (Chart.Name)
                {
                    case "chartCut2":
                        doughnutSeriesView1.Animation = anitemp1;
                        break;
                    case "chartStock2":
                        doughnutSeriesView1.Animation = anitemp2;
                        break;
                    case "chartAss2":
                        doughnutSeriesView1.Animation = anitemp3;
                        break;
                    case "chartStit2":
                        doughnutSeriesView1.Animation = anitemp4;
                        break;
                }

                series1.Label.TextPattern = "{A} {V:#,#.0}%";

                series1.Label.Font = new System.Drawing.Font("Tahoma", 12F);
                series1.View = doughnutSeriesView1;
                Chart.Legend.Font = new System.Drawing.Font("Tahoma", 12F);
                // Add a title to the chart and hide the legend.
                ChartTitle chartTitle1 = new ChartTitle();
                chartTitle1.Text = "";
                Chart.Titles.Add(chartTitle1);

            }
            catch 
            {
            }
        }

        public DataTable SEL_SMT_WEEK_FTT(string ARG_QTYPE, string ARG_LINE, string ARG_MLINE, string ARG_DATE)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_PROD.SP_SMT_WEEKLY_FTT_NEW";

                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_TYPE";
                MyOraDB.Parameter_Name[1] = "V_P_LINE";
                MyOraDB.Parameter_Name[2] = "V_P_MLINE";
                MyOraDB.Parameter_Name[3] = "V_P_DATE";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_LINE;
                MyOraDB.Parameter_Values[2] = ARG_MLINE;
                MyOraDB.Parameter_Values[3] = ARG_DATE;
                MyOraDB.Parameter_Values[4] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];
            }
            catch
            {
                return null;
            }
        }

        private void chartCut1_CustomDrawAxisLabel(object sender, CustomDrawAxisLabelEventArgs e)
        {
            try
            {
                if (e.Item.Axis is AxisX)
                {
                    e.Item.Text = e.Item.Text.Replace("_", "\n");
                }
            }
            catch
            {

            }
        }

        private void chartStock1_CustomDrawAxisLabel(object sender, CustomDrawAxisLabelEventArgs e)
        {
            try
            {
                if (e.Item.Axis is AxisX)
                {
                    e.Item.Text = e.Item.Text.Replace("_", "\n");
                }
            }
            catch
            {

            }
        }

        private void chartStit1_CustomDrawAxisLabel(object sender, CustomDrawAxisLabelEventArgs e)
        {
            try
            {
                if (e.Item.Axis is AxisX)
                {
                    e.Item.Text = e.Item.Text.Replace("_", "\n");
                }
            }
            catch
            {

            }
        }

        private void chartAss1_CustomDrawAxisLabel(object sender, CustomDrawAxisLabelEventArgs e)
        {
            try
            {
                if (e.Item.Axis is AxisX)
                {
                    e.Item.Text = e.Item.Text.Replace("_", "\n");
                }
            }
            catch
            {

            }
        }

        private void LBL_Click(object sender, EventArgs e)
        {
            load_data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FRM_SMT_WEEKLY_FTT_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                cmdBack.Tag = ComVar.Var._Frm_Back;
                setConfigForm();
                int_count = 20;
                initForm();
                timer1.Start();
                timer2.Start();
            }
            else
            {
                timer1.Stop();
                timer2.Stop();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                if (int_count < 20)
                    int_count++;
                else
                {
                    int_count = 0;
                    load_data();
                }
            }
            catch
            {
            }
        }

        #region  Get Config Data From Database
        /// <summary>
        /// Declare _dtnInit
        /// Dictionary<string, string> _dtnInit = new Dictionary<string, string>();
        /// </summary>
        private void setConfigForm()
        {
            try
            {
                System.Collections.Generic.Dictionary<string, string> dtnInit = new System.Collections.Generic.Dictionary<string, string>();
                dtnInit = ComVar.Func.getInitForm(ComVar.Var._Area + this.GetType().Assembly.GetName().Name, this.GetType().Name);

                for (int i = 0; i < dtnInit.Count; i++)
                {
                    setComValue(dtnInit.ElementAt(i).Key, dtnInit.ElementAt(i).Value);
                }
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.GetType().Name + "-->setConfigForm-->Err:    " + ex.ToString());
            }
        }

        private void setComValue(string obj, string obj_value)
        {
            try
            {
                if (obj.Contains('.'))
                {
                    string[] strSplit = obj.Split('.');
                    Control[] cnt = this.Controls.Find(strSplit[0], true);

                    for (int i = 0; i < cnt.Length; i++)
                    {
                        System.Reflection.PropertyInfo propertyInfo = cnt[i].GetType().GetProperty(strSplit[1]);
                        propertyInfo.SetValue(cnt[i], Convert.ChangeType(obj_value, propertyInfo.PropertyType), null);
                    }
                }
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.GetType().Name + "-->setComValue (" + obj + ", " + obj_value + ") Err:    " + ex.ToString());
            }

        }
        #endregion 

        private void cmd_Click(object sender, EventArgs e)
        {
            Control cnt = (Control)sender;
            ComVar.Var.callForm = cnt.Tag == null ? "" : cnt.Tag.ToString();
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }


        
    }
}
