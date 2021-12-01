using DCSoft.WinForms.Design;
using DCSoft.WinForms.Native;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DCSoftDotfuscate
{
	public class GClass282 : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object Value)
		{
			if (provider == null)
			{
				return Value;
			}
			Guid inputValue = Guid.Empty;
			if (Value is Guid)
			{
				inputValue = (Guid)Value;
			}
			using (dlgGUIDEditor dlgGUIDEditor = new dlgGUIDEditor())
			{
				dlgGUIDEditor.InputValue = inputValue;
				IWindowsFormsEditorService iwindowsFormsEditorService_ = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
				if (smethod_0(dlgGUIDEditor, iwindowsFormsEditorService_) == DialogResult.OK && !Value.Equals(dlgGUIDEditor.InputValue))
				{
					Value = dlgGUIDEditor.InputValue;
				}
			}
			return Value;
		}

		internal static DialogResult smethod_0(Form form_0, IWindowsFormsEditorService iwindowsFormsEditorService_0)
		{
			Control control = iwindowsFormsEditorService_0 as Control;
			if (control != null)
			{
				foreach (Control control2 in control.Controls)
				{
					if (control2 is Button)
					{
						AnimatedRectDrawer animatedRectDrawer = new AnimatedRectDrawer();
						animatedRectDrawer.Add(control2, Rectangle.Empty, form_0);
						return form_0.ShowDialog(control);
					}
				}
			}
			return iwindowsFormsEditorService_0.ShowDialog(form_0);
		}
	}
}
