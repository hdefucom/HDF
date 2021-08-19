using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace DCSoftDotfuscate
{
	public static class GClass279
	{
		[ComImport]
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[Guid("00020400-0000-0000-C000-000000000046")]
		private interface Interface1
		{
			[PreserveSig]
			int imethod_0(out int int_0);

			int imethod_1(int int_0, int int_1, out IntPtr intptr_0);

			[PreserveSig]
			int imethod_2(ref Guid guid_0, ref string string_0, int int_0, int int_1, out int int_2);
		}

		private const int int_0 = 0;

		private const int int_1 = 2048;

		public static bool smethod_0(object object_0)
		{
			return object_0 is Interface1;
		}

		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		public static Type smethod_1(object object_0, bool bool_0)
		{
			smethod_3(object_0, "obj");
			return smethod_4((Interface1)object_0, bool_0);
		}

		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		public static bool smethod_2(object object_0, string string_0, out int int_2)
		{
			smethod_3(object_0, "obj");
			return smethod_5((Interface1)object_0, string_0, out int_2);
		}

		public static object Invoke(object object_0, int int_2, object[] object_1)
		{
			string string_ = "[DispId=" + int_2 + "]";
			return Invoke(object_0, string_, object_1);
		}

		public static object Invoke(object object_0, string string_0, object[] object_1)
		{
			smethod_3(object_0, "obj");
			Type type = object_0.GetType();
			return type.InvokeMember(string_0, BindingFlags.InvokeMethod | BindingFlags.GetProperty, null, object_0, object_1, null);
		}

		private static void smethod_3<T>(T gparam_0, string string_0) where T : class
		{
			if (gparam_0 == null)
			{
				throw new ArgumentNullException(string_0);
			}
		}

		private static Type smethod_4(Interface1 interface1_0, bool bool_0)
		{
			smethod_3(interface1_0, "dispatch");
			IntPtr intptr_ = IntPtr.Zero;
			Type type = null;
			int num;
			int num2 = interface1_0.imethod_0(out num);
			if (num2 == 0 && num > 0)
			{
				num2 = interface1_0.imethod_1(0, 2048, out intptr_);
				if (intptr_ != IntPtr.Zero)
				{
					type = Marshal.GetTypeForITypeInfo(intptr_);
				}
			}
			if (type == null && bool_0)
			{
				Marshal.ThrowExceptionForHR(num2);
				throw new TypeLoadException();
			}
			return type;
		}

		private static bool smethod_5(Interface1 interface1_0, string string_0, out int int_2)
		{
			smethod_3(interface1_0, "dispatch");
			smethod_3(string_0, "name");
			bool result = false;
			Guid guid_ = Guid.Empty;
			int num = interface1_0.imethod_2(ref guid_, ref string_0, 1, 2048, out int_2);
			if (num == 0)
			{
				result = true;
			}
			else if (num == -2147352570 && int_2 == -1)
			{
				result = false;
			}
			else
			{
				Marshal.ThrowExceptionForHR(num);
			}
			return result;
		}
	}
}
