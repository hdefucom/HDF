using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>AppErrorInfo 的COM接口</summary>
	[Guid("A9888526-AAAD-417A-A5F5-91DC0518415B")]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	public interface IAppErrorInfo
	{
		/// <summary>属性EventName</summary>
		[DispId(2)]
		string EventName
		{
			get;
		}

		/// <summary>属性Message</summary>
		[DispId(3)]
		string Message
		{
			get;
		}

		/// <summary>属性SourceElement</summary>
		[DispId(4)]
		XTextElement SourceElement
		{
			get;
		}

		/// <summary>属性SourceException</summary>
		[DispId(5)]
		Exception SourceException
		{
			get;
		}
	}
}
