using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[Serializable]
	[DefaultMember("Item")]
	public class GClass283 : IDisposable
	{
		public class GClass284
		{
			private string string_0 = null;

			private Image image_0 = null;

			public string method_0()
			{
				return string_0;
			}

			public void method_1(string string_1)
			{
				string_0 = string_1;
			}

			public Image method_2()
			{
				return image_0;
			}

			public void method_3(Image image_1)
			{
				image_0 = image_1;
			}
		}

		protected ArrayList arrayList_0 = new ArrayList();

		protected Size size_0 = new Size(16, 16);

		protected Color color_0 = Color.White;

		public int method_0()
		{
			return arrayList_0.Count;
		}

		public bool method_1(int int_0)
		{
			return int_0 >= 0 && int_0 < method_0();
		}

		public Size method_2()
		{
			return size_0;
		}

		public void method_3(Size size_1)
		{
			size_0 = size_1;
		}

		public Color method_4()
		{
			return color_0;
		}

		public void method_5(Color color_1)
		{
			color_0 = color_1;
		}

		public Image method_6(string string_0)
		{
			return method_9(string_0)?.method_2();
		}

		public Image method_7(int int_0)
		{
			if (int_0 >= 0 && int_0 < method_0())
			{
				return ((GClass284)arrayList_0[int_0]).method_2();
			}
			return null;
		}

		public Image method_8(int int_0)
		{
			return ((GClass284)arrayList_0[int_0]).method_2();
		}

		public GClass284 method_9(string string_0)
		{
			foreach (GClass284 item in arrayList_0)
			{
				if (item.method_0() == string_0)
				{
					return item;
				}
			}
			return null;
		}

		public GClass284 method_10(int int_0)
		{
			return (GClass284)arrayList_0[int_0];
		}

		public bool method_11(GClass284 gclass284_0)
		{
			return arrayList_0.Contains(gclass284_0);
		}

		public bool method_12(string string_0)
		{
			return method_9(string_0) != null;
		}

		public bool method_13(Image image_0)
		{
			foreach (GClass284 item in arrayList_0)
			{
				if (item.method_2() == image_0)
				{
					return true;
				}
			}
			return false;
		}

		public virtual int vmethod_0(Assembly assembly_0, string string_0, string string_1)
		{
			Stream manifestResourceStream = assembly_0.GetManifestResourceStream(string_0);
			if (manifestResourceStream == null)
			{
				return -1;
			}
			if (string_1 == null)
			{
				string_1 = string_0;
			}
			return method_15(string_1, manifestResourceStream);
		}

		public virtual int vmethod_1(string string_0)
		{
			throw new NotSupportedException("未实现");
		}

		public int method_14(string string_0, Image image_0)
		{
			GClass284 gClass = method_9(string_0);
			if (gClass == null)
			{
				gClass = new GClass284();
				gClass.method_1(string_0);
				gClass.method_3(image_0);
				return arrayList_0.Add(gClass);
			}
			gClass.method_3(image_0);
			return arrayList_0.IndexOf(gClass);
		}

		public int method_15(string string_0, Stream stream_0)
		{
			if (stream_0 != null)
			{
				Image image = Image.FromStream(stream_0);
				if (image is Bitmap && color_0 != Color.Transparent)
				{
					((Bitmap)image).MakeTransparent(color_0);
				}
				int result = method_14(string_0, image);
				stream_0.Close();
				return result;
			}
			return -1;
		}

		public int method_16(string string_0, string string_1)
		{
			if (File.Exists(string_1))
			{
				FileStream stream_ = new FileStream(string_1, FileMode.Open, FileAccess.Read);
				return method_15(string_0, stream_);
			}
			return -1;
		}

		public int method_17(Image image_0)
		{
			GClass284 gClass = new GClass284();
			gClass.method_1(null);
			gClass.method_3(image_0);
			return arrayList_0.Add(gClass);
		}

		public int method_18(string string_0)
		{
			if (string_0 == null || string_0.Length == 0)
			{
				return -1;
			}
			int num = 0;
			while (true)
			{
				if (num < arrayList_0.Count)
				{
					if (((GClass284)arrayList_0[num]).method_0() == string_0)
					{
						break;
					}
					num++;
					continue;
				}
				return -1;
			}
			return num;
		}

		public void method_19(string string_0)
		{
			GClass284 gClass = method_9(string_0);
			if (gClass != null)
			{
				if (gClass.method_2() != null)
				{
					gClass.method_2().Dispose();
				}
				arrayList_0.Remove(gClass);
			}
		}

		public GClass284[] method_20()
		{
			return (GClass284[])arrayList_0.ToArray(typeof(GClass284));
		}

		public Image[] method_21()
		{
			if (method_0() == 0)
			{
				return null;
			}
			Image[] array = new Image[arrayList_0.Count];
			for (int i = 0; i < method_0(); i++)
			{
				array[i] = ((GClass284)arrayList_0[i]).method_2();
			}
			return array;
		}

		public ImageList method_22()
		{
			ImageList imageList = new ImageList();
			foreach (GClass284 item in arrayList_0)
			{
				imageList.Images.Add(item.method_2());
			}
			return imageList;
		}

		public virtual void vmethod_2()
		{
			foreach (GClass284 item in arrayList_0)
			{
				if (item.method_2() != null)
				{
					item.method_2().Dispose();
					item.method_3(null);
				}
			}
		}

		public void Dispose()
		{
			vmethod_2();
		}
	}
}
