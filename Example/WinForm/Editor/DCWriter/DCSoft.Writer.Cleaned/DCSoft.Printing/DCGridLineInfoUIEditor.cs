using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Printing
{
	[ComVisible(false)]
	
	public class DCGridLineInfoUIEditor : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			using (dlgDCGridLineInfo dlgDCGridLineInfo = new dlgDCGridLineInfo())
			{
				dlgDCGridLineInfo.InputGridLineInfo = (value as DCGridLineInfo);
				if (dlgDCGridLineInfo.ShowDialog() == DialogResult.OK)
				{
					return dlgDCGridLineInfo.InputGridLineInfo.method_5();
				}
			}
			return value;
		}
	}
}
