using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.WinForms
{
	public class dlgScreenSnapshot : Form
	{
		public struct CursorInfo
		{
			public int cbSize;

			public int flags;

			public IntPtr hCursor;

			public int int_0;

			public int int_1;
		}

		/// <summary>
		///       必需的设计器变量。
		///       </summary>
		private IContainer components = null;

		private Label label1;

		private ListBox lstArea;

		private Label label2;

		private NumericUpDown txtDelay;

		private Button cmdStart;

		private Button cmdClose;

		private Timer myTimer;

		private Label lblBounds;

		private Button cmdRefresh;

		private Label lblWait;

		private CheckBox chkCursor;

		private PictureBox picDesktop;

		private Bitmap myBmpContent = null;

		private string strDesktop = null;

		private string strBounds = null;

		private string strWait = null;

		private static Bitmap desktopBmp = null;

		private Rectangle mySnapshotBounds = Rectangle.Empty;

		private DateTime dtmEnd = DateTime.MinValue;

		/// <summary>
		///       截屏所得的位图数据
		///       </summary>
		public Bitmap BmpContent => myBmpContent;

		/// <summary>
		///       清理所有正在使用的资源。
		///       </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		///       设计器支持所需的方法 - 不要
		///       使用代码编辑器修改此方法的内容。
		///       </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.WinForms.dlgScreenSnapshot));
			label1 = new System.Windows.Forms.Label();
			lstArea = new System.Windows.Forms.ListBox();
			label2 = new System.Windows.Forms.Label();
			txtDelay = new System.Windows.Forms.NumericUpDown();
			cmdStart = new System.Windows.Forms.Button();
			cmdClose = new System.Windows.Forms.Button();
			myTimer = new System.Windows.Forms.Timer(components);
			lblBounds = new System.Windows.Forms.Label();
			cmdRefresh = new System.Windows.Forms.Button();
			lblWait = new System.Windows.Forms.Label();
			chkCursor = new System.Windows.Forms.CheckBox();
			picDesktop = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)txtDelay).BeginInit();
			((System.ComponentModel.ISupportInitialize)picDesktop).BeginInit();
			SuspendLayout();
			label1.AccessibleDescription = null;
			label1.AccessibleName = null;
			resources.ApplyResources(label1, "label1");
			label1.Font = null;
			label1.Name = "label1";
			lstArea.AccessibleDescription = null;
			lstArea.AccessibleName = null;
			resources.ApplyResources(lstArea, "lstArea");
			lstArea.BackgroundImage = null;
			lstArea.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			lstArea.FormattingEnabled = true;
			lstArea.Items.AddRange(new object[1]
			{
				resources.GetString("lstArea.Items")
			});
			lstArea.Name = "lstArea";
			lstArea.DrawItem += new System.Windows.Forms.DrawItemEventHandler(lstArea_DrawItem);
			lstArea.DoubleClick += new System.EventHandler(lstArea_DoubleClick);
			lstArea.SelectedIndexChanged += new System.EventHandler(lstArea_SelectedIndexChanged);
			label2.AccessibleDescription = null;
			label2.AccessibleName = null;
			resources.ApplyResources(label2, "label2");
			label2.Font = null;
			label2.Name = "label2";
			txtDelay.AccessibleDescription = null;
			txtDelay.AccessibleName = null;
			resources.ApplyResources(txtDelay, "txtDelay");
			txtDelay.Font = null;
			txtDelay.Name = "txtDelay";
			txtDelay.Value = new decimal(new int[4]
			{
				5,
				0,
				0,
				0
			});
			cmdStart.AccessibleDescription = null;
			cmdStart.AccessibleName = null;
			resources.ApplyResources(cmdStart, "cmdStart");
			cmdStart.BackgroundImage = null;
			cmdStart.Font = null;
			cmdStart.Name = "cmdStart";
			cmdStart.UseVisualStyleBackColor = true;
			cmdStart.Click += new System.EventHandler(cmdStart_Click);
			cmdClose.AccessibleDescription = null;
			cmdClose.AccessibleName = null;
			resources.ApplyResources(cmdClose, "cmdClose");
			cmdClose.BackgroundImage = null;
			cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cmdClose.Font = null;
			cmdClose.Name = "cmdClose";
			cmdClose.UseVisualStyleBackColor = true;
			cmdClose.Click += new System.EventHandler(cmdClose_Click);
			myTimer.Tick += new System.EventHandler(myTimer_Tick);
			lblBounds.AccessibleDescription = null;
			lblBounds.AccessibleName = null;
			resources.ApplyResources(lblBounds, "lblBounds");
			lblBounds.Font = null;
			lblBounds.Name = "lblBounds";
			cmdRefresh.AccessibleDescription = null;
			cmdRefresh.AccessibleName = null;
			resources.ApplyResources(cmdRefresh, "cmdRefresh");
			cmdRefresh.BackgroundImage = null;
			cmdRefresh.Font = null;
			cmdRefresh.Name = "cmdRefresh";
			cmdRefresh.UseVisualStyleBackColor = true;
			cmdRefresh.Click += new System.EventHandler(cmdRefresh_Click);
			lblWait.AccessibleDescription = null;
			lblWait.AccessibleName = null;
			resources.ApplyResources(lblWait, "lblWait");
			lblWait.Name = "lblWait";
			chkCursor.AccessibleDescription = null;
			chkCursor.AccessibleName = null;
			resources.ApplyResources(chkCursor, "chkCursor");
			chkCursor.BackgroundImage = null;
			chkCursor.Font = null;
			chkCursor.Name = "chkCursor";
			chkCursor.UseVisualStyleBackColor = true;
			picDesktop.AccessibleDescription = null;
			picDesktop.AccessibleName = null;
			resources.ApplyResources(picDesktop, "picDesktop");
			picDesktop.BackgroundImage = null;
			picDesktop.Font = null;
			picDesktop.ImageLocation = null;
			picDesktop.Name = "picDesktop";
			picDesktop.TabStop = false;
			base.AccessibleDescription = null;
			base.AccessibleName = null;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackgroundImage = null;
			base.CancelButton = cmdClose;
			base.Controls.Add(picDesktop);
			base.Controls.Add(chkCursor);
			base.Controls.Add(lblWait);
			base.Controls.Add(cmdRefresh);
			base.Controls.Add(lblBounds);
			base.Controls.Add(cmdClose);
			base.Controls.Add(cmdStart);
			base.Controls.Add(txtDelay);
			base.Controls.Add(label2);
			base.Controls.Add(lstArea);
			base.Controls.Add(label1);
			Font = null;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Icon = null;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgScreenSnapshot";
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgScreenSnapshot_Load);
			((System.ComponentModel.ISupportInitialize)txtDelay).EndInit();
			((System.ComponentModel.ISupportInitialize)picDesktop).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		public dlgScreenSnapshot()
		{
			InitializeComponent();
			strBounds = lblBounds.Text;
			lblBounds.Text = "";
			strDesktop = (string)lstArea.Items[0];
			strWait = lblWait.Text;
			lblWait.Text = "";
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgScreenSnapshot_Load(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Normal;
			Activate();
			cmdRefresh_Click(null, null);
		}

		private void lstArea_DrawItem(object sender, DrawItemEventArgs e)
		{
			if (e.Index < 0)
			{
				return;
			}
			e.DrawBackground();
			bool flag = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
			if (e.Index == 0)
			{
				if (desktopBmp == null)
				{
					desktopBmp = (Bitmap)picDesktop.Image;
					desktopBmp.MakeTransparent(Color.Red);
				}
				e.Graphics.DrawImage(desktopBmp, new Rectangle(e.Bounds.Left + 2, e.Bounds.Top + (e.Bounds.Height - 16) / 2, 16, 16));
			}
			string text = strDesktop;
			GClass244 gClass = lstArea.Items[e.Index] as GClass244;
			if (gClass != null)
			{
				Icon icon = gClass.method_24();
				if (icon != null && icon.Height > 0)
				{
					e.Graphics.DrawIcon(icon, new Rectangle(e.Bounds.Left + 2, e.Bounds.Top + (e.Bounds.Height - 16) / 2, 16, 16));
				}
				text = gClass.method_3();
			}
			if (text != null)
			{
				using (StringFormat stringFormat = new StringFormat())
				{
					stringFormat.Alignment = StringAlignment.Near;
					stringFormat.LineAlignment = StringAlignment.Center;
					stringFormat.FormatFlags = StringFormatFlags.NoWrap;
					e.Graphics.DrawString(text, lstArea.Font, flag ? SystemBrushes.HighlightText : SystemBrushes.WindowText, new RectangleF(e.Bounds.Left + 20, e.Bounds.Top, e.Bounds.Width - 20, e.Bounds.Height), stringFormat);
				}
			}
		}

		private void myTimer_Tick(object sender, EventArgs e)
		{
			TimeSpan timeSpan = dtmEnd.Subtract(DateTime.Now);
			lblWait.Text = string.Format(strWait, timeSpan.Seconds);
			if (timeSpan.Seconds == 0)
			{
				myTimer.Stop();
				Bitmap image = new Bitmap(mySnapshotBounds.Width, mySnapshotBounds.Height);
				using (Graphics graphics = Graphics.FromImage(image))
				{
					graphics.CopyFromScreen(mySnapshotBounds.Left, mySnapshotBounds.Top, 0, 0, mySnapshotBounds.Size, CopyPixelOperation.SourceCopy);
					if (chkCursor.Checked)
					{
						Point mousePosition = Control.MousePosition;
						mousePosition.X -= mySnapshotBounds.Left;
						mousePosition.Y -= mySnapshotBounds.Top;
						CursorInfo info = default(CursorInfo);
						info.cbSize = Marshal.SizeOf(info);
						if (!GetCursorInfo(ref info))
						{
							throw new Win32Exception();
						}
						if (info.hCursor != IntPtr.Zero && info.flags == 1)
						{
							Cursor cursor = new Cursor(info.hCursor);
							cursor.Draw(graphics, new Rectangle(mousePosition.X - cursor.HotSpot.X, mousePosition.Y - cursor.HotSpot.Y, cursor.Size.Width, cursor.Size.Height));
						}
					}
				}
				myBmpContent = image;
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}

		[DllImport("user32.dll")]
		private static extern bool GetCursorInfo(ref CursorInfo info);

		[DllImport("user32.dll")]
		private static extern IntPtr GetCursor();

		private void cmdStart_Click(object sender, EventArgs e)
		{
			lblWait.Bounds = lstArea.Bounds;
			lblWait.Text = "";
			lblWait.Visible = true;
			dtmEnd = DateTime.Now.AddSeconds((double)txtDelay.Value);
			myTimer.Start();
			lstArea.Enabled = false;
			txtDelay.Enabled = false;
			cmdStart.Enabled = false;
			cmdRefresh.Enabled = false;
			(lstArea.SelectedItem as GClass244)?.method_35();
		}

		private void lstArea_SelectedIndexChanged(object sender, EventArgs e)
		{
			mySnapshotBounds = Rectangle.Empty;
			if (lstArea.SelectedIndex == 0)
			{
				mySnapshotBounds = Screen.PrimaryScreen.Bounds;
			}
			else
			{
				GClass244 gClass = lstArea.SelectedItem as GClass244;
				if (gClass != null && gClass.method_21() != FormWindowState.Minimized)
				{
					mySnapshotBounds = gClass.method_8();
				}
			}
			if (!mySnapshotBounds.IsEmpty)
			{
				mySnapshotBounds = Rectangle.Intersect(Screen.PrimaryScreen.Bounds, mySnapshotBounds);
			}
			if (mySnapshotBounds.IsEmpty)
			{
				mySnapshotBounds = Screen.PrimaryScreen.Bounds;
			}
			lblBounds.Text = string.Format(strBounds, mySnapshotBounds.Left, mySnapshotBounds.Top, mySnapshotBounds.Width, mySnapshotBounds.Height);
		}

		private void cmdRefresh_Click(object sender, EventArgs e)
		{
			int num = 12;
			int num2 = lstArea.SelectedIndex;
			if (num2 < 0)
			{
				num2 = 0;
			}
			lblBounds.Text = "";
			lstArea.Items.Clear();
			lstArea.Items.Add(strDesktop);
			GClass244[] array = GClass244.smethod_6();
			foreach (GClass244 gClass in array)
			{
				if (gClass.Handle != base.Handle && gClass.method_3() != "Program Manager")
				{
					lstArea.Items.Add(gClass);
				}
			}
			if (num2 >= lstArea.Items.Count)
			{
				num2 = lstArea.Items.Count - 1;
			}
			lstArea.SelectedIndex = num2;
		}

		private void cmdClose_Click(object sender, EventArgs e)
		{
			myTimer.Stop();
			Close();
		}

		private void lstArea_DoubleClick(object sender, EventArgs e)
		{
			cmdStart_Click(null, null);
		}
	}
}
