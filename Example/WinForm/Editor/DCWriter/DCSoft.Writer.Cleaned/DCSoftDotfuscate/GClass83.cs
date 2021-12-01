using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass83 : ICloneable
	{
		protected internal const int int_0 = 64;

		protected internal const int int_1 = 6;

		protected internal ulong[] ulong_0;

		protected internal static readonly int int_2 = 63;

		public GClass83()
			: this(64)
		{
		}

		public GClass83(ulong[] ulong_1)
		{
			ulong_0 = ulong_1;
		}

		public GClass83(IList ilist_0)
		{
			for (int i = 0; i < ilist_0.Count; i++)
			{
				int int_ = (int)ilist_0[i];
				vmethod_0(int_);
			}
		}

		public GClass83(int int_3)
		{
			ulong_0 = new ulong[(int_3 - 1 >> 6) + 1];
		}

		public virtual void vmethod_0(int int_3)
		{
			int num = smethod_5(int_3);
			if (num >= ulong_0.Length)
			{
				vmethod_1(int_3);
			}
			ulong[] array;
			IntPtr value;
			(array = ulong_0)[(int)(value = (IntPtr)num)] = (array[(int)value] | smethod_0(int_3));
		}

		private static ulong smethod_0(int int_3)
		{
			int num = int_3 & int_2;
			return (ulong)(1L << num);
		}

		public virtual object Clone()
		{
			int num = 12;
			GClass83 gClass;
			try
			{
				gClass = (GClass83)MemberwiseClone();
				gClass.ulong_0 = new ulong[ulong_0.Length];
				Array.Copy(ulong_0, 0, gClass.ulong_0, 0, ulong_0.Length);
			}
			catch (Exception innerException)
			{
				throw new InvalidOperationException("Unable to clone BitSet", innerException);
			}
			return gClass;
		}

		public override bool Equals(object other)
		{
			if (other == null || !(other is GClass83))
			{
				return false;
			}
			GClass83 gClass = (GClass83)other;
			int num = Math.Min(ulong_0.Length, gClass.ulong_0.Length);
			int num2 = 0;
			while (true)
			{
				if (num2 < num)
				{
					if (ulong_0[num2] != gClass.ulong_0[num2])
					{
						break;
					}
					num2++;
					continue;
				}
				if (ulong_0.Length > num)
				{
					for (int i = num + 1; i < ulong_0.Length; i++)
					{
						if (ulong_0[i] != 0L)
						{
							return false;
						}
					}
				}
				else if (gClass.ulong_0.Length > num)
				{
					for (int j = num + 1; j < gClass.ulong_0.Length; j++)
					{
						if (gClass.ulong_0[j] != 0L)
						{
							return false;
						}
					}
				}
				return true;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public virtual void vmethod_1(int int_3)
		{
			ulong[] destinationArray = new ulong[Math.Max(ulong_0.Length << 1, method_0(int_3))];
			Array.Copy(ulong_0, 0, destinationArray, 0, ulong_0.Length);
			ulong_0 = destinationArray;
		}

		public virtual int vmethod_2()
		{
			return ulong_0.Length;
		}

		public virtual bool vmethod_3(int int_3)
		{
			if (int_3 < 0)
			{
				return false;
			}
			int num = smethod_5(int_3);
			if (num >= ulong_0.Length)
			{
				return false;
			}
			return (ulong_0[num] & smethod_0(int_3)) != 0L;
		}

		public virtual int vmethod_4()
		{
			return ulong_0.Length << 6;
		}

		private int method_0(int int_3)
		{
			return (int_3 >> 6) + 1;
		}

		public static GClass83 smethod_1(int int_3)
		{
			GClass83 gClass = new GClass83(int_3 + 1);
			gClass.vmethod_0(int_3);
			return gClass;
		}

		public static GClass83 smethod_2(int int_3, int int_4)
		{
			GClass83 gClass = new GClass83(Math.Max(int_3, int_4) + 1);
			gClass.vmethod_0(int_3);
			gClass.vmethod_0(int_4);
			return gClass;
		}

		public static GClass83 smethod_3(int int_3, int int_4, int int_5)
		{
			GClass83 gClass = new GClass83();
			gClass.vmethod_0(int_3);
			gClass.vmethod_0(int_4);
			gClass.vmethod_0(int_5);
			return gClass;
		}

		public static GClass83 smethod_4(int int_3, int int_4, int int_5, int int_6)
		{
			GClass83 gClass = new GClass83();
			gClass.vmethod_0(int_3);
			gClass.vmethod_0(int_4);
			gClass.vmethod_0(int_5);
			gClass.vmethod_0(int_6);
			return gClass;
		}

		public virtual GClass83 vmethod_5(GClass83 gclass83_0)
		{
			if (gclass83_0 == null)
			{
				return this;
			}
			GClass83 gClass = (GClass83)Clone();
			gClass.vmethod_6(gclass83_0);
			return gClass;
		}

		public virtual void vmethod_6(GClass83 gclass83_0)
		{
			if (gclass83_0 != null)
			{
				if (gclass83_0.ulong_0.Length > ulong_0.Length)
				{
					method_1(gclass83_0.ulong_0.Length);
				}
				for (int num = Math.Min(ulong_0.Length, gclass83_0.ulong_0.Length) - 1; num >= 0; num--)
				{
					ulong_0[num] |= gclass83_0.ulong_0[num];
				}
			}
		}

		public virtual void vmethod_7(int int_3)
		{
			int num = smethod_5(int_3);
			if (num < ulong_0.Length)
			{
				ulong[] array;
				IntPtr value;
				(array = ulong_0)[(int)(value = (IntPtr)num)] = (array[(int)value] & ~smethod_0(int_3));
			}
		}

		private void method_1(int int_3)
		{
			ulong[] destinationArray = new ulong[int_3];
			int length = Math.Min(int_3, ulong_0.Length);
			Array.Copy(ulong_0, 0, destinationArray, 0, length);
			ulong_0 = destinationArray;
		}

		public virtual int vmethod_8()
		{
			int num = 0;
			for (int num2 = ulong_0.Length - 1; num2 >= 0; num2--)
			{
				ulong num3 = ulong_0[num2];
				if (num3 != 0L)
				{
					for (int num4 = 63; num4 >= 0; num4--)
					{
						if (((long)num3 & (1L << num4)) != 0L)
						{
							num++;
						}
					}
				}
			}
			return num;
		}

		public virtual int[] vmethod_9()
		{
			int[] array = new int[vmethod_8()];
			int num = 0;
			for (int i = 0; i < ulong_0.Length << 6; i++)
			{
				if (vmethod_3(i))
				{
					array[num++] = i;
				}
			}
			return array;
		}

		public virtual ulong[] vmethod_10()
		{
			return ulong_0;
		}

		public override string ToString()
		{
			return vmethod_11(null);
		}

		public virtual string vmethod_11(string[] string_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string value = ",";
			bool flag = false;
			stringBuilder.Append('{');
			for (int i = 0; i < ulong_0.Length << 6; i++)
			{
				if (vmethod_3(i))
				{
					if (i > 0 && flag)
					{
						stringBuilder.Append(value);
					}
					if (string_0 != null)
					{
						stringBuilder.Append(string_0[i]);
					}
					else
					{
						stringBuilder.Append(i);
					}
					flag = true;
				}
			}
			stringBuilder.Append('}');
			return stringBuilder.ToString();
		}

		private static int smethod_5(int int_3)
		{
			return int_3 >> 6;
		}

		public virtual bool vmethod_12()
		{
			int num = ulong_0.Length - 1;
			while (true)
			{
				if (num >= 0)
				{
					if (ulong_0[num] != 0L)
					{
						break;
					}
					num--;
					continue;
				}
				return true;
			}
			return false;
		}
	}
}
