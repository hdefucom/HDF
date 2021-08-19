using DCSoft.Common;
using DCSoft.TemperatureChart;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace DCSoftDotfuscate
{
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[DebuggerDisplay("Count={ Count }")]
	internal class Class159 : List<Class158>
	{
		private DateTime dateTime_0 = TemperatureDocument.NullDate;

		private DateTime dateTime_1 = TemperatureDocument.NullDate;

		internal DCTimeUnit dctimeUnit_0 = DCTimeUnit.Hour;

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
			return TemperatureDocument.NullDate;
		}

		public Class158 method_5()
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
				Class158 @class = base[num5];
				if (@class.dateTime_1.Date < date)
				{
					num = num5 + 1;
				}
			}
			return num;
		}

		public Class158 method_8(int int_0)
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

		public float method_11(DateTime dateTime_2, ref Class158 class158_0)
		{
			int num = method_13(dateTime_2, bool_0: true, bool_1: false);
			if (num >= 0 && num < base.Count - 1)
			{
				Class158 @class = base[num];
				if (@class.dateTime_1 >= dateTime_2)
				{
					if (@class.timeLineZoneInfo_0 != null && !@class.timeLineZoneInfo_0.AlignToGrid)
					{
						if (dateTime_2 <= @class.dateTime_0)
						{
							class158_0 = @class;
							return @class.float_0;
						}
						float result = @class.float_0 + @class.float_1 * (float)(dateTime_2.Ticks - @class.dateTime_0.Ticks) / (float)(@class.dateTime_1.Ticks - @class.dateTime_0.Ticks);
						class158_0 = @class;
						return result;
					}
					if (num >= base.Count)
					{
						class158_0 = base[base.Count - 1];
					}
					else
					{
						class158_0 = base[num];
					}
					return method_12(num);
				}
				if (@class.timeLineZoneInfo_0 != null && !@class.timeLineZoneInfo_0.AlignToGrid)
				{
					Class158 class2 = base[num + 1];
					if (class2.timeLineZoneInfo_0 == @class.timeLineZoneInfo_0)
					{
						float result = @class.float_0 + (class2.float_0 - @class.float_0) * (float)(dateTime_2.Ticks - @class.dateTime_1.Ticks) / (float)(class2.dateTime_1.Ticks - @class.dateTime_1.Ticks);
						class158_0 = @class;
						return result;
					}
				}
			}
			if (num >= base.Count)
			{
				class158_0 = base[base.Count - 1];
			}
			else
			{
				class158_0 = base[num];
			}
			return method_12(num);
		}

		public float method_12(int int_0)
		{
			if (int_0 < 0)
			{
				return 0f;
			}
			Class158 @class;
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

		public void method_14(int int_0, DateTime dateTime_2, DateTime dateTime_3, TickInfoList tickInfoList_0, TimeLineZoneInfo timeLineZoneInfo_0)
		{
			Class158 @class = method_8(int_0 - 1);
			Class158 class2 = method_8(int_0);
			if (!(timeLineZoneInfo_0?.IsExpanded ?? true))
			{
				Class158 class3 = new Class158();
				class3.timeLineZoneInfo_0 = timeLineZoneInfo_0;
				class3.dateTime_0 = timeLineZoneInfo_0.StartTime;
				class3.dateTime_1 = timeLineZoneInfo_0.EndTime;
				class3.string_0 = "";
				class3.int_1 = 0;
				Insert(int_0, class3);
				if (@class != null)
				{
					@class.dateTime_1 = class3.dateTime_0;
				}
				if (class2 != null)
				{
					class2.dateTime_0 = class3.dateTime_1;
				}
				return;
			}
			if (tickInfoList_0 == null || tickInfoList_0.Count == 0)
			{
				if (timeLineZoneInfo_0 == null || timeLineZoneInfo_0.AutoTickStepSeconds <= 0)
				{
					return;
				}
				tickInfoList_0 = new TickInfoList();
				tickInfoList_0.FillTickItems(timeLineZoneInfo_0.AutoTickStepSeconds, 86400f, timeLineZoneInfo_0.AutoTickFormatString);
				if (tickInfoList_0.Count == 0)
				{
					return;
				}
			}
			if (tickInfoList_0 == null || tickInfoList_0.Count == 0)
			{
				return;
			}
			int num = tickInfoList_0.GetStartHourTickIndex(dateTime_2);
			DateTime dateTime = dateTime_2.Date;
			int num2 = 0;
			bool flag = tickInfoList_0[0].Value == 0f;
			bool flag2 = true;
			float num3 = 24f / (float)tickInfoList_0.Count;
			for (int i = 0; i < tickInfoList_0.Count; i++)
			{
				float num4 = num3 * (float)(i + 1);
				if ((double)Math.Abs(num4 - tickInfoList_0[i].Value) > 0.01)
				{
					flag2 = false;
					break;
				}
			}
			DateTime dateTime2 = dateTime_2;
			while (num2++ <= 1000000)
			{
				TickInfo tickInfo = tickInfoList_0[num];
				Class158 class3 = new Class158();
				class3.int_1 = num;
				class3.string_0 = tickInfo.Text;
				class3.color_0 = tickInfo.Color;
				class3.timeLineZoneInfo_0 = timeLineZoneInfo_0;
				if (num == 0)
				{
					class3.dateTime_0 = dateTime;
				}
				else if (flag)
				{
					class3.dateTime_0 = dateTime.AddHours(tickInfoList_0[num].Value);
				}
				else if (flag2)
				{
					class3.dateTime_0 = dateTime.AddHours(tickInfoList_0[num - 1].Value);
				}
				else
				{
					class3.dateTime_0 = dateTime.AddHours((tickInfoList_0[num - 1].Value + tickInfo.Value) / 2f);
				}
				if (num == tickInfoList_0.Count - 1)
				{
					class3.dateTime_1 = dateTime.AddDays(1.0);
				}
				else if (flag)
				{
					class3.dateTime_1 = dateTime.AddHours(tickInfoList_0[num + 1].Value);
				}
				else if (flag2)
				{
					class3.dateTime_1 = dateTime.AddHours(tickInfoList_0[num].Value);
				}
				else
				{
					class3.dateTime_1 = dateTime.AddHours((tickInfo.Value + tickInfoList_0[num + 1].Value) / 2f);
				}
				dateTime2 = class3.dateTime_1;
				if (class3.dateTime_0 >= dateTime_3 && dateTime_3.Hour == 0 && dateTime_3.Minute == 0 && dateTime_3.Second == 0)
				{
					break;
				}
				Insert(int_0, class3);
				int_0++;
				num++;
				if (num >= tickInfoList_0.Count)
				{
					num -= tickInfoList_0.Count;
					dateTime = dateTime.AddDays(1.0);
				}
				if (dateTime2 >= dateTime_3)
				{
					break;
				}
			}
			if (timeLineZoneInfo_0 == null)
			{
				return;
			}
			Class158 class4;
			if (@class != null)
			{
				class4 = method_8(IndexOf(@class) + 1);
				if (class4 != null)
				{
					@class.dateTime_1 = class4.dateTime_0;
				}
			}
			if (class2 == null)
			{
				return;
			}
			class4 = method_8(IndexOf(class2) - 1);
			if (class4 != null)
			{
				class2.dateTime_0 = class4.dateTime_1;
				if (class2.dateTime_0 == class2.dateTime_1)
				{
					Remove(class2);
				}
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
				Class158 @class;
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
					return TemperatureDocument.NullDate;
				}
				if (TemperatureDocument.smethod_4(@class.dateTime_1))
				{
					return @class.dateTime_0;
				}
				long ticks = @class.dateTime_0.Ticks;
				long ticks2 = @class.dateTime_1.Ticks;
				long num7 = (long)((float)(ticks2 - ticks) * (float_1 - @class.float_0) / @class.float_1);
				return new DateTime(ticks + num7);
			}
			return TemperatureDocument.NullDate;
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
			Class158 @class = base[num];
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

		public float method_17(RectangleF rectangleF_0, DateTime dateTime_2, ref Class158 class158_0)
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
			Class158 @class = base[num];
			if (num > 0 && dateTime_2 < @class.dateTime_1)
			{
				num--;
			}
			if (num < base.Count - 1)
			{
				class158_0 = @class;
				return rectangleF_0.Left + @class.float_0;
			}
			class158_0 = base[num];
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
				Class158 @class = base[num3];
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
					Class158 class2 = base[i];
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
