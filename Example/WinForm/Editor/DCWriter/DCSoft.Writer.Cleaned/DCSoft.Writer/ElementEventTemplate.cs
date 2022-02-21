using DCSoft.Common;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档元素事件模板
	///       </summary>
	/// <remarks>编写 袁永福</remarks>
	[DocumentComment]
	[ComClass("00012345-6789-ABCD-EF01-23456789006C", "A7953E00-41A5-4841-9440-71BC417C914E", "2C834075-AF5D-46C2-9415-83E93EC39519")]
	[ToolboxBitmap(typeof(ElementEventTemplate))]
	[ComSourceInterfaces(typeof(IElementEventTemplateComEvents))]
	
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("00012345-6789-ABCD-EF01-23456789006C")]
	[ToolboxItem(false)]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IElementEventTemplate))]
	public class ElementEventTemplate : Component, IElementEventTemplate
	{
		internal const string CLASSID = "00012345-6789-ABCD-EF01-23456789006C";

		internal const string CLASSID_Interface = "A7953E00-41A5-4841-9440-71BC417C914E";

		internal const string CLASSID_ComEventInterface = "2C834075-AF5D-46C2-9415-83E93EC39519";

		private string _Name = null;

		private bool _Enabled = true;

		/// <summary>
		///       对象名称
		///       </summary>
		[DefaultValue(null)]
		public string Name
		{
			get
			{
				if (string.IsNullOrEmpty(_Name) && Site != null)
				{
					return Site.Name;
				}
				return _Name;
			}
			set
			{
				_Name = value;
			}
		}

		/// <summary>
		///       对象是否可用
		///       </summary>
		[DefaultValue(true)]
		
		public bool Enabled
		{
			get
			{
				return _Enabled;
			}
			set
			{
				_Enabled = value;
			}
		}

		/// <summary>
		///       判断是否是当前类型
		///       </summary>
		private bool IsCurrentType => GetType().Equals(typeof(ElementEventTemplate));

		/// <summary>
		///       判断是否存在Load事件
		///       </summary>
		public virtual bool HasLoad => !IsCurrentType || this.Load != null;

		/// <summary>
		///       是否存在MouseClick事件
		///       </summary>
		
		public virtual bool HasMouseClick => !IsCurrentType || this.MouseClick != null;

		/// <summary>
		///       是否存在MouseDblClick事件
		///       </summary>
		
		public virtual bool HasMouseDblClick => !IsCurrentType || this.MouseDblClick != null;

		/// <summary>
		///       是否需要处理MouseDown事件
		///       </summary>
		
		public virtual bool HasMouseDown => !IsCurrentType || this.MouseDown != null;

		/// <summary>
		///       是否需要处理MouseMove事件
		///       </summary>
		
		public virtual bool HasMouseMove => !IsCurrentType || this.MouseMove != null;

		/// <summary>
		///       是否有MouseUp事件
		///       </summary>
		
		public virtual bool HasMouseUp => !IsCurrentType || this.MouseUp != null;

		/// <summary>
		///       是否有KeyDown事件
		///       </summary>
		
		public virtual bool HasKeyDown => !IsCurrentType || this.KeyDown != null;

		/// <summary>
		///       是否有KeyPress事件
		///       </summary>
		
		public virtual bool HasKeyPress => !IsCurrentType || this.KeyPress != null;

		/// <summary>
		///       是否有KeyUp事件
		///       </summary>
		
		public virtual bool HasKeyUp => !IsCurrentType || this.KeyUp != null;

		/// <summary>
		///       判断是否存在 ContentChanged 事件
		///       </summary>
		
		public virtual bool HasContentChanged => !IsCurrentType || this.ContentChanged != null;

		/// <summary>
		///       判断是否存在 ContentChanging 事件
		///       </summary>
		
		public virtual bool HasContentChanging => !IsCurrentType || this.ContentChanging != null;

		/// <summary>
		///       判断是否存在GetFocus事件
		///       </summary>
		
		public virtual bool HasGotFocus => !IsCurrentType || this.GotFocus != null;

		/// <summary>
		///       判断是否存在失去输入焦点事件
		///       </summary>
		
		public virtual bool HasLostFocus => !IsCurrentType || this.LostFocus != null;

		/// <summary>
		///       是否存在Validating事件
		///       </summary>
		
		public virtual bool HasValidating => !IsCurrentType || this.Validating != null;

		/// <summary>
		///       是否存在数据验证结束事件
		///       </summary>
		
		public virtual bool HasValidated => !IsCurrentType || this.Validated != null;

		/// <summary>
		///       判断是否存在BeforeDropDown事件
		///       </summary>
		
		public virtual bool HasBeforeDropDown => !IsCurrentType || this.BeforeDropDown != null;

		/// <summary>
		///       判断是否存在鼠标进入事件
		///       </summary>
		
		public virtual bool HasMouseEnter => !IsCurrentType || this.MouseEnter != null;

		/// <summary>
		///       判断是否存在鼠标离开事件
		///       </summary>
		
		public virtual bool HasMouseLeave => !IsCurrentType || this.MouseLeave != null;

		/// <summary>
		///       判断是否存在文档元素执行表达式事件
		///       </summary>
		
		public virtual bool HasExpression => !IsCurrentType || this.Expression != null;

		/// <summary>
		///       判断是否存在查询文档元素状态事件
		///       </summary>
		
		public virtual bool HasQueryState => !IsCurrentType || this.QueryState != null;

		/// <summary>
		///       判断是否存在准备绘制文档元素内容前事件
		///       </summary>
		
		public virtual bool HasBeforePaint => !IsCurrentType || this.BeforePaint != null;

		/// <summary>
		///       判断是否存在绘制文档元素内容后触发的事件
		///       </summary>
		
		public virtual bool HasAfterPaint => !IsCurrentType || this.AfterPaint != null;

		/// <summary>
		///       文档元素加载事件
		///       </summary>
		
		public event ElementLoadEventHandler Load = null;

		/// <summary>
		///       文档元素鼠标点击事件
		///       </summary>
		
		public event ElementMouseEventHandler MouseClick = null;

		/// <summary>
		///       文档元素鼠标双击事件
		///       </summary>
		
		public event ElementMouseEventHandler MouseDblClick = null;

		/// <summary>
		///       文档元素鼠标按键按下事件
		///       </summary>
		
		public event ElementMouseEventHandler MouseDown = null;

		/// <summary>
		///       文档元素鼠标移动事件
		///       </summary>
		
		public event ElementMouseEventHandler MouseMove = null;

		/// <summary>
		///       文档元素鼠标按键松开事件
		///       </summary>
		
		public event ElementMouseEventHandler MouseUp = null;

		/// <summary>
		///       文档元素键盘按键按下事件
		///       </summary>
		
		public event ElementKeyEventHandler KeyDown = null;

		/// <summary>
		///       文档元素键盘按键事件
		///       </summary>
		
		public event ElementKeyEventHandler KeyPress = null;

		/// <summary>
		///       文档元素键盘按键松开事件
		///       </summary>
		
		public event ElementKeyEventHandler KeyUp = null;

		/// <summary>
		///       文档内容发生改变后的事件，该事件用于通知情况，不能取消操作
		///       </summary>
		
		public event ContentChangedEventHandler ContentChanged = null;

		/// <summary>
		///       文档内容准备发生改变事件，可以使用该参数来取消操作
		///       </summary>
		
		public event ContentChangingEventHandler ContentChanging = null;

		/// <summary>
		///       文本域获得输入焦点事件
		///       </summary>
		
		public event ElementEventHandler GotFocus = null;

		/// <summary>
		///       文本域失去输入焦点事件
		///       </summary>
		
		public event ElementEventHandler LostFocus = null;

		/// <summary>
		///       数据正在验证事件,在该事件处理中可撤销相关操作
		///       </summary>
		
		public event ElementValidatingEventHandler Validating = null;

		/// <summary>
		///       数据验证结束的事件
		///       </summary>
		
		public event ElementEventHandler Validated = null;

		/// <summary>
		///       鼠标进入事件
		///       </summary>
		
		public event ElementCancelEventHandler BeforeDropDown = null;

		/// <summary>
		///       鼠标进入事件
		///       </summary>
		
		public event ElementEventHandler MouseEnter = null;

		/// <summary>
		///       鼠标离开事件
		///       </summary>
		
		public event ElementEventHandler MouseLeave = null;

		/// <summary>
		///       文档元素执行表达式事件
		///       </summary>
		
		public event ElementExpressionEventHandler Expression = null;

		/// <summary>
		///       查询文档元素状态事件
		///       </summary>
		
		public event ElementQueryStateEventHandler QueryState = null;

		/// <summary>
		///       准备绘制文档元素内容前事件
		///       </summary>
		
		public event ElementPaintEventHandler BeforePaint = null;

		/// <summary>
		///       绘制文档元素内容后触发的事件
		///       </summary>
		
		public event ElementPaintEventHandler AfterPaint = null;

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public ElementEventTemplate()
		{
		}

		private bool IsRunInCom(XTextElement element)
		{
			if (element.WriterControl != null)
			{
				return element.WriterControl.IsAxControl;
			}
			return false;
		}

		/// <summary>
		///       触发文档元素加载事件
		///       </summary>
		/// <param name="eventSender">事件参数</param>
		/// <param name="args">事件参数</param>
		
		public virtual void OnLoad(object sender, ElementLoadEventArgs e)
		{
			int num = 2;
			if (this.Load != null)
			{
				if (e.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						this.Load(sender, e);
					}
					catch (Exception exception_)
					{
						e.Element.OwnerDocument.method_39(e.Element, exception_, "Element.Load");
					}
				}
				else
				{
					this.Load(sender, e);
				}
			}
		}

		/// <summary>
		///       处理文档元素鼠标点击事件
		///       </summary>
		/// <param name="eventSender">参数</param>
		/// <param name="args">参数</param>
		
		public virtual void OnMouseClick(object sender, ElementMouseEventArgs e)
		{
			int num = 6;
			if (this.MouseClick != null)
			{
				if (e.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						this.MouseClick(sender, e);
					}
					catch (Exception exception_)
					{
						e.Element.OwnerDocument.method_39(e.Element, exception_, "Element.MouseClick");
					}
				}
				else
				{
					this.MouseClick(sender, e);
				}
			}
		}

		/// <summary>
		///       处理文档元素鼠标双击事件
		///       </summary>
		/// <param name="eventSender">参数</param>
		/// <param name="args">参数</param>
		
		public virtual void OnMouseDblClick(object sender, ElementMouseEventArgs e)
		{
			int num = 7;
			if (this.MouseDblClick != null)
			{
				if (e.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						this.MouseDblClick(sender, e);
					}
					catch (Exception exception_)
					{
						e.Element.OwnerDocument.method_39(e.Element, exception_, "Element.MouseDblClick");
					}
				}
				else
				{
					this.MouseDblClick(sender, e);
				}
			}
		}

		/// <summary>
		///       处理文档元素鼠标按键按下事件
		///       </summary>
		/// <param name="eventSender">参数</param>
		/// <param name="args">参数</param>
		
		public virtual void OnMouseDown(object sender, ElementMouseEventArgs e)
		{
			int num = 15;
			if (this.MouseDown != null)
			{
				if (e.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						this.MouseDown(sender, e);
					}
					catch (Exception exception_)
					{
						e.Element.OwnerDocument.method_39(e.Element, exception_, "Element.MouseDown");
					}
				}
				else
				{
					this.MouseDown(sender, e);
				}
			}
		}

		/// <summary>
		///       处理文档元素鼠标移动事件
		///       </summary>
		/// <param name="eventSender">参数</param>
		/// <param name="args">参数</param>
		
		public virtual void OnMouseMove(object sender, ElementMouseEventArgs e)
		{
			int num = 0;
			if (this.MouseMove != null)
			{
				if (e.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						this.MouseMove(sender, e);
					}
					catch (Exception exception_)
					{
						e.Element.OwnerDocument.method_39(e.Element, exception_, "Element.MouseMove");
					}
				}
				else
				{
					this.MouseMove(sender, e);
				}
			}
		}

		/// <summary>
		///       处理文档元素鼠标按键松开事件
		///       </summary>
		/// <param name="eventSender">参数</param>
		/// <param name="args">参数</param>
		
		public virtual void OnMouseUp(object sender, ElementMouseEventArgs e)
		{
			int num = 5;
			if (this.MouseUp != null)
			{
				if (e.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						this.MouseUp(sender, e);
					}
					catch (Exception exception_)
					{
						e.Element.OwnerDocument.method_39(e.Element, exception_, "Element.MouseUp");
					}
				}
				else
				{
					this.MouseUp(sender, e);
				}
			}
		}

		/// <summary>
		///       处理文档元素键盘按键按下事件
		///       </summary>
		/// <param name="eventSender">参数</param>
		/// <param name="args">参数</param>
		
		public virtual void OnKeyDown(object sender, ElementKeyEventArgs e)
		{
			int num = 5;
			if (this.KeyDown != null)
			{
				if (e.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						this.KeyDown(sender, e);
					}
					catch (Exception exception_)
					{
						e.Element.OwnerDocument.method_39(e.Element, exception_, "Element.KeyDown");
					}
				}
				else
				{
					this.KeyDown(sender, e);
				}
			}
		}

		/// <summary>
		///       处理文档元素键盘按键事件
		///       </summary>
		/// <param name="eventSender">参数</param>
		/// <param name="args">参数</param>
		
		public virtual void OnKeyPress(object sender, ElementKeyEventArgs e)
		{
			int num = 10;
			if (this.KeyPress != null)
			{
				if (e.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						this.KeyPress(sender, e);
					}
					catch (Exception exception_)
					{
						e.Element.OwnerDocument.method_39(e.Element, exception_, "Element.KeyPress");
					}
				}
				else
				{
					this.KeyPress(sender, e);
				}
			}
		}

		/// <summary>
		///       处理文档元素键盘按键松开事件
		///       </summary>
		/// <param name="eventSender">参数</param>
		/// <param name="args">参数</param>
		
		public virtual void OnKeyUp(object sender, ElementKeyEventArgs e)
		{
			int num = 16;
			if (this.KeyUp != null)
			{
				if (e.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						this.KeyUp(sender, e);
					}
					catch (Exception exception_)
					{
						e.Element.OwnerDocument.method_39(e.Element, exception_, "Element.KeyUp");
					}
				}
				else
				{
					this.KeyUp(sender, e);
				}
			}
		}

		/// <summary>
		///       触发 ContentChanged事件
		///       </summary>
		/// <param name="eventSender">
		/// </param>
		/// <param name="args">
		/// </param>
		
		public virtual void OnContentChanged(object sender, ContentChangedEventArgs e)
		{
			int num = 1;
			if (this.ContentChanged != null)
			{
				if (e.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						this.ContentChanged(sender, e);
					}
					catch (Exception exception_)
					{
						e.Element.OwnerDocument.method_39(e.Element, exception_, "Element.ContentChanged");
					}
				}
				else
				{
					this.ContentChanged(sender, e);
				}
			}
		}

		/// <summary>
		///       触发 ContentChanging事件
		///       </summary>
		/// <param name="eventSender">
		/// </param>
		/// <param name="args">
		/// </param>
		
		public virtual void OnContentChanging(object sender, ContentChangingEventArgs e)
		{
			int num = 3;
			if (this.ContentChanging != null)
			{
				if (e.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						this.ContentChanging(sender, e);
					}
					catch (Exception exception_)
					{
						e.Element.OwnerDocument.method_39(e.Element, exception_, "Element.ContentChanging");
					}
				}
				else
				{
					this.ContentChanging(sender, e);
				}
			}
		}

		/// <summary>
		///       触发获得输入焦点事件
		///       </summary>
		/// <param name="eventSender">事件发起者</param>
		/// <param name="args">事件参数</param>
		
		public virtual void OnGotFocus(object sender, ElementEventArgs e)
		{
			int num = 3;
			if (this.GotFocus != null)
			{
				if (e.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						this.GotFocus(sender, e);
					}
					catch (Exception exception_)
					{
						e.Element.OwnerDocument.method_39(e.Element, exception_, "Element.GotFocus");
					}
				}
				else
				{
					this.GotFocus(sender, e);
				}
			}
		}

		/// <summary>
		///       触发失去输入焦点事件
		///       </summary>
		/// <param name="eventSender">事件发起者</param>
		/// <param name="args">事件参数</param>
		
		public virtual void OnLostFocus(object sender, ElementEventArgs e)
		{
			int num = 7;
			if (this.LostFocus != null)
			{
				if (e.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						this.LostFocus(sender, e);
					}
					catch (Exception exception_)
					{
						e.Element.OwnerDocument.method_39(e.Element, exception_, "Element.LostFocus");
					}
				}
				else
				{
					this.LostFocus(sender, e);
				}
			}
		}

		/// <summary>
		///       触发数据正在验证事件
		///       </summary>
		/// <param name="eventSender">
		/// </param>
		/// <param name="args">
		/// </param>
		
		public virtual void OnValidating(object sender, ElementValidatingEventArgs e)
		{
			int num = 9;
			if (this.Validating != null)
			{
				if (e.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						this.Validating(sender, e);
					}
					catch (Exception exception_)
					{
						e.Element.OwnerDocument.method_39(e.Element, exception_, "Element.Validating");
					}
				}
				else
				{
					this.Validating(sender, e);
				}
			}
		}

		/// <summary>
		///       触发数据验证结束事件
		///       </summary>
		/// <param name="eventSender">事件发起者</param>
		/// <param name="args">参数</param>
		
		public virtual void OnValidated(object sender, ElementEventArgs e)
		{
			int num = 1;
			if (this.Validated != null)
			{
				if (e.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						this.Validated(sender, e);
					}
					catch (Exception exception_)
					{
						e.Element.OwnerDocument.method_39(e.Element, exception_, "Element.Validated");
					}
				}
				else
				{
					this.Validated(sender, e);
				}
			}
		}

		/// <summary>
		///       触发准备弹出下拉列表事件
		///       </summary>
		/// <param name="eventSender">参数</param>
		/// <param name="args">参数</param>
		
		public virtual void OnBeforeDropDown(object sender, ElementCancelEventArgs e)
		{
			int num = 2;
			if (this.BeforeDropDown != null)
			{
				if (e.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						this.BeforeDropDown(sender, e);
					}
					catch (Exception exception_)
					{
						e.Element.OwnerDocument.method_39(e.Element, exception_, "Element.BeforeDropDown");
					}
				}
				else
				{
					this.BeforeDropDown(sender, e);
				}
			}
		}

		/// <summary>
		///       触发鼠标进入事件
		///       </summary>
		/// <param name="eventSender">参数</param>
		/// <param name="args">参数</param>
		
		public virtual void OnMouseEnter(object sender, ElementEventArgs e)
		{
			int num = 8;
			if (this.MouseEnter != null)
			{
				if (e.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						this.MouseEnter(sender, e);
					}
					catch (Exception exception_)
					{
						e.Element.OwnerDocument.method_39(e.Element, exception_, "Element.MouseEnter");
					}
				}
				else
				{
					this.MouseEnter(sender, e);
				}
			}
		}

		/// <summary>
		///       触发鼠标离开事件
		///       </summary>
		/// <param name="eventSender">参数</param>
		/// <param name="args">参数</param>
		
		public virtual void OnMouseLeave(object sender, ElementEventArgs e)
		{
			int num = 16;
			if (this.MouseLeave != null)
			{
				if (e.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						this.MouseLeave(sender, e);
					}
					catch (Exception exception_)
					{
						e.Element.OwnerDocument.method_39(e.Element, exception_, "Element.MouseLeave");
					}
				}
				else
				{
					this.MouseLeave(sender, e);
				}
			}
		}

		/// <summary>
		///       触发文档元素执行表达式事件
		///       </summary>
		/// <param name="eventSender">参数</param>
		/// <param name="args">参数</param>
		
		public virtual void OnExpression(object sender, ElementExpressionEventArgs e)
		{
			int num = 3;
			if (this.Expression != null)
			{
				if (e.Element.OwnerDocument.IsTryCathForRaiseEvent)
				{
					try
					{
						this.Expression(sender, e);
					}
					catch (Exception exception_)
					{
						e.Element.OwnerDocument.method_39(e.Element, exception_, "Element.Expression");
					}
				}
				else
				{
					this.Expression(sender, e);
				}
			}
		}

		/// <summary>
		///       触发查询文档元素状态事件
		///       </summary>
		/// <param name="eventSender">参数</param>
		/// <param name="args">参数</param>
		
		public virtual void OnQueryState(object sender, ElementQueryStateEventArgs e)
		{
			int num = 14;
			if (this.QueryState != null)
			{
				if (e.Element.OwnerDocument.IsTryCathForRaiseEvent)
				{
					try
					{
						this.QueryState(sender, e);
					}
					catch (Exception exception_)
					{
						e.Element.OwnerDocument.method_39(e.Element, exception_, "Element.QueryState");
					}
				}
				else
				{
					this.QueryState(sender, e);
				}
			}
		}

		/// <summary>
		///       触发准备绘制文档元素内容前事件
		///       </summary>
		/// <param name="eventSender">参数</param>
		/// <param name="args">参数</param>
		
		public virtual void OnBeforePaint(object sender, ElementPaintEventArgs e)
		{
			int num = 7;
			if (this.BeforePaint != null)
			{
				if (e.Element.OwnerDocument.IsTryCathForRaiseEvent)
				{
					try
					{
						this.BeforePaint(sender, e);
					}
					catch (Exception exception_)
					{
						e.Element.OwnerDocument.method_39(e.Element, exception_, "Element.BeforePaint");
					}
				}
				else
				{
					this.BeforePaint(sender, e);
				}
			}
		}

		/// <summary>
		///       触发准备绘制文档元素内容前事件
		///       </summary>
		/// <param name="eventSender">参数</param>
		/// <param name="args">参数</param>
		
		public virtual void OnAfterPaint(object sender, ElementPaintEventArgs e)
		{
			int num = 14;
			if (this.AfterPaint != null)
			{
				if (e.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						this.AfterPaint(sender, e);
					}
					catch (Exception exception_)
					{
						e.Element.OwnerDocument.method_39(e.Element, exception_, "Element.AfterPaint");
					}
				}
				else
				{
					this.AfterPaint(sender, e);
				}
			}
		}
	}
}
