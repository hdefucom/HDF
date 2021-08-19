using DCSoft.Script;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass382 : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object Value)
		{
			XVBAOptions xVBAOptions = Value as XVBAOptions;
			xVBAOptions = ((xVBAOptions != null) ? xVBAOptions.Clone() : new XVBAOptions());
			IWindowsFormsEditorService windowsFormsEditorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
			using (dlgScriptOptions dlgScriptOptions = new dlgScriptOptions())
			{
				dlgScriptOptions.OptionsInstance = xVBAOptions;
				if (windowsFormsEditorService.ShowDialog(dlgScriptOptions) == DialogResult.OK)
				{
					return xVBAOptions;
				}
			}
			return Value;
		}
	}
}
