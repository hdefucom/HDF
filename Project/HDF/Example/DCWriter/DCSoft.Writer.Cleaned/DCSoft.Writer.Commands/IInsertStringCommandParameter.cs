using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>InsertStringCommandParameter 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("1AEBE7BB-F83D-4CCF-B698-D6067332E1B5")]
	[ComVisible(true)]
	[Browsable(false)]
	public interface IInsertStringCommandParameter
	{
		/// <summary>属性ParagraphStyle</summary>
		[DispId(2)]
		DocumentContentStyle ParagraphStyle
		{
			get;
			set;
		}

		/// <summary>属性Style</summary>
		[DispId(3)]
		DocumentContentStyle Style
		{
			get;
			set;
		}

		/// <summary>属性Text</summary>
		[DispId(4)]
		string Text
		{
			get;
			set;
		}
	}
}
