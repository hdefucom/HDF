using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       数据标尺刻度信息列表
	///       </summary>
	[Serializable]
	[Guid("AAC5D238-6D6D-4DC7-B097-7D0016B2BD11")]
	[ComVisible(true)]
	[DebuggerDisplay("Count={ Count }")]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	[ComDefaultInterface(typeof(IYAxisScaleInfoList))]
	public class YAxisScaleInfoList : List<YAxisScaleInfo>, IYAxisScaleInfoList
	{
		private class ItemComparaer : IComparer<YAxisScaleInfo>
		{
			public int Compare(YAxisScaleInfo yaxisScaleInfo_0, YAxisScaleInfo yaxisScaleInfo_1)
			{
				if (yaxisScaleInfo_0.Value == yaxisScaleInfo_1.Value)
				{
					return 0;
				}
				if (yaxisScaleInfo_0.Value > yaxisScaleInfo_1.Value)
				{
					return 1;
				}
				return -1;
			}
		}

		/// <summary>
		///       获得最大值
		///       </summary>
		internal float MaxValue
		{
			get
			{
				float num = float.NaN;
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						IYAxisScaleInfo current = enumerator.Current;
						if (!TemperatureDocument.smethod_3(current.Value))
						{
							if (float.IsNaN(num))
							{
								num = current.Value;
							}
							else if (num < current.Value)
							{
								num = current.Value;
							}
						}
					}
				}
				return num;
			}
		}

		/// <summary>
		///       获得最大值
		///       </summary>
		internal float MinValue
		{
			get
			{
				float num = float.NaN;
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						IYAxisScaleInfo current = enumerator.Current;
						if (!TemperatureDocument.smethod_3(current.Value))
						{
							if (float.IsNaN(num))
							{
								num = current.Value;
							}
							else if (num > current.Value)
							{
								num = current.Value;
							}
						}
					}
				}
				return num;
			}
		}

		internal YAxisScaleInfo GetScaleInfoByValue(float Value)
		{
			if (TemperatureDocument.smethod_3(Value) || base.Count == 0)
			{
				return null;
			}
			if (base.Count == 1)
			{
				return base[0];
			}
			int num = base.Count - 1;
			while (true)
			{
				if (num >= 0)
				{
					if (base[num].Value <= Value)
					{
						break;
					}
					num--;
					continue;
				}
				return base[0];
			}
			return base[num];
		}

		/// <summary>
		///       添加项目
		///       </summary>
		/// <param name="Value">
		/// </param>
		/// <param name="scaleRate">
		/// </param>
		public void AddItem(float Value, float scaleRate)
		{
			YAxisScaleInfo yAxisScaleInfo = new YAxisScaleInfo();
			yAxisScaleInfo.Value = Value;
			yAxisScaleInfo.ScaleRate = scaleRate;
			Add(yAxisScaleInfo);
		}

		/// <summary>
		///       根据数值进行排序
		///       </summary>
		public void SortByValue()
		{
			Sort(new ItemComparaer());
		}
	}
}
