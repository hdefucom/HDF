using DCSoft.Common;
using DCSoft.Writer.Dom;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       授权控制器
	///       </summary>
	/// <remarks>编写 袁永福</remarks>
	[DocumentComment]
	[ComVisible(false)]
	public class DCPermissionControler
	{
		private string string_0 = null;

		/// <summary>
		///       最后一次判断生成的消息文本
		///       </summary>
		public string LastMessage
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		/// <summary>
		///       判断是否具有删除的权限
		///       </summary>
		/// <param name="document">文档对象</param>
		/// <param name="creatorIndex">创建记录编号</param>
		/// <param name="deletorIndex">删除记录编号</param>
		/// <returns>是否具有删除权限</returns>
		public virtual bool CanDelete(XTextDocument document, int creatorIndex, int deletorIndex)
		{
			int num = 11;
			if (document == null)
			{
				throw new ArgumentNullException("document");
			}
			LastMessage = null;
			if (document.Options.SecurityOptions.EnablePermission)
			{
				if (creatorIndex >= 0 && !(document.UserHistories.CurrentUserID == document.UserHistories.GetID(creatorIndex)))
				{
					int permissionLevel = document.UserHistories.GetPermissionLevel(creatorIndex);
					int currentPermissionLevel = document.UserHistories.CurrentPermissionLevel;
					if (currentPermissionLevel == permissionLevel && !document.Options.SecurityOptions.CanModifyDeleteSameLevelContent)
					{
						LastMessage = WriterStringsCore.ReadonlyForSameLevelContent;
						return false;
					}
					if (currentPermissionLevel < permissionLevel)
					{
						LastMessage = string.Format(WriterStringsCore.ReadonlyLowPermissionLevel_CurLevel_NeedLevel, currentPermissionLevel, permissionLevel);
						return false;
					}
				}
				if (deletorIndex >= 0)
				{
					if (document.Options.SecurityOptions.EnableLogicDelete)
					{
						LastMessage = WriterStringsCore.ReadonlyLogicDeleted;
						return false;
					}
					int permissionLevel = document.UserHistories.GetPermissionLevel(deletorIndex);
					int currentPermissionLevel = document.UserHistories.CurrentPermissionLevel;
					if (currentPermissionLevel == permissionLevel && !document.Options.SecurityOptions.CanModifyDeleteSameLevelContent && document.UserHistories.CurrentUserID != document.UserHistories.GetID(creatorIndex))
					{
						LastMessage = WriterStringsCore.ReadonlyForSameLevelContent;
						return false;
					}
					if (currentPermissionLevel < permissionLevel)
					{
						LastMessage = string.Format(WriterStringsCore.ReadonlyLowPermissionLevel_CurLevel_NeedLevel, currentPermissionLevel, permissionLevel);
						return false;
					}
				}
			}
			return true;
		}

		/// <summary>
		///       判断是否具有修改的权限
		///       </summary>
		/// <param name="document">文档对象</param>
		/// <param name="creatorIndex">要修改的对象的创建记录编号</param>
		/// <param name="deletorIndex">要修改的对象的删除记录编号</param>
		/// <returns>是否具有权限</returns>
		public virtual bool CanModify(XTextDocument document, int creatorIndex, int deletorIndex)
		{
			int num = 2;
			if (document == null)
			{
				throw new ArgumentNullException("document");
			}
			if (document.Options.SecurityOptions.EnablePermission)
			{
				if (deletorIndex >= 0)
				{
					return false;
				}
				if (creatorIndex >= 0)
				{
					if (document.UserHistories.CurrentUserID == document.UserHistories.GetID(creatorIndex))
					{
						return true;
					}
					int permissionLevel = document.UserHistories.GetPermissionLevel(creatorIndex);
					int currentPermissionLevel = document.UserHistories.CurrentPermissionLevel;
					if (currentPermissionLevel == permissionLevel && !document.Options.SecurityOptions.CanModifyDeleteSameLevelContent)
					{
						LastMessage = WriterStringsCore.ReadonlyForSameLevelContent;
						return false;
					}
					if (currentPermissionLevel < permissionLevel)
					{
						LastMessage = string.Format(WriterStringsCore.ReadonlyLowPermissionLevel_CurLevel_NeedLevel, currentPermissionLevel, permissionLevel);
						return false;
					}
				}
			}
			return true;
		}
	}
}
