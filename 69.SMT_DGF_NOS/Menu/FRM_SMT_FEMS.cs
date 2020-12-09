using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FORM
{
    public partial class FRM_SMT_FEMS : Form
    {
        int int_count = 0;
        //private readonly int indexScreen;
        private string line;
       // private readonly string mline;

        // int i_col_cur = 0;
        readonly Color BackColor1 = Color.FromArgb(232, 246, 247);
        readonly Color BackColor2 = Color.White;

        public FRM_SMT_FEMS()
        {
            InitializeComponent();
            //indexScreen = 1;
            line = "014";
           // mline = "001";
            // lbltitle.Text = title;
        }
       

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                if (int_count < 30)
                    int_count++;
                else
                {
                    int_count = 0;
                    load_data();
                    bindingchart();
                    //bindingchart2();
                }
            }
            catch
            {
            }
        }

        public DataTable SEL_SMT_MON_FEMS(string ARG_QTYPE, string ARG_LINE, string ARG_DATE)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_PROD.SP_SMT_MONTHLY_FEMS";

                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_TYPE";
                MyOraDB.Parameter_Name[1] = "V_P_FACTORY";
                MyOraDB.Parameter_Name[2] = "V_P_LINE";
                MyOraDB.Parameter_Name[3] = "V_P_DATE";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = "VJ";
                MyOraDB.Parameter_Values[2] = ARG_LINE ?? "F1";
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

        private void load_head()
        {
            try
            {
                DataTable dt = SEL_SMT_MON_FEMS("H", line,  UC_MONTH.GetValue());
                int i;
                if (dt != null && dt.Rows.Count > 0)
                {
                    axfpSpread.SetText(1, 1, dt.Rows[0]["MON"].ToString());
                    axfpSpread.set_ColWidth(1, 18);
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
                        axfpSpread.AddCellSpan(i + 2, 1, 1, 1);
                        axfpSpread.SetText(i + 2, 1, dt.Rows[i]["DAY"].ToString());
                        axfpSpread.SetText(i + 2, 2, dt.Rows[i]["DAY1"].ToString());
                        axfpSpread.set_ColWidth(i + 2, (double)218 / (double)(dt.Rows.Count));
                        //axfpSpread.set_ColWidth(i + 2, 240 / 27 + 0.3);
                        //axfpSpread.set_ColWidth(i + 2, (axfpSpread.Width-axfpSpread.get_ColWidth(1))/dt.Rows.Count);
                    }
                    axfpSpread.set_ColWidth(1, 18 + 217 - axfpSpread.get_ColWidth(i + 1) * dt.Rows.Count);
                    //axfpSpread.AddCellSpan(dt.Rows.Count + 1, 1, 1, 2);
                    //axfpSpread.AddCellSpan(dt.Rows.Count, 1, 1, 2);
                    //axfpSpread.AddCellSpan(dt.Rows.Count - 1, 1, 1, 2);
                    //axfpSpread.set_ColWidth(1, 16.4 + 0.1 * 25 / dt.Rows.Count ); 
                    for (int j = i + 2; j <= axfpSpread.MaxCols; j++)
                    {
                        axfpSpread.set_ColWidth(j, 0);
                    }
                }

            }
            catch
            {
            }
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
                    Grid.Font = new Font("Calibri", 12, FontStyle.Regular);
                }

                //axfpSpread.set_RowHeight(irow, 25);
            }
            axfpSpread.RowsFrozen = 2;
        }

        //private string GetText(AxFPSpreadADO.AxfpSpread spread, int col, int row)
        //{
        //    try
        //    {
        //        object data = null;
        //        spread.GetText(col, row, ref data);
        //        return data.ToString();
        //    }
        //    catch 
        //    {
        //        //return "";
        //        //log.Error(ex);
        //        return null;
        //    }

        //}

        private void load_data()
        {
            try
            {
                load_head();
                DataTable dt = SEL_SMT_MON_FEMS("Q3", line,  UC_MONTH.GetValue() );
                if (dt != null && dt.Rows.Count > 0)
                {
                    //axfpSpread.MaxRows = dt.Rows.Count + 2;
                    ClearGrid(axfpSpread);
                    //axfpSpread.SetCellBorder(1, 1, axfpSpread.MaxCols, axfpSpread.MaxRows, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexBottom, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                    //axfpSpread.SetCellBorder(1, 1, axfpSpread.MaxCols, axfpSpread.MaxRows, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexTop, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                    //axfpSpread.SetCellBorder(1, 1, axfpSpread.MaxCols, axfpSpread.MaxRows, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
                    //axfpSpread.SetCellBorder(1, 1, axfpSpread.MaxCols, axfpSpread.MaxRows, FPSpreadADO.CellBorderIndexConstants.CellBorderIndexRight, 0, FPSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            axfpSpread.SetText(j + 1, i + 3, dt.Rows[i][j].ToString());
                            
                            //if (dt.Columns[j].ColumnName.Replace("'", "") == "RATE")
                            //    axfpSpread.SetText(j, i + 3, dt.Rows[i][j].ToString() == "" ? "" : Convert.ToDouble(dt.Rows[i][j].ToString()).ToString() + "%");
                            //else
                            //    axfpSpread.SetText(j, i + 3, dt.Rows[i][j].ToString() == "" ? "" : Convert.ToDouble(dt.Rows[i][j].ToString()).ToString("###,###,###"));
                            //axfpSpread.SetText(j, i + 3, "2,999");
                            //if (j == dt.Columns.Count - 1)
                            //{
                            //    axfpSpread.Row = i + 3;
                            //    axfpSpread.Col = j;
                            //    if (Convert.ToDouble(GetText(axfpSpread, j, i + 3).Replace("%", "").Trim()) < 95)
                            //    {
                            //        axfpSpread.BackColor = Color.Red;
                            //        axfpSpread.ForeColor = Color.White;
                            //    }
                            //    else if (Convert.ToDouble(GetText(axfpSpread, j, i + 3).Replace("%", "").Trim()) > 98)
                            //    {
                            //        axfpSpread.BackColor = Color.Green;
                            //        axfpSpread.ForeColor = Color.White;
                            //    }
                            //    else
                            //    {
                            //        axfpSpread.BackColor = Color.Yellow;
                            //        axfpSpread.ForeColor = Color.Black;
                            //    }

                            //}
                        }
                    }

                }
            }
            catch
            {
            }
        }

        private void bindingchart()
        {
            try
            {
                DataTable dt = SEL_SMT_MON_FEMS("C2", line,  UC_MONTH.GetValue());
                if (dt != null && dt.Rows.Count > 0)
                {
                    chartControl1.DataSource = dt;
                    chartControl1.Series[0].ArgumentDataMember = "DAY";
                    chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { "ELEC_VAILD" });

                    chartControl1.Series[1].ArgumentDataMember = "DAY";
                    chartControl1.Series[1].ValueDataMembers.AddRange(new string[] { "ELEC_INVAILD" });

                    chartControl1.Series[2].ArgumentDataMember = "DAY";
                    chartControl1.Series[2].ValueDataMembers.AddRange(new string[] { "PAIRS" });

                    chartControl1.Series[3].ArgumentDataMember = "DAY";
                    chartControl1.Series[3].ValueDataMembers.AddRange(new string[] { "COST" });

                }
                else
                {

                }
            }
            catch
            {
            }
        }

        private void FRM_SMT_FEMS_Load(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
           
        }

        private void chartControl1_CustomDrawAxisLabel(object sender, DevExpress.XtraCharts.CustomDrawAxisLabelEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }

        private void UC_MONTH_ValueChangeEvent(object sender, EventArgs e)
        {
            load_data();
            bindingchart();
        }

        private void FRM_SMT_FEMS_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                line = ComVar.Var._strValue1;
                int_count = 30;
                timer1.Start();
            }
            else
                timer1.Stop();
        }
    }
}
