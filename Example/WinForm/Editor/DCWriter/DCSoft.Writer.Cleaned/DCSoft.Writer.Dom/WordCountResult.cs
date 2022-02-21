using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档内容统计信息对象
	///       </summary>
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	
	[ComDefaultInterface(typeof(IWordCountResult))]
	[Guid("CCC5A209-B177-4A6C-A148-2827004D4729")]
	[ComClass("CCC5A209-B177-4A6C-A148-2827004D4729", "25BA178C-AE0A-42D4-AACF-FA8A106523C3")]
	[ComVisible(true)]
	public class WordCountResult : IWordCountResult
	{
		internal const string CLASSID = "CCC5A209-B177-4A6C-A148-2827004D4729";

		internal const string CLASSID_Interface = "25BA178C-AE0A-42D4-AACF-FA8A106523C3";

		private int _Pages;

		private int _Paragraphs;

		private int _Words;

		private int _CharsNoWhitespace;

		private int _Chars;

		private int _Lines;

		private int _Images;

		/// <summary>
		///       页数
		///       </summary>
		
		public int Pages
		{
			get
			{
				return _Pages;
			}
			set
			{
				_Pages = value;
			}
		}

		/// <summary>
		///       段落数
		///       </summary>
		
		public int Paragraphs
		{
			get
			{
				return _Paragraphs;
			}
			set
			{
				_Paragraphs = value;
			}
		}

		/// <summary>
		///       单词数
		///       </summary>
		
		public int Words
		{
			get
			{
				return _Words;
			}
			set
			{
				_Words = value;
			}
		}

		/// <summary>
		///       不含空格的字符数
		///       </summary>
		
		public int CharsNoWhitespace
		{
			get
			{
				return _CharsNoWhitespace;
			}
			set
			{
				_CharsNoWhitespace = value;
			}
		}

		/// <summary>
		///       含空格的字符数
		///       </summary>
		
		public int Chars
		{
			get
			{
				return _Chars;
			}
			set
			{
				_Chars = value;
			}
		}

		/// <summary>
		///       文本行数
		///       </summary>
		
		public int Lines
		{
			get
			{
				return _Lines;
			}
			set
			{
				_Lines = value;
			}
		}

		/// <summary>
		///       图片个数
		///       </summary>
		
		public int Images
		{
			get
			{
				return _Images;
			}
			set
			{
				_Images = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public WordCountResult()
		{
			_Pages = 0;
			_Paragraphs = 0;
			_Words = 0;
			_CharsNoWhitespace = 0;
			_Chars = 0;
			_Lines = 0;
			_Images = 0;
			
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="document">文档对象</param>
		/// <param name="content">要统计的文档内容</param>
		
		public WordCountResult(XTextDocument document, IEnumerable content)
		{
			int num = 4;
			_Pages = 0;
			_Paragraphs = 0;
			_Words = 0;
			_CharsNoWhitespace = 0;
			_Chars = 0;
			_Lines = 0;
			_Images = 0;
			
			if (document == null)
			{
				throw new ArgumentNullException("document");
			}
			if (content == null)
			{
				throw new ArgumentNullException("content");
			}
			_Pages = document.Pages.Count;
			bool flag = false;
			XTextLine xTextLine = null;
			foreach (XTextElement item in content)
			{
				if (xTextLine != item.OwnerLine)
				{
					xTextLine = item.OwnerLine;
					_Lines++;
				}
				if (item is XTextParagraphFlagElement)
				{
					_Paragraphs++;
				}
				if (item is XTextCharElement)
				{
					char charValue = ((XTextCharElement)item).CharValue;
					_Chars++;
					if (!char.IsWhiteSpace(charValue))
					{
						_CharsNoWhitespace++;
					}
					if ((charValue >= 'a' && charValue <= 'z') || (charValue >= 'A' && charValue <= 'Z'))
					{
						if (!flag)
						{
							_Words++;
						}
						flag = true;
					}
					else
					{
						if (!char.IsWhiteSpace(charValue))
						{
							_Words++;
						}
						flag = false;
					}
				}
				else
				{
					flag = false;
					if (item is XTextImageElement)
					{
						_Images++;
					}
				}
			}
		}
	}
}
