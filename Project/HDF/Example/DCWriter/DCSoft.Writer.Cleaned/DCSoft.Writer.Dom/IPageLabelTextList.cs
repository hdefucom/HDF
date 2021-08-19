using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>PageLabelTextList 的COM接口</summary>
	[ComVisible(true)]
	[Guid("A190D93A-F50F-4A36-87BE-863F35186D04")]
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IPageLabelTextList
	{
		/// <summary>属性Count</summary>
		[DispId(5)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(6)]
		PageLabelText this[int index]
		{
			get;
			set;
		}

		/// <summary>方法Add</summary>
		[DispId(2)]
		void Add(PageLabelText item);

		/// <summary>方法RemoveAt</summary>
		[DispId(4)]
		void RemoveAt(int index);
	}
}
