using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass648
	{
		private GClass618 gclass618_0;

		private ArrayList arrayList_0;

		public GClass648(GClass618 gclass618_1)
		{
			int num = 9;
			
			if (!GClass618.gclass618_0.Equals(gclass618_1))
			{
				throw new ArgumentException("Only QR Code is supported at this time");
			}
			gclass618_0 = gclass618_1;
			arrayList_0 = ArrayList.Synchronized(new ArrayList(10));
			arrayList_0.Add(new Class255(gclass618_1, new int[1]
			{
				1
			}));
		}

		private Class255 method_0(int int_0)
		{
			if (int_0 >= arrayList_0.Count)
			{
				Class255 @class = (Class255)arrayList_0[arrayList_0.Count - 1];
				for (int i = arrayList_0.Count; i <= int_0; i++)
				{
					Class255 class2 = @class.method_6(new Class255(gclass618_0, new int[2]
					{
						1,
						gclass618_0.method_3(i - 1)
					}));
					arrayList_0.Add(class2);
					@class = class2;
				}
			}
			return (Class255)arrayList_0[int_0];
		}

		public void method_1(int[] int_0, int int_1)
		{
			int num = 4;
			if (int_1 == 0)
			{
				throw new ArgumentException("No error correction bytes");
			}
			int num2 = int_0.Length - int_1;
			if (num2 <= 0)
			{
				throw new ArgumentException("No data bytes provided");
			}
			Class255 class255_ = method_0(int_1);
			int[] array = new int[num2];
			Array.Copy(int_0, 0, array, 0, num2);
			Class255 @class = new Class255(gclass618_0, array);
			@class = @class.method_8(int_1, 1);
			Class255 class2 = @class.method_9(class255_)[1];
			int[] array2 = class2.method_0();
			int num3 = int_1 - array2.Length;
			for (int i = 0; i < num3; i++)
			{
				int_0[num2 + i] = 0;
			}
			Array.Copy(array2, 0, int_0, num2 + num3, array2.Length);
		}
	}
}
