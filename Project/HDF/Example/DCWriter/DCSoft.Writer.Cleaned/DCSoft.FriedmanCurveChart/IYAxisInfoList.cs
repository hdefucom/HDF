using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>YAxisInfoList 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[Guid("9B0E85AB-0021-46F5-B8EE-9A5C098FC4A0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public interface IYAxisInfoList
	{
		/// <summary>属性Count</summary>
		[DispId(6)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(7)]
		FCYAxisInfo this[int index]
		{
			get;
			set;
		}

		/// <summary>方法Add</summary>
		[DispId(2)]
		void Add(FCYAxisInfo item);

		/// <summary>方法GetItemByName</summary>
		[DispId(8)]
		FCYAxisInfo GetItemByName(string name);

		/// <summary>方法IndexOf</summary>
		[DispId(3)]
		int IndexOf(FCYAxisInfo item);

		/// <summary>方法Remove</summary>
		[DispId(4)]
		bool Remove(FCYAxisInfo item);

		/// <summary>方法RemoveAt</summary>
		[DispId(5)]
		void RemoveAt(int index);
	}
}
