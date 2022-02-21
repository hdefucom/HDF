using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>
	///       样式对象列表
	///       </summary>
	[Serializable]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IContentStyleList))]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("00012345-6789-ABCD-EF01-234567890088")]
	[DebuggerDisplay("Count={ Count }")]
	public class ContentStyleList : List<ContentStyle>, IContentStyleList
	{
		
		public ContentStyle SafeGet(int index, ContentStyle defaultValue)
		{
			if (index >= 0 && index < base.Count)
			{
				return base[index];
			}
			return defaultValue;
		}

		/// <summary>
		///       设置数值锁定状态
		///       </summary>
		/// <param name="vLock">
		/// </param>
		
		public void SetValueLocked(bool vLock)
		{
		}

		/// <summary>
		///       项目在列表中的序号
		///       </summary>
		/// <param name="item">
		/// </param>
		/// <returns>
		/// </returns>
		
		public int IndexOfExt(ContentStyle item)
		{
			int num = IndexOf(item);
			if (num >= 0)
			{
				return num;
			}
			int num2 = 0;
			while (true)
			{
				if (num2 < base.Count)
				{
					if (base[num2].method_4(item))
					{
						break;
					}
					num2++;
					continue;
				}
				return -1;
			}
			return num2;
		}

		/// <summary>
		///       更新项目列表的编号属性值
		///       </summary>
		
		public void UpdateStyleIndex()
		{
			for (int i = 0; i < base.Count; i++)
			{
				base[i].Index = i;
			}
		}

		/// <summary>
		///       修复字体名称
		///       </summary>
		
		public void FixFontName()
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ContentStyle current = enumerator.Current;
					XFontValue font = current.Font;
					if (font.method_2())
					{
						current.FontName = font.Name;
					}
				}
			}
		}

		/// <summary>
		///       为COM接口开放的读取列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <returns>获得的列表成员对象</returns>
		[ComVisible(true)]
		
		public ContentStyle ComGetItem(int index)
		{
			return base[index];
		}

		/// <summary>
		///       为COM接口开放的设置列表成员的方法
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <param name="item">新的列表成员对象</param>
		
		[ComVisible(true)]
		public void ComSetItem(int index, ContentStyle item)
		{
			base[index] = item;
		}
	}
}
