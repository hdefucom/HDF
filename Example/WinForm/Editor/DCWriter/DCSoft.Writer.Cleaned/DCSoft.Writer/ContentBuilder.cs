using DCSoft.Common;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档内容创建者
	///       </summary>
	/// <remarks>编制 袁永福 2012-8-23</remarks>
	[DCPublishAPI]
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	[ComClass("0325F407-D5D9-46F5-8D7E-977E2AC27767", "D1FEBAAC-A1F4-4B20-8A1D-A20E4A172106")]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IContentBuilder))]
	[Guid("0325F407-D5D9-46F5-8D7E-977E2AC27767")]
	public class ContentBuilder : IContentBuilder
	{
		internal const string CLASSID = "0325F407-D5D9-46F5-8D7E-977E2AC27767";

		internal const string CLASSID_Interface = "D1FEBAAC-A1F4-4B20-8A1D-A20E4A172106";

		private XTextContainerElement _Container;

		private DocumentContentStyle _ContentStyle;

		private DocumentContentStyle _ParagraphStyle;

		private bool _EnableAddPermissionFlag;

		private bool _AppendRawMode;

		/// <summary>
		///       文档对象
		///       </summary>
		[DCPublishAPI]
		public XTextDocument Document
		{
			get
			{
				if (_Container == null)
				{
					return null;
				}
				return _Container.OwnerDocument;
			}
		}

		/// <summary>
		///       容器对象
		///       </summary>
		[DCPublishAPI]
		public XTextContainerElement Container => _Container;

		/// <summary>
		///       文档内容样式
		///       </summary>
		[DCPublishAPI]
		public DocumentContentStyle ContentStyle => _ContentStyle;

		/// <summary>
		///       段落样式
		///       </summary>
		[DCPublishAPI]
		public DocumentContentStyle ParagraphStyle => _ParagraphStyle;

		/// <summary>
		///       新增的文档内容添加授权标志信息
		///       </summary>
		[DCPublishAPI]
		public bool EnableAddPermissionFlag
		{
			get
			{
				return _EnableAddPermissionFlag;
			}
			set
			{
				_EnableAddPermissionFlag = value;
			}
		}

		/// <summary>
		///       原生态添加模式
		///       </summary>
		[DCPublishAPI]
		public bool AppendRawMode
		{
			get
			{
				return _AppendRawMode;
			}
			set
			{
				_AppendRawMode = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="container">容器对象</param>
		[DCPublishAPI]
		public ContentBuilder(XTextContainerElement container)
		{
			int num = 18;
			_Container = null;
			_ContentStyle = new DocumentContentStyle();
			_ParagraphStyle = new DocumentContentStyle();
			_EnableAddPermissionFlag = true;
			_AppendRawMode = false;
			
			if (container == null)
			{
				throw new ArgumentNullException("container");
			}
			if (container is XTextDocument)
			{
				throw new ArgumentNullException("不能使用 Document.ContentBuilder");
			}
			_Container = container;
		}

		internal void InnerDispose()
		{
			_Container = null;
			_ContentStyle = null;
			_ParagraphStyle = null;
		}

		/// <summary>
		///       清空内容
		///       </summary>
		[DCPublishAPI]
		public void Clear()
		{
			Container.Elements.Clear();
			if (Container is XTextContentElement)
			{
				((XTextContentElement)Container).FixElements();
			}
			Container.UpdateContentVersion();
		}

		/// <summary>
		///       底层的清空内容
		///       </summary>
		[DCPublishAPI]
		public void RawClear()
		{
			Container.Elements.Clear();
		}

		/// <summary>
		///       设置当前段落样式
		///       </summary>
		/// <param name="style">
		/// </param>
		[DCPublishAPI]
		public void SetParagraphStyle(DocumentContentStyle style)
		{
			_ParagraphStyle = style;
			if (Container is XTextContentElement)
			{
				((XTextContentElement)Container).FixElements();
			}
			if (Container.Elements.LastElement is XTextParagraphFlagElement)
			{
				XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)Container.Elements.LastElement;
				xTextParagraphFlagElement.StyleIndex = Document.ContentStyles.GetStyleIndex(style);
				xTextParagraphFlagElement.AutoCreate = false;
			}
		}

		/// <summary>
		///       添加文本内容
		///       </summary>
		/// <param name="text">文本内容</param>
		/// <param name="style">样式</param>
		/// <returns>
		/// </returns>
		[DCPublishAPI]
		public XTextElementList AppendTextWithStyle(string text, DocumentContentStyle style)
		{
			if (style == null)
			{
				style = ContentStyle;
			}
			XTextElementList xTextElementList = Document.CreateTextElementsExt(text, style, style, EnableAddPermissionFlag && Container.RuntimeEnablePermission);
			AppendRange(xTextElementList);
			return xTextElementList;
		}

		/// <summary>
		///       插入文本内容
		///       </summary>
		/// <param name="index">序号</param>
		/// <param name="text">文本内容</param>
		/// <param name="style">样式</param>
		/// <returns>
		/// </returns>
		[DCPublishAPI]
		public XTextElementList InsertTextWithStyle(int index, string text, DocumentContentStyle style)
		{
			if (style == null)
			{
				style = ContentStyle;
			}
			XTextElementList xTextElementList = Document.CreateTextElementsExt(text, style, style, EnableAddPermissionFlag && Container.RuntimeEnablePermission);
			InsertRange(index, xTextElementList);
			return xTextElementList;
		}

		/// <summary>
		///       添加文本内容
		///       </summary>
		/// <param name="text">文本内容</param>
		/// <param name="styleString">表示样式的字符串</param>
		/// <returns>
		/// </returns>
		[DCPublishAPI]
		public XTextElementList AppendTextWithStyleString(string text, string styleString)
		{
			if (string.IsNullOrEmpty(text))
			{
				return null;
			}
			DocumentContentStyle documentContentStyle = (DocumentContentStyle)ContentStyle.Clone();
			documentContentStyle.method_3(styleString);
			XTextElementList xTextElementList = Document.CreateTextElementsExt(text, documentContentStyle, documentContentStyle, EnableAddPermissionFlag && Container.RuntimeEnablePermission);
			AppendRange(xTextElementList);
			return xTextElementList;
		}

		/// <summary>
		///       添加文本内容
		///       </summary>
		/// <param name="index">要插入的位置序号</param>
		/// <param name="text">文本内容</param>
		/// <param name="styleString">样式字符串</param>
		/// <returns>操作生成的文档元素列表</returns>
		[DCPublishAPI]
		public XTextElementList InsertTextWithStyleString(int index, string text, string styleString)
		{
			if (string.IsNullOrEmpty(text))
			{
				return null;
			}
			DocumentContentStyle documentContentStyle = (DocumentContentStyle)ContentStyle.Clone();
			documentContentStyle.method_3(styleString);
			XTextElementList xTextElementList = Document.CreateTextElementsExt(text, documentContentStyle, documentContentStyle, EnableAddPermissionFlag && Container.RuntimeEnablePermission);
			InsertRange(index, xTextElementList);
			return xTextElementList;
		}

		/// <summary>
		///       使用默认样式添加文本内容
		///       </summary>
		/// <param name="text">文本内容</param>
		/// <returns>产生的元素对象</returns>
		[DCPublishAPI]
		public XTextElementList AppendText(string text)
		{
			return AppendTextWithStyle(text, null);
		}

		/// <summary>
		///       使用默认样式插入文本内容
		///       </summary>
		/// <param name="index">插入的文本</param>
		/// <param name="text">文本内容</param>
		/// <returns>产生的元素对象</returns>
		[DCPublishAPI]
		public XTextElementList InsertText(int index, string text)
		{
			return InsertTextWithStyle(index, text, null);
		}

		/// <summary>
		///       添加段落符号
		///       </summary>
		/// <param name="styleString">段落样式</param>
		/// <returns>生成的段落符号元素对象</returns>
		[DCPublishAPI]
		public XTextParagraphFlagElement AppendParagraphFlagWithStyleString(string styleString)
		{
			DocumentContentStyle documentContentStyle = (DocumentContentStyle)ContentStyle.Clone();
			documentContentStyle.method_3(styleString);
			return AppendParagraphFlagWithStyle(documentContentStyle);
		}

		/// <summary>
		///       插入段落符号
		///       </summary>
		/// <param name="index">序号</param>
		/// <param name="styleString">段落样式</param>
		/// <returns>生成的段落符号元素对象</returns>
		[DCPublishAPI]
		public XTextParagraphFlagElement InsertParagraphFlagWithStyleString(int index, string styleString)
		{
			DocumentContentStyle documentContentStyle = (DocumentContentStyle)ContentStyle.Clone();
			documentContentStyle.method_3(styleString);
			return InsertParagraphFlagWithStyle(index, documentContentStyle);
		}

		/// <summary>
		///       添加段落
		///       </summary>
		/// <param name="style">段落样式</param>
		/// <returns>新增的段落标记元素</returns>
		[DCPublishAPI]
		public XTextParagraphFlagElement AppendParagraphFlagWithStyle(DocumentContentStyle style)
		{
			XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
			xTextParagraphFlagElement.OwnerDocument = Document;
			xTextParagraphFlagElement.Parent = Container;
			DocumentContentStyle documentContentStyle = (style == null) ? ParagraphStyle : style;
			if (EnableAddPermissionFlag)
			{
				documentContentStyle = (DocumentContentStyle)documentContentStyle.Clone();
				documentContentStyle.CreatorIndex = Document.UserHistories.CurrentIndex;
				documentContentStyle.DeleterIndex = -1;
			}
			xTextParagraphFlagElement.Style = style;
			Append(xTextParagraphFlagElement);
			return xTextParagraphFlagElement;
		}

		/// <summary>
		///       添加段落
		///       </summary>
		/// <param name="index">序号</param>
		/// <param name="style">段落样式</param>
		/// <returns>新增的段落标记元素</returns>
		[DCPublishAPI]
		public XTextParagraphFlagElement InsertParagraphFlagWithStyle(int index, DocumentContentStyle style)
		{
			XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
			xTextParagraphFlagElement.OwnerDocument = Document;
			xTextParagraphFlagElement.Parent = Container;
			DocumentContentStyle documentContentStyle = (style == null) ? ParagraphStyle : style;
			if (EnableAddPermissionFlag)
			{
				documentContentStyle = (DocumentContentStyle)documentContentStyle.Clone();
				documentContentStyle.CreatorIndex = Document.UserHistories.CurrentIndex;
				documentContentStyle.DeleterIndex = -1;
			}
			xTextParagraphFlagElement.Style = style;
			Insert(index, xTextParagraphFlagElement);
			return xTextParagraphFlagElement;
		}

		/// <summary>
		///       添加段落符号
		///       </summary>
		/// <returns>创建的段落符号</returns>
		[DCPublishAPI]
		public XTextParagraphFlagElement AppendParagraphFlag()
		{
			return AppendParagraphFlagWithStyle(null);
		}

		/// <summary>
		///       添加段落符号
		///       </summary>
		/// <returns>创建的段落符号</returns>
		[DCPublishAPI]
		public XTextParagraphFlagElement InsertParagraphFlag(int index)
		{
			return InsertParagraphFlagWithStyle(index, null);
		}

		/// <summary>
		///       添加文档元素
		///       </summary>
		/// <param name="element">要添加的内容</param>
		[DCPublishAPI]
		public void Append(XTextElement element)
		{
			AppendWithStyle(element, null);
		}

		/// <summary>
		///       插入文档元素
		///       </summary>
		/// <param name="index">序号</param>
		/// <param name="element">文档元素对象</param>
		public void Insert(int index, XTextElement element)
		{
			InsertWithStyle(index, element, null);
		}

		/// <summary>
		///       添加文档元素
		///       </summary>
		/// <param name="element">要添加的内容</param>
		/// <param name="style">新文档元素的样式</param>
		[DCPublishAPI]
		public void AppendWithStyle(XTextElement element, DocumentContentStyle style)
		{
			int num = 9;
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			if (Container.Elements.Contains(element))
			{
				throw new Exception("已经存在要添加的元素");
			}
			element.Parent = Container;
			element.OwnerDocument = Document;
			if (style != null && Document != null)
			{
				element.StyleIndex = Document.ContentStyles.GetStyleIndex(style);
			}
			if (!AppendRawMode && Container is XTextContentElement && Container.Elements.LastElement is XTextParagraphFlagElement)
			{
				Container.Elements.method_13(Container.Elements.Count - 1, element);
			}
			else
			{
				Container.Elements.Add(element);
			}
			if (Container is XTextSectionElement && element is XTextSectionElement)
			{
				((XTextSectionElement)Container).method_56();
			}
		}

		/// <summary>
		///       添加文档元素
		///       </summary>
		/// <param name="index">序号</param>
		/// <param name="element">要添加的内容</param>
		/// <param name="style">新文档元素的样式</param>
		[DCPublishAPI]
		public void InsertWithStyle(int index, XTextElement element, DocumentContentStyle style)
		{
			int num = 11;
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			element.Parent = Container;
			element.OwnerDocument = Document;
			index = FixIndex(index);
			if (style != null && Document != null)
			{
				element.StyleIndex = Document.ContentStyles.GetStyleIndex(style);
			}
			Container.Elements.method_13(index, element);
			if (Container is XTextSectionElement && element is XTextSectionElement)
			{
				((XTextSectionElement)Container).method_56();
			}
		}

		/// <summary>
		///       添加多个文档元素
		///       </summary>
		/// <param name="elements">
		/// </param>
		[DCPublishAPI]
		public void AppendRange(XTextElementList elements)
		{
			AppendRangeWithStyle(elements, null);
		}

		/// <summary>
		///       插入多个文档元素
		///       </summary>
		/// <param name="index">插入的位置</param>
		/// <param name="elements">文档元素对象列表</param>
		[DCPublishAPI]
		public void InsertRange(int index, XTextElementList elements)
		{
			InsertRangeWithStyle(index, elements, null);
		}

		/// <summary>
		///       添加多个文档元素
		///       </summary>
		/// <param name="elements">文档元素对象</param>
		/// <param name="style">元素的样式</param>
		[DCPublishAPI]
		public void AppendRangeWithStyle(XTextElementList elements, DocumentContentStyle style)
		{
			int num = 7;
			if (elements == null)
			{
				throw new ArgumentNullException("elements");
			}
			foreach (XTextElement element in elements)
			{
				if (Container.Elements.Contains(element))
				{
					throw new Exception("列表中已经存在元素");
				}
			}
			if (style != null && Document != null)
			{
				int styleIndex = Document.ContentStyles.GetStyleIndex(style);
				foreach (XTextElement element2 in elements)
				{
					element2.StyleIndex = styleIndex;
				}
			}
			if (!AppendRawMode && Container is XTextContentElement && Container.Elements.LastElement is XTextParagraphFlagElement)
			{
				Container.Elements.method_12(Container.Elements.Count - 1, elements);
			}
			else
			{
				Container.Elements.AddRange(elements);
			}
			foreach (XTextElement element3 in elements)
			{
				element3.Parent = Container;
			}
			if (Container is XTextSectionElement)
			{
				((XTextSectionElement)Container).method_56();
			}
		}

		/// <summary>
		///       添加多个文档元素
		///       </summary>
		/// <param name="index">序号</param>
		/// <param name="elements">文档元素对象</param>
		/// <param name="style">样式</param>
		[DCPublishAPI]
		public void InsertRangeWithStyle(int index, XTextElementList elements, DocumentContentStyle style)
		{
			int num = 2;
			if (elements == null)
			{
				throw new ArgumentNullException("elements");
			}
			if (style != null && Document != null)
			{
				int styleIndex = Document.ContentStyles.GetStyleIndex(style);
				foreach (XTextElement element in elements)
				{
					element.StyleIndex = styleIndex;
				}
			}
			foreach (XTextElement element2 in elements)
			{
				element2.Parent = Container;
				element2.OwnerDocument = Document;
			}
			index = FixIndex(index);
			Container.Elements.method_12(index, elements);
			if (Container is XTextSectionElement)
			{
				((XTextSectionElement)Container).method_56();
			}
		}

		/// <summary>
		///       追加其他文档的正文内容
		///       </summary>
		/// <param name="base64String">BASE64格式的字符串</param>
		/// <param name="fileFormat">文件格式</param>
		/// <param name="removeLogicDeletedContent">删除被标记为逻辑删除的内容</param>
		/// <param name="clearUserTrack">清除用户痕迹</param>
		/// <param name="removeComments">清除批注</param>
		/// <param name="deleteRedundant">是否删除末尾的空白内容</param>
		/// <remarks>导入的文档元素个数</remarks>
		[DCPublishAPI]
		public int AppendDocumentContentByBase64String(string base64String, string fileFormat, bool removeLogicDeletedContent, bool clearUserTrack, bool removeComments, bool deleteRedundant)
		{
			XTextDocument xTextDocument = new XTextDocument();
			xTextDocument.LoadFromBase64String(base64String, fileFormat);
			return AppendDocumentContent(xTextDocument, removeLogicDeletedContent, clearUserTrack, removeComments, deleteRedundant);
		}

		/// <summary>
		///       追加其他文档的正文内容
		///       </summary>
		/// <param name="stream">文件流</param>
		/// <param name="fileFormat">文件格式</param>
		/// <param name="removeLogicDeletedContent">删除被标记为逻辑删除的内容</param>
		/// <param name="clearUserTrack">清除用户痕迹</param>
		/// <param name="removeComments">清除批注</param>
		/// <param name="deleteRedundant">是否删除末尾的空白内容</param>
		/// <remarks>导入的文档元素个数</remarks>
		[DCPublishAPI]
		public int AppendDocumentContentByStream(Stream stream, string fileFormat, bool removeLogicDeletedContent, bool clearUserTrack, bool removeComments, bool deleteRedundant)
		{
			XTextDocument xTextDocument = new XTextDocument();
			xTextDocument.Load(stream, fileFormat);
			return AppendDocumentContent(xTextDocument, removeLogicDeletedContent, clearUserTrack, removeComments, deleteRedundant);
		}

		/// <summary>
		///       追加其他文档的正文内容
		///       </summary>
		/// <param name="fileName">文件名</param>
		/// <param name="fileFormat">文件格式</param>
		/// <param name="removeLogicDeletedContent">删除被标记为逻辑删除的内容</param>
		/// <param name="clearUserTrack">清除用户痕迹</param>
		/// <param name="removeComments">清除批注</param>
		/// <param name="deleteRedundant">是否删除末尾的空白内容</param>
		/// <remarks>导入的文档元素个数</remarks>
		[DCPublishAPI]
		public int AppendDocumentContentByFileName(string fileName, string fileFormat, bool removeLogicDeletedContent, bool clearUserTrack, bool removeComments, bool deleteRedundant)
		{
			XTextDocument xTextDocument = new XTextDocument();
			xTextDocument.Load(fileName, fileFormat);
			return AppendDocumentContent(xTextDocument, removeLogicDeletedContent, clearUserTrack, removeComments, deleteRedundant);
		}

		/// <summary>
		///       追加其他文档的正文内容，本操作会破坏作为参数的文档对象的内容
		///       </summary>
		/// <param name="document">文档对象</param>
		/// <param name="removeLogicDeletedContent">删除被标记为逻辑删除的内容</param>
		/// <param name="clearUserTrack">清除用户痕迹</param>
		/// <param name="removeComments">清除批注</param>
		/// <param name="deleteRedundant">是否删除末尾的空白内容</param>
		/// <remarks>导入的文档元素个数</remarks>
		[DCPublishAPI]
		public int AppendDocumentContent(XTextDocument document, bool removeLogicDeletedContent, bool clearUserTrack, bool removeComments, bool deleteRedundant)
		{
			return InsertDocumentContent(Container.Elements.Count, document, removeLogicDeletedContent, clearUserTrack, removeComments, deleteRedundant);
		}

		/// <summary>
		///       插入其他文档的正文内容
		///       </summary>
		/// <param name="index">要插入的序号</param>
		/// <param name="text">文档内容</param>
		/// <param name="fileFormat">文件格式</param>
		/// <param name="removeLogicDeletedContent">删除被标记为逻辑删除的内容</param>
		/// <param name="clearUserTrack">清除用户痕迹</param>
		/// <param name="removeComments">清除批注</param>
		/// <param name="deleteRedundant">是否删除末尾的空白内容</param>
		/// <remarks>导入的文档元素个数</remarks>
		[ComVisible(false)]
		[DCPublishAPI]
		public int AppendDocumentContentByString(string text, string fileFormat, bool removeLogicDeletedContent, bool clearUserTrack, bool removeComments, bool deleteRedundant)
		{
			return InsertDocumentContentByString(Container.Elements.Count, text, fileFormat, removeLogicDeletedContent, clearUserTrack, removeComments, deleteRedundant);
		}

		/// <summary>
		///       插入其他文档的正文内容
		///       </summary>
		/// <param name="index">要插入的序号</param>
		/// <param name="base64String">BASE64格式的字符串</param>
		/// <param name="fileFormat">文件格式</param>
		/// <param name="removeLogicDeletedContent">删除被标记为逻辑删除的内容</param>
		/// <param name="clearUserTrack">清除用户痕迹</param>
		/// <param name="removeComments">清除批注</param>
		/// <param name="deleteRedundant">是否删除末尾的空白内容</param>
		/// <remarks>导入的文档元素个数</remarks>
		[DCPublishAPI]
		public int InsertDocumentContentByBase64String(int index, string base64String, string fileFormat, bool removeLogicDeletedContent, bool clearUserTrack, bool removeComments, bool deleteRedundant)
		{
			XTextDocument xTextDocument = new XTextDocument();
			xTextDocument.LoadFromBase64String(base64String, fileFormat);
			return InsertDocumentContent(index, xTextDocument, removeLogicDeletedContent, clearUserTrack, removeComments, deleteRedundant);
		}

		/// <summary>
		///       插入其他文档的正文内容
		///       </summary>
		/// <param name="index">要插入的序号</param>
		/// <param name="text">文档内容</param>
		/// <param name="fileFormat">文件格式</param>
		/// <param name="removeLogicDeletedContent">删除被标记为逻辑删除的内容</param>
		/// <param name="clearUserTrack">清除用户痕迹</param>
		/// <param name="removeComments">清除批注</param>
		/// <param name="deleteRedundant">是否删除末尾的空白内容</param>
		/// <remarks>导入的文档元素个数</remarks>
		[ComVisible(false)]
		[DCPublishAPI]
		public int InsertDocumentContentByString(int index, string text, string fileFormat, bool removeLogicDeletedContent, bool clearUserTrack, bool removeComments, bool deleteRedundant)
		{
			XTextDocument xTextDocument = new XTextDocument();
			xTextDocument.LoadFromString(text, fileFormat);
			return InsertDocumentContent(index, xTextDocument, removeLogicDeletedContent, clearUserTrack, removeComments, deleteRedundant);
		}

		/// <summary>
		///       插入其他文档的正文内容
		///       </summary>
		/// <param name="index">要插入的序号</param>
		/// <param name="stream">文件流</param>
		/// <param name="fileFormat">文件格式</param>
		/// <param name="removeLogicDeletedContent">删除被标记为逻辑删除的内容</param>
		/// <param name="clearUserTrack">清除用户痕迹</param>
		/// <param name="removeComments">清除批注</param>
		/// <param name="deleteRedundant">是否删除末尾的空白内容</param>
		/// <remarks>导入的文档元素个数</remarks>
		[ComVisible(false)]
		[DCPublishAPI]
		public int InsertDocumentContentByStream(int index, Stream stream, string fileFormat, bool removeLogicDeletedContent, bool clearUserTrack, bool removeComments, bool deleteRedundant)
		{
			XTextDocument xTextDocument = new XTextDocument();
			xTextDocument.Load(stream, fileFormat);
			return InsertDocumentContent(index, xTextDocument, removeLogicDeletedContent, clearUserTrack, removeComments, deleteRedundant);
		}

		/// <summary>
		///       插入其他文档的正文内容
		///       </summary>
		/// <param name="index">要插入的位置</param>
		/// <param name="fileName">文件名</param>
		/// <param name="fileFormat">文件格式</param>
		/// <param name="removeLogicDeletedContent">删除被标记为逻辑删除的内容</param>
		/// <param name="clearUserTrack">清除用户痕迹</param>
		/// <param name="removeComments">清除批注</param>
		/// <param name="deleteRedundant">是否删除末尾的空白内容</param>
		/// <remarks>导入的文档元素个数</remarks>
		[DCPublishAPI]
		public int InsertDocumentContentByFileName(int index, string fileName, string fileFormat, bool removeLogicDeletedContent, bool clearUserTrack, bool removeComments, bool deleteRedundant)
		{
			XTextDocument xTextDocument = new XTextDocument();
			xTextDocument.Load(fileName, fileFormat);
			return InsertDocumentContent(index, xTextDocument, removeLogicDeletedContent, clearUserTrack, removeComments, deleteRedundant);
		}

		/// <summary>
		///       插入其他文档的正文内容，本操作会破坏作为参数的文档对象的内容
		///       </summary>
		/// <param name="index">要插入的区域的序号</param>
		/// <param name="document">文档对象</param>
		/// <param name="removeLogicDeletedContent">删除被标记为逻辑删除的内容</param>
		/// <param name="clearUserTrack">清除用户痕迹</param>
		/// <param name="removeComments">清除批注</param>
		/// <param name="deleteRedundant">是否删除末尾的空白内容</param>
		/// <remarks>导入的文档元素个数</remarks>
		[DCPublishAPI]
		public int InsertDocumentContent(int index, XTextDocument document, bool removeLogicDeletedContent, bool clearUserTrack, bool removeComments, bool deleteRedundant)
		{
			if (removeLogicDeletedContent)
			{
				WriterUtils.smethod_7(document.Body);
			}
			if (clearUserTrack)
			{
				document.CommitUserTrace();
			}
			if (removeComments)
			{
				document.Comments.Clear();
				foreach (DocumentContentStyle style in document.ContentStyles.Styles)
				{
					style.CommentIndex = -1;
				}
			}
			if (deleteRedundant)
			{
				document.Body.DeleteRedundant(whiteSpace: true, tabSpace: true, paragraphFlag: true, chineseWhitespace: true, pageBreak: true, lineBreak: true, fastMode: true);
			}
			XTextElementList xTextElementList = document.Body.Elements.Clone();
			document.Body.Elements.Clear();
			if (deleteRedundant && xTextElementList.LastElement is XTextParagraphFlagElement)
			{
				xTextElementList.RemoveAt(xTextElementList.Count - 1);
			}
			_ = xTextElementList.LastElement;
			Document.ImportElements(xTextElementList);
			if (xTextElementList.Count > 0)
			{
				InsertRange(index, xTextElementList);
				return xTextElementList.Count;
			}
			return 0;
		}

		private int FixIndex(int index)
		{
			if (index > Container.Elements.Count)
			{
				index = Container.Elements.Count;
			}
			if (Container is XTextContentElement && Container.Elements.LastElement is XTextParagraphFlagElement && index >= Container.Elements.Count)
			{
				index = Container.Elements.Count - 1;
			}
			if (index < 0)
			{
				index = 0;
			}
			return index;
		}
	}
}
