using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DCSoft.Design.Data
{
	[ComVisible(false)]
	public abstract class DBFieldNameEditor : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			DataBaseSchemaTable tableSchema = GetTableSchema(context, provider, value);
			if (tableSchema != null)
			{
				using (dlgBrowseDataBaseSchemaFieldName dlgBrowseDataBaseSchemaFieldName = new dlgBrowseDataBaseSchemaFieldName())
				{
					dlgBrowseDataBaseSchemaFieldName.SelectedFieldName = Convert.ToString(value);
					dlgBrowseDataBaseSchemaFieldName.InputDataTable = tableSchema;
					IWindowsFormsEditorService windowsFormsEditorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
					if (windowsFormsEditorService.ShowDialog(dlgBrowseDataBaseSchemaFieldName) == DialogResult.OK)
					{
						return dlgBrowseDataBaseSchemaFieldName.SelectedFieldName;
					}
				}
			}
			return value;
		}

		public abstract DataBaseSchemaTable GetTableSchema(ITypeDescriptorContext context, IServiceProvider provider, object value);
	}
}
