using System.Runtime.InteropServices;

namespace DCSoft.WinForms
{
	/// <summary>
	///       验证单个字符串数据的委托
	///       </summary>
	/// <param name="strValue" type="string">要验证的字符串</param>
	/// <return>True 验证成功， false 验证错误</return>
	[ComVisible(false)]
	public delegate bool CheckStringHandler(string strValue);
}
