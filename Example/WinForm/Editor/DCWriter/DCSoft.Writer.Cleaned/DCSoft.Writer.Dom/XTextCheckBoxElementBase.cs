using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.WinForms;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Data;
using DCSoft.Writer.Expression;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       复选框控件基础对象类型
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[ToolboxBitmap(typeof(XTextCheckBoxElementBase))]
	
	[Guid("00012345-6789-ABCD-EF01-23456789004F")]
	[DebuggerDisplay("CheckBox:Group={GroupName} , Checked={Checked}")]
	[ComVisible(true)]
	
	public class XTextCheckBoxElementBase : XTextObjectElement, IUpdateDataBindingExt
	{
		private DataFeedbackInfo dataFeedbackInfo_0 = null;

		private bool bool_9 = false;

		private string string_9 = null;

		private bool bool_10 = false;

		private bool bool_11 = false;

		private string string_10 = null;

		private RenderVisibility renderVisibility_0 = RenderVisibility.All;

		private PrintVisibilityModeWhenUnchecked printVisibilityModeWhenUnchecked_0 = PrintVisibilityModeWhenUnchecked.Visible;

		private string string_11 = null;

		private string string_12 = null;

		private bool bool_12 = false;

		[NonSerialized]
		private bool bool_13 = false;

		private bool bool_14 = true;

		private string string_13 = null;

		private string string_14 = null;

		private StringAlignment stringAlignment_0 = StringAlignment.Center;

		private XDataBinding xdataBinding_0 = null;

		[NonSerialized]
		private DataSourceTreeNode dataSourceTreeNode_0 = null;

		[NonSerialized]
		private bool bool_15 = false;

		[NonSerialized]
		private int int_8 = 0;

		private CheckBoxControlStyle checkBoxControlStyle_0 = CheckBoxControlStyle.CheckBox;

		private bool bool_16 = false;

		private bool bool_17 = false;

		private string string_15 = null;

		private string string_16 = null;

		private bool bool_18 = false;

		private EnableState enableState_0 = EnableState.Enabled;

		private EventExpressionInfoList eventExpressionInfoList_0 = null;

		private CheckBoxVisualStyle checkBoxVisualStyle_0 = CheckBoxVisualStyle.Default;

		private bool bool_19 = false;

		/// <summary>
		///       数据回填信息对象
		///       </summary>
		[DefaultValue(null)]
		[ComVisible(true)]
		[XmlElement]
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
		///       必填项。必须设置元素的Name属性，本设置才有效。
		///       </summary>
		[HtmlAttribute]
		[ComVisible(true)]
		
		[DefaultValue(false)]
		public bool Requried
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

		internal bool RuntimeRequired
		{
			get
			{
				if (XTextDocument.smethod_13(GEnum6.const_190))
				{
					return bool_9;
				}
				return false;
			}
		}

		/// <summary>
		///       数据名称
		///       </summary>
		[DefaultValue(null)]
		
		[MemberExpressionable]
		[ComVisible(true)]
		[HtmlAttribute]
		public virtual string DataName
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
		///       数据能否被其他地方引用。需要应用程序支持。
		///       </summary>
		[HtmlAttribute]
		[MemberExpressionable]
		[DefaultValue(false)]
		
		[ComVisible(true)]
		public bool CanBeReferenced
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
		///       保存文档时是否将该节点数据单独拿出来保存。需要应用程序支持。
		///       </summary>
		[DefaultValue(false)]
		[HtmlAttribute]
		[ComVisible(true)]
		
		[MemberExpressionable]
		public bool BringoutToSave
		{
			get
			{
				return bool_11;
			}
			set
			{
				bool_11 = value;
			}
		}

		/// <summary>
		///       引用的数据名称
		///       </summary>
		
		[MemberExpressionable]
		[ComVisible(true)]
		[DefaultValue(null)]
		[HtmlAttribute]
		public string ReferencedDataName
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
		///       勾选框可见性
		///       </summary>
		[ComVisible(true)]
		[DefaultValue(RenderVisibility.All)]
		
		[HtmlAttribute]
		public RenderVisibility CheckboxVisibility
		{
			get
			{
				return renderVisibility_0;
			}
			set
			{
				renderVisibility_0 = value;
			}
		}

		/// <summary>
		///       未勾选时的打印可见性设置
		///       </summary>
		[Browsable(true)]
		
		[DefaultValue(PrintVisibilityModeWhenUnchecked.Visible)]
		[ComVisible(true)]
		public PrintVisibilityModeWhenUnchecked PrintVisibilityWhenUnchecked
		{
			get
			{
				return printVisibilityModeWhenUnchecked_0;
			}
			set
			{
				printVisibilityModeWhenUnchecked_0 = value;
			}
		}

		internal PrintVisibilityModeWhenUnchecked RuntimePrintVisibilityWhenUnchecked
		{
			get
			{
				if (XTextDocument.smethod_13(GEnum6.const_191))
				{
					return printVisibilityModeWhenUnchecked_0;
				}
				return PrintVisibilityModeWhenUnchecked.Visible;
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
				switch (OwnerDocument.Options.ViewOptions.DefaultAdornTextType)
				{
				case InputFieldAdornTextType.Default:
					return null;
				case InputFieldAdornTextType.DataSource:
					if (ValueBinding != null && !ValueBinding.IsEmptyBinding)
					{
						return ValueBinding.DataSource + "#" + ValueBinding.BindingPath;
					}
					return null;
				case InputFieldAdornTextType.ToolTip:
					return ToolTip;
				default:
					return null;
				case InputFieldAdornTextType.ID:
					return base.ID;
				case InputFieldAdornTextType.Name:
					return base.Name;
				}
			}
		}

		/// <summary>
		///       勾选时的打印输出的文本。在打印或者输出HTML/PDF文件时不输出勾选图像，而是输出此文本。如果输出空格，则要使用两个双引号包围起来。
		///       </summary>
		[Category("Appearance")]
		[ComVisible(true)]
		[DefaultValue(null)]
		[HtmlAttribute]
		
		public string PrintTextForChecked
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
		///       不勾选时的打印输出的文本。在打印或者输出HTML/PDF文件时不输出勾选图像，而是输出此文本。如果输出空格，则要使用两个双引号包围起来。
		///       </summary>
		[HtmlAttribute]
		[ComVisible(true)]
		[Category("Appearance")]
		
		[DefaultValue(null)]
		public string PrintTextForUnChecked
		{
			get
			{
				return string_12;
			}
			set
			{
				string_12 = value;
			}
		}

		/// <summary>
		///       只在勾选的时候打印勾选框。如果不勾选则不打印勾选框。默认false。
		///       </summary>
		[ComVisible(true)]
		[Category("Appearance")]
		
		[Obsolete("请使用PrintVisibilityWhenUnchecked属性。")]
		[XmlIgnore]
		[DefaultValue(false)]
		public bool PrintBoxOnlyChecked
		{
			get
			{
				return PrintVisibilityWhenUnchecked == PrintVisibilityModeWhenUnchecked.HiddenCheckBoxOnly;
			}
			set
			{
				if (value)
				{
					PrintVisibilityWhenUnchecked = PrintVisibilityModeWhenUnchecked.HiddenCheckBoxOnly;
				}
				else
				{
					PrintVisibilityWhenUnchecked = PrintVisibilityModeWhenUnchecked.Visible;
				}
			}
		}

		/// <summary>
		///       打印时复选框是否可见
		///       </summary>
		internal bool BoxVisibleForPrint => Checked || RuntimePrintVisibilityWhenUnchecked == PrintVisibilityModeWhenUnchecked.Visible;

		/// <summary>
		///       打印时文本是否可见
		///       </summary>
		internal bool TextVisibleForPrint => Checked || RuntimePrintVisibilityWhenUnchecked == PrintVisibilityModeWhenUnchecked.Visible || RuntimePrintVisibilityWhenUnchecked == PrintVisibilityModeWhenUnchecked.HiddenCheckBoxOnly;

		/// <summary>
		///       运行时使用的文档行垂直对齐方式
		///       </summary>
		
		public override VerticalAlignStyle RuntimeVAlign => VerticalAlignStyle.Bottom;

		/// <summary>
		///       元素内容是否改变
		///       </summary>
		[Browsable(true)]
		[ComVisible(true)]
		[XmlIgnore]
		
		public override bool Modified
		{
			get
			{
				return bool_13;
			}
			set
			{
				bool_13 = value;
			}
		}

		/// <summary>
		///       勾选框靠左侧对齐
		///       </summary>
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		
		[DefaultValue(true)]
		[ComVisible(true)]
		[Category("Appearance")]
		[HtmlAttribute]
		public bool CheckAlignLeft
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
		///       提示文本
		///       </summary>
		
		[HtmlAttribute]
		[DefaultValue(null)]
		public string ToolTip
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
		///       复选框后面跟着的文本
		///       </summary>
		[HtmlAttribute]
		
		[ComVisible(true)]
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		[DefaultValue(null)]
		public string Caption
		{
			get
			{
				return string_14;
			}
			set
			{
				string_14 = value;
			}
		}

		/// <summary>
		///       标题文本对齐方式
		///       </summary>
		[HtmlAttribute]
		
		[ComVisible(true)]
		[DefaultValue(StringAlignment.Center)]
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		public StringAlignment CaptionAlign
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
		///       运行时的是否支持数据源绑定功能
		///       </summary>
		internal virtual bool RuntimeSupportValueBinding => XTextDocument.smethod_13(GEnum6.const_187);

		/// <summary>
		///       内容绑定对象
		///       </summary>
		
		[DefaultValue(null)]
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
		///       绑定的数据源对象
		///       </summary>
		
		[XmlIgnore]
		[ComVisible(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(null)]
		[Browsable(true)]
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
		[ComVisible(false)]
		[DefaultValue(false)]
		
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(true)]
		[XmlIgnore]
		public bool DataBoundNodeValueUsed
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
		///       显示在用户界面上的图片
		///       </summary>
		internal Bitmap DisplayImage
		{
			get
			{
				switch (RuntimeVisualStyle)
				{
				case CheckBoxVisualStyle.SystemCheckBox:
					if (Checked)
					{
						return DCStdImageList.Instance.BmpSystemCheckBoxChecked;
					}
					return DCStdImageList.Instance.BmpSystemCheckBoxUnchecked;
				case CheckBoxVisualStyle.SystemRadioBox:
					if (Checked)
					{
						return DCStdImageList.Instance.BmpSystemRadioBoxChecked;
					}
					return DCStdImageList.Instance.BmpSystemRadioBoxUnchecked;
				case CheckBoxVisualStyle.CheckBox:
					if (Checked)
					{
						return DCStdImageList.Instance.BmpCheckBoxChecked;
					}
					return DCStdImageList.Instance.BmpCheckBoxUnchecked;
				default:
					if (Checked)
					{
						return DCStdImageList.Instance.BmpRadioBoxChecked;
					}
					return DCStdImageList.Instance.BmpRadioBoxUnchecked;
				}
			}
		}

		/// <summary>
		///       多行模式可以改变大小，单行模式不能改变大小
		///       </summary>
		[Browsable(false)]
		
		[XmlIgnore]
		public override ResizeableType Resizeable
		{
			get
			{
				if (RuntimeMultiline)
				{
					return ResizeableType.WidthAndHeight;
				}
				return ResizeableType.FixSize;
			}
			set
			{
				base.Resizeable = value;
			}
		}

		/// <summary>
		///       对象宽度
		///       </summary>
		
		[Browsable(true)]
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
				return base.Name;
			}
		}

		/// <summary>
		///       本属性已经不推荐使用了，请使用Name属性。
		///       </summary>
		[XmlElement]
		[Browsable(false)]
		[DefaultValue(null)]
		
		public virtual string GroupName
		{
			get
			{
				return base.Name;
			}
			set
			{
				base.Name = value;
			}
		}

		/// <summary>
		///       运行时使用的分组名称
		///       </summary>
		
		public string RuntimeGroupName
		{
			get
			{
				int num = 5;
				if (ValueBinding != null && !ValueBinding.IsEmptyBinding)
				{
					return ValueBinding.DataSource + "#" + ValueBinding.BindingPath;
				}
				if (!string.IsNullOrEmpty(base.Name))
				{
					return base.Name;
				}
				return base.ID;
			}
		}

		
		[MemberExpressionable(MemberEffectLevel.DOM)]
		[XmlIgnore]
		public override string FormulaValue
		{
			get
			{
				if (Checked)
				{
					return CheckedValue;
				}
				return null;
			}
			set
			{
				bool flag2 = EditorChecked = Convert.ToBoolean(value);
			}
		}

		/// <summary>
		///       分组信息版本号
		///       </summary>
		internal int GroupInfoVersion
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
		///       控件样式
		///       </summary>
		[Browsable(false)]
		[DefaultValue(CheckBoxControlStyle.CheckBox)]
		[HtmlAttribute]
		
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual CheckBoxControlStyle ControlStyle
		{
			get
			{
				return checkBoxControlStyle_0;
			}
			set
			{
				checkBoxControlStyle_0 = (CheckBoxControlStyle)WriterUtils.FixEnumValue(value);
			}
		}

		/// <summary>
		///       选中状态。本属性只是快速的设置一个状态，不执行表达式和事件VBA脚本，不触发任何事件。
		///       </summary>
		/// <remarks>
		///       若要触发事件，执行相关的表达式，请调用EditorChecked属性。
		///       </remarks>
		
		[MemberExpressionable(MemberEffectLevel.ElementView)]
		[DefaultValue(false)]
		public bool Checked
		{
			get
			{
				return bool_16;
			}
			set
			{
				if (bool_16 != value)
				{
					bool_16 = value;
					_ContentVersion++;
				}
			}
		}

		/// <summary>
		///       数据源绑定操作时默认勾选状态
		///       </summary>
		/// <remarks>
		///       在执行数据源绑定时，如果读取的数据为空，则需要设置的默认勾选状态。
		///       </remarks>
		
		[ComVisible(true)]
		[MemberExpressionable(MemberEffectLevel.ElementView)]
		[DefaultValue(false)]
		public bool DefaultCheckedForValueBinding
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
		///       勾选状态的值
		///       </summary>
		[DefaultValue(null)]
		
		public string CheckedValue
		{
			get
			{
				return string_15;
			}
			set
			{
				string_15 = value;
			}
		}

		/// <summary>
		///       没有勾选状态的值
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("!!!属性已经废除!!!")]
		[DefaultValue(null)]
		public string UnCheckedValue
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
		///       对象数值
		///       </summary>
		
		[Browsable(false)]
		[XmlIgnore]
		public string Value
		{
			get
			{
				if (Checked)
				{
					return CheckedValue;
				}
				return null;
			}
			set
			{
				if (value == CheckedValue)
				{
					Checked = true;
				}
				else
				{
					Checked = false;
				}
			}
		}

		/// <summary>
		///       只读的
		///       </summary>
		
		[DefaultValue(false)]
		public bool Readonly
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

		[Browsable(false)]
		public override bool MouseClickToSelect => false;

		/// <summary>
		///       编辑器中设置或获得选择状态，就完全模拟用户鼠标点击设置勾选状态。触发表达式和事件。
		///       </summary>
		[XmlIgnore]
		
		[Browsable(false)]
		public virtual bool EditorChecked
		{
			get
			{
				return Checked;
			}
			set
			{
				int num = 1;
				if (Checked == value || !OwnerDocument.DocumentControler.CanModify(this))
				{
					return;
				}
				XTextElementList xTextElementList = new XTextElementList();
				if (value && ControlStyle == CheckBoxControlStyle.RadioBox)
				{
					xTextElementList = GetElementsInSameGroup();
					if (value)
					{
						for (int num2 = xTextElementList.Count - 1; num2 >= 0; num2--)
						{
							XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)xTextElementList[num2];
							if (!OwnerDocument.DocumentControler.CanModify(xTextCheckBoxElementBase))
							{
								xTextElementList.RemoveAt(num2);
							}
							else if (xTextCheckBoxElementBase != this && !xTextCheckBoxElementBase.Checked)
							{
								xTextElementList.RemoveAt(num2);
							}
						}
					}
					if (xTextElementList.Contains(this))
					{
						xTextElementList.Remove(this);
						xTextElementList.Add(this);
					}
				}
				else
				{
					xTextElementList.Add(this);
				}
				ContentChangingEventArgs contentChangingEventArgs = new ContentChangingEventArgs();
				contentChangingEventArgs.Document = OwnerDocument;
				contentChangingEventArgs.Tag = this;
				contentChangingEventArgs.Element = this;
				foreach (XTextCheckBoxElementBase item in xTextElementList)
				{
					item.vmethod_28(this, contentChangingEventArgs);
					if (contentChangingEventArgs.Cancel)
					{
						return;
					}
				}
				if (OwnerDocument.BeginLogUndo())
				{
					foreach (XTextCheckBoxElementBase item2 in xTextElementList)
					{
						OwnerDocument.UndoList.AddProperty("InnerEditorChecked", item2.Checked, !item2.Checked, item2);
					}
					OwnerDocument.EndLogUndo();
				}
				foreach (XTextCheckBoxElementBase item3 in xTextElementList)
				{
					item3.Checked = !item3.Checked;
				}
				foreach (XTextCheckBoxElementBase item4 in xTextElementList)
				{
					ContentChangedEventArgs contentChangedEventArgs = new ContentChangedEventArgs();
					contentChangedEventArgs.Document = OwnerDocument;
					contentChangedEventArgs.Element = this;
					contentChangedEventArgs.Tag = this;
					if (WriterControl != null)
					{
						WriterControl.InnerViewControl.LockScrollPosition = true;
					}
					try
					{
						item4.vmethod_29(item4, contentChangedEventArgs);
					}
					finally
					{
						if (WriterControl != null)
						{
							WriterControl.InnerViewControl.LockScrollPosition = false;
						}
					}
					item4.InvalidateView();
				}
				OwnerDocument.Modified = true;
				OwnerDocument.OnDocumentContentChanged();
				if (WriterControl != null)
				{
					WriterControl.vmethod_13(base.ID, base.Name, Checked ? CheckedValue : "", this);
				}
			}
		}

		/// <summary>
		///       DCWriter内部使用。编辑器中设置或获得选择状态，该属性内部使用，而且不会记录撤销操作信息
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		
		public bool InnerEditorChecked
		{
			set
			{
				if (Checked != value)
				{
					ContentChangingEventArgs contentChangingEventArgs = new ContentChangingEventArgs();
					contentChangingEventArgs.Document = OwnerDocument;
					contentChangingEventArgs.Tag = this;
					vmethod_28(this, contentChangingEventArgs);
					if (!contentChangingEventArgs.Cancel)
					{
						Checked = value;
						ContentChangedEventArgs contentChangedEventArgs = new ContentChangedEventArgs();
						contentChangedEventArgs.Document = OwnerDocument;
						contentChangedEventArgs.Tag = this;
						vmethod_29(this, contentChangedEventArgs);
						InvalidateView();
					}
				}
			}
		}

		/// <summary>
		///       是否允许高亮度显示状态
		///       </summary>
		[HtmlAttribute]
		
		[DefaultValue(EnableState.Enabled)]
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
		///       事件表达式列表
		///       </summary>
		[DefaultValue(null)]
		[XmlArrayItem("Expression", typeof(EventExpressionInfo))]
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
		///       返回表示对象数据的文本
		///       </summary>
		
		[XmlIgnore]
		[Browsable(false)]
		public override string Text
		{
			get
			{
				return Caption;
			}
			set
			{
				Caption = value;
			}
		}

		[XmlIgnore]
		
		public override string OuterText
		{
			get
			{
				if (CheckAlignLeft)
				{
					return CheckBoxText + Caption;
				}
				return Caption + CheckBoxText;
			}
			set
			{
			}
		}

		/// <summary>
		///       复选框标题文本
		///       </summary>
		internal string CheckBoxText
		{
			get
			{
				int num = 16;
				if (!Checked && RuntimePrintVisibilityWhenUnchecked != 0)
				{
					return "  ";
				}
				string text = Checked ? method_16(PrintTextForChecked) : method_16(PrintTextForUnChecked);
				if (!string.IsNullOrEmpty(text))
				{
					return text;
				}
				if (!string.IsNullOrEmpty(PrintTextForChecked))
				{
					if (Checked)
					{
						return PrintTextForChecked;
					}
					return "";
				}
				if (ControlStyle == CheckBoxControlStyle.CheckBox)
				{
					if (Checked)
					{
						return "■";
					}
					return "□";
				}
				if (Checked)
				{
					return "●";
				}
				return "○";
			}
		}

		/// <summary>
		///       复选框视图样式
		///       </summary>
		[DefaultValue(CheckBoxVisualStyle.Default)]
		[HtmlAttribute]
		
		public CheckBoxVisualStyle VisualStyle
		{
			get
			{
				return checkBoxVisualStyle_0;
			}
			set
			{
				checkBoxVisualStyle_0 = value;
			}
		}

		/// <summary>
		///       运行时使用的控件样式
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		
		public CheckBoxVisualStyle RuntimeVisualStyle
		{
			get
			{
				if (!XTextDocument.smethod_13(GEnum6.const_192) || VisualStyle == CheckBoxVisualStyle.Default)
				{
					if (ControlStyle == CheckBoxControlStyle.CheckBox)
					{
						return CheckBoxVisualStyle.CheckBox;
					}
					if (ControlStyle == CheckBoxControlStyle.RadioBox)
					{
						return CheckBoxVisualStyle.RadioBox;
					}
					return CheckBoxVisualStyle.CheckBox;
				}
				if (VisualStyle == CheckBoxVisualStyle.SystemDefault)
				{
					if (ControlStyle == CheckBoxControlStyle.CheckBox)
					{
						return CheckBoxVisualStyle.SystemCheckBox;
					}
					if (ControlStyle == CheckBoxControlStyle.RadioBox)
					{
						return CheckBoxVisualStyle.SystemRadioBox;
					}
					return CheckBoxVisualStyle.SystemCheckBox;
				}
				if (VisualStyle == CheckBoxVisualStyle.CheckBox)
				{
					return CheckBoxVisualStyle.CheckBox;
				}
				if (VisualStyle == CheckBoxVisualStyle.RadioBox)
				{
					return CheckBoxVisualStyle.RadioBox;
				}
				if (VisualStyle == CheckBoxVisualStyle.SystemCheckBox)
				{
					return CheckBoxVisualStyle.SystemCheckBox;
				}
				if (VisualStyle == CheckBoxVisualStyle.SystemRadioBox)
				{
					return CheckBoxVisualStyle.SystemRadioBox;
				}
				return CheckBoxVisualStyle.CheckBox;
			}
		}

		/// <summary>
		///       多行文本
		///       </summary>
		
		[HtmlAttribute]
		[DefaultValue(false)]
		public bool Multiline
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

		internal bool RuntimeMultiline
		{
			get
			{
				if (XTextDocument.smethod_13(GEnum6.const_189))
				{
					return bool_19;
				}
				return false;
			}
		}

		/// <summary>
		///       运行时的元素是否可见
		///       </summary>
		
		public override bool RuntimeVisible
		{
			get
			{
				bool runtimeVisible;
				if ((runtimeVisible = base.RuntimeVisible) && !Checked && RuntimePrintVisibilityWhenUnchecked == PrintVisibilityModeWhenUnchecked.HiddenAll && OwnerDocument != null && (OwnerDocument.States.Printing || OwnerDocument.States.PrintPreviewing))
				{
					return false;
				}
				return runtimeVisible;
			}
			set
			{
				base.RuntimeVisible = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		protected XTextCheckBoxElementBase()
		{
		}

		private string method_16(string string_17)
		{
			if (string_17 == null || string.IsNullOrEmpty(string_17))
			{
				return string_17;
			}
			if (string_17.Length > 2 && string_17[0] == '"' && string_17[string_17.Length - 1] == '"')
			{
				return string_17.Substring(1, string_17.Length - 2);
			}
			return string_17;
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
				UpdateDataBindingArgs updateDataBindingArgs = new UpdateDataBindingArgs();
				updateDataBindingArgs.FastMode = true;
				UpdateDataBindingExt(updateDataBindingArgs);
			}
		}

		internal DataSourceTreeNode method_17()
		{
			if (!XTextDocument.smethod_13(GEnum6.const_187))
			{
				return null;
			}
			return method_2(ValueBinding, null);
		}

		
		public virtual int UpdateDataBindingExt(UpdateDataBindingArgs args)
		{
			int num = 13;
			if (!XTextDocument.smethod_13(GEnum6.const_187))
			{
				return 0;
			}
			XDataBinding xDataBinding = RuntimeSupportValueBinding ? ValueBinding : null;
			if (xDataBinding == null)
			{
				return 0;
			}
			if (args == null)
			{
				throw new ArgumentNullException("args");
			}
			if (!args.DetectValueModified)
			{
				DataBoundNodeValueUsed = false;
			}
			if (OwnerDocument.method_104(xDataBinding))
			{
				if (!args.CheckForSpecifyParameterName(xDataBinding))
				{
					return 0;
				}
				if (!args.DetectValueModified)
				{
					ValueBinding.Handled = true;
				}
				_ = OwnerDocument;
				DataSourceTreeNode dataSourceTreeNode = method_2(xDataBinding, args);
				if (!args.DetectValueModified)
				{
					DataBoundNode = dataSourceTreeNode;
				}
				bool flag = false;
				if (!(dataSourceTreeNode?.IsEmpty ?? true))
				{
					if (!args.DetectValueModified)
					{
						DataBoundNodeValueUsed = true;
					}
					object runtimeDisplayValue = dataSourceTreeNode.RuntimeDisplayValue;
					if (runtimeDisplayValue == null || DBNull.Value.Equals(runtimeDisplayValue))
					{
						flag = DefaultCheckedForValueBinding;
					}
					else if (runtimeDisplayValue is bool)
					{
						flag = (bool)runtimeDisplayValue;
					}
					else if (!string.IsNullOrEmpty(CheckedValue))
					{
						IDList iDList = new IDList(Convert.ToString(runtimeDisplayValue), ',');
						flag = iDList.Contains(CheckedValue);
					}
					else
					{
						bool result = false;
						Convert.ToString(runtimeDisplayValue);
						flag = ((!bool.TryParse(Convert.ToString(runtimeDisplayValue), out result)) ? DefaultCheckedForValueBinding : result);
					}
				}
				if (args.DetectValueModified)
				{
					if (Checked != flag)
					{
						DetectResultForValueBindingModified item = new DetectResultForValueBindingModified(ValueBinding, this, Checked.ToString(), flag.ToString());
						args.AddDetectResult(item);
					}
					return 0;
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
				if (xDataBinding.ProcessState == DCProcessStates.Once)
				{
					xDataBinding.ProcessState = DCProcessStates.Never;
				}
				if (Checked != flag)
				{
					Checked = flag;
					if (DataFeedback != null)
					{
						DataFeedback.ContentVersion = base.ContentVersion;
					}
					if (!args.FastMode)
					{
						InvalidateView();
					}
					args.AddHandledElement(this);
					return 1;
				}
			}
			return 0;
		}

		
		public virtual FieldValueDescriptor vmethod_26()
		{
			FieldValueDescriptor fieldValueDescriptor = null;
			if (ValueBinding != null)
			{
				fieldValueDescriptor = new FieldValueDescriptor();
				fieldValueDescriptor.Readonly = ValueBinding.Readonly;
				fieldValueDescriptor.DataSource = ValueBinding.DataSource;
				fieldValueDescriptor.BindingPath = ValueBinding.BindingPath;
				fieldValueDescriptor.BindingPathForText = ValueBinding.BindingPathForText;
				fieldValueDescriptor.Element = this;
				fieldValueDescriptor.ID = base.ID;
				fieldValueDescriptor.Name = base.Name;
				fieldValueDescriptor.Value = Value;
				fieldValueDescriptor._ContentVersion = base.ContentVersion;
			}
			return fieldValueDescriptor;
		}

		
		public virtual bool vmethod_27(FieldValueDescriptor fieldValueDescriptor_0, bool bool_20)
		{
			if (fieldValueDescriptor_0 != null)
			{
				XTextDocument ownerDocument = OwnerDocument;
				if (!ownerDocument.Options.BehaviorOptions.EnableDataBinding)
				{
					return false;
				}
				bool flag = false;
				if (string.IsNullOrEmpty(fieldValueDescriptor_0.Value))
				{
					flag = false;
				}
				else
				{
					bool result = false;
					bool.TryParse(fieldValueDescriptor_0.Value, out result);
					flag = result;
				}
				if (Checked != flag)
				{
					Checked = flag;
					if (!bool_20)
					{
						InvalidateView();
					}
					return true;
				}
			}
			return false;
		}

		
		public void SetValueInDocument(string Value, char splitChar = ',')
		{
			if (Value != null && Value.Length > 0)
			{
				Value.Split(splitChar);
			}
			XTextElementList elementsInSameGroup = GetElementsInSameGroup();
			if (elementsInSameGroup.Count == 1 && CheckedValue == Value)
			{
				Checked = true;
				return;
			}
			if (this is XTextRadioBoxElement)
			{
				foreach (XTextRadioBoxElement item in elementsInSameGroup)
				{
					item.Checked = (item.CheckedValue == Value);
				}
				return;
			}
			IDList iDList = new IDList(Value, splitChar);
			foreach (XTextCheckBoxElementBase item2 in elementsInSameGroup)
			{
				item2.Checked = iDList.Contains(item2.CheckedValue);
			}
		}

		
		[ComVisible(true)]
		public string GetAllValueInDocument(char splitChar = ',')
		{
			int num = 17;
			if (OwnerDocument == null)
			{
				return null;
			}
			XTextElementList elementsInSameGroup = GetElementsInSameGroup();
			if (elementsInSameGroup.Count == 1 && Checked && (CheckedValue == null || CheckedValue.Length == 0))
			{
				return "true";
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (XTextCheckBoxElementBase item in elementsInSameGroup)
			{
				if (item.Checked)
				{
					if (item.CheckedValue != null && item.CheckedValue.Length > 0)
					{
						if (stringBuilder.Length > 0)
						{
							stringBuilder.Append(splitChar);
						}
						stringBuilder.Append(item.CheckedValue);
					}
					if (item is XTextRadioBoxElement)
					{
						break;
					}
				}
			}
			return stringBuilder.ToString();
		}

		/// <summary>
		///       获得文档中所有同组的复选框对象列表
		///       </summary>
		/// <returns>
		/// </returns>
		
		public XTextElementList GetElementsInSameGroup()
		{
			if (OwnerDocument == null)
			{
				return null;
			}
			if (string.IsNullOrEmpty(RuntimeGroupName))
			{
				return new XTextElementList(this);
			}
			XTextElementList xTextElementList = OwnerDocument.CheckBoxGroupInfo.method_5(this);
			if (xTextElementList == null || xTextElementList.Count == 0)
			{
				xTextElementList = new XTextElementList();
				xTextElementList.Add(this);
			}
			return xTextElementList;
		}

		/// <summary>
		///       处理文档事件
		///       </summary>
		/// <param name="args">
		/// </param>
		
		public override void HandleDocumentEvent(DocumentEventArgs args)
		{
			if (args.Style == DocumentEventStyles.MouseClick)
			{
				if (OwnerDocument.Options.BehaviorOptions.DesignMode)
				{
					base.HandleDocumentEvent(args);
				}
				else if (base.Enabled)
				{
					if (!Readonly && OwnerDocument.DocumentControler.CanModify(this, DomAccessFlags.CheckControlReadonly | DomAccessFlags.CheckUserEditable | DomAccessFlags.CheckReadonly | DomAccessFlags.CheckPermission | DomAccessFlags.CheckLock | DomAccessFlags.CheckContentProtect | DomAccessFlags.CheckContainerReadonly))
					{
						if (OwnerDocument.UIStartEditContent())
						{
							if (WriterControl.FormView != FormViewMode.Strict)
							{
								base.DocumentContentElement.Content.CurrentElement = this;
							}
							EditorChecked = !Checked;
						}
						args.Handled = true;
						args.Cursor = Cursors.Arrow;
					}
					method_13(args);
				}
				args.Handled = true;
			}
			else if (args.Style == DocumentEventStyles.MouseMove)
			{
				if (OwnerDocument.EditorControl != null)
				{
					if (!RuntimeMultiline)
					{
						args.Cursor = Cursors.Arrow;
					}
					else
					{
						base.HandleDocumentEvent(args);
					}
					args.Handled = true;
				}
			}
			else if (args.Style == DocumentEventStyles.MouseDown)
			{
				args.Cursor = Cursors.Arrow;
				base.HandleDocumentEvent(args);
				if (base.Enabled && !OwnerDocument.Options.BehaviorOptions.DesignMode)
				{
					args.Handled = true;
				}
			}
			else
			{
				base.HandleDocumentEvent(args);
			}
		}

		/// <summary>
		///       获得提示文本信息
		///       </summary>
		/// <returns>
		/// </returns>
		
		public override GClass96 GetToolTipInfo()
		{
			GClass96 gClass = base.GetToolTipInfo();
			if (gClass == null && !string.IsNullOrEmpty(ToolTip))
			{
				gClass = new GClass96(this, ToolTip);
				gClass.method_12(ToolTipContentType.ElementToolTip);
			}
			return gClass;
		}

		
		public override void vmethod_7(ElementEventArgs elementEventArgs_0)
		{
			if (!string.IsNullOrEmpty(GroupName))
			{
				InvalidateHighlightInfo();
			}
			else
			{
				OwnerDocument.HighlightManager.imethod_8(this);
			}
			base.vmethod_7(elementEventArgs_0);
		}

		
		public override void vmethod_8(ElementEventArgs elementEventArgs_0)
		{
			if (!string.IsNullOrEmpty(GroupName))
			{
				InvalidateHighlightInfo();
			}
			else if (OwnerDocument.HighlightManager != null)
			{
				OwnerDocument.HighlightManager.imethod_8(this);
			}
			base.vmethod_8(elementEventArgs_0);
		}

		
		public override void OnViewGotFocus(ElementEventArgs elementEventArgs_0)
		{
			InvalidateHighlightInfo();
			base.OnViewGotFocus(elementEventArgs_0);
		}

		
		public override void OnViewLostFocus(ElementEventArgs elementEventArgs_0)
		{
			InvalidateHighlightInfo();
			base.OnViewLostFocus(elementEventArgs_0);
		}

		/// <summary>
		///       声明同组的所有的复选框元素高亮度显示信息无效
		///       </summary>
		
		public override void InvalidateHighlightInfo()
		{
			if (!string.IsNullOrEmpty(GroupName) && OwnerDocument.HighlightManager != null && OwnerDocument.Options.ViewOptions.FieldFocusedBackColor.A != 0)
			{
				XTextElementList elementsInSameGroup = GetElementsInSameGroup();
				foreach (XTextElement item in elementsInSameGroup)
				{
					OwnerDocument.HighlightManager.imethod_9(item);
					item.InvalidateView();
				}
			}
		}

		
		public override HighlightInfoList vmethod_20()
		{
			if (RuntimeEnableHighlight == EnableState.Disabled)
			{
				return null;
			}
			XTextElementList elementsInSameGroup = GetElementsInSameGroup();
			if (elementsInSameGroup == null || elementsInSameGroup.Count <= 1)
			{
				return null;
			}
			Color backColor = Color.Transparent;
			if (Focused)
			{
				backColor = OwnerDocument.Options.ViewOptions.FieldFocusedBackColor;
			}
			else if (OwnerDocument.IsHover(this))
			{
				backColor = OwnerDocument.Options.ViewOptions.FieldHoverBackColor;
			}
			if (backColor.A != 0)
			{
				HighlightInfoList highlightInfoList = new HighlightInfoList();
				foreach (XTextElement item in elementsInSameGroup)
				{
					if (item.DocumentContentElement != null)
					{
						HighlightInfo highlightInfo = new HighlightInfo();
						highlightInfo.Range = new XTextRange(item.DocumentContentElement, item.ViewIndex, 1);
						highlightInfo.BackColor = backColor;
						highlightInfo.OwnerElement = item;
						highlightInfoList.Add(highlightInfo);
					}
				}
				return highlightInfoList;
			}
			return null;
		}

		
		public virtual void vmethod_28(object sender, ContentChangingEventArgs e)
		{
			OwnerDocument.method_47(this, "ContentChanging", new object[2]
			{
				this,
				e
			});
			if (OwnerDocument.Options.BehaviorOptions.EnableElementEvents)
			{
				ElementEventTemplateList events = Events;
				if (events != null && events.HasContentChanging)
				{
					events.OnContentChanging(sender, e);
				}
			}
		}

		
		public virtual void vmethod_29(object sender, ContentChangedEventArgs e)
		{
			int num = 19;
			if (!e.LoadingDocument)
			{
				Modified = true;
			}
			OwnerDocument.method_47(this, "ContentChanged", new object[2]
			{
				this,
				e
			});
			if (!e.LoadingDocument)
			{
				if (OwnerDocument.ExpressionExecuter != null)
				{
					OwnerDocument.ExpressionExecuter.imethod_9(this);
				}
				if (OwnerDocument.ElementIDForEditableDependentExecuter != null)
				{
					OwnerDocument.ElementIDForEditableDependentExecuter.Execute(this, fastMode: true);
				}
			}
			else
			{
				OwnerDocument.ElementIDForEditableDependentExecuter.Execute(this, fastMode: false);
			}
			if (OwnerDocument.Options.BehaviorOptions.EnableElementEvents && OwnerDocument.EnableContentChangedEvent)
			{
				ElementEventTemplateList events = Events;
				if (events != null && events.HasContentChanged)
				{
					events.OnContentChanged(sender, e);
				}
				if (Parent != null)
				{
					Parent.method_23(e);
				}
			}
		}

		
		public override void vmethod_17(ReadHTMLEventArgs readHTMLEventArgs_0)
		{
			int num = 5;
			base.ID = readHTMLEventArgs_0.HtmlElement.method_37();
			base.Name = readHTMLEventArgs_0.HtmlElement.method_9("name");
			readHTMLEventArgs_0.ReadDCCustomAttributes(readHTMLEventArgs_0.HtmlElement, this);
			CheckedValue = readHTMLEventArgs_0.HtmlElement.method_9("value");
			if (readHTMLEventArgs_0.HtmlElement.method_13("checked"))
			{
				string a = readHTMLEventArgs_0.HtmlElement.method_9("checked");
				if (a == "false")
				{
					Checked = false;
				}
				else
				{
					Checked = true;
				}
			}
			else
			{
				Checked = false;
			}
			if (readHTMLEventArgs_0.HtmlElement.method_13("disabled"))
			{
				Readonly = true;
			}
		}

		
		public override void vmethod_19(GClass103 gclass103_0)
		{
			gclass103_0.method_40(Text, RuntimeStyle);
		}

		/// <summary>
		///       返回纯文本
		///       </summary>
		/// <returns>
		/// </returns>
		
		public override string ToPlaintString()
		{
			return Text;
		}

		/// <summary>
		///       返回表示对象的字符串
		///       </summary>
		/// <returns>字符串</returns>
		
		public override string ToString()
		{
			int num = 13;
			if (ControlStyle == CheckBoxControlStyle.CheckBox)
			{
				return "CheckBox:" + Checked;
			}
			return "Radio:" + Checked;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <param name="Deeply">是否深入复制，无效</param>
		/// <returns>复制的对象</returns>
		
		public override XTextElement Clone(bool Deeply)
		{
			XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)base.Clone(Deeply);
			if (dataFeedbackInfo_0 != null)
			{
				xTextCheckBoxElementBase.dataFeedbackInfo_0 = dataFeedbackInfo_0.Clone();
			}
			if (eventExpressionInfoList_0 != null)
			{
				xTextCheckBoxElementBase.eventExpressionInfoList_0 = eventExpressionInfoList_0.Clone();
			}
			if (xdataBinding_0 != null)
			{
				xTextCheckBoxElementBase.xdataBinding_0 = xdataBinding_0.Clone();
			}
			xTextCheckBoxElementBase.int_8 = -1;
			return xTextCheckBoxElementBase;
		}

		
		public override void RefreshSize(DocumentPaintEventArgs args)
		{
			if (!RuntimeMultiline || Width <= 0f || Height <= 0f)
			{
				XTextDocument ownerDocument = OwnerDocument;
				SizeF sizeF = GraphicsUnitConvert.Convert(new Size(20, 20), GraphicsUnit.Pixel, ownerDocument.DocumentGraphicsUnit);
				if (!string.IsNullOrEmpty(Caption))
				{
					RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
					SizeF sizeF2 = args.Graphics.MeasureString(Caption, runtimeStyle.Font, 10000, args.Render.method_10());
					sizeF.Width = sizeF.Width + sizeF2.Width + 10f;
					sizeF.Height = Math.Max(sizeF.Height, args.Graphics.GetFontHeight(runtimeStyle.Font));
				}
				Width = sizeF.Width;
				Height = sizeF.Height;
			}
			SizeInvalid = false;
		}

		
		public override void DrawContent(DocumentPaintEventArgs args)
		{
			if (!XTextDocument.smethod_13(GEnum6.const_186) || (args.RenderMode == DocumentRenderMode.Print && !Checked && RuntimePrintVisibilityWhenUnchecked == PrintVisibilityModeWhenUnchecked.HiddenAll))
			{
				return;
			}
			RectangleF absBounds = AbsBounds;
			Image displayImage = DisplayImage;
			SizeF sizeF = GraphicsUnitConvert.Convert(new SizeF(displayImage.Width, displayImage.Height), GraphicsUnit.Pixel, OwnerDocument.DocumentGraphicsUnit);
			float num = absBounds.Left + 4f;
			if (!CheckAlignLeft)
			{
				num = absBounds.Right - sizeF.Width - 4f;
			}
			bool flag = true;
			string text = Caption;
			if (args.RenderMode == DocumentRenderMode.PDF || args.RenderMode == DocumentRenderMode.Print)
			{
				string text2 = Checked ? method_16(PrintTextForChecked) : method_16(PrintTextForUnChecked);
				if (!string.IsNullOrEmpty(text2))
				{
					text = ((!CheckAlignLeft) ? (Caption + text2) : (text2 + Caption));
					sizeF.Width = 0f;
					flag = false;
				}
			}
			if (flag && args.IsVisible(CheckboxVisibility))
			{
				if (args.RenderMode == DocumentRenderMode.PDF)
				{
					Bitmap bitmap = new Bitmap(displayImage.Width, displayImage.Height);
					using (Graphics graphics = Graphics.FromImage(bitmap))
					{
						graphics.Clear(Color.White);
						graphics.DrawImageUnscaled(displayImage, 0, 0);
					}
					args.Graphics.method_0(bitmap, new RectangleF(num, absBounds.Top + (absBounds.Height - sizeF.Height) / 2f, sizeF.Width, sizeF.Height), bool_1: true);
				}
				else
				{
					bool flag2 = true;
					if (!Checked && RuntimePrintVisibilityWhenUnchecked != 0 && args.RenderMode == DocumentRenderMode.Print)
					{
						flag2 = false;
					}
					if (flag2)
					{
						DrawerUtil.DrawImageUnscaledNearestNeighbor(args.Graphics, displayImage, (int)num, (int)(absBounds.Top + (absBounds.Height - sizeF.Height) / 2f));
					}
				}
			}
			if (args.Graphics != null)
			{
				args.Graphics.LogContent(CheckBoxText);
			}
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
			DrawStringFormatExt drawStringFormatExt = args.Render.method_10().Clone();
			float fontHeight = args.Graphics.GetFontHeight(runtimeStyle.Font);
			drawStringFormatExt.SetMultiLine(RuntimeMultiline);
			RectangleF clientViewBounds = args.ClientViewBounds;
			clientViewBounds.Width -= sizeF.Width;
			if (CheckAlignLeft)
			{
				clientViewBounds.X += sizeF.Width;
			}
			drawStringFormatExt.Alignment = CaptionAlign;
			drawStringFormatExt.LineAlignment = StringAlignment.Near;
			if (RuntimeMultiline)
			{
				drawStringFormatExt.LineAlignment = StringAlignment.Center;
			}
			else
			{
				XTextLine ownerLine = base.OwnerLine;
				if (ownerLine.RuntimeVerticalAlign != 0)
				{
					if (ownerLine.RuntimeVerticalAlign == VerticalAlignStyle.Middle)
					{
						clientViewBounds.Y += (clientViewBounds.Height - fontHeight) / 2f;
					}
					else if (ownerLine.RuntimeVerticalAlign == VerticalAlignStyle.Bottom)
					{
						clientViewBounds.Y += clientViewBounds.Height - fontHeight;
					}
				}
				clientViewBounds.Height = fontHeight;
				clientViewBounds.Y += args.Render.method_9().method_0();
			}
			drawStringFormatExt.Font = runtimeStyle.Font;
			drawStringFormatExt.Color = method_4(runtimeStyle.Color);
			drawStringFormatExt.SetBounds(clientViewBounds);
			args.Graphics.method_2(text, drawStringFormatExt);
		}

		public override void Dispose()
		{
			base.Dispose();
			string_14 = null;
			dataSourceTreeNode_0 = null;
			string_9 = null;
			if (eventExpressionInfoList_0 != null)
			{
				eventExpressionInfoList_0.Clear();
				eventExpressionInfoList_0 = null;
			}
			string_11 = null;
			string_12 = null;
			string_10 = null;
			string_13 = null;
			string_16 = null;
			xdataBinding_0 = null;
		}
	}
}
