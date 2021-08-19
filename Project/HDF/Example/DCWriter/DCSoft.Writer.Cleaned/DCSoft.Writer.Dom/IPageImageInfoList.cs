using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>PageImageInfoList 的COM接口</summary>
	[Guid("26CA71E1-18BD-4532-A9BD-A1111A93F003")]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public interface IPageImageInfoList
	{
		/// <summary>属性Count</summary>
		[DispId(5)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(6)]
		PageImageInfo this[int index]
		{
			get;
			set;
		}

		/// <summary>方法Add</summary>
		[DispId(2)]
		void Add(PageImageInfo item);

		/// <summary>方法RemoveAt</summary>
		[DispId(4)]
		void RemoveAt(int index);
	}
}
