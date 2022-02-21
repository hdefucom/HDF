using DCSoft.Common;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档内容正在发生改变事件参数
	///       </summary>
	/// <remarks>编写 袁永福</remarks>
	[ComVisible(true)]
	[Guid("00012345-6789-ABCD-EF01-234567890061")]
	[ComDefaultInterface(typeof(IContentChangingEventArgs))]
	
	[DocumentComment]
	[ComClass("00012345-6789-ABCD-EF01-234567890061", "61FB9A1D-AB49-4AFC-BCCC-0216AA64C328")]
	[ClassInterface(ClassInterfaceType.None)]
	public class ContentChangingEventArgs : EventArgs, IContentChangingEventArgs
	{
		internal const string CLASSID = "00012345-6789-ABCD-EF01-234567890061";

		internal const string CLASSID_Interface = "61FB9A1D-AB49-4AFC-BCCC-0216AA64C328";

		private XTextDocument _Document = null;

		private XTextElement _Element = null;

		private object _Tag = null;

		private int _ElementIndex = 0;

		private XTextElementList _DeletingElements = null;

		private XTextElementList _InsertingElements = null;

		private bool _CancelBubble = false;

		private bool _Cancel = false;

		private bool _Handled = false;

		/// <summary>
		///       文档对象
		///       </summary>
		
		public XTextDocument Document
		{
			get
			{
				return _Document;
			}
			set
			{
				_Document = value;
			}
		}

		/// <summary>
		///       容器元素对象
		///       </summary>
		
		public XTextElement Element
		{
			get
			{
				return _Element;
			}
			set
			{
				_Element = value;
			}
		}

		/// <summary>
		///       额外的数据
		///       </summary>
		
		public object Tag
		{
			get
			{
				return _Tag;
			}
			set
			{
				_Tag = value;
			}
		}

		/// <summary>
		///       发生操作时的元素位置序号
		///       </summary>
		
		public int ElementIndex
		{
			get
			{
				return _ElementIndex;
			}
			set
			{
				_ElementIndex = value;
			}
		}

		/// <summary>
		///       正要删除的元素列表
		///       </summary>
		
		public XTextElementList DeletingElements
		{
			get
			{
				return _DeletingElements;
			}
			set
			{
				_DeletingElements = value;
			}
		}

		/// <summary>
		///       准备新增的元素列表
		///       </summary>
		
		public XTextElementList InsertingElements
		{
			get
			{
				return _InsertingElements;
			}
			set
			{
				_InsertingElements = value;
			}
		}

		/// <summary>
		///       取消事件向上层元素冒泡传递
		///       </summary>
		
		public bool CancelBubble
		{
			get
			{
				return _CancelBubble;
			}
			set
			{
				_CancelBubble = value;
			}
		}

		/// <summary>
		///       用户取消操作
		///       </summary>
		
		public bool Cancel
		{
			get
			{
				return _Cancel;
			}
			set
			{
				_Cancel = value;
			}
		}

		/// <summary>
		///       事件已经被处理掉了，无需后续处理
		///       </summary>
		
		public bool Handled
		{
			get
			{
				return _Handled;
			}
			set
			{
				_Handled = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public ContentChangingEventArgs()
		{
		}

		/// <summary>
		///       获得操作完成后容器元素的预计文本内容
		///       </summary>
		/// <returns>预计的文本</returns>
		
		public string GetContainerNewText()
		{
			XTextContainerElement xTextContainerElement = Element as XTextContainerElement;
			if (xTextContainerElement == null)
			{
				return null;
			}
			XTextElementList xTextElementList = xTextContainerElement.Elements.Clone();
			if (DeletingElements != null)
			{
				foreach (XTextElement deletingElement in DeletingElements)
				{
					int num = xTextElementList.IndexOf(deletingElement);
					if (num >= 0)
					{
						xTextElementList.RemoveAt(num);
					}
				}
			}
			if (InsertingElements != null)
			{
				int num = ElementIndex;
				if (num < 0)
				{
					num = 0;
				}
				if (xTextElementList.Count > 0)
				{
					if (num >= xTextElementList.Count)
					{
						num = xTextElementList.Count - 1;
					}
				}
				else
				{
					num = 0;
				}
				for (int i = 0; i < InsertingElements.Count; i++)
				{
					xTextElementList.method_13(num + i, InsertingElements[i]);
				}
			}
			return xTextElementList.GetInnerText();
		}
	}
}
