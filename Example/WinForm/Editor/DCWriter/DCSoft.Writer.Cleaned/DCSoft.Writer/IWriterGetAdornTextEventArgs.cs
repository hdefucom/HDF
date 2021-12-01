using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>WriterGetAdornTextEventArgs 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[Guid("610763F6-2E8C-4B1C-8528-31B7AE863009")]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IWriterGetAdornTextEventArgs
	{
		/// <summary>属性AdornText</summary>
		[DispId(2)]
		string AdornText
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
	}
}
