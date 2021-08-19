using DCSoft.Writer.Controls;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       文本标签元素编辑器
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class XTextButtonElementEditor : ElementPropertiesEditor
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
			using (dlgButtonElement dlgButtonElement = new dlgButtonElement())
			{
				dlgButtonElement.SourceEventArgs = args;
				if (WriterControl.UIShowDialog(args.WriterControl, dlgButtonElement, args.Element) == DialogResult.OK)
				{
					return true;
				}
				return false;
			}
		}
	}
}