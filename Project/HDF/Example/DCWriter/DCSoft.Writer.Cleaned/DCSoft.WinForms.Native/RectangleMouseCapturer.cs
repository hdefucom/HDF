using DCSoftDotfuscate;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.WinForms.Native
{
	/// <summary>
	///       绘制矩形的鼠标拖拽对象
	///       </summary>
	/// <remarks>编写 袁永福</remarks>
	[ComVisible(false)]
	public class RectangleMouseCapturer : MouseCapturer
	{
		protected int int_0 = 0;

		protected Rectangle rectangle_1 = Rectangle.Empty;

		protected Rectangle rectangle_2 = Rectangle.Empty;

		protected bool bool_1 = false;

		/// <summary>
		///       拖拽类型
		///       </summary>
		public int DragStyle
		{
			get
			{
				return int_0;
			}
			set
			{
				int_0 = value;
			}
		}

		/// <summary>
		///       原始矩形
		///       </summary>
		public Rectangle SourceRectangle
		{
			get
			{
				return rectangle_1;
			}
			set
			{
				rectangle_1 = value;
			}
		}

		/// <summary>
		///       处理后的矩形
		///       </summary>
		public Rectangle DescRectangle
		{
			get
			{
				return rectangle_2;
			}
			set
			{
				rectangle_2 = value;
			}
		}

		/// <summary>
		///       自定义动作样式
		///       </summary>
		public bool CustomAction
		{
			get
			{
				return bool_1;
			}
			set
			{
				bool_1 = value;
			}
		}

		/// <summary>
		///       当前拖拽的矩形区域
		///       </summary>
		public Rectangle CurrentRectangle => MouseCapturer.smethod_3(base.StartPosition, base.CurrentPosition);

		/// <summary>
		///       初始化对象
		///       </summary>
		public RectangleMouseCapturer()
		{
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">进行鼠标拖拽的控件对象</param>
		public RectangleMouseCapturer(Control control_1)
		{
			control_0 = control_1;
		}

		public Rectangle method_5(Rectangle rectangle_3, int int_1, int int_2)
		{
			if (int_0 == -1)
			{
				rectangle_3.Offset(int_1, int_2);
			}
			if (int_0 == 0 || int_0 == 7 || int_0 == 6)
			{
				rectangle_3.Offset(int_1, 0);
				rectangle_3.Width -= int_1;
			}
			if (int_0 == 0 || int_0 == 1 || int_0 == 2)
			{
				rectangle_3.Offset(0, int_2);
				rectangle_3.Height -= int_2;
			}
			if (int_0 == 2 || int_0 == 3 || int_0 == 4)
			{
				rectangle_3.Width += int_1;
			}
			if (int_0 == 4 || int_0 == 5 || int_0 == 6)
			{
				rectangle_3.Height += int_2;
			}
			return rectangle_3;
		}

		protected override void vmethod_2(bool bool_2)
		{
			base.vmethod_2(bool_2);
			if (!bool_1)
			{
				GClass249 gClass = null;
				gClass = ((control_0 == null) ? GClass249.smethod_2() : GClass249.smethod_0(control_0.Handle));
				gClass.DrawRectangle(rectangle_2);
				gClass.Dispose();
			}
		}

		protected override void vmethod_1()
		{
			base.vmethod_1();
			if (!bool_1)
			{
				int int_ = base.CurrentPosition.X - base.StartPosition.X;
				int int_2 = base.CurrentPosition.Y - base.StartPosition.Y;
				rectangle_2 = method_5(rectangle_1, int_, int_2);
			}
		}
	}
}
