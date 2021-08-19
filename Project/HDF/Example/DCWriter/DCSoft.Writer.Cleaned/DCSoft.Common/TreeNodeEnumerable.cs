using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       树状节点枚举器
	                                                                    ///       </summary>
	                                                                    /// <remarks>
	                                                                    ///       本类型遍历树状结构的所有的节点，能使用foreach()结构来遍历树状结构节点。
	                                                                    ///       袁永福到此一游
	                                                                    ///       </remarks>
	[ComVisible(false)]
	[DocumentComment]
	public class TreeNodeEnumerable : IEnumerable
	{
		private class Class8 : IEnumerator
		{
			private class Class9
			{
				public object object_0 = null;

				public IEnumerator ienumerator_0 = null;

				public Class9(object object_1, IEnumerator ienumerator_1)
				{
					object_0 = object_1;
					ienumerator_0 = ienumerator_1;
				}
			}

			private bool bool_0;

			private TreeNodeEnumerable treeNodeEnumerable_0;

			private Stack<Class9> stack_0;

			private IEnumerator ienumerator_0;

			private bool bool_1;

			public object Current
			{
				get
				{
					if (bool_0)
					{
						return null;
					}
					if (stack_0.Count > 0)
					{
						IEnumerator enumerator = stack_0.Peek().ienumerator_0;
						return enumerator.Current;
					}
					return null;
				}
			}

			public Class8(TreeNodeEnumerable treeNodeEnumerable_1)
			{
				int num = 3;
				bool_0 = true;
				treeNodeEnumerable_0 = null;
				stack_0 = new Stack<Class9>();
				ienumerator_0 = null;
				bool_1 = false;
				
				if (treeNodeEnumerable_1 == null)
				{
					throw new ArgumentNullException("parent");
				}
				treeNodeEnumerable_0 = treeNodeEnumerable_1;
				Reset();
			}

			public void Reset()
			{
				treeNodeEnumerable_0.int_0 = 0;
				stack_0.Clear();
				if (treeNodeEnumerable_0.RootNodes != null)
				{
					stack_0.Push(new Class9(treeNodeEnumerable_0.RootParent, treeNodeEnumerable_0.RootNodes.GetEnumerator()));
					bool_0 = true;
				}
				else if (treeNodeEnumerable_0.object_1 != null)
				{
					ArrayList arrayList = new ArrayList();
					object obj = treeNodeEnumerable_0.object_1;
					while (obj != null)
					{
						arrayList.Insert(0, obj);
						obj = treeNodeEnumerable_0.GetParent(obj);
						if (obj != null && arrayList.Contains(obj))
						{
							break;
						}
					}
					method_0(arrayList);
				}
				else if (treeNodeEnumerable_0.ilist_0 != null && treeNodeEnumerable_0.ilist_0.Count > 0)
				{
					method_0(treeNodeEnumerable_0.ilist_0);
				}
			}

			private void method_0(IList ilist_0)
			{
				int num = 0;
				treeNodeEnumerable_0.int_0 = 0;
				bool_0 = false;
				stack_0.Clear();
				stack_0.Push(new Class9(null, new object[1]
				{
					ilist_0[0]
				}.GetEnumerator()));
				stack_0.Peek().ienumerator_0.MoveNext();
				int num2 = 0;
				IEnumerable childNodes;
				while (true)
				{
					if (num2 >= ilist_0.Count - 1)
					{
						return;
					}
					object obj = ilist_0[num2];
					childNodes = treeNodeEnumerable_0.GetChildNodes(obj);
					if (childNodes != null)
					{
						object obj2 = ilist_0[num2 + 1];
						IEnumerator enumerator = childNodes.GetEnumerator();
						stack_0.Push(new Class9(obj, enumerator));
						bool flag = false;
						int num3 = 1000000;
						while (enumerator.MoveNext())
						{
							if (enumerator.Current != obj2)
							{
								if (num3-- < 0)
								{
									throw new Exception("TreeNodeEnumerable:可能死循环");
								}
								continue;
							}
							ienumerator_0 = enumerator;
							flag = true;
							break;
						}
						if (!flag)
						{
							break;
						}
						num2++;
						continue;
					}
					throw new Exception("TreeNodeEnumerable:this._Parent._GetChildNodeHandler(p)==null");
				}
				throw new Exception("TreeNodeEnumerable:" + childNodes.GetType().FullName + "，没找到指定子节点");
			}

			public object method_1()
			{
				if (stack_0.Count > 0)
				{
					return stack_0.Peek().object_0;
				}
				return null;
			}

			public bool MoveNext()
			{
				treeNodeEnumerable_0.class8_0 = this;
				object current;
				do
				{
					if (method_4())
					{
						current = Current;
						continue;
					}
					return false;
				}
				while (!treeNodeEnumerable_0.IsPublish(current));
				treeNodeEnumerable_0.int_0++;
				return true;
			}

			public void method_2()
			{
				bool_1 = true;
			}

			public void method_3()
			{
				if (stack_0.Count > 0)
				{
					Class9 @class = stack_0.Pop();
					if (stack_0.Count > 0)
					{
						stack_0.Peek()?.ienumerator_0.MoveNext();
					}
				}
			}

			private bool method_4()
			{
				if (stack_0.Count > 0)
				{
					IEnumerator enumerator = stack_0.Peek().ienumerator_0;
					if (bool_0)
					{
						bool_0 = false;
						return enumerator.MoveNext();
					}
					if (enumerator != null && enumerator.Current != null)
					{
						Class9 @class = null;
						if (bool_1)
						{
							bool_1 = false;
						}
						else
						{
							IEnumerable childNodes = treeNodeEnumerable_0.GetChildNodes(enumerator.Current);
							if (childNodes != null)
							{
								@class = new Class9(enumerator.Current, childNodes.GetEnumerator());
							}
						}
						if (@class != null)
						{
							stack_0.Push(@class);
						}
					}
					while (stack_0.Count > 0)
					{
						IEnumerator enumerator2 = stack_0.Peek().ienumerator_0;
						if (ienumerator_0 != enumerator2)
						{
							if (!enumerator2.MoveNext())
							{
								stack_0.Pop();
								continue;
							}
							return true;
						}
						ienumerator_0 = null;
						return true;
					}
				}
				return false;
			}
		}

		private object object_0;

		private int int_0;

		private object object_1;

		private IList ilist_0;

		private IEnumerable ienumerable_0;

		private Class8 class8_0;

		                                                                    /// <summary>
		                                                                    ///       根节点的父对象
		                                                                    ///       </summary>
		protected object RootParent
		{
			get
			{
				return object_0;
			}
			set
			{
				object_0 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       最后一次的移动到的位置
		                                                                    ///       </summary>
		public int LastPosition => int_0;

		protected IEnumerable RootNodes
		{
			get
			{
				return ienumerable_0;
			}
			set
			{
				ienumerable_0 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       当前对象的父节点对象
		                                                                    ///       </summary>
		public object CurrentParent
		{
			get
			{
				if (class8_0 != null)
				{
					return class8_0.method_1();
				}
				return null;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		protected TreeNodeEnumerable()
		{
			object_0 = null;
			int_0 = 0;
			object_1 = null;
			ilist_0 = null;
			ienumerable_0 = null;
			class8_0 = null;
			
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象,参数为根节点列表和子节点属性名
		                                                                    ///       </summary>
		                                                                    /// <param name="rootNodes">根节点列表</param>
		protected TreeNodeEnumerable(object object_2, bool bool_0 = false)
		{
			int num = 8;
			object_0 = null;
			int_0 = 0;
			object_1 = null;
			ilist_0 = null;
			ienumerable_0 = null;
			class8_0 = null;
			
			if (object_2 == null)
			{
				throw new ArgumentNullException("rootNode");
			}
			if (bool_0)
			{
				object_1 = object_2;
			}
			else
			{
				ienumerable_0 = new object[1]
				{
					object_2
				};
			}
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象,参数为根节点列表和子节点属性名
		                                                                    ///       </summary>
		                                                                    /// <param name="rootNodes">根节点列表</param>
		protected TreeNodeEnumerable(IList ilist_1, bool bool_0 = false)
		{
			int num = 7;
			object_0 = null;
			int_0 = 0;
			object_1 = null;
			ilist_0 = null;
			ienumerable_0 = null;
			class8_0 = null;
			
			if (ilist_1 == null)
			{
				throw new ArgumentNullException("rootNode");
			}
			if (bool_0)
			{
				ilist_0 = ilist_1;
			}
			else
			{
				ienumerable_0 = ilist_1;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       获得子节点列表
		                                                                    ///       </summary>
		                                                                    /// <param name="instance">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public virtual IEnumerable GetChildNodes(object instance)
		{
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       判断对象是否存在父子关系
		                                                                    ///       </summary>
		                                                                    /// <param name="parent">父节点对象</param>
		                                                                    /// <param name="child">子节点对象</param>
		                                                                    /// <returns>是否存在父子关系</returns>
		public virtual bool IsParent(object parent, object child)
		{
			return false;
		}

		public virtual bool AppendChild(object parent, object child)
		{
			return false;
		}

		                                                                    /// <summary>
		                                                                    ///       构造树状结构。需要实现本类型的IsParent()和AppendChild()方法。
		                                                                    ///       </summary>
		                                                                    /// <param name="resultList">
		                                                                    /// </param>
		public virtual void BuildTree(IList resultList)
		{
			int num = 1;
			if (resultList == null)
			{
				throw new ArgumentNullException("resultList");
			}
			if (ienumerable_0 == null)
			{
				throw new NullReferenceException("this._RootNodes");
			}
			resultList.Clear();
			foreach (object item in ienumerable_0)
			{
				resultList.Add(item);
			}
			ArrayList arrayList = new ArrayList();
			new Dictionary<object, IList>();
			foreach (object item2 in ienumerable_0)
			{
				foreach (object item3 in ienumerable_0)
				{
					if (item2 != item3 && IsParent(item2, item3) && !arrayList.Contains(item3))
					{
						AppendChild(item2, item3);
						arrayList.Add(item3);
						if (resultList.Contains(item2))
						{
							resultList.Remove(item2);
						}
					}
				}
			}
		}

		                                                                    /// <summary>
		                                                                    ///       获得父节点
		                                                                    ///       </summary>
		                                                                    /// <param name="childNode">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public virtual object GetParent(object childNode)
		{
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       判断是否是对外发布的节点对象
		                                                                    ///       </summary>
		                                                                    /// <param name="instance">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public virtual bool IsPublish(object instance)
		{
			return true;
		}

		                                                                    /// <summary>
		                                                                    ///       忽略掉当前子节点，立即退出当前层次的循环。
		                                                                    ///       </summary>
		public void CancelChild()
		{
			if (class8_0 != null)
			{
				class8_0.method_2();
			}
		}

		                                                                    /// <summary>
		                                                                    ///       获得枚举器
		                                                                    ///       </summary>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public IEnumerator GetEnumerator()
		{
			Class8 result = class8_0 = new Class8(this);
			int_0 = 0;
			return result;
		}
	}
}
