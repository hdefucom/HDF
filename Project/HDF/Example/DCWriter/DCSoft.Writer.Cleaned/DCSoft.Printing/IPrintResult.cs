using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Printing
{
	/// <summary>PrintResult 的COM接口</summary>
	[Guid("9BC0FFC2-0F6C-43A1-B925-13802CB31131")]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public interface IPrintResult
	{
		/// <summary>属性ClientName</summary>
		[DispId(4)]
		string ClientName
		{
			get;
			set;
		}

		/// <summary>属性CompleteSuccessed</summary>
		[DispId(5)]
		bool CompleteSuccessed
		{
			get;
		}

		/// <summary>属性Copies</summary>
		[DispId(6)]
		int Copies
		{
			get;
			set;
		}

		/// <summary>属性EndTime</summary>
		[DispId(7)]
		DateTime EndTime
		{
			get;
			set;
		}

		/// <summary>属性JumpPrintMode</summary>
		[DispId(8)]
		bool JumpPrintMode
		{
			get;
			set;
		}

		/// <summary>属性Message</summary>
		[DispId(9)]
		string Message
		{
			get;
			set;
		}

		/// <summary>属性NumOfPages</summary>
		[DispId(10)]
		int NumOfPages
		{
			get;
		}

		/// <summary>属性PageInfos</summary>
		[DispId(11)]
		PrintPageResultList PageInfos
		{
			get;
		}

		/// <summary>属性PaperSourceName</summary>
		[DispId(12)]
		string PaperSourceName
		{
			get;
			set;
		}

		/// <summary>属性Position</summary>
		[DispId(13)]
		int Position
		{
			get;
			set;
		}

		/// <summary>属性PrinterName</summary>
		[DispId(14)]
		string PrinterName
		{
			get;
			set;
		}

		/// <summary>属性StartTime</summary>
		[DispId(15)]
		DateTime StartTime
		{
			get;
			set;
		}

		/// <summary>属性State</summary>
		[DispId(19)]
		PrintResultStates State
		{
			get;
			set;
		}

		/// <summary>属性SuccessedPageIndexs</summary>
		[DispId(16)]
		int[] SuccessedPageIndexs
		{
			get;
		}

		/// <summary>属性Title</summary>
		[DispId(17)]
		string Title
		{
			get;
			set;
		}

		/// <summary>属性TotalTickSpan</summary>
		[DispId(20)]
		int TotalTickSpan
		{
			get;
			set;
		}

		/// <summary>属性UserCancel</summary>
		[DispId(18)]
		bool UserCancel
		{
			get;
			set;
		}
	}
}
