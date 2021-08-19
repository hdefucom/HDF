using DCSoft.Common;
using DCSoft.Writer.Dom;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       带标记的区域提供者对象
	///       </summary>
	[DCPublishAPI]
	[ComVisible(false)]
	public class FlagXTextRangeProvider : XTextRangeProvider
	{
		private char _Prefix = '{';

		private char _Endfix = '}';

		/// <summary>
		///       起始字符
		///       </summary>
		[DCPublishAPI]
		public char Prefix
		{
			get
			{
				return _Prefix;
			}
			set
			{
				if (_Prefix != value)
				{
					_Prefix = value;
					Reset();
				}
			}
		}

		/// <summary>
		///       结尾字符
		///       </summary>
		[DCPublishAPI]
		public char Endfix
		{
			get
			{
				return _Endfix;
			}
			set
			{
				if (_Endfix != value)
				{
					_Endfix = value;
					Reset();
				}
			}
		}

		/// <summary>
		///       检测区域元素
		///       </summary>
		/// <param name="baseElement">基础元素</param>
		/// <param name="element">当前元素</param>
		/// <param name="forward">判断方向</param>
		/// <returns>检测结果</returns>
		protected override DetectRangeResult DetectRangeElemnet(XTextElement baseElement, XTextElement element, bool forward)
		{
			if (element is XTextCharElement)
			{
				char charValue = ((XTextCharElement)element).CharValue;
				if (char.IsLetterOrDigit(charValue))
				{
					return DetectRangeResult.Include;
				}
				if (forward && charValue == _Prefix)
				{
					return DetectRangeResult.Finish;
				}
				if (!forward && charValue == _Endfix)
				{
					return DetectRangeResult.Finish;
				}
				return DetectRangeResult.Cancel;
			}
			return DetectRangeResult.Cancel;
		}
	}
}
