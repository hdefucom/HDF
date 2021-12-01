using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass352 : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object Value)
		{
			ValueValidateStyle valueValidateStyle = Value as ValueValidateStyle;
			valueValidateStyle = ((valueValidateStyle != null) ? valueValidateStyle.method_4() : new ValueValidateStyle());
			using (dlgValueValidateStyleEditor dlgValueValidateStyleEditor = new dlgValueValidateStyleEditor())
			{
				dlgValueValidateStyleEditor.ValidateStyle = valueValidateStyle;
				if (dlgValueValidateStyleEditor.ShowDialog() == DialogResult.OK)
				{
					return dlgValueValidateStyleEditor.ValidateStyle;
				}
			}
			return Value;
		}
	}
}
