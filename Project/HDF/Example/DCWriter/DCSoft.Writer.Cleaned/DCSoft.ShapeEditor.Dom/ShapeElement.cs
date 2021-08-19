using DCSoft.Drawing;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.ShapeEditor.Dom
{
	/// <summary>
	///       图形文档元素基础类型
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[ComVisible(false)]
	public class ShapeElement : IDisposable, ICloneable
	{
		private bool bool_0 = true;

		private bool bool_1 = true;

		private ContentStyle contentStyle_0 = null;

		private bool bool_2 = true;

		private int int_0 = -1;

		private string string_0 = null;

		private ShapeContainerElement shapeContainerElement_0 = null;

		private ShapeDocument shapeDocument_0 = null;

		/// <summary>
		///       元素大小无效标记
		///       </summary>
		/// <remarks>若设置该属性,则元素的大小发生改变,系统需要从该元素
		///       开始重新进行文档排版和分页</remarks>
		[XmlIgnore]
		public virtual bool SizeInvalid
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		/// <summary>
		///       元素视图无效标记
		///       </summary>
		/// <remarks>若设置该属性,则元素的显示样式无效,系统需要重新
		///       绘制该元素</remarks>
		[XmlIgnore]
		public bool ViewInvalid
		{
			get
			{
				return bool_1;
			}
			set
			{
				bool_1 = value;
			}
		}

		/// <summary>
		///       绘制文档内容使用的样式
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public virtual ContentStyle RuntimeStyle
		{
			get
			{
				if (LocalStyle != null)
				{
					return LocalStyle;
				}
				if (OwnerDocument == null)
				{
					return null;
				}
				return OwnerDocument.ContentStyles.GetRuntimeStyle(StyleIndex);
			}
		}

		/// <summary>
		///       本地内容样式
		///       </summary>
		[DefaultValue(null)]
		public ContentStyle LocalStyle
		{
			get
			{
				return contentStyle_0;
			}
			set
			{
				contentStyle_0 = value;
			}
		}

		[Browsable(false)]
		[XmlIgnore]
		public ContentStyle Style
		{
			get
			{
				if (OwnerDocument == null)
				{
					return null;
				}
				return OwnerDocument.ContentStyles.GetStyle(StyleIndex);
			}
			set
			{
				StyleIndex = OwnerDocument.ContentStyles.GetStyleIndex(value);
			}
		}

		/// <summary>
		///       对象是否可见
		///       </summary>
		[DefaultValue(true)]
		public bool Visible
		{
			get
			{
				return bool_2;
			}
			set
			{
				bool_2 = value;
			}
		}

		/// <summary>
		///       使用的样式编号
		///       </summary>
		[XmlAttribute]
		[DefaultValue(-1)]
		public virtual int StyleIndex
		{
			get
			{
				return int_0;
			}
			set
			{
				int_0 = value;
				bool_0 = true;
			}
		}

		/// <summary>
		///       对象相对于父元素客户区的边界
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public virtual RectangleF Bounds
		{
			get
			{
				return RectangleF.Empty;
			}
			set
			{
			}
		}

		/// <summary>
		///       元素在文档视图中绝对坐标位置
		///       </summary>
		[Browsable(false)]
		public virtual PointF AbsLocation
		{
			get
			{
				PointF location = Bounds.Location;
				for (ShapeContainerElement parent = Parent; parent != null; parent = parent.Parent)
				{
					ContentStyle runtimeStyle = parent.RuntimeStyle;
					location.X = location.X + runtimeStyle.PaddingLeft + parent.Left;
					location.Y = location.Y + runtimeStyle.PaddingTop + parent.Top;
					if (parent is ShapeDocumentPage)
					{
						break;
					}
				}
				return location;
			}
		}

		[Browsable(false)]
		public virtual RectangleF AbsBounds
		{
			get
			{
				RectangleF bounds = Bounds;
				bounds.Location = AbsLocation;
				return bounds;
			}
		}

		/// <summary>
		///       子元素列表
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public virtual ShapeElementList Elements
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
		///       编号
		///       </summary>
		[DefaultValue(null)]
		public string ID
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		/// <summary>
		///       父节点对象
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public virtual ShapeContainerElement Parent
		{
			get
			{
				return shapeContainerElement_0;
			}
			set
			{
				shapeContainerElement_0 = value;
				if (shapeContainerElement_0 != null)
				{
					OwnerDocument = shapeContainerElement_0.OwnerDocument;
				}
			}
		}

		/// <summary>
		///       对象所属文档对象
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public virtual ShapeDocument OwnerDocument
		{
			get
			{
				return shapeDocument_0;
			}
			set
			{
				shapeDocument_0 = value;
			}
		}

		/// <summary>
		///       对象所属页面对象
		///       </summary>
		[Browsable(false)]
		public ShapeDocumentPage OwnerPage
		{
			get
			{
				ShapeElement shapeElement = this;
				while (true)
				{
					if (shapeElement != null)
					{
						if (shapeElement is ShapeDocumentPage)
						{
							break;
						}
						shapeElement = shapeElement.Parent;
						continue;
					}
					return null;
				}
				return (ShapeDocumentPage)shapeElement;
			}
		}

		/// <summary>
		///       对象被选中
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public bool Selected
		{
			get
			{
				if (OwnerPage != null)
				{
					return OwnerPage.Selection.Contains(this);
				}
				return false;
			}
		}

		public virtual void vmethod_0(float float_0, float float_1)
		{
		}

		public virtual void vmethod_1(GClass328 gclass328_0)
		{
		}

		public virtual void vmethod_2(GEventArgs11 geventArgs11_0)
		{
		}

		public virtual void vmethod_3(DCGraphics dcgraphics_0)
		{
		}

		public virtual GClass330 vmethod_4()
		{
			return null;
		}

		public virtual GraphicsPath vmethod_5()
		{
			return null;
		}

		public virtual void vmethod_6(ShapeRenderEventArgs shapeRenderEventArgs_0)
		{
			shapeRenderEventArgs_0.Render.vmethod_1(this, shapeRenderEventArgs_0);
		}

		public virtual void vmethod_7(ShapeRenderEventArgs shapeRenderEventArgs_0)
		{
		}

		public virtual void vmethod_8(ShapeMouseEventArgs shapeMouseEventArgs_0)
		{
		}

		public virtual void vmethod_9(ShapeMouseEventArgs shapeMouseEventArgs_0)
		{
		}

		public virtual void vmethod_10(ShapeMouseEventArgs shapeMouseEventArgs_0)
		{
		}

		public virtual bool vmethod_11(RectangleF rectangleF_0)
		{
			return true;
		}

		public virtual Bitmap vmethod_12()
		{
			RectangleF absBounds = AbsBounds;
			if (absBounds.Width > 0f && absBounds.Height > 0f)
			{
				SizeF sizeF = GraphicsUnitConvert.Convert(absBounds.Size, OwnerDocument.DocumentGraphicsUnit, GraphicsUnit.Pixel);
				Bitmap bitmap = new Bitmap((int)Math.Ceiling(sizeF.Width), (int)Math.Ceiling(sizeF.Height));
				using (DCGraphics dCGraphics = DCGraphics.smethod_0(bitmap))
				{
					dCGraphics.PageUnit = OwnerDocument.DocumentGraphicsUnit;
					dCGraphics.TranslateTransform(0f - absBounds.Left, 0f - absBounds.Top);
					ShapeRenderEventArgs shapeRenderEventArgs = new ShapeRenderEventArgs();
					shapeRenderEventArgs.ClipRectangle = absBounds;
					shapeRenderEventArgs.DesignMode = false;
					shapeRenderEventArgs.Document = OwnerDocument;
					shapeRenderEventArgs.Element = this;
					shapeRenderEventArgs.Graphics = dCGraphics;
					shapeRenderEventArgs.Render = OwnerDocument.DocumentRender;
					shapeRenderEventArgs.Style = ShapeRenderStyle.Paint;
					shapeRenderEventArgs.ViewOptions = OwnerDocument.Options.ViewOptions;
					shapeRenderEventArgs.ZoomRate = 1f;
					vmethod_6(shapeRenderEventArgs);
				}
				return bitmap;
			}
			return null;
		}

		public virtual void vmethod_13(ShapeLabelEditEventArgs shapeLabelEditEventArgs_0)
		{
			shapeLabelEditEventArgs_0.Cancel = true;
		}

		public virtual void vmethod_14(ShapeLabelEditEventArgs shapeLabelEditEventArgs_0)
		{
			shapeLabelEditEventArgs_0.Cancel = true;
		}

		public virtual void vmethod_15()
		{
			if (OwnerDocument != null)
			{
				OwnerDocument.vmethod_22(this);
			}
		}

		public virtual void vmethod_16(ShapeFileFormat shapeFileFormat_0)
		{
		}

		object ICloneable.Clone()
		{
			return (ShapeElement)MemberwiseClone();
		}

		public virtual ShapeElement vmethod_17(bool bool_3)
		{
			return (ShapeElement)((ICloneable)this).Clone();
		}

		/// <summary>
		///       销毁对象
		///       </summary>
		public virtual void Dispose()
		{
		}
	}
}
