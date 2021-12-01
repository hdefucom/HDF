using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.Design;
using System.Drawing.Design;
using System.Drawing;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public class BoolEditor : System.Drawing.Design.UITypeEditor
    {
        public BoolEditor()
        {
        }

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
                BoolControl boolControl = new BoolControl(edSvc, value);
                edSvc.DropDownControl(boolControl);
                return boolControl.Value;
            }
            return value;
        }
    }

}
