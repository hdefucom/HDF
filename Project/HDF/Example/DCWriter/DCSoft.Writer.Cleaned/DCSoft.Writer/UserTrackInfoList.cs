using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Security;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer
{
	/// <summary>
	///       用户痕迹信息列表
	///       </summary>
	[ComDefaultInterface(typeof(IUserTrackInfoList))]
	[Guid("6A078F46-F943-482A-9332-0FC59C502CD8")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[DCPublishAPI]
	[DebuggerDisplay("Count={ Count }")]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[ComClass("6A078F46-F943-482A-9332-0FC59C502CD8", "41CAB7D0-1773-4965-9193-62F421392D66")]
	[DocumentComment]
	public class UserTrackInfoList : List<UserTrackInfo>, IUserTrackInfoList
	{
		private class Class45 : IComparer<UserTrackInfo>
		{
			public int Compare(UserTrackInfo userTrackInfo_0, UserTrackInfo userTrackInfo_1)
			{
				DateTime d = userTrackInfo_0.SaveTime;
				if (d == UserHistoryInfo.NullDateTime)
				{
					d = DateTime.MaxValue;
				}
				DateTime dateTime = userTrackInfo_1.SaveTime;
				if (dateTime == UserHistoryInfo.NullDateTime)
				{
					dateTime = DateTime.MaxValue;
				}
				int num = d.CompareTo(dateTime);
				if (num == 0)
				{
					int num2 = userTrackInfo_0._CreateIndex;
					if (num2 < 0)
					{
						num2 = userTrackInfo_0._DeletorIndex;
					}
					int num3 = userTrackInfo_1._CreateIndex;
					if (num3 < 0)
					{
						num3 = userTrackInfo_1._DeletorIndex;
					}
					return num2 - num3;
				}
				return num;
			}
		}

		internal const string string_0 = "6A078F46-F943-482A-9332-0FC59C502CD8";

		internal const string string_1 = "41CAB7D0-1773-4965-9193-62F421392D66";

		private XTextDocument xtextDocument_0 = null;

		private int int_0 = 0;

		private bool bool_0 = true;

		/// <summary>
		///       所操作的文档对象
		///       </summary>
		[XmlIgnore]
		public XTextDocument Document
		{
			get
			{
				return xtextDocument_0;
			}
			set
			{
				xtextDocument_0 = value;
			}
		}

		/// <summary>
		///       对象内容对应的文档版本号
		///       </summary>
		[XmlIgnore]
		public int ContentVersion
		{
			get
			{
				return int_0;
			}
			set
			{
				int_0 = value;
			}
		}

		[XmlIgnore]
		[DCPublishAPI]
		public bool IncludeComment
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		/// <summary>
		///       获得当前信息
		///       </summary>
		[XmlIgnore]
		[DCPublishAPI]
		public UserTrackInfo Current
		{
			get
			{
				if (xtextDocument_0 == null || base.Count == 0)
				{
					return null;
				}
				if (Document.CurrentContentPartyStyle == PageContentPartyStyle.Body)
				{
					XTextElement currentElement = Document.CurrentElement;
					using (Enumerator enumerator = GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							UserTrackInfo current = enumerator.Current;
							if (current.Elements.Contains(currentElement))
							{
								return current;
							}
						}
					}
				}
				return null;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		[DCPublishAPI]
		public UserTrackInfoList()
		{
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		internal UserTrackInfoList(XTextDocument xtextDocument_1)
		{
			xtextDocument_0 = xtextDocument_1;
		}

		/// <summary>
		///       刷新状态
		///       </summary>
		[DCPublishAPI]
		public void Refresh()
		{
			if (XTextDocument.smethod_13(GEnum6.const_129) && xtextDocument_0 != null)
			{
				int_0 = xtextDocument_0.ContentVersion;
				Clear();
				method_0(xtextDocument_0.Body.Content);
				if (base.Count != 0)
				{
					List<UserTrackInfo> list = new List<UserTrackInfo>();
					using (Enumerator enumerator = GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							UserTrackInfo current = enumerator.Current;
							if (current._CreateIndex >= 0 && current._DeletorIndex >= 0)
							{
								UserTrackInfo userTrackInfo = new UserTrackInfo();
								userTrackInfo.InfoType = UserTrackType.Create;
								userTrackInfo._CreateIndex = current._CreateIndex;
								userTrackInfo.Elements.AddRange(current.Elements);
								list.Add(userTrackInfo);
								userTrackInfo = new UserTrackInfo();
								userTrackInfo.InfoType = UserTrackType.Delete;
								userTrackInfo._DeletorIndex = current._DeletorIndex;
								userTrackInfo.Elements.AddRange(current.Elements);
								list.Add(userTrackInfo);
							}
							else if (current._DeletorIndex >= 0)
							{
								current.InfoType = UserTrackType.Delete;
								list.Add(current);
							}
							else if (current._CreateIndex >= 0)
							{
								current.InfoType = UserTrackType.Create;
								list.Add(current);
							}
							else if (current._CommentIndex >= 0)
							{
								current.InfoType = UserTrackType.Comment;
								list.Add(current);
							}
						}
					}
					Clear();
					AddRange(list);
					using (Enumerator enumerator = GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							UserTrackInfo current = enumerator.Current;
							if (current._CreateIndex >= 0)
							{
								UserHistoryInfo info = xtextDocument_0.UserHistories.GetInfo(current._CreateIndex);
								if (info != null)
								{
									current.UserID = info.ID;
									current.UserName = info.Name;
									current.SaveTime = info.SavedTime;
									current.PermissionLevel = info.PermissionLevel;
								}
							}
							else if (current._DeletorIndex >= 0)
							{
								UserHistoryInfo info = xtextDocument_0.UserHistories.GetInfo(current._DeletorIndex);
								if (info != null)
								{
									current.UserID = info.ID;
									current.UserName = info.Name;
									current.SaveTime = info.SavedTime;
									current.PermissionLevel = info.PermissionLevel;
								}
							}
							else if (current._CommentIndex >= 0)
							{
								DocumentComment byCommentIndex = xtextDocument_0.Comments.GetByCommentIndex(current._CommentIndex);
								if (byCommentIndex != null)
								{
									current.CommentText = byCommentIndex.Text;
									int creatorIndex = byCommentIndex.CreatorIndex;
									if (creatorIndex >= 0)
									{
										UserHistoryInfo info2 = xtextDocument_0.UserHistories.GetInfo(creatorIndex);
										current.UserID = info2.ID;
										current.UserName = info2.Name;
										current.SaveTime = info2.SavedTime;
										current.PermissionLevel = info2.PermissionLevel;
									}
									else
									{
										current.UserID = byCommentIndex.AuthorID;
										current.UserName = byCommentIndex.Author;
										current.SaveTime = byCommentIndex.CreationTime;
										current.PermissionLevel = 0;
									}
								}
							}
						}
					}
				}
			}
		}

		private void method_0(XTextElementList xtextElementList_0)
		{
			UserTrackInfo userTrackInfo = null;
			bool fillCommentToUserTrackList = Document.Options.BehaviorOptions.FillCommentToUserTrackList;
			foreach (XTextElement item in xtextElementList_0)
			{
				RuntimeDocumentContentStyle runtimeStyle = item.RuntimeStyle;
				if (runtimeStyle.CreatorIndex >= 0 || runtimeStyle.DeleterIndex >= 0)
				{
					if (userTrackInfo == null || userTrackInfo._CreateIndex != runtimeStyle.CreatorIndex || userTrackInfo._DeletorIndex != runtimeStyle.DeleterIndex)
					{
						userTrackInfo = new UserTrackInfo();
						userTrackInfo._CreateIndex = runtimeStyle.CreatorIndex;
						userTrackInfo._DeletorIndex = runtimeStyle.DeleterIndex;
						Add(userTrackInfo);
					}
					userTrackInfo.Elements.Add(item);
				}
				else if (fillCommentToUserTrackList && runtimeStyle.CommentIndex >= 0)
				{
					if (userTrackInfo == null || userTrackInfo._CommentIndex != runtimeStyle.CommentIndex)
					{
						userTrackInfo = new UserTrackInfo();
						userTrackInfo._CommentIndex = runtimeStyle.CommentIndex;
						Add(userTrackInfo);
					}
					userTrackInfo.Elements.Add(item);
				}
				else
				{
					userTrackInfo = null;
				}
			}
		}

		/// <summary>
		///       为COM接口开放的读取列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <returns>获得的列表成员对象</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public UserTrackInfo ComGetItem(int index)
		{
			return base[index];
		}

		/// <summary>
		///       为COM接口开放的设置列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <param name="item">新的列表成员对象</param>
		[ComVisible(true)]
		[DCPublishAPI]
		public void ComSetItem(int index, UserTrackInfo item)
		{
			base[index] = item;
		}
	}
}
