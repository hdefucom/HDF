using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.WinForms.Design
{
	[ComVisible(false)]
	public class MultiLineStringUITypeEditor : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			using (dlgString dlgString = new dlgString())
			{
				dlgString.InputText = Convert.ToString(value);
				if (dlgString.ShowDialog() == DialogResult.OK)
				{
					return dlgString.InputText;
				}
			}
			return value;
		}
	}
}
