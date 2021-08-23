using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms.Design;


namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public class SupSubEditor : System.Drawing.Design.UITypeEditor
    {

        public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        // Displays the UI for value selection.
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (edSvc != null)
            {
                SupSubControl supsubControl = new SupSubControl(edSvc, value);
                edSvc.DropDownControl(supsubControl);
                return supsubControl.Value;
            }
            return value;
        }
    }

}
