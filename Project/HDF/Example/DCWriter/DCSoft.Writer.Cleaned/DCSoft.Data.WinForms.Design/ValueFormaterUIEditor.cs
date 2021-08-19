using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DCSoft.Data.WinForms.Design
{
	                                                                    /// <summary>
	                                                                    ///       数据源格式编辑器
	                                                                    ///       </summary>
	[ComVisible(false)]
	public class ValueFormaterUIEditor : UITypeEditor
	{
		                                                                    /// <summary>
		                                                                    ///       返回编辑器类型
		                                                                    ///       </summary>
		                                                                    /// <param name="context">参数</param>
		                                                                    /// <returns>类型为下拉列表类型</returns>
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		                                                                    /// <summary>
		                                                                    ///       编辑数据
		                                                                    ///       </summary>
		                                                                    /// <param name="context">参数</param>
		                                                                    /// <param name="provider">参数</param>
		                                                                    /// <param name="Value">旧数值</param>
		                                                                    /// <returns>新数值</returns>
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object Value)
		{
			if (provider == null)
			{
				return Value;
			}
			IWindowsFormsEditorService windowsFormsEditorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
			if (windowsFormsEditorService == null)
			{
				return Value;
			}
			using (dlgFormatDesigner dlgFormatDesigner = new dlgFormatDesigner())
			{
				ValueFormater valueFormater = Value as ValueFormater;
				valueFormater = (dlgFormatDesigner.InputFormater = ((valueFormater != null) ? valueFormater.Clone() : new ValueFormater()));
				if (windowsFormsEditorService.ShowDialog(dlgFormatDesigner) == DialogResult.OK)
				{
					return dlgFormatDesigner.InputFormater;
				}
			}
			return Value;
		}
	}
}
