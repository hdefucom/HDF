using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>DocumentCommentList 的COM接口</summary>
	[Guid("013C10FE-E70E-4E9E-98EB-440F1500F678")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public interface IDocumentCommentList
	{
		/// <summary>属性Count</summary>
		[DispId(9)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(10)]
		DocumentComment this[int index]
		{
			get;
			set;
		}

		/// <summary>方法Add</summary>
		[DispId(2)]
		void Add(DocumentComment item);

		/// <summary>方法Clear</summary>
		[DispId(3)]
		void Clear();

		/// <summary>方法ComGetItem</summary>
		[DispId(11)]
		DocumentComment ComGetItem(int index);

		/// <summary>方法ComSetItem</summary>
		[DispId(12)]
		void ComSetItem(int index, DocumentComment item);

		/// <summary>方法Remove</summary>
		[DispId(7)]
		bool Remove(DocumentComment item);

		/// <summary>方法RemoveAt</summary>
		[DispId(8)]
		void RemoveAt(int index);
	}
}
