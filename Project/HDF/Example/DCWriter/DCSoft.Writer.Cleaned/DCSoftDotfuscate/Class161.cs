using DCSoft.TemperatureChart;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal class Class161
	{
		private TemperatureControl temperatureControl_0 = null;

		private GControl1 gcontrol1_0 = null;

		private YAxisInfo yaxisInfo_0 = null;

		private ValuePoint valuePoint_0 = null;

		private Point point_0 = Point.Empty;

		private static Cursor cursor_0 = null;

		private static Cursor cursor_1 = null;

		private static Cursor cursor_2 = null;

		private Enum17 enum17_0 = Enum17.const_0;

		public TemperatureControl method_0()
		{
			return temperatureControl_0;
		}

		public void method_1(TemperatureControl temperatureControl_1)
		{
			temperatureControl_0 = temperatureControl_1;
			if (temperatureControl_0 != null)
			{
				gcontrol1_0 = temperatureControl_0.InnerViewControl;
			}
		}

		public GControl1 method_2()
		{
			return gcontrol1_0;
		}

		public void method_3(GControl1 gcontrol1_1)
		{
			gcontrol1_0 = gcontrol1_1;
		}

		public bool method_4()
		{
			return !method_2().method_14().Config.Readonly || method_2().method_14().Config.EditValuePointMode != EditValuePointEventHandleMode.None;
		}

		public bool method_5()
		{
			if (method_18() != 0)
			{
				enum17_0 = Enum17.const_0;
				method_2().Cursor = Cursors.Arrow;
				if (yaxisInfo_0 != null)
				{
					yaxisInfo_0.Selected = false;
					yaxisInfo_0 = null;
					temperatureControl_0.Invalidate(invalidateChildren: true);
					gcontrol1_0.method_60(null, bool_4: false);
				}
				return true;
			}
			return false;
		}

		public void method_6()
		{
			if (method_4())
			{
				enum17_0 = Enum17.const_2;
				if (yaxisInfo_0 != null)
				{
					yaxisInfo_0.Selected = false;
					yaxisInfo_0 = null;
					temperatureControl_0.Invalidate(invalidateChildren: true);
				}
			}
		}

		public void method_7()
		{
			if (method_4())
			{
				enum17_0 = Enum17.const_4;
				if (yaxisInfo_0 != null)
				{
					yaxisInfo_0.Selected = false;
				}
				yaxisInfo_0 = null;
				temperatureControl_0.Invalidate(invalidateChildren: true);
			}
		}

		public void method_8()
		{
			if (method_4())
			{
				enum17_0 = Enum17.const_5;
				if (yaxisInfo_0 != null)
				{
					yaxisInfo_0.Selected = false;
				}
				yaxisInfo_0 = null;
				temperatureControl_0.Invalidate(invalidateChildren: true);
			}
		}

		public void method_9(YAxisInfo yaxisInfo_1)
		{
			int num = 5;
			if (yaxisInfo_1 == null)
			{
				throw new ArgumentNullException("info");
			}
			if (method_4())
			{
				TemperatureDocument temperatureDocument = gcontrol1_0.method_14();
				if (!temperatureDocument.Config.YAxisInfos.Contains(yaxisInfo_1))
				{
					throw new ArgumentOutOfRangeException("Info:" + yaxisInfo_1.Name);
				}
				foreach (YAxisInfo yAxisInfo in temperatureDocument.Config.YAxisInfos)
				{
					yAxisInfo.Selected = false;
				}
				yaxisInfo_1.ValueVisible = true;
				yaxisInfo_1.Selected = true;
				enum17_0 = Enum17.const_1;
				temperatureControl_0.Invalidate(invalidateChildren: true);
				yaxisInfo_0 = yaxisInfo_1;
			}
		}

		private bool method_10()
		{
			return enum17_0 == Enum17.const_1 && yaxisInfo_0 != null;
		}

		public bool method_11(YAxisInfo yaxisInfo_1)
		{
			return enum17_0 == Enum17.const_1 && yaxisInfo_0 == yaxisInfo_1;
		}

		public bool method_12(object object_0, MouseEventArgs mouseEventArgs_0)
		{
			int num = 18;
			if (!method_4())
			{
				return false;
			}
			Control control = object_0 as Control;
			switch (enum17_0)
			{
			default:
				return false;
			case Enum17.const_1:
			{
				if (control != null)
				{
					control.Cursor = smethod_0();
				}
				ValuePoint valuePoint = method_16(yaxisInfo_0, mouseEventArgs_0.X, mouseEventArgs_0.Y);
				string string_ = null;
				if (valuePoint != null)
				{
					string_ = string.Format(DCTimeLineStrings.NewValuePoint_Name, yaxisInfo_0.Title) + Environment.NewLine + DCTimeLineStrings.Time + ":" + valuePoint.Time.ToString(Class157.smethod_0(yaxisInfo_0.InputTimePrecision)) + Environment.NewLine + DCTimeLineStrings.Value + ":" + valuePoint.Value;
				}
				method_2().method_60(string_, bool_4: true);
				return true;
			}
			case Enum17.const_2:
				if (control != null)
				{
					PointF pointF = method_2().method_31(mouseEventArgs_0.X, mouseEventArgs_0.Y);
					ValuePoint valuePoint2 = method_2().method_61(pointF.X, pointF.Y);
					if (valuePoint2 == null)
					{
						return false;
					}
					control.Cursor = smethod_2();
					return true;
				}
				return true;
			case Enum17.const_3:
				return true;
			case Enum17.const_4:
			case Enum17.const_5:
				if (valuePoint_0 != null && mouseEventArgs_0.Button == MouseButtons.Left)
				{
					if (control != null)
					{
						control.Cursor = smethod_1();
					}
					YAxisInfo yAxisInfo = (YAxisInfo)valuePoint_0.Parent;
					if (yAxisInfo == null)
					{
						return true;
					}
					ValuePoint valuePoint = method_16(yAxisInfo, mouseEventArgs_0.X, mouseEventArgs_0.Y);
					method_2().method_14();
					string string_ = null;
					if (valuePoint != null)
					{
						DateTime time = valuePoint_0.Time;
						if (method_18() == Enum17.const_4)
						{
							time = valuePoint.Time;
						}
						string_ = string.Format(DCTimeLineStrings.DragValuePoint_Name, yAxisInfo.Title) + Environment.NewLine + DCTimeLineStrings.Time + ":" + time.ToString(Class157.smethod_0(yAxisInfo.InputTimePrecision)) + Environment.NewLine + DCTimeLineStrings.Value + ":" + valuePoint.Value;
					}
					method_2().method_60(string_, bool_4: true);
					return true;
				}
				if (control != null)
				{
					control.Cursor = Cursors.Arrow;
				}
				return false;
			}
		}

		public bool method_13(object object_0, MouseEventArgs mouseEventArgs_0)
		{
			int num = 7;
			if (!method_4())
			{
				return false;
			}
			if (method_18() == Enum17.const_2)
			{
				TemperatureDocument temperatureDocument = method_2().method_14();
				PointF pointF = method_2().method_31(mouseEventArgs_0.X, mouseEventArgs_0.Y);
				ValuePoint valuePoint = method_2().method_61(pointF.X, pointF.Y);
				if (valuePoint != null)
				{
					EditValuePointEventArgs editValuePointEventArgs = new EditValuePointEventArgs(temperatureControl_0, temperatureDocument, valuePoint, EditValuePointMode.Delete);
					editValuePointEventArgs.Result = true;
					method_2().method_47(editValuePointEventArgs);
					if (editValuePointEventArgs.Result)
					{
						ValuePointList ownerList = valuePoint.OwnerList;
						ownerList.Remove(valuePoint);
						temperatureDocument.Modified = true;
						method_2().Invalidate();
					}
					return true;
				}
				return false;
			}
			if (method_18() == Enum17.const_1)
			{
				TemperatureDocument temperatureDocument = method_2().method_14();
				if (yaxisInfo_0 != null)
				{
					ValuePoint valuePoint2 = method_16(yaxisInfo_0, mouseEventArgs_0.X, mouseEventArgs_0.Y);
					if (valuePoint2 != null)
					{
						valuePoint2.Time = Class157.smethod_1(valuePoint2.Time, yaxisInfo_0.InputTimePrecision);
						valuePoint2.Parent = yaxisInfo_0;
						EditValuePointEventArgs editValuePointEventArgs = new EditValuePointEventArgs(temperatureControl_0, temperatureDocument, valuePoint2, EditValuePointMode.Insert);
						editValuePointEventArgs.Result = true;
						if (method_2() != null)
						{
							method_2().method_47(editValuePointEventArgs);
						}
						if (editValuePointEventArgs.Result)
						{
							ValuePointList ownerList = temperatureDocument.method_19(yaxisInfo_0.Name);
							ownerList.Add(valuePoint2);
							ownerList.SortByTime();
							temperatureDocument.Modified = true;
							method_2().Invalidate();
							method_2().method_23();
						}
						return true;
					}
				}
				PointF pointF = method_2().method_31(mouseEventArgs_0.X, mouseEventArgs_0.Y);
				foreach (TitleLineInfo allTitleLine in temperatureDocument.Config.GetAllTitleLines())
				{
					RectangleF rectangleF = new RectangleF(temperatureDocument.DataGridBounds.Left, allTitleLine.Top, temperatureDocument.DataGridBounds.Width, allTitleLine.Height);
					if (rectangleF.Contains(pointF))
					{
						ValuePointList ownerList = temperatureDocument.method_19(allTitleLine.Name);
						DateTime dateTime_ = temperatureDocument.RuntimeTicks.method_15(temperatureDocument.DataGridBounds, pointF.X);
						ValuePoint valuePoint3 = new ValuePoint();
						valuePoint3.Time = Class157.smethod_1(dateTime_, allTitleLine.InputTimePrecision);
						if (ownerList.IsTextMode(allTitleLine))
						{
							valuePoint3.Text = "-";
						}
						else
						{
							valuePoint3.Value = 0f;
						}
						valuePoint3.Value = 0f;
						valuePoint3.Parent = allTitleLine;
						EditValuePointEventArgs editValuePointEventArgs = new EditValuePointEventArgs(temperatureControl_0, temperatureDocument, valuePoint3, EditValuePointMode.Insert);
						editValuePointEventArgs.Result = true;
						if (method_2() != null)
						{
							method_2().method_47(editValuePointEventArgs);
						}
						if (editValuePointEventArgs.Result)
						{
							ownerList.Add(valuePoint3);
							ownerList.SortByTime();
							temperatureDocument.Modified = true;
							method_2().Invalidate();
							method_2().method_23();
						}
						break;
					}
				}
				return true;
			}
			if (method_18() == Enum17.const_4 || method_18() == Enum17.const_5)
			{
				if (mouseEventArgs_0.Button == MouseButtons.Left)
				{
					TemperatureDocument temperatureDocument = method_2().method_14();
					PointF pointF = method_2().method_31(mouseEventArgs_0.X, mouseEventArgs_0.Y);
					if (temperatureDocument.DataGridBounds.Contains(pointF.X, pointF.Y))
					{
						ValuePoint valuePoint = method_2().method_61(pointF.X, pointF.Y);
						if (valuePoint != null)
						{
							YAxisInfo yAxisInfo = valuePoint.Parent as YAxisInfo;
							if (yAxisInfo != null && yAxisInfo.Style == YAxisInfoStyle.Value)
							{
								valuePoint_0 = valuePoint;
								if (method_18() == Enum17.const_5)
								{
									Point point = method_2().method_30(0f, temperatureDocument.DataGridBounds.Top + temperatureDocument.DataGridBounds.Height * yAxisInfo.RuntimeTopPadding);
									Rectangle clip = new Rectangle(height: method_2().method_30(0f, temperatureDocument.DataGridBounds.Bottom - temperatureDocument.DataGridBounds.Height * yAxisInfo.RuntimeBottomPadding).Y - point.Y, x: mouseEventArgs_0.X, y: point.Y, width: 2);
									clip.Location = method_2().PointToScreen(clip.Location);
									Cursor.Clip = clip;
									point_0 = new Point(mouseEventArgs_0.X, mouseEventArgs_0.Y);
									return true;
								}
							}
						}
					}
				}
				return false;
			}
			return false;
		}

		public bool method_14(object object_0, MouseEventArgs mouseEventArgs_0)
		{
			if (!method_4())
			{
				return false;
			}
			Cursor.Clip = Rectangle.Empty;
			if (method_18() == Enum17.const_5 || method_18() == Enum17.const_4)
			{
				if (valuePoint_0 != null)
				{
					if (Math.Abs(point_0.X - mouseEventArgs_0.X) < SystemInformation.DragSize.Width && Math.Abs(point_0.Y - mouseEventArgs_0.Y) < SystemInformation.DragSize.Height)
					{
						return true;
					}
					ValuePoint valuePoint = method_16((YAxisInfo)valuePoint_0.Parent, mouseEventArgs_0.X, mouseEventArgs_0.Y);
					TemperatureDocument temperatureDocument = method_2().method_14();
					if (valuePoint != null)
					{
						ValuePoint valuePoint2 = valuePoint_0.Clone();
						if (method_18() == Enum17.const_4)
						{
							valuePoint2.Time = valuePoint.Time;
						}
						valuePoint2.Value = valuePoint.Value;
						EditValuePointEventArgs editValuePointEventArgs = new EditValuePointEventArgs(temperatureControl_0, temperatureDocument, valuePoint2, EditValuePointMode.Update);
						method_2().method_47(editValuePointEventArgs);
						if (editValuePointEventArgs.Result)
						{
							valuePoint_0.Time = valuePoint2.Time;
							valuePoint_0.Value = valuePoint2.Value;
							method_2().Invalidate();
							temperatureDocument.Modified = true;
							method_2().Cursor = Cursors.Arrow;
							method_2().method_23();
						}
						method_2().method_60(null, bool_4: false);
						valuePoint_0 = null;
					}
				}
				return true;
			}
			if (method_18() == Enum17.const_0)
			{
				return false;
			}
			return true;
		}

		public bool method_15(KeyEventArgs keyEventArgs_0)
		{
			if (!method_4())
			{
				return false;
			}
			if (keyEventArgs_0.KeyCode == Keys.Escape && method_5())
			{
				return true;
			}
			return false;
		}

		private ValuePoint method_16(YAxisInfo yaxisInfo_1, int int_0, int int_1)
		{
			int num = 10;
			if (yaxisInfo_1 == null)
			{
				throw new ArgumentNullException("info");
			}
			TemperatureDocument temperatureDocument = method_2().method_14();
			PointF pointF = method_2().method_31(int_0, int_1);
			if (temperatureDocument.DataGridBounds.Contains(pointF.X, pointF.Y))
			{
				DateTime dateTime = temperatureDocument.RuntimeTicks.method_15(temperatureDocument.DataGridBounds, pointF.X);
				if (TemperatureDocument.smethod_4(dateTime))
				{
					return null;
				}
				float num2 = yaxisInfo_1.method_4(temperatureDocument, temperatureDocument.DataGridBounds, pointF.Y);
				if (TemperatureDocument.smethod_3(num2))
				{
					return null;
				}
				ValuePoint valuePoint = new ValuePoint();
				valuePoint.Time = dateTime;
				valuePoint.Value = num2;
				valuePoint.Parent = yaxisInfo_1;
				return valuePoint;
			}
			return null;
		}

		public void method_17()
		{
			enum17_0 = Enum17.const_0;
			yaxisInfo_0 = null;
		}

		public static Cursor smethod_0()
		{
			int num = 6;
			if (cursor_0 == null)
			{
				Stream manifestResourceStream = typeof(Class157).Assembly.GetManifestResourceStream("DCSoft.TemperatureChart.Images.PointerNewRecord.cur");
				cursor_0 = new Cursor(manifestResourceStream);
			}
			return cursor_0;
		}

		public static Cursor smethod_1()
		{
			int num = 3;
			if (cursor_1 == null)
			{
				Stream manifestResourceStream = typeof(Class157).Assembly.GetManifestResourceStream("DCSoft.TemperatureChart.Images.PointerDragRecord.cur");
				cursor_1 = new Cursor(manifestResourceStream);
			}
			return cursor_1;
		}

		public static Cursor smethod_2()
		{
			int num = 13;
			if (cursor_2 == null)
			{
				Stream manifestResourceStream = typeof(Class157).Assembly.GetManifestResourceStream("DCSoft.TemperatureChart.Images.PointerDeleteRecord.cur");
				cursor_2 = new Cursor(manifestResourceStream);
			}
			return cursor_2;
		}

		internal Enum17 method_18()
		{
			return enum17_0;
		}

		public bool method_19()
		{
			return enum17_0 == Enum17.const_2;
		}
	}
}
