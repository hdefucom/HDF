using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Printing
{
	/// <summary>JumpPrintInfo 的COM接口</summary>
	[Browsable(false)]
	[Guid("0515D5BD-2221-4E99-B369-A22EF1C7D2A1")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IJumpPrintInfo
	{
		/// <summary>属性Enabled</summary>
		[DispId(2)]
		bool Enabled
		{
			get;
			set;
		}

		/// <summary>属性EndPageIndex</summary>
		[DispId(3)]
		int EndPageIndex
		{
			get;
			set;
		}

		/// <summary>属性EndPosition</summary>
		[DispId(4)]
		float EndPosition
		{
			get;
			set;
		}

		/// <summary>属性HasValidateInfo</summary>
		[DispId(11)]
		bool HasValidateInfo
		{
			get;
		}

		/// <summary>属性Mode</summary>
		[DispId(9)]
		JumpPrintMode Mode
		{
			get;
			set;
		}

		/// <summary>属性NativeEndPosition</summary>
		[DispId(5)]
		float NativeEndPosition
		{
			get;
			set;
		}

		/// <summary>属性NativePosition</summary>
		[DispId(6)]
		float NativePosition
		{
			get;
			set;
		}

		/// <summary>属性Page</summary>
		[DispId(10)]
		PrintPage Page
		{
			get;
			set;
		}

		/// <summary>属性PageIndex</summary>
		[DispId(7)]
		int PageIndex
		{
			get;
			set;
		}

		/// <summary>属性Position</summary>
		[DispId(8)]
		float Position
		{
			get;
			set;
		}
	}
}
