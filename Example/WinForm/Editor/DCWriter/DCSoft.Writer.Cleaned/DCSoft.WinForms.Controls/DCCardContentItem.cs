using DCSoft.Common;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.WinForms.Controls
{
	/// <summary>
	///       卡片内容项目
	///       </summary>
	/// <remarks>袁永福到此一游</remarks>
	[ComVisible(false)]
	
	public class DCCardContentItem
	{
		private string _DataField = null;

		private int _Left = 0;

		private int _Top = 0;

		private int _Width = 0;

		private int _Height = 0;

		/// <summary>
		///       绑定的数据源的字段名
		///       </summary>
		[XmlAttribute]
		[DefaultValue(null)]
		public string DataField
		{
			get
			{
				return _DataField;
			}
			set
			{
				_DataField = value;
			}
		}

		/// <summary>
		///       左端位置
		///       </summary>
		[DefaultValue(0)]
		[XmlAttribute]
		public int Left
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
		///       顶端位置
		///       </summary>
		[XmlAttribute]
		[DefaultValue(0)]
		public int Top
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
		///       宽度
		///       </summary>
		[DefaultValue(0)]
		[XmlAttribute]
		public int Width
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

		/// <summary>
		///       高度
		///       </summary>
		[XmlAttribute]
		[DefaultValue(0)]
		public int Height
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
		///       绘制对象
		///       </summary>
		/// <param name="args">参数</param>
		public virtual void OnPaint(DCCardContentItemPaintEventArgs args)
		{
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public virtual DCCardContentItem Clone()
		{
			return (DCCardContentItem)MemberwiseClone();
		}
	}
}
