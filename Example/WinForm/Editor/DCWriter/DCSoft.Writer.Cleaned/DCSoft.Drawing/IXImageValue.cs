using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>XImageValue 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("28DF30EA-2F2C-42D8-9E03-5716D79142AD")]
	public interface IXImageValue
	{
		/// <summary>属性Height</summary>
		[DispId(2)]
		int Height
		{
			get;
		}

		/// <summary>属性ImageData</summary>
		[DispId(3)]
		byte[] ImageData
		{
			get;
			set;
		}

		/// <summary>属性ImageDataBase64String</summary>
		[DispId(4)]
		string ImageDataBase64String
		{
			get;
			set;
		}

		/// <summary>属性Size</summary>
		[DispId(5)]
		Size Size
		{
			get;
		}

		/// <summary>属性Width</summary>
		[DispId(6)]
		int Width
		{
			get;
		}
	}
}
