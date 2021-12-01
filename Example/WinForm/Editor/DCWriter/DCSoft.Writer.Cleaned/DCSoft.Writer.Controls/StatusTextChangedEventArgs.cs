using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       状态栏文本发生改变事件参数
	///       </summary>
	[ComVisible(true)]
	[ComClass("8B2D88C4-1D59-4E6A-845C-E59F8E76A817", "AEF26CE0-0989-4320-A3F0-4FD86FBB179B")]
	[ComDefaultInterface(typeof(IStatusTextChangedEventArgs))]
	[Guid("8B2D88C4-1D59-4E6A-845C-E59F8E76A817")]
	[DCPublishAPI]
	[ClassInterface(ClassInterfaceType.None)]
	public class StatusTextChangedEventArgs : EventArgs, IStatusTextChangedEventArgs
	{
		internal const string CLASSID = "8B2D88C4-1D59-4E6A-845C-E59F8E76A817";

		internal const string CLASSID_Interface = "AEF26CE0-0989-4320-A3F0-4FD86FBB179B";

		private WriterControl _WriterControl = null;

		private string _StatusText = null;

		/// <summary>
		///       编辑器控件对象
		///       </summary>
		[DCPublishAPI]
		public WriterControl WriterControl => _WriterControl;

		/// <summary>
		///       状态栏文本
		///       </summary>
		[DCPublishAPI]
		public string StatusText => _StatusText;

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">
		/// </param>
		/// <param name="statusText">
		/// </param>
		[DCInternal]
		public StatusTextChangedEventArgs(WriterControl writerControl_0, string statusText)
		{
			_WriterControl = writerControl_0;
			_StatusText = statusText;
		}
	}
}
