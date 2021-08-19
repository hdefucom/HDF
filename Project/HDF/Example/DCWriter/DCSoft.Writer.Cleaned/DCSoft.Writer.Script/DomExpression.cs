using DCSoft.Common;
using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Script
{
	/// <summary>
	///       表达式对象
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[DocumentComment]
	[ComVisible(false)]
	public class DomExpression
	{
		private string _Name = null;

		private string _Expression = null;

		private bool _ReferencedElementsRefreshed = false;

		[NonSerialized]
		private XTextElementList _ReferencedElements = null;

		private DomExpressionType _Type = DomExpressionType.Simple;

		/// <summary>
		///       对象名称
		///       </summary>
		[DefaultValue(null)]
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name = value;
			}
		}

		/// <summary>
		///       表达式文本
		///       </summary>
		[DefaultValue(null)]
		public string Expression
		{
			get
			{
				return _Expression;
			}
			set
			{
				_Expression = value;
				_ReferencedElements = null;
				_ReferencedElementsRefreshed = false;
			}
		}

		internal bool ReferencedElementsRefreshed
		{
			get
			{
				return _ReferencedElementsRefreshed;
			}
			set
			{
				_ReferencedElementsRefreshed = value;
			}
		}

		/// <summary>
		///       表达式中引用的文档元素对象
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public XTextElementList ReferencedElements
		{
			get
			{
				return _ReferencedElements;
			}
			set
			{
				_ReferencedElements = value;
			}
		}

		/// <summary>
		///       简单的表达式格式
		///       </summary>
		[DefaultValue(DomExpressionType.Simple)]
		public DomExpressionType Type
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
	}
}
