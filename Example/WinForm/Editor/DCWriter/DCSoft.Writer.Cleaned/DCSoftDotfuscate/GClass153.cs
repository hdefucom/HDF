using DCSoft.FriedmanCurveChart;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass153 : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			using (FCdlgTickList fCdlgTickList = new FCdlgTickList())
			{
				if (value is FCTickInfoList)
				{
					fCdlgTickList.InputTicks = ((FCTickInfoList)value).Clone();
				}
				if (fCdlgTickList.ShowDialog() == DialogResult.OK)
				{
					return fCdlgTickList.InputTicks;
				}
			}
			return value;
		}
	}
}
