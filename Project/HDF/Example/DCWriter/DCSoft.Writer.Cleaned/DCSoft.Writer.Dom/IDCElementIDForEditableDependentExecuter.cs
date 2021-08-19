using DCSoft.Common;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	[DCInternal]
	[ComVisible(false)]
	public interface IDCElementIDForEditableDependentExecuter
	{
		/// <summary>
		///       由于元素编号发生改变而自动更新设置
		///       </summary>
		/// <param name="elements">要操作的文档元素列表</param>
		/// <param name="idMaps">新旧元素编号映射表</param>
		/// <returns>操作修改的元素个数</returns>
		int SynchronForModifyElementID(XTextElementList elements, Dictionary<string, string> idMaps);

		void RefreshState();

		string GetEffectTargetElementIDs(XTextElement srcElement);

		/// <summary>
		///       执行操作
		///       </summary>
		/// <param name="srcElement">
		/// </param>
		/// <param name="fastMode">
		/// </param>
		/// <returns>
		/// </returns>
		int Execute(XTextElement srcElement, bool fastMode);
	}
}
