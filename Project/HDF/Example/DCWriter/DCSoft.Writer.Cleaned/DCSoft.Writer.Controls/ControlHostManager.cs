#define DEBUG
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       编辑器承载的控件的管理器
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	internal class ControlHostManager : GInterface20
	{
		private class Class283
		{
			private XTextControlHostElement xtextControlHostElement_0 = null;

			[NonSerialized]
			private int int_0 = 0;

			private Control control_0 = null;

			private object object_0 = null;

			private bool bool_0 = false;

			private int int_1 = 0;

			public XTextControlHostElement method_0()
			{
				return xtextControlHostElement_0;
			}

			public void method_1(XTextControlHostElement xtextControlHostElement_1)
			{
				xtextControlHostElement_0 = xtextControlHostElement_1;
				if (xtextControlHostElement_0 != null)
				{
					int_0 = xtextControlHostElement_0.ManageID;
				}
			}

			internal int method_2()
			{
				return int_0;
			}

			internal void method_3(int int_2)
			{
				int_0 = int_2;
			}

			public Control method_4()
			{
				return control_0;
			}

			public void method_5(Control control_1)
			{
				control_0 = control_1;
			}

			public object method_6()
			{
				return object_0;
			}

			public void method_7(object object_1)
			{
				object_0 = object_1;
			}

			public bool method_8()
			{
				return bool_0;
			}

			public void method_9(bool bool_1)
			{
				bool_0 = bool_1;
			}

			public int method_10()
			{
				return int_1;
			}

			public void method_11(int int_2)
			{
				int_1 = int_2;
			}
		}

		private delegate void Delegate8(XTextControlHostElement xtextControlHostElement_0);

		private WriterViewControl writerViewControl_0 = null;

		private List<XTextControlHostElement> list_0 = new List<XTextControlHostElement>();

		private List<Class283> list_1 = new List<Class283>();

		private List<XTextControlHostElement> list_2 = null;

		/// <summary>
		///       编辑器控件
		///       </summary>
		public WriterViewControl ViewControl
		{
			get
			{
				return writerViewControl_0;
			}
			set
			{
				writerViewControl_0 = value;
			}
		}

		/// <summary>
		///       是否允许承载控件
		///       </summary>
		public bool Enable
		{
			get
			{
				if (ViewControl == null)
				{
					return false;
				}
				return ViewControl.DocumentOptions.BehaviorOptions.EnableControlHostAtDesignTime || !ViewControl.DocumentOptions.BehaviorOptions.DesignMode;
			}
		}

		public void imethod_0()
		{
			list_2 = null;
			list_0.Clear();
		}

		/// <summary>
		///       声明控件的布局状态发生改变，需要更新对应的控件的位置
		///       </summary>
		/// <param name="element">
		/// </param>
		public void InvalidateLayout(XTextControlHostElement element)
		{
			if (!list_0.Contains(element))
			{
				list_0.Add(element);
			}
		}

		/// <summary>
		///       更新所有布局状态发生改变的元素对应的控件的位置
		///       </summary>
		public void UpdateInvalidateLayout()
		{
			if (!Enable || list_0.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < list_0.Count; i++)
			{
				XTextControlHostElement xTextControlHostElement = list_0[i];
				Control control = GetControl(xTextControlHostElement);
				if (control != null)
				{
					method_2(control, xTextControlHostElement);
				}
			}
			list_0.Clear();
		}

		private Class283 method_0(Control control_0)
		{
			foreach (Class283 item in list_1)
			{
				if (item.method_4() == control_0)
				{
					return item;
				}
			}
			return null;
		}

		private Class283 method_1(XTextControlHostElement xtextControlHostElement_0)
		{
			foreach (Class283 item in list_1)
			{
				if (item.method_0() == xtextControlHostElement_0)
				{
					return item;
				}
			}
			return null;
		}

		/// <summary>
		///       更新文档中承载的控件的位置
		///       </summary>
		public void UpdateHostWindowsControlPosition()
		{
			foreach (Class283 item in list_1)
			{
				method_2(item.method_4(), item.method_0());
				item.method_11(item.method_0().ContentVersion);
			}
		}

		/// <summary>
		///       更新文档中承载的控件的位置
		///       </summary>
		public void UpdateHostWindowsControlPositionAsynic()
		{
			writerViewControl_0.BeginInvoke(new ComVoidHandler(UpdateHostWindowsControlPosition), null);
		}

		/// <summary>
		///       异步的更新文档中承载的控件的位置
		///       </summary>
		public void UpdateHostWindowsControlPositionAsynic(XTextControlHostElement element)
		{
			writerViewControl_0.BeginInvoke(new Delegate8(UpdateHostWindowsControlPosition), element);
		}

		/// <summary>
		///       更新文档中承载的控件的位置
		///       </summary>
		public void UpdateHostWindowsControlPosition(XTextControlHostElement element)
		{
			Class283 @class = method_1(element);
			if (@class != null)
			{
				method_2(@class.method_4(), @class.method_0());
				@class.method_11(element.ContentVersion);
			}
		}

		/// <summary>
		///       重置承载的控件
		///       </summary>
		/// <param name="element">元素对象</param>
		public void ResetHostControl(XTextControlHostElement element)
		{
			if (Enable)
			{
				Class283 @class = method_1(element);
				if (@class != null)
				{
					method_7(@class);
					list_1.Remove(@class);
				}
				ReloadControl(element, checkDelayLoad: true, addAfterHostedControlLoaded: true);
				imethod_1();
			}
		}

		/// <summary>
		///       为指定的文档元素加载控件
		///       </summary>
		/// <param name="element">文档元素对象</param>
		/// <param name="checkDelayLoad">检查延迟加载标记</param>
		/// <returns>控件对象</returns>
		public Control ReloadControl(XTextControlHostElement element, bool checkDelayLoad, bool addAfterHostedControlLoaded)
		{
			int num = 5;
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			if (!Enable)
			{
				return null;
			}
			if (element.RuntimeControlType == HostedControlType.DocumentImage)
			{
				return null;
			}
			if (ViewControl == null || ViewControl.IsUpdating)
			{
				return null;
			}
			element.ErrorMessage = null;
			bool flag = element.BelongToDocumentDom(ViewControl.Document, checkLogicDelete: true);
			Class283 @class = method_1(element);
			if (element.HostMode != ObjectHostMode.Dynamic || !flag)
			{
				if (@class != null)
				{
					method_7(@class);
					list_1.Remove(@class);
				}
				if (flag && element.HostMode == ObjectHostMode.Static)
				{
					element.method_22();
				}
				return null;
			}
			Control control = null;
			try
			{
				if (element.RuntimeControlType != HostedControlType.OCX && element.RuntimeControlType != HostedControlType.NativeWinControl)
				{
					Type controlType = ControlHelper.GetControlType(element.TypeFullName, typeof(Control));
					if (@class != null && !controlType.IsAssignableFrom(@class.method_6().GetType()))
					{
						list_1.Remove(@class);
						method_8(@class.method_4());
						@class = null;
					}
				}
				if (@class == null)
				{
					if (!checkDelayLoad || !element.DelayLoadControl)
					{
						@class = method_3(element);
						control = @class.method_4();
						if (@class.method_4() != null)
						{
							try
							{
								if (!@class.method_8())
								{
									element.vmethod_30(@class.method_4());
								}
							}
							catch (Exception ex)
							{
								element.method_16(ex.Message, ex);
							}
							list_1.Add(@class);
							if (@class.method_4() is XTextControlHostElement.GClass1)
							{
								Font font = ViewControl.Font;
								if (font.Unit != GraphicsUnit.Point)
								{
									font = new Font(font.Name, font.Size, font.Style, GraphicsUnit.Point, font.GdiCharSet);
									ViewControl.Font = font;
								}
							}
							ViewControl.Controls.Add(@class.method_4());
							Debug.WriteLine("已经添加了承载的控件 " + @class.method_4().GetType().FullName);
							if (!@class.method_4().IsHandleCreated && !@class.method_4().IsDisposed)
							{
								Debug.WriteLine("延迟创建控件句柄 " + @class.method_4().GetType().FullName);
								@class.method_4().CreateControl();
							}
						}
					}
				}
				else
				{
					control = @class.method_4();
					if (@class.method_10() != element.ContentVersion)
					{
						try
						{
							if (!@class.method_8())
							{
								element.vmethod_30(@class.method_4());
							}
						}
						catch (Exception ex)
						{
							element.method_16(ex.Message, ex);
						}
					}
				}
				if (@class != null)
				{
					method_2(@class.method_4(), element);
				}
			}
			catch (Exception ex)
			{
				element.method_16(ex.Message, ex);
			}
			if (addAfterHostedControlLoaded && control != null)
			{
				method_5(element);
			}
			return control;
		}

		/// <summary>
		///       删除指定元素对应的控件
		///       </summary>
		/// <param name="element">文档元素对象</param>
		public void RemoveControl(XTextControlHostElement element)
		{
			if (Enable)
			{
				Class283 @class = method_1(element);
				if (@class != null)
				{
					method_7(@class);
					list_1.Remove(@class);
				}
			}
		}

		/// <summary>
		///       获得指定文档元素对应的控件
		///       </summary>
		/// <param name="element">文档元素对象</param>
		/// <returns>控件对象</returns>
		public Control GetControl(XTextControlHostElement element)
		{
			foreach (Class283 item in list_1)
			{
				if (item.method_0() == element || item.method_2() == element.ManageID)
				{
					return item.method_4();
				}
			}
			return null;
		}

		/// <summary>
		///       更新控件内容版本号
		///       </summary>
		/// <param name="element">文档元素对象</param>
		public void UpdateControlContentVersion(XTextControlHostElement element)
		{
			method_1(element)?.method_11(element.ContentVersion);
		}

		/// <summary>
		///       试图设置控件大小
		///       </summary>
		/// <param name="element">文档元素对象</param>
		/// <param name="viewWidth">视图宽度</param>
		/// <param name="viewHeight">视图高度</param>
		/// <returns>操作后的大小</returns>
		public SizeF TrySetControlSize(XTextControlHostElement element, float viewWidth, float viewHeight)
		{
			Control control = GetControl(element);
			if (control != null)
			{
				return ControlHelper.TrySetControlSize(element, control, viewWidth, viewHeight);
			}
			return SizeF.Empty;
		}

		private void method_2(Control control_0, XTextControlHostElement xtextControlHostElement_0)
		{
			if (control_0 != null && !((control_0.Parent as WriterViewControl)?.IsUpdating ?? true))
			{
				try
				{
					_ = xtextControlHostElement_0.AbsBounds;
					Rectangle rectangle = ViewControl.method_254(xtextControlHostElement_0);
					float rateOfDocumentUnitToPixel = ViewControl.RateOfDocumentUnitToPixel;
					RuntimeDocumentContentStyle runtimeStyle = xtextControlHostElement_0.RuntimeStyle;
					rectangle.X = (int)((float)rectangle.X + runtimeStyle.PaddingLeft * rateOfDocumentUnitToPixel);
					rectangle.Y = (int)((float)rectangle.Y + runtimeStyle.PaddingTop * rateOfDocumentUnitToPixel);
					rectangle.Width = (int)((float)rectangle.Width - (runtimeStyle.PaddingLeft + runtimeStyle.PaddingRight) * rateOfDocumentUnitToPixel);
					rectangle.Height = (int)((float)rectangle.Height - (runtimeStyle.PaddingTop + runtimeStyle.PaddingBottom) * rateOfDocumentUnitToPixel);
					if (rectangle.Width == 0)
					{
						rectangle.Width = 1;
					}
					if (rectangle.Height == 0)
					{
						rectangle.Height = 1;
					}
					if (!control_0.Bounds.Equals(rectangle))
					{
						control_0.Bounds = rectangle;
					}
				}
				catch (Exception ex)
				{
					xtextControlHostElement_0.method_16(ex.Message, ex);
				}
			}
		}

		private Class283 method_3(XTextControlHostElement xtextControlHostElement_0)
		{
			Class283 @class = new Class283();
			@class.method_1(xtextControlHostElement_0);
			@class.method_7(xtextControlHostElement_0.vmethod_32());
			if (@class.method_6() != null)
			{
				switch (xtextControlHostElement_0.RuntimeControlType)
				{
				case HostedControlType.Control:
				{
					@class.method_5((Control)@class.method_6());
					RuntimeDocumentContentStyle runtimeStyle = xtextControlHostElement_0.RuntimeStyle;
					if (runtimeStyle.BackgroundColor.A != 0)
					{
						@class.method_4().BackColor = Color.FromArgb(255, runtimeStyle.BackgroundColor);
					}
					else if (@class.method_4().BackColor == SystemColors.Control)
					{
						@class.method_4().BackColor = writerViewControl_0.PageBackColor;
					}
					break;
				}
				case HostedControlType.OCX:
					@class.method_5((Control)@class.method_6());
					break;
				case HostedControlType.NativeWinControl:
					@class.method_5((Control)@class.method_6());
					break;
				case HostedControlType.WPF:
				{
					@class.method_5(GClass129.smethod_5(@class.method_6()));
					RuntimeDocumentContentStyle runtimeStyle = xtextControlHostElement_0.RuntimeStyle;
					if (runtimeStyle.BackgroundColor.A != 0)
					{
						@class.method_4().BackColor = Color.FromArgb(255, runtimeStyle.BackgroundColor);
					}
					else if (@class.method_4().BackColor == SystemColors.Control)
					{
						@class.method_4().BackColor = writerViewControl_0.PageBackColor;
					}
					break;
				}
				}
			}
			@class.method_9(xtextControlHostElement_0.SpecifyHostedInstance != null);
			@class.method_11(xtextControlHostElement_0.ContentVersion);
			if (@class.method_4() != null)
			{
				@class.method_4().GotFocus += method_4;
			}
			return @class;
		}

		private void method_4(object sender, EventArgs e)
		{
			Class283 @class = method_0((Control)sender);
			if (@class != null)
			{
				XTextElement xTextElement = @class.method_0();
				XTextDocumentContentElement documentContentElement = xTextElement.DocumentContentElement;
				documentContentElement.SetSelection(xTextElement.ViewIndex, 1);
			}
		}

		/// <summary>
		///       删除被删除的元素对应的控件
		///       </summary>
		public void RemoveDeletedHostControl()
		{
			if (!Enable)
			{
				return;
			}
			for (int num = list_1.Count - 1; num >= 0; num--)
			{
				Class283 @class = list_1[num];
				if (!@class.method_0().BelongToDocumentDom(ViewControl.Document, checkLogicDelete: true))
				{
					method_7(@class);
					if (list_1.Count > num)
					{
						list_1.RemoveAt(num);
					}
				}
			}
		}

		internal void method_5(XTextControlHostElement xtextControlHostElement_0)
		{
			if (list_2 == null)
			{
				list_2 = new List<XTextControlHostElement>();
			}
			if (!list_2.Contains(xtextControlHostElement_0))
			{
				list_2.Add(xtextControlHostElement_0);
			}
		}

		public void imethod_1()
		{
			writerViewControl_0.BeginInvoke(new EventHandler(method_6));
		}

		private void method_6(object sender, EventArgs e)
		{
			if (list_2 != null)
			{
				List<XTextControlHostElement> list = new List<XTextControlHostElement>(list_2);
				list_2 = null;
				foreach (XTextControlHostElement item in list)
				{
					item.AfterHostedControlLoaded();
				}
			}
		}

		/// <summary>
		///       重新加载编辑器承载的控件
		///       </summary>
		public void ReloadControls()
		{
			if (!Enable || ViewControl == null || ViewControl.IsUpdating)
			{
				return;
			}
			List<Control> list = new List<Control>();
			foreach (XTextControlHostElement item in ViewControl.Document.GetElementsByType(typeof(XTextControlHostElement)))
			{
				if (item.RuntimeControlType == HostedControlType.DocumentImage)
				{
					try
					{
						item.vmethod_27();
						object obj = item.vmethod_32();
						if (obj != null && obj != item.SpecifyHostedInstance)
						{
							item.vmethod_30(obj);
							item.HostedInstance = obj;
						}
					}
					catch (Exception ex)
					{
						item.HostedInstance = null;
						item.method_16(ex.Message, ex);
					}
					if (item.HostedInstance != null)
					{
						item.method_22();
					}
				}
				Control control = ReloadControl(item, checkDelayLoad: true, addAfterHostedControlLoaded: true);
				if (control != null)
				{
					list.Add(control);
				}
			}
			for (int num = list_1.Count - 1; num >= 0; num--)
			{
				Class283 @class = list_1[num];
				if (!list.Contains(@class.method_4()))
				{
					method_7(@class);
					if (list_1.Count > num)
					{
						list_1.RemoveAt(num);
					}
				}
			}
			DeleteUnkownControls();
			imethod_1();
		}

		private void method_7(Class283 class283_0)
		{
			if (list_1.Contains(class283_0))
			{
				list_1.Remove(class283_0);
			}
			if (class283_0.method_4() != null && ViewControl.Controls.Contains(class283_0.method_4()))
			{
				bool flag;
				if (flag = (ViewControl.Focused || ViewControl.ContainsFocus))
				{
					ViewControl.Focus();
				}
				ViewControl.Controls.Remove(class283_0.method_4());
				if (GClass129.smethod_4(class283_0.method_6()))
				{
					GClass129.smethod_6(class283_0.method_4());
					class283_0.method_4().Dispose();
				}
				else if (!class283_0.method_8())
				{
					class283_0.method_4().Dispose();
				}
				else
				{
					class283_0.method_4().Dispose();
				}
				if (flag)
				{
					try
					{
						ViewControl.Focus();
					}
					catch (Exception ex)
					{
						Debug.WriteLine(ex.ToString());
					}
				}
			}
		}

		private void method_8(Control control_0)
		{
			if (ViewControl.Controls.Contains(control_0))
			{
				bool flag = ViewControl.Focused || ViewControl.ContainsFocus;
				ViewControl.Controls.Remove(control_0);
				GClass129.smethod_6(control_0);
				control_0.Dispose();
				if (flag)
				{
					ViewControl.Focus();
				}
			}
		}

		/// <summary>
		///       删除未知的无主控件
		///       </summary>
		public void DeleteUnkownControls()
		{
			for (int num = ViewControl.Controls.Count - 1; num >= 0; num--)
			{
				Control control_ = ViewControl.Controls[num];
				Class283 @class = method_0(control_);
				if (@class == null)
				{
					method_8(control_);
				}
			}
		}

		/// <summary>
		///       删除所有的控件
		///       </summary>
		public void ClearControls()
		{
			for (int num = list_1.Count - 1; num >= 0; num--)
			{
				Class283 @class = list_1[num];
				try
				{
					ViewControl.Controls.Remove(@class.method_4());
					list_1.RemoveAt(num);
					@class.method_4().Dispose();
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.Message);
				}
			}
			DeleteUnkownControls();
		}
	}
}
