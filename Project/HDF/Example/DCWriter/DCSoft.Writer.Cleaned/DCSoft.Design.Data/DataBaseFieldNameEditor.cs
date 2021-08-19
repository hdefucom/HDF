using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms.Design;

namespace DCSoft.Design.Data
{
	[ComVisible(false)]
	public class DataBaseFieldNameEditor : UITypeEditor
	{
		public override bool GetPaintValueSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override void PaintValue(PaintValueEventArgs paintValueEventArgs_0)
		{
			string text = Convert.ToString(paintValueEventArgs_0.Value);
			if (text == null || text.Trim().Length <= 0)
			{
				return;
			}
			if (DataBaseSchema.Instance != null && DataBaseSchema.Instance.Tables.Count > 0)
			{
				DataBaseSchemaField field = DataBaseSchema.Instance.GetField(text);
				if (field != null && field.PrimaryKey)
				{
					paintValueEventArgs_0.Graphics.DrawImage(GClass136.smethod_0().Images[2], 0, 0);
					return;
				}
			}
			paintValueEventArgs_0.Graphics.DrawImage(GClass136.smethod_0().Images[1], 0, 0);
		}

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.DropDown;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object Value)
		{
			using (DataBaseSchemaTreeView dataBaseSchemaTreeView = new DataBaseSchemaTreeView())
			{
				dataBaseSchemaTreeView.RefreshView();
				IWindowsFormsEditorService windowsFormsEditorService2 = dataBaseSchemaTreeView.EditorService = (IWindowsFormsEditorService)context.GetService(typeof(IWindowsFormsEditorService));
				dataBaseSchemaTreeView.SelectedPath = Convert.ToString(Value);
				dataBaseSchemaTreeView.Size = new Size(250, 400);
				dataBaseSchemaTreeView.UserSelected = false;
				windowsFormsEditorService2.DropDownControl(dataBaseSchemaTreeView);
				if (dataBaseSchemaTreeView.UserSelected)
				{
					return dataBaseSchemaTreeView.SelectedPath;
				}
			}
			return Value;
		}
	}
}
