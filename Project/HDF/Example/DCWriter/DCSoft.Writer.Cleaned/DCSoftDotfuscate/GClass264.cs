using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	public sealed class GClass264
	{
		private struct Struct69
		{
			public int int_0;

			public int int_1;

			public IntPtr intptr_0;

			public IntPtr intptr_1;

			public int int_2;
		}

		private struct Struct70
		{
			public int int_0;

			public int int_1;

			public IntPtr intptr_0;

			public int int_2;

			public int int_3;
		}

		[StructLayout(LayoutKind.Sequential)]
		private class Class177
		{
			internal int int_0 = 20;

			internal int int_1 = 1;

			internal IntPtr intptr_0 = IntPtr.Zero;

			internal IntPtr intptr_1 = IntPtr.Zero;

			internal int int_2 = 0;

			public Class177(Bitmap bitmap_0)
			{
				intptr_0 = bitmap_0.GetHbitmap();
			}
		}

		[StructLayout(LayoutKind.Sequential)]
		private class Class178
		{
			internal int int_0 = 20;

			internal int int_1 = 4;

			internal IntPtr intptr_0 = IntPtr.Zero;

			internal int int_2 = 0;

			internal int int_3 = 0;

			public Class178(Metafile metafile_0)
			{
				intptr_0 = metafile_0.GetHenhmetafile();
			}
		}

		public static object smethod_0(Image image_0)
		{
			if (image_0 == null)
			{
				return null;
			}
			object object_ = RuntimeHelpers.GetObjectValue(smethod_1(image_0));
			Guid guid_ = typeof(GInterface21).GUID;
			return smethod_2(ref object_, ref guid_, bool_0: true);
		}

		private static object smethod_1(Image image_0)
		{
			int num = 13;
			object obj = null;
			if (image_0 is Bitmap)
			{
				obj = new Class177((Bitmap)image_0);
			}
			else if (image_0 is Metafile)
			{
				obj = new Class178((Metafile)image_0);
			}
			if (obj == null)
			{
				throw new Exception("AXUnknownImage");
			}
			return obj;
		}

		private static object smethod_2(ref object object_0, ref Guid guid_0, bool bool_0)
		{
			object object_ = null;
			switch (smethod_3(ref object_0))
			{
			case -1:
			case 0:
				return null;
			case 1:
			{
				Struct69 struct69_ = default(Struct69);
				Class177 class2 = (Class177)object_0;
				struct69_.int_0 = Marshal.SizeOf(struct69_);
				struct69_.int_1 = class2.int_1;
				struct69_.intptr_0 = class2.intptr_0;
				struct69_.intptr_1 = class2.intptr_1;
				OleCreatePictureIndirect(ref struct69_, ref guid_0, bool_0, out object_);
				return object_;
			}
			case 2:
				return object_;
			default:
				return object_;
			case 4:
			{
				Struct70 struct70_ = default(Struct70);
				Class178 @class = (Class178)object_0;
				struct70_.int_0 = Marshal.SizeOf(struct70_);
				struct70_.int_1 = @class.int_1;
				struct70_.intptr_0 = @class.intptr_0;
				OleCreatePictureIndirect_1(ref struct70_, ref guid_0, bool_0, out object_);
				return object_;
			}
			}
		}

		[DllImport("oleaut32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern void OleCreatePictureIndirect([In] ref Struct69 struct69_0, ref Guid guid_0, bool bool_0, [MarshalAs(UnmanagedType.Interface)] out object object_0);

		[DllImport("oleaut32.dll", CharSet = CharSet.Ansi, EntryPoint = "OleCreatePictureIndirect", ExactSpelling = true, SetLastError = true)]
		private static extern void OleCreatePictureIndirect_1([In] ref Struct70 struct70_0, ref Guid guid_0, bool bool_0, [MarshalAs(UnmanagedType.Interface)] out object object_0);

		private static int smethod_3(ref object object_0)
		{
			int result = 0;
			try
			{
				if (object_0 is Class177)
				{
					Class177 @class = (Class177)object_0;
					return @class.int_1;
				}
				if (object_0 is Class178)
				{
					Class178 class2 = (Class178)object_0;
					result = class2.int_1;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				result = 0;
			}
			return result;
		}

		private GClass264()
		{
		}
	}
}
