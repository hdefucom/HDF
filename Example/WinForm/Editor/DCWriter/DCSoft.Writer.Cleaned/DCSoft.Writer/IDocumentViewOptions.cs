using DCSoft.Drawing;
using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>DocumentViewOptions 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("D9CF1866-B246-40C7-BA6F-CAB856CEDEA8")]
	[Browsable(false)]
	[ComVisible(true)]
	public interface IDocumentViewOptions
	{
		/// <summary>属性AdornTextBackColor</summary>
		[DispId(66)]
		Color AdornTextBackColor
		{
			get;
			set;
		}

		/// <summary>属性AdornTextBackColorValue</summary>
		[DispId(67)]
		string AdornTextBackColorValue
		{
			get;
			set;
		}

		/// <summary>属性AdornTextVisibility</summary>
		[DispId(68)]
		DCAdornTextVisibility AdornTextVisibility
		{
			get;
			set;
		}

		/// <summary>属性AutoZoomDropdownListFontSize</summary>
		[DispId(71)]
		bool AutoZoomDropdownListFontSize
		{
			get;
			set;
		}

		/// <summary>属性BackgroundTextColor</summary>
		[DispId(2)]
		Color BackgroundTextColor
		{
			get;
			set;
		}

		/// <summary>属性BackgroundTextColorValue</summary>
		[DispId(3)]
		string BackgroundTextColorValue
		{
			get;
			set;
		}

		/// <summary>属性BothBlackWhenPrint</summary>
		[DispId(91)]
		bool BothBlackWhenPrint
		{
			get;
			set;
		}

		/// <summary>属性CommentDateFormatString</summary>
		[DispId(4)]
		string CommentDateFormatString
		{
			get;
			set;
		}

		/// <summary>属性CommentFontName</summary>
		[DispId(98)]
		string CommentFontName
		{
			get;
			set;
		}

		/// <summary>属性CommentFontSize</summary>
		[DispId(5)]
		float CommentFontSize
		{
			get;
			set;
		}

		/// <summary>属性DefaultAdornTextType</summary>
		[DispId(70)]
		InputFieldAdornTextType DefaultAdornTextType
		{
			get;
			set;
		}

		/// <summary>属性DefaultInputFieldHighlight</summary>
		[DispId(62)]
		EnableState DefaultInputFieldHighlight
		{
			get;
			set;
		}

		/// <summary>属性DefaultInputFieldTextColor</summary>
		[DispId(6)]
		Color DefaultInputFieldTextColor
		{
			get;
			set;
		}

		/// <summary>属性DefaultInputFieldTextColorValue</summary>
		[DispId(7)]
		string DefaultInputFieldTextColorValue
		{
			get;
			set;
		}

		/// <summary>属性DefaultLineColorForImageEditor</summary>
		[DispId(87)]
		Color DefaultLineColorForImageEditor
		{
			get;
			set;
		}

		/// <summary>属性DefaultLineColorForImageEditorValue</summary>
		[DispId(88)]
		string DefaultLineColorForImageEditorValue
		{
			get;
			set;
		}

		/// <summary>属性DropdownListFontName</summary>
		[DispId(72)]
		string DropdownListFontName
		{
			get;
			set;
		}

		/// <summary>属性DropdownListFontSize</summary>
		[DispId(8)]
		float DropdownListFontSize
		{
			get;
			set;
		}

		/// <summary>属性EmphasisMarkSize</summary>
		[DispId(95)]
		float EmphasisMarkSize
		{
			get;
			set;
		}

		/// <summary>属性EnableEncryptView</summary>
		[DispId(9)]
		bool EnableEncryptView
		{
			get;
			set;
		}

		/// <summary>属性EnableFieldTextColor</summary>
		[DispId(10)]
		bool EnableFieldTextColor
		{
			get;
			set;
		}

		/// <summary>属性EnableRightToLeft</summary>
		[DispId(11)]
		bool EnableRightToLeft
		{
			get;
			set;
		}

		/// <summary>属性FieldBackColor</summary>
		[DispId(12)]
		Color FieldBackColor
		{
			get;
			set;
		}

		/// <summary>属性FieldBackColorValue</summary>
		[DispId(13)]
		string FieldBackColorValue
		{
			get;
			set;
		}

		/// <summary>属性FieldBorderColor</summary>
		[DispId(59)]
		Color FieldBorderColor
		{
			get;
			set;
		}

		/// <summary>属性FieldBorderColorValue</summary>
		[DispId(60)]
		string FieldBorderColorValue
		{
			get;
			set;
		}

		/// <summary>属性FieldFocusedBackColor</summary>
		[DispId(14)]
		Color FieldFocusedBackColor
		{
			get;
			set;
		}

		/// <summary>属性FieldFocusedBackColorValue</summary>
		[DispId(15)]
		string FieldFocusedBackColorValue
		{
			get;
			set;
		}

		/// <summary>属性FieldHoverBackColor</summary>
		[DispId(16)]
		Color FieldHoverBackColor
		{
			get;
			set;
		}

		/// <summary>属性FieldHoverBackColorValue</summary>
		[DispId(17)]
		string FieldHoverBackColorValue
		{
			get;
			set;
		}

		/// <summary>属性FieldInvalidateValueBackColor</summary>
		[DispId(18)]
		Color FieldInvalidateValueBackColor
		{
			get;
			set;
		}

		/// <summary>属性FieldInvalidateValueBackColorValue</summary>
		[DispId(19)]
		string FieldInvalidateValueBackColorValue
		{
			get;
			set;
		}

		/// <summary>属性FieldInvalidateValueForeColor</summary>
		[DispId(20)]
		Color FieldInvalidateValueForeColor
		{
			get;
			set;
		}

		/// <summary>属性FieldInvalidateValueForeColorValue</summary>
		[DispId(21)]
		string FieldInvalidateValueForeColorValue
		{
			get;
			set;
		}

		/// <summary>属性FieldTextColor</summary>
		[DispId(22)]
		Color FieldTextColor
		{
			get;
			set;
		}

		/// <summary>属性FieldTextColorValue</summary>
		[DispId(23)]
		string FieldTextColorValue
		{
			get;
			set;
		}

		/// <summary>属性FieldTextPrintColor</summary>
		[DispId(56)]
		Color FieldTextPrintColor
		{
			get;
			set;
		}

		/// <summary>属性FieldTextPrintColorValue</summary>
		[DispId(54)]
		string FieldTextPrintColorValue
		{
			get;
			set;
		}

		/// <summary>属性GraphicsSmoothingMode</summary>
		[DispId(92)]
		SmoothingMode GraphicsSmoothingMode
		{
			get;
			set;
		}

		/// <summary>属性GridLineColor</summary>
		[DispId(24)]
		Color GridLineColor
		{
			get;
			set;
		}

		/// <summary>属性GridLineColorValue</summary>
		[DispId(74)]
		string GridLineColorValue
		{
			get;
			set;
		}

		/// <summary>属性GridLineStyle</summary>
		[DispId(57)]
		DashStyle GridLineStyle
		{
			get;
			set;
		}

		/// <summary>属性HeaderBottomLineWidth</summary>
		[DispId(96)]
		float HeaderBottomLineWidth
		{
			get;
			set;
		}

		/// <summary>属性HiddenFieldBorderWhenLostFocus</summary>
		[DispId(73)]
		bool HiddenFieldBorderWhenLostFocus
		{
			get;
			set;
		}

		/// <summary>属性HiddenTableBorderJumpPrintPage</summary>
		[DispId(99)]
		bool HiddenTableBorderJumpPrintPage
		{
			get;
			set;
		}

		/// <summary>属性HighlightProtectedContent</summary>
		[DispId(61)]
		bool HighlightProtectedContent
		{
			get;
			set;
		}

		/// <summary>属性IgnoreFieldBorderWhenPrint</summary>
		[DispId(25)]
		bool IgnoreFieldBorderWhenPrint
		{
			get;
			set;
		}

		/// <summary>属性ImageInterpolationMode</summary>
		[DispId(97)]
		InterpolationMode ImageInterpolationMode
		{
			get;
			set;
		}

		/// <summary>属性LayoutDirection</summary>
		[DispId(26)]
		ContentLayoutDirectionStyle LayoutDirection
		{
			get;
			set;
		}

		/// <summary>属性MaskColorForJumpPrint</summary>
		[DispId(93)]
		Color MaskColorForJumpPrint
		{
			get;
			set;
		}

		/// <summary>属性MaskColorForJumpPrintValue</summary>
		[DispId(94)]
		string MaskColorForJumpPrintValue
		{
			get;
			set;
		}

		/// <summary>属性MinTableColumnWidth</summary>
		[DispId(27)]
		float MinTableColumnWidth
		{
			get;
			set;
		}

		/// <summary>属性NewInputContentUnderlineColor</summary>
		[DispId(100)]
		Color NewInputContentUnderlineColor
		{
			get;
			set;
		}

		/// <summary>属性NewInputContentUnderlineColorValue</summary>
		[DispId(101)]
		string NewInputContentUnderlineColorValue
		{
			get;
			set;
		}

		/// <summary>属性NoneBorderColor</summary>
		[DispId(28)]
		Color NoneBorderColor
		{
			get;
			set;
		}

		/// <summary>属性NoneBorderColorValue</summary>
		[DispId(29)]
		string NoneBorderColorValue
		{
			get;
			set;
		}

		/// <summary>属性NormalFieldBorderColor</summary>
		[DispId(30)]
		Color NormalFieldBorderColor
		{
			get;
			set;
		}

		/// <summary>属性NormalFieldBorderColorValue</summary>
		[DispId(31)]
		string NormalFieldBorderColorValue
		{
			get;
			set;
		}

		/// <summary>属性OldWhitespaceWidth</summary>
		[DispId(32)]
		bool OldWhitespaceWidth
		{
			get;
			set;
		}

		/// <summary>属性PageMarginLineLength</summary>
		[DispId(63)]
		int PageMarginLineLength
		{
			get;
			set;
		}

		/// <summary>属性PreserveBackgroundTextWhenPrint</summary>
		[DispId(64)]
		bool PreserveBackgroundTextWhenPrint
		{
			get;
			set;
		}

		/// <summary>属性PrintBackgroundText</summary>
		[DispId(33)]
		bool PrintBackgroundText
		{
			get;
			set;
		}

		/// <summary>属性PrintGridLine</summary>
		[DispId(34)]
		bool PrintGridLine
		{
			get;
			set;
		}

		/// <summary>属性PrintImageAltText</summary>
		[DispId(35)]
		bool PrintImageAltText
		{
			get;
			set;
		}

		/// <summary>属性ProtectedContentBackColor</summary>
		[DispId(89)]
		Color ProtectedContentBackColor
		{
			get;
			set;
		}

		/// <summary>属性ProtectedContentBackColorValue</summary>
		[DispId(90)]
		string ProtectedContentBackColorValue
		{
			get;
			set;
		}

		/// <summary>属性ReadonlyFieldBorderColor</summary>
		[DispId(36)]
		Color ReadonlyFieldBorderColor
		{
			get;
			set;
		}

		/// <summary>属性ReadonlyFieldBorderColorValue</summary>
		[DispId(37)]
		string ReadonlyFieldBorderColorValue
		{
			get;
			set;
		}

		/// <summary>属性RichTextBoxCompatibility</summary>
		[DispId(38)]
		bool RichTextBoxCompatibility
		{
			get;
			set;
		}

		/// <summary>属性SectionBorderVisibility</summary>
		[DispId(75)]
		RenderVisibility SectionBorderVisibility
		{
			get;
			set;
		}

		/// <summary>属性SelectionHighlight</summary>
		[DispId(39)]
		SelectionHighlightStyle SelectionHighlight
		{
			get;
			set;
		}

		/// <summary>属性SelectionHightlightMaskColor</summary>
		[DispId(40)]
		Color SelectionHightlightMaskColor
		{
			get;
			set;
		}

		/// <summary>属性SelectionHightlightMaskColorValue</summary>
		[DispId(41)]
		string SelectionHightlightMaskColorValue
		{
			get;
			set;
		}

		/// <summary>属性ShowBackgroundCellID</summary>
		[DispId(42)]
		bool ShowBackgroundCellID
		{
			get;
			set;
		}

		/// <summary>属性ShowCellNoneBorder</summary>
		[DispId(43)]
		bool ShowCellNoneBorder
		{
			get;
			set;
		}

		/// <summary>属性ShowExpressionFlag</summary>
		[DispId(44)]
		bool ShowExpressionFlag
		{
			get;
			set;
		}

		/// <summary>属性ShowFieldBorderElement</summary>
		[DispId(45)]
		bool ShowFieldBorderElement
		{
			get;
			set;
		}

		/// <summary>属性ShowFormButton</summary>
		[DispId(65)]
		bool ShowFormButton
		{
			get;
			set;
		}

		/// <summary>属性ShowGrayMaskOverDisableContentParty</summary>
		[DispId(69)]
		bool ShowGrayMaskOverDisableContentParty
		{
			get;
			set;
		}

		/// <summary>属性ShowGridLine</summary>
		[DispId(46)]
		bool ShowGridLine
		{
			get;
			set;
		}

		/// <summary>属性ShowHeaderBottomLine</summary>
		[DispId(47)]
		bool ShowHeaderBottomLine
		{
			get;
			set;
		}

		/// <summary>属性ShowInputFieldStateTag</summary>
		[DispId(78)]
		bool ShowInputFieldStateTag
		{
			get;
			set;
		}

		/// <summary>属性ShowLineNumber</summary>
		[DispId(58)]
		bool ShowLineNumber
		{
			get;
			set;
		}

		/// <summary>属性ShowPageBreak</summary>
		[DispId(76)]
		bool ShowPageBreak
		{
			get;
			set;
		}

		/// <summary>属性ShowPageLine</summary>
		[DispId(48)]
		bool ShowPageLine
		{
			get;
			set;
		}

		/// <summary>属性ShowParagraphFlag</summary>
		[DispId(49)]
		bool ShowParagraphFlag
		{
			get;
			set;
		}

		/// <summary>属性SpecifyExtenGridLineStep</summary>
		[DispId(50)]
		float SpecifyExtenGridLineStep
		{
			get;
			set;
		}

		/// <summary>属性SupportUG</summary>
		[DispId(102)]
		bool SupportUG
		{
			get;
			set;
		}

		/// <summary>属性TableCellBorderVisibility</summary>
		[DispId(77)]
		RenderVisibility TableCellBorderVisibility
		{
			get;
			set;
		}

		/// <summary>属性TagColorForModifiedField</summary>
		[DispId(79)]
		Color TagColorForModifiedField
		{
			get;
			set;
		}

		/// <summary>属性TagColorForModifiedFieldValue</summary>
		[DispId(80)]
		string TagColorForModifiedFieldValue
		{
			get;
			set;
		}

		/// <summary>属性TagColorForNormalField</summary>
		[DispId(81)]
		Color TagColorForNormalField
		{
			get;
			set;
		}

		/// <summary>属性TagColorForNormalFieldValue</summary>
		[DispId(82)]
		string TagColorForNormalFieldValue
		{
			get;
			set;
		}

		/// <summary>属性TagColorForReadonlyField</summary>
		[DispId(83)]
		Color TagColorForReadonlyField
		{
			get;
			set;
		}

		/// <summary>属性TagColorForReadonlyFieldValue</summary>
		[DispId(84)]
		string TagColorForReadonlyFieldValue
		{
			get;
			set;
		}

		/// <summary>属性TagColorForValueInvalidateField</summary>
		[DispId(85)]
		Color TagColorForValueInvalidateField
		{
			get;
			set;
		}

		/// <summary>属性TagColorForValueInvalidateFieldValue</summary>
		[DispId(86)]
		string TagColorForValueInvalidateFieldValue
		{
			get;
			set;
		}

		/// <summary>属性TextRenderStyle</summary>
		[DispId(51)]
		TextRenderingHint TextRenderStyle
		{
			get;
			set;
		}

		/// <summary>属性UnEditableFieldBorderColor</summary>
		[DispId(52)]
		Color UnEditableFieldBorderColor
		{
			get;
			set;
		}

		/// <summary>属性UnEditableFieldBorderColorValue</summary>
		[DispId(53)]
		string UnEditableFieldBorderColorValue
		{
			get;
			set;
		}

		/// <summary>属性UseLanguage2</summary>
		[DispId(55)]
		bool UseLanguage2
		{
			get;
			set;
		}
	}
}
