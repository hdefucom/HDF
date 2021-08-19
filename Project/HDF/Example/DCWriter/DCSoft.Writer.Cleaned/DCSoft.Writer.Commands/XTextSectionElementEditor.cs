using DCSoft.Writer.Controls;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       文档节元素编辑器
	///       </summary>
	[ComVisible(false)]
	public class XTextSectionElementEditor : ElementPropertiesEditor
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
		///       编辑元素
		///       </summary>
		/// <param name="args">
		/// </param>
		/// <returns>
		/// </returns>
		public override bool Edit(ElementPropertiesEditEventArgs args)
		{
			using (dlgSectionElementEditor dlgSectionElementEditor = new dlgSectionElementEditor())
			{
				dlgSectionElementEditor.SourceEventArgs = args;
				if (WriterControl.UIShowDialog(args.WriterControl, dlgSectionElementEditor, args.Element) == DialogResult.OK)
				{
					return true;
				}
				return false;
			}
		}
	}
}
