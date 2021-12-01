using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextHorizontalLineElement 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("9AA99A18-54AF-4077-B44A-23CC42EEAE04")]
	[Browsable(false)]
	[ComVisible(true)]
	public interface IXTextHorizontalLineElement
	{
		/// <summary>属性Attributes</summary>
		[DispId(9)]
		XAttributeList Attributes
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

		/// <summary>属性EventTemplateName</summary>
		[DispId(11)]
		string EventTemplateName
		{
			get;
			set;
		}

		/// <summary>属性Height</summary>
		[DispId(12)]
		float Height
		{
			get;
			set;
		}

		/// <summary>属性ID</summary>
		[DispId(13)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性LineLengthInCM</summary>
		[DispId(28)]
		float LineLengthInCM
		{
			get;
			set;
		}

		/// <summary>属性NextElement</summary>
		[DispId(21)]
		XTextElement NextElement
		{
			get;
		}

		/// <summary>属性OwnerDocument</summary>
		[DispId(22)]
		XTextDocument OwnerDocument
		{
			get;
			set;
		}

		/// <summary>属性OwnerPageIndex</summary>
		[DispId(14)]
		int OwnerPageIndex
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

		/// <summary>属性Style</summary>
		[DispId(15)]
		DocumentContentStyle Style
		{
			get;
			set;
		}

		/// <summary>属性StyleIndex</summary>
		[DispId(16)]
		int StyleIndex
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

		/// <summary>属性UserFlags</summary>
		[DispId(25)]
		int UserFlags
		{
			get;
			set;
		}

		/// <summary>属性ViewIndex</summary>
		[DispId(26)]
		int ViewIndex
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

		/// <summary>方法EditorRefreshView</summary>
		[DispId(4)]
		void EditorRefreshView();

		/// <summary>方法EndSetStyle</summary>
		[DispId(5)]
		bool EndSetStyle();

		/// <summary>方法Focus</summary>
		[DispId(6)]
		void Focus();

		/// <summary>方法GetAttribute</summary>
		[DispId(19)]
		string GetAttribute(string name);

		/// <summary>方法HasAttribute</summary>
		[DispId(27)]
		bool HasAttribute(string name);

		/// <summary>方法InvalidateView</summary>
		[DispId(7)]
		void InvalidateView();

		/// <summary>方法PBGetAttribute</summary>
		[DispId(29)]
		string PBGetAttribute(ref string name);

		/// <summary>方法PBSetAttribute</summary>
		[DispId(30)]
		bool PBSetAttribute(ref string name, ref string string_0);

		/// <summary>方法Select</summary>
		[DispId(8)]
		bool Select();

		/// <summary>方法SetAttribute</summary>
		[DispId(20)]
		bool SetAttribute(string name, string Value);
	}
}
