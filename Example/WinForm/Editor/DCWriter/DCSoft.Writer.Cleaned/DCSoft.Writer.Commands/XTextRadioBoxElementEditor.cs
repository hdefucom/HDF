using DCSoft.Writer.Controls;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       复选框元素编辑器
	///       </summary>
	[ComVisible(false)]
	public class XTextRadioBoxElementEditor : ElementPropertiesEditor
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
			using (dlgCheckBoxElementEditor dlgCheckBoxElementEditor = new dlgCheckBoxElementEditor())
			{
				dlgCheckBoxElementEditor.SourceEventArgs = args;
				if (WriterControl.UIShowDialog(args.WriterControl, dlgCheckBoxElementEditor, args.Element) == DialogResult.OK)
				{
					return true;
				}
			}
			return false;
		}
	}
}
