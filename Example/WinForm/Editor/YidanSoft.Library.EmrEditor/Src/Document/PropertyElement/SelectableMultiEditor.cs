using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.Windows.Forms;
using YidanSoft.Library.EmrEditor.Src.Document.PropertyElement;

namespace YidanSoft.Library.EmrEditor.Src.Document

{
    class SelectableMultiEditor : System.Drawing.Design.UITypeEditor
    {

        public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        // Displays the UI for value selection.
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (edSvc != null)
            {
                //DateTimeFormatControl supsubControl = new DateTimeFormatControl(edSvc, value);
                //edSvc.DropDownControl(supsubControl);
                ItemInputForm frm = new ItemInputForm(true, value);
                edSvc.ShowDialog(frm);
                return frm.Value;
            }
            return value;
        }
    }

}
