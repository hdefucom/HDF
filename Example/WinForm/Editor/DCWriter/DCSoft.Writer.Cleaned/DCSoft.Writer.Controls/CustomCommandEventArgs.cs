using DCSoft.Common;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       自定义命令事件参数
	///       </summary>
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("237AFCB8-41E9-4277-90F2-171069A3E971", "7F39B85E-DD00-43E7-8A0D-4E81D7422599")]
	[ComDefaultInterface(typeof(ICustomCommandEventArgs))]
	[Guid("237AFCB8-41E9-4277-90F2-171069A3E971")]
	[ComVisible(true)]
	[DCPublishAPI]
	[DocumentComment]
	public class CustomCommandEventArgs : ICustomCommandEventArgs
	{
		internal const string CLASSID = "237AFCB8-41E9-4277-90F2-171069A3E971";

		internal const string CLASSID_Interface = "7F39B85E-DD00-43E7-8A0D-4E81D7422599";

		private string _CommandName = null;

		/// <summary>
		///       命令名称
		///       </summary>
		[DCPublishAPI]
		public string CommandName => _CommandName;

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="cmd">命令名称</param>
		[DCInternal]
		public CustomCommandEventArgs(string string_0)
		{
			_CommandName = string_0;
		}
	}
}
