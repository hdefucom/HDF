using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextFileBlockElement 的COM接口</summary>
	[Guid("9E74F75D-3D57-45FA-929E-99E7E912987D")]
	[Browsable(false)]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IXTextFileBlockElement
	{
		/// <summary>属性Attributes</summary>
		[DispId(9)]
		XAttributeList Attributes
		{
			get;
			set;
		}

		/// <summary>属性ContentElement</summary>
		[DispId(10)]
		XTextContentElement ContentElement
		{
			get;
		}

		/// <summary>属性ContentSource</summary>
		[DispId(11)]
		FileContentSource ContentSource
		{
			get;
			set;
		}

		/// <summary>属性ContentSourceValue</summary>
		[DispId(12)]
		string ContentSourceValue
		{
			get;
		}

		/// <summary>属性Events</summary>
		[DispId(13)]
		ElementEventTemplateList Events
		{
			get;
		}

		/// <summary>属性EventTemplateName</summary>
		[DispId(14)]
		string EventTemplateName
		{
			get;
			set;
		}

		/// <summary>属性Height</summary>
		[DispId(15)]
		float Height
		{
			get;
			set;
		}

		/// <summary>属性ID</summary>
		[DispId(16)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性Name</summary>
		[DispId(17)]
		string Name
		{
			get;
			set;
		}

		/// <summary>属性NextElement</summary>
		[DispId(18)]
		XTextElement NextElement
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

		/// <summary>属性OwnerPageIndex</summary>
		[DispId(19)]
		int OwnerPageIndex
		{
			get;
		}

		/// <summary>属性Parent</summary>
		[DispId(20)]
		XTextContainerElement Parent
		{
			get;
			set;
		}

		/// <summary>属性PreviousElement</summary>
		[DispId(21)]
		XTextElement PreviousElement
		{
			get;
		}

		/// <summary>属性Style</summary>
		[DispId(22)]
		DocumentContentStyle Style
		{
			get;
			set;
		}

		/// <summary>属性Text</summary>
		[DispId(23)]
		string Text
		{
			get;
			set;
		}

		/// <summary>属性TypeName</summary>
		[DispId(24)]
		string TypeName
		{
			get;
		}

		/// <summary>属性UserFlags</summary>
		[DispId(29)]
		int UserFlags
		{
			get;
			set;
		}

		/// <summary>属性ViewIndex</summary>
		[DispId(30)]
		int ViewIndex
		{
			get;
		}

		/// <summary>属性Width</summary>
		[DispId(25)]
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
		[DispId(26)]
		string GetAttribute(string name);

		/// <summary>方法InvalidateView</summary>
		[DispId(7)]
		void InvalidateView();

		/// <summary>方法Select</summary>
		[DispId(8)]
		bool Select();

		/// <summary>方法SetAttribute</summary>
		[DispId(27)]
		bool SetAttribute(string name, string Value);
	}
}
