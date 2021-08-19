using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>BorderBackgroundCommandParameter 的COM接口</summary>
	[ComVisible(true)]
	[Guid("685ABB26-D0E5-414C-8ED3-EC6F349D7966")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IBorderBackgroundCommandParameter
	{
		/// <summary>属性ApplyRange</summary>
		[DispId(2)]
		StyleApplyRanges ApplyRange
		{
			get;
			set;
		}

		/// <summary>属性BackgroundColor</summary>
		[DispId(3)]
		Color BackgroundColor
		{
			get;
			set;
		}

		/// <summary>属性BorderBottomColor</summary>
		[DispId(4)]
		Color BorderBottomColor
		{
			get;
			set;
		}

		/// <summary>属性BorderLeftColor</summary>
		[DispId(5)]
		Color BorderLeftColor
		{
			get;
			set;
		}

		/// <summary>属性BorderRightColor</summary>
		[DispId(6)]
		Color BorderRightColor
		{
			get;
			set;
		}

		/// <summary>属性BorderSettingsStyle</summary>
		[DispId(7)]
		BorderSettingsStyle BorderSettingsStyle
		{
			get;
			set;
		}

		/// <summary>属性BorderStyle</summary>
		[DispId(8)]
		DashStyle BorderStyle
		{
			get;
			set;
		}

		/// <summary>属性BorderTopColor</summary>
		[DispId(9)]
		Color BorderTopColor
		{
			get;
			set;
		}

		/// <summary>属性BorderWidth</summary>
		[DispId(10)]
		float BorderWidth
		{
			get;
			set;
		}

		/// <summary>属性BottomBorder</summary>
		[DispId(11)]
		bool BottomBorder
		{
			get;
			set;
		}

		/// <summary>属性CenterVerticalBorder</summary>
		[DispId(12)]
		bool CenterVerticalBorder
		{
			get;
			set;
		}

		/// <summary>属性Elements</summary>
		[DispId(17)]
		XTextElementList Elements
		{
			get;
			set;
		}

		/// <summary>属性LeftBorder</summary>
		[DispId(13)]
		bool LeftBorder
		{
			get;
			set;
		}

		/// <summary>属性MiddleHorizontalBorder</summary>
		[DispId(14)]
		bool MiddleHorizontalBorder
		{
			get;
			set;
		}

		/// <summary>属性RightBorder</summary>
		[DispId(15)]
		bool RightBorder
		{
			get;
			set;
		}

		/// <summary>属性TopBorder</summary>
		[DispId(16)]
		bool TopBorder
		{
			get;
			set;
		}
	}
}
