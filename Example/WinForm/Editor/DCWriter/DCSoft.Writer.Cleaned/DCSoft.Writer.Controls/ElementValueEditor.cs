using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       文档元素内容编辑器
	///       </summary>
	
	[ComVisible(false)]
	public abstract class ElementValueEditor
	{
		/// <summary>
		///       编辑元素数值
		///       </summary>
		/// <param name="host">编辑器宿主对象</param>
		/// <param name="context">上下文对象</param>
		/// <returns>编辑结果</returns>
		public virtual ElementValueEditResult EditValue(TextWindowsFormsEditorHost host, ElementValueEditContext context)
		{
			return ElementValueEditResult.None;
		}

		/// <summary>
		///       获得编辑元素的方式
		///       </summary>
		/// <param name="host">编辑器宿主</param>
		/// <param name="context">编辑上下文对象</param>
		/// <returns>编辑的方式</returns>
		public virtual ElementValueEditorEditStyle GetEditStyle(TextWindowsFormsEditorHost host, ElementValueEditContext context)
		{
			return ElementValueEditorEditStyle.None;
		}
	}
}
