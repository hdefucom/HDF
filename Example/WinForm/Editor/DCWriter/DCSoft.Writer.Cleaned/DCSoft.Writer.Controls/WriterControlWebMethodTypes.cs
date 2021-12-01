using DCSoft.Common;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       编辑器事件类型
	///       </summary>
	[ComVisible(true)]
	[DCPublishAPI]
	[Guid("5699CA97-5A44-410E-BFC1-B736EA8F067E")]
	[Flags]
	public enum WriterControlWebMethodTypes
	{
		/// <summary>
		///       无效状态
		///       </summary>
		Invalidate = -1,
		/// <summary>
		///       没有任何事件 
		///       </summary>
		None = 0x0,
		QueryAssistInputItems = 0x1,
		ReportError = 0x2,
		SaveFileContent = 0x4,
		ReadFileContent = 0x8,
		UIStartEditContent = 0x10,
		QueryListItems = 0x20,
		GetKBLibrary = 0x40,
		ButtonClick = 0x80,
		DocumentPrinted = 0x100,
		SaveFileContentForAutoSave = 0x200,
		BeforePlayMedia = 0x400,
		QueryListItemsWithDocumentParameter = 0x800,
		/// <summary>
		///       所有的事件
		///       </summary>
		All = 0xFFFFFF
	}
}
