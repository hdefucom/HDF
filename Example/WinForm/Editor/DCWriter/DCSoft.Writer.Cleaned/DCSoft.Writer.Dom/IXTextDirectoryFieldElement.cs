using DCSoft.Drawing;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextDirectoryFieldElement 的COM接口</summary>
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("1E1D65E3-591F-47D7-9172-DC10BF3119A5")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	public interface IXTextDirectoryFieldElement
	{
		/// <summary>属性Alignment</summary>
		[DispId(5)]
		StringAlignment Alignment
		{
			get;
			set;
		}

		/// <summary>属性ID</summary>
		[DispId(6)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性InnerXML</summary>
		[DispId(7)]
		string InnerXML
		{
			get;
		}

		/// <summary>属性InnerXMLWithoutTrack</summary>
		[DispId(8)]
		string InnerXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性Modified</summary>
		[DispId(9)]
		bool Modified
		{
			get;
			set;
		}

		/// <summary>属性NextElement</summary>
		[DispId(10)]
		XTextElement NextElement
		{
			get;
		}

		/// <summary>属性OuterXML</summary>
		[DispId(11)]
		string OuterXML
		{
			get;
		}

		/// <summary>属性OuterXMLWithoutTrack</summary>
		[DispId(12)]
		string OuterXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性OwnerPagePartyStyle</summary>
		[DispId(13)]
		PageContentPartyStyle OwnerPagePartyStyle
		{
			get;
		}

		/// <summary>属性Parent</summary>
		[DispId(14)]
		XTextContainerElement Parent
		{
			get;
			set;
		}

		/// <summary>属性PreviousElement</summary>
		[DispId(15)]
		XTextElement PreviousElement
		{
			get;
		}

		/// <summary>属性Visible</summary>
		[DispId(16)]
		bool Visible
		{
			get;
			set;
		}

		/// <summary>属性Width</summary>
		[DispId(17)]
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
