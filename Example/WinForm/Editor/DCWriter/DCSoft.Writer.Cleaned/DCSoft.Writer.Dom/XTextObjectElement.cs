using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.WinForms;
using DCSoft.WinForms.Native;
using DCSoft.Writer.Script;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       嵌入在文档中的对象基础类型
	///       </summary>
	[Serializable]
	
	[Guid("00012345-6789-ABCD-EF01-23456789001E")]
	
	public abstract class XTextObjectElement : XTextElement, IDeleteable, IMemberPropertyExpressions
	{
		
		public static int int_6 = 20;

		public static float float_5 = 3f;

		private float float_6 = 0f;

		private float float_7 = 0f;

		private ElementZOrderStyle elementZOrderStyle_0 = ElementZOrderStyle.Normal;

		private bool bool_5 = false;

		private string string_3 = null;

		private string string_4 = null;

		private PropertyExpressionInfoList propertyExpressionInfoList_0 = null;

		private string string_5 = null;

		private bool bool_6 = true;

		private ElementVisibility elementVisibility_0 = ElementVisibility.Visible;

		protected VBScriptItemList vbscriptItemList_0 = null;

		private HyperlinkInfo hyperlinkInfo_0 = null;

		private ContentReadonlyState contentReadonlyState_0 = ContentReadonlyState.Inherit;

		private bool bool_7 = true;

		private int int_7 = 0;

		private string string_6 = null;

		private XAttributeList xattributeList_0 = null;

		private double double_0 = 0.0;

		private ResizeableType resizeableType_0 = ResizeableType.WidthAndHeight;

		private string string_7 = null;

		private bool bool_8 = true;

		private string string_8 = null;

		[NonSerialized]
		private object object_0 = null;

		private Rectangle rectangle_0 = Rectangle.Empty;

		/// <summary>
		///       文档内容布局时使用的宽度
		///       </summary>
		[Browsable(false)]
		
		public override float LayoutWidth
		{
			get
			{
				if (elementZOrderStyle_0 != 0)
				{
					return float_5;
				}
				return Width;
			}
		}

		/// <summary>
		///       文档内容布局时使用的高度
		///       </summary>
		[Browsable(false)]
		
		public override float LayoutHeight
		{
			get
			{
				if (elementZOrderStyle_0 != 0)
				{
					return float_5;
				}
				return Height;
			}
		}

		/// <summary>
		///       对象在文档中的绝对坐标位置
		///       </summary>
		[XmlIgnore]
		[Browsable(true)]
		
		public override float AbsLeft
		{
			get
			{
				float num = base.AbsLeft;
				if (RuntimeZOrderStyle != 0)
				{
					num += OffsetX;
				}
				return num;
			}
		}

		/// <summary>
		///       对象在文档中的绝对坐标位置
		///       </summary>
		[XmlIgnore]
		[Browsable(true)]
		
		public override float AbsTop
		{
			get
			{
				float num = base.AbsTop;
				if (RuntimeZOrderStyle != 0)
				{
					num += OffsetY;
				}
				return num;
			}
		}

		/// <summary>
		///       X方向偏移量，只有ZOrderStyle=UnderText、InFrontOfText时才有效。
		///       </summary>
		[ComVisible(true)]
		
		[DefaultValue(0f)]
		public float OffsetX
		{
			get
			{
				return float_6;
			}
			set
			{
				float_6 = value;
			}
		}

		/// <summary>
		///       Y方向偏移量，只有ZOrderStyle=UnderText、InFrontOfText时才有效。
		///       </summary>
		[DefaultValue(0f)]
		
		[ComVisible(true)]
		public float OffsetY
		{
			get
			{
				return float_7;
			}
			set
			{
				float_7 = value;
			}
		}

		/// <summary>
		///       内部使用的设置偏移量的属性。
		///       </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[XmlIgnore]
		
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[ComVisible(false)]
		public PointF InnerEditorOffset
		{
			get
			{
				return new PointF(OffsetX, OffsetY);
			}
			set
			{
				PointF left = new PointF(OffsetX, OffsetY);
				if (left != value)
				{
					InvalidateView();
					OffsetX = value.X;
					OffsetY = value.Y;
					InvalidateView();
				}
			}
		}

		/// <summary>
		///       元素Z轴位置
		///       </summary>
		[ComVisible(true)]
		[DefaultValue(ElementZOrderStyle.Normal)]
		
		public ElementZOrderStyle ZOrderStyle
		{
			get
			{
				return elementZOrderStyle_0;
			}
			set
			{
				elementZOrderStyle_0 = value;
			}
		}

		/// <summary>
		///       运行时的Z轴位置
		///       </summary>
		
		public override ElementZOrderStyle RuntimeZOrderStyle
		{
			get
			{
				if (XTextDocument.smethod_13(GEnum6.const_222))
				{
					return elementZOrderStyle_0;
				}
				return ElementZOrderStyle.Normal;
			}
		}

		/// <summary>
		///       在WEB客户端选中状态.DCWriter内部使用。
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		[DefaultValue(false)]
		[ComVisible(false)]
		[HtmlAttribute]
		public bool WebClientSelected
		{
			get
			{
				if (OwnerDocument != null && OwnerDocument.WebClientCurrentElement != null)
				{
					return OwnerDocument.WebClientCurrentElement == this;
				}
				return bool_5;
			}
			set
			{
				bool_5 = value;
			}
		}

		/// <summary>
		///       客户端单击执行的javascript脚本。当Options.BehaviorOptions.EnableExpression为false时，本属性无效。
		///       </summary>
		
		[HtmlAttribute]
		[DefaultValue(null)]
		public string JavaScriptForClick
		{
			get
			{
				return string_3;
			}
			set
			{
				string_3 = value;
			}
		}

		/// <summary>
		///       双击时执行的javascript脚本。当Options.BehaviorOptions.EnableExpression为false时，本属性无效。
		///       </summary>
		
		[DefaultValue(null)]
		[HtmlAttribute]
		public string JavaScriptForDoubleClick
		{
			get
			{
				return string_4;
			}
			set
			{
				string_4 = value;
			}
		}

		/// <summary>
		///       成员表达式列表
		///       </summary>
		[XmlArrayItem("Item", typeof(PropertyExpressionInfo))]
		
		[HtmlAttribute]
		[Browsable(true)]
		[ComVisible(true)]
		[DefaultValue(null)]
		[Editor("DCSoft.Writer.Commands.PropertyExpressionInfoListUITypeEditor", typeof(UITypeEditor))]
		public PropertyExpressionInfoList PropertyExpressions
		{
			get
			{
				if (propertyExpressionInfoList_0 == null)
				{
					propertyExpressionInfoList_0 = new PropertyExpressionInfoList();
				}
				propertyExpressionInfoList_0.Owner = this;
				return propertyExpressionInfoList_0;
			}
			set
			{
				propertyExpressionInfoList_0 = value;
			}
		}

		/// <summary>
		///       运行时使用的扩展标记文字
		///       </summary>
		
		[Browsable(false)]
		public override string RuntimeAdornText
		{
			get
			{
				switch (OwnerDocument.Options.ViewOptions.DefaultAdornTextType)
				{
				case InputFieldAdornTextType.Default:
					return null;
				case InputFieldAdornTextType.ToolTip:
					return GetToolTipInfo()?.method_5();
				default:
					return null;
				case InputFieldAdornTextType.ID:
					return base.ID;
				case InputFieldAdornTextType.Name:
					return Name;
				}
			}
		}

		/// <summary>
		///       数值表达式
		///       </summary>
		[HtmlAttribute]
		[DefaultValue(null)]
		public string ValueExpression
		{
			get
			{
				return PropertyExpressions.GetValue("FormulaValue");
			}
			set
			{
				PropertyExpressions.SetValue("FormulaValue", value);
			}
		}

		/// <summary>
		///        元素是否可见
		///       </summary>
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		[DefaultValue(true)]
		
		[XmlElement]
		[Browsable(true)]
		public override bool Visible
		{
			get
			{
				return bool_6;
			}
			set
			{
				bool_6 = value;
			}
		}

		/// <summary>
		///       运行时使用的垂直对齐方式
		///       </summary>
		
		[Browsable(false)]
		public virtual VerticalAlignStyle RuntimeVAlign => VerticalAlignStyle.Top;

		/// <summary>
		///       本属性已经淘汰，请使用PrintVisibility属性。
		///       </summary>
		[DefaultValue(true)]
		[Obsolete("请使用PrintVisibility属性。")]
		public bool Printable
		{
			get
			{
				return PrintVisibility == ElementVisibility.Visible;
			}
			set
			{
				if (value)
				{
					PrintVisibility = ElementVisibility.Visible;
				}
				else
				{
					PrintVisibility = ElementVisibility.None;
				}
			}
		}

		/// <summary>
		///       打印时的可见性设置
		///       </summary>
		[MemberExpressionable]
		[Browsable(true)]
		
		[DefaultValue(ElementVisibility.Visible)]
		[ComVisible(true)]
		[XmlElement]
		public virtual ElementVisibility PrintVisibility
		{
			get
			{
				return elementVisibility_0;
			}
			set
			{
				elementVisibility_0 = value;
			}
		}

		/// <summary>
		///       元素占据排版位置，能参与文档内容排版。
		///       </summary>
		
		[Browsable(false)]
		public override bool RuntimeLayoutable
		{
			get
			{
				XTextDocument ownerDocument = OwnerDocument;
				if (ownerDocument != null && ownerDocument.States.Printing && PrintVisibility == ElementVisibility.None)
				{
					return false;
				}
				return base.RuntimeLayoutable;
			}
		}

		/// <summary>
		///       脚本项目列表
		///       </summary>
		[XmlArrayItem("Item", typeof(VBScriptItem))]
		[ComVisible(true)]
		[DefaultValue(null)]
		public virtual VBScriptItemList ScriptItems
		{
			get
			{
				if (vbscriptItemList_0 == null && DocumentBehaviorOptions.StaticAutoCreateInstanceInProperty)
				{
					vbscriptItemList_0 = new VBScriptItemList();
				}
				return vbscriptItemList_0;
			}
			set
			{
				vbscriptItemList_0 = value;
			}
		}

		/// <summary>
		///       返回运行时使用的脚本信息对象列表
		///       </summary>
		[ComVisible(false)]
		[Browsable(false)]
		[XmlIgnore]
		
		public override VBScriptItemList RuntimeScriptItems => ScriptItems;

		/// <summary>
		///       预览内容用的图片，用于快速在用户界面上绘制文档内容，打印的时候则尽量不用
		///       </summary>
		public virtual Image PreviewImage => null;

		/// <summary>
		///       文档链接信息
		///       </summary>
		/// <remarks>
		///       获得或设置该元素的链接目标。当该属性为空时，元素没有链接样式，当该属性不为空，则该元素具有热点，
		///       在预览文档时，用户鼠标移动到该元素上，则鼠标光标显示为手形，并且显示热点提示文本。当
		///       用户点击该元素，则触发报表预览控件的热点点击事件。当报表文档输出为HTML文档时，则该元素输出的内
		///       容上添加超链接并链接到该属性指定的目标。
		///       </remarks>
		[DefaultValue(null)]
		[ComVisible(true)]
		[HtmlAttribute(AutoUseAttributeString = true)]
		
		public virtual HyperlinkInfo LinkInfo
		{
			get
			{
				return hyperlinkInfo_0;
			}
			set
			{
				hyperlinkInfo_0 = value;
			}
		}

		/// <summary>
		///       内容是否只读
		///       </summary>
		[Browsable(true)]
		[HtmlAttribute]
		[MemberExpressionable]
		
		[DefaultValue(ContentReadonlyState.Inherit)]
		[XmlElement]
		public virtual ContentReadonlyState ContentReadonly
		{
			get
			{
				return contentReadonlyState_0;
			}
			set
			{
				contentReadonlyState_0 = value;
			}
		}

		/// <summary>
		///       运行时的内容是否只读
		///       </summary>
		
		[Browsable(false)]
		public virtual bool RuntimeContentReadonly
		{
			get
			{
				ContentReadonlyState contentReadonly = ContentReadonly;
				if (contentReadonly == ContentReadonlyState.Inherit)
				{
					for (XTextContainerElement parent = Parent; parent != null; parent = parent.Parent)
					{
						switch (parent.ContentReadonly)
						{
						case ContentReadonlyState.True:
							return true;
						case ContentReadonlyState.False:
							return false;
						}
					}
					return false;
				}
				return contentReadonly == ContentReadonlyState.True;
			}
		}

		/// <summary>
		///       对象能否被删除
		///       </summary>
		[ComVisible(true)]
		[MemberExpressionable]
		
		[DefaultValue(true)]
		[HtmlAttribute]
		public bool Deleteable
		{
			get
			{
				return bool_7;
			}
			set
			{
				bool_7 = value;
			}
		}

		internal bool RuntimeDeleteable
		{
			get
			{
				if (XTextDocument.smethod_13(GEnum6.const_176))
				{
					return bool_7;
				}
				return true;
			}
		}

		/// <summary>
		///       用户标记
		///       </summary>
		[XmlElement]
		[ComVisible(true)]
		[Browsable(false)]
		[DefaultValue(0)]
		
		[HtmlAttribute]
		public int UserFlags
		{
			get
			{
				return int_7;
			}
			set
			{
				int_7 = value;
			}
		}

		/// <summary>
		///       文档元素事件模板名称
		///       </summary>
		[DefaultValue(null)]
		[ComVisible(true)]
		public string EventTemplateName
		{
			get
			{
				return string_6;
			}
			set
			{
				string_6 = value;
			}
		}

		/// <summary>
		///       用户自定义属性列表
		///       </summary>
		[HtmlAttribute]
		[DefaultValue(null)]
		[XmlArrayItem("Attribute", typeof(XAttribute))]
		[Browsable(true)]
		
		public override XAttributeList Attributes
		{
			get
			{
				if (!XTextDocument.smethod_13(GEnum6.const_180))
				{
					return null;
				}
				if (xattributeList_0 == null && DocumentBehaviorOptions.StaticAutoCreateInstanceInProperty)
				{
					xattributeList_0 = new XAttributeList();
				}
				return xattributeList_0;
			}
			set
			{
				xattributeList_0 = value;
			}
		}

		/// <summary>
		///       对象宽度高度比,若大于等于0.1则该设置有效，否则无效
		///       </summary>
		
		[Browsable(false)]
		[XmlIgnore]
		public virtual double WidthHeightRate
		{
			get
			{
				return double_0;
			}
			set
			{
				double_0 = value;
			}
		}

		/// <summary>
		///       用户是否可以改变对象大小
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public virtual ResizeableType Resizeable
		{
			get
			{
				if (RuntimeContentReadonly)
				{
					return ResizeableType.FixSize;
				}
				return resizeableType_0;
			}
			set
			{
				resizeableType_0 = value;
			}
		}

		/// <summary>
		///       对象名称
		///       </summary>
		[HtmlAttribute]
		[ComVisible(true)]
		[DefaultValue(null)]
		[MemberExpressionable(MemberEffectLevel.DOM)]
		
		public string Name
		{
			get
			{
				return string_7;
			}
			set
			{
				string_7 = value;
				if (OwnerDocument != null)
				{
					OwnerDocument.CheckBoxGroupInfo.method_2();
				}
			}
		}

		/// <summary>
		///       对象是否可用,可以接受鼠标键盘事件
		///       </summary>
		[MemberExpressionable]
		[DefaultValue(true)]
		
		[HtmlAttribute]
		[ComVisible(true)]
		public bool Enabled
		{
			get
			{
				return bool_8;
			}
			set
			{
				bool_8 = value;
			}
		}

		/// <summary>
		///       附加的字符串数据
		///       </summary>
		
		[DefaultValue(null)]
		[HtmlAttribute]
		[MemberExpressionable]
		public string StringTag
		{
			get
			{
				return string_8;
			}
			set
			{
				string_8 = value;
			}
		}

		/// <summary>
		///       附加的对象数据,这个数据不保存到文档
		///       </summary>
		
		[XmlIgnore]
		[MemberExpressionable]
		public object Tag
		{
			get
			{
				return object_0;
			}
			set
			{
				object_0 = value;
			}
		}

		/// <summary>
		///       鼠标点击时选择元素
		///       </summary>
		[Browsable(false)]
		public virtual bool MouseClickToSelect => true;

		/// <summary>
		///       判断能否使用鼠标拖拽该对象
		///       </summary>
		[Browsable(false)]
		
		public bool ShowDragRect
		{
			get
			{
				if (Resizeable == ResizeableType.FixSize)
				{
					return false;
				}
				XTextDocumentContentElement documentContentElement = base.DocumentContentElement;
				return documentContentElement.IsSelected(this) && documentContentElement.Selection.AbsLength == 1;
			}
		}

		/// <summary>
		///       专为编辑器提供的对象大小属性
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public override SizeF EditorSize
		{
			get
			{
				return new SizeF(Width, Height);
			}
			set
			{
				float num = value.Width;
				float num2 = value.Height;
				if (OwnerDocument != null && num > OwnerDocument.Width)
				{
					num = OwnerDocument.Width;
				}
				double widthHeightRate = WidthHeightRate;
				if (widthHeightRate > 0.1)
				{
					num2 = (int)((double)num / widthHeightRate);
				}
				if (OwnerDocument != null && num2 > OwnerDocument.PageSettings.ViewPaperHeight)
				{
					num2 = OwnerDocument.PageSettings.ViewPaperHeight;
					if (widthHeightRate > 0.1)
					{
						num = (int)((double)num2 * widthHeightRate);
					}
				}
				Width = num;
				Height = num2;
			}
		}

		
		public override PropertyExpressionInfoList GetRuntimePropertyExpressions()
		{
			return PropertyExpressions;
		}

		/// <summary>
		///       获得提示文本信息
		///       </summary>
		/// <returns>
		/// </returns>
		
		public override GClass96 GetToolTipInfo()
		{
			int num = 5;
			GClass96 gClass = base.GetToolTipInfo();
			if (gClass == null && LinkInfo != null && !LinkInfo.IsEmpty)
			{
				gClass = new GClass96(this, null);
				if (!string.IsNullOrEmpty(LinkInfo.Title))
				{
					gClass.method_6(LinkInfo.Title);
				}
				else if (LinkInfo.Reference.StartsWith("#"))
				{
					gClass.method_6(WriterStringsCore.CurrentDocument);
				}
				else
				{
					gClass.method_6(LinkInfo.Reference);
				}
				gClass.method_4(WriterStringsCore.CtrlClickToLink);
			}
			return gClass;
		}

		/// <summary>
		///       获得指定名称的属性值
		///       </summary>
		/// <param name="name">属性名</param>
		/// <returns>获得的属性值</returns>
		[ComVisible(true)]
		
		public override string GetAttribute(string name)
		{
			if (!XTextDocument.smethod_13(GEnum6.const_180))
			{
				return null;
			}
			if (xattributeList_0 != null)
			{
				return xattributeList_0.GetValue(name);
			}
			return null;
		}

		/// <summary>
		///       设置属性值
		///       </summary>
		/// <param name="name">属性名</param>
		/// <param name="Value">属性值</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(true)]
		
		public override bool SetAttribute(string name, string Value)
		{
			if (!XTextDocument.smethod_13(GEnum6.const_180))
			{
				return false;
			}
			if (xattributeList_0 == null)
			{
				xattributeList_0 = new XAttributeList();
			}
			xattributeList_0.SetValue(name, Value);
			return true;
		}

		/// <summary>
		///       判断是否存在指定名称的属性
		///       </summary>
		/// <param name="name">属性名</param>
		/// <returns>是否存在</returns>
		
		[ComVisible(true)]
		public override bool HasAttribute(string name)
		{
			if (!XTextDocument.smethod_13(GEnum6.const_180))
			{
				return false;
			}
			if (xattributeList_0 != null)
			{
				return xattributeList_0.ContainsByName(name);
			}
			return false;
		}

		public virtual void vmethod_23()
		{
		}

		
		public virtual GClass300 vmethod_24()
		{
			GClass300.int_0 = int_6;
			GClass300 gClass = new GClass300(new Rectangle(0, 0, (int)Width, (int)Height), bool_6: true);
			gClass.method_12(bool_6: true);
			gClass.method_19(DashStyle.Solid);
			if (OwnerDocument.DocumentControler.CanModify(this, DomAccessFlags.Normal))
			{
				gClass.method_1(Resizeable);
			}
			else
			{
				gClass.method_1(ResizeableType.FixSize);
				gClass.method_12(bool_6: false);
			}
			gClass.method_5(bool_6: true);
			if (gClass.method_0() != 0 && Parent.RuntimeEnablePermission)
			{
				if (RuntimeStyle.DeleterIndex >= 0)
				{
					gClass.method_1(ResizeableType.FixSize);
				}
				else if (base.CreatorPermessionLevel > OwnerDocument.UserHistories.CurrentPermissionLevel)
				{
					gClass.method_1(ResizeableType.FixSize);
				}
			}
			return gClass;
		}

		public override void RefreshSize(DocumentPaintEventArgs args)
		{
			SizeInvalid = false;
		}

		/// <summary>
		///       绘制对象
		///       </summary>
		/// <param name="args">
		/// </param>
		
		public override void Draw(DocumentPaintEventArgs args)
		{
			if (base.DocumentContentElement != null)
			{
				try
				{
					OwnerDocument.method_85(this);
					args.Render.vmethod_3(this, args);
					DrawContent(args);
					if (args.RenderMode == DocumentRenderMode.Paint && args.ActiveMode && ShowDragRect && Enabled)
					{
						GClass300 gClass = vmethod_24();
						gClass.method_9(new Rectangle((int)AbsLeft, (int)AbsTop, gClass.method_8().Width, gClass.method_8().Height));
						gClass.method_21(args.Graphics);
					}
					RectangleF absBounds = AbsBounds;
					absBounds.Width -= 1f;
					absBounds.Height -= 1f;
					args.Render.vmethod_2(this, args, absBounds);
				}
				catch (Exception ex)
				{
					using (DrawStringFormatExt drawStringFormatExt = new DrawStringFormatExt())
					{
						drawStringFormatExt.Alignment = StringAlignment.Near;
						drawStringFormatExt.LineAlignment = StringAlignment.Near;
						drawStringFormatExt.FormatFlags = StringFormatFlags.NoClip;
						args.Graphics.ResetClip();
						args.Graphics.DrawString(ex.ToString(), new XFontValue(), Color.Red, args.ViewBounds, drawStringFormatExt);
					}
				}
			}
		}

		protected virtual GEnum72 vmethod_25(int int_8, int int_9)
		{
			return vmethod_24()?.method_23(int_8, int_9) ?? GEnum72.const_0;
		}

		protected void method_13(DocumentEventArgs documentEventArgs_0)
		{
			base.HandleDocumentEvent(documentEventArgs_0);
		}

		/// <summary>
		///       处理文档用户界面事件
		///       </summary>
		/// <param name="args">事件参数</param>
		
		public override void HandleDocumentEvent(DocumentEventArgs args)
		{
			bool designMode = OwnerDocument.Options.BehaviorOptions.DesignMode;
			if (args.Style == DocumentEventStyles.MouseDown && Enabled)
			{
				if (OwnerDocument.EditorControl != null && OwnerDocument.EditorControl.MouseDragScroll)
				{
					return;
				}
				GEnum72 gEnum = vmethod_25(args.X, args.Y);
				if (ShowDragRect)
				{
					if (gEnum >= GEnum72.const_2)
					{
						method_14(gEnum);
						args.Handled = true;
						if (OwnerDocument.EditorControl != null)
						{
							OwnerDocument.EditorControl.UpdateTextCaret();
						}
						return;
					}
					if (RuntimeZOrderStyle != 0 && gEnum == GEnum72.const_1)
					{
						method_14(gEnum);
						args.Handled = true;
						return;
					}
				}
			}
			if (args.Style == DocumentEventStyles.MouseClick)
			{
				if ((!Enabled && !designMode) || (OwnerDocument.EditorControl != null && OwnerDocument.EditorControl.MouseDragScroll))
				{
					return;
				}
				GEnum72 gEnum = vmethod_25(args.X, args.Y);
				if (ShowDragRect && gEnum >= GEnum72.const_2)
				{
					method_14(gEnum);
					args.Handled = true;
					if (OwnerDocument.EditorControl != null)
					{
						OwnerDocument.EditorControl.UpdateTextCaret();
					}
					return;
				}
				if (LinkInfo != null && !LinkInfo.IsEmpty && OwnerDocument.EditorControl != null && OwnerDocument.Options.BehaviorOptions.EnableHyperLink && (Control.ModifierKeys & Keys.Control) == Keys.Control)
				{
					args.Cursor = Cursors.Hand;
					WriterLinkEventArgs writerLinkEventArgs_ = new WriterLinkEventArgs(OwnerDocument.EditorControl, OwnerDocument, this, LinkInfo.Reference, LinkInfo.Target);
					OwnerDocument.EditorControl.vmethod_33(writerLinkEventArgs_);
					args.Handled = true;
					return;
				}
				args.Handled = true;
				if (RuntimeSelectable || MouseClickToSelect)
				{
					int viewIndex = base.ViewIndex;
					viewIndex = OwnerDocument.Content.FixIndexForStrictFormViewMode(viewIndex, FixIndexDirection.Both, enableSetAutoClearSelectionFlag: true);
					if (viewIndex == base.ViewIndex)
					{
						OwnerDocument.Content.method_47(viewIndex, 1);
					}
					else
					{
						OwnerDocument.Content.method_47(viewIndex, 0);
					}
					OwnerDocument.Selection.StateVersion++;
					args.AlreadSetSelection = true;
					if (gEnum != GEnum72.const_1)
					{
						args.Handled = true;
						return;
					}
					args.Handled = true;
					base.HandleDocumentEvent(args);
				}
			}
			else if (args.Style == DocumentEventStyles.MouseMove)
			{
				if (!Enabled && !designMode)
				{
					return;
				}
				if (ShowDragRect)
				{
					GClass300 gClass = vmethod_24();
					GEnum72 gEnum = gClass.method_23(args.X, args.Y);
					if (gEnum >= GEnum72.const_2)
					{
						args.Cursor = GClass300.smethod_6(gEnum);
						base.HandleDocumentEvent(args);
						return;
					}
				}
				if (LinkInfo != null && !LinkInfo.IsEmpty && OwnerDocument.Options.BehaviorOptions.EnableHyperLink)
				{
					args.Cursor = Cursors.Hand;
				}
				else
				{
					args.Cursor = Cursors.Arrow;
				}
				args.Handled = true;
			}
			else
			{
				base.HandleDocumentEvent(args);
			}
		}

		private bool method_14(GEnum72 genum72_0)
		{
			int num = 18;
			MouseCapturer mouseCapturer = new MouseCapturer(OwnerDocument.EditorControl.InnerViewControl);
			mouseCapturer.Tag = genum72_0;
			mouseCapturer.ReversibleShape = GEnum68.const_4;
			mouseCapturer.Draw += method_15;
			XTextDocumentContentElement documentContentElement = base.DocumentContentElement;
			if (mouseCapturer.method_1())
			{
				if (genum72_0 == GEnum72.const_1)
				{
					if (!mouseCapturer.MoveSize.IsEmpty)
					{
						InvalidateView();
						float num2 = OffsetX + OwnerDocument.PixelToDocumentUnit(mouseCapturer.MoveSize.Width);
						float num3 = OffsetY + OwnerDocument.PixelToDocumentUnit(mouseCapturer.MoveSize.Height);
						if (OwnerDocument.BeginLogUndo())
						{
							OwnerDocument.UndoList.AddProperty("InnerEditorOffset", new PointF(OffsetX, OffsetY), new PointF(num2, num3), this);
							OwnerDocument.EndLogUndo();
						}
						OffsetX = num2;
						OffsetY = num3;
						InvalidateView();
						OwnerDocument.Modified = true;
						ContentChangedEventArgs contentChangedEventArgs = new ContentChangedEventArgs();
						contentChangedEventArgs.EventSource = ContentChangedEventSource.UndoRedo;
						contentChangedEventArgs.Document = OwnerDocument;
						XTextContainerElement xTextContainerElement = (XTextContainerElement)(contentChangedEventArgs.Element = Parent);
						xTextContainerElement.method_23(contentChangedEventArgs);
						OwnerDocument.OnDocumentContentChanged();
						return true;
					}
					return false;
				}
				if (rectangle_0.Width > 0 && rectangle_0.Height > 0 && ((float)rectangle_0.Width != Width || (float)rectangle_0.Height != Height))
				{
					float tickCountFloat = CountDown.GetTickCountFloat();
					float tickCountFloat2 = CountDown.GetTickCountFloat();
					SizeF sizeF = new SizeF(Width, Height);
					InvalidateView();
					SizeF size = base.Size;
					EditorSize = new SizeF(rectangle_0.Width, rectangle_0.Height);
					WriterUtils.smethod_20(OwnerDocument, new XTextElementList(this), bool_2: false);
					tickCountFloat2 = CountDown.GetTickCountFloat() - tickCountFloat2;
					tickCountFloat2 = CountDown.GetTickCountFloat();
					if (size != base.Size)
					{
						vmethod_23();
						InvalidateView();
						tickCountFloat2 = CountDown.GetTickCountFloat() - tickCountFloat2;
						documentContentElement.SetSelection(base.ViewIndex, 1);
						if (OwnerDocument.BeginLogUndo())
						{
							OwnerDocument.UndoList.AddProperty(GEnum18.const_2, sizeF, new SizeF(Width, Height), this);
							OwnerDocument.EndLogUndo();
						}
						tickCountFloat2 = CountDown.GetTickCountFloat();
						ContentElement.method_31(ContentElement.PrivateContent.IndexOf(this));
						tickCountFloat2 = CountDown.GetTickCountFloat() - tickCountFloat2;
						OwnerDocument.Modified = true;
						ContentChangedEventArgs contentChangedEventArgs = new ContentChangedEventArgs();
						contentChangedEventArgs.EventSource = ContentChangedEventSource.UndoRedo;
						contentChangedEventArgs.Document = OwnerDocument;
						XTextContainerElement xTextContainerElement = (XTextContainerElement)(contentChangedEventArgs.Element = Parent);
						xTextContainerElement.method_23(contentChangedEventArgs);
						OwnerDocument.OnDocumentContentChanged();
						tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
						return true;
					}
				}
			}
			return false;
		}

		private void method_15(object sender, CaptureMouseMoveEventArgs e)
		{
			GEnum72 genum72_ = (GEnum72)e.method_2().Tag;
			Rectangle rectangle_ = Rectangle.Ceiling(AbsBounds);
			Point point_ = e.method_3();
			Point point_2 = e.method_5();
			Point point = GClass300.smethod_7(rectangle_, genum72_);
			SimpleRectangleTransform gClass = OwnerDocument.EditorControl.method_22(point.X, point.Y);
			if (gClass != null)
			{
				point_ = gClass.TransformPoint(point_);
				point_2 = gClass.TransformPoint(point_2);
				rectangle_ = GClass300.smethod_4(point_2.X - point_.X, point_2.Y - point_.Y, genum72_, Rectangle.Ceiling(AbsBounds));
				if (rectangle_.Width > (int)OwnerDocument.Width)
				{
					rectangle_.Width = (int)OwnerDocument.Width;
				}
				if (WidthHeightRate > 0.1)
				{
					rectangle_.Height = (int)((double)rectangle_.Width / WidthHeightRate);
				}
				rectangle_0 = rectangle_;
				rectangle_ = gClass.vmethod_21(rectangle_);
				using (GClass249 gClass2 = GClass249.smethod_0(OwnerDocument.EditorControl.InnerViewControl.Handle))
				{
					gClass2.method_21(GEnum64.const_2);
					gClass2.method_23(Color.Red);
					gClass2.DrawRectangle(rectangle_);
				}
			}
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <param name="Deeply">是否深度复制</param>
		/// <returns>复制品</returns>
		
		public override XTextElement Clone(bool Deeply)
		{
			XTextObjectElement xTextObjectElement = (XTextObjectElement)base.Clone(Deeply);
			if (xattributeList_0 != null && xattributeList_0.Count > 0)
			{
				xTextObjectElement.xattributeList_0 = xattributeList_0.Clone();
			}
			else
			{
				xTextObjectElement.xattributeList_0 = null;
			}
			if (hyperlinkInfo_0 != null)
			{
				xTextObjectElement.hyperlinkInfo_0 = hyperlinkInfo_0.method_0();
			}
			if (propertyExpressionInfoList_0 != null)
			{
				xTextObjectElement.propertyExpressionInfoList_0 = propertyExpressionInfoList_0.Clone();
			}
			if (vbscriptItemList_0 != null && vbscriptItemList_0.Count > 0)
			{
				xTextObjectElement.vbscriptItemList_0 = vbscriptItemList_0.Clone();
			}
			else
			{
				xTextObjectElement.vbscriptItemList_0 = null;
			}
			return xTextObjectElement;
		}

		public override void Dispose()
		{
			base.Dispose();
			if (xattributeList_0 != null)
			{
				xattributeList_0.Clear();
				xattributeList_0 = null;
			}
			string_6 = null;
			string_3 = null;
			string_4 = null;
			hyperlinkInfo_0 = null;
			string_7 = null;
			if (propertyExpressionInfoList_0 != null)
			{
				propertyExpressionInfoList_0.Clear();
				propertyExpressionInfoList_0 = null;
			}
			if (vbscriptItemList_0 != null)
			{
				vbscriptItemList_0.Clear();
				vbscriptItemList_0 = null;
			}
			string_8 = null;
			object_0 = null;
			string_5 = null;
		}
	}
}
