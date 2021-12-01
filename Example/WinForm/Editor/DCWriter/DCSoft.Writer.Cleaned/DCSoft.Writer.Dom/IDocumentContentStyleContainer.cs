using DCSoft.Drawing;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>DocumentContentStyleContainer 的COM接口</summary>
	[Browsable(false)]
	[ComVisible(true)]
	[Guid("403CE00C-8CB7-44E3-8A7A-5668B6830A51")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IDocumentContentStyleContainer
	{
		/// <summary>属性Default</summary>
		[DispId(2)]
		ContentStyle Default
		{
			get;
			set;
		}

		/// <summary>属性Styles</summary>
		[DispId(3)]
		ContentStyleList Styles
		{
			get;
			set;
		}
	}
}
