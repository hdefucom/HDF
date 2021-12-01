using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>ParseSelectedItemsEventArgs 的COM接口</summary>
	[Guid("63AD7DC7-897B-420C-A8D9-71DF8B01AD6D")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	public interface IParseSelectedItemsEventArgs
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

		/// <summary>属性FormatString</summary>
		[DispId(4)]
		string FormatString
		{
			get;
		}

		/// <summary>属性Items</summary>
		[DispId(5)]
		string[] Items
		{
			get;
		}

		/// <summary>属性Result</summary>
		[DispId(6)]
		string[] Result
		{
			get;
			set;
		}

		/// <summary>属性Separator</summary>
		[DispId(9)]
		string Separator
		{
			get;
		}

		/// <summary>属性SeparatorChar</summary>
		[DispId(7)]
		char SeparatorChar
		{
			get;
		}

		/// <summary>属性Text</summary>
		[DispId(8)]
		string Text
		{
			get;
		}
	}
}
