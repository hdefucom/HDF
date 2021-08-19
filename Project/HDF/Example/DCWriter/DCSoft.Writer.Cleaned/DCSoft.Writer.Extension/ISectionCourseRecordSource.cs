using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Extension
{
	/// <summary>SectionCourseRecordSource 的COM接口</summary>
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("7E0BD05C-275D-4BAD-9774-E543118D813E")]
	public interface ISectionCourseRecordSource
	{
		/// <summary>属性Author</summary>
		[DispId(2)]
		string Author
		{
			get;
			set;
		}

		/// <summary>属性Document</summary>
		[DispId(3)]
		XTextDocument Document
		{
			get;
			set;
		}

		/// <summary>属性EnablePermission</summary>
		[DispId(4)]
		bool EnablePermission
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

		/// <summary>属性Locked</summary>
		[DispId(10)]
		bool Locked
		{
			get;
			set;
		}

		/// <summary>属性Modified</summary>
		[DispId(7)]
		bool Modified
		{
			get;
			set;
		}

		/// <summary>属性NewPage</summary>
		[DispId(5)]
		bool NewPage
		{
			get;
			set;
		}

		/// <summary>属性Readonly</summary>
		[DispId(8)]
		bool Readonly
		{
			get;
			set;
		}

		/// <summary>属性RecordBorderColor</summary>
		[DispId(13)]
		Color RecordBorderColor
		{
			get;
			set;
		}

		/// <summary>属性RecordSpacing</summary>
		[DispId(11)]
		float RecordSpacing
		{
			get;
			set;
		}

		/// <summary>属性SpecifyBackgroundCololr</summary>
		[DispId(12)]
		Color SpecifyBackgroundCololr
		{
			get;
			set;
		}

		/// <summary>属性Title</summary>
		[DispId(6)]
		string Title
		{
			get;
			set;
		}
	}
}
