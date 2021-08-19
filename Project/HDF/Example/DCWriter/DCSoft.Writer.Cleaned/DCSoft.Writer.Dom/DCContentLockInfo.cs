using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档内容锁定信息
	///       </summary>
	[Serializable]
	[Guid("495A2C79-9C36-4CA1-9AF2-E6B793ECC7F1")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("495A2C79-9C36-4CA1-9AF2-E6B793ECC7F1", "678CD509-93EC-4184-B543-2247D344A688")]
	[DocumentComment]
	[DCPublishAPI]
	[ComDefaultInterface(typeof(IDCContentLockInfo))]
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	[ComVisible(true)]
	[XmlType]
	public class DCContentLockInfo : IDCStringSerializable, IDCContentLockInfo
	{
		internal const string CLASSID = "495A2C79-9C36-4CA1-9AF2-E6B793ECC7F1";

		internal const string CLASSID_Interface = "678CD509-93EC-4184-B543-2247D344A688";

		private string _OwnerUserID = null;

		private DateTime _CreationTime = DocumentInfo.NullDateTime;

		private string _AuthorisedUserIDList = null;

		/// <summary>
		///       文件锁定的拥有者用户ID
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(null)]
		public string OwnerUserID
		{
			get
			{
				return _OwnerUserID;
			}
			set
			{
				_OwnerUserID = value;
			}
		}

		/// <summary>
		///       锁定时间
		///       </summary>
		[DCPublishAPI]
		public DateTime CreationTime
		{
			get
			{
				return _CreationTime;
			}
			set
			{
				_CreationTime = value;
			}
		}

		/// <summary>
		///       授权用户名列表，各个用户名之间用半角逗号分开。
		///       </summary>
		[DefaultValue(null)]
		[DCPublishAPI]
		public string AuthorisedUserIDList
		{
			get
			{
				return _AuthorisedUserIDList;
			}
			set
			{
				_AuthorisedUserIDList = value;
			}
		}

		public bool IsEmpty => string.IsNullOrEmpty(_AuthorisedUserIDList) && _CreationTime != DocumentInfo.NullDateTime && string.IsNullOrEmpty(_OwnerUserID);

		/// <summary>
		///       检查操作文档的当前用户是否为授权用户
		///       </summary>
		/// <param name="document">文档对象</param>
		/// <returns>是否授权通过</returns>
		public bool CheckCurrentUserAuthorize(XTextDocument document)
		{
			int num = 10;
			if (document == null)
			{
				throw new ArgumentNullException("documnet");
			}
			if (!document.Options.BehaviorOptions.EnableContentLock)
			{
				return true;
			}
			if (document.CurrentUser != null)
			{
				return CheckAuthorize(document.CurrentUser.ID);
			}
			return CheckAuthorize(null);
		}

		/// <summary>
		///       检查是否为授权用户
		///       </summary>
		/// <param name="userID">用户名</param>
		/// <returns>是否授权通过</returns>
		public bool CheckAuthorize(string userID)
		{
			if (string.IsNullOrEmpty(OwnerUserID) && string.IsNullOrEmpty(AuthorisedUserIDList))
			{
				return true;
			}
			if (userID == OwnerUserID)
			{
				return true;
			}
			if (string.IsNullOrEmpty(userID))
			{
				return false;
			}
			if (!string.IsNullOrEmpty(AuthorisedUserIDList))
			{
				IDList iDList = new IDList(AuthorisedUserIDList);
				if (iDList.Contains(userID))
				{
					return true;
				}
			}
			return false;
		}

		public string DCWriteString()
		{
			return ValueTypeHelper.GetPropertiesAttributeString(this, detectDefaultValue: true);
		}

		public void DCReadString(string text)
		{
			ValueTypeHelper.SetPropertiesAttributeString(this, text);
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public DCContentLockInfo Clone()
		{
			return (DCContentLockInfo)MemberwiseClone();
		}
	}
}
