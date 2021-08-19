using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       Y坐标轴信息列表
	///       </summary>
	[Serializable]
	[ComDefaultInterface(typeof(IYAxisInfoList))]
	[DebuggerDisplay("Count={ Count }")]
	[Guid("2AE887E6-90D2-4959-AAB0-66DF860F5DDC")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[DocumentComment]
	public class YAxisInfoList : List<YAxisInfo>, IYAxisInfoList
	{
		public YAxisInfo LastInfo
		{
			get
			{
				if (base.Count > 0)
				{
					return base[base.Count - 1];
				}
				return null;
			}
		}

		public float TotalTitleWidth
		{
			get
			{
				float num = 0f;
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						YAxisInfo current = enumerator.Current;
						if (!current.MergeIntoLeft)
						{
							num += current.TitleWidth;
						}
					}
				}
				return num;
			}
		}

		/// <summary>
		///       获得指定名称的项目
		///       </summary>
		/// <param name="name">名称</param>
		/// <returns>找到的项目</returns>
		public YAxisInfo GetItemByName(string name)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					YAxisInfo current = enumerator.Current;
					if (current.Name == name)
					{
						return current;
					}
				}
			}
			return null;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public YAxisInfoList Clone()
		{
			YAxisInfoList yAxisInfoList = new YAxisInfoList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					YAxisInfo current = enumerator.Current;
					yAxisInfoList.Add(current.Clone());
				}
			}
			return yAxisInfoList;
		}
	}
}
