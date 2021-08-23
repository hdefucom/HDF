using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using YidanSoft.Library.EmrEditor.Src.Document;
using YidanSoft.Library.EmrEditor.Src.Document.Table;
using YidanSoft.Library.EmrEditor.Src.Document.PropertyElement;
using System.ComponentModel;
using System.Reflection;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    class DropDownTableSumTypeEditor<T> : System.Drawing.Design.UITypeEditor
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
                var dict = value.GetType().GetFields(BindingFlags.Static | BindingFlags.Public).Select(f =>
                 {
                     T val = (T)f.GetValue(null);
                     var des = (DescriptionAttribute)Attribute.GetCustomAttribute(f, typeof(DescriptionAttribute), false);
                     return new KeyValuePair<string, T>(des.Description, val);
                 });

                DropDownTableSumTypeControl<T> Control = new DropDownTableSumTypeControl<T>(edSvc, value, dict);
                edSvc.DropDownControl(Control);
                return Control.Value;


            }
            return value;
        }
    }

}
