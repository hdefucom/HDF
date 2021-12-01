using DCSoft.Drawing;
using DCSoft.WinForms;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextControlHostElement 的COM接口</summary>
	[Guid("280EF940-4858-4348-800F-C4FEF1D2BD00")]
	[Browsable(false)]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IXTextControlHostElement
	{
		/// <summary>属性Attributes</summary>
		[DispId(13)]
		XAttributeList Attributes
		{
			get;
			set;
		}

		/// <summary>属性ControlType</summary>
		[DispId(16)]
		HostedControlType ControlType
		{
			get;
			set;
		}

		/// <summary>属性Deleteable</summary>
		[DispId(18)]
		bool Deleteable
		{
			get;
			set;
		}

		/// <summary>属性Enabled</summary>
		[DispId(19)]
		bool Enabled
		{
			get;
			set;
		}

		/// <summary>属性Focused</summary>
		[DispId(20)]
		bool Focused
		{
			get;
		}

		/// <summary>属性Height</summary>
		[DispId(21)]
		float Height
		{
			get;
			set;
		}

		/// <summary>属性HostedInstance</summary>
		[DispId(22)]
		object HostedInstance
		{
			get;
			set;
		}

		/// <summary>属性ID</summary>
		[DispId(23)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性InnerXML</summary>
		[DispId(47)]
		string InnerXML
		{
			get;
		}

		/// <summary>属性InnerXMLWithoutTrack</summary>
		[DispId(48)]
		string InnerXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性Name</summary>
		[DispId(25)]
		string Name
		{
			get;
			set;
		}

		/// <summary>属性NextElement</summary>
		[DispId(26)]
		XTextElement NextElement
		{
			get;
		}

		/// <summary>属性OuterXML</summary>
		[DispId(49)]
		string OuterXML
		{
			get;
		}

		/// <summary>属性OuterXMLWithoutTrack</summary>
		[DispId(50)]
		string OuterXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性OwnerCell</summary>
		[DispId(27)]
		XTextTableCellElement OwnerCell
		{
			get;
		}

		/// <summary>属性OwnerDocument</summary>
		[DispId(28)]
		XTextDocument OwnerDocument
		{
			get;
			set;
		}

		/// <summary>属性OwnerLine</summary>
		[DispId(29)]
		XTextLine OwnerLine
		{
			get;
			set;
		}

		/// <summary>属性OwnerPageIndex</summary>
		[DispId(30)]
		int OwnerPageIndex
		{
			get;
		}

		/// <summary>属性OwnerPagePartyStyle</summary>
		[DispId(51)]
		PageContentPartyStyle OwnerPagePartyStyle
		{
			get;
		}

		/// <summary>属性OwnerSection</summary>
		[DispId(31)]
		XTextSectionElement OwnerSection
		{
			get;
		}

		/// <summary>属性Parameters</summary>
		[DispId(32)]
		ObjectParameterList Parameters
		{
			get;
			set;
		}

		/// <summary>属性Parent</summary>
		[DispId(33)]
		XTextContainerElement Parent
		{
			get;
			set;
		}

		/// <summary>属性PixelHeight</summary>
		[DispId(55)]
		float PixelHeight
		{
			get;
			set;
		}

		/// <summary>属性PixelWidth</summary>
		[DispId(56)]
		float PixelWidth
		{
			get;
			set;
		}

		/// <summary>属性PreviousElement</summary>
		[DispId(34)]
		XTextElement PreviousElement
		{
			get;
		}

		/// <summary>属性Printable</summary>
		[DispId(52)]
		bool Printable
		{
			get;
			set;
		}

		/// <summary>属性PrintVisibility</summary>
		[DispId(54)]
		ElementVisibility PrintVisibility
		{
			get;
			set;
		}

		/// <summary>属性Resizeable</summary>
		[DispId(36)]
		ResizeableType Resizeable
		{
			get;
			set;
		}

		/// <summary>属性Style</summary>
		[DispId(37)]
		DocumentContentStyle Style
		{
			get;
			set;
		}

		/// <summary>属性TypeFullName</summary>
		[DispId(38)]
		string TypeFullName
		{
			get;
			set;
		}

		/// <summary>属性TypeName</summary>
		[DispId(39)]
		string TypeName
		{
			get;
		}

		/// <summary>属性UserFlags</summary>
		[DispId(53)]
		int UserFlags
		{
			get;
			set;
		}

		/// <summary>属性ViewIndex</summary>
		[DispId(40)]
		int ViewIndex
		{
			get;
		}

		/// <summary>属性Width</summary>
		[DispId(41)]
		float Width
		{
			get;
			set;
		}

		/// <summary>方法BeginSetStyle</summary>
		[DispId(2)]
		bool BeginSetStyle();

		/// <summary>方法CreateContentDocument</summary>
		[DispId(3)]
		XTextDocument CreateContentDocument(bool includeThis);

		/// <summary>方法EditorRefreshView</summary>
		[DispId(5)]
		void EditorRefreshView();

		/// <summary>方法EditorSetSize</summary>
		[DispId(7)]
		bool EditorSetSize(float width, float height, bool updateView, bool logUndo);

		/// <summary>方法EditorSetVisible</summary>
		[DispId(8)]
		bool EditorSetVisible(bool visible);

		/// <summary>方法EditorSetVisibleExt</summary>
		[DispId(9)]
		bool EditorSetVisibleExt(bool visible, bool logUndo, bool fastMode);

		/// <summary>方法EndSetStyle</summary>
		[DispId(10)]
		bool EndSetStyle();

		/// <summary>方法Focus</summary>
		[DispId(11)]
		void Focus();

		/// <summary>方法GetAttribute</summary>
		[DispId(42)]
		string GetAttribute(string name);

		/// <summary>方法GetXMLFragment</summary>
		[DispId(43)]
		string GetXMLFragment();

		/// <summary>方法HasAttribute</summary>
		[DispId(44)]
		bool HasAttribute(string name);

		/// <summary>方法Select</summary>
		[DispId(12)]
		bool Select();

		/// <summary>方法SetAttribute</summary>
		[DispId(45)]
		bool SetAttribute(string name, string Value);

		/// <summary>方法SetNativeHostedControlHandle</summary>
		[DispId(46)]
		bool SetNativeHostedControlHandle(IntPtr handle);
	}
}
