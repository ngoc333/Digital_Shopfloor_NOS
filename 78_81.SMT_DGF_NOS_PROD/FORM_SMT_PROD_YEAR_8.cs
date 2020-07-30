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
using System.Runtime.InteropServices;

namespace FORM
{
    public partial class FORM_SMT_PROD_YEAR_8 : Form
    {
        public FORM_SMT_PROD_YEAR_8()
        {
            InitializeComponent();
        }
        [DllImport("user32")]
        static extern bool AnimateWindow(IntPtr hwnd, int time, int flags);
        const int AW_SLIDE = 0X40000;
        const int AW_HOR_POSITIVE = 0X4;
        const int AW_HOR_NEGATIVE = 0X2;
        const int AW_BLEND = 0X80000;
        const int AW_HIDE = 0x00010000;
      //  int indexScreen;
        string line, mline,Lang;
       

        int int_count = 0;
       // int i_col_cur = 0;
        Color BackColor1 = Color.FromArgb(232, 246, 247);
        Color BackColor2 = Color.White;

        private void FRM_SMT_YEAR_PROD_STATUS_Load(object sender, EventArgs e)
        {
            //ClassLib.ComCtl.Form_Maximized(this, indexScreen); //2 man hinh tro len
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            setConfigForm();
           // axfpSpread.Hide();
            //load_data();
            //CreateChart();
        }

        private void showAnimation(Control flg)
        {
            flg.Hide();
            timer2.Stop();
            this.Cursor = Cursors.WaitCursor;
            load_data();
            AnimateWindow(flg.Handle, 300, AW_SLIDE | 0X4); //IPEX_Monitor.ClassLib.WinAPI.getSlidType("2")
            flg.Show();
            timer2.Interval = 1000;
            timer2.Start();
            this.Cursor = Cursors.Default;
        }

        private void ClearGrid(AxFPSpreadADO.AxfpSpread Grid)
        {
            for (int irow = 3; irow <= Grid.MaxRows; irow++)
            {
                Grid.Row = irow;
                for (int icol = 1; icol <= Grid.MaxCols; icol++)
                {
                    Grid.Col = icol;
                    //Grid.SetText(icol, irow, "");
                    switch (irow % 2)
                    {
                        case 0:
                            Grid.BackColor = BackColor1;
                            Grid.ForeColor = Color.Black;
                            break;
                        case 1:
                            Grid.BackColor = BackColor2;
                            Grid.ForeColor = Color.Black;
                            break;
                    }
                    Grid.Font = new Font("Calibri", 14, FontStyle.Regular);
                }

                axfpSpread.set_RowHeight(irow, 30);
            }
            axfpSpread.RowsFrozen = 2;
        }

        private void bindingdatachart(DevExpress.XtraCharts.ChartControl _chart, DataTable dt, string col1, string col2)
        {
            _chart.DataSource = dt;
            _chart.Series[0].ArgumentDataMember = "DAY";
            _chart.Series[0].ValueDataMembers.AddRange(new string[] { col1 });
            //chartControl1.Series[0].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Numerical;
            _chart.Series[1].ArgumentDataMember = "DAY";
            _chart.Series[1].ValueDataMembers.AddRange(new string[] { col2 });
            //chartControl1.Series[1].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Numerical;
        }


        private void BindingGauges(DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge circularGauge, double num, int iMin, int iMax, double iRangeMin, double iRangeMax)
        {            
            if (circularGauge.Scales.Count <= 0)
            {
                return;
            }
            circularGauge.Scales[0].EnableAnimation = false;
            circularGauge.Scales[0].MinValue = iMin;
            circularGauge.Scales[0].MaxValue = iMax;
            circularGauge.Scales[0].Value = 90;
            if (circularGauge.Scales[0].Ranges.Count >= 3)
            {
                circularGauge.Scales[0].Ranges[0].StartValue = (float)(iMin);
                circularGauge.Scales[0].Ranges[0].EndValue = (float)iRangeMin;
                circularGauge.Scales[0].Ranges[1].StartValue = (float)iRangeMin;
                circularGauge.Scales[0].Ranges[1].EndValue = (float)iRangeMax;
                circularGauge.Scales[0].Ranges[2].StartValue = (float)iRangeMax;
                circularGauge.Scales[0].Ranges[2].EndValue = (float)(iMax);
            }
            try
            {

                circularGauge.Scales[0].MinValue = iMin;
                circularGauge.Scales[0].MaxValue = iMax;

                circularGauge.Scales[0].EnableAnimation = true;
                circularGauge.Scales[0].EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
                circularGauge.Scales[0].Value = (float)num;
            }
            catch 
            { }
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
        private void load_data()
        {
            try
            {
                load_head();
                DataTable dt = SEL_SMT_YEAR_PROD_STATUS("Q", line, mline, UC_YEAR.GetValue().ToString());
                
                //DataTable dt1 = SEL_SMT_MON_PROD_STATUS("C1", line, mline, "");
                if (dt != null && dt.Rows.Count > 0)
                {
                    axfpSpread.MaxRows = dt.Rows.Count + 2;
                    ClearGrid(axfpSpread);

                    for (int i = 3; i < dt.Rows.Count; i++)
                    {
                        for (int j = 2; j < dt.Columns.Count; j++)
                        {
                            if (dt.Columns[j].ColumnName.Replace("'", "") == "RATE")
                                axfpSpread.SetText(j, i, dt.Rows[i][j].ToString() == "" ? "" : Convert.ToDouble(dt.Rows[i][j].ToString()).ToString() + "%");
                            else
                                axfpSpread.SetText(j, i, dt.Rows[i][j].ToString() == "" ? "" : Convert.ToDouble(dt.Rows[i][j].ToString()).ToString("###,###,###"));

                            if (j == dt.Columns.Count - 1)
                            {
                                axfpSpread.Row = i;
                                axfpSpread.Col = j;
                                if (Convert.ToDouble(GetText(axfpSpread, j, i ).Replace("%", "").Trim()) < 95)
                                {
                                    axfpSpread.BackColor = Color.Red;
                                    axfpSpread.ForeColor = Color.White;
                                }
                                else if (Convert.ToDouble(GetText(axfpSpread, j, i).Replace("%", "").Trim()) > 98)
                                {
                                    axfpSpread.BackColor = Color.Green;
                                    axfpSpread.ForeColor = Color.White;
                                }
                                else
                                {
                                    axfpSpread.BackColor = Color.Yellow;
                                    axfpSpread.ForeColor = Color.Black;
                                }

                            }
                        }
                    }

                }
                DataTable dt_chart = SEL_SMT_YEAR_PROD_STATUS("C", line, mline, UC_YEAR.GetValue().ToString());
               // bindingdatachart(chartControl1, dt_chart, "UPC_QTY", "UPC_TAR");
              //  bindingdatachart(chartControl2, dt_chart, "UPS1_QTY", "UPS1_TAR");
               // bindingdatachart(chartControl3, dt_chart, "UPS2_QTY", "UPS2_TAR");
                bindingdatachart(chartControl4, dt_chart, "FSS_QTY", "FSS_TAR");
                bindingdatachart(chartControl5, dt_chart, "FGA_QTY", "FGA_TAR");
                int i_min = 0, i_max = 100;
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (GetText(axfpSpread, dt.Columns.Count - 1, 4).Replace("%", "").Trim() != "")
                    {

                        if (Convert.ToDouble(GetText(axfpSpread, dt.Columns.Count - 1, 4).Replace("%", "").Trim()) > 90 && Convert.ToDouble(GetText(axfpSpread, dt.Columns.Count - 1, 4).Replace("%", "").Trim()) < 100)
                        {
                            i_min = 90;
                            i_max = 100;
                        }
                        else if (Convert.ToDouble(GetText(axfpSpread, dt.Columns.Count - 1, 4).Replace("%", "").Trim()) < 90)
                        {
                            i_min = 90 - 3;
                            i_max = 100;
                        }
                        else if (Convert.ToDouble(GetText(axfpSpread, dt.Columns.Count - 1, 4).Replace("%", "").Trim()) > 100)
                        {
                            i_min = 90;
                            i_max = 100 + 3;
                        }
                        else if (Convert.ToDouble(GetText(axfpSpread, dt.Columns.Count - 1, 4).Replace("%", "").Trim()) == 0)
                        {
                            i_min = 0;
                            i_max = 100;
                        }
                        BindingGauges(circularGauge1, Convert.ToDouble(GetText(axfpSpread, dt.Columns.Count - 1, 4).Replace("%", "").Trim()), i_min, i_max, 95, 98);
                        lblRate.Text = Convert.ToDouble(GetText(axfpSpread, dt.Columns.Count - 1, 4).Replace("%", "").Trim()) + "%";
                    }
                }
                else
                {
                    BindingGauges(circularGauge1, 0, 0, 100, 95, 98);
                    lblRate.Text = "0%";
                }
            }
            catch
            { 
            }
        }
        private void load_head()
        {
            try
            {
                DataTable dt = SEL_SMT_YEAR_PROD_STATUS("H", line, mline, UC_YEAR.GetValue().ToString());
                int i;
                if (dt != null && dt.Rows.Count > 0)
                {                    
                    //axfpSpread.SetText(1, 1, dt.Rows[0]["MON"].ToString());
                    axfpSpread.set_ColWidth(1, 16.5);
                  //  axfpSpread.set_ColWidth(2, 226);
                    for (i = 0; i < dt.Rows.Count; i++)
                    {

                        if (dt.Rows[i]["CUR"].ToString() == "1")
                        {
                            axfpSpread.Row = 1;
                            axfpSpread.Col = i + 2;
                            axfpSpread.BackColor = Color.Salmon;
                            axfpSpread.Row = 2;
                            axfpSpread.Col = i + 2;
                            axfpSpread.BackColor = Color.Salmon;
                            
                        }
                        //axfpSpread.AddCellSpan(i + 2, 1, 1, 1);
                        axfpSpread.SetText(i + 2, 1, dt.Rows[i]["YEAR"].ToString());
                        axfpSpread.SetText(i + 2, 2, dt.Rows[i]["MON"].ToString());
                        axfpSpread.set_ColWidth(i + 2, (double)221 / (double)(dt.Rows.Count));
                        //axfpSpread.set_ColWidth(i + 2, 240 / 27 + 0.3);
                        //axfpSpread.set_ColWidth(i + 2, (axfpSpread.Width-axfpSpread.get_ColWidth(1))/dt.Rows.Count);
                    }
                    axfpSpread.set_ColWidth(1, 17.7 + 220 - axfpSpread.get_ColWidth(i + 1) * dt.Rows.Count);
                    axfpSpread.AddCellSpan(dt.Rows.Count + 1, 1, 1, 2);
                    axfpSpread.AddCellSpan(dt.Rows.Count, 1, 1, 2);
                    axfpSpread.AddCellSpan(dt.Rows.Count - 1, 1, 1, 2);
                    //axfpSpread.set_ColWidth(1, 16.4 + 0.1 * 25 / dt.Rows.Count ); 
                    for ( int j = i + 2; j<= axfpSpread.MaxCols;j++)
                    {
                        axfpSpread.set_ColWidth(j,0);
                    }
                }
                
            }
            catch
            {
            }
        }

        public DataTable SEL_SMT_YEAR_PROD_STATUS(string ARG_QTYPE, string ARG_LINE, string ARG_MLINE, string ARG_DATE)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_PROD.SP_SMT_YEARLY_PROD_STATUS";

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        private void stackedBarChart_CustomDrawAxisLabel(object sender, CustomDrawAxisLabelEventArgs e)
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

        
        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                if (int_count < 20)
                    int_count++;
                else
                {
                    int_count = 0;
                    showAnimation(axfpSpread);
                }
            }
            catch
            {
            }
        }

        private void lblDate_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            load_data();
        }

        private void FRM_SMT_YEAR_PROD_STATUS_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                cmdBack.Tag = ComVar.Var._Frm_Back;
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                int_count = 29;
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void chartControl1_CustomDrawAxisLabel(object sender, CustomDrawAxisLabelEventArgs e)
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

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        private void UC_YEAR_ValueChangeEvent(object sender, EventArgs e)
        {
            int_count = 0;
            showAnimation(axfpSpread);
        }


        private void initForm()
        {
            line = ComVar.Var._strValue1;
            mline = ComVar.Var._strValue2;
            Lang = ComVar.Var._strValue3;
            switch (Lang)
            {
                case "Vn":
                    btnDay.Text = "Ngày";
                    btnMonth.Text = "Tháng";
                    btnWeek.Text = "Tuần";
                    btnYear.Text = "Năm";
                    lblTitle.Text = "Trạng thái sản xuất theo Năm";
                    break;
                case "En":
                    btnDay.Text = "Day";
                    btnMonth.Text = "Month";
                    btnWeek.Text = "Week";
                    btnYear.Text = "Year";
                    lblTitle.Text = "Production Status by Year";
                    break;
            }

        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }

        private void menu_Click(object sender, EventArgs e)
        {
            Control cnt = (Control)sender;
            ComVar.Var.callForm = cnt.Tag == null ? "" : cnt.Tag.ToString();
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

    }
}
