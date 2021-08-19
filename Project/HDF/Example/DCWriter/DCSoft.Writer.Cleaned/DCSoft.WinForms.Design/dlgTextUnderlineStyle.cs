using DCSoft.Drawing;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.WinForms.Design
{
	/// <summary>
	///       下划线样式对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgTextUnderlineStyle : Form
	{
		private IContainer icontainer_0 = null;

		private ListBox lstItems;

		private Button btnOK;

		private Button btnCancel;

		private GClass304 btnColor;

		private Label label1;

		private Label lblTextDemo;

		private TextUnderlineStyle textUnderlineStyle_0 = TextUnderlineStyle.Single;

		private Color color_0 = Color.Black;

		private Color color_1 = Color.Black;

		/// <summary>
		///       选择的下划线样式
		///       </summary>
		public TextUnderlineStyle SelectedStyle
		{
			get
			{
				return textUnderlineStyle_0;
			}
			set
			{
				textUnderlineStyle_0 = value;
			}
		}

		/// <summary>
		///       被选中的颜色
		///       </summary>
		public Color DefaultColor
		{
			get
			{
				return color_0;
			}
			set
			{
				color_0 = value;
			}
		}

		/// <summary>
		///       被选中的颜色
		///       </summary>
		public Color SelectedColor
		{
			get
			{
				return color_1;
			}
			set
			{
				color_1 = value;
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
			btnColor = new DCSoftDotfuscate.GClass304();
			label1 = new System.Windows.Forms.Label();
			lblTextDemo = new System.Windows.Forms.Label();
			SuspendLayout();
			lstItems.Dock = System.Windows.Forms.DockStyle.Top;
			lstItems.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			lstItems.Font = new System.Drawing.Font("宋体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			lstItems.FormattingEnabled = true;
			lstItems.ItemHeight = 35;
			lstItems.Location = new System.Drawing.Point(0, 0);
			lstItems.Name = "lstItems";
			lstItems.Size = new System.Drawing.Size(319, 249);
			lstItems.TabIndex = 0;
			lstItems.DrawItem += new System.Windows.Forms.DrawItemEventHandler(lstItems_DrawItem);
			btnOK.Location = new System.Drawing.Point(62, 303);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(75, 23);
			btnOK.TabIndex = 3;
			btnOK.Text = "确定(&O)";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			btnCancel.Location = new System.Drawing.Point(170, 303);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(75, 23);
			btnCancel.TabIndex = 4;
			btnCancel.Text = "取消(&C)";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			btnColor.Location = new System.Drawing.Point(59, 263);
			btnColor.Name = "btnColor";
			btnColor.Size = new System.Drawing.Size(186, 23);
			btnColor.TabIndex = 2;
			btnColor.UseVisualStyleBackColor = true;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(12, 268);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(41, 12);
			label1.TabIndex = 1;
			label1.Text = "颜色：";
			lblTextDemo.AutoSize = true;
			lblTextDemo.Location = new System.Drawing.Point(273, 253);
			lblTextDemo.Name = "lblTextDemo";
			lblTextDemo.Size = new System.Drawing.Size(191, 12);
			lblTextDemo.TabIndex = 5;
			lblTextDemo.Text = "南京都昌信息科技有限公司 AaBbCc";
			lblTextDemo.Visible = false;
			base.AcceptButton = btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.ClientSize = new System.Drawing.Size(319, 337);
			base.Controls.Add(lblTextDemo);
			base.Controls.Add(label1);
			base.Controls.Add(btnColor);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(lstItems);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgTextUnderlineStyle";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "下划线样式";
			base.Load += new System.EventHandler(dlgTextUnderlineStyle_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		public dlgTextUnderlineStyle()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
			btnColor.method_9(method_0);
		}

		private void method_0(object sender, EventArgs e)
		{
			lstItems.Refresh();
		}

		private void dlgTextUnderlineStyle_Load(object sender, EventArgs e)
		{
			foreach (object value in Enum.GetValues(typeof(TextUnderlineStyle)))
			{
				lstItems.Items.Add(value);
			}
			lstItems.SelectedItem = SelectedStyle;
			btnColor.method_1(SelectedColor);
			btnColor.method_5(bool_2: true);
			btnColor.method_7(DefaultColor);
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			SelectedColor = btnColor.method_0();
			SelectedStyle = (TextUnderlineStyle)lstItems.SelectedItem;
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void lstItems_DrawItem(object sender, DrawItemEventArgs e)
		{
			if (e.Index >= 0)
			{
				bool flag = (e.State & DrawItemState.Selected) == DrawItemState.Selected || (e.State & DrawItemState.Focus) == DrawItemState.Focus;
				e.DrawBackground();
				TextUnderlineStyle style = (TextUnderlineStyle)lstItems.Items[e.Index];
				string text = lblTextDemo.Text;
				SizeF sizeF = e.Graphics.MeasureString(text, Font, 100000);
				using (StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic))
				{
					stringFormat.Alignment = StringAlignment.Center;
					stringFormat.LineAlignment = StringAlignment.Center;
					Rectangle bounds = e.Bounds;
					RectangleF layoutRectangle = new RectangleF((float)bounds.Left + ((float)bounds.Width - sizeF.Width) / 2f, (float)bounds.Top + ((float)bounds.Height - sizeF.Height) / 2f, sizeF.Width, sizeF.Height);
					if (flag)
					{
						e.Graphics.DrawString(text, Font, SystemBrushes.HighlightText, layoutRectangle, stringFormat);
					}
					else
					{
						e.Graphics.DrawString(text, Font, GClass438.smethod_0(DefaultColor), layoutRectangle, stringFormat);
					}
					DrawerUtil.DrawUnderLine(new DCGraphics(e.Graphics), style, flag ? SystemColors.HighlightText : btnColor.method_0(), layoutRectangle.Left, layoutRectangle.Bottom - 2f, layoutRectangle.Right, layoutRectangle.Bottom - 2f, 3f);
				}
			}
		}
	}
}
