using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>FileContentSource 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("C14AF047-EDBF-4152-B832-E5B6957D30EA")]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public interface IFileContentSource
	{
		/// <summary>属性FileName</summary>
		[DispId(2)]
		string FileName
		{
			get;
			set;
		}

		/// <summary>属性FileSystemName</summary>
		[DispId(3)]
		string FileSystemName
		{
			get;
			set;
		}

		/// <summary>属性Format</summary>
		[DispId(4)]
		string Format
		{
			get;
			set;
		}

		/// <summary>属性Range</summary>
		[DispId(5)]
		string Range
		{
			get;
			set;
		}

		/// <summary>属性RuntimeFileName</summary>
		[DispId(6)]
		string RuntimeFileName
		{
			get;
			set;
		}

		/// <summary>属性RuntimeFormat</summary>
		[DispId(7)]
		string RuntimeFormat
		{
			get;
			set;
		}
	}
}
