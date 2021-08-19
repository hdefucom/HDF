using System;
using System.ComponentModel;
using System.Drawing;
using System.Xml.Serialization;

namespace DCSoft.Drawing
{
	/// <summary>
	///       绘制字符串的格式化信息对象。是System.Drawing.StringFormat的一个封装.
	///       </summary>
	[Serializable]
	public class DrawStringFormatExt : IDisposable
	{
		private enum StringFormatType
		{
			Normal,
			GenericDefault,
			GenericTypographic
		}

		private static DrawStringFormatExt _GenericDefault = null;

		private static DrawStringFormatExt _GenericTypographic = null;

		/// <summary>
		///       内容只读
		///       </summary>
		private bool _Readonly = false;

		private StringFormatType _FormatType = StringFormatType.Normal;

		private bool _FormatModified = false;

		[NonSerialized]
		private StringFormat _Value = null;

		private Color _Color = Color.Black;

		private XFontValue _Font = null;

		private StringAlignment _Alignment = StringAlignment.Near;

		private StringAlignment _LineAlignment = StringAlignment.Near;

		private StringFormatFlags _FormatFlags = StringFormatFlags.NoWrap;

		private StringTrimming _Trimming = StringTrimming.None;

		private float _Left = 0f;

		private float _Top = 0f;

		private float _Width = 0f;

		private float _Height = 0f;

		/// <summary>
		///       通用格式对象
		///       </summary>
		public static DrawStringFormatExt GenericDefault
		{
			get
			{
				if (_GenericDefault == null)
				{
					_GenericDefault = new DrawStringFormatExt();
					_GenericDefault.SetStringFormatAsGenericDefault();
					_GenericDefault._Readonly = true;
				}
				return _GenericDefault;
			}
		}

		/// <summary>
		///       通用格式对象
		///       </summary>
		public static DrawStringFormatExt GenericTypographic
		{
			get
			{
				if (_GenericTypographic == null)
				{
					_GenericTypographic = new DrawStringFormatExt();
					_GenericTypographic.SetStringFormatAsGenericTypographic();
					_GenericTypographic._Readonly = true;
				}
				return _GenericTypographic;
			}
		}

		/// <summary>
		///       内部的对象值
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public StringFormat Value
		{
			get
			{
				if (!_FormatModified)
				{
					if (_FormatType == StringFormatType.GenericDefault)
					{
						return StringFormat.GenericDefault;
					}
					if (_FormatType == StringFormatType.GenericTypographic)
					{
						return StringFormat.GenericTypographic;
					}
				}
				if (_Value == null)
				{
					_Value = CreateStringFormat();
				}
				return _Value;
			}
		}

		/// <summary>
		///       文本颜色
		///       </summary>
		[DefaultValue(typeof(Color), "Black")]
		public Color Color
		{
			get
			{
				return _Color;
			}
			set
			{
				if (!_Readonly)
				{
					_Color = value;
				}
			}
		}

		/// <summary>
		///       字体设置
		///       </summary>
		[DefaultValue(null)]
		[XmlElement]
		public XFontValue Font
		{
			get
			{
				return _Font;
			}
			set
			{
				if (!_Readonly)
				{
					_Font = value;
				}
			}
		}

		/// <summary>
		///       水平对齐方式
		///       </summary>
		[DefaultValue(StringAlignment.Near)]
		[XmlAttribute]
		public StringAlignment Alignment
		{
			get
			{
				return _Alignment;
			}
			set
			{
				if (!_Readonly)
				{
					_Alignment = value;
					SetFormatModified();
				}
			}
		}

		/// <summary>
		///       垂直对齐方式
		///       </summary>
		[XmlAttribute]
		[DefaultValue(StringAlignment.Near)]
		public StringAlignment LineAlignment
		{
			get
			{
				return _LineAlignment;
			}
			set
			{
				if (!_Readonly)
				{
					_LineAlignment = value;
					SetFormatModified();
				}
			}
		}

		/// <summary>
		///       格式化标记
		///       </summary>
		[DefaultValue(StringFormatFlags.NoWrap)]
		[XmlAttribute]
		public StringFormatFlags FormatFlags
		{
			get
			{
				return _FormatFlags;
			}
			set
			{
				if (!_Readonly)
				{
					_FormatFlags = value;
					SetFormatModified();
				}
			}
		}

		/// <summary>
		///       设置字符修整模式
		///       </summary>
		[DefaultValue(StringTrimming.None)]
		[XmlAttribute]
		public StringTrimming Trimming
		{
			get
			{
				return _Trimming;
			}
			set
			{
				if (!_Readonly)
				{
					_Trimming = value;
					SetFormatModified();
				}
			}
		}

		/// <summary>
		///       文本布局矩形位置
		///       </summary>
		public float Left
		{
			get
			{
				return _Left;
			}
			set
			{
				if (!_Readonly)
				{
					_Left = value;
				}
			}
		}

		/// <summary>
		///       文本布局矩形位置
		///       </summary>
		public float Top
		{
			get
			{
				return _Top;
			}
			set
			{
				if (!_Readonly)
				{
					_Top = value;
				}
			}
		}

		/// <summary>
		///       文本布局矩形位置
		///       </summary>
		public float Width
		{
			get
			{
				return _Width;
			}
			set
			{
				if (!_Readonly)
				{
					_Width = value;
				}
			}
		}

		/// <summary>
		///       文本布局矩形位置
		///       </summary>
		public float Height
		{
			get
			{
				return _Height;
			}
			set
			{
				if (!_Readonly)
				{
					_Height = value;
				}
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public DrawStringFormatExt(DrawStringFormatExt baseFormat)
		{
			if (baseFormat != null)
			{
				_Alignment = baseFormat._Alignment;
				_Color = baseFormat._Color;
				if (baseFormat._Font != null)
				{
					_Font = baseFormat._Font.Clone();
				}
				_FormatFlags = baseFormat._FormatFlags;
				_FormatModified = baseFormat._FormatModified;
				_FormatType = baseFormat._FormatType;
				_Height = baseFormat._Height;
				_Left = baseFormat._Left;
				_LineAlignment = baseFormat._LineAlignment;
				_Top = baseFormat._Top;
				_Trimming = baseFormat._Trimming;
				_Value = null;
				_Width = baseFormat._Width;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public DrawStringFormatExt()
		{
		}

		public DrawStringFormatExt Clone()
		{
			DrawStringFormatExt drawStringFormatExt = (DrawStringFormatExt)MemberwiseClone();
			if (Font != null)
			{
				drawStringFormatExt.Font = Font.Clone();
			}
			drawStringFormatExt._Value = null;
			drawStringFormatExt._Readonly = false;
			return drawStringFormatExt;
		}

		public void SetStringFormatAlignment(ContentAlignment alignment)
		{
			if (!_Readonly)
			{
				switch (alignment)
				{
				case ContentAlignment.MiddleCenter:
					Alignment = StringAlignment.Center;
					LineAlignment = StringAlignment.Center;
					break;
				case ContentAlignment.MiddleLeft:
					Alignment = StringAlignment.Near;
					LineAlignment = StringAlignment.Center;
					break;
				case ContentAlignment.TopLeft:
					Alignment = StringAlignment.Near;
					LineAlignment = StringAlignment.Near;
					break;
				case ContentAlignment.TopCenter:
					Alignment = StringAlignment.Center;
					LineAlignment = StringAlignment.Near;
					break;
				case ContentAlignment.TopRight:
					Alignment = StringAlignment.Far;
					LineAlignment = StringAlignment.Near;
					break;
				case ContentAlignment.BottomLeft:
					Alignment = StringAlignment.Near;
					LineAlignment = StringAlignment.Far;
					break;
				case ContentAlignment.MiddleRight:
					Alignment = StringAlignment.Far;
					LineAlignment = StringAlignment.Center;
					break;
				case ContentAlignment.BottomRight:
					Alignment = StringAlignment.Far;
					LineAlignment = StringAlignment.Far;
					break;
				case ContentAlignment.BottomCenter:
					Alignment = StringAlignment.Center;
					LineAlignment = StringAlignment.Far;
					break;
				}
			}
		}

		/// <summary>
		///       设置字符串格式为多行文本
		///       </summary>
		/// <param name="multiLine">是否多行文本</param>
		public void SetMultiLine(bool multiLine)
		{
			if (!_Readonly)
			{
				if (multiLine)
				{
					FormatFlags &= ~StringFormatFlags.NoWrap;
				}
				else
				{
					FormatFlags |= StringFormatFlags.NoWrap;
				}
			}
		}

		private void SetFormatModified()
		{
			if (_Value != null)
			{
				_Value.Dispose();
				_Value = null;
			}
			_FormatModified = true;
		}

		/// <summary>
		///       设置通用排版格式
		///       </summary>
		public void SetStringFormatAsGenericDefault()
		{
			SetStringFormat(StringFormat.GenericDefault);
			_FormatType = StringFormatType.GenericDefault;
			ClearValue();
			_FormatModified = false;
		}

		/// <summary>
		///       设置通用排版格式
		///       </summary>
		public void SetStringFormatAsGenericTypographic()
		{
			SetStringFormat(StringFormat.GenericTypographic);
			_FormatType = StringFormatType.GenericTypographic;
			ClearValue();
			_FormatModified = false;
		}

		/// <summary>
		///       创建字符串格式化对象
		///       </summary>
		/// <returns>
		/// </returns>
		public StringFormat CreateStringFormat()
		{
			StringFormat stringFormat = null;
			if (_FormatType == StringFormatType.GenericTypographic)
			{
				stringFormat = new StringFormat(StringFormat.GenericTypographic);
				if (!_FormatModified)
				{
					return stringFormat;
				}
			}
			else if (_FormatType == StringFormatType.GenericDefault)
			{
				stringFormat = new StringFormat(StringFormat.GenericDefault);
				if (!_FormatModified)
				{
					return stringFormat;
				}
			}
			else
			{
				stringFormat = new StringFormat();
			}
			stringFormat.Alignment = Alignment;
			stringFormat.LineAlignment = LineAlignment;
			stringFormat.FormatFlags = FormatFlags;
			stringFormat.Trimming = Trimming;
			return stringFormat;
		}

		/// <summary>
		///       设置格式化对象
		///       </summary>
		/// <param name="f">格式化对象</param>
		public void SetStringFormat(StringFormat stringFormat_0)
		{
			if (!_Readonly && stringFormat_0 != null)
			{
				_Alignment = stringFormat_0.Alignment;
				_LineAlignment = stringFormat_0.LineAlignment;
				_Trimming = stringFormat_0.Trimming;
				_FormatFlags = stringFormat_0.FormatFlags;
				SetFormatModified();
			}
		}

		public void SetBounds(RectangleF bounds)
		{
			if (!_Readonly)
			{
				_Left = bounds.Left;
				_Top = bounds.Top;
				_Width = bounds.Width;
				_Height = bounds.Height;
			}
		}

		public void SetBounds(float left, float float_0, float width, float height)
		{
			if (!_Readonly)
			{
				_Left = left;
				_Top = float_0;
				_Width = width;
				_Height = height;
			}
		}

		public void Dispose()
		{
			ClearValue();
		}

		private void ClearValue()
		{
			if (_Value != null)
			{
				_Value.Dispose();
				_Value = null;
			}
		}
	}
}
