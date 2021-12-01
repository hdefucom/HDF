using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.FriedmanCurveChart;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[DCInternal]
	[ToolboxItem(false)]
	[ComVisible(false)]
	public class GControl2 : UserControl
	{
		private const string string_0 = "都昌产程图控件(DCFriedmanCurve)，是南京都昌信息科技有限公司开发的医疗行业使用的产程图控件，适用于.NET平台。南京都昌信息科技有限公司专业研发医学数据可视化技术，并自主研发了电子病历编辑器软件、产程图控件等等，公司网址 www.dcwriter.cn。";

		private bool bool_0 = false;

		private GClass17 gclass17_0 = null;

		private Enum19 enum19_0 = Enum19.const_0;

		private bool bool_1 = true;

		private bool bool_2 = false;

		private FCDocumentViewMode fcdocumentViewMode_0 = FCDocumentViewMode.Page;

		private int int_0 = 0;

		private FriedmanCurveDocument friedmanCurveDocument_0 = null;

		private FCValuePointClickEventHandler fcvaluePointClickEventHandler_0 = null;

		private bool bool_3 = true;

		private RectangleF rectangleF_0 = RectangleF.Empty;

		private GEnum23 genum23_0 = GEnum23.const_2;

		private SimpleRectangleTransform gclass435_0 = null;

		private int int_1 = 0;

		private Class166 class166_0 = null;

		private FCEditValuePointEventHandler fceditValuePointEventHandler_0 = null;

		private FriedmanCurveZoneEventHandler friedmanCurveZoneEventHandler_0 = null;

		private FriedmanCurveZoneEventHandler friedmanCurveZoneEventHandler_1 = null;

		private EventHandler eventHandler_0 = null;

		private Point point_0 = Point.Empty;

		private Point point_1 = Point.Empty;

		private Point point_2 = Point.Empty;

		private long long_0 = 0L;

		private ToolTip toolTip_0 = null;

		private EventHandler eventHandler_1 = null;

		private EventHandler eventHandler_2 = null;

		public GControl2()
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, value: true);
		}

		private bool method_0()
		{
			return bool_0;
		}

		private GClass17 method_1()
		{
			if (gclass17_0 == null)
			{
				gclass17_0 = new GClass17(this);
			}
			return gclass17_0;
		}

		public void method_2()
		{
			if (!base.IsHandleCreated)
			{
				return;
			}
			if (!FriedmanCurveDocument.smethod_4(method_14().CaretDateTime))
			{
				if (method_14().DataGridBounds.Height > 0f)
				{
					if (method_14().CaretDateTime >= method_14().RuntimeTicks.method_0() && method_14().CaretDateTime <= method_14().RuntimeTicks.method_2())
					{
						bool_0 = method_1().Create(0, 5, (int)method_14().method_1(method_14().DataGridBounds.Height));
						float float_ = method_14().RuntimeTicks.method_16(method_14().DataGridBounds, method_14().CaretDateTime);
						float top = method_14().DataGridBounds.Top;
						Point point = method_30(float_, top);
						method_1().SetPos(point.X, point.Y);
						method_1().Show();
					}
					else
					{
						method_1().Hide();
					}
				}
			}
			else if (method_0())
			{
				method_1().Hide();
			}
		}

		private FriedmanCurveControl method_3()
		{
			return base.Parent as FriedmanCurveControl;
		}

		internal Enum19 method_4()
		{
			return enum19_0;
		}

		internal void method_5(Enum19 enum19_1)
		{
			enum19_0 = enum19_1;
		}

		public bool method_6()
		{
			return bool_1;
		}

		public void method_7(bool bool_4)
		{
			bool_1 = bool_4;
		}

		public bool method_8()
		{
			return bool_2;
		}

		public void method_9(bool bool_4)
		{
			if (bool_2 != bool_4)
			{
				bool_2 = bool_4;
				if (base.IsHandleCreated)
				{
					Invalidate();
				}
			}
		}

		public FCDocumentViewMode method_10()
		{
			return fcdocumentViewMode_0;
		}

		public void method_11(FCDocumentViewMode fcdocumentViewMode_1)
		{
			if (fcdocumentViewMode_0 != fcdocumentViewMode_1)
			{
				method_54();
				point_2 = Point.Empty;
				fcdocumentViewMode_0 = fcdocumentViewMode_1;
				if (method_14() != null)
				{
					method_14().ViewMode = fcdocumentViewMode_1;
					method_14().LayoutInvalidate = true;
				}
			}
		}

		public int method_12()
		{
			return int_0;
		}

		public void method_13(int int_2)
		{
			if (int_0 != int_2)
			{
				int_0 = int_2;
				method_14().LayoutInvalidate = true;
			}
		}

		public FriedmanCurveDocument method_14()
		{
			if (friedmanCurveDocument_0 == null)
			{
				friedmanCurveDocument_0 = new FriedmanCurveDocument();
			}
			friedmanCurveDocument_0.InnerBehaviorMode = method_4();
			return friedmanCurveDocument_0;
		}

		public void method_15(FriedmanCurveDocument friedmanCurveDocument_1)
		{
			friedmanCurveDocument_0 = friedmanCurveDocument_1;
			if (friedmanCurveDocument_0 != null)
			{
				friedmanCurveDocument_0.LayoutInvalidate = true;
			}
		}

		internal PageSettings method_16()
		{
			PageSettings pageSettings = new PageSettings();
			if (method_14() != null && method_14().Config.PageSettings != null)
			{
				method_14().Config.PageSettings.method_0(pageSettings);
			}
			return pageSettings;
		}

		public Color method_17()
		{
			if (method_14() != null)
			{
				return method_14().Config.PageBackColor;
			}
			return Color.White;
		}

		public void method_18(Color color_0)
		{
			if (method_14() != null)
			{
				method_14().Config.PageBackColor = color_0;
			}
		}

		internal Color method_19()
		{
			if (method_14() != null)
			{
				Color pageBackColor = method_14().Config.PageBackColor;
				if (pageBackColor.A != 0)
				{
					return pageBackColor;
				}
			}
			return Color.White;
		}

		public void method_20(FCValuePointClickEventHandler fcvaluePointClickEventHandler_1)
		{
			FCValuePointClickEventHandler fCValuePointClickEventHandler = fcvaluePointClickEventHandler_0;
			FCValuePointClickEventHandler fCValuePointClickEventHandler2;
			do
			{
				fCValuePointClickEventHandler2 = fCValuePointClickEventHandler;
				FCValuePointClickEventHandler value = (FCValuePointClickEventHandler)Delegate.Combine(fCValuePointClickEventHandler2, fcvaluePointClickEventHandler_1);
				fCValuePointClickEventHandler = Interlocked.CompareExchange(ref fcvaluePointClickEventHandler_0, value, fCValuePointClickEventHandler2);
			}
			while ((object)fCValuePointClickEventHandler != fCValuePointClickEventHandler2);
		}

		public void method_21(FCValuePointClickEventHandler fcvaluePointClickEventHandler_1)
		{
			FCValuePointClickEventHandler fCValuePointClickEventHandler = fcvaluePointClickEventHandler_0;
			FCValuePointClickEventHandler fCValuePointClickEventHandler2;
			do
			{
				fCValuePointClickEventHandler2 = fCValuePointClickEventHandler;
				FCValuePointClickEventHandler value = (FCValuePointClickEventHandler)Delegate.Remove(fCValuePointClickEventHandler2, fcvaluePointClickEventHandler_1);
				fCValuePointClickEventHandler = Interlocked.CompareExchange(ref fcvaluePointClickEventHandler_0, value, fCValuePointClickEventHandler2);
			}
			while ((object)fCValuePointClickEventHandler != fCValuePointClickEventHandler2);
		}

		protected override void OnLoad(EventArgs eventArgs_0)
		{
			base.OnLoad(eventArgs_0);
			if (!base.DesignMode)
			{
				method_24();
				method_28();
			}
		}

		protected override void OnResize(EventArgs eventArgs_0)
		{
			base.OnResize(eventArgs_0);
			if (!base.DesignMode)
			{
				Invalidate();
				method_28();
			}
		}

		public void method_22()
		{
			try
			{
				method_32();
				float tickCountFloat = CountDown.GetTickCountFloat();
				method_14().RefreshDataSource();
				method_24();
				tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
				tickCountFloat = CountDown.GetTickCountFloat();
				method_28();
				tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
				point_2 = Point.Empty;
				Invalidate();
			}
			finally
			{
			}
		}

		public void method_23()
		{
			float tickCountFloat = CountDown.GetTickCountFloat();
			method_32();
			method_24();
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
			tickCountFloat = CountDown.GetTickCountFloat();
			method_28();
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
			point_2 = Point.Empty;
			Invalidate();
		}

		public void method_24()
		{
			if (method_14() != null)
			{
				DateTime maxDate = FriedmanCurveDocument.NullDate;
				DateTime minDate = FriedmanCurveDocument.NullDate;
				method_14().ViewMode = method_10();
				method_14().UpdateNumOfPage(out maxDate, out minDate);
			}
		}

		public bool method_25()
		{
			return bool_3;
		}

		public void method_26(bool bool_4)
		{
			if (bool_3 != bool_4)
			{
				bool_3 = bool_4;
				if (base.IsHandleCreated)
				{
					method_23();
				}
			}
		}

		private void method_27(object sender, EventArgs e)
		{
			method_2();
		}

		internal void method_28()
		{
			if (!base.IsHandleCreated || method_14() == null || method_33())
			{
				return;
			}
			method_14().eventHandler_0 = method_27;
			if (method_10() == FCDocumentViewMode.Page)
			{
				method_37(new SimpleRectangleTransform());
				rectangleF_0 = method_14().method_53(method_16());
				method_36().set_DescRectF(rectangleF_0);
				RectangleF rectangleF_ = GraphicsUnitConvert.Convert(rectangleF_0, method_14().GraphicsUnit, GraphicsUnit.Pixel);
				rectangleF_.X = 10f;
				rectangleF_.Y = 10f;
				if (rectangleF_.Width + 20f < (float)base.ClientSize.Width)
				{
					rectangleF_.X = 10f + ((float)base.ClientSize.Width - rectangleF_.Width) / 2f;
				}
				method_36().setSourceRectF(rectangleF_);
				Size size = new Size((int)rectangleF_.Right + 10, (int)rectangleF_.Bottom + 10);
				using (Graphics graphics_ = CreateGraphics())
				{
					method_14().method_4(new DCGraphics(graphics_));
				}
				if (base.AutoScrollMinSize != size)
				{
					base.AutoScrollMinSize = size;
				}
			}
			else if (method_10() == FCDocumentViewMode.Normal)
			{
				base.AutoScrollMinSize = new Size(1, 1);
				method_14().Left = 0f;
				method_14().Top = 0f;
				method_14().Width = GraphicsUnitConvert.Convert(base.ClientSize.Width, GraphicsUnit.Pixel, method_14().GraphicsUnit);
				method_14().Height = GraphicsUnitConvert.Convert(base.ClientSize.Height, GraphicsUnit.Pixel, method_14().GraphicsUnit);
				method_37(new SimpleRectangleTransform());
				method_36().set_DescRectF(new RectangleF(method_14().Left, method_14().Top, method_14().Width, method_14().Height));
				method_36().setSourceRectF(new RectangleF(0f, 0f, base.ClientSize.Width, base.ClientSize.Height));
				using (Graphics graphics_ = CreateGraphics())
				{
					method_14().method_4(new DCGraphics(graphics_));
				}
			}
			else if (method_10() == FCDocumentViewMode.FriedmanCurve)
			{
				SizeF empty = SizeF.Empty;
				using (Graphics graphics_ = CreateGraphics())
				{
					RectangleF empty2 = RectangleF.Empty;
					method_32();
					graphics_.PageUnit = method_14().GraphicsUnit;
					empty = method_14().method_51(graphics_);
					empty2.X = 0f;
					empty2.Y = 0f;
					empty2.Width = (int)empty.Width;
					empty2.Height = (int)empty.Height;
					SizeF sz = GraphicsUnitConvert.Convert(empty2.Size, method_14().GraphicsUnit, GraphicsUnit.Pixel);
					if (method_25())
					{
						empty2.X = 0f;
						empty2.Y = 0f;
						empty2.Height = GraphicsUnitConvert.Convert(base.ClientSize.Height - 1, GraphicsUnit.Pixel, method_14().GraphicsUnit);
						sz.Height = base.ClientSize.Height;
					}
					method_14().Bounds = empty2;
					method_37(new SimpleRectangleTransform());
					method_36().set_DescRectF(empty2);
					method_36().setSourceRectF(new RectangleF(0f, 0f, sz.Width, sz.Height));
					if (base.AutoScrollMinSize != sz)
					{
						base.AutoScrollMinSize = new Size((int)sz.Width, 1);
					}
				}
			}
			method_29();
			method_2();
		}

		private void method_29()
		{
			Point autoScrollPosition = base.AutoScrollPosition;
			method_36().method_19(new PointF(autoScrollPosition.X, autoScrollPosition.Y));
		}

		internal Point method_30(float float_0, float float_1)
		{
			PointF pointF = method_36().UnTransformPointF(float_0, float_1);
			return new Point((int)pointF.X, (int)pointF.Y);
		}

		internal PointF method_31(int int_2, int int_3)
		{
			return method_36().TransformPointF(int_2, int_3);
		}

		private void method_32()
		{
			int num = 0;
			if (method_14() != null)
			{
				foreach (FCDocumentData data in method_14().Datas)
				{
					num += data.Values.Count;
				}
			}
			if (num > 100000)
			{
				GClass445.smethod_9(this, DCFriedmanCurveStrings.Watting);
			}
		}

		private bool method_33()
		{
			if (base.DesignMode)
			{
				return true;
			}
			Control parent = base.Parent;
			while (true)
			{
				if (parent != null)
				{
					if (parent.Site != null && parent.Site.DesignMode)
					{
						break;
					}
					parent = parent.Parent;
					continue;
				}
				return false;
			}
			return true;
		}

		internal GEnum23 method_34()
		{
			return genum23_0;
		}

		internal void method_35(GEnum23 genum23_1)
		{
			genum23_0 = genum23_1;
		}

		internal SimpleRectangleTransform method_36()
		{
			if (gclass435_0 == null)
			{
				gclass435_0 = new SimpleRectangleTransform();
			}
			return gclass435_0;
		}

		internal void method_37(SimpleRectangleTransform gclass435_1)
		{
			gclass435_0 = gclass435_1;
		}

		protected override void OnPaint(PaintEventArgs pevent)
		{
			int num = 19;
			base.OnPaint(pevent);
			if (!GClass354.smethod_0(GetType()))
			{
				if (method_33())
				{
					string s = GetType().Name + ":" + base.Name + Environment.NewLine + "Version:" + base.ProductVersion + Environment.NewLine + "都昌产程图控件(DCFriedmanCurve)，是南京都昌信息科技有限公司开发的医疗行业使用的产程图控件，适用于.NET平台。南京都昌信息科技有限公司专业研发医学数据可视化技术，并自主研发了电子病历编辑器软件、产程图控件等等，公司网址 www.dcwriter.cn。";
					using (StringFormat stringFormat = new StringFormat())
					{
						stringFormat.Alignment = StringAlignment.Center;
						stringFormat.LineAlignment = StringAlignment.Center;
						pevent.Graphics.DrawString(s, Font, Brushes.Black, new RectangleF(0f, 0f, base.ClientSize.Width, base.ClientSize.Height), stringFormat);
					}
				}
				else
				{
					try
					{
						method_54();
						if (method_14() == null)
						{
							goto IL_03a5;
						}
						method_14().PrintingMode = false;
						method_29();
						method_14().InnerBehaviorMode = method_4();
						RectangleF rectangleF = pevent.ClipRectangle;
						rectangleF = method_36().vmethod_11(rectangleF);
						pevent.Graphics.PageUnit = method_14().GraphicsUnit;
						PointF pointF = method_31(0, 0);
						pevent.Graphics.TranslateTransform(0f - pointF.X, 0f - pointF.Y);
						method_14().ViewMode = method_10();
						if (method_10() != 0)
						{
							if (rectangleF.IntersectsWith(method_14().Bounds))
							{
								pevent.Graphics.FillRectangle(GClass438.smethod_0(method_19()), rectangleF);
								method_14().PageIndex = method_12();
								float tickCountFloat = CountDown.GetTickCountFloat();
								method_14().method_13(new DCGraphics(pevent.Graphics), rectangleF, method_34());
								tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
							}
							goto IL_03a5;
						}
						rectangleF.Inflate(1f, 1f);
						if (method_14().Config.BackColor.A != 0)
						{
							pevent.Graphics.FillRectangle(GClass438.smethod_0(method_14().Config.BackColor), rectangleF);
						}
						RectangleF rect = RectangleF.Intersect(rectangleF_0, rectangleF);
						if (!rect.IsEmpty)
						{
							float tickCountFloat2 = CountDown.GetTickCountFloat();
							pevent.Graphics.FillRectangle(GClass438.smethod_0(method_19()), rect);
							pevent.Graphics.DrawRectangle(Pens.Black, rectangleF_0.Left, rectangleF_0.Top, rectangleF_0.Width, rectangleF_0.Height);
							tickCountFloat2 = CountDown.GetTickCountFloat() - tickCountFloat2;
							tickCountFloat2 = CountDown.GetTickCountFloat() - tickCountFloat2;
							if (rectangleF.IntersectsWith(friedmanCurveDocument_0.Bounds))
							{
								method_14().PageIndex = method_12();
								tickCountFloat2 = CountDown.GetTickCountFloat() - tickCountFloat2;
								float tickCountFloat = CountDown.GetTickCountFloat();
								method_14().method_13(new DCGraphics(pevent.Graphics), rectangleF, GEnum23.const_2);
								tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
							}
							tickCountFloat2 = CountDown.GetTickCountFloat() - tickCountFloat2;
							FriedmanCurveDocument.smethod_0(method_14())?.method_28(pevent.Graphics, rectangleF_0, bool_7: true);
							goto IL_03a5;
						}
						goto end_IL_0123;
						IL_03a5:
						method_54();
						end_IL_0123:;
					}
					catch (Exception ex)
					{
						using (StringFormat stringFormat = new StringFormat())
						{
							stringFormat.Alignment = StringAlignment.Near;
							stringFormat.LineAlignment = StringAlignment.Center;
							pevent.Graphics.DrawString(ex.ToString(), Font, Brushes.Red, new RectangleF(0f, 0f, base.ClientSize.Width, base.ClientSize.Height), stringFormat);
						}
					}
				}
			}
		}

		public void method_38(int int_2)
		{
			using (PrintDialog printDialog = new PrintDialog())
			{
				printDialog.AllowCurrentPage = false;
				printDialog.AllowSelection = false;
				printDialog.AllowSomePages = false;
				if (printDialog.ShowDialog(this) == DialogResult.OK)
				{
					using (FriedmanCurvePrintDocument friedmanCurvePrintDocument = new FriedmanCurvePrintDocument(method_14()))
					{
						if (int_2 >= 0)
						{
							friedmanCurvePrintDocument.SpecifyPageIndex = int_2;
						}
						friedmanCurvePrintDocument.PrinterSettings = printDialog.PrinterSettings;
						friedmanCurvePrintDocument.Print();
					}
				}
			}
		}

		public void method_39(Stream stream_0)
		{
			int num = 8;
			if (stream_0 == null)
			{
				throw new ArgumentNullException("stream");
			}
			FriedmanCurveDocument friedmanCurveDocument = new FriedmanCurveDocument();
			if (friedmanCurveDocument.Load(stream_0))
			{
				method_40(friedmanCurveDocument);
			}
		}

		internal void method_40(FriedmanCurveDocument friedmanCurveDocument_1)
		{
			int num = 7;
			if (friedmanCurveDocument_1 == null)
			{
				throw new ArgumentNullException("doc");
			}
			method_15(friedmanCurveDocument_1);
			if (base.IsHandleCreated)
			{
				method_24();
				method_14().LayoutInvalidate = true;
				method_28();
				Invalidate();
				method_43().method_5();
			}
		}

		public void method_41(Stream stream_0)
		{
			int num = 1;
			if (stream_0 == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (method_14() != null)
			{
				method_14().Save(stream_0);
			}
		}

		internal int method_42()
		{
			return int_1;
		}

		internal Class166 method_43()
		{
			if (class166_0 == null)
			{
				class166_0 = new Class166();
				class166_0.method_1(base.Parent as FriedmanCurveControl);
				class166_0.method_3(this);
			}
			return class166_0;
		}

		public void method_44(FCEditValuePointEventHandler fceditValuePointEventHandler_1)
		{
			FCEditValuePointEventHandler fCEditValuePointEventHandler = fceditValuePointEventHandler_0;
			FCEditValuePointEventHandler fCEditValuePointEventHandler2;
			do
			{
				fCEditValuePointEventHandler2 = fCEditValuePointEventHandler;
				FCEditValuePointEventHandler value = (FCEditValuePointEventHandler)Delegate.Combine(fCEditValuePointEventHandler2, fceditValuePointEventHandler_1);
				fCEditValuePointEventHandler = Interlocked.CompareExchange(ref fceditValuePointEventHandler_0, value, fCEditValuePointEventHandler2);
			}
			while ((object)fCEditValuePointEventHandler != fCEditValuePointEventHandler2);
		}

		public void method_45(FCEditValuePointEventHandler fceditValuePointEventHandler_1)
		{
			FCEditValuePointEventHandler fCEditValuePointEventHandler = fceditValuePointEventHandler_0;
			FCEditValuePointEventHandler fCEditValuePointEventHandler2;
			do
			{
				fCEditValuePointEventHandler2 = fCEditValuePointEventHandler;
				FCEditValuePointEventHandler value = (FCEditValuePointEventHandler)Delegate.Remove(fCEditValuePointEventHandler2, fceditValuePointEventHandler_1);
				fCEditValuePointEventHandler = Interlocked.CompareExchange(ref fceditValuePointEventHandler_0, value, fCEditValuePointEventHandler2);
			}
			while ((object)fCEditValuePointEventHandler != fCEditValuePointEventHandler2);
		}

		internal void method_46(FCEditValuePointEventArgs fceditValuePointEventArgs_0)
		{
			if (toolTip_0 != null)
			{
				toolTip_0.SetToolTip(this, null);
			}
			switch (method_14().Config.EditValuePointMode)
			{
			case FCEditValuePointEventHandleMode.None:
				fceditValuePointEventArgs_0.Result = false;
				break;
			case FCEditValuePointEventHandleMode.Program:
				if (fceditValuePointEventHandler_0 != null)
				{
					fceditValuePointEventHandler_0(this, fceditValuePointEventArgs_0);
				}
				break;
			case FCEditValuePointEventHandleMode.Silent:
				fceditValuePointEventArgs_0.Result = true;
				break;
			case FCEditValuePointEventHandleMode.OwnedUI:
				switch (fceditValuePointEventArgs_0.EditMode)
				{
				case FCEditValuePointMode.Insert:
				{
					using (FCdlgEditSingleValue fCdlgEditSingleValue = new FCdlgEditSingleValue())
					{
						fCdlgEditSingleValue.Text = string.Format(DCFriedmanCurveStrings.NewValuePoint_Name, fceditValuePointEventArgs_0.SerialTitle);
						if (fceditValuePointEventArgs_0.YAxisInfo != null)
						{
							fCdlgEditSingleValue.InputTimePrecision = fceditValuePointEventArgs_0.YAxisInfo.InputTimePrecision;
						}
						else if (fceditValuePointEventArgs_0.TitleLineInfo != null)
						{
							fCdlgEditSingleValue.InputTimePrecision = fceditValuePointEventArgs_0.TitleLineInfo.InputTimePrecision;
						}
						fCdlgEditSingleValue.InputTitle = fceditValuePointEventArgs_0.SerialTitle;
						fCdlgEditSingleValue.InputTime = fceditValuePointEventArgs_0.ValuePoint.Time;
						fCdlgEditSingleValue.EnableInputTime = true;
						fCdlgEditSingleValue.InputValue = fceditValuePointEventArgs_0.ValuePoint.ValueString;
						fCdlgEditSingleValue.Tag = fceditValuePointEventArgs_0.ValuePoint;
						fCdlgEditSingleValue.EventOKButtonClick += method_47;
						if (fCdlgEditSingleValue.ShowDialog(this) == DialogResult.OK)
						{
							fceditValuePointEventArgs_0.ValuePoint.Time = fCdlgEditSingleValue.InputTime;
							float result = 0f;
							if (float.TryParse(fCdlgEditSingleValue.InputValue, out result))
							{
								fceditValuePointEventArgs_0.ValuePoint.Value = result;
							}
							fceditValuePointEventArgs_0.Result = true;
						}
						else
						{
							fceditValuePointEventArgs_0.Result = false;
						}
					}
					break;
				}
				case FCEditValuePointMode.Delete:
				{
					string text = string.Format(DCFriedmanCurveStrings.PromptDeleteValuePoint_Title_Time_Value, fceditValuePointEventArgs_0.SerialTitle, fceditValuePointEventArgs_0.ValuePoint.Time, fceditValuePointEventArgs_0.ValuePoint.RuntimeText);
					if (MessageBox.Show(this, text, DCFriedmanCurveStrings.SystemAlert, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						fceditValuePointEventArgs_0.Result = true;
					}
					else
					{
						fceditValuePointEventArgs_0.Result = false;
					}
					break;
				}
				case FCEditValuePointMode.Update:
				{
					using (FCdlgEditSingleValue fCdlgEditSingleValue = new FCdlgEditSingleValue())
					{
						fCdlgEditSingleValue.Text = string.Format(DCFriedmanCurveStrings.EditValuePoint_Title, fceditValuePointEventArgs_0.SerialTitle);
						if (fceditValuePointEventArgs_0.YAxisInfo != null)
						{
							fCdlgEditSingleValue.InputTimePrecision = fceditValuePointEventArgs_0.YAxisInfo.InputTimePrecision;
						}
						else if (fceditValuePointEventArgs_0.TitleLineInfo != null)
						{
							fCdlgEditSingleValue.InputTimePrecision = fceditValuePointEventArgs_0.TitleLineInfo.InputTimePrecision;
						}
						fCdlgEditSingleValue.InputTitle = fceditValuePointEventArgs_0.SerialTitle;
						fCdlgEditSingleValue.InputTime = fceditValuePointEventArgs_0.ValuePoint.Time;
						fCdlgEditSingleValue.EnableInputTime = false;
						fCdlgEditSingleValue.InputValue = fceditValuePointEventArgs_0.ValuePoint.ValueString;
						fCdlgEditSingleValue.Tag = fceditValuePointEventArgs_0.ValuePoint;
						fCdlgEditSingleValue.EventOKButtonClick += method_47;
						if (fCdlgEditSingleValue.ShowDialog(this) == DialogResult.OK)
						{
							float result = 0f;
							if (float.TryParse(fCdlgEditSingleValue.InputValue, out result))
							{
								fceditValuePointEventArgs_0.ValuePoint.Value = result;
							}
							fceditValuePointEventArgs_0.Result = true;
						}
						else
						{
							fceditValuePointEventArgs_0.Result = false;
						}
					}
					break;
				}
				}
				break;
			}
		}

		private void method_47(object sender, CancelEventArgs e)
		{
			FCdlgEditSingleValue fCdlgEditSingleValue = (FCdlgEditSingleValue)sender;
			FCValuePoint fCValuePoint = (FCValuePoint)fCdlgEditSingleValue.Tag;
			string string_ = null;
			float num = float.NaN;
			if (fCValuePoint.Parent is FCYAxisInfo)
			{
				FCYAxisInfo fCYAxisInfo = (FCYAxisInfo)fCValuePoint.Parent;
				num = Class163.smethod_2(fCdlgEditSingleValue.InputValue, fCYAxisInfo.MaxValue, fCYAxisInfo.MinValue, ref string_, bool_0: true, fCYAxisInfo.AllowOutofRange);
				if (!string.IsNullOrEmpty(string_))
				{
					MessageBox.Show(fCdlgEditSingleValue, string_, fCdlgEditSingleValue.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					e.Cancel = true;
				}
				fCdlgEditSingleValue.ResultValue = num;
			}
		}

		public void method_48(FriedmanCurveZoneEventHandler friedmanCurveZoneEventHandler_2)
		{
			FriedmanCurveZoneEventHandler friedmanCurveZoneEventHandler = friedmanCurveZoneEventHandler_0;
			FriedmanCurveZoneEventHandler friedmanCurveZoneEventHandler2;
			do
			{
				friedmanCurveZoneEventHandler2 = friedmanCurveZoneEventHandler;
				FriedmanCurveZoneEventHandler value = (FriedmanCurveZoneEventHandler)Delegate.Combine(friedmanCurveZoneEventHandler2, friedmanCurveZoneEventHandler_2);
				friedmanCurveZoneEventHandler = Interlocked.CompareExchange(ref friedmanCurveZoneEventHandler_0, value, friedmanCurveZoneEventHandler2);
			}
			while ((object)friedmanCurveZoneEventHandler != friedmanCurveZoneEventHandler2);
		}

		public void method_49(FriedmanCurveZoneEventHandler friedmanCurveZoneEventHandler_2)
		{
			FriedmanCurveZoneEventHandler friedmanCurveZoneEventHandler = friedmanCurveZoneEventHandler_0;
			FriedmanCurveZoneEventHandler friedmanCurveZoneEventHandler2;
			do
			{
				friedmanCurveZoneEventHandler2 = friedmanCurveZoneEventHandler;
				FriedmanCurveZoneEventHandler value = (FriedmanCurveZoneEventHandler)Delegate.Remove(friedmanCurveZoneEventHandler2, friedmanCurveZoneEventHandler_2);
				friedmanCurveZoneEventHandler = Interlocked.CompareExchange(ref friedmanCurveZoneEventHandler_0, value, friedmanCurveZoneEventHandler2);
			}
			while ((object)friedmanCurveZoneEventHandler != friedmanCurveZoneEventHandler2);
		}

		public void method_50(FriedmanCurveZoneEventHandler friedmanCurveZoneEventHandler_2)
		{
			FriedmanCurveZoneEventHandler friedmanCurveZoneEventHandler = friedmanCurveZoneEventHandler_1;
			FriedmanCurveZoneEventHandler friedmanCurveZoneEventHandler2;
			do
			{
				friedmanCurveZoneEventHandler2 = friedmanCurveZoneEventHandler;
				FriedmanCurveZoneEventHandler value = (FriedmanCurveZoneEventHandler)Delegate.Combine(friedmanCurveZoneEventHandler2, friedmanCurveZoneEventHandler_2);
				friedmanCurveZoneEventHandler = Interlocked.CompareExchange(ref friedmanCurveZoneEventHandler_1, value, friedmanCurveZoneEventHandler2);
			}
			while ((object)friedmanCurveZoneEventHandler != friedmanCurveZoneEventHandler2);
		}

		public void method_51(FriedmanCurveZoneEventHandler friedmanCurveZoneEventHandler_2)
		{
			FriedmanCurveZoneEventHandler friedmanCurveZoneEventHandler = friedmanCurveZoneEventHandler_1;
			FriedmanCurveZoneEventHandler friedmanCurveZoneEventHandler2;
			do
			{
				friedmanCurveZoneEventHandler2 = friedmanCurveZoneEventHandler;
				FriedmanCurveZoneEventHandler value = (FriedmanCurveZoneEventHandler)Delegate.Remove(friedmanCurveZoneEventHandler2, friedmanCurveZoneEventHandler_2);
				friedmanCurveZoneEventHandler = Interlocked.CompareExchange(ref friedmanCurveZoneEventHandler_1, value, friedmanCurveZoneEventHandler2);
			}
			while ((object)friedmanCurveZoneEventHandler != friedmanCurveZoneEventHandler2);
		}

		public void method_52(EventHandler eventHandler_3)
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value = (EventHandler)Delegate.Combine(eventHandler2, eventHandler_3);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}

		public void method_53(EventHandler eventHandler_3)
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value = (EventHandler)Delegate.Remove(eventHandler2, eventHandler_3);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}

		protected override void OnMouseDown(MouseEventArgs mevent)
		{
			base.OnMouseDown(mevent);
			point_1 = new Point(mevent.X, mevent.Y);
			method_55();
			if (method_43().method_13(this, mevent))
			{
				return;
			}
			if (mevent.Button == MouseButtons.Left)
			{
				point_0 = new Point(mevent.X, mevent.Y);
			}
			PointF pointF;
			if (mevent.Button == MouseButtons.Left && method_14().Config.AllowUserCollapseZone && method_14().Config.Zones != null)
			{
				pointF = method_31(mevent.X, mevent.Y);
				foreach (FriedmanCurveZoneInfo zone in method_14().Config.Zones)
				{
					if (zone.ExpandedHandleBounds.Contains(pointF.X, pointF.Y))
					{
						zone.IsExpanded = !zone.IsExpanded;
						method_28();
						Invalidate();
						if (zone.IsExpanded)
						{
							if (friedmanCurveZoneEventHandler_1 != null)
							{
								FriedmanCurveZoneEventArgs e = new FriedmanCurveZoneEventArgs(method_14(), zone);
								friedmanCurveZoneEventHandler_1(this, e);
							}
						}
						else if (friedmanCurveZoneEventHandler_0 != null)
						{
							FriedmanCurveZoneEventArgs e = new FriedmanCurveZoneEventArgs(method_14(), zone);
							friedmanCurveZoneEventHandler_0(this, e);
						}
						int_1 = Environment.TickCount + 300;
						return;
					}
				}
			}
			if (mevent.Button != MouseButtons.Left || method_4() != Enum19.const_1)
			{
				return;
			}
			pointF = method_31(mevent.X, mevent.Y);
			object obj = method_14().method_55(pointF.X, pointF.Y);
			if (obj == null)
			{
				obj = method_14();
			}
			if (obj != method_14().SelectedObject)
			{
				method_14().SelectedObject = obj;
				Invalidate();
				if (eventHandler_1 != null)
				{
					eventHandler_1(this, EventArgs.Empty);
				}
			}
		}

		private void method_54()
		{
			if (Environment.TickCount - long_0 > 100L && method_8() && !point_2.IsEmpty)
			{
				GClass150.smethod_0(base.Handle, 0, point_2.Y, base.ClientSize.Width, point_2.Y);
				GClass150.smethod_0(base.Handle, point_2.X, 0, point_2.X, base.ClientSize.Height);
			}
		}

		private void method_55()
		{
			if (!point_2.IsEmpty)
			{
				method_54();
				point_2 = Point.Empty;
			}
		}

		protected override bool ProcessCmdKey(ref Message message_0, Keys keyData)
		{
			return false;
		}

		protected override bool ProcessDialogKey(Keys keyData)
		{
			return false;
		}

		protected override void OnKeyDown(KeyEventArgs kevent)
		{
			base.OnKeyDown(kevent);
			if (!kevent.Handled && !method_43().method_15(kevent))
			{
				method_56(kevent);
			}
		}

		internal void method_56(KeyEventArgs keyEventArgs_0)
		{
			if (method_10() != FCDocumentViewMode.FriedmanCurve)
			{
				return;
			}
			Point autoScrollPosition = new Point(-base.AutoScrollPosition.X, -base.AutoScrollPosition.Y);
			if (keyEventArgs_0.KeyCode == Keys.Left || keyEventArgs_0.KeyCode == Keys.Up)
			{
				autoScrollPosition.Offset(-(int)method_14().TickViewWidth, 0);
				method_55();
				base.AutoScrollPosition = autoScrollPosition;
			}
			else if (keyEventArgs_0.KeyCode == Keys.Right || keyEventArgs_0.KeyCode == Keys.Down)
			{
				autoScrollPosition.Offset((int)method_14().TickViewWidth, 0);
				method_55();
				base.AutoScrollPosition = autoScrollPosition;
			}
			else if (keyEventArgs_0.KeyCode == Keys.Prior)
			{
				int num = (int)((float)base.ClientSize.Width - method_14().LeftHeaderPixelWidth - 20f);
				if (num < 40)
				{
					num = 40;
				}
				autoScrollPosition.Offset(-num, 0);
				method_55();
				base.AutoScrollPosition = autoScrollPosition;
			}
			else if (keyEventArgs_0.KeyCode == Keys.Next)
			{
				int num = (int)((float)base.ClientSize.Width - method_14().LeftHeaderPixelWidth - 20f);
				if (num < 40)
				{
					num = 40;
				}
				autoScrollPosition.Offset(num, 0);
				method_55();
				base.AutoScrollPosition = autoScrollPosition;
			}
			else if (keyEventArgs_0.KeyCode == Keys.Home)
			{
				autoScrollPosition = new Point(0, 0);
				method_55();
				base.AutoScrollPosition = autoScrollPosition;
			}
			else if (keyEventArgs_0.KeyCode == Keys.End)
			{
				autoScrollPosition = new Point(base.AutoScrollMinSize.Width, 0);
				method_55();
				base.AutoScrollPosition = autoScrollPosition;
			}
		}

		protected override void OnMouseLeave(EventArgs eventArgs_0)
		{
			base.OnMouseLeave(eventArgs_0);
			method_54();
			point_2 = Point.Empty;
			method_57(null);
		}

		protected override void OnMouseWheel(MouseEventArgs mouseEventArgs_0)
		{
			method_54();
			point_2 = Point.Empty;
			base.OnMouseWheel(mouseEventArgs_0);
		}

		protected override void OnMouseClick(MouseEventArgs mouseEventArgs_0)
		{
			base.OnMouseClick(mouseEventArgs_0);
		}

		private void method_57(FCValuePoint fcvaluePoint_0)
		{
			if (method_14().MouseHoverValuePoint != fcvaluePoint_0)
			{
				if (method_14().MouseHoverValuePoint != null && method_14().Config.LinkVisualStyle == FCDocumentLinkVisualStyle.Hover && !string.IsNullOrEmpty(method_14().MouseHoverValuePoint.Link))
				{
					method_58(method_14().MouseHoverValuePoint);
				}
				method_14().MouseHoverValuePoint = fcvaluePoint_0;
				if (fcvaluePoint_0 != null && method_14().Config.LinkVisualStyle == FCDocumentLinkVisualStyle.Hover && !string.IsNullOrEmpty(fcvaluePoint_0.Link))
				{
					method_58(fcvaluePoint_0);
				}
			}
		}

		private void method_58(FCValuePoint fcvaluePoint_0)
		{
			if (fcvaluePoint_0 != null)
			{
				RectangleF rectangleF = method_36().vmethod_23(fcvaluePoint_0.ViewBounds);
				Invalidate(new Rectangle((int)rectangleF.Left - 2, (int)rectangleF.Top - 2, (int)rectangleF.Width + 4, (int)rectangleF.Height + 4));
			}
		}

		protected override void OnMouseMove(MouseEventArgs mevent)
		{
			int num = 2;
			base.OnMouseMove(mevent);
			if (method_43().method_12(this, mevent))
			{
				return;
			}
			FCValuePoint fcvaluePoint_ = null;
			if (mevent.Button == MouseButtons.Left && !point_0.IsEmpty)
			{
				if (method_6())
				{
					Point autoScrollPosition = base.AutoScrollPosition;
					autoScrollPosition.Offset(mevent.X - point_0.X, mevent.Y - point_0.Y);
					point_0 = new Point(mevent.X, mevent.Y);
					base.AutoScrollPosition = new Point(-autoScrollPosition.X, -autoScrollPosition.Y);
				}
			}
			else
			{
				if (method_8() && mevent.Button == MouseButtons.None && mevent.Delta == 0)
				{
					method_54();
					point_2 = new Point(mevent.X, mevent.Y);
					method_54();
				}
				if (method_14().Config.ShowTooltip)
				{
					if (toolTip_0 == null)
					{
						toolTip_0 = new ToolTip();
					}
					if (string.IsNullOrEmpty(method_14().Config.TitleForToolTip))
					{
						toolTip_0.ToolTipTitle = DCFriedmanCurveStrings.SystemAlert;
					}
					else
					{
						toolTip_0.ToolTipTitle = method_14().Config.TitleForToolTip;
					}
					string text = null;
					PointF pt = method_31(mevent.X, mevent.Y);
					FCTitleLineInfoList fCTitleLineInfoList = new FCTitleLineInfoList();
					fCTitleLineInfoList.AddRange(method_14().RuntimeHeaderLines);
					fCTitleLineInfoList.AddRange(method_14().RuntimeFooterLines);
					if (method_14().Config.DebugMode)
					{
						foreach (FCTitleLineInfo item in fCTitleLineInfoList)
						{
							if (item.ValueType == FCTitleLineValueType.HourTick)
							{
								RectangleF rectangleF = new RectangleF(method_14().DataGridBounds.Left, item.Top, method_14().DataGridBounds.Width, item.Height);
								if (rectangleF.Contains(pt))
								{
									foreach (Class164 runtimeTick in method_14().RuntimeTicks)
									{
										if (runtimeTick.float_0 <= pt.X - rectangleF.Left && pt.X - rectangleF.Left <= runtimeTick.float_0 + runtimeTick.float_1)
										{
											text = "Index   :" + method_14().RuntimeTicks.IndexOf(runtimeTick) + Environment.NewLine + "Left    :" + runtimeTick.float_0 + Environment.NewLine + "Width   :" + runtimeTick.float_1 + Environment.NewLine + "Right   :" + Convert.ToString(runtimeTick.float_0 + runtimeTick.float_1) + Environment.NewLine + "开始时间:" + runtimeTick.dateTime_0.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine + "结束时间:" + runtimeTick.dateTime_1.ToString("yyyy-MM-dd HH:mm:ss");
											break;
										}
									}
								}
							}
						}
					}
					if (text == null)
					{
						foreach (FCTitleLineInfo item2 in fCTitleLineInfoList)
						{
							if (item2.ShowExpandedHandle && item2.ExpandedHandleBounds.Contains(pt))
							{
								text = DCFriedmanCurveStrings.PromptExpandedCollapseTitleLine;
								break;
							}
						}
					}
					if (text == null && method_14().Config.AllowUserCollapseZone && method_14().Config.Zones != null)
					{
						foreach (FriedmanCurveZoneInfo zone in method_14().Config.Zones)
						{
							if (!zone.ExpandedHandleBounds.IsEmpty && zone.ExpandedHandleBounds.Contains(pt.X, pt.Y))
							{
								text = DCFriedmanCurveStrings.PromptExpandedCollapseZone;
								break;
							}
						}
					}
					Cursor = Cursors.Arrow;
					if (text == null)
					{
						FCValuePoint fCValuePoint = method_60(pt.X, pt.Y);
						fcvaluePoint_ = fCValuePoint;
						if (fCValuePoint != null)
						{
							text = ((!string.IsNullOrEmpty(fCValuePoint.Title)) ? fCValuePoint.Title : (string.IsNullOrEmpty(fCValuePoint.Link) ? fCValuePoint.RuntimeTitle : fCValuePoint.Link));
							if (method_14().Config.DebugMode)
							{
								text = text + Environment.NewLine + "Bounds:" + fCValuePoint.ViewBounds.ToString() + Environment.NewLine + "PIndex:" + fCValuePoint.InstanceIndex + Environment.NewLine + "Time:" + fCValuePoint.Time.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine + "Text:" + fCValuePoint.Text + Environment.NewLine + "Value:" + fCValuePoint.Value.ToString();
							}
							if (!string.IsNullOrEmpty(fCValuePoint.Link) && (method_43() == null || !method_43().method_4() || method_43().method_18() == Enum18.const_0))
							{
								Cursor = Cursors.Hand;
							}
						}
					}
					if (toolTip_0.GetToolTip(this) != text)
					{
						toolTip_0.SetToolTip(this, text);
					}
				}
			}
			method_57(fcvaluePoint_);
		}

		internal void method_59(string string_1, bool bool_4)
		{
			if (toolTip_0 == null)
			{
				toolTip_0 = new ToolTip();
			}
			if (string.IsNullOrEmpty(method_14().Config.TitleForToolTip))
			{
				toolTip_0.ToolTipTitle = DCFriedmanCurveStrings.SystemAlert;
			}
			else
			{
				toolTip_0.ToolTipTitle = method_14().Config.TitleForToolTip;
			}
			if (string.IsNullOrEmpty(string_1))
			{
				toolTip_0.SetToolTip(this, null);
			}
			else if (toolTip_0.GetToolTip(this) != string_1)
			{
				toolTip_0.ShowAlways = bool_4;
				toolTip_0.SetToolTip(this, string_1);
			}
		}

		protected override void OnScroll(ScrollEventArgs scrollEventArgs_0)
		{
			method_55();
			long_0 = Environment.TickCount;
			base.OnScroll(scrollEventArgs_0);
		}

		internal FCValuePoint method_60(float float_0, float float_1)
		{
			lock (method_14())
			{
				for (int num = method_14().Config.YAxisInfos.Count - 1; num >= 0; num--)
				{
					FCYAxisInfo fCYAxisInfo = method_14().Config.YAxisInfos[num];
					if (fCYAxisInfo.Visible && fCYAxisInfo.ValueVisible)
					{
						FCValuePointList valuesByName = method_14().Datas.GetValuesByName(fCYAxisInfo.Name);
						if (fCYAxisInfo.Style == FCYAxisInfoStyle.Text)
						{
							foreach (FCValuePoint item in valuesByName)
							{
								if (item.ViewBounds.Contains(float_0, float_1))
								{
									return item;
								}
							}
						}
						else if (fCYAxisInfo.Style == FCYAxisInfoStyle.Value)
						{
							foreach (FCValuePoint item2 in valuesByName)
							{
								if (item2.ViewBounds.Contains(float_0, float_1))
								{
									return item2;
								}
								if (item2.ShadowPoint != null && item2.ShowShadowPoint && item2.ShadowPoint.ViewBounds.Contains(float_0, float_1))
								{
									return item2.ShadowPoint;
								}
							}
						}
					}
				}
				foreach (FCTitleLineInfo runtimeFooterLine in method_14().RuntimeFooterLines)
				{
					FCValuePointList valuesByName = method_14().Datas.GetValuesByName(runtimeFooterLine.Name);
					foreach (FCValuePoint item3 in valuesByName)
					{
						if (item3.ViewBounds.Contains(float_0, float_1))
						{
							return item3;
						}
					}
				}
				foreach (FCTitleLineInfo runtimeHeaderLine in method_14().RuntimeHeaderLines)
				{
					FCValuePointList valuesByName = method_14().Datas.GetValuesByName(runtimeHeaderLine.Name);
					foreach (FCValuePoint item4 in valuesByName)
					{
						if (item4.ViewBounds.Contains(float_0, float_1))
						{
							return item4;
						}
					}
				}
			}
			return null;
		}

		public void method_61(EventHandler eventHandler_3)
		{
			EventHandler eventHandler = eventHandler_1;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value = (EventHandler)Delegate.Combine(eventHandler2, eventHandler_3);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}

		public void method_62(EventHandler eventHandler_3)
		{
			EventHandler eventHandler = eventHandler_1;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value = (EventHandler)Delegate.Remove(eventHandler2, eventHandler_3);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}

		protected override void OnMouseUp(MouseEventArgs mevent)
		{
			base.OnMouseUp(mevent);
			if (method_43().method_14(this, mevent))
			{
				return;
			}
			point_0 = Point.Empty;
			if (Math.Abs(mevent.X - point_1.X) >= SystemInformation.DragSize.Width || Math.Abs(mevent.Y - point_1.Y) >= SystemInformation.DragSize.Height || mevent.Button != MouseButtons.Left)
			{
				return;
			}
			PointF pointF = method_31(mevent.X, mevent.Y);
			if (method_4() != Enum19.const_1 && method_64(mevent.X, mevent.Y))
			{
				return;
			}
			if (method_14().InnerBehaviorMode != Enum19.const_1 && mevent.Button == MouseButtons.Left)
			{
				FCValuePoint fCValuePoint = method_60(pointF.X, pointF.Y);
				if (fCValuePoint != null && fcvaluePointClickEventHandler_0 != null)
				{
					FCValuePointClickEventArgs e = new FCValuePointClickEventArgs(fCValuePoint);
					fcvaluePointClickEventHandler_0(this, e);
				}
				if (fCValuePoint != null && !string.IsNullOrEmpty(fCValuePoint.Link))
				{
					FCDocumentLinkClickEventArgs fcdocumentLinkClickEventArgs_ = new FCDocumentLinkClickEventArgs(method_3(), method_14(), fCValuePoint, fCValuePoint.Link, fCValuePoint.LinkTarget);
					method_3().method_5(fcdocumentLinkClickEventArgs_);
					return;
				}
			}
			if (!method_63(mevent) && method_4() != Enum19.const_1 && eventHandler_2 != null)
			{
				object obj = method_14().method_55(pointF.X, pointF.Y);
				if (obj is FCHeaderLabelInfo)
				{
					eventHandler_2(obj, null);
				}
			}
		}

		private bool method_63(MouseEventArgs mouseEventArgs_0)
		{
			PointF pt = method_31(mouseEventArgs_0.X, mouseEventArgs_0.Y);
			FriedmanCurveDocument friedmanCurveDocument = method_14();
			if (!friedmanCurveDocument.DataGridBounds.Contains(pt))
			{
				return false;
			}
			FCYAxisInfo fCYAxisInfo = null;
			for (int num = method_14().VisibleYAxisInfos.Count - 1; num >= 0; num--)
			{
				FCYAxisInfo fCYAxisInfo2 = method_14().VisibleYAxisInfos[num];
				if (fCYAxisInfo2.Style == FCYAxisInfoStyle.Value && fCYAxisInfo2.ValueVisible)
				{
					FCValuePointList fCValuePointList = friedmanCurveDocument.method_40(fCYAxisInfo2.Name);
					if (fCValuePointList != null && fCValuePointList.Count > 0)
					{
						DateTime dateTime = method_14().RuntimeTicks.method_15(friedmanCurveDocument.DataGridBounds, pt.X);
						if (!FriedmanCurveDocument.smethod_4(dateTime))
						{
							int floorIndexByTime = fCValuePointList.GetFloorIndexByTime(dateTime);
							int num2 = Math.Max(0, floorIndexByTime - 10);
							Math.Max(fCValuePointList.Count - 1, floorIndexByTime + 10);
							PointF pointF = PointF.Empty;
							for (int i = num2; i < fCValuePointList.Count; i++)
							{
								FCValuePoint fCValuePoint = fCValuePointList[i];
								RectangleF viewBounds = fCValuePoint.ViewBounds;
								if (viewBounds.IsEmpty)
								{
									pointF = PointF.Empty;
									continue;
								}
								if (viewBounds.Contains(pt))
								{
									fCYAxisInfo = fCYAxisInfo2;
									break;
								}
								PointF pointF2 = new PointF(viewBounds.Left + viewBounds.Width / 2f, viewBounds.Top + viewBounds.Height / 2f);
								if (!pointF.IsEmpty)
								{
									double num3 = MathCommon.smethod_20(pointF2.X, pointF2.Y, pointF.X, pointF.Y, pt.X, pt.Y, bool_0: true);
									if (num3 >= 0.0 && num3 <= (double)(viewBounds.Height / 2f))
									{
										fCYAxisInfo = fCYAxisInfo2;
										break;
									}
								}
								pointF = pointF2;
							}
						}
					}
					if (fCYAxisInfo != null)
					{
						break;
					}
				}
			}
			if (fCYAxisInfo == null)
			{
				return false;
			}
			if (friedmanCurveDocument.Config.SelectionMode == DCFriedmanCurveSelectionMode.MultiSelec)
			{
				fCYAxisInfo.Selected = !fCYAxisInfo.Selected;
			}
			else if (friedmanCurveDocument.Config.SelectionMode == DCFriedmanCurveSelectionMode.SingleSelect)
			{
				fCYAxisInfo.Selected = !fCYAxisInfo.Selected;
				foreach (FCYAxisInfo yAxisInfo in friedmanCurveDocument.Config.YAxisInfos)
				{
					if (yAxisInfo != fCYAxisInfo)
					{
						yAxisInfo.Selected = false;
					}
				}
			}
			Invalidate();
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, null);
			}
			return true;
		}

		internal bool method_64(int int_2, int int_3)
		{
			PointF pointF = method_31(int_2, int_3);
			FCTitleLineInfoList fCTitleLineInfoList = new FCTitleLineInfoList();
			fCTitleLineInfoList.AddRange(method_14().RuntimeHeaderLines);
			fCTitleLineInfoList.AddRange(method_14().RuntimeFooterLines);
			foreach (FCTitleLineInfo item in fCTitleLineInfoList)
			{
				if (item.ShowExpandedHandle && item.ExpandedHandleBounds.Contains(pointF.X, pointF.Y))
				{
					item.IsExpanded = !item.IsExpanded;
					method_14().LayoutInvalidate = true;
					method_28();
					Invalidate();
					int_1 = Environment.TickCount + 300;
					return true;
				}
			}
			foreach (FCYAxisInfo yAxisInfo in method_14().YAxisInfos)
			{
				if (yAxisInfo.bool_14 && yAxisInfo.ClickToHide && new RectangleF(yAxisInfo.TitleLeft, yAxisInfo.TitleTop, yAxisInfo.TitleWidth, yAxisInfo.TitleHeight).Contains(pointF.X, pointF.Y))
				{
					yAxisInfo.ValueVisible = !yAxisInfo.ValueVisible;
					method_14().method_3();
					Invalidate();
					return true;
				}
			}
			if (eventHandler_2 != null)
			{
				object obj = method_14().method_55(pointF.X, pointF.Y);
				if (obj is FCHeaderLabelInfo)
				{
					eventHandler_2(obj, null);
				}
			}
			return false;
		}

		internal void method_65(EventHandler eventHandler_3)
		{
			EventHandler eventHandler = eventHandler_2;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value = (EventHandler)Delegate.Combine(eventHandler2, eventHandler_3);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}

		internal void method_66(EventHandler eventHandler_3)
		{
			EventHandler eventHandler = eventHandler_2;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value = (EventHandler)Delegate.Remove(eventHandler2, eventHandler_3);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}

		protected override void Dispose(bool disposing)
		{
			if (toolTip_0 != null)
			{
				toolTip_0.Dispose();
				toolTip_0 = null;
			}
			base.Dispose(disposing);
		}

		public void method_67()
		{
			MessageBox.Show(this, "都昌产程图控件(DCFriedmanCurve)，是南京都昌信息科技有限公司开发的医疗行业使用的产程图控件，适用于.NET平台。南京都昌信息科技有限公司专业研发医学数据可视化技术，并自主研发了电子病历编辑器软件、产程图控件等等，公司网址 www.dcwriter.cn。", "关于...");
		}
	}
}
