using System.ComponentModel;
using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	                                                                    /// <summary>NsoNetDog 的COM接口</summary>
	[Guid("C65D0A67-ACAB-4F3B-BCC4-884CBDECC0DD")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface INsoNetDog
	{
		                                                                    /// <summary>方法Create</summary>
		[DispId(2)]
		void Create();

		                                                                    /// <summary>方法CreateRemote</summary>
		[DispId(3)]
		void CreateRemote();
	}
}
