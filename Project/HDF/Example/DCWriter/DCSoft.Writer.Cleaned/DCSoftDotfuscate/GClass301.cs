using DCSoft.WinForms.Design;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass301 : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			using (dlgFillStyleConfigDesigner dlgFillStyleConfigDesigner = new dlgFillStyleConfigDesigner())
			{
				if (value is GClass441)
				{
					dlgFillStyleConfigDesigner.InputListItems = ((GClass441)value).method_2();
				}
				else if (value is string)
				{
					GClass441 gClass = new GClass441();
					gClass.method_1((string)value);
					dlgFillStyleConfigDesigner.InputListItems = gClass;
				}
				if (dlgFillStyleConfigDesigner.ShowDialog() == DialogResult.OK)
				{
					if (context.PropertyDescriptor.PropertyType.Equals(typeof(string)))
					{
						return dlgFillStyleConfigDesigner.InputListItems.ToString();
					}
					return dlgFillStyleConfigDesigner.InputListItems;
				}
			}
			return value;
		}
	}
}
