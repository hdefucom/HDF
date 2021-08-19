using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>EditValuePointEventArgs 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("29DB8183-00BE-4A52-BDFD-E8622FE4C9E4")]
	[Browsable(false)]
	public interface IEditValuePointEventArgs
	{
		/// <summary>属性Document</summary>
		[DispId(2)]
		FriedmanCurveDocument Document
		{
			get;
		}

		/// <summary>属性EditMode</summary>
		[DispId(3)]
		FCEditValuePointMode EditMode
		{
			get;
		}

		/// <summary>属性Result</summary>
		[DispId(4)]
		bool Result
		{
			get;
			set;
		}

		/// <summary>属性SerialName</summary>
		[DispId(5)]
		string SerialName
		{
			get;
		}

		/// <summary>属性SerialTitle</summary>
		[DispId(6)]
		string SerialTitle
		{
			get;
		}

		/// <summary>属性TitleLineInfo</summary>
		[DispId(7)]
		FCTitleLineInfo TitleLineInfo
		{
			get;
		}

		/// <summary>属性ValuePoint</summary>
		[DispId(8)]
		FCValuePoint ValuePoint
		{
			get;
		}

		/// <summary>属性YAxisInfo</summary>
		[DispId(9)]
		FCYAxisInfo YAxisInfo
		{
			get;
		}
	}
}
