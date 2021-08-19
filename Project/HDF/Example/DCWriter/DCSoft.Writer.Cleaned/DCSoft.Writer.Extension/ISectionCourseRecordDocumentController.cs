using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Extension
{
	/// <summary>SectionCourseRecordDocumentController 的COM接口</summary>
	[ComVisible(true)]
	[Browsable(false)]
	[Guid("9ADF3486-1428-4EA2-BFD3-C92C728CBE09")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface ISectionCourseRecordDocumentController
	{
		/// <summary>属性ActivedRecordBorderColor</summary>
		[DispId(12354)]
		Color ActivedRecordBorderColor
		{
			get;
			set;
		}

		/// <summary>属性AuthorNameAttributeName</summary>
		[DispId(12355)]
		string AuthorNameAttributeName
		{
			get;
			set;
		}

		/// <summary>属性AutoSetEnablePermission</summary>
		[DispId(12378)]
		bool AutoSetEnablePermission
		{
			get;
			set;
		}

		/// <summary>属性ComViewControl</summary>
		[DispId(12356)]
		IAxWriterControl ComViewControl
		{
			get;
			set;
		}

		/// <summary>属性ContactString</summary>
		[DispId(12357)]
		string ContactString
		{
			get;
			set;
		}

		/// <summary>属性CurrentContentContainerElement</summary>
		[DispId(12358)]
		XTextContainerElement CurrentContentContainerElement
		{
			get;
		}

		/// <summary>属性CurrentRecord</summary>
		[DispId(12359)]
		SectionCourseRecord CurrentRecord
		{
			get;
			set;
		}

		/// <summary>属性GenerateTitleAndMark</summary>
		[DispId(12360)]
		bool GenerateTitleAndMark
		{
			get;
			set;
		}

		/// <summary>属性HasModifiedRecord</summary>
		[DispId(12361)]
		bool HasModifiedRecord
		{
			get;
		}

		/// <summary>属性ImportUserTrack</summary>
		[DispId(12379)]
		bool ImportUserTrack
		{
			get;
			set;
		}

		/// <summary>属性NewPageFlagAttributeName</summary>
		[DispId(12362)]
		string NewPageFlagAttributeName
		{
			get;
			set;
		}

		/// <summary>属性ReadonlyBackColor</summary>
		[DispId(12363)]
		Color ReadonlyBackColor
		{
			get;
			set;
		}

		/// <summary>属性ReadonlyRecordBackColor</summary>
		[DispId(12364)]
		Color ReadonlyRecordBackColor
		{
			get;
			set;
		}

		/// <summary>属性RecordCount</summary>
		[DispId(12365)]
		int RecordCount
		{
			get;
		}

		/// <summary>属性Records</summary>
		[DispId(12366)]
		SectionCourseRecord[] Records
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

		/// <summary>方法AddDocument</summary>
		[DispId(12342)]
		void AddDocument(XTextDocument document);

		/// <summary>方法AddDocumentFromFile</summary>
		[DispId(12368)]
		void AddDocumentFromFile(string fileName, string format);

		/// <summary>方法AddDocumentFromSourceRecord</summary>
		[DispId(12369)]
		void AddDocumentFromSourceRecord(SectionCourseRecordSource sourceRecord);

		/// <summary>方法AddDocumentFromString</summary>
		[DispId(12370)]
		void AddDocumentFromString(string strData, string format);

		/// <summary>方法AppendNewRecord</summary>
		[DispId(12343)]
		bool AppendNewRecord(XTextDocument document);

		/// <summary>方法AppendNewRecordByRecordSource</summary>
		[DispId(12371)]
		bool AppendNewRecordByRecordSource(SectionCourseRecordSource recordSource);

		/// <summary>方法DeleteCurrentRecord</summary>
		[DispId(12344)]
		bool DeleteCurrentRecord();

		/// <summary>方法EditCurrentRecord</summary>
		[DispId(12345)]
		bool EditCurrentRecord();

		/// <summary>方法GetRecord</summary>
		[DispId(12346)]
		SectionCourseRecord GetRecord(int index);

		/// <summary>方法GetRecordByElement</summary>
		[DispId(12347)]
		SectionCourseRecord GetRecordByElement(XTextElement element);

		/// <summary>方法InsertNewRecordAtCurrentPosition</summary>
		[DispId(12348)]
		bool InsertNewRecordAtCurrentPosition(XTextDocument document, bool downward);

		/// <summary>方法InsertNewRecordAtCurrentPositionByRecordSource</summary>
		[DispId(12372)]
		bool InsertNewRecordAtCurrentPositionByRecordSource(SectionCourseRecordSource recordSource, bool downward);

		/// <summary>方法LoadFrameTemplateByFileName</summary>
		[DispId(12373)]
		void LoadFrameTemplateByFileName(string fileName);

		/// <summary>方法LoadFrameTemplateByString</summary>
		[DispId(12376)]
		void LoadFrameTemplateByString(string text, string format);

		/// <summary>方法RefreshHeaderText</summary>
		[DispId(12349)]
		void RefreshHeaderText();

		/// <summary>方法RefreshView</summary>
		[DispId(12377)]
		void RefreshView(SectionCourseRecordSource[] records);

		/// <summary>方法RefreshViewWithDocuments</summary>
		[DispId(12351)]
		void RefreshViewWithDocuments();

		/// <summary>方法SetAttributeNameLabelIDMap</summary>
		[DispId(12352)]
		void SetAttributeNameLabelIDMap(string attributeName, string labelID);

		/// <summary>方法Start</summary>
		[DispId(12353)]
		void Start();
	}
}
