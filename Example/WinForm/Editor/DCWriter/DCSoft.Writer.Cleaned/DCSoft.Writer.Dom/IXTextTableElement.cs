using DCSoft.Drawing;
using DCSoft.Writer.Script;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextTableElement 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[ComVisible(true)]
	[Guid("56FB6F65-8B16-36B3-854B-A69FF648795D")]
	public interface IXTextTableElement
	{
		/// <summary>属性AbsTop</summary>
		[DispId(96)]
		float AbsTop
		{
			get;
		}

		/// <summary>属性AllowUserDeleteRow</summary>
		[DispId(88)]
		bool AllowUserDeleteRow
		{
			get;
			set;
		}

		/// <summary>属性AllowUserInsertRow</summary>
		[DispId(89)]
		bool AllowUserInsertRow
		{
			get;
			set;
		}

		/// <summary>属性AllowUserToResizeColumns</summary>
		[DispId(61)]
		bool AllowUserToResizeColumns
		{
			get;
			set;
		}

		/// <summary>属性AllowUserToResizeEvenInFormViewMode</summary>
		[DispId(90)]
		bool AllowUserToResizeEvenInFormViewMode
		{
			get;
			set;
		}

		/// <summary>属性AllowUserToResizeRows</summary>
		[DispId(62)]
		bool AllowUserToResizeRows
		{
			get;
			set;
		}

		/// <summary>属性Attributes</summary>
		[DispId(12)]
		XAttributeList Attributes
		{
			get;
			set;
		}

		/// <summary>属性Cells</summary>
		[DispId(15)]
		XTextElementList Cells
		{
			get;
		}

		/// <summary>属性Columns</summary>
		[DispId(16)]
		XTextElementList Columns
		{
			get;
			set;
		}

		/// <summary>属性ContentLock</summary>
		[DispId(87)]
		DCContentLockInfo ContentLock
		{
			get;
			set;
		}

		/// <summary>属性ContentReadonly</summary>
		[DispId(51)]
		ContentReadonlyState ContentReadonly
		{
			get;
			set;
		}

		/// <summary>属性ContentVersion</summary>
		[DispId(17)]
		int ContentVersion
		{
			get;
		}

		/// <summary>属性Deleteable</summary>
		[DispId(63)]
		bool Deleteable
		{
			get;
			set;
		}

		/// <summary>属性DocumentContentElement</summary>
		[DispId(18)]
		XTextDocumentContentElement DocumentContentElement
		{
			get;
		}

		/// <summary>属性ElementIndex</summary>
		[DispId(69)]
		int ElementIndex
		{
			get;
			set;
		}

		/// <summary>属性ElementsCount</summary>
		[DispId(76)]
		int ElementsCount
		{
			get;
		}

		/// <summary>属性EnablePermission</summary>
		[DispId(64)]
		DCBooleanValue EnablePermission
		{
			get;
			set;
		}

		/// <summary>属性EnableValueValidate</summary>
		[DispId(77)]
		bool EnableValueValidate
		{
			get;
			set;
		}

		/// <summary>属性EventTemplateName</summary>
		[DispId(20)]
		string EventTemplateName
		{
			get;
			set;
		}

		/// <summary>属性FirstCell</summary>
		[DispId(22)]
		XTextTableCellElement FirstCell
		{
			get;
		}

		/// <summary>属性FirstChild</summary>
		[DispId(91)]
		XTextElement FirstChild
		{
			get;
		}

		/// <summary>属性FirstContentElement</summary>
		[DispId(23)]
		XTextElement FirstContentElement
		{
			get;
		}

		/// <summary>属性Focused</summary>
		[DispId(24)]
		bool Focused
		{
			get;
		}

		/// <summary>属性HasHeaderRow</summary>
		[DispId(25)]
		bool HasHeaderRow
		{
			get;
		}

		/// <summary>属性HasSelection</summary>
		[DispId(26)]
		bool HasSelection
		{
			get;
		}

		/// <summary>属性HeaderRows</summary>
		[DispId(27)]
		XTextElementList HeaderRows
		{
			get;
		}

		/// <summary>属性Height</summary>
		[DispId(28)]
		float Height
		{
			get;
			set;
		}

		/// <summary>属性ID</summary>
		[DispId(29)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性InnerXML</summary>
		[DispId(83)]
		string InnerXML
		{
			get;
		}

		/// <summary>属性InnerXMLWithoutTrack</summary>
		[DispId(92)]
		string InnerXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性LastCell</summary>
		[DispId(30)]
		XTextTableCellElement LastCell
		{
			get;
		}

		/// <summary>属性LastChild</summary>
		[DispId(93)]
		XTextElement LastChild
		{
			get;
		}

		/// <summary>属性LastContentElement</summary>
		[DispId(31)]
		XTextElement LastContentElement
		{
			get;
		}

		/// <summary>属性LastVisibleCell</summary>
		[DispId(58)]
		XTextTableCellElement LastVisibleCell
		{
			get;
		}

		/// <summary>属性Modified</summary>
		[DispId(66)]
		bool Modified
		{
			get;
			set;
		}

		/// <summary>属性NeastLevel</summary>
		[DispId(32)]
		int NeastLevel
		{
			get;
		}

		/// <summary>属性NextElement</summary>
		[DispId(33)]
		XTextElement NextElement
		{
			get;
		}

		/// <summary>属性NumOfColumns</summary>
		[DispId(34)]
		int NumOfColumns
		{
			get;
			set;
		}

		/// <summary>属性NumOfRows</summary>
		[DispId(35)]
		int NumOfRows
		{
			get;
			set;
		}

		/// <summary>属性OuterXML</summary>
		[DispId(84)]
		string OuterXML
		{
			get;
		}

		/// <summary>属性OuterXMLWithoutTrack</summary>
		[DispId(94)]
		string OuterXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性OwnerCell</summary>
		[DispId(36)]
		XTextTableCellElement OwnerCell
		{
			get;
		}

		/// <summary>属性OwnerDocument</summary>
		[DispId(37)]
		XTextDocument OwnerDocument
		{
			get;
			set;
		}

		/// <summary>属性OwnerLine</summary>
		[DispId(38)]
		XTextLine OwnerLine
		{
			get;
			set;
		}

		/// <summary>属性OwnerPageIndex</summary>
		[DispId(39)]
		int OwnerPageIndex
		{
			get;
		}

		/// <summary>属性OwnerPagePartyStyle</summary>
		[DispId(95)]
		PageContentPartyStyle OwnerPagePartyStyle
		{
			get;
		}

		/// <summary>属性OwnerSection</summary>
		[DispId(40)]
		XTextSectionElement OwnerSection
		{
			get;
		}

		/// <summary>属性Parent</summary>
		[DispId(41)]
		XTextContainerElement Parent
		{
			get;
			set;
		}

		/// <summary>属性PreviousElement</summary>
		[DispId(42)]
		XTextElement PreviousElement
		{
			get;
		}

		/// <summary>属性PrintVisibility</summary>
		[DispId(107)]
		ElementVisibility PrintVisibility
		{
			get;
			set;
		}

		/// <summary>属性Rows</summary>
		[DispId(43)]
		XTextElementList Rows
		{
			get;
			set;
		}

		/// <summary>属性RowsCount</summary>
		[DispId(78)]
		int RowsCount
		{
			get;
		}

		/// <summary>属性RuntimeStyle</summary>
		[DispId(44)]
		RuntimeDocumentContentStyle RuntimeStyle
		{
			get;
		}

		/// <summary>属性ScriptItems</summary>
		[DispId(45)]
		VBScriptItemList ScriptItems
		{
			get;
			set;
		}

		/// <summary>属性ShowCellNoneBorder</summary>
		[DispId(97)]
		DCBooleanValue ShowCellNoneBorder
		{
			get;
			set;
		}

		/// <summary>属性Style</summary>
		[DispId(46)]
		DocumentContentStyle Style
		{
			get;
			set;
		}

		/// <summary>属性StyleIndex</summary>
		[DispId(79)]
		int StyleIndex
		{
			get;
			set;
		}

		/// <summary>属性SubfieldMode</summary>
		[DispId(101)]
		TableSubfieldMode SubfieldMode
		{
			get;
			set;
		}

		/// <summary>属性SubfieldNumber</summary>
		[DispId(102)]
		int SubfieldNumber
		{
			get;
			set;
		}

		/// <summary>属性TableWidth</summary>
		[DispId(47)]
		float TableWidth
		{
			get;
		}

		/// <summary>属性ToolTip</summary>
		[DispId(98)]
		string ToolTip
		{
			get;
			set;
		}

		/// <summary>属性TypeName</summary>
		[DispId(48)]
		string TypeName
		{
			get;
		}

		/// <summary>属性UserFlags</summary>
		[DispId(59)]
		int UserFlags
		{
			get;
			set;
		}

		/// <summary>属性Visible</summary>
		[DispId(49)]
		bool Visible
		{
			get;
			set;
		}

		/// <summary>属性VisibleExpression</summary>
		[DispId(68)]
		string VisibleExpression
		{
			get;
			set;
		}

		/// <summary>属性Width</summary>
		[DispId(50)]
		float Width
		{
			get;
			set;
		}

		/// <summary>方法BeginSetStyle</summary>
		[DispId(2)]
		bool BeginSetStyle();

		/// <summary>方法CommitUserTrace</summary>
		[DispId(70)]
		bool CommitUserTrace();

		/// <summary>方法CreateContentDocument</summary>
		[DispId(3)]
		XTextDocument CreateContentDocument(bool includeThis);

		/// <summary>方法EditorDelete</summary>
		[DispId(4)]
		bool EditorDelete(bool logUndo);

		/// <summary>方法EditorRefreshView</summary>
		[DispId(5)]
		void EditorRefreshView();

		/// <summary>方法EditorSetContentStyle</summary>
		[DispId(52)]
		void EditorSetContentStyle(DocumentContentStyle newStyle, bool logUndo);

		/// <summary>方法EditorSetContentStyleFast</summary>
		[DispId(53)]
		bool EditorSetContentStyleFast(DocumentContentStyle newStyle);

		/// <summary>方法EditorSetStyle</summary>
		[DispId(105)]
		bool EditorSetStyle(DocumentContentStyle style);

		/// <summary>方法EditorSetStyleDeeply</summary>
		[DispId(106)]
		bool EditorSetStyleDeeply(DocumentContentStyle style);

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

		/// <summary>方法GetAllElements</summary>
		[DispId(60)]
		XTextElementList GetAllElements();

		/// <summary>方法GetAllElementsWithoutCharElement</summary>
		[DispId(65)]
		XTextElementList GetAllElementsWithoutCharElement();

		/// <summary>方法GetAttribute</summary>
		[DispId(54)]
		string GetAttribute(string name);

		/// <summary>方法GetCellByCellIndex</summary>
		[DispId(72)]
		XTextTableCellElement GetCellByCellIndex(string strCellIndex, bool throwException);

		/// <summary>方法GetCellText</summary>
		[DispId(81)]
		string GetCellText(int rowIndex, int colIndex, bool throwException);

		/// <summary>方法GetCellTextByCellIndex</summary>
		[DispId(82)]
		string GetCellTextByCellIndex(string strCellIndex, bool throwException);

		/// <summary>方法GetElementById</summary>
		[DispId(73)]
		XTextElement GetElementById(string string_0);

		/// <summary>方法GetElementsById</summary>
		[DispId(74)]
		XTextElementList GetElementsById(string string_0);

		/// <summary>方法GetElementsByName</summary>
		[DispId(75)]
		XTextElementList GetElementsByName(string name);

		/// <summary>方法GetElementsByTypeName</summary>
		[DispId(55)]
		XTextElementList GetElementsByTypeName(string elementTypeName);

		/// <summary>方法GetFirstElementByTypeName</summary>
		[DispId(56)]
		XTextElement GetFirstElementByTypeName(string elementTypeName);

		/// <summary>方法HasAttribute</summary>
		[DispId(67)]
		bool HasAttribute(string name);

		/// <summary>方法InvalidateView</summary>
		[DispId(10)]
		void InvalidateView();

		/// <summary>方法PBGetAttribute</summary>
		[DispId(103)]
		string PBGetAttribute(ref string name);

		/// <summary>方法PBSetAttribute</summary>
		[DispId(104)]
		bool PBSetAttribute(ref string name, ref string string_0);

		/// <summary>方法Select</summary>
		[DispId(11)]
		bool Select();

		/// <summary>方法SetAttribute</summary>
		[DispId(57)]
		bool SetAttribute(string name, string Value);

		/// <summary>方法SetContentLock</summary>
		[DispId(85)]
		bool SetContentLock(string userID, string authoriseUserIDList, bool logUndo);

		/// <summary>方法SetContentLockByCurrentUser</summary>
		[DispId(86)]
		bool SetContentLockByCurrentUser();

		/// <summary>方法Subfield</summary>
		[DispId(99)]
		bool Subfield(bool updateView);

		/// <summary>方法SubfieldSpecify</summary>
		[DispId(100)]
		bool SubfieldSpecify(TableSubfieldMode mode, int number, bool updateView);
	}
}
