using DCSoft.Writer.Controls;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	[ComVisible(false)]
	public class XTextRulerElementEditor : ElementPropertiesEditor
	{
		/// <summary>
		///       判断是否支持方法
		///       </summary>
		/// <param name="method">
		/// </param>
		/// <returns>
		/// </returns>
		public override bool IsSupportMethod(ElementPropertiesEditMethod method)
		{
			return true;
		}

		/// <summary>
		///       编辑操作
		///       </summary>
		/// <param name="args">
		/// </param>
		/// <returns>
		/// </returns>
		public override bool Edit(ElementPropertiesEditEventArgs args)
		{
			using (dlgRulerElement dlgRulerElement = new dlgRulerElement())
			{
				dlgRulerElement.SourceEventArgs = args;
				if (WriterControl.UIShowDialog(args.WriterControl, dlgRulerElement, args.Element) == DialogResult.OK)
				{
					return true;
				}
				return false;
			}
		}
	}
}
