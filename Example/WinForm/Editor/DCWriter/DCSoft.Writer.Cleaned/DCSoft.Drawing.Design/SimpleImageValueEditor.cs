using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Drawing.Design
{
	/// <summary>
	///       简单的图片数值编辑器
	///       </summary>
	[ComVisible(false)]
	
	public class SimpleImageValueEditor : UITypeEditor
	{
		/// <summary>
		///       返回编辑模式为对话框
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
			int num = 1;
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "*.jpg;*.png;*.gif;*.bmp|*.jpg;*.png;*.gif;*.bmp";
				openFileDialog.CheckFileExists = true;
				openFileDialog.ShowReadOnly = false;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					if (context.PropertyDescriptor.PropertyType.Equals(typeof(XImageValue)))
					{
						return new XImageValue(openFileDialog.FileName);
					}
					return Image.FromFile(openFileDialog.FileName);
				}
			}
			return value;
		}

		/// <summary>
		///       支持自定义绘制数值
		///       </summary>
		/// <param name="context">
		/// </param>
		/// <returns>
		/// </returns>
		public override bool GetPaintValueSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		/// <summary>
		///       绘制数值
		///       </summary>
		/// <param name="e">
		/// </param>
		public override void PaintValue(PaintValueEventArgs paintValueEventArgs_0)
		{
			Image image = null;
			if (paintValueEventArgs_0.Value is Image)
			{
				image = (Image)paintValueEventArgs_0.Value;
			}
			else if (paintValueEventArgs_0.Value is XImageValue)
			{
				image = ((XImageValue)paintValueEventArgs_0.Value).Value;
			}
			if (image != null)
			{
				paintValueEventArgs_0.Graphics.DrawImage(image, paintValueEventArgs_0.Bounds);
			}
		}
	}
}
