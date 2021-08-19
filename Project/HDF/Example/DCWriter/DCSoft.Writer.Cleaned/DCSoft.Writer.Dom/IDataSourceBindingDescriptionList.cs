using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>DataSourceBindingDescriptionList 的COM接口</summary>
	[Browsable(false)]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("BB9EC01B-A78C-45FD-A1CF-83C56606327D")]
	public interface IDataSourceBindingDescriptionList
	{
		/// <summary>属性Count</summary>
		[DispId(2)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(3)]
		DataSourceBindingDescription this[int index]
		{
			get;
			set;
		}
	}
}
