using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.TemperatureChart;
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
	
	[ComVisible(false)]
	[ToolboxItem(false)]
	
	public class GControl1 : UserControl
	{
		private const string string_0 = "都昌时间轴控件(DCTimeline)，是南京都昌信息科技有限公司开发的医疗行业使用的时间轴控件，适用于.NET平台。南京都昌信息科技有限公司专业研发医学数据可视化技术，并自主研发了电子病历编辑器软件、时间轴控件等等，公司网址 www.dcwriter.cn。";

		private bool bool_0 = false;

		private GClass17 gclass17_0 = null;

		private Enum16 enum16_0 = Enum16.const_0;

		private bool bool_1 = true;

		private bool bool_2 = false;

		private DocumentViewMode documentViewMode_0 = DocumentViewMode.Page;

		private int int_0 = 0;

		private TemperatureDocument temperatureDocument_0 = null;

		private ValuePointClickEventHandler valuePointClickEventHandler_0 = null;

		private bool bool_3 = true;

		private RectangleF rectangleF_0 = RectangleF.Empty;

		private GEnum22 genum22_0 = GEnum22.const_2;

		private SimpleRectangleTransform gclass435_0 = null;

		private int int_1 = 0;

		private Class161 class161_0 = null;

		private EditValuePointEventHandler editValuePointEventHandler_0 = null;

		private TimeLineZoneEventHandler timeLineZoneEventHandler_0 = null;

		private TimeLineZoneEventHandler timeLineZoneEventHandler_1 = null;

		private EventHandler eventHandler_0 = null;

		private Point point_0 = Point.Empty;

		private Point point_1 = Point.Empty;

		private Point point_2 = Point.Empty;

		private long long_0 = 0L;

		private ToolTip toolTip_0 = null;

		private EventHandler eventHandler_1 = null;

		private EventHandler eventHandler_2 = null;

		public GControl1()
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

		protected override void OnGotFocus(EventArgs eventArgs_0)
		{
			base.OnGotFocus(eventArgs_0);
			method_2();
		}

		protected override void OnLostFocus(EventArgs eventArgs_0)
		{
			base.OnLostFocus(eventArgs_0);
		}

		public void method_2()
		{
			if (!base.IsHandleCreated)
			{
				return;
			}
			if (!TemperatureDocument.smethod_4(method_14().CaretDateTime))
			{
				if (method_14().DataGridBounds.Height > 0f)
				{
					if (method_14().CaretDateTime >= method_14().RuntimeTicks.method_0() && method_14().CaretDateTime <= method_14().RuntimeTicks.method_2())
					{
						bool_0 = method_1().Create(0, 5, (int)method_14().method_12(method_14().DataGridBounds.Height));
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

		private TemperatureControl method_3()
		{
			return base.Parent as TemperatureControl;
		}

		internal Enum16 method_4()
		{
			return enum16_0;
		}

		internal void method_5(Enum16 enum16_1)
		{
			enum16_0 = enum16_1;
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

		public DocumentViewMode method_10()
		{
			return documentViewMode_0;
		}

		public void method_11(DocumentViewMode documentViewMode_1)
		{
			if (documentViewMode_0 != documentViewMode_1)
			{
				method_55();
				point_2 = Point.Empty;
				documentViewMode_0 = documentViewMode_1;
				if (method_14() != null)
				{
					method_14().ViewMode = documentViewMode_1;
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

		public TemperatureDocument method_14()
		{
			if (temperatureDocument_0 == null)
			{
				temperatureDocument_0 = new TemperatureDocument();
			}
			temperatureDocument_0.InnerBehaviorMode = method_4();
			return temperatureDocument_0;
		}

		public void method_15(TemperatureDocument temperatureDocument_1)
		{
			temperatureDocument_0 = temperatureDocument_1;
			if (temperatureDocument_0 != null)
			{
				temperatureDocument_0.LayoutInvalidate = true;
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

		public void method_20(ValuePointClickEventHandler valuePointClickEventHandler_1)
		{
			ValuePointClickEventHandler valuePointClickEventHandler = valuePointClickEventHandler_0;
			ValuePointClickEventHandler valuePointClickEventHandler2;
			do
			{
				valuePointClickEventHandler2 = valuePointClickEventHandler;
				ValuePointClickEventHandler value = (ValuePointClickEventHandler)Delegate.Combine(valuePointClickEventHandler2, valuePointClickEventHandler_1);
				valuePointClickEventHandler = Interlocked.CompareExchange(ref valuePointClickEventHandler_0, value, valuePointClickEventHandler2);
			}
			while ((object)valuePointClickEventHandler != valuePointClickEventHandler2);
		}

		public void method_21(ValuePointClickEventHandler valuePointClickEventHandler_1)
		{
			ValuePointClickEventHandler valuePointClickEventHandler = valuePointClickEventHandler_0;
			ValuePointClickEventHandler valuePointClickEventHandler2;
			do
			{
				valuePointClickEventHandler2 = valuePointClickEventHandler;
				ValuePointClickEventHandler value = (ValuePointClickEventHandler)Delegate.Remove(valuePointClickEventHandler2, valuePointClickEventHandler_1);
				valuePointClickEventHandler = Interlocked.CompareExchange(ref valuePointClickEventHandler_0, value, valuePointClickEventHandler2);
			}
			while ((object)valuePointClickEventHandler != valuePointClickEventHandler2);
		}

		protected override void OnLoad(EventArgs eventArgs_0)
		{
			base.OnLoad(eventArgs_0);
			if (!method_33())
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
				DateTime maxDate = TemperatureDocument.NullDate;
				DateTime minDate = TemperatureDocument.NullDate;
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
			if (method_10() == DocumentViewMode.Page)
			{
				method_37(new SimpleRectangleTransform());
				rectangleF_0 = method_14().method_8(method_16());
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
					method_14().method_15(new DCGraphics(graphics_));
				}
				if (base.AutoScrollMinSize != size)
				{
					base.AutoScrollMinSize = size;
				}
			}
			else if (method_10() == DocumentViewMode.Normal)
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
					method_14().method_15(new DCGraphics(graphics_));
				}
			}
			else if (method_10() == DocumentViewMode.Timeline)
			{
				SizeF empty = SizeF.Empty;
				using (Graphics graphics_ = CreateGraphics())
				{
					RectangleF empty2 = RectangleF.Empty;
					method_32();
					graphics_.PageUnit = method_14().GraphicsUnit;
					empty = method_14().method_6(graphics_);
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
				foreach (DocumentData data in method_14().Datas)
				{
					num += data.Values.Count;
				}
			}
			if (num > 100000)
			{
				GClass445.smethod_9(this, DCTimeLineStrings.Watting);
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

		internal GEnum22 method_34()
		{
			return genum22_0;
		}

		internal void method_35(GEnum22 genum22_1)
		{
			genum22_0 = genum22_1;
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
			int num = 5;
			base.OnPaint(pevent);
			if (method_33())
			{
				string s = GetType().Name + ":" + base.Name + Environment.NewLine + "Version:" + base.ProductVersion + Environment.NewLine + "都昌时间轴控件(DCTimeline)，是南京都昌信息科技有限公司开发的医疗行业使用的时间轴控件，适用于.NET平台。南京都昌信息科技有限公司专业研发医学数据可视化技术，并自主研发了电子病历编辑器软件、时间轴控件等等，公司网址 www.dcwriter.cn。";
				using (StringFormat stringFormat = new StringFormat())
				{
					stringFormat.Alignment = StringAlignment.Center;
					stringFormat.LineAlignment = StringAlignment.Center;
					pevent.Graphics.DrawString(s, Font, Brushes.Black, new RectangleF(0f, 0f, base.ClientSize.Width, base.ClientSize.Height), stringFormat);
				}
			}
			else
			{
				method_38(pevent);
			}
		}

		private void method_38(PaintEventArgs paintEventArgs_0)
		{
			try
			{
				method_55();
				if (method_14() == null)
				{
					goto IL_0284;
				}
				method_14().PrintingMode = false;
				method_29();
				method_14().InnerBehaviorMode = method_4();
				RectangleF rectangleF = paintEventArgs_0.ClipRectangle;
				rectangleF = method_36().vmethod_11(rectangleF);
				paintEventArgs_0.Graphics.PageUnit = method_14().GraphicsUnit;
				PointF pointF = method_31(0, 0);
				paintEventArgs_0.Graphics.TranslateTransform(0f - pointF.X, 0f - pointF.Y);
				method_14().ViewMode = method_10();
				if (method_10() != 0)
				{
					if (rectangleF.IntersectsWith(method_14().Bounds))
					{
						paintEventArgs_0.Graphics.FillRectangle(GClass438.smethod_0(method_19()), rectangleF);
						method_14().PageIndex = method_12();
						float tickCountFloat = CountDown.GetTickCountFloat();
						method_14().method_29(new DCGraphics(paintEventArgs_0.Graphics), rectangleF, method_34());
						tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
					}
					goto IL_0284;
				}
				rectangleF.Inflate(1f, 1f);
				if (method_14().Config.BackColor.A != 0)
				{
					paintEventArgs_0.Graphics.FillRectangle(GClass438.smethod_0(method_14().Config.BackColor), rectangleF);
				}
				RectangleF rect = RectangleF.Intersect(rectangleF_0, rectangleF);
				if (!rect.IsEmpty)
				{
					float tickCountFloat2 = CountDown.GetTickCountFloat();
					paintEventArgs_0.Graphics.FillRectangle(GClass438.smethod_0(method_19()), rect);
					paintEventArgs_0.Graphics.DrawRectangle(Pens.Black, rectangleF_0.Left, rectangleF_0.Top, rectangleF_0.Width, rectangleF_0.Height);
					tickCountFloat2 = CountDown.GetTickCountFloat() - tickCountFloat2;
					tickCountFloat2 = CountDown.GetTickCountFloat() - tickCountFloat2;
					if (rectangleF.IntersectsWith(temperatureDocument_0.Bounds))
					{
						method_14().PageIndex = method_12();
						tickCountFloat2 = CountDown.GetTickCountFloat() - tickCountFloat2;
						float tickCountFloat = CountDown.GetTickCountFloat();
						method_14().method_29(new DCGraphics(paintEventArgs_0.Graphics), rectangleF, GEnum22.const_2);
						tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
					}
					tickCountFloat2 = CountDown.GetTickCountFloat() - tickCountFloat2;
					TemperatureDocument.smethod_0(method_14())?.method_28(paintEventArgs_0.Graphics, rectangleF_0, bool_7: true);
					goto IL_0284;
				}
				goto end_IL_0001;
				IL_0284:
				method_55();
				end_IL_0001:;
			}
			catch (Exception ex)
			{
				using (StringFormat stringFormat = new StringFormat())
				{
					stringFormat.Alignment = StringAlignment.Near;
					stringFormat.LineAlignment = StringAlignment.Center;
					paintEventArgs_0.Graphics.DrawString(ex.ToString(), Font, Brushes.Red, new RectangleF(0f, 0f, base.ClientSize.Width, base.ClientSize.Height), stringFormat);
				}
			}
		}

		public void method_39(int int_2)
		{
			using (PrintDialog printDialog = new PrintDialog())
			{
				printDialog.AllowCurrentPage = false;
				printDialog.AllowSelection = false;
				printDialog.AllowSomePages = false;
				if (printDialog.ShowDialog(this) == DialogResult.OK)
				{
					using (TemperaturePrintDocument temperaturePrintDocument = new TemperaturePrintDocument(method_14()))
					{
						if (int_2 >= 0)
						{
							temperaturePrintDocument.SpecifyPageIndex = int_2;
						}
						temperaturePrintDocument.PrinterSettings = printDialog.PrinterSettings;
						temperaturePrintDocument.Print();
					}
				}
			}
		}

		public void method_40(Stream stream_0)
		{
			int num = 8;
			if (stream_0 == null)
			{
				throw new ArgumentNullException("stream");
			}
			TemperatureDocument temperatureDocument = new TemperatureDocument();
			if (temperatureDocument.Load(stream_0))
			{
				method_41(temperatureDocument);
			}
		}

		internal void method_41(TemperatureDocument temperatureDocument_1)
		{
			int num = 0;
			if (temperatureDocument_1 == null)
			{
				throw new ArgumentNullException("doc");
			}
			method_15(temperatureDocument_1);
			if (base.IsHandleCreated)
			{
				method_24();
				method_14().LayoutInvalidate = true;
				method_28();
				Invalidate();
				method_44().method_5();
			}
		}

		public void method_42(Stream stream_0)
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

		internal int method_43()
		{
			return int_1;
		}

		internal Class161 method_44()
		{
			if (class161_0 == null)
			{
				class161_0 = new Class161();
				class161_0.method_1(base.Parent as TemperatureControl);
				class161_0.method_3(this);
			}
			return class161_0;
		}

		public void method_45(EditValuePointEventHandler editValuePointEventHandler_1)
		{
			EditValuePointEventHandler editValuePointEventHandler = editValuePointEventHandler_0;
			EditValuePointEventHandler editValuePointEventHandler2;
			do
			{
				editValuePointEventHandler2 = editValuePointEventHandler;
				EditValuePointEventHandler value = (EditValuePointEventHandler)Delegate.Combine(editValuePointEventHandler2, editValuePointEventHandler_1);
				editValuePointEventHandler = Interlocked.CompareExchange(ref editValuePointEventHandler_0, value, editValuePointEventHandler2);
			}
			while ((object)editValuePointEventHandler != editValuePointEventHandler2);
		}

		public void method_46(EditValuePointEventHandler editValuePointEventHandler_1)
		{
			EditValuePointEventHandler editValuePointEventHandler = editValuePointEventHandler_0;
			EditValuePointEventHandler editValuePointEventHandler2;
			do
			{
				editValuePointEventHandler2 = editValuePointEventHandler;
				EditValuePointEventHandler value = (EditValuePointEventHandler)Delegate.Remove(editValuePointEventHandler2, editValuePointEventHandler_1);
				editValuePointEventHandler = Interlocked.CompareExchange(ref editValuePointEventHandler_0, value, editValuePointEventHandler2);
			}
			while ((object)editValuePointEventHandler != editValuePointEventHandler2);
		}

		internal void method_47(EditValuePointEventArgs editValuePointEventArgs_0)
		{
			if (toolTip_0 != null)
			{
				toolTip_0.SetToolTip(this, null);
			}
			switch (method_14().Config.EditValuePointMode)
			{
			case EditValuePointEventHandleMode.None:
				editValuePointEventArgs_0.Result = false;
				break;
			case EditValuePointEventHandleMode.Program:
				if (editValuePointEventHandler_0 != null)
				{
					editValuePointEventHandler_0(this, editValuePointEventArgs_0);
				}
				break;
			case EditValuePointEventHandleMode.Silent:
				editValuePointEventArgs_0.Result = true;
				break;
			case EditValuePointEventHandleMode.OwnedUI:
				switch (editValuePointEventArgs_0.EditMode)
				{
				case EditValuePointMode.Insert:
				{
					using (dlgEditSingleValue dlgEditSingleValue = new dlgEditSingleValue())
					{
						dlgEditSingleValue.Text = string.Format(DCTimeLineStrings.NewValuePoint_Name, editValuePointEventArgs_0.SerialTitle);
						if (editValuePointEventArgs_0.YAxisInfo != null)
						{
							dlgEditSingleValue.InputTimePrecision = editValuePointEventArgs_0.YAxisInfo.InputTimePrecision;
						}
						else if (editValuePointEventArgs_0.TitleLineInfo != null)
						{
							dlgEditSingleValue.InputTimePrecision = editValuePointEventArgs_0.TitleLineInfo.InputTimePrecision;
						}
						dlgEditSingleValue.InputTitle = editValuePointEventArgs_0.SerialTitle;
						dlgEditSingleValue.InputTime = editValuePointEventArgs_0.ValuePoint.Time;
						dlgEditSingleValue.EnableInputTime = true;
						dlgEditSingleValue.InputValue = editValuePointEventArgs_0.ValuePoint.ValueString;
						dlgEditSingleValue.Tag = editValuePointEventArgs_0.ValuePoint;
						dlgEditSingleValue.EventOKButtonClick += method_48;
						if (dlgEditSingleValue.ShowDialog(this) == DialogResult.OK)
						{
							editValuePointEventArgs_0.ValuePoint.Time = dlgEditSingleValue.InputTime;
							float result = 0f;
							if (float.TryParse(dlgEditSingleValue.InputValue, out result))
							{
								editValuePointEventArgs_0.ValuePoint.Value = result;
							}
							editValuePointEventArgs_0.Result = true;
						}
						else
						{
							editValuePointEventArgs_0.Result = false;
						}
					}
					break;
				}
				case EditValuePointMode.Delete:
				{
					string text = string.Format(DCTimeLineStrings.PromptDeleteValuePoint_Title_Time_Value, editValuePointEventArgs_0.SerialTitle, editValuePointEventArgs_0.ValuePoint.Time, editValuePointEventArgs_0.ValuePoint.RuntimeText);
					if (MessageBox.Show(this, text, DCTimeLineStrings.SystemAlert, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						editValuePointEventArgs_0.Result = true;
					}
					else
					{
						editValuePointEventArgs_0.Result = false;
					}
					break;
				}
				case EditValuePointMode.Update:
				{
					using (dlgEditSingleValue dlgEditSingleValue = new dlgEditSingleValue())
					{
						dlgEditSingleValue.Text = string.Format(DCTimeLineStrings.EditValuePoint_Title, editValuePointEventArgs_0.SerialTitle);
						if (editValuePointEventArgs_0.YAxisInfo != null)
						{
							dlgEditSingleValue.InputTimePrecision = editValuePointEventArgs_0.YAxisInfo.InputTimePrecision;
						}
						else if (editValuePointEventArgs_0.TitleLineInfo != null)
						{
							dlgEditSingleValue.InputTimePrecision = editValuePointEventArgs_0.TitleLineInfo.InputTimePrecision;
						}
						dlgEditSingleValue.InputTitle = editValuePointEventArgs_0.SerialTitle;
						dlgEditSingleValue.InputTime = editValuePointEventArgs_0.ValuePoint.Time;
						dlgEditSingleValue.EnableInputTime = false;
						dlgEditSingleValue.InputValue = editValuePointEventArgs_0.ValuePoint.ValueString;
						dlgEditSingleValue.Tag = editValuePointEventArgs_0.ValuePoint;
						dlgEditSingleValue.EventOKButtonClick += method_48;
						if (dlgEditSingleValue.ShowDialog(this) == DialogResult.OK)
						{
							float result = 0f;
							if (float.TryParse(dlgEditSingleValue.InputValue, out result))
							{
								editValuePointEventArgs_0.ValuePoint.Value = result;
							}
							editValuePointEventArgs_0.Result = true;
						}
						else
						{
							editValuePointEventArgs_0.Result = false;
						}
					}
					break;
				}
				}
				break;
			}
		}

		private void method_48(object sender, CancelEventArgs e)
		{
			dlgEditSingleValue dlgEditSingleValue = (dlgEditSingleValue)sender;
			ValuePoint valuePoint = (ValuePoint)dlgEditSingleValue.Tag;
			string string_ = null;
			float num = float.NaN;
			if (valuePoint.Parent is YAxisInfo)
			{
				YAxisInfo yAxisInfo = (YAxisInfo)valuePoint.Parent;
				num = Class157.smethod_2(dlgEditSingleValue.InputValue, yAxisInfo.MaxValue, yAxisInfo.MinValue, ref string_, bool_0: true, yAxisInfo.AllowOutofRange);
				if (!string.IsNullOrEmpty(string_))
				{
					MessageBox.Show(dlgEditSingleValue, string_, dlgEditSingleValue.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					e.Cancel = true;
				}
				dlgEditSingleValue.ResultValue = num;
			}
		}

		public void method_49(TimeLineZoneEventHandler timeLineZoneEventHandler_2)
		{
			TimeLineZoneEventHandler timeLineZoneEventHandler = timeLineZoneEventHandler_0;
			TimeLineZoneEventHandler timeLineZoneEventHandler2;
			do
			{
				timeLineZoneEventHandler2 = timeLineZoneEventHandler;
				TimeLineZoneEventHandler value = (TimeLineZoneEventHandler)Delegate.Combine(timeLineZoneEventHandler2, timeLineZoneEventHandler_2);
				timeLineZoneEventHandler = Interlocked.CompareExchange(ref timeLineZoneEventHandler_0, value, timeLineZoneEventHandler2);
			}
			while ((object)timeLineZoneEventHandler != timeLineZoneEventHandler2);
		}

		public void method_50(TimeLineZoneEventHandler timeLineZoneEventHandler_2)
		{
			TimeLineZoneEventHandler timeLineZoneEventHandler = timeLineZoneEventHandler_0;
			TimeLineZoneEventHandler timeLineZoneEventHandler2;
			do
			{
				timeLineZoneEventHandler2 = timeLineZoneEventHandler;
				TimeLineZoneEventHandler value = (TimeLineZoneEventHandler)Delegate.Remove(timeLineZoneEventHandler2, timeLineZoneEventHandler_2);
				timeLineZoneEventHandler = Interlocked.CompareExchange(ref timeLineZoneEventHandler_0, value, timeLineZoneEventHandler2);
			}
			while ((object)timeLineZoneEventHandler != timeLineZoneEventHandler2);
		}

		public void method_51(TimeLineZoneEventHandler timeLineZoneEventHandler_2)
		{
			TimeLineZoneEventHandler timeLineZoneEventHandler = timeLineZoneEventHandler_1;
			TimeLineZoneEventHandler timeLineZoneEventHandler2;
			do
			{
				timeLineZoneEventHandler2 = timeLineZoneEventHandler;
				TimeLineZoneEventHandler value = (TimeLineZoneEventHandler)Delegate.Combine(timeLineZoneEventHandler2, timeLineZoneEventHandler_2);
				timeLineZoneEventHandler = Interlocked.CompareExchange(ref timeLineZoneEventHandler_1, value, timeLineZoneEventHandler2);
			}
			while ((object)timeLineZoneEventHandler != timeLineZoneEventHandler2);
		}

		public void method_52(TimeLineZoneEventHandler timeLineZoneEventHandler_2)
		{
			TimeLineZoneEventHandler timeLineZoneEventHandler = timeLineZoneEventHandler_1;
			TimeLineZoneEventHandler timeLineZoneEventHandler2;
			do
			{
				timeLineZoneEventHandler2 = timeLineZoneEventHandler;
				TimeLineZoneEventHandler value = (TimeLineZoneEventHandler)Delegate.Remove(timeLineZoneEventHandler2, timeLineZoneEventHandler_2);
				timeLineZoneEventHandler = Interlocked.CompareExchange(ref timeLineZoneEventHandler_1, value, timeLineZoneEventHandler2);
			}
			while ((object)timeLineZoneEventHandler != timeLineZoneEventHandler2);
		}

		public void method_53(EventHandler eventHandler_3)
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

		public void method_54(EventHandler eventHandler_3)
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
			method_56();
			if (method_44().method_13(this, mevent))
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
				foreach (TimeLineZoneInfo zone in method_14().Config.Zones)
				{
					if (zone.ExpandedHandleBounds.Contains(pointF.X, pointF.Y))
					{
						zone.IsExpanded = !zone.IsExpanded;
						method_28();
						Invalidate();
						if (zone.IsExpanded)
						{
							if (timeLineZoneEventHandler_1 != null)
							{
								TimeLineZoneEventArgs e = new TimeLineZoneEventArgs(method_14(), zone);
								timeLineZoneEventHandler_1(this, e);
							}
						}
						else if (timeLineZoneEventHandler_0 != null)
						{
							TimeLineZoneEventArgs e = new TimeLineZoneEventArgs(method_14(), zone);
							timeLineZoneEventHandler_0(this, e);
						}
						int_1 = Environment.TickCount + 300;
						return;
					}
				}
			}
			if (mevent.Button != MouseButtons.Left || method_4() != Enum16.const_1)
			{
				return;
			}
			pointF = method_31(mevent.X, mevent.Y);
			object obj = method_14().method_10(pointF.X, pointF.Y);
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

		private void method_55()
		{
			if (Environment.TickCount - long_0 > 100L && method_8() && !point_2.IsEmpty)
			{
				GClass146.smethod_0(base.Handle, 0, point_2.Y, base.ClientSize.Width, point_2.Y);
				GClass146.smethod_0(base.Handle, point_2.X, 0, point_2.X, base.ClientSize.Height);
			}
		}

		private void method_56()
		{
			if (!point_2.IsEmpty)
			{
				method_55();
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
			if (!kevent.Handled && !method_44().method_15(kevent))
			{
				method_57(kevent);
			}
		}

		internal void method_57(KeyEventArgs keyEventArgs_0)
		{
			if (method_10() != DocumentViewMode.Timeline)
			{
				return;
			}
			Point autoScrollPosition = new Point(-base.AutoScrollPosition.X, -base.AutoScrollPosition.Y);
			if (keyEventArgs_0.KeyCode == Keys.Left || keyEventArgs_0.KeyCode == Keys.Up)
			{
				autoScrollPosition.Offset(-(int)method_14().TickViewWidth, 0);
				method_56();
				base.AutoScrollPosition = autoScrollPosition;
			}
			else if (keyEventArgs_0.KeyCode == Keys.Right || keyEventArgs_0.KeyCode == Keys.Down)
			{
				autoScrollPosition.Offset((int)method_14().TickViewWidth, 0);
				method_56();
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
				method_56();
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
				method_56();
				base.AutoScrollPosition = autoScrollPosition;
			}
			else if (keyEventArgs_0.KeyCode == Keys.Home)
			{
				autoScrollPosition = new Point(0, 0);
				method_56();
				base.AutoScrollPosition = autoScrollPosition;
			}
			else if (keyEventArgs_0.KeyCode == Keys.End)
			{
				autoScrollPosition = new Point(base.AutoScrollMinSize.Width, 0);
				method_56();
				base.AutoScrollPosition = autoScrollPosition;
			}
		}

		protected override void OnMouseLeave(EventArgs eventArgs_0)
		{
			base.OnMouseLeave(eventArgs_0);
			method_55();
			point_2 = Point.Empty;
			method_58(null);
		}

		protected override void OnMouseWheel(MouseEventArgs mouseEventArgs_0)
		{
			method_55();
			point_2 = Point.Empty;
			base.OnMouseWheel(mouseEventArgs_0);
		}

		protected override void OnMouseClick(MouseEventArgs mouseEventArgs_0)
		{
			base.OnMouseClick(mouseEventArgs_0);
		}

		private void method_58(ValuePoint valuePoint_0)
		{
			if (method_14().MouseHoverValuePoint != valuePoint_0)
			{
				if (method_14().MouseHoverValuePoint != null && method_14().Config.LinkVisualStyle == DocumentLinkVisualStyle.Hover && !string.IsNullOrEmpty(method_14().MouseHoverValuePoint.Link))
				{
					method_59(method_14().MouseHoverValuePoint);
				}
				method_14().MouseHoverValuePoint = valuePoint_0;
				if (valuePoint_0 != null && method_14().Config.LinkVisualStyle == DocumentLinkVisualStyle.Hover && !string.IsNullOrEmpty(valuePoint_0.Link))
				{
					method_59(valuePoint_0);
				}
			}
		}

		private void method_59(ValuePoint valuePoint_0)
		{
			if (valuePoint_0 != null)
			{
				RectangleF rectangleF = method_36().vmethod_23(valuePoint_0.ViewBounds);
				Invalidate(new Rectangle((int)rectangleF.Left - 2, (int)rectangleF.Top - 2, (int)rectangleF.Width + 4, (int)rectangleF.Height + 4));
			}
		}

		protected override void OnMouseMove(MouseEventArgs mevent)
		{
			int num = 8;
			base.OnMouseMove(mevent);
			if (method_44().method_12(this, mevent))
			{
				return;
			}
			ValuePoint valuePoint_ = null;
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
					method_55();
					point_2 = new Point(mevent.X, mevent.Y);
					method_55();
				}
				if (method_14().Config.ShowTooltip)
				{
					if (toolTip_0 == null)
					{
						toolTip_0 = new ToolTip();
					}
					if (string.IsNullOrEmpty(method_14().Config.TitleForToolTip))
					{
						toolTip_0.ToolTipTitle = DCTimeLineStrings.SystemAlert;
					}
					else
					{
						toolTip_0.ToolTipTitle = method_14().Config.TitleForToolTip;
					}
					string text = null;
					PointF pt = method_31(mevent.X, mevent.Y);
					TitleLineInfoList titleLineInfoList = new TitleLineInfoList();
					titleLineInfoList.AddRange(method_14().RuntimeHeaderLines);
					titleLineInfoList.AddRange(method_14().RuntimeFooterLines);
					if (method_14().Config.DebugMode)
					{
						foreach (TitleLineInfo item in titleLineInfoList)
						{
							if (item.ValueType == TitleLineValueType.HourTick)
							{
								RectangleF rectangleF = new RectangleF(method_14().DataGridBounds.Left, item.Top, method_14().DataGridBounds.Width, item.Height);
								if (rectangleF.Contains(pt))
								{
									foreach (Class158 runtimeTick in method_14().RuntimeTicks)
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
						foreach (TitleLineInfo item2 in titleLineInfoList)
						{
							if (item2.ShowExpandedHandle && item2.ExpandedHandleBounds.Contains(pt))
							{
								text = DCTimeLineStrings.PromptExpandedCollapseTitleLine;
								break;
							}
						}
					}
					if (text == null && method_14().Config.AllowUserCollapseZone && method_14().Config.Zones != null)
					{
						foreach (TimeLineZoneInfo zone in method_14().Config.Zones)
						{
							if (!zone.ExpandedHandleBounds.IsEmpty && zone.ExpandedHandleBounds.Contains(pt.X, pt.Y))
							{
								text = DCTimeLineStrings.PromptExpandedCollapseZone;
								break;
							}
						}
					}
					Cursor = Cursors.Arrow;
					if (text == null)
					{
						ValuePoint valuePoint = method_61(pt.X, pt.Y);
						valuePoint_ = valuePoint;
						if (valuePoint != null)
						{
							text = ((!string.IsNullOrEmpty(valuePoint.Title)) ? valuePoint.Title : (string.IsNullOrEmpty(valuePoint.Link) ? valuePoint.RuntimeTitle : valuePoint.Link));
							if (method_14().Config.DebugMode)
							{
								text = text + Environment.NewLine + "Bounds:" + valuePoint.ViewBounds.ToString() + Environment.NewLine + "PIndex:" + valuePoint.InstanceIndex + Environment.NewLine + "Time:" + valuePoint.Time.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine + "Text:" + valuePoint.Text + Environment.NewLine + "Value:" + valuePoint.Value.ToString();
							}
							if (!string.IsNullOrEmpty(valuePoint.Link) && (method_44() == null || !method_44().method_4() || method_44().method_18() == Enum17.const_0))
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
			method_58(valuePoint_);
		}

		internal void method_60(string string_1, bool bool_4)
		{
			if (toolTip_0 == null)
			{
				toolTip_0 = new ToolTip();
			}
			if (string.IsNullOrEmpty(method_14().Config.TitleForToolTip))
			{
				toolTip_0.ToolTipTitle = DCTimeLineStrings.SystemAlert;
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
			method_56();
			long_0 = Environment.TickCount;
			base.OnScroll(scrollEventArgs_0);
		}

		internal ValuePoint method_61(float float_0, float float_1)
		{
			lock (method_14())
			{
				for (int num = method_14().Config.YAxisInfos.Count - 1; num >= 0; num--)
				{
					YAxisInfo yAxisInfo = method_14().Config.YAxisInfos[num];
					if (yAxisInfo.Visible && yAxisInfo.ValueVisible)
					{
						ValuePointList valuesByName = method_14().Datas.GetValuesByName(yAxisInfo.Name);
						if (yAxisInfo.Style == YAxisInfoStyle.Text)
						{
							foreach (ValuePoint item in valuesByName)
							{
								if (item.ViewBounds.Contains(float_0, float_1))
								{
									return item;
								}
							}
						}
						else if (yAxisInfo.Style == YAxisInfoStyle.Value)
						{
							foreach (ValuePoint item2 in valuesByName)
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
				foreach (TitleLineInfo runtimeFooterLine in method_14().RuntimeFooterLines)
				{
					ValuePointList valuesByName = method_14().Datas.GetValuesByName(runtimeFooterLine.Name);
					foreach (ValuePoint item3 in valuesByName)
					{
						if (item3.ViewBounds.Contains(float_0, float_1))
						{
							return item3;
						}
					}
				}
				foreach (TitleLineInfo runtimeHeaderLine in method_14().RuntimeHeaderLines)
				{
					ValuePointList valuesByName = method_14().Datas.GetValuesByName(runtimeHeaderLine.Name);
					foreach (ValuePoint item4 in valuesByName)
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

		public void method_62(EventHandler eventHandler_3)
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

		public void method_63(EventHandler eventHandler_3)
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
			if (method_44().method_14(this, mevent))
			{
				return;
			}
			point_0 = Point.Empty;
			if (Math.Abs(mevent.X - point_1.X) >= SystemInformation.DragSize.Width || Math.Abs(mevent.Y - point_1.Y) >= SystemInformation.DragSize.Height || mevent.Button != MouseButtons.Left)
			{
				return;
			}
			PointF pointF = method_31(mevent.X, mevent.Y);
			if (method_4() != Enum16.const_1 && method_65(mevent.X, mevent.Y))
			{
				return;
			}
			if (method_14().InnerBehaviorMode != Enum16.const_1 && mevent.Button == MouseButtons.Left)
			{
				ValuePoint valuePoint = method_61(pointF.X, pointF.Y);
				if (valuePoint != null && valuePointClickEventHandler_0 != null)
				{
					ValuePointClickEventArgs e = new ValuePointClickEventArgs(valuePoint);
					valuePointClickEventHandler_0(this, e);
				}
				if (valuePoint != null && !string.IsNullOrEmpty(valuePoint.Link))
				{
					DocumentLinkClickEventArgs documentLinkClickEventArgs_ = new DocumentLinkClickEventArgs(method_3(), method_14(), valuePoint, valuePoint.Link, valuePoint.LinkTarget);
					method_3().method_5(documentLinkClickEventArgs_);
					return;
				}
			}
			if (!method_64(mevent) && method_4() != Enum16.const_1 && eventHandler_2 != null)
			{
				object obj = method_14().method_10(pointF.X, pointF.Y);
				if (obj is HeaderLabelInfo)
				{
					eventHandler_2(obj, null);
				}
			}
		}

		private bool method_64(MouseEventArgs mouseEventArgs_0)
		{
			PointF pt = method_31(mouseEventArgs_0.X, mouseEventArgs_0.Y);
			TemperatureDocument temperatureDocument = method_14();
			if (!temperatureDocument.DataGridBounds.Contains(pt))
			{
				return false;
			}
			YAxisInfo yAxisInfo = null;
			for (int num = method_14().VisibleYAxisInfos.Count - 1; num >= 0; num--)
			{
				YAxisInfo yAxisInfo2 = method_14().VisibleYAxisInfos[num];
				if (yAxisInfo2.Style == YAxisInfoStyle.Value && yAxisInfo2.ValueVisible)
				{
					ValuePointList valuePointList = temperatureDocument.method_19(yAxisInfo2.Name);
					if (valuePointList != null && valuePointList.Count > 0)
					{
						DateTime dateTime = method_14().RuntimeTicks.method_15(temperatureDocument.DataGridBounds, pt.X);
						if (!TemperatureDocument.smethod_4(dateTime))
						{
							int floorIndexByTime = valuePointList.GetFloorIndexByTime(dateTime);
							int num2 = Math.Max(0, floorIndexByTime - 10);
							Math.Max(valuePointList.Count - 1, floorIndexByTime + 10);
							PointF pointF = PointF.Empty;
							for (int i = num2; i < valuePointList.Count; i++)
							{
								ValuePoint valuePoint = valuePointList[i];
								RectangleF viewBounds = valuePoint.ViewBounds;
								if (viewBounds.IsEmpty)
								{
									pointF = PointF.Empty;
									continue;
								}
								if (viewBounds.Contains(pt))
								{
									yAxisInfo = yAxisInfo2;
									break;
								}
								PointF pointF2 = new PointF(viewBounds.Left + viewBounds.Width / 2f, viewBounds.Top + viewBounds.Height / 2f);
								if (!pointF.IsEmpty)
								{
									double num3 = MathCommon.smethod_20(pointF2.X, pointF2.Y, pointF.X, pointF.Y, pt.X, pt.Y, bool_0: true);
									if (num3 >= 0.0 && num3 <= (double)(viewBounds.Height / 2f))
									{
										yAxisInfo = yAxisInfo2;
										break;
									}
								}
								pointF = pointF2;
							}
						}
					}
					if (yAxisInfo != null)
					{
						break;
					}
				}
			}
			if (yAxisInfo == null)
			{
				return false;
			}
			if (temperatureDocument.Config.SelectionMode == DCTimeLineSelectionMode.MultiSelec)
			{
				yAxisInfo.Selected = !yAxisInfo.Selected;
			}
			else if (temperatureDocument.Config.SelectionMode == DCTimeLineSelectionMode.SingleSelect)
			{
				yAxisInfo.Selected = !yAxisInfo.Selected;
				foreach (YAxisInfo yAxisInfo3 in temperatureDocument.Config.YAxisInfos)
				{
					if (yAxisInfo3 != yAxisInfo)
					{
						yAxisInfo3.Selected = false;
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

		internal bool method_65(int int_2, int int_3)
		{
			PointF pointF = method_31(int_2, int_3);
			TitleLineInfoList titleLineInfoList = new TitleLineInfoList();
			titleLineInfoList.AddRange(method_14().RuntimeHeaderLines);
			titleLineInfoList.AddRange(method_14().RuntimeFooterLines);
			foreach (TitleLineInfo item in titleLineInfoList)
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
			foreach (YAxisInfo yAxisInfo in method_14().YAxisInfos)
			{
				if (yAxisInfo.bool_13 && yAxisInfo.ClickToHide && new RectangleF(yAxisInfo.TitleLeft, yAxisInfo.TitleTop, yAxisInfo.TitleWidth, yAxisInfo.TitleHeight).Contains(pointF.X, pointF.Y))
				{
					yAxisInfo.ValueVisible = !yAxisInfo.ValueVisible;
					method_14().method_14();
					Invalidate();
					return true;
				}
			}
			if (eventHandler_2 != null)
			{
				object obj = method_14().method_10(pointF.X, pointF.Y);
				if (obj is HeaderLabelInfo)
				{
					eventHandler_2(obj, null);
				}
			}
			return false;
		}

		internal void method_66(EventHandler eventHandler_3)
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

		internal void method_67(EventHandler eventHandler_3)
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

		public void method_68()
		{
			MessageBox.Show(this, "都昌时间轴控件(DCTimeline)，是南京都昌信息科技有限公司开发的医疗行业使用的时间轴控件，适用于.NET平台。南京都昌信息科技有限公司专业研发医学数据可视化技术，并自主研发了电子病历编辑器软件、时间轴控件等等，公司网址 www.dcwriter.cn。", "关于...");
		}
	}
}
