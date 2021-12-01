using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace ZYCommon
{
	public class PropertyList : UserControl
	{
		private ArrayList myItems = new ArrayList();

		private int intItemHeight = 23;

		private int intUpdateLevel = 0;

		private TextBox myTextBox;

		private NumericUpDown myNumber;

		private Button myButton;

		private PropertyItem mySelectedItem = null;

		private int intLabelWidth = 15;

		public PropertyItem SelectedItem
		{
			get
			{
				return mySelectedItem;
			}
			set
			{
				if (mySelectedItem == value)
				{
					return;
				}
				PropertyItem propertyItem = mySelectedItem;
				if (propertyItem != null)
				{
					RefreshItem(propertyItem);
				}
				mySelectedItem = value;
				int num = myItems.IndexOf(mySelectedItem) * intItemHeight + base.AutoScrollPosition.Y;
				if (num < 0)
				{
					base.AutoScrollPosition = new Point(0, num - base.AutoScrollPosition.Y);
				}
				else if (num + intItemHeight > base.ClientSize.Height)
				{
					base.AutoScrollPosition = new Point(0, num + intItemHeight - base.ClientSize.Height - base.AutoScrollPosition.Y);
				}
				RefreshItem(mySelectedItem);
				if (myTextBox.Visible)
				{
					myTextBox_LostFocus(myTextBox, null);
				}
				if (myNumber.Visible)
				{
					myTextBox_LostFocus(myNumber, null);
				}
				if (myButton.Visible)
				{
					myButton.Visible = false;
				}
				Rectangle valueViewBounds = GetValueViewBounds(mySelectedItem);
				if (!(mySelectedItem.Value is bool))
				{
					if (mySelectedItem.Value is Color)
					{
						myButton.Location = new Point(valueViewBounds.Right - myButton.Width - 1, valueViewBounds.Top + (valueViewBounds.Height - myButton.Height) / 2);
						myButton.Tag = mySelectedItem;
						myButton.Show();
					}
					else if (mySelectedItem.Value is int || mySelectedItem.Value is long || mySelectedItem.Value is float || mySelectedItem.Value is double || mySelectedItem.Value is decimal)
					{
						myNumber.Bounds = valueViewBounds;
						myNumber.Value = (int)mySelectedItem.Value;
						myNumber.Tag = mySelectedItem;
						myNumber.Show();
					}
					else
					{
						myTextBox.Bounds = valueViewBounds;
						myTextBox.Text = mySelectedItem.Value.ToString();
						myTextBox.Tag = mySelectedItem;
						myTextBox.Show();
					}
				}
			}
		}

		public int SelectedIndex
		{
			get
			{
				return myItems.IndexOf(mySelectedItem);
			}
			set
			{
				if (value >= 0 && value < myItems.Count)
				{
					SelectedItem = (PropertyItem)myItems[value];
				}
			}
		}

		public ArrayList Items
		{
			get
			{
				return myItems;
			}
			set
			{
				myItems = value;
			}
		}

		public int ItemHeight
		{
			get
			{
				return intItemHeight;
			}
			set
			{
				intItemHeight = value;
			}
		}

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.ExStyle |= 512;
				return createParams;
			}
		}

		public PropertyList()
		{
			AutoScroll = true;
			BackColor = SystemColors.Control;
			myTextBox = new TextBox();
			myTextBox.Visible = false;
			base.Controls.Add(myTextBox);
			EventHandler value = myTextBox_LostFocus;
			myTextBox.LostFocus += value;
			myTextBox.KeyDown += myTextBox_KeyDown;
			myNumber = new NumericUpDown();
			myNumber.Visible = false;
			base.Controls.Add(myNumber);
			myNumber.ValueChanged += myNumber_ValueChanged;
			myButton = new Button();
			myButton.Visible = false;
			myButton.Size = new Size(20, 20);
			myButton.Text = "...";
			base.Controls.Add(myButton);
			myButton.Click += myButton_Click;
		}

		protected override bool IsInputKey(Keys keyData)
		{
			return true;
		}

		private void myButton_Click(object sender, EventArgs e)
		{
			PropertyItem propertyItem = myButton.Tag as PropertyItem;
			if (propertyItem != null && propertyItem.Value is Color)
			{
				using (ColorDialog colorDialog = new ColorDialog())
				{
					colorDialog.Color = (Color)propertyItem.Value;
					colorDialog.AllowFullOpen = true;
					if (colorDialog.ShowDialog(this) == DialogResult.OK)
					{
						propertyItem.Value = colorDialog.Color;
						RefreshItem(propertyItem);
					}
				}
			}
		}

		private void myNumber_ValueChanged(object sender, EventArgs e)
		{
			if (myNumber.Visible)
			{
				PropertyItem propertyItem = myNumber.Tag as PropertyItem;
				if (propertyItem != null)
				{
					propertyItem.Value = (int)myNumber.Value;
				}
			}
		}

		private void myTextBox_LostFocus(object sender, EventArgs e)
		{
			if (sender == myNumber && myNumber.Visible)
			{
				myNumber.Visible = false;
				PropertyItem propertyItem = myNumber.Tag as PropertyItem;
				if (propertyItem != null)
				{
					propertyItem.Value = (int)myNumber.Value;
					RefreshItem(propertyItem);
				}
			}
			if (sender == myTextBox && myTextBox.Visible)
			{
				myTextBox.Visible = false;
				PropertyItem propertyItem = myTextBox.Tag as PropertyItem;
				if (propertyItem != null)
				{
					try
					{
						if (propertyItem.Value is string)
						{
							propertyItem.Value = myTextBox.Text;
						}
						else if (propertyItem.Value is int)
						{
							propertyItem.Value = Convert.ToInt32(myTextBox.Text);
						}
						else if (propertyItem.Value is float)
						{
							propertyItem.Value = Convert.ToSingle(myTextBox.Text);
						}
						else if (propertyItem.Value is double)
						{
							propertyItem.Value = Convert.ToDouble(myTextBox.Text);
						}
					}
					catch
					{
					}
					RefreshItem(propertyItem);
				}
			}
		}

		public void BeginUpdate()
		{
			intUpdateLevel++;
		}

		public void EndUpdate()
		{
			intUpdateLevel--;
			if (intUpdateLevel <= 0)
			{
				intUpdateLevel = 0;
				UpdateView();
			}
		}

		public void UpdateView()
		{
			base.AutoScrollMinSize = new Size(0, myItems.Count * intItemHeight);
			Refresh();
		}

		public PropertyItem NewItem(string strName, string strText, object objValue)
		{
			PropertyItem propertyItem = new PropertyItem();
			myItems.Add(propertyItem);
			propertyItem.Name = strName;
			propertyItem.Label = strText;
			propertyItem.Value = objValue;
			return propertyItem;
		}

		public PropertyItem HitTest(int x, int y)
		{
			y -= base.AutoScrollPosition.Y;
			int num = (int)Math.Floor((double)y / (double)intItemHeight);
			if (num >= 0 && num < myItems.Count)
			{
				return (PropertyItem)myItems[num];
			}
			return null;
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
			case Keys.Right:
				break;
			case Keys.Up:
				if (mySelectedItem == null)
				{
					SelectedIndex = 0;
				}
				else
				{
					SelectedIndex--;
				}
				break;
			case Keys.Down:
				if (mySelectedItem == null)
				{
					SelectedIndex = 0;
				}
				else
				{
					SelectedIndex++;
				}
				break;
			}
		}

		protected override void OnClick(EventArgs e)
		{
			if (myTextBox.Visible)
			{
				myTextBox_LostFocus(myTextBox, null);
			}
			Point pt = PointToClient(Control.MousePosition);
			PropertyItem propertyItem = HitTest(pt.X, pt.Y);
			if (propertyItem != null)
			{
				if (propertyItem != mySelectedItem)
				{
					SelectedItem = propertyItem;
				}
				if (GetValueViewBounds(mySelectedItem).Contains(pt))
				{
					if (mySelectedItem.Value is bool)
					{
						mySelectedItem.Value = !(bool)mySelectedItem.Value;
					}
					else
					{
						if (myTextBox.Visible)
						{
							myTextBox.Focus();
							myTextBox.SelectAll();
						}
						if (myNumber.Visible)
						{
							myNumber.Focus();
						}
					}
				}
			}
			RefreshItem(mySelectedItem);
		}

		private Rectangle GetValueViewBounds(PropertyItem myItem)
		{
			return new Rectangle(intLabelWidth + 2, myItems.IndexOf(myItem) * intItemHeight + base.AutoScrollPosition.Y + 1, base.ClientSize.Width - intLabelWidth - 3, intItemHeight - 2);
		}

		private Rectangle GetItemViewBounds(PropertyItem myItem)
		{
			return new Rectangle(0, myItems.IndexOf(myItem) * intItemHeight + base.AutoScrollPosition.Y, base.ClientSize.Width, intItemHeight);
		}

		public void RefreshItem(PropertyItem myItem)
		{
			Invalidate(new Rectangle(0, myItems.IndexOf(myItem) * intItemHeight - 3 + base.AutoScrollPosition.Y, base.ClientSize.Width, intItemHeight + 6));
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			intLabelWidth = 15;
			foreach (PropertyItem myItem in myItems)
			{
				SizeF sizeF = graphics.MeasureString(myItem.Label, Font);
				if ((float)intLabelWidth < sizeF.Width + 2f)
				{
					intLabelWidth = (int)sizeF.Width + 2;
				}
			}
			if ((double)intLabelWidth < (double)(base.ClientSize.Width - 3) * 0.4)
			{
				intLabelWidth = (int)((double)(base.ClientSize.Width - 3) * 0.4);
			}
			Rectangle rect = new Rectangle(0, base.AutoScrollPosition.Y, base.ClientSize.Width, intItemHeight);
			Rectangle clipRectangle = e.ClipRectangle;
			graphics.DrawLine(SystemPens.WindowText, intLabelWidth, clipRectangle.Top, intLabelWidth, clipRectangle.Bottom);
			foreach (PropertyItem myItem2 in myItems)
			{
				if (rect.IntersectsWith(clipRectangle))
				{
					graphics.FillRectangle((myItem2 == mySelectedItem) ? SystemBrushes.Highlight : SystemBrushes.Control, new Rectangle(rect.Left, rect.Top, intLabelWidth, rect.Height));
					graphics.DrawRectangle(SystemPens.ControlDarkDark, rect);
					graphics.DrawString(myItem2.Label, Font, (myItem2 == mySelectedItem) ? SystemBrushes.HighlightText : SystemBrushes.WindowText, new RectangleF(rect.Left + 3, rect.Top + (int)(((float)rect.Height - Font.GetHeight()) / 2f), intLabelWidth, rect.Height));
					Rectangle rectangle = new Rectangle(intLabelWidth + 1, rect.Top, base.ClientSize.Width - intLabelWidth + 1, intItemHeight);
					RectangleF rectangleF = new RectangleF(rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height);
					Rectangle rectangle2 = new Rectangle(rectangle.Left + 2, rectangle.Top + (rectangle.Height - 16) / 2, 16, 16);
					Rectangle r = new Rectangle(rectangle.Left + 2, rect.Top + (int)(((float)rect.Height - Font.GetHeight()) / 2f), base.ClientSize.Width - rectangle.Left, (int)Font.GetHeight());
					if (myItem2.Value is bool)
					{
						ButtonState buttonState = ButtonState.Flat;
						if ((bool)myItem2.Value)
						{
							buttonState |= ButtonState.Checked;
						}
						ControlPaint.DrawCheckBox(graphics, rectangle2, buttonState);
					}
					else if (myItem2.Value is Color)
					{
						using (SolidBrush brush = new SolidBrush((Color)myItem2.Value))
						{
							graphics.FillRectangle(brush, rectangle2);
						}
						graphics.DrawRectangle(SystemPens.WindowText, rectangle2);
						string s = "#" + Convert.ToInt32(((Color)myItem2.Value).ToArgb() & 0xFFFFFF).ToString("X6");
						r.X += 18;
						graphics.DrawString(s, Font, SystemBrushes.WindowText, r);
					}
					else
					{
						graphics.DrawString(myItem2.Value.ToString(), Font, SystemBrushes.WindowText, r);
					}
				}
				else if (rect.Top > clipRectangle.Bottom)
				{
					break;
				}
				rect.Y += intItemHeight;
			}
		}

		private void myTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				myTextBox_LostFocus(sender, null);
				SelectedIndex++;
			}
		}
	}
}
