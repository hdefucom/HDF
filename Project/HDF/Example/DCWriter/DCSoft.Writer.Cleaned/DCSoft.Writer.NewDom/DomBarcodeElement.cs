using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.NewDom
{
	/// <summary>
	///       一维条码元素
	///       </summary>
	[ComVisible(false)]
	public class DomBarcodeElement : DomObjectElement
	{
		private StringAlignment _Alignment = StringAlignment.Center;

		private DCBarcodeStyle _BarcodeStyle = DCBarcodeStyle.Code128A;

		private DCContentLockInfo _ContentLock = null;

		private ContentReadonlyState _ContentReadonly = ContentReadonlyState.Inherit;

		private float _MinBarWidth = 10f;

		private bool _ShowText = true;

		private string _Text = null;

		[XmlAttribute]
		[DefaultValue(StringAlignment.Center)]
		public StringAlignment Alignment
		{
			get
			{
				return _Alignment;
			}
			set
			{
				_Alignment = value;
			}
		}

		/// <summary>
		///       条码样式
		///       </summary>
		[XmlAttribute]
		[DefaultValue(DCBarcodeStyle.Code128A)]
		public DCBarcodeStyle BarcodeStyle
		{
			get
			{
				return _BarcodeStyle;
			}
			set
			{
				_BarcodeStyle = value;
			}
		}

		/// <summary>
		///       内容锁定状态
		///       </summary>
		[XmlElement]
		[DefaultValue(null)]
		public DCContentLockInfo ContentLock
		{
			get
			{
				return _ContentLock;
			}
			set
			{
				_ContentLock = value;
			}
		}

		/// <summary>
		///       内容只读状态
		///       </summary>
		[DefaultValue(ContentReadonlyState.Inherit)]
		[XmlElement]
		public ContentReadonlyState ContentReadonly
		{
			get
			{
				return _ContentReadonly;
			}
			set
			{
				_ContentReadonly = value;
			}
		}

		[DefaultValue(10f)]
		public float MinBarWidth
		{
			get
			{
				return _MinBarWidth;
			}
			set
			{
				_MinBarWidth = value;
			}
		}

		[DefaultValue(true)]
		public bool ShowText
		{
			get
			{
				return _ShowText;
			}
			set
			{
				_ShowText = value;
			}
		}

		/// <summary>
		///       对象文本值
		///       </summary>
		[XmlElement]
		[DefaultValue(null)]
		public string Text
		{
			get
			{
				return _Text;
			}
			set
			{
				_Text = value;
			}
		}
	}
}
