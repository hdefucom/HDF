using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>YAxisScaleInfoList 的COM接口</summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("E3552BA4-2396-4AC6-A557-7170C7AE70A3")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	public interface IYAxisScaleInfoList
	{
		/// <summary>属性Count</summary>
		[DispId(6)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(7)]
		FCYAxisScaleInfo this[int index]
		{
			get;
			set;
		}

		/// <summary>方法Add</summary>
		[DispId(2)]
		void Add(FCYAxisScaleInfo item);

		/// <summary>方法IndexOf</summary>
		[DispId(3)]
		int IndexOf(FCYAxisScaleInfo item);

		/// <summary>方法Remove</summary>
		[DispId(4)]
		bool Remove(FCYAxisScaleInfo item);

		/// <summary>方法RemoveAt</summary>
		[DispId(5)]
		void RemoveAt(int index);
	}
}
