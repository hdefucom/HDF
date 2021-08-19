using DCSoft.Writer.Controls;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       会计数字编辑器
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class XTextAccountingNumberElementEditor : ElementPropertiesEditor
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
		///       编辑
		///       </summary>
		/// <param name="args">
		/// </param>
		/// <returns>
		/// </returns>
		public override bool Edit(ElementPropertiesEditEventArgs args)
		{
			using (dlgAccountintNumber dlgAccountintNumber = new dlgAccountintNumber())
			{
				dlgAccountintNumber.SourceEventArgs = args;
				if (WriterControl.UIShowDialog(args.WriterControl, dlgAccountintNumber, args.Element) == DialogResult.OK)
				{
					return true;
				}
			}
			return false;
		}
	}
}
