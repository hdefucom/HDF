using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DCSoft.WinForms.Design
{
	[ComVisible(false)]
	public class ObjectCollectionEditor : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object Value)
		{
			int num = 14;
			IWindowsFormsEditorService windowsFormsEditorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
			Type propertyType = context.PropertyDescriptor.PropertyType;
			Type[] interfaces = propertyType.GetInterfaces();
			bool flag = false;
			Type[] array = interfaces;
			foreach (Type type in array)
			{
				if (type.Equals(typeof(IList)))
				{
					flag = true;
				}
			}
			if (!flag)
			{
				throw new ArgumentException("未实现接口 System.Collection.IList");
			}
			Type type2 = null;
			MemberInfo[] defaultMembers = propertyType.GetDefaultMembers();
			foreach (MemberInfo memberInfo in defaultMembers)
			{
				if (memberInfo is PropertyInfo)
				{
					type2 = ((PropertyInfo)memberInfo).PropertyType;
					break;
				}
			}
			IList list = null;
			IList list2 = Value as IList;
			if (list2 == null)
			{
				list = (IList)Activator.CreateInstance(propertyType);
			}
			else if (list2 is ICloneable)
			{
				list = (IList)((ICloneable)list2).Clone();
			}
			else
			{
				list = (IList)Activator.CreateInstance(propertyType);
				foreach (object item in list2)
				{
					list.Add(item);
				}
			}
			using (dlgCollectionEditor dlgCollectionEditor = new dlgCollectionEditor())
			{
				dlgCollectionEditor.CollectionInstance = list;
				dlgCollectionEditor.ItemMemberType = type2;
				dlgCollectionEditor.Text = "编辑 " + context.PropertyDescriptor.Name;
				PropertyInfo property = type2.GetProperty("Name", BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
				if (property != null)
				{
					dlgCollectionEditor.ItemNameMember = property.Name;
				}
				if (windowsFormsEditorService.ShowDialog(dlgCollectionEditor) == DialogResult.OK)
				{
					return dlgCollectionEditor.CollectionInstance;
				}
			}
			return Value;
		}
	}
}
