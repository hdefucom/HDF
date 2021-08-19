using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Security
{
	/// <summary>
	///       用户历史信息列表
	///       </summary>
	/// <remarks>编写 袁永福</remarks>
	[Serializable]
	[DocumentComment]
	[ComClass("696E0894-CC08-4003-9566-1A0F4AE68087", "35D44AE6-80B3-4C34-B57E-5E03370CB20E")]
	[DCPublishAPI]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IUserHistoryInfoList))]
	[Guid("696E0894-CC08-4003-9566-1A0F4AE68087")]
	[DebuggerDisplay("Count={ Count }")]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	public class UserHistoryInfoList : List<UserHistoryInfo>, ICloneable, IUserHistoryInfoList
	{
		private class UserHistoryInfoIndexComparer : IComparer<UserHistoryInfo>
		{
			public int Compare(UserHistoryInfo userHistoryInfo_0, UserHistoryInfo userHistoryInfo_1)
			{
				return userHistoryInfo_0.Index - userHistoryInfo_1.Index;
			}
		}

		internal const string CLASSID = "696E0894-CC08-4003-9566-1A0F4AE68087";

		internal const string CLASSID_Interface = "35D44AE6-80B3-4C34-B57E-5E03370CB20E";

		/// <summary>
		///       能否允许压缩掉最后一个列表项目。
		///       </summary>
		internal bool _CanCompressLastItem = true;

		/// <summary>
		///       当前编号
		///       </summary>
		public int CurrentIndex => base.Count - 1;

		/// <summary>
		///       当前授权等级
		///       </summary>
		public int CurrentPermissionLevel
		{
			get
			{
				if (base.Count > 0)
				{
					return base[base.Count - 1].PermissionLevel;
				}
				return -1;
			}
		}

		/// <summary>
		///       当前用户信息
		///       </summary>
		public UserHistoryInfo CurrentInfo
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

		/// <summary>
		///       当前用户编号
		///       </summary>
		public string CurrentUserID
		{
			get
			{
				if (base.Count > 0)
				{
					return base[base.Count - 1].ID;
				}
				return null;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		[DCPublishAPI]
		public UserHistoryInfoList()
		{
		}

		/// <summary>
		///       刷新元素编号
		///       </summary>
		public void RefreshIndex()
		{
			for (int i = 0; i < base.Count; i++)
			{
				base[i].Index = i;
			}
		}

		/// <summary>
		///       获得指定编号的用户历史信息对象
		///       </summary>
		/// <param name="index">编号</param>
		/// <returns>用户历史信息对象</returns>
		public UserHistoryInfo GetInfo(int index)
		{
			if (index < 0 || base.Count == 0)
			{
				return null;
			}
			if (index >= 0 && index < base.Count)
			{
				return base[index];
			}
			return base[0];
		}

		/// <summary>
		///       获得指定用户编号的授权许可等级
		///       </summary>
		/// <param name="index">用户编号</param>
		/// <returns>许可等级</returns>
		public int GetPermissionLevel(int index)
		{
			return GetInfo(index)?.PermissionLevel ?? int.MinValue;
		}

		/// <summary>
		///       获得指定用户编号的用户编号
		///       </summary>
		/// <param name="index">用户编号</param>
		/// <returns>用户编号</returns>
		public string GetID(int index)
		{
			return GetInfo(index)?.ID;
		}

		/// <summary>
		///       深度复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public UserHistoryInfoList Clone()
		{
			return (UserHistoryInfoList)((ICloneable)this).Clone();
		}

		object ICloneable.Clone()
		{
			UserHistoryInfoList userHistoryInfoList = new UserHistoryInfoList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					UserHistoryInfo current = enumerator.Current;
					userHistoryInfoList.Add(current.Clone());
				}
			}
			return userHistoryInfoList;
		}

		/// <summary>
		///       根据序号进行排序
		///       </summary>
		public void SortByIndex()
		{
			Sort(new UserHistoryInfoIndexComparer());
		}

		/// <summary>
		///       为COM接口开放的读取列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <returns>获得的列表成员对象</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public UserHistoryInfo ComGetItem(int index)
		{
			return base[index];
		}

		/// <summary>
		///       为COM接口开放的设置列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <param name="item">新的列表成员对象</param>
		[DCPublishAPI]
		[ComVisible(true)]
		public void ComSetItem(int index, UserHistoryInfo item)
		{
			base[index] = item;
		}
	}
}
