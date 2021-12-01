using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       项目列表编辑器
	///       </summary>
	[ComVisible(false)]
	public class ListItemCollectionEditor : UITypeEditor
	{
		/// <summary>
		///       采用对话框模式
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
			using (dlgListItems dlgListItems = new dlgListItems())
			{
				dlgListItems.InputItems = (value as ListItemCollection);
				if (dlgListItems.ShowDialog() == DialogResult.OK)
				{
					return dlgListItems.InputItems;
				}
			}
			return value;
		}
	}
}
