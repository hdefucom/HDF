using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>KBEntryLoadTemplateContentEventArgs 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("98302397-4E8A-4679-953E-9837FF4C666C")]
	public interface IKBEntryLoadTemplateContentEventArgs
	{
		/// <summary>属性Content</summary>
		[DispId(2)]
		byte[] Content
		{
			get;
			set;
		}

		/// <summary>属性Entry</summary>
		[DispId(3)]
		KBEntry Entry
		{
			get;
		}

		/// <summary>属性Format</summary>
		[DispId(4)]
		string Format
		{
			get;
			set;
		}

		/// <summary>属性Library</summary>
		[DispId(5)]
		KBLibrary Library
		{
			get;
		}

		/// <summary>属性Result</summary>
		[DispId(6)]
		bool Result
		{
			get;
			set;
		}
	}
}
