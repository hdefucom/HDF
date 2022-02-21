using DCSoft.Common;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>
	///       矩形区域对象
	///       </summary>
	[Guid("DDB4624F-CD9D-4D80-9A56-F7E019A272AC")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IRectangleClass))]
	[DocumentComment]
	
	public class RectangleClass : IRectangleClass
	{
		private int _Left = 0;

		private int _Top = 0;

		private int _Width = 0;

		private int _Height = 0;

		/// <summary>
		///       左端位置
		///       </summary>
		[DefaultValue(0)]
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
		///       判断对象是否为空
		///       </summary>
		public bool IsEmpty => _Left == 0 && _Top == 0 && _Width == 0 && _Height == 0;

		/// <summary>
		///       设置或获得标准矩形对象
		///       </summary>
		[ComVisible(false)]
		[Browsable(false)]
		public Rectangle StdRectangle
		{
			get
			{
				return new Rectangle(_Left, _Top, _Width, _Height);
			}
			set
			{
				_Left = value.Left;
				_Top = value.Top;
				_Width = value.Width;
				_Height = value.Height;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public RectangleClass()
		{
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="rect">
		/// </param>
		public RectangleClass(Rectangle rect)
		{
			_Left = rect.Left;
			_Top = rect.Top;
			_Width = rect.Width;
			_Height = rect.Height;
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="left">
		/// </param>
		/// <param name="top">
		/// </param>
		/// <param name="width">
		/// </param>
		/// <param name="height">
		/// </param>
		public RectangleClass(int left, int int_0, int width, int height)
		{
			_Left = left;
			_Top = int_0;
			_Width = width;
			_Height = height;
		}
	}
}
