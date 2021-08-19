using DCSoft.Drawing;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>ValuePoint 的COM接口</summary>
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("9F36C604-29E1-45D2-AE88-521AC6B42DC1")]
	[ComVisible(true)]
	public interface IValuePoint
	{
		/// <summary>属性Color</summary>
		[DispId(7)]
		Color Color
		{
			get;
			set;
		}

		/// <summary>属性ColorValue</summary>
		[DispId(10)]
		string ColorValue
		{
			get;
			set;
		}

		/// <summary>属性EndTime</summary>
		[DispId(16)]
		DateTime EndTime
		{
			get;
			set;
		}

		/// <summary>属性ID</summary>
		[DispId(8)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性Image</summary>
		[DispId(11)]
		XImageValue Image
		{
			get;
			set;
		}

		/// <summary>属性LanternValue</summary>
		[DispId(3)]
		float LanternValue
		{
			get;
			set;
		}

		/// <summary>属性Link</summary>
		[DispId(12)]
		string Link
		{
			get;
			set;
		}

		/// <summary>属性LinkTarget</summary>
		[DispId(13)]
		string LinkTarget
		{
			get;
			set;
		}

		/// <summary>属性SpecifySymbolStyle</summary>
		[DispId(15)]
		FCValuePointSymbolStyle SpecifySymbolStyle
		{
			get;
			set;
		}

		/// <summary>属性Text</summary>
		[DispId(4)]
		string Text
		{
			get;
			set;
		}

		/// <summary>属性Time</summary>
		[DispId(5)]
		DateTime Time
		{
			get;
			set;
		}

		/// <summary>属性Title</summary>
		[DispId(14)]
		string Title
		{
			get;
			set;
		}

		/// <summary>属性Value</summary>
		[DispId(6)]
		float Value
		{
			get;
			set;
		}

		/// <summary>方法LoadImageByBase64String</summary>
		[DispId(9)]
		void LoadImageByBase64String(string string_0);
	}
}
