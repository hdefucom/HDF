using DCSoft.Common;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       当前应用系统操作员用户信息
	///       </summary>
	[ComDefaultInterface(typeof(ICurrentUserInfo))]
	[Guid("00012345-6789-ABCD-EF01-234567890021")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("00012345-6789-ABCD-EF01-234567890021", "49634361-A7BB-4BCB-9A43-75AEE9902914")]
	[DocumentComment]
	[ComVisible(true)]
	
	public class CurrentUserInfo : ICurrentUserInfo
	{
		internal const string CLASSID = "00012345-6789-ABCD-EF01-234567890021";

		internal const string CLASSID_Interface = "49634361-A7BB-4BCB-9A43-75AEE9902914";

		private string _ID = null;

		private string _Name = null;

		private int _PermissionLevel = 0;

		private string _Description = null;

		private Image _MarkImage = null;

		private string _ClientName = null;

		/// <summary>
		///       用户编号
		///       </summary>
		
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
		///       用户姓名
		///       </summary>
		
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
		///       授权等级
		///       </summary>
		
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
		///       用户相关的说明
		///       </summary>
		
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
		///       签名图片
		///       </summary>
		
		[ComVisible(false)]
		public Image MarkImage
		{
			get
			{
				return _MarkImage;
			}
			set
			{
				_MarkImage = value;
			}
		}

		/// <summary>
		///       客户端的名称,可以为电脑IP/计算机名等等。
		///       </summary>
		
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
		///       初始化对象
		///       </summary>
		
		public CurrentUserInfo()
		{
		}
	}
}
