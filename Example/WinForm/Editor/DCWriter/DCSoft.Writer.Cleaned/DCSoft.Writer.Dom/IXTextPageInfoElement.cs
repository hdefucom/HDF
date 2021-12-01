using DCSoft.Drawing;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextPageInfoElement 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Guid("632AB5E7-D689-4E60-BF9B-CE86E24C39A5")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	public interface IXTextPageInfoElement
	{
		/// <summary>属性AutoHeight</summary>
		[DispId(34)]
		bool AutoHeight
		{
			get;
			set;
		}

		/// <summary>属性ColumnIndex</summary>
		[DispId(10)]
		int ColumnIndex
		{
			get;
		}

		/// <summary>属性ContentElement</summary>
		[DispId(11)]
		XTextContentElement ContentElement
		{
			get;
		}

		/// <summary>属性Deleteable</summary>
		[DispId(35)]
		bool Deleteable
		{
			get;
			set;
		}

		/// <summary>属性DisplayFormat</summary>
		[DispId(25)]
		ParagraphListStyle DisplayFormat
		{
			get;
			set;
		}

		/// <summary>属性DocumentContentElement</summary>
		[DispId(12)]
		XTextDocumentContentElement DocumentContentElement
		{
			get;
		}

		/// <summary>属性ElementIndex</summary>
		[DispId(37)]
		int ElementIndex
		{
			get;
			set;
		}

		/// <summary>属性Enabled</summary>
		[DispId(39)]
		bool Enabled
		{
			get;
			set;
		}

		/// <summary>属性EventTemplateName</summary>
		[DispId(26)]
		string EventTemplateName
		{
			get;
			set;
		}

		/// <summary>属性FormatString</summary>
		[DispId(27)]
		string FormatString
		{
			get;
			set;
		}

		/// <summary>属性Height</summary>
		[DispId(14)]
		float Height
		{
			get;
			set;
		}

		/// <summary>属性ID</summary>
		[DispId(15)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性Name</summary>
		[DispId(40)]
		string Name
		{
			get;
			set;
		}

		/// <summary>属性NextElement</summary>
		[DispId(28)]
		XTextElement NextElement
		{
			get;
		}

		/// <summary>属性OwnerDocument</summary>
		[DispId(29)]
		XTextDocument OwnerDocument
		{
			get;
			set;
		}

		/// <summary>属性OwnerPageIndex</summary>
		[DispId(16)]
		int OwnerPageIndex
		{
			get;
		}

		/// <summary>属性PageIndexFix</summary>
		[DispId(17)]
		int PageIndexFix
		{
			get;
			set;
		}

		/// <summary>属性PrintVisibility</summary>
		[DispId(41)]
		ElementVisibility PrintVisibility
		{
			get;
			set;
		}

		/// <summary>属性SpecifyPageIndexs</summary>
		[DispId(42)]
		SpecifyPageIndexInfoList SpecifyPageIndexs
		{
			get;
			set;
		}

		/// <summary>属性SpecifyPageIndexTextList</summary>
		[DispId(36)]
		string SpecifyPageIndexTextList
		{
			get;
			set;
		}

		/// <summary>属性Style</summary>
		[DispId(18)]
		DocumentContentStyle Style
		{
			get;
			set;
		}

		/// <summary>属性StyleIndex</summary>
		[DispId(19)]
		int StyleIndex
		{
			get;
			set;
		}

		/// <summary>属性Text</summary>
		[DispId(20)]
		string Text
		{
			get;
			set;
		}

		/// <summary>属性TypeName</summary>
		[DispId(21)]
		string TypeName
		{
			get;
		}

		/// <summary>属性UserFlags</summary>
		[DispId(30)]
		int UserFlags
		{
			get;
			set;
		}

		/// <summary>属性ValueType</summary>
		[DispId(22)]
		PageInfoValueType ValueType
		{
			get;
			set;
		}

		/// <summary>属性ViewIndex</summary>
		[DispId(23)]
		int ViewIndex
		{
			get;
		}

		/// <summary>属性Width</summary>
		[DispId(24)]
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

		/// <summary>方法EditorSetVisible</summary>
		[DispId(5)]
		bool EditorSetVisible(bool visible);

		/// <summary>方法EditorSetVisibleExt</summary>
		[DispId(6)]
		bool EditorSetVisibleExt(bool visible, bool logUndo, bool fastMode);

		/// <summary>方法EndSetStyle</summary>
		[DispId(7)]
		bool EndSetStyle();

		/// <summary>方法Focus</summary>
		[DispId(8)]
		void Focus();

		/// <summary>方法GetAttribute</summary>
		[DispId(31)]
		string GetAttribute(string name);

		/// <summary>方法GetXMLFragment</summary>
		[DispId(38)]
		string GetXMLFragment();

		/// <summary>方法HasAttribute</summary>
		[DispId(32)]
		bool HasAttribute(string name);

		/// <summary>方法PBGetAttribute</summary>
		[DispId(43)]
		string PBGetAttribute(ref string name);

		/// <summary>方法PBSetAttribute</summary>
		[DispId(44)]
		bool PBSetAttribute(ref string name, ref string string_0);

		/// <summary>方法Select</summary>
		[DispId(9)]
		bool Select();

		/// <summary>方法SetAttribute</summary>
		[DispId(33)]
		bool SetAttribute(string name, string Value);
	}
}
