using DCSoft.Drawing;
using DCSoft.ShapeEditor;
using DCSoft.ShapeEditor.Dom;
using DCSoft.WinForms.Native;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ToolboxItem(false)]
	[ComVisible(false)]
	[DefaultEvent("SelectionChanged")]
	public class GControl9 : UserControl
	{
		private bool bool_0 = true;

		private GraphicsUnit graphicsUnit_0 = GraphicsUnit.Document;

		private ShapeDocument shapeDocument_0 = null;

		private GClass333 gclass333_0 = null;

		private ShapeContainerElement shapeContainerElement_0 = null;

		private GClass331 gclass331_0 = new GClass331();

		private float float_0 = 1f;

		private float float_1 = 1f;

		private bool bool_1 = true;

		private ContentStyle contentStyle_0 = null;

		private GClass332 gclass332_0 = new GClass332();

		private ShapeLabelEditEventArgs shapeLabelEditEventArgs_0 = null;

		private EventHandler eventHandler_0 = null;

		private EventHandler eventHandler_1 = null;

		public GControl9()
		{
			AutoScroll = true;
			DoubleBuffered = true;
		}

		protected override void Dispose(bool disposing)
		{
			if (shapeDocument_0 != null && shapeDocument_0.EditorControl == this)
			{
				shapeDocument_0.EditorControl = null;
			}
			base.Dispose(disposing);
		}

		public bool method_0()
		{
			return bool_0;
		}

		public void method_1(bool bool_2)
		{
			bool_0 = bool_2;
		}

		public GraphicsUnit method_2()
		{
			return graphicsUnit_0;
		}

		public void method_3(GraphicsUnit graphicsUnit_1)
		{
			graphicsUnit_0 = graphicsUnit_1;
		}

		public ShapeDocument method_4()
		{
			if (shapeDocument_0 == null)
			{
				shapeDocument_0 = new ShapeDocument();
			}
			shapeDocument_0.EditorControl = this;
			shapeDocument_0.EditMode = method_0();
			return shapeDocument_0;
		}

		public void method_5(ShapeDocument shapeDocument_1)
		{
			shapeDocument_0 = shapeDocument_1;
			if (shapeDocument_0 != null)
			{
				shapeDocument_0.EditorControl = this;
				shapeDocument_0.DefaultFont = new XFontValue(Font);
				shapeDocument_0.EditMode = method_0();
			}
		}

		public ShapeElement method_6()
		{
			if (method_12() == null)
			{
				return null;
			}
			return method_12().CurrentElement;
		}

		public ContentStyle method_7()
		{
			if (method_4() != null)
			{
				ShapeElement shapeElement = method_6();
				if (shapeElement != null)
				{
					return shapeElement.RuntimeStyle;
				}
				return method_4().ContentStyles.Default;
			}
			return null;
		}

		public GClass333 method_8()
		{
			if (gclass333_0 == null)
			{
				gclass333_0 = new GClass333();
			}
			gclass333_0.method_1(method_4());
			gclass333_0.method_3(this);
			return gclass333_0;
		}

		public void method_9(GClass333 gclass333_1)
		{
			gclass333_0 = gclass333_1;
		}

		public ShapeContainerElement method_10()
		{
			if (method_4() == null)
			{
				return null;
			}
			if (shapeContainerElement_0 == null)
			{
				if (method_4().Pages.Count > 0)
				{
					return (ShapeDocumentPage)method_4().Pages[0];
				}
				return method_4();
			}
			return shapeContainerElement_0;
		}

		public void method_11(ShapeContainerElement shapeContainerElement_1)
		{
			int num = 8;
			if (shapeContainerElement_1 != null && shapeContainerElement_1.OwnerDocument != method_4())
			{
				throw new ArgumentException("Bad RootElement document");
			}
			shapeContainerElement_0 = shapeContainerElement_1;
		}

		public ShapeDocumentPage method_12()
		{
			if (method_10() == null)
			{
				return null;
			}
			return method_10().OwnerPage;
		}

		public GClass331 method_13()
		{
			if (gclass331_0 == null)
			{
				gclass331_0 = new GClass331();
			}
			return gclass331_0;
		}

		public void method_14(GClass331 gclass331_1)
		{
			gclass331_0 = gclass331_1;
		}

		public float method_15()
		{
			if (float_0 < 0.01f)
			{
				float_0 = 0.01f;
			}
			return float_0;
		}

		public void method_16(float float_2)
		{
			if (float_2 > 0.01f)
			{
				float_0 = float_2;
			}
		}

		public float method_17()
		{
			if (float_1 < 0.01f)
			{
				float_1 = 0.01f;
			}
			return float_1;
		}

		public void method_18(float float_2)
		{
			if (float_2 > 0.01f)
			{
				float_1 = float_2;
			}
		}

		protected override void OnLoad(EventArgs eventArgs_0)
		{
			base.OnLoad(eventArgs_0);
			if (!base.DesignMode)
			{
				method_36().method_5(typeof(ShapeRectangleElement), new GClass321());
				method_36().method_5(typeof(ShapeEllipseElement), new GClass322());
				method_36().method_5(typeof(ShapeLineElement), new GClass326());
				method_36().method_5(typeof(ShapePolygonElement), new GClass327());
				method_36().method_5(typeof(ShapeLinesElement), new GClass325());
				method_36().method_5(typeof(ShapeWireLabelElement), new GClass324());
				method_36().method_5(typeof(ShapeZoomInElement), new GClass323());
			}
		}

		public void method_19()
		{
			if (method_10() != null)
			{
				SizeF size = new SizeF(method_10().Width, method_10().Height);
				size = GraphicsUnitConvert.Convert(size, method_2(), GraphicsUnit.Pixel);
				size.Width *= method_15();
				size.Height *= method_17();
				base.AutoScrollMinSize = new Size((int)size.Width + 15, (int)size.Height + 15);
			}
			else
			{
				base.AutoScrollMinSize = Size.Empty;
			}
		}

		public void method_20()
		{
			if (method_4() != null)
			{
				using (Graphics graphics = CreateGraphics())
				{
					graphics.PageUnit = method_4().DocumentGraphicsUnit;
					method_4().vmethod_3(new DCGraphics(graphics));
				}
			}
			method_19();
			Invalidate();
		}

		public RectangleF method_21(Rectangle rectangle_0)
		{
			PointF location = method_23(rectangle_0.Location);
			SizeF size = GraphicsUnitConvert.Convert(new SizeF(rectangle_0.Width, rectangle_0.Height), GraphicsUnit.Pixel, method_2());
			size.Width /= method_15();
			size.Height /= method_17();
			return new RectangleF(location, size);
		}

		public Rectangle method_22(RectangleF rectangleF_0)
		{
			Point point = method_27(rectangleF_0.Location);
			SizeF sizeF = GraphicsUnitConvert.Convert(rectangleF_0.Size, method_2(), GraphicsUnit.Pixel);
			return new Rectangle(point.X, point.Y, (int)(sizeF.Width * method_15()), (int)(sizeF.Height * method_17()));
		}

		public PointF method_23(Point point_0)
		{
			point_0.X -= base.AutoScrollPosition.X;
			point_0.Y -= base.AutoScrollPosition.Y;
			PointF pointF = GraphicsUnitConvert.Convert(new PointF(point_0.X, point_0.Y), GraphicsUnit.Pixel, method_2());
			PointF result = new PointF(pointF.X / method_15(), pointF.Y / method_17());
			if (method_10() != null)
			{
				PointF absLocation = method_10().AbsLocation;
				result.X += absLocation.X;
				result.Y += absLocation.Y;
			}
			return result;
		}

		public PointF method_24(int int_0, int int_1)
		{
			return method_23(new Point(int_0, int_1));
		}

		public SizeF method_25(Size size_0)
		{
			SizeF size = new SizeF(size_0.Width, size_0.Height);
			size = GraphicsUnitConvert.Convert(size, GraphicsUnit.Pixel, method_2());
			size.Width /= method_15();
			size.Height /= method_17();
			return size;
		}

		public Size method_26(SizeF sizeF_0)
		{
			SizeF sizeF = GraphicsUnitConvert.Convert(sizeF_0, method_2(), GraphicsUnit.Pixel);
			sizeF.Width *= method_15();
			sizeF.Height *= method_17();
			return new Size((int)sizeF.Width, (int)sizeF.Height);
		}

		public Point method_27(PointF pointF_0)
		{
			if (method_10() != null)
			{
				PointF absLocation = method_10().AbsLocation;
				pointF_0.X -= absLocation.X;
				pointF_0.Y -= absLocation.Y;
			}
			pointF_0 = GraphicsUnitConvert.Convert(pointF_0, method_2(), GraphicsUnit.Pixel);
			pointF_0.X *= method_15();
			pointF_0.Y *= method_17();
			pointF_0.X += base.AutoScrollPosition.X;
			pointF_0.Y += base.AutoScrollPosition.Y;
			return new Point((int)pointF_0.X, (int)pointF_0.Y);
		}

		public PointF method_28(PointF pointF_0, ShapeElement shapeElement_0)
		{
			int num = 2;
			if (shapeElement_0 == null)
			{
				throw new ArgumentNullException("element");
			}
			PointF absLocation = shapeElement_0.AbsLocation;
			return new PointF(pointF_0.X - absLocation.X, pointF_0.Y - absLocation.Y);
		}

		public PointF method_29(float float_2, float float_3, ShapeElement shapeElement_0)
		{
			int num = 1;
			if (shapeElement_0 == null)
			{
				throw new ArgumentNullException("element");
			}
			PointF absLocation = shapeElement_0.AbsLocation;
			return new PointF(float_2 - absLocation.X, float_3 - absLocation.Y);
		}

		public virtual void vmethod_0(RectangleF rectangleF_0)
		{
			if (!rectangleF_0.IsEmpty)
			{
				Invalidate(method_22(rectangleF_0));
			}
		}

		public bool method_30()
		{
			return bool_1;
		}

		public void method_31(bool bool_2)
		{
			bool_1 = bool_2;
		}

		public ShapeElement method_32(int int_0, int int_1)
		{
			if (method_10() != null)
			{
				PointF pointF = method_24(int_0, int_1);
				PointF absLocation = method_10().AbsLocation;
				ShapeElement shapeElement = method_10().method_2(pointF.X - absLocation.X, pointF.Y - absLocation.Y);
				if (shapeElement == null)
				{
					shapeElement = method_10();
				}
				return shapeElement;
			}
			return null;
		}

		public virtual void vmethod_1(Type type_0)
		{
			Class187.smethod_0(type_0);
			method_36().method_1(method_36().method_6(type_0));
			if (method_36().method_0() == null)
			{
				throw new NotSupportedException(type_0.FullName);
			}
			method_36().method_0().method_1(this);
			method_36().method_0().method_3(method_4());
			method_36().method_0().vmethod_0();
			Cursor = Cursors.Cross;
		}

		public ContentStyle method_33()
		{
			return contentStyle_0;
		}

		public void method_34(ContentStyle contentStyle_1)
		{
			contentStyle_0 = contentStyle_1;
		}

		public int method_35()
		{
			ContentStyle contentStyle = null;
			if (contentStyle_0 != null)
			{
				contentStyle = contentStyle_0.Clone();
			}
			if (contentStyle == null && method_7() != null)
			{
				contentStyle = method_7().Clone();
			}
			if (contentStyle == null)
			{
				return -1;
			}
			return method_4().ContentStyles.GetStyleIndex(contentStyle);
		}

		public virtual void vmethod_2()
		{
			vmethod_7();
		}

		public GClass332 method_36()
		{
			if (gclass332_0 == null)
			{
				gclass332_0 = new GClass332();
			}
			return gclass332_0;
		}

		public void method_37(GClass332 gclass332_1)
		{
			gclass332_0 = gclass332_1;
		}

		public Type method_38()
		{
			if (method_36().method_0() != null)
			{
				return method_36().method_0().method_6();
			}
			return null;
		}

		private ShapeElementList method_39(ShapeElement shapeElement_0)
		{
			ShapeElementList shapeElementList = new ShapeElementList();
			while (shapeElement_0 != null)
			{
				shapeElementList.Add(shapeElement_0);
				if (shapeElement_0 == method_10())
				{
					break;
				}
				shapeElement_0 = shapeElement_0.Parent;
			}
			return shapeElementList;
		}

		protected override void OnMouseDown(MouseEventArgs mevent)
		{
			vmethod_3();
			method_44(mevent, GEnum28.const_0);
			base.OnMouseDown(mevent);
		}

		protected override void OnMouseMove(MouseEventArgs mevent)
		{
			method_44(mevent, GEnum28.const_1);
			base.OnMouseMove(mevent);
		}

		protected override void OnMouseUp(MouseEventArgs mevent)
		{
			method_44(mevent, GEnum28.const_2);
			base.OnMouseUp(mevent);
		}

		protected override void OnMouseClick(MouseEventArgs mouseEventArgs_0)
		{
			base.OnMouseClick(mouseEventArgs_0);
		}

		protected override void OnDoubleClick(EventArgs eventArgs_0)
		{
			base.OnDoubleClick(eventArgs_0);
		}

		protected override void OnMouseDoubleClick(MouseEventArgs mouseEventArgs_0)
		{
			method_44(mouseEventArgs_0, GEnum28.const_4);
			base.OnMouseDoubleClick(mouseEventArgs_0);
		}

		public bool method_40(ShapeElement shapeElement_0)
		{
			int num = 4;
			if (shapeElement_0 == null)
			{
				throw new ArgumentNullException("element");
			}
			ShapeLabelEditEventArgs shapeLabelEditEventArgs = new ShapeLabelEditEventArgs();
			shapeLabelEditEventArgs.Document = method_4();
			shapeLabelEditEventArgs.Element = shapeElement_0;
			shapeLabelEditEventArgs.Cancel = true;
			shapeLabelEditEventArgs.ContentStyle = shapeElement_0.RuntimeStyle;
			shapeElement_0.vmethod_13(shapeLabelEditEventArgs);
			if (shapeLabelEditEventArgs.Cancel)
			{
				return false;
			}
			shapeLabelEditEventArgs_0 = shapeLabelEditEventArgs;
			RectangleF rectangleF_ = shapeLabelEditEventArgs.EditAreaBounds;
			if (rectangleF_.IsEmpty)
			{
				rectangleF_ = shapeElement_0.AbsBounds;
			}
			Rectangle bounds = method_22(rectangleF_);
			if (shapeLabelEditEventArgs.EditorControl == null)
			{
				ContentStyle contentStyle = shapeLabelEditEventArgs.ContentStyle;
				if (contentStyle == null)
				{
					contentStyle = shapeElement_0.RuntimeStyle;
				}
				if (shapeLabelEditEventArgs.ControlType == LabelEditorControlType.TextBox)
				{
					TextBox textBox = new TextBox();
					textBox.Text = shapeLabelEditEventArgs.Text;
					XFontValue xFontValue = contentStyle.Font.Clone();
					if (!method_4().AutoZoomFontSize)
					{
						xFontValue.Size *= method_17();
					}
					textBox.Font = xFontValue.Value;
					textBox.ForeColor = Color.FromArgb(255, contentStyle.Color);
					if (contentStyle.BackgroundColor.A != 0)
					{
						textBox.BackColor = Color.FromArgb(255, contentStyle.BackgroundColor);
					}
					textBox.Multiline = contentStyle.Multiline;
					if (contentStyle.Align == DocumentContentAlignment.Center || contentStyle.Align == DocumentContentAlignment.Justify)
					{
						textBox.TextAlign = HorizontalAlignment.Center;
					}
					else if (contentStyle.Align == DocumentContentAlignment.Left)
					{
						textBox.TextAlign = HorizontalAlignment.Left;
					}
					else if (contentStyle.Align == DocumentContentAlignment.Right)
					{
						textBox.TextAlign = HorizontalAlignment.Right;
					}
					if (contentStyle.HasVisibleBorder)
					{
						textBox.BorderStyle = BorderStyle.FixedSingle;
					}
					else
					{
						textBox.BorderStyle = BorderStyle.None;
					}
					textBox.Bounds = bounds;
					if (textBox.Height != bounds.Height)
					{
						textBox.Top = bounds.Top + (bounds.Height - textBox.Height) / 2;
					}
					base.Controls.Add(textBox);
					shapeLabelEditEventArgs.EditorControl = textBox;
					textBox.Tag = shapeLabelEditEventArgs;
					textBox.Focus();
					textBox.LostFocus += method_42;
					textBox.KeyDown += method_41;
					shapeLabelEditEventArgs.EditorControl = textBox;
				}
			}
			return true;
		}

		public virtual bool vmethod_3()
		{
			ShapeLabelEditEventArgs shapeLabelEditEventArgs = shapeLabelEditEventArgs_0;
			shapeLabelEditEventArgs_0 = null;
			if (shapeLabelEditEventArgs != null)
			{
				bool flag = false;
				if (shapeLabelEditEventArgs.EditorControl is TextBox)
				{
					TextBox textBox = (TextBox)shapeLabelEditEventArgs.EditorControl;
					ShapeElement element = shapeLabelEditEventArgs.Element;
					shapeLabelEditEventArgs.NewText = textBox.Text;
					shapeLabelEditEventArgs.Cancel = false;
					element.vmethod_14(shapeLabelEditEventArgs);
					flag = !shapeLabelEditEventArgs.Cancel;
				}
				if (shapeLabelEditEventArgs.EditorControl != null)
				{
					base.Controls.Remove(shapeLabelEditEventArgs.EditorControl);
					shapeLabelEditEventArgs.EditorControl.Dispose();
				}
				if (flag)
				{
					using (DCGraphics dcgraphics_ = method_4().vmethod_21())
					{
						shapeLabelEditEventArgs.Element.vmethod_3(dcgraphics_);
					}
					shapeLabelEditEventArgs.Element.vmethod_15();
					Update();
					shapeLabelEditEventArgs.Element.vmethod_15();
				}
				shapeLabelEditEventArgs = null;
				return flag;
			}
			return false;
		}

		public virtual bool vmethod_4()
		{
			ShapeLabelEditEventArgs shapeLabelEditEventArgs = shapeLabelEditEventArgs_0;
			shapeLabelEditEventArgs_0 = null;
			if (shapeLabelEditEventArgs != null)
			{
				if (shapeLabelEditEventArgs.EditorControl != null)
				{
					base.Controls.Remove(shapeLabelEditEventArgs.EditorControl);
					shapeLabelEditEventArgs.EditorControl.Dispose();
				}
				shapeLabelEditEventArgs = null;
				return true;
			}
			return false;
		}

		private void method_41(object sender, KeyEventArgs e)
		{
			if (sender is TextBox)
			{
				TextBox textBox = (TextBox)sender;
				if (e.KeyCode == Keys.Return && !textBox.Multiline)
				{
					vmethod_3();
				}
				else if (e.KeyCode == Keys.Escape)
				{
					vmethod_4();
				}
			}
		}

		private void method_42(object sender, EventArgs e)
		{
			vmethod_3();
		}

		public GClass249 method_43()
		{
			GClass249 gClass = GClass249.smethod_0(base.Handle);
			gClass.method_21(GEnum64.const_2);
			gClass.method_23(Color.Red);
			return gClass;
		}

		private void method_44(MouseEventArgs mouseEventArgs_0, GEnum28 genum28_0)
		{
			if (method_10() == null)
			{
				return;
			}
			ShapeMouseEventArgs shapeMouseEventArgs = new ShapeMouseEventArgs();
			PointF pointF = method_24(mouseEventArgs_0.X, mouseEventArgs_0.Y);
			shapeMouseEventArgs.ClientX = mouseEventArgs_0.X;
			shapeMouseEventArgs.ClientY = mouseEventArgs_0.Y;
			shapeMouseEventArgs.X = pointF.X;
			shapeMouseEventArgs.Y = pointF.Y;
			shapeMouseEventArgs.Button = mouseEventArgs_0.Button;
			shapeMouseEventArgs.Clicks = mouseEventArgs_0.Clicks;
			shapeMouseEventArgs.Delta = mouseEventArgs_0.Delta;
			if (method_36().method_0() != null)
			{
				method_36().method_0().method_3(method_10().OwnerDocument);
				method_36().method_0().method_1(this);
				if (!method_36().method_0().method_12() && genum28_0 == GEnum28.const_0)
				{
					method_36().method_0().method_5(null);
					ShapeElement shapeElement = method_32(mouseEventArgs_0.X, mouseEventArgs_0.Y);
					if (shapeElement != null)
					{
						ShapeContainerElement shapeContainerElement = null;
						if (shapeElement is ShapeContainerElement)
						{
							shapeContainerElement = (ShapeContainerElement)shapeElement;
						}
						while (shapeContainerElement != null)
						{
							if (!method_8().vmethod_1(shapeContainerElement, method_36().method_0().method_6()))
							{
								shapeContainerElement = shapeContainerElement.Parent;
								continue;
							}
							method_36().method_0().method_5(shapeContainerElement);
							break;
						}
					}
				}
				if (method_36().method_0().method_4() != null)
				{
					GEnum75 gEnum = GEnum75.const_1;
					switch (genum28_0)
					{
					case GEnum28.const_0:
						gEnum = method_36().method_0().vmethod_1(shapeMouseEventArgs);
						break;
					case GEnum28.const_1:
						gEnum = method_36().method_0().vmethod_2(shapeMouseEventArgs);
						break;
					case GEnum28.const_2:
						gEnum = method_36().method_0().vmethod_3(shapeMouseEventArgs);
						break;
					}
					switch (gEnum)
					{
					case GEnum75.const_1:
						break;
					default:
						vmethod_7();
						break;
					case GEnum75.const_2:
						vmethod_6();
						break;
					}
				}
			}
			else
			{
				if (!method_30())
				{
					return;
				}
				GEnum76 gEnum2 = GEnum76.const_0;
				ShapeDocumentPage ownerPage = method_10().OwnerPage;
				foreach (ShapeElement item in ownerPage.Selection)
				{
					GClass330 gClass = item.vmethod_4();
					PointF pointF2 = method_29(pointF.X, pointF.Y, item);
					float runtimeControlPointSize = item.OwnerDocument.Options.ViewOptions.RuntimeControlPointSize;
					GClass329 gClass2 = null;
					if (gClass != null && gClass.Count > 0)
					{
						foreach (GClass329 item2 in gClass)
						{
							if (item2.method_14(pointF2.X, pointF2.Y, runtimeControlPointSize) && item2.method_8())
							{
								Cursor = item2.method_10();
								gClass2 = item2;
								gEnum2 = GEnum76.const_1;
								break;
							}
						}
					}
					if (genum28_0 == GEnum28.const_0 && mouseEventArgs_0.Button == MouseButtons.Left)
					{
						if (gClass2 == null)
						{
							GClass328 gClass3 = new GClass328();
							gClass3.method_1(pointF.X);
							gClass3.method_3(pointF.Y);
							gClass3.method_5(pointF2.X);
							gClass3.method_7(pointF2.Y);
							item.vmethod_1(gClass3);
							if (gClass3.method_8() == GEnum73.const_2)
							{
								gEnum2 = GEnum76.const_2;
							}
							else if (gClass3.method_8() == GEnum73.const_1)
							{
								gEnum2 = GEnum76.const_3;
							}
						}
						if (gEnum2 != 0 && MouseCapturer.DragDetect(base.Handle))
						{
							MouseCapturer mouseCapturer = new MouseCapturer(this);
							mouseCapturer.InitStartPosition = new Point(mouseEventArgs_0.X, mouseEventArgs_0.Y);
							GEventArgs11 gEventArgs = new GEventArgs11();
							gEventArgs.method_5(gClass2);
							gEventArgs.method_1(gEnum2);
							gEventArgs.method_7(this);
							gEventArgs.method_13(mouseCapturer);
							gEventArgs.method_9(pointF);
							gEventArgs.method_11(new Point(mouseEventArgs_0.X, mouseEventArgs_0.Y));
							gEventArgs.method_15(method_43());
							item.vmethod_2(gEventArgs);
							gEventArgs.method_14().Dispose();
							return;
						}
					}
					if (gClass2 != null)
					{
						Cursor = gClass2.method_10();
						return;
					}
				}
				Cursor = DefaultCursor;
				ShapeElement shapeElement2 = method_32(mouseEventArgs_0.X, mouseEventArgs_0.Y);
				if (shapeElement2 != null)
				{
					ShapeDocumentPage ownerPage2 = shapeElement2.OwnerPage;
					if (genum28_0 == GEnum28.const_0 && mouseEventArgs_0.Button == MouseButtons.Left)
					{
						ownerPage2.method_5(shapeElement2, bool_4: true);
					}
					ShapeElementList shapeElementList = method_39(shapeElement2);
					foreach (ShapeElement item3 in shapeElementList)
					{
						PointF pointF3 = method_28(pointF, item3);
						shapeMouseEventArgs.X = pointF3.X;
						shapeMouseEventArgs.Y = pointF3.Y;
						switch (genum28_0)
						{
						case GEnum28.const_0:
							item3.vmethod_9(shapeMouseEventArgs);
							break;
						case GEnum28.const_1:
							item3.vmethod_8(shapeMouseEventArgs);
							break;
						case GEnum28.const_2:
							item3.vmethod_10(shapeMouseEventArgs);
							break;
						}
						if (shapeMouseEventArgs.Handled)
						{
							break;
						}
					}
					if (!shapeMouseEventArgs.Handled && genum28_0 == GEnum28.const_0 && mouseEventArgs_0.Clicks == 2)
					{
						method_40(shapeElement2);
					}
				}
			}
		}

		protected override void OnKeyDown(KeyEventArgs kevent)
		{
			if (method_10() != null && method_36().method_0() != null)
			{
				switch (method_36().method_0().vmethod_4(kevent))
				{
				case GEnum75.const_3:
					vmethod_7();
					break;
				case GEnum75.const_2:
					vmethod_6();
					break;
				}
			}
			base.OnKeyDown(kevent);
		}

		protected override void OnKeyPress(KeyPressEventArgs keyPressEventArgs_0)
		{
			if (method_10() != null && method_36().method_0() != null)
			{
				switch (method_36().method_0().vmethod_5(keyPressEventArgs_0))
				{
				case GEnum75.const_3:
					vmethod_7();
					break;
				case GEnum75.const_2:
					vmethod_6();
					break;
				}
			}
			base.OnKeyPress(keyPressEventArgs_0);
		}

		public virtual bool vmethod_5(ShapeElement shapeElement_0)
		{
			if (shapeElement_0 != null)
			{
				method_10().Elements.Add(shapeElement_0);
				shapeElement_0.Parent = method_10();
				shapeElement_0.OwnerDocument = method_4();
				method_12().method_5(shapeElement_0, bool_4: true);
				method_4().Modified = true;
				method_4().method_6();
				method_4().vmethod_24(EventArgs.Empty);
				return true;
			}
			return false;
		}

		protected virtual void vmethod_6()
		{
			if (method_36().method_0() != null && method_36().method_0().method_10() != null)
			{
				ShapeElement shapeElement = method_36().method_0().method_10();
				shapeElement.StyleIndex = method_35();
				method_36().method_0().method_4().vmethod_19(shapeElement);
				method_36().method_0().method_4().vmethod_15();
				method_36().method_0().method_5(null);
				method_36().method_1(null);
				method_12().method_5(shapeElement, bool_4: true);
				method_4().Modified = true;
				method_4().method_6();
				method_4().vmethod_24(EventArgs.Empty);
			}
			Cursor = DefaultCursor;
		}

		protected virtual void vmethod_7()
		{
			if (method_36().method_0() != null)
			{
				method_36().method_0().method_5(null);
			}
			method_36().method_1(null);
			Cursor = Cursors.Default;
			Invalidate();
		}

		protected override void OnPaint(PaintEventArgs pevent)
		{
			int num = 13;
			RectangleF layoutRectangle;
			if (base.DesignMode)
			{
				layoutRectangle = new RectangleF(0f, 0f, base.ClientSize.Width, base.ClientSize.Height);
				using (StringFormat stringFormat = new StringFormat())
				{
					stringFormat.Alignment = StringAlignment.Center;
					stringFormat.LineAlignment = StringAlignment.Center;
					pevent.Graphics.DrawString(base.Name + Environment.NewLine + GetType().FullName + Environment.NewLine + "Version : " + base.ProductVersion, Font, Brushes.Red, layoutRectangle, stringFormat);
				}
			}
			else if (method_10() == null)
			{
				layoutRectangle = new RectangleF(0f, 0f, base.ClientSize.Width, base.ClientSize.Height);
				using (StringFormat stringFormat = new StringFormat())
				{
					stringFormat.Alignment = StringAlignment.Center;
					stringFormat.LineAlignment = StringAlignment.Center;
					pevent.Graphics.DrawString(ResourceStrings.NoDocument, Font, Brushes.Red, layoutRectangle, stringFormat);
				}
			}
			else
			{
				ShapeRenderEventArgs shapeRenderEventArgs = new ShapeRenderEventArgs();
				shapeRenderEventArgs.Document = method_4();
				shapeRenderEventArgs.Element = method_10();
				shapeRenderEventArgs.Graphics = new DCGraphics(pevent.Graphics);
				RectangleF clipRectangle = method_21(new Rectangle(pevent.ClipRectangle.Left - 1, pevent.ClipRectangle.Top - 1, pevent.ClipRectangle.Width + 2, pevent.ClipRectangle.Height + 2));
				clipRectangle.Width += 5f;
				clipRectangle.Height += 5f;
				shapeRenderEventArgs.ClipRectangle = clipRectangle;
				shapeRenderEventArgs.Document.DocumentRender = method_13();
				shapeRenderEventArgs.Render = method_13();
				shapeRenderEventArgs.DesignMode = method_30();
				shapeRenderEventArgs.ViewOptions = method_4().Options.ViewOptions;
				shapeRenderEventArgs.ViewOptions.RuntimeControlPointSize = (float)GraphicsUnitConvert.Convert(shapeRenderEventArgs.ViewOptions.ControlPointPixelSize, GraphicsUnit.Pixel, method_2()) / method_15();
				PointF pointF = method_23(new Point(0, 0));
				shapeRenderEventArgs.Graphics.ScaleTransform(method_15(), method_17());
				shapeRenderEventArgs.Graphics.TranslateTransform(0f - pointF.X, 0f - pointF.Y);
				shapeRenderEventArgs.Graphics.PageUnit = shapeRenderEventArgs.Document.DocumentGraphicsUnit;
				shapeRenderEventArgs.ZoomRate = method_15();
				method_10().vmethod_6(shapeRenderEventArgs);
			}
			base.OnPaint(pevent);
		}

		public bool method_45()
		{
			if (method_12() != null)
			{
				return method_12().method_6();
			}
			return false;
		}

		public ShapeSelection method_46()
		{
			if (method_12() == null)
			{
				return null;
			}
			return method_12().Selection;
		}

		public void method_47(EventHandler eventHandler_2)
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value = (EventHandler)Delegate.Combine(eventHandler2, eventHandler_2);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}

		public void method_48(EventHandler eventHandler_2)
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value = (EventHandler)Delegate.Remove(eventHandler2, eventHandler_2);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}

		public virtual void vmethod_8(EventArgs eventArgs_0)
		{
			if (method_46() != null)
			{
				foreach (ShapeElement item in method_46())
				{
					if (item != method_10())
					{
						method_34(item.RuntimeStyle.Clone());
					}
				}
			}
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, eventArgs_0);
			}
		}

		public void method_49(EventHandler eventHandler_2)
		{
			EventHandler eventHandler = eventHandler_1;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value = (EventHandler)Delegate.Combine(eventHandler2, eventHandler_2);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}

		public void method_50(EventHandler eventHandler_2)
		{
			EventHandler eventHandler = eventHandler_1;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value = (EventHandler)Delegate.Remove(eventHandler2, eventHandler_2);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}

		public virtual void vmethod_9(EventArgs eventArgs_0)
		{
			method_19();
			if (eventHandler_1 != null)
			{
				eventHandler_1(this, eventArgs_0);
			}
		}

		public bool method_51()
		{
			if (method_4() == null)
			{
				return false;
			}
			return method_4().Modified;
		}

		public void method_52(bool bool_2)
		{
			if (method_4() != null)
			{
				method_4().Modified = bool_2;
			}
		}

		public Graphics method_53()
		{
			Graphics graphics = CreateGraphics();
			graphics.PageUnit = method_2();
			return graphics;
		}
	}
}
