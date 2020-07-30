using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using DevExpress.XtraCharts;
using System.Runtime.InteropServices;

namespace FORM
{
    public partial class FORM_QUALITY_RATE_MONTH : Form
    {
        public FORM_QUALITY_RATE_MONTH()
        {
            InitializeComponent();
        }
        // int indexScreen;
        string line, Mline,Lang;
        int cCount = 0;
        Form[] arrForm = new Form[3];
        const int AW_SLIDE = 0X40000;
        [DllImport("user32")]
        static extern bool AnimateWindow(IntPtr hwnd, int time, int flags);
        public FORM_QUALITY_RATE_MONTH(string Title, int _indexScreen, string _Line, string _Mline,string _Lang)
        {
            InitializeComponent();
            //indexScreen = _indexScreen;
            
        }

        private void GoFullscreen()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;

        }

        public DataTable SP_SMT_FTT_MONTHLY(string ARG_QTYPE, string ARG_MONTH, string ARG_LINE_CD, string ARG_MLINE_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_FTT_DAILY.SP_SMT_FTT_DAILY_NEW";

                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_TYPE";
                MyOraDB.Parameter_Name[1] = "ARG_MONTH";
                MyOraDB.Parameter_Name[2] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[3] = "ARG_MLINE_CD";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_MONTH;
                MyOraDB.Parameter_Values[2] = ARG_LINE_CD;
                MyOraDB.Parameter_Values[3] = ARG_MLINE_CD;
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


        public DataTable SP_SMT_QR_HI_BC(string ARG_QTYPE, string ARG_LINE_CD, string ARG_MLINE_CD, string ARG_MONTH)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_PHUOC.SP_SMT_QR_BC_HI_CHART_V2";

                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                MyOraDB.Parameter_Name[1] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[2] = "ARG_MLINE_CD";
                MyOraDB.Parameter_Name[3] = "ARG_MONTH";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_LINE_CD;
                MyOraDB.Parameter_Values[2] = ARG_MLINE_CD;
                MyOraDB.Parameter_Values[3] = ARG_MONTH;
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

        private void ClearGrid()
        {
            for (int iRow = 0; iRow <= axfpFTT.MaxRows; iRow++)
            {
                for (int iCol = 2; iCol <= axfpFTT.MaxCols; iCol++)
                {
                    axfpFTT.SetText(iCol, iRow, "");
                }
            }
        }

        private void BindingGrid()
        {
            DataTable dt = SP_SMT_FTT_MONTHLY("Q", UC_MONTH.GetValue() , line, Mline);
            DataTable dtHeader = SP_SMT_FTT_MONTHLY("H", UC_MONTH.GetValue(), line, Mline);
            axfpFTT.Visible = false;
            ClearGrid();
            int iMline;
            int.TryParse(ComVar.Var._strValue2, out iMline);

            if (dt != null && dt.Rows.Count > 0)
            {
                try
                {
                    //for (int k = axfpFTT.MaxCols; k > 3; k--)
                    //{
                    //    axfpFTT.Col = k + 3;
                    //    if (k + 3 > dtHeader.Rows.Count) axfpFTT.ColHidden = true;
                    //    else axfpFTT.ColHidden = false;
                    //}
                    axfpFTT.MaxCols = dtHeader.Rows.Count + 2;

                    axfpFTT.SetText(1, 1, dtHeader.Rows[0]["MON"].ToString());
                    //Write Header
                    for (int i = 0; i < dtHeader.Rows.Count; i++)
                    {
                        axfpFTT.SetText(i + 3, 1, dtHeader.Rows[i]["Day"].ToString() + '\n' + dtHeader.Rows[i]["Day1"].ToString());

                        if (dtHeader.Rows[i]["IS_TODAY"].ToString().Equals("Y"))
                        {
                            axfpFTT.Row = 1;
                            axfpFTT.Col = i + 3;
                            axfpFTT.BackColor = Color.Salmon;
                            axfpFTT.ForeColor = Color.White;

                        }
                        else
                        {
                            axfpFTT.Row = 1;
                            axfpFTT.Col = i + 3;
                            axfpFTT.BackColor = Color.FromArgb(0, 128, 128);
                            axfpFTT.ForeColor = Color.White;
                        }
                    }

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 1; j < dt.Columns.Count; j++)
                        {
                            axfpFTT.SetText(j + 1, i + 2, dt.Rows[i][j].ToString());
                            axfpFTT.set_ColWidth(j + 2, 210d / (axfpFTT.MaxCols - 2));
                        }
                    }

                    if (ComVar.Var._strValue1 == "009" && ComVar.Var._strValue2 == "T01")
                    {
                        axfpFTT.SetText(2, 3, "Sitching 1");
                        axfpFTT.SetText(2, 4, "Sitching 2");
                    }
                    else if (ComVar.Var._strValue2 == "" || ComVar.Var._strValue1 == "099")
                    {
                        axfpFTT.Row = 2;
                        axfpFTT.RowHidden = true;
                        axfpFTT.Row = 3;
                        axfpFTT.RowHidden = true;
                        axfpFTT.Row = 4;
                        axfpFTT.RowHidden = true;
                    }
                    else
                    {
                        axfpFTT.SetText(2, 3, "Sitching " + (1 + (2 * (iMline - 1))).ToString());
                        axfpFTT.SetText(2, 4, "Sitching " + (2 + (2 * (iMline - 1))).ToString());
                    }

                }
                catch 
                { }
                finally {
                    axfpFTT.Visible = true;
                    AnimateWindow(axfpFTT.Handle, 300, AW_SLIDE | 0X4);
                }
            
            }
        }

        private void FRM_SMT_FTT_MONTHLY_PHUOC_Load(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            GoFullscreen();
            setConfigForm();
            
            
        }
        int Target = 0;
        private void BindingChartFTT()
        {
            string sMonth = UC_MONTH.GetValue();
            DataTable dt = SP_SMT_FTT_MONTHLY("C", sMonth, line, Mline);

            chartFTT.DataSource = dt;
            chartFTT.Series[0].ArgumentDataMember = "YMD";
            chartFTT.Series[0].ValueDataMembers.AddRange(new string[] { "FTT_QTY" });
            chartFTT.Series[0].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;

            //for (int i = 0; i < dt.Rows.Count ; i++)
            //    if (Convert.ToInt32(chartFTT.Series[0].Points[i]) > 95)
            //        chartFTT.Series[0].Points[i].Color = Color.Yellow;
            //    else
            //        chartFTT.Series[0].Points[i].Color = Color.Red;

                    

            DevExpress.XtraCharts.ConstantLine constantLine1 = new DevExpress.XtraCharts.ConstantLine();
            ((XYDiagram)chartFTT.Diagram).AxisY.ConstantLines.Clear();
            constantLine1.AxisValueSerializable = "1";
            constantLine1.Color = Color.Purple;
           // constantLine1.Name = "TARGET: " + dt.Rows[0]["FTT_TARGET"].ToString() + "%";
            constantLine1.Title.Alignment = DevExpress.XtraCharts.ConstantLineTitleAlignment.Far;
            constantLine1.Title.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            constantLine1.LineStyle.Thickness = 2;
            Target = Convert.ToInt32(dt.Rows[0]["FTT_TARGET"].ToString());
            constantLine1.AxisValue = dt.Rows[0]["FTT_TARGET"].ToString();
            ((XYDiagram)chartFTT.Diagram).AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] {
            constantLine1});
        }

        private void chartFTT_CustomDrawAxisLabel(object sender, DevExpress.XtraCharts.CustomDrawAxisLabelEventArgs e)
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

        private void chartFTT_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            if ((e.SeriesPoint as DevExpress.XtraCharts.SeriesPoint).Values[0] >= Target)
                e.SeriesDrawOptions.Color = Color.LimeGreen;
            else if ((e.SeriesPoint as DevExpress.XtraCharts.SeriesPoint).Values[0] < Target && (e.SeriesPoint as DevExpress.XtraCharts.SeriesPoint).Values[0] >= Target - 5) e.SeriesDrawOptions.Color = Color.Yellow;
            else
                e.SeriesDrawOptions.Color = Color.Red ;
    
        }
            


        private void BindingChartHi_BC()
        {

            DataTable dt1 = SP_SMT_QR_HI_BC("HI", line, Mline, UC_MONTH.GetValue());

            chartHI.DataSource = dt1;
            chartHI.Series[0].ArgumentDataMember = "DEF_NAME";
            chartHI.Series[0].ValueDataMembers.AddRange(new string[] { "PRS_QTY" });
            chartHI.Series[0].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;

            chartHI.Series[1].ArgumentDataMember = "DEF_NAME";
            chartHI.Series[1].ValueDataMembers.AddRange(new string[] { "PAR" });
            chartHI.Series[1].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;

            DataTable dt2 = SP_SMT_QR_HI_BC("RE", line, Mline, UC_MONTH.GetValue());

            chartRE.DataSource = dt2;
            chartRE.Series[0].ArgumentDataMember = "DEF_NAME";
            chartRE.Series[0].ValueDataMembers.AddRange(new string[] { "PRS_QTY" });
            chartRE.Series[0].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;

            chartRE.Series[1].ArgumentDataMember = "DEF_NAME";
            chartRE.Series[1].ValueDataMembers.AddRange(new string[] { "PAR" });
            chartRE.Series[1].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
        }
        private void tmrDate_Tick(object sender, EventArgs e)
        {
            cCount++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            if (cCount >= 30)
            {
                BindingGrid();
                BindingChartFTT();
                BindingChartHi_BC();
                cCount = 0;
            }
            
        }

        private void FRM_SMT_FTT_MONTHLY_PHUOC_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                cmdBack.Tag = ComVar.Var._Frm_Back;
                setConfigForm();
                initForm();
                cCount = 30;
                tmrDate.Start();
            }
            else
                tmrDate.Stop();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        private void UC_MONTH_ValueChangeEvent(object sender, EventArgs e)
        {
            BindingGrid();
            BindingChartFTT();
            BindingChartHi_BC();
        }

        private void initForm()
        {
            line = ComVar.Var._strValue1;
            Mline = ComVar.Var._strValue2;            
            Lang = ComVar.Var._strValue3;
            if (ComVar.Var._strValue3 == "Vn")
            {
                lblTitle.Text = "Tỉ lệ chất lượng theo tháng";
                btnDay.Text = "Ngày";
                btnMonth.Text = "Tháng";
                btnWeek.Text = "Tuần";
                btnYear.Text = "Năm";
            }
            else
            {
                lblTitle.Text = "QR Status by Month";
                btnDay.Text = "Day";
                btnMonth.Text = "Month";
                btnWeek.Text = "Week";
                btnYear.Text = "Year";
            }

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

        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }
    }
}
