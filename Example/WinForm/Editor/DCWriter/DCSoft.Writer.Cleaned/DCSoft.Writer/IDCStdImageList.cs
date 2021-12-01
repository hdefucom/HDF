using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>DCStdImageList 的COM接口</summary>
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("DAC1FD81-51AE-4700-A97B-9E840CC5FB45")]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IDCStdImageList
	{
		/// <summary>属性TransparentColor</summary>
		[DispId(4)]
		Color TransparentColor
		{
			get;
			set;
		}

		/// <summary>属性TransparentColorValue</summary>
		[DispId(5)]
		string TransparentColorValue
		{
			get;
			set;
		}

		/// <summary>方法SetBitmapByBase64String</summary>
		[DispId(2)]
		void SetBitmapByBase64String(DCStdImageKey dcstdImageKey_0, string base64String);

		/// <summary>方法SetBitmapByFileName</summary>
		[DispId(3)]
		void SetBitmapByFileName(DCStdImageKey dcstdImageKey_0, string fileName);
	}
}
