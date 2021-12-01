using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	[ComVisible(false)]
	public class WriterDataFormatsUIEditor : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.DropDown;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			using (dlgWriterDataFormats dlgWriterDataFormats = new dlgWriterDataFormats())
			{
				dlgWriterDataFormats.Text = context.PropertyDescriptor.Name;
				if (value is WriterDataFormats)
				{
					dlgWriterDataFormats.InputDataFormat = (WriterDataFormats)value;
				}
				else
				{
					dlgWriterDataFormats.InputDataFormat = WriterDataFormats.All;
				}
				if (dlgWriterDataFormats.ShowDialog() == DialogResult.OK)
				{
					return dlgWriterDataFormats.InputDataFormat;
				}
			}
			return value;
		}
	}
}
