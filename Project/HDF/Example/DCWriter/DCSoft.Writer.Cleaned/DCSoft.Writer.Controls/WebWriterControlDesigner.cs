using DCSoft.Common;
using System.Runtime.InteropServices;
using System.Web.UI.Design;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       Web控件设计器,本类型是DCWriter内部使用。
	///       </summary>
	[ComVisible(false)]
	[DocumentComment(0)]
	public class WebWriterControlDesigner : ControlDesigner
	{
		/// <summary>
		///       允许设置控件大小
		///       </summary>
		public override bool AllowResize => true;
	}
}
