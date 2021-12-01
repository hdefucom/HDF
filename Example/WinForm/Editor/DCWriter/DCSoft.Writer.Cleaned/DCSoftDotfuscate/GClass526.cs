using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass526
	{
		private class Class213 : IComparer<GClass527>
		{
			public int Compare(GClass527 gclass527_0, GClass527 gclass527_1)
			{
				if (gclass527_0.bool_0 != gclass527_1.bool_0)
				{
					if (gclass527_0.bool_0)
					{
						return -1;
					}
					return 1;
				}
				int num = gclass527_0.int_1 - gclass527_1.int_1;
				if (num == 0)
				{
					num = gclass527_0.int_0 - gclass527_1.int_0;
				}
				return num;
			}
		}

		[ComVisible(false)]
		public class GClass527
		{
			public string string_0 = null;

			public int int_0 = 0;

			public float float_0 = float.NaN;

			public float float_1 = float.NaN;

			public float float_2 = float.NaN;

			public float float_3 = float.NaN;

			public Color color_0 = Color.Black;

			public float float_4 = 1f;

			public DashStyle dashStyle_0 = DashStyle.Solid;

			public int int_1 = 0;

			public bool bool_0 = false;

			public GClass527 method_0()
			{
				return (GClass527)MemberwiseClone();
			}

			public override string ToString()
			{
				return string_0 + " " + float_0 + "," + float_1 + "->" + float_2 + "," + float_3;
			}
		}

		private List<GClass527> list_0 = new List<GClass527>();

		public void method_0(string string_0, RectangleF rectangleF_0, bool bool_0, bool bool_1, bool bool_2, bool bool_3, Color color_0, float float_0, DashStyle dashStyle_0, int int_0, bool bool_4)
		{
			int num = 4;
			if (!(rectangleF_0.Width <= 0f) && !(rectangleF_0.Height <= 0f))
			{
				if (bool_0)
				{
					method_1(string_0 + "-L", rectangleF_0.Left, rectangleF_0.Top, rectangleF_0.Left, rectangleF_0.Bottom, color_0, float_0, dashStyle_0, int_0, bool_4);
				}
				if (bool_1)
				{
					method_1(string_0 + "-T", rectangleF_0.Left, rectangleF_0.Top, rectangleF_0.Right, rectangleF_0.Top, color_0, float_0, dashStyle_0, int_0, bool_4);
				}
				if (bool_2)
				{
					method_1(string_0 + "-R", rectangleF_0.Right, rectangleF_0.Top, rectangleF_0.Right, rectangleF_0.Bottom, color_0, float_0, dashStyle_0, int_0, bool_4);
				}
				if (bool_3)
				{
					method_1(string_0 + "-B", rectangleF_0.Left, rectangleF_0.Bottom, rectangleF_0.Right, rectangleF_0.Bottom, color_0, float_0, dashStyle_0, int_0, bool_4);
				}
			}
		}

		public void method_1(string string_0, float float_0, float float_1, float float_2, float float_3, Color color_0, float float_4, DashStyle dashStyle_0, int int_0, bool bool_0)
		{
			GClass527 gClass = new GClass527();
			gClass.string_0 = string_0;
			gClass.float_0 = float_0;
			gClass.float_1 = float_1;
			gClass.float_2 = float_2;
			gClass.float_3 = float_3;
			gClass.color_0 = color_0;
			gClass.float_4 = float_4;
			gClass.dashStyle_0 = dashStyle_0;
			gClass.int_1 = int_0;
			gClass.bool_0 = bool_0;
			list_0.Add(gClass);
		}

		public void method_2()
		{
			method_3();
			method_4();
		}

		private void method_3()
		{
			int num = 14;
			List<GClass527> list = new List<GClass527>();
			foreach (GClass527 item in method_6())
			{
				if (item.float_0 > item.float_2)
				{
					float float_ = item.float_0;
					item.float_0 = item.float_2;
					item.float_2 = float_;
				}
				if (item.float_1 > item.float_3)
				{
					float float_ = item.float_1;
					item.float_1 = item.float_3;
					item.float_3 = float_;
				}
			}
			int num2 = Color.White.ToArgb();
			int num3 = 0;
			for (int i = 0; i < method_6().Count; i++)
			{
				GClass527 current = method_6()[i];
				if (!(current.string_0 == "E8-T"))
				{
				}
				if (!current.bool_0 && current.color_0.ToArgb() != num2)
				{
					continue;
				}
				bool flag = false;
				for (int j = 0; j < method_6().Count; j++)
				{
					GClass527 gClass = method_6()[j];
					if (current != gClass && !gClass.bool_0 && gClass.int_1 >= current.int_1 && !(gClass.float_4 <= 0f))
					{
						if (gClass.float_0 <= current.float_0 && gClass.float_2 >= current.float_2 && gClass.float_1 == current.float_1 && gClass.float_3 == current.float_3 && gClass.float_3 == gClass.float_1)
						{
							flag = true;
							break;
						}
						if (gClass.float_1 <= current.float_1 && gClass.float_3 >= current.float_3 && gClass.float_0 == current.float_0 && gClass.float_2 == current.float_2 && gClass.float_0 == gClass.float_2 && current.float_2 == current.float_0)
						{
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					method_6().RemoveAt(i);
					num3++;
					i--;
				}
			}
			foreach (GClass527 item2 in method_6())
			{
				if (!item2.bool_0)
				{
					bool flag2 = false;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						GClass527 gClass = list[i];
						if (item2.color_0 == gClass.color_0 && item2.dashStyle_0 == gClass.dashStyle_0 && item2.float_4 == gClass.float_4 && item2.int_1 == gClass.int_1 && item2.bool_0 == gClass.bool_0)
						{
							if (item2.float_0 == item2.float_2 && item2.float_0 == gClass.float_0 && gClass.float_0 == gClass.float_2)
							{
								if (method_5(item2.float_1, item2.float_3, gClass.float_1, gClass.float_3))
								{
									gClass.float_1 = Math.Min(item2.float_1, gClass.float_1);
									gClass.float_3 = Math.Max(item2.float_3, gClass.float_3);
									flag2 = true;
									break;
								}
							}
							else if (item2.float_1 == item2.float_3 && item2.float_1 == gClass.float_1 && gClass.float_1 == gClass.float_3 && method_5(item2.float_0, item2.float_2, gClass.float_0, gClass.float_2))
							{
								gClass.float_0 = Math.Min(item2.float_0, gClass.float_0);
								gClass.float_2 = Math.Max(item2.float_2, gClass.float_2);
								flag2 = true;
								break;
							}
						}
					}
					if (!flag2)
					{
						list.Add(item2.method_0());
					}
				}
			}
			foreach (GClass527 item3 in method_6())
			{
				if (item3.bool_0)
				{
					bool flag2 = false;
					method_6().IndexOf(item3);
					int count2 = list.Count;
					for (int i = 0; i < count2; i++)
					{
						GClass527 gClass = list[i];
						if (item3.float_0 == item3.float_2 && item3.float_0 == gClass.float_0 && gClass.float_0 == gClass.float_2)
						{
							if (method_5(item3.float_1, item3.float_3, gClass.float_1, gClass.float_3))
							{
								flag2 = true;
								if (gClass.bool_0)
								{
									gClass.float_1 = Math.Min(item3.float_1, gClass.float_1);
									gClass.float_3 = Math.Max(item3.float_3, gClass.float_3);
								}
								else
								{
									if (item3.float_1 < gClass.float_1)
									{
										GClass527 gClass2 = item3.method_0();
										gClass2.float_3 = gClass.float_1;
										list.Add(gClass2);
									}
									if (item3.float_3 > gClass.float_3)
									{
										GClass527 gClass2 = item3.method_0();
										gClass2.float_1 = gClass.float_3;
										list.Add(gClass2);
									}
								}
								break;
							}
						}
						else if (item3.float_1 == item3.float_3 && item3.float_1 == gClass.float_1 && gClass.float_1 == gClass.float_3 && method_5(item3.float_0, item3.float_2, gClass.float_0, gClass.float_2))
						{
							flag2 = true;
							if (gClass.bool_0)
							{
								gClass.float_0 = Math.Min(item3.float_0, gClass.float_0);
								gClass.float_2 = Math.Max(item3.float_2, gClass.float_2);
							}
							else
							{
								if (item3.float_0 < gClass.float_0)
								{
									GClass527 gClass2 = item3.method_0();
									gClass2.float_2 = gClass.float_0;
									list.Add(gClass2);
								}
								if (item3.float_2 > gClass.float_2)
								{
									GClass527 gClass2 = item3.method_0();
									gClass2.float_0 = gClass.float_2;
									list.Add(gClass2);
								}
							}
							break;
						}
					}
					if (!flag2)
					{
						list.Add(item3);
					}
				}
			}
			list_0 = list;
		}

		private void method_4()
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].int_0 = i;
			}
			list_0.Sort(new Class213());
		}

		private bool method_5(float float_0, float float_1, float float_2, float float_3)
		{
			if (float_0 <= float_3 && float_1 >= float_2)
			{
				return true;
			}
			return false;
		}

		public List<GClass527> method_6()
		{
			return list_0;
		}

		public void method_7(List<GClass527> list_1)
		{
			list_0 = list_1;
		}
	}
}
