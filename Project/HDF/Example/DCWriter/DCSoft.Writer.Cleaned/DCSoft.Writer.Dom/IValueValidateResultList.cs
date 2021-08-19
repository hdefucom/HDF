using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>ValueValidateResultList 的COM接口</summary>
	[Browsable(false)]
	[Guid("F3A06595-468E-455B-987D-99196DBDAAF9")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	public interface IValueValidateResultList
	{
		/// <summary>属性Count</summary>
		[DispId(9)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(10)]
		ValueValidateResult this[int index]
		{
			get;
			set;
		}

		/// <summary>方法Add</summary>
		[DispId(2)]
		void Add(ValueValidateResult item);

		/// <summary>方法Clear</summary>
		[DispId(3)]
		void Clear();

		/// <summary>方法ComGetItem</summary>
		[DispId(11)]
		ValueValidateResult ComGetItem(int index);

		/// <summary>方法ComSetItem</summary>
		[DispId(12)]
		void ComSetItem(int index, ValueValidateResult item);

		/// <summary>方法Contains</summary>
		[DispId(4)]
		bool Contains(ValueValidateResult item);

		/// <summary>方法Remove</summary>
		[DispId(8)]
		bool Remove(ValueValidateResult item);
	}
}
