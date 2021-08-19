using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	[ComVisible(false)]
	public class TypeNameComparer : IComparer<Type>, IComparer
	{
		private bool bool_0 = true;

		public TypeNameComparer()
		{
		}

		public TypeNameComparer(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public int Compare(Type type_0, Type type_1)
		{
			if (bool_0)
			{
				return string.Compare(type_0.FullName, type_1.FullName);
			}
			return string.Compare(type_0.Name, type_1.Name);
		}

		int IComparer.Compare(object object_0, object object_1)
		{
			return Compare((Type)object_0, (Type)object_1);
		}
	}
}
