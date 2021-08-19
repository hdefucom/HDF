using DCSoft.Drawing;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>ParagraphFormatCommandParameter 的COM接口</summary>
	[ComVisible(true)]
	[Guid("D148ADCD-EB51-493A-A009-44AB73BEFAF4")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IParagraphFormatCommandParameter
	{
		/// <summary>属性FirstLineIndent</summary>
		[DispId(2)]
		float FirstLineIndent
		{
			get;
			set;
		}

		/// <summary>属性LeftIndent</summary>
		[DispId(3)]
		float LeftIndent
		{
			get;
			set;
		}

		/// <summary>属性LineSpacing</summary>
		[DispId(4)]
		float LineSpacing
		{
			get;
			set;
		}

		/// <summary>属性LineSpacingStyle</summary>
		[DispId(5)]
		LineSpacingStyle LineSpacingStyle
		{
			get;
			set;
		}

		/// <summary>属性SpacingAfter</summary>
		[DispId(6)]
		float SpacingAfter
		{
			get;
			set;
		}

		/// <summary>属性SpacingBefore</summary>
		[DispId(7)]
		float SpacingBefore
		{
			get;
			set;
		}
	}
}
