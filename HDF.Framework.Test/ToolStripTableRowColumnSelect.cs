using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Gocent.Library.Editor.Controls.Extend;

[DefaultEvent("Selected")]
[ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
public class ToolStripTableRowColumnSelect : ToolStripControlHost
{

    public TableRowColumnSelect TableRowColumnSelectControl => this.Control as TableRowColumnSelect;



    public event EventHandler PreviewSelect;
    public new event EventHandler<TableRowColumnSelectedEventArgs> Selected;


    public int SelectRow => TableRowColumnSelectControl.SelectRow;
    public int SelectColumn => TableRowColumnSelectControl.SelectColumn;





    public ToolStripTableRowColumnSelect() : base(new TableRowColumnSelect())
    {
        this.Padding = Padding.Empty;
    }

    protected override void OnSubscribeControlEvents(Control c)
    {
        base.OnSubscribeControlEvents(c);

        var control = (TableRowColumnSelect)c;
        control.Selected += OnSelected;
        control.PreviewSelect += OnPreviewSelect;
    }

    protected override void OnUnsubscribeControlEvents(Control c)
    {
        base.OnUnsubscribeControlEvents(c);


        var control = (TableRowColumnSelect)c;
        control.Selected -= OnSelected;
        control.PreviewSelect -= OnPreviewSelect;
    }



    protected virtual void OnSelected(object sender, TableRowColumnSelectedEventArgs e)
    {
        if (this.OwnerItem is ToolStripDropDownItem dropdown)
            dropdown.HideDropDown();

        Selected?.Invoke(this, e);
    }


    protected virtual void OnPreviewSelect(object sender, EventArgs e)
    {
        PreviewSelect?.Invoke(this, e);
    }







}
