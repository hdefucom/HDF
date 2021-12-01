using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>WordCountResult 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[Guid("25BA178C-AE0A-42D4-AACF-FA8A106523C3")]
	[ComVisible(true)]
	public interface IWordCountResult
	{
		/// <summary>属性Chars</summary>
		[DispId(2)]
		int Chars
		{
			get;
			set;
		}

		/// <summary>属性CharsNoWhitespace</summary>
		[DispId(3)]
		int CharsNoWhitespace
		{
			get;
			set;
		}

		/// <summary>属性Images</summary>
		[DispId(4)]
		int Images
		{
			get;
			set;
		}

		/// <summary>属性Lines</summary>
		[DispId(5)]
		int Lines
		{
			get;
			set;
		}

		/// <summary>属性Pages</summary>
		[DispId(6)]
		int Pages
		{
			get;
			set;
		}

		/// <summary>属性Paragraphs</summary>
		[DispId(7)]
		int Paragraphs
		{
			get;
			set;
		}

		/// <summary>属性Words</summary>
		[DispId(8)]
		int Words
		{
			get;
			set;
		}
	}
}
