using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>HeaderLabelInfoList 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Guid("2F0AC84F-49B9-44F2-8CFB-C2F5753ABD94")]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
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
		HeaderLabelInfo this[int index]
		{
			get;
			set;
		}

		/// <summary>方法Add</summary>
		[DispId(2)]
		void Add(HeaderLabelInfo item);

		/// <summary>方法IndexOf</summary>
		[DispId(3)]
		int IndexOf(HeaderLabelInfo item);

		/// <summary>方法Remove</summary>
		[DispId(4)]
		bool Remove(HeaderLabelInfo item);

		/// <summary>方法RemoveAt</summary>
		[DispId(5)]
		void RemoveAt(int index);
	}
}
