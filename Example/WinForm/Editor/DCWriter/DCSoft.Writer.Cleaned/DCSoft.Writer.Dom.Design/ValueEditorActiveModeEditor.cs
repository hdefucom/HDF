using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Dom.Design
{
	/// <summary>
	///       数值编辑器激活方式编辑器
	///       </summary>
	[ComVisible(false)]
	public class ValueEditorActiveModeEditor : UITypeEditor
	{
		/// <summary>
		///       对话框编辑模式
		///       </summary>
		/// <param name="context">
		/// </param>
		/// <returns>
		/// </returns>
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		/// <summary>
		///       编辑数值
		///       </summary>
		/// <param name="context">
		/// </param>
		/// <param name="provider">
		/// </param>
		/// <param name="value">
		/// </param>
		/// <returns>
		/// </returns>
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			ValueEditorActiveMode editorActiveMode = ValueEditorActiveMode.MouseDblClick;
			if (value is ValueEditorActiveMode)
			{
				editorActiveMode = (ValueEditorActiveMode)value;
			}
			else if (value is string)
			{
				editorActiveMode = (ValueEditorActiveMode)Enum.Parse(typeof(ValueEditorActiveMode), (string)value);
			}
			using (dlgValueEditorActiveMode dlgValueEditorActiveMode = new dlgValueEditorActiveMode())
			{
				dlgValueEditorActiveMode.EditorActiveMode = editorActiveMode;
				if (dlgValueEditorActiveMode.ShowDialog() == DialogResult.OK)
				{
					if (context.PropertyDescriptor.PropertyType.Equals(typeof(string)))
					{
						return dlgValueEditorActiveMode.EditorActiveMode.ToString();
					}
					return dlgValueEditorActiveMode.EditorActiveMode;
				}
			}
			return value;
		}
	}
}
