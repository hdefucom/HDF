using DCSoft.Writer.Controls;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       水平线元素属性编辑器
	///       </summary>
	[ComVisible(false)]
	public class XTextHorizontalLineElementEditor : ElementPropertiesEditor
	{
		/// <summary>
		///       支持的方法
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
		///       编辑元素
		///       </summary>
		/// <param name="args">
		/// </param>
		/// <returns>
		/// </returns>
		public override bool Edit(ElementPropertiesEditEventArgs args)
		{
			using (dlgHorizontalLine dlgHorizontalLine = new dlgHorizontalLine())
			{
				dlgHorizontalLine.SourceEventArgs = args;
				if (WriterControl.UIShowDialog(args.WriterControl, dlgHorizontalLine, args.Element) == DialogResult.OK)
				{
					return true;
				}
			}
			return false;
		}
	}
}
