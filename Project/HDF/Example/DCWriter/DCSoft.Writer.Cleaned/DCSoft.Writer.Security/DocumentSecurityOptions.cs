using DCSoft.Common;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Writer.Security
{
	/// <summary>
	///       授权相关的选项
	///       </summary>
	/// <remarks>编写 袁永福</remarks>
	[Serializable]
	[DCPublishAPI]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IDocumentSecurityOptions))]
	[Guid("2A18B30D-9A12-474D-967B-473CC1D24CFE")]
	[ComClass("2A18B30D-9A12-474D-967B-473CC1D24CFE", "E5F54326-317A-4B4F-B89C-22164D42E846")]
	[ClassInterface(ClassInterfaceType.None)]
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	[DocumentComment]
	public class DocumentSecurityOptions : ICloneable, IDocumentSecurityOptions
	{
		internal const string CLASSID = "2A18B30D-9A12-474D-967B-473CC1D24CFE";

		internal const string CLASSID_Interface = "E5F54326-317A-4B4F-B89C-22164D42E846";

		private string _CreatorTipFormatString = null;

		private string _DeleterTipFormatString = null;

		private bool _AutoEnablePermissionWhenUserLogin = true;

		private bool _EnablePermission = false;

		private bool _CanModifyDeleteSameLevelContent = true;

		private bool _RealDeleteOwnerContent = false;

		private bool _ShowPermissionTip = true;

		private bool _PowerfulSignDocument = true;

		private bool _EnableLogicDelete = false;

		private bool _ShowLogicDeletedContent = false;

		private bool _ShowPermissionMark = false;

		private TrackVisibleConfig _TrackVisibleLevel0 = null;

		private TrackVisibleConfig _TrackVisibleLevel1 = null;

		private TrackVisibleConfig _TrackVisibleLevel2 = null;

		private TrackVisibleConfig _TrackVisibleLevel3 = null;

		private static TrackVisibleConfig _DefaultTrackVisibleLevel0 = null;

		private static TrackVisibleConfig _DefaultTrackVisibleLevel1 = null;

		private static TrackVisibleConfig _DefaultTrackVisibleLevel2 = null;

		private static TrackVisibleConfig _DefaultTrackVisibleLevel3 = null;

		/// <summary>
		///       文档内容创建信息格式化字符串
		///       </summary>
		/// <remarks>
		///       例如“{DisplaySavedTime:yyyy-MM-dd HH:mm:ss}由{Name}创建”。
		///       这里可用的属性名是类型DCSoft.Writer.Security.UserHistoryInfo中所有公开的属性名。
		///       可以为Index,ID,Name,Name2,SavedTime,DisplaySavedTime,SaveTimeString,PermissionLevel,
		///       Description,ClientName,Tag。
		///       </remarks>
		[DefaultValue(null)]
		[DCDescription(typeof(DocumentSecurityOptions), "CreatorTipFormatString_Name_Time")]
		public string CreatorTipFormatString
		{
			get
			{
				return _CreatorTipFormatString;
			}
			set
			{
				_CreatorTipFormatString = value;
			}
		}

		/// <summary>
		///       文档内容逻辑删除信息格式化字符串
		///       </summary>
		/// <remarks>
		///       例如“{DisplaySavedTime:yyyy-MM-dd HH:mm:ss}由{Name}删除”
		///       这里可用的属性名是类型DCSoft.Writer.Security.UserHistoryInfo中所有公开的属性名。
		///       可以为Index,ID,Name,Name2,SavedTime,DisplaySavedTime,SaveTimeString,PermissionLevel,
		///       Description,ClientName,Tag。
		///       </remarks>
		[DCDescription(typeof(DocumentSecurityOptions), "DeleterTipFormatString_Name_Time")]
		[DefaultValue(null)]
		public string DeleterTipFormatString
		{
			get
			{
				return _DeleterTipFormatString;
			}
			set
			{
				_DeleterTipFormatString = value;
			}
		}

		/// <summary>
		///       在用户登录时自动启用授权控制。
		///       </summary>
		[DCDescription(typeof(DocumentSecurityOptions), "AutoEnablePermissionWhenUserLogin")]
		[DefaultValue(true)]
		public bool AutoEnablePermissionWhenUserLogin
		{
			get
			{
				return _AutoEnablePermissionWhenUserLogin;
			}
			set
			{
				_AutoEnablePermissionWhenUserLogin = value;
			}
		}

		/// <summary>
		///       启用文档内容安全和权限控制。若为false则不启用，文档内容可任意编辑。默认为false。
		///       </summary>
		[DCDescription(typeof(DocumentSecurityOptions), "EnablePermission")]
		[DefaultValue(false)]
		public bool EnablePermission
		{
			get
			{
				return _EnablePermission;
			}
			set
			{
				_EnablePermission = value;
			}
		}

		/// <summary>
		///       能否修改或删除同授权等级的内容
		///       </summary>
		[DefaultValue(true)]
		public bool CanModifyDeleteSameLevelContent
		{
			get
			{
				return _CanModifyDeleteSameLevelContent;
			}
			set
			{
				_CanModifyDeleteSameLevelContent = value;
			}
		}

		/// <summary>
		///       用户是物理删除自己曾经输入的内容。默认为true。
		///       </summary>
		/// <remarks>
		///       用户能物理删除自己曾经输入的内容。默认为false。例如用户“张三”
		///       曾经输入一段文字保存后在被其他高权限的用户修改掉了，然后“张三”
		///       再次登录来打开文档修改此前由本人输入的内容。若RealDeleteOwnerContent选项值为true，
		///       则此时进行的是物理删除，不会留下任何痕迹；若RealDeleteOwnerContent选项值为false，
		///       则此时进行的是逻辑删除，会留下修改痕迹。
		///       </remarks>
		[DefaultValue(false)]
		[DCDescription(typeof(DocumentSecurityOptions), "RealDeleteOwnerContent")]
		public bool RealDeleteOwnerContent
		{
			get
			{
				return _RealDeleteOwnerContent;
			}
			set
			{
				_RealDeleteOwnerContent = value;
			}
		}

		/// <summary>
		///       是否显示授权相关的提示信息，若为true，则在编辑器中当鼠标移动到
		///       文档内容时，会以提示文本的方式显示文档内容权限和痕迹信息。
		///       默认为true。
		///       </summary>
		[DCDescription(typeof(DocumentSecurityOptions), "ShowPermissionTip")]
		[DefaultValue(true)]
		public bool ShowPermissionTip
		{
			get
			{
				return _ShowPermissionTip;
			}
			set
			{
				_ShowPermissionTip = value;
			}
		}

		/// <summary>
		///       使用强权文档签名。若设置为false，则高权限的用户仍然可以修改低权限签名锁定的内容。
		///       默认为true。
		///       </summary>
		[DefaultValue(true)]
		[DCDescription(typeof(DocumentSecurityOptions), "PowerfulSignDocument")]
		public bool PowerfulSignDocument
		{
			get
			{
				return _PowerfulSignDocument;
			}
			set
			{
				_PowerfulSignDocument = value;
			}
		}

		/// <summary>
		///       执行逻辑删除。默认为false。
		///       </summary>
		[DCDescription(typeof(DocumentSecurityOptions), "EnableLogicDelete")]
		[DefaultValue(false)]
		public bool EnableLogicDelete
		{
			get
			{
				return _EnableLogicDelete;
			}
			set
			{
				_EnableLogicDelete = value;
			}
		}

		/// <summary>
		///       显示被逻辑删除的元素。默认为false。
		///       </summary>
		[DefaultValue(false)]
		[DCDescription(typeof(DocumentSecurityOptions), "ShowLogicDeletedContent")]
		public bool ShowLogicDeletedContent
		{
			get
			{
				return _ShowLogicDeletedContent;
			}
			set
			{
				_ShowLogicDeletedContent = value;
			}
		}

		/// <summary>
		///       是否显示授权标记。若为true，则用蓝色下划线标记出高权限用户输入
		///       的内容，使用删除线标记出被逻辑删除的内容。
		///       默认为false。
		///       </summary>
		[DCDescription(typeof(DocumentSecurityOptions), "ShowPermissionMark")]
		[DefaultValue(false)]
		public bool ShowPermissionMark
		{
			get
			{
				return _ShowPermissionMark;
			}
			set
			{
				_ShowPermissionMark = value;
			}
		}

		/// <summary>
		///       等级0的用户痕迹可视化选项
		///       </summary>
		[Browsable(true)]
		[DCDescription(typeof(DocumentSecurityOptions), "TrackVisibleLevel0")]
		public TrackVisibleConfig TrackVisibleLevel0
		{
			get
			{
				return _TrackVisibleLevel0;
			}
			set
			{
				_TrackVisibleLevel0 = value;
			}
		}

		/// <summary>
		///       等级1的用户痕迹可视化选项
		///       </summary>
		[DCDescription(typeof(DocumentSecurityOptions), "TrackVisibleLevel1")]
		[Browsable(true)]
		public TrackVisibleConfig TrackVisibleLevel1
		{
			get
			{
				return _TrackVisibleLevel1;
			}
			set
			{
				_TrackVisibleLevel1 = value;
			}
		}

		/// <summary>
		///       等级2的用户痕迹可视化选项
		///       </summary>
		[DCDescription(typeof(DocumentSecurityOptions), "TrackVisibleLevel2")]
		[Browsable(true)]
		public TrackVisibleConfig TrackVisibleLevel2
		{
			get
			{
				return _TrackVisibleLevel2;
			}
			set
			{
				_TrackVisibleLevel2 = value;
			}
		}

		/// <summary>
		///       等级大于等于3的用户痕迹可视化选项
		///       </summary>
		[Browsable(true)]
		[DCDescription(typeof(DocumentSecurityOptions), "TrackVisibleLevel3")]
		public TrackVisibleConfig TrackVisibleLevel3
		{
			get
			{
				return _TrackVisibleLevel3;
			}
			set
			{
				_TrackVisibleLevel3 = value;
			}
		}

		/// <summary>
		///       系统默认的等级0的用户痕迹可视化选项
		///       </summary>
		/// <remarks>
		///       无下划线无背景色，删除线为一条淡红色线。
		///       </remarks>
		public static TrackVisibleConfig DefaultTrackVisibleLevel0
		{
			get
			{
				if (_DefaultTrackVisibleLevel0 == null)
				{
					_DefaultTrackVisibleLevel0 = new TrackVisibleConfig();
					_DefaultTrackVisibleLevel0.DeleteLineColor = Color.Coral;
					_DefaultTrackVisibleLevel0.DeleteLineNum = 1;
					_DefaultTrackVisibleLevel0.UnderLineColor = Color.LightBlue;
				}
				return _DefaultTrackVisibleLevel0;
			}
			set
			{
				_DefaultTrackVisibleLevel0 = value;
			}
		}

		/// <summary>
		///       系统默认的等级1的用户痕迹可视化选项
		///       </summary>
		/// <remarks>
		///       默认为无背景色。下划线为1条蓝色线，删除线为1条红色线。
		///       </remarks>
		public static TrackVisibleConfig DefaultTrackVisibleLevel1
		{
			get
			{
				if (_DefaultTrackVisibleLevel1 == null)
				{
					_DefaultTrackVisibleLevel1 = new TrackVisibleConfig();
					_DefaultTrackVisibleLevel1.UnderLineColor = Color.Blue;
					_DefaultTrackVisibleLevel1.UnderLineColorNum = 1;
					_DefaultTrackVisibleLevel1.DeleteLineColor = Color.Red;
					_DefaultTrackVisibleLevel1.DeleteLineNum = 1;
				}
				return _DefaultTrackVisibleLevel1;
			}
			set
			{
				_DefaultTrackVisibleLevel1 = value;
			}
		}

		/// <summary>
		///       系统默认的等级2的用户痕迹可视化选项
		///       </summary>
		/// <remarks>
		///       默认为背景色为淡黄色。下划线为双蓝色线。删除线为双红色线。
		///       </remarks>
		public static TrackVisibleConfig DefaultTrackVisibleLevel2
		{
			get
			{
				if (_DefaultTrackVisibleLevel2 == null)
				{
					_DefaultTrackVisibleLevel2 = new TrackVisibleConfig();
					_DefaultTrackVisibleLevel2.UnderLineColor = Color.Blue;
					_DefaultTrackVisibleLevel2.UnderLineColorNum = 2;
					_DefaultTrackVisibleLevel2.DeleteLineColor = Color.Red;
					_DefaultTrackVisibleLevel2.DeleteLineNum = 2;
					_DefaultTrackVisibleLevel2.BackgroundColor = Color.LightYellow;
				}
				return _DefaultTrackVisibleLevel2;
			}
			set
			{
				_DefaultTrackVisibleLevel2 = value;
			}
		}

		/// <summary>
		///       系统默认的等级大于等于3的用户痕迹可视化选项
		///       </summary>
		/// <remarks>
		///       默认为背景色为黄色。下划线为2条蓝色。删除线为2条红色。
		///       </remarks>
		public static TrackVisibleConfig DefaultTrackVisibleLevel3
		{
			get
			{
				if (_DefaultTrackVisibleLevel3 == null)
				{
					_DefaultTrackVisibleLevel3 = new TrackVisibleConfig();
					_DefaultTrackVisibleLevel3.UnderLineColor = Color.Blue;
					_DefaultTrackVisibleLevel3.UnderLineColorNum = 2;
					_DefaultTrackVisibleLevel3.DeleteLineColor = Color.Red;
					_DefaultTrackVisibleLevel3.DeleteLineNum = 2;
					_DefaultTrackVisibleLevel3.BackgroundColor = Color.Yellow;
				}
				return _DefaultTrackVisibleLevel3;
			}
			set
			{
				_DefaultTrackVisibleLevel3 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public DocumentSecurityOptions()
		{
			_TrackVisibleLevel0 = DefaultTrackVisibleLevel0.Clone();
			_TrackVisibleLevel1 = DefaultTrackVisibleLevel1.Clone();
			_TrackVisibleLevel2 = DefaultTrackVisibleLevel2.Clone();
			_TrackVisibleLevel3 = DefaultTrackVisibleLevel2.Clone();
		}

		/// <summary>
		///       获得指定等级使用的可视化设置
		///       </summary>
		/// <param name="level">等级</param>
		/// <returns>获得的可视化设置信息对象</returns>
		public TrackVisibleConfig GetTrackVisibleConfig(int level)
		{
			if (!XTextDocument.smethod_13(GEnum6.const_131))
			{
				return TrackVisibleLevel0;
			}
			bool flag = XTextDocument.smethod_13(GEnum6.const_132);
			if (level <= 0)
			{
				if (flag)
				{
					return TrackVisibleLevel0;
				}
				return DefaultTrackVisibleLevel0;
			}
			if (level == 1)
			{
				if (flag)
				{
					return TrackVisibleLevel1;
				}
				return DefaultTrackVisibleLevel1;
			}
			if (level == 2)
			{
				if (flag)
				{
					return TrackVisibleLevel2;
				}
				return DefaultTrackVisibleLevel2;
			}
			if (level >= 3)
			{
				if (flag)
				{
					return TrackVisibleLevel3;
				}
				return DefaultTrackVisibleLevel3;
			}
			return null;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public DocumentSecurityOptions Clone()
		{
			return (DocumentSecurityOptions)((ICloneable)this).Clone();
		}

		object ICloneable.Clone()
		{
			DocumentSecurityOptions documentSecurityOptions = (DocumentSecurityOptions)MemberwiseClone();
			if (_TrackVisibleLevel0 != null)
			{
				documentSecurityOptions._TrackVisibleLevel0 = _TrackVisibleLevel0.Clone();
			}
			if (_TrackVisibleLevel1 != null)
			{
				documentSecurityOptions._TrackVisibleLevel1 = _TrackVisibleLevel1.Clone();
			}
			if (_TrackVisibleLevel2 != null)
			{
				documentSecurityOptions._TrackVisibleLevel2 = _TrackVisibleLevel2.Clone();
			}
			if (_TrackVisibleLevel3 != null)
			{
				documentSecurityOptions._TrackVisibleLevel3 = _TrackVisibleLevel3.Clone();
			}
			return documentSecurityOptions;
		}

		/// <summary>
		///       返回表示对象的字符串
		///       </summary>
		/// <returns>字符串</returns>
		public override string ToString()
		{
			int num = 1;
			StringBuilder stringBuilder = new StringBuilder();
			if (EnablePermission)
			{
				stringBuilder.Append("Enable ");
			}
			if (EnableLogicDelete)
			{
				stringBuilder.Append("LogicDelete ");
			}
			if (ShowLogicDeletedContent)
			{
				stringBuilder.Append("ShowLogicDeleted ");
			}
			if (ShowPermissionMark)
			{
				stringBuilder.Append("ShowMark ");
			}
			if (ShowPermissionTip)
			{
				stringBuilder.Append("ShowTip ");
			}
			if (RealDeleteOwnerContent)
			{
				stringBuilder.Append("RealDeleteOwnerContent ");
			}
			return stringBuilder.ToString();
		}
	}
}
