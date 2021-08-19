using DCSoft.Drawing;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass439 : UITypeEditor
	{
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object Value)
		{
			using (FontDialog fontDialog = new FontDialog())
			{
				fontDialog.ShowApply = false;
				fontDialog.ShowColor = false;
				if (Value != null)
				{
					if (Value is Font)
					{
						fontDialog.Font = (Font)Value;
					}
					else if (Value is XFontValue)
					{
						fontDialog.Font = ((XFontValue)Value).Value;
					}
				}
				if (fontDialog.ShowDialog() == DialogResult.OK)
				{
					Type propertyType = context.PropertyDescriptor.PropertyType;
					Value = (propertyType.Equals(typeof(Font)) ? fontDialog.Font : ((!propertyType.Equals(typeof(XFontValue))) ? ((object)fontDialog.Font) : ((object)new XFontValue(fontDialog.Font))));
				}
			}
			return Value;
		}

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}
	}
}
