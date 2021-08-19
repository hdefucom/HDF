using System.Collections;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass335
	{
		public const string string_0 = "FileNameW";

		private IDataObject idataObject_0 = null;

		public static GClass335 smethod_0()
		{
			return new GClass335(Clipboard.GetDataObject());
		}

		public GClass335(IDataObject idataObject_1)
		{
			idataObject_0 = idataObject_1;
		}

		public GClass335(DragEventArgs dragEventArgs_0)
		{
			idataObject_0 = dragEventArgs_0.Data;
		}

		public IDataObject method_0()
		{
			return idataObject_0;
		}

		public string[] method_1()
		{
			if (idataObject_0 != null)
			{
				return idataObject_0.GetFormats();
			}
			return null;
		}

		public bool method_2(string string_1)
		{
			if (idataObject_0 == null)
			{
				return false;
			}
			return idataObject_0.GetDataPresent(string_1);
		}

		public object method_3()
		{
			string[] formats = idataObject_0.GetFormats();
			if (formats != null && formats.Length > 0)
			{
				return idataObject_0.GetData(formats[0]);
			}
			return null;
		}

		public bool method_4()
		{
			int num = 6;
			if (idataObject_0 == null)
			{
				return false;
			}
			if (idataObject_0.GetDataPresent(DataFormats.Bitmap))
			{
				return true;
			}
			if (idataObject_0.GetDataPresent(DataFormats.Tiff))
			{
				return true;
			}
			if (idataObject_0.GetDataPresent("PNG"))
			{
				return true;
			}
			if (idataObject_0.GetDataPresent("GIF"))
			{
				return true;
			}
			return false;
		}

		public Image method_5()
		{
			int num = 5;
			if (idataObject_0 == null)
			{
				return null;
			}
			object obj = null;
			if (idataObject_0.GetDataPresent(DataFormats.Bitmap))
			{
				obj = idataObject_0.GetData(DataFormats.Bitmap);
			}
			else if (idataObject_0.GetDataPresent(DataFormats.Tiff))
			{
				obj = idataObject_0.GetData(DataFormats.Tiff);
			}
			else if (idataObject_0.GetDataPresent("PNG"))
			{
				obj = idataObject_0.GetData("PNG");
			}
			else if (idataObject_0.GetDataPresent("GIF"))
			{
				obj = idataObject_0.GetData("GIF");
			}
			if (obj is Stream)
			{
				return Image.FromStream((Stream)obj);
			}
			if (obj is Image)
			{
				return (Image)obj;
			}
			return null;
		}

		public void method_6(Image image_0)
		{
			if (idataObject_0 != null)
			{
				idataObject_0.SetData(DataFormats.Bitmap, image_0);
			}
		}

		public bool method_7()
		{
			if (idataObject_0 == null)
			{
				return false;
			}
			return idataObject_0.GetDataPresent(DataFormats.UnicodeText);
		}

		public string method_8()
		{
			if (idataObject_0 == null)
			{
				return null;
			}
			return idataObject_0.GetData(DataFormats.UnicodeText) as string;
		}

		public void method_9(string string_1)
		{
			if (idataObject_0 == null)
			{
				idataObject_0.SetData(DataFormats.UnicodeText, string_1);
			}
		}

		public bool method_10()
		{
			if (idataObject_0 == null)
			{
				return false;
			}
			return idataObject_0.GetDataPresent(DataFormats.Html);
		}

		public string method_11()
		{
			if (idataObject_0 == null)
			{
				return null;
			}
			object data = idataObject_0.GetData(DataFormats.Html);
			return data as string;
		}

		public void method_12(string string_1)
		{
			if (idataObject_0 == null)
			{
				idataObject_0.SetData(DataFormats.Html, string_1);
			}
		}

		public bool method_13()
		{
			if (idataObject_0 == null)
			{
				return false;
			}
			return idataObject_0.GetDataPresent(DataFormats.Rtf);
		}

		public string method_14()
		{
			if (idataObject_0 == null)
			{
				return null;
			}
			return idataObject_0.GetData(DataFormats.Rtf) as string;
		}

		public void method_15(string string_1)
		{
			if (idataObject_0 == null)
			{
				idataObject_0.SetData(DataFormats.Rtf, string_1);
			}
		}

		public bool method_16()
		{
			int num = 7;
			if (idataObject_0 == null)
			{
				return false;
			}
			if (idataObject_0.GetDataPresent(DataFormats.FileDrop))
			{
				return true;
			}
			return idataObject_0.GetDataPresent("FileNameW");
		}

		public string[] method_17()
		{
			int num = 9;
			if (idataObject_0 == null)
			{
				return null;
			}
			object obj = null;
			if (idataObject_0.GetDataPresent(DataFormats.FileDrop))
			{
				obj = idataObject_0.GetData(DataFormats.FileDrop);
			}
			else if (idataObject_0.GetDataPresent("FileNameW"))
			{
				obj = idataObject_0.GetData("FileNameW");
			}
			IEnumerable enumerable = obj as IEnumerable;
			if (enumerable != null)
			{
				ArrayList arrayList = new ArrayList();
				foreach (string item in enumerable)
				{
					if (item != null && item.Length > 0)
					{
						arrayList.Add(item);
					}
				}
				if (arrayList.Count > 0)
				{
					return (string[])arrayList.ToArray(typeof(string));
				}
			}
			return null;
		}

		public string method_18()
		{
			string[] array = method_17();
			if (array != null && array.Length > 0)
			{
				return array[0];
			}
			return null;
		}

		public bool method_19(string string_1)
		{
			if (idataObject_0 != null)
			{
				string[] formats = idataObject_0.GetFormats();
				if (formats != null && formats.Length > 0)
				{
					string[] array = formats;
					foreach (string a in array)
					{
						if (a == string_1)
						{
							return true;
						}
					}
					array = formats;
					foreach (string a in array)
					{
						if (a.EndsWith(string_1))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		public void method_20()
		{
			if (idataObject_0 != null)
			{
				Clipboard.SetDataObject(idataObject_0);
			}
		}
	}
}
