using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>EditValuePointEventArgs 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("B1BBF5DF-E1D1-4411-B351-410A509982CC")]
	public interface IEditValuePointEventArgs
	{
		/// <summary>属性Document</summary>
		[DispId(2)]
		TemperatureDocument Document
		{
			get;
		}

		/// <summary>属性EditMode</summary>
		[DispId(3)]
		EditValuePointMode EditMode
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
		TitleLineInfo TitleLineInfo
		{
			get;
		}

		/// <summary>属性ValuePoint</summary>
		[DispId(8)]
		ValuePoint ValuePoint
		{
			get;
		}

		/// <summary>属性YAxisInfo</summary>
		[DispId(9)]
		YAxisInfo YAxisInfo
		{
			get;
		}
	}
}
