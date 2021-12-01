using DCSoft.Common;
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Serialization;

namespace DCSoft.Script
{
	/// <summary>
	///       global object instance list
	///       </summary>
	[XmlType]
	[DebuggerDisplay("Count={ Count }")]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[ComVisible(false)]
	public class XVBAScriptGlobalObjectList : IEnumerable, ICloneable
	{
		private ArrayList myItems = new ArrayList();

		/// <summary>
		///       get instance specify  name
		///       </summary>
		/// <param name="name">name</param>
		/// <returns>instance</returns>
		public object this[string name]
		{
			get
			{
				foreach (XVBAScriptGlobalObject myItem in myItems)
				{
					if (string.Compare(myItem.Name, name, ignoreCase: true) == 0)
					{
						return myItem.Value;
					}
				}
				return null;
			}
			set
			{
				foreach (XVBAScriptGlobalObject myItem in myItems)
				{
					if (string.Compare(myItem.Name, name, ignoreCase: true) == 0)
					{
						myItem.Value = value;
						if (value != null)
						{
							myItem.ValueType = value.GetType();
						}
						return;
					}
				}
				XVBAScriptGlobalObject xVBAScriptGlobalObject2 = new XVBAScriptGlobalObject();
				xVBAScriptGlobalObject2.Name = name;
				xVBAScriptGlobalObject2.Value = value;
				if (value != null)
				{
					xVBAScriptGlobalObject2.ValueType = value.GetType();
				}
				myItems.Add(xVBAScriptGlobalObject2);
			}
		}

		public int Count => myItems.Count;

		public void SetValue(string name, object Value, Type ValueType)
		{
			int num = 16;
			if (!XmlReader.IsName(name))
			{
				throw new ArgumentException("name");
			}
			if (ValueType == null)
			{
				throw new ArgumentNullException("ValueType");
			}
			foreach (XVBAScriptGlobalObject myItem in myItems)
			{
				if (string.Compare(myItem.Name, name, ignoreCase: true) == 0)
				{
					myItem.Value = Value;
					myItem.ValueType = ValueType;
					return;
				}
			}
			XVBAScriptGlobalObject xVBAScriptGlobalObject2 = new XVBAScriptGlobalObject();
			xVBAScriptGlobalObject2.Name = name;
			xVBAScriptGlobalObject2.Value = Value;
			xVBAScriptGlobalObject2.ValueType = ValueType;
			myItems.Add(xVBAScriptGlobalObject2);
		}

		private XVBAScriptGlobalObject GetItem(string name)
		{
			int num = 11;
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			foreach (XVBAScriptGlobalObject myItem in myItems)
			{
				if (string.Compare(myItem.Name, name, ignoreCase: true) == 0)
				{
					return myItem;
				}
			}
			return null;
		}

		/// <summary>
		///       删除指定名称的全局对象
		///       </summary>
		/// <param name="name">指定的名称</param>
		public void Remove(string name)
		{
			XVBAScriptGlobalObject item = GetItem(name);
			if (item != null)
			{
				myItems.Remove(item);
			}
		}

		public void Clear()
		{
			myItems.Clear();
		}

		public IEnumerator GetEnumerator()
		{
			return myItems.GetEnumerator();
		}

		object ICloneable.Clone()
		{
			XVBAScriptGlobalObjectList xVBAScriptGlobalObjectList = (XVBAScriptGlobalObjectList)Activator.CreateInstance(GetType());
			xVBAScriptGlobalObjectList.myItems.Clear();
			foreach (XVBAScriptGlobalObject myItem in myItems)
			{
				XVBAScriptGlobalObject xVBAScriptGlobalObject2 = new XVBAScriptGlobalObject();
				xVBAScriptGlobalObject2.Name = myItem.Name;
				xVBAScriptGlobalObject2.Value = myItem.Value;
				xVBAScriptGlobalObject2.ValueType = myItem.ValueType;
				xVBAScriptGlobalObjectList.myItems.Add(xVBAScriptGlobalObject2);
			}
			return xVBAScriptGlobalObjectList;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public XVBAScriptGlobalObjectList Clone()
		{
			return (XVBAScriptGlobalObjectList)((ICloneable)this).Clone();
		}

		public void CopyTo(XVBAScriptGlobalObjectList list)
		{
			int num = 5;
			if (list == null)
			{
				throw new ArgumentNullException("list");
			}
			if (myItems == null)
			{
				list.myItems = new ArrayList();
			}
			else
			{
				list.myItems = (ArrayList)myItems.Clone();
			}
		}
	}
}
