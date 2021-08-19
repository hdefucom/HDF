using DCSoft.Drawing;
using DCSoft.FriedmanCurveChart;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass151 : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.CheckFileExists = true;
				openFileDialog.ShowReadOnly = false;
				openFileDialog.Filter = DCFriedmanCurveStrings.ImageFilter;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					return new XImageValue(openFileDialog.FileName);
				}
			}
			return value;
		}
	}
}
