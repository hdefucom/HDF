using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.NewDom
{
	/// <summary>
	///       水平线元素
	///       </summary>
	[ComVisible(false)]
	public class DomHorizontalLineElement : DomObjectElement
	{
		private float _LineLengthInCM = 0f;

		private float _LineSize = 1f;

		/// <summary>
		///       以厘米单位计算的线条长度，如果为0则填充整页宽度.
		///       </summary>
		[DefaultValue(0f)]
		[XmlAttribute]
		public float LineLengthInCM
		{
			get
			{
				return _LineLengthInCM;
			}
			set
			{
				_LineLengthInCM = value;
			}
		}

		/// <summary>
		///       线条高度
		///       </summary>
		[DefaultValue(1f)]
		[XmlAttribute]
		public float LineSize
		{
			get
			{
				return _LineSize;
			}
			set
			{
				_LineSize = value;
			}
		}

		/// <summary>
		///       高度
		///       </summary>
		[DefaultValue(20f)]
		[XmlElement]
		public override float Height
		{
			get
			{
				return base.Height;
			}
			set
			{
				base.Height = value;
			}
		}

		public DomHorizontalLineElement()
		{
			Height = 20f;
		}
	}
}
