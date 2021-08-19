using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       Y坐标轴信息列表
	///       </summary>
	[Serializable]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[DebuggerDisplay("Count={ Count }")]
	[Guid("248B4EE5-96AC-4D33-B840-48C82AB0AC1C")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IYAxisInfoList))]
	[DocumentComment]
	public class FCYAxisInfoList : List<FCYAxisInfo>, IYAxisInfoList
	{
		public FCYAxisInfo LastInfo
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
						FCYAxisInfo current = enumerator.Current;
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
		public FCYAxisInfo GetItemByName(string name)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					FCYAxisInfo current = enumerator.Current;
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
		public FCYAxisInfoList Clone()
		{
			FCYAxisInfoList fCYAxisInfoList = new FCYAxisInfoList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					FCYAxisInfo current = enumerator.Current;
					fCYAxisInfoList.Add(current.Clone());
				}
			}
			return fCYAxisInfoList;
		}
	}
}
