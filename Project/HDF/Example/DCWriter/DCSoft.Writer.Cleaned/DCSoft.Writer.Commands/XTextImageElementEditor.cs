using DCSoft.Writer.Controls;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       图片内容编辑器
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class XTextImageElementEditor : ElementPropertiesEditor
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
			using (dlgImageElementEditor dlgImageElementEditor = new dlgImageElementEditor())
			{
				dlgImageElementEditor.SourceEventArgs = args;
				if (WriterControl.UIShowDialog(args.WriterControl, dlgImageElementEditor, args.Element) == DialogResult.OK)
				{
					return true;
				}
				return false;
			}
		}
	}
}
