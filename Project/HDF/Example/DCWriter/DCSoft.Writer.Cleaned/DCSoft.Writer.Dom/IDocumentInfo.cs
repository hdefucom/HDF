using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>DocumentInfo 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[ComVisible(true)]
	[Guid("760F4A6D-1A63-4E49-844B-743406573313")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IDocumentInfo
	{
		/// <summary>属性Author</summary>
		[DispId(2)]
		string Author
		{
			get;
			set;
		}

		/// <summary>属性AuthorName</summary>
		[DispId(17)]
		string AuthorName
		{
			get;
			set;
		}

		/// <summary>属性AuthorPermissionLevel</summary>
		[DispId(18)]
		int AuthorPermissionLevel
		{
			get;
			set;
		}

		/// <summary>属性Comment</summary>
		[DispId(3)]
		string Comment
		{
			get;
			set;
		}

		/// <summary>属性CreationTime</summary>
		[DispId(4)]
		DateTime CreationTime
		{
			get;
			set;
		}

		/// <summary>属性DepartmentID</summary>
		[DispId(19)]
		string DepartmentID
		{
			get;
			set;
		}

		/// <summary>属性DepartmentName</summary>
		[DispId(20)]
		string DepartmentName
		{
			get;
			set;
		}

		/// <summary>属性Description</summary>
		[DispId(5)]
		string Description
		{
			get;
			set;
		}

		/// <summary>属性DocumentEditState</summary>
		[DispId(21)]
		int DocumentEditState
		{
			get;
			set;
		}

		/// <summary>属性DocumentFormat</summary>
		[DispId(29)]
		string DocumentFormat
		{
			get;
			set;
		}

		/// <summary>属性DocumentProcessState</summary>
		[DispId(22)]
		int DocumentProcessState
		{
			get;
			set;
		}

		/// <summary>属性DocumentType</summary>
		[DispId(23)]
		string DocumentType
		{
			get;
			set;
		}

		/// <summary>属性EditMinute</summary>
		[DispId(6)]
		int EditMinute
		{
			get;
			set;
		}

		/// <summary>属性FieldBorderElementWidth</summary>
		[DispId(30)]
		float FieldBorderElementWidth
		{
			get;
			set;
		}

		/// <summary>属性HeightInPrintJob</summary>
		[DispId(24)]
		int HeightInPrintJob
		{
			get;
			set;
		}

		/// <summary>属性ID</summary>
		[DispId(7)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性IsTemplate</summary>
		[DispId(8)]
		bool IsTemplate
		{
			get;
			set;
		}

		/// <summary>属性KBEntryRangeMask</summary>
		[DispId(28)]
		int KBEntryRangeMask
		{
			get;
			set;
		}

		/// <summary>属性LastModifiedTime</summary>
		[DispId(9)]
		DateTime LastModifiedTime
		{
			get;
			set;
		}

		/// <summary>属性LastPrintTime</summary>
		[DispId(10)]
		DateTime LastPrintTime
		{
			get;
			set;
		}

		/// <summary>属性MRID</summary>
		[DispId(11)]
		string MRID
		{
			get;
			set;
		}

		/// <summary>属性NumOfPage</summary>
		[DispId(12)]
		int NumOfPage
		{
			get;
			set;
		}

		/// <summary>属性Operator</summary>
		[DispId(13)]
		string Operator
		{
			get;
			set;
		}

		/// <summary>属性Printable</summary>
		[DispId(25)]
		bool Printable
		{
			get;
			set;
		}

		/// <summary>属性Readonly</summary>
		[DispId(32)]
		bool Readonly
		{
			get;
			set;
		}

		/// <summary>属性ShowHeaderBottomLine</summary>
		[DispId(31)]
		DCBooleanValue ShowHeaderBottomLine
		{
			get;
			set;
		}

		/// <summary>属性StartPositionInPringJob</summary>
		[DispId(26)]
		int StartPositionInPringJob
		{
			get;
			set;
		}

		/// <summary>属性SubDocumentSettings</summary>
		[DispId(33)]
		SubDocumentSettings SubDocumentSettings
		{
			get;
			set;
		}

		/// <summary>属性TimeoutHours</summary>
		[DispId(14)]
		int TimeoutHours
		{
			get;
			set;
		}

		/// <summary>属性Title</summary>
		[DispId(15)]
		string Title
		{
			get;
			set;
		}

		/// <summary>属性UseLanguage2</summary>
		[DispId(27)]
		bool UseLanguage2
		{
			get;
			set;
		}

		/// <summary>属性Version</summary>
		[DispId(16)]
		string Version
		{
			get;
			set;
		}
	}
}
