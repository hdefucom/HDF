using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>ContentStyle 的COM接口</summary>
	[Guid("EFBE9A17-837D-4FBA-80C1-97DEDAD1C385")]
	[ComVisible(true)]
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IContentStyle
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

		/// <summary>属性BackgroundColor2String</summary>
		[DispId(4)]
		string BackgroundColor2String
		{
			get;
			set;
		}

		/// <summary>属性BackgroundColorString</summary>
		[DispId(5)]
		string BackgroundColorString
		{
			get;
			set;
		}

		/// <summary>属性BackgroundImage</summary>
		[DispId(6)]
		XImageValue BackgroundImage
		{
			get;
			set;
		}

		/// <summary>属性BackgroundStyle</summary>
		[DispId(7)]
		XBrushStyleConst BackgroundStyle
		{
			get;
			set;
		}

		/// <summary>属性Bold</summary>
		[DispId(8)]
		bool Bold
		{
			get;
			set;
		}

		/// <summary>属性BorderBottom</summary>
		[DispId(9)]
		bool BorderBottom
		{
			get;
			set;
		}

		/// <summary>属性BorderBottomColor</summary>
		[DispId(10)]
		Color BorderBottomColor
		{
			get;
			set;
		}

		/// <summary>属性BorderBottomColorString</summary>
		[DispId(11)]
		string BorderBottomColorString
		{
			get;
			set;
		}

		/// <summary>属性BorderColor</summary>
		[DispId(12)]
		Color BorderColor
		{
			get;
			set;
		}

		/// <summary>属性BorderLeft</summary>
		[DispId(13)]
		bool BorderLeft
		{
			get;
			set;
		}

		/// <summary>属性BorderLeftColor</summary>
		[DispId(14)]
		Color BorderLeftColor
		{
			get;
			set;
		}

		/// <summary>属性BorderLeftColorString</summary>
		[DispId(15)]
		string BorderLeftColorString
		{
			get;
			set;
		}

		/// <summary>属性BorderRight</summary>
		[DispId(16)]
		bool BorderRight
		{
			get;
			set;
		}

		/// <summary>属性BorderRightColor</summary>
		[DispId(17)]
		Color BorderRightColor
		{
			get;
			set;
		}

		/// <summary>属性BorderRightColorString</summary>
		[DispId(18)]
		string BorderRightColorString
		{
			get;
			set;
		}

		/// <summary>属性BorderSpacing</summary>
		[DispId(19)]
		float BorderSpacing
		{
			get;
			set;
		}

		/// <summary>属性BorderStyle</summary>
		[DispId(20)]
		DashStyle BorderStyle
		{
			get;
			set;
		}

		/// <summary>属性BorderTop</summary>
		[DispId(21)]
		bool BorderTop
		{
			get;
			set;
		}

		/// <summary>属性BorderTopColor</summary>
		[DispId(22)]
		Color BorderTopColor
		{
			get;
			set;
		}

		/// <summary>属性BorderTopColorString</summary>
		[DispId(23)]
		string BorderTopColorString
		{
			get;
			set;
		}

		/// <summary>属性BorderWidth</summary>
		[DispId(24)]
		float BorderWidth
		{
			get;
			set;
		}

		/// <summary>属性CharacterCircle</summary>
		[DispId(25)]
		CharacterCircleStyles CharacterCircle
		{
			get;
			set;
		}

		/// <summary>属性Color</summary>
		[DispId(26)]
		Color Color
		{
			get;
			set;
		}

		/// <summary>属性ColorString</summary>
		[DispId(27)]
		string ColorString
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
		[DispId(32)]
		FontStyle FontStyle
		{
			get;
			set;
		}

		/// <summary>属性Height</summary>
		[DispId(33)]
		float Height
		{
			get;
			set;
		}

		/// <summary>属性Italic</summary>
		[DispId(34)]
		bool Italic
		{
			get;
			set;
		}

		/// <summary>属性LayoutAlign</summary>
		[DispId(35)]
		ContentLayoutAlign LayoutAlign
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
		[DispId(37)]
		float LetterSpacing
		{
			get;
			set;
		}

		/// <summary>属性LineSpacing</summary>
		[DispId(38)]
		float LineSpacing
		{
			get;
			set;
		}

		/// <summary>属性LineSpacingStyle</summary>
		[DispId(39)]
		LineSpacingStyle LineSpacingStyle
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
		[DispId(44)]
		bool Multiline
		{
			get;
			set;
		}

		/// <summary>属性PaddingBottom</summary>
		[DispId(45)]
		float PaddingBottom
		{
			get;
			set;
		}

		/// <summary>属性PaddingLeft</summary>
		[DispId(46)]
		float PaddingLeft
		{
			get;
			set;
		}

		/// <summary>属性PaddingRight</summary>
		[DispId(47)]
		float PaddingRight
		{
			get;
			set;
		}

		/// <summary>属性PaddingTop</summary>
		[DispId(48)]
		float PaddingTop
		{
			get;
			set;
		}

		/// <summary>属性PageBreakAfter</summary>
		[DispId(49)]
		bool PageBreakAfter
		{
			get;
			set;
		}

		/// <summary>属性PageBreakBefore</summary>
		[DispId(50)]
		bool PageBreakBefore
		{
			get;
			set;
		}

		/// <summary>属性ParagraphListStyle</summary>
		[DispId(51)]
		ParagraphListStyle ParagraphListStyle
		{
			get;
			set;
		}

		/// <summary>属性RightToLeft</summary>
		[DispId(52)]
		bool RightToLeft
		{
			get;
			set;
		}

		/// <summary>属性Rotate</summary>
		[DispId(53)]
		float Rotate
		{
			get;
			set;
		}

		/// <summary>属性RoundRadio</summary>
		[DispId(54)]
		float RoundRadio
		{
			get;
			set;
		}

		/// <summary>属性Spacing</summary>
		[DispId(55)]
		float Spacing
		{
			get;
			set;
		}

		/// <summary>属性SpacingAfterParagraph</summary>
		[DispId(56)]
		float SpacingAfterParagraph
		{
			get;
			set;
		}

		/// <summary>属性SpacingBeforeParagraph</summary>
		[DispId(57)]
		float SpacingBeforeParagraph
		{
			get;
			set;
		}

		/// <summary>属性Strikeout</summary>
		[DispId(58)]
		bool Strikeout
		{
			get;
			set;
		}

		/// <summary>属性Subscript</summary>
		[DispId(59)]
		bool Subscript
		{
			get;
			set;
		}

		/// <summary>属性Superscript</summary>
		[DispId(60)]
		bool Superscript
		{
			get;
			set;
		}

		/// <summary>属性Underline</summary>
		[DispId(61)]
		bool Underline
		{
			get;
			set;
		}

		/// <summary>属性ValueLocked</summary>
		[DispId(62)]
		bool ValueLocked
		{
			get;
			set;
		}

		/// <summary>属性VertialText</summary>
		[DispId(64)]
		bool VertialText
		{
			get;
			set;
		}

		/// <summary>属性VerticalAlign</summary>
		[DispId(65)]
		VerticalAlignStyle VerticalAlign
		{
			get;
			set;
		}

		/// <summary>属性Visibility</summary>
		[DispId(66)]
		RenderVisibility Visibility
		{
			get;
			set;
		}

		/// <summary>属性Visible</summary>
		[DispId(67)]
		bool Visible
		{
			get;
			set;
		}

		/// <summary>属性Zoom</summary>
		[DispId(68)]
		float Zoom
		{
			get;
			set;
		}
	}
}
