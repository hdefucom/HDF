using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>WriterReportErrorEventArgs 的COM接口</summary>
	[Guid("3E829F65-FB88-4B9F-933E-BDF855B4097A")]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public interface IWriterReportErrorEventArgs
	{
		/// <summary>属性Details</summary>
		[DispId(6)]
		string Details
		{
			get;
			set;
		}

		/// <summary>属性Document</summary>
		[DispId(3)]
		XTextDocument Document
		{
			get;
		}

		/// <summary>属性Element</summary>
		[DispId(4)]
		XTextElement Element
		{
			get;
		}

		/// <summary>属性Handled</summary>
		[DispId(5)]
		bool Handled
		{
			get;
			set;
		}

		/// <summary>属性Message</summary>
		[DispId(7)]
		string Message
		{
			get;
			set;
		}
	}
}
