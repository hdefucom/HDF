using DCSoft.Writer.Controls;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       文件块元素编辑对象
	///       </summary>
	[ComVisible(false)]
	public class XTextFileBlockElementEditor : ElementPropertiesEditor
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
			using (dlgXTextFileBlockElement dlgXTextFileBlockElement = new dlgXTextFileBlockElement())
			{
				dlgXTextFileBlockElement.SourceEventArgs = args;
				if (WriterControl.UIShowDialog(args.WriterControl, dlgXTextFileBlockElement, args.Element) == DialogResult.OK)
				{
					return true;
				}
				return false;
			}
		}
	}
}
