using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>ContentBuilder 的COM接口</summary>
	[Guid("D1FEBAAC-A1F4-4B20-8A1D-A20E4A172106")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IContentBuilder
	{
		/// <summary>属性AppendRawMode</summary>
		[DispId(24)]
		bool AppendRawMode
		{
			get;
			set;
		}

		/// <summary>属性Container</summary>
		[DispId(25)]
		XTextContainerElement Container
		{
			get;
		}

		/// <summary>属性ContentStyle</summary>
		[DispId(26)]
		DocumentContentStyle ContentStyle
		{
			get;
		}

		/// <summary>属性Document</summary>
		[DispId(27)]
		XTextDocument Document
		{
			get;
		}

		/// <summary>属性EnableAddPermissionFlag</summary>
		[DispId(28)]
		bool EnableAddPermissionFlag
		{
			get;
			set;
		}

		/// <summary>属性ParagraphStyle</summary>
		[DispId(29)]
		DocumentContentStyle ParagraphStyle
		{
			get;
		}

		/// <summary>方法Append</summary>
		[DispId(2)]
		void Append(XTextElement element);

		/// <summary>方法AppendDocumentContent</summary>
		[DispId(30)]
		int AppendDocumentContent(XTextDocument document, bool removeLogicDeletedContent, bool clearUserTrack, bool removeComments, bool deleteRedundant);

		/// <summary>方法AppendDocumentContentByBase64String</summary>
		[DispId(33)]
		int AppendDocumentContentByBase64String(string base64String, string fileFormat, bool removeLogicDeletedContent, bool clearUserTrack, bool removeComments, bool deleteRedundant);

		/// <summary>方法AppendDocumentContentByFileName</summary>
		[DispId(34)]
		int AppendDocumentContentByFileName(string fileName, string fileFormat, bool removeLogicDeletedContent, bool clearUserTrack, bool removeComments, bool deleteRedundant);

		/// <summary>方法AppendParagraphFlag</summary>
		[DispId(3)]
		XTextParagraphFlagElement AppendParagraphFlag();

		/// <summary>方法AppendParagraphFlagWithStyle</summary>
		[DispId(4)]
		XTextParagraphFlagElement AppendParagraphFlagWithStyle(DocumentContentStyle style);

		/// <summary>方法AppendParagraphFlagWithStyleString</summary>
		[DispId(5)]
		XTextParagraphFlagElement AppendParagraphFlagWithStyleString(string styleString);

		/// <summary>方法AppendRange</summary>
		[DispId(6)]
		void AppendRange(XTextElementList elements);

		/// <summary>方法AppendRangeWithStyle</summary>
		[DispId(7)]
		void AppendRangeWithStyle(XTextElementList elements, DocumentContentStyle style);

		/// <summary>方法AppendText</summary>
		[DispId(8)]
		XTextElementList AppendText(string text);

		/// <summary>方法AppendTextWithStyle</summary>
		[DispId(9)]
		XTextElementList AppendTextWithStyle(string text, DocumentContentStyle style);

		/// <summary>方法AppendTextWithStyleString</summary>
		[DispId(10)]
		XTextElementList AppendTextWithStyleString(string text, string styleString);

		/// <summary>方法AppendWithStyle</summary>
		[DispId(11)]
		void AppendWithStyle(XTextElement element, DocumentContentStyle style);

		/// <summary>方法Clear</summary>
		[DispId(12)]
		void Clear();

		/// <summary>方法Insert</summary>
		[DispId(13)]
		void Insert(int index, XTextElement element);

		/// <summary>方法InsertDocumentContent</summary>
		[DispId(31)]
		int InsertDocumentContent(int index, XTextDocument document, bool removeLogicDeletedContent, bool clearUserTrack, bool removeComments, bool deleteRedundant);

		/// <summary>方法InsertDocumentContentByBase64String</summary>
		[DispId(35)]
		int InsertDocumentContentByBase64String(int index, string base64String, string fileFormat, bool removeLogicDeletedContent, bool clearUserTrack, bool removeComments, bool deleteRedundant);

		/// <summary>方法InsertDocumentContentByFileName</summary>
		[DispId(36)]
		int InsertDocumentContentByFileName(int index, string fileName, string fileFormat, bool removeLogicDeletedContent, bool clearUserTrack, bool removeComments, bool deleteRedundant);

		/// <summary>方法InsertParagraphFlag</summary>
		[DispId(14)]
		XTextParagraphFlagElement InsertParagraphFlag(int index);

		/// <summary>方法InsertParagraphFlagWithStyle</summary>
		[DispId(15)]
		XTextParagraphFlagElement InsertParagraphFlagWithStyle(int index, DocumentContentStyle style);

		/// <summary>方法InsertParagraphFlagWithStyleString</summary>
		[DispId(16)]
		XTextParagraphFlagElement InsertParagraphFlagWithStyleString(int index, string styleString);

		/// <summary>方法InsertRange</summary>
		[DispId(17)]
		void InsertRange(int index, XTextElementList elements);

		/// <summary>方法InsertRangeWithStyle</summary>
		[DispId(18)]
		void InsertRangeWithStyle(int index, XTextElementList elements, DocumentContentStyle style);

		/// <summary>方法InsertText</summary>
		[DispId(19)]
		XTextElementList InsertText(int index, string text);

		/// <summary>方法InsertTextWithStyle</summary>
		[DispId(20)]
		XTextElementList InsertTextWithStyle(int index, string text, DocumentContentStyle style);

		/// <summary>方法InsertTextWithStyleString</summary>
		[DispId(21)]
		XTextElementList InsertTextWithStyleString(int index, string text, string styleString);

		/// <summary>方法InsertWithStyle</summary>
		[DispId(22)]
		void InsertWithStyle(int index, XTextElement element, DocumentContentStyle style);

		/// <summary>方法RawClear</summary>
		[DispId(32)]
		void RawClear();

		/// <summary>方法SetParagraphStyle</summary>
		[DispId(23)]
		void SetParagraphStyle(DocumentContentStyle style);
	}
}
