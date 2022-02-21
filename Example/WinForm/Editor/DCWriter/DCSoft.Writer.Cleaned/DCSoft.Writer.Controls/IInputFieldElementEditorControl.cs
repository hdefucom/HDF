using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       自定义输入域数值编辑控件要实现的接口
	///       </summary>
	[ComVisible(false)]
	[DocumentComment]
	
	public interface IInputFieldElementEditorControl
	{
		/// <summary>
		///       初始化控件
		///       </summary>
		/// <param name="args">参数</param>
		void EditorInitalize(InputFieldElementEditorEventArgs args);
	}
}
