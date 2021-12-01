using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.TemperatureChart;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextTemperatureChartElement 的COM接口</summary>
	[Guid("6E5FD021-473D-4328-BE4A-EFE1E44E1DC5")]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IXTextTemperatureChartElement
	{
		/// <summary>属性Deleteable</summary>
		[DispId(6)]
		bool Deleteable
		{
			get;
			set;
		}

		/// <summary>属性Document</summary>
		[DispId(26)]
		TemperatureDocument Document
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

		/// <summary>属性EventTemplateName</summary>
		[DispId(8)]
		string EventTemplateName
		{
			get;
			set;
		}

		/// <summary>属性Height</summary>
		[DispId(29)]
		float Height
		{
			get;
			set;
		}

		/// <summary>属性ID</summary>
		[DispId(9)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性InnerXML</summary>
		[DispId(10)]
		string InnerXML
		{
			get;
		}

		/// <summary>属性InnerXMLWithoutTrack</summary>
		[DispId(11)]
		string InnerXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性LinkInfo</summary>
		[DispId(12)]
		HyperlinkInfo LinkInfo
		{
			get;
			set;
		}

		/// <summary>属性Name</summary>
		[DispId(13)]
		string Name
		{
			get;
			set;
		}

		/// <summary>属性NextElement</summary>
		[DispId(14)]
		XTextElement NextElement
		{
			get;
		}

		/// <summary>属性OuterXML</summary>
		[DispId(15)]
		string OuterXML
		{
			get;
		}

		/// <summary>属性OuterXMLWithoutTrack</summary>
		[DispId(16)]
		string OuterXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性OwnerDocument</summary>
		[DispId(17)]
		XTextDocument OwnerDocument
		{
			get;
			set;
		}

		/// <summary>属性OwnerPagePartyStyle</summary>
		[DispId(18)]
		PageContentPartyStyle OwnerPagePartyStyle
		{
			get;
		}

		/// <summary>属性Parent</summary>
		[DispId(19)]
		XTextContainerElement Parent
		{
			get;
			set;
		}

		/// <summary>属性PixelHeight</summary>
		[DispId(27)]
		float PixelHeight
		{
			get;
			set;
		}

		/// <summary>属性PixelWidth</summary>
		[DispId(28)]
		float PixelWidth
		{
			get;
			set;
		}

		/// <summary>属性PreviousElement</summary>
		[DispId(20)]
		XTextElement PreviousElement
		{
			get;
		}

		/// <summary>属性UserFlags</summary>
		[DispId(22)]
		int UserFlags
		{
			get;
			set;
		}

		/// <summary>属性ViewIndex</summary>
		[DispId(23)]
		int ViewIndex
		{
			get;
		}

		/// <summary>属性Visible</summary>
		[DispId(24)]
		bool Visible
		{
			get;
			set;
		}

		/// <summary>属性Width</summary>
		[DispId(25)]
		float Width
		{
			get;
			set;
		}

		/// <summary>方法GetAttribute</summary>
		[DispId(2)]
		string GetAttribute(string name);

		/// <summary>方法GetXMLFragment</summary>
		[DispId(3)]
		string GetXMLFragment();

		/// <summary>方法HasAttribute</summary>
		[DispId(4)]
		bool HasAttribute(string name);

		/// <summary>方法SetAttribute</summary>
		[DispId(5)]
		bool SetAttribute(string name, string Value);
	}
}
