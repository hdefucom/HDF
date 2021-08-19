using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>HeaderLabelInfoList 的COM接口</summary>
	[Guid("5C9D8BE7-A2D8-4169-A724-61EFBEE5A6F3")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	public interface IHeaderLabelInfoList
	{
		/// <summary>属性Count</summary>
		[DispId(6)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(7)]
		FCHeaderLabelInfo this[int index]
		{
			get;
			set;
		}

		/// <summary>方法Add</summary>
		[DispId(2)]
		void Add(FCHeaderLabelInfo item);

		/// <summary>方法IndexOf</summary>
		[DispId(3)]
		int IndexOf(FCHeaderLabelInfo item);

		/// <summary>方法Remove</summary>
		[DispId(4)]
		bool Remove(FCHeaderLabelInfo item);

		/// <summary>方法RemoveAt</summary>
		[DispId(5)]
		void RemoveAt(int index);
	}
}
