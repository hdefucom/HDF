using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass343
	{
		private static Dictionary<string, ImageFormat> dictionary_0;

		private static Dictionary<string, string> dictionary_1;

		private static Dictionary<string, Image> dictionary_2;

		private static Dictionary<byte[], Image> dictionary_3;

		static GClass343()
		{
			dictionary_0 = null;
			dictionary_1 = null;
			dictionary_2 = new Dictionary<string, Image>();
			dictionary_3 = new Dictionary<byte[], Image>();
			dictionary_0 = new Dictionary<string, ImageFormat>();
			dictionary_0["bmp"] = ImageFormat.Bmp;
			dictionary_0["emf"] = ImageFormat.Emf;
			dictionary_0["exif"] = ImageFormat.Exif;
			dictionary_0["gif"] = ImageFormat.Gif;
			dictionary_0["icon"] = ImageFormat.Icon;
			dictionary_0["png"] = ImageFormat.Png;
			dictionary_0["tiff"] = ImageFormat.Tiff;
			dictionary_0["wmf"] = ImageFormat.Wmf;
			dictionary_0["jpeg"] = ImageFormat.Jpeg;
			dictionary_0["jpg"] = ImageFormat.Jpeg;
			dictionary_1 = new Dictionary<string, string>();
			dictionary_1["bmp"] = "image/bmp";
			dictionary_1["gif"] = "image/gif";
			dictionary_1["jpg"] = "image/jpg";
			dictionary_1["jpeg"] = "image/jpeg";
			dictionary_1["tif"] = "image/tif";
			dictionary_1["tiff"] = "image/tif";
			dictionary_1["ico"] = "image/x-icon";
			dictionary_1["png"] = "image/png";
		}

		public static string smethod_0(ImageFormat imageFormat_0)
		{
			int num = 15;
			string text = smethod_2(imageFormat_0);
			if (text != null && dictionary_1.ContainsKey(text))
			{
				return dictionary_1[text];
			}
			return "image";
		}

		public static string smethod_1(string string_0)
		{
			foreach (string key in dictionary_1.Keys)
			{
				if (string.Compare(key, string_0, ignoreCase: true) == 0)
				{
					return dictionary_1[key];
				}
			}
			return null;
		}

		public static string smethod_2(ImageFormat imageFormat_0)
		{
			if (imageFormat_0 == null)
			{
				return null;
			}
			foreach (string key in dictionary_0.Keys)
			{
				if (dictionary_0[key].Guid == imageFormat_0.Guid)
				{
					return key;
				}
			}
			return null;
		}

		public static ImageFormat smethod_3(string string_0)
		{
			if (string_0 == null)
			{
				return null;
			}
			int num = string_0.LastIndexOf('.');
			if (num >= 0)
			{
				string_0 = string_0.Substring(num + 1);
			}
			string_0 = string_0.Trim().ToLower();
			if (dictionary_0.ContainsKey(string_0))
			{
				return dictionary_0[string_0];
			}
			return null;
		}

		public static string smethod_4(string string_0)
		{
			if (string_0 == null)
			{
				return null;
			}
			int num = string_0.LastIndexOf('.');
			if (num >= 0)
			{
				string_0 = string_0.Substring(num).Trim().ToLower();
				if (dictionary_1.ContainsKey(string_0))
				{
					return dictionary_1[string_0];
				}
			}
			return null;
		}

		public static ImageFormat smethod_5(string string_0)
		{
			int num = 7;
			if (string_0 == null)
			{
				return null;
			}
			string_0 = string_0.Trim().ToLower();
			if (string_0.StartsWith("."))
			{
				string_0 = string_0.Substring(1);
			}
			string_0 = string_0.Trim();
			if (dictionary_0.ContainsKey(string_0))
			{
				return dictionary_0[string_0];
			}
			return null;
		}

		public static bool smethod_6(string string_0)
		{
			int num = 3;
			if (string_0 == null)
			{
				return false;
			}
			string_0 = string_0.Trim().ToLower();
			foreach (string key in dictionary_0.Keys)
			{
				if (string_0.EndsWith("." + key))
				{
					return true;
				}
			}
			return false;
		}

		public static Image smethod_7(string string_0)
		{
			int num = 7;
			try
			{
				if (string_0 == null)
				{
					return null;
				}
				if (!File.Exists(string_0))
				{
					return null;
				}
				return Image.FromFile(string_0);
			}
			catch (Exception ex)
			{
				Console.WriteLine("SafeLoadImage :" + ex.ToString());
			}
			return null;
		}

		public static Image smethod_8(string string_0)
		{
			if (!string.IsNullOrEmpty(string_0) && File.Exists(string_0))
			{
				if (dictionary_2.ContainsKey(string_0))
				{
					return dictionary_2[string_0];
				}
				Image image = Image.FromFile(string_0);
				dictionary_2[string_0] = image;
				return image;
			}
			return null;
		}

		public static Image smethod_9(string string_0)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				return null;
			}
			byte[] array = Convert.FromBase64String(string_0);
			foreach (byte[] key in dictionary_3.Keys)
			{
				if (array.Length == key.Length)
				{
					bool flag = true;
					for (int i = 0; i < array.Length; i++)
					{
						if (array[i] != key[i])
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						return dictionary_3[key];
					}
				}
			}
			MemoryStream stream = new MemoryStream(array);
			Image image = Image.FromStream(stream);
			dictionary_3[array] = image;
			return image;
		}

		private GClass343()
		{
		}
	}
}
