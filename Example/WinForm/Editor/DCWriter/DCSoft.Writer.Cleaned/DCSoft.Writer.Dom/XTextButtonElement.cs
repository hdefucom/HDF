using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.WinForms;
using DCSoft.Writer.Script;
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
	///       按钮元素
	///       </summary>
	[Serializable]
	[Guid("3ED207D7-E972-4C88-93BE-8C96ABF60E0C")]
	[ComVisible(true)]
	[XmlType("XTextButton")]
	[ToolboxBitmap(typeof(XTextButtonElement))]
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("3ED207D7-E972-4C88-93BE-8C96ABF60E0C", "24096F15-6E09-4FA0-B4F6-25F11EB422B1")]
	[DebuggerDisplay("Button:ID={ID} , Text={Text}")]
	[ComDefaultInterface(typeof(IXTextButtonElement))]
	
	
	public class XTextButtonElement : XTextObjectElement, IXTextButtonElement
	{
		internal const string string_9 = "3ED207D7-E972-4C88-93BE-8C96ABF60E0C";

		internal const string string_10 = "24096F15-6E09-4FA0-B4F6-25F11EB422B1";

		
		public const float float_8 = 199f;

		private bool bool_9 = false;

		private bool bool_10 = false;

		private XImageValue ximageValue_0 = null;

		private XImageValue ximageValue_1 = null;

		private XImageValue ximageValue_2 = null;

		private string string_11 = null;

		private string string_12 = null;

		private string string_13 = null;

		[NonSerialized]
		private GEnum90 genum90_0 = GEnum90.const_0;

		private static DrawStringFormatExt drawStringFormatExt_0 = null;

		/// <summary>
		///       以文本方式打印
		///       </summary>
		[DefaultValue(false)]
		
		[ComVisible(true)]
		[XmlElement]
		public bool PrintAsText
		{
			get
			{
				return bool_9;
			}
			set
			{
				bool_9 = value;
			}
		}

		/// <summary>
		///       自动大小 
		///       </summary>
		
		[DefaultValue(false)]
		[XmlElement]
		[ComVisible(true)]
		public bool AutoSize
		{
			get
			{
				return bool_10;
			}
			set
			{
				bool_10 = value;
			}
		}

		/// <summary>
		///       按钮图片
		///       </summary>
		[XmlElement]
		
		[ComVisible(true)]
		[DefaultValue(null)]
		public XImageValue Image
		{
			get
			{
				return ximageValue_0;
			}
			set
			{
				ximageValue_0 = value;
			}
		}

		/// <summary>
		///       按下状态时的图片
		///       </summary>
		
		[DefaultValue(null)]
		[XmlElement]
		public XImageValue ImageForDown
		{
			get
			{
				return ximageValue_1;
			}
			set
			{
				ximageValue_1 = value;
			}
		}

		/// <summary>
		///       鼠标悬停时的图片
		///       </summary>
		[DefaultValue(null)]
		
		[XmlElement]
		public XImageValue ImageForMouseOver
		{
			get
			{
				return ximageValue_2;
			}
			set
			{
				ximageValue_2 = value;
			}
		}

		
		public override string DomDisplayName => "Button:" + base.ID;

		/// <summary>
		///       文档元素编号前缀
		///       </summary>
		
		public override string ElementIDPrefix => "button";

		[Browsable(false)]
		[XmlIgnore]
		[MemberExpressionable(MemberEffectLevel.DOM)]
		public override string FormulaValue
		{
			get
			{
				return Text;
			}
			set
			{
				Text = method_12(value);
				InvalidateView();
			}
		}

		/// <summary>
		///       对象能否被选中
		///       </summary>
		
		public override bool RuntimeSelectable
		{
			get
			{
				if (OwnerDocument != null && OwnerDocument.Options.BehaviorOptions.DesignMode)
				{
					return true;
				}
				return false;
			}
		}

		/// <summary>
		///       对象宽度
		///       </summary>
		[Browsable(true)]
		
		[XmlElement]
		[HtmlAttribute]
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		public override float Width
		{
			get
			{
				return base.Width;
			}
			set
			{
				base.Width = value;
			}
		}

		/// <summary>
		///       对象高度
		///       </summary>
		[HtmlAttribute]
		[XmlElement]
		[Browsable(true)]
		
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		public override float Height
		{
			get
			{
				return base.Height;
			}
			set
			{
				base.Height = value;
			}
		}

		/// <summary>
		///       文本值
		///       </summary>
		[MemberExpressionable(MemberEffectLevel.ElementView)]
		[HtmlAttribute]
		[Browsable(true)]
		[XmlElement]
		
		public override string Text
		{
			get
			{
				return string_11;
			}
			set
			{
				string_11 = value;
			}
		}

		/// <summary>
		///       按钮点击时使用的脚本
		///       </summary>
		[DefaultValue(null)]
		
		[HtmlAttribute]
		public string ScriptTextForClick
		{
			get
			{
				return string_12;
			}
			set
			{
				string_12 = value;
			}
		}

		/// <summary>
		///       命令名称
		///       </summary>
		[DefaultValue(null)]
		
		[HtmlAttribute]
		public string CommandName
		{
			get
			{
				return string_13;
			}
			set
			{
				string_13 = value;
			}
		}

		/// <summary>
		///       用户能否改变对象大小
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public override ResizeableType Resizeable
		{
			get
			{
				if (AutoSize)
				{
					return ResizeableType.FixSize;
				}
				return ResizeableType.WidthAndHeight;
			}
			set
			{
			}
		}

		/// <summary>
		///       返回运行时使用的脚本信息对象列表
		///       </summary>
		
		[ComVisible(false)]
		[Browsable(false)]
		[XmlIgnore]
		public override VBScriptItemList RuntimeScriptItems
		{
			get
			{
				VBScriptItemList vBScriptItemList = vbscriptItemList_0;
				if (!string.IsNullOrEmpty(ScriptTextForClick))
				{
					vBScriptItemList = ((vBScriptItemList != null) ? vBScriptItemList.Clone() : new VBScriptItemList());
					VBScriptItem vBScriptItem = new VBScriptItem();
					vBScriptItem.ScriptText = ScriptTextForClick;
					vBScriptItemList.Add(vBScriptItem);
				}
				return vBScriptItemList;
			}
		}

		/// <summary>
		///       DCWriter内部使用。绘制文本使用的文本格式化对象
		///       </summary>
		public static DrawStringFormatExt InnerFormatForDrawContent
		{
			get
			{
				if (drawStringFormatExt_0 == null)
				{
					drawStringFormatExt_0 = GClass522.smethod_1();
				}
				return drawStringFormatExt_0;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public XTextButtonElement()
		{
			Width = 199f;
			Height = 80f;
		}

		/// <summary>
		///       从图片文件加载ImageForUp属性值
		///       </summary>
		/// <param name="fileName">文件名</param>
		
		[ComVisible(true)]
		public void LoadImageFromFile(string fileName)
		{
			XImageValue xImageValue = new XImageValue();
			xImageValue.Load(fileName);
			if (ximageValue_0 != null)
			{
				XImageValue xImageValue2 = ximageValue_0;
				ximageValue_0 = null;
				xImageValue2.Dispose();
			}
			ximageValue_0 = xImageValue;
		}

		/// <summary>
		///       从图片的Base64字符串加载ImageForUp属性值
		///       </summary>
		/// <param name="fileName">文件名</param>
		[ComVisible(true)]
		
		public void LoadImageFromBase64String(string base64)
		{
			XImageValue xImageValue = new XImageValue();
			xImageValue.LoadBase64String(base64);
			if (ximageValue_0 != null)
			{
				XImageValue xImageValue2 = ximageValue_0;
				ximageValue_0 = null;
				xImageValue2.Dispose();
			}
			ximageValue_0 = xImageValue;
		}

		/// <summary>
		///       从图片文件加载ImageForDown属性值
		///       </summary>
		/// <param name="fileName">文件名</param>
		
		[ComVisible(true)]
		public void LoadImageForDownFromFile(string fileName)
		{
			XImageValue xImageValue = new XImageValue();
			xImageValue.Load(fileName);
			if (ximageValue_1 != null)
			{
				XImageValue xImageValue2 = ximageValue_1;
				ximageValue_1 = null;
				xImageValue2.Dispose();
			}
			ximageValue_1 = xImageValue;
		}

		/// <summary>
		///       从图片的Base64字符串加载ImageForDown属性值
		///       </summary>
		/// <param name="fileName">文件名</param>
		
		[ComVisible(true)]
		public void LoadImageForDownFromBase64String(string base64)
		{
			XImageValue xImageValue = new XImageValue();
			xImageValue.LoadBase64String(base64);
			if (ximageValue_1 != null)
			{
				XImageValue xImageValue2 = ximageValue_1;
				ximageValue_1 = null;
				xImageValue2.Dispose();
			}
			ximageValue_1 = xImageValue;
		}

		/// <summary>
		///       从图片文件加载ImageForMouseOver属性值
		///       </summary>
		/// <param name="fileName">文件名</param>
		[ComVisible(true)]
		
		public void LoadImageForMouseOverFromFile(string fileName)
		{
			XImageValue xImageValue = new XImageValue();
			xImageValue.Load(fileName);
			if (ximageValue_2 != null)
			{
				XImageValue xImageValue2 = ximageValue_2;
				ximageValue_2 = null;
				xImageValue2.Dispose();
			}
			ximageValue_2 = xImageValue;
		}

		/// <summary>
		///       从图片的Base64字符串加载ImageForMouseOver属性值
		///       </summary>
		/// <param name="fileName">文件名</param>
		[ComVisible(true)]
		
		public void LoadImageForMouseOverFromBase64String(string base64)
		{
			XImageValue xImageValue = new XImageValue();
			xImageValue.LoadBase64String(base64);
			if (ximageValue_2 != null)
			{
				XImageValue xImageValue2 = ximageValue_2;
				ximageValue_2 = null;
				xImageValue2.Dispose();
			}
			ximageValue_2 = xImageValue;
		}

		public override bool vmethod_1(bool bool_11)
		{
			return !string.IsNullOrEmpty(string_12);
		}

		/// <summary>
		///       处理文档事件
		///       </summary>
		/// <param name="args">事件参数</param>
		
		public override void HandleDocumentEvent(DocumentEventArgs args)
		{
			int num = 3;
			if (!XTextDocument.smethod_13(GEnum6.const_202))
			{
				base.HandleDocumentEvent(args);
				return;
			}
			bool designMode;
			if (!(designMode = OwnerDocument.Options.BehaviorOptions.DesignMode))
			{
				args.Cursor = Cursors.Arrow;
			}
			switch (args.Style)
			{
			case DocumentEventStyles.MouseEnter:
				if (!designMode && !base.Enabled)
				{
					args.Handled = true;
					args.CancelBubble = true;
					return;
				}
				if (args.Button == MouseButtons.None)
				{
					genum90_0 = GEnum90.const_1;
					InvalidateView();
					base.HandleDocumentEvent(args);
					args.Handled = true;
					args.CancelBubble = true;
					return;
				}
				break;
			case DocumentEventStyles.MouseLeave:
				if (!designMode && !base.Enabled)
				{
					args.Handled = true;
					args.CancelBubble = true;
					return;
				}
				if (args.Button == MouseButtons.None)
				{
					genum90_0 = GEnum90.const_0;
					InvalidateView();
					base.HandleDocumentEvent(args);
					args.Handled = true;
					args.CancelBubble = true;
					return;
				}
				break;
			case DocumentEventStyles.MouseDown:
				if (designMode)
				{
					break;
				}
				args.Cursor = Cursors.Arrow;
				if (!base.Enabled)
				{
					args.Handled = true;
					args.CancelBubble = true;
				}
				else if (args.Button == MouseButtons.Left)
				{
					genum90_0 = GEnum90.const_2;
					InvalidateView();
					if (OwnerDocument.EditorControl == null)
					{
					}
					base.HandleDocumentEvent(args);
					args.Handled = true;
					args.CancelBubble = true;
				}
				return;
			case DocumentEventStyles.MouseClick:
				if (args.Button != MouseButtons.Left || designMode)
				{
					break;
				}
				args.Cursor = Cursors.Arrow;
				if (!base.Enabled)
				{
					args.Handled = true;
					args.CancelBubble = true;
					return;
				}
				genum90_0 = GEnum90.const_1;
				InvalidateView();
				if (OwnerDocument != null && !string.IsNullOrEmpty(CommandName))
				{
					EventHandler eventHandler = OwnerDocument.GetParameterValue(CommandName) as EventHandler;
					if (eventHandler != null)
					{
						eventHandler(this, EventArgs.Empty);
						args.Handled = true;
						args.CancelBubble = true;
						return;
					}
				}
				if (OwnerDocument.EditorControl != null)
				{
					WriterButtonClickEventArgs writerButtonClickEventArgs = new WriterButtonClickEventArgs(OwnerDocument.EditorControl, this);
					OwnerDocument.EditorControl.vmethod_32(writerButtonClickEventArgs);
					if (writerButtonClickEventArgs.Handled)
					{
						args.Handled = true;
						args.CancelBubble = true;
						return;
					}
				}
				if (!string.IsNullOrEmpty(ScriptTextForClick) && OwnerDocument.ScriptEngine != null)
				{
					string methodNameByScriptText = OwnerDocument.ScriptEngine.GetMethodNameByScriptText(ScriptTextForClick);
					if (!string.IsNullOrEmpty(methodNameByScriptText))
					{
						OwnerDocument.ScriptEngine.ExecuteSub(this, methodNameByScriptText);
					}
				}
				args.Handled = true;
				args.CancelBubble = true;
				return;
			case DocumentEventStyles.MouseDblClick:
				if (args.Button == MouseButtons.Left && designMode && OwnerDocument != null && OwnerDocument.EditorControl != null)
				{
					OwnerDocument.EditorControl.ExecuteCommand("ElementProperties", showUI: true, this);
					return;
				}
				break;
			}
			base.HandleDocumentEvent(args);
			if (!designMode)
			{
				args.Cursor = Cursors.Arrow;
			}
		}

		
		public override void RefreshSize(DocumentPaintEventArgs args)
		{
			if (AutoSize)
			{
				SizeF sizeF = method_16(args.Graphics);
				Width = sizeF.Width;
				Height = sizeF.Height;
			}
			else
			{
				base.RefreshSize(args);
			}
		}

		
		public SizeF method_16(DCGraphics dcgraphics_0)
		{
			GClass522 gClass = method_17();
			return gClass.method_22(dcgraphics_0);
		}

		private GClass522 method_17()
		{
			GClass522 gClass = new GClass522();
			gClass.method_3(RuntimeStyle.Font);
			gClass.method_7(RuntimeStyle.BackgroundColor);
			gClass.method_9(Text);
			gClass.method_11(genum90_0);
			gClass.method_13(base.Enabled);
			gClass.method_5(method_4(RuntimeStyle.Color));
			gClass.method_17(Image);
			gClass.method_19(ImageForDown);
			gClass.method_21(ImageForMouseOver);
			return gClass;
		}

		/// <summary>
		///       绘制元素图形
		///       </summary>
		/// <param name="args">参数</param>
		public override void DrawContent(DocumentPaintEventArgs args)
		{
			if (!XTextDocument.smethod_13(GEnum6.const_202))
			{
				return;
			}
			if (PrintAsText && (args.RenderMode == DocumentRenderMode.Print || args.RenderMode == DocumentRenderMode.ReadPaint))
			{
				if (Text != null && Text.Length > 0)
				{
					DrawStringFormatExt drawStringFormatExt = new DrawStringFormatExt();
					drawStringFormatExt.Alignment = StringAlignment.Center;
					drawStringFormatExt.LineAlignment = StringAlignment.Center;
					drawStringFormatExt.Color = method_4(RuntimeStyle.Color);
					drawStringFormatExt.Font = RuntimeStyle.Font;
					drawStringFormatExt.SetBounds(args.ViewBounds);
					args.Graphics.method_2(Text, drawStringFormatExt);
				}
				return;
			}
			GClass522 gClass = method_17();
			if (args.RenderMode != 0)
			{
				gClass.method_11(GEnum90.const_0);
			}
			RectangleF absBounds = AbsBounds;
			gClass.method_1(new RectangleF(absBounds.Left + 1f, absBounds.Top + 1f, absBounds.Width - 4f, absBounds.Height - 4f));
			if (args.RenderMode == DocumentRenderMode.PDF)
			{
				Image image_ = CreateContentImage();
				args.Graphics.DrawImage(image_, AbsBounds);
			}
			else
			{
				gClass.method_23(args.Graphics);
			}
			OwnerDocument.method_114(this, args, GEnum6.const_202);
		}

		
		public override Image CreateContentImage()
		{
			if (Image != null && Image.HasContent)
			{
				return (Image)Image.Value.Clone();
			}
			return base.CreateContentImage();
		}

		public override void Dispose()
		{
			base.Dispose();
			if (ximageValue_0 != null)
			{
				ximageValue_0.Dispose();
				ximageValue_0 = null;
			}
			if (ximageValue_1 != null)
			{
				ximageValue_1.Dispose();
				ximageValue_1 = null;
			}
			if (ximageValue_2 != null)
			{
				ximageValue_2.Dispose();
				ximageValue_2 = null;
			}
		}

		public override void vmethod_17(ReadHTMLEventArgs readHTMLEventArgs_0)
		{
			base.ID = readHTMLEventArgs_0.HtmlElement.method_37();
			Text = readHTMLEventArgs_0.HtmlElement.method_9("value");
			readHTMLEventArgs_0.ReadDCCustomAttributes(readHTMLEventArgs_0.HtmlElement, this);
			Style = readHTMLEventArgs_0.CreateContentStyle(readHTMLEventArgs_0.CurrentStyle, this, readHTMLEventArgs_0.HtmlElement);
			if (!string.IsNullOrEmpty(readHTMLEventArgs_0.HtmlElement.method_0().method_231()))
			{
				Width = readHTMLEventArgs_0.ToLength(readHTMLEventArgs_0.HtmlElement.method_0().method_231());
			}
			if (!string.IsNullOrEmpty(readHTMLEventArgs_0.HtmlElement.method_0().method_105()))
			{
				Height = readHTMLEventArgs_0.ToLength(readHTMLEventArgs_0.HtmlElement.method_0().method_105());
			}
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <param name="Deeply">是否深度复制</param>
		/// <returns>复制品</returns>
		public override XTextElement Clone(bool Deeply)
		{
			XTextButtonElement xTextButtonElement = (XTextButtonElement)base.Clone(Deeply);
			if (ximageValue_0 != null)
			{
				xTextButtonElement.ximageValue_0 = ximageValue_0.Clone();
			}
			if (ximageValue_1 != null)
			{
				xTextButtonElement.ximageValue_1 = ximageValue_1.Clone();
			}
			if (ximageValue_2 != null)
			{
				xTextButtonElement.ximageValue_2 = ximageValue_2.Clone();
			}
			return xTextButtonElement;
		}
	}
}
