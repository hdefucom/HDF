using DCSoft.Common;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Security
{
	/// <summary>
	///       用户历史信息
	///       </summary>
	/// <remarks>编写 袁永福</remarks>
	[Serializable]
	[ComClass("488F34CE-B17C-4992-895A-859BE0982AD7", "FFA1C8D8-176B-40CE-9334-FD23534A9F12")]
	[DCPublishAPI]
	[ComVisible(true)]
	[DocumentComment]
	[Guid("488F34CE-B17C-4992-895A-859BE0982AD7")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IUserHistoryInfo))]
	public class UserHistoryInfo : ICloneable, IUserHistoryInfo
	{
		internal const string CLASSID = "488F34CE-B17C-4992-895A-859BE0982AD7";

		internal const string CLASSID_Interface = "FFA1C8D8-176B-40CE-9334-FD23534A9F12";

		private int _Index = 0;

		private string _ID = null;

		private string _Name = null;

		private string _Name2 = null;

		private DateTime _SavedTime = NullDateTime;

		private DateTime _DisplaySavedTime = NullDateTime;

		private int _PermissionLevel = 0;

		private string _Description = null;

		private string _ClientName = null;

		private string _Tag = null;

		/// <summary>
		///       表示空的日期数值
		///       </summary>
		public static DateTime NullDateTime = GClass117.dateTime_0;

		/// <summary>
		///       对象编号
		///       </summary>
		[DefaultValue(0)]
		[XmlAttribute]
		[DCPublishAPI]
		public int Index
		{
			get
			{
				return _Index;
			}
			set
			{
				_Index = value;
			}
		}

		/// <summary>
		///       用户编号
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(null)]
		public string ID
		{
			get
			{
				return _ID;
			}
			set
			{
				_ID = value;
			}
		}

		/// <summary>
		///       用户名
		///       </summary>
		[DefaultValue(null)]
		[DCPublishAPI]
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name = value;
			}
		}

		/// <summary>
		///       名称2
		///       </summary>
		[DefaultValue(null)]
		[DCPublishAPI]
		public string Name2
		{
			get
			{
				return _Name2;
			}
			set
			{
				_Name2 = value;
			}
		}

		/// <summary>
		///       保存文档的时间
		///       </summary>
		[DCPublishAPI]
		public DateTime SavedTime
		{
			get
			{
				return _SavedTime;
			}
			set
			{
				_SavedTime = value;
			}
		}

		/// <summary>
		///       用于显示的保存文档的时间
		///       </summary>
		[XmlIgnore]
		[DCPublishAPI]
		public DateTime DisplaySavedTime
		{
			get
			{
				return _DisplaySavedTime;
			}
			set
			{
				_DisplaySavedTime = value;
			}
		}

		/// <summary>
		///       判断保存文档时间是否是空的
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		public bool IsEmptySaveTime => _SavedTime == NullDateTime;

		/// <summary>
		///       表示保存时间的字符串
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		public string SaveTimeString
		{
			get
			{
				int num = 13;
				if (_SavedTime == NullDateTime)
				{
					return "";
				}
				return _SavedTime.ToString("yyyy-MM-dd HH:mm:ss");
			}
		}

		/// <summary>
		///       用户权限许可等级
		///       </summary>
		[DefaultValue(0)]
		[DCPublishAPI]
		public int PermissionLevel
		{
			get
			{
				return _PermissionLevel;
			}
			set
			{
				_PermissionLevel = value;
			}
		}

		/// <summary>
		///       附加的说明文字
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(null)]
		public string Description
		{
			get
			{
				return _Description;
			}
			set
			{
				_Description = value;
			}
		}

		/// <summary>
		///       客户端的名称,可以为电脑IP/计算机名等等。
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(null)]
		public string ClientName
		{
			get
			{
				return _ClientName;
			}
			set
			{
				_ClientName = value;
			}
		}

		/// <summary>
		///       扩展数据
		///       </summary>
		[DefaultValue(null)]
		[DCPublishAPI]
		public string Tag
		{
			get
			{
				return _Tag;
			}
			set
			{
				_Tag = value;
			}
		}

		/// <summary>
		///       创建一个对象实例
		///       </summary>
		/// <returns>
		/// </returns>
		public static UserHistoryInfo CreateInstance()
		{
			return new UserHistoryInfo();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		[DCPublishAPI]
		public UserHistoryInfo()
		{
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="info">
		/// </param>
		[DCPublishAPI]
		public UserHistoryInfo(UserLoginInfo info)
		{
			if (info != null)
			{
				ID = info.ID;
				Name = info.Name;
				Name2 = info.Name2;
				PermissionLevel = info.PermissionLevel;
				SavedTime = NullDateTime;
				Description = info.Description;
				Tag = info.Tag;
				ClientName = info.ClientName;
			}
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		[DCPublishAPI]
		public UserHistoryInfo Clone()
		{
			return (UserHistoryInfo)((ICloneable)this).Clone();
		}

		object ICloneable.Clone()
		{
			return MemberwiseClone();
		}

		/// <summary>
		///       返回表示对象数据的字符串
		///       </summary>
		/// <returns>字符串</returns>
		public override string ToString()
		{
			return Index + ":" + ID + " " + Name + " " + SaveTimeString;
		}
	}
}
