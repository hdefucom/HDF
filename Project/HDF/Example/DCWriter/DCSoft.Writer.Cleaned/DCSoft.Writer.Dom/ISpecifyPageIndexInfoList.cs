using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>SpecifyPageIndexInfoList 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[ComVisible(true)]
	[Guid("90DD9F88-9BAF-4F4B-AA06-D75BFF97BA93")]
	public interface ISpecifyPageIndexInfoList
	{
		/// <summary>属性Count</summary>
		[DispId(6)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(7)]
		SpecifyPageIndexInfo this[int index]
		{
			get;
			set;
		}

		/// <summary>方法Add</summary>
		[DispId(2)]
		void Add(SpecifyPageIndexInfo item);

		/// <summary>方法Clear</summary>
		[DispId(3)]
		void Clear();

		/// <summary>方法Remove</summary>
		[DispId(4)]
		bool Remove(SpecifyPageIndexInfo item);

		/// <summary>方法RemoveAt</summary>
		[DispId(5)]
		void RemoveAt(int index);
	}
}
