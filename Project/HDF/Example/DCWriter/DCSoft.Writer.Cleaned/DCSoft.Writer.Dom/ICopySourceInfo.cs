using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>CopySourceInfo 的COM接口</summary>
	[Browsable(false)]
	[Guid("CFCE3920-FE4C-4FE7-9D39-2D5D44F4E391")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface ICopySourceInfo
	{
		/// <summary>属性DescPropertyName</summary>
		[DispId(2)]
		string DescPropertyName
		{
			get;
			set;
		}

		/// <summary>属性IgnoreChildElements</summary>
		[DispId(3)]
		bool IgnoreChildElements
		{
			get;
			set;
		}

		/// <summary>属性SourceID</summary>
		[DispId(4)]
		string SourceID
		{
			get;
			set;
		}

		/// <summary>属性SourcePropertyName</summary>
		[DispId(5)]
		string SourcePropertyName
		{
			get;
			set;
		}
	}
}
