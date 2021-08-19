using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.Design
{
	                                                                    /// <summary>
	                                                                    ///       类型列表
	                                                                    ///       </summary>
	[Serializable]
	[DocumentComment]
	[ComVisible(false)]
	public class DCTypeInfoList : List<DCTypeInfo>
	{
		private class TypeNameComparer : IComparer<DCTypeInfo>
		{
			public int Compare(DCTypeInfo dctypeInfo_0, DCTypeInfo dctypeInfo_1)
			{
				return string.Compare(dctypeInfo_0.FullName, dctypeInfo_1.FullName);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       获得指定名称的类型信息对象
		                                                                    ///       </summary>
		                                                                    /// <param name="name">类型名称</param>
		                                                                    /// <returns>获得的信息对象</returns>
		public DCTypeInfo this[string name]
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						DCTypeInfo current = enumerator.Current;
						if (current.FullName == name)
						{
							return current;
						}
					}
				}
				return null;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       判断是否存在指定名称的类型
		                                                                    ///       </summary>
		                                                                    /// <param name="name">类型名称</param>
		                                                                    /// <returns>是否存在名称</returns>
		public bool Contains(string name)
		{
			return this[name] != null;
		}

		public DCTypeInfo GetTypeBySimpleName(string name)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DCTypeInfo current = enumerator.Current;
					if (current.Name == name)
					{
						return current;
					}
				}
			}
			return null;
		}

		public void SortByFullName()
		{
			Sort(new TypeNameComparer());
		}
	}
}
