using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.Design
{
	                                                                    /// <summary>
	                                                                    ///       成员信息对象列表
	                                                                    ///       </summary>
	[Serializable]
	[ComVisible(false)]
	public class DCMemberInfoList : List<DCMemberInfo>
	{
		private class MemberComparer : IComparer<DCMemberInfo>
		{
			private int _type = 0;

			public MemberComparer(int type)
			{
				_type = type;
			}

			public int Compare(DCMemberInfo dcmemberInfo_0, DCMemberInfo dcmemberInfo_1)
			{
				int num = 0;
				num = ((dcmemberInfo_0 is DCFieldInfo) ? 3 : ((dcmemberInfo_0 is DCPropertyInfo) ? 2 : ((dcmemberInfo_0 is DCMethodInfo) ? 1 : 0)));
				int num2 = 0;
				num2 = ((dcmemberInfo_1 is DCFieldInfo) ? 3 : ((dcmemberInfo_1 is DCPropertyInfo) ? 2 : ((dcmemberInfo_1 is DCMethodInfo) ? 1 : 0)));
				if (num != num2)
				{
					return num - num2;
				}
				if (_type == 0)
				{
					return string.Compare(dcmemberInfo_0.Name, dcmemberInfo_1.Name, ignoreCase: true);
				}
				if (_type == 1)
				{
					string strA = string.IsNullOrEmpty(dcmemberInfo_0.DisplayName) ? dcmemberInfo_0.Name : dcmemberInfo_0.DisplayName;
					string strB = string.IsNullOrEmpty(dcmemberInfo_1.DisplayName) ? dcmemberInfo_1.Name : dcmemberInfo_1.DisplayName;
					return string.Compare(strA, strB, ignoreCase: true);
				}
				return string.Compare(dcmemberInfo_0.Name, dcmemberInfo_1.Name, ignoreCase: true);
			}
		}

		public DCMemberInfo this[string name]
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						DCMemberInfo current = enumerator.Current;
						if (string.Compare(current.Name, name, ignoreCase: false) == 0)
						{
							return current;
						}
					}
				}
				return null;
			}
		}

		public bool Contains(string name)
		{
			return this[name] != null;
		}

		                                                                    /// <summary>
		                                                                    ///       按照名称进行排序
		                                                                    ///       </summary>
		public void SortByName()
		{
			Sort(new MemberComparer(0));
		}

		                                                                    /// <summary>
		                                                                    ///       按照显示名称进行排序
		                                                                    ///       </summary>
		public void SortByDispalyName()
		{
			Sort(new MemberComparer(1));
		}
	}
}
