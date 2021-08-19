using DCSoft.Common;
using DCSoft.Data;
using DCSoft.Writer.Data;
using DCSoft.Writer.Expression;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       基础的纯文本数据输入域,DCWriter内部使用。
	///       </summary>
	[Serializable]
	[DCInternal]
	[DebuggerDisplay("Base Input Name:{Name}")]
	[Guid("00012345-6789-ABCD-EF01-23456789001F")]
	[XmlType("XInputFieldBase")]
	[DocumentComment]
	public class XTextInputFieldElementBase : XTextFieldElementBase, IContentReadonlyable
	{
		private DCBorderTextPosition dcborderTextPosition_0 = DCBorderTextPosition.Middle;

		private DCFastInputMode dcfastInputMode_0 = DCFastInputMode.NextField;

		private bool bool_17 = true;

		private MoveFocusHotKeys moveFocusHotKeys_0 = MoveFocusHotKeys.Default;

		private int int_10 = 0;

		private float float_5 = 0f;

		private StringAlignment stringAlignment_0 = StringAlignment.Near;

		private string string_16 = null;

		private EventExpressionInfoList eventExpressionInfoList_0 = null;

		private string string_17 = null;

		private string string_18 = null;

		private bool bool_18 = true;

		private string string_19 = null;

		private ValueFormater valueFormater_0 = null;

		[NonSerialized]
		private DataSourceTreeNode dataSourceTreeNode_1 = null;

		[NonSerialized]
		private DataSourceTreeNode dataSourceTreeNode_2 = null;

		private string string_20 = null;

		private string string_21 = null;

		private DCBooleanValue dcbooleanValue_1 = DCBooleanValue.Inherit;

		private string string_22 = null;

		private ContentViewEncryptType contentViewEncryptType_0 = ContentViewEncryptType.None;

		[NonSerialized]
		private int int_11 = 0;

		[NonSerialized]
		private int int_12 = 0;

		private int int_13 = 0;

		[NonSerialized]
		private float float_6 = 0f;

		[NonSerialized]
		[Browsable(false)]
		[XmlIgnore]
		[DCInternal]
		public EventHandler eventHandler_0 = null;

		private DCVisibleState dcvisibleState_0 = DCVisibleState.Default;

		private EnableState enableState_0 = EnableState.Enabled;

		[NonSerialized]
		private bool bool_19 = false;

		[XmlIgnore]
		[MemberExpressionable(MemberEffectLevel.DOM)]
		[Browsable(false)]
		[DCPublishAPI]
		public override string FormulaValue
		{
			get
			{
				if (string.IsNullOrEmpty(InnerValue))
				{
					return Text;
				}
				return InnerValue;
			}
			set
			{
				base.FormulaValue = vmethod_39(value, bool_20: false);
			}
		}

		/// <summary>
		///       边框文本对齐方式
		///       </summary>
		[HtmlAttribute]
		[MemberExpressionable]
		[DCPublishAPI]
		[ComVisible(true)]
		[DefaultValue(DCBorderTextPosition.Middle)]
		public DCBorderTextPosition BorderTextPosition
		{
			get
			{
				return dcborderTextPosition_0;
			}
			set
			{
				dcborderTextPosition_0 = value;
			}
		}

		/// <summary>
		///       快速录入方式
		///       </summary>
		[ComVisible(true)]
		[DCPublishAPI]
		[DefaultValue(DCFastInputMode.NextField)]
		[HtmlAttribute]
		[MemberExpressionable]
		public DCFastInputMode FastInputMode
		{
			get
			{
				return dcfastInputMode_0;
			}
			set
			{
				dcfastInputMode_0 = value;
			}
		}

		/// <summary>
		///       获取或设置一个值，该值指示用户能否使用 Tab 键将焦点放到该元素中上。 
		///       </summary>
		[HtmlAttribute]
		[DefaultValue(true)]
		[DCPublishAPI]
		[MemberExpressionable]
		public bool TabStop
		{
			get
			{
				return bool_17;
			}
			set
			{
				bool_17 = value;
			}
		}

		/// <summary>
		///       获取或设置一个运行时的值，该值指示用户能否使用 Tab 键将焦点放到该元素中上。 
		///       </summary>
		public override bool RuntimeTabStop => TabStop;

		/// <summary>
		///       移动焦点使用的快捷键
		///       </summary>
		[MemberExpressionable]
		[DCPublishAPI]
		[HtmlAttribute]
		[DefaultValue(MoveFocusHotKeys.Default)]
		public MoveFocusHotKeys MoveFocusHotKey
		{
			get
			{
				return moveFocusHotKeys_0;
			}
			set
			{
				moveFocusHotKeys_0 = (MoveFocusHotKeys)WriterUtils.FixEnumValue(value);
			}
		}

		/// <summary>
		///       实际使用的移动焦点所使用的快捷键样式
		///       </summary>
		[HtmlAttribute]
		[ReadOnly(true)]
		[Browsable(false)]
		[DefaultValue(MoveFocusHotKeys.None)]
		[XmlIgnore]
		public override MoveFocusHotKeys RuntimeMoveFocusHotKey
		{
			get
			{
				MoveFocusHotKeys moveFocusHotKeys = MoveFocusHotKey;
				if (moveFocusHotKeys == MoveFocusHotKeys.Default && OwnerDocument != null)
				{
					moveFocusHotKeys = OwnerDocument.Options.BehaviorOptions.MoveFocusHotKey;
				}
				if (moveFocusHotKeys == MoveFocusHotKeys.Default)
				{
					moveFocusHotKeys = MoveFocusHotKeys.None;
				}
				return moveFocusHotKeys;
			}
			set
			{
			}
		}

		/// <summary>
		///       是否为最顶端的输入域对象
		///       </summary>
		[Browsable(false)]
		public bool IsTopLevelField => GetOwnerParent(typeof(XTextInputFieldElementBase), includeThis: false) == null;

		/// <summary>
		///       焦点切换序号
		///       </summary>
		[HtmlAttribute]
		[MemberExpressionable]
		[DefaultValue(0)]
		[DCPublishAPI]
		public int TabIndex
		{
			get
			{
				return int_10;
			}
			set
			{
				int_10 = value;
			}
		}

		/// <summary>
		///       输入域指定宽度,若大于0则输入域宽度不小于该值，而且当内容很多时，自动变宽。
		///       </summary>
		[DefaultValue(0f)]
		[DCPublishAPI]
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		[HtmlAttribute]
		public float SpecifyWidth
		{
			get
			{
				return float_5;
			}
			set
			{
				float_5 = value;
			}
		}

		internal float RuntimeSpecifyWidth
		{
			get
			{
				if (XTextDocument.smethod_13(GEnum6.const_164))
				{
					return float_5;
				}
				return 0f;
			}
		}

		/// <summary>
		///       内容对齐方式
		///       </summary>
		[DCPublishAPI]
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		[ComVisible(true)]
		[DefaultValue(StringAlignment.Near)]
		[HtmlAttribute]
		public StringAlignment Alignment
		{
			get
			{
				return stringAlignment_0;
			}
			set
			{
				stringAlignment_0 = value;
			}
		}

		/// <summary>
		///       运行时使用的内容对齐方式
		///       </summary>
		private StringAlignment RuntimeAlignment => Alignment;

		/// <summary>
		///       内容只读
		///       </summary>
		[DefaultValue(false)]
		[Obsolete("!!!!请使用 ContentReadonly 或 RuntimeContentReadonly 属性。")]
		[DCPublishAPI]
		public bool Readonly
		{
			get
			{
				return ContentReadonly == ContentReadonlyState.True;
			}
			set
			{
				if (value)
				{
					ContentReadonly = ContentReadonlyState.True;
				}
				else
				{
					ContentReadonly = ContentReadonlyState.False;
				}
			}
		}

		/// <summary>
		///       内容是否可编辑
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		public override bool ContentEditable => !RuntimeContentReadonly;

		/// <summary>
		///       默认使用的事件表达式字符串
		///       </summary>
		[DefaultValue(null)]
		[HtmlAttribute]
		[DCPublishAPI]
		public string DefaultEventExpression
		{
			get
			{
				return string_16;
			}
			set
			{
				string_16 = value;
			}
		}

		/// <summary>
		///       事件表达式列表
		///       </summary>
		[Browsable(true)]
		[DCPublishAPI]
		[XmlArrayItem("Expression", typeof(EventExpressionInfo))]
		[DefaultValue(null)]
		public EventExpressionInfoList EventExpressions
		{
			get
			{
				if (eventExpressionInfoList_0 == null && DocumentBehaviorOptions.StaticAutoCreateInstanceInProperty)
				{
					eventExpressionInfoList_0 = new EventExpressionInfoList();
				}
				return eventExpressionInfoList_0;
			}
			set
			{
				eventExpressionInfoList_0 = value;
			}
		}

		/// <summary>
		///       运行时使用的事件表达式列表
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public virtual EventExpressionInfoList RuntimeEventExpressions
		{
			get
			{
				EventExpressionInfoList eventExpressionInfoList = null;
				if (!string.IsNullOrEmpty(DefaultEventExpression))
				{
					eventExpressionInfoList = new EventExpressionInfoList();
					EventExpressionInfo eventExpressionInfo = new EventExpressionInfo();
					eventExpressionInfo.Expression = DefaultEventExpression;
					eventExpressionInfoList.Add(eventExpressionInfo);
					if (EventExpressions != null)
					{
						eventExpressionInfoList.AddRange(EventExpressions);
					}
					return eventExpressionInfoList;
				}
				return EventExpressions;
			}
		}

		/// <summary>
		///       单位文本
		///       </summary>
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		[HtmlAttribute]
		[DefaultValue(null)]
		[DCPublishAPI]
		public string UnitText
		{
			get
			{
				return string_17;
			}
			set
			{
				string_17 = value;
			}
		}

		internal string RuntimeUnitText
		{
			get
			{
				if (XTextDocument.smethod_13(GEnum6.const_162))
				{
					return string_17;
				}
				return null;
			}
		}

		/// <summary>
		///       标签文本
		///       </summary>
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		[DCPublishAPI]
		[HtmlAttribute]
		[DefaultValue(null)]
		public string LabelText
		{
			get
			{
				return string_18;
			}
			set
			{
				string_18 = value;
			}
		}

		internal string RuntimeLabelText
		{
			get
			{
				if (XTextDocument.smethod_13(GEnum6.const_161))
				{
					return string_18;
				}
				return null;
			}
		}

		/// <summary>
		///       用户可以直接修改文本域中的内容
		///       </summary>
		[DefaultValue(true)]
		[DCPublishAPI]
		[MemberExpressionable]
		[HtmlAttribute]
		public bool UserEditable
		{
			get
			{
				return bool_18;
			}
			set
			{
				bool_18 = value;
			}
		}

		internal bool RuntimeUserEditable
		{
			get
			{
				if (XTextDocument.smethod_13(GEnum6.const_175))
				{
					return bool_18;
				}
				return true;
			}
		}

		/// <summary>
		///       对象名称
		///       </summary>
		[DefaultValue(null)]
		[DCPublishAPI]
		public string Name
		{
			get
			{
				return string_19;
			}
			set
			{
				string_19 = value;
			}
		}

		/// <summary>
		///       对象文本
		///       </summary>
		[Browsable(true)]
		[XmlIgnore]
		[ReadOnly(true)]
		[DCPublishAPI]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override string OuterText
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder();
				bool flag;
				if ((flag = (OwnerDocument == null || OwnerDocument.Options.BehaviorOptions.OutputFieldBorderTextToContentText)) && !string.IsNullOrEmpty(base.RuntimeStartBorderText))
				{
					stringBuilder.Append(base.RuntimeStartBorderText);
				}
				if (!string.IsNullOrEmpty(RuntimeLabelText))
				{
					stringBuilder.Append(RuntimeLabelText);
				}
				stringBuilder.Append(base.InnerText);
				if (!string.IsNullOrEmpty(RuntimeUnitText))
				{
					stringBuilder.Append(RuntimeUnitText);
				}
				if (flag && !string.IsNullOrEmpty(base.RuntimeEndBorderText))
				{
					stringBuilder.Append(base.RuntimeEndBorderText);
				}
				return stringBuilder.ToString();
			}
			set
			{
				base.Text = value;
			}
		}

		/// <summary>
		///       显示的名称
		///       </summary>
		[Browsable(false)]
		public string DisplayName
		{
			get
			{
				if (!string.IsNullOrEmpty(base.ID))
				{
					return base.ID;
				}
				return Name;
			}
		}

		/// <summary>
		///       显示的格式化对象
		///       </summary>
		[HtmlAttribute]
		[DefaultValue(null)]
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		[DCPublishAPI]
		public ValueFormater DisplayFormat
		{
			get
			{
				if (valueFormater_0 == null && DocumentBehaviorOptions.StaticAutoCreateInstanceInProperty)
				{
					valueFormater_0 = new ValueFormater();
				}
				return valueFormater_0;
			}
			set
			{
				valueFormater_0 = value;
			}
		}

		internal ValueFormater RuntimeDisplayFormat
		{
			get
			{
				if (XTextDocument.smethod_13(GEnum6.const_181))
				{
					return DisplayFormat;
				}
				return null;
			}
		}

		/// <summary>
		///       扩展提示文本
		///       </summary>
		[Browsable(false)]
		public override string RuntimeAdornText
		{
			get
			{
				int num = 15;
				if (base.HasValueBinding && !base.ValueBinding.IsEmptyBinding)
				{
					return base.ValueBinding.DataSource + "#" + base.ValueBinding.BindingPath;
				}
				return null;
			}
		}

		[DCInternal]
		[Browsable(false)]
		public virtual bool HasDisplayTextFormat => RuntimeDisplayFormat != null && !RuntimeDisplayFormat.IsEmpty;

		[DCInternal]
		internal DataSourceTreeNode DataSourceNodeForWriteText
		{
			get
			{
				return dataSourceTreeNode_1;
			}
			set
			{
				dataSourceTreeNode_1 = value;
			}
		}

		[DCInternal]
		internal DataSourceTreeNode DataSourceNodeForText
		{
			get
			{
				return dataSourceTreeNode_2;
			}
			set
			{
				dataSourceTreeNode_2 = value;
			}
		}

		/// <summary>
		///       选择项目时使用的拼音码
		///       </summary>
		[ComVisible(true)]
		[MemberExpressionable(MemberEffectLevel.DOM)]
		[XmlElement]
		[DCPublishAPI]
		[DefaultValue(null)]
		[ReadOnly(true)]
		public string SelectedSpellCode
		{
			get
			{
				return string_20;
			}
			set
			{
				string_20 = value;
			}
		}

		/// <summary>
		///       内置的数值
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(null)]
		[HtmlAttribute]
		[MemberExpressionable(MemberEffectLevel.DOM)]
		public string InnerValue
		{
			get
			{
				return string_21;
			}
			set
			{
				string_21 = value;
			}
		}

		/// <summary>
		///       打印背景文字
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(DCBooleanValue.Inherit)]
		[HtmlAttribute]
		public DCBooleanValue PrintBackgroundText
		{
			get
			{
				return dcbooleanValue_1;
			}
			set
			{
				dcbooleanValue_1 = value;
			}
		}

		/// <summary>
		///       运行时的是否打印背景文字
		///       </summary>
		[DCInternal]
		public override bool RuntimePrintBackgroundText
		{
			get
			{
				if (PrintBackgroundText == DCBooleanValue.False)
				{
					return false;
				}
				if (PrintBackgroundText == DCBooleanValue.True)
				{
					return true;
				}
				if (OwnerDocument != null)
				{
					return OwnerDocument.Options.ViewOptions.PrintBackgroundText;
				}
				return true;
			}
		}

		/// <summary>
		///       背景文本
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(null)]
		[HtmlAttribute]
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		public string BackgroundText
		{
			get
			{
				return string_22;
			}
			set
			{
				string_22 = value;
				base.InnerBackgroundTextElements = null;
			}
		}

		/// <summary>
		///       运行时使用的背景文字
		///       </summary>
		internal override string RuntimeBackgroundText
		{
			get
			{
				if (XTextDocument.smethod_13(GEnum6.const_163))
				{
					return BackgroundText;
				}
				return null;
			}
		}

		/// <summary>
		///       内容加密等级
		///       </summary>
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		[Category("Appearance")]
		[DCPublishAPI]
		[DefaultValue(ContentViewEncryptType.None)]
		[HtmlAttribute]
		public ContentViewEncryptType ViewEncryptType
		{
			get
			{
				return contentViewEncryptType_0;
			}
			set
			{
				contentViewEncryptType_0 = (ContentViewEncryptType)WriterUtils.FixEnumValue(value);
			}
		}

		/// <summary>
		///       第一个显示的内容元素编号
		///       </summary>
		internal int StartContentElementIndex => int_11;

		/// <summary>
		///       最后一个显示的内容元素编号
		///       </summary>
		internal int EndContentElementIndex => int_12;

		/// <summary>
		///       内容元素个数
		///       </summary>
		internal int ContentElementCount => int_13;

		/// <summary>
		///       数据校验结果中使用的名称
		///       </summary>
		protected override string NameForValidateResult
		{
			get
			{
				string iD = base.ID;
				iD = RuntimeLabelText;
				if (string.IsNullOrEmpty(iD))
				{
					iD = Name;
				}
				if (string.IsNullOrEmpty(iD))
				{
					iD = RuntimeBackgroundText;
				}
				return iD;
			}
		}

		/// <summary>
		///       边框元素是否可见
		///       </summary>
		[DefaultValue(DCVisibleState.Default)]
		[DCPublishAPI]
		[HtmlAttribute]
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		public DCVisibleState BorderVisible
		{
			get
			{
				return dcvisibleState_0;
			}
			set
			{
				dcvisibleState_0 = value;
			}
		}

		/// <summary>
		///       是否允许高亮度显示状态
		///       </summary>
		[HtmlAttribute]
		[DCPublishAPI]
		[DefaultValue(EnableState.Enabled)]
		[MemberExpressionable(MemberEffectLevel.ElementView)]
		public virtual EnableState EnableHighlight
		{
			get
			{
				return enableState_0;
			}
			set
			{
				enableState_0 = (EnableState)WriterUtils.FixEnumValue(value);
			}
		}

		/// <summary>
		///       运行时的是否允许高亮度显示模式
		///       </summary>
		[Browsable(false)]
		[HtmlAttribute]
		public EnableState RuntimeEnableHighlight
		{
			get
			{
				EnableState enableState = EnableHighlight;
				if (enableState == EnableState.Default && OwnerDocument != null)
				{
					enableState = OwnerDocument.Options.ViewOptions.DefaultInputFieldHighlight;
				}
				if (enableState == EnableState.Default)
				{
					enableState = EnableState.Enabled;
				}
				return enableState;
			}
		}

		/// <summary>
		///       当前高亮度状态
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		[XmlIgnore]
		public bool CurrentHighlightState
		{
			get
			{
				return bool_19;
			}
			set
			{
				bool_19 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		protected XTextInputFieldElementBase()
		{
			base.EnableValueValidate = true;
		}

		public override bool vmethod_27(GClass108 gclass108_0, int int_14)
		{
			if (RuntimeContentReadonly && !OwnerDocument.DocumentControler.IsAdministrator)
			{
				if (gclass108_0 != null && gclass108_0.Count > 0)
				{
					gclass108_0.method_0(this, WriterStringsCore.ReadonlyContainerReadonly, gclass108_0[0].Reason);
				}
				return true;
			}
			if (Elements == null || Elements.Count == 0)
			{
				return false;
			}
			return base.vmethod_27(gclass108_0, int_14);
		}

		internal virtual bool vmethod_37(XTextFieldBorderElement xtextFieldBorderElement_2)
		{
			xtextFieldBorderElement_2.bool_5 = false;
			float num = Math.Abs(RuntimeSpecifyWidth);
			if (num > 0f)
			{
				XTextElementList xTextElementList = new XTextElementList();
				vmethod_32(xTextElementList, bool_20: true);
				if (xTextElementList.Contains(xtextFieldBorderElement_2))
				{
					float num2 = 0f;
					foreach (XTextElement item in xTextElementList)
					{
						num2 = ((!(item is XTextFieldBorderElement) || item.Parent != this) ? (num2 + item.Width) : (num2 + ((XTextFieldBorderElement)item).ContentWidth));
					}
					if (num > num2)
					{
						float num3 = num - num2;
						xtextFieldBorderElement_2.bool_5 = true;
						if (xtextFieldBorderElement_2 == base.StartElement)
						{
							switch (RuntimeAlignment)
							{
							case StringAlignment.Near:
								xtextFieldBorderElement_2.Width = xtextFieldBorderElement_2.ContentWidth;
								break;
							case StringAlignment.Center:
								xtextFieldBorderElement_2.Width = xtextFieldBorderElement_2.ContentWidth + num3 / 2f;
								break;
							case StringAlignment.Far:
								xtextFieldBorderElement_2.Width = xtextFieldBorderElement_2.ContentWidth + num3;
								break;
							}
						}
						else
						{
							switch (RuntimeAlignment)
							{
							case StringAlignment.Near:
								xtextFieldBorderElement_2.Width = xtextFieldBorderElement_2.ContentWidth + num3;
								break;
							case StringAlignment.Center:
								xtextFieldBorderElement_2.Width = xtextFieldBorderElement_2.ContentWidth + num3 / 2f;
								break;
							case StringAlignment.Far:
								xtextFieldBorderElement_2.Width = xtextFieldBorderElement_2.ContentWidth;
								break;
							}
						}
						return true;
					}
					xtextFieldBorderElement_2.Width = xtextFieldBorderElement_2.ContentWidth;
					xtextFieldBorderElement_2.Width = xtextFieldBorderElement_2.ContentWidth;
					return true;
				}
			}
			return false;
		}

		/// <summary>
		///       处理文档事件
		///       </summary>
		/// <param name="args">
		/// </param>
		public override void HandleDocumentEvent(DocumentEventArgs args)
		{
			if (args.Style == DocumentEventStyles.LostFocus && !OwnerDocument.States.ExecutingRedo && !OwnerDocument.States.ExecutingUndo && Modified)
			{
				string text = vmethod_40(Text);
				if (text != Text)
				{
					base.EditorTextExt = text;
				}
			}
			base.HandleDocumentEvent(args);
		}

		/// <summary>
		///       获得下一个可以获得焦点的输入域对象
		///       </summary>
		/// <returns>
		/// </returns>
		[ComVisible(true)]
		public XTextInputFieldElementBase GetNextFocusFieldElement()
		{
			XTextInputFieldElementBase xTextInputFieldElementBase = this;
			do
			{
				xTextInputFieldElementBase = (XTextInputFieldElementBase)OwnerDocument.GetNextElement(xTextInputFieldElementBase, typeof(XTextInputFieldElementBase), includeHiddenElement: false);
			}
			while (xTextInputFieldElementBase != null && !xTextInputFieldElementBase.TabStop);
			return xTextInputFieldElementBase;
		}

		/// <summary>
		///       文档加载后的处理
		///       </summary>
		/// <param name="args">参数</param>
		public override void AfterLoad(ElementLoadEventArgs args)
		{
			base.AfterLoad(args);
			if (args.UpdateValueBinding && RuntimeSupportValueBinding && base.ValueBinding != null && base.ValueBinding.AutoUpdate)
			{
				UpdateDataBindingArgs updateDataBindingArgs = new UpdateDataBindingArgs();
				updateDataBindingArgs.FastMode = true;
				UpdateDataBindingExt(updateDataBindingArgs);
			}
			if (HasDisplayTextFormat)
			{
				string text = Text;
				string text2 = vmethod_40(text);
				if (text2 != text)
				{
					SetInnerTextFast(text2);
				}
			}
		}

		[DCInternal]
		public virtual string vmethod_38(string string_23)
		{
			return string_23;
		}

		[DCInternal]
		public virtual string vmethod_39(string string_23, bool bool_20)
		{
			return string_23;
		}

		public virtual string vmethod_40(string string_23)
		{
			if (RuntimeDisplayFormat != null && !RuntimeDisplayFormat.IsEmpty)
			{
				string_23 = RuntimeDisplayFormat.Execute(string_23);
			}
			return string_23;
		}

		/// <summary>
		///       更新数据源
		///       </summary>
		/// <param name="dataSource">绑定的数据源对象</param>
		/// <param name="fastMode">快速模式</param>
		/// <returns>操作是否导致了文档内容发生改变</returns>
		public override int UpdateDataBindingExt(UpdateDataBindingArgs args)
		{
			if (!args.DetectValueModified)
			{
				dataSourceTreeNode_1 = null;
				base.DataBoundNodeValueUsed = false;
			}
			XDataBinding xDataBinding = RuntimeSupportValueBinding ? base.ValueBinding : null;
			if (OwnerDocument.method_104(xDataBinding) && RuntimeSupportValueBinding)
			{
				if (!args.CheckForSpecifyParameterName(xDataBinding))
				{
					return 0;
				}
				if (!args.DetectValueModified)
				{
					xDataBinding.Handled = true;
					dataSourceTreeNode_2 = null;
				}
				DataSourceTreeNode dataSourceTreeNode = method_2(xDataBinding, args);
				if (!args.DetectValueModified)
				{
					base.DataBoundNode = dataSourceTreeNode;
				}
				XTextDocument ownerDocument = OwnerDocument;
				if (!ownerDocument.Options.BehaviorOptions.EnableDataBinding)
				{
					return 0;
				}
				int result = 0;
				object obj = null;
				object obj2 = null;
				if (!(dataSourceTreeNode?.IsEmpty ?? true))
				{
					obj = dataSourceTreeNode.RuntimeDisplayValue;
				}
				bool flag = false;
				if (obj == null || DBNull.Value.Equals(obj))
				{
					flag = true;
				}
				else if (obj is float)
				{
					if (float.IsNaN((float)obj))
					{
						flag = true;
					}
				}
				else if (obj is double && double.IsNaN((double)obj))
				{
					flag = true;
				}
				if (args.DetectValueModified)
				{
					string text = flag ? null : Convert.ToString(obj);
					if (string.IsNullOrEmpty(text))
					{
						text = null;
					}
					string text2 = InnerValue;
					if (string.Equals(text2, base.DefaultValueForValueBinding))
					{
						text2 = null;
					}
					if (string.IsNullOrEmpty(text2))
					{
						text2 = null;
					}
					if (!string.Equals(text, text2))
					{
						DetectResultForValueBindingModified item = new DetectResultForValueBindingModified(base.ValueBinding, this, text2, text);
						args.AddDetectResult(item);
					}
					return 0;
				}
				if (!flag)
				{
					if (!string.IsNullOrEmpty(xDataBinding.BindingPathForText))
					{
						dataSourceTreeNode_2 = method_3(xDataBinding.DataSource, xDataBinding.BindingPathForText, args);
						obj2 = ((dataSourceTreeNode_2 == null) ? vmethod_39(Convert.ToString(obj), bool_20: false) : Convert.ToString(dataSourceTreeNode_2.RuntimeDisplayValue));
					}
					else
					{
						obj2 = vmethod_39(Convert.ToString(obj), bool_20: false);
					}
				}
				else
				{
					obj2 = null;
				}
				args.AddHandledElement(this);
				if (flag)
				{
					if (method_30(null, null, args.FastMode))
					{
						base.DataBoundNodeValueUsed = true;
						result = 1;
					}
				}
				else if (method_30(Convert.ToString(obj2), Convert.ToString(obj), args.FastMode))
				{
					base.DataBoundNodeValueUsed = true;
					result = 1;
				}
				if (!string.IsNullOrEmpty(xDataBinding.WriteTextBindingPath))
				{
					dataSourceTreeNode_1 = method_3(xDataBinding.DataSource, xDataBinding.WriteTextBindingPath, args);
				}
				if (base.DataFeedback != null)
				{
					if (!base.DataFeedback.IsEmpty && !base.DataFeedback.IsEmpty && !string.IsNullOrEmpty(base.DataFeedback.KeyFeildDataSourcePath))
					{
						DataSourceTreeNode dataSourceTreeNode2 = method_2(xDataBinding, args, base.DataFeedback.KeyFeildDataSourcePath);
						if (dataSourceTreeNode2 != null)
						{
							base.DataFeedback.KeyFieldValue = Convert.ToString(dataSourceTreeNode2.RuntimeDisplayValue);
						}
					}
					base.DataFeedback.ContentVersion = base.ContentVersion;
				}
				if (xDataBinding.ProcessState == DCProcessStates.Once)
				{
					xDataBinding.ProcessState = DCProcessStates.Never;
				}
				return result;
			}
			return base.UpdateDataBindingExt(args);
		}

		[DCInternal]
		private bool method_30(string string_23, string string_24, bool bool_20)
		{
			if (string.IsNullOrEmpty(string_24))
			{
				InnerValue = "";
				string defaultValueForValueBinding = base.DefaultValueForValueBinding;
				SelectedSpellCode = null;
				if (bool_20 || Parent == null)
				{
					XTextElementList xTextElementList = SetInnerTextFastExt(defaultValueForValueBinding, null, updateContentElements: false);
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
					SetEditorTextExt(defaultValueForValueBinding, DomAccessFlags.None, disablePermissioin: true, updateContent: true);
				}
			}
			else
			{
				SelectedSpellCode = null;
				if (bool_20 || Parent == null)
				{
					XTextElementList xTextElementList = SetInnerTextFast(string_23);
					if (xTextElementList != null && xTextElementList.Count > 0)
					{
						DocumentContentStyle documentContentStyle = xTextElementList[0].RuntimeStyle.CloneParent();
						documentContentStyle.CreatorIndex = -1;
						documentContentStyle.DeleterIndex = -1;
						int styleIndex = OwnerDocument.ContentStyles.GetStyleIndex(documentContentStyle);
						foreach (XTextElement item2 in xTextElementList)
						{
							item2.StyleIndex = styleIndex;
						}
					}
				}
				else
				{
					SetEditorTextExt(string_23, DomAccessFlags.None, disablePermissioin: true, updateContent: true);
				}
				InnerValue = string_24;
			}
			vmethod_23(bool_20: true);
			int_7 = base.ContentVersion;
			return true;
		}

		[DCInternal]
		protected override bool vmethod_26(string string_23, bool bool_20)
		{
			if (string.IsNullOrEmpty(string_23))
			{
				return method_30(null, null, bool_20);
			}
			string string_24 = vmethod_39(string_23, bool_20: false);
			return method_30(string_24, string_23, bool_20);
		}

		[DCPublishAPI]
		public virtual FieldValueDescriptor vmethod_41()
		{
			FieldValueDescriptor fieldValueDescriptor = null;
			if (base.ValueBinding != null)
			{
				fieldValueDescriptor = new FieldValueDescriptor();
				fieldValueDescriptor.Readonly = base.ValueBinding.Readonly;
				fieldValueDescriptor.DataSource = base.ValueBinding.DataSource;
				fieldValueDescriptor.BindingPath = base.ValueBinding.BindingPath;
				fieldValueDescriptor.BindingPathForText = base.ValueBinding.BindingPathForText;
				fieldValueDescriptor.Element = this;
				fieldValueDescriptor.ID = base.ID;
				fieldValueDescriptor.Value = Text;
				fieldValueDescriptor.Name = Name;
				fieldValueDescriptor._ContentVersion = base.ContentVersion;
			}
			return fieldValueDescriptor;
		}

		[DCInternal]
		public virtual bool vmethod_42(FieldValueDescriptor fieldValueDescriptor_0, bool bool_20)
		{
			if (fieldValueDescriptor_0 != null)
			{
				XTextDocument ownerDocument = OwnerDocument;
				if (!ownerDocument.Options.BehaviorOptions.EnableDataBinding)
				{
					return false;
				}
				return vmethod_26(fieldValueDescriptor_0.Value, bool_20);
			}
			return false;
		}

		/// <summary>
		///       保持字段域数据到数据源中
		///       </summary>
		/// <returns>操作是否成功</returns>
		[DCInternal]
		[Obsolete("本方法已废除")]
		public virtual bool WriteDataSource()
		{
			return false;
		}

		/// <summary>
		///       快速设置输入域的文本内容
		///       </summary>
		/// <param name="txt">新的文本内容</param>
		/// <param name="newTextStyle">新文本使用的样式</param>
		/// <returns>操作生成的文档元素列表</returns>
		public override XTextElementList SetInnerTextFastExt(string string_23, DocumentContentStyle newTextStyle)
		{
			string string_24 = vmethod_40(string_23);
			return base.SetInnerTextFastExt(string_24, newTextStyle);
		}

		/// <summary>
		///       修正文档元素DOM结构
		///       </summary>
		public override void FixDomState()
		{
			base.FixDomState();
		}

		/// <summary>
		///       判断文档元素是否需要加密显示
		///       </summary>
		/// <param name="element">文档元素对象</param>
		/// <returns>是否需要加密显示</returns>
		[DCInternal]
		public bool IsEncrypt(XTextElement element)
		{
			ContentViewEncryptType contentViewEncryptType = ViewEncryptType;
			switch (contentViewEncryptType)
			{
			case ContentViewEncryptType.Partial:
				if (!XTextDocument.smethod_13(GEnum6.const_169))
				{
					contentViewEncryptType = ContentViewEncryptType.None;
				}
				break;
			case ContentViewEncryptType.Both:
				if (!XTextDocument.smethod_13(GEnum6.const_170))
				{
					contentViewEncryptType = ContentViewEncryptType.None;
				}
				break;
			}
			if (contentViewEncryptType == ContentViewEncryptType.None)
			{
				return false;
			}
			if (element == null)
			{
				return false;
			}
			if (element is XTextFieldBorderElement)
			{
				return false;
			}
			if (IsBackgroundTextElement(element))
			{
				return false;
			}
			switch (contentViewEncryptType)
			{
			case ContentViewEncryptType.Partial:
			{
				int count = Elements.Count;
				if (count <= 1)
				{
					return true;
				}
				int num = Elements.IndexOf(element);
				if (count == 2 && num == 1)
				{
					return true;
				}
				if (num == 0 || num == count - 1)
				{
					return false;
				}
				return true;
			}
			case ContentViewEncryptType.Both:
				return true;
			default:
				return false;
			}
		}

		/// <summary>
		///       刷新视图
		///       </summary>
		[DCPublishAPI]
		public override void EditorRefreshView()
		{
			if (base.InnerBackgroundTextElements != null && OwnerDocument.HighlightManager != null)
			{
				foreach (XTextElement innerBackgroundTextElement in base.InnerBackgroundTextElements)
				{
					OwnerDocument.HighlightManager.imethod_8(innerBackgroundTextElement);
				}
			}
			base.InnerBackgroundTextElements = null;
			string text = Text;
			string text2 = vmethod_40(text);
			if (text != text2)
			{
				SetInnerTextFast(text2);
				InnerValue = text2;
			}
			base.EditorRefreshView();
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int vmethod_32(XTextElementList xtextElementList_3, bool bool_20)
		{
			if (OwnerDocument != null)
			{
			}
			bool_13 = false;
			bool flag = true;
			XTextDocument ownerDocument = OwnerDocument;
			bool flag2;
			if (flag2 = ownerDocument.PrintingViewMode)
			{
				if (ownerDocument.Options.ViewOptions.IgnoreFieldBorderWhenPrint)
				{
					flag = false;
				}
				if (RuntimePrintBackgroundText || ownerDocument.Options.ViewOptions.PreserveBackgroundTextWhenPrint)
				{
					flag2 = false;
				}
			}
			bool flag3;
			if (!(flag3 = (flag || !string.IsNullOrEmpty(RuntimeLabelText) || !string.IsNullOrEmpty(base.RuntimeStartBorderText) || RuntimeSpecifyWidth != 0f)) && RuntimeSpecifyWidth != 0f && (Alignment == StringAlignment.Near || Alignment == StringAlignment.Center))
			{
				flag3 = true;
			}
			bool flag4;
			if (!(flag4 = (flag || !string.IsNullOrEmpty(RuntimeUnitText) || !string.IsNullOrEmpty(base.RuntimeEndBorderText) || RuntimeSpecifyWidth != 0f)) && RuntimeSpecifyWidth != 0f && (Alignment == StringAlignment.Center || Alignment == StringAlignment.Far))
			{
				flag4 = true;
			}
			int num = 0;
			if (flag3)
			{
				base.StartElement.Parent = this;
				xtextElementList_3.AddRaw(base.StartElement);
				num++;
			}
			float num2 = 0f;
			if (RuntimeSpecifyWidth < 0f)
			{
				num2 = Math.Abs(RuntimeSpecifyWidth);
				if (flag3)
				{
					num2 -= base.StartElement.ContentWidth;
				}
				if (flag4)
				{
					num2 -= base.EndElement.ContentWidth;
				}
			}
			if (flag2)
			{
				if (num2 > 0f && bool_20)
				{
					float_6 = 0f;
					num += method_31(xtextElementList_3, bool_20, num2, -1);
				}
				else
				{
					num += method_29(xtextElementList_3, bool_20);
				}
			}
			else
			{
				bool flag5 = false;
				if (Elements != null && Elements.Count > 0)
				{
					foreach (XTextElement element in Elements)
					{
						if (element.RuntimeVisible)
						{
							flag5 = true;
							break;
						}
					}
				}
				if (flag5)
				{
					bool_13 = true;
					if (num2 > 0f && bool_20)
					{
						float_6 = 0f;
						num += method_31(xtextElementList_3, bool_20, num2, -1);
					}
					else
					{
						num += method_29(xtextElementList_3, bool_20);
					}
				}
				else
				{
					method_28();
					if (base.InnerBackgroundTextElements != null && base.InnerBackgroundTextElements.Count > 0)
					{
						xtextElementList_3.AddRange(base.InnerBackgroundTextElements);
						num += base.InnerBackgroundTextElements.Count;
						bool_13 = true;
					}
				}
			}
			if (flag4)
			{
				xtextElementList_3.Add(base.EndElement);
				num++;
			}
			if (flag3)
			{
				base.StartElement.method_13();
			}
			if (flag4)
			{
				base.EndElement.method_13();
			}
			return num;
		}

		private int method_31(XTextElementList xtextElementList_3, bool bool_20, float float_7, int int_14)
		{
			float_6 = float_7;
			int num = 0;
			XTextElementList xTextElementList = new XTextElementList();
			method_29(xTextElementList, bool_20);
			bool_13 = (xTextElementList.Count > 0);
			int_13 = xTextElementList.Count;
			float num2 = 0f;
			foreach (XTextElement item in xTextElementList)
			{
				num2 += item.Width;
			}
			if (num2 > float_7)
			{
				num2 = 0f;
				int num3 = 0;
				int num4 = xTextElementList.Count - 1;
				while (num4 >= 0)
				{
					num2 += xTextElementList[num4].Width;
					if (!(num2 > float_7))
					{
						num4--;
						continue;
					}
					num3 = num4 + 1;
					if (num3 >= xTextElementList.Count)
					{
						num3 = xTextElementList.Count - 1;
					}
					break;
				}
				if (int_14 < 0)
				{
					int_14 = int_11;
				}
				if (int_14 > num3)
				{
					int_14 = num3;
				}
				if (int_14 < 0)
				{
					int_14 = 0;
				}
				num2 = 0f;
				for (num4 = int_11; num4 < xTextElementList.Count; num4++)
				{
					num2 += xTextElementList[num4].Width;
					if (num4 == int_14)
					{
						xtextElementList_3.Add(xTextElementList[num4]);
						num++;
						continue;
					}
					if (num2 > float_7)
					{
						break;
					}
					xtextElementList_3.Add(xTextElementList[num4]);
					num++;
				}
			}
			else
			{
				xtextElementList_3.AddRange(xTextElementList);
				num = xTextElementList.Count;
			}
			int_12 = xTextElementList.IndexOf(xtextElementList_3.LastElement);
			return num;
		}

		internal bool method_32(bool bool_20, bool bool_21)
		{
			if (RuntimeSpecifyWidth >= 0f || Elements.Count == 0)
			{
				return false;
			}
			float num = 0f;
			XTextElementList xTextElementList = new XTextElementList();
			method_29(xTextElementList, bool_17: true);
			int num2 = int_11;
			int_11 = 0;
			int num3 = xTextElementList.Count - 1;
			while (num3 >= 0)
			{
				num += xTextElementList[num3].Width;
				if (!(num >= float_6) || num3 >= xTextElementList.Count - 1)
				{
					num3--;
					continue;
				}
				int_11 = num3;
				break;
			}
			if (int_11 != num2)
			{
				method_34(bool_20, bool_21);
				return true;
			}
			return false;
		}

		internal bool method_33(XTextElement xtextElement_0, bool bool_20, bool bool_21)
		{
			if (UIIsUpdating)
			{
				return false;
			}
			if (xtextElement_0 == this)
			{
				return false;
			}
			if (RuntimeSpecifyWidth >= 0f)
			{
				return false;
			}
			XTextElementList xTextElementList = new XTextElementList();
			vmethod_32(xTextElementList, bool_20: false);
			if (xTextElementList.Contains(xtextElement_0))
			{
				XTextElementList xTextElementList2 = new XTextElementList();
				vmethod_32(xTextElementList2, bool_20: true);
				if (!xTextElementList2.Contains(xtextElement_0))
				{
					xTextElementList2.Clear();
					method_29(xTextElementList2, bool_17: true);
					int num = xTextElementList2.IndexOf(xtextElement_0);
					if (num >= 0)
					{
						int num2 = int_11;
						if (num < StartContentElementIndex)
						{
							int_11 = num;
						}
						else if (num > EndContentElementIndex)
						{
							float num3 = 0f;
							int_11 = 0;
							int num4 = num;
							while (num4 >= 0)
							{
								num3 += xTextElementList2[num4].Width;
								if (!(num3 > float_6) || num4 == num)
								{
									num4--;
									continue;
								}
								int_11 = num4 + 1;
								break;
							}
						}
						if (num2 == int_11)
						{
							return false;
						}
						method_34(bool_20, bool_21);
						return true;
					}
				}
			}
			return false;
		}

		private void method_34(bool bool_20, bool bool_21)
		{
			if (bool_20)
			{
				for (XTextElement parent = Parent; parent != null; parent = parent.Parent)
				{
					if (parent is XTextContentElement)
					{
						XTextContentElement xTextContentElement = (XTextContentElement)parent;
						if (xTextContentElement is XTextDocumentContentElement)
						{
							XTextDocumentContentElement xTextDocumentContentElement = (XTextDocumentContentElement)xTextContentElement;
							XTextContentElement.Class11 @class = new XTextContentElement.Class11();
							@class.method_11(bool_5: false);
							@class.method_5(bool_5: true);
							xTextDocumentContentElement.method_62(@class);
						}
						else
						{
							XTextContentElement.Class11 @class = new XTextContentElement.Class11();
							@class.method_11(bool_5: false);
							@class.method_5(bool_5: true);
							@class.method_7(bool_5: true);
							xTextContentElement.vmethod_37(@class);
						}
					}
				}
			}
			if (bool_21)
			{
				XTextContentElement xTextContentElement = ContentElement;
				xTextContentElement.vmethod_38(xTextContentElement.PrivateContent.IndexOf(base.StartElement), xTextContentElement.PrivateContent.IndexOf(base.EndElement), bool_22: false);
			}
		}

		public override void vmethod_34(ContentChangedEventArgs contentChangedEventArgs_0)
		{
			if (OwnerDocument.EnableContentChangedEvent && eventHandler_0 != null)
			{
				EventHandler eventHandler = eventHandler_0;
				eventHandler_0 = null;
				eventHandler(this, contentChangedEventArgs_0);
			}
			vmethod_43(contentChangedEventArgs_0.LoadingDocument);
			if (OwnerDocument.HighlightManager != null)
			{
				OwnerDocument.HighlightManager.imethod_9(this);
			}
			base.vmethod_34(contentChangedEventArgs_0);
		}

		public virtual void vmethod_43(bool bool_20)
		{
			int num = 18;
			if (OwnerDocument != null && OwnerDocument.ExpressionExecuter != null && OwnerDocument.method_78(this))
			{
				OwnerDocument.ExpressionExecuter.imethod_1(this, RuntimeEventExpressions, "ContentChanged", bool_20);
			}
		}

		[DCInternal]
		public override ValueValidateResult vmethod_24(bool bool_20)
		{
			ValueValidateResult result = base.vmethod_24(bool_20);
			if (bool_20)
			{
			}
			return result;
		}

		public override void OnViewGotFocus(ElementEventArgs elementEventArgs_0)
		{
			if (OwnerDocument.Options.ViewOptions.FieldFocusedBackColor.A != 0 && OwnerDocument.HighlightManager != null)
			{
				OwnerDocument.HighlightManager.imethod_9(this);
				InvalidateView();
			}
			base.OnViewGotFocus(elementEventArgs_0);
		}

		public override void OnViewLostFocus(ElementEventArgs elementEventArgs_0)
		{
			if (OwnerDocument.Options.ViewOptions.FieldFocusedBackColor.A != 0 && OwnerDocument.HighlightManager != null)
			{
				OwnerDocument.HighlightManager.imethod_9(this);
				InvalidateView();
			}
			base.OnViewLostFocus(elementEventArgs_0);
		}

		public override void vmethod_7(ElementEventArgs elementEventArgs_0)
		{
			if (OwnerDocument.Options.ViewOptions.FieldHoverBackColor.A != 0)
			{
				if (OwnerDocument.HighlightManager != null)
				{
					OwnerDocument.HighlightManager.imethod_9(this);
				}
				InvalidateView();
			}
			base.vmethod_7(elementEventArgs_0);
		}

		public override void vmethod_8(ElementEventArgs elementEventArgs_0)
		{
			if (OwnerDocument.Options.ViewOptions.FieldHoverBackColor.A != 0 && OwnerDocument.HighlightManager != null)
			{
				OwnerDocument.HighlightManager.imethod_9(this);
				InvalidateView();
			}
			base.vmethod_8(elementEventArgs_0);
		}

		public override HighlightInfoList vmethod_20()
		{
			EnableState runtimeEnableHighlight = RuntimeEnableHighlight;
			if (runtimeEnableHighlight == EnableState.Disabled)
			{
				return null;
			}
			XTextDocument ownerDocument = OwnerDocument;
			if (ownerDocument == null)
			{
				return null;
			}
			DocumentViewOptions viewOptions = ownerDocument.Options.ViewOptions;
			Color color_ = Color.Transparent;
			if (base.LastValidateResult != null)
			{
				color_ = viewOptions.FieldInvalidateValueBackColor;
			}
			if (color_.A == 0 && runtimeEnableHighlight == EnableState.Enabled)
			{
				if (Focused && viewOptions.FieldFocusedBackColor.A != 0)
				{
					color_ = viewOptions.FieldFocusedBackColor;
				}
				else if (ownerDocument.IsHover(this) && viewOptions.FieldHoverBackColor.A != 0)
				{
					color_ = viewOptions.FieldHoverBackColor;
				}
				else if (viewOptions.FieldBackColor.A != 0)
				{
					switch (runtimeEnableHighlight)
					{
					case EnableState.Disabled:
						return null;
					case EnableState.Default:
					{
						XTextElement parent = Parent;
						while (parent != null)
						{
							if (!(parent is XTextInputFieldElementBase))
							{
								parent = parent.Parent;
								continue;
							}
							return null;
						}
						break;
					}
					}
					color_ = viewOptions.FieldBackColor;
				}
			}
			Color color_2 = Color.Empty;
			if (base.LastValidateResult != null)
			{
				color_2 = viewOptions.FieldInvalidateValueForeColor;
			}
			if (color_.A != 0 || color_2.A != 0)
			{
				XTextDocumentContentElement documentContentElement = base.DocumentContentElement;
				if (documentContentElement != null && FirstContentElement != null && LastContentElement != null)
				{
					HighlightInfo highlightInfo = new HighlightInfo(new XTextRange(documentContentElement, FirstContentElement, LastContentElement), color_, color_2);
					highlightInfo.ActiveStyle = HighlightActiveStyle.Static;
					highlightInfo.OwnerElement = this;
					HighlightInfoList highlightInfoList = new HighlightInfoList();
					highlightInfoList.Add(highlightInfo);
					return highlightInfoList;
				}
			}
			return null;
		}

		/// <summary>
		///       设置文本内容
		///       </summary>
		/// <param name="args">参数</param>
		/// <returns>是否修改内容</returns>
		public override bool SetEditorText(SetContainerTextArgs args)
		{
			if (!args.IgnoreDisplayFormat)
			{
				args.NewText = vmethod_40(args.NewText);
			}
			bool result;
			if (result = base.SetEditorText(args))
			{
				if (vmethod_23(bool_20: false) && OwnerDocument != null && OwnerDocument.EditorControl != null)
				{
					OwnerDocument.EditorControl.UpdateToolTip(checkVersion: true);
				}
				if (OwnerDocument != null && (OwnerDocument.Options.EditOptions.ValueValidateMode == DocumentValueValidateMode.LostFocus || OwnerDocument.Options.EditOptions.ValueValidateMode == DocumentValueValidateMode.Dynamic) && ValidateStyle != null && RuntimeSupportValidateStyle)
				{
					ValidateStyle.ContentVersion = base.ContentVersion - 1;
					vmethod_24(bool_20: false);
				}
			}
			return result;
		}

		[DCInternal]
		public override bool vmethod_23(bool bool_20)
		{
			if (base.vmethod_23(bool_20))
			{
				if (bool_20)
				{
				}
				return true;
			}
			return false;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <param name="Deeply">是否深度复制</param>
		/// <returns>复制品</returns>
		public override XTextElement Clone(bool Deeply)
		{
			XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)base.Clone(Deeply);
			if (valueFormater_0 != null)
			{
				xTextInputFieldElementBase.valueFormater_0 = valueFormater_0.Clone();
			}
			if (eventExpressionInfoList_0 != null)
			{
				xTextInputFieldElementBase.eventExpressionInfoList_0 = eventExpressionInfoList_0.Clone();
			}
			xTextInputFieldElementBase.InnerBackgroundTextElements = null;
			return xTextInputFieldElementBase;
		}

		/// <summary>
		///       返回调试信息文本
		///       </summary>
		/// <returns>返回的文本</returns>
		public override string ToDebugString()
		{
			int num = 8;
			if (!string.IsNullOrEmpty(base.ID))
			{
				return "Field[" + base.ID + "]";
			}
			if (!string.IsNullOrEmpty(Name))
			{
				return "Field[" + Name + "]";
			}
			return "Field";
		}

		public override void vmethod_19(GClass103 gclass103_0)
		{
			int num = 11;
			if (!string.IsNullOrEmpty(RuntimeLabelText))
			{
				gclass103_0.method_40(RuntimeLabelText, RuntimeStyle);
			}
			if (Elements.Count == 0)
			{
				if (OwnerDocument.Options.BehaviorOptions.OutputBackgroundTextToRTF)
				{
					string runtimeBackgroundText = RuntimeBackgroundText;
					if (!string.IsNullOrEmpty(runtimeBackgroundText))
					{
						DocumentContentStyle documentContentStyle = (DocumentContentStyle)OwnerDocument.DefaultStyle.Clone();
						documentContentStyle.Color = OwnerDocument.Options.ViewOptions.BackgroundTextColor;
						gclass103_0.method_40("[" + runtimeBackgroundText + "]", documentContentStyle.MyRuntimeStyle);
						gclass103_0.method_41();
					}
				}
			}
			else
			{
				base.vmethod_19(gclass103_0);
			}
			if (!string.IsNullOrEmpty(RuntimeUnitText))
			{
				gclass103_0.method_40(RuntimeUnitText, RuntimeStyle);
			}
		}

		public override void Dispose()
		{
			base.Dispose();
			string_22 = null;
			dataSourceTreeNode_1 = null;
			string_16 = null;
			valueFormater_0 = null;
			if (eventExpressionInfoList_0 != null)
			{
				eventExpressionInfoList_0.Clear();
				eventExpressionInfoList_0 = null;
			}
			string_21 = null;
			string_18 = null;
			string_19 = null;
			string_20 = null;
			string_17 = null;
		}
	}
}
