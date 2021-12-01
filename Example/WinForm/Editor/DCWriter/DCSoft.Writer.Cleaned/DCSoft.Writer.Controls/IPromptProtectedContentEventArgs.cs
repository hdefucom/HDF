using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>PromptProtectedContentEventArgs 的COM接口</summary>
	[ComVisible(true)]
	[Guid("E1D27491-21C8-44EF-B44D-3DFE63E3CBEB")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	public interface IPromptProtectedContentEventArgs
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

		/// <summary>属性Handled</summary>
		[DispId(4)]
		bool Handled
		{
			get;
			set;
		}

		/// <summary>属性Message</summary>
		[DispId(5)]
		string Message
		{
			get;
		}

		/// <summary>属性PromptMode</summary>
		[DispId(6)]
		PromptProtectedContentMode PromptMode
		{
			get;
		}
	}
}
