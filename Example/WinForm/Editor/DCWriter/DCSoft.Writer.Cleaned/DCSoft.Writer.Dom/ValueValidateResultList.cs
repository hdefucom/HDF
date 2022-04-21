using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       数值校验结果集合
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComClass("00012345-6789-ABCD-EF01-234567890047", "F3A06595-468E-455B-987D-99196DBDAAF9")]
	[DebuggerDisplay("Count={ Count }")]
	[ClassInterface(ClassInterfaceType.None)]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[ComVisible(true)]
	
	[Guid("00012345-6789-ABCD-EF01-234567890047")]
	
	[ComDefaultInterface(typeof(IValueValidateResultList))]
	public class ValueValidateResultList : List<ValueValidateResult>, IValueValidateResultList
	{
		private class ItemComparer : IComparer<ValueValidateResult>
		{
			public int Compare(ValueValidateResult valueValidateResult_0, ValueValidateResult valueValidateResult_1)
			{
				if (valueValidateResult_0.Element != null && valueValidateResult_1.Element != null)
				{
					return WriterUtils.smethod_2(valueValidateResult_0.Element, valueValidateResult_1.Element);
				}
				return 0;
			}
		}

		internal const string CLASSID = "00012345-6789-ABCD-EF01-234567890047";

		internal const string CLASSID_Interface = "F3A06595-468E-455B-987D-99196DBDAAF9";

		
		public ValueValidateResultList()
		{
		}

		/// <summary>
		///       返回表示对象内容的字符串
		///       </summary>
		/// <returns>字符串</returns>
		
		public override string ToString()
		{
			int num = 7;
			StringBuilder stringBuilder = new StringBuilder();
			int num2 = 1;
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ValueValidateResult current = enumerator.Current;
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(Environment.NewLine);
					}
					stringBuilder.Append(Convert.ToString(num2) + ".");
					num2++;
					stringBuilder.Append(current.Message);
				}
			}
			return stringBuilder.ToString();
		}

		/// <summary>
		///       为COM接口开放的读取列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <returns>获得的列表成员对象</returns>
		
		[ComVisible(true)]
		public ValueValidateResult ComGetItem(int index)
		{
			return base[index];
		}

		/// <summary>
		///       为COM接口开放的设置列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <param name="item">新的列表成员对象</param>
		
		[ComVisible(true)]
		public void ComSetItem(int index, ValueValidateResult item)
		{
			base[index] = item;
		}

		/// <summary>
		///       根据元素的DOM层次结构进行排序
		///       </summary>
		internal void SoryByDOMLevel()
		{
			Sort(new ItemComparer());
		}
	}
}
