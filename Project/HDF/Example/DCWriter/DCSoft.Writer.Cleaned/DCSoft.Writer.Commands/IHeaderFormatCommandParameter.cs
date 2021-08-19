using DCSoft.Drawing;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>HeaderFormatCommandParameter 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Guid("C1D39294-3BDF-4E1E-99BB-A64842326881")]
	public interface IHeaderFormatCommandParameter
	{
		/// <summary>属性FirstLineIndent</summary>
		[DispId(2)]
		float FirstLineIndent
		{
			get;
			set;
		}

		/// <summary>属性FontName</summary>
		[DispId(3)]
		string FontName
		{
			get;
			set;
		}

		/// <summary>属性FontSize</summary>
		[DispId(4)]
		float FontSize
		{
			get;
			set;
		}

		/// <summary>属性FontStyle</summary>
		[DispId(5)]
		FontStyle FontStyle
		{
			get;
			set;
		}

		/// <summary>属性LeftIndent</summary>
		[DispId(6)]
		float LeftIndent
		{
			get;
			set;
		}

		/// <summary>属性LineSpacing</summary>
		[DispId(7)]
		float LineSpacing
		{
			get;
			set;
		}

		/// <summary>属性LineSpacingStyle</summary>
		[DispId(8)]
		LineSpacingStyle LineSpacingStyle
		{
			get;
			set;
		}

		/// <summary>属性ParagraphListStyle</summary>
		[DispId(9)]
		ParagraphListStyle ParagraphListStyle
		{
			get;
			set;
		}

		/// <summary>属性ParagraphMultiLevel</summary>
		[DispId(10)]
		bool ParagraphMultiLevel
		{
			get;
			set;
		}

		/// <summary>属性ParagraphOutlineLevel</summary>
		[DispId(11)]
		int ParagraphOutlineLevel
		{
			get;
			set;
		}

		/// <summary>属性VisibleInDirectory</summary>
		[DispId(12)]
		bool VisibleInDirectory
		{
			get;
			set;
		}
	}
}
