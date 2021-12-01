using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       弹出时间日期方式编辑文本输入域内容的编辑器,编辑器中不显示秒数
	///       </summary>
	[ComVisible(false)]
	internal class XTextInputFieldElementDateTimeWithoutSectionValueEditor : ElementValueEditor
	{
		/// <summary>
		///       获得编辑样式
		///       </summary>
		/// <param name="host">
		/// </param>
		/// <param name="context">
		/// </param>
		/// <returns>
		/// </returns>
		public override ElementValueEditorEditStyle GetEditStyle(TextWindowsFormsEditorHost host, ElementValueEditContext context)
		{
			return ElementValueEditorEditStyle.DropDown;
		}

		/// <summary>
		///       编辑数值
		///       </summary>
		/// <param name="host">宿主对象</param>
		/// <param name="context">上下文对象</param>
		/// <returns>操作是否成功</returns>
		public override ElementValueEditResult EditValue(TextWindowsFormsEditorHost host, ElementValueEditContext context)
		{
			return XTextInputFieldElementDateTimeValueEditor.smethod_0(host, context, bool_0: false);
		}
	}
}
