using DCSoft.Common;
using DCSoft.FriedmanCurveChart;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace DCSoftDotfuscate
{
	[DebuggerDisplay("Count={ Count }")]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	internal class Class165 : List<Class164>
	{
		private DateTime dateTime_0 = FriedmanCurveDocument.NullDate;

		private DateTime dateTime_1 = FriedmanCurveDocument.NullDate;

		internal DCFriedmanCurveUnit dcfriedmanCurveUnit_0 = DCFriedmanCurveUnit.Hour;

		private float float_0 = 0f;

		public DateTime method_0()
		{
			return dateTime_0;
		}

		public void method_1(DateTime dateTime_2)
		{
			dateTime_0 = dateTime_2;
		}

		public DateTime method_2()
		{
			return dateTime_1;
		}

		public void method_3(DateTime dateTime_2)
		{
			dateTime_1 = dateTime_2;
		}

		public DateTime method_4()
		{
			if (base.Count > 0)
			{
				return base[base.Count - 1].dateTime_1;
			}
			return FriedmanCurveDocument.NullDate;
		}

		public Class164 method_5()
		{
			if (base.Count > 0)
			{
				return base[base.Count - 1];
			}
			return null;
		}

		public int method_6(RectangleF rectangleF_0, RectangleF rectangleF_1)
		{
			return method_7(Math.Max(rectangleF_0.Left, rectangleF_1.Left) - rectangleF_0.Left);
		}

		public int method_7(float float_1)
		{
			int num = 0;
			int num2 = base.Count - 1;
			int num3 = 0;
			while (num2 - num > 10)
			{
				num3++;
				int num4 = (num2 + num) / 2;
				if (base[num4].float_0 > float_1)
				{
					num2 = num4;
				}
				else
				{
					num = num4;
				}
			}
			DateTime date = base[num].dateTime_0.Date;
			for (int num5 = num - 1; num5 >= 0; num5--)
			{
				Class164 @class = base[num5];
				if (@class.dateTime_1.Date < date)
				{
					num = num5 + 1;
				}
			}
			return num;
		}

		public Class164 method_8(int int_0)
		{
			if (int_0 < 0 || int_0 >= base.Count)
			{
				return null;
			}
			return base[int_0];
		}

		public DateTime method_9(int int_0)
		{
			if (int_0 < 0)
			{
				return method_0();
			}
			return base[int_0].dateTime_0;
		}

		public DateTime method_10(int int_0)
		{
			if (int_0 >= base.Count)
			{
				return method_2();
			}
			return base[int_0].dateTime_1;
		}

		public float method_11(DateTime dateTime_2, ref Class164 class164_0)
		{
			int num = method_13(dateTime_2, bool_0: true, bool_1: false);
			if (num >= 0 && num < base.Count - 1)
			{
				Class164 @class = base[num];
				if (@class.dateTime_1 >= dateTime_2)
				{
					if (@class.friedmanCurveZoneInfo_0 != null && !@class.friedmanCurveZoneInfo_0.AlignToGrid)
					{
						if (dateTime_2 <= @class.dateTime_0)
						{
							class164_0 = @class;
							return @class.float_0;
						}
						float result = @class.float_0 + @class.float_1 * (float)(dateTime_2.Ticks - @class.dateTime_0.Ticks) / (float)(@class.dateTime_1.Ticks - @class.dateTime_0.Ticks);
						class164_0 = @class;
						return result;
					}
					if (num >= base.Count)
					{
						class164_0 = base[base.Count - 1];
					}
					else
					{
						class164_0 = base[num];
					}
					return method_12(num);
				}
				if (@class.friedmanCurveZoneInfo_0 != null && !@class.friedmanCurveZoneInfo_0.AlignToGrid)
				{
					Class164 class2 = base[num + 1];
					if (class2.friedmanCurveZoneInfo_0 == @class.friedmanCurveZoneInfo_0)
					{
						float result = @class.float_0 + (class2.float_0 - @class.float_0) * (float)(dateTime_2.Ticks - @class.dateTime_1.Ticks) / (float)(class2.dateTime_1.Ticks - @class.dateTime_1.Ticks);
						class164_0 = @class;
						return result;
					}
				}
			}
			if (num >= base.Count)
			{
				class164_0 = base[base.Count - 1];
			}
			else
			{
				class164_0 = base[num];
			}
			return method_12(num);
		}

		public float method_12(int int_0)
		{
			if (int_0 < 0)
			{
				return 0f;
			}
			Class164 @class;
			if (int_0 >= base.Count)
			{
				@class = base[base.Count - 1];
				return @class.float_0 + @class.float_1;
			}
			@class = base[int_0];
			return @class.float_0 + @class.float_1 / 2f;
		}

		public int method_13(DateTime dateTime_2, bool bool_0, bool bool_1)
		{
			if (base.Count == 0)
			{
				return 0;
			}
			if (dateTime_2 < base[0].dateTime_1)
			{
				return 0;
			}
			if (dateTime_2 > base[base.Count - 1].dateTime_1)
			{
				return base.Count - 1;
			}
			int num = 0;
			int num2 = base.Count - 1;
			int num3 = 0;
			int num4 = -1;
			int num5 = 0;
			int num6 = (int)(base.Count * (dateTime_2.Ticks - method_0().Ticks) / (method_2().Ticks - method_0().Ticks));
			if (num6 >= 0 && num6 < base.Count)
			{
				DateTime t = bool_1 ? base[num6].dateTime_0 : base[num6].dateTime_1;
				if (dateTime_2 < t)
				{
					num2 = num6;
					int num7 = Math.Max(0, num2 - 10);
					if (base[num7].dateTime_1 < dateTime_2)
					{
						num = num7;
					}
				}
				else
				{
					num = num6;
					int num7 = Math.Min(num + 10, base.Count - 1);
					if (base[num7].dateTime_0 > dateTime_2)
					{
						num2 = num7;
					}
				}
			}
			while (num2 - num > 5)
			{
				num5++;
				if (num3++ <= 1000)
				{
					int num8 = (num + num2) / 2;
					DateTime value = bool_1 ? base[num8].dateTime_0 : base[num8].dateTime_1;
					int num9 = dateTime_2.CompareTo(value);
					if (num9 < 0)
					{
						num2 = num8;
						continue;
					}
					if (num9 > 0)
					{
						num = num8;
						continue;
					}
					num4 = num8;
					break;
				}
				num4 = 0;
				break;
			}
			if (num4 == -1)
			{
				num2 = Math.Min(num2 + 1, base.Count);
				for (int i = num; i < num2; i++)
				{
					num5++;
					_ = base[i];
					DateTime t2 = base[i].dateTime_1;
					if (bool_1)
					{
						t2 = base[i].dateTime_0;
					}
					if (dateTime_2 <= t2)
					{
						return i;
					}
				}
			}
			if (num4 < 0)
			{
				num4 = num2;
			}
			return num4;
		}

		public void method_14(int int_0, DateTime dateTime_2, DateTime dateTime_3, DateTime dateTime_4, FCTickInfoList fctickInfoList_0, FriedmanCurveZoneInfo friedmanCurveZoneInfo_0)
		{
			DateTime d = dateTime_4.Date.AddHours(dateTime_4.Hour);
			DateTime dateTime = dateTime_2.Date.AddHours(dateTime_2.Hour);
			DateTime t = dateTime_3.Date.AddHours(dateTime_3.Hour);
			for (int i = 0; dateTime.AddHours(i) <= t; i++)
			{
				Class164 @class = new Class164();
				@class.string_0 = dateTime.AddHours(i).Hour.ToString();
				@class.string_1 = (dateTime.AddHours(i) - d).TotalHours.ToString();
				@class.int_1 = i;
				@class.dateTime_0 = dateTime.AddHours(i);
				@class.dateTime_1 = dateTime.AddHours(i + 1).AddMilliseconds(-1.0);
				@class.color_0 = Color.Black;
				Insert(i, @class);
			}
		}

		internal DateTime method_15(RectangleF rectangleF_0, float float_1)
		{
			int num = 0;
			int num2 = base.Count - 1;
			int num3 = 0;
			float_1 -= rectangleF_0.Left;
			while (true)
			{
				if (num2 - num > 5)
				{
					if (num3++ > 1000)
					{
						break;
					}
					int num4 = (num + num2) / 2;
					float num5 = base[num4].float_0;
					if (float_1 < num5)
					{
						num2 = num4;
					}
					else
					{
						num = num4;
					}
					continue;
				}
				int num6 = num2;
				Class164 @class;
				while (true)
				{
					if (num6 >= num)
					{
						@class = base[num6];
						if (@class.float_0 < float_1)
						{
							break;
						}
						num6--;
						continue;
					}
					return FriedmanCurveDocument.NullDate;
				}
				if (FriedmanCurveDocument.smethod_4(@class.dateTime_1))
				{
					return @class.dateTime_0;
				}
				long ticks = @class.dateTime_0.Ticks;
				long ticks2 = @class.dateTime_1.Ticks;
				long num7 = (long)((float)(ticks2 - ticks) * (float_1 - @class.float_0) / @class.float_1);
				return new DateTime(ticks + num7);
			}
			return FriedmanCurveDocument.NullDate;
		}

		public float method_16(RectangleF rectangleF_0, DateTime dateTime_2)
		{
			int num = method_13(dateTime_2, bool_0: false, bool_1: false);
			if (num < 0)
			{
				return float.NaN;
			}
			if (num >= base.Count)
			{
				return rectangleF_0.Left + base[base.Count - 1].float_0 + base[base.Count - 1].float_1;
			}
			Class164 @class = base[num];
			if (@class.dateTime_1 == dateTime_2)
			{
				return rectangleF_0.Left + @class.float_0 + @class.float_1;
			}
			if (@class.int_1 == 0 || @class.dateTime_1 == dateTime_2)
			{
				return rectangleF_0.Left + @class.float_0;
			}
			if (num > 0)
			{
				return rectangleF_0.Left + @class.float_0 + @class.float_1 * (float)(dateTime_2.Ticks - @class.dateTime_0.Ticks) / (float)(@class.dateTime_1.Ticks - @class.dateTime_0.Ticks);
			}
			return base[num].float_0;
		}

		public float method_17(RectangleF rectangleF_0, DateTime dateTime_2, ref Class164 class164_0)
		{
			int num = method_13(dateTime_2, bool_0: false, bool_1: false);
			if (num < 0)
			{
				return float.NaN;
			}
			if (num >= base.Count)
			{
				return rectangleF_0.Left + base[base.Count - 1].float_0 + base[base.Count - 1].float_1;
			}
			Class164 @class = base[num];
			if (num > 0 && dateTime_2 < @class.dateTime_1)
			{
				num--;
			}
			if (num < base.Count - 1)
			{
				class164_0 = @class;
				return rectangleF_0.Left + @class.float_0;
			}
			class164_0 = base[num];
			return base[num].float_0;
		}

		public RectangleF method_18(RectangleF rectangleF_0, DateTime dateTime_2)
		{
			RectangleF result = new RectangleF(-1f, rectangleF_0.Top, -1f, rectangleF_0.Height);
			bool flag = false;
			dateTime_2 = dateTime_2.Date;
			DateTime t = dateTime_2.AddDays(1.0);
			int num = method_13(dateTime_2, bool_0: false, bool_1: true);
			method_8(num);
			num = Math.Min(base.Count - 1, num + 5);
			int num2 = 0;
			int num3 = num;
			while (num3 >= num - 10)
			{
				num2++;
				Class164 @class = base[num3];
				if (!(dateTime_2 >= @class.dateTime_0))
				{
					num3--;
					continue;
				}
				result.X = rectangleF_0.Left + @class.float_0;
				if (dateTime_2 == @class.dateTime_1)
				{
					result.X = rectangleF_0.Left + @class.float_0 + @class.float_1;
				}
				for (int i = num3; i < base.Count; i++)
				{
					num2++;
					Class164 class2 = base[i];
					if (t <= class2.dateTime_1)
					{
						result.Width = rectangleF_0.Left + class2.float_0 + class2.float_1 - result.Left;
						flag = true;
						break;
					}
				}
				break;
			}
			if (result.Left < 0f)
			{
				return RectangleF.Empty;
			}
			if (!flag)
			{
				result.Width = rectangleF_0.Right - result.Left;
			}
			return result;
		}

		public float method_19()
		{
			return float_0;
		}

		public void method_20(float float_1)
		{
			float_0 = float_1;
		}

		public float method_21(int int_0)
		{
			if (base.Count == 0)
			{
				return 0f;
			}
			if (int_0 < 0)
			{
				return 0f;
			}
			if (int_0 >= base.Count)
			{
				return base[base.Count - 1].float_0 + base[base.Count - 1].float_1;
			}
			return base[int_0].float_0;
		}
	}
}
