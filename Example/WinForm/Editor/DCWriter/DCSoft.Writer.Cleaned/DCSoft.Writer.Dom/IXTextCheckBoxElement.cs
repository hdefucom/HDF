using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Writer.Data;
using DCSoft.Writer.Expression;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextCheckBoxElement 的COM接口</summary>
	[Browsable(false)]
	[Guid("B66A5465-A0A1-4766-BEB8-2C42080D1916")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IXTextCheckBoxElement
	{
		/// <summary>属性Attributes</summary>
		[DispId(9)]
		XAttributeList Attributes
		{
			get;
			set;
		}

		/// <summary>属性Caption</summary>
		[DispId(10)]
		string Caption
		{
			get;
			set;
		}

		/// <summary>属性CaptionAlign</summary>
		[DispId(64)]
		StringAlignment CaptionAlign
		{
			get;
			set;
		}

		/// <summary>属性CheckAlignLeft</summary>
		[DispId(39)]
		bool CheckAlignLeft
		{
			get;
			set;
		}

		/// <summary>属性CheckboxVisibility</summary>
		[DispId(65)]
		RenderVisibility CheckboxVisibility
		{
			get;
			set;
		}

		/// <summary>属性Checked</summary>
		[DispId(11)]
		bool Checked
		{
			get;
			set;
		}

		/// <summary>属性CheckedValue</summary>
		[DispId(12)]
		string CheckedValue
		{
			get;
			set;
		}

		/// <summary>属性ControlStyle</summary>
		[DispId(13)]
		CheckBoxControlStyle ControlStyle
		{
			get;
			set;
		}

		/// <summary>属性DataName</summary>
		[DispId(66)]
		string DataName
		{
			get;
			set;
		}

		/// <summary>属性Deleteable</summary>
		[DispId(14)]
		bool Deleteable
		{
			get;
			set;
		}

		/// <summary>属性EditorChecked</summary>
		[DispId(15)]
		bool EditorChecked
		{
			get;
			set;
		}

		/// <summary>属性ElementIndex</summary>
		[DispId(44)]
		int ElementIndex
		{
			get;
			set;
		}

		/// <summary>属性Enabled</summary>
		[DispId(43)]
		bool Enabled
		{
			get;
			set;
		}

		/// <summary>属性EventExpressions</summary>
		[DispId(17)]
		EventExpressionInfoList EventExpressions
		{
			get;
			set;
		}

		/// <summary>属性EventTemplateName</summary>
		[DispId(18)]
		string EventTemplateName
		{
			get;
			set;
		}

		/// <summary>属性Focused</summary>
		[DispId(19)]
		bool Focused
		{
			get;
		}

		/// <summary>属性GroupName</summary>
		[DispId(20)]
		string GroupName
		{
			get;
			set;
		}

		/// <summary>属性ID</summary>
		[DispId(21)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性InnerXML</summary>
		[DispId(49)]
		string InnerXML
		{
			get;
		}

		/// <summary>属性InnerXMLWithoutTrack</summary>
		[DispId(50)]
		string InnerXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性LinkInfo</summary>
		[DispId(51)]
		HyperlinkInfo LinkInfo
		{
			get;
			set;
		}

		/// <summary>属性Modified</summary>
		[DispId(41)]
		bool Modified
		{
			get;
			set;
		}

		/// <summary>属性Multiline</summary>
		[DispId(45)]
		bool Multiline
		{
			get;
			set;
		}

		/// <summary>属性Name</summary>
		[DispId(22)]
		string Name
		{
			get;
			set;
		}

		/// <summary>属性NextElement</summary>
		[DispId(23)]
		XTextElement NextElement
		{
			get;
		}

		/// <summary>属性OuterXML</summary>
		[DispId(52)]
		string OuterXML
		{
			get;
		}

		/// <summary>属性OuterXMLWithoutTrack</summary>
		[DispId(53)]
		string OuterXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性OwnerCell</summary>
		[DispId(24)]
		XTextTableCellElement OwnerCell
		{
			get;
		}

		/// <summary>属性OwnerDocument</summary>
		[DispId(25)]
		XTextDocument OwnerDocument
		{
			get;
			set;
		}

		/// <summary>属性OwnerLine</summary>
		[DispId(26)]
		XTextLine OwnerLine
		{
			get;
			set;
		}

		/// <summary>属性OwnerPageIndex</summary>
		[DispId(27)]
		int OwnerPageIndex
		{
			get;
		}

		/// <summary>属性OwnerPagePartyStyle</summary>
		[DispId(59)]
		PageContentPartyStyle OwnerPagePartyStyle
		{
			get;
		}

		/// <summary>属性OwnerParagraphEOF</summary>
		[DispId(54)]
		XTextParagraphFlagElement OwnerParagraphEOF
		{
			get;
		}

		/// <summary>属性OwnerSection</summary>
		[DispId(28)]
		XTextSectionElement OwnerSection
		{
			get;
		}

		/// <summary>属性Parent</summary>
		[DispId(29)]
		XTextContainerElement Parent
		{
			get;
			set;
		}

		/// <summary>属性PreviousElement</summary>
		[DispId(30)]
		XTextElement PreviousElement
		{
			get;
		}

		/// <summary>属性PrintBoxOnlyChecked</summary>
		[DispId(56)]
		bool PrintBoxOnlyChecked
		{
			get;
			set;
		}

		/// <summary>属性PrintTextForChecked</summary>
		[DispId(57)]
		string PrintTextForChecked
		{
			get;
			set;
		}

		/// <summary>属性PrintTextForUnChecked</summary>
		[DispId(58)]
		string PrintTextForUnChecked
		{
			get;
			set;
		}

		/// <summary>属性PrintVisibility</summary>
		[DispId(61)]
		ElementVisibility PrintVisibility
		{
			get;
			set;
		}

		/// <summary>属性PrintVisibilityWhenUnchecked</summary>
		[DispId(63)]
		PrintVisibilityModeWhenUnchecked PrintVisibilityWhenUnchecked
		{
			get;
			set;
		}

		/// <summary>属性PropertyExpressions</summary>
		[DispId(62)]
		PropertyExpressionInfoList PropertyExpressions
		{
			get;
			set;
		}

		/// <summary>属性Readonly</summary>
		[DispId(31)]
		bool Readonly
		{
			get;
			set;
		}

		/// <summary>属性StringTag</summary>
		[DispId(69)]
		string StringTag
		{
			get;
			set;
		}

		/// <summary>属性Style</summary>
		[DispId(32)]
		DocumentContentStyle Style
		{
			get;
			set;
		}

		/// <summary>属性ToolTip</summary>
		[DispId(47)]
		string ToolTip
		{
			get;
			set;
		}

		/// <summary>属性UnCheckedValue</summary>
		[DispId(33)]
		string UnCheckedValue
		{
			get;
			set;
		}

		/// <summary>属性UserFlags</summary>
		[DispId(40)]
		int UserFlags
		{
			get;
			set;
		}

		/// <summary>属性Value</summary>
		[DispId(34)]
		string Value
		{
			get;
			set;
		}

		/// <summary>属性ValueBinding</summary>
		[DispId(35)]
		XDataBinding ValueBinding
		{
			get;
			set;
		}

		/// <summary>属性ValueExpression</summary>
		[DispId(60)]
		string ValueExpression
		{
			get;
			set;
		}

		/// <summary>属性ViewIndex</summary>
		[DispId(36)]
		int ViewIndex
		{
			get;
		}

		/// <summary>属性VisualStyle</summary>
		[DispId(46)]
		CheckBoxVisualStyle VisualStyle
		{
			get;
			set;
		}

		/// <summary>属性Width</summary>
		[DispId(70)]
		float Width
		{
			get;
			set;
		}

		/// <summary>方法BeginSetStyle</summary>
		[DispId(2)]
		bool BeginSetStyle();

		/// <summary>方法EditorRefreshView</summary>
		[DispId(3)]
		void EditorRefreshView();

		/// <summary>方法EditorSetVisible</summary>
		[DispId(4)]
		bool EditorSetVisible(bool visible);

		/// <summary>方法EditorSetVisibleExt</summary>
		[DispId(5)]
		bool EditorSetVisibleExt(bool visible, bool logUndo, bool fastMode);

		/// <summary>方法EndSetStyle</summary>
		[DispId(6)]
		bool EndSetStyle();

		/// <summary>方法Focus</summary>
		[DispId(7)]
		void Focus();

		/// <summary>方法GetAttribute</summary>
		[DispId(37)]
		string GetAttribute(string name);

		/// <summary>方法GetXMLFragment</summary>
		[DispId(48)]
		string GetXMLFragment();

		/// <summary>方法HasAttribute</summary>
		[DispId(42)]
		bool HasAttribute(string name);

		/// <summary>方法PBGetAttribute</summary>
		[DispId(67)]
		string PBGetAttribute(ref string name);

		/// <summary>方法PBSetAttribute</summary>
		[DispId(68)]
		bool PBSetAttribute(ref string name, ref string string_0);

		/// <summary>方法Select</summary>
		[DispId(8)]
		bool Select();

		/// <summary>方法SetAttribute</summary>
		[DispId(38)]
		bool SetAttribute(string name, string Value);
	}
}
