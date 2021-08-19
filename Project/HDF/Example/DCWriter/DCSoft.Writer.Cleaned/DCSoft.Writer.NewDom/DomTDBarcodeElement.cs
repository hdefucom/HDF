using DCSoft.Drawing;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.NewDom
{
	/// <summary>
	///       二维条码元素
	///       </summary>
	[ComVisible(false)]
	public class DomTDBarcodeElement : DomObjectElement
	{
		private VerticalAlignStyle _VAlign = VerticalAlignStyle.Bottom;

		private float _Width = 0f;

		private float _Height = 0f;

		private XDataBinding _ValueBinding = null;

		private DCTDBarcodeType _BarcodeType = DCTDBarcodeType.QR;

		private DCTBErroeCorrectionLevelType _ErroeCorrectionLevel = DCTBErroeCorrectionLevelType.M;

		private string _Text = null;

		/// <summary>
		///       垂直对齐方式
		///       </summary>
		[XmlAttribute]
		[DefaultValue(VerticalAlignStyle.Bottom)]
		public VerticalAlignStyle VAlign
		{
			get
			{
				return _VAlign;
			}
			set
			{
				_VAlign = value;
			}
		}

		/// <summary>
		///       对象宽度
		///       </summary>
		[XmlAttribute]
		[DefaultValue(0)]
		public override float Width
		{
			get
			{
				return _Width;
			}
			set
			{
				_Width = value;
			}
		}

		[XmlAttribute]
		[DefaultValue(0f)]
		public override float Height
		{
			get
			{
				return _Height;
			}
			set
			{
				_Height = value;
			}
		}

		/// <summary>
		///       内容绑定对象
		///       </summary>
		[DefaultValue(null)]
		[XmlElement]
		public XDataBinding ValueBinding
		{
			get
			{
				return _ValueBinding;
			}
			set
			{
				_ValueBinding = value;
			}
		}

		/// <summary>
		///       条码类型
		///       </summary>
		[XmlAttribute]
		[DefaultValue(DCTDBarcodeType.QR)]
		public DCTDBarcodeType BarcodeType
		{
			get
			{
				return _BarcodeType;
			}
			set
			{
				_BarcodeType = value;
			}
		}

		/// <summary>
		///       数据校验等级
		///       </summary>
		[XmlAttribute]
		[DefaultValue(DCTBErroeCorrectionLevelType.M)]
		public DCTBErroeCorrectionLevelType ErroeCorrectionLevel
		{
			get
			{
				return _ErroeCorrectionLevel;
			}
			set
			{
				_ErroeCorrectionLevel = value;
			}
		}

		/// <summary>
		///       文本值
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
