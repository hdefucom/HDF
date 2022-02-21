using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       内容链接对象
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[ComDefaultInterface(typeof(IXTextContentLinkFieldElement))]
	[ComClass("00012345-6789-ABCD-EF01-234567890053", "C9D4A84C-019B-4B0F-9917-5AD2F4E56109")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	[Guid("00012345-6789-ABCD-EF01-234567890053")]
	[XmlType("XContentLinkField")]
	
	public class XTextContentLinkFieldElement : XTextFieldElementBase, IXTextContentLinkFieldElement
	{
		internal const string string_16 = "00012345-6789-ABCD-EF01-234567890053";

		internal const string string_17 = "C9D4A84C-019B-4B0F-9917-5AD2F4E56109";

		private bool bool_17 = false;

		private FileContentSource fileContentSource_0 = new FileContentSource();

		private ContentUpdateState contentUpdateState_0 = ContentUpdateState.AutoUpdate;

		private bool bool_18 = false;

		private bool bool_19 = true;

		
		public override string DomDisplayName => "ContentLink:" + base.ID + " " + ContentSource;

		/// <summary>
		///       内容只读
		///       </summary>
		[DefaultValue(false)]
		[HtmlAttribute]
		public bool Readonly
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
		///       用户可否编辑内容
		///       </summary>
		[Browsable(false)]
		public override bool ContentEditable => !Readonly;

		/// <summary>
		///       文件内容来源
		///       </summary>
		[HtmlAttribute]
		public FileContentSource ContentSource
		{
			get
			{
				return fileContentSource_0;
			}
			set
			{
				fileContentSource_0 = value;
				base.InnerBackgroundTextElements = null;
			}
		}

		/// <summary>
		///       更新的内容的状态
		///       </summary>
		[DefaultValue(ContentUpdateState.AutoUpdate)]
		public ContentUpdateState UpdateState
		{
			get
			{
				return contentUpdateState_0;
			}
			set
			{
				contentUpdateState_0 = value;
			}
		}

		/// <summary>
		///       采用替换更新模式内容
		///       </summary>
		/// <remarks>采用替换更新模式下，系统会加载引用的文档内容，删除本元素并插入导入的新元素。</remarks>
		[DefaultValue(false)]
		[HtmlAttribute]
		public bool ReplaceUpdateMode
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
		///       保存文件的时候也保存链接的内容
		///       </summary>
		[DefaultValue(true)]
		[HtmlAttribute]
		public bool SaveLinkedContent
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
		///       为XML序列化/反序列化的子元素列表
		///       </summary>
		
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlArray("XElements", IsNullable = true)]
		public override XTextElementList ElementsForSerialize
		{
			get
			{
				if (SaveLinkedContent)
				{
					return base.ElementsForSerialize;
				}
				return null;
			}
			set
			{
				base.ElementsForSerialize = value;
			}
		}

		/// <summary>
		///       运行时是用的背景文字
		///       </summary>
		internal override string RuntimeBackgroundText
		{
			get
			{
				int num = 13;
				string text = null;
				if (ContentSource != null)
				{
					text = ContentSource.FileName;
				}
				if (string.IsNullOrEmpty(text))
				{
					text = "[" + base.ID + "]";
				}
				return text;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		
		public override int vmethod_32(XTextElementList xtextElementList_3, bool bool_20)
		{
			if (OwnerDocument.PrintingViewMode)
			{
				return base.vmethod_32(xtextElementList_3, bool_20);
			}
			if (OwnerDocument.Options.BehaviorOptions.DesignMode)
			{
				int num = 0;
				if (base.StartElement != null)
				{
					xtextElementList_3.Add(base.StartElement);
					num++;
				}
				method_28();
				foreach (XTextElement innerBackgroundTextElement in base.InnerBackgroundTextElements)
				{
					innerBackgroundTextElement.StyleIndex = StyleIndex;
				}
				xtextElementList_3.AddRange(base.InnerBackgroundTextElements);
				num += base.InnerBackgroundTextElements.Count;
				if (base.EndElement != null)
				{
					xtextElementList_3.Add(base.EndElement);
					num++;
				}
				return num;
			}
			return base.vmethod_32(xtextElementList_3, bool_20);
		}

		/// <summary>
		///       文档内容加载后的处理
		///       </summary>
		/// <param name="args">参数对象</param>
		
		public override void AfterLoad(ElementLoadEventArgs args)
		{
			if (!OwnerDocument.Options.BehaviorOptions.DesignMode)
			{
				if (UpdateState == ContentUpdateState.AutoUpdate)
				{
					method_31(bool_20: true);
				}
				else if (UpdateState == ContentUpdateState.UpdateOne && method_31(bool_20: true))
				{
					UpdateState = ContentUpdateState.Updated;
				}
			}
			base.AfterLoad(args);
		}

		
		public override void OnViewGotFocus(ElementEventArgs elementEventArgs_0)
		{
			base.OnViewGotFocus(elementEventArgs_0);
			method_30();
		}

		
		public override void OnViewLostFocus(ElementEventArgs elementEventArgs_0)
		{
			base.OnViewLostFocus(elementEventArgs_0);
			method_30();
		}

		
		public override void vmethod_7(ElementEventArgs elementEventArgs_0)
		{
			base.vmethod_7(elementEventArgs_0);
			method_30();
		}

		
		public override void vmethod_8(ElementEventArgs elementEventArgs_0)
		{
			base.vmethod_8(elementEventArgs_0);
			method_30();
		}

		private void method_30()
		{
			base.StartElement.InvalidateView();
			base.EndElement.InvalidateView();
		}

		public bool method_31(bool bool_20)
		{
			if (ContentSource == null)
			{
				return false;
			}
			XTextElementList xTextElementList = OwnerDocument.ImportDocument(ContentSource);
			if (xTextElementList != null && xTextElementList.Count > 0)
			{
				WriterUtils.smethod_20(OwnerDocument, xTextElementList, bool_2: false);
				_ = OwnerDocument;
				if (ReplaceUpdateMode)
				{
					XTextContainerElement parent = Parent;
					int num = parent.Elements.IndexOf(this);
					parent.Elements.RemoveAt(num);
					parent.Elements.method_12(num, xTextElementList);
					if (!bool_20)
					{
						parent.FixDomState();
						foreach (XTextElement item in xTextElementList)
						{
							item.AfterLoad(new ElementLoadEventArgs(item, ContentSource.RuntimeFormat));
							parent.UpdateContentVersion();
							int viewIndex = parent.FirstContentElementInPublicContent.ViewIndex;
							OwnerDocument.DocumentControler.vmethod_6(xTextElementList);
							parent.ContentElement.vmethod_38(viewIndex, -1, bool_22: false);
						}
					}
				}
				else
				{
					Elements.Clear();
					Elements.AddRange(xTextElementList);
					if (!bool_20)
					{
						base.AfterLoad(new ElementLoadEventArgs(this, ContentSource.RuntimeFormat));
						UpdateContentVersion();
						ContentElement.vmethod_36(bool_22: true);
						int viewIndex = FirstContentElementInPublicContent.ViewIndex;
						OwnerDocument.DocumentControler.vmethod_6(xTextElementList);
						ContentElement.vmethod_38(viewIndex, -1, bool_22: false);
					}
				}
				return true;
			}
			return false;
		}

		
		public override XTextElement Clone(bool Deeply)
		{
			XTextContentLinkFieldElement xTextContentLinkFieldElement = (XTextContentLinkFieldElement)base.Clone(Deeply);
			if (fileContentSource_0 != null)
			{
				xTextContentLinkFieldElement.fileContentSource_0 = fileContentSource_0.Clone();
			}
			return xTextContentLinkFieldElement;
		}
	}
}
