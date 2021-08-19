using DCSoft.Common;
using DCSoft.Drawing;
using DCSoftDotfuscate;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       产程图贴图对象
	///       </summary>
	[DocumentComment]
	public class DCFriedmanCurveImage
	{
		private string _Name = null;

		private float _Left = 0f;

		private float _Top = 0f;

		private XImageValue _Image = null;

		/// <summary>
		///       名称
		///       </summary>
		[XmlAttribute]
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
		[Editor(typeof(GClass151), typeof(UITypeEditor))]
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
		public DCFriedmanCurveImage Clone()
		{
			DCFriedmanCurveImage dCFriedmanCurveImage = (DCFriedmanCurveImage)MemberwiseClone();
			if (_Image != null)
			{
				dCFriedmanCurveImage._Image = _Image.Clone();
			}
			return dCFriedmanCurveImage;
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
