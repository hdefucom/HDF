using DCSoft.Drawing;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextCustomShapeElement 的COM接口</summary>
	[Guid("EDAC2210-DEF9-46DD-8431-A11DE7765F1B")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[Browsable(false)]
	public interface IXTextCustomShapeElement
	{
		/// <summary>属性Deleteable</summary>
		[DispId(5)]
		bool Deleteable
		{
			get;
			set;
		}

		/// <summary>属性Enabled</summary>
		[DispId(6)]
		bool Enabled
		{
			get;
			set;
		}

		/// <summary>属性EventTemplateName</summary>
		[DispId(7)]
		string EventTemplateName
		{
			get;
			set;
		}

		/// <summary>属性Height</summary>
		[DispId(8)]
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

		/// <summary>属性Name</summary>
		[DispId(12)]
		string Name
		{
			get;
			set;
		}

		/// <summary>属性NextElement</summary>
		[DispId(13)]
		XTextElement NextElement
		{
			get;
		}

		/// <summary>属性OuterXML</summary>
		[DispId(14)]
		string OuterXML
		{
			get;
		}

		/// <summary>属性OuterXMLWithoutTrack</summary>
		[DispId(15)]
		string OuterXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性OwnerDocument</summary>
		[DispId(16)]
		XTextDocument OwnerDocument
		{
			get;
			set;
		}

		/// <summary>属性OwnerPagePartyStyle</summary>
		[DispId(17)]
		PageContentPartyStyle OwnerPagePartyStyle
		{
			get;
		}

		/// <summary>属性Parent</summary>
		[DispId(18)]
		XTextContainerElement Parent
		{
			get;
			set;
		}

		/// <summary>属性PreviousElement</summary>
		[DispId(19)]
		XTextElement PreviousElement
		{
			get;
		}

		/// <summary>属性Printable</summary>
		[DispId(20)]
		bool Printable
		{
			get;
			set;
		}

		/// <summary>属性ViewIndex</summary>
		[DispId(21)]
		int ViewIndex
		{
			get;
		}

		/// <summary>属性Width</summary>
		[DispId(22)]
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
