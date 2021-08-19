using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DCSoft.Design
{
	[ComVisible(false)]
	public class TypeNameUITypeEditor : UITypeEditor
	{
		protected virtual TypeVisiblityFlags TypeVisibility => TypeVisiblityFlags.AllType;

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		protected virtual DCTypeLibrary GetTypeLib(ITypeDescriptorContext context, IServiceProvider provider)
		{
			return null;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			DCTypeLibrary typeLib = GetTypeLib(context, provider);
			if (typeLib == null || typeLib.DomInfo == null || typeLib.DomInfo.Assemblies == null || typeLib.DomInfo.Assemblies.Count == 0)
			{
				return value;
			}
			using (frmBrowseType frmBrowseType = new frmBrowseType())
			{
				frmBrowseType.TypeLibrary = typeLib;
				frmBrowseType.SelectedTypeName = (string)value;
				frmBrowseType.TypeVisibilityFlag = TypeVisibility;
				IWindowsFormsEditorService windowsFormsEditorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
				if (windowsFormsEditorService.ShowDialog(frmBrowseType) == DialogResult.OK)
				{
					return frmBrowseType.SelectedTypeName;
				}
			}
			return value;
		}
	}
}
