using DCSoft.Writer.Dom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	[ComVisible(false)]
	public class dlgImagePartitionEditor : Form
	{
		public List<XImagePartition> list_0;

		private float float_0;

		private float float_1;

		private float float_2;

		private float float_3;

		private float float_4;

		private float float_5;

		private RectangleF rectangleF_0;

		private Region region_0;

		private Region region_1;

		private Graphics graphics_0;

		private XImagePartition ximagePartition_0;

		private IContainer icontainer_0 = null;

		private ToolStrip toolStrip1;

		private SplitContainer splitContainer1;

		private ListBox lstAreas;

		private PictureBox picboxImage;

		private ToolStripButton toolbtnNewArea;

		private ToolStripButton toolbtnSaveArea;

		private ToolStripButton toolbtnDeleteArea;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripButton toolbtnOK;

		private ToolStripButton toolbtnCancel;

		public dlgImagePartitionEditor(Image image_0, List<XImagePartition> list_1)
		{
			InitializeComponent();
			graphics_0 = picboxImage.CreateGraphics();
			region_1 = new Region();
			ximagePartition_0 = new XImagePartition();
			list_0 = new List<XImagePartition>();
			if (image_0 != null)
			{
				method_0(image_0);
				rectangleF_0 = new RectangleF((float)picboxImage.Bounds.X + float_0, (float)picboxImage.Bounds.Y + float_1, float_4, float_5);
				region_0 = new Region(rectangleF_0);
				picboxImage.Image = image_0;
			}
			if (list_1 != null && list_1.Count > 0)
			{
				list_0 = list_1;
				foreach (XImagePartition item in list_1)
				{
					lstAreas.Items.Add(item);
				}
			}
		}

		private void method_0(Image image_0)
		{
			if (image_0 != null)
			{
				float_3 = (float)picboxImage.Width / (float)picboxImage.Height;
				float_2 = (float)image_0.Width / (float)image_0.Height;
				if (float_3 >= float_2)
				{
					float_5 = picboxImage.Height;
					float_1 = 0f;
					float_4 = (float)picboxImage.Height * float_2;
					float_0 = ((float)picboxImage.Width - float_4) / 2f;
				}
				else
				{
					float_4 = picboxImage.Width;
					float_0 = 0f;
					float_5 = (float)picboxImage.Width / float_2;
					float_1 = ((float)picboxImage.Height - float_5) / 2f;
				}
			}
		}

		private void lstAreas_SelectedIndexChanged(object sender, EventArgs e)
		{
			toolbtnDeleteArea.Enabled = true;
			picboxImage.Invalidate(region_1);
			if (lstAreas.SelectedItem != null)
			{
				XImagePartition xImagePartition = lstAreas.SelectedItem as XImagePartition;
				PointF[] array = xImagePartition.RatioToPointFsList.ToArray();
				byte[] array2 = new byte[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i].X = float_4 * array[i].X + float_0;
					array[i].Y = float_5 * array[i].Y + float_1;
					array2[i] = 1;
				}
				GraphicsPath path = new GraphicsPath(array, array2);
				region_1 = new Region(path);
				graphics_0.FillPath(Brushes.Blue, path);
			}
		}

		private void toolbtnSaveArea_Click(object sender, EventArgs e)
		{
			toolbtnSaveArea.Enabled = false;
			toolbtnNewArea.Enabled = true;
			toolbtnOK.Enabled = true;
			lstAreas.Enabled = true;
			picboxImage.Invalidate();
			using (dlgImagePartitionInfoEditor dlgImagePartitionInfoEditor = new dlgImagePartitionInfoEditor())
			{
				if (dlgImagePartitionInfoEditor.ShowDialog() == DialogResult.OK)
				{
					ximagePartition_0.Text = dlgImagePartitionInfoEditor.string_0;
					ximagePartition_0.Value = dlgImagePartitionInfoEditor.int_0;
				}
			}
			list_0.Add(ximagePartition_0);
			lstAreas.Items.Add(ximagePartition_0);
			lstAreas.SelectedItem = ximagePartition_0;
			picboxImage.MouseClick -= picboxImage_MouseClick;
		}

		private void toolbtnNewArea_Click(object sender, EventArgs e)
		{
			toolbtnNewArea.Enabled = false;
			toolbtnDeleteArea.Enabled = false;
			toolbtnSaveArea.Enabled = true;
			toolbtnOK.Enabled = false;
			lstAreas.Enabled = false;
			picboxImage.Invalidate();
			ximagePartition_0 = new XImagePartition();
			picboxImage.MouseClick += picboxImage_MouseClick;
		}

		private void picboxImage_MouseClick(object sender, MouseEventArgs e)
		{
			if (region_0.IsVisible(new PointF(e.X, e.Y)))
			{
				graphics_0.DrawRectangle(new Pen(Brushes.Black), new Rectangle(e.X - 1, e.Y - 1, 3, 3));
				float x = ((float)e.X - float_0) / float_4;
				float y = ((float)e.Y - float_1) / float_5;
				ximagePartition_0.RatioToPointFsList.Add(new PointF(x, y));
			}
		}

		private void toolbtnDeleteArea_Click(object sender, EventArgs e)
		{
			list_0.Remove((XImagePartition)lstAreas.SelectedItem);
			lstAreas.Items.Remove(lstAreas.SelectedItem);
		}

		private void toolbtnCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			Close();
		}

		private void toolbtnOK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			Close();
		}

		/// <summary>
		///       Clean up any resources being used.
		///       </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		///       Required method for Designer support - do not modify
		///       the contents of this method with the code editor.
		///       </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgImagePartitionEditor));
			toolStrip1 = new System.Windows.Forms.ToolStrip();
			toolbtnNewArea = new System.Windows.Forms.ToolStripButton();
			toolbtnSaveArea = new System.Windows.Forms.ToolStripButton();
			toolbtnDeleteArea = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			toolbtnOK = new System.Windows.Forms.ToolStripButton();
			toolbtnCancel = new System.Windows.Forms.ToolStripButton();
			splitContainer1 = new System.Windows.Forms.SplitContainer();
			lstAreas = new System.Windows.Forms.ListBox();
			picboxImage = new System.Windows.Forms.PictureBox();
			toolStrip1.SuspendLayout();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)picboxImage).BeginInit();
			SuspendLayout();
			toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[6]
			{
				toolbtnNewArea,
				toolbtnSaveArea,
				toolbtnDeleteArea,
				toolStripSeparator1,
				toolbtnOK,
				toolbtnCancel
			});
			toolStrip1.Location = new System.Drawing.Point(0, 0);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.Size = new System.Drawing.Size(760, 25);
			toolStrip1.TabIndex = 0;
			toolStrip1.Text = "toolStrip1";
			toolbtnNewArea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			toolbtnNewArea.Image = (System.Drawing.Image)resources.GetObject("toolbtnNewArea.Image");
			toolbtnNewArea.ImageTransparentColor = System.Drawing.Color.Magenta;
			toolbtnNewArea.Name = "toolbtnNewArea";
			toolbtnNewArea.Size = new System.Drawing.Size(60, 22);
			toolbtnNewArea.Text = "新增区域";
			toolbtnNewArea.Click += new System.EventHandler(toolbtnNewArea_Click);
			toolbtnSaveArea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			toolbtnSaveArea.Enabled = false;
			toolbtnSaveArea.Image = (System.Drawing.Image)resources.GetObject("toolbtnSaveArea.Image");
			toolbtnSaveArea.ImageTransparentColor = System.Drawing.Color.Magenta;
			toolbtnSaveArea.Name = "toolbtnSaveArea";
			toolbtnSaveArea.Size = new System.Drawing.Size(60, 22);
			toolbtnSaveArea.Text = "保存区域";
			toolbtnSaveArea.Click += new System.EventHandler(toolbtnSaveArea_Click);
			toolbtnDeleteArea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			toolbtnDeleteArea.Enabled = false;
			toolbtnDeleteArea.Image = (System.Drawing.Image)resources.GetObject("toolbtnDeleteArea.Image");
			toolbtnDeleteArea.ImageTransparentColor = System.Drawing.Color.Magenta;
			toolbtnDeleteArea.Name = "toolbtnDeleteArea";
			toolbtnDeleteArea.Size = new System.Drawing.Size(60, 22);
			toolbtnDeleteArea.Text = "删除区域";
			toolbtnDeleteArea.Click += new System.EventHandler(toolbtnDeleteArea_Click);
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			toolbtnOK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			toolbtnOK.Image = (System.Drawing.Image)resources.GetObject("toolbtnOK.Image");
			toolbtnOK.ImageTransparentColor = System.Drawing.Color.Magenta;
			toolbtnOK.Name = "toolbtnOK";
			toolbtnOK.Size = new System.Drawing.Size(120, 22);
			toolbtnOK.Text = "保存区域列表并退出";
			toolbtnOK.Click += new System.EventHandler(toolbtnOK_Click);
			toolbtnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			toolbtnCancel.Image = (System.Drawing.Image)resources.GetObject("toolbtnCancel.Image");
			toolbtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
			toolbtnCancel.Name = "toolbtnCancel";
			toolbtnCancel.Size = new System.Drawing.Size(96, 22);
			toolbtnCancel.Text = "取消保存并退出";
			toolbtnCancel.Visible = false;
			toolbtnCancel.Click += new System.EventHandler(toolbtnCancel_Click);
			splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			splitContainer1.IsSplitterFixed = true;
			splitContainer1.Location = new System.Drawing.Point(0, 25);
			splitContainer1.Name = "splitContainer1";
			splitContainer1.Panel1.AutoScroll = true;
			splitContainer1.Panel1.Controls.Add(lstAreas);
			splitContainer1.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
			splitContainer1.Panel1MinSize = 50;
			splitContainer1.Panel2.AutoScroll = true;
			splitContainer1.Panel2.Controls.Add(picboxImage);
			splitContainer1.Panel2MinSize = 50;
			splitContainer1.Size = new System.Drawing.Size(760, 600);
			splitContainer1.SplitterDistance = 136;
			splitContainer1.SplitterWidth = 5;
			splitContainer1.TabIndex = 1;
			lstAreas.Dock = System.Windows.Forms.DockStyle.Fill;
			lstAreas.FormattingEnabled = true;
			lstAreas.ItemHeight = 12;
			lstAreas.Location = new System.Drawing.Point(0, 0);
			lstAreas.Name = "lstAreas";
			lstAreas.Size = new System.Drawing.Size(136, 600);
			lstAreas.TabIndex = 0;
			lstAreas.SelectedIndexChanged += new System.EventHandler(lstAreas_SelectedIndexChanged);
			picboxImage.Dock = System.Windows.Forms.DockStyle.Fill;
			picboxImage.Location = new System.Drawing.Point(0, 0);
			picboxImage.Name = "picboxImage";
			picboxImage.Size = new System.Drawing.Size(619, 600);
			picboxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			picboxImage.TabIndex = 0;
			picboxImage.TabStop = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(760, 625);
			base.Controls.Add(splitContainer1);
			base.Controls.Add(toolStrip1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgImagePartitionEditor";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "图片区域编辑器";
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)picboxImage).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
