using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Design
{
	/// <summary>
	///       事件名称编辑器
	///       </summary>
	[ComVisible(false)]
	public class EventNameUIEditor : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object Value)
		{
			if (context.Instance == null)
			{
				return Value;
			}
			Type type = context.Instance.GetType();
			EventInfo[] events = type.GetEvents(BindingFlags.Instance | BindingFlags.Public);
			if (events != null && events.Length > 0)
			{
				using (dlgSimpleListBox dlgSimpleListBox = new dlgSimpleListBox())
				{
					EventInfo[] array = events;
					foreach (EventInfo eventInfo in array)
					{
						dlgSimpleListBox.InputItems.Add(eventInfo.Name);
					}
					dlgSimpleListBox.InputItems.Sort();
					dlgSimpleListBox.InputText = (string)Value;
					if (dlgSimpleListBox.ShowDialog() == DialogResult.OK)
					{
						return dlgSimpleListBox.InputText;
					}
				}
			}
			return Value;
		}
	}
}
