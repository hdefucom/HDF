using DCSoft.Common;
using DCSoft.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       重复引用的图片数据信息列表，DCWriter内部使用。
	///       </summary>
	[Serializable]
	
	[ComVisible(false)]
	public class RepeatedImageValueList : List<RepeatedImageValue>, IDisposable
	{
		/// <summary>
		///       元素个数,DCWriter内部使用
		///       </summary>
		[XmlAttribute]
		[Browsable(false)]
		public int ItemCount
		{
			get
			{
				return base.Count;
			}
			set
			{
			}
		}

		internal void method_0(XTextDocument xtextDocument_0)
		{
			XTextElementList elementsByType = xtextDocument_0.GetElementsByType(typeof(XTextImageElement));
			foreach (RepeatedImageValue repeatedImage in xtextDocument_0.RepeatedImages)
			{
				repeatedImage.ReferenceCount = 0;
				foreach (XTextImageElement item in elementsByType)
				{
					if (item.EnableRepeatedImage && item.ValueIndexOfRepeatedImage == repeatedImage.ValueIndex)
					{
						repeatedImage.ReferenceCount++;
					}
				}
			}
		}

		
		public void method_1(XTextDocument xtextDocument_0)
		{
			XTextElementList elementsByType = xtextDocument_0.GetElementsByType(typeof(XTextImageElement));
			foreach (XTextImageElement item in elementsByType)
			{
				if (item.EnableRepeatedImage && item.Image != null && item.Image.HasContent)
				{
					item.ValueIndexOfRepeatedImage = method_2(item.Image);
					item.Image = null;
				}
			}
			foreach (RepeatedImageValue repeatedImage in xtextDocument_0.RepeatedImages)
			{
				repeatedImage.ReferenceCount = 0;
				foreach (XTextImageElement item2 in elementsByType)
				{
					if (item2.EnableRepeatedImage && item2.ValueIndexOfRepeatedImage == repeatedImage.ValueIndex)
					{
						repeatedImage.ReferenceCount++;
					}
				}
			}
			for (int num = xtextDocument_0.RepeatedImages.Count - 1; num >= 0; num--)
			{
				RepeatedImageValue current = xtextDocument_0.RepeatedImages[num];
				if (current.ReferenceCount == 0)
				{
					xtextDocument_0.RepeatedImages.RemoveAt(num);
					current.Dispose();
				}
			}
		}

		private int method_2(XImageValue ximageValue_0)
		{
			if (!(ximageValue_0?.HasContent ?? false))
			{
				return -1;
			}
			int num = 0;
			while (true)
			{
				if (num < base.Count)
				{
					if (base[num].method_0(ximageValue_0))
					{
						break;
					}
					num++;
					continue;
				}
				RepeatedImageValue repeatedImageValue = new RepeatedImageValue(ximageValue_0);
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						RepeatedImageValue current = enumerator.Current;
						repeatedImageValue.ValueIndex = Math.Max(repeatedImageValue.ValueIndex, current.ValueIndex + 1);
					}
				}
				Add(repeatedImageValue);
				return repeatedImageValue.ValueIndex;
			}
			return base[num].ValueIndex;
		}

		public RepeatedImageValue method_3(int int_0)
		{
			if (int_0 < 0)
			{
				return null;
			}
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					RepeatedImageValue current = enumerator.Current;
					if (current.ValueIndex == int_0)
					{
						return current;
					}
				}
			}
			return null;
		}

		public RepeatedImageValueList method_4()
		{
			RepeatedImageValueList repeatedImageValueList = new RepeatedImageValueList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					RepeatedImageValue current = enumerator.Current;
					repeatedImageValueList.Add((RepeatedImageValue)current.Clone());
				}
			}
			return repeatedImageValueList;
		}

		public void Dispose()
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					RepeatedImageValue current = enumerator.Current;
					current.Dispose();
				}
			}
			Clear();
		}
	}
}
