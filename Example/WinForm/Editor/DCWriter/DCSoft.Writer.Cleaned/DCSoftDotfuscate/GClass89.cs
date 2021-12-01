using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass89 : IEnumerable, GInterface17
	{
		protected sealed class GClass90 : IEnumerator
		{
			private object object_0;

			private int int_0;

			private GClass89 gclass89_0;

			public object Current
			{
				get
				{
					int num = 11;
					if (object_0 == null)
					{
						throw new InvalidOperationException("Enumeration has either not started or has already finished.");
					}
					return object_0;
				}
			}

			internal GClass90()
			{
			}

			internal GClass90(GClass89 gclass89_1)
			{
				gclass89_0 = gclass89_1;
				Reset();
			}

			public bool MoveNext()
			{
				if (int_0 >= gclass89_0.ilist_0.Count)
				{
					int num = int_0;
					int_0++;
					if (num < gclass89_0.ilist_0.Count)
					{
						object_0 = gclass89_0.ilist_0[num];
					}
					object_0 = gclass89_0.object_1;
					return true;
				}
				object_0 = null;
				return false;
			}

			public void Reset()
			{
				int_0 = 0;
				object_0 = null;
			}
		}

		public const int int_0 = 100;

		public const int int_1 = 10;

		protected int int_2;

		private GInterface13 ginterface13_0;

		protected int[] int_3;

		protected object object_0;

		protected object object_1;

		public static readonly IDictionary idictionary_0 = new Hashtable();

		protected int int_4;

		protected IList ilist_0;

		protected int int_5;

		protected internal object object_2;

		protected GInterface15 ginterface15_0;

		protected IDictionary idictionary_1;

		protected IDictionary idictionary_2;

		protected bool bool_0;

		protected object object_3;

		public GClass89(object object_4)
			: this(new GClass87(), object_4)
		{
		}

		public GClass89(GInterface13 ginterface13_1, object object_4)
			: this(ginterface13_1, object_4, 100)
		{
		}

		public GClass89(GInterface13 ginterface13_1, object object_4, int int_6)
		{
			bool_0 = false;
			int_5 = -1;
			int_2 = -1;
			idictionary_1 = null;
			object_2 = object_4;
			ginterface13_0 = ginterface13_1;
			ilist_0 = new ArrayList(int_6);
			object_0 = ginterface13_1.imethod_5(2, "DOWN");
			object_3 = ginterface13_1.imethod_5(3, "UP");
			object_1 = ginterface13_1.imethod_5(GClass84.int_6, "EOF");
		}

		protected void method_0(int int_6)
		{
			int num = 6;
			object obj = null;
			obj = ((int_6 == 2) ? ((!method_11()) ? object_0 : ginterface13_0.imethod_5(2, "DOWN")) : ((!method_11()) ? object_3 : ginterface13_0.imethod_5(3, "UP")));
			ilist_0.Add(obj);
		}

		public virtual void imethod_0()
		{
			if (int_5 == -1)
			{
				method_1();
			}
			int_5++;
		}

		protected void method_1()
		{
			method_2(object_2);
			int_5 = 0;
		}

		protected void method_2(object object_4)
		{
			bool flag;
			if (!(flag = ginterface13_0.imethod_18(object_4)))
			{
				ilist_0.Add(object_4);
				method_3(object_4, ilist_0.Count - 1);
			}
			int num = ginterface13_0.imethod_10(object_4);
			if (!flag && num > 0)
			{
				method_0(2);
			}
			for (int i = 0; i < num; i++)
			{
				object object_5 = ginterface13_0.imethod_9(object_4, i);
				method_2(object_5);
			}
			if (!flag && num > 0)
			{
				method_0(3);
			}
		}

		protected void method_3(object object_4, int int_6)
		{
			if (idictionary_1 == null)
			{
				return;
			}
			if (idictionary_2 == null)
			{
				idictionary_2 = new Hashtable();
			}
			int num = ginterface13_0.imethod_13(object_4);
			if (idictionary_1 == idictionary_0 || idictionary_1.Contains(num))
			{
				ArrayList arrayList = (ArrayList)idictionary_2[num];
				if (arrayList == null)
				{
					arrayList = new ArrayList();
					arrayList.Add(int_6);
					idictionary_2[num] = arrayList;
				}
				else if (!arrayList.Contains(int_6))
				{
					arrayList.Add(int_6);
				}
			}
		}

		public object imethod_9(int int_6)
		{
			if (int_5 == -1)
			{
				method_1();
			}
			return ilist_0[int_6];
		}

		public IEnumerator GetEnumerator()
		{
			if (int_5 == -1)
			{
				method_1();
			}
			return new GClass90(this);
		}

		public int method_4(object object_4)
		{
			if (idictionary_2 == null)
			{
				return method_5(object_4);
			}
			int num = ginterface13_0.imethod_13(object_4);
			ArrayList arrayList = (ArrayList)idictionary_2[num];
			if (arrayList == null)
			{
				return method_5(object_4);
			}
			int num2 = 0;
			int num3;
			while (true)
			{
				if (num2 < arrayList.Count)
				{
					num3 = (int)arrayList[num2];
					if (imethod_9(num3) == object_4)
					{
						break;
					}
					num2++;
					continue;
				}
				return -1;
			}
			return num3;
		}

		protected int method_5(object object_4)
		{
			if (int_5 == -1)
			{
				method_1();
			}
			int num = 0;
			while (true)
			{
				if (num < ilist_0.Count)
				{
					object obj = ilist_0[num];
					if (obj == object_4)
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

		public virtual int imethod_1()
		{
			return int_5;
		}

		public virtual int imethod_2(int int_6)
		{
			return ginterface13_0.imethod_13(imethod_10(int_6));
		}

		protected object method_6(int int_6)
		{
			if (int_6 == 0)
			{
				return null;
			}
			if (int_5 - int_6 < 0)
			{
				return null;
			}
			return ilist_0[int_5 - int_6];
		}

		public object imethod_10(int int_6)
		{
			if (int_5 == -1)
			{
				method_1();
			}
			if (int_6 == 0)
			{
				return null;
			}
			if (int_6 < 0)
			{
				return method_6(-int_6);
			}
			if (int_5 + int_6 - 1 >= ilist_0.Count)
			{
				return object_1;
			}
			return ilist_0[int_5 + int_6 - 1];
		}

		public virtual int imethod_3()
		{
			if (int_5 == -1)
			{
				method_1();
			}
			int_4 = imethod_1();
			return int_4;
		}

		public int method_7()
		{
			int num = int_3[int_2--];
			imethod_7(num);
			return num;
		}

		public void method_8(int int_6)
		{
			if (int_3 == null)
			{
				int_3 = new int[10];
			}
			else if (int_2 + 1 >= int_3.Length)
			{
				int[] destinationArray = new int[int_3.Length * 2];
				Array.Copy(int_3, 0, destinationArray, 0, int_3.Length);
				int_3 = destinationArray;
			}
			int_3[++int_2] = int_5;
			imethod_7(int_6);
		}

		public virtual void imethod_4(int int_6)
		{
		}

		public void method_9(IDictionary idictionary_3)
		{
			idictionary_1 = idictionary_3;
		}

		public void method_10(int int_6)
		{
			if (idictionary_1 == null)
			{
				idictionary_1 = new Hashtable();
			}
			else if (idictionary_1 == idictionary_0)
			{
				return;
			}
			idictionary_1.Add(int_6, int_6);
		}

		public void imethod_5()
		{
			imethod_7(int_4);
		}

		public virtual void imethod_6(int int_6)
		{
			imethod_7(int_6);
		}

		public virtual void imethod_7(int int_6)
		{
			if (int_5 == -1)
			{
				method_1();
			}
			int_5 = int_6;
		}

		public virtual int imethod_8()
		{
			if (int_5 == -1)
			{
				method_1();
			}
			return ilist_0.Count;
		}

		public override string ToString()
		{
			int num = 5;
			if (int_5 == -1)
			{
				method_1();
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < ilist_0.Count; i++)
			{
				object obj = ilist_0[i];
				stringBuilder.Append(" ");
				stringBuilder.Append(ginterface13_0.imethod_13(obj));
			}
			return stringBuilder.ToString();
		}

		public virtual string imethod_11(object object_4, object object_5)
		{
			int num = 9;
			if (object_4 == null || object_5 == null)
			{
				return null;
			}
			if (int_5 == -1)
			{
				method_1();
			}
			Console.Out.WriteLine("stop: " + object_5);
			if (object_4 is GClass78)
			{
				Console.Out.Write(string.Concat("ToString: ", ((GClass78)object_4).vmethod_3(), ", "));
			}
			else
			{
				Console.Out.WriteLine(object_4);
			}
			if (object_5 is GClass78)
			{
				Console.Out.WriteLine(((GClass78)object_5).vmethod_3());
			}
			else
			{
				Console.Out.WriteLine(object_5);
			}
			if (ginterface15_0 != null)
			{
				int num2 = ginterface13_0.imethod_15(object_4);
				int num3 = ginterface13_0.imethod_16(object_5);
				if (ginterface13_0.imethod_13(object_5) == 3)
				{
					num3 = ginterface13_0.imethod_16(object_4);
				}
				else if (ginterface13_0.imethod_13(object_5) == GClass84.int_6)
				{
					num3 = imethod_8() - 2;
				}
				return ginterface15_0.imethod_12(num2, num3);
			}
			object obj = null;
			int i;
			for (i = 0; i < ilist_0.Count; i++)
			{
				obj = ilist_0[i];
				if (obj == object_4)
				{
					break;
				}
			}
			StringBuilder stringBuilder = new StringBuilder();
			string text;
			for (obj = ilist_0[i]; obj != object_5; obj = ilist_0[i])
			{
				text = ginterface13_0.imethod_12(obj);
				if (text == null)
				{
					text = " " + ginterface13_0.imethod_13(obj);
				}
				stringBuilder.Append(text);
				i++;
			}
			text = ginterface13_0.imethod_12(object_5);
			if (text == null)
			{
				text = " " + ginterface13_0.imethod_13(object_5);
			}
			stringBuilder.Append(text);
			return stringBuilder.ToString();
		}

		public bool method_11()
		{
			return bool_0;
		}

		public void imethod_12(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public virtual GInterface15 imethod_13()
		{
			return ginterface15_0;
		}

		public virtual void vmethod_0(GInterface15 ginterface15_1)
		{
			ginterface15_0 = ginterface15_1;
		}

		public GInterface13 imethod_14()
		{
			return ginterface13_0;
		}

		public virtual object imethod_15()
		{
			return object_2;
		}
	}
}
