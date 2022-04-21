using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Printing
{
	/// <summary>
	///       打印页集合对象
	///       </summary>
	[Serializable]
	[ComDefaultInterface(typeof(IPrintPageCollection))]
	[ComVisible(true)]
	
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("C9298742-0307-44F3-9FC8-2E6F27AC4246")]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[DebuggerDisplay("Count={ Count }")]
	public class PrintPageCollection : List<PrintPage>, IPrintPageCollection
	{
		private float _Top = 0f;

		/// <summary>
		///       自定义绘制页眉页脚
		///       </summary>
		protected bool bolCustomDrawHeadFooter = false;

		private GraphicsUnit intGraphicsUnit = GraphicsUnit.Document;

		private int intMinPageHeight = 50;

		/// <summary>
		///       自定义绘制页眉页脚
		///       </summary>
		
		public bool CustomDrawHeadFooter
		{
			get
			{
				return bolCustomDrawHeadFooter;
			}
			set
			{
				bolCustomDrawHeadFooter = value;
			}
		}

		/// <summary>
		///       度量单位
		///       </summary>
		
		public GraphicsUnit GraphicsUnit
		{
			get
			{
				return intGraphicsUnit;
			}
			set
			{
				intGraphicsUnit = value;
			}
		}

		/// <summary>
		///       最小页高
		///       </summary>
		
		public int MinPageHeight
		{
			get
			{
				return intMinPageHeight;
			}
			set
			{
				intMinPageHeight = value;
			}
		}

		/// <summary>
		///       对象的顶端位置
		///       </summary>
		public float Top
		{
			get
			{
				return _Top;
			}
			set
			{
				_Top = value;
			}
		}

		/// <summary>
		///       获得第一页
		///       </summary>
		public PrintPage FirstPage
		{
			get
			{
				if (base.Count > 0)
				{
					return base[0];
				}
				return null;
			}
		}

		/// <summary>
		///       获得最后一页
		///       </summary>
		public PrintPage LastPage
		{
			get
			{
				if (base.Count > 0)
				{
					return base[base.Count - 1];
				}
				return null;
			}
		}

		/// <summary>
		///       所有页面的高度
		///       </summary>
		public float Height
		{
			get
			{
				float num = 0f;
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						PrintPage current = enumerator.Current;
						num += current.Height;
					}
				}
				return num;
			}
		}

		/// <summary>
		///       获得可见的页面对象列表
		///       </summary>
		/// <param name="startPageIndex">从0开始计算的开始页码号</param>
		/// <param name="endPageIndex">从0开始计算的结束页码号</param>
		/// <returns>获得的页面信息对象列表</returns>
		
		public PrintPageCollection GetVisiblePages(int startPageIndex, int endPageIndex)
		{
			if (startPageIndex < 0 && endPageIndex < 0)
			{
				return this;
			}
			int num = Math.Max(0, startPageIndex);
			int num2 = base.Count - 1;
			if (endPageIndex >= 0)
			{
				num2 = Math.Min(endPageIndex, base.Count - 1);
			}
			PrintPageCollection printPageCollection = new PrintPageCollection();
			for (int i = num; i <= num2; i++)
			{
				printPageCollection.Add(base[i]);
			}
			return printPageCollection;
		}

		
		public PrintPage SafeGet(int index)
		{
			if (index >= 0 && index < base.Count)
			{
				return base[index];
			}
			return null;
		}

		
		public bool ContainsTop(int vTop)
		{
			float num = _Top;
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PrintPage current = enumerator.Current;
					num += current.Height;
					if (num > (float)vTop)
					{
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>
		///       获得最大的页宽
		///       </summary>
		/// <returns>
		/// </returns>
		
		public float GetPageMaxWidth()
		{
			float num = 0f;
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PrintPage current = enumerator.Current;
					if (current.Width > num)
					{
						num = current.Width;
					}
				}
			}
			return num;
		}

		/// <summary>
		///       返回指定位置处的页面对象
		///       </summary>
		/// <param name="y">指定的垂直位置</param>
		/// <returns>页面对象</returns>
		
		public PrintPage GetPage(int int_0)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PrintPage current = enumerator.Current;
					if (int_0 >= current.ClientBounds.Top && int_0 <= current.ClientBounds.Bottom)
					{
						return current;
					}
				}
			}
			return null;
		}

		
		public PrintPage GetPageByViewPosition(int int_0)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PrintPage current = enumerator.Current;
					if ((float)int_0 >= current.Top && (float)int_0 < current.Bottom)
					{
						return current;
					}
				}
			}
			return null;
		}

		public int IndexOfByPosition(float position, int defaultValue)
		{
			int num = 0;
			int num2 = base.Count - 1;
			while (num2 - num > 10)
			{
				int num3 = (num + num2) / 2;
				if (position >= base[num3].Top)
				{
					num = num3;
				}
				else
				{
					num2 = num3;
				}
			}
			int num4 = num2;
			while (true)
			{
				if (num4 >= num)
				{
					if (position >= base[num4].Top)
					{
						break;
					}
					num4--;
					continue;
				}
				return defaultValue;
			}
			return num4;
		}
	}
}
