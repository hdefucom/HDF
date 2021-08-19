using DCSoft.Common;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Security
{
	/// <summary>
	///       用户登录信息
	///       </summary>
	/// <remarks>编写 袁永福</remarks>
	[ComDefaultInterface(typeof(IUserLoginInfo))]
	[ComClass("7A260714-20C7-4AED-82C0-B4D0A46DE166", "EC9EA1DA-11AF-4919-BB1A-C00D60CDE8C3")]
	[DocumentComment]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("7A260714-20C7-4AED-82C0-B4D0A46DE166")]
	[DCPublishAPI]
	public class UserLoginInfo : IUserLoginInfo
	{
		internal const string CLASSID = "7A260714-20C7-4AED-82C0-B4D0A46DE166";

		internal const string CLASSID_Interface = "EC9EA1DA-11AF-4919-BB1A-C00D60CDE8C3";

		private string _ID = null;

		private string _Name = null;

		private string _Name2 = null;

		private string _ClientName = null;

		private int _PermissionLevel = 0;

		private string _Description = null;

		private string _Tag = null;

		/// <summary>
		///       用户编号
		///       </summary>
		[DefaultValue(null)]
		[DCPublishAPI]
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
		[DCPublishAPI]
		[DefaultValue(null)]
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
		///       用户名2
		///       </summary>
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
		///       客户端名称
		///       </summary>
		[DCPublishAPI]
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
		///       用户权限许可等级,数值越高，等级就越高，高等级能压制低等级，低等级无法修改高等级。
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
		///       登录时附加的说明文字
		///       </summary>
		[DefaultValue(null)]
		[DCPublishAPI]
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
		///       初始化对象
		///       </summary>
		[DCPublishAPI]
		public UserLoginInfo()
		{
		}
	}
}
