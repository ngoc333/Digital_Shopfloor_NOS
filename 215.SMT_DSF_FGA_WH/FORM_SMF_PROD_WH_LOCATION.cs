using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Threading;
using System.IO;


namespace FORM
{
    public partial class FORM_SMF_PROD_WH_LOCATION : Form
    {
        public FORM_SMF_PROD_WH_LOCATION()
        {
            InitializeComponent();
            cmd_back.Visible = FORM.Var._Show_back_icon;
        }


        int rows_dt_shelf;
        DataTable _dt_Shelf= null;
        DataTable _dt_mold = null;
        DataTable _dt_mold_in_wh = null;
        string _str_Pre_Box="";
        int index = 1;
        int _icount = 0;
        int _ReLoad = 60,_time=0, _preHeadRow =0;
        DataTable _dt_search = null;
        string _str_text = "";
        bool _bStatus = true;
        bool _bLoad = true;
        string _strScan = "";
        Dictionary<string, int>[] _DicLocation = new Dictionary<string, int>[1];
        List<string> _ls_search = new List<string>();

        

        System.Windows.Media.Color _M_Bcolor = System.Windows.Media.Color.FromRgb(255, 128, 0);
        System.Windows.Media.Color _M_Fcolor = System.Windows.Media.Color.FromRgb(255, 255, 255);
        System.Windows.Media.Color _M_BcolorTop, _M_FcolorTop;

        private void set_Text_En_Vi()
        {
            if (ComVar.Var._strValue3 == "Vn")
            {
                lblTitle.Text = "Sơ Đồ Vị Trí";
            }
            else
            {
                lblTitle.Text = "F/G Warehouse Location";

            }
        }

        private void Test_Location_IP_Mold_Load(object sender, EventArgs e)
        {
            //Com_Base.Variables.Master = Com_Base.Functions.Init_Computer(AppDomain.CurrentDomain.BaseDirectory + "App.xml", "master");
            


           


            GoFullscreen(true);

            //Color c = Color.FromArgb(230123); 15043570   11878325

           // InitFSP();

         //   fsp_Main.GetCellRange(1, 1).StyleNew.BackColor = Color.FromArgb(System.Convert.ToInt32("-11812533"));
          //  fsp_Main.GetCellRange(1, 2).StyleNew.BackColor = Color.FromArgb(75, 193, 75);

           // fsp_Main.GetCellRange(1, i).StyleNew.BackColor;

           // InitfpSpread();

            //if (Com_Base.Variables.Master[0].ContainsKey("Floor"))
            //{
            //    if (Com_Base.Variables.Master[0]["Floor"].ToString() == "1")
            //    {
            //        axfpSpread2.Visible = false;
            //        // pn_loc_wh.Location = new Point(3, 2);
            //     //   pn_loc_wh.Width = 1909;
            //    }
            //}
            //else
            //{
            //    if (Com_Base.Variables.Master[0]["WH_CD"].ToString() == "013" || Com_Base.Variables.Master[0]["WH_CD"].ToString() == "011")
            //        axfpSpread2.Visible = false;
            //    else
            //        axfpSpread2.Visible = true;
            //}

            if (ComVar.Var._strValue1 == "013" || ComVar.Var._strValue1 == "011")
                axfpSpread2.Visible = false;
            else
                axfpSpread2.Visible = true;

            if (ComVar.Var._strValue1 == "099")
            {
                axfpSpread2.SetText(1, 1, "W/H 1");
                axfpSpread2.SetText(1, 3, "W/H 2");
            }

            //if (ComVar.Var._strValue1 == "018")
            //{
            //    pn_loc_wh.Location = new Point(3, 2);
            //    pn_loc_wh.Size = new Size(1909, 595);
            //    // axfpSpread2.SetText(1, 3, "W/H 2");
            //}
            //else
            //{
            //    pn_loc_wh.Location = new Point(147, 2);
            //    pn_loc_wh.Size = new Size(1765, 595);
                
            //}
        }

#region Function
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

        private void InitForm()
        {
            axSpreadHead.Visible = false;
            axSpreadTail.Visible = false;
            InitLocation();

        }

        #region InitBox

       

        private void InitLocation()
        {
            try
            {
                rows_dt_shelf = _dt_Shelf.Rows.Count;
                //int x1 = Convert.ToInt32(_dt_Shelf.Rows[0]["group1_x"]);
                //int y1 = Convert.ToInt32(_dt_Shelf.Rows[0]["group1_y"]);

                //int x2 = Convert.ToInt32(_dt_Shelf.Rows[0]["group1_x"]);
                //int y2 = Convert.ToInt32(_dt_Shelf.Rows[0]["group1_y"]);

                Color BColorTop = Color.FromArgb(Convert.ToInt32(_dt_Shelf.Rows[0]["BCOLOR_TOP"]));
                Color FColorTop = Color.FromArgb(Convert.ToInt32(_dt_Shelf.Rows[0]["FCOLOR_TOP"]));

                _M_BcolorTop = System.Windows.Media.Color.FromArgb(BColorTop.A, BColorTop.R, BColorTop.G, BColorTop.B);
                _M_FcolorTop = System.Windows.Media.Color.FromArgb(FColorTop.A, FColorTop.R, FColorTop.G, FColorTop.B);

                int y0 = 100;
                int x, y, w_element, h_element, w_box, h_box, plus_x;
                x = Convert.ToInt32(_dt_Shelf.Rows[0]["col_x"]);
                y = Convert.ToInt32(_dt_Shelf.Rows[0]["col_y"]);
                plus_x = Convert.ToInt32(_dt_Shelf.Rows[0]["plus_x"]);
                bool b_background = false;
                Color Bcolor = Color.Empty;
                Color Fcolor = Color.Empty;
                Color Bcolor_Polygon = Color.Empty;
                string str_status="" , str_status_polygon = "";
              //  LocationBox.BoxSmall1 box;
                //CreateBox(x, y, _dt_Shelf.Rows[0]["shelf"].ToString(), "", _dt_Shelf.Rows[0]["cell"].ToString(), w, h, false);

                for (int i = 0; i < rows_dt_shelf; i++)
                {
                    
                    str_status = _dt_Shelf.Rows[i]["STA_COLOR"].ToString();
                    switch (_dt_Shelf.Rows[i]["status"].ToString())
                    {
                        case "":
                            x += Convert.ToInt32(_dt_Shelf.Rows[i]["plus_x"]);;
                            y = y0;
                            b_background = true;
                            str_status_polygon = _dt_Shelf.Rows[i - 1]["STA_COLOR"].ToString();
                           // Bcolor_Polygon = Color.FromArgb(Convert.ToInt32(_dt_Shelf.Rows[i - 1]["BCOLOR" + str_status_polygon]));
                            
                            break;
                        case "NEW_LINE":
                            x = Convert.ToInt32(_dt_Shelf.Rows[i]["col_x"]);
                            y = Convert.ToInt32(_dt_Shelf.Rows[i]["col_y"]);
                            y0 = y;
                            b_background = false;                            
                            str_status_polygon = "1";
                            break;                        
                    }
                    w_element = Convert.ToInt32(_dt_Shelf.Rows[i]["element_host_W"]);
                    h_element = Convert.ToInt32(_dt_Shelf.Rows[i]["element_host_H"]);
                    w_box = Convert.ToInt32(_dt_Shelf.Rows[i]["box_W"]);
                    h_box = Convert.ToInt32(_dt_Shelf.Rows[i]["box_H"]);

                    Bcolor = Color.FromArgb(Convert.ToInt32(_dt_Shelf.Rows[i]["BCOLOR" + str_status]));
                    Fcolor = Color.FromArgb(Convert.ToInt32(_dt_Shelf.Rows[i]["FCOLOR" + str_status]));
                    CreateBox(x, y, _dt_Shelf.Rows[i]["shelf"].ToString(), "", _dt_Shelf.Rows[i]["cell"].ToString(),
                                w_element, h_element, w_box, h_box, b_background, _dt_Shelf.Rows[i]["text"].ToString()
                                , _M_BcolorTop
                                , System.Windows.Media.Color.FromArgb(Bcolor.A, Bcolor.R, Bcolor.G, Bcolor.B)
                                , System.Windows.Media.Color.FromArgb(Fcolor.A, Fcolor.R, Fcolor.G, Fcolor.B)
                                , _M_FcolorTop
                                , _M_BcolorTop
                                , setBoderBox(str_status), false
                            );
              
                    
                }

                

            }
            catch (Exception)
            {}            
        }

        private void CreateBox(int x, int y, string shelf, string floor, string cell, int w_element, int h_element, int w_box, int h_box, bool bg_clolor, string arg_text
                               , System.Windows.Media.Color arg_bcolor_top
                               , System.Windows.Media.Color arg_bcolor
                               , System.Windows.Media.Color arg_fcolor
                               , System.Windows.Media.Color arg_fcolor_top
                               , System.Windows.Media.Color arg_bcolor_polygon
                               , string arg_boder, bool arg_boder_polygon
                               )
        {
            //this.BeginInvoke((Action)(() =>
            //{

            System.Windows.Forms.Integration.ElementHost Element = new System.Windows.Forms.Integration.ElementHost();
            LocationBox.BoxSmall1 box = new LocationBox.BoxSmall1();


            box.setSizeBox(w_box, h_box);
            box.setVisible(bg_clolor);
          //  box.Caption = shelf.Substring(0, 1);
            box.Caption = arg_text;
            box.SetCaption();
           // box.Caption1 = shelf.Substring(1, 2);
            box.Caption1 = shelf;
            box.SetCaption1();
            box.TabIndex = index;           
            box.Name = shelf;
            box.BoxColor(arg_bcolor, arg_bcolor_top, arg_bcolor, arg_fcolor, arg_fcolor_top, arg_boder);
            box.BoxPolygonColor(arg_bcolor_polygon, arg_boder_polygon);

            box.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(BoxHead_MouseLeftButtonUp);

            Element.Name = shelf;
            Element.Location = new Point(x, y);
            Element.Size = new Size(w_element, h_element);
            Element.TabIndex = index;
            //  if (bg_clolor) Element.BackColor = Color.SkyBlue;
            
            Element.Child = box;
            //  if (bf== true) 
            //     Element.SendToBack();
            // Element.BringToFront();
            // Element.BackColor = Color.White;

            //perform on the UI thread
            //     this.Controls.Add(Element);
            pn_loc_wh.Controls.Add(Element);

            //this.Controls.Add(Element);
            Element.BringToFront();
            index++;


            //}));
        }

        private void BoxHead_MouseLeftButtonUp(object sender, System.EventArgs e)
        {

            LocationBox.BoxSmall1 box = (LocationBox.BoxSmall1)sender;

           
            
            //LocationBox.BoxSmall1 box2;
            //box.BoxColor(System.Windows.Media.Color.FromRgb(51, 102, 255), System.Windows.Media.Color.FromRgb(51, 102, 255)
            //            , System.Windows.Media.Color.FromRgb(51, 102, 255), System.Windows.Media.Color.FromRgb(255, 255, 255)
            //            , System.Windows.Media.Color.FromRgb(255, 255, 255),false);

            //string str_name = box.Name.Substring(0, 1)
            //                  + (Convert.ToInt16(box.Name.Substring(1, 2)) + 1).ToString().PadLeft(2, '0');

            //if (_DicLocation[0].ContainsKey(str_name))
            //{
            //    ElementHost el = (ElementHost)pn_loc_wh.Controls[_DicLocation[0][str_name]];
            //    box2 = (LocationBox.BoxSmall1)el.Child;
            //    box2.BoxPolygonColor(System.Windows.Media.Color.FromRgb(51, 102, 255), false);
            //}

            System.Windows.Media.Color Mbcolor = System.Windows.Media.Color.FromRgb(51, 102, 255);
            System.Windows.Media.Color Mfcolor = System.Windows.Media.Color.FromRgb(255, 255, 255);

            SetColorBox(box.Name, box, Mbcolor, Mbcolor, Mbcolor, Mfcolor, Mfcolor, "0");

            if (_str_Pre_Box != box.Name)
                SetBoxDafault(_str_Pre_Box);
            axSpreadHead.SetText(1, 1,"Shelf " + box.Name);
            Set_Data_Grid_Head(SEL_DETAIL_CELL_HEAD(box.Name), box.Name);


            _str_Pre_Box = box.Name;


            //click_clear_head();
           // box.BoxColorChange();

           // I_PreClick = box.TabIndex;
        }

        

        private void SetBoxDafault(string arg_name)
        {
            if (_DicLocation[0].ContainsKey(arg_name))
            {
                //if (_ls_search.Contains(arg_name))
                //{
                //    SetColorBox(arg_name, null, _M_Bcolor, _M_Bcolor, _M_Bcolor, _M_Fcolor, _M_Fcolor, "101");
                //    return;
                //}

                Color Dbcolor = Color.Empty, Dfcolor = Color.Empty;
                System.Windows.Media.Color Mbcolor, Mfcolor;
                string str_status = "";

                var result = (from DataRow dRow in _dt_Shelf.Rows
                              where (string)dRow["shelf"] == arg_name
                              select new { bcolor = (string)dRow["BCOLOR" + dRow["STA_COLOR"]]
                                          ,fcolor = (string)dRow["FCOLOR" + dRow["STA_COLOR"]]
                                          ,status = (decimal)dRow["STA_COLOR"]
                                          }).Distinct();
                
                foreach(var e in result)
                {
                    Dbcolor = Color.FromArgb(Convert.ToInt32(e.bcolor));
                    Dfcolor = Color.FromArgb(Convert.ToInt32(e.fcolor));
                    str_status = e.status.ToString();
                }

                Mbcolor = System.Windows.Media.Color.FromArgb(Dbcolor.A, Dbcolor.R, Dbcolor.G, Dbcolor.B);
                Mfcolor = System.Windows.Media.Color.FromArgb(Dfcolor.A, Dfcolor.R, Dfcolor.G, Dfcolor.B);

                SetColorBox(arg_name, null, Mbcolor, _M_BcolorTop, Mbcolor, Mfcolor, _M_FcolorTop, setBoderBox(str_status));

                //LocationBox.BoxSmall1 box;
                
                //box = Getbox(arg_name);
                //box.BoxColor(Mbcolor, Mbcolor, Mbcolor, Mfcolor, Mfcolor, setBoderBox(str_status));


                //LocationBox.BoxSmall1 box2;
                //string str_name = arg_name.Substring(0, 1)
                //              + (Convert.ToInt16(arg_name.Substring(1, 2)) + 1).ToString().PadLeft(2, '0');
                //if (_DicLocation[0].ContainsKey(str_name))
                //{
                //    box2 = Getbox(str_name);
                //    box2.BoxPolygonColor(Mbcolor, setBoderBox(str_status));
                //}


            }
        }

        private void SetColorBox(string arg_name, LocationBox.BoxSmall1 arg_box,
                                 System.Windows.Media.Color arg_front, System.Windows.Media.Color arg_top, System.Windows.Media.Color arg_right,
                                 System.Windows.Media.Color arg_fore_front, System.Windows.Media.Color arg_fore_top, string arg_boder)
        {
            LocationBox.BoxSmall1 box;
            if (arg_box != null) 
                box = arg_box;
            else
                box = Getbox(arg_name);

            box.BoxColor(arg_front, arg_top, arg_right, arg_fore_front, arg_fore_top, arg_boder);


            LocationBox.BoxSmall1 box2;
            string str_name = arg_name.Substring(0, 1)
                          + (Convert.ToInt16(arg_name.Substring(1, 2)) + 1).ToString().PadLeft(2, '0');
            if (_DicLocation[0].ContainsKey(str_name))
            {
                box2 = Getbox(str_name);
                box2.BoxPolygonColor(arg_top, false);
            }
        }

        private LocationBox.BoxSmall1 Getbox(string arg_name)
        {
            if (_DicLocation[0].ContainsKey(arg_name))
            {
                ElementHost element = (ElementHost)pn_loc_wh.Controls[_DicLocation[0][arg_name]];
                return (LocationBox.BoxSmall1)element.Child;
            }
            else return null;
        }

        private string setBoderBox(string arg_str)
        {
           
            if (arg_str == "2" || arg_str == "4")
                return "101";
            else
                return "0";

        }

        private void Init_Dictionary_Location()
        {
            _DicLocation[0] = new Dictionary<string, int>();
            for (int i = 0; i < pn_loc_wh.Controls.Count; i++)
            {
                _DicLocation[0].Add(pn_loc_wh.Controls[i].Name, i);
                

            }
        }

        

        #endregion InitBox


        private void Set_Data_Grid_Head(DataTable arg_dt, string arg_box_name)
        {
            try
            {
                DataTable dt;
                axSpreadHead.Visible = false;
                if (txt_obsnu.Text != "" && _ls_search.Contains(arg_box_name))
                {
                    string expression = "po = '" + txt_obsnu.Text + "' AND item = '" + cbo_item.SelectedValue.ToString() + "'";
                    string sortOrder = "DPO, STYLE_NM, STYLE_CD, DEST ASC";
                    string[] str_HeadName = new string[arg_dt.Columns.Count];
                    for (int i = 0; i < arg_dt.Columns.Count; i++)
                    {
                        str_HeadName[i] = arg_dt.Columns[i].ColumnName;
                    }
                    dt = arg_dt.Select(expression, sortOrder).CopyToDataTable().DefaultView.ToTable(true, str_HeadName);
                }
                else
                {
                    dt = arg_dt;
                }

                axSpreadHead.ClearRange(1, 4, axSpreadHead.MaxCols, axSpreadHead.MaxRows, true);
                axSpreadHead.FontSize = 16f;
                axSpreadHead.MaxRows = 3;
                axSpreadHead.TypeVAlign = FPUSpreadADO.TypeVAlignConstants.TypeVAlignCenter;

                for (int i = 1; i <= axSpreadHead.MaxCols; i++)
                {

                    axSpreadHead.Col = i;
                    switch (i)
                    {
                        case 1:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                            axSpreadHead.TypeHAlign = FPUSpreadADO.TypeHAlignConstants.TypeHAlignCenter;
                            break;
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                            axSpreadHead.TypeHAlign = FPUSpreadADO.TypeHAlignConstants.TypeHAlignRight;
                            break;
                        case 2:
                        case 4:
                            axSpreadHead.TypeHAlign = FPUSpreadADO.TypeHAlignConstants.TypeHAlignLeft;
                            break;
                    }
                }


                for (int i = 1; i <= 3; i++)
                {
                    axSpreadHead.Row = i;
                    axSpreadHead.Col = -1;
                    axSpreadHead.FontSize = 18f;
                    axSpreadHead.FontBold = true;
                    for (int k = 1; k < axSpreadHead.MaxCols; k++)
                    {
                        axSpreadHead.Col = k;
                        axSpreadHead.TypeHAlign = FPUSpreadADO.TypeHAlignConstants.TypeHAlignCenter;
                    }

                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    int k = 0;
                    axSpreadHead.MaxRows = dt.Rows.Count + 3;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        k = i + 4;

                        for (int j = 0; j < axSpreadHead.MaxCols; j++)
                        {
                            axSpreadHead.SetText(j + 1, k, dt.Rows[i][j].ToString());

                        }
                    }

                    axSpreadHead.RowsFrozen = 3;


                }
            }
            catch (Exception)
            { }
            finally
            {
                
                FORM.ClassLib.WinAPI.AnimateWindow(this.axSpreadHead.Handle, 400, FORM.ClassLib.WinAPI.getSlidType("5"));
                axSpreadHead.Visible = true;
                axSpreadTail.Visible = false;
            }


        }

        private string Get_data_grid(int arg_col, int arg_row)
        {
            axSpreadHead.Row = arg_row;
            axSpreadHead.Col = arg_col;
            return axSpreadHead.Text;
        }

        private void Set_Data_Grid_Tail(DataTable arg_dt)
        {
            try
            {
                axSpreadTail.Visible = false;
                axSpreadTail.MaxCols = 1;
                axSpreadTail.MaxCols = arg_dt.Rows.Count + 1;

                axSpreadTail.FontSize = 16f;
                axSpreadTail.TypeHAlign = FPUSpreadADO.TypeHAlignConstants.TypeHAlignCenter;
                axSpreadTail.TypeVAlign = FPUSpreadADO.TypeVAlignConstants.TypeVAlignCenter;
                axSpreadTail.Col = 1;
                axSpreadTail.FontBold = true;

                for (int i = 0; i < arg_dt.Rows.Count; i++)
                {
                    axSpreadTail.Col = i + 2;
                    axSpreadTail.Row = 1;
                    axSpreadTail.BackColor = Color.Gray;
                    axSpreadTail.ForeColor = Color.White;
                    axSpreadTail.SetText(i + 2, 1, arg_dt.Rows[i]["CS_SIZE"].ToString());
                    axSpreadTail.SetText(i + 2, 2, arg_dt.Rows[i]["QTY"].ToString());

                }
                axSpreadTail.SetCellBorder(2, 1, axSpreadTail.MaxCols, 1, FPUSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0, FPUSpreadADO.CellBorderStyleConstants.CellBorderStyleBlank);
              //  axSpreadTail.SetCellBorder(2, 2, axSpreadTail.MaxCols, 2, FPUSpreadADO.CellBorderIndexConstants.CellBorderIndexLeft, 0, FPUSpreadADO.CellBorderStyleConstants.CellBorderStyleSolid);
            }
            catch (Exception)
            { }
            finally
            {
                
                FORM.ClassLib.WinAPI.AnimateWindow(this.axSpreadTail.Handle, 400, FORM.ClassLib.WinAPI.getSlidType("5"));
                axSpreadTail.Visible = true;

            }
        }

        private void load_cbo_item(DataTable dt)
        {
            if (dt == null)
            {
                cbo_item.DataSource = null;
                return;
            }
            var result = (from DataRow dRow in dt.Rows
                          //where (string)dRow["model_cd"] == arg_model
                          //  && dRow["cs_size"].ToString().StartsWith(arg_size))
                          orderby dRow["ITEM"]
                          select new { code = (string)dRow["ITEM"], name = (string)dRow["ITEM"] }).Distinct();

            DataTable temp_datatable = new DataTable("Combo List");
            // DataRow newrow;
            temp_datatable.Columns.Add(new DataColumn("Code", Type.GetType("System.String")));
            temp_datatable.Columns.Add(new DataColumn("Name", Type.GetType("System.String")));

            DataRow newrow = temp_datatable.NewRow();

            //newrow[0] = "";
            //newrow[1] = "ALL";
            //temp_datatable.Rows.InsertAt(newrow, 0);


            foreach (var element in result)
            {
                newrow = temp_datatable.NewRow();
                newrow["code"] = element.code;
                newrow["name"] = element.name;
                temp_datatable.Rows.Add(newrow);
            }



            cbo_item.DataSource = temp_datatable;
            cbo_item.DisplayMember = "name";
            cbo_item.ValueMember = "code";

            //  cbo_item.SelectedValue = "";
        }

        private void Clear_seach()
        {
            //string[] arr = new string[_ls_search.Count];
            //_ls_search.CopyTo(arr);
            List<string> ls = new List<string>();
            ls = _ls_search.ToList();
            _ls_search.Clear();
            LocationBox.BoxSmall1 box;
            foreach (string str in ls)
            {
                box = Getbox(str);
                box.setBlink(false);
                box.BoxColorDefault();
                
            }
        }

        private void ReloadData()
        {
            try
            {
                Color BColorTop = Color.FromArgb(Convert.ToInt32(_dt_Shelf.Rows[0]["BCOLOR_TOP"]));
                Color FColorTop = Color.FromArgb(Convert.ToInt32(_dt_Shelf.Rows[0]["FCOLOR_TOP"]));
                Color Bcolor = Color.Empty;
                Color Fcolor = Color.Empty;
                LocationBox.BoxSmall1 box;
                for (int i = 0; i < _dt_Shelf.Rows.Count; i++)
                {
                    box = Getbox(_dt_Shelf.Rows[i]["SHELF"].ToString());
                    box.Caption = _dt_Shelf.Rows[i]["TEXT"].ToString();
                    box.SetCaption();
                    //setBoderBox(_dt_Shelf.Rows[i]["STA_COLOR"].ToString())
                    Bcolor = Color.FromArgb(Convert.ToInt32(_dt_Shelf.Rows[i]["BCOLOR" + _dt_Shelf.Rows[i]["STA_COLOR"].ToString()]));
                    Fcolor = Color.FromArgb(Convert.ToInt32(_dt_Shelf.Rows[i]["FCOLOR" + _dt_Shelf.Rows[i]["STA_COLOR"].ToString()]));

                    box.BoxColor(System.Windows.Media.Color.FromArgb(Bcolor.A, Bcolor.R, Bcolor.G, Bcolor.B)
                                 , System.Windows.Media.Color.FromArgb(BColorTop.A, BColorTop.R, BColorTop.G, BColorTop.B)
                                 , System.Windows.Media.Color.FromArgb(Bcolor.A, Bcolor.R, Bcolor.G, Bcolor.B)
                                 , System.Windows.Media.Color.FromArgb(Fcolor.A, Fcolor.R, Fcolor.G, Fcolor.B)
                                 , System.Windows.Media.Color.FromArgb(FColorTop.A, FColorTop.R, FColorTop.G, FColorTop.B)
                                 , setBoderBox(_dt_Shelf.Rows[i]["STA_COLOR"].ToString()));


                }
            }
            catch (Exception)
            { }

        }

        #region no use

        private void dt_default()
        {
            _dt_mold_in_wh = new DataTable("Combo List");
            DataRow row = _dt_mold_in_wh.NewRow();
            _dt_mold_in_wh.Columns.Add(new DataColumn("SHELF", Type.GetType("System.String")));
            _dt_mold_in_wh.Columns.Add(new DataColumn("LOCATED_CD", Type.GetType("System.String")));

            row["SHELF"] = "";
            row["LOCATED_CD"] = "";
            _dt_mold_in_wh.Rows.InsertAt(row, 0);


        }
        #region Combobox

        private void cbo_default(ComboBox arg_tb)
        {
            DataTable dataTable = new DataTable("Combo List");
            DataRow row = dataTable.NewRow();
            dataTable.Columns.Add(new DataColumn("Code", Type.GetType("System.String")));
            dataTable.Columns.Add(new DataColumn("Name", Type.GetType("System.String")));

            row["Code"] = "";
            row["Name"] = "ALL";
            dataTable.Rows.InsertAt(row, 0);

            arg_tb.DataSource = dataTable;
            arg_tb.ValueMember = "Code";
            arg_tb.DisplayMember = "Name";
        }

        private void load_cbo_model()
        {
            //_dt_mold = SELECT_MOLD_IN_WH();
            if (_dt_mold != null && _dt_mold.Rows.Count > 0)
            {
                init_cbo_model_txt(_dt_mold, "");
                cbo_default(cbo_item);
                cbo_default(cbo_size);
                cbo_default(cbo_seq);
            }
            
        }
        
        private void load_cbo_size(DataTable dt, string arg_model, string arg_moldcd)
        {
            //
            //cbo_com.DataSource = dt_com;


            var result = (from DataRow dRow in dt.Rows
                          where (dRow["model_cd"].ToString().StartsWith(arg_model)
                              && dRow["mold_cd"].ToString().StartsWith(arg_moldcd))
                          orderby Convert.ToDouble(dRow["use_size"].ToString().Replace("T", ".5"))
                          select new { code = dRow["use_size"], name = dRow["use_size"] }).Distinct().ToArray();



            DataTable temp_datatable = new DataTable("Combo List");
            DataRow newrow;
            temp_datatable.Columns.Add(new DataColumn("Code", Type.GetType("System.String")));
            temp_datatable.Columns.Add(new DataColumn("Name", Type.GetType("System.String")));

            newrow = temp_datatable.NewRow();
            newrow["Code"] = "";
            newrow["Name"] = "ALL";
            temp_datatable.Rows.Add(newrow);

            foreach (var element in result)
            {
                newrow = temp_datatable.NewRow();
                newrow["Code"] = element.code;
                newrow["Name"] = element.name;
                temp_datatable.Rows.Add(newrow);
            }

            cbo_size.DataSource = temp_datatable;
            cbo_size.DisplayMember = "Name";
            cbo_size.ValueMember = "Code";

            cbo_size.SelectedValue = "";
        }

        private void load_cbo_seq(DataTable dt, string arg_model, string arg_moldcd, string arg_size)
        {
            //
            //cbo_com.DataSource = dt_com;


            var result = (from DataRow dRow in dt.Rows
                          where (dRow["model_cd"].ToString().StartsWith(arg_model)
                              && dRow["mold_cd"].ToString().StartsWith(arg_moldcd)
                              && dRow["use_size"].ToString().StartsWith(arg_size))
                          orderby dRow["seq_no"]
                          select new { code = dRow["seq_no"], name = dRow["seq_no"] }).Distinct().ToArray();



            DataTable temp_datatable = new DataTable("Combo List");
            DataRow newrow;
            temp_datatable.Columns.Add(new DataColumn("Code", Type.GetType("System.String")));
            temp_datatable.Columns.Add(new DataColumn("Name", Type.GetType("System.String")));

            newrow = temp_datatable.NewRow();
            newrow["Code"] = "";
            newrow["Name"] = "ALL";
            temp_datatable.Rows.Add(newrow);

            foreach (var element in result)
            {
                newrow = temp_datatable.NewRow();
                newrow["Code"] = element.code;
                newrow["Name"] = element.name;
                temp_datatable.Rows.Add(newrow);
            }



            cbo_seq.DataSource = temp_datatable;
            cbo_seq.DisplayMember = "Name";
            cbo_seq.ValueMember = "Code";

            cbo_seq.SelectedValue = "";
        }

        private void init_cbo_model_txt(DataTable dt, string txt)
        {
            string expression = "model_name LIKE '" + txt + "%'";
            string sortOrder = "model_name ASC";
            DataTable temp_datatable = dt.Select(expression, sortOrder).CopyToDataTable().DefaultView.ToTable(true, "model_cd", "model_name");

            DataRow newrow = temp_datatable.NewRow();
            newrow[0] = "";
            newrow[1] = "ALL";
            temp_datatable.Rows.InsertAt(newrow, 0);

            cbo_style.DataSource = temp_datatable;
            cbo_style.DisplayMember = "model_name";
            cbo_style.ValueMember = "model_cd";
            //cbo_model.Splits[0].DisplayColumns["Code"].Width = 150;
            cbo_style.SelectedValue = "";
        }
        

        #endregion Combobox
        #endregion no use

#endregion Fuction

        #region DB
        public DataTable SEL_MOLD_LOCATED_MASTER()
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "SEPHIROTH.PKG_SMF.SEL_LOCATED_MASTER";

                MyOraDB.ReDim_Parameter(2);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "OUT_CURSOR";
                MyOraDB.Parameter_Name[1] = "ARG_WH_CD";

                MyOraDB.Parameter_Type[0] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;

                MyOraDB.Parameter_Values[0] = "";
                MyOraDB.Parameter_Values[1] = ComVar.Var._strValue1;

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


        public DataTable SEL_DETAIL_CELL_HEAD(string arg_shelf)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "SEPHIROTH.PKG_SMF.SEL_DETAIL_CELL";

                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "OUT_CURSOR";
                MyOraDB.Parameter_Name[1] = "ARG_WH_CD";
                MyOraDB.Parameter_Name[2] = "ARG_CELL";

                MyOraDB.Parameter_Type[0] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;

                MyOraDB.Parameter_Values[0] = "";
                MyOraDB.Parameter_Values[1] = ComVar.Var._strValue1;
                MyOraDB.Parameter_Values[2] = arg_shelf;

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

        public DataTable SEL_DETAIL_CELL_TAIL(string arg_shelf, string arg_style_cd, string arg_po, string arg_item )
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "SEPHIROTH.PKG_SMF.SEL_DETAIL_CELL_STYLE";

                MyOraDB.ReDim_Parameter(6);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "OUT_CURSOR";
                MyOraDB.Parameter_Name[1] = "ARG_WH_CD";
                MyOraDB.Parameter_Name[2] = "ARG_CELL";
                MyOraDB.Parameter_Name[3] = "ARG_STYLE_CD";
                MyOraDB.Parameter_Name[4] = "ARG_PO";
                MyOraDB.Parameter_Name[5] = "ARG_ITEM";

                MyOraDB.Parameter_Type[0] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (int)OracleType.VarChar;

                MyOraDB.Parameter_Values[0] = "";
                MyOraDB.Parameter_Values[1] = ComVar.Var._strValue1;
                MyOraDB.Parameter_Values[2] = arg_shelf;
                MyOraDB.Parameter_Values[3] = arg_style_cd;
                MyOraDB.Parameter_Values[4] = arg_po;
                MyOraDB.Parameter_Values[5] = arg_item;

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

        public DataTable SEL_SEARCH_BY_PO(string arg_po, string arg_item)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "SEPHIROTH.PKG_SMF.SEL_SEARCH_BY_PO";

                MyOraDB.ReDim_Parameter(4);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "OUT_CURSOR";
                MyOraDB.Parameter_Name[1] = "ARG_WH_CD";
                MyOraDB.Parameter_Name[2] = "ARG_PO";
                MyOraDB.Parameter_Name[3] = "ARG_ITEM";

                MyOraDB.Parameter_Type[0] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;

                MyOraDB.Parameter_Values[0] = "";
                MyOraDB.Parameter_Values[1] = ComVar.Var._strValue1;
                MyOraDB.Parameter_Values[2] = arg_po;
                MyOraDB.Parameter_Values[3] = arg_item;

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


#region Event
      
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd")) + "\n\r" + string.Format(DateTime.Now.ToString("HH:mm:ss"));
                _time++;
                if (_time >= _ReLoad)
                {
                    DataTable dt = SEL_MOLD_LOCATED_MASTER();
                    if (dt != null & dt.Rows.Count > 0)
                    {
                        _dt_Shelf = dt;
                        lbl_Actual.Text = _dt_Shelf.Rows[0]["TOT_ACTUAL"].ToString();
                        lbl_Capa.Text = _dt_Shelf.Rows[0]["TOT_CAPA"].ToString();
                        lbl_Remain.Text = _dt_Shelf.Rows[0]["TOT_REMAIN"].ToString();
                        ReloadData();

                    }
                    _time = 0;
                }
                else if (_bLoad && _time == 1)
                {
                    _dt_Shelf = SEL_MOLD_LOCATED_MASTER();

                    lbl_Actual.Text = _dt_Shelf.Rows[0]["TOT_ACTUAL"].ToString();
                    lbl_Capa.Text = _dt_Shelf.Rows[0]["TOT_CAPA"].ToString();
                    lbl_Remain.Text = _dt_Shelf.Rows[0]["TOT_REMAIN"].ToString();

                    InitForm();
                    Init_Dictionary_Location();
                    _bLoad = false;
                }


                if (_bStatus == false)
                {
                    _icount++;
                    if (_icount > 10)
                    {
                        _bStatus = true;
                        _icount = 0;

                        if (_strScan != "")
                        {
                            Getbox(_strScan).setBlink(false);
                            SetBoxDafault(_strScan);
                            BoxHead_MouseLeftButtonUp(Getbox(_strScan), null);
                        }
                    }
                    
                }
            }
            catch (Exception)
            {
            }
            
          //  if (_isPause==false) txtBarcode.Focus();
        }
      
        private void lblDate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FORM.Var._Show_back_icon)
                    ComVar.Var.callForm = "Exit";
            }
            catch (Exception)
            { }

        }

        private void cbo_item_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Clear_seach();
                var result = (from DataRow dRow in _dt_search.Rows
                              where (string)dRow["ITEM"] == cbo_item.SelectedValue.ToString()
                              //  && dRow["cs_size"].ToString().StartsWith(arg_size))
                              orderby dRow["ITEM"]
                              select new { locate = (string)dRow["LOCATE_CD"] }).Distinct();

                foreach (var element in result)
                {
                    // newrow = temp_datatable.NewRow();
                    _ls_search.Add(element.locate);
                    Getbox(element.locate).setBlink(true);
                   // SetColorBox(element.locate, null, _M_Bcolor, _M_Bcolor, _M_Bcolor, _M_Fcolor, _M_Fcolor, "0");
                    //  temp_datatable.Rows.Add(newrow);
                }
            }
            catch (Exception)
            { }
            finally
            {
                axSpreadHead.Visible = false;
                axSpreadTail.Visible = false;
            }
        }


        private void cbo_model_SelectionChangeCommitted(object sender, EventArgs e)
        {
           // load_cbo_moldcd(_dt_mold, cbo_style.SelectedValue.ToString());
        }

       

        private void cbo_size_SelectionChangeCommitted(object sender, EventArgs e)
        {
           // load_cbo_seq(_dt_mold, cbo_style.SelectedValue.ToString(), cbo_item.SelectedValue.ToString(), cbo_size.SelectedValue.ToString());
        }

        private void FORM_MOLD_LOCATION_VisibleChanged(object sender, EventArgs e)
        {
           // if (this.Visible) InitForm();
            if (this.Visible)
            {
                set_Text_En_Vi();
                timer1.Start();
                cmd_back.Visible = FORM.Var._Show_back_icon;
                if (ComVar.Var._strValue1 == "014" && FORM.Var._Show_back_icon == false)
                {
                    timer2.Start();
                    
                }
            }
            else
            {
                timer1.Stop();
                if (_strScan != "")
                {
                    Getbox(_strScan).setBlink(false);
                    //SetBoxDafault(_strScan);
                   // BoxHead_MouseLeftButtonUp(Getbox(_strScan), null);
                }
                Clear_seach();
                pn_search_Click(pn_search, null);
                _bStatus = true;
            }
        }


        private void axSpreadHead_ClickEvent(object sender, AxFPUSpreadADO._DSpreadEvents_ClickEvent e)
        {
            try
            {
                if (_preHeadRow > 3)
                {
                    axSpreadHead.Col = -1;
                    axSpreadHead.Row = _preHeadRow;
                    axSpreadHead.BackColor = Color.White;
                    axSpreadHead.ForeColor = Color.Black;
                }
                if (e.row > 3)
                {
                    axSpreadHead.Col = -1;
                    axSpreadHead.Row = e.row;
                    axSpreadHead.BackColor = Color.FromArgb(51, 102, 255);
                    axSpreadHead.ForeColor = Color.White;
                    _preHeadRow = e.row;
                    Set_Data_Grid_Tail(SEL_DETAIL_CELL_TAIL(Get_data_grid(1, 1).Replace("Shelf ", ""), Get_data_grid(3, e.row), Get_data_grid(5, e.row), Get_data_grid(6, e.row)));

                }
            }
            catch (Exception)
            { }
        }

        private void txt_obsnu_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    _dt_search = SEL_SEARCH_BY_PO(txt_obsnu.Text.Trim(), cbo_item.SelectedText);
                    load_cbo_item(_dt_search);
                    cbo_item_SelectionChangeCommitted(cbo_item, null);
                    txt_obsnu.SelectAll();
                }
            }
            catch (Exception)
            { }
            finally
            {
                axSpreadHead.Visible = false;
                axSpreadTail.Visible = false;
            }
            
        }

        private void txt_obsnu_Click(object sender, EventArgs e)
        {
            string progFiles = @"C:\Program Files\Common Files\Microsoft Shared\ink";

            string onScreenKeyboardPath = System.IO.Path.Combine(progFiles, "TabTip.exe");

            //onScreenKeyboardProc = 
            System.Diagnostics.Process.Start(onScreenKeyboardPath);

            //key = !key;
            //if (key)
            //{
            //    txt_item_location.Text = "";
            //    string progFiles = @"C:\Program Files\Common Files\Microsoft Shared\ink";

            //    string onScreenKeyboardPath = System.IO.Path.Combine(progFiles, "TabTip.exe");

            //    //onScreenKeyboardProc = 
            //    System.Diagnostics.Process.Start(onScreenKeyboardPath);
            //}
            //else
            //{
            //    System.Diagnostics.Process[] oskProcessArray = System.Diagnostics.Process.GetProcessesByName("TabTip");

            //    foreach (System.Diagnostics.Process onscreenProcess in oskProcessArray)
            //    {

            //        onscreenProcess.Kill();

            //    }
            //}
            txt_obsnu.SelectAll();
        }

        private void pn_search_Click(object sender, EventArgs e)
        {
            axSpreadTail.Visible = false;
            axSpreadHead.Visible = false;
            txt_obsnu.Text = "";
            load_cbo_item(null);
            Clear_seach();
            SetBoxDafault(_str_Pre_Box);

        }

#endregion Event


        private void button1_Click(object sender, EventArgs e)
        {
            pn_body.Controls.Clear();
            Test_Location_IP_Mold_Load(null, null);
        }
        int _il = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            
            ElementHost element = (ElementHost)pn_body.Controls[_il];

            LocationBox.BoxSmall1 box = (LocationBox.BoxSmall1)element.Child;
            box.BoxColorSearch();

            if (_il > 0)
            {
                ElementHost element2 = (ElementHost)pn_body.Controls[_il - 1];

                LocationBox.BoxSmall1 box2 = (LocationBox.BoxSmall1)element2.Child;
                box2.BoxColorDefault();
            }
            _il++;
        }

        private void pn_loc_wh_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                _str_text = File.ReadAllText(@"D:\ScanUCCKhoNosH\LOG\locate.txt");
                if (_str_text.Split('\n')[0] != "" && _bStatus)
                {
                    FORM.Var._Form_status = true;
                    this.Show();
                    FORM.Var._Form_status = false;
                    _bStatus = false;
                    File.WriteAllText(@"D:\ScanUCCKhoNosH\LOG\locate.txt", "");

                    _strScan = _str_text.Split('\n')[0].Trim();
                    Getbox(_strScan).setBlink(true);
                    

                    //  BoxHead_MouseLeftButtonUp(Getbox(_str_text.Split('\n')[0].Trim()), e);

                }
            }
            catch 
            {
                //MessageBox.Show(ex.ToString());
            }           
        }

        private void cmd_back_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
            //Application.Exit();
        }

        private void axfpSpread2_BeforeEditMode(object sender, AxFPUSpreadADO._DSpreadEvents_BeforeEditModeEvent e)
        {
            e.cancel = true;
        }

        
    }
}
