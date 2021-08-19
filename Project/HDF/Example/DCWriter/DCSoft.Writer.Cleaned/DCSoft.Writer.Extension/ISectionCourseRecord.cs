using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Extension
{
	/// <summary>SectionCourseRecord 的COM接口</summary>
	[Guid("9D7E53C3-8B67-41FA-9064-8769393DA91F")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface ISectionCourseRecord
	{
		/// <summary>属性Author</summary>
		[DispId(15)]
		string Author
		{
			get;
			set;
		}

		/// <summary>属性ContentElement</summary>
		[DispId(5)]
		XTextContainerElement ContentElement
		{
			get;
		}

		/// <summary>属性DocumentAttributes</summary>
		[DispId(6)]
		XAttributeList DocumentAttributes
		{
			get;
		}

		/// <summary>属性DocumentInfo</summary>
		[DispId(7)]
		DocumentInfo DocumentInfo
		{
			get;
		}

		/// <summary>属性EnablePermission</summary>
		[DispId(17)]
		bool EnablePermission
		{
			get;
			set;
		}

		/// <summary>属性FileFormat</summary>
		[DispId(8)]
		string FileFormat
		{
			get;
			set;
		}

		/// <summary>属性FileName</summary>
		[DispId(9)]
		string FileName
		{
			get;
			set;
		}

		/// <summary>属性Index</summary>
		[DispId(16)]
		int Index
		{
			set;
		}

		/// <summary>属性IsCurrent</summary>
		[DispId(10)]
		bool IsCurrent
		{
			get;
			set;
		}

		/// <summary>属性Locked</summary>
		[DispId(18)]
		bool Locked
		{
			get;
		}

		/// <summary>属性Modified</summary>
		[DispId(11)]
		bool Modified
		{
			get;
			set;
		}

		/// <summary>属性Readonly</summary>
		[DispId(12)]
		bool Readonly
		{
			get;
			set;
		}

		/// <summary>属性Title</summary>
		[DispId(13)]
		string Title
		{
			get;
		}

		/// <summary>属性XMLText</summary>
		[DispId(14)]
		string XMLText
		{
			get;
		}

		/// <summary>方法CreateRecordDocument</summary>
		[DispId(2)]
		XTextDocument CreateRecordDocument();

		/// <summary>方法GetDocumentAttributeValue</summary>
		[DispId(3)]
		string GetDocumentAttributeValue(string name);

		/// <summary>方法SetDocumentAttribute</summary>
		[DispId(4)]
		void SetDocumentAttribute(string name, string Value);
	}
}
