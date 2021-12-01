using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextSelection 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[Guid("CD19358D-3EC4-4175-8ADF-489B694AC039")]
	[Browsable(false)]
	public interface IXTextSelection
	{
		/// <summary>属性AbsEndIndex</summary>
		[DispId(5)]
		int AbsEndIndex
		{
			get;
		}

		/// <summary>属性AbsLength</summary>
		[DispId(6)]
		int AbsLength
		{
			get;
		}

		/// <summary>属性AbsStartIndex</summary>
		[DispId(7)]
		int AbsStartIndex
		{
			get;
		}

		/// <summary>属性Cells</summary>
		[DispId(8)]
		XTextElementList Cells
		{
			get;
		}

		/// <summary>属性CellsWithoutOverried</summary>
		[DispId(9)]
		XTextElementList CellsWithoutOverried
		{
			get;
		}

		/// <summary>属性ContentElements</summary>
		[DispId(10)]
		XTextElementList ContentElements
		{
			get;
		}

		/// <summary>属性Document</summary>
		[DispId(11)]
		XTextDocument Document
		{
			get;
		}

		/// <summary>属性DocumentContent</summary>
		[DispId(12)]
		XTextDocumentContentElement DocumentContent
		{
			get;
		}

		/// <summary>属性FirstElement</summary>
		[DispId(13)]
		XTextElement FirstElement
		{
			get;
		}

		/// <summary>属性LastElement</summary>
		[DispId(14)]
		XTextElement LastElement
		{
			get;
		}

		/// <summary>属性Length</summary>
		[DispId(15)]
		int Length
		{
			get;
		}

		/// <summary>属性Mode</summary>
		[DispId(16)]
		ContentRangeMode Mode
		{
			get;
		}

		/// <summary>属性ParagraphsEOFs</summary>
		[DispId(17)]
		XTextElementList ParagraphsEOFs
		{
			get;
		}

		/// <summary>属性RTFText</summary>
		[DispId(18)]
		string RTFText
		{
			get;
		}

		/// <summary>属性SelectionParagraphFlags</summary>
		[DispId(19)]
		XTextElementList SelectionParagraphFlags
		{
			get;
		}

		/// <summary>属性SelectionVersion</summary>
		[DispId(20)]
		int SelectionVersion
		{
			get;
		}

		/// <summary>属性StartIndex</summary>
		[DispId(21)]
		int StartIndex
		{
			get;
		}

		/// <summary>属性Text</summary>
		[DispId(22)]
		string Text
		{
			get;
		}

		/// <summary>属性XMLText</summary>
		[DispId(23)]
		string XMLText
		{
			get;
		}

		/// <summary>方法Contains</summary>
		[DispId(2)]
		bool Contains(XTextElement element);

		/// <summary>方法GetContentText</summary>
		[DispId(4)]
		string GetContentText(string format);
	}
}
