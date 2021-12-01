using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>WriterReadFileContentEventArgs 的COM接口</summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("6ACA5A24-7F1F-430A-B028-6DF89C54A4A7")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	public interface IWriterReadFileContentEventArgs
	{
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

		/// <summary>属性FileExisted</summary>
		[DispId(5)]
		bool FileExisted
		{
			get;
			set;
		}

		/// <summary>属性FileFormat</summary>
		[DispId(9)]
		string FileFormat
		{
			get;
			set;
		}

		/// <summary>属性FileName</summary>
		[DispId(11)]
		string FileName
		{
			get;
			set;
		}

		/// <summary>属性FileSystemName</summary>
		[DispId(12)]
		string FileSystemName
		{
			get;
			set;
		}

		/// <summary>属性Handled</summary>
		[DispId(10)]
		bool Handled
		{
			get;
			set;
		}

		/// <summary>属性ResultBase64String</summary>
		[DispId(8)]
		string ResultBase64String
		{
			get;
			set;
		}

		/// <summary>方法GetResultBinary</summary>
		[DispId(2)]
		byte[] GetResultBinary();
	}
}
