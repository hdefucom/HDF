using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       数值校验结果信息对象
	///       </summary>
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	[ComClass("CC401D0B-A5D8-4FCC-86B5-D5606F4EF4AD", "0C3BFAF9-A7AD-4618-B0C3-ED9807B116DF")]
	[ComDefaultInterface(typeof(IValueValidateResult))]
	[Guid("CC401D0B-A5D8-4FCC-86B5-D5606F4EF4AD")]
	
	[ComVisible(true)]
	public class ValueValidateResult : IValueValidateResult
	{
		internal const string CLASSID = "CC401D0B-A5D8-4FCC-86B5-D5606F4EF4AD";

		internal const string CLASSID_Interface = "0C3BFAF9-A7AD-4618-B0C3-ED9807B116DF";

		[NonSerialized]
		private XTextElement _Element = null;

		private ValueValidateLevel _Level = ValueValidateLevel.Error;

		private string _Message = null;

		private ValueValidateResultTypes _Type = ValueValidateResultTypes.ValueValidate;

		private string _ExcludeKeywordText = null;

		/// <summary>
		///       文档元素对象
		///       </summary>
		[XmlIgnore]
		
		public XTextElement Element
		{
			get
			{
				return _Element;
			}
			set
			{
				_Element = value;
			}
		}

		/// <summary>
		///       相关的文档元素名称
		///       </summary>
		[XmlAttribute]
		
		public string ElementID
		{
			get
			{
				if (_Element == null)
				{
					return null;
				}
				return _Element.ID;
			}
			set
			{
			}
		}

		/// <summary>
		///       信息等级
		///       </summary>
		[XmlAttribute]
		
		public ValueValidateLevel Level
		{
			get
			{
				return _Level;
			}
			set
			{
				_Level = value;
			}
		}

		/// <summary>
		///       信息
		///       </summary>
		
		[XmlAttribute]
		public string Message
		{
			get
			{
				return _Message;
			}
			set
			{
				_Message = value;
			}
		}

		/// <summary>
		///       类型
		///       </summary>
		
		[XmlAttribute]
		public ValueValidateResultTypes Type
		{
			get
			{
				return _Type;
			}
			set
			{
				_Type = value;
			}
		}

		/// <summary>
		///       相关的违禁关键字文本
		///       </summary>
		
		[XmlAttribute]
		public string ExcludeKeywordText
		{
			get
			{
				return _ExcludeKeywordText;
			}
			set
			{
				_ExcludeKeywordText = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public ValueValidateResult()
		{
		}

		/// <summary>
		///       在文档中选择相关内容
		///       </summary>
		/// <returns>操作是否成功</returns>
		
		public bool Selet()
		{
			if (Element == null)
			{
				return false;
			}
			XTextDocument ownerDocument = Element.OwnerDocument;
			if (Type == ValueValidateResultTypes.ExcludeKeyword)
			{
				return ownerDocument.Content.method_47(ownerDocument.Content.IndexOf(Element), ExcludeKeywordText.Length);
			}
			Element.Focus();
			return true;
		}

		/// <summary>
		///       获得所引用的文档元素列表
		///       </summary>
		/// <returns>
		/// </returns>
		internal XTextElementList GetReferenceElements()
		{
			if (Element == null)
			{
				return null;
			}
			_ = Element.OwnerDocument;
			if (Type == ValueValidateResultTypes.ExcludeKeyword)
			{
				XTextElementList xTextElementList = new XTextElementList();
				XTextContent content = Element.DocumentContentElement.Content;
				int num = content.method_8(Element);
				if (num >= 0)
				{
					return content.SafeGetRange(num, ExcludeKeywordText.Length);
				}
				return null;
			}
			return new XTextElementList(Element);
		}

		/// <summary>
		///       返回表示对象数据的字符串
		///       </summary>
		/// <returns>字符串</returns>
		public override string ToString()
		{
			int num = 5;
			if (Element == null)
			{
				return Message;
			}
			return Element.ID + ":" + Message;
		}

		internal void Clear()
		{
			_Element = null;
			_ExcludeKeywordText = null;
			_Message = null;
		}
	}
}
