using DCSoft.Printing;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass155 : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object Value)
		{
			using (dlgPageSetup dlgPageSetup = new dlgPageSetup())
			{
				XPageSettings xPageSettings = Value as XPageSettings;
				if (xPageSettings == null)
				{
					dlgPageSetup.PageSettings = new XPageSettings();
				}
				else
				{
					dlgPageSetup.PageSettings = xPageSettings.Clone();
				}
				if (dlgPageSetup.ShowDialog() == DialogResult.OK)
				{
					return dlgPageSetup.PageSettings;
				}
			}
			return Value;
		}
	}
}
