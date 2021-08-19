using Open_Newtonsoft_Json.Utilities;
using System;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Serialization
{
	[ComVisible(false)]
	internal static class CachedAttributeGetter<T> where T : Attribute
	{
		private static readonly ThreadSafeStore<object, T> TypeAttributeCache = new ThreadSafeStore<object, T>(JsonTypeReflector.GetAttribute<T>);

		public static T GetAttribute(object type)
		{
			return TypeAttributeCache.Get(type);
		}
	}
}
