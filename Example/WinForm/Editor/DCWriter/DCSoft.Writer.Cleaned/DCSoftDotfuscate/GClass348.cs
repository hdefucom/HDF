#define DEBUG
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public static class GClass348
	{
		private class Class193
		{
			public Type type_0 = null;

			public PropertyInfo propertyInfo_0 = null;

			public string string_0 = null;
		}

		private static List<Class193> list_0 = new List<Class193>();

		private static PropertyInfo smethod_0(object object_0, string string_0)
		{
			int num = 0;
			if (object_0 == null)
			{
				throw new ArgumentNullException("instance");
			}
			if (string.IsNullOrEmpty(string_0))
			{
				throw new ArgumentNullException("propertyName");
			}
			string_0 = string_0.Trim().ToLower();
			Type type = object_0.GetType();
			foreach (Class193 item in list_0)
			{
				if (item.type_0 == type && item.string_0 == string_0)
				{
					return item.propertyInfo_0;
				}
			}
			PropertyInfo propertyInfo = type.GetProperty(string_0, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
			if (propertyInfo != null)
			{
				Class193 @class = new Class193();
				@class.type_0 = type;
				@class.string_0 = string_0;
				ParameterInfo[] indexParameters = propertyInfo.GetIndexParameters();
				if (indexParameters != null && indexParameters.Length > 0)
				{
					propertyInfo = null;
				}
				@class.propertyInfo_0 = propertyInfo;
				list_0.Add(@class);
			}
			return propertyInfo;
		}

		public static bool smethod_1(object object_0, string string_0, out object object_1)
		{
			PropertyInfo propertyInfo = smethod_0(object_0, string_0);
			if (propertyInfo != null && propertyInfo.CanRead)
			{
				try
				{
					object_1 = propertyInfo.GetValue(object_0, null);
					return true;
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.Message);
					object_1 = null;
					return false;
				}
			}
			object_1 = null;
			return false;
		}

		public static object smethod_2(object object_0, string string_0, bool bool_0)
		{
			PropertyInfo propertyInfo = smethod_0(object_0, string_0);
			if (propertyInfo != null && propertyInfo.CanRead)
			{
				if (bool_0)
				{
					return propertyInfo.GetValue(object_0, null);
				}
				try
				{
					return propertyInfo.GetValue(object_0, null);
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.Message);
					return null;
				}
			}
			if (bool_0)
			{
				throw new ArgumentOutOfRangeException(string_0);
			}
			return null;
		}

		public static bool smethod_3(object object_0, string string_0, object object_1, bool bool_0)
		{
			PropertyInfo propertyInfo = smethod_0(object_0, string_0);
			if (propertyInfo == null)
			{
				if (bool_0)
				{
					throw new ArgumentOutOfRangeException(string_0);
				}
				return false;
			}
			object obj = object_1;
			if (object_1 != null && !propertyInfo.PropertyType.IsInstanceOfType(obj))
			{
				TypeConverter converter = TypeDescriptor.GetConverter(propertyInfo.PropertyType);
				if (bool_0)
				{
					obj = ((converter == null) ? Convert.ChangeType(obj, propertyInfo.PropertyType) : converter.ConvertFrom(obj));
				}
				else
				{
					try
					{
						if (converter != null)
						{
							obj = converter.ConvertFrom(obj);
						}
						else
						{
							if (propertyInfo.PropertyType.IsEnum)
							{
								obj = ((!(obj is string)) ? Enum.ToObject(propertyInfo.PropertyType, obj) : Enum.Parse(propertyInfo.PropertyType, (string)obj));
							}
							obj = Convert.ChangeType(obj, propertyInfo.PropertyType);
						}
					}
					catch (Exception)
					{
						return false;
					}
				}
			}
			if (bool_0)
			{
				propertyInfo.SetValue(object_0, obj, null);
				return true;
			}
			try
			{
				propertyInfo.SetValue(object_0, obj, null);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
