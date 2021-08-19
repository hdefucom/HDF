using DCSoft.Common;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Text;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       刻度信息列表
	///       </summary>
	[Serializable]
	[Editor(typeof(GClass149), typeof(UITypeEditor))]
	[DocumentComment]
	public class TickInfoList : List<TickInfo>
	{
		/// <summary>
		///       填充时刻成员
		///       </summary>
		/// <param name="tickStepSeconds">时刻长度，单位秒。</param>
		/// <param name="totalSeconds">总的秒数</param>
		/// <param name="specifyFormatString">指定的时刻格式化字符串</param>
		internal void FillTickItems(int tickStepSeconds, float totalSeconds, string specifyFormatString)
		{
			int num = 16;
			if (tickStepSeconds <= 0)
			{
				return;
			}
			for (int i = 0; (float)i < totalSeconds; i += tickStepSeconds)
			{
				TickInfo tickInfo = new TickInfo();
				DateTime dateTime = new DateTime(1900, 1, 1).AddSeconds(i);
				string text = dateTime.Hour.ToString();
				if (string.IsNullOrEmpty(specifyFormatString))
				{
					if (tickStepSeconds < 60)
					{
						text = dateTime.ToString("HH:mm:ss");
					}
					else if (tickStepSeconds < 3600)
					{
						text = dateTime.ToString("HH:mm");
					}
				}
				else
				{
					text = dateTime.ToString(specifyFormatString);
				}
				tickInfo.Text = text;
				tickInfo.Value = (float)i / 3600f;
				Add(tickInfo);
			}
		}

		/// <summary>
		///       添加项目
		///       </summary>
		/// <param name="v">时刻</param>
		/// <param name="txt">文本</param>
		/// <param name="c">颜色</param>
		public void AddItem(int int_0, string string_0, Color color_0)
		{
			Add(new TickInfo(int_0, string_0, color_0));
		}

		/// <summary>
		///       获得小时刻度序号
		///       </summary>
		/// <param name="dtm">时间</param>
		/// <returns>序号</returns>
		internal int GetStartHourTickIndex(DateTime dateTime_0)
		{
			if (base.Count == 0)
			{
				return 0;
			}
			bool flag = base[0].Value == 0f;
			float num = (float)dateTime_0.Hour + (float)dateTime_0.Minute / 60f + (float)dateTime_0.Second / 3600f;
			int num2 = 0;
			while (true)
			{
				if (num2 < base.Count)
				{
					if (num != base[num2].Value)
					{
					}
					if (num < base[num2].Value)
					{
						break;
					}
					num2++;
					continue;
				}
				return base.Count - 1;
			}
			if (flag)
			{
				return Math.Max(num2 - 1, 0);
			}
			return num2;
		}

		/// <summary>
		///       返回表示数据的字符串
		///       </summary>
		/// <returns>
		/// </returns>
		public override string ToString()
		{
			int num = 17;
			StringBuilder stringBuilder = new StringBuilder();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					TickInfo current = enumerator.Current;
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(",");
					}
					stringBuilder.Append(current.Value.ToString());
				}
			}
			return stringBuilder.ToString();
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public TickInfoList Clone()
		{
			TickInfoList tickInfoList = new TickInfoList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					TickInfo current = enumerator.Current;
					tickInfoList.Add(current.Clone());
				}
			}
			return tickInfoList;
		}
	}
}
