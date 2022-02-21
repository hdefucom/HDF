using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.WinForms;
using DCSoft.WinForms.Native;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       具有自定义绘制用户界面的输入域对象
	///       </summary>
	/// <remarks>
	///       派生的类型需要重载RefreshShapeState,DrawContent方法
	///       编制 袁永福
	///       </remarks>
	[Serializable]
	[Guid("00012345-6789-ABCD-EF01-234567890017")]
	[DocumentComment]
	
	public class XTextShapeInputFieldElement : XTextInputFieldElementBase
	{
		[NonSerialized]
		private bool bool_20 = false;

		private bool bool_21 = true;

		private ResizeableType resizeableType_0 = ResizeableType.WidthAndHeight;

		private bool bool_22 = true;

		private Rectangle rectangle_0 = Rectangle.Empty;

		/// <summary>
		///       运行时使用的垂直对齐方式
		///       </summary>
		[Browsable(false)]
		public virtual VerticalAlignStyle RuntimeVAlign => VerticalAlignStyle.Top;

		/// <summary>
		///       用户编辑文档内容模式
		///       </summary>
		[XmlIgnore]
		[DefaultValue(false)]
		public bool EditMode
		{
			get
			{
				if (Enabled)
				{
					return bool_20;
				}
				return false;
			}
			set
			{
				bool_20 = value;
			}
		}

		/// <summary>
		///       自动退出编辑内容模式
		///       </summary>
		/// <remarks>当光标离开输入域时自动设置元素为图形显示模式。</remarks>
		[DefaultValue(true)]
		public bool AutoExitEditMode
		{
			get
			{
				return bool_21;
			}
			set
			{
				bool_21 = value;
			}
		}

		/// <summary>
		///       是否允许用户编辑文档内容
		///       </summary>
		[Browsable(false)]
		public virtual bool EnableEditMode => true;

		/// <summary>
		///       对象中第一个文档元素对象
		///       </summary>
		[Browsable(false)]
		public override XTextElement FirstContentElement
		{
			get
			{
				if (EditMode)
				{
					return base.FirstContentElement;
				}
				return this;
			}
		}

		/// <summary>
		///       对象中最后一个文档元素对象
		///       </summary>
		[Browsable(false)]
		public override XTextElement LastContentElement
		{
			get
			{
				if (EditMode)
				{
					return base.LastContentElement;
				}
				return this;
			}
		}

		/// <summary>
		///       用户是否可以改变对象大小
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public virtual ResizeableType Resizeable
		{
			get
			{
				return resizeableType_0;
			}
			set
			{
				resizeableType_0 = value;
			}
		}

		/// <summary>
		///       对象是否可用,可以接受鼠标键盘事件
		///       </summary>
		[DefaultValue(true)]
		public bool Enabled
		{
			get
			{
				return bool_22;
			}
			set
			{
				bool_22 = value;
			}
		}

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
		///       初始化对象
		///       </summary>
		protected XTextShapeInputFieldElement()
		{
		}

		/// <summary>
		///       设置编辑模式
		///       </summary>
		/// <param name="mode">新的编辑模式</param>
		/// <param name="updateSelection">是否更新文档的选择区域</param>
		/// <returns>操作是否成功</returns>
		public virtual bool EditorSetEditMode(bool mode, bool updateSelection)
		{
			if (mode && !EnableEditMode)
			{
				return false;
			}
			if (EditMode != mode)
			{
				XTextDocumentContentElement documentContentElement = base.DocumentContentElement;
				bool flag = false;
				if (EditMode)
				{
					flag = Focused;
				}
				else if (documentContentElement.IsSelected(this) || documentContentElement.CurrentElement == this)
				{
					flag = true;
				}
				EditMode = mode;
				if (EditMode != mode)
				{
					return false;
				}
				int startIndex = documentContentElement.Selection.StartIndex;
				XTextElement currentElement = documentContentElement.CurrentElement;
				if (OwnerDocument.HighlightManager != null)
				{
					OwnerDocument.HighlightManager.imethod_9(this);
				}
				XTextContentElement contentElement = ContentElement;
				int num = 0;
				int num2 = 0;
				if (EditMode)
				{
					num = contentElement.PrivateContent.IndexOf(this);
					num2 = num + 1;
				}
				else
				{
					num = contentElement.PrivateContent.IndexOf(base.StartElement);
					num2 = contentElement.PrivateContent.IndexOf(base.EndElement);
				}
				if (!EditMode)
				{
					SizeInvalid = true;
					CheckShapeState(updateSize: true);
				}
				contentElement.vmethod_36(bool_22: true);
				contentElement.vmethod_38(num - 1, num2 + 1, bool_22: false);
				if (flag)
				{
					if (EditMode)
					{
						Focus();
					}
					else if (updateSelection)
					{
						documentContentElement.SetSelection(documentContentElement.Content.IndexOf(this), 0);
					}
				}
				else if (updateSelection)
				{
					int num3 = documentContentElement.Content.IndexOf(currentElement);
					if (num3 >= 0)
					{
						documentContentElement.SetSelection(num3, 0);
					}
					else
					{
						startIndex = documentContentElement.Content.FixElementIndex(startIndex);
						documentContentElement.SetSelection(startIndex, 0);
					}
				}
				return true;
			}
			return false;
		}

		/// <summary>
		///       获得输入焦点
		///       </summary>
		public override void Focus()
		{
			if (EditMode)
			{
				base.Focus();
				return;
			}
			XTextElement firstContentElement = FirstContentElement;
			if (firstContentElement != null)
			{
				int viewIndex = firstContentElement.ViewIndex;
				base.DocumentContentElement.Content.MoveToPosition(viewIndex);
			}
		}

		/// <summary>
		///       声明用户界面无效，需要重新绘制
		///       </summary>
		public override void InvalidateView()
		{
			if (EditMode)
			{
				base.InvalidateView();
			}
			else if (OwnerDocument != null)
			{
				OwnerDocument.method_69(this);
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int vmethod_32(XTextElementList xtextElementList_3, bool bool_23)
		{
			if (EditMode)
			{
				return base.vmethod_32(xtextElementList_3, bool_23);
			}
			CheckShapeState(updateSize: true);
			xtextElementList_3.Add(this);
			return 1;
		}

		public virtual GClass300 vmethod_44()
		{
			GClass300.int_0 = XTextObjectElement.int_6;
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

		/// <summary>
		///       绘制对象
		///       </summary>
		/// <param name="args">
		/// </param>
		public override void Draw(DocumentPaintEventArgs args)
		{
			if (EditMode)
			{
				base.Draw(args);
			}
			else if (args.RenderMode == DocumentRenderMode.PDF)
			{
				Image image = CreateContentImage();
				if (image != null && image.RawFormat.Guid != ImageFormat.Jpeg.Guid)
				{
					MemoryStream memoryStream = new MemoryStream();
					image.Save(memoryStream, ImageFormat.Jpeg);
					image.Dispose();
					image = null;
					memoryStream.Position = 0L;
					image = Image.FromStream(memoryStream);
				}
				args.Graphics.DrawImage(image, args.ViewBounds);
			}
			else
			{
				args.Render.vmethod_3(this, args);
				DrawContent(args);
				method_35(args);
				RectangleF absBounds = AbsBounds;
				absBounds.Width -= 1f;
				absBounds.Height -= 1f;
				args.Render.vmethod_2(this, args, absBounds);
			}
		}

		protected void method_35(DocumentPaintEventArgs documentPaintEventArgs_0)
		{
			if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Paint && documentPaintEventArgs_0.ActiveMode && ShowDragRect && Enabled)
			{
				GClass300 gClass = vmethod_44();
				gClass.method_9(new Rectangle((int)AbsLeft, (int)AbsTop, gClass.method_8().Width, gClass.method_8().Height));
				gClass.method_21(documentPaintEventArgs_0.Graphics);
			}
		}

		protected virtual GEnum72 vmethod_45(int int_14, int int_15)
		{
			return vmethod_44()?.method_23(int_14, int_15) ?? GEnum72.const_0;
		}

		public virtual void vmethod_46(DocumentEventArgs documentEventArgs_0)
		{
			EditorSetEditMode(!EditMode, updateSelection: true);
			documentEventArgs_0.Handled = true;
		}

		/// <summary>
		///       处理文档用户界面事件
		///       </summary>
		/// <param name="args">事件参数</param>
		public override void HandleDocumentEvent(DocumentEventArgs args)
		{
			if (args.Style == DocumentEventStyles.DefaultEditMethod)
			{
				vmethod_46(args);
			}
			else if (args.Style == DocumentEventStyles.MouseDown)
			{
				if (!Enabled || (OwnerDocument.EditorControl != null && OwnerDocument.EditorControl.MouseDragScroll) || EditMode)
				{
					return;
				}
				if (args.MouseClicks == 2)
				{
					vmethod_46(args);
				}
				else if (ShowDragRect)
				{
					GEnum72 gEnum = vmethod_45(args.X, args.Y);
					if (gEnum >= GEnum72.const_2)
					{
						method_36(gEnum);
						args.Handled = true;
						if (OwnerDocument.EditorControl != null)
						{
							OwnerDocument.EditorControl.UpdateTextCaret();
						}
					}
				}
				else
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
					args.Handled = true;
				}
			}
			else if (args.Style == DocumentEventStyles.MouseMove)
			{
				if (!Enabled || EditMode)
				{
					return;
				}
				if (ShowDragRect)
				{
					GClass300 gClass = vmethod_44();
					GEnum72 gEnum = gClass.method_23(args.X, args.Y);
					if (gEnum >= GEnum72.const_2)
					{
						args.Cursor = GClass300.smethod_6(gEnum);
						base.HandleDocumentEvent(args);
						return;
					}
				}
				args.Cursor = Cursors.Arrow;
			}
			else
			{
				base.HandleDocumentEvent(args);
			}
		}

		private bool method_36(GEnum72 genum72_0)
		{
			MouseCapturer mouseCapturer = new MouseCapturer(OwnerDocument.EditorControl.InnerViewControl);
			mouseCapturer.Tag = genum72_0;
			mouseCapturer.ReversibleShape = GEnum68.const_4;
			mouseCapturer.Draw += method_37;
			XTextDocumentContentElement documentContentElement = base.DocumentContentElement;
			if (mouseCapturer.method_1() && rectangle_0.Width > 0 && rectangle_0.Height > 0 && ((float)rectangle_0.Width != Width || (float)rectangle_0.Height != Height))
			{
				SizeF sizeF = new SizeF(Width, Height);
				InvalidateView();
				EditorSize = new SizeF(rectangle_0.Width, rectangle_0.Height);
				SizeInvalid = true;
				CheckShapeState(updateSize: true);
				vmethod_47();
				InvalidateView();
				documentContentElement.SetSelection(base.ViewIndex, 1);
				if (OwnerDocument.BeginLogUndo())
				{
					OwnerDocument.UndoList.AddProperty(GEnum18.const_2, sizeF, new SizeF(Width, Height), this);
					OwnerDocument.EndLogUndo();
				}
				ContentElement.method_31(ContentElement.PrivateContent.IndexOf(this));
				OwnerDocument.Modified = true;
				return true;
			}
			return false;
		}

		public virtual void vmethod_47()
		{
		}

		public override void OnViewLostFocus(ElementEventArgs elementEventArgs_0)
		{
			base.OnViewLostFocus(elementEventArgs_0);
			if (!AutoExitEditMode || !EditMode || elementEventArgs_0.WriterControl == null || !elementEventArgs_0.WriterControl.AbsoluteFocused)
			{
				return;
			}
			XTextElement currentElement = OwnerDocument.CurrentElement;
			if (EditorSetEditMode(mode: false, updateSelection: false))
			{
				int num = base.DocumentContentElement.Content.IndexOf(currentElement);
				if (num < 0)
				{
					num = base.DocumentContentElement.Content.IndexOf(this);
				}
				if (num >= 0)
				{
					base.DocumentContentElement.SetSelection(num, 0);
				}
			}
		}

		private void method_37(object sender, CaptureMouseMoveEventArgs e)
		{
			GEnum72 genum72_ = (GEnum72)e.method_2().Tag;
			Rectangle rectangle = Rectangle.Ceiling(AbsBounds);
			Point point_ = e.method_3();
			Point point_2 = e.method_5();
			SimpleRectangleTransform gClass = OwnerDocument.EditorControl.method_22(rectangle.Left, rectangle.Top);
			if (gClass != null)
			{
				point_ = gClass.TransformPoint(point_);
				point_2 = gClass.TransformPoint(point_2);
				rectangle = GClass300.smethod_4(point_2.X - point_.X, point_2.Y - point_.Y, genum72_, Rectangle.Ceiling(AbsBounds));
				if (rectangle.Width > (int)OwnerDocument.Width)
				{
					rectangle.Width = (int)OwnerDocument.Width;
				}
				rectangle_0 = rectangle;
				rectangle = gClass.vmethod_21(rectangle);
				using (GClass249 gClass2 = GClass249.smethod_0(OwnerDocument.EditorControl.InnerViewControl.Handle))
				{
					gClass2.method_21(GEnum64.const_2);
					gClass2.method_23(Color.Red);
					gClass2.DrawRectangle(rectangle);
				}
			}
		}

		/// <summary>
		///       检查状态
		///       </summary>
		/// <param name="updateSize">
		/// </param>
		public virtual void CheckShapeState(bool updateSize)
		{
		}

		/// <summary>
		///       计算对象大小
		///       </summary>
		/// <param name="args">参数</param>
		public override void RefreshSize(DocumentPaintEventArgs args)
		{
			SizeInvalid = true;
			CheckShapeState(updateSize: true);
			base.RefreshSize(args);
		}

		public override void vmethod_19(GClass103 gclass103_0)
		{
			if (EditMode)
			{
				base.vmethod_19(gclass103_0);
				return;
			}
			SizeF size = new SizeF(Width, Height);
			size = GraphicsUnitConvert.Convert(size, OwnerDocument.DocumentGraphicsUnit, GraphicsUnit.Pixel);
			using (Image image_ = base.CreateContentImage())
			{
				gclass103_0.method_45(image_, (int)size.Width, (int)size.Height, null, RuntimeStyle);
			}
		}
	}
}
