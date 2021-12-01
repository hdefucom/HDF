using System;
using System.Collections;
using System.Reflection;

namespace DCSoftDotfuscate
{
	public class GClass296
	{
		public class GClass297 : IComparable
		{
			public int int_0 = 0;

			public int int_1 = 0;

			public int int_2 = 0;

			public int int_3 = 0;

			public int int_4 = 0;

			public int int_5 = 0;

			public object object_0 = null;

			public int int_6 = 0;

			public int int_7 = 0;

			public int method_0()
			{
				return int_0 + int_2;
			}

			public int CompareTo(object target)
			{
				GClass297 gClass = (GClass297)target;
				int num = int_1 * 10000 + int_0;
				int num2 = gClass.int_1 * 10000 + gClass.int_0;
				if (num == num2)
				{
					return 0;
				}
				if (num > num2)
				{
					return 1;
				}
				return -1;
			}
		}

		[DefaultMember("Item")]
		public class GClass298 : CollectionBase
		{
			private class Class181 : IComparer
			{
				public int Compare(object object_0, object object_1)
				{
					GClass297 gClass = (GClass297)object_0;
					GClass297 gClass2 = (GClass297)object_1;
					if (gClass.int_1 != gClass2.int_1)
					{
						return gClass.int_1 - gClass2.int_1;
					}
					return gClass.int_0 - gClass2.int_0;
				}
			}

			public int int_0 = 0;

			public int int_1 = 0;

			public int int_2 = 0;

			public int int_3 = 0;

			public GClass297 method_0(int int_4)
			{
				return (GClass297)base.InnerList[int_4];
			}

			public void method_1(GClass297 gclass297_0)
			{
				base.InnerList.Add(gclass297_0);
			}

			public void method_2(object object_0, int int_4, int int_5, int int_6, int int_7)
			{
				GClass297 gClass = new GClass297();
				gClass.int_4 = int_4;
				gClass.int_5 = int_5;
				gClass.int_6 = int_6;
				gClass.int_7 = int_7;
				gClass.object_0 = object_0;
				base.InnerList.Add(gClass);
			}

			public void method_3(int int_4, GClass297 gclass297_0)
			{
				base.InnerList.Insert(int_4, gclass297_0);
			}

			public void method_4()
			{
				if (base.Count <= 1)
				{
					return;
				}
				Class181 @class = new Class181();
				int count = base.Count;
				for (int i = 1; i < count; i++)
				{
					for (int num = count - 1; num >= i; num--)
					{
						if (@class.Compare(base.List[num], base.List[num - 1]) < 0)
						{
							object value = base.List[num];
							base.List[num] = base.List[num - 1];
							base.List[num - 1] = value;
						}
					}
				}
			}
		}

		public float float_0 = 0f;

		public float float_1 = 0f;

		public float float_2 = 10f;

		public float float_3 = 10f;

		protected GClass298 gclass298_0 = new GClass298();

		protected ArrayList arrayList_0 = new ArrayList();

		public GClass298 method_0()
		{
			return gclass298_0;
		}

		public ArrayList method_1()
		{
			return arrayList_0;
		}

		public void method_2()
		{
			foreach (GClass297 item in gclass298_0)
			{
				item.int_0 = (int)Math.Round((double)((float)item.int_4 - float_0) / (double)float_2);
				item.int_1 = (int)Math.Floor((double)((float)item.int_5 - float_1) / (double)float_3);
				item.int_2 = (int)Math.Round((double)item.int_6 / (double)float_2);
				item.int_3 = (int)Math.Round((double)item.int_7 / (double)float_3);
			}
			gclass298_0.method_4();
			arrayList_0.Clear();
			GClass298 gClass2 = null;
			GClass298 gClass3 = null;
			foreach (GClass297 item2 in gclass298_0)
			{
				if (gClass2 == null || gClass2.int_2 != item2.int_1)
				{
					gClass2 = new GClass298();
					gClass2.int_2 = item2.int_1;
					gClass2.int_0 = item2.int_5;
					if (gClass3 != null && (float)(gClass2.int_0 - gClass3.int_0 - gClass3.int_1) > float_3 / 3f)
					{
						for (int i = gClass3.int_2 + gClass3.int_3; i < gClass2.int_2; i++)
						{
							GClass298 gClass4 = new GClass298();
							gClass4.int_2 = i;
							gClass4.int_3 = 1;
							arrayList_0.Add(gClass4);
						}
					}
					gClass3 = gClass2;
					arrayList_0.Add(gClass2);
				}
				gClass2.method_1(item2);
				if (item2.int_3 > gClass2.int_3)
				{
					gClass2.int_3 = item2.int_3;
				}
				if (gClass2.int_1 < item2.int_7)
				{
					gClass2.int_1 = item2.int_7;
				}
				if (gClass2.int_0 > item2.int_5)
				{
					gClass2.int_0 = item2.int_5;
				}
			}
			foreach (GClass298 item3 in arrayList_0)
			{
				if (item3.Count > 0)
				{
					_ = item3.method_0(0).int_0;
					for (int i = 1; i < item3.Count; i++)
					{
						if (item3.method_0(i).int_0 > item3.method_0(i - 1).method_0() + 1)
						{
							GClass297 gClass6 = new GClass297();
							gClass6.int_0 = item3.method_0(i - 1).method_0();
							gClass6.int_2 = item3.method_0(i).int_0 - gClass6.int_0;
							item3.method_3(i, gClass6);
							i++;
						}
					}
				}
			}
		}

		public void method_3()
		{
			if (arrayList_0.Count <= 0)
			{
				return;
			}
			GClass298 gClass = (GClass298)arrayList_0[0];
			if (gClass.int_2 > 0)
			{
				for (int i = 0; i < gClass.int_2; i++)
				{
					GClass298 gClass2 = new GClass298();
					gClass2.int_2 = i;
					arrayList_0.Insert(i, gClass2);
				}
			}
		}

		public void method_4()
		{
			foreach (GClass298 item in arrayList_0)
			{
				if (item.Count > 0 && item.method_0(0).int_0 > 0)
				{
					GClass297 gClass2 = new GClass297();
					gClass2.int_0 = 0;
					gClass2.int_2 = item.method_0(0).int_0;
					item.method_3(0, gClass2);
				}
			}
		}

		public void method_5()
		{
			while (arrayList_0.Count > 0)
			{
				GClass298 gClass = (GClass298)arrayList_0[0];
				if (gClass.Count <= 0)
				{
					arrayList_0.RemoveAt(0);
					continue;
				}
				break;
			}
		}
	}
}
