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
using System.IO;
using System.Threading;
//using C1.Win.C1FlexGrid;

namespace FORM
{
    public partial class FORM_SMF_FGWH_INVENOTRY : Form
    {
        bool _load = true;
       // DataTable _dt = null;
        int _icount = 0;
       // int _rowTotal = 3;
        public string[] judul_plan;
       // Thread th;

        public FORM_SMF_FGWH_INVENOTRY()
        {
            InitializeComponent();
            cmd_back.Visible = FORM.Var._Show_back_icon;
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

        private void set_Text_En_Vi()
        {
            if (ComVar.Var._strValue3 == "Vn")
            {
                lblTitle.Text = "Tồn Kho Thành Phẩm";
            }
            else
            {
                lblTitle.Text = "F/G Warehouse Inventory";
                
            }
        }

        private string get_Text(int arg_col, int arg_row)
        {
            axSpear.Col = arg_col;
            axSpear.Row = arg_row;
            return axSpear.Text;
        }

        private void set_Merge_Col(int arg_col, int arg_Start_Row, int arg_End_Row)
        {
            //string str="", str1="";
            for (int i = arg_Start_Row +1; i <= arg_End_Row; i++)
            {
                if (get_Text(arg_col, i) == get_Text(arg_col, i-1))
                {
                    axSpear.ColMerge = FPUSpreadADO.MergeConstants.MergeAlways;
                }
            }
            
        }




        private void load_data(DataTable arg_dt)
        {
            try
            {
                if (arg_dt != null && arg_dt.Rows.Count > 0)
                {
                    int iMaxRow = arg_dt.Rows.Count;
                    axSpear.MaxRows = iMaxRow + 2;
                    for (int i = 0; i < iMaxRow; i++)
                    {
                        if (arg_dt.Rows[i]["OBS_ID"].ToString().ToUpper() == "TOTAL")
                        {
                            axSpear.Row = i+3;
                            axSpear.BackColor = Color.Green;
                            axSpear.ForeColor = Color.White;
                            axSpear.FontBold = true;
                           // axSpear.Col = 1;
                            axSpear.FontSize = 16f;
                            axSpear.Col = 1;
                            axSpear.FontSize = 20f;
                            axSpear.set_RowHeight(i + 3, 26.33);
                            axSpear.AddCellSpan(1, i + 3, 8, 1);
                            axSpear.SetCellBorder(1, i + 3, axSpear.MaxCols, i + 3, FPUSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0, FPUSpreadADO.CellBorderStyleConstants.CellBorderStyleBlank);
                            if (i + 3 == 3) axSpear.RowsFrozen = 3;
                        }
                        for (int j = 1; j <= axSpear.MaxCols; j++)
                        {
                            axSpear.Col = j;
                            axSpear.Row = i + 3;
                         //   axSpear.SetText(j, i + 3, arg_dt.Rows[i][j].ToString());
                            axSpear.Text = arg_dt.Rows[i][j].ToString();
                            
                            if (arg_dt.Columns[j].ColumnName =="STK_PRS" && i >0)
                            {   if (arg_dt.Rows[i]["ORDER_PRS"].ToString() == arg_dt.Rows[i]["STK_PRS"].ToString())
                                {
                                    axSpear.ForeColor = Color.DodgerBlue;
                                }
                                else
                                    axSpear.ForeColor = Color.Black;
                            }

                            if (arg_dt.Columns[j].ColumnName == "STK_CTN" && i > 0)
                            {
                                if (arg_dt.Rows[i]["ORDER_CTN"].ToString() == arg_dt.Rows[i]["STK_CTN"].ToString())
                                {
                                    axSpear.ForeColor = Color.DodgerBlue;
                                }
                                else
                                    axSpear.ForeColor = Color.Black;
                            }
                            
                        }
                        
                        
                        
                    }

                   // axSpear.SetOddEvenRowColor(0xf2e9e3, 0, 0x8c3e0b, 0xffffff);

                }
                else
                    axSpear.MaxRows = 3;

                for (int i = 1; i <= 3;i++ )
                {
                    axSpear.Col = i;
                    axSpear.ColMerge = FPUSpreadADO.MergeConstants.MergeAlways;
                }
                
            }
            catch (Exception)
            {
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

                string process_name = "SEPHIROTH.PKG_DMC.SEL_WH_INVENTORY";
                //ARGMODE
                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_WH_CD";
                MyOraDB.Parameter_Name[1] = "ARG_YMD";
                MyOraDB.Parameter_Name[2] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = "";
                MyOraDB.Parameter_Values[1] = "";
                MyOraDB.Parameter_Values[2] = "";
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
                string process_name = "SEPHIROTH.PKG_SMF.SEL_WH_INVENTORY";
                if (ComVar.Var._strValue1 == "009")
                    process_name = "SEPHIROTH.PKG_SMF.SEL_WH_INVENTORY_NOSK";
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


                ArrayList vModifyList = new ArrayList
                {
                    ComVar.Var._strValue1,
                    ((DateTime)dtpDate.EditValue).ToString("yyyyMMdd"),
                    arg_PO,
                    arg_item,
                    arg_inv,
                    arg_status
                };

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
                _icount++;
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
                if (_icount == 40)
                {
                    load_data(LOAD_DATA_v2());
                    _icount = 0;
                }

                else if (_load && _icount == 1)
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
                    dtpDate.DateTime = DateTime.Now;
                    set_Text_En_Vi();

                    _icount = 0;
                    timer1.Start();


                    //th.Join();
                    //load_data(_dt);

                    //th.Abort();
                   // _load = false;
                }
                else
                {
                    timer1.Stop();
                    
                }
            }
            catch (Exception)
            {}
                
        }

       

        private void FORM_IPEX3_LOGISTIC_Load(object sender, EventArgs e)
        {
            try
            {
                dtpDate.DateTime = DateTime.Now;
                //Com_Base.Variables.Master = Com_Base.Functions.Init_Computer(AppDomain.CurrentDomain.BaseDirectory + "App.xml", "master");
                GoFullscreen(true);
                axSpear.Dock = DockStyle.Fill;
                cmd_back.Visible = FORM.Var._Show_back_icon;
                //th = new Thread(getdata);
                //th.Start();
                


                //  string str = File.ReadAllText(@"c:\temp\location.txt");
              //  load_data();
                
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
            if (e.col == 12)
            {
                axSpear.Col = e.col;
                axSpear.Row = e.row;
                if (axSpear.Text == "Yes")
                    axSpear.Text = "No";

                else
                    axSpear.Text = "Yes";

               // Save_Status(axSpear.
            }
        }

        private void axSpear_BeforeEditMode(object sender, AxFPUSpreadADO._DSpreadEvents_BeforeEditModeEvent e)
        {
            e.cancel = true;
        }

        private void dtpDate_EditValueChanged(object sender, EventArgs e)
        {
            if (_load==false)
                load_data(LOAD_DATA_v2());
        }

        private void cmd_back_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }




    }
}
