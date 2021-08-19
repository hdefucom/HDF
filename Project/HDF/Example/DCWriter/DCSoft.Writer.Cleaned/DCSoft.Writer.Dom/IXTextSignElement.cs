using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextSignElement 的COM接口</summary>
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("635A3879-B2B2-4299-92B2-523E6790E133")]
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IXTextSignElement
	{
		/// <summary>属性ContentElement</summary>
		[DispId(11)]
		XTextContentElement ContentElement
		{
			get;
		}

		/// <summary>属性DocumentContentElement</summary>
		[DispId(12)]
		XTextDocumentContentElement DocumentContentElement
		{
			get;
		}

		/// <summary>属性ElementIndex</summary>
		[DispId(34)]
		int ElementIndex
		{
			get;
			set;
		}

		/// <summary>属性Events</summary>
		[DispId(14)]
		ElementEventTemplateList Events
		{
			get;
		}

		/// <summary>属性Focused</summary>
		[DispId(15)]
		bool Focused
		{
			get;
		}

		/// <summary>属性Height</summary>
		[DispId(16)]
		float Height
		{
			get;
			set;
		}

		/// <summary>属性ID</summary>
		[DispId(33)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性NextElement</summary>
		[DispId(17)]
		XTextElement NextElement
		{
			get;
		}

		/// <summary>属性OwnerCell</summary>
		[DispId(18)]
		XTextTableCellElement OwnerCell
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

		/// <summary>属性OwnerLine</summary>
		[DispId(20)]
		XTextLine OwnerLine
		{
			get;
			set;
		}

		/// <summary>属性OwnerPageIndex</summary>
		[DispId(21)]
		int OwnerPageIndex
		{
			get;
		}

		/// <summary>属性OwnerSection</summary>
		[DispId(22)]
		XTextSectionElement OwnerSection
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

		/// <summary>属性RuntimeStyle</summary>
		[DispId(25)]
		RuntimeDocumentContentStyle RuntimeStyle
		{
			get;
		}

		/// <summary>属性Style</summary>
		[DispId(26)]
		DocumentContentStyle Style
		{
			get;
			set;
		}

		/// <summary>属性StyleIndex</summary>
		[DispId(27)]
		int StyleIndex
		{
			get;
			set;
		}

		/// <summary>属性TypeName</summary>
		[DispId(28)]
		string TypeName
		{
			get;
		}

		/// <summary>属性ViewIndex</summary>
		[DispId(29)]
		int ViewIndex
		{
			get;
		}

		/// <summary>属性Width</summary>
		[DispId(30)]
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

		/// <summary>方法InvalidateView</summary>
		[DispId(9)]
		void InvalidateView();

		/// <summary>方法PBGetAttribute</summary>
		[DispId(35)]
		string PBGetAttribute(ref string name);

		/// <summary>方法PBSetAttribute</summary>
		[DispId(36)]
		bool PBSetAttribute(ref string name, ref string string_0);

		/// <summary>方法Select</summary>
		[DispId(10)]
		bool Select();

		/// <summary>方法SetAttribute</summary>
		[DispId(32)]
		bool SetAttribute(string name, string Value);
	}
}
