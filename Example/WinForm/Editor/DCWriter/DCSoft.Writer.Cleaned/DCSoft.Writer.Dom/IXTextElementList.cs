using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextElementList 的COM接口</summary>
	[Browsable(false)]
	[Guid("F8FC43D5-EE32-3BE2-86E3-30332E3AFBA7")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IXTextElementList
	{
		/// <summary>属性Count</summary>
		[DispId(8)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(10)]
		XTextElement this[int index]
		{
			get;
			set;
		}

		/// <summary>方法Add</summary>
		[DispId(18)]
		void Add(XTextElement element);

		/// <summary>方法AddRangeRaw</summary>
		[DispId(19)]
		void AddRangeRaw(XTextElementList elements);

		/// <summary>方法Clear</summary>
		[DispId(14)]
		void Clear();

		/// <summary>方法ComAddItem</summary>
		[DispId(15)]
		void ComAddItem(XTextElement item);

		/// <summary>方法ComGetItem</summary>
		[DispId(16)]
		XTextElement ComGetItem(int index);

		/// <summary>方法ComSetItem</summary>
		[DispId(17)]
		void ComSetItem(int index, XTextElement item);

		/// <summary>方法GetItem</summary>
		[DispId(11)]
		XTextElement GetItem(int index);

		/// <summary>方法RemoveAt</summary>
		[DispId(12)]
		void RemoveAt(int index);
	}
}
