using DCSoft.Common;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass530
	{
		
		public static GEnum88 smethod_0(object object_0)
		{
			if (object_0 == null)
			{
				return GEnum88.flag_0;
			}
			string b = "PageTitlePosition";
			FieldInfo[] fields = object_0.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
			int num = 0;
			FieldInfo fieldInfo;
			while (true)
			{
				if (num < fields.Length)
				{
					fieldInfo = fields[num];
					if (fieldInfo.FieldType.Name == b)
					{
						break;
					}
					num++;
					continue;
				}
				return GEnum88.flag_0;
			}
			return (GEnum88)fieldInfo.GetValue(object_0);
		}
	}
}
