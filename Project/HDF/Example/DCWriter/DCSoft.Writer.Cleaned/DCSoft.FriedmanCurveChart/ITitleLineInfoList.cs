using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>TitleLineInfoList 的COM接口</summary>
	[Guid("16FC2C23-D2E6-4389-9411-E06DCBE9C2BE")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	public interface ITitleLineInfoList
	{
		/// <summary>属性Count</summary>
		[DispId(7)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(8)]
		FCTitleLineInfo this[int index]
		{
			get;
			set;
		}

		/// <summary>方法Add</summary>
		[DispId(2)]
		void Add(FCTitleLineInfo item);

		/// <summary>方法GetItemByName</summary>
		[DispId(3)]
		FCTitleLineInfo GetItemByName(string name);

		/// <summary>方法IndexOf</summary>
		[DispId(4)]
		int IndexOf(FCTitleLineInfo item);

		/// <summary>方法Remove</summary>
		[DispId(5)]
		bool Remove(FCTitleLineInfo item);

		/// <summary>方法RemoveAt</summary>
		[DispId(6)]
		void RemoveAt(int index);
	}
}
