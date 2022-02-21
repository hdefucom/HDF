using DCSoft.Common;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       成员表达式信息列表
	///       </summary>
	[Serializable]
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("1ECE76F8-B37E-46F7-9E2A-6B40AF9EDA9B", "A9022DCB-008A-4A3E-9504-3392A73C5FC7")]
	
	[Guid("1ECE76F8-B37E-46F7-9E2A-6B40AF9EDA9B")]
	[ComDefaultInterface(typeof(IPropertyExpressionInfoList))]
	[ComVisible(true)]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[DebuggerDisplay("Count={ Count }")]
	[Editor("DCSoft.Writer.Commands.PropertyExpressionInfoListUITypeEditor", typeof(UITypeEditor))]
	public class PropertyExpressionInfoList : List<PropertyExpressionInfo>, IDCStringSerializable, IPropertyExpressionInfoList
	{
		internal const string CLASSID = "1ECE76F8-B37E-46F7-9E2A-6B40AF9EDA9B";

		internal const string CLASSID_Interface = "A9022DCB-008A-4A3E-9504-3392A73C5FC7";

		private XTextElement _Owner = null;

		internal XTextElement Owner
		{
			get
			{
				return _Owner;
			}
			set
			{
				_Owner = value;
			}
		}

		
		public PropertyExpressionInfoList()
		{
		}

		/// <summary>
		///       为COM接口开放的读取列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <returns>获得的列表成员对象</returns>
		
		[ComVisible(true)]
		public PropertyExpressionInfo ComGetItem(int index)
		{
			return base[index];
		}

		/// <summary>
		///       为COM接口开放的设置列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <param name="item">新的列表成员对象</param>
		
		[ComVisible(true)]
		public void ComSetItem(int index, PropertyExpressionInfo item)
		{
			base[index] = item;
		}

		
		[ComVisible(true)]
		public void SetValue(string memberName, string expression)
		{
			SetValueExt(memberName, expression, allowChainReaction: true);
		}

		
		[ComVisible(true)]
		public void SetValueExt(string memberName, string expression, bool allowChainReaction)
		{
			if (string.IsNullOrEmpty(memberName))
			{
				return;
			}
			if (expression != null)
			{
				expression = expression.Trim();
			}
			PropertyExpressionInfo propertyExpressionInfo = GetItem(memberName);
			if (string.IsNullOrEmpty(expression))
			{
				if (propertyExpressionInfo != null)
				{
					Remove(propertyExpressionInfo);
				}
			}
			else
			{
				if (propertyExpressionInfo == null)
				{
					propertyExpressionInfo = new PropertyExpressionInfo();
					propertyExpressionInfo.Name = memberName;
					Add(propertyExpressionInfo);
				}
				propertyExpressionInfo.Expression = expression;
				propertyExpressionInfo.AllowChainReaction = allowChainReaction;
			}
			if (_Owner != null)
			{
				XTextElement owner = Owner;
				if (owner.OwnerDocument != null && owner.OwnerDocument.ExpressionExecuter != null)
				{
					owner.OwnerDocument.ExpressionExecuter.imethod_4(owner);
				}
			}
		}

		
		public string GetValue(string memberName)
		{
			return GetItem(memberName)?.Expression;
		}

		
		public PropertyExpressionInfo GetItem(string memberName)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PropertyExpressionInfo current = enumerator.Current;
					if (string.Compare(current.Name, memberName, ignoreCase: true) == 0)
					{
						return current;
					}
				}
			}
			return null;
		}

		
		public string DCWriteString()
		{
			GClass340 gClass = new GClass340();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PropertyExpressionInfo current = enumerator.Current;
					gClass.method_2(current.Name, current.Expression);
				}
			}
			return gClass.ToString();
		}

		
		public void DCReadString(string text)
		{
			GClass340 gClass = new GClass340(text);
			foreach (GClass341 item in gClass)
			{
				SetValue(item.Name, item.method_0());
			}
		}

		
		public override string ToString()
		{
			return DCWriteString();
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		
		public PropertyExpressionInfoList Clone()
		{
			PropertyExpressionInfoList propertyExpressionInfoList = new PropertyExpressionInfoList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PropertyExpressionInfo current = enumerator.Current;
					propertyExpressionInfoList.Add(current.method_0());
				}
			}
			return propertyExpressionInfoList;
		}

		/// <summary>
		///       非深度复制
		///       </summary>
		/// <returns>复制品</returns>
		
		public PropertyExpressionInfoList CloneNotDeeply()
		{
			PropertyExpressionInfoList propertyExpressionInfoList = new PropertyExpressionInfoList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PropertyExpressionInfo current = enumerator.Current;
					propertyExpressionInfoList.Add(current);
				}
			}
			return propertyExpressionInfoList;
		}
	}
}
