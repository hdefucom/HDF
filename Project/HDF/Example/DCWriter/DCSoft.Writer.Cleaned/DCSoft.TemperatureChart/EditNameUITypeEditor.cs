using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       标题名字编辑器
	///       </summary>
	[ComVisible(false)]
	public class EditNameUITypeEditor : UITypeEditor
	{
		private IWindowsFormsEditorService myService = null;

		/// <summary>
		///       名称初始化
		///       </summary>
		public string strName2 = null;

		/// <summary>
		///       采用下拉列表模式
		///       </summary>
		/// <param name="context">
		/// </param>
		/// <returns>
		/// </returns>
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.DropDown;
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
			using (ListBox listBox = new ListBox())
			{
				if (TemperatureControl._StanderNameList != null && TemperatureControl._StanderNameList.Count > 0)
				{
					for (int i = 0; i < TemperatureControl._StanderNameList.Count; i++)
					{
						listBox.Items.Add(TemperatureControl._StanderNameList[i]);
					}
					myService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
					if (myService == null)
					{
						return value;
					}
					listBox.SelectedIndexChanged += lst_SelectedIndexChanged;
					myService.DropDownControl(listBox);
					if (strName2 != null)
					{
						return strName2;
					}
				}
				return value;
			}
		}

		private void lst_SelectedIndexChanged(object sender, EventArgs e)
		{
			strName2 = ((ListBox)sender).Text;
			myService.CloseDropDown();
		}
	}
}
