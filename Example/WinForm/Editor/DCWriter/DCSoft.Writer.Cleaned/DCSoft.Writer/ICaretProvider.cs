using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       光标提供者接口
	///       </summary>
	[ComVisible(false)]
	[DCInternal]
	public interface ICaretProvider
	{
		/// <summary>
		///       隐藏光标
		///       </summary>
		/// <returns>操作是否成功</returns>
		bool Hide();

		/// <summary>
		///       创建光标对象
		///       </summary>
		/// <param name="hBitmap">图片句柄</param>
		/// <param name="nWidth">光标宽度</param>
		/// <param name="nHeight">光标高度</param>
		/// <returns>操作是否成功</returns>
		bool Create(int hBitmap, int nWidth, int nHeight);

		/// <summary>
		///       设置光标位置
		///       </summary>
		/// <param name="x">X坐标</param>
		/// <param name="y">Y坐标</param>
		/// <returns>操作是否成功</returns>
		bool SetPos(int int_0, int int_1);

		/// <summary>
		///       显示光标
		///       </summary>
		/// <returns>操作是否成功</returns>
		bool Show();
	}
}
