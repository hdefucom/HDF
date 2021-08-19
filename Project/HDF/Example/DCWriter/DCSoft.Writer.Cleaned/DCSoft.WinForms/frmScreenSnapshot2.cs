using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.WinForms
{
	/// <summary>
	///       快捷截屏窗口
	///       </summary>
	[ComVisible(false)]
	public class frmScreenSnapshot2 : Form
	{
		private class Class4
		{
			public int int_0 = 0;

			public int int_1 = 0;
		}

		private Bitmap bitmap_0 = null;

		private Class4 class4_0 = null;

		private Class4 class4_1 = null;

		private Rectangle rectangle_0 = Rectangle.Empty;

		private IContainer icontainer_0 = null;

		private ToolStrip myToolStrip;

		private ToolStripButton btnOK;

		private ToolStripButton btnCancel;

		private ToolStripButton btnReselect;

		/// <summary>
		///       用户截取的位图图像
		///       </summary>
		public Bitmap BmpConent => bitmap_0;

		/// <summary>
		///       初始化对象
		///       </summary>
		public frmScreenSnapshot2()
		{
			InitializeComponent();
			myToolStrip.Visible = false;
			base.DialogResult = DialogResult.Cancel;
			base.FormBorderStyle = FormBorderStyle.None;
			base.ControlBox = false;
			Rectangle rectangle = base.Bounds = Screen.PrimaryScreen.Bounds;
			Bitmap bitmap = new Bitmap(rectangle.Width, rectangle.Height);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.CopyFromScreen(0, 0, 0, 0, rectangle.Size);
			}
			BackgroundImage = bitmap;
		}

		private void frmScreenSnapshot2_Load(object sender, EventArgs e)
		{
			Activate();
		}

		protected override void OnKeyDown(KeyEventArgs kevent)
		{
			base.OnKeyDown(kevent);
			if (kevent.KeyCode == Keys.Escape)
			{
				Close();
			}
		}

		/// <summary>
		///       鼠标按键按下事件处理
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnMouseDown(MouseEventArgs mevent)
		{
			base.OnMouseDown(mevent);
			if (mevent.Button == MouseButtons.Left)
			{
				myToolStrip.Visible = false;
				Update();
				using (GClass249 gClass = GClass249.smethod_0(base.Handle))
				{
					gClass.method_23(Color.White);
					if (!rectangle_0.IsEmpty)
					{
						gClass.DrawRectangle(rectangle_0);
					}
					if (class4_1 != null)
					{
						gClass.method_11(0, class4_1.int_1, base.ClientSize.Width, class4_1.int_1);
						gClass.method_11(class4_1.int_0, 0, class4_1.int_0, base.ClientSize.Height);
					}
				}
				class4_0 = new Class4();
				class4_0.int_0 = mevent.X;
				class4_0.int_1 = mevent.Y;
			}
		}

		/// <summary>
		///       鼠标移动事件处理
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnMouseMove(MouseEventArgs mevent)
		{
			using (GClass249 gClass = GClass249.smethod_0(base.Handle))
			{
				gClass.method_23(Color.White);
				if (class4_0 == null)
				{
					if (class4_1 != null)
					{
						gClass.method_11(0, class4_1.int_1, base.ClientSize.Width, class4_1.int_1);
						gClass.method_11(class4_1.int_0, 0, class4_1.int_0, base.ClientSize.Height);
					}
					class4_1 = new Class4();
					class4_1.int_0 = mevent.X;
					class4_1.int_1 = mevent.Y;
					gClass.method_11(0, class4_1.int_1, base.ClientSize.Width, class4_1.int_1);
					gClass.method_11(class4_1.int_0, 0, class4_1.int_0, base.ClientSize.Height);
				}
				else
				{
					Rectangle rectangle = method_0(class4_0.int_0, class4_0.int_1, mevent.X, mevent.Y);
					gClass.DrawRectangle(rectangle);
					if (class4_1 != null)
					{
						rectangle = method_0(class4_0.int_0, class4_0.int_1, class4_1.int_0, class4_1.int_1);
						gClass.DrawRectangle(rectangle);
					}
					class4_1 = new Class4();
					class4_1.int_0 = mevent.X;
					class4_1.int_1 = mevent.Y;
				}
			}
			base.OnMouseMove(mevent);
		}

		/// <summary>
		///       鼠标按键松开事件
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnMouseUp(MouseEventArgs mevent)
		{
			if (class4_1 != null && class4_0 != null)
			{
				class4_1 = null;
				Rectangle b = method_0(class4_0.int_0, class4_0.int_1, mevent.X, mevent.Y);
				b = Rectangle.Intersect(new Rectangle(0, 0, base.Width, base.Height), b);
				class4_0 = null;
				if (b.Width > 2 || b.Height > 2)
				{
					rectangle_0 = b;
					b = new Rectangle(rectangle_0.Left, rectangle_0.Top - myToolStrip.Height, myToolStrip.Width, myToolStrip.Height);
					if (b.Right > base.Width)
					{
						b.X = base.Width - b.Width;
					}
					if (b.Top < 0)
					{
						b.Y = 0;
					}
					myToolStrip.Location = b.Location;
					myToolStrip.Visible = true;
				}
			}
			base.OnMouseUp(mevent);
		}

		/// <summary>
		///       鼠标离开窗口事件处理
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnMouseLeave(EventArgs eventArgs_0)
		{
			if (class4_1 != null)
			{
				using (GClass249 gClass = GClass249.smethod_0(base.Handle))
				{
					gClass.method_23(Color.White);
					gClass.method_11(0, class4_1.int_1, base.ClientSize.Width, class4_1.int_1);
					gClass.method_11(class4_1.int_0, 0, class4_1.int_0, base.ClientSize.Height);
				}
				class4_1 = null;
			}
			base.OnMouseLeave(eventArgs_0);
		}

		/// <summary>
		///       鼠标点击事件处理
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnMouseClick(MouseEventArgs mouseEventArgs_0)
		{
			base.OnMouseClick(mouseEventArgs_0);
			if (mouseEventArgs_0.Clicks == 2 && mouseEventArgs_0.Button == MouseButtons.Left && rectangle_0.Width > 0 && rectangle_0.Height > 0 && rectangle_0.Contains(mouseEventArgs_0.X, mouseEventArgs_0.Y))
			{
				btnOK_Click(null, null);
			}
			if (mouseEventArgs_0.Button == MouseButtons.Right)
			{
				Close();
			}
		}

		protected override void OnDoubleClick(EventArgs eventArgs_0)
		{
			base.OnDoubleClick(eventArgs_0);
			Point mousePosition = Control.MousePosition;
			mousePosition = PointToClient(mousePosition);
			if (!rectangle_0.IsEmpty && rectangle_0.Contains(mousePosition))
			{
				btnOK_Click(null, null);
			}
		}

		private Rectangle method_0(int int_0, int int_1, int int_2, int int_3)
		{
			Rectangle empty = Rectangle.Empty;
			empty.X = Math.Min(int_0, int_2);
			empty.Y = Math.Min(int_1, int_3);
			empty.Width = Math.Max(int_0, int_2) - empty.Left;
			empty.Height = Math.Max(int_1, int_3) - empty.Top;
			return empty;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (rectangle_0.Width > 0 && rectangle_0.Height > 0)
			{
				Bitmap image = new Bitmap(rectangle_0.Width, rectangle_0.Height);
				using (Graphics graphics = Graphics.FromImage(image))
				{
					graphics.DrawImage(BackgroundImage, new Rectangle(0, 0, rectangle_0.Width, rectangle_0.Height), rectangle_0, GraphicsUnit.Pixel);
				}
				bitmap_0 = image;
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}

		/// <summary>
		///       取消操作按钮事件
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="e">
		/// </param>
		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		///       重新选取按钮事件
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="e">
		/// </param>
		private void btnReselect_Click(object sender, EventArgs e)
		{
			rectangle_0 = Rectangle.Empty;
			myToolStrip.Visible = false;
			class4_1 = null;
			class4_0 = null;
			Refresh();
		}

		/// <summary>
		///       清理所有正在使用的资源。
		///       </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		///       设计器支持所需的方法 - 不要
		///       使用代码编辑器修改此方法的内容。
		///       </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.WinForms.frmScreenSnapshot2));
			myToolStrip = new System.Windows.Forms.ToolStrip();
			btnOK = new System.Windows.Forms.ToolStripButton();
			btnCancel = new System.Windows.Forms.ToolStripButton();
			btnReselect = new System.Windows.Forms.ToolStripButton();
			myToolStrip.SuspendLayout();
			SuspendLayout();
			myToolStrip.AccessibleDescription = null;
			myToolStrip.AccessibleName = null;
			resources.ApplyResources(myToolStrip, "myToolStrip");
			myToolStrip.BackgroundImage = null;
			myToolStrip.Font = null;
			myToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			myToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[3]
			{
				btnOK,
				btnCancel,
				btnReselect
			});
			myToolStrip.Name = "myToolStrip";
			myToolStrip.ShowItemToolTips = false;
			btnOK.AccessibleDescription = null;
			btnOK.AccessibleName = null;
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.BackgroundImage = null;
			btnOK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			btnOK.Name = "btnOK";
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.AccessibleDescription = null;
			btnCancel.AccessibleName = null;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.BackgroundImage = null;
			btnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			btnCancel.Name = "btnCancel";
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			btnReselect.AccessibleDescription = null;
			btnReselect.AccessibleName = null;
			resources.ApplyResources(btnReselect, "btnReselect");
			btnReselect.BackgroundImage = null;
			btnReselect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			btnReselect.Name = "btnReselect";
			btnReselect.Click += new System.EventHandler(btnReselect_Click);
			base.AccessibleDescription = null;
			base.AccessibleName = null;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackgroundImage = null;
			base.Controls.Add(myToolStrip);
			Font = null;
			base.Icon = null;
			base.Name = "frmScreenSnapshot2";
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(frmScreenSnapshot2_Load);
			myToolStrip.ResumeLayout(false);
			myToolStrip.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
