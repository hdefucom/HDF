using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>WriterBeforeUIKeyboardInputStringEventArgs 的COM接口</summary>
	[Browsable(false)]
	[Guid("E2FBA882-B5E9-4B78-BFD5-5278268C5F04")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IWriterBeforeUIKeyboardInputStringEventArgs
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

		/// <summary>属性Element</summary>
		[DispId(4)]
		XTextElement Element
		{
			get;
		}

		/// <summary>属性InputString</summary>
		[DispId(5)]
		string InputString
		{
			get;
		}

		/// <summary>属性OutputString</summary>
		[DispId(6)]
		string OutputString
		{
			get;
			set;
		}
	}
}
