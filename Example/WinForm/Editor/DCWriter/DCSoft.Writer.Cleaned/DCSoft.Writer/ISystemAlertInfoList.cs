using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>SystemAlertInfoList 的COM接口</summary>
	[Guid("6B532050-E4CD-4C85-83D1-705F2C533682")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface ISystemAlertInfoList
	{
		/// <summary>属性Count</summary>
		[DispId(2)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(3)]
		SystemAlertInfo this[int index]
		{
			get;
			set;
		}
	}
}
