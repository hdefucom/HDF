using DCSoft.FriedmanCurveChart;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal class Class166
	{
		private FriedmanCurveControl friedmanCurveControl_0 = null;

		private GControl2 gcontrol2_0 = null;

		private FCYAxisInfo fcyaxisInfo_0 = null;

		private FCValuePoint fcvaluePoint_0 = null;

		private Point point_0 = Point.Empty;

		private static Cursor cursor_0 = null;

		private static Cursor cursor_1 = null;

		private static Cursor cursor_2 = null;

		private Enum18 enum18_0 = Enum18.const_0;

		public FriedmanCurveControl method_0()
		{
			return friedmanCurveControl_0;
		}

		public void method_1(FriedmanCurveControl friedmanCurveControl_1)
		{
			friedmanCurveControl_0 = friedmanCurveControl_1;
			if (friedmanCurveControl_0 != null)
			{
				gcontrol2_0 = friedmanCurveControl_0.InnerViewControl;
			}
		}

		public GControl2 method_2()
		{
			return gcontrol2_0;
		}

		public void method_3(GControl2 gcontrol2_1)
		{
			gcontrol2_0 = gcontrol2_1;
		}

		public bool method_4()
		{
			return !method_2().method_14().Config.Readonly || method_2().method_14().Config.EditValuePointMode != FCEditValuePointEventHandleMode.None;
		}

		public bool method_5()
		{
			if (method_18() != 0)
			{
				enum18_0 = Enum18.const_0;
				method_2().Cursor = Cursors.Arrow;
				if (fcyaxisInfo_0 != null)
				{
					fcyaxisInfo_0.Selected = false;
					fcyaxisInfo_0 = null;
					friedmanCurveControl_0.Invalidate(invalidateChildren: true);
					gcontrol2_0.method_59(null, bool_4: false);
				}
				return true;
			}
			return false;
		}

		public void method_6()
		{
			if (method_4())
			{
				enum18_0 = Enum18.const_2;
				if (fcyaxisInfo_0 != null)
				{
					fcyaxisInfo_0.Selected = false;
					fcyaxisInfo_0 = null;
					friedmanCurveControl_0.Invalidate(invalidateChildren: true);
				}
			}
		}

		public void method_7()
		{
			if (method_4())
			{
				enum18_0 = Enum18.const_4;
				if (fcyaxisInfo_0 != null)
				{
					fcyaxisInfo_0.Selected = false;
				}
				fcyaxisInfo_0 = null;
				friedmanCurveControl_0.Invalidate(invalidateChildren: true);
			}
		}

		public void method_8()
		{
			if (method_4())
			{
				enum18_0 = Enum18.const_5;
				if (fcyaxisInfo_0 != null)
				{
					fcyaxisInfo_0.Selected = false;
				}
				fcyaxisInfo_0 = null;
				friedmanCurveControl_0.Invalidate(invalidateChildren: true);
			}
		}

		public void method_9(FCYAxisInfo fcyaxisInfo_1)
		{
			int num = 12;
			if (fcyaxisInfo_1 == null)
			{
				throw new ArgumentNullException("info");
			}
			if (method_4())
			{
				FriedmanCurveDocument friedmanCurveDocument = gcontrol2_0.method_14();
				if (!friedmanCurveDocument.Config.YAxisInfos.Contains(fcyaxisInfo_1))
				{
					throw new ArgumentOutOfRangeException("Info:" + fcyaxisInfo_1.Name);
				}
				foreach (FCYAxisInfo yAxisInfo in friedmanCurveDocument.Config.YAxisInfos)
				{
					yAxisInfo.Selected = false;
				}
				fcyaxisInfo_1.ValueVisible = true;
				fcyaxisInfo_1.Selected = true;
				enum18_0 = Enum18.const_1;
				friedmanCurveControl_0.Invalidate(invalidateChildren: true);
				fcyaxisInfo_0 = fcyaxisInfo_1;
			}
		}

		private bool method_10()
		{
			return enum18_0 == Enum18.const_1 && fcyaxisInfo_0 != null;
		}

		public bool method_11(FCYAxisInfo fcyaxisInfo_1)
		{
			return enum18_0 == Enum18.const_1 && fcyaxisInfo_0 == fcyaxisInfo_1;
		}

		public bool method_12(object object_0, MouseEventArgs mouseEventArgs_0)
		{
			int num = 4;
			if (!method_4())
			{
				return false;
			}
			Control control = object_0 as Control;
			switch (enum18_0)
			{
			default:
				return false;
			case Enum18.const_1:
			{
				if (control != null)
				{
					control.Cursor = smethod_0();
				}
				FCValuePoint fCValuePoint = method_16(fcyaxisInfo_0, mouseEventArgs_0.X, mouseEventArgs_0.Y);
				string string_ = null;
				if (fCValuePoint != null)
				{
					string_ = string.Format(DCFriedmanCurveStrings.NewValuePoint_Name, fcyaxisInfo_0.Title) + Environment.NewLine + DCFriedmanCurveStrings.Time + ":" + fCValuePoint.Time.ToString(Class163.smethod_0(fcyaxisInfo_0.InputTimePrecision)) + Environment.NewLine + DCFriedmanCurveStrings.Value + ":" + fCValuePoint.Value;
				}
				method_2().method_59(string_, bool_4: true);
				return true;
			}
			case Enum18.const_2:
				if (control != null)
				{
					PointF pointF = method_2().method_31(mouseEventArgs_0.X, mouseEventArgs_0.Y);
					FCValuePoint fCValuePoint2 = method_2().method_60(pointF.X, pointF.Y);
					if (fCValuePoint2 == null)
					{
						return false;
					}
					control.Cursor = smethod_2();
					return true;
				}
				return true;
			case Enum18.const_3:
				return true;
			case Enum18.const_4:
			case Enum18.const_5:
				if (fcvaluePoint_0 != null && mouseEventArgs_0.Button == MouseButtons.Left)
				{
					if (control != null)
					{
						control.Cursor = smethod_1();
					}
					FCYAxisInfo fCYAxisInfo = (FCYAxisInfo)fcvaluePoint_0.Parent;
					if (fCYAxisInfo == null)
					{
						return true;
					}
					FCValuePoint fCValuePoint = method_16(fCYAxisInfo, mouseEventArgs_0.X, mouseEventArgs_0.Y);
					method_2().method_14();
					string string_ = null;
					if (fCValuePoint != null)
					{
						DateTime time = fcvaluePoint_0.Time;
						if (method_18() == Enum18.const_4)
						{
							time = fCValuePoint.Time;
						}
						string_ = string.Format(DCFriedmanCurveStrings.DragValuePoint_Name, fCYAxisInfo.Title) + Environment.NewLine + DCFriedmanCurveStrings.Time + ":" + time.ToString(Class163.smethod_0(fCYAxisInfo.InputTimePrecision)) + Environment.NewLine + DCFriedmanCurveStrings.Value + ":" + fCValuePoint.Value;
					}
					method_2().method_59(string_, bool_4: true);
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
			int num = 5;
			if (!method_4())
			{
				return false;
			}
			if (method_18() == Enum18.const_2)
			{
				FriedmanCurveDocument friedmanCurveDocument = method_2().method_14();
				PointF pointF = method_2().method_31(mouseEventArgs_0.X, mouseEventArgs_0.Y);
				FCValuePoint fCValuePoint = method_2().method_60(pointF.X, pointF.Y);
				if (fCValuePoint != null)
				{
					FCEditValuePointEventArgs fCEditValuePointEventArgs = new FCEditValuePointEventArgs(friedmanCurveControl_0, friedmanCurveDocument, fCValuePoint, FCEditValuePointMode.Delete);
					fCEditValuePointEventArgs.Result = true;
					method_2().method_46(fCEditValuePointEventArgs);
					if (fCEditValuePointEventArgs.Result)
					{
						FCValuePointList ownerList = fCValuePoint.OwnerList;
						ownerList.Remove(fCValuePoint);
						friedmanCurveDocument.Modified = true;
						method_2().Invalidate();
					}
					return true;
				}
				return false;
			}
			if (method_18() == Enum18.const_1)
			{
				FriedmanCurveDocument friedmanCurveDocument = method_2().method_14();
				if (fcyaxisInfo_0 != null)
				{
					FCValuePoint fCValuePoint2 = method_16(fcyaxisInfo_0, mouseEventArgs_0.X, mouseEventArgs_0.Y);
					if (fCValuePoint2 != null)
					{
						fCValuePoint2.Time = Class163.smethod_1(fCValuePoint2.Time, fcyaxisInfo_0.InputTimePrecision);
						fCValuePoint2.Parent = fcyaxisInfo_0;
						FCEditValuePointEventArgs fCEditValuePointEventArgs = new FCEditValuePointEventArgs(friedmanCurveControl_0, friedmanCurveDocument, fCValuePoint2, FCEditValuePointMode.Insert);
						fCEditValuePointEventArgs.Result = true;
						if (method_2() != null)
						{
							method_2().method_46(fCEditValuePointEventArgs);
						}
						if (fCEditValuePointEventArgs.Result)
						{
							FCValuePointList ownerList = friedmanCurveDocument.method_40(fcyaxisInfo_0.Name);
							ownerList.Add(fCValuePoint2);
							ownerList.SortByTime();
							friedmanCurveDocument.Modified = true;
							method_2().Invalidate();
							method_2().method_23();
						}
						return true;
					}
				}
				PointF pointF = method_2().method_31(mouseEventArgs_0.X, mouseEventArgs_0.Y);
				foreach (FCTitleLineInfo allTitleLine in friedmanCurveDocument.Config.GetAllTitleLines())
				{
					RectangleF rectangleF = new RectangleF(friedmanCurveDocument.DataGridBounds.Left, allTitleLine.Top, friedmanCurveDocument.DataGridBounds.Width, allTitleLine.Height);
					if (rectangleF.Contains(pointF))
					{
						FCValuePointList ownerList = friedmanCurveDocument.method_40(allTitleLine.Name);
						DateTime dateTime_ = friedmanCurveDocument.RuntimeTicks.method_15(friedmanCurveDocument.DataGridBounds, pointF.X);
						FCValuePoint fCValuePoint3 = new FCValuePoint();
						fCValuePoint3.Time = Class163.smethod_1(dateTime_, allTitleLine.InputTimePrecision);
						if (ownerList.IsTextMode(allTitleLine))
						{
							fCValuePoint3.Text = "-";
						}
						else
						{
							fCValuePoint3.Value = 0f;
						}
						fCValuePoint3.Value = 0f;
						fCValuePoint3.Parent = allTitleLine;
						FCEditValuePointEventArgs fCEditValuePointEventArgs = new FCEditValuePointEventArgs(friedmanCurveControl_0, friedmanCurveDocument, fCValuePoint3, FCEditValuePointMode.Insert);
						fCEditValuePointEventArgs.Result = true;
						if (method_2() != null)
						{
							method_2().method_46(fCEditValuePointEventArgs);
						}
						if (fCEditValuePointEventArgs.Result)
						{
							ownerList.Add(fCValuePoint3);
							ownerList.SortByTime();
							friedmanCurveDocument.Modified = true;
							method_2().Invalidate();
							method_2().method_23();
						}
						break;
					}
				}
				return true;
			}
			if (method_18() == Enum18.const_4 || method_18() == Enum18.const_5)
			{
				if (mouseEventArgs_0.Button == MouseButtons.Left)
				{
					FriedmanCurveDocument friedmanCurveDocument = method_2().method_14();
					PointF pointF = method_2().method_31(mouseEventArgs_0.X, mouseEventArgs_0.Y);
					if (friedmanCurveDocument.DataGridBounds.Contains(pointF.X, pointF.Y))
					{
						FCValuePoint fCValuePoint = method_2().method_60(pointF.X, pointF.Y);
						if (fCValuePoint != null)
						{
							FCYAxisInfo fCYAxisInfo = fCValuePoint.Parent as FCYAxisInfo;
							if (fCYAxisInfo != null && fCYAxisInfo.Style == FCYAxisInfoStyle.Value)
							{
								fcvaluePoint_0 = fCValuePoint;
								if (method_18() == Enum18.const_5)
								{
									Point point = method_2().method_30(0f, friedmanCurveDocument.DataGridBounds.Top + friedmanCurveDocument.DataGridBounds.Height * fCYAxisInfo.RuntimeTopPadding);
									Rectangle clip = new Rectangle(height: method_2().method_30(0f, friedmanCurveDocument.DataGridBounds.Bottom - friedmanCurveDocument.DataGridBounds.Height * fCYAxisInfo.RuntimeBottomPadding).Y - point.Y, x: mouseEventArgs_0.X, y: point.Y, width: 2);
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
			if (method_18() == Enum18.const_5 || method_18() == Enum18.const_4)
			{
				if (fcvaluePoint_0 != null)
				{
					if (Math.Abs(point_0.X - mouseEventArgs_0.X) < SystemInformation.DragSize.Width && Math.Abs(point_0.Y - mouseEventArgs_0.Y) < SystemInformation.DragSize.Height)
					{
						return true;
					}
					FCValuePoint fCValuePoint = method_16((FCYAxisInfo)fcvaluePoint_0.Parent, mouseEventArgs_0.X, mouseEventArgs_0.Y);
					FriedmanCurveDocument friedmanCurveDocument = method_2().method_14();
					if (fCValuePoint != null)
					{
						FCValuePoint fCValuePoint2 = fcvaluePoint_0.Clone();
						if (method_18() == Enum18.const_4)
						{
							fCValuePoint2.Time = fCValuePoint.Time;
						}
						fCValuePoint2.Value = fCValuePoint.Value;
						FCEditValuePointEventArgs fCEditValuePointEventArgs = new FCEditValuePointEventArgs(friedmanCurveControl_0, friedmanCurveDocument, fCValuePoint2, FCEditValuePointMode.Update);
						method_2().method_46(fCEditValuePointEventArgs);
						if (fCEditValuePointEventArgs.Result)
						{
							fcvaluePoint_0.Time = fCValuePoint2.Time;
							fcvaluePoint_0.Value = fCValuePoint2.Value;
							method_2().Invalidate();
							friedmanCurveDocument.Modified = true;
							method_2().Cursor = Cursors.Arrow;
							method_2().method_23();
						}
						method_2().method_59(null, bool_4: false);
						fcvaluePoint_0 = null;
					}
				}
				return true;
			}
			if (method_18() == Enum18.const_0)
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

		private FCValuePoint method_16(FCYAxisInfo fcyaxisInfo_1, int int_0, int int_1)
		{
			int num = 15;
			if (fcyaxisInfo_1 == null)
			{
				throw new ArgumentNullException("info");
			}
			FriedmanCurveDocument friedmanCurveDocument = method_2().method_14();
			PointF pointF = method_2().method_31(int_0, int_1);
			if (friedmanCurveDocument.DataGridBounds.Contains(pointF.X, pointF.Y))
			{
				DateTime dateTime = friedmanCurveDocument.RuntimeTicks.method_15(friedmanCurveDocument.DataGridBounds, pointF.X);
				if (FriedmanCurveDocument.smethod_4(dateTime))
				{
					return null;
				}
				float num2 = fcyaxisInfo_1.method_4(friedmanCurveDocument, friedmanCurveDocument.DataGridBounds, pointF.Y);
				if (FriedmanCurveDocument.smethod_3(num2))
				{
					return null;
				}
				FCValuePoint fCValuePoint = new FCValuePoint();
				fCValuePoint.Time = dateTime;
				fCValuePoint.Value = num2;
				fCValuePoint.Parent = fcyaxisInfo_1;
				return fCValuePoint;
			}
			return null;
		}

		public void method_17()
		{
			enum18_0 = Enum18.const_0;
			fcyaxisInfo_0 = null;
		}

		public static Cursor smethod_0()
		{
			int num = 0;
			if (cursor_0 == null)
			{
				Stream manifestResourceStream = typeof(Class163).Assembly.GetManifestResourceStream("DCSoft.FriedmanCurveChart.Images.PointerNewRecord.cur");
				cursor_0 = new Cursor(manifestResourceStream);
			}
			return cursor_0;
		}

		public static Cursor smethod_1()
		{
			int num = 2;
			if (cursor_1 == null)
			{
				Stream manifestResourceStream = typeof(Class163).Assembly.GetManifestResourceStream("DCSoft.FriedmanCurveChart.Images.PointerDragRecord.cur");
				cursor_1 = new Cursor(manifestResourceStream);
			}
			return cursor_1;
		}

		public static Cursor smethod_2()
		{
			int num = 15;
			if (cursor_2 == null)
			{
				Stream manifestResourceStream = typeof(Class163).Assembly.GetManifestResourceStream("DCSoft.FriedmanCurveChart.Images.PointerDeleteRecord.cur");
				cursor_2 = new Cursor(manifestResourceStream);
			}
			return cursor_2;
		}

		internal Enum18 method_18()
		{
			return enum18_0;
		}

		public bool method_19()
		{
			return enum18_0 == Enum18.const_2;
		}
	}
}
