using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Writer.Data;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextTDBarcodeElement 的COM接口</summary>
	[Guid("FD042381-D32A-4EFD-9104-95E069725336")]
	[Browsable(false)]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IXTextTDBarcodeElement
	{
		/// <summary>属性Attributes</summary>
		[DispId(5)]
		XAttributeList Attributes
		{
			get;
			set;
		}

		/// <summary>属性BarcodeType</summary>
		[DispId(6)]
		DCTDBarcodeType BarcodeType
		{
			get;
			set;
		}

		/// <summary>属性Deleteable</summary>
		[DispId(7)]
		bool Deleteable
		{
			get;
			set;
		}

		/// <summary>属性Enabled</summary>
		[DispId(8)]
		bool Enabled
		{
			get;
			set;
		}

		/// <summary>属性ErroeCorrectionLevel</summary>
		[DispId(9)]
		DCTBErroeCorrectionLevelType ErroeCorrectionLevel
		{
			get;
			set;
		}

		/// <summary>属性EventTemplateName</summary>
		[DispId(10)]
		string EventTemplateName
		{
			get;
			set;
		}

		/// <summary>属性ID</summary>
		[DispId(11)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性InnerXML</summary>
		[DispId(12)]
		string InnerXML
		{
			get;
		}

		/// <summary>属性InnerXMLWithoutTrack</summary>
		[DispId(13)]
		string InnerXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性LinkInfo</summary>
		[DispId(14)]
		HyperlinkInfo LinkInfo
		{
			get;
			set;
		}

		/// <summary>属性Name</summary>
		[DispId(15)]
		string Name
		{
			get;
			set;
		}

		/// <summary>属性NextElement</summary>
		[DispId(16)]
		XTextElement NextElement
		{
			get;
		}

		/// <summary>属性OuterXML</summary>
		[DispId(17)]
		string OuterXML
		{
			get;
		}

		/// <summary>属性OuterXMLWithoutTrack</summary>
		[DispId(18)]
		string OuterXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性OwnerDocument</summary>
		[DispId(19)]
		XTextDocument OwnerDocument
		{
			get;
			set;
		}

		/// <summary>属性OwnerPagePartyStyle</summary>
		[DispId(20)]
		PageContentPartyStyle OwnerPagePartyStyle
		{
			get;
		}

		/// <summary>属性Parent</summary>
		[DispId(21)]
		XTextContainerElement Parent
		{
			get;
			set;
		}

		/// <summary>属性PreviousElement</summary>
		[DispId(22)]
		XTextElement PreviousElement
		{
			get;
		}

		/// <summary>属性PrintVisibility</summary>
		[DispId(34)]
		ElementVisibility PrintVisibility
		{
			get;
			set;
		}

		/// <summary>属性StringTag</summary>
		[DispId(24)]
		string StringTag
		{
			get;
			set;
		}

		/// <summary>属性Style</summary>
		[DispId(25)]
		DocumentContentStyle Style
		{
			get;
			set;
		}

		/// <summary>属性StyleIndex</summary>
		[DispId(26)]
		int StyleIndex
		{
			get;
			set;
		}

		/// <summary>属性Tag</summary>
		[DispId(27)]
		object Tag
		{
			get;
			set;
		}

		/// <summary>属性Text</summary>
		[DispId(28)]
		string Text
		{
			get;
			set;
		}

		/// <summary>属性UserFlags</summary>
		[DispId(29)]
		int UserFlags
		{
			get;
			set;
		}

		/// <summary>属性VAlign</summary>
		[DispId(30)]
		VerticalAlignStyle VAlign
		{
			get;
			set;
		}

		/// <summary>属性ValueBinding</summary>
		[DispId(31)]
		XDataBinding ValueBinding
		{
			get;
			set;
		}

		/// <summary>属性ViewIndex</summary>
		[DispId(32)]
		int ViewIndex
		{
			get;
		}

		/// <summary>属性Width</summary>
		[DispId(33)]
		float Width
		{
			get;
			set;
		}

		/// <summary>方法GetAttribute</summary>
		[DispId(2)]
		string GetAttribute(string name);

		/// <summary>方法HasAttribute</summary>
		[DispId(3)]
		bool HasAttribute(string name);

		/// <summary>方法SetAttribute</summary>
		[DispId(4)]
		bool SetAttribute(string name, string Value);
	}
}
