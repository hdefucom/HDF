using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Drawing.Design
{
	[ComVisible(false)]
	public class dlgParagraphListStyle : Form
	{
		private IContainer icontainer_0 = null;

		private ListBox lstParagraphListStyle;

		private Button btnOK;

		private Button btnCancel;

		private ParagraphListStyle paragraphListStyle_0 = ParagraphListStyle.None;

		private bool bool_0 = true;

		public ParagraphListStyle SelectedListStyle
		{
			get
			{
				return paragraphListStyle_0;
			}
			set
			{
				paragraphListStyle_0 = value;
			}
		}

		/// <summary>
		///       包含圆点列表模式
		///       </summary>
		public bool IncludeBulletedList
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Drawing.Design.dlgParagraphListStyle));
			lstParagraphListStyle = new System.Windows.Forms.ListBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			resources.ApplyResources(lstParagraphListStyle, "lstParagraphListStyle");
			lstParagraphListStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			lstParagraphListStyle.FormattingEnabled = true;
			lstParagraphListStyle.Name = "lstParagraphListStyle";
			lstParagraphListStyle.DrawItem += new System.Windows.Forms.DrawItemEventHandler(lstParagraphListStyle_DrawItem);
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(lstParagraphListStyle);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgParagraphListStyle";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgParagraphListStyle_Load);
			ResumeLayout(false);
		}

		public dlgParagraphListStyle()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgParagraphListStyle_Load(object sender, EventArgs e)
		{
			int num = 3;
			foreach (ParagraphListStyle value in Enum.GetValues(typeof(ParagraphListStyle)))
			{
				if (IncludeBulletedList || !value.ToString().StartsWith("BulletedList"))
				{
					lstParagraphListStyle.Items.Add(value);
				}
			}
			lstParagraphListStyle.SelectedItem = SelectedListStyle;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			SelectedListStyle = (ParagraphListStyle)lstParagraphListStyle.SelectedItem;
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void lstParagraphListStyle_DrawItem(object sender, DrawItemEventArgs e)
		{
			int num = 19;
			RectangleF layoutRectangle = new RectangleF(e.Bounds.Left, e.Bounds.Top, e.Bounds.Width, e.Bounds.Height);
			e.DrawBackground();
			Brush brush = (e.State == DrawItemState.Selected || e.State == DrawItemState.Focus) ? SystemBrushes.HighlightText : SystemBrushes.ControlText;
			using (StringFormat stringFormat = new StringFormat())
			{
				stringFormat.Alignment = StringAlignment.Near;
				stringFormat.LineAlignment = StringAlignment.Center;
				stringFormat.FormatFlags = StringFormatFlags.NoWrap;
				ParagraphListStyle paragraphListStyle = (ParagraphListStyle)lstParagraphListStyle.Items[e.Index];
				if (paragraphListStyle == ParagraphListStyle.None)
				{
					e.Graphics.DrawString("无", lstParagraphListStyle.Font, brush, layoutRectangle, stringFormat);
				}
				else
				{
					ContentStyle contentStyle = new ContentStyle();
					contentStyle.ParagraphListStyle = paragraphListStyle;
					if (contentStyle.IsListNumberStyle)
					{
						StringBuilder stringBuilder = new StringBuilder();
						for (int i = 1; i <= 4; i++)
						{
							if (i > 1)
							{
								stringBuilder.Append(' ');
							}
							stringBuilder.Append(contentStyle.method_26(i));
						}
						e.Graphics.DrawString(stringBuilder.ToString(), new XFontValue("宋体", lstParagraphListStyle.Font.Size).Value, brush, layoutRectangle, stringFormat);
					}
					else
					{
						XFontValue xFontValue = new XFontValue("Wingdings", lstParagraphListStyle.Font.Size);
						SizeF sizeF = e.Graphics.MeasureString(contentStyle.BulletedString, xFontValue.Value, 1000);
						e.Graphics.DrawString(contentStyle.BulletedString, xFontValue.Value, brush, layoutRectangle, stringFormat);
						float num2 = layoutRectangle.Left + sizeF.Width + 5f;
						layoutRectangle.Width = layoutRectangle.Right - num2;
						layoutRectangle.X = num2;
						e.Graphics.DrawString(contentStyle.ParagraphListStyle.ToString(), lstParagraphListStyle.Font, brush, layoutRectangle, stringFormat);
					}
				}
			}
		}
	}
}
