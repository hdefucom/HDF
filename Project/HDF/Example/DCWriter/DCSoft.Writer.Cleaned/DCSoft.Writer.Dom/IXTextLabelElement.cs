using DCSoft.Common;
using DCSoft.Drawing;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextLabelElement 的COM接口</summary>
	[Guid("AB8B3F31-C36E-4EF5-8A73-84397555E16C")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	public interface IXTextLabelElement
	{
		/// <summary>属性Alignment</summary>
		[DispId(12)]
		DCContentAlignment Alignment
		{
			get;
			set;
		}

		/// <summary>属性AttributeNameForContactAction</summary>
		[DispId(51)]
		string AttributeNameForContactAction
		{
			get;
			set;
		}

		/// <summary>属性Attributes</summary>
		[DispId(13)]
		XAttributeList Attributes
		{
			get;
			set;
		}

		/// <summary>属性AutoSize</summary>
		[DispId(14)]
		bool AutoSize
		{
			get;
			set;
		}

		/// <summary>属性ColumnIndex</summary>
		[DispId(15)]
		int ColumnIndex
		{
			get;
		}

		/// <summary>属性ContactAction</summary>
		[DispId(62)]
		LabelTextContactActionMode ContactAction
		{
			get;
			set;
		}

		/// <summary>属性Deleteable</summary>
		[DispId(43)]
		bool Deleteable
		{
			get;
			set;
		}

		/// <summary>属性DocumentContentElement</summary>
		[DispId(16)]
		XTextDocumentContentElement DocumentContentElement
		{
			get;
		}

		/// <summary>属性EditorSize</summary>
		[DispId(17)]
		SizeF EditorSize
		{
			get;
			set;
		}

		/// <summary>属性Enabled</summary>
		[DispId(52)]
		bool Enabled
		{
			get;
			set;
		}

		/// <summary>属性Events</summary>
		[DispId(18)]
		ElementEventTemplateList Events
		{
			get;
		}

		/// <summary>属性EventTemplateName</summary>
		[DispId(19)]
		string EventTemplateName
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

		/// <summary>属性ID</summary>
		[DispId(22)]
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
		[DispId(53)]
		string InnerXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性LinkInfo</summary>
		[DispId(48)]
		HyperlinkInfo LinkInfo
		{
			get;
			set;
		}

		/// <summary>属性LinkTextForContactAction</summary>
		[DispId(54)]
		string LinkTextForContactAction
		{
			get;
			set;
		}

		/// <summary>属性Multiline</summary>
		[DispId(23)]
		bool Multiline
		{
			get;
			set;
		}

		/// <summary>属性Name</summary>
		[DispId(24)]
		string Name
		{
			get;
			set;
		}

		/// <summary>属性NextElement</summary>
		[DispId(25)]
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
		[DispId(55)]
		string OuterXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性OwnerCell</summary>
		[DispId(26)]
		XTextTableCellElement OwnerCell
		{
			get;
		}

		/// <summary>属性OwnerDocument</summary>
		[DispId(27)]
		XTextDocument OwnerDocument
		{
			get;
			set;
		}

		/// <summary>属性OwnerLine</summary>
		[DispId(28)]
		XTextLine OwnerLine
		{
			get;
			set;
		}

		/// <summary>属性OwnerPageIndex</summary>
		[DispId(29)]
		int OwnerPageIndex
		{
			get;
		}

		/// <summary>属性OwnerPagePartyStyle</summary>
		[DispId(56)]
		PageContentPartyStyle OwnerPagePartyStyle
		{
			get;
		}

		/// <summary>属性OwnerSection</summary>
		[DispId(30)]
		XTextSectionElement OwnerSection
		{
			get;
		}

		/// <summary>属性PageTexts</summary>
		[DispId(44)]
		PageLabelTextList PageTexts
		{
			get;
			set;
		}

		/// <summary>属性Parent</summary>
		[DispId(31)]
		XTextContainerElement Parent
		{
			get;
			set;
		}

		/// <summary>属性PixelHeight</summary>
		[DispId(63)]
		float PixelHeight
		{
			get;
			set;
		}

		/// <summary>属性PixelWidth</summary>
		[DispId(64)]
		float PixelWidth
		{
			get;
			set;
		}

		/// <summary>属性PreviousElement</summary>
		[DispId(32)]
		XTextElement PreviousElement
		{
			get;
		}

		/// <summary>属性PrintVisibility</summary>
		[DispId(59)]
		ElementVisibility PrintVisibility
		{
			get;
			set;
		}

		/// <summary>属性PropertyExpressions</summary>
		[DispId(65)]
		PropertyExpressionInfoList PropertyExpressions
		{
			get;
			set;
		}

		/// <summary>属性StrictMatchPageIndex</summary>
		[DispId(58)]
		bool StrictMatchPageIndex
		{
			get;
			set;
		}

		/// <summary>属性Style</summary>
		[DispId(33)]
		DocumentContentStyle Style
		{
			get;
			set;
		}

		/// <summary>属性StyleIndex</summary>
		[DispId(34)]
		int StyleIndex
		{
			get;
			set;
		}

		/// <summary>属性Text</summary>
		[DispId(35)]
		string Text
		{
			get;
			set;
		}

		/// <summary>属性TypeName</summary>
		[DispId(36)]
		string TypeName
		{
			get;
		}

		/// <summary>属性UserFlags</summary>
		[DispId(41)]
		int UserFlags
		{
			get;
			set;
		}

		/// <summary>属性ValueExpression</summary>
		[DispId(45)]
		string ValueExpression
		{
			get;
			set;
		}

		/// <summary>属性ViewIndex</summary>
		[DispId(37)]
		int ViewIndex
		{
			get;
		}

		/// <summary>属性Width</summary>
		[DispId(38)]
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
		[DispId(4)]
		void EditorRefreshView();

		/// <summary>方法EditorSetSize</summary>
		[DispId(5)]
		bool EditorSetSize(float width, float height, bool updateView, bool logUndo);

		/// <summary>方法EditorSetStyle</summary>
		[DispId(60)]
		bool EditorSetStyle(DocumentContentStyle style);

		/// <summary>方法EditorSetVisible</summary>
		[DispId(6)]
		bool EditorSetVisible(bool visible);

		/// <summary>方法EditorSetVisibleExt</summary>
		[DispId(7)]
		bool EditorSetVisibleExt(bool visible, bool logUndo, bool fastMode);

		/// <summary>方法EndSetStyle</summary>
		[DispId(8)]
		bool EndSetStyle();

		/// <summary>方法Focus</summary>
		[DispId(9)]
		void Focus();

		/// <summary>方法GetAttribute</summary>
		[DispId(39)]
		string GetAttribute(string name);

		/// <summary>方法GetXMLFragment</summary>
		[DispId(61)]
		string GetXMLFragment();

		/// <summary>方法HasAttribute</summary>
		[DispId(46)]
		bool HasAttribute(string name);

		/// <summary>方法InvalidateView</summary>
		[DispId(10)]
		void InvalidateView();

		/// <summary>方法PBGetAttribute</summary>
		[DispId(66)]
		string PBGetAttribute(ref string name);

		/// <summary>方法PBSetAttribute</summary>
		[DispId(67)]
		bool PBSetAttribute(ref string name, ref string string_0);

		/// <summary>方法Select</summary>
		[DispId(11)]
		bool Select();

		/// <summary>方法SetAttribute</summary>
		[DispId(40)]
		bool SetAttribute(string name, string Value);

		/// <summary>方法SetPageLabelText</summary>
		[DispId(42)]
		void SetPageLabelText(int pageIndex, string text);

		/// <summary>方法UpdateContactAction</summary>
		[DispId(50)]
		bool UpdateContactAction();
	}
}
