using DevExpress.Utils;
using DevExpress.XtraGrid.Views.BandedGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FORM
{
    public partial class FORM_KAIZEN : Form
    {
        public FORM_KAIZEN()
        {
            InitializeComponent();
        }
       // int indexScreen;
        string line, mline, Lang;
        int int_count = 0;
      //  init strinit = new init();

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            if (int_count < 40)
                int_count++;
            else
            {
                int_count = 0;
                load_data();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch { }
        }

        public DataTable SEL_HR_MANAGEMENT(string Qtype, string ARG_LINE_CD, string ARG_MLINE_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_SMT_PHUOC.SP_SMT_HR_MANAGEMENT";

                MyOraDB.ReDim_Parameter(4);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                MyOraDB.Parameter_Name[1] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[2] = "ARG_MLINE_CD";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = Qtype;
                MyOraDB.Parameter_Values[1] = ARG_LINE_CD;
                MyOraDB.Parameter_Values[2] = ARG_MLINE_CD;
                MyOraDB.Parameter_Values[3] = "";


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


        private void BindingChartType()
        {
            chartControl3.DataSource = SEL_HR_MANAGEMENT("TYPE", line, mline);
            chartControl3.Series[0].ArgumentDataMember = "TYPE";
            chartControl3.Series[0].ValueDataMembers.AddRange(new string[] { "TOT_MAN" });
        }


        private void load_data()
        {
            try
            {
                SetData("CHART_COL", DateTime.Now.ToString("yyyy"), line, "000");
                setDataChart1("CHART_PIE1", DateTime.Now.ToString("yyyy"), line, "000");
                setDataChart1("CHART_PIE2", DateTime.Now.ToString("yyyy"), line, "000");
                //DataTable dt1 = SEL_SMT_KAIZEN("CHART_PIE1", line, mline, "");
                //if (dt != null && dt.Rows.Count > 0)
                //{
                //    bindingdatachart(chartControl1, dt);
                //}

                //if (dt1 != null && dt1.Rows.Count > 0)
                //{
                //    bindingdatachart1(chartControl2, dt1);
                //}
                //BindingChartType();

            }
            catch
            {
            }
        }

        private void bindingdatachart(DevExpress.XtraCharts.ChartControl _chart, DataTable dt)
        {
            //try
            //{
            //    this.Cursor = Cursors.WaitCursor;
            //    g

            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}
        }

        private void SetData(string arg_type, string date, string line, string mline)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                gvwBase.BeginUpdate();
                //  plant = cbo_Plant.SelectedValue == null ? "" : cbo_Plant.SelectedValue.ToString();
                //  line = cbo_line.SelectedValue == null ? "" : cbo_line.SelectedValue.ToString();
                chartControl1.DataSource = null;
                grdBase.DataSource = null;
                DataSet ds = Data_Select(arg_type, date, line, mline );
                if (ds == null || ds.Tables.Count == 0) return;
                DataTable dtSource = ds.Tables[0];
                DataTable dtChart = null;
                if (ds.Tables[0].Select("DIV = 'TOTAL IDEAS' ", "MON").Count() > 0)
                    dtChart = ds.Tables[0].Select("DIV = 'TOTAL IDEAS' AND MON <> 'Total'", "YMD").CopyToDataTable();

                fnProcess(dtSource, "CHART_COL");
                dtSource.Columns.Remove("YMD");
                DataTable dt = Pivot(dtSource, dtSource.Columns["MON"], dtSource.Columns["TOTAL"]);
                grdBase.DataSource = dt;

                if (dtSource != null)
                {
                    gvwBase.BandPanelRowHeight = 50;
                    gvwBase.RowHeight = 50;
                    for (int i = 0; i < gvwBase.Columns.Count; i++)
                    {
                        //Title             
                        gvwBase.Columns[i].OwnerBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gvwBase.Columns[i].OwnerBand.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                        gvwBase.Columns[i].OwnerBand.Width = 50;
                        gvwBase.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                        gvwBase.Columns[i].OwnerBand.AppearanceHeader.Font = new Font("Calibri", 18, FontStyle.Bold);
                        // gvwBase.Columns[i].OwnerBand.AppearanceHeader.ForeColor = Color.Black;
                        //gvwBase.Columns[i].OwnerBand.AppearanceHeader.BackColor = Color.DodgerBlue;
                        // gvwBase.Columns[i].OwnerBand.AppearanceHeader.BackColor2 = Color.Orange;                   

                        //Data
                        gvwBase.Columns[i].AppearanceCell.Font = new Font("Calibri", 16, FontStyle.Bold);
                        if (i == 0)
                        {
                            gvwBase.Columns[i].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
                        }
                        else
                        {
                            gvwBase.Columns[i].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                        }

                        gvwBase.Columns[i].AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;

                        if (i == 0)
                            gvwBase.Columns[i].OwnerBand.Width = 100;

                        if (i > 0)
                        {
                            // gvwBase.Columns[i].OwnerBand.Width = 80;
                            gvwBase.Columns[i].DisplayFormat.FormatType = FormatType.Numeric;
                            gvwBase.Columns[i].DisplayFormat.FormatString = "#,#.#";
                        }

                    }
                }
                gvwBase.EndUpdate();

                //SetChart(dtChart);

                chartControl1.DataSource = dtChart;
                chartControl1.Series[0].ArgumentDataMember = "MON";
                chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { "TOTAL" });

                
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                Debug.WriteLine(ex.ToString());
                throw;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void setDataChart1(string arg_type, string date, string line, string mline)
        {
            DataSet ds = Data_Select(arg_type, date, line, mline);
            if (ds == null || ds.Tables.Count == 0) return;
            DataTable dtSource = ds.Tables[0];
            if (arg_type == "CHART_PIE1")
            {
                chartControl3.DataSource = dtSource;
                chartControl3.Series[0].ArgumentDataMember = "DIV";
                chartControl3.Series[0].ValueDataMembers.AddRange(new string[] { "RESULT" });
            }
            else
            {
                chartControl2.DataSource = dtSource;
                chartControl2.Series[0].ArgumentDataMember = "DIV";
                chartControl2.Series[0].ValueDataMembers.AddRange(new string[] { "CATALOG" });
            }
        }
        private void fnProcess(DataTable dt, string type)
        {
            try
            {
                if (type == "CHART_COL")
                {
                    gvwBase.Bands.Clear();
                    gvwBase.Columns.Clear();
                }
                GridBand gridBand1 = new GridBand();
                BandedGridColumn column_Band1 = new BandedGridColumn();

                gridBand1.Caption = "MONTH";
                gridBand1.Name = "MON";
                gridBand1.VisibleIndex = 0;
                gridBand1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

                column_Band1.Caption = "DIV";
                column_Band1.FieldName = "DIV";
                column_Band1.Name = "DIV";
                column_Band1.Visible = true;
                column_Band1.Width = 150;
                column_Band1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

                gridBand1.Columns.Add(column_Band1);

                gvwBase.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { column_Band1 });
                gvwBase.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gridBand1 });


                //Create Header
                DataView view = new DataView(dt);
                DataTable distinctValues = view.ToTable(true, "MON");
                for (int i = 0; i < distinctValues.Rows.Count; i++)
                {
                    for (int j = 0; j < distinctValues.Columns.Count; j++)
                    {
                        GridBand gridBand = new GridBand();
                        BandedGridColumn column_Band = new BandedGridColumn();

                        gridBand.Caption = distinctValues.Rows[i]["MON"].ToString();
                        gridBand.Name = string.Concat("MON", i);
                        gridBand.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                        gridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                        gridBand.VisibleIndex = i;

                        column_Band.Caption = distinctValues.Rows[i]["MON"].ToString();
                        column_Band.FieldName = distinctValues.Rows[i]["MON"].ToString();
                        column_Band.Name = distinctValues.Rows[i]["MON"].ToString();
                        column_Band.Visible = true;
                        column_Band.Width = 100;

                        gridBand.Columns.Add(column_Band);
                        gvwBase.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { column_Band });
                        gvwBase.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gridBand });
                        gridBand.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void bindingdatachart1(DevExpress.XtraCharts.ChartControl _chart, DataTable dt)
        {
            _chart.DataSource = dt;
            _chart.Series[0].ArgumentDataMember = "MULTI_SKILL";
            _chart.Series[0].ValueDataMembers.AddRange(new string[] { "QTY" });
        }

        private DataSet Data_Select(string arg_type, string date, string line, string mline)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_PROD.SP_SMT_KAIZEN";

                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_QTYPE";
                MyOraDB.Parameter_Name[1] = "V_P_YM";
                MyOraDB.Parameter_Name[2] = "V_P_LINE";
                MyOraDB.Parameter_Name[3] = "V_P_MLINE";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = arg_type;
                MyOraDB.Parameter_Values[1] = date;
                MyOraDB.Parameter_Values[2] = line;
                MyOraDB.Parameter_Values[3] = mline;
                MyOraDB.Parameter_Values[4] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret;
            }

            catch
            {
                return null;
            }
       
        }

        private void FRM_SMT_MULTI_SKILL_Load(object sender, EventArgs e)
        {
            setConfigForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FRM_SMT_MULTI_SKILL_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                initForm();
                int_count = 40;
                timer1.Start();                
            }
            else
            {
                timer1.Stop();
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Form fc = Application.OpenForms["FRM_MUILTISKILL_QUATERLY"];
            //if (fc != null)
            //    fc.Close();


            //string Caption = "Multi-Skill by Quarter";
            //switch (Lang)
            //{
            //    case "Vn":
            //        Caption = "Đa Kỹ Năng theo Quý";
            //        break;
            //    default:
            //        Caption = "Multi-Skill by Quarter";
            //        break;
            //}
            //FRM_MUILTISKILL_QUATERLY f = new FRM_MUILTISKILL_QUATERLY(Caption, 1, line, mline, Lang);
            //f.Show();
            ////f.TopMost = true;
            
        }

        private void initForm()
        {
            line = ComVar.Var._strValue1;
            mline = ComVar.Var._strValue2;
            Lang = ComVar.Var._strValue3;
            if (ComVar.Var._strValue1 == "Vn")
            {
                lblTitle.Text = "Phân tích đa kỹ năng";
              //  lblTitleGauges.Text = "Tỉ lệ vắng mặt trung bình (%)";
            }
            else
            {
                lblTitle.Text = "Kaizen Feedback System";
              //  lblTitleGauges.Text = "Absenteeism AVG (%)";
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
        DataTable Pivot(DataTable dt, DataColumn pivotColumn, DataColumn pivotValue)
        {
            // find primary key columns 
            //(i.e. everything but pivot column and pivot value)
            DataTable temp = dt.Copy();
            temp.Columns.Remove(pivotColumn.ColumnName);
            temp.Columns.Remove(pivotValue.ColumnName);
            string[] pkColumnNames = temp.Columns.Cast<DataColumn>()
            .Select(c => c.ColumnName)
            .ToArray();

            // prep results table
            DataTable result = temp.DefaultView.ToTable(true, pkColumnNames).Copy();
            result.PrimaryKey = result.Columns.Cast<DataColumn>().ToArray();
            dt.AsEnumerable()
            .Select(r => r[pivotColumn.ColumnName].ToString())
            .Distinct().ToList()
            .ForEach(c => result.Columns.Add(c, pivotValue.DataType));
            //.ForEach(c => result.Columns.Add(c, pivotColumn.DataType));

            // load it
            foreach (DataRow row in dt.Rows)
            {
                // find row to update
                DataRow aggRow = result.Rows.Find(
                pkColumnNames
                .Select(c => row[c])
                .ToArray());
                // the aggregate used here is LATEST 
                // adjust the next line if you want (SUM, MAX, etc...)
                aggRow[row[pivotColumn.ColumnName].ToString()] = row[pivotValue.ColumnName];
            }

            return result;
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
