using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;
//using JPlatform.Client.Controls;


namespace FORM
{
    public partial class FORM_TO_PO_WEEK_NOS_L : Form
    {
        public FORM_TO_PO_WEEK_NOS_L()
        {
            InitializeComponent();
        }

        int cnt = 0, i_max = 0, i_min = 0;
        string str_op = "";
        string strCol = "";
       // FORM_TO_PO_WEEK_CHART frm_chart = new FORM_TO_PO_WEEK_CHART();
        #region db
        Database db = new Database();
        DataTable _dtXML = null;
        #endregion
        #region UC
        UC.UC_DWMY uc = new UC.UC_DWMY(1);

        #endregion

        private void FRM_ROLL_SLABTEST_MON_Load(object sender, EventArgs e)
        {            
            timer1.Enabled = true;
            timer1.Start();
            timer1.Interval = 1000;
            _dtXML = ComVar.Func.ReadXML(Application.StartupPath + @"\InitForm.xml", this.GetType().Name);
          //  lblTitle1.Text = _dtXML.Rows[0]["frmTitle"].ToString();

          //  pnYMD.Controls.Add(uc);
            uc.OnDWMYClick += DWMYClick;
            uc.YMD_Change(6);
        }

        void DWMYClick(string ButtonCap, string ButtonCD)
        {
            //MessageBox.Show(ButtonCap + "    " + ButtonCD);
            switch (ButtonCD)
            {
                case "C":
                    ComVar.Var.callForm = _dtXML.Rows[0]["frmHome"].ToString();
                    break;
                case "D":
                    
                    //this.Close();
                    //Form fc = Application.OpenForms["FRM_SMT_OS_PROD_DAILY"];
                    //if (fc != null)
                    //    fc.Show();
                    //else
                    //{
                    //    SMT_INSOLE_PROD_DAILY f = new SMT_INSOLE_PROD_DAILY();
                    //    f.Show();
                    //}
                    break;
                case "M":
                    ComVar.Var.callForm = _dtXML.Rows[0]["frmMonth"].ToString();
                    //this.Close();
                    //Form fc1 = Application.OpenForms["FRM_SMT_OS_PROD_MONTH"];
                    //if (fc1 != null)
                    //    fc1.Show();
                    //else
                    //{
                    //    SMT_INSOLE_PROD_MONTH f1 = new SMT_INSOLE_PROD_MONTH();
                    //    f1.Show();
                    //}
                    break;
                case "Y":
                    ComVar.Var.callForm = _dtXML.Rows[0]["frmYear"].ToString();
                    //this.Close();
                    //Form fc2 = Application.OpenForms["FRM_SMT_OS_PROD_YEAR"];
                    //if (fc2 != null)
                    //    fc2.Show();
                    //else
                    //{
                    //    SMT_INSOLE_PROD_YEAR f2 = new SMT_INSOLE_PROD_YEAR();
                    //    f2.Show();
                    //}
                    break;
            }
        }

        public DataSet SEL_TO_PO_WEEKLY()
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_SMT_TO_PO.SEL_TO_PO_BY_WEEK";

                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_LINE";
                MyOraDB.Parameter_Name[1] = "ARG_MLINE";
                MyOraDB.Parameter_Name[2] = "OUT_CURSOR";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR1";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR2";
                
                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Type[4] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ComVar.Var._strValue4;
                MyOraDB.Parameter_Values[1] = ComVar.Var._strValue2;
                MyOraDB.Parameter_Values[2] = "";
                MyOraDB.Parameter_Values[3] = "";
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
        private void formatband()
        {
            try
            {
                
                int n;
                DataTable dtsource = null;
                DataSet ds = SEL_TO_PO_WEEKLY();
                dtsource = ds.Tables[0];
                DataTable dt = ds.Tables[1];
                if (dtsource != null && dtsource.Rows.Count > 0)
                {
                    string name;
                 //   bandMon.Caption = dtsource.Rows[0]["MON"].ToString();
                    if (dtsource.Rows.Count > 0)
                    {
                        foreach (DevExpress.XtraGrid.Views.BandedGrid.GridBand band in gvwView.Bands[1].Children)
                        {
                            double num;
                            if (double.TryParse(band.Caption, out num))
                            {
                                for (int i = 0; i < dtsource.Rows.Count; i++)
                                {
                                    if (band.Name.Contains(dtsource.Rows[i][0].ToString().Substring(dtsource.Rows[i][0].ToString().Length - 2)))
                                    {
                                        band.Visible = true;
                                        break;
                                    }
                                    if (i == dtsource.Rows.Count - 1)
                                    {
                                        band.Visible = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                return;
            }
        }
        private void setGrid()
        {
            
            for (int i = 0; i < gvwView.Columns.Count; i++)
            {
                gvwView.Columns[i].OptionsColumn.ReadOnly = true;
                gvwView.Columns[i].OptionsColumn.AllowEdit = false;
                if (i > 1)
                {
                    gvwView.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gvwView.Columns[i].DisplayFormat.FormatString = "#,0.#";
                    gvwView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                }
                else if (i == 1)
                    gvwView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                else
                    gvwView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;

                if (i == 0)
                    gvwView.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                else
                    gvwView.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;

            }
        }

        private void BindingData()
        {
            try
            {
                grdView.Refresh();
                DataTable dtsource = null;
                DataSet ds = SEL_TO_PO_WEEKLY();
                dtsource = ds.Tables[0];
                DataTable dt = ds.Tables[1];

                //formatband();
              //  frm_chart._dt = dtsource.Copy();
              //  frm_chart._dtTotal = ds.Tables[2];
                if (dtsource == null || dtsource.Rows.Count < 0) return;
                // strCol = dtsource.Rows[0]["COL"].ToString();
                // grdView.DataSource = dtsource.Rows.Count > 0 ? dtsource.Select("MC <> 'TOTAL'", "STT ASC").CopyToDataTable() : dtsource;
                grdView.DataSource = dtsource;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    gvwView.Columns[i * 3 + 2].OwnerBand.ParentBand.Caption = dt.Rows[i]["THEDATE"].ToString();
                }
            }
            catch
            {}
            

            //lblTot_Plan.Text = "0";
            //lblTot_RPlan.Text = "0";
            //lblTot_Act.Text = "0";
            //lblTot_Rate.Text = "0";
            //for (int i = 0; i < gvwView.Columns.Count; i++)
            //{
            //    gvwView.Columns[i].OwnerBand.Caption = "";
            //}
           // if (dtsource != null && dtsource.Rows.Count > 0)
            //{
                //lblTot_Plan.Text = dtsource.Rows[0]["TOT_PLAN"].ToString() + " Prs";
                //lblTot_RPlan.Text = dtsource.Rows[0]["TOT_RPLAN"].ToString() + " Prs";
                //lblTot_Act.Text = dtsource.Rows[0]["TOT_ACT"].ToString() + " Prs";
                //lblTot_Rate.Text = dtsource.Rows[0]["TOT_RATE"].ToString();

                //i_max = Convert.ToInt32(dtsource.Rows[0]["MAX"].ToString());
               // i_min = Convert.ToInt32(dtsource.Rows[0]["MIN"].ToString());
                //lbl1.Text = ">" + i_max + "%";
                //lbl2.Text = i_min + "% ~ " + i_max + "%";
                //lbl3.Text = "<" + i_min + "%";
                /*
                for (int i = 0; i < gvwView.Columns.Count; i++)
                {
                    gvwView.Columns[i].OptionsColumn.ReadOnly = true;
                    gvwView.Columns[i].OptionsColumn.AllowEdit = false;
                    gvwView.Columns[i].OptionsFilter.AllowFilter = false;
                  //  gvwView.Columns[i].OwnerBand.Caption = dtsource.Rows[0][gvwView.Columns[i].FieldName].ToString();
                    gvwView.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                    gvwView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gvwView.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gvwView.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 16, FontStyle.Regular);
                    if (i > 4)
                    {
                        //gvwView.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 13, FontStyle.Regular);
                        gvwView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gvwView.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    }
                    else
                    {
                        gvwView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        gvwView.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    }
                }

                gvwView.Columns[0].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gvwView.Columns[0].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                */
            //}
            
            //axfpSpread.MaxRows = 2;
            //if (dtsource != null && dtsource.Rows.Count > 0)
            //{
            //    for (int i_row = 0; i_row < dtsource.Rows.Count; i_row++)
            //    {
            //        for (int i_col = 0; i_col < dtsource.Columns.Count; i_col++)
            //        {
            //            axfpSpread.Col = i_col + 1;
            //            axfpSpread.Row = i_row + 3;
            //            axfpSpread.ForeColor = Color.Black;
            //            //axfpSpread.TypeHAlign= FPUSpreadADO.TypeHAlignConstants.TypeHAlignCenter;
            //            //axfpSpread.TypeVAlign = FPUSpreadADO.TypeVAlignConstants.TypeVAlignCenter;
            //            //axfpSpread.Font = new System.Drawing.Font("Calibri", 22, FontStyle.Regular);
            //            axfpSpread.set_RowHeight(i_row+3, 27);
            //            axfpSpread.SetText(i_col + 1, i_row + 3, dtsource.Rows[i_row][i_col].ToString());
            //            //axfpSpread.CellBorderStyle = FPUSpreadADO.CellBorderStyleConstants.CellBorderStyleDot;
            //        }
            //    }
            //}
        }

        private void gvwView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {

                e.Appearance.ForeColor = Color.Black;
                if (gvwView.GetRowCellValue(e.RowHandle, "GRP_NM").ToString().Contains("Line"))
                {
                    e.Appearance.BackColor = Color.FromArgb(255, 255, 153);
                }
                else if (gvwView.GetRowCellValue(e.RowHandle, "DIV").ToString().Equals("Total"))
                {

                    e.Appearance.BackColor = Color.FromArgb(252,213,180);

                    //   e.Appearance.ForeColor = Color.Black;

                    //if (e.CellValue.ToString().Replace("%","") != "")
                    //{
                    //    if (Convert.ToDouble(e.CellValue.ToString().Replace("%", "").Trim()) > i_max)
                    //    {
                    //        e.Appearance.BackColor = Color.Green;
                    //        e.Appearance.ForeColor = Color.White;
                    //    }
                    //    else if (Convert.ToDouble(e.CellValue.ToString().Replace("%", "").Trim()) >= i_min && Convert.ToDouble(e.CellValue.ToString().Replace("%", "").Trim()) <= i_max)
                    //    {
                    //        e.Appearance.BackColor = Color.Yellow;
                    //        e.Appearance.ForeColor = Color.Black;
                    //    }
                    //    else
                    //    {
                    //        e.Appearance.BackColor = Color.Red;
                    //        e.Appearance.ForeColor = Color.White;
                    //    }
                    //}
                    //e.Appearance.BackColor = Color.FromArgb(255, 255, 192);
                    //e.Appearance.ForeColor = Color.Black;
                    //e.Appearance.Font = new System.Drawing.Font("Calibri", 16, FontStyle.Regular);
                }

                if (gvwView.GetRowCellValue(e.RowHandle, "GRP_NM").ToString().Contains("Line") && gvwView.GetRowCellValue(e.RowHandle, "DIV").ToString().Equals("Total"))
                {
                    e.Appearance.BackColor = Color.FromArgb(255,192,0);
                    e.Appearance.ForeColor = Color.Black;
                }

                if (e.CellValue.ToString().Contains("Red"))
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.ForeColor = Color.White;
                }
                else if (e.CellValue.ToString().Contains("Lime"))
                {
                    e.Appearance.BackColor = Color.FromArgb(0, 255, 0);
                    e.Appearance.ForeColor = Color.Black;
                }

                //if (e.Column.Name.Contains("PO"))
                //{
                //    int to, po;
                //    if (gvwView.GetRowCellValue(e.RowHandle, e.Column.Name.Substring(0, 4) + "_TO") == null) to = 0;
                //    else
                //        int.TryParse(gvwView.GetRowCellValue(e.RowHandle, e.Column.Name.Substring(0, 4) + "_TO").ToString(), out to);
                //    if (gvwView.GetRowCellValue(e.RowHandle, e.Column.Name.Substring(0, 4) + "_PO") == null) po = 0;
                //    else
                //        int.TryParse(gvwView.GetRowCellValue(e.RowHandle, e.Column.Name.Substring(0, 4) + "_PO").ToString(), out po);

                //    if (po > to)
                //    {
                //        e.Appearance.BackColor = Color.Red;
                //        e.Appearance.ForeColor = Color.White;
                //    }
                //}
            }
            catch (Exception)
            {}

        }

        private void gvwBase_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //try
            //{
            //    //return;
            //    Rectangle rect = e.Bounds;
            //    rect.Inflate(new Size(1, 1));

            //    Brush brush = new SolidBrush(e.Appearance.BackColor);
            //    e.Graphics.FillRectangle(brush, rect);
            //    Pen pen_horizental = new Pen(Color.Blue, 3F);
            //    Pen pen_vertical = new Pen(Color.Blue, 4F);

            //    if (e.Column.FieldName.Contains("COL"))
            //    {
            //        if (e.Column.FieldName == strCol)
            //        {
            //            // draw bottom
            //            //e.Graphics.DrawLine(pen_horizental, rect.X, rect.Y + rect.Height - 1, rect.X + rect.Width, rect.Y + rect.Height - 1);
            //            //// draw top
            //            //e.Graphics.DrawLine(pen_horizental, rect.X, rect.Y, rect.X + rect.Width, rect.Y);

            //            if (e.RowHandle == 0)
            //            {
            //                //e.Graphics.DrawLine(pen_horizental, rect.X, rect.Y, rect.X + rect.Width, rect.Y);
            //            }
            //            else if (e.RowHandle == gvwView.RowCount - 1)
            //            {
            //                e.Graphics.DrawLine(pen_horizental, rect.X, rect.Y + rect.Height - 1, rect.X + rect.Width, rect.Y + rect.Height - 1);
            //            }
            //            // draw right
            //            e.Graphics.DrawLine(pen_vertical, rect.X + rect.Width, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);


            //            // draw left
            //            e.Graphics.DrawLine(pen_horizental, rect.X, rect.Y, rect.X, rect.Y + rect.Height);


            //        }

            //        string[] ls = e.DisplayText.Split('\n');
            //        //if (e.RowHandle < gvwBase.RowCount - 1)
            //        //{
            //        //    e.Graphics.DrawString(ls[0], new Font("Calibri", 12), new SolidBrush(Color.Black), rect, e.Appearance.GetStringFormat());
            //        //}
            //        //else
            //        //{
            //        //    e.Graphics.DrawString(ls[0], new Font("Calibri", 12), new SolidBrush(Color.Black), rect, e.Appearance.GetStringFormat());
            //        //}

            //        if (e.RowHandle < gvwView.RowCount - 1)
            //        {
            //            if (e.Appearance.BackColor == Color.Red || e.Appearance.BackColor == Color.Green)
            //            {
            //                e.Graphics.DrawString(ls[0], new System.Drawing.Font("Times New Roman", 16, FontStyle.Regular), new SolidBrush(Color.White), rect, e.Appearance.GetStringFormat());
            //            }
            //            else
            //            {
            //                e.Graphics.DrawString(ls[0], new System.Drawing.Font("Times New Roman", 16, FontStyle.Regular), new SolidBrush(Color.Black), rect, e.Appearance.GetStringFormat());
            //            }
            //        }
            //        else
            //        {
            //            e.Graphics.DrawString(ls[0], new System.Drawing.Font("Times New Roman", 16, FontStyle.Regular), new SolidBrush(Color.Black), rect, e.Appearance.GetStringFormat());
            //        }

            //        e.Handled = true;
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
        }

        private void gvwBase_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == null) return;
            if (e.Column.AppearanceHeader.BackColor != Color.Empty)
            {
                //e.Appearance.BackColor = Color.Red;
                e.Info.AllowColoring = true;
                //e.Appearance.BackColor = Color.Red;
            }
            if (e.Column.AppearanceHeader.ForeColor != Color.Empty)
            {
                //e.Appearance.BackColor = Color.Red;
                e.Info.AllowColoring = true;
                //e.Appearance.BackColor = Color.Red;
            }
        }

        private void gvwBase_CustomDrawBandHeader(object sender, DevExpress.XtraGrid.Views.BandedGrid.BandHeaderCustomDrawEventArgs e)
        {
            try
            {
                //return;
                Rectangle rect = e.Bounds;
                rect.Inflate(new Size(1, 1));

                Brush brush = new SolidBrush(e.Appearance.BackColor);
                e.Graphics.FillRectangle(brush, rect);
                Pen pen_horizental = new Pen(Color.Blue, 3F);
                Pen pen_vertical = new Pen(Color.Blue, 4F);
                Pen line = new Pen(Color.White, 3F);
                bool boBorder = false;
                string[] ls = e.Band.Caption.Split('\n');

                if (e.Band.HasChildren)
                {
                    if (e.Band.Children[0].Columns.Count > 0)
                        if (e.Band.Children[0].Columns[0].Caption == strCol)
                        {
                            boBorder = true;
                        }
                }
                else
                {
                    if (e.Band.Columns.Count > 0)
                        if (e.Band.Columns[0].Caption == strCol)
                        {
                            boBorder = true;
                        }
                }

                if (boBorder)
                {
                    if (e.Band.HasChildren)
                        e.Graphics.DrawLine(pen_horizental, rect.X, rect.Y, rect.X + rect.Width, rect.Y);
                    else
                    {
                        //e.Graphics.DrawLine(line, rect.X, rect.Y, rect.X + rect.Width, rect.Y);
                    }
                    // draw right
                    e.Graphics.DrawLine(pen_vertical, rect.X + rect.Width - 2, rect.Y, rect.X + rect.Width - 2, rect.Y + rect.Height);


                    // draw left
                    e.Graphics.DrawLine(pen_horizental, rect.X + 1, rect.Y, rect.X + 1, rect.Y + rect.Height);


                    e.Graphics.DrawString(ls[0], e.Appearance.GetFont(), new SolidBrush(e.Appearance.GetForeColor()), rect, e.Appearance.GetStringFormat());
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd")) + "\n\r" + string.Format(DateTime.Now.ToString("HH:mm:ss"));
            if (cnt < 40)
            {
                cnt++;                
            }
            else
            {
                cnt = 0;
                BindingData();
            }
        }

        private void FRM_ROLL_SLABTEST_MON_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    setGrid();
                    timer1.Start();
                    cnt = 40;
                }
                else
                    timer1.Stop();
            }
            catch
            {

            }
        }

        private void lblDateTime_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = ComVar.Var._Frm_Back;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "198";
        }


        private void gvwView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (gvwView.GetRowCellValue(e.RowHandle, "GRP_NM").ToString() == "Chart")
            {
                
            }
        }

        private void grdView_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }

        private void gvwView_DoubleClick(object sender, EventArgs e)
        {
            

            DevExpress.XtraGrid.Views.BandedGrid.BandedGridView view = (DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)sender;

            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            BandedGridHitInfo info = view.CalcHitInfo(pt);
            DevExpress.XtraGrid.Views.BandedGrid.BandedGridView sndr = sender as DevExpress.XtraGrid.Views.BandedGrid.BandedGridView;
            DevExpress.Utils.DXMouseEventArgs dxMouseEventArgs = e as DevExpress.Utils.DXMouseEventArgs;
            DevExpress.XtraGrid.Views.BandedGrid.ViewInfo.BandedGridHitInfo hitInfo = sndr.CalcHitInfo(dxMouseEventArgs.Location);
            
            if (hitInfo.Band.Caption == "Chart")
            {
                ComVar.Var._IsBack = true;
                ComVar.Var._bValue1 = true;
                ComVar.Var.callForm = "198";
               // frm_chart.ShowDialog();
            }
        }

        //private void lblRubber_Click(object sender, EventArgs e)
        //{
        //    //lblTitle.Text = "Rubber Slabtest Tracking by Month";
        //    BindingData("OS");
        //    bindingdatachart("OS");
        //    str_op = "OS";
        //    pnRubber.GradientEndColor = Color.White;//Color.FromArgb(255, 128, 128);
        //    pnEVA.GradientEndColor = Color.Gray;
        //}

        //private void lblEVA_Click(object sender, EventArgs e)
        //{
        //    //lblTitle.Text = "EVA Slabtest Tracking by Month";
        //    BindingData("PH");
        //    bindingdatachart("PH");
        //    str_op = "PH";
        //    pnEVA.GradientEndColor = Color.White; //Color.FromArgb(255, 128, 128);
        //    pnRubber.GradientEndColor = Color.Gray;
        //}

        //private void cmdYear_Click(object sender, EventArgs e)
        //{

        //}
    }
}
