using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace DCSoft.WinForms.Design
{
	/// <summary>
	///       下拉式字符串列表编辑器
	///       </summary>
	public class StringListDropDownEditor : CustomDrawValueListBoxEditor
	{
		private class Class37
		{
			public Type type_0 = null;

			public string string_0 = null;

			public string[] string_1 = null;
		}

		private static ArrayList arrayList_0 = new ArrayList();

		/// <summary>
		///       不自定义绘制列表项目
		///       </summary>
		public override Size BoxSize => Size.Empty;

		public static void smethod_0(Type type_0, string string_0, string[] string_1)
		{
			int num = 19;
			if (type_0 == null)
			{
				throw new ArgumentNullException("instanceType");
			}
			if (string_0 == null)
			{
				throw new ArgumentNullException("PropertyName");
			}
			if (type_0.GetProperty(string_0, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public) == null)
			{
				throw new ArgumentException("不存在属性" + string_0);
			}
			foreach (Class37 item in arrayList_0)
			{
				if (item.type_0 == type_0 && string.Compare(item.string_0, string_0, ignoreCase: true) == 0)
				{
					item.string_1 = string_1;
					return;
				}
			}
			Class37 class2 = new Class37();
			class2.type_0 = type_0;
			class2.string_0 = string_0;
			class2.string_1 = string_1;
			arrayList_0.Add(class2);
		}

		public static string[] smethod_1(Type type_0, string string_0)
		{
			foreach (Class37 item in arrayList_0)
			{
				if (item.type_0 == type_0 && string.Compare(item.string_0, string_0, ignoreCase: true) == 0)
				{
					return item.string_1;
				}
			}
			return null;
		}

		/// <summary>
		///       填充列表
		///       </summary>
		/// <param name="ctl">列表控件</param>
		/// <param name="context">参数</param>
		protected override void FillListBox(ListBox listBox_0, ITypeDescriptorContext context)
		{
			listBox_0.ItemHeight = (int)listBox_0.Font.GetHeight() + 3;
			string[] array = smethod_1(context.PropertyDescriptor.ComponentType, context.PropertyDescriptor.Name);
			if (array != null)
			{
				listBox_0.Items.AddRange(array);
			}
		}
	}
}
