using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Runtime.InteropServices;
using System.Threading;
using System.Collections;

namespace FORM
{
    public partial class FRM_DVR_FC_TRACKING_DASHBOARD : Form
    {
        public FRM_DVR_FC_TRACKING_DASHBOARD()
        {
            InitializeComponent();
            
        }
        #region Variable
        int CountLoading = 0;
        DataTable _dt = null;
        Color Row_Default = Color.White;
        Color Row_Extend = Color.FromArgb(244, 248, 255);
         [DllImport("user32")]
        static extern bool AnimateWindow(IntPtr hwnd, int time, int flags);
        const int AW_SLIDE = 0X40000;
        const int AW_HOR_POSITIVE = 0X4;
        const int AW_HOR_NEGATIVE = 0X2;
        const int AW_BLEND = 0X80000;
        const int AW_HIDE = 0x00010000;
        bool _load = false;


        #endregion


        #region Func
        private void set_Text_En_Vi()
        {
            if (ComVar.Var._strValue3 == "Vn")
            {
                lblTitle.Text = "Theo dõi xuất hàng";
            }
            else
            {
                lblTitle.Text = "Delivery Focus Tracking";

            }
        }

        private void showAnimation(Control flg)
        {
            flg.Hide();
            this.Cursor = Cursors.WaitCursor;
            BindDingData(_dt);
            AnimateWindow(flg.Handle, 300, AW_SLIDE | 0X4); //IPEX_Monitor.ClassLib.WinAPI.getSlidType("2")
            flg.Show();
            this.Cursor = Cursors.Default;
        }

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
        #endregion

        #region Orac
        private DataTable SEL_DATA(string ARG_LINE)
        {
            try
            {
                System.Data.DataSet retDS;
                COM.OraDB MyOraDB = new COM.OraDB();

                MyOraDB.ReDim_Parameter(4);
                if (ComVar.Var._strValue1 == "009")
                    MyOraDB.Process_Name = "MES.PKG_SMART_F_WH.SEL_DELIVERY_TRACKING_NOSK";
                else
                    MyOraDB.Process_Name = "MES.PKG_SMART_F_WH.SEL_DELIVERY_TRACKING_V3";


                MyOraDB.Parameter_Name[0] = "ARG_LINE";
                MyOraDB.Parameter_Name[1] = "ARG_FRM_DAY";
                MyOraDB.Parameter_Name[2] = "ARG_TO_DAY";
                MyOraDB.Parameter_Name[3] = "CV_1";


                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ComVar.Var._strValue1;
                MyOraDB.Parameter_Values[1] = dtpDate1.DateTime.ToString("yyyyMMdd");
                MyOraDB.Parameter_Values[2] = dtpDate2.DateTime.ToString("yyyyMMdd"); ;
                MyOraDB.Parameter_Values[3] = "";

                MyOraDB.Add_Select_Parameter(true);

                retDS = MyOraDB.Exe_Select_Procedure();

                if (retDS == null) return null;

                return retDS.Tables[MyOraDB.Process_Name];
            }
            catch 
            { return null; }
        }

        private DataTable SEL_DETAIL_INV(string ARG_LINE, string ARG_PO, string ARG_ITEM)
        {
            try
            {
                System.Data.DataSet retDS;
                COM.OraDB MyOraDB = new COM.OraDB();

                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = "MES.PKG_SMART_F_WH.SEL_DETAIL_TRACKING";

                MyOraDB.Parameter_Name[0] = "V_P_PLANT";
                MyOraDB.Parameter_Name[1] = "V_P_DATE";
                MyOraDB.Parameter_Name[2] = "V_P_OBS_NU";
                MyOraDB.Parameter_Name[3] = "V_P_OBS_SEQ";
                MyOraDB.Parameter_Name[4] = "CV_1";


                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_LINE;
                MyOraDB.Parameter_Values[1] = "";
                MyOraDB.Parameter_Values[2] = ARG_PO;
                MyOraDB.Parameter_Values[3] = ARG_ITEM;
                MyOraDB.Parameter_Values[4] = "";

                MyOraDB.Add_Select_Parameter(true);

                retDS = MyOraDB.Exe_Select_Procedure();

                if (retDS == null) return null;

                return retDS.Tables[MyOraDB.Process_Name];
            }
            catch 
            { return null; }
        }

        #endregion

        private void FRM_DVR_FC_TRACKING_DASHBOARD_Load(object sender, EventArgs e)
        {
            //Com_Base.Variables.Master = Com_Base.Functions.Init_Computer(AppDomain.CurrentDomain.BaseDirectory + "App.xml", "master");
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            dtpDate1.DateTime = DateTime.Now.AddDays(1);
            dtpDate2.DateTime = DateTime.Now.AddDays(10);
           // GoFullscreen(true);
            cmd_back.Visible = FORM.Var._Show_back_icon;
        }

        private void FRM_DVR_FC_TRACKING_DASHBOARD_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                set_Text_En_Vi();
                CountLoading = 0;
                _load = true;
                tmr_Reload.Start();
                tmr_Blinking.Start();
            }
            else
            {
                tmr_Reload.Stop();
                tmr_Blinking.Stop();
            }

        }

        private void tmr_Reload_Tick(object sender, EventArgs e)
        {
            CountLoading++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));

            try
            {
                if (CountLoading >= 20)
                {
                    _dt = SEL_DATA(ComVar.Var._strValue1);
                    BindDingData(_dt);
                    CountLoading = 0;
                }
                else if (_load && CountLoading == 1)
                {
                    _dt = SEL_DATA(ComVar.Var._strValue1);
                    BindDingData(_dt);

                    _load = false;
                }
            }
            catch (Exception)
            {}
           
        }

        private string GetText(AxFPUSpreadADO.AxfpSpread spread, int col, int row)
        {
            try
            {
                object data = null;
                spread.GetText(col, row, ref data);
                return data.ToString();
            }
            catch 
            {

                return null;
            }

        }


        private void CreateGridSpan()
        {
            try
            {

                for (int i = 0; i <= 2; i++)
                {
                    axfpView.Col = i;
                    axfpView.ColMerge = FPUSpreadADO.MergeConstants.MergeAlways;
                }
                //int startMline = 2;
                //int startMline1 = 2;
               


                //for (int i = 2; i <= axfpView.MaxRows + 1; i++)
                //{
                //    if (GetText(axfpView, 1, i - 1) + GetText(axfpView, 0, i) != " ")
                //    {
                //        if (GetText(axfpView, 1, i) != GetText(axfpView, 1, startMline))
                //        {
                //            axfpView.AddCellSpan(1, startMline, 1, i - startMline);
                //            startMline = i;
                //        }
                //    }
                //}


                //for (int i = 2; i <= axfpView.MaxRows + 1; i++)
                //{
                //    if (GetText(axfpView, 1, i - 1) + GetText(axfpView, 0, i) != " ")
                //    {
                //        if (GetText(axfpView, 1, i) + GetText(axfpView, 2, i) != GetText(axfpView, 1, startMline1) + GetText(axfpView, 2, startMline1))
                //        {
                //            axfpView.AddCellSpan(2, startMline1, 1, i - startMline1);
                //            startMline1 = i;
                //        }
                //    }
                //}

            }
            catch 
            { }
        }

        private void ClearData()
        {
            for (int irow = 2; irow <= axfpView.MaxRows; irow++)
            {
                for (int icol = 2; icol <= axfpView.MaxCols; icol++)
                {
                    axfpView.SetText(icol, irow, "");
                    axfpView.Row = irow;
                    axfpView.Col = icol;
                    switch (irow % 2)
                    { 
                        case 0:
                            axfpView.BackColor = Row_Default;
                            break;
                        case 1:
                            axfpView.BackColor = Row_Extend;
                            break;
                    }
                }
            }
        }

        private void BindDingData(DataTable arg_dt)
        {
            try
            {
                if (arg_dt != null && arg_dt.Rows.Count > 0)
                {
                    DataTable dt;
                    if (cmd_chk2.Visible)
                        dt = arg_dt.Select("BALANCE <> '0'","CGAC, MODEL, OBS_NU, LINE_NM, ITEM").CopyToDataTable();
                    else
                        dt = arg_dt;

                    pnBody.Hide();
                    axfpView.MaxRows = dt.Rows.Count + 1;
                    ClearData();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        axfpView.Row = i + 2;
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            axfpView.Col = j + 1;
                            switch (j + 1)
                            {
                                case 1:
                                    axfpView.TypeHAlign = FPUSpreadADO.TypeHAlignConstants.TypeHAlignCenter;

                                    break;
                                case 8:
                                case 9:
                                    axfpView.TypeHAlign = FPUSpreadADO.TypeHAlignConstants.TypeHAlignRight;
                                    axfpView.CellType = FPUSpreadADO.CellTypeConstants.CellTypeNumber;
                                    axfpView.TypeNumberDecPlaces = 0;
                                    axfpView.TypeNumberShowSep = true;
                                    break;
                                case 10:
                                    if (Convert.ToInt32(dt.Rows[i][j]) != 0)
                                    {
                                        axfpView.BackColor = Color.Red;
                                        axfpView.ForeColor = Color.White;
                                    }
                                    else
                                        axfpView.ForeColor = Color.Black;

                                    axfpView.TypeHAlign = FPUSpreadADO.TypeHAlignConstants.TypeHAlignRight;
                                    axfpView.CellType = FPUSpreadADO.CellTypeConstants.CellTypeNumber;
                                    axfpView.TypeNumberDecPlaces = 0;
                                    axfpView.TypeNumberShowSep = true;
                                    break;
                                default:
                                    axfpView.TypeHAlign = FPUSpreadADO.TypeHAlignConstants.TypeHAlignCenter;
                                    break;
                            }

                            axfpView.SetText(j + 1, i + 2, dt.Rows[i][j].ToString());




                           // axfpView.Font = new Font("Calibri", 20, FontStyle.Bold);
                            axfpView.TypeVAlign = FPUSpreadADO.TypeVAlignConstants.TypeVAlignCenter;
                            axfpView.set_RowHeight(i + 2, 30);
                        }

                    }
                    CreateGridSpan();




                }
            }
            catch
            { }
            finally 
            { 
                pnBody.Show();
            }
        }

        private void bgw_Loading_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.axfpView.InvokeRequired)
                this.axfpView.Invoke((MethodInvoker)delegate
                {
                    //BindDingData(dt);
                    showAnimation(pnBody);
                });
                else
                {
                    BindDingData(_dt);
                }
        }

        

        private void lblDate_DoubleClick(object sender, EventArgs e)
        {
            if (!FORM.Var._Show_back_icon)
                ComVar.Var.callForm = "Exit";
        }

        private void tmr_Blinking_Tick(object sender, EventArgs e)
        {
            axfpView.Col = 10;
            for (int ir = 1; ir <= axfpView.MaxRows; ir++)
            {
                axfpView.Row = ir;
                if (axfpView.BackColor == Color.Red)
                {
                    axfpView.BackColor = Color.WhiteSmoke;
                    axfpView.ForeColor = Color.Red;
                }
                else if (axfpView.BackColor == Color.WhiteSmoke)
                {
                    axfpView.BackColor = Color.Red;
                    axfpView.ForeColor = Color.White;
                }
            }
        }

        private void cmd_back_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }

        private void axfpView_ClickEvent(object sender, AxFPUSpreadADO._DSpreadEvents_ClickEvent e)
        {
            if (e.col == 10)
            {
                string strplant = ComVar.Var._strValue1;
                string strpo = GetText(axfpView, 5, e.row);
                string stritem = GetText(axfpView, 6, e.row);
                _dt = SEL_DETAIL_INV(strplant, strpo, stritem);
                if (_dt != null && _dt.Rows.Count > 0)
                {
                    FORM.PO_DETAIL PO_detail = new FORM.PO_DETAIL();
                    PO_detail.BindingData(_dt, strpo, stritem);
                    PO_detail.ShowDialog();

                }
            }
        }

        private void Click_Check_Click(object sender, EventArgs e)
        {
            Control cnt = (Control)sender;
            if (cnt.Tag.ToString() == "Red")
            {
                cmd_chk1.Visible = false;
                cmd_chk2.Visible = true;
                
            }
            else
            {
                cmd_chk1.Visible = true;
                cmd_chk2.Visible = false;
            }
            _dt = SEL_DATA(ComVar.Var._strValue1);
            BindDingData(_dt);
        }

    }
}
