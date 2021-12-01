using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>ElementExpressionEventArgs 的COM接口</summary>
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("11A21CBD-0555-4AAD-BF09-0C4E2E8E0F13")]
	public interface IElementExpressionEventArgs
	{
		/// <summary>属性Document</summary>
		[DispId(2)]
		XTextDocument Document
		{
			get;
			set;
		}

		/// <summary>属性Element</summary>
		[DispId(3)]
		XTextElement Element
		{
			get;
			set;
		}

		/// <summary>属性Expression</summary>
		[DispId(4)]
		string Expression
		{
			get;
		}

		/// <summary>属性Handled</summary>
		[DispId(5)]
		bool Handled
		{
			get;
			set;
		}

		/// <summary>属性Result</summary>
		[DispId(6)]
		object Result
		{
			get;
			set;
		}

		/// <summary>属性WriterControl</summary>
		[DispId(7)]
		WriterControl WriterControl
		{
			get;
			set;
		}
	}
}
