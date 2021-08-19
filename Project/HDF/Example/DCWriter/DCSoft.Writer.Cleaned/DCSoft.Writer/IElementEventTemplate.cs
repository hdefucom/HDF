using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>ElementEventTemplate 的COM接口</summary>
	[Guid("A7953E00-41A5-4841-9440-71BC417C914E")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public interface IElementEventTemplate
	{
		/// <summary>属性Enabled</summary>
		[DispId(12361)]
		bool Enabled
		{
			get;
			set;
		}

		/// <summary>属性Name</summary>
		[DispId(12362)]
		string Name
		{
			get;
			set;
		}
	}
}
