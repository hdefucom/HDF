using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Dom.Design
{
	/// <summary>
	///       文档元素自定义属性扩展编辑器
	///       </summary>
	[ComVisible(false)]
	public class XAttributeListEditor : UITypeEditor
	{
		/// <summary>
		///       获得编辑模式
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
			XAttributeList xAttributeList = value as XAttributeList;
			using (dlgAttributes dlgAttributes = new dlgAttributes())
			{
				if (xAttributeList == null)
				{
					dlgAttributes.InputAttributes = new XAttributeList();
				}
				else
				{
					dlgAttributes.InputAttributes = xAttributeList.Clone();
				}
				if (dlgAttributes.ShowDialog() == DialogResult.OK)
				{
					return dlgAttributes.InputAttributes;
				}
			}
			return value;
		}
	}
}
