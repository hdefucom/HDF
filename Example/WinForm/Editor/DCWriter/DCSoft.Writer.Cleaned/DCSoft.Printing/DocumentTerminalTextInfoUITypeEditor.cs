using DCSoft.Common;
using DCSoft.Drawing;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Printing
{
	[ComVisible(false)]
	
	public class DocumentTerminalTextInfoUITypeEditor : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			using (dlgTerminalTextInfo dlgTerminalTextInfo = new dlgTerminalTextInfo())
			{
				dlgTerminalTextInfo.InputTextInfo = (value as DocumentTerminalTextInfo);
				if (dlgTerminalTextInfo.InputTextInfo == null)
				{
					dlgTerminalTextInfo.InputTextInfo = new DocumentTerminalTextInfo();
				}
				else
				{
					dlgTerminalTextInfo.InputTextInfo = dlgTerminalTextInfo.InputTextInfo.method_7();
				}
				if (dlgTerminalTextInfo.ShowDialog() == DialogResult.OK)
				{
					return dlgTerminalTextInfo.InputTextInfo;
				}
			}
			return value;
		}
	}
}
