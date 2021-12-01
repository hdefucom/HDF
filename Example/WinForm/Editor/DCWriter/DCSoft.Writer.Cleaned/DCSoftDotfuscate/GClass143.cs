#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass143
	{
		private static Dictionary<int, DateTime> dictionary_0 = new Dictionary<int, DateTime>();

		private static Hashtable hashtable_0 = new Hashtable();

		private static bool bool_0 = true;

		private static GClass138[] gclass138_0 = null;

		private static volatile GClass138[] gclass138_1 = null;

		private static readonly object object_0 = new object();

		private static object object_1 = null;

		private static volatile List<GClass138> list_0 = null;

		private static string string_0 = null;

		internal static GClass138[] smethod_0(string string_1, bool bool_1)
		{
			try
			{
				if (object_1 == object_0)
				{
					return null;
				}
				if (object_1 == null)
				{
					byte[] array = Class150.smethod_0();
					string b = "Load";
					string name = "DCSoft.MyLicense.MyLicenseDataLoader";
					List<Type> list = new List<Type>();
					Type type = typeof(GClass143).Assembly.GetType(name, throwOnError: false, ignoreCase: true);
					if (type != null)
					{
						list.Add(type);
					}
					else
					{
						MethodInfo[] methods = typeof(AppDomain).GetMethods();
						foreach (MethodInfo methodInfo in methods)
						{
							if (methodInfo.Name == b)
							{
								ParameterInfo[] parameters = methodInfo.GetParameters();
								if (parameters != null && parameters.Length == 1 && parameters[0].ParameterType == typeof(byte[]))
								{
									Assembly assembly = (Assembly)methodInfo.Invoke(AppDomain.CurrentDomain, new object[1]
									{
										array
									});
									if (assembly != null)
									{
										list.AddRange(assembly.GetTypes());
									}
									break;
								}
							}
						}
						if (list.Count == 0)
						{
							return null;
						}
					}
					foreach (Type item in list)
					{
						if (!item.IsPublic)
						{
						}
						MethodInfo[] methods2 = item.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
						bool flag = false;
						MethodInfo[] methods = methods2;
						foreach (MethodInfo methodInfo2 in methods)
						{
							if (methodInfo2.ReturnType == typeof(int))
							{
								ParameterInfo[] parameters = methodInfo2.GetParameters();
								if (parameters == null || parameters.Length <= 0)
								{
									flag = true;
									int num = (int)methodInfo2.Invoke(null, null);
									Random random = new Random(28348092);
									for (int j = 0; j < 28; j++)
									{
										random.Next();
									}
									if (random.Next() != num)
									{
										flag = false;
									}
								}
							}
						}
						if (flag)
						{
							methods = methods2;
							foreach (MethodInfo methodInfo2 in methods)
							{
								if (methodInfo2.IsStatic && methodInfo2.ReturnType == typeof(object[]))
								{
									ParameterInfo[] parameters = methodInfo2.GetParameters();
									if (parameters != null && parameters.Length == 7 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool) && parameters[2].ParameterType == typeof(bool) && parameters[3].ParameterType == typeof(string) && parameters[4].ParameterType == typeof(int) && parameters[5].ParameterType == typeof(string) && parameters[6].ParameterType == typeof(string))
									{
										object_1 = methodInfo2;
										break;
									}
								}
							}
							if (object_1 != null)
							{
								break;
							}
						}
					}
					if (object_1 == null)
					{
						object_1 = object_0;
					}
				}
				if (object_1 != null)
				{
					object[] array2 = (object[])((MethodInfo)object_1).Invoke(null, new object[7]
					{
						string_1,
						bool_1,
						false,
						string.Empty,
						0,
						string.Empty,
						string.Empty
					});
					if (array2 != null)
					{
						List<GClass138> list2 = new List<GClass138>();
						object[] array3 = array2;
						foreach (object obj in array3)
						{
							if (obj is GClass138)
							{
								list2.Add((GClass138)obj);
							}
						}
						return list2.ToArray();
					}
				}
			}
			catch (Exception)
			{
			}
			return null;
		}

		public static void smethod_1(int int_0, DateTime dateTime_0)
		{
			dictionary_0[int_0] = dateTime_0;
		}

		public static string smethod_2(string string_1)
		{
			if (string.IsNullOrEmpty(string_1))
			{
				return null;
			}
			byte[] bytes = Encoding.UTF8.GetBytes(string_1);
			byte b = (byte)Environment.TickCount;
			for (int i = 0; i < bytes.Length; i++)
			{
				bytes[i] = (byte)(bytes[i] ^ b);
			}
			byte[] array = new byte[bytes.Length + 2];
			Array.Copy(bytes, array, bytes.Length);
			array[bytes.Length] = 1;
			array[bytes.Length + 1] = b;
			return Convert.ToBase64String(array);
		}

		public static string smethod_3(string string_1)
		{
			if (string.IsNullOrEmpty(string_1))
			{
				return null;
			}
			byte[] array = Convert.FromBase64String(string_1);
			byte b = array[array.Length - 2];
			if (b == 1)
			{
				byte b2 = array[array.Length - 1];
				for (int num = array.Length - 2; num >= 0; num--)
				{
					array[num] = (byte)(array[num] ^ b2);
				}
				return Encoding.UTF8.GetString(array, 0, array.Length - 2);
			}
			return null;
		}

		public static GAttribute2[] smethod_4(MemberInfo memberInfo_0)
		{
			if (hashtable_0.ContainsKey(memberInfo_0))
			{
				return (GAttribute2[])hashtable_0[memberInfo_0];
			}
			ArrayList arrayList = new ArrayList();
			Attribute[] customAttributes = Attribute.GetCustomAttributes(memberInfo_0, typeof(GAttribute2));
			for (int i = 0; i < customAttributes.Length; i++)
			{
				GAttribute2 value = (GAttribute2)customAttributes[i];
				arrayList.Add(value);
			}
			if (arrayList.Count > 0)
			{
				GAttribute2[] array = (GAttribute2[])arrayList.ToArray(typeof(GAttribute2));
				hashtable_0[memberInfo_0] = array;
				return array;
			}
			hashtable_0[memberInfo_0] = null;
			return null;
		}

		public static bool smethod_5()
		{
			return bool_0;
		}

		public static void smethod_6(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public static bool smethod_7(string string_1, bool bool_1)
		{
			gclass138_0 = smethod_0(string_1, bool_1: false);
			return gclass138_0 != null && gclass138_0.Length > 0;
		}

		public static bool smethod_8()
		{
			return list_0 == null || list_0.Count == 0;
		}

		public static GClass138[] smethod_9()
		{
			int num = 8;
			GEnum21 gEnum = Class154.smethod_1();
			if (gEnum == GEnum21.const_0)
			{
				gclass138_1 = null;
			}
			if (gclass138_1 == null)
			{
				lock (typeof(GClass143))
				{
					if (gEnum == GEnum21.const_1)
					{
						new List<GClass138>();
						string string_ = Class154.smethod_4("ffffffff", "ffffffff");
						gclass138_1 = smethod_0(string_, bool_1: false);
						if (gclass138_1 != null)
						{
							GClass138[] array = gclass138_1;
							foreach (GClass138 gClass in array)
							{
								gClass.method_11(Enum15.const_1);
							}
						}
					}
				}
			}
			return gclass138_1;
		}

		internal static GClass138 smethod_10(string string_1)
		{
			GClass138[] array = smethod_0(string_1, bool_1: false);
			if (array != null && array.Length > 0)
			{
				return array[0];
			}
			return null;
		}

		private static string smethod_11()
		{
			string name = "DCSoft.MyLicense.dlgStartPassword";
			Type type = typeof(GClass143).Assembly.GetType(name, throwOnError: false);
			if (type != null)
			{
				using (Form form = (Form)Activator.CreateInstance(type))
				{
					string name2 = "PasswordText";
					PropertyInfo property = type.GetProperty(name2);
					if (form.ShowDialog() == DialogResult.OK)
					{
						return (string)property.GetValue(form, null);
					}
				}
			}
			return null;
		}

		public static string smethod_12(bool bool_1)
		{
			int num = 10;
			lock (typeof(GClass143))
			{
				GEnum21 gEnum = Class154.smethod_1();
				GClass138[] array = null;
				if (gEnum == GEnum21.const_1)
				{
					string string_ = Class154.smethod_4("ffffffff", "ffffffff");
					array = smethod_0(string_, bool_1: false);
				}
				if (array != null && array.Length > 0)
				{
					GClass138[] array2 = array;
					foreach (GClass138 gClass in array2)
					{
						if (gClass.method_26() && smethod_30(gClass, bool_1: false, bool_2: false, bool_3: true))
						{
							if (!string.IsNullOrEmpty(gClass.method_51()))
							{
								if (!bool_1)
								{
									return null;
								}
								string text = smethod_11();
								if (text == null)
								{
									return null;
								}
								if (text != gClass.method_51())
								{
									MessageBox.Show(Class151.smethod_9());
									return null;
								}
							}
							Class143 @class = new Class143();
							@class.method_5(gClass.method_28());
							@class.method_29(gClass.method_48());
							@class.method_33(gClass.method_50());
							@class.method_27(gClass.method_39());
							@class.method_23(gClass.method_37());
							@class.method_21(gClass.method_36());
							@class.method_15(gClass.method_31());
							@class.method_17(smethod_32());
							@class.method_19(gClass.method_33());
							Enum14 @enum = gClass.method_13();
							@enum &= ~Enum14.flag_19;
							@enum &= ~Enum14.flag_18;
							@enum &= ~Enum14.flag_15;
							@enum &= ~Enum14.flag_13;
							@enum |= Enum14.flag_1;
							@class.method_1(@enum);
							return @class.method_34();
						}
					}
				}
			}
			return null;
		}

		public static bool smethod_13(int int_0)
		{
			GClass138 gClass = smethod_24(int_0);
			if (gClass != null && gClass.method_21())
			{
				if (gClass.method_34())
				{
					if (gClass.method_22())
					{
						if (gClass.method_10() == Enum15.const_1)
						{
							return true;
						}
						GClass138[] array = smethod_9();
						if (array != null)
						{
							GClass138[] array2 = array;
							foreach (GClass138 gClass2 in array2)
							{
								if (gClass.method_33() == gClass2.method_33() && gClass.method_17() == gClass2.method_17() && gClass.method_28() == gClass2.method_28() && gClass.method_50() == gClass2.method_50())
								{
									return true;
								}
							}
						}
						return false;
					}
					return true;
				}
				return false;
			}
			return true;
		}

		public static bool smethod_14(bool bool_1)
		{
			gclass138_1 = null;
			GClass138[] array = smethod_9();
			bool result = false;
			if (array != null && array.Length > 0)
			{
				GClass138[] array2 = array;
				foreach (GClass138 gclass138_ in array2)
				{
					if (smethod_30(gclass138_, bool_1: false, bool_2: false, bool_1))
					{
						smethod_25(gclass138_);
						result = true;
					}
				}
				return result;
			}
			return false;
		}

		public static bool smethod_15(byte[] byte_0, bool bool_1)
		{
			return smethod_18(GClass145.smethod_3(byte_0), bool_1);
		}

		public static bool smethod_16(Stream stream_0, bool bool_1)
		{
			using (StreamReader streamReader = new StreamReader(stream_0, Encoding.ASCII))
			{
				string string_ = streamReader.ReadToEnd();
				return smethod_18(string_, bool_1);
			}
		}

		public static bool smethod_17(string string_1, bool bool_1)
		{
			if (string.IsNullOrEmpty(string_1))
			{
				return false;
			}
			try
			{
				string string_2 = null;
				Uri uri = new Uri(string_1);
				if (uri.Scheme == Uri.UriSchemeFile)
				{
					string localPath = uri.LocalPath;
					if (File.Exists(localPath))
					{
						string_2 = File.ReadAllText(localPath, Encoding.ASCII);
					}
				}
				else if (uri.Scheme == Uri.UriSchemeHttp)
				{
					using (WebClient webClient = new WebClient())
					{
						string_2 = webClient.DownloadString(string_1);
					}
				}
				return smethod_18(string_2, bool_1);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				return false;
			}
		}

		public static bool smethod_18(string string_1, bool bool_1)
		{
			if (string_1 == null || string.IsNullOrEmpty(string_1))
			{
				return false;
			}
			try
			{
				GClass138[] array = smethod_0(string_1, bool_1: false);
				bool result = false;
				if (array != null && array.Length > 0)
				{
					GClass138[] array2 = array;
					foreach (GClass138 gClass in array2)
					{
						if (smethod_30(gClass, bool_1: false, bool_2: false, bool_1))
						{
							smethod_25(gClass);
							result = true;
						}
						else
						{
							smethod_23(gClass.method_28());
						}
					}
				}
				return result;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static bool smethod_19(int int_0)
		{
			return smethod_24(int_0)?.method_34() ?? false;
		}

		public static bool smethod_20(Type type_0, int int_0, bool bool_1)
		{
			GClass138 gClass = smethod_24(int_0);
			if (gClass.method_45())
			{
				string a = GAttribute5.smethod_0(type_0);
				if (a != gClass.method_48())
				{
					if (bool_1)
					{
						throw new GException13(Class151.smethod_2());
					}
					return false;
				}
			}
			return true;
		}

		public static bool smethod_21(bool bool_1, bool bool_2)
		{
			StackTrace stackTrace = new StackTrace();
			StackFrame frame = stackTrace.GetFrame(1);
			MethodBase method = frame.GetMethod();
			if (method != null)
			{
				GAttribute2[] gattribute2_ = smethod_4(method);
				return smethod_28(gattribute2_, bool_1, bool_2);
			}
			return true;
		}

		public static bool smethod_22(int int_0, string string_1, bool bool_1, bool bool_2)
		{
			GClass138 gClass = smethod_24(int_0);
			if (gClass != null && ((gClass.method_14() & Enum13.flag_24) == Enum13.flag_24 || (gClass.method_13() & Enum14.flag_13) == Enum14.flag_13))
			{
				if (gClass.method_51() != string_1 && bool_1)
				{
					string_1 = smethod_11();
				}
				if (string_1 != gClass.method_51())
				{
					if (bool_2)
					{
						throw new GException13(Class151.smethod_9());
					}
					return false;
				}
			}
			return true;
		}

		public static void smethod_23(int int_0)
		{
			if (list_0 != null)
			{
				foreach (GClass138 item in list_0)
				{
					item.method_29(int_0);
				}
			}
			if (gclass138_0 != null)
			{
				GClass138[] array = gclass138_0;
				foreach (GClass138 current in array)
				{
					current.method_29(int_0);
				}
			}
			if (gclass138_1 != null)
			{
				GClass138[] array = gclass138_1;
				foreach (GClass138 current in array)
				{
					current.method_29(int_0);
				}
			}
			hashtable_0.Clear();
		}

		public static GClass138 smethod_24(int int_0)
		{
			if (gclass138_0 != null)
			{
				GClass138[] array = gclass138_0;
				foreach (GClass138 gClass in array)
				{
					if (gClass.method_30(int_0))
					{
						return gClass;
					}
				}
			}
			if (list_0 != null)
			{
				foreach (GClass138 item in list_0)
				{
					if (item.method_30(int_0))
					{
						return item;
					}
				}
			}
			return GClass138.smethod_0();
		}

		private static void smethod_25(GClass138 gclass138_2)
		{
			if (list_0 == null)
			{
				list_0 = new List<GClass138>();
			}
			for (int num = list_0.Count - 1; num >= 0; num--)
			{
				if (list_0[num].method_28() == gclass138_2.method_28())
				{
					list_0.RemoveAt(num);
				}
			}
			list_0.Add(gclass138_2);
		}

		public static bool smethod_26(int int_0, int int_1, bool bool_1, bool bool_2)
		{
			GClass138 gClass = smethod_24(int_1);
			if (gClass != null && smethod_30(gClass, bool_1, bool_2: false, bool_2) && smethod_29(gClass, int_0))
			{
				return true;
			}
			if (bool_1)
			{
				throw new GException13(Class151.smethod_6());
			}
			return false;
		}

		public static bool smethod_27(MemberInfo memberInfo_0, bool bool_1, bool bool_2)
		{
			GAttribute2[] gattribute2_ = smethod_4(memberInfo_0);
			return smethod_28(gattribute2_, bool_1, bool_2);
		}

		public static bool smethod_28(GAttribute2[] gattribute2_0, bool bool_1, bool bool_2)
		{
			if (gattribute2_0 == null || gattribute2_0.Length == 0)
			{
				return true;
			}
			int num = 0;
			while (true)
			{
				if (num < gattribute2_0.Length)
				{
					GAttribute2 gAttribute = gattribute2_0[num];
					GClass138 gClass = smethod_24(gAttribute.method_1());
					if (gClass != null && smethod_30(gClass, bool_1, bool_2: false, bool_2))
					{
						long num2 = 1L << gAttribute.method_0();
						if ((gClass.method_31() & num2) == num2)
						{
							break;
						}
					}
					num++;
					continue;
				}
				if (bool_1)
				{
					throw new GException13(Class151.smethod_8());
				}
				return false;
			}
			return true;
		}

		private static bool smethod_29(GClass138 gclass138_2, int int_0)
		{
			long num = 1L << int_0;
			return (gclass138_2.method_31() & num) == num;
		}

		private static bool smethod_30(GClass138 gclass138_2, bool bool_1, bool bool_2, bool bool_3)
		{
			if (gclass138_2 == GClass138.smethod_0())
			{
				return true;
			}
			if (gclass138_2.method_15(Enum14.flag_25, Enum13.flag_23))
			{
				GClass137 gClass = new GClass137(gclass138_2.method_7());
				if (!gClass.method_0())
				{
					if (bool_1)
					{
						throw new Exception(Class151.smethod_7());
					}
					return false;
				}
			}
			if (gclass138_2.method_21() && !Debugger.IsAttached)
			{
				return true;
			}
			if (!bool_2 && gclass138_2.method_15(Enum14.flag_1, Enum13.flag_2) && gclass138_2.method_32() != smethod_32())
			{
				if (bool_1)
				{
					throw new Exception(Class151.smethod_10());
				}
				return false;
			}
			if (gclass138_2.method_15(Enum14.flag_15, Enum13.flag_28) && gclass138_2.method_18() != smethod_31())
			{
				if (bool_1)
				{
					throw new GException13(Class151.smethod_4());
				}
				return false;
			}
			if (gclass138_2.method_15(Enum14.flag_6, Enum13.flag_3) && gclass138_2.method_37() < DateTime.Now)
			{
				if (bool_1)
				{
					throw new GException13(Class151.smethod_5());
				}
				return false;
			}
			if (gclass138_2.method_15(Enum14.flag_27, Enum13.flag_26))
			{
				foreach (int key in dictionary_0.Keys)
				{
					if ((gclass138_2.method_28() & key) == key)
					{
						DateTime t = dictionary_0[key];
						if (t > gclass138_2.method_5())
						{
							if (!bool_1)
							{
							}
							return false;
						}
					}
				}
			}
			if (bool_3 && gclass138_2.method_15(Enum14.flag_12, Enum13.flag_11) && gclass138_2.method_39() < DateTime.Now)
			{
				if (bool_1)
				{
					throw new GException13(Class151.smethod_3());
				}
				return false;
			}
			return true;
		}

		public static string smethod_31()
		{
			return Class154.smethod_0();
		}

		public static string smethod_32()
		{
			int num = 4;
			if (string_0 == null)
			{
				string string_ = "Win32_NetworkAdapter";
				string string_2 = "MACAddress";
				object obj = smethod_33(string_, string_2);
				if (obj != null)
				{
					string text = Convert.ToString(obj);
					text = text.ToUpper();
					text = GClass145.smethod_2(text, "0123456789ABCDEF");
					string_0 = "N" + text;
				}
				else
				{
					string string_3 = "Win32_Processor";
					string string_4 = "ProcessorId";
					obj = smethod_33(string_3, string_4);
					if (obj != null)
					{
						string_0 = "C" + obj;
					}
					else
					{
						string string_5 = "Win32_DiskDrive";
						string string_6 = "Signature";
						obj = smethod_33(string_5, string_6);
						if (obj != null)
						{
							string_0 = "D" + obj;
						}
					}
				}
				if (string_0 == null)
				{
					string text2 = string_0 = "BadSystemID";
				}
			}
			return string_0;
		}

		internal static object smethod_33(string string_1, string string_2)
		{
			using (ManagementClass managementClass = new ManagementClass(string_1))
			{
				using (ManagementObjectCollection managementObjectCollection = managementClass.GetInstances())
				{
					foreach (ManagementObject item in managementObjectCollection)
					{
						foreach (PropertyData property in item.Properties)
						{
							if (property.Name == string_2 && property.Value != null)
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
