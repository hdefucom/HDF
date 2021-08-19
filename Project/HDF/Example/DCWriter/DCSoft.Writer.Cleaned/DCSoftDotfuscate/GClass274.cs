using System;
using System.Collections;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public abstract class GClass274
	{
		[ComVisible(false)]
		public class GClass277
		{
			private string string_0 = null;

			private object object_0 = null;

			public string Name => string_0;

			public GClass277(string string_1, object object_1)
			{
				string_0 = string_1;
				object_0 = object_1;
			}

			public object method_0()
			{
				return object_0;
			}
		}

		protected ArrayList arrayList_0 = new ArrayList();

		protected GClass274()
		{
			vmethod_1();
		}

		public virtual string vmethod_0()
		{
			return null;
		}

		public object method_0(string string_0)
		{
			object obj = null;
			foreach (GClass277 item in arrayList_0)
			{
				if (item.Name == string_0 && obj == null)
				{
					obj = item.method_0();
					if (obj != null)
					{
						break;
					}
				}
			}
			return obj;
		}

		public string method_1(string string_0)
		{
			object obj = method_0(string_0);
			if (obj == null)
			{
				return null;
			}
			return Convert.ToString(obj);
		}

		public bool method_2(string string_0)
		{
			object obj = method_0(string_0);
			if (obj == null)
			{
				return false;
			}
			return Convert.ToBoolean(obj);
		}

		public int method_3(string string_0)
		{
			object obj = method_0(string_0);
			if (obj == null)
			{
				return 0;
			}
			return Convert.ToInt32(obj);
		}

		public ulong method_4(string string_0)
		{
			object obj = method_0(string_0);
			if (obj == null)
			{
				return 0uL;
			}
			return Convert.ToUInt64(obj);
		}

		public ushort method_5(string string_0)
		{
			object obj = method_0(string_0);
			if (obj == null)
			{
				return 0;
			}
			return Convert.ToUInt16(obj);
		}

		public uint method_6(string string_0)
		{
			object obj = method_0(string_0);
			if (obj == null)
			{
				return 0u;
			}
			return Convert.ToUInt32(obj);
		}

		public DateTime method_7(string string_0)
		{
			object obj = method_0(string_0);
			if (obj == null)
			{
				return DateTime.MinValue;
			}
			return Convert.ToDateTime(obj);
		}

		public virtual void vmethod_1()
		{
			arrayList_0.Clear();
			using (ManagementClass managementClass = new ManagementClass(vmethod_0()))
			{
				using (ManagementObjectCollection managementObjectCollection = managementClass.GetInstances())
				{
					using (ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = managementObjectCollection.GetEnumerator())
					{
						if (managementObjectEnumerator.MoveNext())
						{
							ManagementObject managementObject = (ManagementObject)managementObjectEnumerator.Current;
							foreach (PropertyData property in managementObject.Properties)
							{
								arrayList_0.Add(new GClass277(property.Name, property.Value));
							}
						}
					}
				}
			}
		}

		public override string ToString()
		{
			int num = 12;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(vmethod_0());
			foreach (GClass277 item in arrayList_0)
			{
				stringBuilder.Append(Environment.NewLine);
				stringBuilder.Append(item.Name + "=" + item.method_0());
			}
			return stringBuilder.ToString();
		}

		public static object smethod_0(string string_0, string string_1)
		{
			using (ManagementClass managementClass = new ManagementClass(string_0))
			{
				using (ManagementObjectCollection managementObjectCollection = managementClass.GetInstances())
				{
					foreach (ManagementObject item in managementObjectCollection)
					{
						foreach (PropertyData property in item.Properties)
						{
							if (property.Name == string_1 && property.Value != null)
							{
								return property.Value;
							}
						}
					}
				}
			}
			return null;
		}
	}
}
