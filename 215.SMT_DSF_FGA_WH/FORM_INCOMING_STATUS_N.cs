using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Drawing.Drawing2D;
using Microsoft.VisualBasic.PowerPacks;
using System.Collections;
using System.Threading;
//using C1.Win.C1FlexGrid;

namespace FORM
{
    public partial class FORM_INCOMING_STATUS_N : Form
    {
        //bool _load = true;
        DataTable _dt = null;
        int icount = 0;
        bool _load = false;
        

        Dictionary<string, int>[] _dic_loc = new Dictionary<string, int>[9];


        public FORM_INCOMING_STATUS_N()
        {
            InitializeComponent();
            cmd_back.Visible = FORM.Var._Show_back_icon;
            ComVar.Var.writeToLog(" init: ");
        }

        #region Func

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



        private string Get_text(int arg_col, int arg_row)
        {
            axSpear.Col = arg_col;
            axSpear.Row = arg_row;
            return axSpear.Text;
        }

        private void set_Text_En_Vi()
        {
            if (ComVar.Var._strValue3 == "Vn")
            {
                lblTitle.Text = "Nhập Kho Mỗi Giờ Theo Line";
                
            }
            else
            {
                lblTitle.Text = "Hourly Incoming By Mini Line";
            }
        }


        private void load_data(DataTable arg_dt)
        {
            try
            {

              //  DataTable dt = LOAD_DATA_v2();
                int iMaxRow = arg_dt.Rows.Count;
                axSpear.ClearRange(2, 3, axSpear.MaxCols, axSpear.MaxRows, true);
                if (arg_dt != null && iMaxRow > 0)
                {

                    for (int i = 0; i < iMaxRow; i++)
                    {
                        if (arg_dt.Rows[i]["MLINE_CD"].ToString() != "")
                        {
                            axSpear.SetText(Convert.ToInt16(arg_dt.Rows[i]["col_set"]), Convert.ToInt16(arg_dt.Rows[i]["row_set"]), arg_dt.Rows[i]["QTY"].ToString());
                            axSpear.SetText(Convert.ToInt16(arg_dt.Rows[i]["col_set"]) + 1, Convert.ToInt16(arg_dt.Rows[i]["row_set"]), arg_dt.Rows[i]["CTNS"].ToString());
                            axSpear.SetText(axSpear.MaxCols - 1, Convert.ToInt16(arg_dt.Rows[i]["row_set"]), arg_dt.Rows[i]["QTY_TOT"].ToString());
                            axSpear.SetText(axSpear.MaxCols, Convert.ToInt16(arg_dt.Rows[i]["row_set"]), arg_dt.Rows[i]["CTNS_TOT"].ToString());
                        }
                    }
                    //int iMaxRow = dt.Rows.Count;
                    //axSpear.MaxRows = 2;
                    //axSpear.MaxRows = iMaxRow + 2;
                    //for (int i = 0; i < iMaxRow; i++)
                    //{
                    //    if (dt.Rows[i]["DPO"].ToString().ToUpper() == "TOTAL")
                    //    {
                    //        axSpear.Col = -1;
                    //        axSpear.Row = i + 3;
                    //        axSpear.BackColor = Color.DodgerBlue;
                    //        axSpear.ForeColor = Color.White;
                    //        axSpear.FontBold = true;
                    //        // axSpear.Col = 1;
                    //        axSpear.FontSize = 16f;
                    //        axSpear.Col = 1;
                    //        axSpear.FontSize = 20f;
                    //        axSpear.set_RowHeight(i + 3, 32.33);
                    //        axSpear.AddCellSpan(1, i + 3, 10, 1);
                    //        axSpear.SetCellBorder(1, i + 3, axSpear.MaxCols, i + 3, FPUSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0, FPUSpreadADO.CellBorderStyleConstants.CellBorderStyleBlank);
                    //        if (i + 3 == 3) axSpear.RowsFrozen = 3;
                    //    }
                    //    if (dt.Rows[i]["STATUS"].ToString().ToUpper() == "YES")
                    //    {
                    //        axSpear.Row = i + 3;
                    //        axSpear.Col = 13;
                    //        axSpear.BackColor = Color.Green;
                    //        axSpear.ForeColor = Color.White;
                    //    }
                    //    for (int j = 1; j <= axSpear.MaxCols; j++)
                    //    {
                    //        axSpear.SetText(j, i + 3, dt.Rows[i][j].ToString());
                    //    }
                    //    axSpear.set_RowHeight(i + 3, 25.0);
                    //}
                }
                //else
                //    axSpear.MaxRows = 2;

                //for (int i = 1; i <= 3; i++)
                //{
                //    axSpear.Col = i;
                //    axSpear.ColMerge = FPUSpreadADO.MergeConstants.MergeAlways;
                //}
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog("load_data " + ex.Message);
            }
           
        }


        private void save_Status()
        {
            for (int i = 3; i < axSpear.MaxRows - 1; i++)
            {
                if (Get_text(13, i).ToUpper()=="YES")
                    Save_Status(Get_text(6, i), Get_text(7, i), Get_text(8, i), "Y");
            }
        }




        #endregion Func


        #region DB
        private DataTable LOAD_DATA()
        {           
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "SEPHIROTH.PKG_DMC.SEL_PROD_SET_STATUS";
                //ARGMODE
                MyOraDB.ReDim_Parameter(1);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "OUT_CURSOR";
                MyOraDB.Parameter_Type[0] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Values[0] = "";
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


        public DataTable LOAD_DATA_v2()
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            System.Data.DataSet ds_ret;

            try
            {
                string process_name = "SEPHIROTH.PKG_SMF.SEL_INCOMING_STATUS";

                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;


                MyOraDB.Parameter_Name[0] = "ARG_WH_CD";
                MyOraDB.Parameter_Name[1] = "ARG_YMD";
                MyOraDB.Parameter_Name[2] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ComVar.Var._strValue1;
                MyOraDB.Parameter_Values[1] = ((DateTime)dtpDate.EditValue).ToString("yyyyMMdd");
                MyOraDB.Parameter_Values[2] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                ComVar.Var.writeToLog(" count: " + ds_ret.Tables[process_name].Rows.Count);
                return ds_ret.Tables[process_name];
            }
            catch
            {
                return null;
            }
        }

        private bool Save_Status(string arg_PO, string arg_item, string arg_inv, string arg_status)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            bool l_rs = false;
            try
            {
                int iCount = 6;
                MyOraDB.ReDim_Parameter(iCount);

                //01.PROCEDURE¸í
                MyOraDB.Process_Name = "SEPHIROTH.PKG_SMF.SAVE_SHIPPING_STATUS";

                //02.ARGURMENT ¸í 
                MyOraDB.Parameter_Name[0] = "ARG_WH_CD";
                MyOraDB.Parameter_Name[1] = "ARG_YMD";
                MyOraDB.Parameter_Name[2] = "ARG_PO";
                MyOraDB.Parameter_Name[3] = "ARG_ITEM";
                MyOraDB.Parameter_Name[4] = "ARG_INV";
                MyOraDB.Parameter_Name[5] = "ARG_STATUS";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (int)OracleType.VarChar;


                ArrayList vModifyList = new ArrayList();
                //int iRow = fgrid_main.Rows.Fixed + 1;
               // for (int iRow = fgrid_main.Rows.Fixed; iRow < fgrid_main.Rows.Count; iRow++)
               // {
                    //  if (fgrid_main[iRow, 3] != null && fgrid_main[iRow, 3].ToString() != "")
                    //  {
                vModifyList.Add(ComVar.Var._strValue1);                                        
                vModifyList.Add(((DateTime)dtpDate.EditValue).ToString("yyyyMMdd"));                    
                vModifyList.Add(arg_PO);                      
                vModifyList.Add(arg_item);
                vModifyList.Add(arg_inv);
                vModifyList.Add(arg_status);          
                    //  }
              //  }

                MyOraDB.Parameter_Values = new string[vModifyList.Count];
                for (int j = 0; j < vModifyList.Count; j++)
                {
                    MyOraDB.Parameter_Values[j] = Convert.ToString(vModifyList[j]).Trim();
                }

                MyOraDB.Add_Modify_Parameter(true);

                if (MyOraDB.Exe_Modify_Procedure() == null)
                    l_rs = false;
                else
                    l_rs = true;
            }
            catch 
            {
                return false;
            }
            return l_rs;
        }


        #endregion DB

        

        #region event
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                icount++;
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
                if (icount == 40)
                {
                    load_data(LOAD_DATA_v2());
                    icount = 0;
                }
                else if (_load && icount == 1)
                {
                    load_data(LOAD_DATA_v2());
                    _load = false;
                }
            }
            catch (Exception)
            {} 
        }

      


        private void FORM_IPEX3_LOGISTIC_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    _load = true;
                    icount = 0;
                    //_load = true;
                    set_Text_En_Vi();
                    timer1.Start();
                    dtpDate.DateTime = DateTime.Now;

                   // _load = false;
                   // load_data();
                }
                else
                {
                    timer1.Stop();
                }
            }
            catch (Exception)
            {}
                
        }

        private void Get_Data_From_DB()
        {
            _dt = LOAD_DATA_v2();
            
        }
       

        private void FORM_IPEX3_LOGISTIC_Load(object sender, EventArgs e)
        {
            try
            {
                _load = true;
                dtpDate.EditValue = DateTime.Now;
                //Thread th = new Thread(Get_Data_From_DB);
                //th.Start();

                //Com_Base.Variables.Master = Com_Base.Functions.Init_Computer(AppDomain.CurrentDomain.BaseDirectory + "App.xml", "master");
                GoFullscreen(true);
                axSpear.Dock = DockStyle.Fill;
                cmd_back.Visible = FORM.Var._Show_back_icon;
                
                //th.Join();
                //load_data(_dt);
                
            }
            catch (Exception)
            {}
            
        }

        private void lblDate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FORM.Var._Show_back_icon)
                    ComVar.Var.callForm = "Exit";
            }
            catch (Exception)
            {}

        }

        #endregion event


        private void axSpear_ClickEvent(object sender, AxFPUSpreadADO._DSpreadEvents_ClickEvent e)
        {
            //if (e.col == 13)
            //{

            //    axSpear.Col = e.col;
            //    axSpear.Row = e.row;

            //    if (Get_text(7, e.row).Substring(0, 1) == "_")
            //    {
            //        POP_SHIP_SCHEDULE pop = new POP_SHIP_SCHEDULE();
            //        pop.ShowDialog();                    
            //        return;
            //    }

            //    if (axSpear.Text == "Yes")
            //    {
            //        axSpear.Text = "No";
            //        Save_Status(Get_text(6, e.row), Get_text(7, e.row), Get_text(8, e.row), "N");
            //        axSpear.Col = e.col;
            //        axSpear.BackColor = Color.White;
            //        axSpear.ForeColor = Color.Black;
            //    }
            //    else
            //    {
            //        axSpear.Text = "Yes";
            //        Save_Status(Get_text(6, e.row), Get_text(7, e.row), Get_text(8, e.row), "Y");
            //        axSpear.Col = e.col;
            //        axSpear.BackColor = Color.Green;
            //        axSpear.ForeColor = Color.White;                   
            //    }
            //   // Save_Status(axSpear.
            //}
        }

        private void axSpear_BeforeEditMode(object sender, AxFPUSpreadADO._DSpreadEvents_BeforeEditModeEvent e)
        {
            e.cancel = true;
        }

        private void dtpDate_EditValueChanged(object sender, EventArgs e)
        {
            if(_load==false)
                load_data(LOAD_DATA_v2());
        }

        private void FORM_SMF_SHIP_SCHEDULE_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void cmd_back_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }




    }
}
