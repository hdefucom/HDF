using DCSoft.Common;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Security;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer
{
	/// <summary>
	///       用户痕迹信息
	///       </summary>
	/// <remarks>包含了文档中的一次用户修改操作的痕迹信息</remarks>
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IUserTrackInfo))]
	
	[ComClass("34D18984-C9E4-4E16-AABA-1089841AFDFF", "7D641D73-509A-4ABE-BCEA-55876B322AC9")]
	
	[Guid("34D18984-C9E4-4E16-AABA-1089841AFDFF")]
	public class UserTrackInfo : IUserTrackInfo
	{
		internal const string CLASSID = "34D18984-C9E4-4E16-AABA-1089841AFDFF";

		internal const string CLASSID_Interface = "7D641D73-509A-4ABE-BCEA-55876B322AC9";

		private string _UserID = null;

		private string _UserName = null;

		private DateTime _SaveTime = UserHistoryInfo.NullDateTime;

		private UserTrackType _InfoType = UserTrackType.Create;

		private int _PermissionLevel = 0;

		private XTextElementList _Elements = new XTextElementList();

		private string _CommentText = null;

		/// <summary>
		///       缓存一下元素文本，提高性能
		///       </summary>
		private string _Text = null;

		internal int _CreateIndex = -1;

		internal int _DeletorIndex = -1;

		internal int _CommentIndex = -1;

		/// <summary>
		///       在视图中的高度
		///       </summary>
		internal int _ViewHeight = -1;

		/// <summary>
		///       用户系统名
		///       </summary>
		[XmlAttribute]
		[DefaultValue(null)]
		
		public string UserID
		{
			get
			{
				return _UserID;
			}
			set
			{
				_UserID = value;
			}
		}

		/// <summary>
		///       用户姓名
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
		
		public string UserName
		{
			get
			{
				return _UserName;
			}
			set
			{
				_UserName = value;
			}
		}

		/// <summary>
		///       用户保存文档的事件
		///       </summary>
		[XmlAttribute]
		
		public DateTime SaveTime
		{
			get
			{
				return _SaveTime;
			}
			set
			{
				_SaveTime = value;
			}
		}

		/// <summary>
		///       痕迹信息类型
		///       </summary>
		[XmlAttribute]
		
		public UserTrackType InfoType
		{
			get
			{
				return _InfoType;
			}
			set
			{
				_InfoType = value;
			}
		}

		/// <summary>
		///       用户授权等级
		///       </summary>
		[XmlAttribute]
		
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
		///       用户操作的文档元素类型
		///       </summary>
		[XmlIgnore]
		
		public XTextElementList Elements
		{
			get
			{
				return _Elements;
			}
			set
			{
				_Elements = value;
			}
		}

		/// <summary>
		///       相关的批注文本
		///       </summary>
		
		[DefaultValue(null)]
		[XmlElement]
		public string CommentText
		{
			get
			{
				return _CommentText;
			}
			set
			{
				_CommentText = value;
			}
		}

		/// <summary>
		///       用户
		///       </summary>
		[DefaultValue(null)]
		
		[XmlElement]
		public string Text
		{
			get
			{
				if (InfoType == UserTrackType.Comment)
				{
					return CommentText;
				}
				if (_Text == null)
				{
					_Text = _Elements.GetInnerText();
				}
				return _Text;
			}
			set
			{
			}
		}

		/// <summary>
		///       标准标题文字
		///       </summary>
		[XmlElement]
		[DefaultValue(null)]
		
		public string StdTitle
		{
			get
			{
				int num = 7;
				string str = "";
				if (SaveTime != UserHistoryInfo.NullDateTime)
				{
					str = SaveTime.ToString("yyyy-MM-dd HH:mm:ss");
				}
				str = str + WriterStringsCore.By + UserName;
				if (InfoType == UserTrackType.Create)
				{
					return str + WriterStringsCore.Input;
				}
				if (InfoType == UserTrackType.Comment)
				{
					return str + WriterStringsCore.DocumentComment;
				}
				return str + WriterStringsCore.Delete;
			}
			set
			{
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public UserTrackInfo()
		{
		}
	}
}
