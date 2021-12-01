using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>DetectResultForValueBindingModifiedList 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[ComVisible(true)]
	[Guid("D0A86420-1826-4B24-87F2-63B19AFE2F9F")]
	public interface IDetectResultForValueBindingModifiedList
	{
		/// <summary>属性Count</summary>
		[DispId(2)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(3)]
		DetectResultForValueBindingModified this[int index]
		{
			get;
			set;
		}
	}
}
