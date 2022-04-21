using DCSoft.Common;
using DCSoft.WinForms;
using DCSoft.Writer.Data;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       简单文本标签元素基础类型
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	
	
	public class XTextLabelElementBase : XTextObjectElement, IUpdateDataBindingExt
	{
		[NonSerialized]
		private DataSourceTreeNode dataSourceTreeNode_0 = null;

		[NonSerialized]
		private bool bool_9 = false;

		private XDataBinding xdataBinding_0 = null;

		private string string_9 = null;

		private PageLabelTextList pageLabelTextList_0 = null;

		private bool bool_10 = false;

		/// <summary>
		///       绑定的数据源对象
		///       </summary>
		
		[ComVisible(false)]
		[DefaultValue(null)]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
		public DataSourceTreeNode DataBoundNode
		{
			get
			{
				return dataSourceTreeNode_0;
			}
			set
			{
				dataSourceTreeNode_0 = value;
			}
		}

		/// <summary>
		///       使用了数据源节点的数值
		///       </summary>
		[XmlIgnore]
		
		[ComVisible(false)]
		[DefaultValue(false)]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool DataBoundNodeValueUsed
		{
			get
			{
				return bool_9;
			}
			set
			{
				bool_9 = value;
			}
		}

		/// <summary>
		///       内容绑定对象
		///       </summary>
		
		[HtmlAttribute]
		[DefaultValue(null)]
		public XDataBinding ValueBinding
		{
			get
			{
				if (xdataBinding_0 == null && DocumentBehaviorOptions.StaticAutoCreateInstanceInProperty)
				{
					xdataBinding_0 = new XDataBinding();
				}
				return xdataBinding_0;
			}
			set
			{
				xdataBinding_0 = value;
			}
		}

		/// <summary>
		///       运行时的是否自动设置大小
		///       </summary>
		
		[Browsable(false)]
		public virtual bool RuntimeAutoSize => true;

		/// <summary>
		///       用户能否改变对象大小
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public override ResizeableType Resizeable
		{
			get
			{
				if (RuntimeAutoSize)
				{
					return ResizeableType.FixSize;
				}
				return ResizeableType.WidthAndHeight;
			}
			set
			{
				base.Resizeable = value;
			}
		}

		[Browsable(false)]
		[XmlIgnore]
		[MemberExpressionable(MemberEffectLevel.DOM)]
		
		public override string FormulaValue
		{
			get
			{
				return Text;
			}
			set
			{
				Text = method_12(value);
				if (RuntimeAutoSize)
				{
					EditorRefreshView();
				}
				else
				{
					InvalidateView();
				}
			}
		}

		/// <summary>
		///       对象宽度
		///       </summary>
		[Browsable(true)]
		
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		[XmlElement]
		public override float Width
		{
			get
			{
				return base.Width;
			}
			set
			{
				base.Width = value;
			}
		}

		/// <summary>
		///       对象高度
		///       </summary>
		[Browsable(true)]
		
		[XmlElement]
		[HtmlAttribute]
		public override float Height
		{
			get
			{
				return base.Height;
			}
			set
			{
				base.Height = value;
			}
		}

		/// <summary>
		///       文本值
		///       </summary>
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		
		[Browsable(true)]
		[XmlElement]
		public override string Text
		{
			get
			{
				return string_9;
			}
			set
			{
				string_9 = value;
			}
		}

		/// <summary>
		///       各个页面的文本
		///       </summary>
		[DefaultValue(null)]
		
		[XmlArrayItem("PageText", typeof(PageLabelText))]
		public PageLabelTextList PageTexts
		{
			get
			{
				if (pageLabelTextList_0 == null)
				{
					pageLabelTextList_0 = new PageLabelTextList();
				}
				return pageLabelTextList_0;
			}
			set
			{
				pageLabelTextList_0 = value;
			}
		}

		/// <summary>
		///       调用PageTexts时严格匹配页码
		///       </summary>
		/// <remarks>
		///       如果本属性为true，则严格匹配PageTexts列表中指定的页码，如果没找到对应页码的信息，则显示本对象的Text值。
		///       </remarks>
		[Browsable(true)]
		[HtmlAttribute]
		
		[DefaultValue(false)]
		[MemberExpressionable(MemberEffectLevel.ElementView)]
		[ComVisible(true)]
		public bool StrictMatchPageIndex
		{
			get
			{
				return bool_10;
			}
			set
			{
				bool_10 = value;
			}
		}

		/// <summary>
		///       分页文本的预览文本
		///       </summary>
		[Browsable(true)]
		
		public string PageTextsPreview
		{
			get
			{
				if (pageLabelTextList_0 == null)
				{
					return "";
				}
				return pageLabelTextList_0.ToString();
			}
		}

		/// <summary>
		///       文档加载后的处理
		///       </summary>
		/// <param name="args">参数</param>
		
		public override void AfterLoad(ElementLoadEventArgs args)
		{
			base.AfterLoad(args);
			if (ValueBinding != null && ValueBinding.AutoUpdate)
			{
				UpdateDataBindingExt(new UpdateDataBindingArgs(null, fastMode: true));
			}
		}

		
		public int UpdateDataBindingExt(UpdateDataBindingArgs args)
		{
			DataBoundNodeValueUsed = false;
			DataBoundNode = null;
			if (ValueBinding != null && ValueBinding.Enabled && !ValueBinding.IsEmptyBinding)
			{
				if (ValueBinding.ProcessState == DCProcessStates.Never)
				{
					return 0;
				}
				if (!args.CheckForSpecifyParameterName(ValueBinding))
				{
					return 0;
				}
				XTextDocument ownerDocument = OwnerDocument;
				if (!ownerDocument.Options.BehaviorOptions.EnableDataBinding)
				{
					return 0;
				}
				DataSourceTreeNode dataSourceTreeNode2 = DataBoundNode = method_2(ValueBinding, args);
				object obj = null;
				if (!(dataSourceTreeNode2?.IsEmpty ?? true))
				{
					obj = dataSourceTreeNode2.RuntimeDisplayValue;
					DataBoundNodeValueUsed = true;
				}
				string text = null;
				text = ((obj != null && !DBNull.Value.Equals(obj)) ? Convert.ToString(obj) : null);
				if (ValueBinding.ProcessState == DCProcessStates.Once)
				{
					ValueBinding.ProcessState = DCProcessStates.Never;
				}
				if (Text != text)
				{
					Text = text;
					if (!args.FastMode)
					{
						InvalidateView();
					}
					return 1;
				}
			}
			return 0;
		}

		/// <summary>
		///       设置页码文本值
		///       </summary>
		/// <param name="pageIndex">从0开始计算的页码</param>
		/// <param name="text">文本值</param>
		[ComVisible(true)]
		public void SetPageLabelText(int pageIndex, string text)
		{
			PageTexts.SetPageText(pageIndex, text);
		}

		
		[ComVisible(false)]
		public string method_16(int int_8)
		{
			if (!XTextDocument.smethod_13(GEnum6.const_195))
			{
				return Text;
			}
			if (pageLabelTextList_0 != null && pageLabelTextList_0.Count > 0)
			{
				string text = pageLabelTextList_0.GetText(int_8, StrictMatchPageIndex);
				if (!string.IsNullOrEmpty(text))
				{
					if (!XTextDocument.smethod_13(GEnum6.const_195))
					{
						return Text;
					}
					return text;
				}
			}
			return Text;
		}

		protected virtual bool vmethod_26()
		{
			return !XTextDocument.smethod_13(GEnum6.const_195);
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <param name="Deeply">是否深度复制</param>
		/// <returns>复制品</returns>
		
		public override XTextElement Clone(bool Deeply)
		{
			XTextLabelElementBase xTextLabelElementBase = (XTextLabelElementBase)base.Clone(Deeply);
			if (pageLabelTextList_0 != null && pageLabelTextList_0.Count > 0)
			{
				xTextLabelElementBase.pageLabelTextList_0 = pageLabelTextList_0.Clone();
			}
			else
			{
				xTextLabelElementBase.pageLabelTextList_0 = null;
			}
			return xTextLabelElementBase;
		}

		/// <summary>
		///       返回表示对象的字符串
		///       </summary>
		/// <returns>返回的文本</returns>
		
		public override string ToString()
		{
			return Text;
		}

		public override void Dispose()
		{
			base.Dispose();
			dataSourceTreeNode_0 = null;
			if (pageLabelTextList_0 != null)
			{
				pageLabelTextList_0.Clear();
				pageLabelTextList_0 = null;
			}
			string_9 = null;
			xdataBinding_0 = null;
		}
	}
}
