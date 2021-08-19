using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass145
	{
		public const int int_0 = 2;

		public const int int_1 = 32;

		public const int int_2 = 4;

		public const int int_3 = 8;

		public const int int_4 = 16;

		public const int int_5 = 64;

		public const string string_0 = "5D3C9445-3D81-4d23-86C9-3F051737E3A1";

		public const string string_1 = "1B016C4C-E796-4d29-875A-37541BD4ADEF";

		public const string string_2 = "0123456789ABCDEF";

		private static int int_6 = 0;

		private static Dictionary<Type, string> dictionary_0 = new Dictionary<Type, string>();

		public static GClass138 smethod_0(GClass138 gclass138_0, int int_7, Type type_0, DateTime dateTime_0)
		{
			GClass138 gClass = gclass138_0;
			int_6++;
			if ((gClass?.method_34() ?? false) && int_6 % 100 != 0 && gClass != null && gClass.method_34())
			{
				return gClass;
			}
			string text = smethod_1(type_0);
			if (string.IsNullOrEmpty(text))
			{
				if (gClass != null && gClass.method_12())
				{
					return gClass;
				}
				return GClass138.smethod_0();
			}
			if (gClass != null)
			{
				int hashCode = text.GetHashCode();
				if (gClass.method_1() != hashCode)
				{
					GClass143.smethod_23(int_7);
					gClass = null;
				}
			}
			if (gClass == null)
			{
				GClass143.smethod_1(int_7, dateTime_0);
				gClass = GClass143.smethod_24(int_7);
				if ((gClass != null && !gClass.method_3()) || GClass143.smethod_14(bool_1: false) || GClass143.smethod_18(text, bool_1: false))
				{
				}
				gClass = GClass143.smethod_24(int_7);
				if (gClass == null)
				{
					gClass = GClass138.smethod_0();
				}
				else if (!string.IsNullOrEmpty(text))
				{
					gClass.method_2(text.GetHashCode());
				}
				else
				{
					gClass.method_2(0);
				}
			}
			return gClass;
		}

		private static string smethod_1(Type type_0)
		{
			if (type_0 == null)
			{
				return null;
			}
			string name = "_RegisterCode";
			FieldInfo field = type_0.GetField(name, BindingFlags.IgnoreCase | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			if (field != null)
			{
				string text = (string)field.GetValue(null);
				if (!string.IsNullOrEmpty(text))
				{
					return text;
				}
			}
			if (dictionary_0.ContainsKey(type_0))
			{
				return dictionary_0[type_0];
			}
			string name2 = "_RegisterCodeFileUrl";
			field = type_0.GetField(name2, BindingFlags.IgnoreCase | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			if (field != null)
			{
				string text2 = "";
				string text3 = (string)field.GetValue(null);
				if (!string.IsNullOrEmpty(text3))
				{
					try
					{
						Uri uri = new Uri(text3);
						if (uri.Scheme == Uri.UriSchemeFile)
						{
							string localPath = uri.LocalPath;
							if (File.Exists(localPath))
							{
								text2 = File.ReadAllText(localPath, Encoding.ASCII);
							}
						}
						else if (uri.Scheme == Uri.UriSchemeHttp)
						{
							using (WebClient webClient = new WebClient())
							{
								text2 = webClient.DownloadString(text3);
							}
						}
					}
					catch (Exception)
					{
					}
				}
				dictionary_0[type_0] = text2;
				field?.SetValue(null, text2);
				return text2;
			}
			return null;
		}

		internal static string smethod_2(string string_3, string string_4)
		{
			if (string_3 == null || string_3.Length == 0)
			{
				return string_3;
			}
			if (string_4 == null || string_4.Length == 0)
			{
				return string_3;
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char value in string_3)
			{
				if (string_4.IndexOf(value) >= 0)
				{
					stringBuilder.Append(value);
				}
			}
			return stringBuilder.ToString();
		}

		internal static string smethod_3(byte[] byte_0)
		{
			int num = 0;
			if (byte_0 == null || byte_0.Length == 0)
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (byte b in byte_0)
			{
				stringBuilder.Append("0123456789ABCDEF"[b >> 4]);
				stringBuilder.Append("0123456789ABCDEF"[b & 0xF]);
			}
			return stringBuilder.ToString();
		}
	}
}
