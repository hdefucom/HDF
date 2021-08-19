using DCSoft.TemperatureChart;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass149 : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			using (dlgTickList dlgTickList = new dlgTickList())
			{
				if (value is TickInfoList)
				{
					dlgTickList.InputTicks = ((TickInfoList)value).Clone();
				}
				if (dlgTickList.ShowDialog() == DialogResult.OK)
				{
					return dlgTickList.InputTicks;
				}
			}
			return value;
		}
	}
}
