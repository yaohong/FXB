using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace FXB.MyControl
{
    class MyDataGridView : DataGridView
    {
        SolidBrush solidBrush;
        public MyDataGridView()
        {
            //this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            //UpdateStyles(); 
            this.SetStyle(ControlStyles.UserPaint |ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);

            solidBrush = new SolidBrush(this.RowHeadersDefaultCellStyle.ForeColor);

            //this.RowsDefaultCellStyle.BackColor = Color.Bisque;
            //this.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, solidBrush, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 5);
            base.OnRowPostPaint(e);
        }
    }
}
