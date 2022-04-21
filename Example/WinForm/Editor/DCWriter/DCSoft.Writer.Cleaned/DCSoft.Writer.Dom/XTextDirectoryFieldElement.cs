using DCSoft.Common;
using DCSoft.Drawing;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       目录域对象 
	///       </summary>
	[ComVisible(true)]
	
	
	[ComClass("74D09E85-5AE3-4FCA-B2E5-BFEDDB96F69D", "1E1D65E3-591F-47D7-9172-DC10BF3119A5")]
	[ComDefaultInterface(typeof(IXTextDirectoryFieldElement))]
	[Guid("74D09E85-5AE3-4FCA-B2E5-BFEDDB96F69D")]
	[XmlType("XDirectoryField")]
	[ClassInterface(ClassInterfaceType.None)]
	public class XTextDirectoryFieldElement : XTextInputFieldElementBase, IXTextDirectoryFieldElement
	{
		
		[ComVisible(false)]
		[Browsable(false)]
		public class GClass4
		{
			private XTextParagraphFlagElement xtextParagraphFlagElement_0 = null;

			private string string_0 = null;

			private int int_0 = 0;

			private int int_1 = -1;

			private int int_2 = -1;

			private XTextLabelElement xtextLabelElement_0 = null;

			public XTextParagraphFlagElement method_0()
			{
				return xtextParagraphFlagElement_0;
			}

			public void method_1(XTextParagraphFlagElement xtextParagraphFlagElement_1)
			{
				xtextParagraphFlagElement_0 = xtextParagraphFlagElement_1;
			}

			public string method_2()
			{
				return string_0;
			}

			public void method_3(string string_1)
			{
				string_0 = string_1;
			}

			public int method_4()
			{
				return int_0;
			}

			public void method_5(int int_3)
			{
				int_0 = int_3;
			}

			public int method_6()
			{
				return int_1;
			}

			public void method_7(int int_3)
			{
				int_1 = int_3;
			}

			public int method_8()
			{
				return int_2;
			}

			public void method_9(int int_3)
			{
				int_2 = int_3;
			}

			public XTextLabelElement method_10()
			{
				return xtextLabelElement_0;
			}

			public void method_11(XTextLabelElement xtextLabelElement_1)
			{
				xtextLabelElement_0 = xtextLabelElement_1;
			}
		}

		internal const string string_23 = "DCTopic_";

		internal const string string_24 = "74D09E85-5AE3-4FCA-B2E5-BFEDDB96F69D";

		internal const string string_25 = "1E1D65E3-591F-47D7-9172-DC10BF3119A5";

		private int int_14 = 3;

		private bool bool_20 = true;

		[NonSerialized]
		private List<GClass4> list_0 = new List<GClass4>();

		
		public override string DomDisplayName => "Directory:" + base.ID;

		/// <summary>
		///       目录显示级别
		///       </summary>
		[HtmlAttribute]
		[DefaultValue(3)]
		
		public int DisplayLevel
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
		///       显示页码
		///       </summary>
		[HtmlAttribute]
		[DefaultValue(true)]
		
		public bool ShowPageIndex
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
		///       初始化对象
		///       </summary>
		
		public XTextDirectoryFieldElement()
		{
			ContentReadonly = ContentReadonlyState.False;
			EnableHighlight = EnableState.Disabled;
			base.BorderVisible = DCVisibleState.Hidden;
		}

		
		public override void AfterLoad(ElementLoadEventArgs args)
		{
			base.AfterLoad(args);
			XTextDocumentContentElement documentContentElement = base.DocumentContentElement;
			documentContentElement.method_57(bool_23: true, bool_24: true);
			list_0 = new List<GClass4>();
			method_37(documentContentElement.RootParagraphFlag, list_0, 0);
			foreach (XTextElement element in Elements)
			{
				if (element is XTextLabelElement)
				{
					XTextLabelElement xTextLabelElement = (XTextLabelElement)element;
					foreach (GClass4 item in list_0)
					{
						if (item.method_10() == null && item.method_0().TopicID == xTextLabelElement.ReferencedTopicID)
						{
							item.method_11(xTextLabelElement);
							break;
						}
					}
				}
			}
		}

		
		public void method_35(bool bool_21)
		{
			int num = 13;
			if (OwnerDocument != null)
			{
				OwnerDocument.Body.GetElementsByType(typeof(XTextParagraphFlagElement));
				Elements.Clear();
				XTextDocumentContentElement documentContentElement = base.DocumentContentElement;
				documentContentElement.method_57(bool_23: true, bool_24: true);
				list_0 = new List<GClass4>();
				method_37(documentContentElement.RootParagraphFlag, list_0, 0);
				XTextContentElement contentElement = ContentElement;
				float num2 = contentElement.ClientWidth - 10f;
				XFontValue defaultFont = OwnerDocument.DefaultFont;
				int tickCount = Environment.TickCount;
				using (DCGraphics dCGraphics = OwnerDocument.CreateDCGraphics())
				{
					SizeF sizeF = dCGraphics.MeasureString(".", defaultFont, 10000, DrawStringFormatExt.GenericTypographic);
					int count = OwnerDocument.Pages.Count;
					int num3 = 0;
					foreach (GClass4 item in list_0)
					{
						if (item.method_0().RuntimeStyle.VisibleInDirectory)
						{
							item.method_0().TopicID = tickCount++;
							num3++;
							XTextLabelElement xTextLabelElement = new XTextLabelElement();
							xTextLabelElement.Multiline = false;
							xTextLabelElement.ID = base.ID + "_Label_" + num3;
							string text = item.method_0().ParagraphText;
							if (text != null)
							{
								int num4 = text.IndexOf('\r');
								if (num4 > 0)
								{
									text = text.Substring(0, num4);
								}
								num4 = text.IndexOf('\n');
								if (num4 > 0)
								{
									text = text.Substring(0, num4);
								}
							}
							string text2 = new string(' ', item.method_4() * 3);
							if (ShowPageIndex)
							{
								text2 = text2 + "..." + count;
							}
							SizeF sizeF2 = dCGraphics.MeasureString(text2, defaultFont, 10000, DrawStringFormatExt.GenericTypographic);
							while (dCGraphics.MeasureString(text, defaultFont, 10000, DrawStringFormatExt.GenericTypographic).Width + sizeF2.Width > num2 && text.Length > 2)
							{
								text = text.Substring(0, text.Length - 1);
							}
							if (ShowPageIndex)
							{
								text2 = new string(' ', item.method_4() * 3) + text + count;
								int num5 = (int)Math.Floor((num2 - dCGraphics.MeasureString(text2, defaultFont, 10000, DrawStringFormatExt.GenericTypographic).Width) / sizeF.Width);
								if (num5 < 0)
								{
									num5 = 0;
								}
								text2 = (xTextLabelElement.Text = new string(' ', item.method_4() * 3) + text + new string('.', num5) + count);
							}
							else
							{
								xTextLabelElement.Text = new string(' ', item.method_4() * 3) + text;
							}
							xTextLabelElement.AutoSize = true;
							xTextLabelElement.OwnerDocument = OwnerDocument;
							xTextLabelElement.Parent = this;
							xTextLabelElement.StyleIndex = StyleIndex;
							xTextLabelElement.Alignment = DCContentAlignment.MiddleLeft;
							xTextLabelElement.LinkInfo = new HyperlinkInfo();
							xTextLabelElement.LinkInfo.Reference = "#DCTopic_" + item.method_0().TopicID;
							xTextLabelElement.LinkInfo.Title = text;
							xTextLabelElement.Tag = item;
							xTextLabelElement.ReferencedTopicID = item.method_0().TopicID;
							item.method_11(xTextLabelElement);
							Elements.Add(xTextLabelElement);
						}
					}
				}
				if (bool_21)
				{
					EditorRefreshView();
					method_36();
				}
			}
		}

		
		
		public void method_36()
		{
			if (ShowPageIndex)
			{
				foreach (GClass4 item in list_0)
				{
					XTextLabelElement xTextLabelElement = item.method_10();
					if (xTextLabelElement != null)
					{
						string text = xTextLabelElement.Text;
						if (!string.IsNullOrEmpty(text) && item.method_0() != null)
						{
							int num = text.LastIndexOf('.');
							if (num > 0)
							{
								text = text.Substring(0, num);
							}
							text = (xTextLabelElement.Text = text + Convert.ToString(item.method_0().OwnerPageIndex + 1));
						}
					}
				}
			}
		}

		private void method_37(XTextParagraphFlagElement xtextParagraphFlagElement_0, List<GClass4> list_1, int int_15)
		{
			if (xtextParagraphFlagElement_0 != null && xtextParagraphFlagElement_0.ChildParagraphs != null)
			{
				foreach (XTextParagraphFlagElement childParagraph in xtextParagraphFlagElement_0.ChildParagraphs)
				{
					GClass4 gClass = new GClass4();
					gClass.method_1(childParagraph);
					gClass.method_5(int_15);
					childParagraph.Text = childParagraph.ParagraphText;
					list_1.Add(gClass);
					if (childParagraph.ChildParagraphs != null && childParagraph.ChildParagraphs.Count > 0 && int_15 + 1 < DisplayLevel)
					{
						method_37(childParagraph, list_1, int_15 + 1);
					}
				}
			}
		}

		
		public override void vmethod_17(ReadHTMLEventArgs readHTMLEventArgs_0)
		{
			readHTMLEventArgs_0.ReadDCCustomAttributes(readHTMLEventArgs_0.HtmlElement, this);
		}

		
		public override XTextElement Clone(bool Deeply)
		{
			XTextDirectoryFieldElement xTextDirectoryFieldElement = (XTextDirectoryFieldElement)base.Clone(Deeply);
			xTextDirectoryFieldElement.list_0 = null;
			return xTextDirectoryFieldElement;
		}
	}
}
