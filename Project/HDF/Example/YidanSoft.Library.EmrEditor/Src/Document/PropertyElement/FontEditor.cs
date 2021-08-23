using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using YidanSoft.Library.EmrEditor.Src.Document.PorpertyElement;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    class FontEditor : System.Drawing.Design.UITypeEditor
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
                FontControl fontControl = new FontControl(edSvc, value);
                edSvc.DropDownControl(fontControl);
                return fontControl.Value;
            }
            return value;
        }
    }

}
