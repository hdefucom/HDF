using DCSoft.Writer.Dom;
using DCSoft.Writer.Security;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>QueryUserHistoryDisplayTextEventArgs 的COM接口</summary>
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("D8F880B4-FEB7-4E32-ADA2-24D603BD5527")]
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IQueryUserHistoryDisplayTextEventArgs
	{
		/// <summary>属性Document</summary>
		[DispId(2)]
		XTextDocument Document
		{
			get;
		}

		/// <summary>属性Element</summary>
		[DispId(3)]
		XTextElement Element
		{
			get;
		}

		/// <summary>属性ForLogicDelete</summary>
		[DispId(4)]
		bool ForLogicDelete
		{
			get;
		}

		/// <summary>属性Info</summary>
		[DispId(5)]
		UserHistoryInfo Info
		{
			get;
		}

		/// <summary>属性Result</summary>
		[DispId(6)]
		string Result
		{
			get;
			set;
		}
	}
}
