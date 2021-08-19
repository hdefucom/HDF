using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	[ComVisible(false)]
	public sealed class PropertyExpressionInfoListUITypeEditor : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			using (dlgPropertyExpressionInfoList dlgPropertyExpressionInfoList = new dlgPropertyExpressionInfoList())
			{
				dlgPropertyExpressionInfoList.InputOwner = context.Instance;
				dlgPropertyExpressionInfoList.InputInfos = (value as PropertyExpressionInfoList);
				if (dlgPropertyExpressionInfoList.ShowDialog() == DialogResult.OK)
				{
					return dlgPropertyExpressionInfoList.InputInfos;
				}
			}
			return value;
		}
	}
}
