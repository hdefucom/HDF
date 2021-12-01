using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>WriterSaveFileContentEventArgs 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[Guid("45B150B5-AE4F-4809-9AC4-32766FDEC5B3")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public interface IWriterSaveFileContentEventArgs
	{
		/// <summary>属性Base64ContentToSave</summary>
		[DispId(2)]
		string Base64ContentToSave
		{
			get;
			set;
		}

		/// <summary>属性Document</summary>
		[DispId(3)]
		XTextDocument Document
		{
			get;
		}

		/// <summary>属性Element</summary>
		[DispId(4)]
		XTextElement Element
		{
			get;
		}

		/// <summary>属性FileFormat</summary>
		[DispId(5)]
		string FileFormat
		{
			get;
			set;
		}

		/// <summary>属性FileName</summary>
		[DispId(10)]
		string FileName
		{
			get;
			set;
		}

		/// <summary>属性FileSystemName</summary>
		[DispId(11)]
		string FileSystemName
		{
			get;
			set;
		}

		/// <summary>属性Handled</summary>
		[DispId(8)]
		bool Handled
		{
			get;
			set;
		}

		/// <summary>属性Result</summary>
		[DispId(9)]
		bool Result
		{
			get;
			set;
		}
	}
}
