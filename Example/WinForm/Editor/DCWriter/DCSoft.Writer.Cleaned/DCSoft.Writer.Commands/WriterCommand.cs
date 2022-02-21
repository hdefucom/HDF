using DCSoft.Common;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       编辑器动作基础类型
	///       </summary>
	[ComVisible(false)]
	[DocumentComment]
	public abstract class WriterCommand
	{
		private GEnum6 _FunctionID = GEnum6.const_0;

		/// <summary>
		///       动作名称
		///       </summary>
		protected string strName = null;

		private bool _EnableHotKey = true;

		private bool _Enable = true;

		private int _Priority = 10;

		private Keys _ShortcutKey = Keys.None;

		private string _Description = null;

		private GClass133 _Descriptor = null;

		private WriterCommandModule _Module = null;

		/// <summary>
		///       动作对象在工具条上的图标图片对象
		///       </summary>
		protected Image myToolbarImage = null;

		/// <summary>
		///       授权相关的功能编号
		///       </summary>
		
		[ComVisible(false)]
		[Browsable(false)]
		[XmlIgnore]
		public GEnum6 FunctionID
		{
			get
			{
				return _FunctionID;
			}
			internal set
			{
				_FunctionID = value;
			}
		}

		/// <summary>
		///       动作名称
		///       </summary>
		public string Name
		{
			get
			{
				return strName;
			}
			set
			{
				strName = value;
			}
		}

		/// <summary>
		///       是否启用快键键
		///       </summary>
		public bool EnableHotKey
		{
			get
			{
				return _EnableHotKey;
			}
			set
			{
				_EnableHotKey = value;
			}
		}

		/// <summary>
		///       动作对象是否可用
		///       </summary>
		public bool Enable
		{
			get
			{
				return _Enable;
			}
			set
			{
				_Enable = value;
			}
		}

		/// <summary>
		///       优先级，值越低则越优先
		///       </summary>
		public int Priority
		{
			get
			{
				return _Priority;
			}
			set
			{
				_Priority = value;
			}
		}

		/// <summary>
		///       快捷键
		///       </summary>
		public Keys ShortcutKey
		{
			get
			{
				return _ShortcutKey;
			}
			set
			{
				_ShortcutKey = value;
			}
		}

		/// <summary>
		///       动作说明
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
		///       动作命令描述信息对象
		///       </summary>
		public GClass133 Descriptor
		{
			get
			{
				return _Descriptor;
			}
			set
			{
				_Descriptor = value;
			}
		}

		/// <summary>
		///       命令所属的模块对象
		///       </summary>
		public WriterCommandModule Module
		{
			get
			{
				return _Module;
			}
			set
			{
				_Module = value;
			}
		}

		/// <summary>
		///       动作对象在工具条上的图标图片对象
		///       </summary>
		public virtual Image ToolbarImage
		{
			get
			{
				int num = 8;
				if (myToolbarImage == null)
				{
					ToolboxBitmapAttribute toolboxBitmapAttribute = Attribute.GetCustomAttribute(GetType(), typeof(ToolboxBitmapAttribute), inherit: false) as ToolboxBitmapAttribute;
					if (toolboxBitmapAttribute != null)
					{
						Image image = toolboxBitmapAttribute.GetImage(GetType());
						if (image == null)
						{
							throw new Exception("Miss image resource " + GetType().FullName);
						}
						if (image is Bitmap)
						{
							Bitmap bitmap = (Bitmap)image;
							bitmap.MakeTransparent(bitmap.GetPixel(0, bitmap.Height - 1));
						}
						myToolbarImage = image;
					}
				}
				return myToolbarImage;
			}
			set
			{
				myToolbarImage = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public WriterCommand()
		{
		}

		/// <summary>
		///       执行命令
		///       </summary>
		/// <param name="args">参数</param>
		public virtual void Invoke(WriterCommandEventArgs args)
		{
		}

		/// <summary>
		///       返回表示对象的字符串
		///       </summary>
		/// <returns>字符串</returns>
		public override string ToString()
		{
			return "Command:" + Name;
		}
	}
}
