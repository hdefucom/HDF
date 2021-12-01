using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>WriterStartEditEventArgs 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("2800DB6D-3FA6-4397-9723-35B24B6994BA")]
	public interface IWriterStartEditEventArgs
	{
		/// <summary>属性CanDetectAgain</summary>
		[DispId(2)]
		bool CanDetectAgain
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

		/// <summary>属性Readonly</summary>
		[DispId(5)]
		bool Readonly
		{
			get;
			set;
		}
	}
}
