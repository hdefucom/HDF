using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextContent 的COM接口</summary>
	[Guid("89D2B286-781C-42A1-8DBF-81AFECFAA950")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IXTextContent
	{
		/// <summary>属性Count</summary>
		[DispId(15)]
		int Count
		{
			get;
		}

		/// <summary>属性CurrentElement</summary>
		[DispId(16)]
		XTextElement CurrentElement
		{
			get;
			set;
		}

		/// <summary>属性CurrentLine</summary>
		[DispId(17)]
		XTextLine CurrentLine
		{
			get;
		}

		/// <summary>属性CurrentParagraphEOF</summary>
		[DispId(18)]
		XTextParagraphFlagElement CurrentParagraphEOF
		{
			get;
		}

		/// <summary>属性CurrentSelectElement</summary>
		[DispId(19)]
		XTextElement CurrentSelectElement
		{
			get;
		}

		/// <summary>属性FirstContentElement</summary>
		[DispId(21)]
		XTextElement FirstContentElement
		{
			get;
		}

		/// <summary>属性FirstElement</summary>
		[DispId(22)]
		XTextElement FirstElement
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(23)]
		XTextElement this[int index]
		{
			get;
			set;
		}

		/// <summary>属性LastContentElement</summary>
		[DispId(24)]
		XTextElement LastContentElement
		{
			get;
		}

		/// <summary>属性LastElement</summary>
		[DispId(25)]
		XTextElement LastElement
		{
			get;
		}

		/// <summary>属性Selection</summary>
		[DispId(27)]
		XTextSelection Selection
		{
			get;
		}

		/// <summary>属性SelectionLength</summary>
		[DispId(28)]
		int SelectionLength
		{
			get;
		}

		/// <summary>属性SelectionStartIndex</summary>
		[DispId(29)]
		int SelectionStartIndex
		{
			get;
		}

		/// <summary>方法Contains</summary>
		[DispId(4)]
		bool Contains(XTextElement item);

		/// <summary>方法MoveStep</summary>
		[DispId(8)]
		void MoveStep(float Step);

		/// <summary>方法MoveToElement</summary>
		[DispId(9)]
		bool MoveToElement(XTextElement element);

		/// <summary>方法MoveToPoint</summary>
		[DispId(10)]
		void MoveToPoint(float float_0, float float_1);

		/// <summary>方法MoveToPosition</summary>
		[DispId(11)]
		bool MoveToPosition(int index);

		/// <summary>方法MoveToTarget</summary>
		[DispId(12)]
		void MoveToTarget(MoveTarget target);

		/// <summary>方法SelectParagraph</summary>
		[DispId(13)]
		bool SelectParagraph();

		/// <summary>方法SelectWord</summary>
		[DispId(14)]
		bool SelectWord();
	}
}
