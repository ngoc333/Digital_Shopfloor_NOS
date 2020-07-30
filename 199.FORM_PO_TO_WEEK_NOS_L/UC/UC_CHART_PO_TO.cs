using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;

namespace FORM.UC
{
    public partial class UC_CHART_PO_TO : UserControl
    {
        public UC_CHART_PO_TO(string title)
        {
            InitializeComponent();
            Chart1.Titles[0].Text = title;
        }

        public void BindingData(DataTable arg_dt, string title)
        {
            try
            {
                Chart1.Series.Clear();
                Series series2 = new Series("POD", ViewType.Bar);

                for (int i = 0; i < arg_dt.Rows.Count; i++)
                {
                    series2.Points.Add(new SeriesPoint(arg_dt.Rows[i]["DIV"].ToString(), arg_dt.Rows[i]["QTY"] == null || arg_dt.Rows[i]["QTY"].ToString() == "" ? 0 : arg_dt.Rows[i]["QTY"]));

                    series2.Points[i].Color = Color.FromName(arg_dt.Rows[i]["STATUS"].ToString());

                }

                Chart1.SeriesSerializable = new DevExpress.XtraCharts.Series[] { series2 };

                series2.Label.Font = new Font("Calibri", 12.25F, System.Drawing.FontStyle.Regular);
                series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

                //Chart1.DataSource = dt;
                //Chart1.Series[0].ArgumentDataMember = "DIV";
                //Chart1.Series[0].ValueDataMembers.AddRange(new string[] { "QTY" });
                

                //Chart1.Series[0].Points[0].Color = Color.Green;
                //Chart1.Series[0].Points[1].Color = Color.FromName(dt.Rows[1]["STATUS"].ToString());
                //Chart1.Series[0].Points[2].Color = Color.FromName(dt.Rows[2]["STATUS"].ToString());
                //((BarSeriesView)Chart1.Series[0].View).FillStyle.FillMode = FillMode.Solid;
                //((BarSeriesView)Chart1.Series[0].View).Color = Color.Green;
                //Chart1.Series[1].ArgumentDataMember = "DIV";
                //Chart1.Series[1].ValueDataMembers.AddRange(new string[] { title + "_PO" });

                //if (title.Equals("TOTAL"))
                //{
                //    Chart1.BackColor = Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(213)))), ((int)(((byte)(181)))));
                //    Chart1.Legend.BackColor = Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(213)))), ((int)(((byte)(181)))));
                //    ((XYDiagram)Chart1.Diagram).DefaultPane.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(213)))), ((int)(((byte)(181)))));
                //}
                
            }
            catch { }
        }

        
    }
}
