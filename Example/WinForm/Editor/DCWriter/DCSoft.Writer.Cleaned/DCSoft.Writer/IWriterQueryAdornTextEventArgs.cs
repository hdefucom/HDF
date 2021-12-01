using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>WriterQueryAdornTextEventArgs 的COM接口</summary>
	[Guid("55C507A8-806D-4930-BB2B-FE14C20E0765")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[Browsable(false)]
	public interface IWriterQueryAdornTextEventArgs
	{
		/// <summary>属性AdornText</summary>
		[DispId(2)]
		string AdornText
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
	}
}
