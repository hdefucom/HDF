#define DEBUG
using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.WinForms.Design;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Data;
using DCSoft.Writer.Script;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       容器元素对象
	///       </summary>
	/// <remarks>
	///       本类型是从XTextElement上派生的容器文本文档元素类型,它能包含其他的文本文档元素,
	///       还可以包含其他的容器元素.是文本文档对象模型中比较基础的类型.
	///       编制 袁永福 2007-3-21
	///       </remarks>
	[Serializable]
	[ComDefaultInterface(typeof(IXTextContainerElement))]
	[DCPublishAPI]
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("00012345-6789-ABCD-EF01-234567890050", "20D11DD0-C872-4394-9B47-53C6BB2B5BC1")]
	[Guid("00012345-6789-ABCD-EF01-234567890050")]
	[ComVisible(true)]
	[DocumentComment]
	public class XTextContainerElement : XTextElement, IDeleteable, IUpdateDataBindingExt, IMemberPropertyExpressions, IXTextContainerElement
	{
		internal const string string_3 = "00012345-6789-ABCD-EF01-234567890050";

		internal const string string_4 = "20D11DD0-C872-4394-9B47-53C6BB2B5BC1";

		[NonSerialized]
		private ElementRenderResult elementRenderResult_0 = null;

		[NonSerialized]
		internal Enum10 enum10_0 = Enum10.const_0;

		private DataFeedbackInfo dataFeedbackInfo_0 = null;

		private int int_6 = 0;

		private string string_5 = null;

		private bool bool_5 = false;

		private bool bool_6 = false;

		private string string_6 = null;

		private string string_7 = null;

		private bool bool_7 = false;

		[NonSerialized]
		private bool bool_8 = false;

		private string string_8 = null;

		private string string_9 = null;

		private PropertyExpressionInfoList propertyExpressionInfoList_0 = null;

		private bool bool_9 = false;

		private bool bool_10 = false;

		[NonSerialized]
		private ValueValidateResult valueValidateResult_0 = null;

		private ValueValidateStyle valueValidateStyle_0 = null;

		[NonSerialized]
		private bool bool_11 = false;

		private ContainerAutoHideMode containerAutoHideMode_0 = ContainerAutoHideMode.None;

		[NonSerialized]
		private bool bool_12 = false;

		protected bool bool_13 = false;

		private XDataBinding xdataBinding_0 = null;

		private string string_10 = null;

		[NonSerialized]
		private DataSourceTreeNode dataSourceTreeNode_0 = null;

		[NonSerialized]
		private bool bool_14 = false;

		[NonSerialized]
		protected int int_7 = 0;

		private string string_11 = null;

		private string string_12 = null;

		[NonSerialized]
		private object object_0 = null;

		private int int_8 = 0;

		private DCBooleanValue dcbooleanValue_0 = DCBooleanValue.Inherit;

		private DCContentLockInfo dccontentLockInfo_0 = null;

		private ContentReadonlyState contentReadonlyState_0 = ContentReadonlyState.Inherit;

		private DomExpressionList domExpressionList_0 = null;

		private VBScriptItemList vbscriptItemList_0 = null;

		private XAttributeList xattributeList_0 = new XAttributeList();

		private CopySourceInfo copySourceInfo_0 = null;

		private string string_13 = null;

		[NonSerialized]
		private ContentBuilder contentBuilder_0 = null;

		private XTextElementList xtextElementList_0 = null;

		internal int int_9 = 0;

		[NonSerialized]
		internal XTextElementList xtextElementList_1 = null;

		private ElementType elementType_0 = ElementType.All;

		private ElementVisibility elementVisibility_0 = ElementVisibility.Visible;

		private bool bool_15 = true;

		private bool bool_16 = true;

		/// <summary>
		///       最后一次绘制内容的结果
		///       </summary>
		[DCPublishAPI]
		[XmlIgnore]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[ComVisible(true)]
		public ElementRenderResult LastRenderResult
		{
			get
			{
				return elementRenderResult_0;
			}
			set
			{
				elementRenderResult_0 = value;
			}
		}

		/// <summary>
		///       数据回填信息对象
		///       </summary>
		[XmlElement]
		[ComVisible(true)]
		[DefaultValue(null)]
		public DataFeedbackInfo DataFeedback
		{
			get
			{
				return dataFeedbackInfo_0;
			}
			set
			{
				dataFeedbackInfo_0 = value;
			}
		}

		/// <summary>
		///       最大可输入的字符的长度，属性值小于等于0则无限制。
		///       </summary>
		/// <remarks>
		///       仅仅限制用户手工操作输入的字符长度，不限制直接DOM操作。
		///       </remarks>
		[DefaultValue(0)]
		[HtmlAttribute]
		[ComVisible(true)]
		[MemberExpressionable]
		[DCPublishAPI]
		public int MaxInputLength
		{
			get
			{
				return int_6;
			}
			set
			{
				int_6 = value;
			}
		}

		internal int RuntimeMaxInputLength
		{
			get
			{
				if (XTextDocument.smethod_13(GEnum6.const_167))
				{
					return int_6;
				}
				return 0;
			}
		}

		/// <summary>
		///       数据名称。需要应用程序支持。
		///       </summary>
		[ComVisible(true)]
		[DefaultValue(null)]
		[MemberExpressionable]
		[HtmlAttribute]
		[DCPublishAPI]
		public virtual string DataName
		{
			get
			{
				return string_5;
			}
			set
			{
				string_5 = value;
			}
		}

		/// <summary>
		///       数据能否被其他地方引用。需要应用程序支持。
		///       </summary>
		[MemberExpressionable]
		[DefaultValue(false)]
		[ComVisible(true)]
		[HtmlAttribute]
		[DCPublishAPI]
		public bool CanBeReferenced
		{
			get
			{
				return bool_5;
			}
			set
			{
				bool_5 = value;
			}
		}

		/// <summary>
		///       保存文档时是否将该节点数据单独拿出来保存。需要应用程序支持。
		///       </summary>
		[DefaultValue(false)]
		[DCPublishAPI]
		[ComVisible(true)]
		[HtmlAttribute]
		[MemberExpressionable]
		public bool BringoutToSave
		{
			get
			{
				return bool_6;
			}
			set
			{
				bool_6 = value;
			}
		}

		/// <summary>
		///       引用的数据名称
		///       </summary>
		[DefaultValue(null)]
		[ComVisible(true)]
		[DCPublishAPI]
		[HtmlAttribute]
		[MemberExpressionable]
		public string ReferencedDataName
		{
			get
			{
				return string_6;
			}
			set
			{
				string_6 = value;
			}
		}

		/// <summary>
		///       提示文本
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(null)]
		[ComVisible(true)]
		[MemberExpressionable]
		[HtmlAttribute]
		[Editor(typeof(MultiLineStringUITypeEditor), typeof(UITypeEditor))]
		public string ToolTip
		{
			get
			{
				return string_7;
			}
			set
			{
				string_7 = value;
			}
		}

		internal string RuntimeToolTip
		{
			get
			{
				if (XTextDocument.smethod_13(GEnum6.const_165))
				{
					return string_7;
				}
				return null;
			}
		}

		/// <summary>
		///       实际使用的移动焦点所使用的快捷键样式
		///       </summary>
		[Browsable(false)]
		[HtmlAttribute]
		[ReadOnly(true)]
		[DCInternal]
		[DefaultValue(MoveFocusHotKeys.None)]
		[XmlIgnore]
		public virtual MoveFocusHotKeys RuntimeMoveFocusHotKey
		{
			get
			{
				return MoveFocusHotKeys.None;
			}
			set
			{
			}
		}

		/// <summary>
		///       能否接受制表符，默认false。
		///       </summary>
		[DefaultValue(false)]
		[DCPublishAPI]
		[HtmlAttribute]
		[MemberExpressionable]
		public virtual bool AcceptTab
		{
			get
			{
				return bool_7;
			}
			set
			{
				bool_7 = value;
			}
		}

		/// <summary>
		///       获取或设置一个运行时的值，该值指示用户能否使用 Tab 键将焦点放到该元素中上。 
		///       </summary>
		[Browsable(false)]
		[DCInternal]
		public virtual bool RuntimeTabStop => false;

		/// <summary>
		///       在WEB客户端选中状态.DCWriter内部使用。
		///       </summary>
		[HtmlAttribute]
		[DefaultValue(false)]
		[ComVisible(false)]
		[Browsable(false)]
		[XmlIgnore]
		[DCInternal]
		public bool WebClientSelected
		{
			get
			{
				bool flag = false;
				if (OwnerDocument != null && OwnerDocument.WebClientCurrentElement != null)
				{
					return OwnerDocument.WebClientCurrentElement == this;
				}
				return bool_8;
			}
			set
			{
				bool_8 = value;
			}
		}

		/// <summary>
		///       客户端单击执行的javascript脚本。当Options.BehaviorOptions.EnableExpression为false时，本属性无效。
		///       </summary>
		[DCPublishAPI]
		[HtmlAttribute]
		[DefaultValue(null)]
		public string JavaScriptForClick
		{
			get
			{
				return string_8;
			}
			set
			{
				string_8 = value;
			}
		}

		/// <summary>
		///       双击时执行的javascript脚本。当Options.BehaviorOptions.EnableExpression为false时，本属性无效。
		///       </summary>
		[DefaultValue(null)]
		[HtmlAttribute]
		[DCPublishAPI]
		public string JavaScriptForDoubleClick
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
		///       属性值表达式列表
		///       </summary>
		[XmlArrayItem("Item", typeof(PropertyExpressionInfo))]
		[DCPublishAPI]
		[DefaultValue(null)]
		[Browsable(true)]
		[ComVisible(true)]
		[Editor("DCSoft.Writer.Commands.PropertyExpressionInfoListUITypeEditor", typeof(UITypeEditor))]
		[HtmlAttribute]
		public PropertyExpressionInfoList PropertyExpressions
		{
			get
			{
				if (propertyExpressionInfoList_0 != null)
				{
					propertyExpressionInfoList_0.Owner = this;
				}
				return propertyExpressionInfoList_0;
			}
			set
			{
				propertyExpressionInfoList_0 = value;
			}
		}

		/// <summary>
		///       打印标记
		///       </summary>
		internal bool InnerPrintedFlag
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
		///       是否启用数值校验功能
		///       </summary>
		[HtmlAttribute]
		[DefaultValue(false)]
		[ComVisible(true)]
		[DCPublishAPI]
		public bool EnableValueValidate
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
		///       最后一次数据校验的结果
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		[DCPublishAPI]
		public ValueValidateResult LastValidateResult => valueValidateResult_0;

		/// <summary>
		///       数据验证样式
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(null)]
		[HtmlAttribute]
		public virtual ValueValidateStyle ValidateStyle
		{
			get
			{
				if (valueValidateStyle_0 == null && DocumentBehaviorOptions.StaticAutoCreateInstanceInProperty)
				{
					valueValidateStyle_0 = new ValueValidateStyle();
				}
				return valueValidateStyle_0;
			}
			set
			{
				valueValidateStyle_0 = value;
			}
		}

		/// <summary>
		///       运行时的是否支持内容校验功能
		///       </summary>
		internal virtual bool RuntimeSupportValidateStyle => XTextDocument.smethod_13(GEnum6.const_177);

		/// <summary>
		///       数据校验结果中使用的名称
		///       </summary>
		protected virtual string NameForValidateResult => base.ID;

		/// <summary>
		///       包含了未分页处理的分页符号
		///       </summary>
		[DCInternal]
		[Browsable(false)]
		internal virtual bool ContainsUnHandledPageBreak
		{
			get
			{
				return bool_11;
			}
			set
			{
				if (bool_11 != value)
				{
					bool_11 = value;
				}
			}
		}

		/// <summary>
		///       自动隐藏模式
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(ContainerAutoHideMode.None)]
		public ContainerAutoHideMode AutoHideMode
		{
			get
			{
				return containerAutoHideMode_0;
			}
			set
			{
				containerAutoHideMode_0 = value;
			}
		}

		/// <summary>
		///       元素内容是否改变
		///       </summary>
		[DCPublishAPI]
		[XmlIgnore]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(true)]
		[ComVisible(true)]
		[MemberExpressionable(MemberEffectLevel.DOM)]
		public override bool Modified
		{
			get
			{
				return bool_12;
			}
			set
			{
				if (bool_12 != value)
				{
					bool_12 = value;
				}
			}
		}

		/// <summary>
		///       是否具有内容元素
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		[DCInternal]
		public virtual bool HasContentElement => bool_13;

		/// <summary>
		///       是否具有数据源绑定信息对象实例
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		public bool HasValueBinding => xdataBinding_0 != null;

		/// <summary>
		///       内容绑定对象
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(null)]
		[Browsable(true)]
		[HtmlAttribute]
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
		///       运行时的是否支持数据源绑定功能
		///       </summary>
		internal virtual bool RuntimeSupportValueBinding => XTextDocument.smethod_13(GEnum6.const_179);

		/// <summary>
		///       数据源绑定时的默认值。当获得的数据源数据为空时在采用该默认值。
		///       </summary>
		[DefaultValue(null)]
		[ComVisible(true)]
		[Browsable(true)]
		[DCPublishAPI]
		[HtmlAttribute]
		public string DefaultValueForValueBinding
		{
			get
			{
				return string_10;
			}
			set
			{
				string_10 = value;
			}
		}

		/// <summary>
		///       绑定的数据源对象
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[ComVisible(false)]
		[DCInternal]
		[Browsable(true)]
		[XmlIgnore]
		[DefaultValue(null)]
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
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCInternal]
		[XmlIgnore]
		[ComVisible(false)]
		[Browsable(true)]
		[DefaultValue(false)]
		public bool DataBoundNodeValueUsed
		{
			get
			{
				return bool_14;
			}
			set
			{
				bool_14 = value;
			}
		}

		/// <summary>
		///       最后一次执行数据源绑定时的内容版本号
		///       </summary>
		[DCInternal]
		[Browsable(false)]
		public int DataBindingContentVersion => int_7;

		[XmlIgnore]
		[MemberExpressionable(MemberEffectLevel.DOM)]
		[Browsable(false)]
		[DCPublishAPI]
		public override string FormulaValue
		{
			get
			{
				return Text;
			}
			set
			{
				_ = (XTextInputFieldElement)Elements.method_5(typeof(XTextInputFieldElement));
				SetContainerTextArgs setContainerTextArgs = new SetContainerTextArgs();
				setContainerTextArgs.NewText = method_12(value);
				setContainerTextArgs.LogUndo = false;
				setContainerTextArgs.AccessFlags = DomAccessFlags.None;
				setContainerTextArgs.DisablePermission = true;
				setContainerTextArgs.EventSource = ContentChangedEventSource.Default;
				setContainerTextArgs.FocusContainer = false;
				setContainerTextArgs.IgnoreDisplayFormat = false;
				setContainerTextArgs.ShowUI = false;
				setContainerTextArgs.UpdateContent = true;
				SetEditorText(setContainerTextArgs);
			}
		}

		/// <summary>
		///       内容可编辑依赖的文档元素编号
		///       </summary>
		[DefaultValue(null)]
		[HtmlAttribute]
		[ComVisible(true)]
		[DCPublishAPI]
		public string ElementIDForEditableDependent
		{
			get
			{
				return string_11;
			}
			set
			{
				string_11 = value;
			}
		}

		/// <summary>
		///       元素内容只读性表达式。
		///       </summary>
		[DCPublishAPI]
		[ComVisible(true)]
		[DefaultValue(null)]
		[HtmlAttribute]
		public string ContentReadonlyExpression
		{
			get
			{
				int num = 13;
				if (PropertyExpressions == null)
				{
					return null;
				}
				return PropertyExpressions.GetValue("ContentReadonly");
			}
			set
			{
				int num = 16;
				if (PropertyExpressions == null)
				{
					PropertyExpressions = new PropertyExpressionInfoList();
				}
				PropertyExpressions.SetValue("ContentReadonly", value);
				if (OwnerDocument != null && OwnerDocument.ExpressionExecuter != null)
				{
					OwnerDocument.ExpressionExecuter.imethod_4(this);
				}
			}
		}

		/// <summary>
		///       元素可见性表达式
		///       </summary>
		[DefaultValue(null)]
		[HtmlAttribute]
		[DCPublishAPI]
		public string VisibleExpression
		{
			get
			{
				int num = 18;
				if (PropertyExpressions == null)
				{
					return null;
				}
				return PropertyExpressions.GetValue("Visible");
			}
			set
			{
				int num = 1;
				if (PropertyExpressions == null)
				{
					PropertyExpressions = new PropertyExpressionInfoList();
				}
				PropertyExpressions.SetValue("Visible", value);
			}
		}

		/// <summary>
		///       数值表达式
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(null)]
		public string ValueExpression
		{
			get
			{
				int num = 13;
				if (PropertyExpressions == null)
				{
					return null;
				}
				return PropertyExpressions.GetValue("FormulaValue");
			}
			set
			{
				int num = 18;
				if (PropertyExpressions == null)
				{
					PropertyExpressions = new PropertyExpressionInfoList();
				}
				PropertyExpressions.SetValue("FormulaValue", value);
			}
		}

		/// <summary>
		///       应用程序额外的数据，该数据不存储到文件中,也不参与二进制序列化
		///       </summary>
		[MemberExpressionable(MemberEffectLevel.DOM)]
		[Browsable(false)]
		[XmlIgnore]
		[DCPublishAPI]
		public object TagValue
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

		/// <summary>
		///       用户标记
		///       </summary>
		[ComVisible(true)]
		[MemberExpressionable(MemberEffectLevel.DOM)]
		[XmlElement]
		[DCPublishAPI]
		[DefaultValue(0)]
		[Browsable(false)]
		public int UserFlags
		{
			get
			{
				return int_8;
			}
			set
			{
				int_8 = value;
			}
		}

		/// <summary>
		///       容器内部是否启用授权控制
		///       </summary>
		[DefaultValue(DCBooleanValue.Inherit)]
		[MemberExpressionable(MemberEffectLevel.DOM)]
		[HtmlAttribute]
		[ComVisible(true)]
		[DCPublishAPI]
		public virtual DCBooleanValue EnablePermission
		{
			get
			{
				return dcbooleanValue_0;
			}
			set
			{
				dcbooleanValue_0 = value;
			}
		}

		/// <summary>
		///       运行时的内容是否启用授权控制
		///       </summary>
		[Browsable(false)]
		[DCInternal]
		public virtual bool RuntimeEnablePermission
		{
			get
			{
				XTextContainerElement xTextContainerElement = this;
				while (true)
				{
					if (xTextContainerElement != null)
					{
						if (xTextContainerElement.EnablePermission != 0)
						{
							if (xTextContainerElement.EnablePermission == DCBooleanValue.False)
							{
								break;
							}
							xTextContainerElement = xTextContainerElement.Parent;
							continue;
						}
						return true;
					}
					return OwnerDocument.Options.SecurityOptions.EnablePermission;
				}
				return false;
			}
		}

		/// <summary>
		///       内容锁
		///       </summary>
		[DefaultValue(null)]
		[XmlElement]
		[DCPublishAPI]
		[Browsable(true)]
		[HtmlAttribute]
		public DCContentLockInfo ContentLock
		{
			get
			{
				return dccontentLockInfo_0;
			}
			set
			{
				dccontentLockInfo_0 = value;
			}
		}

		/// <summary>
		///       判断当前内容是否被内容锁定机制而锁定
		///       </summary>
		private bool IsContentLocked
		{
			get
			{
				if (ContentLock != null && OwnerDocument != null)
				{
					if (!XTextDocument.smethod_13(GEnum6.const_135))
					{
						return false;
					}
					return !ContentLock.CheckCurrentUserAuthorize(OwnerDocument);
				}
				return false;
			}
		}

		/// <summary>
		///       内容是否只读
		///       </summary>
		[HtmlAttribute]
		[XmlElement]
		[DefaultValue(ContentReadonlyState.Inherit)]
		[Browsable(true)]
		[MemberExpressionable(MemberEffectLevel.DOM)]
		[DCPublishAPI]
		public virtual ContentReadonlyState ContentReadonly
		{
			get
			{
				return contentReadonlyState_0;
			}
			set
			{
				contentReadonlyState_0 = value;
			}
		}

		/// <summary>
		///       DCWriter内部使用。
		///       </summary>
		[DCInternal]
		[Obsolete("DCWriter内部使用，请勿调用。")]
		[ComVisible(false)]
		[Browsable(false)]
		[XmlIgnore]
		[DefaultValue(false)]
		[HtmlAttribute]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool InnerRuntimeContentReadonly
		{
			get
			{
				return RuntimeContentReadonly;
			}
			set
			{
			}
		}

		/// <summary>
		///       运行时的内容是否只读
		///       </summary>
		[ReadOnly(true)]
		[Browsable(false)]
		[DCInternal]
		public virtual bool RuntimeContentReadonly
		{
			get
			{
				ContentReadonlyState contentReadonly = ContentReadonly;
				if (contentReadonly == ContentReadonlyState.True)
				{
					return true;
				}
				if (IsContentLocked)
				{
					return true;
				}
				if (contentReadonly == ContentReadonlyState.Inherit)
				{
					XTextContainerElement parent = Parent;
					while (true)
					{
						if (parent != null)
						{
							ContentReadonlyState contentReadonly2 = parent.ContentReadonly;
							if (contentReadonly2 != 0)
							{
								if (!parent.IsContentLocked)
								{
									if (contentReadonly2 == ContentReadonlyState.False)
									{
										break;
									}
									parent = parent.Parent;
									continue;
								}
								return true;
							}
							return true;
						}
						return false;
					}
					return false;
				}
				return false;
			}
		}

		/// <summary>
		///       文档内容可用户直接编辑
		///       </summary>
		[Browsable(false)]
		public virtual bool ContentEditable => true;

		/// <summary>
		///       对象所属文档对象
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[ComVisible(true)]
		[Browsable(false)]
		[XmlIgnore]
		[DCPublishAPI]
		public override XTextDocument OwnerDocument
		{
			get
			{
				return base.OwnerDocument;
			}
			set
			{
				if (base.OwnerDocument != value)
				{
					base.OwnerDocument = value;
					foreach (XTextElement element in Elements)
					{
						element.OwnerDocument = value;
					}
				}
			}
		}

		/// <summary>
		///       表达式列表
		///       </summary>
		[XmlArrayItem("Expression", typeof(DomExpression))]
		[DCPublishAPI]
		[DefaultValue(null)]
		public virtual DomExpressionList Expressions
		{
			get
			{
				if (domExpressionList_0 == null && DocumentBehaviorOptions.StaticAutoCreateInstanceInProperty)
				{
					domExpressionList_0 = new DomExpressionList();
				}
				return domExpressionList_0;
			}
			set
			{
				domExpressionList_0 = value;
			}
		}

		/// <summary>
		///       脚本项目列表
		///       </summary>
		[XmlArrayItem("Item", typeof(VBScriptItem))]
		[DCPublishAPI]
		[DefaultValue(null)]
		public virtual VBScriptItemList ScriptItems
		{
			get
			{
				if (vbscriptItemList_0 == null && DocumentBehaviorOptions.StaticAutoCreateInstanceInProperty)
				{
					vbscriptItemList_0 = new VBScriptItemList();
				}
				return vbscriptItemList_0;
			}
			set
			{
				vbscriptItemList_0 = value;
			}
		}

		/// <summary>
		///       返回运行时使用的脚本信息对象列表
		///       </summary>
		[Browsable(false)]
		[DCInternal]
		[XmlIgnore]
		[ComVisible(false)]
		public override VBScriptItemList RuntimeScriptItems => vbscriptItemList_0;

		/// <summary>
		///       用户自定义属性列表
		///       </summary>
		[Browsable(true)]
		[DefaultValue(null)]
		[XmlArrayItem("Attribute", typeof(XAttribute))]
		[DCPublishAPI]
		[HtmlAttribute]
		public override XAttributeList Attributes
		{
			get
			{
				if (!XTextDocument.smethod_13(GEnum6.const_180))
				{
					return null;
				}
				if (xattributeList_0 == null)
				{
					xattributeList_0 = new XAttributeList();
				}
				if (WriterControl != null)
				{
					WriterControl.CollectOuterReferences(xattributeList_0);
				}
				return xattributeList_0;
			}
			set
			{
				xattributeList_0 = value;
			}
		}

		/// <summary>
		///       内容复制来源
		///       </summary>
		[DefaultValue(null)]
		[HtmlAttribute]
		[Browsable(true)]
		[DCPublishAPI]
		public virtual CopySourceInfo CopySource
		{
			get
			{
				return copySourceInfo_0;
			}
			set
			{
				copySourceInfo_0 = value;
			}
		}

		/// <summary>
		///       文档元素事件模板名称
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(null)]
		public string EventTemplateName
		{
			get
			{
				return string_13;
			}
			set
			{
				string_13 = value;
			}
		}

		/// <summary>
		///       内容创建器
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		[DCPublishAPI]
		[ComVisible(true)]
		public ContentBuilder ContentBuilder
		{
			get
			{
				if (contentBuilder_0 == null)
				{
					contentBuilder_0 = new ContentBuilder(this);
				}
				if (WriterControl != null)
				{
					WriterControl.CollectOuterReference(contentBuilder_0);
				}
				return contentBuilder_0;
			}
		}

		/// <summary>
		///       第一个子元素
		///       </summary>
		[ComVisible(true)]
		[DCPublishAPI]
		public virtual XTextElement FirstChild
		{
			get
			{
				if (Elements.Count > 0)
				{
					return Elements[0];
				}
				return null;
			}
		}

		/// <summary>
		///       最后一个子元素
		///       </summary>
		[ComVisible(true)]
		[DCPublishAPI]
		public virtual XTextElement LastChild
		{
			get
			{
				if (Elements.Count > 0)
				{
					return Elements[Elements.Count - 1];
				}
				return null;
			}
		}

		/// <summary>
		///       子元素列表
		///       </summary>
		[XmlIgnore]
		[DCPublishAPI]
		[Browsable(false)]
		public override XTextElementList Elements
		{
			get
			{
				return xtextElementList_0;
			}
			set
			{
				xtextElementList_0 = value;
				if (xtextElementList_0 != null)
				{
					xtextElementList_0.method_6(this);
					foreach (XTextElement item in xtextElementList_0)
					{
						item.Parent = this;
					}
				}
			}
		}

		/// <summary>
		///       子元素的个数
		///       </summary>
		[ComVisible(true)]
		[DCPublishAPI]
		public int ElementsCount
		{
			get
			{
				if (Elements != null)
				{
					return Elements.Count;
				}
				return 0;
			}
		}

		/// <summary>
		///       序列化元素的个数,DCWriter内部测试使用
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		[DCInternal]
		[DefaultValue(0)]
		public int ElementsForSerializeCount
		{
			get
			{
				if (int_9 == 0 && xtextElementList_1 != null)
				{
					return xtextElementList_1.Count;
				}
				return int_9;
			}
			set
			{
				int_9 = value;
			}
		}

		/// <summary>
		///       为XML序列化/反序列化的子元素列表
		///       </summary>
		[DCInternal]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[XmlArray("XElements", IsNullable = true)]
		[Browsable(false)]
		public virtual XTextElementList ElementsForSerialize
		{
			get
			{
				return xtextElementList_1;
			}
			set
			{
				xtextElementList_1 = value;
				if (xtextElementList_1 != null)
				{
					xtextElementList_1.method_6(this);
				}
			}
		}

		/// <summary>
		///       子孙元素中第一个显示在文档内容中的元素
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		public override XTextElement FirstContentElement
		{
			get
			{
				foreach (XTextElement item in xtextElementList_0)
				{
					if (item.RuntimeVisible)
					{
						if (item is XTextTableElement)
						{
							XTextTableElement xTextTableElement = (XTextTableElement)item;
							if (xTextTableElement.FirstCell != null)
							{
								return xTextTableElement.FirstCell.FirstContentElement;
							}
						}
						if (!(item is XTextContainerElement))
						{
							return item;
						}
						XTextContainerElement xTextContainerElement = (XTextContainerElement)item;
						XTextElement firstContentElement = xTextContainerElement.FirstContentElement;
						if (firstContentElement != null)
						{
							return firstContentElement;
						}
					}
				}
				return null;
			}
		}

		/// <summary>
		///       子孙元素中第一个显示在文档内容中的元素
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		public override XTextElement LastContentElement
		{
			get
			{
				int num = xtextElementList_0.Count - 1;
				XTextElement xTextElement;
				while (true)
				{
					if (num >= 0)
					{
						xTextElement = xtextElementList_0[num];
						if (xTextElement.RuntimeVisible)
						{
							if (xTextElement is XTextTableElement)
							{
								XTextTableElement xTextTableElement = (XTextTableElement)xTextElement;
								if (xTextTableElement.LastVisibleCell != null)
								{
									return xTextTableElement.LastVisibleCell.LastContentElement;
								}
								return null;
							}
							if (!(xTextElement is XTextContainerElement))
							{
								break;
							}
							XTextContainerElement xTextContainerElement = (XTextContainerElement)xTextElement;
							XTextElement lastContentElement = xTextContainerElement.LastContentElement;
							if (lastContentElement != null)
							{
								return lastContentElement;
							}
						}
						num--;
						continue;
					}
					return null;
				}
				return xTextElement;
			}
		}

		/// <summary>
		///       判断是否包含被用户选择的内容
		///       </summary>
		[Browsable(false)]
		[ComVisible(true)]
		[DCInternal]
		[DCPublishAPI]
		public override bool HasSelection
		{
			get
			{
				XTextElement firstContentElement = FirstContentElement;
				XTextElement lastContentElement = LastContentElement;
				XTextDocumentContentElement documentContentElement = base.DocumentContentElement;
				if (documentContentElement != null && documentContentElement.Selection != null)
				{
					int absStartIndex = documentContentElement.Selection.AbsStartIndex;
					int absEndIndex = documentContentElement.Selection.AbsEndIndex;
					if (firstContentElement.ViewIndex <= absEndIndex && lastContentElement.ViewIndex >= absStartIndex)
					{
						return true;
					}
				}
				return false;
			}
		}

		/// <summary>
		///       允许接收的子元素类型
		///       </summary>
		[Browsable(false)]
		[DCInternal]
		[XmlIgnore]
		public virtual ElementType RuntimeAcceptChildElementTypes => AcceptChildElementTypes2;

		/// <summary>
		///       能接收的子元素类型
		///       </summary>
		[ComVisible(true)]
		[DCPublishAPI]
		[XmlElement]
		[DefaultValue(ElementType.All)]
		public ElementType AcceptChildElementTypes2
		{
			get
			{
				return elementType_0;
			}
			set
			{
				elementType_0 = value;
			}
		}

		/// <summary>
		///       返回预览对象内容的字符串
		///       </summary>
		/// <returns>
		/// </returns>
		[Browsable(false)]
		[DCInternal]
		public virtual string PreviewString
		{
			get
			{
				int num = 12;
				StringBuilder stringBuilder = new StringBuilder();
				foreach (XTextElement element in Elements)
				{
					if (!(element is XTextParagraphFlagElement))
					{
						stringBuilder.Append(element.ToString());
						if (stringBuilder.Length > 20)
						{
							break;
						}
					}
				}
				return "Para:" + stringBuilder.ToString();
			}
		}

		/// <summary>
		///       容器元素中包含的所有的复选框元素列表
		///       </summary>
		[DCPublishAPI]
		[ComVisible(true)]
		[Browsable(false)]
		[XmlIgnore]
		public XTextElementList CheckBoxes => GetElementsByType(typeof(XTextCheckBoxElement));

		/// <summary>
		///       容器元素中包含的所有的单选框元素列表
		///       </summary>
		[DCPublishAPI]
		[XmlIgnore]
		[ComVisible(true)]
		[Browsable(false)]
		public XTextElementList RadioBoxes => GetElementsByType(typeof(XTextRadioBoxElement));

		/// <summary>
		///       判断元素是否获得输入焦点
		///       </summary>
		[Browsable(false)]
		public override bool Focused
		{
			get
			{
				XTextDocument ownerDocument = OwnerDocument;
				if (ownerDocument == null)
				{
					return false;
				}
				XTextDocumentContentElement documentContentElement = base.DocumentContentElement;
				if (documentContentElement == null)
				{
					return false;
				}
				if (ownerDocument.CurrentContentElement == documentContentElement)
				{
					if (documentContentElement == this)
					{
						return true;
					}
					XTextElement currentElement = documentContentElement.CurrentElement;
					XTextElement xTextElement = currentElement;
					if (this is XTextContentElement)
					{
						return xTextElement.IsParentOrSupParent(this);
					}
					XTextElement firstContentElementInPublicContent = FirstContentElementInPublicContent;
					while (xTextElement != null)
					{
						if (firstContentElementInPublicContent != xTextElement && xTextElement == this)
						{
							if (this is XTextFieldElementBase)
							{
								XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)this;
								if (currentElement == xTextFieldElementBase.StartElement)
								{
									xTextElement = xTextElement.Parent;
									continue;
								}
							}
							return true;
						}
						xTextElement = xTextElement.Parent;
					}
				}
				return false;
			}
		}

		/// <summary>
		///       返回文本内容，不包含被逻辑删除的部分。
		///       </summary>
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		[XmlIgnore]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(true)]
		[ReadOnly(true)]
		public override string Text
		{
			get
			{
				if (Elements == null || Elements.Count == 0)
				{
					return "";
				}
				StringBuilder stringBuilder = new StringBuilder();
				foreach (XTextElement element in Elements)
				{
					if (element.RuntimeVisible && (element.RuntimeStyle == null || element.RuntimeStyle.DeleterIndex < 0))
					{
						stringBuilder.Append(element.OuterText);
					}
				}
				return stringBuilder.ToString();
			}
			set
			{
				if ((string.IsNullOrEmpty(Text) && string.IsNullOrEmpty(value)) || Text == value)
				{
					return;
				}
				if (Parent == null)
				{
					SetInnerTextFast(value);
					return;
				}
				if (UIIsUpdating)
				{
					SetInnerTextFast(value);
				}
				if (OwnerDocument != null && OwnerDocument.ReadyState != DomReadyStates.Complete)
				{
					SetInnerTextFast(value);
					return;
				}
				if (string.IsNullOrEmpty(value))
				{
					GEventArgs4 gEventArgs = new GEventArgs4(this, 0, Elements.Count, null, bool_10: true, bool_11: true, bool_12: true);
					gEventArgs.method_31(bool_10: false);
					gEventArgs.method_23(bool_10: true);
					OwnerDocument.method_63(gEventArgs);
					return;
				}
				XTextElementList xTextElementList = OwnerDocument.CreateTextElements(value, null, RuntimeStyle.CloneWithoutBorder());
				if (xTextElementList != null && xTextElementList.Count > 0)
				{
					GEventArgs4 gEventArgs = new GEventArgs4(this, 0, Elements.Count, xTextElementList, bool_10: true, bool_11: true, bool_12: true);
					gEventArgs.method_29(DomAccessFlags.None);
					gEventArgs.method_31(bool_10: false);
					gEventArgs.method_23(bool_10: true);
					OwnerDocument.method_63(gEventArgs);
				}
			}
		}

		/// <summary>
		///       在编辑器中设置获得对象文本值,这个操作会被系统记录，能进行重复和撤销操作。
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public string EditorText
		{
			get
			{
				return Text;
			}
			set
			{
				SetEditorTextExt(value, DomAccessFlags.Normal, disablePermissioin: false, updateContent: true);
			}
		}

		/// <summary>
		///       在编辑器中设置/获得对象文本值,这个操作会被系统记录，能进行重复和撤销操作,而且不受用户界面层只读的限制。
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public string EditorTextExt
		{
			get
			{
				return Text;
			}
			set
			{
				SetEditorTextExt(value, DomAccessFlags.None, disablePermissioin: false, updateContent: true);
			}
		}

		/// <summary>
		///       打印时是否可见
		///       </summary>
		[XmlElement]
		[Browsable(true)]
		[DCPublishAPI]
		[MemberExpressionable(MemberEffectLevel.DOM)]
		[DefaultValue(ElementVisibility.Visible)]
		public virtual ElementVisibility PrintVisibility
		{
			get
			{
				return elementVisibility_0;
			}
			set
			{
				elementVisibility_0 = value;
			}
		}

		/// <summary>
		///        元素是否可见
		///       </summary>
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		[DefaultValue(true)]
		[Browsable(true)]
		[XmlElement]
		[DCPublishAPI]
		[HtmlAttribute]
		public override bool Visible
		{
			get
			{
				return bool_15;
			}
			set
			{
				bool_15 = value;
			}
		}

		/// <summary>
		///       元素占据排版位置，能参与文档内容排版。
		///       </summary>
		[Browsable(false)]
		[DCInternal]
		public override bool RuntimeLayoutable
		{
			get
			{
				XTextDocument ownerDocument = OwnerDocument;
				if (ownerDocument != null && ownerDocument.States.Printing && PrintVisibility == ElementVisibility.None)
				{
					return false;
				}
				return base.RuntimeLayoutable;
			}
		}

		/// <summary>
		///       文档元素能否被用户删除
		///       </summary>
		[MemberExpressionable(MemberEffectLevel.DOM)]
		[DefaultValue(true)]
		[HtmlAttribute]
		[DCPublishAPI]
		public bool Deleteable
		{
			get
			{
				return bool_16;
			}
			set
			{
				bool_16 = value;
			}
		}

		internal bool RuntimeDeleteable
		{
			get
			{
				if (XTextDocument.smethod_13(GEnum6.const_176))
				{
					return bool_16;
				}
				return true;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		[DCInternal]
		protected XTextContainerElement()
		{
			xtextElementList_0 = new XTextElementList();
			xtextElementList_0.method_6(this);
		}

		public override void vmethod_0(bool bool_17)
		{
			base.vmethod_0(bool_17);
			if (Elements != null)
			{
				Elements.method_0(bool_17);
			}
		}

		/// <summary>
		///       清空最后一次绘图结果信息
		///       </summary>
		[ComVisible(true)]
		[Browsable(false)]
		[DCPublishAPI]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void ClearLastRenderResult()
		{
			elementRenderResult_0 = null;
			if (xtextElementList_0 != null && xtextElementList_0.Count > 0)
			{
				foreach (XTextElement item in xtextElementList_0)
				{
					if (item is XTextContainerElement)
					{
						XTextContainerElement xTextContainerElement = (XTextContainerElement)item;
						xTextContainerElement.elementRenderResult_0 = null;
						xTextContainerElement.ClearLastRenderResult();
					}
				}
			}
		}

		/// <summary>
		///       收集所有的数据回填信息对象
		///       </summary>
		/// <param name="result">数据回填信息对象列表</param>
		/// <param name="checkContentVersion">是否检查版本号</param>
		[DCPublishAPI]
		[ComVisible(true)]
		public virtual void CollectDataFeedback(DataFeedbackInfoList result, bool checkContentVersion)
		{
			int num = 19;
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(this, bool_2: true);
			foreach (XTextElement item in domTreeNodeEnumerable)
			{
				if (item is XTextContainerElement)
				{
					XTextContainerElement xTextContainerElement = (XTextContainerElement)item;
					if (!xTextContainerElement.RuntimeContentReadonly)
					{
						DataFeedbackInfo dataFeedback = xTextContainerElement.DataFeedback;
						if (!(dataFeedback?.IsEmpty ?? true) && (!checkContentVersion || dataFeedback.ContentVersion != xTextContainerElement.ContentVersion))
						{
							dataFeedback.ContentVersion = xTextContainerElement.ContentVersion;
							dataFeedback.FieldValue = xTextContainerElement.InnerText;
							dataFeedback.Owner = xTextContainerElement;
							if (xTextContainerElement is XTextInputFieldElement)
							{
								XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)xTextContainerElement;
								if (!string.IsNullOrEmpty(xTextInputFieldElement.InnerValue))
								{
									dataFeedback.FieldValue = xTextInputFieldElement.InnerValue;
								}
							}
							result.Add(dataFeedback);
						}
					}
				}
				else if (item is XTextCheckBoxElementBase)
				{
					XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)item;
					if (!xTextCheckBoxElementBase.Readonly && (xTextCheckBoxElementBase.Parent == null || !xTextCheckBoxElementBase.Parent.RuntimeContentReadonly))
					{
						DataFeedbackInfo dataFeedback = xTextCheckBoxElementBase.DataFeedback;
						if (!(dataFeedback?.IsEmpty ?? true) && (!checkContentVersion || dataFeedback.ContentVersion != xTextCheckBoxElementBase.ContentVersion))
						{
							dataFeedback.ContentVersion = xTextCheckBoxElementBase.ContentVersion;
							if (xTextCheckBoxElementBase.Checked && !string.IsNullOrEmpty(xTextCheckBoxElementBase.CheckedValue))
							{
								dataFeedback.FieldValue = xTextCheckBoxElementBase.CheckedValue;
							}
							else
							{
								dataFeedback.FieldValue = xTextCheckBoxElementBase.Checked.ToString();
							}
							dataFeedback.Owner = xTextCheckBoxElementBase;
							result.Add(dataFeedback);
						}
					}
				}
			}
		}

		[DCInternal]
		public override PropertyExpressionInfoList GetRuntimePropertyExpressions()
		{
			PropertyExpressionInfoList propertyExpressionInfoList = PropertyExpressions;
			if (!string.IsNullOrEmpty(ContentReadonlyExpression))
			{
				propertyExpressionInfoList = ((propertyExpressionInfoList != null) ? propertyExpressionInfoList.CloneNotDeeply() : new PropertyExpressionInfoList());
				propertyExpressionInfoList.Owner = this;
			}
			return propertyExpressionInfoList;
		}

		[DCInternal]
		public virtual bool vmethod_23(bool bool_17)
		{
			if (valueValidateResult_0 != null)
			{
				valueValidateResult_0 = null;
				if (valueValidateStyle_0 != null)
				{
					valueValidateStyle_0.ContentVersion = base.ContentVersion;
				}
				if (!bool_17)
				{
					vmethod_25();
				}
				return true;
			}
			return false;
		}

		[DCPublishAPI]
		public virtual ValueValidateResult vmethod_24(bool bool_17)
		{
			int num = 15;
			XTextDocument ownerDocument = OwnerDocument;
			if (ownerDocument == null)
			{
				return null;
			}
			if (ownerDocument.Options.EditOptions.ValueValidateMode == DocumentValueValidateMode.None)
			{
				return null;
			}
			if (!EnableValueValidate)
			{
				return null;
			}
			if (ownerDocument.Options.BehaviorOptions.EnableElementEvents)
			{
				ElementValidatingEventArgs elementValidatingEventArgs = new ElementValidatingEventArgs(this);
				elementValidatingEventArgs.ResultState = ElementValidatingState.Pass;
				ownerDocument.method_30(elementValidatingEventArgs);
				if (!elementValidatingEventArgs.Handled)
				{
					ElementEventTemplateList events = Events;
					if (events != null && events.HasValidating)
					{
						events.OnValidating(this, elementValidatingEventArgs);
					}
				}
				if (elementValidatingEventArgs.Handled)
				{
					switch (elementValidatingEventArgs.ResultState)
					{
					case ElementValidatingState.Success:
						valueValidateResult_0 = null;
						if (!elementValidatingEventArgs.Cancel)
						{
							vmethod_25();
						}
						return null;
					case ElementValidatingState.Pass:
						if (!elementValidatingEventArgs.Cancel)
						{
							vmethod_25();
						}
						break;
					case ElementValidatingState.Fail:
						valueValidateResult_0 = new ValueValidateResult();
						valueValidateResult_0.Element = this;
						valueValidateResult_0.Type = ValueValidateResultTypes.ValueValidate;
						valueValidateResult_0.Level = elementValidatingEventArgs.ResultLevel;
						valueValidateResult_0.Message = elementValidatingEventArgs.Message;
						if (!elementValidatingEventArgs.Cancel)
						{
							vmethod_25();
						}
						InvalidateHighlightInfo();
						return valueValidateResult_0;
					}
				}
			}
			ValueValidateStyle valueValidateStyle = RuntimeSupportValidateStyle ? ValidateStyle : null;
			if (!(valueValidateStyle?.IsEmpty ?? true))
			{
				if (valueValidateStyle.ContentVersion == base.ContentVersion)
				{
					if (valueValidateResult_0 != null && valueValidateStyle != null && valueValidateStyle.RequiredInvalidateFlag)
					{
						InvalidateHighlightInfo();
					}
					vmethod_25();
					return valueValidateResult_0;
				}
				valueValidateStyle.ContentVersion = base.ContentVersion;
				valueValidateStyle.Value = Text;
				if (valueValidateStyle.method_1())
				{
					valueValidateResult_0 = null;
				}
				else
				{
					valueValidateResult_0 = new ValueValidateResult();
					valueValidateResult_0.Element = this;
					valueValidateResult_0.Level = valueValidateStyle.Level;
					string text = NameForValidateResult;
					if (string.IsNullOrEmpty(text))
					{
						text = base.ID;
					}
					if (valueValidateStyle != null && !string.IsNullOrEmpty(valueValidateStyle.CustomMessage))
					{
						valueValidateResult_0.Message = valueValidateStyle.CustomMessage;
					}
					else if (string.IsNullOrEmpty(text))
					{
						valueValidateResult_0.Message = valueValidateStyle.Message;
					}
					else
					{
						valueValidateResult_0.Message = text + ":" + valueValidateStyle.Message;
					}
					valueValidateResult_0.Type = ValueValidateResultTypes.ValueValidate;
				}
				if (!bool_17)
				{
					InvalidateView();
				}
			}
			else
			{
				valueValidateResult_0 = null;
			}
			if (valueValidateResult_0 == null)
			{
				string text2 = ownerDocument.method_80(this);
				if (!string.IsNullOrEmpty(text2))
				{
					valueValidateResult_0 = new ValueValidateResult();
					valueValidateResult_0.Message = text2;
					valueValidateResult_0.Level = ValueValidateLevel.Warring;
					valueValidateResult_0.Type = ValueValidateResultTypes.ValueValidate;
					valueValidateResult_0.Element = this;
					if (!bool_17)
					{
						InvalidateView();
					}
				}
			}
			if (ownerDocument.Options.BehaviorOptions.DebugMode && valueValidateResult_0 != null && !string.IsNullOrEmpty(valueValidateResult_0.Message))
			{
				string text2 = string.Format(WriterStringsCore.ValueInvalidate_Source_Value_Result, ToDebugString(), Text, valueValidateResult_0.Message);
				Debug.WriteLine(text2);
			}
			vmethod_25();
			InvalidateHighlightInfo();
			return valueValidateResult_0;
		}

		[DCInternal]
		public override HighlightInfoList vmethod_20()
		{
			if (EnableValueValidate && valueValidateResult_0 != null)
			{
				Color fieldInvalidateValueBackColor = OwnerDocument.Options.ViewOptions.FieldInvalidateValueBackColor;
				Color fieldInvalidateValueForeColor = OwnerDocument.Options.ViewOptions.FieldInvalidateValueForeColor;
				if ((fieldInvalidateValueBackColor.A != 0 || fieldInvalidateValueForeColor.A != 0) && base.DocumentContentElement != null && FirstContentElement != null && LastContentElement != null)
				{
					HighlightInfo highlightInfo = new HighlightInfo(new XTextRange(base.DocumentContentElement, FirstContentElement, LastContentElement), fieldInvalidateValueBackColor, fieldInvalidateValueForeColor);
					highlightInfo.ActiveStyle = HighlightActiveStyle.Static;
					highlightInfo.OwnerElement = this;
					HighlightInfoList highlightInfoList = new HighlightInfoList();
					highlightInfoList.Add(highlightInfo);
					return highlightInfoList;
				}
			}
			return null;
		}

		[DCInternal]
		public override GClass96 GetToolTipInfo()
		{
			if (LastValidateResult != null)
			{
				GClass96 gClass = new GClass96(this, LastValidateResult.Message);
				gClass.method_12(ToolTipContentType.ValidateResult);
				gClass.method_10(GEnum5.const_1);
				return gClass;
			}
			if (!string.IsNullOrEmpty(RuntimeToolTip))
			{
				GClass96 gClass2 = new GClass96(this, RuntimeToolTip);
				gClass2.method_12(ToolTipContentType.ElementToolTip);
				return gClass2;
			}
			return base.GetToolTipInfo();
		}

		[DCInternal]
		public virtual void vmethod_25()
		{
			if (valueValidateResult_0 == null)
			{
				OwnerDocument.method_100(this);
			}
			if (OwnerDocument.Options.BehaviorOptions.EnableElementEvents)
			{
				ElementEventArgs elementEventArgs = new ElementEventArgs(this);
				if (WriterControl != null)
				{
					WriterControl.GlobalElementEventMan.method_29(this, elementEventArgs);
				}
				ElementEventTemplateList events = Events;
				if (events != null && events.HasValidated)
				{
					events.OnValidated(this, elementEventArgs);
				}
			}
		}

		[DCInternal]
		protected void method_13(ContentChangedEventArgs contentChangedEventArgs_0)
		{
			bool flag = false;
			DocumentValueValidateMode valueValidateMode = OwnerDocument.Options.EditOptions.ValueValidateMode;
			if (valueValidateMode == DocumentValueValidateMode.Dynamic)
			{
				flag = true;
			}
			else if (contentChangedEventArgs_0.UndoRedoCause && valueValidateMode == DocumentValueValidateMode.LostFocus)
			{
				flag = true;
			}
			if (RuntimeSupportValidateStyle)
			{
				ValueValidateStyle validateStyle = ValidateStyle;
				if (validateStyle != null && validateStyle.Required && validateStyle.RequiredInvalidateFlag && LastValidateResult != null)
				{
					flag = true;
				}
			}
			if (flag)
			{
				vmethod_24(contentChangedEventArgs_0.LoadingDocument);
			}
		}

		/// <summary>
		///       提交所有用户的修改记录。删除被逻辑删除的内容，清除用户修改痕迹。
		///       </summary>
		/// <returns>操作是否修改了文档内容</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public virtual bool CommitUserTrace()
		{
			bool result = false;
			XTextDocument ownerDocument = OwnerDocument;
			for (int num = Elements.Count - 1; num >= 0; num--)
			{
				XTextElement xTextElement = Elements[num];
				DocumentContentStyle parent = xTextElement.RuntimeStyle.Parent;
				if (parent.DeleterIndex >= 0)
				{
					Elements.RemoveAt(num);
					result = true;
				}
				else if (parent.CreatorIndex >= 0)
				{
					DocumentContentStyle documentContentStyle = (DocumentContentStyle)parent.Clone();
					documentContentStyle.DeleterIndex = -1;
					xTextElement.StyleIndex = ownerDocument.ContentStyles.GetStyleIndex(documentContentStyle);
					result = true;
				}
				if (xTextElement is XTextContainerElement)
				{
					XTextContainerElement xTextContainerElement = (XTextContainerElement)xTextElement;
					if (xTextContainerElement.CommitUserTrace())
					{
						result = true;
					}
				}
			}
			if (ownerDocument.UndoList != null)
			{
				ownerDocument.UndoList.Clear();
			}
			return result;
		}

		[DCInternal]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("已经不推荐使用了，跪求使用UpdateDataBindingSpecifyDataSource()")]
		public int method_14(bool bool_17)
		{
			UpdateDataBindingArgs updateDataBindingArgs = new UpdateDataBindingArgs();
			updateDataBindingArgs.DataNode = DataBoundNode;
			updateDataBindingArgs.FastMode = bool_17;
			return UpdateDataBindingExt(updateDataBindingArgs);
		}

		/// <summary>
		///       !!!!已过时，请使用UpdateDataBindingExt(UpdateDataBindingArgs args)!!
		///       </summary>
		/// <param name="dataSource">绑定的数据源对象</param>
		/// <param name="fastMode">快速模式</param>
		/// <returns>操作是否导致了文档内容发生改变的处数</returns>
		[DCInternal]
		[Obsolete("!!!!已过时，请使用UpdateDataBindingExt(UpdateDataBindingArgs args)!!")]
		public virtual int UpdateDataBindingSpecifyDataSource(object dataSource, bool fastMode)
		{
			UpdateDataBindingArgs args = new UpdateDataBindingArgs(dataSource, fastMode);
			return UpdateDataBindingExt(args);
		}

		internal DataSourceTreeNode method_15()
		{
			if (RuntimeSupportValueBinding)
			{
				return method_2(ValueBinding, null);
			}
			return null;
		}

		/// <summary>
		///       更新数据源
		///       </summary>
		/// <param name="dataSource">绑定的数据源对象</param>
		/// <param name="fastMode">快速模式</param>
		/// <returns>操作是否导致了文档内容发生改变的处数</returns>
		[DCInternal]
		public virtual int UpdateDataBindingExt(UpdateDataBindingArgs args)
		{
			int num = 9;
			DataBoundNodeValueUsed = false;
			if (args == null)
			{
				throw new ArgumentNullException("args");
			}
			if (!OwnerDocument.Options.BehaviorOptions.EnableDataBinding)
			{
				return 0;
			}
			XDataBinding xDataBinding = RuntimeSupportValueBinding ? ValueBinding : null;
			DataSourceTreeNode dataSourceTreeNode = null;
			if (OwnerDocument.method_104(xDataBinding))
			{
				dataSourceTreeNode = method_2(xDataBinding, args);
			}
			if (!args.DetectValueModified)
			{
				DataBoundNode = dataSourceTreeNode;
			}
			int num2 = 0;
			foreach (XTextElement element in Elements)
			{
				if (element is IUpdateDataBindingExt)
				{
					int num3 = ((IUpdateDataBindingExt)element).UpdateDataBindingExt(args);
					num2 += num3;
				}
			}
			if (args.DetectValueModified)
			{
				if (dataSourceTreeNode != null)
				{
					object obj = dataSourceTreeNode.RuntimeDisplayValue;
					if (obj == null || DBNull.Value.Equals(obj))
					{
						obj = null;
					}
					string text = (obj == null) ? null : Convert.ToString(obj);
					string text2 = Text;
					if (string.IsNullOrEmpty(text2))
					{
						text2 = null;
					}
					if (!string.Equals(text, text2))
					{
						DetectResultForValueBindingModified item = new DetectResultForValueBindingModified(ValueBinding, this, text2, text);
						args.AddDetectResult(item);
					}
				}
				return 0;
			}
			if (num2 == 0 && dataSourceTreeNode != null)
			{
				object runtimeDisplayValue = dataSourceTreeNode.RuntimeDisplayValue;
				if (runtimeDisplayValue == null || DBNull.Value.Equals(runtimeDisplayValue))
				{
					if (vmethod_26(null, args.FastMode))
					{
						if (dataFeedbackInfo_0 != null && !dataFeedbackInfo_0.IsEmpty)
						{
							dataFeedbackInfo_0.ContentVersion = base.ContentVersion;
						}
						num2 = 1;
						DataBoundNodeValueUsed = true;
					}
				}
				else if (vmethod_26(Convert.ToString(runtimeDisplayValue), args.FastMode))
				{
					if (dataFeedbackInfo_0 != null && !dataFeedbackInfo_0.IsEmpty)
					{
						dataFeedbackInfo_0.ContentVersion = base.ContentVersion;
					}
					num2 = 1;
					DataBoundNodeValueUsed = true;
				}
				args.AddHandledElement(this);
			}
			if (DataFeedback != null)
			{
				if (!DataFeedback.IsEmpty && !DataFeedback.IsEmpty && !string.IsNullOrEmpty(DataFeedback.KeyFeildDataSourcePath))
				{
					DataSourceTreeNode dataSourceTreeNode2 = method_2(xDataBinding, args, DataFeedback.KeyFeildDataSourcePath);
					if (dataSourceTreeNode2 != null)
					{
						DataFeedback.KeyFieldValue = Convert.ToString(dataSourceTreeNode2.RuntimeDisplayValue);
					}
				}
				DataFeedback.ContentVersion = base.ContentVersion;
			}
			if (xDataBinding != null && xDataBinding.ProcessState == DCProcessStates.Once)
			{
				xDataBinding.ProcessState = DCProcessStates.Never;
			}
			if (xDataBinding != null)
			{
				xDataBinding.Handled = true;
			}
			return num2;
		}

		[DCInternal]
		protected virtual bool vmethod_26(string string_14, bool bool_17)
		{
			if (string.IsNullOrEmpty(string_14))
			{
				string_14 = DefaultValueForValueBinding;
			}
			if (bool_17 || Parent == null)
			{
				XTextElementList xTextElementList = SetInnerTextFastExt(string_14, null, updateContentElements: false);
				if (xTextElementList != null && xTextElementList.Count > 0)
				{
					foreach (XTextElement item in xTextElementList)
					{
						DocumentContentStyle documentContentStyle = item.RuntimeStyle.CloneParent();
						documentContentStyle.CreatorIndex = -1;
						documentContentStyle.DeleterIndex = -1;
						item.StyleIndex = OwnerDocument.ContentStyles.GetStyleIndex(documentContentStyle);
					}
				}
			}
			else
			{
				SetEditorTextExt(string_14, DomAccessFlags.None, disablePermissioin: true, updateContent: true);
			}
			int_7 = base.ContentVersion;
			return true;
		}

		/// <summary>
		///       使用当前用户信息锁定文档元素内容
		///       </summary>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public bool SetContentLockByCurrentUser()
		{
			string text = null;
			if (OwnerDocument.CurrentUser != null)
			{
				text = OwnerDocument.CurrentUser.ID;
			}
			if (string.IsNullOrEmpty(text))
			{
				return false;
			}
			DCContentLockInfo dCContentLockInfo = new DCContentLockInfo();
			dCContentLockInfo.OwnerUserID = text;
			dCContentLockInfo.CreationTime = OwnerDocument.GetNowDateTime();
			ContentLock = dCContentLockInfo;
			return true;
		}

		/// <summary>
		///       锁定文档元素的内容
		///       </summary>
		/// <param name="userID">锁定操作的用户ID</param>
		/// <param name="authoriseUserIDList">授权操作的用户ID列表，各个列表之间用英文逗号分开</param>
		/// <param name="logUndo">是否记录撤销操作信息</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public bool SetContentLock(string userID, string authoriseUserIDList, bool logUndo)
		{
			int num = 19;
			DCContentLockInfo dCContentLockInfo = new DCContentLockInfo();
			dCContentLockInfo.OwnerUserID = userID;
			dCContentLockInfo.AuthorisedUserIDList = authoriseUserIDList;
			dCContentLockInfo.CreationTime = OwnerDocument.GetNowDateTime();
			if (logUndo)
			{
				if (OwnerDocument.CanLogUndo)
				{
					OwnerDocument.UndoList.AddProperty("ContentLock", ContentLock, dCContentLockInfo, this);
				}
				else if (OwnerDocument.BeginLogUndo())
				{
					OwnerDocument.UndoList.AddProperty("ContentLock", ContentLock, dCContentLockInfo, this);
					OwnerDocument.EndLogUndo();
				}
			}
			ContentLock = dCContentLockInfo;
			return true;
		}

		[DCInternal]
		public virtual bool vmethod_27(GClass108 gclass108_0, int int_10)
		{
			if (OwnerDocument != null && OwnerDocument.EditorControl != null)
			{
				OwnerDocument.EditorControl.method_61(this, gclass108_0, int_10);
			}
			bool flag = false;
			XTextDocument ownerDocument = OwnerDocument;
			DocumentControler documentControler = ownerDocument.DocumentControler;
			XTextElementList elements = Elements;
			int num = elements.Count - 1;
			if (this is XTextContentElement)
			{
				num--;
			}
			for (int i = 0; i <= num; i++)
			{
				XTextElement xTextElement = elements[i];
				if (!documentControler.CanDelete(xTextElement, DomAccessFlags.CheckControlReadonly | DomAccessFlags.CheckReadonly | DomAccessFlags.CheckPermission | DomAccessFlags.CheckFormView | DomAccessFlags.CheckLock | DomAccessFlags.CheckContentProtect | DomAccessFlags.CheckContainerReadonly))
				{
					documentControler.method_23(gclass108_0);
					flag = true;
					if (gclass108_0 == null)
					{
						break;
					}
					if (int_10 == 0 || int_10 < gclass108_0.Count)
					{
						documentControler.method_23(gclass108_0);
					}
				}
				if (!(xTextElement is XTextContainerElement))
				{
					continue;
				}
				if (((XTextContainerElement)xTextElement).vmethod_27(gclass108_0, int_10))
				{
					flag = true;
					if (gclass108_0 == null && flag)
					{
						break;
					}
				}
				if (int_10 > 0 && gclass108_0.Count >= int_10)
				{
					break;
				}
			}
			return flag;
		}

		[DCInternal]
		public virtual RuntimeDocumentContentStyle vmethod_28(XTextElement xtextElement_0)
		{
			RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
			if (runtimeStyle != null && runtimeStyle.HasVisibleBackground)
			{
				return runtimeStyle;
			}
			return null;
		}

		/// <summary>
		///       获得指定名称的属性值
		///       </summary>
		/// <param name="name">属性名</param>
		/// <returns>获得的属性值</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public override string GetAttribute(string name)
		{
			if (!XTextDocument.smethod_13(GEnum6.const_180))
			{
				return null;
			}
			if (xattributeList_0 != null)
			{
				return xattributeList_0.GetValue(name);
			}
			return null;
		}

		/// <summary>
		///       设置属性值
		///       </summary>
		/// <param name="name">属性名</param>
		/// <param name="Value">属性值</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public override bool SetAttribute(string name, string Value)
		{
			if (!XTextDocument.smethod_13(GEnum6.const_180))
			{
				return false;
			}
			if (xattributeList_0 == null)
			{
				xattributeList_0 = new XAttributeList();
			}
			xattributeList_0.SetValue(name, Value);
			return true;
		}

		/// <summary>
		///       判断是否存在指定名称的属性
		///       </summary>
		/// <param name="name">属性名</param>
		/// <returns>是否存在</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public override bool HasAttribute(string name)
		{
			if (!XTextDocument.smethod_13(GEnum6.const_180))
			{
				return false;
			}
			if (xattributeList_0 != null)
			{
				return xattributeList_0.ContainsByName(name);
			}
			return false;
		}

		protected void method_16()
		{
			if (xattributeList_0 != null)
			{
				xattributeList_0.Clear();
			}
		}

		/// <summary>
		///       创建新的文档对象，使其包含本文档元素的复制品
		///       </summary>
		/// <param name="includeThis">是否包含本文档原始对象</param>
		/// <remarks>
		///       如果选项SecurityOptions.EnablePermission=true，则创建的文档对象包含被逻辑删除的内容及历史痕迹记录。
		///       如果该选项为false，则没有任何痕迹信息，而且被标记为逻辑删除的内容会还原出来。
		///       </remarks>
		/// <returns>创建的文档对象</returns>
		[DCPublishAPI]
		public override XTextDocument CreateContentDocument(bool includeThis)
		{
			XTextElementList xTextElementList = new XTextElementList();
			if (includeThis)
			{
				xTextElementList.Add(this);
			}
			else
			{
				xTextElementList.AddRange(Elements);
			}
			return WriterUtils.smethod_32(OwnerDocument, xTextElementList, bool_2: true);
		}

		/// <summary>
		///       获得所有的文档元素对象,包括自己
		///       </summary>
		/// <returns>元素列表</returns>
		[DCPublishAPI]
		[DCInternal]
		[ComVisible(true)]
		public virtual XTextElementList GetAllElements()
		{
			XTextElementList xTextElementList = new XTextElementList();
			method_17(this, xTextElementList, bool_17: true);
			return xTextElementList;
		}

		/// <summary>
		///       获得所有的文档元素对象,包括自己,但不包括任何字符元素
		///       </summary>
		/// <returns>元素列表</returns>
		[DCInternal]
		[ComVisible(true)]
		[DCPublishAPI]
		public virtual XTextElementList GetAllElementsWithoutCharElement()
		{
			XTextElementList xTextElementList = new XTextElementList();
			method_17(this, xTextElementList, bool_17: false);
			return xTextElementList;
		}

		private void method_17(XTextElement xtextElement_0, XTextElementList xtextElementList_2, bool bool_17)
		{
			xtextElementList_2.Add(xtextElement_0);
			if (xtextElement_0.Elements != null)
			{
				foreach (XTextElement element in xtextElement_0.Elements)
				{
					if (bool_17 || !(element is XTextCharElement))
					{
						method_17(element, xtextElementList_2, bool_17);
					}
				}
			}
		}

		[DCInternal]
		internal virtual void vmethod_29(XTextElementList xtextElementList_2)
		{
		}

		[DCInternal]
		public override void vmethod_21(string string_14)
		{
			int num = 13;
			if (propertyExpressionInfoList_0 != null && propertyExpressionInfoList_0.Count == 0)
			{
				propertyExpressionInfoList_0 = null;
			}
			if (string.IsNullOrEmpty(string_14) || string.Compare(string_14, "xml", ignoreCase: true) == 0)
			{
				xtextElementList_1 = WriterUtils.smethod_60(Elements, bool_2: false);
				int_9 = 0;
			}
			foreach (XTextElement element in Elements)
			{
				if (!(element is XTextCharElement))
				{
					element.vmethod_21(string_14);
				}
			}
		}

		[DCInternal]
		public override void vmethod_22()
		{
			xtextElementList_1 = null;
			foreach (XTextElement element in Elements)
			{
				element.vmethod_22();
			}
			base.vmethod_22();
		}

		/// <summary>
		///       文档加载后的处理
		///       </summary>
		/// <param name="args">参数</param>
		[DCInternal]
		public override void AfterLoad(ElementLoadEventArgs args)
		{
			if (propertyExpressionInfoList_0 != null && propertyExpressionInfoList_0.Count == 0)
			{
				propertyExpressionInfoList_0 = null;
			}
			if (vbscriptItemList_0 != null && vbscriptItemList_0.Count == 0)
			{
				vbscriptItemList_0 = null;
			}
			if (domExpressionList_0 != null && domExpressionList_0.Count == 0)
			{
				domExpressionList_0 = null;
			}
			if (!method_18(bool_17: false))
			{
			}
			WriterUtils.smethod_62(Elements, bool_2: false);
			if (this is XTextContentElement)
			{
				((XTextContentElement)this).FixElements();
			}
			XTextDocument elementOwnerDocument = base.ElementOwnerDocument;
			foreach (XTextElement element in Elements)
			{
				element.SetParentRaw(this);
				element.method_5(elementOwnerDocument);
				args.Element = this;
				if (!(element is XTextCharElement))
				{
					element.AfterLoad(args);
				}
			}
			args.Element = this;
			base.AfterLoad(args);
			if (args.UpdateExpression)
			{
				XTextDocument ownerDocument = OwnerDocument;
				if (ownerDocument != null && ownerDocument.ExpressionExecuter != null)
				{
					ownerDocument.ExpressionExecuter.imethod_4(this);
				}
			}
		}

		[DCInternal]
		internal bool method_18(bool bool_17)
		{
			int num = 12;
			if (xtextElementList_1 != null && xtextElementList_1.Count > 0)
			{
				if (int_9 > 0 && int_9 != xtextElementList_1.Count)
				{
					XTextDocument ownerDocument = OwnerDocument;
					if (ownerDocument != null && ownerDocument.Options.BehaviorOptions.WeakMode)
					{
						throw new Exception("保存的元素个数不匹配,标记为" + int_9 + "个，实际为" + xtextElementList_1.Count + "个");
					}
				}
				xtextElementList_0.Clear();
				foreach (XTextElement item in xtextElementList_1)
				{
					if (item is XTextParagraphElement)
					{
						xtextElementList_0.AddRange(item.Elements);
					}
					else
					{
						xtextElementList_0.AddRaw(item);
					}
				}
				xtextElementList_1.Clear();
				xtextElementList_1 = null;
				if (bool_17)
				{
					foreach (XTextElement item2 in xtextElementList_0)
					{
						if (item2 is XTextContainerElement)
						{
							((XTextContainerElement)item2).method_18(bool_17);
						}
					}
				}
				return true;
			}
			return false;
		}

		/// <summary>
		///       对整个内容执行重新排版操作
		///       </summary>
		[DCInternal]
		[DCPublishAPI]
		public virtual void ExecuteLayout()
		{
		}

		/// <summary>
		///       插入子元素
		///       </summary>
		/// <param name="index">指定的序号</param>
		/// <param name="element">新添加的元素</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		public virtual bool InsertChildElement(int index, XTextElement element)
		{
			if (element != null)
			{
				element.method_6(this);
				if (!xtextElementList_0.Contains(element))
				{
					xtextElementList_0.method_13(index, element);
				}
				return true;
			}
			return false;
		}

		/// <summary>
		///       在指定的子元素之前插入新的子元素
		///       </summary>
		/// <param name="newElement">新元素</param>
		/// <param name="oldElement">已有的子元素</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public bool InsertBefore(XTextElement newElement, XTextElement oldElement)
		{
			int num = 3;
			if (newElement == null)
			{
				throw new ArgumentNullException("newElement");
			}
			int num2 = 0;
			if (oldElement == null)
			{
				num2 = 0;
			}
			else
			{
				num2 = Elements.IndexOf(oldElement);
				if (num2 < 0)
				{
					num2 = 0;
				}
			}
			return InsertChildElement(num2, newElement);
		}

		/// <summary>
		///       在指定的子元素之后插入新的子元素
		///       </summary>
		/// <param name="newElement">新元素</param>
		/// <param name="oldElement">已有的子元素</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public bool InsertAfter(XTextElement newElement, XTextElement oldElement)
		{
			int num = 3;
			if (newElement == null)
			{
				throw new ArgumentNullException("newElement");
			}
			int count = Elements.Count;
			if (oldElement == null)
			{
				count = Elements.Count;
			}
			else
			{
				count = Elements.IndexOf(oldElement);
				count = ((count >= 0) ? (count + 1) : Elements.Count);
			}
			return InsertChildElement(count, newElement);
		}

		/// <summary>
		///       添加子元素
		///       </summary>
		/// <param name="element">新添加的元素</param>
		/// <returns>操作是否成功</returns>
		[DCInternal]
		[ComVisible(true)]
		[DCPublishAPI]
		public virtual bool AppendChildElement(XTextElement element)
		{
			if (element is XTextDocument)
			{
				XTextDocument xTextDocument = (XTextDocument)element;
				foreach (XTextElement element2 in xTextDocument.Body.Elements)
				{
					element2.OwnerDocument = OwnerDocument;
					element2.Parent = this;
					xtextElementList_0.Add(element2);
				}
				return true;
			}
			if (element != null)
			{
				if (element.Parent != null && element.Parent != this)
				{
					XTextContainerElement parent = element.Parent;
					if (parent.Elements.Contains(element))
					{
						parent.Elements.Remove(element);
					}
				}
				if (!xtextElementList_0.Contains(element))
				{
					xtextElementList_0.Add(element);
				}
				element.SetParentRaw(this);
				if (element is XTextContainerElement)
				{
					element.OwnerDocument = OwnerDocument;
				}
				else
				{
					element.method_5(OwnerDocument);
				}
				return true;
			}
			return false;
		}

		/// <summary>
		///       删除子元素
		///       </summary>
		/// <param name="element">要删除的子元素</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		public virtual bool RemoveChild(XTextElement element)
		{
			if (element != null)
			{
				xtextElementList_0.Remove(element);
				element.SetParentRaw(null);
				return true;
			}
			return false;
		}

		[ComVisible(false)]
		[DCInternal]
		public virtual bool vmethod_30()
		{
			if (Parent != null && !Parent.RuntimeVisible)
			{
				return false;
			}
			XTextDocument ownerDocument = OwnerDocument;
			if (ownerDocument == null)
			{
				return Visible;
			}
			if (!(ownerDocument?.Options.BehaviorOptions.DesignMode ?? true) && !ownerDocument.IsVisible(this))
			{
				return false;
			}
			if (!Visible)
			{
				return false;
			}
			if (ownerDocument != null && ownerDocument.States.Printing && PrintVisibility != 0)
			{
				return false;
			}
			return true;
		}

		[DCInternal]
		public virtual void vmethod_31(bool bool_17)
		{
			XTextDocument ownerDocument = OwnerDocument;
			RuntimeVisible = vmethod_30();
			if (RuntimeVisible)
			{
				bool showLogicDeletedContent = OwnerDocument.Options.SecurityOptions.ShowLogicDeletedContent;
				foreach (XTextElement element in Elements)
				{
					if (element is XTextContainerElement)
					{
						XTextContainerElement xTextContainerElement = (XTextContainerElement)element;
						if (bool_17)
						{
							xTextContainerElement.vmethod_31(bool_17);
						}
						else
						{
							xTextContainerElement.RuntimeVisible = xTextContainerElement.vmethod_30();
						}
					}
					else if (ownerDocument == null)
					{
						element.RuntimeVisible = element.Visible;
					}
					else
					{
						element.RuntimeVisible = (element.Visible && ownerDocument.IsVisible(element, showLogicDeletedContent));
					}
				}
			}
			else if (bool_17)
			{
				foreach (XTextElement element2 in Elements)
				{
					element2.RuntimeVisible = false;
					if (element2 is XTextContainerElement)
					{
						((XTextContainerElement)element2).vmethod_31(bool_17: true);
					}
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DCInternal]
		public virtual int vmethod_32(XTextElementList xtextElementList_2, bool bool_17)
		{
			int num = 0;
			foreach (XTextElement element in Elements)
			{
				if (element is XTextCharElement || element is XTextParagraphFlagElement)
				{
					if (element.RuntimeVisible)
					{
						xtextElementList_2.AddRaw(element);
						num++;
					}
					else if (this is XTextContentElement && Elements.LastElement == element)
					{
						xtextElementList_2.AddRaw(element);
						num++;
					}
				}
				else if (element.RuntimeLayoutable)
				{
					if (element is XTextTableElement)
					{
						if (bool_17)
						{
							xtextElementList_2.AddRaw(element);
							num++;
						}
						else
						{
							XTextTableElement xTextTableElement = (XTextTableElement)element;
							foreach (XTextTableRowElement row in xTextTableElement.Rows)
							{
								if (row.RuntimeVisible)
								{
									foreach (XTextTableCellElement cell in row.Cells)
									{
										if (cell.RuntimeVisible)
										{
											num += cell.vmethod_32(xtextElementList_2, bool_17);
										}
									}
								}
							}
						}
					}
					else if (element is XTextSectionElement)
					{
						XTextSectionElement xTextSectionElement = (XTextSectionElement)element;
						if (xTextSectionElement.RuntimeEnableCollapse && xTextSectionElement.IsCollapsed)
						{
							xtextElementList_2.AddRaw(element);
							num++;
						}
						else if (bool_17)
						{
							xtextElementList_2.AddRaw(element);
							num++;
						}
						else
						{
							((XTextSectionElement)element).vmethod_32(xtextElementList_2, bool_17);
						}
					}
					else if (element is XTextContainerElement)
					{
						XTextContainerElement xTextContainerElement = (XTextContainerElement)element;
						num += xTextContainerElement.vmethod_32(xtextElementList_2, bool_17);
					}
					else
					{
						xtextElementList_2.AddRaw(element);
						num++;
					}
				}
			}
			bool_13 = (num > 0);
			return num;
		}

		[DCInternal]
		public override void vmethod_17(ReadHTMLEventArgs readHTMLEventArgs_0)
		{
			method_19(readHTMLEventArgs_0);
		}

		[DCInternal]
		protected void method_19(ReadHTMLEventArgs readHTMLEventArgs_0)
		{
			int num = 18;
			readHTMLEventArgs_0.ReadDCCustomAttributes(readHTMLEventArgs_0.HtmlElement, this);
			if (readHTMLEventArgs_0.HtmlElement.vmethod_2() != null)
			{
				foreach (GClass163 item in readHTMLEventArgs_0.HtmlElement.vmethod_2())
				{
					if (!(item is GClass215) && !readHTMLEventArgs_0.IsDCIgnore(item))
					{
						string dCTypeName = readHTMLEventArgs_0.GetDCTypeName(item);
						if (!string.IsNullOrEmpty(dCTypeName))
						{
							if (dCTypeName == typeof(DocumentComment).Name)
							{
								DocumentComment documentComment = new DocumentComment();
								readHTMLEventArgs_0.ReadDCCustomAttributes(item, documentComment);
								OwnerDocument.Comments.Add(documentComment);
								foreach (GClass163 item2 in item.vmethod_2())
								{
									if (item2.method_37() != null && item2.method_37().StartsWith("dcmcontent"))
									{
										documentComment.Text = item2.InnerText;
										if (documentComment.Text != null)
										{
											documentComment.Text = documentComment.Text.Trim();
										}
									}
								}
								continue;
							}
							Type type = WriterAppHost.smethod_3(dCTypeName);
							if (type == null)
							{
								type = ControlHelper.GetControlType(dCTypeName, typeof(XTextElement));
							}
							if (type != null)
							{
								if (type == typeof(XTextDocumentBodyElement))
								{
									OwnerDocument.Body.vmethod_17(new ReadHTMLEventArgs(readHTMLEventArgs_0, item, OwnerDocument, null));
								}
								else if (type == typeof(XTextDocumentFooterElement))
								{
									OwnerDocument.Footer.vmethod_17(new ReadHTMLEventArgs(readHTMLEventArgs_0, item, OwnerDocument, null));
								}
								else if (type == typeof(XTextDocumentHeaderElement))
								{
									OwnerDocument.Header.vmethod_17(new ReadHTMLEventArgs(readHTMLEventArgs_0, item, OwnerDocument, null));
								}
								else
								{
									XTextElement xTextElement = (XTextElement)Activator.CreateInstance(type);
									if (xTextElement != null)
									{
										xTextElement.method_5(OwnerDocument);
										xTextElement.SetParentRaw(this);
									}
									GClass222 gClass3 = item.method_0().method_0();
									if (readHTMLEventArgs_0.CurrentStyle != null)
									{
										gClass3.method_8(readHTMLEventArgs_0.CurrentStyle, bool_0: false, GClass222.string_0);
									}
									ReadHTMLEventArgs readHTMLEventArgs_ = new ReadHTMLEventArgs(readHTMLEventArgs_0, item, OwnerDocument, gClass3);
									xTextElement.vmethod_17(readHTMLEventArgs_);
									if (type == typeof(XTextSectionElement))
									{
										OwnerDocument.Body.Elements.Add(xTextElement);
									}
									else
									{
										Elements.Add(xTextElement);
									}
								}
								continue;
							}
						}
						GClass222 gClass4 = item.method_0().method_0();
						string text = item.method_43();
						switch (text)
						{
						case "hr":
						{
							XTextHorizontalLineElement xTextHorizontalLineElement = new XTextHorizontalLineElement();
							xTextHorizontalLineElement.OwnerDocument = OwnerDocument;
							xTextHorizontalLineElement.ID = item.method_37();
							readHTMLEventArgs_0.ReadDCCustomAttributes(item, xTextHorizontalLineElement);
							if (item.method_13("color"))
							{
								xTextHorizontalLineElement.Style.Color = readHTMLEventArgs_0.ToColor(item.method_9("color"), Color.Black);
							}
							Elements.Add(xTextHorizontalLineElement);
							break;
						}
						case "div":
						{
							if (readHTMLEventArgs_0.CurrentStyle != null)
							{
								gClass4.method_8(readHTMLEventArgs_0.CurrentStyle, bool_0: false, GClass222.string_0);
							}
							method_19(new ReadHTMLEventArgs(readHTMLEventArgs_0, item, OwnerDocument, gClass4));
							XTextParagraphFlagElement xTextParagraphFlagElement3 = new XTextParagraphFlagElement();
							xTextParagraphFlagElement3.Style = readHTMLEventArgs_0.CreateContentStyle(gClass4, xTextParagraphFlagElement3, item);
							Elements.Add(xTextParagraphFlagElement3);
							break;
						}
						case "ul":
						case "ol":
							foreach (GClass163 item3 in item.vmethod_2())
							{
								if (item3.method_43() == "li")
								{
									if (readHTMLEventArgs_0.CurrentStyle != null)
									{
										gClass4.method_8(readHTMLEventArgs_0.CurrentStyle, bool_0: false, GClass222.string_0);
									}
									method_19(new ReadHTMLEventArgs(readHTMLEventArgs_0, item, OwnerDocument, gClass4));
									XTextParagraphFlagElement xTextParagraphFlagElement2 = new XTextParagraphFlagElement();
									xTextParagraphFlagElement2.Style = readHTMLEventArgs_0.CreateContentStyle(gClass4, xTextParagraphFlagElement2, item);
									if (text == "ul")
									{
										xTextParagraphFlagElement2.Style.ParagraphListStyle = ParagraphListStyle.BulletedList;
									}
									else
									{
										xTextParagraphFlagElement2.Style.ParagraphListStyle = ParagraphListStyle.ListNumberStyle;
									}
									Elements.Add(xTextParagraphFlagElement2);
								}
							}
							break;
						case "pre":
						{
							if (readHTMLEventArgs_0.CurrentStyle != null)
							{
								gClass4.method_8(readHTMLEventArgs_0.CurrentStyle, bool_0: false, GClass222.string_0);
							}
							XTextStringElement xTextStringElement = new XTextStringElement();
							xTextStringElement.OwnerDocument = OwnerDocument;
							xTextStringElement.Parent = this;
							xTextStringElement.Style = readHTMLEventArgs_0.CreateContentStyle(gClass4, xTextStringElement, item);
							xTextStringElement.Text = item.InnerText;
							Elements.Add(xTextStringElement);
							XTextParagraphFlagElement xTextParagraphFlagElement3 = new XTextParagraphFlagElement();
							xTextParagraphFlagElement3.Style = readHTMLEventArgs_0.CreateContentStyle(gClass4, xTextStringElement, item);
							Elements.Add(xTextParagraphFlagElement3);
							break;
						}
						case "input":
						{
							if (readHTMLEventArgs_0.CurrentStyle != null)
							{
								gClass4.method_8(readHTMLEventArgs_0.CurrentStyle, bool_0: false, GClass222.string_0);
							}
							string text2 = item.method_9("type");
							if (text2 != null)
							{
								text2 = text2.Trim().ToLower();
							}
							if (text2 == "password")
							{
								XTextInputFieldElement xTextInputFieldElement = new XTextInputFieldElement();
								xTextInputFieldElement.OwnerDocument = OwnerDocument;
								xTextInputFieldElement.Parent = this;
								xTextInputFieldElement.vmethod_17(new ReadHTMLEventArgs(readHTMLEventArgs_0, item, OwnerDocument, gClass4));
								xTextInputFieldElement.ViewEncryptType = ContentViewEncryptType.Both;
								Elements.Add(xTextInputFieldElement);
							}
							else if (text2 == "button" || text2 == "submit")
							{
								XTextButtonElement xTextButtonElement = new XTextButtonElement();
								xTextButtonElement.OwnerDocument = OwnerDocument;
								xTextButtonElement.Parent = this;
								xTextButtonElement.vmethod_17(new ReadHTMLEventArgs(readHTMLEventArgs_0, item, OwnerDocument, gClass4));
								Elements.Add(xTextButtonElement);
							}
							else if (text2 == "image")
							{
								XTextImageElement xTextImageElement = new XTextImageElement();
								xTextImageElement.OwnerDocument = OwnerDocument;
								xTextImageElement.Parent = this;
								xTextImageElement.vmethod_17(new ReadHTMLEventArgs(readHTMLEventArgs_0, item, OwnerDocument, gClass4));
								Elements.Add(xTextImageElement);
							}
							else
							{
								XTextInputFieldElement xTextInputFieldElement = new XTextInputFieldElement();
								xTextInputFieldElement.OwnerDocument = OwnerDocument;
								xTextInputFieldElement.Parent = this;
								xTextInputFieldElement.vmethod_17(new ReadHTMLEventArgs(readHTMLEventArgs_0, item, OwnerDocument, gClass4));
								Elements.Add(xTextInputFieldElement);
							}
							break;
						}
						case "textarea":
						{
							if (readHTMLEventArgs_0.CurrentStyle != null)
							{
								gClass4.method_8(readHTMLEventArgs_0.CurrentStyle, bool_0: false, GClass222.string_0);
							}
							XTextInputFieldElement xTextInputFieldElement = new XTextInputFieldElement();
							xTextInputFieldElement.OwnerDocument = OwnerDocument;
							xTextInputFieldElement.Parent = this;
							xTextInputFieldElement.AcceptChildElementTypes2 |= ElementType.ParagraphFlag;
							xTextInputFieldElement.vmethod_17(new ReadHTMLEventArgs(readHTMLEventArgs_0, item, OwnerDocument, gClass4));
							Elements.Add(xTextInputFieldElement);
							break;
						}
						case "select":
						{
							if (readHTMLEventArgs_0.CurrentStyle != null)
							{
								gClass4.method_8(readHTMLEventArgs_0.CurrentStyle, bool_0: false, GClass222.string_0);
							}
							XTextInputFieldElement xTextInputFieldElement = new XTextInputFieldElement();
							xTextInputFieldElement.OwnerDocument = OwnerDocument;
							xTextInputFieldElement.Parent = this;
							xTextInputFieldElement.vmethod_17(new ReadHTMLEventArgs(readHTMLEventArgs_0, item, OwnerDocument, gClass4));
							Elements.Add(xTextInputFieldElement);
							break;
						}
						case "img":
						{
							XTextImageElement xTextImageElement = new XTextImageElement();
							xTextImageElement.OwnerDocument = OwnerDocument;
							xTextImageElement.Parent = this;
							xTextImageElement.vmethod_17(new ReadHTMLEventArgs(readHTMLEventArgs_0, item, OwnerDocument, item.method_0()));
							Elements.Add(xTextImageElement);
							break;
						}
						case "#text":
						{
							if (readHTMLEventArgs_0.CurrentStyle != null)
							{
								gClass4.method_8(readHTMLEventArgs_0.CurrentStyle, bool_0: false, GClass222.string_0);
							}
							string text4 = StringFormatHelper.NormalizeSpace(item.vmethod_7());
							text4 = ((!OwnerDocument.Options.BehaviorOptions.DoubleCompressHtmlWhitespace) ? text4.Replace("&nbsp;", " ") : text4.Replace("&nbsp;", "  "));
							text4 = HttpUtility.HtmlDecode(text4);
							if (!string.IsNullOrEmpty(text4))
							{
								XTextStringElement xTextStringElement = new XTextStringElement();
								xTextStringElement.OwnerDocument = OwnerDocument;
								xTextStringElement.Text = text4;
								xTextStringElement.Style = readHTMLEventArgs_0.CreateContentStyle(gClass4, xTextStringElement, item);
								Elements.Add(xTextStringElement);
							}
							break;
						}
						case "p":
						{
							if (readHTMLEventArgs_0.CurrentStyle != null)
							{
								gClass4.method_8(readHTMLEventArgs_0.CurrentStyle, bool_0: false, GClass222.string_0);
							}
							XTextParagraphFlagElement xTextParagraphFlagElement2 = new XTextParagraphFlagElement();
							xTextParagraphFlagElement2.OwnerDocument = OwnerDocument;
							xTextParagraphFlagElement2.Parent = Parent;
							xTextParagraphFlagElement2.Style = readHTMLEventArgs_0.CreateContentStyle(gClass4, xTextParagraphFlagElement2, item);
							string text3 = item.method_9("align");
							if (!string.IsNullOrEmpty(text3))
							{
								switch (text3.Trim().ToLower())
								{
								case "justify":
									xTextParagraphFlagElement2.Style.Align = DocumentContentAlignment.Justify;
									break;
								case "right":
									xTextParagraphFlagElement2.Style.Align = DocumentContentAlignment.Right;
									break;
								case "center":
									xTextParagraphFlagElement2.Style.Align = DocumentContentAlignment.Center;
									break;
								case "left":
									xTextParagraphFlagElement2.Style.Align = DocumentContentAlignment.Left;
									break;
								default:
									xTextParagraphFlagElement2.Style.Align = DocumentContentAlignment.Left;
									break;
								}
							}
							method_19(new ReadHTMLEventArgs(readHTMLEventArgs_0, item, OwnerDocument, gClass4));
							Elements.Add(xTextParagraphFlagElement2);
							break;
						}
						case "br":
						{
							XTextLineBreakElement element = new XTextLineBreakElement();
							Elements.Add(element);
							break;
						}
						case "table":
						{
							if (readHTMLEventArgs_0.CurrentStyle != null)
							{
								gClass4.method_8(readHTMLEventArgs_0.CurrentStyle, bool_0: false, GClass222.string_0);
							}
							XTextTableElement xTextTableElement = new XTextTableElement();
							xTextTableElement.OwnerDocument = OwnerDocument;
							xTextTableElement.Parent = this;
							xTextTableElement.vmethod_17(new ReadHTMLEventArgs(readHTMLEventArgs_0, item, OwnerDocument, gClass4));
							Elements.Add(xTextTableElement);
							break;
						}
						case "sub":
							if (readHTMLEventArgs_0.CurrentStyle != null)
							{
								gClass4.method_8(readHTMLEventArgs_0.CurrentStyle, bool_0: false, GClass222.string_0);
							}
							gClass4.method_10("dc_sub", "true");
							gClass4.method_6("dc_sup");
							method_19(new ReadHTMLEventArgs(readHTMLEventArgs_0, item, OwnerDocument, gClass4));
							break;
						case "sup":
							if (readHTMLEventArgs_0.CurrentStyle != null)
							{
								gClass4.method_8(readHTMLEventArgs_0.CurrentStyle, bool_0: false, GClass222.string_0);
							}
							gClass4.method_10("dc_sup", "true");
							gClass4.method_6("dc_sub");
							method_19(new ReadHTMLEventArgs(readHTMLEventArgs_0, item, OwnerDocument, gClass4));
							break;
						case "center":
							if (readHTMLEventArgs_0.CurrentStyle != null)
							{
								gClass4.method_8(readHTMLEventArgs_0.CurrentStyle, bool_0: false, GClass222.string_0);
							}
							gClass4.method_10("text-align", "center");
							method_19(new ReadHTMLEventArgs(readHTMLEventArgs_0, item, OwnerDocument, gClass4));
							break;
						case "em":
						case "i":
							if (readHTMLEventArgs_0.CurrentStyle != null)
							{
								gClass4.method_8(readHTMLEventArgs_0.CurrentStyle, bool_0: false, GClass222.string_0);
							}
							gClass4.method_10("font-style", "italic");
							method_19(new ReadHTMLEventArgs(readHTMLEventArgs_0, item, OwnerDocument, gClass4));
							break;
						case "strong":
						case "b":
							if (readHTMLEventArgs_0.CurrentStyle != null)
							{
								gClass4.method_8(readHTMLEventArgs_0.CurrentStyle, bool_0: false, GClass222.string_0);
							}
							gClass4.method_10("font-weight", "bold");
							method_19(new ReadHTMLEventArgs(readHTMLEventArgs_0, item, OwnerDocument, gClass4));
							break;
						case "strike":
						case "s":
							if (readHTMLEventArgs_0.CurrentStyle != null)
							{
								gClass4.method_8(readHTMLEventArgs_0.CurrentStyle, bool_0: false, GClass222.string_0);
							}
							gClass4.method_10("text-decoration", "line-through");
							method_19(new ReadHTMLEventArgs(readHTMLEventArgs_0, item, OwnerDocument, gClass4));
							break;
						case "u":
							if (readHTMLEventArgs_0.CurrentStyle != null)
							{
								gClass4.method_8(readHTMLEventArgs_0.CurrentStyle, bool_0: false, GClass222.string_0);
							}
							gClass4.method_10("text-decoration", "underline");
							method_19(new ReadHTMLEventArgs(readHTMLEventArgs_0, item, OwnerDocument, gClass4));
							break;
						case "font":
							if (readHTMLEventArgs_0.CurrentStyle != null)
							{
								gClass4.method_8(readHTMLEventArgs_0.CurrentStyle, bool_0: false, GClass222.string_0);
							}
							if (item.method_13("color"))
							{
								gClass4.method_10("color", item.method_9("color"));
							}
							if (item.method_13("face"))
							{
								gClass4.method_10("font-family", item.method_9("face"));
							}
							if (item.method_13("size"))
							{
								switch (readHTMLEventArgs_0.ToInt32(item.method_9("size")))
								{
								case 1:
									gClass4.method_10("font-size", "7");
									break;
								case 2:
									gClass4.method_10("font-size", "10");
									break;
								case 3:
									gClass4.method_10("font-size", "12");
									break;
								case 4:
									gClass4.method_10("font-size", "14");
									break;
								case 5:
									gClass4.method_10("font-size", "18");
									break;
								case 6:
									gClass4.method_10("font-size", "24");
									break;
								case 7:
									gClass4.method_10("font-size", "35");
									break;
								}
							}
							method_19(new ReadHTMLEventArgs(readHTMLEventArgs_0, item, OwnerDocument, gClass4));
							break;
						case "h1":
						{
							gClass4.method_10("font-size", "24");
							method_19(new ReadHTMLEventArgs(readHTMLEventArgs_0, item, OwnerDocument, gClass4));
							XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
							xTextParagraphFlagElement.OwnerDocument = OwnerDocument;
							xTextParagraphFlagElement.Parent = this;
							xTextParagraphFlagElement.Style = readHTMLEventArgs_0.CreateContentStyle(gClass4, xTextParagraphFlagElement, item);
							xTextParagraphFlagElement.Style.ParagraphOutlineLevel = 0;
							Elements.Add(xTextParagraphFlagElement);
							break;
						}
						case "h2":
						{
							gClass4.method_10("font-size", "18");
							method_19(new ReadHTMLEventArgs(readHTMLEventArgs_0, item, OwnerDocument, gClass4));
							XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
							xTextParagraphFlagElement.OwnerDocument = OwnerDocument;
							xTextParagraphFlagElement.Parent = this;
							xTextParagraphFlagElement.Style = readHTMLEventArgs_0.CreateContentStyle(gClass4, xTextParagraphFlagElement, item);
							xTextParagraphFlagElement.Style.ParagraphOutlineLevel = 1;
							Elements.Add(xTextParagraphFlagElement);
							break;
						}
						case "h3":
						{
							gClass4.method_10("font-size", "13");
							method_19(new ReadHTMLEventArgs(readHTMLEventArgs_0, item, OwnerDocument, gClass4));
							XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
							xTextParagraphFlagElement.OwnerDocument = OwnerDocument;
							xTextParagraphFlagElement.Parent = this;
							xTextParagraphFlagElement.Style = readHTMLEventArgs_0.CreateContentStyle(gClass4, xTextParagraphFlagElement, item);
							xTextParagraphFlagElement.Style.ParagraphOutlineLevel = 2;
							Elements.Add(xTextParagraphFlagElement);
							break;
						}
						case "h4":
						{
							gClass4.method_10("font-size", "12");
							method_19(new ReadHTMLEventArgs(readHTMLEventArgs_0, item, OwnerDocument, gClass4));
							XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
							xTextParagraphFlagElement.OwnerDocument = OwnerDocument;
							xTextParagraphFlagElement.Parent = this;
							xTextParagraphFlagElement.Style = readHTMLEventArgs_0.CreateContentStyle(gClass4, xTextParagraphFlagElement, item);
							xTextParagraphFlagElement.Style.ParagraphOutlineLevel = 3;
							Elements.Add(xTextParagraphFlagElement);
							break;
						}
						case "h5":
						{
							gClass4.method_10("font-size", "10");
							method_19(new ReadHTMLEventArgs(readHTMLEventArgs_0, item, OwnerDocument, gClass4));
							XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
							xTextParagraphFlagElement.OwnerDocument = OwnerDocument;
							xTextParagraphFlagElement.Parent = this;
							xTextParagraphFlagElement.Style = readHTMLEventArgs_0.CreateContentStyle(gClass4, xTextParagraphFlagElement, item);
							xTextParagraphFlagElement.Style.ParagraphOutlineLevel = 4;
							Elements.Add(xTextParagraphFlagElement);
							break;
						}
						case "h6":
						{
							gClass4.method_10("font-size", "8");
							method_19(new ReadHTMLEventArgs(readHTMLEventArgs_0, item, OwnerDocument, gClass4));
							XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
							xTextParagraphFlagElement.OwnerDocument = OwnerDocument;
							xTextParagraphFlagElement.Parent = this;
							xTextParagraphFlagElement.Style = readHTMLEventArgs_0.CreateContentStyle(gClass4, xTextParagraphFlagElement, item);
							xTextParagraphFlagElement.Style.ParagraphOutlineLevel = 5;
							Elements.Add(xTextParagraphFlagElement);
							break;
						}
						default:
							if (readHTMLEventArgs_0.CurrentStyle != null)
							{
								gClass4.method_8(readHTMLEventArgs_0.CurrentStyle, bool_0: false, GClass222.string_0);
							}
							method_19(new ReadHTMLEventArgs(readHTMLEventArgs_0, item, OwnerDocument, gClass4));
							break;
						}
					}
				}
			}
		}

		[DCInternal]
		public override void vmethod_19(GClass103 gclass103_0)
		{
			XTextElementList xTextElementList = WriterUtils.smethod_59(Elements, gclass103_0.vmethod_0(), gclass103_0.method_12());
			if (xTextElementList != null && xTextElementList.Count > 0)
			{
				if (!(this is XTextContentElement))
				{
					XTextParagraphElement xTextParagraphElement = (XTextParagraphElement)xTextElementList[0];
				}
				foreach (XTextElement item in xTextElementList)
				{
					if (this is XTextTableCellElement && item is XTextParagraphElement)
					{
						XTextParagraphElement xTextParagraphElement = (XTextParagraphElement)item;
						xTextParagraphElement.xtextTableCellElement_0 = (XTextTableCellElement)this;
					}
					item.vmethod_19(gclass103_0);
				}
			}
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <param name="Deeply">是否复制子孙节点</param>
		/// <returns>复制品</returns>
		[DCInternal]
		public override XTextElement Clone(bool Deeply)
		{
			XTextContainerElement xTextContainerElement = (XTextContainerElement)base.Clone(Deeply);
			xTextContainerElement.contentBuilder_0 = null;
			if (dataFeedbackInfo_0 != null)
			{
				xTextContainerElement.dataFeedbackInfo_0 = dataFeedbackInfo_0.Clone();
			}
			if (propertyExpressionInfoList_0 != null && propertyExpressionInfoList_0.Count > 0)
			{
				xTextContainerElement.propertyExpressionInfoList_0 = propertyExpressionInfoList_0.Clone();
			}
			if (copySourceInfo_0 != null)
			{
				xTextContainerElement.copySourceInfo_0 = copySourceInfo_0.Clone();
			}
			if (dccontentLockInfo_0 != null)
			{
				xTextContainerElement.dccontentLockInfo_0 = dccontentLockInfo_0.Clone();
			}
			if (valueValidateStyle_0 != null)
			{
				xTextContainerElement.valueValidateStyle_0 = valueValidateStyle_0.method_4();
			}
			xTextContainerElement.valueValidateResult_0 = null;
			if (xdataBinding_0 != null)
			{
				xTextContainerElement.xdataBinding_0 = xdataBinding_0.Clone();
			}
			if (xattributeList_0 != null && xattributeList_0.Count > 0)
			{
				xTextContainerElement.xattributeList_0 = xattributeList_0.Clone();
			}
			else
			{
				xTextContainerElement.xattributeList_0 = null;
			}
			if (vbscriptItemList_0 != null && vbscriptItemList_0.Count > 0)
			{
				xTextContainerElement.vbscriptItemList_0 = vbscriptItemList_0.Clone();
			}
			else
			{
				xTextContainerElement.vbscriptItemList_0 = null;
			}
			xTextContainerElement.xtextElementList_0 = new XTextElementList();
			xTextContainerElement.xtextElementList_1 = null;
			xTextContainerElement.int_9 = 0;
			if (Deeply && xtextElementList_0 != null)
			{
				xTextContainerElement.xtextElementList_0 = new XTextElementList();
				foreach (XTextElement item in xtextElementList_0)
				{
					XTextElement xTextElement = item.Clone(Deeply);
					xTextElement.Parent = xTextContainerElement;
					xTextElement.OwnerDocument = item.OwnerDocument;
					if (xTextElement.Elements != null && xTextElement.Elements.Count > 0)
					{
						foreach (XTextElement element in xTextElement.Elements)
						{
							element.Parent = (XTextContainerElement)xTextElement;
						}
					}
					xTextContainerElement.xtextElementList_0.Add(xTextElement);
					xTextElement.Parent = xTextContainerElement;
				}
			}
			return xTextContainerElement;
		}

		/// <summary>
		///       销毁对象
		///       </summary>
		[DCInternal]
		public override void Dispose()
		{
			base.Dispose();
			if (xtextElementList_1 != null)
			{
				foreach (XTextElement item in xtextElementList_1)
				{
					item.Dispose();
				}
				xtextElementList_1.Clear();
				xtextElementList_1.method_6(null);
				xtextElementList_1 = null;
			}
			if (xtextElementList_0 != null)
			{
				foreach (XTextElement element in Elements)
				{
					element?.Dispose();
				}
				xtextElementList_0.Clear();
				xtextElementList_0.method_6(null);
				xtextElementList_0 = null;
			}
			if (xattributeList_0 != null)
			{
				xattributeList_0.Clear();
				xattributeList_0 = null;
			}
			if (contentBuilder_0 != null)
			{
				contentBuilder_0.InnerDispose();
				contentBuilder_0 = null;
			}
			dccontentLockInfo_0 = null;
			copySourceInfo_0 = null;
			dataSourceTreeNode_0 = null;
			string_5 = null;
			string_10 = null;
			string_11 = null;
			string_13 = null;
			if (domExpressionList_0 != null)
			{
				domExpressionList_0.Clear();
				domExpressionList_0 = null;
			}
			string_8 = null;
			string_9 = null;
			if (valueValidateResult_0 != null)
			{
				valueValidateResult_0.Clear();
				valueValidateResult_0 = null;
			}
			if (propertyExpressionInfoList_0 != null)
			{
				propertyExpressionInfoList_0.Owner = null;
				propertyExpressionInfoList_0.Clear();
				propertyExpressionInfoList_0 = null;
			}
			string_6 = null;
			if (vbscriptItemList_0 != null)
			{
				vbscriptItemList_0.Clear();
				vbscriptItemList_0 = null;
			}
			object_0 = null;
			string_7 = null;
			valueValidateStyle_0 = null;
			xdataBinding_0 = null;
			string_12 = null;
		}

		/// <summary>
		///       遍历子孙文档元素
		///       </summary>
		/// <param name="handler">遍历过程的委托对象</param>
		[DCInternal]
		public void Enumerate(ElementEnumerateEventHandler handler)
		{
			ElementEnumerateEventArgs args = new ElementEnumerateEventArgs();
			Enumerate(handler, args, includeSelfNode: false);
		}

		/// <summary>
		///       遍历子孙文档元素
		///       </summary>
		/// <param name="handler">遍历过程的委托对象</param>
		/// <param name="includeSelfNode">是否包含节点本身</param>
		[DCInternal]
		public void Enumerate(ElementEnumerateEventHandler handler, bool includeSelfNode)
		{
			ElementEnumerateEventArgs args = new ElementEnumerateEventArgs();
			Enumerate(handler, args, includeSelfNode);
		}

		/// <summary>
		///       遍历子孙元素
		///       </summary>
		/// <param name="handler">遍历过程的委托对象</param>
		/// <param name="args">参数</param>
		/// <param name="includeSelfNode">是否包含节点本身</param>
		[DCInternal]
		public void Enumerate(ElementEnumerateEventHandler handler, ElementEnumerateEventArgs args, bool includeSelfNode)
		{
			int num = 5;
			if (handler == null)
			{
				throw new ArgumentNullException("handler");
			}
			if (args == null)
			{
				throw new ArgumentNullException("args");
			}
			if (includeSelfNode)
			{
				args._Parent = Parent;
				args._Element = this;
				handler(this, args);
				if (args.Cancel || args.CancelChild)
				{
					return;
				}
			}
			method_20(handler, args);
			_ = args.HandlerCount;
		}

		private void method_20(ElementEnumerateEventHandler elementEnumerateEventHandler_0, ElementEnumerateEventArgs elementEnumerateEventArgs_0)
		{
			if (elementEnumerateEventArgs_0.ReverseMode)
			{
				for (int num = Elements.Count - 1; num >= 0; num--)
				{
					XTextElement xTextElement = Elements[num];
					if (xTextElement is XTextCharElement)
					{
						if (elementEnumerateEventArgs_0._ExcludeCharElement)
						{
							continue;
						}
					}
					else if (xTextElement is XTextParagraphFlagElement && elementEnumerateEventArgs_0._ExcludeParagraphFlag)
					{
						continue;
					}
					elementEnumerateEventArgs_0._Parent = this;
					elementEnumerateEventArgs_0._Element = xTextElement;
					elementEnumerateEventArgs_0._CancelChild = false;
					elementEnumerateEventHandler_0(this, elementEnumerateEventArgs_0);
					elementEnumerateEventArgs_0.IncreaseHandlerCount();
					if (elementEnumerateEventArgs_0._Cancel)
					{
						break;
					}
					if (!elementEnumerateEventArgs_0._CancelChild && xTextElement is XTextContainerElement)
					{
						((XTextContainerElement)xTextElement).method_20(elementEnumerateEventHandler_0, elementEnumerateEventArgs_0);
						if (elementEnumerateEventArgs_0.Cancel)
						{
							break;
						}
					}
					elementEnumerateEventArgs_0._CancelChild = false;
				}
			}
			else
			{
				foreach (XTextElement element in Elements)
				{
					if (element is XTextCharElement)
					{
						if (elementEnumerateEventArgs_0._ExcludeCharElement)
						{
							continue;
						}
					}
					else if (element is XTextParagraphFlagElement && elementEnumerateEventArgs_0._ExcludeParagraphFlag)
					{
						continue;
					}
					elementEnumerateEventArgs_0._Parent = this;
					elementEnumerateEventArgs_0._Element = element;
					elementEnumerateEventArgs_0._CancelChild = false;
					elementEnumerateEventHandler_0(this, elementEnumerateEventArgs_0);
					elementEnumerateEventArgs_0.IncreaseHandlerCount();
					if (elementEnumerateEventArgs_0._Cancel)
					{
						break;
					}
					if (!elementEnumerateEventArgs_0._CancelChild && element is XTextContainerElement)
					{
						((XTextContainerElement)element).method_20(elementEnumerateEventHandler_0, elementEnumerateEventArgs_0);
						if (elementEnumerateEventArgs_0.Cancel)
						{
							break;
						}
					}
					elementEnumerateEventArgs_0._CancelChild = false;
				}
			}
		}

		/// <summary>
		///       获得文档中指定name值的元素对象,查找时name值区分大小写的。
		///       </summary>
		/// <param name="name">指定的编号</param>
		/// <returns>找到的元素对象</returns>
		[DCPublishAPI]
		public virtual XTextElementList GetElementsByName(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				return null;
			}
			XTextElementList xTextElementList = new XTextElementList();
			DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(Elements);
			foreach (XTextElement item in domTreeNodeEnumerable)
			{
				if (item is XTextFieldElementBase)
				{
					XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)item;
					if (xTextInputFieldElementBase.Name == name)
					{
						xTextElementList.Add(xTextInputFieldElementBase);
					}
				}
				else if (item is XTextObjectElement)
				{
					XTextObjectElement xTextObjectElement = (XTextObjectElement)item;
					if (xTextObjectElement.Name == name)
					{
						xTextElementList.Add(xTextObjectElement);
					}
				}
			}
			return xTextElementList;
		}

		/// <summary>
		///       获得具有指定样式编号的文档对象。
		///       </summary>
		/// <param name="styleIndex">样式编号</param>
		/// <returns>找到的文档元素列表</returns>
		[DCPublishAPI]
		public virtual XTextElementList GetElementsByStyleIndex(int styleIndex)
		{
			XTextElementList xTextElementList = new XTextElementList();
			DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(this);
			domTreeNodeEnumerable.ExcludeParagraphFlag = false;
			domTreeNodeEnumerable.ExcludeCharElement = false;
			foreach (XTextElement item in domTreeNodeEnumerable)
			{
				if (item.StyleIndex == styleIndex)
				{
					xTextElementList.Add(item);
				}
			}
			return xTextElementList;
		}

		/// <summary>
		///       获得第一个绑定了指定数据源的输入域对象
		///       </summary>
		/// <param name="dataSource">数据源名称</param>
		/// <param name="bindingPath">绑定的路径</param>
		/// <returns>获得的输入域元素</returns>
		[DCPublishAPI]
		public virtual XTextInputFieldElement GetFirstFieldElementByDataSource(string dataSource, string bindingPath)
		{
			XTextElementList xTextElementList = method_21(dataSource, bindingPath);
			foreach (XTextElement item in xTextElementList)
			{
				if (item is XTextInputFieldElement)
				{
					return (XTextInputFieldElement)item;
				}
			}
			return null;
		}

		private XTextElementList method_21(string string_14, string string_15)
		{
			XTextElementList xTextElementList = new XTextElementList();
			foreach (XTextInputFieldElement item in GetElementsByType(typeof(XTextInputFieldElement)))
			{
				if (item.ValueBinding != null && WriterUtils.smethod_43(item.ValueBinding.DataSource, string_14) && (WriterUtils.smethod_43(item.ValueBinding.BindingPath, string_15) || WriterUtils.smethod_43(item.ValueBinding.BindingPathForText, string_15)))
				{
					xTextElementList.Add(item);
				}
			}
			foreach (XTextCheckBoxElementBase item2 in GetElementsByType(typeof(XTextCheckBoxElementBase)))
			{
				if (item2.ValueBinding != null && WriterUtils.smethod_43(item2.ValueBinding.DataSource, string_14) && WriterUtils.smethod_43(item2.ValueBinding.BindingPath, string_15))
				{
					xTextElementList.Add(item2);
				}
			}
			return xTextElementList;
		}

		/// <summary>
		///       获得文档中所有指定编号的元素对象列表,查找时ID值区分大小写的。
		///       </summary>
		/// <param name="id">指定的编号</param>
		/// <returns>找到的元素对象列表</returns>
		[DCPublishAPI]
		public virtual XTextElementList GetElementsById(string string_14)
		{
			if (string.IsNullOrEmpty(string_14))
			{
				return null;
			}
			XTextElementList xTextElementList = new XTextElementList();
			new XTextElementList();
			DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(this);
			domTreeNodeEnumerable.ExcludeCharElement = true;
			domTreeNodeEnumerable.ExcludeParagraphFlag = true;
			foreach (XTextElement item in domTreeNodeEnumerable)
			{
				if (item.ID == string_14)
				{
					xTextElementList.Add(item);
				}
				else if (item is XTextFieldElementBase)
				{
					XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)item;
					if (xTextInputFieldElementBase.Name == string_14)
					{
						xTextElementList.Add(xTextInputFieldElementBase);
					}
				}
				else if (item is XTextCheckBoxElementBase)
				{
					XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)item;
					if (xTextCheckBoxElementBase.Name == string_14)
					{
						xTextElementList.Add(xTextCheckBoxElementBase);
					}
				}
			}
			return xTextElementList;
		}

		/// <summary>
		///       获得文档中指定编号的元素对象,查找时ID值区分大小写的。
		///       </summary>
		/// <param name="id">指定的编号</param>
		/// <returns>找到的元素对象</returns>
		[DCPublishAPI]
		public virtual XTextElement GetElementById(string string_14)
		{
			return GetElementByIdExt(string_14, idAttributeOnly: false);
		}

		/// <summary>
		///       获得文档中指定编号的元素对象,查找时ID值区分大小写的。
		///       </summary>
		/// <param name="id">指定的编号</param>
		/// <param name="idAttributeOnly">只匹配元素ID属性</param>
		/// <returns>找到的元素对象</returns>
		[DCPublishAPI]
		public virtual XTextElement GetElementByIdExt(string string_14, bool idAttributeOnly)
		{
			if (string.IsNullOrEmpty(string_14))
			{
				return null;
			}
			XTextElement xTextElement = null;
			XTextElement xTextElement2 = null;
			DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(this);
			domTreeNodeEnumerable.ExcludeParagraphFlag = true;
			domTreeNodeEnumerable.ExcludeParagraphFlag = true;
			if (idAttributeOnly)
			{
				foreach (XTextElement item in domTreeNodeEnumerable)
				{
					if (item.ID == string_14)
					{
						xTextElement = item;
						break;
					}
				}
			}
			else
			{
				foreach (XTextElement item2 in domTreeNodeEnumerable)
				{
					if (item2.ID == string_14)
					{
						xTextElement = item2;
						break;
					}
					if (item2 is XTextInputFieldElementBase && xTextElement2 == null)
					{
						XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)item2;
						if (xTextInputFieldElementBase.Name == string_14)
						{
							xTextElement2 = xTextInputFieldElementBase;
						}
					}
					else if (item2 is XTextCheckBoxElementBase && xTextElement2 == null)
					{
						XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)item2;
						if (xTextCheckBoxElementBase.Name == string_14)
						{
							xTextElement2 = xTextCheckBoxElementBase;
						}
					}
				}
			}
			if (xTextElement != null)
			{
				return xTextElement;
			}
			return xTextElement2;
		}

		/// <summary>
		///       获得文档中所有的指定类型的文档元素列表
		///       </summary>
		/// <param name="elementTypeName">元素类型名称</param>
		/// <returns>获得的元素列表</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public XTextElementList GetElementsByTypeName(string elementTypeName)
		{
			int num = 9;
			if (string.IsNullOrEmpty(elementTypeName))
			{
				throw new ArgumentNullException("elementTypeName");
			}
			Type controlType = ControlHelper.GetControlType(elementTypeName, typeof(XTextElement));
			if (controlType == null || !typeof(XTextElement).IsAssignableFrom(controlType))
			{
				throw new ArgumentOutOfRangeException(elementTypeName);
			}
			return GetElementsByType(controlType);
		}

		/// <summary>
		///       在子孙文档元素中获得第一个指定类型的文档元素，但不包括本元素本身。
		///       </summary>
		/// <param name="elementTypeName">文档元素类型名称</param>
		/// <returns>获得的文档元素对象</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public XTextElement GetFirstElementByTypeName(string elementTypeName)
		{
			int num = 12;
			if (string.IsNullOrEmpty(elementTypeName))
			{
				throw new ArgumentNullException("elementTypeName");
			}
			Type controlType = ControlHelper.GetControlType(elementTypeName, typeof(XTextElement));
			if (controlType == null || !typeof(XTextElement).IsAssignableFrom(controlType))
			{
				throw new ArgumentOutOfRangeException(elementTypeName);
			}
			return GetFirstElementByType(controlType);
		}

		/// <summary>
		///       获得子孙元素中最后一个指定类型的文档元素对象
		///       </summary>
		/// <param name="elementType">元素类型</param>
		/// <returns>获得的文档元素对象</returns>
		[DCPublishAPI]
		public XTextElement GetLastElementByType(Type elementType)
		{
			int num = 2;
			if (elementType == null)
			{
				throw new ArgumentNullException("elementType");
			}
			if (!typeof(XTextElement).IsAssignableFrom(elementType))
			{
				throw new InvalidCastException(elementType.FullName);
			}
			bool flag = elementType.Equals(typeof(XTextCharElement));
			int num2 = Elements.Count - 1;
			XTextElement lastElementByType;
			while (true)
			{
				if (num2 >= 0)
				{
					XTextElement xTextElement = Elements[num2];
					if (!flag || !(xTextElement is XTextCharElement))
					{
						if (elementType.IsInstanceOfType(xTextElement))
						{
							return xTextElement;
						}
						if (xTextElement is XTextContainerElement)
						{
							XTextContainerElement xTextContainerElement = (XTextContainerElement)xTextElement;
							lastElementByType = xTextContainerElement.GetLastElementByType(elementType);
							if (lastElementByType != null)
							{
								break;
							}
						}
					}
					num2--;
					continue;
				}
				return null;
			}
			return lastElementByType;
		}

		/// <summary>
		///       在子孙文档元素中获得第一个指定类型的文档元素，但不包括本元素本身。
		///       </summary>
		/// <param name="elementType">文档元素类型</param>
		/// <returns>获得的文档元素对象</returns>
		[ComVisible(false)]
		[DCPublishAPI]
		public XTextElement GetFirstElementByType(Type elementType)
		{
			int num = 10;
			if (elementType == null)
			{
				throw new ArgumentNullException("elementType");
			}
			if (!typeof(XTextElement).IsAssignableFrom(elementType))
			{
				throw new InvalidCastException(elementType.FullName);
			}
			bool flag = elementType.Equals(typeof(XTextCharElement));
			foreach (XTextElement element in Elements)
			{
				if (!flag || !(element is XTextCharElement))
				{
					if (elementType.IsInstanceOfType(element))
					{
						return element;
					}
					if (element is XTextContainerElement)
					{
						XTextElement firstElementByType = ((XTextContainerElement)element).GetFirstElementByType(elementType);
						if (firstElementByType != null)
						{
							return firstElementByType;
						}
					}
				}
			}
			return null;
		}

		/// <summary>
		///       获得本文档元素容器包含的所有的指定类型的文档元素列表
		///       </summary>
		/// <param name="elementType">元素类型</param>
		/// <returns>获得的元素列表</returns>
		[ComVisible(false)]
		[DCPublishAPI]
		public virtual XTextElementList GetElementsByType(Type elementType)
		{
			int num = 3;
			if (elementType == null)
			{
				throw new ArgumentNullException("elementType");
			}
			if (!typeof(XTextElement).IsAssignableFrom(elementType))
			{
				throw new InvalidCastException(elementType.FullName);
			}
			return Elements.GetElementsByTypeDeeply(elementType);
		}

		/// <summary>
		///       计算元素大小
		///       </summary>
		/// <param name="args">参数</param>
		[DCInternal]
		public override void RefreshSize(DocumentPaintEventArgs args)
		{
			if (Elements != null)
			{
				foreach (XTextElement element in Elements)
				{
					if (!args.CheckSizeInvalidateWhenRefreshSize || element.SizeInvalid)
					{
						if (element is XTextCharElement)
						{
							((XTextCharElement)element).FontSizeZoomRate = 1f;
						}
						else if (element is XTextParagraphFlagElement)
						{
							((XTextParagraphFlagElement)element).FontSizeZoomRate = 1f;
						}
						element.RefreshSize(args);
					}
				}
			}
			SizeInvalid = false;
		}

		[DCInternal]
		public void method_22(ContentChangingEventArgs contentChangingEventArgs_0)
		{
			XTextContainerElement xTextContainerElement = this;
			while (xTextContainerElement != null)
			{
				xTextContainerElement.vmethod_33(contentChangingEventArgs_0);
				if (!contentChangingEventArgs_0.CancelBubble)
				{
					xTextContainerElement = xTextContainerElement.Parent;
					continue;
				}
				break;
			}
		}

		[DCInternal]
		public virtual void vmethod_33(ContentChangingEventArgs contentChangingEventArgs_0)
		{
			OwnerDocument.method_47(this, "ContentChanging", new object[2]
			{
				this,
				contentChangingEventArgs_0
			});
			if (OwnerDocument.EnableContentChangedEvent && OwnerDocument.Options.BehaviorOptions.EnableElementEvents)
			{
				if (WriterControl != null)
				{
					WriterControl.GlobalElementEventMan.method_21(this, contentChangingEventArgs_0);
				}
				if (Events != null && Events.HasContentChanging)
				{
					Events.OnContentChanging(this, contentChangingEventArgs_0);
				}
			}
		}

		[DCInternal]
		public void method_23(ContentChangedEventArgs contentChangedEventArgs_0)
		{
			XTextContainerElement xTextContainerElement = this;
			while (xTextContainerElement != null)
			{
				xTextContainerElement.vmethod_34(contentChangedEventArgs_0);
				if (!contentChangedEventArgs_0.CancelBubble)
				{
					if (contentChangedEventArgs_0.EventSource == ContentChangedEventSource.ValueEditor)
					{
						contentChangedEventArgs_0.EventSource = ContentChangedEventSource.Default;
					}
					xTextContainerElement = xTextContainerElement.Parent;
					continue;
				}
				break;
			}
		}

		/// <summary>
		///       处理文档消息事件
		///       </summary>
		/// <param name="args">参数</param>
		[DCInternal]
		public override void HandleDocumentEvent(DocumentEventArgs args)
		{
			base.HandleDocumentEvent(args);
			if (args.Style == DocumentEventStyles.LostFocusExt && OwnerDocument.CopySourceExecuter != null)
			{
				OwnerDocument.CopySourceExecuter.imethod_2(this);
			}
		}

		[DCInternal]
		public override void OnViewLostFocus(ElementEventArgs elementEventArgs_0)
		{
			if (OwnerDocument.Options.EditOptions.ValueValidateMode == DocumentValueValidateMode.LostFocus)
			{
				vmethod_24(bool_17: false);
			}
			base.OnViewLostFocus(elementEventArgs_0);
		}

		[DCInternal]
		public virtual void vmethod_34(ContentChangedEventArgs contentChangedEventArgs_0)
		{
			int num = 10;
			WriterControl writerControl = WriterControl;
			XTextDocument ownerDocument = OwnerDocument;
			bool loadingDocument;
			if (!(loadingDocument = contentChangedEventArgs_0.LoadingDocument))
			{
				Modified = true;
			}
			ownerDocument.method_47(this, "ContentChanged", new object[2]
			{
				this,
				contentChangedEventArgs_0
			});
			if (ownerDocument.EnableContentChangedEvent && ownerDocument.Options.BehaviorOptions.EnableElementEvents)
			{
				writerControl?.GlobalElementEventMan.method_19(this, contentChangedEventArgs_0);
				ElementEventTemplateList events = Events;
				if (events != null && events.HasContentChanged)
				{
					events.OnContentChanged(this, contentChangedEventArgs_0);
				}
			}
			if (!loadingDocument && ownerDocument.ExpressionExecuter != null)
			{
				ownerDocument.ExpressionExecuter.imethod_9(this);
			}
			method_13(contentChangedEventArgs_0);
			if (writerControl != null && writerControl.EnabledEventMessage && ownerDocument.EnableContentChangedEvent)
			{
				WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(WriterControlEventMessageType.ContentChanged);
				writerControlEventMessage.SrcElement = this;
				writerControlEventMessage.ToElement = this;
				writerControl.method_49(writerControlEventMessage);
			}
		}

		/// <summary>
		///       获得输入焦点
		///       </summary>
		public override void Focus()
		{
			if (!BelongToDocumentDom(OwnerDocument, checkLogicDelete: false))
			{
				return;
			}
			OwnerDocument.method_124(this);
			XTextElement firstContentElement = FirstContentElement;
			if (firstContentElement == null)
			{
				return;
			}
			XTextDocumentContentElement documentContentElement = base.DocumentContentElement;
			if (documentContentElement != null)
			{
				if (OwnerDocument.CurrentContentElement != documentContentElement)
				{
					documentContentElement.Focus();
				}
				int viewIndex = firstContentElement.ViewIndex;
				documentContentElement.SetSelection(firstContentElement.ViewIndex, 0);
				if (viewIndex != firstContentElement.ViewIndex)
				{
					documentContentElement.SetSelection(firstContentElement.ViewIndex, 0);
				}
				if (OwnerDocument.EditorControl != null)
				{
					OwnerDocument.EditorControl.ScrollToCaret();
				}
			}
		}

		/// <summary>
		///       设置文档元素样式
		///       </summary>
		/// <param name="style">文档样式</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(true)]
		public virtual bool EditorSetStyleDeeply(DocumentContentStyle style)
		{
			int num = 1;
			if (OwnerDocument == null)
			{
				throw new NullReferenceException(WriterStringsCore.NeedSetOwnerDocument);
			}
			if (style == null)
			{
				throw new ArgumentNullException("style");
			}
			if (base.EditorSetStyle(style))
			{
				DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(this);
				domTreeNodeEnumerable.ExcludeParagraphFlag = false;
				domTreeNodeEnumerable.ExcludeCharElement = false;
				foreach (XTextElement item in domTreeNodeEnumerable)
				{
					item.StyleIndex = StyleIndex;
				}
				return true;
			}
			return true;
		}

		/// <summary>
		///       结束设置文档元素样式，并设置所有的子孙节点元素
		///       </summary>
		/// <returns>操作是否成功</returns>
		[DCInternal]
		[Obsolete("请使用EditorSetStyleDeeply(style)")]
		public virtual bool EndSetStyleDeeply()
		{
			if (method_8(bool_5: false))
			{
				DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(this);
				domTreeNodeEnumerable.ExcludeCharElement = false;
				domTreeNodeEnumerable.ExcludeParagraphFlag = false;
				foreach (XTextElement item in domTreeNodeEnumerable)
				{
					item.StyleIndex = StyleIndex;
				}
				return true;
			}
			return false;
		}

		/// <summary>
		///       设置文本
		///       </summary>
		/// <param name="newText">新文本</param>
		/// <param name="flags">标记</param>
		/// <param name="disablePermissioin">禁止权限控制</param>
		/// <param name="updateContent">是否更新文档内容</param>
		/// <returns>操作是否修改了对象内容</returns>
		public bool SetEditorTextExt(string newText, DomAccessFlags flags, bool disablePermissioin, bool updateContent)
		{
			SetContainerTextArgs setContainerTextArgs = new SetContainerTextArgs();
			setContainerTextArgs.NewText = newText;
			setContainerTextArgs.AccessFlags = flags;
			setContainerTextArgs.DisablePermission = disablePermissioin;
			setContainerTextArgs.UpdateContent = updateContent;
			return SetEditorText(setContainerTextArgs);
		}

		/// <summary>
		///       设置文档元素内容
		///       </summary>
		/// <param name="style">新的样式对象</param>
		/// <param name="logUndo">是否记录撤销操作信息</param>
		/// <returns>操作是否成功</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[Obsolete("请使用EditorSetContentStyle()")]
		public bool SetContentStyle(DocumentContentStyle style, bool logUndo)
		{
			if (logUndo)
			{
				OwnerDocument.BeginLogUndo();
			}
			bool result = XTextSelection.smethod_0(style, null, null, OwnerDocument, Elements, bool_1: true, null, logUndo);
			if (logUndo)
			{
				OwnerDocument.EndLogUndo();
			}
			OwnerDocument.OnSelectionChanged();
			OwnerDocument.OnDocumentContentChanged();
			return result;
		}

		/// <summary>
		///       设置文本
		///       </summary>
		/// <param name="args">参数</param>
		/// <returns>操作是否修改了对象内容</returns>
		public virtual bool SetEditorText(SetContainerTextArgs args)
		{
			int num = 19;
			if (args == null)
			{
				throw new ArgumentNullException("args");
			}
			bool flag = false;
			if (!UIIsUpdating && BelongToDocumentDom(OwnerDocument, checkLogicDelete: false))
			{
				lock (OwnerDocument)
				{
					string text = Text;
					if (text == null || text != args.NewText)
					{
						bool canLogUndo = OwnerDocument.CanLogUndo;
						if (args.LogUndo && !canLogUndo)
						{
							OwnerDocument.BeginLogUndo();
						}
						if (string.IsNullOrEmpty(args.NewText))
						{
							GEventArgs4 gEventArgs = new GEventArgs4(this, 0, Elements.Count, null, bool_10: true, bool_11: true, bool_12: true);
							gEventArgs.method_7(args.EventSource);
							if (this is XTextContentElement && gEventArgs.method_12() == Elements.Count && Elements.LastElement is XTextParagraphFlagElement)
							{
								gEventArgs.method_13(Elements.Count - 1);
							}
							gEventArgs.method_33(args.FocusContainer);
							gEventArgs.method_27(args.DisablePermission);
							gEventArgs.method_29(args.AccessFlags);
							gEventArgs.method_31(bool_10: false);
							gEventArgs.method_21(args.UpdateContent);
							gEventArgs.method_23(bool_10: true);
							gEventArgs.method_19(args.LogUndo);
							gEventArgs.method_25(args.RaiseEvent);
							gEventArgs.method_1(bool_10: true);
							gEventArgs.method_31(bool_10: false);
							if (!args.DisablePermission && RuntimeEnablePermission)
							{
								for (int i = 0; i < Elements.Count; i++)
								{
									XTextElement xTextElement = Elements[i];
									if (xTextElement.RuntimeStyle.DeleterIndex >= 0)
									{
										bool flag2 = true;
										for (int j = i; j < Elements.Count; j++)
										{
											if (Elements[j].RuntimeStyle.DeleterIndex < 0)
											{
												flag2 = false;
												break;
											}
										}
										if (flag2)
										{
											gEventArgs.method_13(i);
										}
										break;
									}
								}
							}
							flag = (OwnerDocument.method_63(gEventArgs) != 0);
						}
						else
						{
							DocumentContentStyle documentContentStyle = args.NewTextStyle;
							if (documentContentStyle == null)
							{
								if (Elements.Count > 0)
								{
									documentContentStyle = Elements[0].RuntimeStyle.CloneWithoutBorder();
									documentContentStyle.TitleLevel = -1;
									documentContentStyle.ProtectType = ContentProtectType.None;
								}
								else
								{
									documentContentStyle = RuntimeStyle.CloneWithoutBorder();
								}
								documentContentStyle.DeleterIndex = -1;
							}
							if (!RuntimeEnablePermission)
							{
								documentContentStyle.CreatorIndex = -1;
							}
							if (this is XTextInputFieldElement && OwnerDocument.Options.ViewOptions.DefaultInputFieldTextColor.A != 0)
							{
								documentContentStyle.Color = OwnerDocument.Options.ViewOptions.DefaultInputFieldTextColor;
							}
							DocumentContentStyle documentContentStyle2 = args.NewParagraphStyle;
							if (documentContentStyle2 == null)
							{
								XTextElement firstContentElement = FirstContentElement;
								if (firstContentElement != null && firstContentElement.OwnerParagraphEOF != null)
								{
									documentContentStyle2 = firstContentElement.OwnerParagraphEOF.RuntimeStyle.Parent;
								}
								if (documentContentStyle2 == null)
								{
									documentContentStyle2 = OwnerDocument.CurrentStyleInfo.Paragraph;
								}
							}
							documentContentStyle2 = (DocumentContentStyle)documentContentStyle2.Clone();
							documentContentStyle2.ValueLocked = false;
							if (!RuntimeEnablePermission)
							{
								documentContentStyle2.CreatorIndex = -1;
							}
							XTextElementList xTextElementList = OwnerDocument.CreateTextElementsExt(args.NewText, documentContentStyle2, documentContentStyle, RuntimeEnablePermission);
							if (xTextElementList != null && xTextElementList.Count > 0)
							{
								GEventArgs4 gEventArgs = new GEventArgs4(this, 0, Elements.Count, xTextElementList, bool_10: true, bool_11: true, bool_12: true);
								gEventArgs.method_33(args.FocusContainer);
								gEventArgs.method_27(args.DisablePermission);
								gEventArgs.method_29(args.AccessFlags);
								gEventArgs.method_31(bool_10: false);
								gEventArgs.method_21(args.UpdateContent);
								gEventArgs.method_23(bool_10: true);
								gEventArgs.method_19(args.LogUndo);
								gEventArgs.method_25(args.RaiseEvent);
								gEventArgs.method_1(bool_10: true);
								gEventArgs.method_7(args.EventSource);
								gEventArgs.method_31(bool_10: false);
								if (!args.DisablePermission && RuntimeEnablePermission)
								{
									for (int i = 0; i < Elements.Count; i++)
									{
										XTextElement xTextElement = Elements[i];
										if (xTextElement.RuntimeStyle.DeleterIndex >= 0)
										{
											bool flag2 = true;
											for (int j = i; j < Elements.Count; j++)
											{
												if (Elements[j].RuntimeStyle.DeleterIndex < 0)
												{
													flag2 = false;
													break;
												}
											}
											if (flag2)
											{
												gEventArgs.method_13(i);
											}
											break;
										}
									}
								}
								if (this is XTextContentElement && gEventArgs.method_12() == Elements.Count && Elements.LastElement is XTextParagraphFlagElement)
								{
									gEventArgs.method_13(Elements.Count - 1);
								}
								flag = (OwnerDocument.method_63(gEventArgs) != 0);
							}
						}
						if (args.LogUndo && !canLogUndo)
						{
							if (flag)
							{
								OwnerDocument.EndLogUndo();
							}
							else
							{
								OwnerDocument.CancelLogUndo();
							}
						}
						if (flag && args.RaiseEvent)
						{
							if (args.RaiseDocumentContentChangedEvent)
							{
								OwnerDocument.OnDocumentContentChanged();
							}
							OwnerDocument.OnSelectionChanged();
						}
					}
				}
			}
			else
			{
				XTextElementList xTextElementList = SetInnerTextFast(args.NewText);
				flag = (xTextElementList != null && xTextElementList.Count > 0);
			}
			if (OwnerDocument != null && !OwnerDocument.UIIsUpdating)
			{
				if (args.ShowUI)
				{
					OwnerDocument.method_91(null);
				}
				OwnerDocument.method_90();
			}
			return flag;
		}

		/// <summary>
		///       快速设置元素的文本内容
		///       </summary>
		/// <param name="txt">文本</param>
		/// <returns>创建的元素对象列表</returns>
		public XTextElementList SetInnerTextFast(string string_14)
		{
			return SetInnerTextFastExt(string_14, null);
		}

		/// <summary>
		///       快速设置元素的文本内容
		///       </summary>
		/// <param name="txt">文本</param>
		/// <param name="newTextStyle">文本样式</param>
		/// <returns>创建的元素对象列表</returns>
		public virtual XTextElementList SetInnerTextFastExt(string string_14, DocumentContentStyle newTextStyle)
		{
			return SetInnerTextFastExt(string_14, newTextStyle, updateContentElements: true);
		}

		/// <summary>
		///       快速设置元素的文本内容
		///       </summary>
		/// <param name="txt">文本</param>
		/// <param name="newTextStyle">文本样式</param>
		/// <param name="updateContentElements">是否更新容器元素的状态,如果为false，则本函数能更快的执行。</param>
		/// <returns>创建的元素对象列表</returns>
		public virtual XTextElementList SetInnerTextFastExt(string string_14, DocumentContentStyle newTextStyle, bool updateContentElements)
		{
			if (Elements == null)
			{
				Elements = new XTextElementList();
			}
			DocumentContentStyle paragraphStyle = null;
			XTextParagraphFlagElement xTextParagraphFlagElement = null;
			if (LastContentElementInPublicContent != null)
			{
				xTextParagraphFlagElement = LastContentElementInPublicContent.OwnerParagraphEOF;
			}
			if (xTextParagraphFlagElement != null && xTextParagraphFlagElement.RuntimeStyle != null)
			{
				paragraphStyle = xTextParagraphFlagElement.RuntimeStyle.CloneParent();
			}
			XTextElement xTextElement = null;
			if (this is XTextContentElement && Elements.LastElement is XTextParagraphFlagElement)
			{
				xTextElement = Elements.LastElement;
			}
			XTextElementList xTextElementList;
			if (OwnerDocument == null)
			{
				xTextElementList = new XTextElementList();
				if (!string.IsNullOrEmpty(string_14))
				{
					int styleIndex = StyleIndex;
					if (Elements.Count > 0)
					{
						styleIndex = Elements[0].StyleIndex;
					}
					foreach (char c in string_14)
					{
						switch (c)
						{
						case '\r':
						{
							XTextParagraphFlagElement xTextParagraphFlagElement2 = new XTextParagraphFlagElement();
							if (xTextParagraphFlagElement != null)
							{
								xTextParagraphFlagElement2.StyleIndex = xTextParagraphFlagElement.StyleIndex;
							}
							xTextElementList.Add(xTextParagraphFlagElement2);
							break;
						}
						default:
						{
							XTextCharElement xTextCharElement = new XTextCharElement();
							xTextCharElement.StyleIndex = styleIndex;
							xTextCharElement.CharValue = c;
							xTextElementList.Add(xTextCharElement);
							break;
						}
						case '\n':
							break;
						}
					}
				}
				Elements = new XTextElementList();
				Elements.AddRange(xTextElementList);
				if (xTextElement != null)
				{
					Elements.Add(xTextElement);
				}
				_ContentVersion++;
				return xTextElementList;
			}
			if (newTextStyle == null)
			{
				newTextStyle = ((Elements.Count <= 0) ? RuntimeStyle.CloneWithoutBorder() : ((DocumentContentStyle)OwnerDocument.ContentStyles.GetStyle(Elements[0].StyleIndex)));
			}
			xTextElementList = OwnerDocument.CreateTextElementsExt(string_14, paragraphStyle, newTextStyle, RuntimeEnablePermission);
			lock (OwnerDocument)
			{
				if (xTextElementList != null && xTextElementList.Count > 0)
				{
					Elements.Clear();
					foreach (XTextElement item in xTextElementList)
					{
						item.SetParentRaw(this);
						Elements.AddRaw(item);
					}
					if (xTextElement != null)
					{
						Elements.Add(xTextElement);
					}
					if (ContentElement != null && updateContentElements && !UIIsUpdating)
					{
						XTextContentElement.Class11 @class = new XTextContentElement.Class11();
						@class.method_11(bool_5: true);
						@class.method_5(bool_5: true);
						@class.method_7(bool_5: true);
						ContentElement.vmethod_37(@class);
					}
					UpdateContentVersion();
				}
				else
				{
					Elements.Clear();
					if (xTextElement != null)
					{
						Elements.Add(xTextElement);
					}
					if (ContentElement != null && updateContentElements && !UIIsUpdating)
					{
						XTextContentElement.Class11 @class = new XTextContentElement.Class11();
						@class.method_11(bool_5: true);
						@class.method_5(bool_5: true);
						@class.method_7(bool_5: true);
						ContentElement.vmethod_37(@class);
					}
					UpdateContentVersion();
				}
			}
			if (OwnerDocument != null && !OwnerDocument.IsLoadingDocument && OwnerDocument.CopySourceExecuter != null)
			{
				OwnerDocument.CopySourceExecuter.imethod_2(this);
			}
			return xTextElementList;
		}

		/// <summary>
		///       直接设置DOM内容文本，不触发任何事件，不更新任何状态，速度最快。
		///       </summary>
		/// <param name="text">文本</param>
		/// <param name="textStyleIndex">文本样式编号</param>
		/// <param name="paragraphStyleIndex">段落样式编号</param>
		[ComVisible(true)]
		public void SetTextRawDOM(string text, int textStyleIndex, int paragraphStyleIndex)
		{
			if (text != null && text.Length != 0)
			{
				XTextElementList elements = Elements;
				if (textStyleIndex == -2)
				{
					textStyleIndex = ((elements.Count <= 0) ? StyleIndex : elements.LastElement.StyleIndex);
				}
				if (paragraphStyleIndex == -2)
				{
					paragraphStyleIndex = textStyleIndex;
				}
				XTextElement xTextElement = null;
				if (this is XTextContentElement && elements.LastElement is XTextParagraphFlagElement)
				{
					xTextElement = elements.LastElement;
				}
				elements.Clear();
				OwnerDocument.method_59(text, textStyleIndex, paragraphStyleIndex, elements);
				if (xTextElement != null)
				{
					elements.AddRaw(xTextElement);
				}
			}
		}

		private void method_24()
		{
		}

		[DCInternal]
		public override bool vmethod_3(GInterface5 ginterface5_0)
		{
			if (base.OwnerLine == null)
			{
				bool result = false;
				foreach (XTextElement element in Elements)
				{
					if (element.vmethod_3(ginterface5_0))
					{
						result = true;
						break;
					}
				}
				return result;
			}
			return base.OwnerLine.HtmlVisible;
		}

		[DCPublishAPI]
		public void method_25()
		{
			XTextContentElement contentElement = ContentElement;
			DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(this);
			foreach (XTextElement item in domTreeNodeEnumerable)
			{
				XTextElement xTextElement2 = item;
				if (xTextElement2 is XTextTableElement)
				{
					XTextTableElement xTextTableElement = (XTextTableElement)xTextElement2;
					foreach (XTextTableCellElement cell in xTextTableElement.Cells)
					{
						cell.Width = 0f;
						cell.Height = 0f;
					}
					xTextTableElement.ExecuteLayout();
					domTreeNodeEnumerable.CancelChild();
				}
				else if (xTextElement2 is XTextSectionElement)
				{
					XTextSectionElement xTextSectionElement = (XTextSectionElement)xTextElement2;
					xTextSectionElement.ExecuteLayout();
					domTreeNodeEnumerable.CancelChild();
				}
			}
			XTextElement currentElement = base.DocumentContentElement.CurrentElement;
			XTextElement xTextElement3 = FirstContentElement;
			if (this is XTextContentElement)
			{
				xTextElement3 = ((XTextContentElement)this).PrivateContent.FirstElement;
			}
			if (xTextElement3 == null)
			{
				xTextElement3 = this;
			}
			while (xTextElement3 != null && !contentElement.PrivateContent.Contains(xTextElement3))
			{
				xTextElement3 = xTextElement3.Parent;
			}
			XTextElement xTextElement4 = contentElement.PrivateContent.GetPreElement(xTextElement3);
			if (xTextElement4 == null)
			{
				xTextElement4 = xTextElement3;
			}
			XTextElement xTextElement5 = LastContentElement;
			while (xTextElement5 != null && !contentElement.PrivateContent.Contains(xTextElement5))
			{
				xTextElement5 = xTextElement5.Parent;
			}
			XTextElement xTextElement6 = contentElement.PrivateContent.GetNextElement(xTextElement5);
			if (xTextElement6 == null)
			{
				xTextElement6 = xTextElement5;
			}
			int num = contentElement.PrivateContent.IndexOf(xTextElement6);
			for (int i = contentElement.PrivateContent.IndexOf(xTextElement4); i <= num; i++)
			{
				if (contentElement.PrivateContent[i].OwnerLine != null)
				{
					contentElement.PrivateContent[i].OwnerLine.InvalidateState = true;
				}
			}
			UpdateContentVersion();
			contentElement.vmethod_36(bool_22: true);
			contentElement.vmethod_38(contentElement.PrivateContent.IndexOf(xTextElement4), contentElement.PrivateContent.IndexOf(xTextElement6), bool_22: false);
			XTextDocumentContentElement documentContentElement = base.DocumentContentElement;
			documentContentElement.method_70();
			if (currentElement != null)
			{
				documentContentElement.Content.AutoClearSelection = true;
				documentContentElement.Content.LineEndFlag = false;
				int viewIndex = currentElement.ViewIndex;
				documentContentElement.Content.MoveToPosition(viewIndex);
			}
		}

		/// <summary>
		///       在编辑器中删除整个对象,但保留其内容
		///       </summary>
		/// <param name="logUndo">是否记录撤销操作信息</param>
		[DCPublishAPI]
		public virtual bool EditorDeletePreserveContent(bool logUndo)
		{
			if (this is XTextDocumentContentElement)
			{
				return false;
			}
			XTextContainerElement parent = Parent;
			int int_ = parent.Elements.IndexOf(this);
			XTextDocument ownerDocument = OwnerDocument;
			if (logUndo)
			{
				ownerDocument.BeginLogUndo();
			}
			GEventArgs4 gEventArgs = new GEventArgs4(parent, int_, 1, null, logUndo, bool_11: true, bool_12: true);
			gEventArgs.method_21(bool_10: false);
			int num = ownerDocument.method_63(gEventArgs);
			if (num > 0)
			{
				gEventArgs.method_21(bool_10: true);
				gEventArgs.method_13(0);
				gEventArgs.method_15(Elements);
				num = ownerDocument.method_63(gEventArgs);
			}
			if (logUndo)
			{
				ownerDocument.EndLogUndo();
			}
			return num != 0;
		}

		/// <summary>
		///       在编辑器中删除整个对象
		///       </summary>
		/// <param name="logUndo">是否记录撤销操作信息</param>
		[DCPublishAPI]
		public virtual bool EditorDelete(bool logUndo)
		{
			if (this is XTextDocumentContentElement)
			{
				return false;
			}
			if (OwnerDocument == null)
			{
				throw new Exception(WriterStringsCore.OwnerDocumentNUll);
			}
			if (!BelongToDocumentDom(OwnerDocument, checkLogicDelete: false))
			{
				return false;
			}
			XTextContainerElement parent = Parent;
			int int_ = parent.Elements.IndexOf(this);
			XTextDocument ownerDocument = OwnerDocument;
			if (logUndo)
			{
				ownerDocument.BeginLogUndo();
			}
			int num = ownerDocument.method_63(new GEventArgs4(parent, int_, 1, null, logUndo, bool_11: true, bool_12: true));
			if (logUndo)
			{
				ownerDocument.EndLogUndo();
			}
			if (num > 0 && !logUndo)
			{
				ownerDocument.UndoList.Clear();
			}
			return num != 0;
		}

		/// <summary>
		///       设置文档内容的样式,本操作受到文档内容保护机制的限制。
		///       </summary>
		/// <param name="newStyle">新样式</param>
		/// <param name="logUndo">是否记录撤销操作信息</param>
		[ComVisible(true)]
		[DCPublishAPI]
		public virtual void EditorSetContentStyle(DocumentContentStyle newStyle, bool logUndo)
		{
			int num = 7;
			if (newStyle == null)
			{
				throw new ArgumentNullException("newStyle");
			}
			if (OwnerDocument == null)
			{
				throw new Exception(WriterStringsCore.OwnerDocumentNUll);
			}
			XTextElementList xTextElementList = new XTextElementList();
			xTextElementList.Add(this);
			vmethod_32(xTextElementList, bool_17: true);
			if (logUndo)
			{
				OwnerDocument.BeginLogUndo();
			}
			bool flag = XTextSelection.smethod_0(newStyle, newStyle, newStyle, OwnerDocument, xTextElementList, bool_1: true, null, logUndo);
			if (logUndo)
			{
				OwnerDocument.EndLogUndo();
			}
			if (flag)
			{
				OwnerDocument.CurrentStyleInfo = null;
				OwnerDocument.OnSelectionChanged();
				OwnerDocument.OnDocumentContentChanged();
			}
		}

		/// <summary>
		///       快速设置文档内容的样式，不记录撤销操作信息，不更新文档视图，不触发事件
		///       </summary>
		/// <param name="newStyle">新样式</param>
		[DCPublishAPI]
		[ComVisible(true)]
		public virtual bool EditorSetContentStyleFast(DocumentContentStyle newStyle)
		{
			int num = 15;
			if (newStyle == null)
			{
				throw new ArgumentNullException("newStyle");
			}
			if (OwnerDocument == null)
			{
				throw new Exception(WriterStringsCore.OwnerDocumentNUll);
			}
			FixDomState();
			XTextElementList xTextElementList = new XTextElementList();
			xTextElementList.Add(this);
			vmethod_32(xTextElementList, bool_17: true);
			bool result;
			if (result = XTextSelection.smethod_0(newStyle, newStyle, newStyle, OwnerDocument, xTextElementList, bool_1: false, null, bool_2: false))
			{
				OwnerDocument.CurrentStyleInfo = null;
			}
			return result;
		}

		public virtual void vmethod_35()
		{
			int num = 0;
			foreach (XTextElement element in Elements)
			{
				element.ElementIndex = num;
				if (element is XTextContainerElement)
				{
					((XTextContainerElement)element).vmethod_35();
				}
				num++;
			}
		}

		/// <summary>
		///       修复DOM结构状态
		///       </summary>
		[DCInternal]
		public override void FixDomState()
		{
			XTextDocument ownerDocument = OwnerDocument;
			if (xtextElementList_1 != null && xtextElementList_1.Count > 0)
			{
				xtextElementList_0.bool_0 = false;
				if (!method_18(bool_17: false))
				{
				}
				WriterUtils.smethod_62(Elements, bool_2: false);
			}
			if (xtextElementList_0 != null && xtextElementList_0.Count > 0)
			{
				int num = 0;
				WriterUtils.smethod_62(Elements, bool_2: false);
				foreach (XTextElement element in Elements)
				{
					element.ElementIndex = num;
					num++;
					element.SetParentRaw(this);
					element.method_5(ownerDocument);
					if (!(element is XTextCharElement) && !(element is XTextParagraphFlagElement))
					{
						element.FixDomState();
					}
				}
			}
		}
	}
}
