using DCSoft.Common;
using DCSoft.Data;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Expression;
using DCSoftDotfuscate;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       文本输入域设置信息对象
	///       </summary>
	[ComVisible(false)]
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	public class XTextInputFieldElementProperties : GClass8
	{
		private string _ID = null;

		private float _SpecifyWidth = 0f;

		private EventExpressionInfoList _EventExpressions = null;

		private bool _MultiParagraph = false;

		private EnableState _EnableHighlight = EnableState.Enabled;

		private string _NextFieldVisibleExpression = null;

		private ElementType _AcceptChildElementTypes = ElementType.All;

		private string _Name = null;

		private ContentReadonlyState _ContentReadonly = ContentReadonlyState.False;

		private string _ToolTip = null;

		private string _BackgroundText = null;

		private bool _UserEditable = true;

		private ValueFormater _DisplayFormat = null;

		private XAttributeList _Attributes = null;

		private string _Text = null;

		private string _InitalizeInnerValue = null;

		private string _InitalizeText = null;

		private InputFieldSettings _FieldSettings = null;

		private XDataBinding _ValueBinding = null;

		private ValueValidateStyle _ValidateStyle = null;

		internal bool _ValidateStyleModified = true;

		/// <summary>
		///       编号
		///       </summary>
		public string ID
		{
			get
			{
				return _ID;
			}
			set
			{
				_ID = value;
			}
		}

		/// <summary>
		///       输入域指定宽度,若大于0则输入域宽度不小于该值，而且当内容很多时，自动变宽。
		///       </summary>
		[DefaultValue(0f)]
		public float SpecifyWidth
		{
			get
			{
				return _SpecifyWidth;
			}
			set
			{
				_SpecifyWidth = value;
			}
		}

		/// <summary>
		///       事件表达式列表
		///       </summary>
		[XmlArrayItem("Expression", typeof(EventExpressionInfo))]
		[DefaultValue(null)]
		public EventExpressionInfoList EventExpressions
		{
			get
			{
				return _EventExpressions;
			}
			set
			{
				_EventExpressions = value;
			}
		}

		/// <summary>
		///       能否接受多个段落
		///       </summary>
		[DefaultValue(false)]
		public bool MultiParagraph
		{
			get
			{
				return _MultiParagraph;
			}
			set
			{
				_MultiParagraph = value;
			}
		}

		/// <summary>
		///       是否允许高亮度显示状态
		///       </summary>
		[DefaultValue(EnableState.Enabled)]
		public EnableState EnableHighlight
		{
			get
			{
				return _EnableHighlight;
			}
			set
			{
				_EnableHighlight = value;
			}
		}

		/// <summary>
		///       控制下一个文本域可见性的数值
		///       </summary>
		/// <remarks>
		///       若文本输入域的文本值等于本属性值,则设置下一个文本域的可见,否则不可见.
		///       以此可以设置简单的级联输入域.
		///       </remarks>
		[DefaultValue(null)]
		public string NextFieldVisibleExpression
		{
			get
			{
				return _NextFieldVisibleExpression;
			}
			set
			{
				_NextFieldVisibleExpression = value;
			}
		}

		/// <summary>
		///       能接收的子元素类型
		///       </summary>
		[XmlElement]
		[DefaultValue(ElementType.All)]
		public ElementType AcceptChildElementTypes2
		{
			get
			{
				return _AcceptChildElementTypes;
			}
			set
			{
				_AcceptChildElementTypes = value;
			}
		}

		/// <summary>
		///       字段名称
		///       </summary>
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name = value;
			}
		}

		/// <summary>
		///       元素内容只读状态
		///       </summary>
		public ContentReadonlyState ContentReadonly
		{
			get
			{
				return _ContentReadonly;
			}
			set
			{
				_ContentReadonly = value;
			}
		}

		/// <summary>
		///       提示文本
		///       </summary>
		[DefaultValue(null)]
		public string ToolTip
		{
			get
			{
				return _ToolTip;
			}
			set
			{
				_ToolTip = value;
			}
		}

		/// <summary>
		///       背景文本
		///       </summary>
		[DefaultValue(null)]
		public string BackgroundText
		{
			get
			{
				return _BackgroundText;
			}
			set
			{
				_BackgroundText = value;
			}
		}

		/// <summary>
		///       用户可以直接修改文本域中的内容
		///       </summary>
		[DefaultValue(true)]
		public bool UserEditable
		{
			get
			{
				return _UserEditable;
			}
			set
			{
				_UserEditable = value;
			}
		}

		/// <summary>
		///       显示的格式化对象
		///       </summary>
		public ValueFormater DisplayFormat
		{
			get
			{
				return _DisplayFormat;
			}
			set
			{
				_DisplayFormat = value;
			}
		}

		/// <summary>
		///       自定义属性列表
		///       </summary>
		public XAttributeList Attributes
		{
			get
			{
				return _Attributes;
			}
			set
			{
				_Attributes = value;
			}
		}

		/// <summary>
		///       文本值 
		///       </summary>
		public string Text
		{
			get
			{
				return _Text;
			}
			set
			{
				_Text = value;
			}
		}

		/// <summary>
		///       初始化的表单值，本属性只能用于新增元素操作
		///       </summary>
		public string InitalizeInnerValue
		{
			get
			{
				return _InitalizeInnerValue;
			}
			set
			{
				_InitalizeInnerValue = value;
			}
		}

		/// <summary>
		///       初始化的文本值，本属性只能用于新增元素操作
		///       </summary>
		public string InitalizeText
		{
			get
			{
				return _InitalizeText;
			}
			set
			{
				_InitalizeText = value;
			}
		}

		/// <summary>
		///       输入域设置
		///       </summary>
		public InputFieldSettings FieldSettings
		{
			get
			{
				return _FieldSettings;
			}
			set
			{
				_FieldSettings = value;
			}
		}

		/// <summary>
		///       数据源绑定
		///       </summary>
		public XDataBinding ValueBinding
		{
			get
			{
				return _ValueBinding;
			}
			set
			{
				_ValueBinding = value;
			}
		}

		/// <summary>
		///       数据校验格式
		///       </summary>
		public ValueValidateStyle ValidateStyle
		{
			get
			{
				return _ValidateStyle;
			}
			set
			{
				_ValidateStyle = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public XTextInputFieldElementProperties()
		{
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="field">要读取设置的文本输入域对象</param>
		public XTextInputFieldElementProperties(XTextInputFieldElement field)
		{
			if (field != null)
			{
				ReadProperties(field);
			}
		}

		/// <summary>
		///       读取属性值
		///       </summary>
		/// <param name="element">
		/// </param>
		/// <returns>
		/// </returns>
		public override bool ReadProperties(XTextElement element)
		{
			int num = 12;
			XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)element;
			_ID = xTextInputFieldElement.ID;
			_Name = xTextInputFieldElement.Name;
			_ContentReadonly = xTextInputFieldElement.ContentReadonly;
			_UserEditable = xTextInputFieldElement.UserEditable;
			_ValidateStyle = xTextInputFieldElement.ValidateStyle;
			_ValueBinding = xTextInputFieldElement.ValueBinding;
			_FieldSettings = xTextInputFieldElement.FieldSettings;
			_Attributes = xTextInputFieldElement.Attributes;
			_DisplayFormat = xTextInputFieldElement.DisplayFormat;
			_ToolTip = xTextInputFieldElement.ToolTip;
			_BackgroundText = xTextInputFieldElement.BackgroundText;
			_SpecifyWidth = xTextInputFieldElement.SpecifyWidth;
			AcceptChildElementTypes2 = xTextInputFieldElement.AcceptChildElementTypes2;
			if (xTextInputFieldElement.EventExpressions != null)
			{
				foreach (EventExpressionInfo eventExpression in xTextInputFieldElement.EventExpressions)
				{
					if (eventExpression.EventName == "ContentChanged" && eventExpression.Target == EventExpressionTarget.NextElement)
					{
						NextFieldVisibleExpression = eventExpression.Expression;
						break;
					}
				}
			}
			EnableHighlight = xTextInputFieldElement.EnableHighlight;
			if (xTextInputFieldElement.EventExpressions != null)
			{
				EventExpressions = xTextInputFieldElement.EventExpressions.Clone();
			}
			return true;
		}

		/// <summary>
		///       为新增元素显示对话框
		///       </summary>
		/// <param name="args">
		/// </param>
		/// <returns>
		/// </returns>
		public override bool PromptNewElement(WriterCommandEventArgs args)
		{
			return false;
		}

		/// <summary>
		///       为编辑元素属性而显示对话框
		///       </summary>
		/// <param name="args">
		/// </param>
		/// <returns>
		/// </returns>
		public override bool PromptEditProperties(WriterCommandEventArgs args)
		{
			if (PromptNewElement(args))
			{
				return true;
			}
			return false;
		}

		/// <summary>
		///       根据对象设置创建输入域元素对象
		///       </summary>
		/// <param name="document">文档对象</param>
		/// <returns>创建的输入域元素对象</returns>
		public override XTextElement CreateElement(XTextDocument document)
		{
			XTextInputFieldElement xTextInputFieldElement = new XTextInputFieldElement();
			xTextInputFieldElement.Elements = new XTextElementList();
			xTextInputFieldElement.OwnerDocument = document;
			ApplyToElement(document, xTextInputFieldElement, logUndo: false);
			if (!string.IsNullOrEmpty(InitalizeText))
			{
				xTextInputFieldElement.SetInnerTextFast(InitalizeText);
			}
			if (!string.IsNullOrEmpty(InitalizeInnerValue))
			{
				xTextInputFieldElement.InnerValue = InitalizeInnerValue;
			}
			return xTextInputFieldElement;
		}

		/// <summary>
		///       应用到元素中
		///       </summary>
		/// <param name="document">文档对象</param>
		/// <param name="element">元素对象</param>
		/// <param name="logUndo">是否记录撤销信息</param>
		/// <returns>操作是否成功</returns>
		public override bool ApplyToElement(XTextDocument document, XTextElement element, bool logUndo)
		{
			int num = 3;
			XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)element;
			if (_Name != null)
			{
				_Name = _Name.Trim();
			}
			bool flag = false;
			if (xTextInputFieldElement.ID != ID)
			{
				if (logUndo && document.CanLogUndo)
				{
					document.UndoList.AddProperty("ID", xTextInputFieldElement.ID, ID, xTextInputFieldElement);
				}
				xTextInputFieldElement.ID = ID;
				flag = true;
			}
			if (xTextInputFieldElement.EnableHighlight != EnableHighlight)
			{
				if (logUndo && document.CanLogUndo)
				{
					document.UndoList.AddProperty("EnableHighlight", xTextInputFieldElement.EnableHighlight, EnableHighlight, xTextInputFieldElement);
				}
				xTextInputFieldElement.EnableHighlight = EnableHighlight;
				flag = true;
			}
			EventExpressionInfoList eventExpressionInfoList = EventExpressions;
			if (!string.IsNullOrEmpty(NextFieldVisibleExpression))
			{
				if (eventExpressionInfoList == null)
				{
					eventExpressionInfoList = new EventExpressionInfoList();
				}
				EventExpressionInfo eventExpressionInfo = null;
				foreach (EventExpressionInfo item in eventExpressionInfoList)
				{
					if (item.EventName == "ContentChanged" && item.Target == EventExpressionTarget.NextElement)
					{
						eventExpressionInfo = item;
						break;
					}
				}
				if (eventExpressionInfo == null)
				{
					eventExpressionInfo = new EventExpressionInfo();
					eventExpressionInfo.EventName = "ContentChanged";
					eventExpressionInfo.Target = EventExpressionTarget.NextElement;
					eventExpressionInfoList.Add(eventExpressionInfo);
				}
				eventExpressionInfo.Expression = NextFieldVisibleExpression;
			}
			if (eventExpressionInfoList != xTextInputFieldElement.EventExpressions)
			{
				if (logUndo && document.CanLogUndo)
				{
					document.UndoList.AddProperty("EventExpressions", xTextInputFieldElement.EventExpressions, eventExpressionInfoList, xTextInputFieldElement);
				}
				xTextInputFieldElement.EventExpressions = eventExpressionInfoList;
				flag = true;
			}
			if (xTextInputFieldElement.AcceptChildElementTypes2 != AcceptChildElementTypes2)
			{
				if (logUndo && document.CanLogUndo)
				{
					document.UndoList.AddProperty("AcceptChildElementTypes2", xTextInputFieldElement.AcceptChildElementTypes2, AcceptChildElementTypes2, xTextInputFieldElement);
				}
				xTextInputFieldElement.AcceptChildElementTypes2 = AcceptChildElementTypes2;
				flag = true;
			}
			if (xTextInputFieldElement.Name != Name)
			{
				if (logUndo && document.CanLogUndo)
				{
					document.UndoList.AddProperty("Name", xTextInputFieldElement.Name, Name, xTextInputFieldElement);
				}
				xTextInputFieldElement.Name = Name;
				flag = true;
			}
			if (xTextInputFieldElement.SpecifyWidth != SpecifyWidth)
			{
				if (logUndo && document.CanLogUndo)
				{
					document.UndoList.AddProperty("SpecifyWidth", xTextInputFieldElement.SpecifyWidth, SpecifyWidth, xTextInputFieldElement);
				}
				xTextInputFieldElement.SpecifyWidth = SpecifyWidth;
				flag = true;
			}
			if (xTextInputFieldElement.ToolTip != ToolTip)
			{
				if (logUndo && document.CanLogUndo)
				{
					document.UndoList.AddProperty("ToolTip", xTextInputFieldElement.ToolTip, ToolTip, xTextInputFieldElement);
				}
				xTextInputFieldElement.ToolTip = ToolTip;
				flag = true;
			}
			if (xTextInputFieldElement.BackgroundText != BackgroundText)
			{
				if (logUndo && document.CanLogUndo)
				{
					document.UndoList.AddProperty("BackgroundText", xTextInputFieldElement.BackgroundText, BackgroundText, xTextInputFieldElement);
				}
				xTextInputFieldElement.BackgroundText = BackgroundText;
				flag = true;
			}
			if (xTextInputFieldElement.ContentReadonly != ContentReadonly)
			{
				if (logUndo && document.CanLogUndo)
				{
					document.UndoList.AddProperty("ContentReadonly", xTextInputFieldElement.ContentReadonly, ContentReadonly, xTextInputFieldElement);
				}
				xTextInputFieldElement.ContentReadonly = ContentReadonly;
				flag = true;
			}
			if (xTextInputFieldElement.UserEditable != UserEditable)
			{
				if (logUndo && document.CanLogUndo)
				{
					document.UndoList.AddProperty("UserEditable", xTextInputFieldElement.UserEditable, UserEditable, xTextInputFieldElement);
				}
				xTextInputFieldElement.UserEditable = UserEditable;
				flag = true;
			}
			if (xTextInputFieldElement.ValidateStyle != ValidateStyle)
			{
				if (logUndo && document.CanLogUndo)
				{
					document.UndoList.AddProperty("ValidateStyle", xTextInputFieldElement.ValidateStyle, ValidateStyle, xTextInputFieldElement);
				}
				xTextInputFieldElement.ValidateStyle = ValidateStyle;
				flag = true;
			}
			bool flag2 = false;
			if (xTextInputFieldElement.ValueBinding != ValueBinding)
			{
				if (logUndo && document.CanLogUndo)
				{
					document.UndoList.AddProperty("ValueBinding", xTextInputFieldElement.ValueBinding, ValueBinding, xTextInputFieldElement);
				}
				xTextInputFieldElement.ValueBinding = ValueBinding;
				flag2 = true;
				flag = true;
			}
			if (xTextInputFieldElement.FieldSettings != FieldSettings)
			{
				if (logUndo && document.CanLogUndo)
				{
					document.UndoList.AddProperty("FieldSettings", xTextInputFieldElement.FieldSettings, FieldSettings, xTextInputFieldElement);
				}
				xTextInputFieldElement.FieldSettings = FieldSettings;
				flag = true;
			}
			if (xTextInputFieldElement.Attributes != Attributes)
			{
				if (logUndo && document.CanLogUndo)
				{
					document.UndoList.AddProperty("Attributes", xTextInputFieldElement.Attributes, Attributes, xTextInputFieldElement);
				}
				xTextInputFieldElement.Attributes = Attributes;
				flag = true;
			}
			if (xTextInputFieldElement.DisplayFormat != DisplayFormat)
			{
				if (logUndo && document.CanLogUndo)
				{
					document.UndoList.AddProperty("DisplayFormat", xTextInputFieldElement.DisplayFormat, DisplayFormat, xTextInputFieldElement);
				}
				xTextInputFieldElement.DisplayFormat = DisplayFormat;
				flag = true;
			}
			if (flag2 && xTextInputFieldElement.ValueBinding != null)
			{
				xTextInputFieldElement.UpdateDataBindingExt(new UpdateDataBindingArgs(null, fastMode: false));
			}
			if (flag)
			{
				ContentChangedEventArgs contentChangedEventArgs = new ContentChangedEventArgs();
				contentChangedEventArgs.Document = xTextInputFieldElement.OwnerDocument;
				contentChangedEventArgs.Element = xTextInputFieldElement;
				contentChangedEventArgs.LoadingDocument = false;
				xTextInputFieldElement.method_23(contentChangedEventArgs);
			}
			return flag;
		}
	}
}
