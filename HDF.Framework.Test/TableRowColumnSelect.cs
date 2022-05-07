using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gocent.Library.Editor.Controls.Extend;

public class TableRowColumnSelect : Control
{

    const int CellSize = 15;
    const int CellSpacing = 4;

    int StartX;
    int StartY;

    int Row;
    int Column;

    public int SelectRow { get; private set; }
    public int SelectColumn { get; private set; }



    //public bool ShowTitle { get; set; } = true;


    //public int TitleHeight { get; set; }=










    public event EventHandler PreviewSelect;
    public event EventHandler<TableRowColumnSelectedEventArgs> Selected;









    public TableRowColumnSelect()
    {
        this.DoubleBuffered = true;
    }

    protected override Size DefaultSize => new Size(200, 160);

    protected override void OnSizeChanged(EventArgs e)
    {
        base.OnSizeChanged(e);
        RefreshRowColumnCount();
    }

    protected override void OnVisibleChanged(EventArgs e)
    {
        base.OnVisibleChanged(e);
        RefreshRowColumnCount();
    }


    private void RefreshRowColumnCount()
    {
        var cs = CellSize + CellSpacing;

        var w = this.Width - CellSpacing;
        var h = this.Height - CellSpacing;

        Column = w / cs;
        Row = h / cs;

        if (Column < 1 || Row < 1)
            return;


        var ws = w % cs;
        var hs = h % cs;


        StartX = ws / 2 + CellSpacing;
        StartY = hs / 2 + CellSpacing;
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);


        var realr = 0;
        var realc = 0;


        if (e.X <= StartX || e.Y <= StartY)
            goto Refresh;


        var x = e.X - this.StartX;
        var y = e.Y - this.StartX;


        var cs = CellSize + CellSpacing;

        realc = x / cs;
        realr = y / cs;

        var sw = x % cs;
        var sh = y % cs;

        if (sw > CellSpacing)
            realc++;
        if (sh > CellSpacing)
            realr++;

        if (realc > Column)
            realc = Column;
        if (realr > Row)
            realr = Row;

        Refresh:

        if (realr != SelectRow || realc != SelectColumn)
        {
            SelectRow = realr;
            SelectColumn = realc;
            this.Invalidate();
            PreviewSelect?.Invoke(this, EventArgs.Empty);
        }
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);

        this.SelectRow = 0;
        this.SelectColumn = 0;
        this.Invalidate();
        PreviewSelect?.Invoke(this, EventArgs.Empty);
    }


    protected override void OnMouseClick(MouseEventArgs e)
    {
        if (this.SelectRow < 1 || this.SelectColumn < 1)
            return;

        Selected?.Invoke(this, new TableRowColumnSelectedEventArgs(this.SelectRow, this.SelectColumn));

        this.SelectRow = 0;
        this.SelectColumn = 0;


    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var cs = CellSize + CellSpacing;

        for (int i = 0; i < Row; i++)
        {
            for (int j = 0; j < Column; j++)
            {
                if (!this.DesignMode && i < SelectRow && j < SelectColumn)
                {
                    e.Graphics.DrawRectangle(Pens.Orange, StartX + j * cs, StartY + i * cs, CellSize, CellSize);
                    e.Graphics.DrawRectangle(Pens.Red, StartX + j * cs - 1, StartY + i * cs - 1, CellSize + 2, CellSize + 2);
                }
                else
                    e.Graphics.DrawRectangle(Pens.Black, StartX + j * cs, StartY + i * cs, CellSize, CellSize);
            }
        }

    }



}


public class TableRowColumnSelectedEventArgs : EventArgs
{
    public int Row { get; }
    public int Column { get; }

    public TableRowColumnSelectedEventArgs(int row, int column)
    {
        this.Row = row;
        this.Column = column;
    }
}
