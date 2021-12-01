using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>FileSaveCommandParameter 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("346F30F2-6835-48BA-AADF-CEE0330D3739")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[ComVisible(true)]
	public interface IFileSaveCommandParameter
	{
		/// <summary>属性AutoSetFormat</summary>
		[DispId(7)]
		bool AutoSetFormat
		{
			get;
			set;
		}

		/// <summary>属性BackgroundMode</summary>
		[DispId(2)]
		bool BackgroundMode
		{
			get;
			set;
		}

		/// <summary>属性FileName</summary>
		[DispId(3)]
		string FileName
		{
			get;
			set;
		}

		/// <summary>属性FileSystemName</summary>
		[DispId(4)]
		string FileSystemName
		{
			get;
			set;
		}

		/// <summary>属性Format</summary>
		[DispId(5)]
		string Format
		{
			get;
			set;
		}

		/// <summary>属性Message</summary>
		[DispId(6)]
		string Message
		{
			get;
			set;
		}
	}
}
