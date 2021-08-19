using DCSoft.Common;
using System.Runtime.InteropServices;
using System.Web.UI.Design;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       Web控件设计器,本类型是DCWriter内部使用。
	///       </summary>
	[DocumentComment(0)]
	[ComVisible(false)]
	public class WebTemperatureControlDesigner : ControlDesigner
	{
		/// <summary>
		///       允许修改大小
		///       </summary>
		public override bool AllowResize => true;
	}
}
