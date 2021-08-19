using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.WinForms.Design
{
	/// <summary>
	///       工具箱项目对象
	///       </summary>
	[DocumentComment]
	[ComVisible(false)]
	public class DCToolBoxItem
	{
		private string _Name = null;

		private string _Text = null;

		private Image _Image = null;

		private int _ImageIndex = -1;

		private string _ImageKey = null;

		private string _TextValue = null;

		private string _DataFormat = null;

		private object _Value = null;

		[NonSerialized]
		private Rectangle _Bounds = Rectangle.Empty;

		/// <summary>
		///       名称
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
		///       文本值
		///       </summary>
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

		[DefaultValue(null)]
		public Image Image
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

		[DefaultValue(-1)]
		public int ImageIndex
		{
			get
			{
				return _ImageIndex;
			}
			set
			{
				_ImageIndex = value;
			}
		}

		[DefaultValue(null)]
		public string ImageKey
		{
			get
			{
				return _ImageKey;
			}
			set
			{
				_ImageKey = value;
			}
		}

		/// <summary>
		///       文本数值
		///       </summary>
		[DefaultValue(null)]
		[Category("Data")]
		public string TextValue
		{
			get
			{
				return _TextValue;
			}
			set
			{
				_TextValue = value;
			}
		}

		/// <summary>
		///       数据格式
		///       </summary>
		[DefaultValue(null)]
		[Category("Data")]
		public string DataFormat
		{
			get
			{
				return _DataFormat;
			}
			set
			{
				_DataFormat = value;
			}
		}

		/// <summary>
		///       对象数值
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(null)]
		public object Value
		{
			get
			{
				return _Value;
			}
			set
			{
				_Value = value;
			}
		}

		/// <summary>
		///       对象在视图中的边界
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(null)]
		[Browsable(false)]
		internal Rectangle Bounds
		{
			get
			{
				return _Bounds;
			}
			set
			{
				_Bounds = value;
			}
		}
	}
}
