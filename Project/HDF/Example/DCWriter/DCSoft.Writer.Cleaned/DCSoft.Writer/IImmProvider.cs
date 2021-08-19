using DCSoft.Common;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer
{
	/// <summary>
	///       输入法操作器接口
	///       </summary>
	[ComVisible(false)]
	[DCInternal]
	public interface IImmProvider
	{
		/// <summary>
		///       判断指定的窗口中输入法是否打开
		///       </summary>
		/// <returns>输入法是否打开</returns>
		bool IsImmOpen();

		/// <summary>
		///       为指定的窗口设置输入法的位置
		///       </summary>
		/// <param name="x">输入法位置的X坐标</param>
		/// <param name="y">输入法位置的Y坐标</param>
		void SetImmPos(int int_0, int int_1);

		/// <summary>
		///       备份转换状态
		///       </summary>
		/// <returns>操作是否成功</returns>
		bool BackConversionStatus();

		/// <summary>
		///       还原转换状态
		///       </summary>
		/// <returns>操作是否成功</returns>
		bool RestoreConversionStatus();

		/// <summary>
		///       是否为更新输入法位置的消息
		///       </summary>
		/// <param name="msg">
		/// </param>
		/// <returns>
		/// </returns>
		bool IsWM_IME_NOTIFY_IMN_SETOPENSTATUS(Message message_0);
	}
}
