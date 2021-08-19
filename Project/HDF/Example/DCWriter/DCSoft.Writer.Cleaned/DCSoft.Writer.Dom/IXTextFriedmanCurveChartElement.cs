using DCSoft.Common;
using DCSoft.Drawing;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextFriedmanCurveChartElement 的COM接口</summary>
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("3C399D74-B3EA-410B-B093-79F46CE0DA80")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	public interface IXTextFriedmanCurveChartElement
	{
		/// <summary>属性Deleteable</summary>
		[DispId(82)]
		bool Deleteable
		{
			get;
			set;
		}

		/// <summary>属性Enabled</summary>
		[DispId(93)]
		bool Enabled
		{
			get;
			set;
		}

		/// <summary>属性EventTemplateName</summary>
		[DispId(95)]
		string EventTemplateName
		{
			get;
			set;
		}

		/// <summary>属性ID</summary>
		[DispId(103)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性InnerXML</summary>
		[DispId(105)]
		string InnerXML
		{
			get;
		}

		/// <summary>属性InnerXMLWithoutTrack</summary>
		[DispId(106)]
		string InnerXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性LinkInfo</summary>
		[DispId(114)]
		HyperlinkInfo LinkInfo
		{
			get;
			set;
		}

		/// <summary>属性Name</summary>
		[DispId(117)]
		string Name
		{
			get;
			set;
		}

		/// <summary>属性NextElement</summary>
		[DispId(118)]
		XTextElement NextElement
		{
			get;
		}

		/// <summary>属性OuterXML</summary>
		[DispId(120)]
		string OuterXML
		{
			get;
		}

		/// <summary>属性OuterXMLWithoutTrack</summary>
		[DispId(121)]
		string OuterXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性OwnerDocument</summary>
		[DispId(123)]
		XTextDocument OwnerDocument
		{
			get;
			set;
		}

		/// <summary>属性OwnerPagePartyStyle</summary>
		[DispId(127)]
		PageContentPartyStyle OwnerPagePartyStyle
		{
			get;
		}

		/// <summary>属性Parent</summary>
		[DispId(130)]
		XTextContainerElement Parent
		{
			get;
			set;
		}

		/// <summary>属性PixelHeight</summary>
		[DispId(133)]
		float PixelHeight
		{
			get;
			set;
		}

		/// <summary>属性PixelWidth</summary>
		[DispId(134)]
		float PixelWidth
		{
			get;
			set;
		}

		/// <summary>属性PreviousElement</summary>
		[DispId(136)]
		XTextElement PreviousElement
		{
			get;
		}

		/// <summary>属性PrintVisibility</summary>
		[DispId(138)]
		ElementVisibility PrintVisibility
		{
			get;
			set;
		}

		/// <summary>属性UserFlags</summary>
		[DispId(161)]
		int UserFlags
		{
			get;
			set;
		}

		/// <summary>属性ViewIndex</summary>
		[DispId(164)]
		int ViewIndex
		{
			get;
		}

		/// <summary>属性Visible</summary>
		[DispId(167)]
		bool Visible
		{
			get;
			set;
		}

		/// <summary>属性Width</summary>
		[DispId(168)]
		float Width
		{
			get;
			set;
		}

		/// <summary>方法GetAttribute</summary>
		[DispId(24)]
		string GetAttribute(string name);

		/// <summary>方法GetXMLFragment</summary>
		[DispId(34)]
		string GetXMLFragment();

		/// <summary>方法HasAttribute</summary>
		[DispId(36)]
		bool HasAttribute(string name);

		/// <summary>方法SetAttribute</summary>
		[DispId(59)]
		bool SetAttribute(string name, string Value);
	}
}
