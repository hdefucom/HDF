using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass287
	{
		private IList ilist_0 = null;

		private Type type_0 = null;

		private object object_0 = null;

		public IList method_0()
		{
			return ilist_0;
		}

		public void method_1(IList ilist_1)
		{
			ilist_0 = ilist_1;
		}

		public Type method_2()
		{
			return type_0;
		}

		public void method_3(Type type_1)
		{
			type_0 = type_1;
		}

		public object method_4()
		{
			return object_0;
		}

		public void method_5(object object_1)
		{
			object_0 = object_1;
		}

		private PropertyDescriptorCollection method_6()
		{
			if (method_2() == null)
			{
				return null;
			}
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(method_2());
			properties.Sort();
			return properties;
		}

		public void method_7()
		{
			if (method_4() is DataGridView)
			{
				method_8((DataGridView)method_4());
			}
		}

		private void method_8(DataGridView dataGridView_0)
		{
			dataGridView_0.Rows.Clear();
			dataGridView_0.Columns.Clear();
			PropertyDescriptorCollection propertyDescriptorCollection = method_6();
			foreach (PropertyDescriptor item in propertyDescriptorCollection)
			{
				DataGridViewColumn dataGridViewColumn = null;
				if (item.IsReadOnly)
				{
					dataGridViewColumn = new DataGridViewTextBoxColumn();
					dataGridViewColumn.ReadOnly = true;
				}
				else if (item.PropertyType.Equals(typeof(Image)) || item.PropertyType.IsSubclassOf(typeof(Image)))
				{
					DataGridViewImageColumn dataGridViewImageColumn = new DataGridViewImageColumn();
					dataGridViewColumn = dataGridViewImageColumn;
				}
				else if (item.PropertyType.Equals(typeof(bool)))
				{
					DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
					dataGridViewColumn = dataGridViewCheckBoxColumn;
				}
				else
				{
					DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
					dataGridViewColumn = dataGridViewTextBoxColumn;
				}
				if (dataGridViewColumn != null)
				{
					dataGridViewColumn.HeaderText = item.DisplayName;
					dataGridViewColumn.Name = item.Name;
					dataGridViewColumn.Tag = item;
				}
				dataGridView_0.Columns.Add(dataGridViewColumn);
			}
			foreach (object item2 in method_0())
			{
				DataGridViewRow dataGridViewRow = new DataGridViewRow();
				dataGridViewRow.CreateCells(dataGridView_0);
				int num = 0;
				foreach (DataGridViewColumn column in dataGridView_0.Columns)
				{
					PropertyDescriptor propertyDescriptor = (PropertyDescriptor)column.Tag;
					object value = propertyDescriptor.GetValue(item2);
					dataGridViewRow.Cells[num].Value = value;
					num++;
				}
			}
		}
	}
}
