using DCSoft.Common;
using DCSoft.WinForms;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       窗体环境的编辑器宿主对象
	///       </summary>
	[DCInternal]
	[ComVisible(false)]
	public class TextWindowsFormsEditorHost : IDisposable, ITypeDescriptorContext, IWindowsFormsEditorService
	{
		private WriterControl writerControl_0 = null;

		private XTextDocument xtextDocument_0 = null;

		private bool bool_0 = false;

		private GForm0 gform0_0 = null;

		private ElementValueEditContext elementValueEditContext_0 = null;

		private bool bool_1 = false;

		private bool bool_2 = false;

		private static bool bool_3 = false;

		private bool bool_4 = false;

		private static Size size_0 = new Size(0, 0);

		private object object_0 = null;

		/// <summary>
		///       编辑器对象
		///       </summary>
		public WriterControl EditControl
		{
			get
			{
				return writerControl_0;
			}
			set
			{
				writerControl_0 = value;
				if (writerControl_0 != null)
				{
					GEnum65 applicationStyle = WinFormUtils.GetApplicationStyle(writerControl_0);
					ForceFousePopupControl = (applicationStyle == GEnum65.const_0);
				}
			}
		}

		/// <summary>
		///       文档对象
		///       </summary>
		public XTextDocument Document
		{
			get
			{
				return xtextDocument_0;
			}
			set
			{
				xtextDocument_0 = value;
			}
		}

		/// <summary>
		///       弹出用户界面时仍然保持编辑器控件获得输入焦点
		///       </summary>
		public bool KeepWriterControlFocused
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
		///       当前正在执行的文档元素值编辑操作上下文对象
		///       </summary>
		public ElementValueEditContext CurrentEditContext => elementValueEditContext_0;

		/// <summary>
		///       正在编辑数值
		///       </summary>
		public bool EditingValue => bool_1;

		/// <summary>
		///       在编辑数值后触发一次DocumentContentChanged事件
		///       </summary>
		public bool RaiseDocumentContentChangedOnceAfterEditValue
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
		///       判断应用程序是不是WPF应用程序
		///       </summary>
		public static bool ForceFousePopupControl
		{
			get
			{
				return bool_3;
			}
			set
			{
				bool_3 = value;
			}
		}

		/// <summary>
		///       用户是否确认操作
		///       </summary>
		public bool UserAccept
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
		///       弹出式的窗体大小修正量
		///       </summary>
		/// <remarks>
		///       一些应用程序使用了皮肤的功能，此时弹出式的窗体可能强加上皮肤的功能，导致客户区大小设置不正确。
		///       此时可以使用该属性来对冲掉皮肤对客户区大小的影响。
		///       </remarks>
		public static Size PopupFormSizeFix
		{
			get
			{
				return size_0;
			}
			set
			{
				size_0 = value;
			}
		}

		/// <summary>
		///       正在显示下拉列表
		///       </summary>
		public bool ShowingDropDown => gform0_0 != null && gform0_0.Visible;

		IContainer ITypeDescriptorContext.Container => null;

		/// <summary>
		///       当前编辑的对象实例
		///       </summary>
		public object ElementInstance
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

		object ITypeDescriptorContext.Instance => object_0;

		PropertyDescriptor ITypeDescriptorContext.PropertyDescriptor => null;

		public void method_0()
		{
			elementValueEditContext_0 = null;
			object_0 = null;
		}

		/// <summary>
		///       编辑文档元素数值
		///       </summary>
		/// <param name="element">文档元素对象</param>
		/// <param name="editor">编辑器对象</param>
		/// <returns>操作是否成功</returns>
		public ElementValueEditResult EditValue(XTextElement element, ElementValueEditor editor)
		{
			int num = 15;
			if (editor == null)
			{
				throw new ArgumentNullException("editor");
			}
			if (bool_1)
			{
				return ElementValueEditResult.None;
			}
			bool_1 = true;
			try
			{
				GClass293.ReleaseCapture();
				EditControl.Focus();
				WriterEditElementValueEventArgs writerEditElementValueEventArgs = new WriterEditElementValueEventArgs(EditControl, Document, element, editor);
				EditControl.vmethod_22(writerEditElementValueEventArgs);
				if (writerEditElementValueEventArgs.Handled)
				{
					return writerEditElementValueEventArgs.Result;
				}
				object_0 = element;
				ElementValueEditContext elementValueEditContext = new ElementValueEditContext();
				elementValueEditContext.Document = Document;
				elementValueEditContext.Element = element;
				elementValueEditContext.PropertyName = null;
				elementValueEditContext.Editor = editor;
				elementValueEditContext_0 = elementValueEditContext;
				elementValueEditContext_0.EditStyle = editor.GetEditStyle(this, elementValueEditContext);
				RaiseDocumentContentChangedOnceAfterEditValue = false;
				ElementValueEditResult result = editor.EditValue(this, elementValueEditContext);
				elementValueEditContext_0 = null;
				bool_1 = false;
				if (RaiseDocumentContentChangedOnceAfterEditValue)
				{
					RaiseDocumentContentChangedOnceAfterEditValue = false;
					Document.OnDocumentContentChanged();
				}
				return result;
			}
			finally
			{
				elementValueEditContext_0 = null;
				bool_1 = false;
			}
		}

		/// <summary>
		///       取消当前编辑操作
		///       </summary>
		public void CancelEditValue()
		{
			if (CurrentEditContext != null && gform0_0 != null)
			{
				gform0_0.method_22(bool_4: true);
			}
		}

		/// <summary>
		///       关闭弹出式窗体
		///       </summary>
		public void CloseDropDown()
		{
			if (gform0_0 != null)
			{
				gform0_0.method_22(bool_4: true);
			}
			EditControl.ShowingUI = false;
		}

		public void method_1(Form form_0, Size size_1)
		{
			form_0.ClientSize = new Size(size_1.Width + 5 + PopupFormSizeFix.Width, size_1.Height + 5 + PopupFormSizeFix.Height);
		}

		public void method_2()
		{
			if (gform0_0 == null || gform0_0.Controls.Count <= 0)
			{
				return;
			}
			Control control = gform0_0.Controls[0];
			Size preferredSize = control.GetPreferredSize(new Size(0, 300));
			method_1(gform0_0, preferredSize);
			if (object_0 is XTextElement)
			{
				XTextElement xTextElement = (XTextElement)object_0;
				if (!(xTextElement is XTextParagraphFlagElement))
				{
					xTextElement = xTextElement.FirstContentElement;
				}
				if (xTextElement != null)
				{
					Rectangle rectangle_ = writerControl_0.method_9(xTextElement.AbsLeft, xTextElement.AbsTop, xTextElement.Height);
					gform0_0.method_17(rectangle_);
					gform0_0.method_18();
					control.Dock = DockStyle.Fill;
					control.Refresh();
				}
			}
		}

		public void method_3(GForm0 gform0_1, object object_1)
		{
			if (gform0_1 == null || gform0_1.Controls.Count <= 0)
			{
				return;
			}
			Control control = gform0_1.Controls[0];
			Size preferredSize = control.GetPreferredSize(new Size(0, 300));
			gform0_1.ClientSize = new Size(preferredSize.Width + 5 + PopupFormSizeFix.Width, preferredSize.Height + 5 + PopupFormSizeFix.Height);
			if (object_1 is XTextElement)
			{
				XTextElement xTextElement = (XTextElement)object_1;
				if (!(xTextElement is XTextParagraphFlagElement))
				{
					xTextElement = xTextElement.FirstContentElement;
				}
				if (xTextElement != null)
				{
					Rectangle rectangle_ = writerControl_0.method_9(xTextElement.AbsLeft, xTextElement.AbsTop, xTextElement.Height);
					gform0_1.method_17(rectangle_);
					gform0_1.method_18();
					control.Dock = DockStyle.Fill;
					control.Refresh();
				}
			}
		}

		public void method_4(GForm0 gform0_1, object object_1)
		{
			int num = 16;
			if (gform0_1 == null)
			{
				throw new ArgumentNullException("frm");
			}
			if (GClass354.smethod_3())
			{
				return;
			}
			if (EditControl == null)
			{
				throw new ArgumentNullException("EditControl");
			}
			if (EditControl.IsDisposed)
			{
				throw new Exception(WriterStringsCore.WriterControlDisposed);
			}
			gform0_1.method_15(EditControl.InnerViewControl);
			if (!gform0_1.IsHandleCreated)
			{
				gform0_1.CreateControl();
			}
			gform0_1.RightToLeft = EditControl.RightToLeft;
			gform0_1.Owner = EditControl.FindForm();
			gform0_1.TopMost = (gform0_1.Owner == null || writerControl_0.DocumentOptions.BehaviorOptions.ForcePopupFormTopMost);
			if (object_1 is XTextElement)
			{
				XTextElement xTextElement = (XTextElement)object_1;
				if (!(xTextElement is XTextParagraphFlagElement))
				{
					ContentLayoutDirectionStyle contentLayoutDirectionStyle = ContentLayoutDirectionStyle.LeftToRight;
					contentLayoutDirectionStyle = ((xTextElement.OwnerLine != null) ? xTextElement.OwnerLine.RuntimeLayoutDirection : xTextElement.FirstContentElement.OwnerLine.RuntimeLayoutDirection);
					xTextElement = ((contentLayoutDirectionStyle != ContentLayoutDirectionStyle.RightToLeft) ? xTextElement.FirstContentElement : xTextElement.LastContentElement);
				}
				if (xTextElement != null)
				{
					Rectangle rectangle_ = EditControl.method_9(xTextElement.AbsLeft, xTextElement.AbsTop, xTextElement.Height);
					gform0_1.method_17(rectangle_);
					gform0_1.method_18();
					EditControl.ShowingUI = true;
					EditControl.method_1();
					gform0_1.method_1(Environment.TickCount);
					gform0_1.method_3(500L);
					gform0_1.Show();
					EditControl.method_6();
				}
			}
		}

		public void method_5(GForm0 gform0_1, object object_1)
		{
			if (object_1 is XTextElement)
			{
				XTextElement xTextElement = (XTextElement)object_1;
				Rectangle rectangle_ = EditControl.method_9(xTextElement.AbsLeft, xTextElement.AbsTop, xTextElement.Height);
				gform0_1.method_17(rectangle_);
				gform0_1.method_18();
			}
		}

		/// <summary>
		///       弹出下拉列表
		///       </summary>
		/// <param name="control">要显示的数据内容控件</param>
		/// <returns>用户是否确认数据编辑操作</returns>
		public void DropDownControl(Control control)
		{
			int num = 11;
			if (GClass354.smethod_3())
			{
				return;
			}
			bool_4 = false;
			if (control == null)
			{
				throw new ArgumentNullException("control");
			}
			if (EditControl == null)
			{
				throw new ArgumentNullException("EditControl");
			}
			if (EditControl.IsDisposed)
			{
				throw new Exception(WriterStringsCore.WriterControlDisposed);
			}
			IImmProvider immProvider = EditControl.AppHost.Tools.CreateImmProvider(EditControl);
			immProvider?.BackConversionStatus();
			if (gform0_0 == null)
			{
				gform0_0 = new GForm0();
				gform0_0.method_15(writerControl_0.InnerViewControl);
				gform0_0.method_8(bool_4: true);
			}
			gform0_0.RightToLeft = EditControl.RightToLeft;
			Size preferredSize = control.GetPreferredSize(new Size(0, 300));
			gform0_0.ClientSize = new Size(preferredSize.Width + 5 + PopupFormSizeFix.Width, preferredSize.Height + 5 + PopupFormSizeFix.Height);
			GClass244 gClass = new GClass244(gform0_0.Handle);
			gClass.method_8();
			gClass.method_5();
			gform0_0.Controls.Clear();
			if (!control.IsHandleCreated)
			{
				control.CreateControl();
			}
			gform0_0.Controls.Add(control);
			control.RightToLeft = EditControl.RightToLeft;
			control.Dock = DockStyle.Fill;
			if (gform0_0.ClientSize.Width >= control.Width)
			{
			}
			gform0_0.method_6(bool_4: true);
			if (writerControl_0 != null && writerControl_0.IsHandleCreated && !writerControl_0.IsDisposed && object_0 != null)
			{
				gform0_0.Owner = writerControl_0.FindForm();
				gform0_0.TopMost = (gform0_0.Owner == null || writerControl_0.DocumentOptions.BehaviorOptions.ForcePopupFormTopMost);
				if (object_0 is XTextElement)
				{
					XTextElement xTextElement = (XTextElement)object_0;
					if (!(xTextElement is XTextParagraphFlagElement))
					{
						ContentLayoutDirectionStyle contentLayoutDirectionStyle = ContentLayoutDirectionStyle.LeftToRight;
						contentLayoutDirectionStyle = ((xTextElement.OwnerLine != null) ? xTextElement.OwnerLine.RuntimeLayoutDirection : xTextElement.FirstContentElement.OwnerLine.RuntimeLayoutDirection);
						xTextElement = ((contentLayoutDirectionStyle != ContentLayoutDirectionStyle.RightToLeft) ? xTextElement.FirstContentElement : xTextElement.LastContentElement);
					}
					if (xTextElement == null)
					{
						goto IL_04b4;
					}
					Rectangle rectangle_ = writerControl_0.method_9(xTextElement.AbsLeft, xTextElement.AbsTop, xTextElement.Height);
					gform0_0.method_17(rectangle_);
					gform0_0.method_18();
				}
				EditControl.ShowingUI = true;
				EditControl.method_1();
				gform0_0.method_1(Environment.TickCount);
				gform0_0.method_3(500L);
				gform0_0.Show();
				gform0_0.method_8(bool_4: true);
				EditControl.method_6();
				if (control is MonthCalendar)
				{
					MonthCalendar monthCalendar = (MonthCalendar)control;
					preferredSize = monthCalendar.Size;
					gform0_0.ClientSize = new Size(preferredSize.Width + PopupFormSizeFix.Width, preferredSize.Height + PopupFormSizeFix.Height);
				}
				else if (control.GetType().Name == "DateTimeSelectControl")
				{
					preferredSize = control.GetPreferredSize(Size.Empty);
					gform0_0.ClientSize = new Size(preferredSize.Width + PopupFormSizeFix.Width, preferredSize.Height + PopupFormSizeFix.Height);
				}
				else if (control.GetType().Name == "DateSelectControl")
				{
					preferredSize = control.GetPreferredSize(Size.Empty);
					gform0_0.ClientSize = new Size(preferredSize.Width + PopupFormSizeFix.Width, preferredSize.Height + PopupFormSizeFix.Height);
				}
				if (!gform0_0.method_7())
				{
					if (ForceFousePopupControl)
					{
						writerControl_0.Focus();
					}
				}
				else
				{
					control.Focus();
				}
			}
			gform0_0.vmethod_0();
			goto IL_04b4;
			IL_04b4:
			immProvider?.RestoreConversionStatus();
			EditControl.Document.MouseCapture = null;
			if (gform0_0 != null)
			{
				gform0_0.method_22(bool_4: true);
				EditControl.ShowingUI = false;
				if (gform0_0 != null)
				{
					gform0_0.Controls.Clear();
				}
				if (gform0_0 != null)
				{
					gform0_0.Dispose();
					gform0_0 = null;
				}
			}
			if (writerControl_0 != null)
			{
				Form form = writerControl_0.FindForm();
				if (form != null)
				{
					form.Activate();
					form.BringToFront();
				}
				new GClass244(writerControl_0);
				if (!writerControl_0.Focused)
				{
				}
			}
		}

		public void method_6(Size size_1)
		{
			if (gform0_0 != null)
			{
				gform0_0.ClientSize = new Size(size_1.Width + PopupFormSizeFix.Width, size_1.Height + PopupFormSizeFix.Height);
				gform0_0.method_18();
			}
		}

		public void method_7(Form form_0, Size size_1)
		{
			form_0.ClientSize = new Size(size_1.Width + PopupFormSizeFix.Width, size_1.Height + PopupFormSizeFix.Height);
		}

		/// <summary>
		///       显示对话框
		///       </summary>
		/// <param name="dialog">对话框</param>
		/// <returns>显示结果</returns>
		public DialogResult ShowDialog(Form dialog)
		{
			return dialog.ShowDialog(EditControl);
		}

		/// <summary>
		///       销毁对象
		///       </summary>
		public void Dispose()
		{
			elementValueEditContext_0 = null;
			xtextDocument_0 = null;
			writerControl_0 = null;
			object_0 = null;
			if (gform0_0 != null)
			{
				gform0_0.Dispose();
				gform0_0 = null;
			}
		}

		void ITypeDescriptorContext.OnComponentChanged()
		{
		}

		bool ITypeDescriptorContext.OnComponentChanging()
		{
			return true;
		}

		/// <summary>
		///       获得指定类型的服务对象
		///       </summary>
		/// <param name="serviceType">
		/// </param>
		/// <returns>
		/// </returns>
		public object GetService(Type serviceType)
		{
			if (serviceType.IsInstanceOfType(this))
			{
				return this;
			}
			Type type = GetType();
			Type[] interfaces = type.GetInterfaces();
			int num = 0;
			while (true)
			{
				if (num < interfaces.Length)
				{
					Type type2 = interfaces[num];
					if (type2.Equals(serviceType))
					{
						break;
					}
					num++;
					continue;
				}
				if (EditControl != null)
				{
					return EditControl.AppHost.Services.GetService(serviceType);
				}
				return null;
			}
			return this;
		}
	}
}
