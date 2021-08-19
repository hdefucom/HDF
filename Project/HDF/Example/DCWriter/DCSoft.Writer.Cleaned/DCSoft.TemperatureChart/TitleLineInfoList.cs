using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       对象列表
	///       </summary>
	[Serializable]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[ComDefaultInterface(typeof(ITitleLineInfoList))]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("2AEB9430-5DA2-47A3-9360-D34A83F3EB20")]
	[DocumentComment]
	[ComVisible(true)]
	[DebuggerDisplay("Count={ Count }")]
	public class TitleLineInfoList : List<TitleLineInfo>, ITitleLineInfoList
	{
		/// <summary>
		///       总的运行时高度
		///       </summary>
		internal float TotalRuntimeHeight
		{
			get
			{
				float num = 0f;
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						TitleLineInfo current = enumerator.Current;
						num += current.RuntimeHeight;
					}
				}
				return num;
			}
		}

		/// <summary>
		///       获得运行时使用的标题行列表
		///       </summary>
		/// <returns>
		/// </returns>
		internal TitleLineInfoList GetRuntimeInfos()
		{
			TitleLineInfoList titleLineInfoList = new TitleLineInfoList();
			TitleLineInfo titleLineInfo = null;
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					TitleLineInfo current = enumerator.Current;
					current.ShowExpandedHandle = false;
					if (current.LayoutType == TitleLineLayoutType.AutoCascade)
					{
						current.ShowExpandedHandle = true;
					}
					if (titleLineInfo != null && current.GroupName == titleLineInfo.GroupName)
					{
						current.ShowExpandedHandle = false;
						if (!titleLineInfo.IsExpanded)
						{
							continue;
						}
					}
					if (!string.IsNullOrEmpty(current.GroupName) && (titleLineInfo == null || titleLineInfo.GroupName != current.GroupName))
					{
						titleLineInfo = current;
						current.ShowExpandedHandle = true;
					}
					if (current.LayoutType == TitleLineLayoutType.AutoCascade && string.IsNullOrEmpty(current.GroupName))
					{
						current.ShowExpandedHandle = true;
					}
					titleLineInfoList.Add(current);
				}
			}
			return titleLineInfoList;
		}

		/// <summary>
		///       获得指定名称的项目
		///       </summary>
		/// <param name="name">名称</param>
		/// <returns>项目</returns>
		public TitleLineInfo GetItemByName(string name)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					TitleLineInfo current = enumerator.Current;
					if (current.Name == name)
					{
						return current;
					}
				}
			}
			return null;
		}
	}
}
