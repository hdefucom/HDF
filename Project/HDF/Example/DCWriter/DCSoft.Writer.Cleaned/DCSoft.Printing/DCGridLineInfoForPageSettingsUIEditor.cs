using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Printing
{
	[ComVisible(false)]
	public class DCGridLineInfoForPageSettingsUIEditor : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			using (dlgDCGridLineInfoForPageSettings dlgDCGridLineInfoForPageSettings = new dlgDCGridLineInfoForPageSettings())
			{
				dlgDCGridLineInfoForPageSettings.InputGridLineInfo = (value as DCGridLineInfo);
				if (dlgDCGridLineInfoForPageSettings.ShowDialog() == DialogResult.OK)
				{
					return dlgDCGridLineInfoForPageSettings.InputGridLineInfo.method_5();
				}
			}
			return value;
		}
	}
}
