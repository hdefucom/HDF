using DCSoft.Common;
using DCSoft.Drawing;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Printing
{
	[DCInternal]
	[ComVisible(false)]
	public class WatermarkInfoUITypeEditor : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			using (dlgWatermarkInfo dlgWatermarkInfo = new dlgWatermarkInfo())
			{
				dlgWatermarkInfo.InputInfo = (value as WatermarkInfo);
				if (dlgWatermarkInfo.InputInfo == null)
				{
					dlgWatermarkInfo.InputInfo = new WatermarkInfo();
				}
				else
				{
					dlgWatermarkInfo.InputInfo = dlgWatermarkInfo.InputInfo.Clone();
				}
				if (dlgWatermarkInfo.ShowDialog() == DialogResult.OK)
				{
					return dlgWatermarkInfo.InputInfo;
				}
			}
			return value;
		}
	}
}
