using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>DocumentOutlineNodeList 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("8F4FD322-682A-427A-8157-58766B58BE7C")]
	[ComVisible(true)]
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IDocumentOutlineNodeList
	{
		/// <summary>属性Count</summary>
		[DispId(2)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(3)]
		DocumentOutlineNode this[int index]
		{
			get;
			set;
		}
	}
}
