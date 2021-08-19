using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       对象列表
	///       </summary>
	[Serializable]
	[ComVisible(true)]
	[DebuggerDisplay("Count={ Count }")]
	[DocumentComment]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(ITitleLineInfoList))]
	[Guid("AE2A47EC-CD1A-4531-B830-2F04508CFE06")]
	public class FCTitleLineInfoList : List<FCTitleLineInfo>, ITitleLineInfoList
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
						FCTitleLineInfo current = enumerator.Current;
						num = num + current.RuntimeHeight + current.BottomSpacing;
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
		internal FCTitleLineInfoList GetRuntimeInfos()
		{
			FCTitleLineInfoList fCTitleLineInfoList = new FCTitleLineInfoList();
			FCTitleLineInfo fCTitleLineInfo = null;
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					FCTitleLineInfo current = enumerator.Current;
					current.ShowExpandedHandle = false;
					if (current.LayoutType == FCTitleLineLayoutType.AutoCascade)
					{
						current.ShowExpandedHandle = true;
					}
					if (fCTitleLineInfo != null && current.GroupName == fCTitleLineInfo.GroupName)
					{
						current.ShowExpandedHandle = false;
						if (!fCTitleLineInfo.IsExpanded)
						{
							continue;
						}
					}
					if (!string.IsNullOrEmpty(current.GroupName) && (fCTitleLineInfo == null || fCTitleLineInfo.GroupName != current.GroupName))
					{
						fCTitleLineInfo = current;
						current.ShowExpandedHandle = true;
					}
					if (current.LayoutType == FCTitleLineLayoutType.AutoCascade && string.IsNullOrEmpty(current.GroupName))
					{
						current.ShowExpandedHandle = true;
					}
					fCTitleLineInfoList.Add(current);
				}
			}
			return fCTitleLineInfoList;
		}

		/// <summary>
		///       获得指定名称的项目
		///       </summary>
		/// <param name="name">名称</param>
		/// <returns>项目</returns>
		public FCTitleLineInfo GetItemByName(string name)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					FCTitleLineInfo current = enumerator.Current;
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
