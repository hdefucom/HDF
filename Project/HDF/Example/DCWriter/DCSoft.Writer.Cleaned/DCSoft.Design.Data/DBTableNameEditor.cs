using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DCSoft.Design.Data
{
	[ComVisible(false)]
	public class DBTableNameEditor : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			using (dlgBrowseDataBaseSchemaTableName dlgBrowseDataBaseSchemaTableName = new dlgBrowseDataBaseSchemaTableName())
			{
				dlgBrowseDataBaseSchemaTableName.SelectedTableName = Convert.ToString(value);
				dlgBrowseDataBaseSchemaTableName.DBSchema = GetDBSchema();
				IWindowsFormsEditorService windowsFormsEditorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
				if (windowsFormsEditorService.ShowDialog(dlgBrowseDataBaseSchemaTableName) == DialogResult.OK)
				{
					return dlgBrowseDataBaseSchemaTableName.SelectedTableName;
				}
			}
			return value;
		}

		public virtual DataBaseSchema GetDBSchema()
		{
			return DataBaseSchema.Instance;
		}
	}
}
