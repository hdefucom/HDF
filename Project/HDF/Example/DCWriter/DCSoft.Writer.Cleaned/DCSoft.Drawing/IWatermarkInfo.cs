using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>WatermarkInfo 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("818EF2BB-F82D-4843-9809-AE2A7DB69250")]
	public interface IWatermarkInfo
	{
		/// <summary>属性Alpha</summary>
		[DispId(3)]
		int Alpha
		{
			get;
			set;
		}

		/// <summary>属性Angle</summary>
		[DispId(4)]
		float Angle
		{
			get;
			set;
		}

		/// <summary>属性BackColor</summary>
		[DispId(5)]
		Color BackColor
		{
			get;
			set;
		}

		/// <summary>属性BackColorValue</summary>
		[DispId(6)]
		string BackColorValue
		{
			get;
			set;
		}

		/// <summary>属性Color</summary>
		[DispId(7)]
		Color Color
		{
			get;
			set;
		}

		/// <summary>属性ColorValue</summary>
		[DispId(8)]
		string ColorValue
		{
			get;
			set;
		}

		/// <summary>属性Font</summary>
		[DispId(9)]
		XFontValue Font
		{
			get;
			set;
		}

		/// <summary>属性Image</summary>
		[DispId(10)]
		XImageValue Image
		{
			get;
			set;
		}

		/// <summary>属性PrintWatermark</summary>
		[DispId(14)]
		bool PrintWatermark
		{
			get;
			set;
		}

		/// <summary>属性Repeat</summary>
		[DispId(11)]
		bool Repeat
		{
			get;
			set;
		}

		/// <summary>属性ShowWatermark</summary>
		[DispId(15)]
		bool ShowWatermark
		{
			get;
			set;
		}

		/// <summary>属性Text</summary>
		[DispId(12)]
		string Text
		{
			get;
			set;
		}

		/// <summary>属性Type</summary>
		[DispId(13)]
		WatermarkType Type
		{
			get;
			set;
		}

		/// <summary>方法Clone</summary>
		[DispId(2)]
		WatermarkInfo Clone();
	}
}
