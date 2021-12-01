using DCSoft.Drawing;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Xml.Serialization;

namespace DCSoft.ShapeEditor.Dom
{
	/// <summary>
	///       图形文档对象
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[XmlInclude(typeof(ShapeWireLabelElement))]
	[XmlInclude(typeof(ShapePolygonElement))]
	[XmlInclude(typeof(ShapeEllipseElement))]
	[XmlInclude(typeof(ShapeZoomInElement))]
	[XmlInclude(typeof(ShapeDocumentImagePage))]
	[XmlInclude(typeof(ShapeLinesElement))]
	[XmlInclude(typeof(ShapeRectangleElement))]
	[ComVisible(false)]
	[XmlInclude(typeof(ShapeLineElement))]
	public class ShapeDocument : ShapeContainerElement
	{
		[NonSerialized]
		private GControl9 gcontrol9_0 = null;

		private bool bool_4 = false;

		private Color color_0 = Color.Transparent;

		private bool bool_5 = true;

		private bool bool_6 = true;

		private GraphicsUnit graphicsUnit_0 = GraphicsUnit.Document;

		[NonSerialized]
		private float float_4 = 1f;

		private XFontValue xfontValue_0 = new XFontValue();

		private ShapeContentStyleContainer shapeContentStyleContainer_0 = new ShapeContentStyleContainer();

		private ShapeDocumentOptions shapeDocumentOptions_0 = new ShapeDocumentOptions();

		[NonSerialized]
		private GClass333 gclass333_0 = null;

		[NonSerialized]
		private GClass331 gclass331_0 = new GClass331();

		private EventHandler eventHandler_0 = null;

		private EventHandler eventHandler_1 = null;

		private bool bool_7 = false;

		[NonSerialized]
		private int int_1 = 0;

		/// <summary>
		///       是否具有内容页
		///       </summary>
		public bool HasPages => Pages != null && Pages.Count > 0;

		/// <summary>
		///       编辑器控件
		///       </summary>
		[ComVisible(false)]
		[XmlIgnore]
		[Browsable(false)]
		public GControl9 EditorControl
		{
			get
			{
				return gcontrol9_0;
			}
			set
			{
				gcontrol9_0 = value;
			}
		}

		/// <summary>
		///       启用本地元素样式模式
		///       </summary>
		/// <remarks>
		///       当处于本地元素样式模式下，文档元素的样式信息存储在LocalStyle中，而不是集中
		///       存储在文档的ContentStyles中。使用本地模式能简化编程操作，但增加数据量。
		///       </remarks>
		[DefaultValue(false)]
		public bool LocalElementStyleMode
		{
			get
			{
				return bool_4;
			}
			set
			{
				bool_4 = value;
			}
		}

		/// <summary>
		///       文字背景色
		///       </summary>
		[XmlIgnore]
		[DefaultValue(typeof(Color), "Transparent")]
		public Color TextBackColor
		{
			get
			{
				return color_0;
			}
			set
			{
				color_0 = value;
			}
		}

		/// <summary>
		///       文本背景色颜色值
		///       </summary>
		[Browsable(false)]
		[XmlElement]
		[DefaultValue(null)]
		public string TextBackColorString
		{
			get
			{
				if (TextBackColor == Color.Transparent)
				{
					return null;
				}
				return ColorTranslator.ToHtml(TextBackColor);
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					TextBackColor = Color.Transparent;
				}
				else
				{
					TextBackColor = ColorTranslator.FromHtml(value);
				}
			}
		}

		/// <summary>
		///       自动缩放字体大小
		///       </summary>
		[DefaultValue(true)]
		public bool AutoZoomFontSize
		{
			get
			{
				return bool_5;
			}
			set
			{
				bool_5 = value;
			}
		}

		/// <summary>
		///       编辑模式
		///       </summary>
		[DefaultValue(true)]
		public bool EditMode
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
		///       坐标系统使用的度量单位
		///       </summary>
		[DefaultValue(GraphicsUnit.Document)]
		public GraphicsUnit DocumentGraphicsUnit
		{
			get
			{
				return graphicsUnit_0;
			}
			set
			{
				graphicsUnit_0 = value;
			}
		}

		/// <summary>
		///       文档中的第一页
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public ShapeDocumentPage FirstPage
		{
			get
			{
				if (Pages.Count > 0)
				{
					return (ShapeDocumentPage)Pages[0];
				}
				return null;
			}
		}

		/// <summary>
		///       当前文档使用的缩放比例
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public float ZoomRate
		{
			get
			{
				return float_4;
			}
			set
			{
				float_4 = value;
			}
		}

		/// <summary>
		///       默认字体
		///       </summary>
		[Category("Appearance")]
		public XFontValue DefaultFont
		{
			get
			{
				return xfontValue_0;
			}
			set
			{
				if (xfontValue_0 != value && value != null)
				{
					xfontValue_0 = value;
					shapeContentStyleContainer_0.Default.Font = value;
				}
			}
		}

		/// <summary>
		///       文档样式容器
		///       </summary>
		[ComVisible(true)]
		public ShapeContentStyleContainer ContentStyles
		{
			get
			{
				if (shapeContentStyleContainer_0 == null)
				{
					shapeContentStyleContainer_0 = new ShapeContentStyleContainer();
				}
				return shapeContentStyleContainer_0;
			}
			set
			{
				shapeContentStyleContainer_0 = value;
				if (shapeContentStyleContainer_0 != null)
				{
				}
			}
		}

		/// <summary>
		///       选项
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public ShapeDocumentOptions Options
		{
			get
			{
				if (shapeDocumentOptions_0 == null)
				{
					shapeDocumentOptions_0 = new ShapeDocumentOptions();
				}
				return shapeDocumentOptions_0;
			}
			set
			{
				shapeDocumentOptions_0 = value;
			}
		}

		/// <summary>
		///       对象所属文档对象就是自己
		///       </summary>
		[ComVisible(false)]
		[Browsable(false)]
		[XmlIgnore]
		public override ShapeDocument OwnerDocument
		{
			get
			{
				return this;
			}
			set
			{
			}
		}

		/// <summary>
		///       文档对象的父节点为空
		///       </summary>
		[Browsable(false)]
		[ComVisible(false)]
		[XmlIgnore]
		public override ShapeContainerElement Parent
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		/// <summary>
		///       文档控制器
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public GClass333 DocumentControler
		{
			get
			{
				if (EditorControl != null)
				{
					return EditorControl.method_8();
				}
				if (gclass333_0 == null)
				{
					gclass333_0 = new GClass333();
				}
				gclass333_0.method_1(this);
				return gclass333_0;
			}
			set
			{
				gclass333_0 = value;
			}
		}

		/// <summary>
		///       页面列表
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public ShapeElementList Pages => Elements;

		/// <summary>
		///       内容呈现器
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public GClass331 DocumentRender
		{
			get
			{
				if (gclass331_0 == null)
				{
					gclass331_0 = new GClass331();
				}
				return gclass331_0;
			}
			set
			{
				gclass331_0 = value;
			}
		}

		/// <summary>
		///       文档内容被改变标记
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public bool Modified
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

		/// <summary>
		///       文档内容版本号，当文档内容发生任何改变时，该属性值都会改变
		///       </summary>
		[Browsable(false)]
		public int ContentVersion => int_1;

		/// <summary>
		///       文档内容选择状态改变事件
		///       </summary>
		public event EventHandler SelectionChanged
		{
			add
			{
				EventHandler eventHandler = eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>
		///       文档内容发生改变事件
		///       </summary>
		public event EventHandler ContentChanged
		{
			add
			{
				EventHandler eventHandler = eventHandler_1;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = eventHandler_1;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public bool method_4(bool bool_8)
		{
			if (LocalElementStyleMode != bool_8)
			{
				LocalElementStyleMode = bool_8;
				if (bool_8)
				{
					foreach (ShapeElement item in vmethod_18(bool_4: false))
					{
						item.LocalStyle = item.RuntimeStyle;
					}
				}
				else
				{
					foreach (ShapeElement item2 in vmethod_18(bool_4: false))
					{
						if (item2.LocalStyle != null)
						{
							item2.StyleIndex = ContentStyles.GetStyleIndex(item2.LocalStyle);
						}
					}
				}
				return true;
			}
			return false;
		}

		public void method_5()
		{
			int num = 0;
			ShapeElementList shapeElementList = vmethod_18(bool_4: true);
			int[] array = new int[ContentStyles.Styles.Count];
			foreach (ShapeElement item in shapeElementList)
			{
				if (item.StyleIndex >= 0 && item.StyleIndex < array.Length)
				{
					array[item.StyleIndex]++;
				}
			}
			ContentStyleList styles = ContentStyles.Styles;
			int count = styles.Count;
			int[] array2 = new int[count];
			foreach (ShapeElement item2 in shapeElementList)
			{
				int styleIndex = item2.StyleIndex;
				if (styleIndex >= 0 && styleIndex < count)
				{
					array2[styleIndex]++;
				}
			}
			bool flag = false;
			for (int i = 0; i < count; i++)
			{
				if (array2[i] == 0)
				{
					flag = true;
				}
				else if (styles[i].IsEmpty)
				{
					flag = true;
					array2[i] = 0;
				}
			}
			if (!flag)
			{
				return;
			}
			ContentStyles.method_1();
			ContentStyle contentStyle = new ContentStyle();
			contentStyle.FontName = "悲剧啊";
			int num2 = 0;
			for (int j = 0; j < count; j++)
			{
				if (array2[j] == 0)
				{
					num2++;
					array2[j] = -1;
					styles[j].Dispose();
					styles[j] = contentStyle;
					continue;
				}
				if (styles[j] == contentStyle)
				{
					num2++;
					continue;
				}
				ContentStyle contentStyle2 = styles[j];
				if (contentStyle2 == contentStyle)
				{
					continue;
				}
				array2[j] = j - num2;
				for (int k = j + 1; k < count; k++)
				{
					if (styles[k] != contentStyle && contentStyle2.method_4(styles[k]))
					{
						array2[k] = array2[j];
						styles[k].Dispose();
						styles[k] = contentStyle;
					}
				}
			}
			foreach (ShapeElement item3 in shapeElementList)
			{
				int styleIndex = item3.StyleIndex;
				if (styleIndex >= 0 && styleIndex < count)
				{
					item3.StyleIndex = array2[styleIndex];
				}
				else
				{
					item3.StyleIndex = -1;
				}
			}
			for (int j = styles.Count - 1; j >= 0; j--)
			{
				if (styles[j] == contentStyle)
				{
					styles.RemoveAt(j);
				}
			}
		}

		public virtual DCGraphics vmethod_21()
		{
			DCGraphics dCGraphics = null;
			if (EditorControl == null)
			{
				Graphics graphics = Graphics.FromHwnd(new IntPtr(0));
				graphics.PageUnit = DocumentGraphicsUnit;
				dCGraphics = new DCGraphics(graphics);
			}
			else
			{
				dCGraphics = new DCGraphics(EditorControl.method_53());
			}
			dCGraphics.AutoDisposeNativeGraphics = true;
			return dCGraphics;
		}

		public virtual void vmethod_22(ShapeElement shapeElement_0)
		{
			int num = 14;
			if (shapeElement_0 == null)
			{
				throw new ArgumentNullException("element");
			}
			if (EditorControl == null)
			{
				return;
			}
			RectangleF rectangleF = shapeElement_0.Bounds;
			rectangleF.Location = shapeElement_0.AbsLocation;
			if (shapeElement_0.Selected)
			{
				GClass330 gClass = shapeElement_0.vmethod_4();
				if (gClass != null && gClass.Count > 0)
				{
					PointF location = rectangleF.Location;
					float runtimeControlPointSize = Options.ViewOptions.RuntimeControlPointSize;
					foreach (GClass329 item in gClass)
					{
						rectangleF = RectangleF.Union(rectangleF, new RectangleF(item.method_2() + location.X - runtimeControlPointSize / 2f, item.method_4() + location.Y - runtimeControlPointSize / 2f, runtimeControlPointSize, runtimeControlPointSize));
					}
					rectangleF.Inflate(runtimeControlPointSize / 2f, runtimeControlPointSize / 2f);
				}
			}
			EditorControl.vmethod_0(rectangleF);
		}

		public virtual void vmethod_23(EventArgs eventArgs_0)
		{
			if (EditorControl != null)
			{
				EditorControl.vmethod_8(eventArgs_0);
			}
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, eventArgs_0);
			}
		}

		public virtual void vmethod_24(EventArgs eventArgs_0)
		{
			if (EditorControl != null)
			{
				EditorControl.vmethod_9(eventArgs_0);
			}
			if (eventHandler_1 != null)
			{
				eventHandler_1(this, eventArgs_0);
			}
		}

		public void method_6()
		{
			int_1++;
		}

		public override void vmethod_16(ShapeFileFormat shapeFileFormat_0)
		{
			base.vmethod_16(shapeFileFormat_0);
			ContentStyles.Styles.FixFontName();
		}

		public virtual bool vmethod_25(string string_2)
		{
			XmlSerializer xmlSerializer = Class189.smethod_1(GetType());
			using (FileStream stream = new FileStream(string_2, FileMode.Open, FileAccess.Read))
			{
				ShapeDocument shapeDocument = (ShapeDocument)xmlSerializer.Deserialize(stream);
				shapeContentStyleContainer_0 = shapeDocument.shapeContentStyleContainer_0;
				xfontValue_0 = shapeDocument.xfontValue_0;
				shapeDocumentOptions_0 = shapeDocument.shapeDocumentOptions_0;
				foreach (ShapeElement element in shapeDocument.Elements)
				{
					vmethod_19(element);
				}
			}
			method_6();
			vmethod_16(ShapeFileFormat.XML);
			Modified = false;
			return true;
		}

		public virtual bool vmethod_26(Stream stream_0)
		{
			XmlSerializer xmlSerializer = Class189.smethod_1(GetType());
			ShapeDocument shapeDocument = (ShapeDocument)xmlSerializer.Deserialize(stream_0);
			shapeContentStyleContainer_0 = shapeDocument.shapeContentStyleContainer_0;
			xfontValue_0 = shapeDocument.xfontValue_0;
			shapeDocumentOptions_0 = shapeDocument.shapeDocumentOptions_0;
			foreach (ShapeElement element in shapeDocument.Elements)
			{
				vmethod_19(element);
			}
			method_6();
			vmethod_16(ShapeFileFormat.XML);
			Modified = false;
			return true;
		}

		public virtual bool vmethod_27(TextReader textReader_0)
		{
			XmlSerializer xmlSerializer = Class189.smethod_1(GetType());
			ShapeDocument shapeDocument = (ShapeDocument)xmlSerializer.Deserialize(textReader_0);
			shapeContentStyleContainer_0 = shapeDocument.shapeContentStyleContainer_0;
			xfontValue_0 = shapeDocument.xfontValue_0;
			shapeDocumentOptions_0 = shapeDocument.shapeDocumentOptions_0;
			foreach (ShapeElement element in shapeDocument.Elements)
			{
				vmethod_19(element);
			}
			method_6();
			vmethod_16(ShapeFileFormat.XML);
			Modified = false;
			return true;
		}

		public virtual bool vmethod_28(string string_2)
		{
			XmlSerializer xmlSerializer = Class189.smethod_1(GetType());
			using (FileStream stream = new FileStream(string_2, FileMode.Create, FileAccess.Write))
			{
				xmlSerializer.Serialize(stream, this);
			}
			return true;
		}

		public virtual bool vmethod_29(Stream stream_0)
		{
			XmlSerializer xmlSerializer = Class189.smethod_1(GetType());
			xmlSerializer.Serialize(stream_0, this);
			return true;
		}

		public virtual bool vmethod_30(TextWriter textWriter_0)
		{
			XmlSerializer xmlSerializer = Class189.smethod_1(GetType());
			xmlSerializer.Serialize(textWriter_0, this);
			return true;
		}

		public override ShapeElement vmethod_17(bool bool_8)
		{
			ShapeDocument shapeDocument = (ShapeDocument)base.vmethod_17(bool_8);
			shapeDocument.shapeContentStyleContainer_0 = (ShapeContentStyleContainer)shapeContentStyleContainer_0.method_2();
			shapeDocument.vmethod_20();
			return shapeDocument;
		}
	}
}
