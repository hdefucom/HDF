using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>TrackVisibleConfig 的COM接口</summary>
	[Guid("E9B6AA40-C74D-41AC-8F4F-88F1E7405D2B")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	public interface ITrackVisibleConfig
	{
		/// <summary>属性BackgroundColor</summary>
		[DispId(2)]
		Color BackgroundColor
		{
			get;
			set;
		}

		/// <summary>属性BackgroundColorString</summary>
		[DispId(3)]
		string BackgroundColorString
		{
			get;
			set;
		}

		/// <summary>属性DeleteLineColor</summary>
		[DispId(4)]
		Color DeleteLineColor
		{
			get;
			set;
		}

		/// <summary>属性DeleteLineColorString</summary>
		[DispId(5)]
		string DeleteLineColorString
		{
			get;
			set;
		}

		/// <summary>属性DeleteLineNum</summary>
		[DispId(6)]
		int DeleteLineNum
		{
			get;
			set;
		}

		/// <summary>属性Enabled</summary>
		[DispId(7)]
		bool Enabled
		{
			get;
			set;
		}

		/// <summary>属性UnderLineColor</summary>
		[DispId(8)]
		Color UnderLineColor
		{
			get;
			set;
		}

		/// <summary>属性UnderLineColorNum</summary>
		[DispId(9)]
		int UnderLineColorNum
		{
			get;
			set;
		}

		/// <summary>属性UnderLineColorString</summary>
		[DispId(10)]
		string UnderLineColorString
		{
			get;
			set;
		}
	}
}
