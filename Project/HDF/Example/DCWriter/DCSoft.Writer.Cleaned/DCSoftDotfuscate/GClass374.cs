using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GClass374 : Dictionary<GClass371, object>, ISerializable
	{
		private object[] object_0 = null;

		public GClass374()
		{
		}

		protected GClass374(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			object_0 = (object[])serializationInfo_0.GetValue("Values", typeof(object[]));
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			int num = 0;
			object[] array = new object[base.Count * 2];
			int num2 = 0;
			foreach (GClass371 key in base.Keys)
			{
				array[num2 * 2] = key.Name;
				array[num2 * 2 + 1] = base[key];
				num2++;
			}
			info.AddValue("Values", array, typeof(object[]));
		}

		public void method_0(Type type_0)
		{
			if (object_0 != null)
			{
				for (int i = 0; i < object_0.Length; i += 2)
				{
					string string_ = (string)object_0[i];
					object value = object_0[i + 1];
					GClass371 key = GClass371.smethod_2(type_0, string_);
					base[key] = value;
				}
				object_0 = null;
			}
		}
	}
}
