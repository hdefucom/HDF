using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass130 : GInterface1
	{
		private bool bool_0 = false;

		protected PropertyInfo propertyInfo_0 = null;

		protected object object_0 = null;

		protected object object_1 = null;

		protected object object_2 = null;

		public bool InGroup
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		public PropertyInfo method_0()
		{
			return propertyInfo_0;
		}

		public void method_1(PropertyInfo propertyInfo_1)
		{
			propertyInfo_0 = propertyInfo_1;
		}

		public object method_2()
		{
			return object_0;
		}

		public void method_3(object object_3)
		{
			object_0 = object_3;
		}

		public object method_4()
		{
			return object_1;
		}

		public void method_5(object object_3)
		{
			object_1 = object_3;
		}

		public object method_6()
		{
			return object_2;
		}

		public void method_7(object object_3)
		{
			object_2 = object_3;
		}

		public virtual void Redo(GEventArgs3 args)
		{
			if (object_0 != null && propertyInfo_0 != null)
			{
				propertyInfo_0.SetValue(object_0, object_2, null);
			}
		}

		public virtual void Undo(GEventArgs3 args)
		{
			if (object_0 != null && propertyInfo_0 != null)
			{
				propertyInfo_0.SetValue(object_0, object_1, null);
			}
		}
	}
}
