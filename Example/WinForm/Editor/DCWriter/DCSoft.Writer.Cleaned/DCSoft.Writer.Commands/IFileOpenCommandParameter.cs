using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>FileOpenCommandParameter 的COM接口</summary>
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("5B1E164D-B3DE-4645-96DA-420C994AFAE0")]
	public interface IFileOpenCommandParameter
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

		/// <summary>属性Message</summary>
		[DispId(5)]
		string Message
		{
			get;
			set;
		}
	}
}
