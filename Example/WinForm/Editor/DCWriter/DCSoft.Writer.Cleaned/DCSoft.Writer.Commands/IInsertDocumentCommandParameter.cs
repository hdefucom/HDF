using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>InsertDocumentCommandParameter 的COM接口</summary>
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[Guid("841C8CC1-8171-4F31-AF4F-708FBE765BD7")]
	public interface IInsertDocumentCommandParameter
	{
		/// <summary>属性FileFormat</summary>
		[DispId(2)]
		string FileFormat
		{
			get;
			set;
		}

		/// <summary>属性ParagraphStyleIndex</summary>
		[DispId(3)]
		int ParagraphStyleIndex
		{
			get;
			set;
		}

		/// <summary>属性StringSource</summary>
		[DispId(4)]
		string StringSource
		{
			get;
			set;
		}

		/// <summary>属性StyleIndex</summary>
		[DispId(5)]
		int StyleIndex
		{
			get;
			set;
		}
	}
}
