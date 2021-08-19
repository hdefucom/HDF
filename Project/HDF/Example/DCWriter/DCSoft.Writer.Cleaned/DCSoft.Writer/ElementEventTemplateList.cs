using DCSoft.Common;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       元素事件模板列表
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	[DocumentComment]
	[DCPublishAPI]
	[ComDefaultInterface(typeof(IElementEventTemplateList))]
	[Guid("D670F798-A4CE-40AC-8B42-37AFFBA4399D")]
	[ComClass("D670F798-A4CE-40AC-8B42-37AFFBA4399D", "BB0F62C0-A161-4AEB-B3F9-262D156B483B")]
	public class ElementEventTemplateList : List<ElementEventTemplate>, IElementEventTemplateList
	{
		internal const string CLASSID = "D670F798-A4CE-40AC-8B42-37AFFBA4399D";

		internal const string CLASSID_Interface = "BB0F62C0-A161-4AEB-B3F9-262D156B483B";

		/// <summary>
		///       获得指定名称的事件监听器，名称不区分大小写
		///       </summary>
		/// <param name="name">名称</param>
		/// <returns>获得的监听器对象</returns>
		[DCPublishAPI]
		public ElementEventTemplate this[string name]
		{
			get
			{
				if (string.IsNullOrEmpty(name))
				{
					return null;
				}
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ElementEventTemplate current = enumerator.Current;
						if (string.Compare(current.Name, name, ignoreCase: true) == 0)
						{
							return current;
						}
					}
				}
				return null;
			}
		}

		/// <summary>
		///       判断是否存在Load事件
		///       </summary>
		internal bool HasLoad
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ElementEventTemplate current = enumerator.Current;
						if (current.Enabled && current.HasLoad)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		/// <summary>
		///       是否存在MouseClick事件
		///       </summary>
		internal bool HasMouseClick
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ElementEventTemplate current = enumerator.Current;
						if (current.Enabled && current.HasMouseClick)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		/// <summary>
		///       是否存在MouseDblClick事件
		///       </summary>
		internal bool HasMouseDblClick
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ElementEventTemplate current = enumerator.Current;
						if (current.Enabled && current.HasMouseDblClick)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		/// <summary>
		///       是否需要处理MouseDown事件
		///       </summary>
		internal bool HasMouseDown
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ElementEventTemplate current = enumerator.Current;
						if (current.Enabled && current.HasMouseDown)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		/// <summary>
		///       是否需要处理MouseMove事件
		///       </summary>
		internal bool HasMouseMove
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ElementEventTemplate current = enumerator.Current;
						if (current.Enabled && current.HasMouseMove)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		/// <summary>
		///       是否有MouseUp事件
		///       </summary>
		internal bool HasMouseUp
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ElementEventTemplate current = enumerator.Current;
						if (current.Enabled && current.HasMouseUp)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		/// <summary>
		///       是否有KeyDown事件
		///       </summary>
		internal bool HasKeyDown
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ElementEventTemplate current = enumerator.Current;
						if (current.Enabled && current.HasKeyDown)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		/// <summary>
		///       是否有KeyPress事件
		///       </summary>
		internal bool HasKeyPress
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ElementEventTemplate current = enumerator.Current;
						if (current.Enabled && current.HasKeyPress)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		/// <summary>
		///       是否有KeyPress事件
		///       </summary>
		internal bool HasKeyUp
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ElementEventTemplate current = enumerator.Current;
						if (current.Enabled && current.HasKeyUp)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		/// <summary>
		///       判断是否存在 ContentChanged 事件
		///       </summary>
		internal bool HasContentChanged
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ElementEventTemplate current = enumerator.Current;
						if (current.Enabled && current.HasContentChanged)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		/// <summary>
		///       判断是否存在 ContentChanging 事件
		///       </summary>
		internal bool HasContentChanging
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ElementEventTemplate current = enumerator.Current;
						if (current.Enabled && current.HasContentChanging)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		/// <summary>
		///       判断是否存在GetFocus事件
		///       </summary>
		internal bool HasGotFocus
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ElementEventTemplate current = enumerator.Current;
						if (current.Enabled && current.HasGotFocus)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		/// <summary>
		///       判断是否存在失去输入焦点事件
		///       </summary>
		internal bool HasLostFocus
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ElementEventTemplate current = enumerator.Current;
						if (current.Enabled && current.HasLostFocus)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		/// <summary>
		///       是否存在Validating事件
		///       </summary>
		internal bool HasValidating
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ElementEventTemplate current = enumerator.Current;
						if (current.Enabled && current.HasValidating)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		/// <summary>
		///       是否存在数据验证结束事件
		///       </summary>
		internal bool HasValidated
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ElementEventTemplate current = enumerator.Current;
						if (current.Enabled && current.HasValidated)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		/// <summary>
		///       判断是否存在BeforeDropDown事件
		///       </summary>
		[DCInternal]
		public bool HasBeforeDropDown
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ElementEventTemplate current = enumerator.Current;
						if (current.Enabled && current.HasBeforeDropDown)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		/// <summary>
		///       判断是否存在鼠标进入事件
		///       </summary>
		internal bool HasMouseEnter
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ElementEventTemplate current = enumerator.Current;
						if (current.Enabled && current.HasMouseEnter)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		/// <summary>
		///       判断是否存在鼠标离开事件
		///       </summary>
		internal bool HasMouseLeave
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ElementEventTemplate current = enumerator.Current;
						if (current.Enabled && current.HasMouseLeave)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		/// <summary>
		///       判断是否存在文档元素执行表达式事件
		///       </summary>
		[DCInternal]
		public bool HasExpression
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ElementEventTemplate current = enumerator.Current;
						if (current.Enabled && current.HasExpression)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		/// <summary>
		///       判断是否存在文档元素执行表达式事件
		///       </summary>
		internal bool HasQueryState
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ElementEventTemplate current = enumerator.Current;
						if (current.Enabled && current.HasQueryState)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		/// <summary>
		///       判断是否存在准备绘制文档元素内容前事件
		///       </summary>
		[DCInternal]
		public virtual bool HasBeforePaint
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ElementEventTemplate current = enumerator.Current;
						if (current.Enabled && current.HasBeforePaint)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		/// <summary>
		///       判断是否存在准备绘制文档元素内容前事件
		///       </summary>
		[DCInternal]
		public virtual bool HasAfterPaint
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ElementEventTemplate current = enumerator.Current;
						if (current.Enabled && current.HasAfterPaint)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		[DCPublishAPI]
		public ElementEventTemplateList()
		{
		}

		/// <summary>
		///       触发文档元素加载事件
		///       </summary>
		/// <param name="eventSender">事件参数</param>
		/// <param name="args">事件参数</param>
		[DCInternal]
		public virtual void OnLoad(object sender, ElementLoadEventArgs e)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ElementEventTemplate current = enumerator.Current;
					if (current.Enabled && current.HasLoad)
					{
						current.OnLoad(sender, e);
						if (e.Handled)
						{
							break;
						}
					}
				}
			}
		}

		/// <summary>
		///       处理文档元素鼠标点击事件
		///       </summary>
		/// <param name="eventSender">参数</param>
		/// <param name="args">参数</param>
		[DCInternal]
		public virtual void OnMouseClick(object sender, ElementMouseEventArgs e)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ElementEventTemplate current = enumerator.Current;
					if (current.Enabled && current.HasMouseClick)
					{
						current.OnMouseClick(sender, e);
						if (e.Handled)
						{
							break;
						}
					}
				}
			}
		}

		/// <summary>
		///       处理文档元素鼠标双击事件
		///       </summary>
		/// <param name="eventSender">参数</param>
		/// <param name="args">参数</param>
		[DCInternal]
		public virtual void OnMouseDblClick(object sender, ElementMouseEventArgs e)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ElementEventTemplate current = enumerator.Current;
					if (current.Enabled && current.HasMouseDblClick)
					{
						current.OnMouseDblClick(sender, e);
						if (e.Handled)
						{
							break;
						}
					}
				}
			}
		}

		/// <summary>
		///       处理文档元素鼠标按键按下事件
		///       </summary>
		/// <param name="eventSender">参数</param>
		/// <param name="args">参数</param>
		[DCInternal]
		public virtual void OnMouseDown(object sender, ElementMouseEventArgs e)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ElementEventTemplate current = enumerator.Current;
					if (current.Enabled && current.HasMouseDown)
					{
						current.OnMouseDown(sender, e);
						if (e.Handled)
						{
							break;
						}
					}
				}
			}
		}

		/// <summary>
		///       处理文档元素鼠标移动事件
		///       </summary>
		/// <param name="eventSender">参数</param>
		/// <param name="args">参数</param>
		[DCInternal]
		public virtual void OnMouseMove(object sender, ElementMouseEventArgs e)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ElementEventTemplate current = enumerator.Current;
					if (current.Enabled && current.HasMouseMove)
					{
						current.OnMouseMove(sender, e);
						if (e.Handled)
						{
							break;
						}
					}
				}
			}
		}

		/// <summary>
		///       处理文档元素鼠标按键松开事件
		///       </summary>
		/// <param name="eventSender">参数</param>
		/// <param name="args">参数</param>
		[DCInternal]
		public virtual void OnMouseUp(object sender, ElementMouseEventArgs e)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ElementEventTemplate current = enumerator.Current;
					if (current.Enabled && current.HasMouseUp)
					{
						current.OnMouseUp(sender, e);
						if (e.Handled)
						{
							break;
						}
					}
				}
			}
		}

		/// <summary>
		///       处理文档元素键盘按键按下事件
		///       </summary>
		/// <param name="eventSender">参数</param>
		/// <param name="args">参数</param>
		[DCInternal]
		public virtual void OnKeyDown(object sender, ElementKeyEventArgs e)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ElementEventTemplate current = enumerator.Current;
					if (current.Enabled && current.HasKeyDown)
					{
						current.OnKeyDown(sender, e);
						if (e.Handled)
						{
							break;
						}
					}
				}
			}
		}

		/// <summary>
		///       处理文档元素键盘按键事件
		///       </summary>
		/// <param name="eventSender">参数</param>
		/// <param name="args">参数</param>
		[DCInternal]
		public virtual void OnKeyPress(object sender, ElementKeyEventArgs e)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ElementEventTemplate current = enumerator.Current;
					if (current.Enabled && current.HasKeyPress)
					{
						current.OnKeyPress(sender, e);
						if (e.Handled)
						{
							break;
						}
					}
				}
			}
		}

		/// <summary>
		///       处理文档元素键盘按键松开事件
		///       </summary>
		/// <param name="eventSender">参数</param>
		/// <param name="args">参数</param>
		[DCInternal]
		public virtual void OnKeyUp(object sender, ElementKeyEventArgs e)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ElementEventTemplate current = enumerator.Current;
					if (current.Enabled && current.HasKeyUp)
					{
						current.OnKeyUp(sender, e);
						if (e.Handled)
						{
							break;
						}
					}
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
		[DCInternal]
		public virtual void OnContentChanged(object sender, ContentChangedEventArgs e)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ElementEventTemplate current = enumerator.Current;
					if (current.Enabled && current.HasContentChanged)
					{
						current.OnContentChanged(sender, e);
						if (e.Handled)
						{
							break;
						}
					}
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
		[DCInternal]
		public virtual void OnContentChanging(object sender, ContentChangingEventArgs e)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ElementEventTemplate current = enumerator.Current;
					if (current.Enabled && current.HasContentChanging)
					{
						current.OnContentChanging(sender, e);
						if (e.Handled)
						{
							break;
						}
					}
				}
			}
		}

		/// <summary>
		///       触发获得输入焦点事件
		///       </summary>
		/// <param name="eventSender">事件发起者</param>
		/// <param name="args">事件参数</param>
		[DCInternal]
		public virtual void OnGotFocus(object sender, ElementEventArgs e)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ElementEventTemplate current = enumerator.Current;
					if (current.Enabled && current.HasGotFocus)
					{
						current.OnGotFocus(sender, e);
						if (e.Handled)
						{
							break;
						}
					}
				}
			}
		}

		/// <summary>
		///       触发失去输入焦点事件
		///       </summary>
		/// <param name="eventSender">事件发起者</param>
		/// <param name="args">事件参数</param>
		[DCInternal]
		public virtual void OnLostFocus(object sender, ElementEventArgs e)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ElementEventTemplate current = enumerator.Current;
					if (current.Enabled && current.HasLostFocus)
					{
						current.OnLostFocus(sender, e);
						if (e.Handled)
						{
							break;
						}
					}
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
		[DCInternal]
		public virtual void OnValidating(object sender, ElementValidatingEventArgs e)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ElementEventTemplate current = enumerator.Current;
					if (current.Enabled && current.HasValidating)
					{
						current.OnValidating(sender, e);
						if (e.Handled)
						{
							break;
						}
					}
				}
			}
		}

		/// <summary>
		///       触发数据验证结束事件
		///       </summary>
		/// <param name="eventSender">事件发起者</param>
		/// <param name="args">参数</param>
		[DCInternal]
		public virtual void OnValidated(object sender, ElementEventArgs e)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ElementEventTemplate current = enumerator.Current;
					if (current.Enabled && current.HasValidated)
					{
						current.OnValidated(sender, e);
						if (e.Handled)
						{
							break;
						}
					}
				}
			}
		}

		/// <summary>
		///       触发BeforeDropDown事件
		///       </summary>
		/// <param name="eventSender">参数</param>
		/// <param name="args">参数</param>
		[DCInternal]
		public virtual void OnBeforeDropDown(object sender, ElementCancelEventArgs e)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ElementEventTemplate current = enumerator.Current;
					if (current.Enabled && current.HasBeforeDropDown)
					{
						current.OnBeforeDropDown(sender, e);
						if (e.Handled)
						{
							break;
						}
					}
				}
			}
		}

		/// <summary>
		///       触发鼠标进入事件
		///       </summary>
		/// <param name="eventSender">参数</param>
		/// <param name="args">参数</param>
		[DCInternal]
		public virtual void OnMouseEnter(object sender, ElementEventArgs e)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ElementEventTemplate current = enumerator.Current;
					if (current.Enabled && current.HasMouseEnter)
					{
						current.OnMouseEnter(sender, e);
						if (e.Handled)
						{
							break;
						}
					}
				}
			}
		}

		/// <summary>
		///       触发鼠标离开事件
		///       </summary>
		/// <param name="eventSender">参数</param>
		/// <param name="args">参数</param>
		[DCInternal]
		public virtual void OnMouseLeave(object sender, ElementEventArgs e)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ElementEventTemplate current = enumerator.Current;
					if (current.Enabled && current.HasMouseLeave)
					{
						current.OnMouseLeave(sender, e);
						if (e.Handled)
						{
							break;
						}
					}
				}
			}
		}

		/// <summary>
		///       触发文档元素执行表达式事件
		///       </summary>
		/// <param name="eventSender">参数</param>
		/// <param name="args">参数</param>
		[DCInternal]
		public virtual void OnExpression(object sender, ElementExpressionEventArgs e)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ElementEventTemplate current = enumerator.Current;
					if (current.Enabled && current.HasExpression)
					{
						current.OnExpression(sender, e);
						if (e.Handled)
						{
							break;
						}
					}
				}
			}
		}

		/// <summary>
		///       触发文档元素执行表达式事件
		///       </summary>
		/// <param name="eventSender">参数</param>
		/// <param name="args">参数</param>
		[DCInternal]
		public virtual void OnQueryState(object sender, ElementQueryStateEventArgs e)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ElementEventTemplate current = enumerator.Current;
					if (current.Enabled && current.HasQueryState)
					{
						current.OnQueryState(sender, e);
						if (e.Handled)
						{
							break;
						}
					}
				}
			}
		}

		/// <summary>
		///       触发准备绘制文档元素内容前事件
		///       </summary>
		/// <param name="eventSender">参数</param>
		/// <param name="args">参数</param>
		[DCInternal]
		public virtual void OnBeforePaint(object sender, ElementPaintEventArgs e)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ElementEventTemplate current = enumerator.Current;
					if (current.Enabled && current.HasBeforePaint)
					{
						current.OnBeforePaint(sender, e);
						if (e.Handled)
						{
							break;
						}
					}
				}
			}
		}

		/// <summary>
		///       触发准备绘制文档元素内容前事件
		///       </summary>
		/// <param name="eventSender">参数</param>
		/// <param name="args">参数</param>
		[DCInternal]
		public virtual void OnAfterPaint(object sender, ElementPaintEventArgs e)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ElementEventTemplate current = enumerator.Current;
					if (current.Enabled && current.HasAfterPaint)
					{
						current.OnAfterPaint(sender, e);
						if (e.Handled)
						{
							break;
						}
					}
				}
			}
		}
	}
}
