using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Dom.Design
{
	/// <summary>
	///       文档元素类型编辑器
	///       </summary>
	[ComVisible(false)]
	public class ElementTypeEditor : UITypeEditor
	{
		/// <summary>
		///       采用对话框编辑模式
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
			ElementType inputElementType = ElementType.All;
			if (value is ElementType)
			{
				inputElementType = (ElementType)value;
			}
			else if (value is string)
			{
				inputElementType = (ElementType)Enum.Parse(typeof(ElementType), (string)value);
			}
			using (dlgElementTypeEditor dlgElementTypeEditor = new dlgElementTypeEditor())
			{
				dlgElementTypeEditor.InputElementType = inputElementType;
				if (dlgElementTypeEditor.ShowDialog() == DialogResult.OK)
				{
					if (context.PropertyDescriptor.PropertyType.Equals(typeof(string)))
					{
						return dlgElementTypeEditor.InputElementType.ToString();
					}
					return dlgElementTypeEditor.InputElementType;
				}
			}
			return value;
		}
	}
}
