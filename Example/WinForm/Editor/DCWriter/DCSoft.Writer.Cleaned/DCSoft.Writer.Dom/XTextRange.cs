using DCSoft.Common;
using DCSoftDotfuscate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档区域对象
	///       </summary>
	/// <remarks>编写 袁永福</remarks>
	
	[DocumentComment]
	[DebuggerDisplay("Index={StartIndex},Length={Length}")]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[ComVisible(false)]
	[Guid("00012345-6789-ABCD-EF01-23456789001A")]
	public class XTextRange : IEnumerable
	{
		private class Class24 : IEnumerator
		{
			private int int_0 = 0;

			private XTextRange xtextRange_0 = null;

			private int int_1 = -1;

			public object Current
			{
				get
				{
					int num = 0;
					if (int_0 != xtextRange_0.int_0)
					{
						throw new InvalidOperationException(" 列表内容已被修改 ");
					}
					if (int_1 >= 0 && int_1 < xtextRange_0.Elements.Count)
					{
						XTextElement xTextElement = xtextRange_0.Elements[int_1];
						if (xTextElement != null)
						{
						}
						return xTextElement;
					}
					return null;
				}
			}

			public Class24(XTextRange xtextRange_1)
			{
				xtextRange_0 = xtextRange_1;
				int_1 = xtextRange_0.StartIndex - 1;
				int_0 = xtextRange_0.int_0;
			}

			public bool MoveNext()
			{
				int num = 9;
				if (int_0 != xtextRange_0.int_0)
				{
					throw new InvalidOperationException(" 列表内容已被修改 ");
				}
				if (int_1 < xtextRange_0.StartIndex + xtextRange_0.Length && int_1 < xtextRange_0.Elements.Count - 1)
				{
					int_1++;
					return true;
				}
				return false;
			}

			public void Reset()
			{
				int_1 = xtextRange_0.StartIndex;
				int_0 = xtextRange_0.int_0;
			}
		}

		private int int_0 = 0;

		private XTextDocument xtextDocument_0 = null;

		private XTextElementList xtextElementList_0 = null;

		private int int_1 = 0;

		private int int_2 = 0;

		private XTextElement xtextElement_0 = null;

		private XTextElement xtextElement_1 = null;

		private bool bool_0 = true;

		/// <summary>
		///       文档对象
		///       </summary>
		public XTextDocument Document
		{
			get
			{
				return xtextDocument_0;
			}
			set
			{
				xtextDocument_0 = value;
				int_0++;
			}
		}

		/// <summary>
		///       参与的元素列表
		///       </summary>
		public XTextElementList Elements
		{
			get
			{
				return xtextElementList_0;
			}
			set
			{
				xtextElementList_0 = value;
				bool_0 = true;
				int_0++;
			}
		}

		/// <summary>
		///       区域开始序号
		///       </summary>
		public int StartIndex
		{
			get
			{
				return int_1;
			}
			set
			{
				int_1 = value;
				bool_0 = true;
				int_0++;
			}
		}

		/// <summary>
		///       区域长度
		///       </summary>
		public int Length
		{
			get
			{
				return int_2;
			}
			set
			{
				int_2 = value;
				bool_0 = true;
				int_0++;
			}
		}

		/// <summary>
		///       区域起始元素
		///       </summary>
		public XTextElement StartElement
		{
			get
			{
				return xtextElement_0;
			}
			set
			{
				xtextElement_0 = value;
				bool_0 = true;
				int_0++;
			}
		}

		/// <summary>
		///       区域结束元素
		///       </summary>
		public XTextElement EndElement
		{
			get
			{
				return xtextElement_1;
			}
			set
			{
				xtextElement_1 = value;
				bool_0 = true;
				int_0++;
			}
		}

		/// <summary>
		///       获得区域中指定序号的元素
		///       </summary>
		/// <param name="index">序号</param>
		/// <returns>指定的元素</returns>
		public XTextElement this[int index]
		{
			get
			{
				method_4();
				return xtextElementList_0[int_1 + index];
			}
		}

		/// <summary>
		///       区域中第一个元素
		///       </summary>
		public XTextElement FirstElement
		{
			get
			{
				method_4();
				return xtextElementList_0[int_1];
			}
		}

		/// <summary>
		///       区域中最后一个元素
		///       </summary>
		public XTextElement LastElement
		{
			get
			{
				method_4();
				return xtextElementList_0[int_1 + int_2];
			}
		}

		/// <summary>
		///       获得纯文本内容
		///       </summary>
		public string Text
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder();
				IEnumerator enumerator = GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						XTextElement xTextElement = (XTextElement)enumerator.Current;
						stringBuilder.Append(xTextElement.ToPlaintString());
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
				return stringBuilder.ToString();
			}
		}

		/// <summary>
		///       获得表示内容的RTF文本
		///       </summary>
		public string RTFText
		{
			get
			{
				method_4();
				if (int_2 == 0)
				{
					return "";
				}
				XTextElementList xTextElementList = Document.CreateParagraphs(this);
				if (xTextElementList == null || xTextElementList.Count == 0)
				{
					return "";
				}
				StringWriter stringWriter = new StringWriter();
				GClass103 gClass = new GClass103();
				gClass.vmethod_4(stringWriter);
				gClass.method_1(Document);
				gClass.method_29();
				gClass.method_33();
				foreach (XTextElement item in xTextElementList)
				{
					item.vmethod_19(gClass);
				}
				gClass.method_34();
				gClass.vmethod_6();
				return stringWriter.ToString();
			}
		}

		/// <summary>
		///       当前文档样式
		///       </summary>
		public DocumentContentStyle Style
		{
			get
			{
				method_4();
				if (Length > 0)
				{
					List<int> list = new List<int>();
					{
						IEnumerator enumerator = GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								XTextElement xTextElement = (XTextElement)enumerator.Current;
								if (!list.Contains(xTextElement.StyleIndex))
								{
									list.Add(xTextElement.StyleIndex);
								}
							}
						}
						finally
						{
							IDisposable disposable = enumerator as IDisposable;
							if (disposable != null)
							{
								disposable.Dispose();
							}
						}
					}
					DocumentContentStyle documentContentStyle = new DocumentContentStyle();
					foreach (int item in list)
					{
						DocumentContentStyle xdependencyObject_ = (DocumentContentStyle)Document.ContentStyles.GetStyle(item);
						XDependencyObject.smethod_7(xdependencyObject_, documentContentStyle, bool_3: true);
					}
					return documentContentStyle;
				}
				return SafeGet(StartIndex)?.RuntimeStyle.Parent;
			}
		}

		private XTextDocumentContentElement Content
		{
			get
			{
				method_4();
				XTextElement xTextElement = this[StartIndex];
				return xTextElement.DocumentContentElement;
			}
		}

		/// <summary>
		///       获得区间包含的段落对象列表
		///       </summary>
		public XTextElementList ParagraphsEOFs
		{
			get
			{
				XTextElementList xTextElementList = new XTextElementList();
				if (Length > 0)
				{
					{
						IEnumerator enumerator = GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								XTextElement xTextElement = (XTextElement)enumerator.Current;
								if (xTextElement is XTextParagraphFlagElement)
								{
									xTextElementList.Add(xTextElement);
								}
							}
						}
						finally
						{
							IDisposable disposable = enumerator as IDisposable;
							if (disposable != null)
							{
								disposable.Dispose();
							}
						}
					}
					if (!(LastElement is XTextParagraphFlagElement))
					{
						xTextElementList.Add(LastElement.OwnerParagraphEOF);
					}
				}
				else
				{
					XTextElement xTextElement = Elements.SafeGet(StartIndex);
					xTextElementList.Add(xTextElement.OwnerParagraphEOF);
				}
				return xTextElementList;
			}
		}

		public static bool smethod_0(XTextRange xtextRange_0, XTextRange xtextRange_1)
		{
			if (xtextRange_0 == xtextRange_1)
			{
				return true;
			}
			if (xtextRange_0 == null || xtextRange_1 == null)
			{
				return false;
			}
			if (xtextRange_0.xtextDocument_0 != xtextRange_1.xtextDocument_0 || xtextRange_0.xtextElementList_0 != xtextRange_1.xtextElementList_0 || xtextRange_0.xtextElement_1 != xtextRange_1.xtextElement_1 || xtextRange_0.int_2 != xtextRange_1.int_2 || xtextRange_0.xtextElement_0 != xtextRange_1.xtextElement_0 || xtextRange_0.int_1 != xtextRange_1.int_1 || xtextRange_0.bool_0 != xtextRange_1.bool_0)
			{
				return false;
			}
			return true;
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public XTextRange()
		{
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="document">文档对象</param>
		/// <param name="elements">元素对象列表</param>
		/// <param name="startIndex">区域的开始序号</param>
		/// <param name="length">区域的长度</param>
		public XTextRange(XTextDocument xtextDocument_1, XTextElementList xtextElementList_1, int int_3, int int_4)
		{
			xtextDocument_0 = xtextDocument_1;
			xtextElementList_0 = xtextElementList_1;
			int_1 = int_3;
			int_2 = int_4;
			bool_0 = true;
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="element">文档元素</param>
		/// <param name="startIndex">开始位置</param>
		/// <param name="length">长度</param>
		public XTextRange(XTextDocumentContentElement xtextDocumentContentElement_0, int int_3, int int_4)
		{
			method_1(xtextDocumentContentElement_0, int_3, int_4);
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="element">文档元素</param>
		/// <param name="startElement">开始元素</param>
		/// <param name="endElement">结束元素</param>
		public XTextRange(XTextDocumentContentElement xtextDocumentContentElement_0, XTextElement xtextElement_2, XTextElement xtextElement_3)
		{
			method_0(xtextDocumentContentElement_0, xtextElement_2, xtextElement_3);
		}

		public void method_0(XTextDocumentContentElement xtextDocumentContentElement_0, XTextElement xtextElement_2, XTextElement xtextElement_3)
		{
			xtextDocument_0 = xtextDocumentContentElement_0.OwnerDocument;
			xtextElementList_0 = xtextDocumentContentElement_0.Content;
			xtextElement_0 = xtextElement_2;
			xtextElement_1 = xtextElement_3;
			bool_0 = true;
			int_0++;
			if (xtextDocument_0 != null)
			{
			}
		}

		public void method_1(XTextDocumentContentElement xtextDocumentContentElement_0, int int_3, int int_4)
		{
			xtextDocument_0 = xtextDocumentContentElement_0.OwnerDocument;
			xtextElementList_0 = xtextDocumentContentElement_0.Content;
			int_1 = int_3;
			int_2 = int_4;
			bool_0 = true;
			int_0++;
			if (xtextDocument_0 != null)
			{
			}
		}

		internal void method_2()
		{
			xtextDocument_0 = null;
			xtextElementList_0 = null;
			xtextElement_1 = null;
			xtextElement_0 = null;
		}

		public void method_3()
		{
			bool_0 = true;
			int_0++;
		}

		
		public void method_4()
		{
			if (bool_0)
			{
				method_5(bool_1: true);
			}
		}

		
		public bool method_5(bool bool_1)
		{
			int num = 19;
			if (xtextElementList_0 == null)
			{
				if (bool_1)
				{
					throw new ArgumentNullException("Elements");
				}
				return false;
			}
			if (xtextElement_0 == null != (xtextElement_1 == null))
			{
				if (bool_1)
				{
					throw new ArgumentException("StartElement vs EndElement");
				}
				return false;
			}
			if (xtextElement_0 != null && xtextElement_1 != null)
			{
				int num2 = WriterUtils.smethod_4(xtextElementList_0, xtextElement_0);
				int num3 = WriterUtils.smethod_4(xtextElementList_0, xtextElement_1);
				int_1 = Math.Min(num2, num3);
				if (int_1 < 0)
				{
					if (bool_1)
					{
						throw new IndexOutOfRangeException(int_1.ToString());
					}
					return false;
				}
				int_2 = Math.Abs(num2 - num3) + 1;
			}
			else
			{
				if (int_2 < 0)
				{
					int_1 += int_2;
					int_2 = -int_2;
				}
				if (int_1 < 0 || int_1 >= xtextElementList_0.Count)
				{
					if (bool_1)
					{
						throw new ArgumentOutOfRangeException("StartIndex");
					}
					return false;
				}
				if (int_2 < 0 || int_1 + int_2 > xtextElementList_0.Count)
				{
					if (bool_1)
					{
						throw new ArgumentOutOfRangeException("Length");
					}
					return false;
				}
			}
			bool_0 = false;
			return true;
		}

		/// <summary>
		///       安全的获得指定序号的元素
		///       </summary>
		/// <param name="index">序号</param>
		/// <returns>元素对象</returns>
		public XTextElement SafeGet(int index)
		{
			method_4();
			return xtextElementList_0.SafeGet(int_1 + index);
		}

		/// <summary>
		///       获得区域包含的元素列表
		///       </summary>
		/// <returns>创建的元素列表</returns>
		public XTextElementList GetElements()
		{
			method_4();
			XTextElementList xTextElementList = new XTextElementList();
			for (int i = 0; i < int_2; i++)
			{
				xTextElementList.Add(xtextElementList_0[int_1 + i]);
			}
			return xTextElementList;
		}

		/// <summary>
		///       判断指定的元素是否在区域中
		///       </summary>
		/// <param name="element">元素对象</param>
		/// <returns>是否在区域中</returns>
		public bool Contains(XTextElement element)
		{
			method_4();
			if (xtextDocument_0 != null && xtextDocument_0.Options.BehaviorOptions.WeakMode)
			{
				int num = -1;
				if (xtextElementList_0.SafeGet(element.ContentIndex) == element)
				{
					num = element.ContentIndex;
				}
				else if (xtextElementList_0.SafeGet(element.PrivateContentIndex) == element)
				{
					num = element.PrivateContentIndex;
				}
				if (num < 0)
				{
					num = xtextElementList_0.IndexOf(element, int_1, int_2);
				}
				if (num >= 0)
				{
					return true;
				}
			}
			else
			{
				try
				{
					int num = -1;
					if (xtextElementList_0.SafeGet(element.ContentIndex) == element)
					{
						num = element.ContentIndex;
					}
					else if (xtextElementList_0.SafeGet(element.PrivateContentIndex) == element)
					{
						num = element.PrivateContentIndex;
					}
					if (num < 0)
					{
						num = xtextElementList_0.IndexOf(element, int_1, int_2);
					}
					if (num >= 0)
					{
						return true;
					}
				}
				catch
				{
					return false;
				}
			}
			return false;
		}

		/// <summary>
		///       判断是否包含指定视图编号
		///       </summary>
		/// <param name="viewIndex">视图编号</param>
		/// <returns>是否包含</returns>
		public bool Contains(int viewIndex)
		{
			method_4();
			if (int_2 == 0)
			{
				return false;
			}
			return viewIndex >= int_1 && viewIndex < int_1 + int_2;
		}

		/// <summary>
		///       设置段落样式
		///       </summary>
		/// <param name="newStyle">
		/// </param>
		/// <returns>
		/// </returns>
		public XTextElementList SetParagraphStyle(DocumentContentStyle newStyle)
		{
			method_4();
			Dictionary<XTextElement, int> dictionary = new Dictionary<XTextElement, int>();
			foreach (XTextParagraphFlagElement paragraphsEOF in ParagraphsEOFs)
			{
				DocumentContentStyle documentContentStyle = paragraphsEOF.RuntimeStyle.CloneParent();
				if (XDependencyObject.smethod_7(newStyle, documentContentStyle, bool_3: true) > 0)
				{
					int styleIndex = Document.ContentStyles.GetStyleIndex(documentContentStyle);
					if (styleIndex != paragraphsEOF.StyleIndex)
					{
						dictionary[paragraphsEOF] = styleIndex;
					}
				}
			}
			if (dictionary.Count > 0)
			{
				Document.method_109(dictionary, bool_32: true);
			}
			return ParagraphsEOFs;
		}

		/// <summary>
		///       获得元素的枚举器
		///       </summary>
		/// <returns>枚举器</returns>
		public IEnumerator GetEnumerator()
		{
			method_4();
			return new Class24(this);
		}

		/// <summary>
		///       返回表示对象数据的字符串
		///       </summary>
		/// <returns>字符串</returns>
		public override string ToString()
		{
			return "Index=" + StartIndex + ",Length=" + Length;
		}
	}
}
