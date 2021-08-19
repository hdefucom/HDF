using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       字符串集合,该集合不会包含相同的字符串值和空引用
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福 2006-1-9</remarks>
	[ComVisible(false)]
	public class SingleStringCollection : CollectionBase
	{
		protected bool bolModified = false;

		protected bool bolReadonly = false;

		private bool bolIgnoreCase = false;

		protected int intPosition = 0;

		                                                                    /// <summary>
		                                                                    ///       对象内容发生改变标志
		                                                                    ///       </summary>
		public bool Modifed
		{
			get
			{
				return bolModified;
			}
			set
			{
				bolModified = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       对象内容只读
		                                                                    ///       </summary>
		public bool Readonly
		{
			get
			{
				return bolReadonly;
			}
			set
			{
				bolReadonly = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       比较字符串时是否区分大小写
		                                                                    ///       </summary>
		public bool IgnoreCase
		{
			get
			{
				return bolIgnoreCase;
			}
			set
			{
				bolIgnoreCase = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       获得指定序号的字符串值
		                                                                    ///       </summary>
		public string this[int index]
		{
			get
			{
				return (string)base.InnerList[index];
			}
			set
			{
				if (CheckValue(value))
				{
					CheckReadonly();
					base.InnerList[index] = value;
				}
			}
		}

		                                                                    /// <summary>
		                                                                    ///       能否移动到上一个位置
		                                                                    ///       </summary>
		public bool CanMovePrevious => intPosition > 0;

		                                                                    /// <summary>
		                                                                    ///       能否移动到下一个位置
		                                                                    ///       </summary>
		public bool CanMoveNext => intPosition <= base.Count - 1;

		                                                                    /// <summary>
		                                                                    ///       当前值
		                                                                    ///       </summary>
		public string CurrentValue => SafeGet(intPosition);

		                                                                    /// <summary>
		                                                                    ///       集合是否包含指定的字符串
		                                                                    ///       </summary>
		                                                                    /// <param name="strValue">字符串值</param>
		                                                                    /// <returns>是否包含</returns>
		public bool Contains(string strValue)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					string strA = (string)enumerator.Current;
					if (string.Compare(strA, strValue, bolIgnoreCase) == 0)
					{
						return true;
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
			return false;
		}

		                                                                    /// <summary>
		                                                                    ///       添加字符串值,若已经存在该值则返回-1否则返回新增的元素的序号
		                                                                    ///       </summary>
		                                                                    /// <param name="strValue">字符串值</param>
		                                                                    /// <returns>新增元素的序号</returns>
		public int Add(string strValue)
		{
			if (CheckValue(strValue))
			{
				CheckReadonly();
				if (Contains(strValue))
				{
					return -1;
				}
				intPosition = base.InnerList.Count;
				return base.InnerList.Add(strValue);
			}
			return -1;
		}

		                                                                    /// <summary>
		                                                                    ///       向对象对象最后面添加字符串，若若已经存在该值则删除
		                                                                    ///       </summary>
		                                                                    /// <param name="strValue">字符串值</param>
		public void AddLast(string strValue)
		{
			if (CheckValue(strValue))
			{
				CheckReadonly();
				int num = IndexOf(strValue);
				if (num >= 0)
				{
					RemoveAt(num);
				}
				base.InnerList.Add(strValue);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       删除指定的字符串值,若存在该字符串则删除并返回true 否则返回false
		                                                                    ///       </summary>
		                                                                    /// <param name="strValue">指定的字符串值</param>
		                                                                    /// <returns>操作是否成功,若存在该字符串则返回true 否则返回false</returns>
		public bool Remove(string strValue)
		{
			CheckReadonly();
			int num = IndexOf(strValue);
			if (num >= 0)
			{
				base.InnerList.RemoveAt(num);
				FixPosition();
				return true;
			}
			return false;
		}

		                                                                    /// <summary>
		                                                                    ///       删除所有的空白字符串
		                                                                    ///       </summary>
		public void RemoveBlankString()
		{
			CheckReadonly();
			for (int num = base.Count - 1; num >= 0; num--)
			{
				if (StringFormatHelper.IsBlankString((string)base.InnerList[num]))
				{
					base.InnerList.RemoveAt(num);
				}
			}
		}

		                                                                    /// <summary>
		                                                                    ///       清空对象值
		                                                                    ///       </summary>
		public new void Clear()
		{
			CheckReadonly();
			FixPosition();
			base.Clear();
		}

		                                                                    /// <summary>
		                                                                    ///       返回指定字符串值在集合中的从0开始的序号,若未找到指定的值则返回-1
		                                                                    ///       </summary>
		                                                                    /// <param name="strValue">字符串值</param>
		                                                                    /// <returns>从0开始的序号</returns>
		public int IndexOf(string strValue)
		{
			int num = 0;
			while (true)
			{
				if (num < base.Count)
				{
					if (string.Compare(strValue, (string)base.InnerList[num]) == 0)
					{
						break;
					}
					num++;
					continue;
				}
				return -1;
			}
			return num;
		}

		                                                                    /// <summary>
		                                                                    ///       检查对象的只读状态
		                                                                    ///       </summary>
		protected void CheckReadonly()
		{
			int num = 3;
			if (bolReadonly)
			{
				throw new NotSupportedException("对象只读");
			}
		}

		                                                                    /// <summary>
		                                                                    ///       检查数据是否可以添加到集合中
		                                                                    ///       </summary>
		                                                                    /// <param name="strValue">字符串数据</param>
		                                                                    /// <returns>可否添加到集合中</returns>
		protected virtual bool CheckValue(string strValue)
		{
			return strValue != null;
		}

		                                                                    /// <summary>
		                                                                    ///       移动当前位置到开始
		                                                                    ///       </summary>
		public void MoveFirst()
		{
			intPosition = 0;
		}

		                                                                    /// <summary>
		                                                                    ///       移动当前位置到最后
		                                                                    ///       </summary>
		public void MoveLast()
		{
			intPosition = base.Count - 1;
		}

		                                                                    /// <summary>
		                                                                    ///       移动到上一个位置
		                                                                    ///       </summary>
		                                                                    /// <returns>获得的字符串值</returns>
		public string MovePrevious()
		{
			return SafeGet(intPosition--);
		}

		                                                                    /// <summary>
		                                                                    ///       移动到下一个位置
		                                                                    ///       </summary>
		                                                                    /// <returns>获得的字符串值</returns>
		public string MoveNext()
		{
			return SafeGet(intPosition++);
		}

		protected string SafeGet(int index)
		{
			if (index >= 0 && index < base.Count)
			{
				return (string)base.List[index];
			}
			return null;
		}

		protected void FixPosition()
		{
			if (intPosition < 0)
			{
				intPosition = 0;
			}
			if (intPosition >= base.Count)
			{
				intPosition = base.Count - 1;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       返回字符串数组
		                                                                    ///       </summary>
		                                                                    /// <returns>字符串数组</returns>
		public string[] ToArray()
		{
			string[] array = new string[base.Count];
			for (int i = 0; i < base.Count; i++)
			{
				array[i] = (string)base.List[i];
			}
			return array;
		}

		                                                                    /// <summary>
		                                                                    ///       返回该集合中所有的字符串组成的字符串
		                                                                    ///       </summary>
		                                                                    /// <returns>字符串</returns>
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					string value = (string)enumerator.Current;
					stringBuilder.Append(value);
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

		                                                                    /// <summary>
		                                                                    ///       返回所有元素组成的字符串,各个元素间用指定的分隔字符串隔开
		                                                                    ///       </summary>
		                                                                    /// <param name="strSpliter">分隔字符串</param>
		                                                                    /// <returns>字符串</returns>
		public string ToString(string strSpliter)
		{
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = true;
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					string value = (string)enumerator.Current;
					if (!flag)
					{
						stringBuilder.Append(strSpliter);
					}
					flag = false;
					stringBuilder.Append(value);
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

		                                                                    /// <summary>
		                                                                    ///       返回所有元素组成的字符串,各个元素间用指定的分隔字符串隔开
		                                                                    ///       </summary>
		                                                                    /// <param name="strPrefix">前缀字符串</param>
		                                                                    /// <param name="strSpliter">分隔字符串</param>
		                                                                    /// <returns>字符串</returns>
		public string ToString(string strPrefix, string strSpliter)
		{
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = true;
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					string value = (string)enumerator.Current;
					if (!flag)
					{
						stringBuilder.Append(strSpliter);
					}
					flag = false;
					stringBuilder.Append(strPrefix);
					stringBuilder.Append(value);
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
}
