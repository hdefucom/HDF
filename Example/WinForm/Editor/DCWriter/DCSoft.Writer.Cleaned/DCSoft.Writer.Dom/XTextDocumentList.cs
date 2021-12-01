using DCSoft.Common;
using DCSoft.Printing;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档对象列表
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[DCPublishAPI]
	[ClassInterface(ClassInterfaceType.None)]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IXTextDocumentList))]
	[Guid("00012345-6789-ABCD-EF01-23456789000C")]
	[ComClass("00012345-6789-ABCD-EF01-23456789000C", "18CD21C5-CCC7-48D8-B3E4-F5B37B75959F")]
	[DebuggerDisplay("Count={ Count }")]
	[DocumentComment]
	public class XTextDocumentList : List<XTextDocument>, IXTextDocumentList
	{
		internal const string CLASSID = "00012345-6789-ABCD-EF01-23456789000C";

		internal const string CLASSID_Interface = "18CD21C5-CCC7-48D8-B3E4-F5B37B75959F";

		private XAttributeList _Attributes = new XAttributeList();

		private int _CurrentDocumentIndex = -1;

		/// <summary>
		///       额外的属性
		///       </summary>
		[DCPublishAPI]
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
		///       当前文档编号
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		public int CurrentDocumentIndex
		{
			get
			{
				return _CurrentDocumentIndex;
			}
			set
			{
				_CurrentDocumentIndex = value;
			}
		}

		/// <summary>
		///       第一个文档对象
		///       </summary>
		[DCPublishAPI]
		public XTextDocument FirstDocument
		{
			get
			{
				if (base.Count > 0)
				{
					return base[0];
				}
				return null;
			}
		}

		/// <summary>
		///       最后一个文档对象
		///       </summary>
		[DCPublishAPI]
		public XTextDocument LastDocument
		{
			get
			{
				if (base.Count > 0)
				{
					return base[base.Count - 1];
				}
				return null;
			}
		}

		/// <summary>
		///       所有文档对象的文档页集合
		///       </summary>
		[DCPublishAPI]
		public PrintPageCollection AllPages
		{
			get
			{
				PrintPageCollection printPageCollection = new PrintPageCollection();
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						XTextDocument current = enumerator.Current;
						printPageCollection.AddRange(current.Pages);
					}
				}
				for (int i = 0; i < printPageCollection.Count; i++)
				{
					printPageCollection[i].GlobalIndex = i;
				}
				return printPageCollection;
			}
		}

		/// <summary>
		///       标题
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		public string Title
		{
			get
			{
				int num = 11;
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						XTextDocument current = enumerator.Current;
						if (!string.IsNullOrEmpty(current.Info.Title))
						{
							return current.Info.Title;
						}
					}
				}
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						XTextDocument current = enumerator.Current;
						if (!string.IsNullOrEmpty(current.FileName))
						{
							return Path.GetFileNameWithoutExtension(current.FileName);
						}
					}
				}
				return "DCSoft.Writer document";
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		[DCPublishAPI]
		public XTextDocumentList()
		{
		}

		/// <summary>
		///       初始化对象并添加一个文档对象
		///       </summary>
		/// <param name="document">
		/// </param>
		[DCPublishAPI]
		public XTextDocumentList(XTextDocument document)
		{
			Add(document);
		}

		/// <summary>
		///       获得对象
		///       </summary>
		/// <param name="index">
		/// </param>
		/// <returns>
		/// </returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DCPublishAPI]
		public XTextDocument GetItem(int index)
		{
			return base[index];
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		[DCPublishAPI]
		public XTextDocumentList Clone()
		{
			XTextDocumentList xTextDocumentList = new XTextDocumentList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					XTextDocument current = enumerator.Current;
					xTextDocumentList.Add(current);
				}
			}
			return xTextDocumentList;
		}

		/// <summary>
		///       追加内容到本列表的最后一个文档对象
		///       </summary>
		/// <param name="document">文档对象</param>
		[DCPublishAPI]
		public void MegeAddToLastDocument(XTextDocument document)
		{
			int num = 3;
			if (document == null)
			{
				throw new ArgumentNullException("document");
			}
			if (base.Count == 0)
			{
				Add(document);
				return;
			}
			XTextDocument lastDocument = LastDocument;
			XTextElementList elements = document.Body.Elements;
			lastDocument.ImportElements(elements);
			lastDocument.Body.Elements.AddRange(elements);
		}

		/// <summary>
		///       为COM接口开放的读取列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <returns>获得的列表成员对象</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public XTextDocument ComGetItem(int index)
		{
			return base[index];
		}

		/// <summary>
		///       为COM接口开放的设置列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <param name="item">新的列表成员对象</param>
		[ComVisible(true)]
		[DCPublishAPI]
		public void ComSetItem(int index, XTextDocument item)
		{
			base[index] = item;
		}
	}
}
