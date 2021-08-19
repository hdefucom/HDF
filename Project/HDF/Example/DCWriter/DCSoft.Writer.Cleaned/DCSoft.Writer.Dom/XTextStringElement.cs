using DCSoft.Common;
using DCSoftDotfuscate;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       ★★★★★★★★★★★DCWriter内部使用，不得用于二次开发。文档字符串对象,这是DCWriter内部使用
	///       </summary>
	/// <remarks>本对象只是在加载或保存文档时临时生成。</remarks>
	[XmlType("XString")]
	[DCPublishAPI]
	[ComVisible(false)]
	public class XTextStringElement : XTextContainerElement
	{
		private const string string_14 = "{{DCSPACES}}";

		private bool bool_17 = false;

		private XTextCharElement xtextCharElement_0 = null;

		private XTextCharElement xtextCharElement_1 = null;

		private bool bool_18 = false;

		private int int_10 = 0;

		private StringBuilder stringBuilder_0 = new StringBuilder();

		/// <summary>
		///       为输出打印格式的HTML而进行合并
		///       </summary>
		[ComVisible(false)]
		[XmlIgnore]
		[DCInternal]
		[Browsable(false)]
		public bool MergeForPrintHtml
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
		///       开始字符元素
		///       </summary>
		[XmlIgnore]
		[ComVisible(false)]
		[Browsable(false)]
		[DCInternal]
		public XTextCharElement StartElement
		{
			get
			{
				return xtextCharElement_0;
			}
			set
			{
				xtextCharElement_0 = value;
			}
		}

		/// <summary>
		///       结束字符元素
		///       </summary>
		[ComVisible(false)]
		[XmlIgnore]
		[Browsable(false)]
		[DCInternal]
		public XTextCharElement EndElement
		{
			get
			{
				return xtextCharElement_1;
			}
			set
			{
				xtextCharElement_1 = value;
			}
		}

		/// <summary>
		///       是否为背景文字模式
		///       </summary>
		[DCInternal]
		[ComVisible(false)]
		[Browsable(false)]
		[XmlIgnore]
		public bool IsBackgroundText
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

		/// <summary>
		///       已作废
		///       </summary>
		[XmlIgnore]
		public override XAttributeList Attributes
		{
			get
			{
				return null;
			}
			set
			{
				base.Attributes = value;
			}
		}

		/// <summary>
		///       空格长度
		///       </summary>
		[HtmlAttribute]
		[XmlAttribute]
		[DefaultValue(0)]
		public int WhiteSpaceLength
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
		///       对象文本
		///       </summary>
		[XmlElement]
		public override string Text
		{
			get
			{
				if (WhiteSpaceLength > 0)
				{
					return new string(' ', WhiteSpaceLength);
				}
				return stringBuilder_0.ToString();
			}
			set
			{
				int num = 8;
				string text = value;
				if (!string.IsNullOrEmpty(text) && text.StartsWith("{{DCSPACES}}"))
				{
					text = text.Substring("{{DCSPACES}}".Length);
					int result = 0;
					text = ((!int.TryParse(text, out result)) ? "" : new string(' ', result));
				}
				stringBuilder_0 = new StringBuilder(text);
				Elements.Clear();
			}
		}

		/// <summary>
		///       子元素列表
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public override XTextElementList Elements
		{
			get
			{
				return base.Elements;
			}
			set
			{
				base.Elements = value;
			}
		}

		/// <summary>
		///       无效属性
		///       </summary>
		[XmlIgnore]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public override XTextElementList ElementsForSerialize
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		/// <summary>
		///       对象是否有内容
		///       </summary>
		[Browsable(false)]
		public bool HasContent => stringBuilder_0.Length > 0 || Elements.Count > 0;

		/// <summary>
		///       初始化对象
		///       </summary>
		public XTextStringElement()
		{
			base.Attributes = null;
		}

		internal void method_26()
		{
			bool flag = true;
			string text = Text;
			string text2 = text;
			foreach (char c in text2)
			{
				if (c != ' ')
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				int_10 = text.Length;
			}
		}

		/// <summary>
		///       获得输出文本
		///       </summary>
		/// <param name="includeSelectionOnly">只包含被选择的部分</param>
		/// <returns>获得的文本</returns>
		public string GetOutputText(bool includeSelectionOnly)
		{
			if (Elements.Count == 0)
			{
				return "";
			}
			string text = "";
			if (!includeSelectionOnly || Elements.Count == 0)
			{
				text = Text;
			}
			else
			{
				StringBuilder stringBuilder = new StringBuilder();
				XTextDocumentContentElement documentContentElement = Elements[0].DocumentContentElement;
				foreach (XTextCharElement element in Elements)
				{
					if (documentContentElement.IsSelected(element))
					{
						stringBuilder.Append(element.CharValue);
					}
				}
				text = stringBuilder.ToString();
			}
			return text;
		}

		internal bool method_27(XTextCharElement xtextCharElement_2)
		{
			if (xtextCharElement_2 != null)
			{
				if (stringBuilder_0.Length == 0)
				{
					return true;
				}
				if (MergeForPrintHtml)
				{
					bool flag = StartElement.CharValue == ' ';
					bool flag2 = xtextCharElement_2.CharValue == ' ';
					if (flag != flag2)
					{
						return false;
					}
				}
				return StyleIndex == xtextCharElement_2.StyleIndex;
			}
			return false;
		}

		internal void method_28(XTextCharElement xtextCharElement_2, string string_15)
		{
			if (stringBuilder_0.Length == 0)
			{
				StyleIndex = xtextCharElement_2.StyleIndex;
			}
			if (StartElement == null)
			{
				StartElement = xtextCharElement_2;
			}
			EndElement = xtextCharElement_2;
			method_5(xtextCharElement_2.OwnerDocument);
			if (string_15 != null)
			{
				stringBuilder_0.Append(string_15);
			}
			Elements.AddRaw(xtextCharElement_2);
		}

		internal XTextElementList method_29()
		{
			XTextElementList xTextElementList = new XTextElementList();
			string text = stringBuilder_0.ToString();
			string text2 = text;
			foreach (char char_ in text2)
			{
				XTextCharElement xTextCharElement = OwnerDocument.method_73(char_, StyleIndex);
				if (xTextCharElement != null)
				{
					xTextCharElement.StyleIndex = StyleIndex;
					xTextCharElement.Parent = Parent;
					xTextElementList.Add(xTextCharElement);
				}
			}
			return xTextElementList;
		}

		public override void vmethod_19(GClass103 gclass103_0)
		{
			if (!IsBackgroundText || OwnerDocument == null || OwnerDocument.Options.BehaviorOptions.OutputBackgroundTextToRTF)
			{
				if (IsBackgroundText)
				{
					RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
					XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)Parent;
					runtimeStyle.ColorForRTF = xTextInputFieldElement.RuntimeBackgroundTextColor;
					gclass103_0.method_40(GetOutputText(gclass103_0.vmethod_0()), RuntimeStyle);
					gclass103_0.method_41();
					runtimeStyle.ColorForRTF = Color.Empty;
				}
				else
				{
					RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
					runtimeStyle.ColorForRTF = Color.Empty;
					gclass103_0.method_40(GetOutputText(gclass103_0.vmethod_0()), RuntimeStyle);
					gclass103_0.method_41();
				}
			}
		}

		/// <summary>
		///       返回表示对象的字符串
		///       </summary>
		/// <returns>字符串</returns>
		public override string ToString()
		{
			if (stringBuilder_0.Length > 20)
			{
				return stringBuilder_0.ToString(0, 20);
			}
			return stringBuilder_0.ToString();
		}
	}
}
