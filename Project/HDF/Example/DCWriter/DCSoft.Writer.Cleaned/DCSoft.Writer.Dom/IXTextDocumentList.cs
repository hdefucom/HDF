using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextDocumentList 的COM接口</summary>
	[Browsable(false)]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("18CD21C5-CCC7-48D8-B3E4-F5B37B75959F")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IXTextDocumentList
	{
		/// <summary>属性Count</summary>
		[DispId(9)]
		int Count
		{
			get;
		}

		/// <summary>属性FirstDocument</summary>
		[DispId(10)]
		XTextDocument FirstDocument
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(11)]
		XTextDocument this[int index]
		{
			get;
			set;
		}

		/// <summary>属性LastDocument</summary>
		[DispId(12)]
		XTextDocument LastDocument
		{
			get;
		}

		/// <summary>属性Title</summary>
		[DispId(13)]
		string Title
		{
			get;
		}

		/// <summary>方法Add</summary>
		[DispId(2)]
		void Add(XTextDocument item);

		/// <summary>方法Clear</summary>
		[DispId(3)]
		void Clear();

		/// <summary>方法ComGetItem</summary>
		[DispId(15)]
		XTextDocument ComGetItem(int index);

		/// <summary>方法ComSetItem</summary>
		[DispId(16)]
		void ComSetItem(int index, XTextDocument item);

		/// <summary>方法Contains</summary>
		[DispId(4)]
		bool Contains(XTextDocument item);

		/// <summary>方法GetItem</summary>
		[DispId(14)]
		XTextDocument GetItem(int index);

		/// <summary>方法Remove</summary>
		[DispId(8)]
		bool Remove(XTextDocument item);
	}
}
