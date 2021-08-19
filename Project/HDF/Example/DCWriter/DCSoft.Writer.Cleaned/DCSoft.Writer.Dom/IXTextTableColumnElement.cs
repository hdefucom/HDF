using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextTableColumnElement 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[Guid("03C90FA7-7002-4333-883F-D1E95C100A32")]
	[ComVisible(true)]
	public interface IXTextTableColumnElement
	{
		/// <summary>属性ID</summary>
		[DispId(8)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性Left</summary>
		[DispId(9)]
		float Left
		{
			get;
			set;
		}

		/// <summary>属性OwnerDocument</summary>
		[DispId(10)]
		XTextDocument OwnerDocument
		{
			get;
			set;
		}

		/// <summary>属性OwnerLine</summary>
		[DispId(11)]
		XTextLine OwnerLine
		{
			get;
			set;
		}

		/// <summary>属性OwnerSection</summary>
		[DispId(12)]
		XTextSectionElement OwnerSection
		{
			get;
		}

		/// <summary>属性OwnerTable</summary>
		[DispId(13)]
		XTextTableElement OwnerTable
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

		/// <summary>属性Style</summary>
		[DispId(16)]
		DocumentContentStyle Style
		{
			get;
			set;
		}

		/// <summary>属性TypeName</summary>
		[DispId(17)]
		string TypeName
		{
			get;
		}

		/// <summary>属性Width</summary>
		[DispId(18)]
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

		/// <summary>方法EditorDelete</summary>
		[DispId(21)]
		bool EditorDelete(bool logUndo);

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
		[DispId(22)]
		void Focus();

		/// <summary>方法GetAttribute</summary>
		[DispId(19)]
		string GetAttribute(string name);

		/// <summary>方法HasAttribute</summary>
		[DispId(24)]
		bool HasAttribute(string name);

		/// <summary>方法InvalidateView</summary>
		[DispId(7)]
		void InvalidateView();

		/// <summary>方法PBGetAttribute</summary>
		[DispId(25)]
		string PBGetAttribute(ref string name);

		/// <summary>方法PBSetAttribute</summary>
		[DispId(26)]
		bool PBSetAttribute(ref string name, ref string string_0);

		/// <summary>方法Select</summary>
		[DispId(23)]
		bool Select();

		/// <summary>方法SetAttribute</summary>
		[DispId(20)]
		bool SetAttribute(string name, string Value);
	}
}
