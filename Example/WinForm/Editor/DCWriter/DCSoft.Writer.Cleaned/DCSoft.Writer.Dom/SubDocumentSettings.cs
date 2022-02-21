using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       当文档作为子文档时的一些设置
	///       </summary>
	[Serializable]
	[ComVisible(true)]
	[Guid("3154CB70-68C1-4203-8B4B-92CBEAE92443")]
	[ComClass("3154CB70-68C1-4203-8B4B-92CBEAE92443", "9F6C58B6-5389-4561-A5D9-02DBE019FC07")]
	
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(ISubDocumentSettings))]
	[DocumentComment]
	public class SubDocumentSettings : ISubDocumentSettings
	{
		internal const string CLASSID = "3154CB70-68C1-4203-8B4B-92CBEAE92443";

		internal const string CLASSID_Interface = "9F6C58B6-5389-4561-A5D9-02DBE019FC07";

		private float _SubDocumentSpacing = 0f;

		private bool _AllowSave = true;

		private bool _Readonly = false;

		private bool _Locked = false;

		private bool _EnablePermission = false;

		private bool _NewPage = false;

		private Color _BorderColor = Color.Transparent;

		private Color _BackColor = Color.Transparent;

		/// <summary>
		///       子文档间距
		///       </summary>
		[DefaultValue(0f)]
		
		public float SubDocumentSpacing
		{
			get
			{
				return _SubDocumentSpacing;
			}
			set
			{
				_SubDocumentSpacing = value;
			}
		}

		/// <summary>
		///       允许保存
		///       </summary>
		
		[DefaultValue(true)]
		public bool AllowSave
		{
			get
			{
				return _AllowSave;
			}
			set
			{
				_AllowSave = value;
			}
		}

		/// <summary>
		///       文档只读
		///       </summary>
		
		[DefaultValue(false)]
		public bool Readonly
		{
			get
			{
				return _Readonly;
			}
			set
			{
				_Readonly = value;
			}
		}

		/// <summary>
		///       文档被锁定.
		///       </summary>
		[DefaultValue(false)]
		
		public bool Locked
		{
			get
			{
				return _Locked;
			}
			set
			{
				_Locked = value;
			}
		}

		/// <summary>
		///       是否启用权限控制
		///       </summary>
		
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
		///       是否强制分页
		///       </summary>
		[DefaultValue(false)]
		
		public bool NewPage
		{
			get
			{
				return _NewPage;
			}
			set
			{
				_NewPage = value;
			}
		}

		/// <summary>
		///       边框线颜色
		///       </summary>
		[XmlIgnore]
		
		[DefaultValue(typeof(Color), "Transparent")]
		public Color BorderColor
		{
			get
			{
				return _BorderColor;
			}
			set
			{
				_BorderColor = value;
			}
		}

		/// <summary>
		///       边框颜色值
		///       </summary>
		[XmlElement]
		[Browsable(false)]
		[DefaultValue(null)]
		public string BorderColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(BorderColor, Color.Transparent);
			}
			set
			{
				BorderColor = XMLSerializeHelper.StringToColor(value, Color.Transparent);
			}
		}

		/// <summary>
		///       边框线颜色
		///       </summary>
		[DefaultValue(typeof(Color), "Transparent")]
		[XmlIgnore]
		
		public Color BackColor
		{
			get
			{
				return _BackColor;
			}
			set
			{
				_BackColor = value;
			}
		}

		/// <summary>
		///       背景颜色值
		///       </summary>
		[XmlElement]
		[Browsable(false)]
		[DefaultValue(null)]
		public string BackColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(BackColor, Color.Transparent);
			}
			set
			{
				BackColor = XMLSerializeHelper.StringToColor(value, Color.Transparent);
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public SubDocumentSettings()
		{
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public SubDocumentSettings Clone()
		{
			return (SubDocumentSettings)MemberwiseClone();
		}
	}
}
