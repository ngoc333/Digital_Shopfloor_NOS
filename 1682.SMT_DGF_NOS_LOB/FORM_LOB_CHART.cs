using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using DevExpress.XtraGauges.Core.Model;
using System.Threading;
using DevExpress.XtraCharts;

namespace FORM
{
    public partial class FORM_LOB_CHART : Form
    {
        public FORM_LOB_CHART()
        {
            InitializeComponent();
        }
          int indexScreen;
        string plant_code, line_code, mline_code;
        int cCount = 0;
        Form[] arrForm = new Form[3];
       // init strinit = new init();
        public FORM_LOB_CHART(string Title, int _indexScreen, string plant, string line, string mline)
        {
            InitializeComponent();
            indexScreen = _indexScreen;
            plant_code = plant;
            mline_code = line;
            line_code = mline;
            tmrDate.Stop();
            lblTitle.Text = Title;
        }
        string plant = ComVar.Var._strValue1;
        string line = ComVar.Var._strValue2;
        private void GoFullscreen()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;

        }


        #region Absent
        private void loadChartAbsent(DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent arcScaleComponent
                                    , DevExpress.XtraCharts.ChartControl argChart
                                    , DevExpress.XtraGauges.Win.Base.LabelComponent arglbl
                                    , string argPer, string argPlan, string argNoPlan)
        {
            try
            {
                float value = 0;
                //Chart Per
                arcScaleComponent.EnableAnimation = false;
                arcScaleComponent.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
                arcScaleComponent.EasingFunction = new BackEase();
                arglbl.Text = "0";
                arcScaleComponent.Value = 0;

                arcScaleComponent.EnableAnimation = true;
                arcScaleComponent.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
                arcScaleComponent.EasingFunction = new BackEase();
                arglbl.Text = argPer;
                float.TryParse(argPer, out value);
                arglbl.Text = value.ToString("##0.#");
                arcScaleComponent.Value = value;

                arcScaleComponent.MinValue = 0f;
                arcScaleComponent.MaxValue = 20f;
                //arcScaleComponent.Ranges[0].StartValue = 0;
                //arcScaleComponent.Ranges[0].EndValue = arcScaleComponent.Ranges[1].StartValue = (float)9; ;
                //arcScaleComponent.Ranges[1].EndValue = arcScaleComponent.Ranges[2].StartValue = (float)10;
                //arcScaleComponent.Ranges[2].EndValue = (float)10;

                //Chart Absent
                /*DataTable dt_tmp = new DataTable();
                dt_tmp.Columns.Add("CAPTION");
                dt_tmp.Columns.Add("VALUE", typeof(double));

                dt_tmp.Rows.Add();
                dt_tmp.Rows[0]["CAPTION"] = "NO PLAN";
                dt_tmp.Rows[0]["VALUE"] = argNoPlan == "" ? "0" : argNoPlan;
                dt_tmp.Rows.Add();
                dt_tmp.Rows[1]["CAPTION"] = "PLAN";
                dt_tmp.Rows[1]["VALUE"] = argPlan;

                argChart.DataSource = dt_tmp;
                argChart.Series[0].ArgumentDataMember = "CAPTION";
                argChart.Series[0].ValueDataMembers.AddRange(new string[] { "VALUE" });
                argChart.Series[0].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;

                */
            }
            catch
            { }
        }

        private void loadDataGridAbsent(DataTable argDt)
        {
            try
            {
                //if (argDt == null || argDt.Rows.Count == 0) return;
                //string[] arr = {"MON", "THEDATE" 
                //         //   ,"TOT_MAN", "TOT_NO_PLAN", "TOT_PLAN", "TOT_PER", "TOT_TUNOVER",  "TOT_TUNOVER_PER"
                //            ,"MAN", "NO_PLAN", "PLAN", "PER", "TUNOVER",  "TUNOVER_PER"
                //          //  ,"MAN2", "NO_PLAN2", "PLAN2", "PER2", "TUNOVER2",  "TUNOVER_PER2"                            
                //           };
                //axfpAbsent.Visible = false;
                //int iNumRow = argDt.Rows.Count;
                //axfpAbsent.MaxRows = 8;
                //axfpAbsent.MaxCols = 5;
                //axfpAbsent.MaxCols = 50;
                //axfpAbsent.SetText(1, 3, argDt.Rows[0]["LOC"].ToString());
                //for (int i = 0; i < argDt.Rows.Count; i++)
                //{
                //    axfpAbsent.set_ColWidth(i + 4, Convert.ToDouble(argDt.Rows[0]["COL_W"].ToString()));
                //    for (int j = 0; j < arr.Length; j++)
                //    {
                //        axfpAbsent.Col = i + 4;
                //        axfpAbsent.Row = j + 1;
                //        axfpAbsent.Text = argDt.Rows[i][arr[j]].ToString();
                //        if (j + 1 > 2)
                //        {
                //            axfpAbsent.BackColor = Color.White;
                //            axfpAbsent.ForeColor = Color.Black;
                //            axfpAbsent.TypeHAlign = FPSpreadADO.TypeHAlignConstants.TypeHAlignRight;
                //            axfpAbsent.TypeVAlign = FPSpreadADO.TypeVAlignConstants.TypeVAlignCenter;
                //        }
                //        else if (j + 1 == 1)
                //        {
                //            axfpAbsent.BackColor = Color.Gray;
                //            axfpAbsent.ForeColor = Color.White;
                //            axfpAbsent.TypeHAlign = FPSpreadADO.TypeHAlignConstants.TypeHAlignCenter;
                //            axfpAbsent.TypeVAlign = FPSpreadADO.TypeVAlignConstants.TypeVAlignCenter;
                //        }
                //        else if (j + 1 == 2)
                //        {
                //            axfpAbsent.BackColor = Color.Silver;
                //            axfpAbsent.ForeColor = Color.White;
                //            axfpAbsent.TypeHAlign = FPSpreadADO.TypeHAlignConstants.TypeHAlignCenter;
                //            axfpAbsent.TypeVAlign = FPSpreadADO.TypeVAlignConstants.TypeVAlignCenter;
                //        }


                //        // axfpAbsent.SetText(i + 4, j + 1, argDt.Rows[i][arr[j]].ToString());
                //    }

                //    if (argDt.Rows[i]["TODAY"].ToString() == argDt.Rows[i]["THEDATE"].ToString())
                //    {
                //        loadChartAbsent(arcScaleComponentRub, chartHrCmp, lblRubValueG, argDt.Rows[i]["PER"].ToString(), argDt.Rows[i]["PLAN"].ToString(), argDt.Rows[i]["NO_PLAN"].ToString());

                //    }

                //}
                //axfpAbsent.Row = -1;
                //axfpAbsent.Col = iNumRow + 3;
                //axfpAbsent.BackColor = Color.Orange;
                //axfpAbsent.ForeColor = Color.White;

                //axfpAbsent.SetCellBorder(iNumRow + 3, 1, iNumRow + 3, axfpAbsent.MaxRows, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexBottom, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleBlank);


                //axfpAbsent.AddCellSpan(4, 1, iNumRow - 1, 1);
                //axfpAbsent.AddCellSpan(iNumRow + 3, 1, 1, 2);
                //axfpAbsent.set_ColWidth(iNumRow + 3, 8);
                //axfpAbsent.MaxCols = iNumRow + 3;
            }
            catch
            { }
            //finally { axfpAbsent.Visible = true; }


        }

       
        private void chartHr(DataTable argDt, DevExpress.XtraCharts.ChartControl argChart)
        {
            try
            {
                if (argDt == null || argDt.Rows.Count == 0) return;
                string strTotal = "";
                double totalMain = 0;
                DataTable dt = argDt.Clone();
                dt.Columns["VALUE_DATA"].DataType = typeof(double);
                foreach (DataRow row in argDt.Rows)
                    dt.ImportRow(row);

                argChart.DataSource = dt;
                argChart.Series[0].ArgumentDataMember = "CAPTION";
                argChart.Series[0].ValueDataMembers.AddRange(new string[] { "VALUE_DATA" });

                double iAbsent, iAttend;
                double.TryParse(dt.Rows[0][1].ToString(), out iAbsent);
                double.TryParse(dt.Rows[1][1].ToString(), out iAttend);

                // return;
                totalMain = iAbsent + iAttend;

                strTotal = "Total Absent\n"
                       + totalMain.ToString() + " Person(s)\n"
                       + (Math.Round(totalMain * 100 / (totalMain + double.Parse(dt.Rows[2][1].ToString())), 1)).ToString() + " %";

                if (argChart.Name == "chartHrCmp")
                {
                    //lblTotAbsent.Text = strTotal;
                }
                else
                {
                    //lblTotAbsent.Text = strTotal;   //PHP
                }


                //if (iAbsent / (iAbsent + iAttend) * 100 >= 5)
                //    argChart.PaletteName = "Absent_Red";
                //else
                //    argChart.PaletteName = "Absent_Blue";
            }
            catch
            {
            }

            //argChart.Series[0].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
            //DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            // chartTitle1.Font = new System.Drawing.Font("Tahoma", 20F);
            //this.argChart.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] { chartTitle1 });
        }


        #endregion Absent



        private void loadChartLine(string type, string ymd, string plant, string line, string mline)
        {
            try
            {

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void loadData(string type, string ymd, string plant, string line, string mline)
        {
            try
            {
                ymd = dtpDate.DateTime.ToString("yyyyMMdd");
                chart.DataSource = null;
                chart1.DataSource = null;
                DataTable dt = null;
                DataTable dt1 = null;
                DataTable dtChart = null;
                DataTable dtChart1 = null;
                dt = GET_DATA(type, ymd, plant, line, "001");
                dtChart = GET_DATA("CHART", ymd, plant, line, "001");

                dt1 = GET_DATA(type, ymd, plant, line, "002");
                dtChart1 = GET_DATA("CHART", ymd, plant, line, "002");



                if (dt.Rows.Count > 0 && dt1.Rows.Count > 0)
                {
                    if (type == "LOB_RESULT")
                    {
                        lblLobChart.Text = dt.Rows[0]["LOB_RESULT"].ToString() + "%";

                        lblLC_002.Text = dt1.Rows[0]["LOB_RESULT"].ToString() + "%";
                    }

                    if (type == "MODEL")
                    {
                        lblModel.Text = dt.Rows[0]["MODEL_NAME"].ToString();
                        lblStyle.Text = dt.Rows[0]["STYLE_NAME"].ToString();

                        lblModel_002.Text = dt1.Rows[0]["MODEL_NAME"].ToString();
                        lblStyle_002.Text = dt1.Rows[0]["STYLE_NAME"].ToString();
                    }
                    if (type == "TAKTTIME")
                    {
                        lblTakttime.Text = dt.Rows[0]["TAKTTIME"].ToString();

                        lblTakttime_002.Text = dt1.Rows[0]["TAKTTIME"].ToString();
                    }
                    if (type == "HIGH_CT")
                    {
                        lblHighest.Text = dt.Rows[0]["MAX_CYCLE_TIME"].ToString();

                        lblHighest_002.Text = dt1.Rows[0]["MAX_CYCLE_TIME"].ToString();
                    }
                }
                else
                {
                    if (type == "LOB_RESULT")
                    {
                        lblLobChart.Text = "0";
                        lblLC_002.Text = "0";
                    }

                    if (type == "MODEL")
                    {
                        lblModel.Text = "0";
                        lblStyle.Text = "0";

                        lblModel_002.Text = "0";
                        lblStyle_002.Text = "0";
                    }
                    if (type == "TAKTTIME")
                    {
                        lblTakttime.Text = "0";
                        lblTakttime_002.Text = "0";
                    }
                    if (type == "HIGH_CT")
                    {
                        lblHighest.Text = "0";
                        lblHighest_002.Text = "0";
                    }
                }
                if (dtChart == null) return;
                if (dtChart1 == null) return;

                if (dtChart.Rows.Count > 0)
                {
                    Series series1 = new Series("CYCLE TIME", ViewType.Bar);
                    chart.Series[0].Points.Clear();
                    for (int i = 0; i < dtChart.Rows.Count; i++)
                    {
                        series1.Points.Add(new SeriesPoint(dtChart.Rows[i]["PROCESS_NAME_VN"].ToString(), dtChart.Rows[i]["CYCLE_TIME"].ToString()));

                        double CycleVal,TaktTimeVal;
                        double.TryParse(dtChart.Rows[i]["CYCLE_TIME"].ToString(), out CycleVal); //out
                        double.TryParse(dtChart.Rows[i]["TAKTTIME"].ToString(), out TaktTimeVal); //out
                        if (CycleVal > TaktTimeVal || CycleVal < (TaktTimeVal / 2))
                        {
                            series1.Points[i].Color = Color.Red;
                        }

                    }
                    chart.SeriesSerializable = new DevExpress.XtraCharts.Series[] { series1};
                    ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].AxisValue = dtChart.Rows[0]["TAKTTIME"].ToString();

                }

                if (dtChart1.Rows.Count > 0)
                {
                    //chart1.DataSource = dtChart1;
                    //chart1.Series[0].ArgumentDataMember = "PROCESS_NAME_VN";
                    //chart1.Series[0].ValueDataMembers.AddRange(new string[] { "CYCLE_TIME" });
                    //((XYDiagram)chart1.Diagram).AxisY.ConstantLines[0].AxisValue = dtChart1.Rows[0]["TAKTTIME"].ToString();

                    Series series1 = new Series("CYCLE TIME", ViewType.Bar);
                    chart1.Series[0].Points.Clear();
                    for (int i = 0; i < dtChart1.Rows.Count; i++)
                    {
                        series1.Points.Add(new SeriesPoint(dtChart1.Rows[i]["PROCESS_NAME_VN"].ToString(), dtChart1.Rows[i]["CYCLE_TIME"].ToString()));

                        double CycleVal, TaktTimeVal;
                        double.TryParse(dtChart1.Rows[i]["CYCLE_TIME"].ToString(), out CycleVal); //out
                        double.TryParse(dtChart1.Rows[i]["TAKTTIME"].ToString(), out TaktTimeVal); //out
                        if (CycleVal > TaktTimeVal || CycleVal < (TaktTimeVal / 2))
                        {
                            series1.Points[i].Color = Color.Red;
                        }

                    }
                    chart1.SeriesSerializable = new DevExpress.XtraCharts.Series[] { series1 };
                    ((XYDiagram)chart1.Diagram).AxisY.ConstantLines[0].AxisValue = dtChart1.Rows[0]["TAKTTIME"].ToString();
                }

                //chartControl1.Series.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }


        #region DB
        private DataTable GET_DATA(string V_P_QTYPE, string V_P_YMD, string plant, string line, string mline)
        {
            COM.OraDB MyOraDB = new COM.OraDB();

            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_PROD.SP_SMT_LOB_CHART";

                MyOraDB.ReDim_Parameter(6);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_QTYPE";
                MyOraDB.Parameter_Name[1] = "V_P_YMD";
                MyOraDB.Parameter_Name[2] = "V_P_LINE";
                MyOraDB.Parameter_Name[3] = "V_P_MLINE";
                MyOraDB.Parameter_Name[4] = "V_P_UPS_MLINE";
                MyOraDB.Parameter_Name[5] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = V_P_QTYPE;
                MyOraDB.Parameter_Values[1] = dtpDate.DateTime.ToString("yyyyMMdd");
                MyOraDB.Parameter_Values[2] = plant;
                MyOraDB.Parameter_Values[3] = line;
                MyOraDB.Parameter_Values[4] = mline;
                MyOraDB.Parameter_Values[5] = "";

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

        #endregion DB

        private void FORM_LOB_CHART_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "Daily LOB Chart - Line 1";
            simpleButton1.Enabled = true;
            simpleButton2.Enabled = false;
            simpleButton3.Enabled = false;
            simpleButton4.Enabled = false;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            dtpDate.DateTime = DateTime.Now;
            string ymd = dtpDate.DateTime.ToString("yyyyMMdd");

            loadData("LOB_RESULT", ymd, plant, line, "001");
            loadData("MODEL", ymd, plant,"","001");
            loadData("TAKTTIME", ymd, plant, "", "001");
            loadData("HIGH_CT", ymd, plant, line, "001");

            loadData("LOB_RESULT", ymd, plant, line, "002");
            loadData("MODEL", ymd, plant, "", "002");
            loadData("TAKTTIME", ymd, plant, "", "002");
            loadData("HIGH_CT", ymd, plant, line, "002");


            GoFullscreen();
        }
       
        private void tmrDate_Tick(object sender, EventArgs e)
        {
            cCount++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            string ymd = dtpDate.DateTime.ToString("yyyyMMdd");
            if (cCount >= 30)
            {
                cCount = 0;
                loadData("LOB_RESULT", ymd, plant, line, "001");
                loadData("MODEL", ymd, plant, "", "001");
                loadData("TAKTTIME", ymd, plant, "", "001");
                loadData("HIGH_CT", ymd, plant, line, "001");

                loadData("LOB_RESULT", ymd, plant, line, "002");
                loadData("MODEL", ymd, plant, "", "002");
                loadData("TAKTTIME", ymd, plant, "", "002");
                loadData("HIGH_CT", ymd, plant, line, "002");
            }

        }

        private void FORM_LOB_CHART_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                string ymd = dtpDate.DateTime.ToString("yyyyMMdd");
                loadData("LOB_RESULT", ymd, plant, line, "001");
                loadData("MODEL", ymd, plant, "", "001");
                loadData("TAKTTIME", ymd, plant, "", "001");
                loadData("HIGH_CT", ymd, plant, line, "001");

                loadData("LOB_RESULT", ymd, plant, line, "002");
                loadData("MODEL", ymd, plant, "", "002");
                loadData("TAKTTIME", ymd, plant, "", "002");
                loadData("HIGH_CT", ymd, plant, line, "002");
                cCount = 30;
                tmrDate.Start();

            }
            else
                tmrDate.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {

            //lblTitle.Text = "Human Absenteeism by Year";
            //btnYM = "Y";
            //axfpAbsent.SetText(1, 1, "Year");
            //loadData();
            //simpleButton3.Enabled = true;
            //simpleButton4.Enabled = false;
            //uc_month.Visible = false;
            //uc_year.Visible = true;
        }
        string btnYM;
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //lblTitle.Text = "Human Absenteeism by Month";
            //btnYM = "A";
            //axfpAbsent.SetText(1, 1, "Month");
            //loadData();
            //simpleButton3.Enabled = false;
            //simpleButton4.Enabled = true;
            //uc_month.Visible = true;
           //uc_year.Visible = false;
           
        }

        private void uc_month_ValueChangeEvent(object sender, EventArgs e)
        {
           // loadData();
        }

        private void initForm()
        {

        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }

        private void menu_Click(object sender, EventArgs e)
        {

        }

        private void cboLine_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            string ymd = dtpDate.DateTime.ToString("yyyyMMdd");
            loadData("LOB_RESULT", ymd, plant, line, "001");
            loadData("MODEL", ymd, plant, "", "001");
            loadData("TAKTTIME", ymd, plant, "", "001");
            loadData("HIGH_CT", ymd, plant, line, "001");

            loadData("LOB_RESULT", ymd, plant, line, "002");
            loadData("MODEL", ymd, plant, "", "002");
            loadData("TAKTTIME", ymd, plant, "", "002");
            loadData("HIGH_CT", ymd, plant, line, "002");
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
