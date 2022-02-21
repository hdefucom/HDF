#define DEBUG
using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Xml;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       文档参数列表
	///       </summary>
	[Serializable]
	[DebuggerDisplay("Count={ Count }")]
	
	[ComVisible(false)]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	public class DocumentParameterCollection : List<DocumentParameter>, ICloneable
	{
		/// <summary>
		///       获得指定名称的参数对象
		///       </summary>
		/// <param name="name">参数名称</param>
		/// <returns>获得的参数对象</returns>
		
		public DocumentParameter this[string name]
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						DocumentParameter current = enumerator.Current;
						if (string.Compare(current.Name, name, ignoreCase: true) == 0)
						{
							return current;
						}
					}
				}
				return null;
			}
		}

		/// <summary>
		///       所有参数名称
		///       </summary>
		
		public string[] Names
		{
			get
			{
				string[] array = new string[base.Count];
				for (int i = 0; i < base.Count; i++)
				{
					array[i] = base[i].Name;
				}
				return array;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public DocumentParameterCollection()
		{
		}

		/// <summary>
		///       为COM接口开放的读取列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <returns>获得的列表成员对象</returns>
		[ComVisible(true)]
		
		public DocumentParameter ComGetItem(int index)
		{
			return base[index];
		}

		/// <summary>
		///       为COM接口开放的设置列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <param name="item">新的列表成员对象</param>
		[ComVisible(true)]
		
		public void ComSetItem(int index, DocumentParameter item)
		{
			base[index] = item;
		}

		/// <summary>
		///       复制数据
		///       </summary>
		/// <param name="ps">目标</param>
		public void CopytValuesTo(DocumentParameterCollection documentParameterCollection_0)
		{
			if (documentParameterCollection_0 != null)
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						DocumentParameter current = enumerator.Current;
						documentParameterCollection_0.SetValue(current.Name, current.Value);
					}
				}
			}
		}

		/// <summary>
		///       获得指定名称的参数值
		///       </summary>
		/// <param name="name">参数名称</param>
		/// <returns>参数值</returns>
		
		public object GetValue(string name)
		{
			return this[name]?.Value;
		}

		/// <summary>
		///       设置参数值
		///       </summary>
		/// <param name="name">参数名</param>
		/// <param name="Value">参数值</param>
		
		public void SetValue(string name, object Value)
		{
			DocumentParameter documentParameter = this[name];
			if (documentParameter == null)
			{
				documentParameter = new DocumentParameter();
				documentParameter.Name = name;
				documentParameter.Value = Value;
				Add(documentParameter);
			}
			else
			{
				documentParameter.Value = Value;
			}
		}

		/// <summary>
		///       设置XML值
		///       </summary>
		/// <param name="name">参数名</param>
		/// <param name="xmlText">XML字符串</param>
		
		public void SetXmlValue(string name, string xmlText)
		{
			int num = 0;
			XmlDocument xmlDocument = new XmlDocument();
			if (string.IsNullOrEmpty(xmlText))
			{
				xmlDocument.LoadXml("<a/>");
			}
			else
			{
				try
				{
					xmlDocument.LoadXml(xmlText);
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.Message);
					xmlDocument.LoadXml("<a/>");
				}
			}
			SetValue(name, xmlDocument.DocumentElement);
		}

		/// <summary>
		///       获得XML值
		///       </summary>
		/// <param name="name">参数名</param>
		/// <returns>XML值</returns>
		
		public string GetXmlValue(string name)
		{
			object value = GetValue(name);
			if (value is XmlNode)
			{
				return ((XmlNode)value).OuterXml;
			}
			return null;
		}

		/// <summary>
		///       判断是否存在指定名称的参数
		///       </summary>
		/// <param name="name">参数名</param>
		/// <returns>是否有指定名称的参数</returns>
		
		public bool Contains(string name)
		{
			return this[name] != null;
		}

		/// <summary>
		///       删除指定名称的参数
		///       </summary>
		/// <param name="name">参数名</param>
		
		public void Remove(string name)
		{
			DocumentParameter documentParameter = this[name];
			if (documentParameter != null)
			{
				Remove(documentParameter);
			}
		}

		
		public string ToValueString()
		{
			int num = 8;
			StringBuilder stringBuilder = new StringBuilder();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DocumentParameter current = enumerator.Current;
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append("&");
					}
					stringBuilder.Append(current.Name + "=");
					stringBuilder.Append(HttpUtility.HtmlEncode(current.StringValue));
				}
			}
			return stringBuilder.ToString();
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		
		public DocumentParameterCollection Clone()
		{
			return (DocumentParameterCollection)((ICloneable)this).Clone();
		}

		object ICloneable.Clone()
		{
			DocumentParameterCollection documentParameterCollection = new DocumentParameterCollection();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DocumentParameter current = enumerator.Current;
					documentParameterCollection.Add(current.Clone());
				}
			}
			return documentParameterCollection;
		}
	}
}
