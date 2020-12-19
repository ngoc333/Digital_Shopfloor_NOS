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

namespace FORM
{
    public partial class FORM_SMT_DTD_YEAR : Form
    {
        public FORM_SMT_DTD_YEAR()
        {
            InitializeComponent();
        }

        int indexScreen;
        string Line, Mline, Lang;
        DataTable dt = null;
        public FORM_SMT_DTD_YEAR(string Title, int _indexScreen, string _Line, string _Mline, string _Lang)
        {
            InitializeComponent();
            indexScreen = _indexScreen;
            Mline = _Mline;
            Line = _Line;
            lblTitle.Text = Title;
        }

        public void setData(string Title, int _indexScreen, string _Line, string _Mline, string _Lang)
        {
            indexScreen = _indexScreen;
            Mline = _Mline;
            Line = _Line;
            lblTitle.Text = Title;

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
        }

        #region PKG
        public DataTable SEL_DATA_DTD_YEAR(string Qtype, string ARG_LINE_CD, string ARG_MLINE_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_SMT_PHUOC.SP_SMT_DTD_YEAR";

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

        public DataTable SEL_DATA_DTD_YEAR_V2(string Qtype, string ARG_YMD, string ARG_LINE_CD, string ARG_MLINE_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_SMT_PHUOC.SP_SMT_DTD_YEAR_V2";

                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                MyOraDB.Parameter_Name[1] = "ARG_YMD";
                MyOraDB.Parameter_Name[2] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[3] = "ARG_MLINE_CD";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = Qtype;
                MyOraDB.Parameter_Values[1] = ARG_YMD;
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

        #endregion
        private void GoFullscreen()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;

        }


        private void BindingDataGrid()
        {
            try
            {
                dt = SEL_DATA_DTD_YEAR_V2("Q", uc_year.GetValue().ToString(), Line, Mline);
                if (dt == null && dt.Rows.Count < 1) return;
                axfpDTD.Hide();
                int rowWIP = 2;
                int colWIP = 3;
                int colDTD = 9;
                for (int iCol = 2; iCol <= axfpDTD.MaxCols; iCol++)
                {
                    axfpDTD.Row = rowWIP;
                    axfpDTD.Col = iCol;
                    axfpDTD.Text = dt.Rows[iCol - 2][colWIP].ToString();
                    axfpDTD.TypeHAlign = FPUSpreadADO.TypeHAlignConstants.TypeHAlignCenter;
                    axfpDTD.TypeVAlign = FPUSpreadADO.TypeVAlignConstants.TypeVAlignCenter;
                    if (dt.Rows[iCol - 2][0].ToString().IndexOf('_') > 0)
                    {
                        axfpDTD.Row = 1;
                        axfpDTD.Col = iCol;
                        axfpDTD.BackColor = Color.Orange;
                        axfpDTD.ForeColor = Color.Black;
                    }
                }
                for (int iCol = 2; iCol <= axfpDTD.MaxCols; iCol++)
                {
                    axfpDTD.Row = rowWIP + 1;
                    axfpDTD.Col = iCol;
                    axfpDTD.Text = dt.Rows[iCol - 2][colDTD].ToString();
                    axfpDTD.TypeHAlign = FPUSpreadADO.TypeHAlignConstants.TypeHAlignCenter;
                    axfpDTD.TypeVAlign = FPUSpreadADO.TypeVAlignConstants.TypeVAlignCenter;
                }
                axfpDTD.Show();
            }
            catch (Exception ex)
            { }

        }


        private void BindingChartWIP()
        {
            try
            {
                chartWIP.DataSource = dt;
                chartWIP.Series[0].ArgumentDataMember = "YM";
                chartWIP.Series[0].ValueDataMembers.AddRange(new string[] { "WIP_DAYS" });
            }
            catch 
            { }
        }


        private void BindingChartLT()
        {
            try
            {

                chartLT.DataSource = dt;
                chartLT.Series[0].ArgumentDataMember = "YM";
                chartLT.Series[0].ValueDataMembers.AddRange(new string[] { "LT_DAYS" });

            }
            catch 
            { }
        }
        private void FRM_SMT_DTD_YEAR_Load(object sender, EventArgs e)
        {
            picDocument.BackgroundImage = Image.FromFile("Leadtime DTD explanation.jpg");
            picDocument.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Visible = false;
            GoFullscreen();
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            //Setup Lang
            axfpDTD.SetText(1, 1, uc_year.GetValue().ToString());
            setConfigForm();


        }
        int cCount = 0;
        private void tmrDate_Tick(object sender, EventArgs e)
        {
            cCount++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            if (cCount >= 30)
            {
                BindingDataGrid();
                BindingChartWIP();
                BindingChartLT();
                cCount = 0;
            }
        }

        private void CustomDrawAxisLabel(object sender, DevExpress.XtraCharts.CustomDrawAxisLabelEventArgs e)
        {
            try
            {
                if (e.Item.Axis is AxisX)
                {
                    e.Item.Text = e.Item.Text.Replace("_N", "").Replace("\n", "");
                }
            }
            catch
            {

            }
        }

      

        private void FRM_SMT_DTD_YEAR_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                cmdBack.Tag = ComVar.Var._Frm_Back;
                initForm();
                cCount = 30;
                tmrDate.Start();


            }
            else
            {
                tmrDate.Stop();
            }
        }

       

        private void lblTitle_MouseEnter(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void lblTitle_MouseLeave(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void uc_year_ValueChangeEvent(object sender, EventArgs e)
        {
            try
            {
                axfpDTD.SetText(1, 1, uc_year.GetValue().ToString());
                BindingDataGrid();
                BindingChartWIP();
                BindingChartLT();
                cCount = 0;
            }
            catch { }
        }

        private void initForm()
        {

            Line = ComVar.Var._strValue1;
            Mline = ComVar.Var._strValue2;
            Lang = ComVar.Var._strValue3;

            switch (ComVar.Var._strValue3)
            {
                case "Vn":
                    btnDay.Text = "Ngày";
                    btnMonth.Text = "Tháng";
                    btnWeek.Text = "Tuần";
                    btnYear.Text = "Năm";
                    lblTitle.Text = "DTD (Dock To Dock) by Year";
                    break;
                case "En":
                    btnDay.Text = "Day";
                    btnMonth.Text = "Month";
                    btnWeek.Text = "Week";
                    btnYear.Text = "Year";
                    lblTitle.Text = "DTD (Dock To Dock) by Year";
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
