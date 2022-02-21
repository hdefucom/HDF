using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       批注列表
	///       </summary>
	[Serializable]
	[ComClass("00012345-6789-ABCD-EF01-2345678900FA", "013C10FE-E70E-4E9E-98EB-440F1500F678")]
	[DebuggerDisplay("Count={ Count }")]
	[Guid("00012345-6789-ABCD-EF01-2345678900FA")]
	
	[ComDefaultInterface(typeof(IDocumentCommentList))]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	public class DocumentCommentList : List<DocumentComment>, IDocumentCommentList
	{
		private class CommentComparer : IComparer<DocumentComment>
		{
			public int Compare(DocumentComment documentComment_0, DocumentComment documentComment_1)
			{
				int num = (documentComment_0.AnchorElement != null) ? documentComment_0.AnchorElement.ContentIndex : 0;
				int num2 = (documentComment_1.AnchorElement != null) ? documentComment_1.AnchorElement.ContentIndex : 0;
				return num - num2;
			}
		}

		internal const string CLASSID = "00012345-6789-ABCD-EF01-2345678900FA";

		internal const string CLASSID_Interface = "013C10FE-E70E-4E9E-98EB-440F1500F678";

		/// <summary>
		///       是否存在可见的文档批注
		///       </summary>
		internal bool HasVisibleComment
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						DocumentComment current = enumerator.Current;
						if (current.RuntimeVisible)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		/// <summary>
		///       最大编号
		///       </summary>
		
		public int MaxID
		{
			get
			{
				int num = 0;
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						DocumentComment current = enumerator.Current;
						num = Math.Max(current.Index, num);
					}
				}
				return num;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public DocumentCommentList()
		{
		}

		/// <summary>
		///       为COM接口开放的读取列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <returns>获得的列表成员对象</returns>
		
		[ComVisible(true)]
		public DocumentComment ComGetItem(int index)
		{
			return base[index];
		}

		/// <summary>
		///       为COM接口开放的设置列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <param name="item">新的列表成员对象</param>
		
		[ComVisible(true)]
		public void ComSetItem(int index, DocumentComment item)
		{
			base[index] = item;
		}

		/// <summary>
		///       复制对象，对元素不进行深度复制
		///       </summary>
		/// <returns>复制品</returns>
		
		public DocumentCommentList Clone(bool deeply)
		{
			DocumentCommentList documentCommentList = new DocumentCommentList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DocumentComment current = enumerator.Current;
					if (deeply)
					{
						documentCommentList.Add(current.method_0());
					}
					else
					{
						documentCommentList.Add(current);
					}
				}
			}
			return documentCommentList;
		}

		/// <summary>
		///       内部使用：为视图进行排版
		///       </summary>
		[ComVisible(false)]
		
		public void SortForView()
		{
			if (base.Count >= 2)
			{
				Sort(new CommentComparer());
			}
		}

		/// <summary>
		///       获得指定编号的批注对象
		///       </summary>
		/// <param name="index">指定的编号</param>
		/// <returns>获得的批注对象</returns>
		
		public DocumentComment GetByCommentIndex(int index)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DocumentComment current = enumerator.Current;
					if (current.Index == index)
					{
						return current;
					}
				}
			}
			return null;
		}

		/// <summary>
		///       修正状态
		///       </summary>
		internal void FixDomState()
		{
			int num = MaxID + 1;
			List<int> list = new List<int>();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DocumentComment current = enumerator.Current;
					if (list.Contains(current.Index))
					{
						current.Index = num++;
					}
					else
					{
						list.Add(current.Index);
					}
				}
			}
		}

		/// <summary>
		///       删除从未引用过的文档批注对象
		///       </summary>
		/// <param name="document">
		/// </param>
		internal void RemoveUselessComment(XTextDocument document)
		{
			for (int i = base.Count - 1; i >= 0; i++)
			{
				int index = base[i].Index;
				bool flag = false;
				foreach (DocumentContentStyle style in document.ContentStyles.Styles)
				{
					if (style.CommentIndex == index)
					{
						flag = true;
					}
				}
				if (!flag)
				{
					RemoveAt(i);
					foreach (DocumentContentStyle style2 in document.ContentStyles.Styles)
					{
						if (style2.CommentIndex == index)
						{
							style2.CommentIndex = -1;
						}
					}
				}
			}
		}

		/// <summary>
		///       更新文档样式列表
		///       </summary>
		/// <param name="document">
		/// </param>
		internal void UpdateStylesCommentID(XTextDocument document)
		{
		}

		internal void ClearData()
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DocumentComment current = enumerator.Current;
					current.AnchorElement = null;
					if (current.ReferenceElements != null)
					{
						current.ReferenceElements.Clear();
						current.ReferenceElements = null;
					}
					current.Text = null;
					current.Title = null;
					current.Attributes = null;
					current.Author = null;
					current.AuthorID = null;
					current.Document = null;
					if (current.DataBoundItem is ValueValidateResult)
					{
						ValueValidateResult valueValidateResult = (ValueValidateResult)current.DataBoundItem;
						valueValidateResult.Clear();
					}
					current.DataBoundItem = null;
				}
			}
			Clear();
		}
	}
}
