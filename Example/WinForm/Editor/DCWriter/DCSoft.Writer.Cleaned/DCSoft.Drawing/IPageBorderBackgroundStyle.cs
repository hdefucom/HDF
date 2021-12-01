using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>PageBorderBackgroundStyle 的COM接口</summary>
	[Browsable(false)]
	[ComVisible(true)]
	[Guid("9BD3F9CE-B608-4722-AD35-68ED742D18B3")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IPageBorderBackgroundStyle
	{
		/// <summary>属性BackgroundColor</summary>
		[DispId(17)]
		Color BackgroundColor
		{
			get;
			set;
		}

		/// <summary>属性BackgroundColorString</summary>
		[DispId(18)]
		string BackgroundColorString
		{
			get;
			set;
		}

		/// <summary>属性BorderBottom</summary>
		[DispId(2)]
		bool BorderBottom
		{
			get;
			set;
		}

		/// <summary>属性BorderBottomColor</summary>
		[DispId(3)]
		Color BorderBottomColor
		{
			get;
			set;
		}

		/// <summary>属性BorderBottomColorString</summary>
		[DispId(4)]
		string BorderBottomColorString
		{
			get;
			set;
		}

		/// <summary>属性BorderColor</summary>
		[DispId(5)]
		Color BorderColor
		{
			get;
			set;
		}

		/// <summary>属性BorderLeft</summary>
		[DispId(6)]
		bool BorderLeft
		{
			get;
			set;
		}

		/// <summary>属性BorderLeftColor</summary>
		[DispId(7)]
		Color BorderLeftColor
		{
			get;
			set;
		}

		/// <summary>属性BorderLeftColorString</summary>
		[DispId(8)]
		string BorderLeftColorString
		{
			get;
			set;
		}

		/// <summary>属性BorderRange</summary>
		[DispId(19)]
		PageBorderRangeTypes BorderRange
		{
			get;
			set;
		}

		/// <summary>属性BorderRight</summary>
		[DispId(9)]
		bool BorderRight
		{
			get;
			set;
		}

		/// <summary>属性BorderRightColor</summary>
		[DispId(10)]
		Color BorderRightColor
		{
			get;
			set;
		}

		/// <summary>属性BorderRightColorString</summary>
		[DispId(11)]
		string BorderRightColorString
		{
			get;
			set;
		}

		/// <summary>属性BorderSpacing</summary>
		[DispId(20)]
		float BorderSpacing
		{
			get;
			set;
		}

		/// <summary>属性BorderStyle</summary>
		[DispId(12)]
		DashStyle BorderStyle
		{
			get;
			set;
		}

		/// <summary>属性BorderStyleValue</summary>
		[DispId(21)]
		int BorderStyleValue
		{
			get;
			set;
		}

		/// <summary>属性BorderTop</summary>
		[DispId(13)]
		bool BorderTop
		{
			get;
			set;
		}

		/// <summary>属性BorderTopColor</summary>
		[DispId(14)]
		Color BorderTopColor
		{
			get;
			set;
		}

		/// <summary>属性BorderTopColorString</summary>
		[DispId(15)]
		string BorderTopColorString
		{
			get;
			set;
		}

		/// <summary>属性BorderWidth</summary>
		[DispId(16)]
		float BorderWidth
		{
			get;
			set;
		}
	}
}
