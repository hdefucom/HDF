using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>QueryKBEntriesEventArgs 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[ComVisible(true)]
	[Guid("12D0A287-D6D3-4C7F-94B9-A9D8405FE2B3")]
	public interface IQueryKBEntriesEventArgs
	{
		/// <summary>属性Cancel</summary>
		[DispId(2)]
		bool Cancel
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

		/// <summary>属性Result</summary>
		[DispId(4)]
		KBEntryList Result
		{
			get;
			set;
		}

		/// <summary>属性SpellCode</summary>
		[DispId(5)]
		string SpellCode
		{
			get;
		}
	}
}
