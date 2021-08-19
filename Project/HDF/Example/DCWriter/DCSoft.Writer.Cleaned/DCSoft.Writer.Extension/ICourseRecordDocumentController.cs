using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Extension
{
	/// <summary>CourseRecordDocumentController 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[Browsable(false)]
	[Guid("D4233D0C-373E-4B70-A044-2144E6577ADB")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface ICourseRecordDocumentController
	{
		/// <summary>属性AuthorNameAttributeName</summary>
		[DispId(12356)]
		string AuthorNameAttributeName
		{
			get;
			set;
		}

		/// <summary>属性CanEditCurrentRecord</summary>
		[DispId(12357)]
		bool CanEditCurrentRecord
		{
			get;
		}

		/// <summary>属性ComViewControl</summary>
		[DispId(12358)]
		IAxWriterControl ComViewControl
		{
			get;
			set;
		}

		/// <summary>属性ContactString</summary>
		[DispId(12359)]
		string ContactString
		{
			get;
			set;
		}

		/// <summary>属性CurrentContentContainerElement</summary>
		[DispId(12360)]
		XTextContainerElement CurrentContentContainerElement
		{
			get;
		}

		/// <summary>属性CurrentRootCell</summary>
		[DispId(12361)]
		XTextTableCellElement CurrentRootCell
		{
			get;
		}

		/// <summary>属性FileFormatAttributeName</summary>
		[DispId(12362)]
		string FileFormatAttributeName
		{
			get;
			set;
		}

		/// <summary>属性FileNameAttributeName</summary>
		[DispId(12363)]
		string FileNameAttributeName
		{
			get;
			set;
		}

		/// <summary>属性HasModifiedRecord</summary>
		[DispId(12364)]
		bool HasModifiedRecord
		{
			get;
		}

		/// <summary>属性ReadonlyBackColor</summary>
		[DispId(12365)]
		Color ReadonlyBackColor
		{
			get;
			set;
		}

		/// <summary>属性RootTable</summary>
		[DispId(12366)]
		XTextTableElement RootTable
		{
			get;
		}

		/// <summary>属性ShowGridLine</summary>
		[DispId(12367)]
		bool ShowGridLine
		{
			get;
			set;
		}

		/// <summary>属性TitleAttributeName</summary>
		[DispId(12368)]
		string TitleAttributeName
		{
			get;
			set;
		}

		/// <summary>方法AppendNewRecord</summary>
		[DispId(12342)]
		bool AppendNewRecord(XTextDocument document);

		/// <summary>方法ClearModifiedFlags</summary>
		[DispId(12343)]
		void ClearModifiedFlags();

		/// <summary>方法DeleteCurrentRecord</summary>
		[DispId(12344)]
		bool DeleteCurrentRecord();

		/// <summary>方法EditCurrentRecord</summary>
		[DispId(12345)]
		bool EditCurrentRecord();

		/// <summary>方法GetAllContentField</summary>
		[DispId(12346)]
		XTextContainerElement[] GetAllContentField(bool modifiedOnly);

		/// <summary>方法GetAllDocuments</summary>
		[DispId(12347)]
		XTextDocument[] GetAllDocuments();

		/// <summary>方法GetModifiedDocuments</summary>
		[DispId(12348)]
		XTextDocument[] GetModifiedDocuments();

		/// <summary>方法InsertNewRecordAtCurrentPosition</summary>
		[DispId(12349)]
		bool InsertNewRecordAtCurrentPosition(XTextDocument document, bool downward);

		/// <summary>方法InsertRecordRow</summary>
		[DispId(12350)]
		XTextContainerElement InsertRecordRow(int recordIndex, XTextDocument document, bool readOnly);

		/// <summary>方法LockAllRecord</summary>
		[DispId(12351)]
		void LockAllRecord();

		/// <summary>方法RefreshHeaderText</summary>
		[DispId(12352)]
		void RefreshHeaderText();

		/// <summary>方法RefreshView</summary>
		[DispId(12353)]
		void RefreshView(XTextDocument[] documents);

		/// <summary>方法SetAttributeNameLabelIDMap</summary>
		[DispId(12354)]
		void SetAttributeNameLabelIDMap(string attributeName, string labelID);

		/// <summary>方法Start</summary>
		[DispId(12355)]
		void Start();
	}
}
