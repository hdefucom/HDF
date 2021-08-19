using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>ContentStyleList 的COM接口</summary>
	[Guid("D5011AC0-DE88-40A2-B429-3D2903D8B5D4")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[Browsable(false)]
	public interface IContentStyleList
	{
		/// <summary>属性Count</summary>
		[DispId(6)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(7)]
		ContentStyle this[int index]
		{
			get;
			set;
		}

		/// <summary>方法Add</summary>
		[DispId(2)]
		void Add(ContentStyle item);

		/// <summary>方法Clear</summary>
		[DispId(3)]
		void Clear();

		/// <summary>方法ComGetItem</summary>
		[DispId(8)]
		ContentStyle ComGetItem(int index);

		/// <summary>方法ComSetItem</summary>
		[DispId(9)]
		void ComSetItem(int index, ContentStyle item);

		/// <summary>方法Remove</summary>
		[DispId(5)]
		bool Remove(ContentStyle item);
	}
}
