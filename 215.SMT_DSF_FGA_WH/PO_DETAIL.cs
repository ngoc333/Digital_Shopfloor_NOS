using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FORM
{
    public partial class PO_DETAIL : Form
    {
        public PO_DETAIL()
        {
            InitializeComponent();
        }
        public void BindingData(DataTable dt, string STRPO, string STRITEM)
        {
            gridControl.DataSource = dt;
            lblPO.Text = STRPO;
            lblItem.Text = STRITEM;
            for (int i = 0; i < gridView.Columns.Count; i++)
            {
                gridView.Columns[i].FieldName = gridView.Columns[i].FieldName.Replace("C_", "");
                gridView.Columns[i].Caption = gridView.Columns[i].Caption.Replace("C_", "");
                if (i > 1)
                {
                    gridView.Columns[i].Width = 60;
                    gridView.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView.Columns[i].DisplayFormat.FormatString = "#,#";
                }
                else
                    gridView.Columns[i].Width = 120;

            }
            gridView.Columns[2].Width = 80;
            gridView.OptionsView.ColumnAutoWidth = false;
            gridView.Columns[0].Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle == gridView.RowCount - 1 )
            {
                e.Appearance.ForeColor = Color.Red;
            }
            if (e.RowHandle == 0)
            {
                e.Appearance.ForeColor = Color.Blue;
            }
        }
    }
}
