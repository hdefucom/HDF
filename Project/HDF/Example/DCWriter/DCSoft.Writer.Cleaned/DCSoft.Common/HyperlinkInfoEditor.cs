using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       超链接信息编辑器
	                                                                    ///       </summary>
	[ComVisible(false)]
	public class HyperlinkInfoEditor : UITypeEditor
	{
		                                                                    /// <summary>
		                                                                    ///       获得编辑方式
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
		                                                                    ///       编辑数据
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
			HyperlinkInfo hyperlinkInfo = value as HyperlinkInfo;
			if (hyperlinkInfo == null)
			{
				hyperlinkInfo = new HyperlinkInfo();
			}
			using (dlgHyperlinkInfo dlgHyperlinkInfo = new dlgHyperlinkInfo())
			{
				dlgHyperlinkInfo.InputInfo = hyperlinkInfo;
				if (dlgHyperlinkInfo.ShowDialog() == DialogResult.OK)
				{
					return dlgHyperlinkInfo.InputInfo;
				}
			}
			return value;
		}
	}
}
