using DCSoft.Common;
using DCSoft.Writer.Dom;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档区域选择提供者
	///       </summary>
	[ComVisible(false)]
	[DocumentComment]
	public class XTextRangeProvider
	{
		private List<XTextRange> _Ranges = new List<XTextRange>();

		private int _ContentVersion = 0;

		private XTextDocument _Document = null;

		/// <summary>
		///       文档对象
		///       </summary>
		public XTextDocument Document
		{
			get
			{
				return _Document;
			}
			set
			{
				if (_Document != value)
				{
					_Document = value;
					Reset();
				}
			}
		}

		/// <summary>
		///       重新设置对象
		///       </summary>
		protected void Reset()
		{
			_Ranges.Clear();
		}

		/// <summary>
		///       获得区域
		///       </summary>
		/// <param name="baseElement">基础元素</param>
		/// <returns>创建的区域</returns>
		public virtual XTextRange GetRange(XTextElement baseElement)
		{
			if (baseElement == null)
			{
				return null;
			}
			if (Document.ContentVersion != _ContentVersion)
			{
				_Ranges.Clear();
			}
			_ContentVersion = Document.ContentVersion;
			int viewIndex = baseElement.ViewIndex;
			foreach (XTextRange range in _Ranges)
			{
				if (range.Contains(viewIndex))
				{
					return range;
				}
			}
			XTextRange xTextRange = CreateRange(baseElement);
			if (xTextRange != null)
			{
				_Ranges.Add(xTextRange);
			}
			return xTextRange;
		}

		/// <summary>
		///       创建区域
		///       </summary>
		/// <param name="baseElement">基础元素</param>
		/// <returns>创建的区域</returns>
		public virtual XTextRange CreateRange(XTextElement baseElement)
		{
			XTextDocumentContentElement documentContentElement = baseElement.DocumentContentElement;
			if (DetectRangeElemnet(baseElement, baseElement, forward: true) != 0)
			{
				return null;
			}
			int num = documentContentElement.Content.method_8(baseElement);
			if (num < 0)
			{
				return null;
			}
			int num2 = num;
			for (int num3 = num - 1; num3 >= 0; num3--)
			{
				switch (DetectRangeElemnet(baseElement, documentContentElement.Content[num3], forward: true))
				{
				case DetectRangeResult.Include:
					num = num3;
					continue;
				default:
					continue;
				case DetectRangeResult.Cancel:
					return null;
				case DetectRangeResult.Finish:
					num = num3;
					break;
				case DetectRangeResult.Exclude:
					break;
				}
				break;
			}
			for (int num3 = num2 + 1; num3 < documentContentElement.Content.Count; num3++)
			{
				switch (DetectRangeElemnet(baseElement, documentContentElement.Content[num3], forward: false))
				{
				case DetectRangeResult.Include:
					num2 = num3;
					continue;
				default:
					continue;
				case DetectRangeResult.Cancel:
					return null;
				case DetectRangeResult.Finish:
					num2 = num3;
					break;
				case DetectRangeResult.Exclude:
					break;
				}
				break;
			}
			XTextRange xTextRange = new XTextRange(documentContentElement, num, num2 - num + 1);
			_Ranges.Add(xTextRange);
			return xTextRange;
		}

		/// <summary>
		///       判断指定元素是否在范围中
		///       </summary>
		/// <param name="baseElement">判断范围的出发点元素</param>
		/// <param name="element">要判断的元素</param>
		/// <param name="forward">方向</param>
		/// <returns>是属于范围中</returns>
		protected virtual DetectRangeResult DetectRangeElemnet(XTextElement baseElement, XTextElement element, bool forward)
		{
			return DetectRangeResult.Cancel;
		}
	}
}
