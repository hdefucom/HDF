using DCSoft.Writer.Data;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextTableRowElement 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[Browsable(false)]
	[Guid("CBD69042-B2BA-38CB-9480-49D68053C72D")]
	public interface IXTextTableRowElement
	{
		/// <summary>属性AbsTop</summary>
		[DispId(60)]
		float AbsTop
		{
			get;
		}

		/// <summary>属性AllowInsertRowDownUseHotKey</summary>
		[DispId(62)]
		DCInsertRowDownUseHotKeys AllowInsertRowDownUseHotKey
		{
			get;
			set;
		}

		/// <summary>属性AllowUserPressTabKeyToInsertRowDown</summary>
		[DispId(63)]
		bool AllowUserPressTabKeyToInsertRowDown
		{
			get;
			set;
		}

		/// <summary>属性AllowUserToResizeHeight</summary>
		[DispId(50)]
		DCBooleanValue AllowUserToResizeHeight
		{
			get;
			set;
		}

		/// <summary>属性Attributes</summary>
		[DispId(29)]
		XAttributeList Attributes
		{
			get;
			set;
		}

		/// <summary>属性Cells</summary>
		[DispId(12)]
		XTextElementList Cells
		{
			get;
			set;
		}

		/// <summary>属性CloneMultipleBaseForBindingDataSource</summary>
		[DispId(64)]
		int CloneMultipleBaseForBindingDataSource
		{
			get;
			set;
		}

		/// <summary>属性CloneType</summary>
		[DispId(13)]
		TableRowCloneType CloneType
		{
			get;
			set;
		}

		/// <summary>属性ContentLock</summary>
		[DispId(54)]
		DCContentLockInfo ContentLock
		{
			get;
			set;
		}

		/// <summary>属性ContentReadonly</summary>
		[DispId(30)]
		ContentReadonlyState ContentReadonly
		{
			get;
			set;
		}

		/// <summary>属性DataSourceRowSpan</summary>
		[DispId(65)]
		int DataSourceRowSpan
		{
			get;
			set;
		}

		/// <summary>属性ElementsCount</summary>
		[DispId(45)]
		int ElementsCount
		{
			get;
		}

		/// <summary>属性EnablePermission</summary>
		[DispId(38)]
		DCBooleanValue EnablePermission
		{
			get;
			set;
		}

		/// <summary>属性EnableValueValidate</summary>
		[DispId(51)]
		bool EnableValueValidate
		{
			get;
			set;
		}

		/// <summary>属性EventTemplateName</summary>
		[DispId(14)]
		string EventTemplateName
		{
			get;
			set;
		}

		/// <summary>属性ExpendForDataBinding</summary>
		[DispId(71)]
		bool ExpendForDataBinding
		{
			get;
			set;
		}

		/// <summary>属性FirstChild</summary>
		[DispId(55)]
		XTextElement FirstChild
		{
			get;
		}

		/// <summary>属性HeaderStyle</summary>
		[DispId(15)]
		bool HeaderStyle
		{
			get;
			set;
		}

		/// <summary>属性Height</summary>
		[DispId(16)]
		float Height
		{
			get;
			set;
		}

		/// <summary>属性ID</summary>
		[DispId(17)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性Index</summary>
		[DispId(18)]
		int Index
		{
			get;
		}

		/// <summary>属性InnerXML</summary>
		[DispId(48)]
		string InnerXML
		{
			get;
		}

		/// <summary>属性LastChild</summary>
		[DispId(56)]
		XTextElement LastChild
		{
			get;
		}

		/// <summary>属性MaxInputLength</summary>
		[DispId(66)]
		int MaxInputLength
		{
			get;
			set;
		}

		/// <summary>属性Modified</summary>
		[DispId(43)]
		bool Modified
		{
			get;
			set;
		}

		/// <summary>属性NewPage</summary>
		[DispId(57)]
		bool NewPage
		{
			get;
			set;
		}

		/// <summary>属性OuterXML</summary>
		[DispId(49)]
		string OuterXML
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

		/// <summary>属性OwnerLastPageIndex</summary>
		[DispId(69)]
		int OwnerLastPageIndex
		{
			get;
		}

		/// <summary>属性OwnerPageIndex</summary>
		[DispId(20)]
		int OwnerPageIndex
		{
			get;
		}

		/// <summary>属性OwnerSection</summary>
		[DispId(21)]
		XTextSectionElement OwnerSection
		{
			get;
		}

		/// <summary>属性OwnerTable</summary>
		[DispId(22)]
		XTextTableElement OwnerTable
		{
			get;
		}

		/// <summary>属性Parent</summary>
		[DispId(23)]
		XTextContainerElement Parent
		{
			get;
			set;
		}

		/// <summary>属性PreviousElement</summary>
		[DispId(24)]
		XTextElement PreviousElement
		{
			get;
		}

		/// <summary>属性PrintCellBackground</summary>
		[DispId(58)]
		bool PrintCellBackground
		{
			get;
			set;
		}

		/// <summary>属性PrintCellBorder</summary>
		[DispId(59)]
		bool PrintCellBorder
		{
			get;
			set;
		}

		/// <summary>属性PrintVisibility</summary>
		[DispId(72)]
		ElementVisibility PrintVisibility
		{
			get;
			set;
		}

		/// <summary>属性RowIndex</summary>
		[DispId(70)]
		int RowIndex
		{
			get;
		}

		/// <summary>属性SpecifyHeight</summary>
		[DispId(25)]
		float SpecifyHeight
		{
			get;
			set;
		}

		/// <summary>属性Style</summary>
		[DispId(26)]
		DocumentContentStyle Style
		{
			get;
			set;
		}

		/// <summary>属性ToolTip</summary>
		[DispId(61)]
		string ToolTip
		{
			get;
			set;
		}

		/// <summary>属性TypeName</summary>
		[DispId(27)]
		string TypeName
		{
			get;
		}

		/// <summary>属性UserFlags</summary>
		[DispId(37)]
		int UserFlags
		{
			get;
			set;
		}

		/// <summary>属性ValueBinding</summary>
		[DispId(46)]
		XDataBinding ValueBinding
		{
			get;
			set;
		}

		/// <summary>属性Visible</summary>
		[DispId(73)]
		bool Visible
		{
			get;
			set;
		}

		/// <summary>属性Width</summary>
		[DispId(28)]
		float Width
		{
			get;
			set;
		}

		/// <summary>方法BeginSetStyle</summary>
		[DispId(2)]
		bool BeginSetStyle();

		/// <summary>方法CommitUserTrace</summary>
		[DispId(47)]
		bool CommitUserTrace();

		/// <summary>方法CreateContentDocument</summary>
		[DispId(3)]
		XTextDocument CreateContentDocument(bool includeThis);

		/// <summary>方法EditorClone</summary>
		[DispId(4)]
		XTextTableRowElement EditorClone();

		/// <summary>方法EditorCloneSpecifyCloneType</summary>
		[DispId(39)]
		XTextTableRowElement EditorCloneSpecifyCloneType(TableRowCloneType cloneType);

		/// <summary>方法EditorDelete</summary>
		[DispId(40)]
		bool EditorDelete(bool logUndo);

		/// <summary>方法EditorRefreshView</summary>
		[DispId(5)]
		void EditorRefreshView();

		/// <summary>方法EditorSetContentStyle</summary>
		[DispId(31)]
		void EditorSetContentStyle(DocumentContentStyle newStyle, bool logUndo);

		/// <summary>方法EditorSetContentStyleFast</summary>
		[DispId(32)]
		bool EditorSetContentStyleFast(DocumentContentStyle newStyle);

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
		[DispId(41)]
		XTextElementList GetAllElements();

		/// <summary>方法GetAllElementsWithoutCharElement</summary>
		[DispId(42)]
		XTextElementList GetAllElementsWithoutCharElement();

		/// <summary>方法GetAttribute</summary>
		[DispId(33)]
		string GetAttribute(string name);

		/// <summary>方法GetElementsByTypeName</summary>
		[DispId(34)]
		XTextElementList GetElementsByTypeName(string elementTypeName);

		/// <summary>方法GetFirstElementByTypeName</summary>
		[DispId(35)]
		XTextElement GetFirstElementByTypeName(string elementTypeName);

		/// <summary>方法HasAttribute</summary>
		[DispId(44)]
		bool HasAttribute(string name);

		/// <summary>方法InvalidateView</summary>
		[DispId(10)]
		void InvalidateView();

		/// <summary>方法PBGetAttribute</summary>
		[DispId(67)]
		string PBGetAttribute(ref string name);

		/// <summary>方法PBSetAttribute</summary>
		[DispId(68)]
		bool PBSetAttribute(ref string name, ref string string_0);

		/// <summary>方法Select</summary>
		[DispId(11)]
		bool Select();

		/// <summary>方法SetAttribute</summary>
		[DispId(36)]
		bool SetAttribute(string name, string Value);

		/// <summary>方法SetContentLock</summary>
		[DispId(52)]
		bool SetContentLock(string userID, string authoriseUserIDList, bool logUndo);

		/// <summary>方法SetContentLockByCurrentUser</summary>
		[DispId(53)]
		bool SetContentLockByCurrentUser();
	}
}
