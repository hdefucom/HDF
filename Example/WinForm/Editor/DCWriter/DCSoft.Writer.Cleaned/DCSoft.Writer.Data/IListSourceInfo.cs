using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>ListSourceInfo 的COM接口</summary>
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("C3F5C68B-53B5-48D5-A352-46ADD435CC72")]
	public interface IListSourceInfo
	{
		/// <summary>属性DisplayPath</summary>
		[DispId(2)]
		string DisplayPath
		{
			get;
			set;
		}

		/// <summary>属性IsEmpty</summary>
		[DispId(4)]
		bool IsEmpty
		{
			get;
		}

		/// <summary>属性Items</summary>
		[DispId(5)]
		ListItemCollection Items
		{
			get;
			set;
		}

		/// <summary>属性Name</summary>
		[DispId(6)]
		string Name
		{
			get;
			set;
		}

		/// <summary>属性RuntimeItems</summary>
		[DispId(7)]
		ListItemCollection RuntimeItems
		{
			get;
			set;
		}

		/// <summary>属性SourceName</summary>
		[DispId(8)]
		string SourceName
		{
			get;
			set;
		}

		/// <summary>属性ValuePath</summary>
		[DispId(9)]
		string ValuePath
		{
			get;
			set;
		}
	}
}
