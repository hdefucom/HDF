using DCSoft.Common;
using DCSoft.Drawing;
using DCSoftDotfuscate;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       时间轴贴图对象
	///       </summary>
	[DocumentComment]
	public class DCTimeLineImage
	{
		private string _Name = null;

		private float _Left = 0f;

		private float _Top = 0f;

		private XImageValue _Image = null;

		/// <summary>
		///       名称
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
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
		///       左端位置,采用Document为单位
		///       </summary>
		[DefaultValue(0f)]
		[XmlAttribute]
		public float Left
		{
			get
			{
				return _Left;
			}
			set
			{
				_Left = value;
			}
		}

		/// <summary>
		///       顶端位置,采用Document为单位
		///       </summary>
		[XmlAttribute]
		[DefaultValue(0f)]
		public float Top
		{
			get
			{
				return _Top;
			}
			set
			{
				_Top = value;
			}
		}

		/// <summary>
		///       图片像素宽度
		///       </summary>
		public int ImagePixelWidth
		{
			get
			{
				if (_Image == null)
				{
					return 0;
				}
				return _Image.Width;
			}
		}

		/// <summary>
		///       图片像素高度
		///       </summary>
		public int ImagePixelHeight
		{
			get
			{
				if (_Image == null)
				{
					return 0;
				}
				return _Image.Height;
			}
		}

		/// <summary>
		///       图片对象
		///       </summary>
		[DefaultValue(null)]
		[Browsable(true)]
		[ComVisible(false)]
		[Editor(typeof(GClass148), typeof(UITypeEditor))]
		public XImageValue Image
		{
			get
			{
				return _Image;
			}
			set
			{
				_Image = value;
			}
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public DCTimeLineImage Clone()
		{
			DCTimeLineImage dCTimeLineImage = (DCTimeLineImage)MemberwiseClone();
			if (_Image != null)
			{
				dCTimeLineImage._Image = _Image.Clone();
			}
			return dCTimeLineImage;
		}

		/// <summary>
		///       返回表示数据的字符串
		///       </summary>
		/// <returns>
		/// </returns>
		public override string ToString()
		{
			return Name + " " + GetType().Name;
		}
	}
}
