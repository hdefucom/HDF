using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Writer.Controls;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       音频信息文档元素对象
	///       </summary>
	[Serializable]
	[DocumentComment]
	[ComClass("135815B3-44F3-44CA-9395-7EBF4385E4CA", "D492C04E-0037-481C-B291-F772FA1DFB97")]
	[DebuggerDisplay("Media:FileName={FileName}")]
	[ToolboxBitmap(typeof(XTextMediaElement))]
	[XmlType("XMedia")]
	[Guid("135815B3-44F3-44CA-9395-7EBF4385E4CA")]
	[ClassInterface(ClassInterfaceType.None)]
	[DCPublishAPI]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IXTextMediaElement))]
	public sealed class XTextMediaElement : XTextControlHostElement, IXTextMediaElement
	{
		internal const string string_16 = "135815B3-44F3-44CA-9395-7EBF4385E4CA";

		internal const string string_17 = "D492C04E-0037-481C-B291-F772FA1DFB97";

		private bool bool_12 = true;

		private float float_8 = 500f;

		private float float_9 = 300f;

		private VerticalAlignStyle verticalAlignStyle_0 = VerticalAlignStyle.Bottom;

		private static readonly object object_4 = new object();

		private bool bool_13 = false;

		private bool bool_14 = true;

		private string string_18 = null;

		private string string_19 = null;

		private string string_20 = null;

		private WindowsMediaPlayerUIMode windowsMediaPlayerUIMode_0 = WindowsMediaPlayerUIMode.mini;

		private string string_21 = null;

		/// <summary>
		///        获取或设置元素宽度
		///       </summary>
		public bool CsMediaPlayer
		{
			get
			{
				return bool_12;
			}
			set
			{
				bool_12 = value;
			}
		}

		/// <summary>
		///        获取或设置元素宽度
		///       </summary>
		public override float Width
		{
			get
			{
				return float_8;
			}
			set
			{
				float_8 = value;
				if (base.HostedInstance != null)
				{
					((MediaPlayerControler)base.HostedInstance).Width = (int)value;
				}
			}
		}

		/// <summary>
		///       获取或设置元素高度
		///       </summary>
		public override float Height
		{
			get
			{
				return float_9;
			}
			set
			{
				float_9 = value;
				if (base.HostedInstance != null)
				{
					((MediaPlayerControler)base.HostedInstance).Height = (int)value;
				}
			}
		}

		public override string DomDisplayName => "Media:" + FileName;

		/// <summary>
		///       属性固定
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public override HostedControlType ControlType
		{
			get
			{
				return HostedControlType.Control;
			}
			set
			{
			}
		}

		/// <summary>
		///       属性固定
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public override string TypeFullName
		{
			get
			{
				return typeof(MediaPlayerControler).FullName;
			}
			set
			{
			}
		}

		/// <summary>
		///       垂直对齐方式
		///       </summary>
		[DefaultValue(VerticalAlignStyle.Bottom)]
		[ComVisible(true)]
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		[HtmlAttribute]
		public VerticalAlignStyle VAlign
		{
			get
			{
				return verticalAlignStyle_0;
			}
			set
			{
				verticalAlignStyle_0 = value;
			}
		}

		/// <summary>
		///       运行时使用的垂直对齐方式
		///       </summary>
		public override VerticalAlignStyle RuntimeVAlign => VAlign;

		/// <summary>
		///       强制为延迟加载控件
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public override bool DelayLoadControl
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		/// <summary>
		///       运行时控件类型
		///       </summary>
		[Browsable(false)]
		public override HostedControlType RuntimeControlType => HostedControlType.Control;

		/// <summary>
		///       循环播放内容
		///       </summary>
		[XmlElement]
		[HtmlAttribute]
		[ComVisible(true)]
		[DefaultValue(false)]
		public bool LoopPlay
		{
			get
			{
				return bool_13;
			}
			set
			{
				if (bool_13 != value)
				{
					bool_13 = value;
					method_27();
				}
			}
		}

		/// <summary>
		///       启用标准的媒体快捷菜单
		///       </summary>
		[ComVisible(true)]
		[DefaultValue(true)]
		[HtmlAttribute]
		[XmlElement]
		public bool EnableMediaContextMenu
		{
			get
			{
				return bool_14;
			}
			set
			{
				if (bool_14 != value)
				{
					bool_14 = value;
					method_27();
				}
			}
		}

		/// <summary>
		///       文本值
		///       </summary>
		[Browsable(true)]
		[HtmlAttribute]
		[ComVisible(true)]
		[XmlElement]
		[DefaultValue(null)]
		public override string Text
		{
			get
			{
				return string_18;
			}
			set
			{
				string_18 = value;
			}
		}

		/// <summary>
		///       媒体文件名
		///       </summary>
		[DefaultValue(null)]
		[ComVisible(true)]
		[XmlElement]
		[HtmlAttribute]
		public string FileName
		{
			get
			{
				return string_19;
			}
			set
			{
				if (string_19 != value)
				{
					string_19 = value;
					method_27();
				}
			}
		}

		/// <summary>
		///       文件系统名称
		///       </summary>
		[ComVisible(true)]
		[HtmlAttribute]
		[XmlElement]
		[DefaultValue(null)]
		public string FileSystemName
		{
			get
			{
				return string_20;
			}
			set
			{
				if (string_20 != value)
				{
					string_20 = value;
					method_27();
				}
			}
		}

		/// <summary>
		///       提示文本
		///       </summary>
		protected override string MessageToDelayLoadControl => WriterStrings.ClickToLoadMedia;

		/// <summary>
		///       播放器界面模式
		///       </summary>
		[DefaultValue(WindowsMediaPlayerUIMode.mini)]
		[ComVisible(true)]
		[HtmlAttribute]
		[XmlElement]
		public WindowsMediaPlayerUIMode PlayerUIMode
		{
			get
			{
				return windowsMediaPlayerUIMode_0;
			}
			set
			{
				if (windowsMediaPlayerUIMode_0 != value)
				{
					windowsMediaPlayerUIMode_0 = value;
					method_27();
				}
			}
		}

		/// <summary>
		///       文件内容类型
		///       </summary>
		[HtmlAttribute]
		[DefaultValue(null)]
		public string FileContentType
		{
			get
			{
				return string_21;
			}
			set
			{
				string_21 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public XTextMediaElement()
		{
			if (CsMediaPlayer)
			{
				ControlType = HostedControlType.Control;
				TypeFullName = typeof(MediaPlayerControler).FullName;
				Width = 500f;
				Height = 300f;
				HostMode = ObjectHostMode.Dynamic;
			}
			Style.PaddingLeft = 20f;
			Style.PaddingBottom = 20f;
			Style.PaddingRight = 20f;
			Style.PaddingTop = 20f;
			PrintVisibility = ElementVisibility.None;
		}

		public override object vmethod_32()
		{
			if (!XTextDocument.smethod_13(GEnum6.const_220))
			{
				return null;
			}
			MediaPlayerControler mediaPlayerControler = new MediaPlayerControler();
			mediaPlayerControler.Width = (int)(550f - RuntimeStyle.PaddingLeft - RuntimeStyle.PaddingRight);
			mediaPlayerControler.Height = (int)(350f - RuntimeStyle.PaddingBottom - RuntimeStyle.PaddingTop);
			mediaPlayerControler.Url = string_19;
			base.HostedInstance = mediaPlayerControler;
			base.HostedType = mediaPlayerControler.GetType();
			HostMode = ObjectHostMode.Dynamic;
			return mediaPlayerControler;
		}

		private void method_24(object sender, EventArgs e)
		{
			if (WriterControl != null && WriterControl.ControlHostManger != null)
			{
				WriterControl.ControlHostManger.UpdateHostWindowsControlPositionAsynic(this);
			}
		}

		/// <summary>
		/// </summary>
		public override void AfterHostedControlLoaded()
		{
			method_25(base.HostedInstance, null);
		}

		private void method_25(object sender, EventArgs e)
		{
			Control control = (Control)sender;
			if (control != null && control.Tag != object_4)
			{
				control.Tag = object_4;
			}
		}

		private string method_26()
		{
			if (WriterControl != null)
			{
				WriterBeforePlayMediaEventArgs writerBeforePlayMediaEventArgs = new WriterBeforePlayMediaEventArgs(WriterControl, OwnerDocument, this, FileName, FileSystemName);
				WriterControl.vmethod_11(writerBeforePlayMediaEventArgs);
				if (writerBeforePlayMediaEventArgs.Cancel)
				{
					return null;
				}
				return writerBeforePlayMediaEventArgs.TargetFileName;
			}
			return FileName;
		}

		private void method_27()
		{
			int num = 13;
			if (WriterControl != null)
			{
				object hostedInstance = base.HostedInstance;
				if (hostedInstance != null)
				{
					ValueTypeHelper.CallMethodByName(hostedInstance, "MyResetPlayerState", new object[3]
					{
						PlayerUIMode.ToString(),
						EnableMediaContextMenu,
						LoopPlay
					}, throwException: true);
				}
			}
		}

		public override void vmethod_30(object object_5)
		{
		}

		public override void vmethod_17(ReadHTMLEventArgs readHTMLEventArgs_0)
		{
			int num = 4;
			if (XTextDocument.smethod_13(GEnum6.const_220))
			{
				readHTMLEventArgs_0.ReadDCCustomAttributes(readHTMLEventArgs_0.HtmlElement, this);
				base.ID = readHTMLEventArgs_0.HtmlElement.method_37();
				SizeF sizeF = readHTMLEventArgs_0.ReadImageSize(readHTMLEventArgs_0.HtmlElement);
				if (sizeF.Width > 0f)
				{
					Width = sizeF.Width;
				}
				if (sizeF.Height > 0f)
				{
					Height = sizeF.Height;
				}
				if (readHTMLEventArgs_0.HtmlElement.TagName == "OBJECT")
				{
					EnableMediaContextMenu = readHTMLEventArgs_0.ToBoolean(readHTMLEventArgs_0.HtmlElement.method_9("EnableContextMenu"), defaultValue: true);
					string string_ = readHTMLEventArgs_0.HtmlElement.method_9("uiMode");
					PlayerUIMode = (WindowsMediaPlayerUIMode)readHTMLEventArgs_0.ToEnumValue(string_, WindowsMediaPlayerUIMode.mini);
					foreach (GClass163 item in readHTMLEventArgs_0.HtmlElement.vmethod_2())
					{
						if (item.TagName == "PARAM" && string.Compare(item.method_9("name"), "PlayCount", ignoreCase: true) == 0 && item.method_9("value") == "0")
						{
							LoopPlay = true;
						}
					}
				}
				else if (readHTMLEventArgs_0.HtmlElement.TagName == "VIDEO")
				{
					LoopPlay = readHTMLEventArgs_0.ToBoolean(readHTMLEventArgs_0.HtmlElement.method_9("loop"), defaultValue: false);
					foreach (GClass163 item2 in readHTMLEventArgs_0.HtmlElement.vmethod_2())
					{
						if (item2.TagName == "SOURCE")
						{
							FileName = item2.method_9("src");
							break;
						}
					}
				}
			}
		}
	}
}
