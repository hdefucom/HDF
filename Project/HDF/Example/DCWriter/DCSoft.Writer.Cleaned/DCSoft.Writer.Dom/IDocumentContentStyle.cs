using DCSoft.Drawing;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>DocumentContentStyle 的COM接口</summary>
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[Guid("3FAB6739-C339-45D9-930F-153F8BFF7CEA")]
	public interface IDocumentContentStyle
	{
		/// <summary>属性Align</summary>
		[DispId(2)]
		DocumentContentAlignment Align
		{
			get;
			set;
		}

		/// <summary>属性BackgroundColor</summary>
		[DispId(3)]
		Color BackgroundColor
		{
			get;
			set;
		}

		/// <summary>属性BackgroundColor2</summary>
		[DispId(80)]
		Color BackgroundColor2
		{
			get;
			set;
		}

		/// <summary>属性BackgroundColorString</summary>
		[DispId(4)]
		string BackgroundColorString
		{
			get;
			set;
		}

		/// <summary>属性BackgroundRepeat</summary>
		[DispId(81)]
		bool BackgroundRepeat
		{
			get;
			set;
		}

		/// <summary>属性BackgroundStyle</summary>
		[DispId(82)]
		XBrushStyleConst BackgroundStyle
		{
			get;
			set;
		}

		/// <summary>属性Bold</summary>
		[DispId(5)]
		bool Bold
		{
			get;
			set;
		}

		/// <summary>属性BorderBottom</summary>
		[DispId(6)]
		bool BorderBottom
		{
			get;
			set;
		}

		/// <summary>属性BorderBottomColor</summary>
		[DispId(7)]
		Color BorderBottomColor
		{
			get;
			set;
		}

		/// <summary>属性BorderBottomColorString</summary>
		[DispId(8)]
		string BorderBottomColorString
		{
			get;
			set;
		}

		/// <summary>属性BorderColor</summary>
		[DispId(9)]
		Color BorderColor
		{
			get;
			set;
		}

		/// <summary>属性BorderLeft</summary>
		[DispId(10)]
		bool BorderLeft
		{
			get;
			set;
		}

		/// <summary>属性BorderLeftColor</summary>
		[DispId(11)]
		Color BorderLeftColor
		{
			get;
			set;
		}

		/// <summary>属性BorderLeftColorString</summary>
		[DispId(12)]
		string BorderLeftColorString
		{
			get;
			set;
		}

		/// <summary>属性BorderRight</summary>
		[DispId(13)]
		bool BorderRight
		{
			get;
			set;
		}

		/// <summary>属性BorderRightColor</summary>
		[DispId(14)]
		Color BorderRightColor
		{
			get;
			set;
		}

		/// <summary>属性BorderRightColorString</summary>
		[DispId(15)]
		string BorderRightColorString
		{
			get;
			set;
		}

		/// <summary>属性BorderSpacing</summary>
		[DispId(16)]
		float BorderSpacing
		{
			get;
			set;
		}

		/// <summary>属性BorderStyle</summary>
		[DispId(17)]
		DashStyle BorderStyle
		{
			get;
			set;
		}

		/// <summary>属性BorderTop</summary>
		[DispId(18)]
		bool BorderTop
		{
			get;
			set;
		}

		/// <summary>属性BorderTopColor</summary>
		[DispId(19)]
		Color BorderTopColor
		{
			get;
			set;
		}

		/// <summary>属性BorderTopColorString</summary>
		[DispId(20)]
		string BorderTopColorString
		{
			get;
			set;
		}

		/// <summary>属性BorderWidth</summary>
		[DispId(21)]
		float BorderWidth
		{
			get;
			set;
		}

		/// <summary>属性BulletedString</summary>
		[DispId(22)]
		string BulletedString
		{
			get;
		}

		/// <summary>属性CharacterCircle</summary>
		[DispId(23)]
		CharacterCircleStyles CharacterCircle
		{
			get;
			set;
		}

		/// <summary>属性Color</summary>
		[DispId(24)]
		Color Color
		{
			get;
			set;
		}

		/// <summary>属性ColorString</summary>
		[DispId(25)]
		string ColorString
		{
			get;
			set;
		}

		/// <summary>属性CommentIndex</summary>
		[DispId(72)]
		int CommentIndex
		{
			get;
			set;
		}

		/// <summary>属性CreatorIndex</summary>
		[DispId(26)]
		int CreatorIndex
		{
			get;
			set;
		}

		/// <summary>属性DeleterIndex</summary>
		[DispId(27)]
		int DeleterIndex
		{
			get;
			set;
		}

		/// <summary>属性DisableDefaultValue</summary>
		[DispId(83)]
		bool DisableDefaultValue
		{
			get;
			set;
		}

		/// <summary>属性EmphasisMark</summary>
		[DispId(84)]
		bool EmphasisMark
		{
			get;
			set;
		}

		/// <summary>属性FirstLineIndent</summary>
		[DispId(28)]
		float FirstLineIndent
		{
			get;
			set;
		}

		/// <summary>属性FixedSpacing</summary>
		[DispId(85)]
		bool FixedSpacing
		{
			get;
			set;
		}

		/// <summary>属性Font</summary>
		[DispId(29)]
		XFontValue Font
		{
			get;
			set;
		}

		/// <summary>属性FontName</summary>
		[DispId(30)]
		string FontName
		{
			get;
			set;
		}

		/// <summary>属性FontSize</summary>
		[DispId(31)]
		float FontSize
		{
			get;
			set;
		}

		/// <summary>属性FontStyle</summary>
		[DispId(86)]
		FontStyle FontStyle
		{
			get;
			set;
		}

		/// <summary>属性GridLineColor</summary>
		[DispId(73)]
		Color GridLineColor
		{
			get;
			set;
		}

		/// <summary>属性GridLineColorString</summary>
		[DispId(74)]
		string GridLineColorString
		{
			get;
			set;
		}

		/// <summary>属性GridLineOffsetY</summary>
		[DispId(76)]
		float GridLineOffsetY
		{
			get;
			set;
		}

		/// <summary>属性GridLineStyle</summary>
		[DispId(77)]
		DashStyle GridLineStyle
		{
			get;
			set;
		}

		/// <summary>属性GridLineType</summary>
		[DispId(32)]
		ContentGridLineType GridLineType
		{
			get;
			set;
		}

		/// <summary>属性Italic</summary>
		[DispId(33)]
		bool Italic
		{
			get;
			set;
		}

		/// <summary>属性LayoutAlign</summary>
		[DispId(34)]
		ContentLayoutAlign LayoutAlign
		{
			get;
			set;
		}

		/// <summary>属性LayoutDirection</summary>
		[DispId(35)]
		ContentLayoutDirectionStyle LayoutDirection
		{
			get;
			set;
		}

		/// <summary>属性LayoutGridHeight</summary>
		[DispId(78)]
		float LayoutGridHeight
		{
			get;
			set;
		}

		/// <summary>属性LeftIndent</summary>
		[DispId(36)]
		float LeftIndent
		{
			get;
			set;
		}

		/// <summary>属性LetterSpacing</summary>
		[DispId(79)]
		float LetterSpacing
		{
			get;
			set;
		}

		/// <summary>属性LineSpacing</summary>
		[DispId(37)]
		float LineSpacing
		{
			get;
			set;
		}

		/// <summary>属性LineSpacingStyle</summary>
		[DispId(38)]
		LineSpacingStyle LineSpacingStyle
		{
			get;
			set;
		}

		/// <summary>属性Link</summary>
		[DispId(39)]
		string Link
		{
			get;
			set;
		}

		/// <summary>属性MarginBottom</summary>
		[DispId(40)]
		float MarginBottom
		{
			get;
			set;
		}

		/// <summary>属性MarginLeft</summary>
		[DispId(41)]
		float MarginLeft
		{
			get;
			set;
		}

		/// <summary>属性MarginRight</summary>
		[DispId(42)]
		float MarginRight
		{
			get;
			set;
		}

		/// <summary>属性MarginTop</summary>
		[DispId(43)]
		float MarginTop
		{
			get;
			set;
		}

		/// <summary>属性Multiline</summary>
		[DispId(87)]
		bool Multiline
		{
			get;
			set;
		}

		/// <summary>属性PaddingBottom</summary>
		[DispId(44)]
		float PaddingBottom
		{
			get;
			set;
		}

		/// <summary>属性PaddingLeft</summary>
		[DispId(45)]
		float PaddingLeft
		{
			get;
			set;
		}

		/// <summary>属性PaddingRight</summary>
		[DispId(46)]
		float PaddingRight
		{
			get;
			set;
		}

		/// <summary>属性PaddingTop</summary>
		[DispId(47)]
		float PaddingTop
		{
			get;
			set;
		}

		/// <summary>属性PageBreakAfter</summary>
		[DispId(48)]
		bool PageBreakAfter
		{
			get;
			set;
		}

		/// <summary>属性PageBreakBefore</summary>
		[DispId(49)]
		bool PageBreakBefore
		{
			get;
			set;
		}

		/// <summary>属性ParagraphListStyle</summary>
		[DispId(50)]
		ParagraphListStyle ParagraphListStyle
		{
			get;
			set;
		}

		/// <summary>属性ParagraphMultiLevel</summary>
		[DispId(88)]
		bool ParagraphMultiLevel
		{
			get;
			set;
		}

		/// <summary>属性ParagraphOutlineLevel</summary>
		[DispId(89)]
		int ParagraphOutlineLevel
		{
			get;
			set;
		}

		/// <summary>属性PrintBackColor</summary>
		[DispId(51)]
		Color PrintBackColor
		{
			get;
			set;
		}

		/// <summary>属性PrintBackColorString</summary>
		[DispId(52)]
		string PrintBackColorString
		{
			get;
			set;
		}

		/// <summary>属性PrintColor</summary>
		[DispId(53)]
		Color PrintColor
		{
			get;
			set;
		}

		/// <summary>属性PrintColorString</summary>
		[DispId(54)]
		string PrintColorString
		{
			get;
			set;
		}

		/// <summary>属性ProtectType</summary>
		[DispId(55)]
		ContentProtectType ProtectType
		{
			get;
			set;
		}

		/// <summary>属性RightToLeft</summary>
		[DispId(56)]
		bool RightToLeft
		{
			get;
			set;
		}

		/// <summary>属性Rotate</summary>
		[DispId(90)]
		float Rotate
		{
			get;
			set;
		}

		/// <summary>属性Spacing</summary>
		[DispId(57)]
		float Spacing
		{
			get;
			set;
		}

		/// <summary>属性SpacingAfterParagraph</summary>
		[DispId(58)]
		float SpacingAfterParagraph
		{
			get;
			set;
		}

		/// <summary>属性SpacingBeforeParagraph</summary>
		[DispId(59)]
		float SpacingBeforeParagraph
		{
			get;
			set;
		}

		/// <summary>属性Strikeout</summary>
		[DispId(60)]
		bool Strikeout
		{
			get;
			set;
		}

		/// <summary>属性Subscript</summary>
		[DispId(61)]
		bool Subscript
		{
			get;
			set;
		}

		/// <summary>属性Superscript</summary>
		[DispId(62)]
		bool Superscript
		{
			get;
			set;
		}

		/// <summary>属性TitleLevel</summary>
		[DispId(63)]
		int TitleLevel
		{
			get;
			set;
		}

		/// <summary>属性Top</summary>
		[DispId(64)]
		float Top
		{
			get;
			set;
		}

		/// <summary>属性Underline</summary>
		[DispId(65)]
		bool Underline
		{
			get;
			set;
		}

		/// <summary>属性UnderlineColor</summary>
		[DispId(91)]
		string UnderlineColor
		{
			get;
			set;
		}

		/// <summary>属性UnderlineStyle</summary>
		[DispId(92)]
		TextUnderlineStyle UnderlineStyle
		{
			get;
			set;
		}

		/// <summary>属性ValueLocked</summary>
		[DispId(66)]
		bool ValueLocked
		{
			get;
			set;
		}

		/// <summary>属性VertialText</summary>
		[DispId(68)]
		bool VertialText
		{
			get;
			set;
		}

		/// <summary>属性VerticalAlign</summary>
		[DispId(69)]
		VerticalAlignStyle VerticalAlign
		{
			get;
			set;
		}

		/// <summary>属性Visibility</summary>
		[DispId(70)]
		RenderVisibility Visibility
		{
			get;
			set;
		}

		/// <summary>属性Visible</summary>
		[DispId(71)]
		bool Visible
		{
			get;
			set;
		}
	}
}
