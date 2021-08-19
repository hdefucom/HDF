using DCSoft.Drawing;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>ValuePoint 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[Guid("DFC1EA65-7B59-4C9F-81FC-7F0B1E850EF2")]
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
		ValuePointSymbolStyle SpecifySymbolStyle
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
