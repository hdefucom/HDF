using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	[ComVisible(false)]
	public class CustomPropertyCollection : List<CustomProperty>, ICustomTypeDescriptor
	{
		public bool Remove(string name, bool IgnoreCase)
		{
			int num = 0;
			while (true)
			{
				if (num < base.Count)
				{
					CustomProperty customProperty = base[num];
					if (string.Compare(customProperty.Name, name, IgnoreCase) == 0)
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			RemoveAt(num);
			return true;
		}

		public virtual AttributeCollection GetAttributes()
		{
			return TypeDescriptor.GetAttributes(this, noCustomTypeDesc: true);
		}

		public virtual string GetClassName()
		{
			return TypeDescriptor.GetClassName(this, noCustomTypeDesc: true);
		}

		public virtual string GetComponentName()
		{
			return TypeDescriptor.GetComponentName(this, noCustomTypeDesc: true);
		}

		public virtual TypeConverter GetConverter()
		{
			return TypeDescriptor.GetConverter(this, noCustomTypeDesc: true);
		}

		public virtual EventDescriptor GetDefaultEvent()
		{
			return TypeDescriptor.GetDefaultEvent(this, noCustomTypeDesc: true);
		}

		public virtual PropertyDescriptor GetDefaultProperty()
		{
			return TypeDescriptor.GetDefaultProperty(this, noCustomTypeDesc: true);
		}

		public virtual object GetEditor(Type editorBaseType)
		{
			return TypeDescriptor.GetEditor(this, editorBaseType, noCustomTypeDesc: true);
		}

		public virtual EventDescriptorCollection GetEvents(Attribute[] attributes)
		{
			return TypeDescriptor.GetEvents(this, attributes, noCustomTypeDesc: true);
		}

		public virtual EventDescriptorCollection GetEvents()
		{
			return TypeDescriptor.GetEvents(this, noCustomTypeDesc: true);
		}

		public virtual PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			PropertyDescriptorCollection propertyDescriptorCollection = new PropertyDescriptorCollection(null);
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CustomProperty current = enumerator.Current;
					ArrayList arrayList = new ArrayList();
					if (!current.IsBrowsable)
					{
						arrayList.Add(new BrowsableAttribute(current.IsBrowsable));
					}
					if (current.IsReadOnly)
					{
						arrayList.Add(new ReadOnlyAttribute(current.IsReadOnly));
					}
					if (current.EditorType != null)
					{
						arrayList.Add(new EditorAttribute(current.EditorType, typeof(UITypeEditor)));
					}
					propertyDescriptorCollection.Add(new CustomPropertyDescriptor(current, (Attribute[])arrayList.ToArray(typeof(Attribute))));
				}
			}
			return propertyDescriptorCollection;
		}

		public virtual PropertyDescriptorCollection GetProperties()
		{
			return TypeDescriptor.GetProperties(this, noCustomTypeDesc: true);
		}

		public virtual object GetPropertyOwner(PropertyDescriptor propertyDescriptor_0)
		{
			return this;
		}
	}
}
