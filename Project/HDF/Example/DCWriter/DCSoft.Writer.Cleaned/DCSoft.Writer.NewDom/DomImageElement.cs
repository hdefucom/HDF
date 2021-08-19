using DCSoft.Drawing;
using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.NewDom
{
	/// <summary>
	///       图片元素
	///       </summary>
	[ComVisible(false)]
	public class DomImageElement : DomObjectElement
	{
		private bool _EnableEditImageAdditionShape = true;

		private bool _EnableRepeatedImage = false;

		private int _ValueIndexOfRepeatedImage = -1;

		private VerticalAlignStyle _VAlign = VerticalAlignStyle.Bottom;

		private string _Alt = null;

		private bool _KeepWidthHeightRate = true;

		private string _Source = null;

		private bool _SaveContentInFile = true;

		private string _AdditionShapeContent = null;

		private bool _AdditionShapeFixSize = false;

		private bool _CompressSaveMode = true;

		private byte[] _ImageData = null;

		private PageImageInfoList _PageImages = null;

		private bool _SmoothZoom = true;

		/// <summary>
		///       允许用户编辑图片上的附加图形
		///       </summary>
		[XmlAttribute]
		[DefaultValue(true)]
		public bool EnableEditImageAdditionShape
		{
			get
			{
				return _EnableEditImageAdditionShape;
			}
			set
			{
				_EnableEditImageAdditionShape = value;
			}
		}

		/// <summary>
		///       是否启用合并图片数据
		///       </summary>
		[XmlAttribute]
		[DefaultValue(false)]
		public bool EnableRepeatedImage
		{
			get
			{
				return _EnableRepeatedImage;
			}
			set
			{
				_EnableRepeatedImage = value;
			}
		}

		/// <summary>
		///       重复引用的图片数据的数据编号,DCWriter内部使用。
		///       </summary>
		[XmlAttribute]
		[DefaultValue(-1)]
		public int ValueIndexOfRepeatedImage
		{
			get
			{
				return _ValueIndexOfRepeatedImage;
			}
			set
			{
				if (_ValueIndexOfRepeatedImage != value)
				{
					_ValueIndexOfRepeatedImage = value;
				}
			}
		}

		/// <summary>
		///       垂直对齐方式
		///       </summary>
		[DefaultValue(VerticalAlignStyle.Bottom)]
		[XmlAttribute]
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
		///       缺少图片数据时显示的文本
		///       </summary>
		[XmlAttribute]
		[DefaultValue(null)]
		public string Alt
		{
			get
			{
				return _Alt;
			}
			set
			{
				_Alt = value;
			}
		}

		/// <summary>
		///       保持宽度、高度比例。若本属性值为true，
		///       则用户鼠标拖拽改变图片大小时会保持图片的宽度高度比例，
		///       否则用户可以随意改变图片的宽度和高度。
		///       </summary>
		[XmlAttribute]
		[DefaultValue(true)]
		public bool KeepWidthHeightRate
		{
			get
			{
				return _KeepWidthHeightRate;
			}
			set
			{
				_KeepWidthHeightRate = value;
			}
		}

		/// <summary>
		///       图片来源
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
		public string Source
		{
			get
			{
				return _Source;
			}
			set
			{
				_Source = value;
			}
		}

		/// <summary>
		///       保存图片数据到文件中
		///       </summary>
		[XmlAttribute]
		[DefaultValue(true)]
		public bool SaveContentInFile
		{
			get
			{
				return _SaveContentInFile;
			}
			set
			{
				_SaveContentInFile = value;
			}
		}

		/// <summary>
		///       扩展图形数据
		///       </summary>
		[XmlElement]
		[DefaultValue(null)]
		public string AdditionShapeContent
		{
			get
			{
				return _AdditionShapeContent;
			}
			set
			{
				_AdditionShapeContent = value;
			}
		}

		/// <summary>
		///       额外的图形数据采用固定大小
		///       </summary>
		[DefaultValue(false)]
		[XmlAttribute]
		public bool AdditionShapeFixSize
		{
			get
			{
				return _AdditionShapeFixSize;
			}
			set
			{
				_AdditionShapeFixSize = value;
			}
		}

		/// <summary>
		///       压缩保存模式,以实际大小来设置保存的数据，这会导致大图片数据的损失。
		///       </summary>
		[XmlAttribute]
		[DefaultValue(true)]
		public bool CompressSaveMode
		{
			get
			{
				return _CompressSaveMode;
			}
			set
			{
				_CompressSaveMode = value;
			}
		}

		[DefaultValue(null)]
		[XmlElement(DataType = "base64Binary")]
		public byte[] ImageData
		{
			get
			{
				return _ImageData;
			}
			set
			{
				_ImageData = value;
			}
		}

		[XmlArrayItem("Image", typeof(PageImageInfo))]
		[DefaultValue(null)]
		public PageImageInfoList PageImages
		{
			get
			{
				return _PageImages;
			}
			set
			{
				_PageImages = value;
			}
		}

		/// <summary>
		///       平滑缩放图像
		///       </summary>
		[DefaultValue(true)]
		[XmlAttribute]
		public bool SmoothZoom
		{
			get
			{
				return _SmoothZoom;
			}
			set
			{
				_SmoothZoom = value;
			}
		}
	}
}
