using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>SearchReplaceCommandArgs 的COM接口</summary>
	[Guid("CFBE23B5-1A78-4061-A718-71712DD7B8EC")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	public interface ISearchReplaceCommandArgs
	{
		/// <summary>属性Backward</summary>
		[DispId(2)]
		bool Backward
		{
			get;
			set;
		}

		/// <summary>属性EnableReplaceString</summary>
		[DispId(3)]
		bool EnableReplaceString
		{
			get;
			set;
		}

		/// <summary>属性IgnoreCase</summary>
		[DispId(4)]
		bool IgnoreCase
		{
			get;
			set;
		}

		/// <summary>属性ReplaceString</summary>
		[DispId(5)]
		string ReplaceString
		{
			get;
			set;
		}

		/// <summary>属性Result</summary>
		[DispId(6)]
		int Result
		{
			get;
			set;
		}

		/// <summary>属性SearchID</summary>
		[DispId(7)]
		bool SearchID
		{
			get;
			set;
		}

		/// <summary>属性SearchString</summary>
		[DispId(8)]
		string SearchString
		{
			get;
			set;
		}
	}
}
