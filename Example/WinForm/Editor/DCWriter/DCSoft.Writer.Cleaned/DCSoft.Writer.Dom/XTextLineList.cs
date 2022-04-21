using DCSoft.Common;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文本行集合
	///       </summary>
	[ComClass("00012345-6789-ABCD-EF01-23456789000E", "6C5B2797-EE70-4854-851A-9802A4D73530")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IXTextLineList))]
	[Guid("00012345-6789-ABCD-EF01-23456789000E")]
	
	
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[DebuggerDisplay("Count={ Count }")]
	[ComVisible(true)]
	public class XTextLineList : List<XTextLine>, IXTextLineList
	{
		internal const string string_0 = "00012345-6789-ABCD-EF01-23456789000E";

		internal const string string_1 = "6C5B2797-EE70-4854-851A-9802A4D73530";

		/// <summary>
		///       第一个文本行
		///       </summary>
		public XTextLine FirstLine
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
		///       最后一个文本行
		///       </summary>
		public XTextLine LastLine
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
		///       所有文本行的高度和
		///       </summary>
		public float Height
		{
			get
			{
				float num = 0f;
				XTextLine xTextLine = null;
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						XTextLine current = enumerator.Current;
						xTextLine = current;
						num = num + current.Height + current.Spacing;
					}
				}
				if (xTextLine != null)
				{
					num -= xTextLine.Spacing;
				}
				return num;
			}
		}

		public void method_0(int int_0, XTextLine xtextLine_0)
		{
			base[int_0] = xtextLine_0;
		}

		internal XTextLine method_1(XTextLine xtextLine_0)
		{
			int num = IndexOf(xtextLine_0);
			if (num > 0)
			{
				return base[num - 1];
			}
			return null;
		}

		internal void method_2()
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					XTextLine current = enumerator.Current;
					current.method_31();
				}
			}
			Clear();
		}
	}
}
