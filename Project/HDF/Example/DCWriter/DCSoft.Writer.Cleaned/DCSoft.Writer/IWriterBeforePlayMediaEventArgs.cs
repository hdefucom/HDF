using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>WriterBeforePlayMediaEventArgs 的COM接口</summary>
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("B5BFF735-5AA3-465A-887F-93ADE8A633AD")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	public interface IWriterBeforePlayMediaEventArgs
	{
		/// <summary>属性Cancel</summary>
		[DispId(2)]
		bool Cancel
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

		/// <summary>属性FileName</summary>
		[DispId(5)]
		string FileName
		{
			get;
		}

		/// <summary>属性MediaElement</summary>
		[DispId(4)]
		XTextElement MediaElement
		{
			get;
		}
	}
}
