using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       编号列表
	                                                                    ///       </summary>
	[DocumentComment]
	[ComVisible(false)]
	public class IDList : IEnumerable
	{
		private List<string> _Values = new List<string>();

		private bool _IgnoreCase = true;

		                                                                    /// <summary>
		                                                                    ///       数值
		                                                                    ///       </summary>
		public List<string> Values => _Values;

		                                                                    /// <summary>
		                                                                    ///       转换为整数的数值
		                                                                    ///       </summary>
		public int[] Int32Values
		{
			get
			{
				List<int> list = new List<int>();
				foreach (string value in Values)
				{
					int result = 0;
					if (int.TryParse(value, out result))
					{
						list.Add(result);
					}
				}
				return list.ToArray();
			}
		}

		                                                                    /// <summary>
		                                                                    ///       是否忽略大小写
		                                                                    ///       </summary>
		public bool IgnoreCase
		{
			get
			{
				return _IgnoreCase;
			}
			set
			{
				_IgnoreCase = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       编号个数
		                                                                    ///       </summary>
		public int Count => _Values.Count;

		                                                                    /// <summary>
		                                                                    ///       获得指定序号处的编号值
		                                                                    ///       </summary>
		                                                                    /// <param name="index">序号</param>
		                                                                    /// <returns>编号值</returns>
		public string this[int index] => _Values[index];

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		public IDList()
		{
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="strIDList">编号列表，各个项目之间用逗号分开</param>
		public IDList(string strIDList)
		{
			Parse(strIDList, ',', '\0', '\0');
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="strIDList">编号列表，各个项目之间用逗号分开</param>
		                                                                    /// <param name="spliter">分割字符</param>
		public IDList(string strIDList, char spliter)
		{
			Parse(strIDList, spliter, '\0', '\0');
		}

		                                                                    /// <summary>
		                                                                    ///       获得编号在列表中的序号
		                                                                    ///       </summary>
		                                                                    /// <param name="id">编号值</param>
		                                                                    /// <returns>序号</returns>
		public int IndexOf(string string_0)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				return -1;
			}
			int num = 0;
			while (true)
			{
				if (num < _Values.Count)
				{
					if (string.Compare(_Values[num], string_0, IgnoreCase) == 0)
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
		                                                                    ///       判断列表中是否包含指定的编号
		                                                                    ///       </summary>
		                                                                    /// <param name="id">编号</param>
		                                                                    /// <returns>是否包含</returns>
		public bool Contains(string string_0)
		{
			return IndexOf(string_0) >= 0;
		}

		                                                                    /// <summary>
		                                                                    ///       添加编号
		                                                                    ///       </summary>
		                                                                    /// <param name="id">编号</param>
		                                                                    /// <returns>新编号在列表中的序号</returns>
		public int Add(string string_0)
		{
			int num = IndexOf(string_0);
			if (num >= 0)
			{
				return num;
			}
			_Values.Add(string_0);
			return _Values.Count - 1;
		}

		                                                                    /// <summary>
		                                                                    ///       删除编号
		                                                                    ///       </summary>
		                                                                    /// <param name="id">要删除的编号</param>
		public void Remove(string string_0)
		{
			int num = IndexOf(string_0);
			if (num >= 0)
			{
				_Values.RemoveAt(num);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       解析编号列表字符串
		                                                                    ///       </summary>
		                                                                    /// <param name="Value">要解析的字符串</param>
		                                                                    /// <param name="splitChar">拆分字符</param>
		                                                                    /// <param name="prefixChar">编号前缀字符</param>
		                                                                    /// <param name="endfixChar">编号后缀字符</param>
		public void Parse(string Value, char splitChar, char prefixChar, char endfixChar)
		{
			try
			{
				_Values = new List<string>();
				if (!string.IsNullOrEmpty(Value))
				{
					string[] array = Value.Split(splitChar);
					for (int i = 0; i < array.Length; i++)
					{
						string text = array[i].Trim();
						if (text.Length > 0)
						{
							if (prefixChar > '\0' && text[0] == prefixChar)
							{
								text = text.Substring(1);
							}
							if (endfixChar > '\0' && text.Length > 0 && text[text.Length - 1] == endfixChar)
							{
								text = text.Substring(0, text.Length - 1);
							}
							if (text.Length > 0)
							{
								Add(text);
							}
						}
					}
				}
			}
			catch
			{
				_Values = new List<string>();
			}
		}

		                                                                    /// <summary>
		                                                                    ///       返回表示对象数据的字符串
		                                                                    ///       </summary>
		                                                                    /// <param name="splitChar">分隔字符</param>
		                                                                    /// <returns>字符串</returns>
		public string ToString(char splitChar)
		{
			return ToString(splitChar, '\0', '\0');
		}

		                                                                    /// <summary>
		                                                                    ///       返回表示对象数据的字符串
		                                                                    ///       </summary>
		                                                                    /// <param name="splitChar">分隔字符</param>
		                                                                    /// <param name="prefixChar">编号前缀字符</param>
		                                                                    /// <param name="endfixChar">编号后缀字符</param>
		                                                                    /// <returns>字符串</returns>
		public string ToString(char splitChar, char prefixChar, char endfixChar)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < _Values.Count; i++)
			{
				if (splitChar > '\0' && stringBuilder.Length > 0)
				{
					stringBuilder.Append(splitChar);
				}
				if (prefixChar > '\0')
				{
					stringBuilder.Append(prefixChar);
				}
				stringBuilder.Append(_Values[i]);
				if (endfixChar > '\0')
				{
					stringBuilder.Append(endfixChar);
				}
			}
			return stringBuilder.ToString();
		}

		                                                                    /// <summary>
		                                                                    ///       返回表示对象数据的字符串
		                                                                    ///       </summary>
		                                                                    /// <returns>字符串</returns>
		public override string ToString()
		{
			return ToString(',', '\0', '\0');
		}

		public IEnumerator GetEnumerator()
		{
			if (Values == null)
			{
				return null;
			}
			return Values.GetEnumerator();
		}
	}
}
