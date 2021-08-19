using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.WinForms
{
	[ComVisible(false)]
	public class dlgListItems2 : Form
	{
		private List<string> list_0 = new List<string>();

		private List<string> list_1 = new List<string>();

		private string string_0 = null;

		private int int_0 = 0;

		private IContainer icontainer_0 = null;

		private ListBox lstItems;

		private Button btnOK;

		private Button btnCancel;

		public List<string> ItemValues
		{
			get
			{
				return list_0;
			}
			set
			{
				list_0 = value;
			}
		}

		public List<string> ItemDescriptions
		{
			get
			{
				return list_1;
			}
			set
			{
				list_1 = value;
			}
		}

		public string SelectedValue
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		public dlgListItems2()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgListItems2_Load(object sender, EventArgs e)
		{
			if (list_0 != null && list_0.Count > 0 && list_1 != null && list_1.Count > 0)
			{
				int_0 = 10;
				using (Graphics graphics = lstItems.CreateGraphics())
				{
					foreach (string item in list_0)
					{
						if (!string.IsNullOrEmpty(item))
						{
							int_0 = (int)Math.Max(val2: graphics.MeasureString(item, lstItems.Font, 10000).Width, val1: int_0);
						}
						lstItems.Items.Add(item);
					}
				}
				int_0 += 5;
				lstItems.DrawMode = DrawMode.OwnerDrawFixed;
				lstItems.MeasureItem += lstItems_MeasureItem;
				lstItems.DrawItem += lstItems_DrawItem;
			}
			if (list_0 != null)
			{
				lstItems.Items.AddRange(list_0.ToArray());
				lstItems.SelectedValue = SelectedValue;
			}
		}

		private void lstItems_DrawItem(object sender, DrawItemEventArgs e)
		{
			e.DrawBackground();
			string text = list_0[e.Index];
			if (string.IsNullOrEmpty(text))
			{
				string text2 = null;
				if (list_1 != null && e.Index >= 0 && e.Index < list_1.Count)
				{
					text2 = list_1[e.Index];
				}
				Brush brush = null;
				brush = (((e.State & DrawItemState.Selected) != DrawItemState.Selected) ? SystemBrushes.ControlText : SystemBrushes.HighlightText);
				bool flag = lstItems.RightToLeft == RightToLeft.Yes;
				using (StringFormat stringFormat = new StringFormat())
				{
					stringFormat.Alignment = StringAlignment.Near;
					stringFormat.LineAlignment = StringAlignment.Center;
					RectangleF layoutRectangle = new RectangleF(e.Bounds.Left, e.Bounds.Top, int_0, e.Bounds.Height);
					if (flag)
					{
						layoutRectangle = new RectangleF(e.Bounds.Right - int_0, e.Bounds.Top, int_0, e.Bounds.Height);
					}
					e.Graphics.DrawString(text, lstItems.Font, brush, layoutRectangle, stringFormat);
					if (!string.IsNullOrEmpty(text2))
					{
						RectangleF layoutRectangle2 = new RectangleF(layoutRectangle.Right, layoutRectangle.Top, e.Bounds.Width - int_0, layoutRectangle.Height);
						if (flag)
						{
							layoutRectangle2 = new RectangleF(layoutRectangle.Left - (float)int_0, layoutRectangle.Top, e.Bounds.Width - int_0, layoutRectangle.Height);
						}
						e.Graphics.DrawString(text2, lstItems.Font, brush, layoutRectangle2, stringFormat);
					}
				}
				e.DrawFocusRectangle();
			}
		}

		private void lstItems_MeasureItem(object sender, MeasureItemEventArgs e)
		{
			e.ItemHeight = (int)(lstItems.Font.GetHeight(e.Graphics) + 3f);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (lstItems.SelectedIndex >= 0)
			{
				string_0 = Convert.ToString(lstItems.SelectedValue);
				base.DialogResult = DialogResult.OK;
				Close();
			}
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
			lstItems = new System.Windows.Forms.ListBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			lstItems.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			lstItems.Font = new System.Drawing.Font("宋体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			lstItems.FormattingEnabled = true;
			lstItems.ItemHeight = 14;
			lstItems.Location = new System.Drawing.Point(1, 2);
			lstItems.Name = "lstItems";
			lstItems.Size = new System.Drawing.Size(497, 382);
			lstItems.TabIndex = 0;
			btnOK.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			btnOK.Location = new System.Drawing.Point(224, 397);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(119, 23);
			btnOK.TabIndex = 1;
			btnOK.Text = "确定(&O)";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			btnCancel.Location = new System.Drawing.Point(364, 397);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(119, 23);
			btnCancel.TabIndex = 2;
			btnCancel.Text = "取消(&C)";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			base.AcceptButton = btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.ClientSize = new System.Drawing.Size(501, 434);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(lstItems);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MinimizeBox = false;
			base.Name = "dlgListItems2";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "请选择项目";
			base.Load += new System.EventHandler(dlgListItems2_Load);
			ResumeLayout(false);
		}
	}
}
