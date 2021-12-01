using DCSoft.Drawing;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextMediaElement 的COM接口</summary>
	[Guid("D492C04E-0037-481C-B291-F772FA1DFB97")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IXTextMediaElement
	{
		/// <summary>属性Attributes</summary>
		[DispId(5)]
		XAttributeList Attributes
		{
			get;
			set;
		}

		/// <summary>属性Deleteable</summary>
		[DispId(21)]
		bool Deleteable
		{
			get;
			set;
		}

		/// <summary>属性Enabled</summary>
		[DispId(18)]
		bool Enabled
		{
			get;
			set;
		}

		/// <summary>属性EnableMediaContextMenu</summary>
		[DispId(16)]
		bool EnableMediaContextMenu
		{
			get;
			set;
		}

		/// <summary>属性FileName</summary>
		[DispId(6)]
		string FileName
		{
			get;
			set;
		}

		/// <summary>属性Height</summary>
		[DispId(7)]
		float Height
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

		/// <summary>属性InnerXML</summary>
		[DispId(9)]
		string InnerXML
		{
			get;
		}

		/// <summary>属性InnerXMLWithoutTrack</summary>
		[DispId(22)]
		string InnerXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性LoopPlay</summary>
		[DispId(17)]
		bool LoopPlay
		{
			get;
			set;
		}

		/// <summary>属性Name</summary>
		[DispId(23)]
		string Name
		{
			get;
			set;
		}

		/// <summary>属性OuterXML</summary>
		[DispId(10)]
		string OuterXML
		{
			get;
		}

		/// <summary>属性OwnerDocument</summary>
		[DispId(24)]
		XTextDocument OwnerDocument
		{
			get;
			set;
		}

		/// <summary>属性OwnerPagePartyStyle</summary>
		[DispId(25)]
		PageContentPartyStyle OwnerPagePartyStyle
		{
			get;
		}

		/// <summary>属性Parent</summary>
		[DispId(11)]
		XTextContainerElement Parent
		{
			get;
			set;
		}

		/// <summary>属性PixelHeight</summary>
		[DispId(26)]
		float PixelHeight
		{
			get;
			set;
		}

		/// <summary>属性PixelWidth</summary>
		[DispId(27)]
		float PixelWidth
		{
			get;
			set;
		}

		/// <summary>属性PlayerUIMode</summary>
		[DispId(12)]
		WindowsMediaPlayerUIMode PlayerUIMode
		{
			get;
			set;
		}

		/// <summary>属性PreviousElement</summary>
		[DispId(13)]
		XTextElement PreviousElement
		{
			get;
		}

		/// <summary>属性PrintVisibility</summary>
		[DispId(19)]
		ElementVisibility PrintVisibility
		{
			get;
			set;
		}

		/// <summary>属性ViewIndex</summary>
		[DispId(14)]
		int ViewIndex
		{
			get;
		}

		/// <summary>属性Width</summary>
		[DispId(15)]
		float Width
		{
			get;
			set;
		}

		/// <summary>方法GetAttribute</summary>
		[DispId(2)]
		string GetAttribute(string name);

		/// <summary>方法GetXMLFragment</summary>
		[DispId(20)]
		string GetXMLFragment();

		/// <summary>方法HasAttribute</summary>
		[DispId(3)]
		bool HasAttribute(string name);

		/// <summary>方法SetAttribute</summary>
		[DispId(4)]
		bool SetAttribute(string name, string Value);
	}
}
