using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Data;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       纯文本数据输入域
	///       </summary>
	[Serializable]
	[DebuggerDisplay("Input Name:{ID}")]
	[Guid("00012345-6789-ABCD-EF01-234567890059")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[XmlType("XInputField")]
	
	[DocumentComment]
	[ComClass("00012345-6789-ABCD-EF01-234567890059", "7F013F6B-FFF8-3B8B-BD4E-4EB9FE965505")]
	[ComDefaultInterface(typeof(IXTextInputFieldElement))]
	public class XTextInputFieldElement : XTextInputFieldElementBase, IXTextInputFieldElement
	{
		internal const string string_23 = "00012345-6789-ABCD-EF01-234567890059";

		internal const string string_24 = "7F013F6B-FFF8-3B8B-BD4E-4EB9FE965505";

		private bool bool_20 = true;

		private DCBooleanValue dcbooleanValue_2 = DCBooleanValue.Inherit;

		private bool bool_21 = false;

		private DCDefaultValueType dcdefaultValueType_0 = DCDefaultValueType.None;

		private InputFieldAdornTextType inputFieldAdornTextType_0 = InputFieldAdornTextType.Default;

		private string string_25 = null;

		private string string_26 = null;

		private LinkListBindingInfo linkListBindingInfo_0 = null;

		private bool bool_22 = true;

		private ValueEditorActiveMode valueEditorActiveMode_0 = ValueEditorActiveMode.Program | ValueEditorActiveMode.F2 | ValueEditorActiveMode.MouseDblClick;

		private int int_14 = -1;

		private string string_27 = null;

		private bool bool_23 = false;

		[NonSerialized]
		private ListItemCollection listItemCollection_0 = null;

		private InputFieldSettings inputFieldSettings_0 = null;

		private string string_28 = null;

		private bool bool_24 = true;

		private DCBooleanValue dcbooleanValue_3 = DCBooleanValue.Inherit;

		private FormButtonStyle formButtonStyle_0 = FormButtonStyle.Auto;

		private bool bool_25 = false;

		public override string DomDisplayName
		{
			get
			{
				int num = 8;
				string text = "Field:" + base.ID + " " + base.Name;
				if (!string.IsNullOrEmpty(base.BackgroundText))
				{
					text = text + "[" + base.BackgroundText + "]";
				}
				return text;
			}
		}

		/// <summary>
		///       文档元素编号前缀
		///       </summary>
		public override string ElementIDPrefix => "field";

		/// <summary>
		///       允许用户直接编辑内容而修改InnerValue值。
		///       </summary>
		
		[DefaultValue(true)]
		[ComVisible(true)]
		[HtmlAttribute]
		[MemberExpressionable(MemberEffectLevel.ElementView)]
		public bool EnableUserEditInnerValue
		{
			get
			{
				return bool_20;
			}
			set
			{
				bool_20 = value;
			}
		}

		/// <summary>
		///       是否显示扩展标记
		///       </summary>
		[ComVisible(true)]
		[DefaultValue(DCBooleanValue.Inherit)]
		
		[HtmlAttribute]
		[MemberExpressionable(MemberEffectLevel.ElementView)]
		public DCBooleanValue ShowInputFieldStateTag
		{
			get
			{
				return dcbooleanValue_2;
			}
			set
			{
				dcbooleanValue_2 = value;
			}
		}

		/// <summary>
		///       运行时是否显示扩展标记
		///       </summary>
		internal bool RuntimeShowInputFieldStateTag
		{
			get
			{
				if (!XTextDocument.smethod_13(GEnum6.const_183))
				{
					return false;
				}
				if (ShowInputFieldStateTag == DCBooleanValue.True)
				{
					return true;
				}
				if (ShowInputFieldStateTag == DCBooleanValue.False)
				{
					return false;
				}
				if (OwnerDocument != null)
				{
					return OwnerDocument.Options.ViewOptions.ShowInputFieldStateTag;
				}
				return true;
			}
		}

		/// <summary>
		///       在下拉列表中自动设置拼音码
		///       </summary>
		[DefaultValue(false)]
		[MemberExpressionable(MemberEffectLevel.DOM)]
		[HtmlAttribute]
		[ComVisible(true)]
		
		public bool AutoSetSpellCodeInDropdownList
		{
			get
			{
				return bool_21;
			}
			set
			{
				bool_21 = value;
			}
		}

		/// <summary>
		///       默认值类型
		///       </summary>
		[DefaultValue(DCDefaultValueType.None)]
		[HtmlAttribute]
		
		[MemberExpressionable]
		public DCDefaultValueType DefaultValueType
		{
			get
			{
				return dcdefaultValueType_0;
			}
			set
			{
				dcdefaultValueType_0 = value;
			}
		}

		/// <summary>
		///       扩展标记文字类型
		///       </summary>
		[DefaultValue(InputFieldAdornTextType.Default)]
		[MemberExpressionable(MemberEffectLevel.ElementView)]
		
		[HtmlAttribute]
		public InputFieldAdornTextType AdornTextType
		{
			get
			{
				return inputFieldAdornTextType_0;
			}
			set
			{
				inputFieldAdornTextType_0 = value;
			}
		}

		/// <summary>
		///       运行时使用的扩展标记文字类型
		///       </summary>
		[ComVisible(false)]
		public InputFieldAdornTextType RuntimeAdornTextType
		{
			get
			{
				InputFieldAdornTextType inputFieldAdornTextType = AdornTextType;
				if (inputFieldAdornTextType == InputFieldAdornTextType.Default)
				{
					inputFieldAdornTextType = OwnerDocument.Options.ViewOptions.DefaultAdornTextType;
				}
				return inputFieldAdornTextType;
			}
		}

		/// <summary>
		///       自定义的扩展标记文字
		///       </summary>
		
		[MemberExpressionable]
		[DefaultValue(null)]
		[HtmlAttribute]
		public string CustomAdornText
		{
			get
			{
				return string_25;
			}
			set
			{
				string_25 = value;
			}
		}

		/// <summary>
		///       运行时使用的扩展标记文字
		///       </summary>
		[Browsable(false)]
		public override string RuntimeAdornText
		{
			get
			{
				int num = 5;
				switch (RuntimeAdornTextType)
				{
				default:
					return null;
				case InputFieldAdornTextType.Default:
					return null;
				case InputFieldAdornTextType.DataSource:
					if (base.HasValueBinding && !base.ValueBinding.IsEmptyBinding)
					{
						if (string.IsNullOrEmpty(base.ValueBinding.DataSource))
						{
							return base.ValueBinding.BindingPath;
						}
						return base.ValueBinding.DataSource + "#" + base.ValueBinding.BindingPath;
					}
					return null;
				case InputFieldAdornTextType.ToolTip:
					return base.ToolTip;
				case InputFieldAdornTextType.ValidateMessage:
					if (base.LastValidateResult != null)
					{
						return base.LastValidateResult.Message;
					}
					return null;
				case InputFieldAdornTextType.ID:
					return base.ID;
				case InputFieldAdornTextType.Name:
					return base.Name;
				case InputFieldAdornTextType.TabIndex:
					return base.TabIndex.ToString();
				case InputFieldAdornTextType.Custom:
					return CustomAdornText;
				}
			}
		}

		/// <summary>
		///       数据编辑器控件类型名称
		///       </summary>
		[MemberExpressionable]
		
		[HtmlAttribute]
		[DefaultValue(null)]
		public string EditorControlTypeName
		{
			get
			{
				return string_26;
			}
			set
			{
				string_26 = value;
			}
		}

		/// <summary>
		///       联动列表信息
		///       </summary>
		[Browsable(true)]
		[ComVisible(true)]
		[HtmlAttribute]
		
		[DefaultValue(null)]
		public LinkListBindingInfo LinkListBinding
		{
			get
			{
				return linkListBindingInfo_0;
			}
			set
			{
				linkListBindingInfo_0 = value;
			}
		}

		/// <summary>
		///       是否启用输入域文字颜色
		///       </summary>
		[DefaultValue(true)]
		[HtmlAttribute]
		
		public bool EnableFieldTextColor
		{
			get
			{
				return bool_22;
			}
			set
			{
				bool_22 = value;
			}
		}

		/// <summary>
		///       数值编辑器激活模式
		///       </summary>
		[MemberExpressionable]
		
		[HtmlAttribute(DetectDefaultValue = false)]
		[DefaultValue(ValueEditorActiveMode.Program | ValueEditorActiveMode.F2 | ValueEditorActiveMode.MouseDblClick)]
		public ValueEditorActiveMode EditorActiveMode
		{
			get
			{
				return valueEditorActiveMode_0;
			}
			set
			{
				valueEditorActiveMode_0 = (ValueEditorActiveMode)WriterUtils.FixEnumValue(value);
			}
		}

		/// <summary>
		///       运行时使用的数值编辑器激活模式
		///       </summary>
		internal ValueEditorActiveMode RuntimeEditorActiveMode
		{
			get
			{
				ValueEditorActiveMode valueEditorActiveMode = EditorActiveMode;
				if (valueEditorActiveMode == ValueEditorActiveMode.Default)
				{
					valueEditorActiveMode = OwnerDocument.Options.BehaviorOptions.DefaultEditorActiveMode;
				}
				if (valueEditorActiveMode != 0 && OwnerDocument.Options.BehaviorOptions.FastInputMode)
				{
					valueEditorActiveMode |= ValueEditorActiveMode.GotFocus;
				}
				return valueEditorActiveMode;
			}
		}

		/// <summary>
		///       选择的项目的从0开始的序号
		///       </summary>
		[MemberExpressionable(MemberEffectLevel.DOM)]
		[ComVisible(true)]
		
		[DefaultValue(-1)]
		[ReadOnly(true)]
		[XmlElement]
		public int SelectedIndex
		{
			get
			{
				return int_14;
			}
			set
			{
				int_14 = value;
			}
		}

		/// <summary>
		///       默认的从0开始计算的下拉列表中选择的序号。
		///       </summary>
		[XmlElement]
		
		[MemberExpressionable(MemberEffectLevel.DOM)]
		[ComVisible(true)]
		[DefaultValue(null)]
		public string DefaultSelectedIndexs
		{
			get
			{
				return string_27;
			}
			set
			{
				string_27 = value;
			}
		}

		/// <summary>
		///       是否启用LastSelectedListItems功能。
		///       </summary>
		[ComVisible(true)]
		
		[DefaultValue(false)]
		public bool EnableLastSelectedListItems
		{
			get
			{
				return bool_23;
			}
			set
			{
				bool_23 = value;
			}
		}

		/// <summary>
		///       最后一次从下拉列表中被选择的项目列表。用户直接修改输入域的内容会设置该属性值为空。
		///       </summary>
		
		[XmlArrayItem("Item", typeof(ListItem))]
		[DefaultValue(null)]
		[ComVisible(true)]
		public ListItemCollection LastSelectedListItems
		{
			get
			{
				return listItemCollection_0;
			}
			set
			{
				listItemCollection_0 = value;
			}
		}

		/// <summary>
		///       输入域设置
		///       </summary>
		
		[Browsable(true)]
		[DefaultValue(null)]
		public InputFieldSettings FieldSettings
		{
			get
			{
				if (inputFieldSettings_0 == null && DocumentBehaviorOptions.StaticAutoCreateInstanceInProperty)
				{
					inputFieldSettings_0 = new InputFieldSettings();
				}
				if (inputFieldSettings_0 != null && WriterControl != null)
				{
					WriterControl.CollectOuterReference(inputFieldSettings_0);
				}
				return inputFieldSettings_0;
			}
			set
			{
				inputFieldSettings_0 = value;
			}
		}

		/// <summary>
		///       自定义的文档元素数值编辑器的名称
		///       </summary>
		[DefaultValue(null)]
		[MemberExpressionable]
		
		public string CustomValueEditorTypeName
		{
			get
			{
				return string_28;
			}
			set
			{
				string_28 = value;
			}
		}

		/// <summary>
		///       自定义的文档元素数值编辑器类型
		///       </summary>
		[Browsable(false)]
		
		[XmlIgnore]
		public Type CustomValueEditorType
		{
			get
			{
				return ControlHelper.GetControlType(CustomValueEditorTypeName, typeof(ElementValueEditor));
			}
			set
			{
				CustomValueEditorTypeName = ControlHelper.GetControlFullTypeName(value);
			}
		}

		/// <summary>
		///       是否允许元素数值编辑器
		///       </summary>
		
		[DefaultValue(true)]
		[HtmlAttribute]
		public bool EnableValueEditor
		{
			get
			{
				return bool_24;
			}
			set
			{
				bool_24 = value;
			}
		}

		/// <summary>
		///       是否显示表单按钮
		///       </summary>
		[HtmlAttribute]
		
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		[DefaultValue(DCBooleanValue.Inherit)]
		public DCBooleanValue ShowFormButton
		{
			get
			{
				return dcbooleanValue_3;
			}
			set
			{
				dcbooleanValue_3 = value;
			}
		}

		/// <summary>
		///       指定的表单按钮样式
		///       </summary>
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		[DefaultValue(FormButtonStyle.Auto)]
		
		[HtmlAttribute]
		public FormButtonStyle FormButtonStyle
		{
			get
			{
				return formButtonStyle_0;
			}
			set
			{
				formButtonStyle_0 = value;
			}
		}

		/// <summary>
		///       表单按钮样式
		///       </summary>
		
		internal FormButtonStyle RuntimeFormButtonStyle
		{
			get
			{
				if (!XTextDocument.smethod_13(GEnum6.const_184))
				{
					return FormButtonStyle.None;
				}
				if (FormButtonStyle != FormButtonStyle.Auto)
				{
					return FormButtonStyle;
				}
				if (!EnableValueEditor)
				{
					return FormButtonStyle.None;
				}
				if (!string.IsNullOrEmpty(EditorControlTypeName))
				{
					return FormButtonStyle.FloatButton;
				}
				if (!string.IsNullOrEmpty(CustomValueEditorTypeName))
				{
					return FormButtonStyle.None;
				}
				if (FieldSettings == null)
				{
					return FormButtonStyle.None;
				}
				bool flag = false;
				if (ShowFormButton == DCBooleanValue.True || (ShowFormButton != DCBooleanValue.False && OwnerDocument != null && OwnerDocument.Options.ViewOptions.ShowFormButton))
				{
					switch (FieldSettings.RuntimeEditStyle)
					{
					case InputFieldEditStyle.Text:
						return FormButtonStyle.None;
					case InputFieldEditStyle.DropdownList:
						return FormButtonStyle.ComboBoxButton;
					case InputFieldEditStyle.Date:
						return FormButtonStyle.DateTimePicker;
					case InputFieldEditStyle.DateTime:
						return FormButtonStyle.DateTimePicker;
					case InputFieldEditStyle.DateTimeWithoutSecond:
						return FormButtonStyle.DateTimePicker;
					case InputFieldEditStyle.Time:
						return FormButtonStyle.DateTimePicker;
					case InputFieldEditStyle.Numeric:
						return FormButtonStyle.None;
					}
				}
				return FormButtonStyle.None;
			}
		}

		/// <summary>
		///       绝对边界
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public override RectangleF AbsBounds
		{
			get
			{
				RectangleF absBounds = base.StartElement.AbsBounds;
				RectangleF absBounds2 = base.EndElement.AbsBounds;
				return RectangleF.Union(absBounds, absBounds2);
			}
		}

		/// <summary>
		///       DCWriter内部使用
		///       </summary>
		
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[ComVisible(false)]
		[DefaultValue(false)]
		[HtmlAttribute]
		[Obsolete("DCWriter内部使用，请勿调用。")]
		[XmlIgnore]
		public bool InnerMultiSelect
		{
			get
			{
				if (FieldSettings == null)
				{
					return false;
				}
				return FieldSettings.MultiSelect;
			}
			set
			{
				if (FieldSettings == null)
				{
					FieldSettings = new InputFieldSettings();
				}
				FieldSettings.MultiSelect = value;
			}
		}

		/// <summary>
		///       DCWriter内部使用
		///       </summary>
		[ComVisible(false)]
		[HtmlAttribute]
		[Browsable(false)]
		[XmlIgnore]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("DCWriter内部使用，请勿调用。")]
		[DefaultValue(InputFieldEditStyle.Text)]
		public InputFieldEditStyle InnerEditStyle
		{
			get
			{
				if (FieldSettings == null)
				{
					return InputFieldEditStyle.Text;
				}
				return FieldSettings.EditStyle;
			}
			set
			{
				if (FieldSettings == null)
				{
					FieldSettings = new InputFieldSettings();
				}
				FieldSettings.EditStyle = value;
			}
		}

		/// <summary>
		///       DCWriter内部使用
		///       </summary>
		[Obsolete("DCWriter内部使用，请勿调用。")]
		
		[HtmlAttribute]
		[Browsable(false)]
		[DefaultValue(",")]
		[XmlIgnore]
		[ComVisible(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string InnerItemSpliter
		{
			get
			{
				int num = 12;
				if (FieldSettings == null)
				{
					return ",";
				}
				return FieldSettings.ListValueSeparatorChar;
			}
			set
			{
				if (FieldSettings == null)
				{
					FieldSettings = new InputFieldSettings();
				}
				FieldSettings.ListValueSeparatorChar = value;
			}
		}

		/// <summary>
		///       DCWriter内部使用
		///       </summary>
		[XmlIgnore]
		[HtmlAttribute]
		[DefaultValue(null)]
		
		[ComVisible(false)]
		[Obsolete("DCWriter内部使用，请勿调用。")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public string InnerListSourceName
		{
			get
			{
				if (FieldSettings != null && FieldSettings.ListSource != null)
				{
					return FieldSettings.ListSource.SourceName;
				}
				return null;
			}
			set
			{
				EnsureHasListItemsInstance();
				FieldSettings.ListSource.SourceName = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public XTextInputFieldElement()
		{
		}

		/// <summary>
		///       根据DefaultValueType的属性值重置对象内容为默认值
		///       </summary>
		/// <returns>操作是否修改了输入域内容</returns>
		
		public virtual bool ResetToDefaultValue()
		{
			int num = 14;
			switch (DefaultValueType)
			{
			case DCDefaultValueType.None:
				return false;
			case DCDefaultValueType.Empty:
				if (Elements.Count > 0 || !string.IsNullOrEmpty(base.InnerValue))
				{
					Elements.Clear();
					base.InnerValue = null;
					return true;
				}
				return false;
			case DCDefaultValueType.CurrentDate:
			case DCDefaultValueType.CurrentTime:
			case DCDefaultValueType.CurrentDateTime:
			{
				DateTime dateTime = DateTime.Now;
				if (OwnerDocument != null)
				{
					dateTime = OwnerDocument.GetNowDateTime();
				}
				string text = null;
				if (DefaultValueType == DCDefaultValueType.CurrentDate)
				{
					text = dateTime.ToString("yyyy-MM-dd");
				}
				else if (DefaultValueType == DCDefaultValueType.CurrentDateTime)
				{
					text = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
				}
				else if (DefaultValueType == DCDefaultValueType.CurrentTime)
				{
					text = dateTime.ToString("HH:mm:ss");
				}
				string iD = text;
				if (base.RuntimeDisplayFormat != null && !base.RuntimeDisplayFormat.IsEmpty)
				{
					iD = base.RuntimeDisplayFormat.Execute(dateTime);
				}
				SetInnerTextFast(iD);
				if (OwnerDocument != null && OwnerDocument.Options.BehaviorOptions.DisplayFormatToInnerValue)
				{
					base.InnerValue = iD;
				}
				else
				{
					base.InnerValue = text;
				}
				break;
			}
			case DCDefaultValueType.CurrnetUserID:
				if (OwnerDocument != null && OwnerDocument.UserHistories.CurrentInfo != null)
				{
					string iD = OwnerDocument.UserHistories.CurrentInfo.Name;
					SetInnerTextFast(iD);
				}
				break;
			case DCDefaultValueType.CurrentUserName:
				if (OwnerDocument != null && OwnerDocument.UserHistories.CurrentInfo != null)
				{
					string iD = OwnerDocument.UserHistories.CurrentInfo.ID;
					SetInnerTextFast(iD);
				}
				break;
			}
			return true;
		}

		/// <summary>
		///       勾选多个下拉项目
		///       </summary>
		/// <param name="indexs">从0开始计算的项目序号列表，各个序号之间用逗号分隔</param>
		
		public void EditorCheckItems(string indexs)
		{
		}

		
		public Color method_35(Color color_3, RuntimeDocumentContentStyle runtimeDocumentContentStyle_1, bool bool_26)
		{
			DocumentViewOptions viewOptions = OwnerDocument.Options.ViewOptions;
			if (base.TextColor.A != 0)
			{
				color_3 = base.TextColor;
			}
			if (viewOptions.EnableFieldTextColor && EnableFieldTextColor)
			{
				color_3 = ((base.TextColor.A == 0) ? viewOptions.FieldTextColor : base.TextColor);
				if (bool_26)
				{
					if (viewOptions.FieldTextPrintColor.A != 0)
					{
						color_3 = viewOptions.FieldTextPrintColor;
					}
					if (runtimeDocumentContentStyle_1 != null && runtimeDocumentContentStyle_1.PrintColor.A != 0)
					{
						color_3 = runtimeDocumentContentStyle_1.PrintColor;
					}
				}
			}
			return color_3;
		}

		/// <summary>
		///       确保下拉列表实例存在
		///       </summary>
		
		[ComVisible(true)]
		public void EnsureHasListItemsInstance()
		{
			if (FieldSettings == null)
			{
				FieldSettings = new InputFieldSettings();
			}
			if (FieldSettings.ListSource == null)
			{
				FieldSettings.ListSource = new ListSourceInfo();
			}
			if (FieldSettings.ListSource.Items == null)
			{
				FieldSettings.ListSource.Items = new ListItemCollection();
			}
		}

		/// <summary>
		///       开始编辑元素数值
		///       </summary>
		/// <returns>操作是否成功</returns>
		[ComVisible(true)]
		
		public virtual bool BeginEditValue()
		{
			if (OwnerDocument != null && OwnerDocument.EditorControl != null)
			{
				return OwnerDocument.EditorControl.method_21(this, bool_12: false, ValueEditorActiveMode.Program, bool_13: false, bool_14: false);
			}
			return false;
		}

		
		public ListItemCollection GetRuntimeListItems()
		{
			return method_36(null, bool_26: true, null);
		}

		
		public ListItemCollection method_36(string string_29, bool bool_26, string string_30)
		{
			if (OwnerDocument == null)
			{
				return null;
			}
			IListSourceProvider ilistSourceProvider_ = null;
			if (OwnerDocument.AppHost != null)
			{
				ilistSourceProvider_ = (IListSourceProvider)OwnerDocument.AppHost.Services.GetService(typeof(IListSourceProvider));
			}
			return ListSourceInfo.smethod_0(OwnerDocument.EditorControl, this, OwnerDocument.AppHost, (FieldSettings == null) ? null : FieldSettings.ListSource, ilistSourceProvider_, null, string_29, bool_26, string_30);
		}

		/// <summary>
		///       处理文档事件
		///       </summary>
		/// <param name="args">
		/// </param>
		public override void HandleDocumentEvent(DocumentEventArgs args)
		{
			if (args.Style == DocumentEventStyles.DefaultEditMethod)
			{
				if (OwnerDocument.EditorControl.method_21(this, bool_12: false, ValueEditorActiveMode.F2, bool_13: true, bool_14: true))
				{
					args.Handled = true;
				}
				return;
			}
			if (args.Style == DocumentEventStyles.KeyDown && args.KeyCode == Keys.Return && (EditorActiveMode & ValueEditorActiveMode.Enter) == ValueEditorActiveMode.Enter)
			{
				WriterControl.IgnoreNextKeyPressEvent = true;
				if (OwnerDocument.EditorControl.method_21(this, bool_12: false, ValueEditorActiveMode.Enter, bool_13: true, bool_14: true))
				{
					args.Handled = true;
					return;
				}
			}
			base.HandleDocumentEvent(args);
		}

		/// <summary>
		///       文档元素加载后事件处理
		///       </summary>
		/// <param name="args">参数</param>
		public override void AfterLoad(ElementLoadEventArgs args)
		{
			if (inputFieldSettings_0 != null)
			{
				inputFieldSettings_0.FixListSourceSettings();
			}
			if (LinkListBinding != null && LinkListBinding.IsRoot)
			{
				OwnerDocument.LinkListExecuter.method_0(this);
			}
			base.AfterLoad(args);
		}

		/// <summary>
		///       让输入域获得节点而且不激发数值编辑器
		///       </summary>
		[ComVisible(true)]
		
		public void FocusWithoutActiveEditor()
		{
			bool_25 = true;
			Focus();
			bool_25 = false;
		}

		public override void OnViewGotFocus(ElementEventArgs elementEventArgs_0)
		{
			base.OnViewGotFocus(elementEventArgs_0);
			if (!WriterUtils.smethod_35((int)RuntimeEditorActiveMode, 8) || base.DocumentContentElement.Selection.Length != 0 || bool_25)
			{
				return;
			}
			bool_25 = false;
			if (OwnerDocument.EditorControl.EditorHost.CurrentEditContext != null && OwnerDocument.EditorControl.EditorHost.CurrentEditContext.Element == this && OwnerDocument.EditorControl.EditorHost.CurrentEditContext.EditStyle == ElementValueEditorEditStyle.Modal)
			{
				return;
			}
			if (FieldSettings != null && WriterControl != null && FieldSettings.RuntimeEditStyle == InputFieldEditStyle.DropdownList)
			{
				if (FieldSettings.DynamicListItems)
				{
					OwnerDocument.EditorControl.method_21(this, bool_12: false, ValueEditorActiveMode.GotFocus, bool_13: true, bool_14: true);
				}
				else if (FieldSettings.ListSource != null && !FieldSettings.ListSource.IsEmpty)
				{
					OwnerDocument.EditorControl.method_21(this, bool_12: false, ValueEditorActiveMode.GotFocus, bool_13: true, bool_14: true);
				}
			}
			else if (FieldSettings != null && FieldSettings.RuntimeEditStyle == InputFieldEditStyle.Date)
			{
				OwnerDocument.EditorControl.method_21(this, bool_12: false, ValueEditorActiveMode.GotFocus, bool_13: true, bool_14: true);
			}
		}

		public override void OnViewLostFocus(ElementEventArgs elementEventArgs_0)
		{
			base.OnViewLostFocus(elementEventArgs_0);
			if (OwnerDocument.EditorControl != null && OwnerDocument.EditorControl.EditorHost != null && OwnerDocument.EditorControl.EditorHost.CurrentEditContext != null && OwnerDocument.EditorControl.EditorHost.CurrentEditContext.Element == this)
			{
				OwnerDocument.EditorControl.CancelEditElementValue();
			}
		}

		/// <summary>
		///       设置选中的列表项目
		///       </summary>
		/// <param name="indexs">从0开始计算的项目编号，各个编号之间用逗号分开</param>
		/// <returns>操作是否修改了文档内容</returns>
		
		public bool EditorSetSelectedIndexs(string indexs)
		{
			int[] indexs2 = StringConvertHelper.ToInt32Values(indexs);
			string newText = OwnerDocument.AppHost.Tools.FormatSelectedValueByIndexs(OwnerDocument.EditorControl, this, indexs2, getText: true);
			OwnerDocument.AppHost.Tools.FormatSelectedValueByIndexs(OwnerDocument.EditorControl, this, indexs2, getText: false);
			return SetEditorTextExt(newText, DomAccessFlags.None, disablePermissioin: true, updateContent: true);
		}

		public override XTextElementList SetInnerTextFastExt(string string_29, DocumentContentStyle newTextStyle, bool updateContentElements)
		{
			XTextElementList xTextElementList = base.SetInnerTextFastExt(string_29, newTextStyle, updateContentElements);
			if (xTextElementList != null && xTextElementList.Count > 0)
			{
				UpdateInnerValue(updateParent: true);
			}
			return xTextElementList;
		}

		public override string vmethod_38(string string_29)
		{
			bool bool_ = false;
			if (OwnerDocument != null)
			{
				bool_ = OwnerDocument.Options.BehaviorOptions.RaiseQueryListItemsWhenUserEditText;
			}
			ListItemCollection listItemCollection = method_36(null, bool_, null);
			if (listItemCollection != null && listItemCollection.Count > 0)
			{
				if (FieldSettings.MultiSelect)
				{
					List<string> list = new List<string>();
					foreach (ListItem item in listItemCollection)
					{
						if (!string.IsNullOrEmpty(item.Text))
						{
							list.Add(item.Text);
						}
						else
						{
							list.Add(item.Value);
						}
					}
					string runtimeListValueSeparator = FieldSettings.RuntimeListValueSeparator;
					string[] array = null;
					array = OwnerDocument.AppHost.Tools.ParseSelectedValue(OwnerDocument.EditorControl, this, list, runtimeListValueSeparator, FieldSettings.ListValueFormatString, string_29);
					if (array == null || array.Length == 0)
					{
						return "";
					}
					StringBuilder stringBuilder = new StringBuilder();
					foreach (ListItem item2 in listItemCollection)
					{
						string b = string.IsNullOrEmpty(item2.Text) ? item2.Value : item2.Text;
						bool flag = false;
						for (int i = 0; i < array.Length; i++)
						{
							if (array[i] == b)
							{
								array[i] = null;
								flag = true;
								break;
							}
						}
						if (flag)
						{
							if (stringBuilder.Length > 0 && !string.IsNullOrEmpty(runtimeListValueSeparator))
							{
								stringBuilder.Append(runtimeListValueSeparator);
							}
							if (string.IsNullOrEmpty(item2.Value))
							{
								stringBuilder.Append(item2.Text);
							}
							else
							{
								stringBuilder.Append(item2.Value);
							}
						}
					}
					return stringBuilder.ToString();
				}
				string text = listItemCollection.TextToValue(string_29);
				if (text == null)
				{
					text = string_29;
				}
				return text;
			}
			return string_29;
		}

		public override string vmethod_39(string string_29, bool bool_26)
		{
			ListItemCollection listItemCollection = method_36(null, OwnerDocument != null && OwnerDocument.Options.BehaviorOptions.RaiseQueryListItemsWhenUserEditText, string_29);
			if (listItemCollection != null)
			{
				if (FieldSettings.MultiSelect)
				{
					List<string> list = new List<string>();
					foreach (ListItem item in listItemCollection)
					{
						if (!string.IsNullOrEmpty(item.Value))
						{
							list.Add(item.Value);
						}
						else
						{
							list.Add(item.Text);
						}
					}
					string runtimeListValueSeparator = FieldSettings.RuntimeListValueSeparator;
					string[] array = null;
					if (OwnerDocument != null)
					{
						array = OwnerDocument.AppHost.Tools.ParseSelectedValue(OwnerDocument.EditorControl, this, list, runtimeListValueSeparator, FieldSettings.ListValueFormatString, string_29);
					}
					if (array == null || array.Length == 0)
					{
						return "";
					}
					StringBuilder stringBuilder = new StringBuilder();
					foreach (ListItem item2 in listItemCollection)
					{
						string b = string.IsNullOrEmpty(item2.Value) ? item2.Text : item2.Value;
						bool flag = false;
						string[] array2 = array;
						foreach (string a in array2)
						{
							if (a == b)
							{
								flag = true;
								break;
							}
						}
						if (flag)
						{
							if (stringBuilder.Length > 0 && !string.IsNullOrEmpty(runtimeListValueSeparator))
							{
								stringBuilder.Append(runtimeListValueSeparator);
							}
							stringBuilder.Append(item2.Text);
						}
					}
					return stringBuilder.ToString();
				}
				string text = listItemCollection.ValueToText(string_29);
				if (text == null && !bool_26)
				{
					text = string_29;
				}
				return text;
			}
			return base.vmethod_40(string_29);
		}

		/// <summary>
		///       根据对象内容更新InnerValue值。
		///       </summary>
		/// <param name="updateParent">是否更新各级父输入域的值</param>
		
		[ComVisible(true)]
		public virtual void UpdateInnerValue(bool updateParent)
		{
			int num = 0;
			if (FieldSettings != null)
			{
				if (FieldSettings.RuntimeEditStyle == InputFieldEditStyle.Date || FieldSettings.RuntimeEditStyle == InputFieldEditStyle.DateTime)
				{
					DateTime result = OwnerDocument.GetNowDateTime();
					bool flag = false;
					if ((base.RuntimeDisplayFormat == null || string.IsNullOrEmpty(base.RuntimeDisplayFormat.Format)) ? DateTime.TryParse(Text, out result) : DateTime.TryParseExact(Text, base.RuntimeDisplayFormat.Format, null, DateTimeStyles.AssumeLocal, out result))
					{
						if (OwnerDocument.Options.BehaviorOptions.DisplayFormatToInnerValue && base.RuntimeDisplayFormat != null && !base.RuntimeDisplayFormat.IsEmpty)
						{
							base.InnerValue = base.RuntimeDisplayFormat.Execute(result);
						}
						else if (FieldSettings.RuntimeEditStyle == InputFieldEditStyle.Date)
						{
							base.InnerValue = result.ToString("yyyy-MM-dd");
						}
						else if (FieldSettings.RuntimeEditStyle == InputFieldEditStyle.Time)
						{
							base.InnerValue = result.ToString("HH:mm:ss");
						}
						else if (FieldSettings.RuntimeEditStyle == InputFieldEditStyle.DateTimeWithoutSecond)
						{
							base.InnerValue = result.ToString("yyyy-MM-dd HH:mm");
						}
						else
						{
							base.InnerValue = result.ToString("yyyy-MM-dd HH:mm:ss");
						}
					}
					else
					{
						base.InnerValue = Text;
					}
				}
				else if (FieldSettings.RuntimeEditStyle == InputFieldEditStyle.Text)
				{
					base.InnerValue = Text;
				}
				else if (FieldSettings.RuntimeEditStyle == InputFieldEditStyle.DropdownList)
				{
					base.InnerValue = vmethod_38(Text);
				}
				else
				{
					base.InnerValue = Text;
				}
			}
			else
			{
				base.InnerValue = Text;
			}
			if (!updateParent)
			{
				return;
			}
			for (XTextElement parent = Parent; parent != null; parent = parent.Parent)
			{
				if (parent is XTextInputFieldElement)
				{
					((XTextInputFieldElement)parent).UpdateInnerValue(updateParent: false);
				}
			}
		}

		public override void vmethod_34(ContentChangedEventArgs contentChangedEventArgs_0)
		{
			if (!contentChangedEventArgs_0.LoadingDocument)
			{
				LastSelectedListItems = null;
			}
			if (contentChangedEventArgs_0.LoadingDocument)
			{
				base.vmethod_34(contentChangedEventArgs_0);
			}
			else if (!contentChangedEventArgs_0.OnlyStyleChanged)
			{
				if (contentChangedEventArgs_0.EventSource != ContentChangedEventSource.ValueEditor && EnableUserEditInnerValue)
				{
					UpdateInnerValue(updateParent: false);
				}
				base.vmethod_34(contentChangedEventArgs_0);
				OwnerDocument.LinkListExecuter.method_1(this, bool_0: false);
			}
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <param name="Deeply">是否深度复制</param>
		/// <returns>复制品</returns>
		
		public override XTextElement Clone(bool Deeply)
		{
			XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)base.Clone(Deeply);
			if (inputFieldSettings_0 != null)
			{
				xTextInputFieldElement.inputFieldSettings_0 = inputFieldSettings_0.Clone();
			}
			if (linkListBindingInfo_0 != null)
			{
				xTextInputFieldElement.linkListBindingInfo_0 = linkListBindingInfo_0.Clone();
			}
			return xTextInputFieldElement;
		}

		public override void vmethod_17(ReadHTMLEventArgs readHTMLEventArgs_0)
		{
			int num = 9;
			base.InnerValue = null;
			readHTMLEventArgs_0.ReadDCCustomAttributes(readHTMLEventArgs_0.HtmlElement, this);
			DocumentContentStyle style = readHTMLEventArgs_0.CreateContentStyle(readHTMLEventArgs_0.CurrentStyle, this, readHTMLEventArgs_0.HtmlElement);
			StyleIndex = OwnerDocument.ContentStyles.GetStyleIndex(style);
			if (readHTMLEventArgs_0.HtmlElement.method_43() == "input")
			{
				string text = readHTMLEventArgs_0.HtmlElement.method_9("value");
				XTextStringElement xTextStringElement = new XTextStringElement();
				xTextStringElement.Text = text;
				xTextStringElement.StyleIndex = StyleIndex;
				base.Name = readHTMLEventArgs_0.HtmlElement.method_9("name");
				Elements.Add(xTextStringElement);
				method_37(readHTMLEventArgs_0);
			}
			else if (readHTMLEventArgs_0.HtmlElement.method_43() == "select")
			{
				EnsureHasListItemsInstance();
				FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
				foreach (GClass163 item in readHTMLEventArgs_0.HtmlElement.vmethod_2())
				{
					if (item.method_43() == "option")
					{
						ListItem listItem = new ListItem();
						listItem.Value = item.method_9("value");
						listItem.Text = item.InnerText;
						FieldSettings.ListSource.Items.Add(listItem);
						if (item.method_13("selected"))
						{
							Text = listItem.Text;
							base.InnerValue = listItem.Value;
						}
					}
				}
				if (readHTMLEventArgs_0.HtmlElement.method_13("dcselectedindex"))
				{
					int result = 0;
					if (int.TryParse(readHTMLEventArgs_0.HtmlElement.method_9("dcselectedindex"), out result) && result >= 0 && result < FieldSettings.ListSource.Items.Count)
					{
						ListItem listItem = FieldSettings.ListSource.Items[result];
						Text = listItem.Text;
						base.InnerValue = listItem.Value;
					}
				}
			}
			else
			{
				method_37(readHTMLEventArgs_0);
				method_19(readHTMLEventArgs_0);
			}
		}

		private void method_37(ReadHTMLEventArgs readHTMLEventArgs_0)
		{
			int num = 6;
			if (readHTMLEventArgs_0.HtmlElement.method_13("listitemcount") && !readHTMLEventArgs_0.HtmlElement.method_13("listtemp"))
			{
				int num2 = readHTMLEventArgs_0.ToInt32(readHTMLEventArgs_0.HtmlElement.method_9("listitemcount"));
				EnsureHasListItemsInstance();
				FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
				for (int i = 0; i < num2; i++)
				{
					ListItem listItem = new ListItem();
					listItem.Text = readHTMLEventArgs_0.HtmlElement.method_9("listtext" + i);
					listItem.Value = readHTMLEventArgs_0.HtmlElement.method_9("listvalue" + i);
					listItem.TextInList = readHTMLEventArgs_0.HtmlElement.method_9("listtextinlist" + i);
					FieldSettings.ListSource.Items.Add(listItem);
				}
			}
		}

		public override void Dispose()
		{
			base.Dispose();
			string_28 = null;
			string_27 = null;
			if (inputFieldSettings_0 != null)
			{
				inputFieldSettings_0 = null;
			}
			inputFieldSettings_0 = null;
			if (listItemCollection_0 != null)
			{
				listItemCollection_0.Clear();
				listItemCollection_0 = null;
			}
			linkListBindingInfo_0 = null;
		}
	}
}
