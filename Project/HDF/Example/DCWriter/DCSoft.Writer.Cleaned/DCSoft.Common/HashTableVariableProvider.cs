using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       使用一个哈希列表来实现的字符串变量提供者对象
	                                                                    ///       </summary>
	[ComVisible(false)]
	public class HashTableVariableProvider : IVariableProvider
	{
		private Hashtable myValues = null;

		                                                                    /// <summary>
		                                                                    ///       保存数据的哈希列表
		                                                                    ///       </summary>
		public Hashtable Values => myValues;

		                                                                    /// <summary>
		                                                                    ///       获得所有变量的名称
		                                                                    ///       </summary>
		public string[] AllNames
		{
			get
			{
				ArrayList arrayList = new ArrayList();
				foreach (object key in myValues.Keys)
				{
					arrayList.Add(Convert.ToString(key));
				}
				return (string[])arrayList.ToArray(typeof(string));
			}
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		public HashTableVariableProvider()
		{
			myValues = new Hashtable();
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="vars">哈希列表对象</param>
		public HashTableVariableProvider(Hashtable vars)
		{
			myValues = vars;
		}

		                                                                    /// <summary>
		                                                                    ///       设置变量值
		                                                                    ///       </summary>
		                                                                    /// <param name="Name">变量名称</param>
		                                                                    /// <param name="Value">变量值</param>
		public void Set(string Name, string Value)
		{
			myValues[Name] = Value;
		}

		                                                                    /// <summary>
		                                                                    ///       判断是否存在指定名称的变量
		                                                                    ///       </summary>
		                                                                    /// <param name="Name">变量名称</param>
		                                                                    /// <returns>是否存在指定名称的变量</returns>
		public bool Exists(string Name)
		{
			foreach (object key in myValues.Keys)
			{
				if (Convert.ToString(key) == Name)
				{
					return true;
				}
			}
			return false;
		}

		                                                                    /// <summary>
		                                                                    ///       获得指定名称的变量值
		                                                                    ///       </summary>
		                                                                    /// <param name="Name">变量名称</param>
		                                                                    /// <returns>变量值</returns>
		public string Get(string Name)
		{
			foreach (object key in myValues.Keys)
			{
				if (Convert.ToString(key) == Name)
				{
					return Convert.ToString(myValues[key]);
				}
			}
			return null;
		}
	}
}
