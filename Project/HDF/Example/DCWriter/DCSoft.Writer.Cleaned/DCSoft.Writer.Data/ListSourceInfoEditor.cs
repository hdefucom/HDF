using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       列表项目编辑器
	///       </summary>
	[ComVisible(false)]
	public class ListSourceInfoEditor : UITypeEditor
	{
		/// <summary>
		///       获得编辑样式
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
			using (dlgListSourceInfo dlgListSourceInfo = new dlgListSourceInfo())
			{
				ListSourceInfo listSourceInfo = value as ListSourceInfo;
				listSourceInfo = ((listSourceInfo != null) ? listSourceInfo.Clone() : new ListSourceInfo());
				if (dlgListSourceInfo.ShowDialog() == DialogResult.OK)
				{
					value = listSourceInfo;
				}
			}
			return value;
		}
	}
}
