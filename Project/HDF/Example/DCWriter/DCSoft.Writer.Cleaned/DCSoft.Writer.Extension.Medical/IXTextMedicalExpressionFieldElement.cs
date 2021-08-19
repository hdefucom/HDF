using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Extension.Medical
{
	/// <summary>XTextMedicalExpressionFieldElement 的COM接口</summary>
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[Guid("2076D8D3-5AB0-4AA8-9B4F-D24550AE550B")]
	public interface IXTextMedicalExpressionFieldElement
	{
		/// <summary>属性Attributes</summary>
		[DispId(6)]
		XAttributeList Attributes
		{
			get;
			set;
		}

		/// <summary>属性ContentBuilder</summary>
		[DispId(36)]
		ContentBuilder ContentBuilder
		{
			get;
		}

		/// <summary>属性ContentReadonly</summary>
		[DispId(7)]
		ContentReadonlyState ContentReadonly
		{
			get;
			set;
		}

		/// <summary>属性EditorText</summary>
		[DispId(8)]
		string EditorText
		{
			get;
			set;
		}

		/// <summary>属性EditorTextExt</summary>
		[DispId(9)]
		string EditorTextExt
		{
			get;
			set;
		}

		/// <summary>属性ElementIndex</summary>
		[DispId(43)]
		int ElementIndex
		{
			get;
			set;
		}

		/// <summary>属性Enabled</summary>
		[DispId(11)]
		bool Enabled
		{
			get;
			set;
		}

		/// <summary>属性EnablePermission</summary>
		[DispId(41)]
		DCBooleanValue EnablePermission
		{
			get;
			set;
		}

		/// <summary>属性EventTemplateName</summary>
		[DispId(12)]
		string EventTemplateName
		{
			get;
			set;
		}

		/// <summary>属性ExpressionStyle</summary>
		[DispId(13)]
		MedicalExpressionStyle ExpressionStyle
		{
			get;
			set;
		}

		/// <summary>属性Focused</summary>
		[DispId(14)]
		bool Focused
		{
			get;
		}

		/// <summary>属性HasSelection</summary>
		[DispId(42)]
		bool HasSelection
		{
			get;
		}

		/// <summary>属性ID</summary>
		[DispId(15)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性InnerValue</summary>
		[DispId(16)]
		string InnerValue
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
		[DispId(37)]
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

		/// <summary>属性OwnerParagraphEOF</summary>
		[DispId(21)]
		XTextParagraphFlagElement OwnerParagraphEOF
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
		[DispId(38)]
		XTextElement PreviousElement
		{
			get;
		}

		/// <summary>属性RuntimeContentReadonly</summary>
		[DispId(24)]
		bool RuntimeContentReadonly
		{
			get;
		}

		/// <summary>属性Style</summary>
		[DispId(25)]
		DocumentContentStyle Style
		{
			get;
			set;
		}

		/// <summary>属性StyleIndex</summary>
		[DispId(26)]
		int StyleIndex
		{
			get;
			set;
		}

		/// <summary>属性TabStop</summary>
		[DispId(27)]
		bool TabStop
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

		/// <summary>属性UserFlags</summary>
		[DispId(39)]
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

		/// <summary>属性Visible</summary>
		[DispId(29)]
		bool Visible
		{
			get;
			set;
		}

		/// <summary>方法BeginSetStyle</summary>
		[DispId(2)]
		bool BeginSetStyle();

		/// <summary>方法EditorSetContentStyle</summary>
		[DispId(32)]
		void EditorSetContentStyle(DocumentContentStyle newStyle, bool logUndo);

		/// <summary>方法EditorSetContentStyleFast</summary>
		[DispId(33)]
		bool EditorSetContentStyleFast(DocumentContentStyle newStyle);

		/// <summary>方法EndSetStyle</summary>
		[DispId(3)]
		bool EndSetStyle();

		/// <summary>方法Focus</summary>
		[DispId(4)]
		void Focus();

		/// <summary>方法GetAttribute</summary>
		[DispId(30)]
		string GetAttribute(string name);

		/// <summary>方法GetElementsByTypeName</summary>
		[DispId(34)]
		XTextElementList GetElementsByTypeName(string elementTypeName);

		/// <summary>方法GetFirstElementByTypeName</summary>
		[DispId(35)]
		XTextElement GetFirstElementByTypeName(string elementTypeName);

		/// <summary>方法InvalidateView</summary>
		[DispId(5)]
		void InvalidateView();

		/// <summary>方法SetAttribute</summary>
		[DispId(31)]
		bool SetAttribute(string name, string Value);
	}
}
