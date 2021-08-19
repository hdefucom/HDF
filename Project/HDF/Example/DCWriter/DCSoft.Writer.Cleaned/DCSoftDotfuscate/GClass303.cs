using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass303 : IDataObject
	{
		private class Class185
		{
			public object object_0 = null;

			public Type type_0 = null;

			public string string_0 = null;
		}

		private List<Class185> list_0 = new List<Class185>();

		public object GetData(Type format)
		{
			return method_0(format)?.object_0;
		}

		public object GetData(string format)
		{
			return method_1(format)?.object_0;
		}

		public object GetData(string format, bool autoConvert)
		{
			return GetData(format);
		}

		public bool GetDataPresent(Type format)
		{
			return method_0(format) != null;
		}

		public bool GetDataPresent(string format)
		{
			return method_1(format) != null;
		}

		public bool GetDataPresent(string format, bool autoConvert)
		{
			return method_1(format) != null;
		}

		public string[] GetFormats()
		{
			string[] array = new string[list_0.Count];
			for (int i = 0; i < list_0.Count; i++)
			{
				array[i] = list_0[i].string_0;
			}
			return array;
		}

		public string[] GetFormats(bool autoConvert)
		{
			return GetFormats();
		}

		public void SetData(object data)
		{
			list_0.Clear();
			Class185 @class = new Class185();
			@class.object_0 = data;
			@class.string_0 = null;
			@class.type_0 = typeof(object);
			list_0.Add(@class);
		}

		public void SetData(Type format, object data)
		{
			Class185 @class = method_0(format);
			if (@class == null)
			{
				@class = new Class185();
				if (data is string)
				{
					@class.string_0 = DataFormats.Text;
				}
				if (data is Image)
				{
					@class.string_0 = DataFormats.Bitmap;
				}
				@class.string_0 = format.FullName;
				@class.type_0 = format;
				list_0.Add(@class);
			}
			@class.object_0 = data;
		}

		public void SetData(string format, object data)
		{
			Class185 @class = method_1(format);
			if (@class == null)
			{
				@class = new Class185();
				@class.string_0 = format;
				list_0.Add(@class);
			}
			@class.object_0 = data;
			if (data != null)
			{
				@class.type_0 = data.GetType();
			}
		}

		public void SetData(string format, bool autoConvert, object data)
		{
			SetData(format, data);
		}

		private Class185 method_0(Type type_0)
		{
			int num = 3;
			if (type_0 == null)
			{
				throw new ArgumentNullException("format");
			}
			foreach (Class185 item in list_0)
			{
				if (item.type_0 != null && (item.type_0.Equals(type_0) || type_0.IsAssignableFrom(type_0)))
				{
					return item;
				}
			}
			return null;
		}

		private Class185 method_1(string string_0)
		{
			int num = 9;
			if (string.IsNullOrEmpty(string_0))
			{
				throw new ArgumentNullException("format");
			}
			foreach (Class185 item in list_0)
			{
				if (string.Compare(item.string_0, string_0, ignoreCase: true) == 0)
				{
					return item;
				}
			}
			return null;
		}
	}
}
