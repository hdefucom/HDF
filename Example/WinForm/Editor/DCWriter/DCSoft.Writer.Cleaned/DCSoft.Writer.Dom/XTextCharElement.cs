using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       字符对象
	///       </summary>
	/// <remarks>编写 袁永福</remarks>
	[Serializable]
	
	[ComClass("4D17869C-1B83-4655-AE1C-1154F7361203", "A453153D-9B11-42B7-B978-175D9E5A30D1")]
	[ComDefaultInterface(typeof(IXTextCharElement))]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("4D17869C-1B83-4655-AE1C-1154F7361203")]
	public sealed class XTextCharElement : XTextElement, IXTextCharElement
	{
		internal const string string_3 = "4D17869C-1B83-4655-AE1C-1154F7361203";

		internal const string string_4 = "A453153D-9B11-42B7-B978-175D9E5A30D1";

		internal float float_5 = 0f;

		internal float float_6 = 0f;

		[NonSerialized]
		private float float_7 = 1f;

		private char char_0 = '\0';

		[NonSerialized]
		private int int_6 = 0;

		[NonSerialized]
		private bool bool_5 = false;

		[NonSerialized]
		internal char char_1 = '\0';

		internal float float_8 = 0f;

		
		public override string DomDisplayName => "Char:" + Text;

		/// <summary>
		///       字符原始宽度
		///       </summary>
		
		public float NativeWidth => float_5;

		/// <summary>
		///       字符原始高度
		///       </summary>
		
		public float NativeHeight => float_6;

		/// <summary>
		///       字体缩放比率
		///       </summary>
		[XmlIgnore]
		[ReadOnly(true)]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float FontSizeZoomRate
		{
			get
			{
				return float_7;
			}
			set
			{
				if (float.IsNaN(value))
				{
					value = 1f;
				}
				float_7 = value;
			}
		}

		/// <summary>
		///       字符数据
		///       </summary>
		
		public char CharValue
		{
			get
			{
				return char_0;
			}
			set
			{
				char_0 = value;
				char_1 = '\0';
				bool_5 = false;
			}
		}

		/// <summary>
		///       字符整数数值
		///       </summary>
		
		public int CharInt32Value => char_0;

		/// <summary>
		///       表示对象的文本
		///       </summary>
		[Browsable(false)]
		
		[XmlIgnore]
		public override string Text
		{
			get
			{
				return char_0.ToString();
			}
			set
			{
				if (value != null && value.Length > 0)
				{
					char_0 = value[0];
				}
			}
		}

		/// <summary>
		///       使用的连接字符个数
		///       </summary>
		internal int LinkCharNum
		{
			get
			{
				return int_6;
			}
			set
			{
				if (int_6 != value)
				{
					int_6 = value;
				}
			}
		}

		/// <summary>
		///       启用连接符号
		///       </summary>
		internal bool ConnectFlag
		{
			get
			{
				return bool_5;
			}
			set
			{
				if (bool_5 != value)
				{
					bool_5 = value;
				}
			}
		}

		/// <summary>
		///       实际绘制字母时使用的字符值
		///       </summary>
		
		[Browsable(false)]
		public char RuntimeCharValue
		{
			get
			{
				if (char_1 > '\0')
				{
					return char_1;
				}
				return char_0;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public XTextCharElement()
		{
		}

		
		public override void Draw(DocumentPaintEventArgs args)
		{
			OwnerDocument.method_85(this);
			args.Render.vmethod_3(this, args);
			args.Render.vmethod_5(this, args);
		}

		
		public override void RefreshSize(DocumentPaintEventArgs args)
		{
			args.Render.vmethod_4(this, args.Graphics);
		}

		/// <summary>
		///       处理文档用户界面事件
		///       </summary>
		/// <param name="args">事件参数</param>
		
		public override void HandleDocumentEvent(DocumentEventArgs args)
		{
			int num = 2;
			if (Parent is XTextFieldElementBase)
			{
				XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)Parent;
				if (xTextFieldElementBase.IsBackgroundTextElement(this))
				{
					return;
				}
			}
			if (args.Style == DocumentEventStyles.MouseDown)
			{
				string link = RuntimeStyle.Link;
				if (link != null && link.Length > 0)
				{
					if (link.StartsWith("#"))
					{
						link.Substring(1);
					}
					else
					{
						OwnerDocument.Content.MoveToElement(this);
					}
					OwnerDocument.method_50(this, link);
					args.Handled = true;
				}
			}
			else if (args.Style == DocumentEventStyles.MouseMove)
			{
				string link = RuntimeStyle.Link;
				if (link != null && link.Length > 0)
				{
					args.Cursor = Cursors.Hand;
					args.Tooltip = link;
				}
			}
			else
			{
				base.HandleDocumentEvent(args);
			}
		}

		internal void method_13()
		{
			if (char_0 == '\t')
			{
				Width = WriterUtils.smethod_53(Left - OwnerDocument.Left, OwnerDocument.DefaultStyle.TabWidth);
			}
		}

		/// <summary>
		///       获得纯文本内容
		///       </summary>
		/// <returns>纯文本内容</returns>
		
		public override string ToPlaintString()
		{
			return char_0.ToString();
		}

		/// <summary>
		///       获得表示对象的文本
		///       </summary>
		/// <returns>文本</returns>
		
		public override string ToString()
		{
			return char_0.ToString();
		}
	}
}
