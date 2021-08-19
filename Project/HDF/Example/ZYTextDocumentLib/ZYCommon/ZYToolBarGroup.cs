using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ZYCommon
{
	public class ZYToolBarGroup : Control
	{
		public interface IZYToolBarButtonAction
		{
			bool isEnable();

			int CheckState();

			bool UIExecute();

			bool SetText(string strText);

			string GetText();
		}

		public enum ZYToolBarButtonStyle
		{
			Button,
			DropDownList,
			TextBox,
			Spliter,
			TextPanel,
			PushButton,
			CustomControl
		}

		public class ZYToolBarButton
		{
			private ZYToolBarButtonStyle intStyle = ZYToolBarButtonStyle.Button;

			private string strText = null;

			public string Value = null;

			public string Command = null;

			public string ToolTip = null;

			public bool Visible = true;

			private bool bolEnable = true;

			internal bool SettingText = false;

			private bool bolPushed = false;

			public IZYToolBarButtonAction Action = null;

			private Control myInnerControl = null;

			public string GroupName = null;

			public bool AutoSize = true;

			public int Width = 10;

			public Rectangle Bounds;

			public Image ButtonImage = null;

			public int ImageListIndex = -1;

			public ButtonClickHandler Click = null;

			public PaintButtonHandler OwnerDraw = null;

			public ZYToolBar OwnerToolBar = null;

			public ZYToolBarButtonStyle Style
			{
				get
				{
					return intStyle;
				}
				set
				{
					intStyle = value;
				}
			}

			public string Text
			{
				get
				{
					if (InnerControl == null)
					{
						return strText;
					}
					return InnerControl.Text;
				}
				set
				{
					SettingText = true;
					strText = value;
					if (InnerControl != null)
					{
						InnerControl.Text = value;
					}
					SettingText = false;
				}
			}

			public bool Enable
			{
				get
				{
					if (Action == null)
					{
						return bolEnable;
					}
					return Action.isEnable();
				}
				set
				{
					bolEnable = value;
				}
			}

			public bool Pushed
			{
				get
				{
					if (Action == null)
					{
						return bolPushed;
					}
					if (Action.CheckState() == -1)
					{
						return bolPushed;
					}
					return Action.CheckState() == 1;
				}
				set
				{
					bolPushed = value;
				}
			}

			public Control InnerControl
			{
				get
				{
					return myInnerControl;
				}
				set
				{
					myInnerControl = value;
					if (myInnerControl != null && Action != null)
					{
						myInnerControl.Text = Action.GetText();
					}
				}
			}
		}

		public class ZYToolBar
		{
			private ArrayList myButtons = new ArrayList();

			private ZYToolBarGroup myOwnerControl = null;

			private int intTop = 0;

			private int intLeft = 0;

			private int intWidth = 0;

			private int intHeight = 27;

			private bool bolVisible = true;

			private string strName = null;

			public string Name
			{
				get
				{
					return strName;
				}
				set
				{
					strName = value;
				}
			}

			public int Left
			{
				get
				{
					return intLeft;
				}
				set
				{
					intLeft = value;
				}
			}

			public int Top
			{
				get
				{
					return intTop;
				}
				set
				{
					intTop = value;
				}
			}

			public int Width
			{
				get
				{
					return intWidth;
				}
				set
				{
					intWidth = value;
				}
			}

			public int Height
			{
				get
				{
					return intHeight;
				}
				set
				{
					intHeight = value;
				}
			}

			public Rectangle Bounds
			{
				get
				{
					return new Rectangle(intLeft, intTop, intWidth, intHeight);
				}
				set
				{
					intLeft = value.Left;
					intTop = value.Top;
					intWidth = value.Width;
					intHeight = value.Height;
				}
			}

			public ZYToolBarGroup OwnerControl
			{
				get
				{
					return myOwnerControl;
				}
				set
				{
					myOwnerControl = value;
				}
			}

			public bool Visible
			{
				get
				{
					return bolVisible;
				}
				set
				{
					bolVisible = value;
				}
			}

			public ArrayList Buttons
			{
				get
				{
					return myButtons;
				}
				set
				{
					myButtons = value;
				}
			}

			public ArrayList GetVisibleButtons()
			{
				ArrayList arrayList = new ArrayList();
				foreach (ZYToolBarButton myButton in myButtons)
				{
					if (myButton.Visible)
					{
						arrayList.Add(myButton);
					}
				}
				return arrayList;
			}

			public ZYToolBarButton AddButton(string strText)
			{
				ZYToolBarButton zYToolBarButton = new ZYToolBarButton();
				zYToolBarButton.Text = strText;
				myButtons.Add(zYToolBarButton);
				zYToolBarButton.OwnerToolBar = this;
				return zYToolBarButton;
			}

			public ZYToolBarButton GetButton(int index)
			{
				if (index >= 0 && index < myButtons.Count)
				{
					return (ZYToolBarButton)myButtons[index];
				}
				return null;
			}

			public ZYToolBarButton GetButton(string strCommand)
			{
				foreach (ZYToolBarButton myButton in myButtons)
				{
					if (myButton.Command == strCommand)
					{
						return myButton;
					}
				}
				return null;
			}

			public void DrawToolBar(Graphics myGraph, Rectangle ClipRect)
			{
				foreach (ZYToolBarButton myButton in myButtons)
				{
					if (myButton.Visible && myButton.Width > 0 && myButton.Bounds.IntersectsWith(ClipRect) && (myOwnerControl.OnPaintButton == null || !myOwnerControl.OnPaintButton(myGraph, myButton)) && (myButton.OwnerDraw == null || !myButton.OwnerDraw(myGraph, myButton)))
					{
						switch (myButton.Style)
						{
						case ZYToolBarButtonStyle.Button:
						case ZYToolBarButtonStyle.PushButton:
						{
							int num4 = myButton.Bounds.X + 1;
							int num5 = num4;
							if (myButton.ButtonImage != null && myOwnerControl.ShowIcon)
							{
								num5 = num4 + myOwnerControl.ImageList.ImageSize.Width + 1;
							}
							int num6 = 0;
							if (!myButton.Pushed)
							{
								num6 = ((myButton == myOwnerControl.CurrentHoverButton) ? 1 : 0);
							}
							else
							{
								num6 = 2;
								if (myButton.Style == ZYToolBarButtonStyle.PushButton)
								{
									myGraph.FillRectangle(SystemBrushes.Window, myButton.Bounds);
								}
							}
							int num7 = myButton.Bounds.Left + 2;
							int num8 = 0;
							if (num6 == 1)
							{
								num8 = -1;
							}
							if (num6 == 2)
							{
								num8 = 1;
							}
							if (myButton.ButtonImage != null && myOwnerControl.ShowIcon)
							{
								int num9 = myButton.Bounds.Top + (myButton.Bounds.Height - myButton.ButtonImage.Size.Height) / 2;
								if (myButton.Enable)
								{
									myGraph.DrawImage(myButton.ButtonImage, num7 + num8, num9 + num8);
								}
								else
								{
									ControlPaint.DrawImageDisabled(myGraph, myButton.ButtonImage, num7 + num8, num9 + num8, SystemColors.ControlLightLight);
								}
								num7 += myButton.ButtonImage.Size.Width;
							}
							if (myOwnerControl.ShowText && myButton.Text != null && myButton.Text.Length > 0)
							{
								RectangleF layoutRectangle = new RectangleF(num7 + num8, (float)myButton.Bounds.Top + ((float)myButton.Bounds.Height - myOwnerControl.Font.GetHeight()) / 2f + (float)num8 + 2f, myButton.Bounds.Right - num7 - 1, myOwnerControl.Font.GetHeight() + 2f);
								if (myButton.Enable)
								{
									myGraph.DrawString(myButton.Text, myOwnerControl.Font, SystemBrushes.WindowText, layoutRectangle);
								}
								else
								{
									ControlPaint.DrawStringDisabled(myGraph, myButton.Text, myOwnerControl.Font, SystemColors.ControlLightLight, layoutRectangle, StringFormat.GenericDefault);
								}
							}
							myOwnerControl.DrawButtonBorder(myGraph, myButton.Bounds, num6);
							break;
						}
						case ZYToolBarButtonStyle.Spliter:
							if (myOwnerControl.FloatStyle)
							{
								int num = myButton.Bounds.X + 1;
								int num2 = myButton.Bounds.Y + 2;
								int num3 = myButton.Bounds.Height - 4;
								myGraph.DrawLine(SystemPens.ControlDark, num, num2, num, num2 + num3);
								myGraph.DrawLine(SystemPens.ControlLightLight, num + 1, num2, num + 1, num2 + num3);
							}
							break;
						case ZYToolBarButtonStyle.TextPanel:
						{
							myOwnerControl.DrawButtonBorder(myGraph, myButton.Bounds, 0);
							RectangleF empty = RectangleF.Empty;
							empty.Y = (float)myButton.Bounds.Top + ((float)myButton.Bounds.Height - myOwnerControl.Font.GetHeight()) / 2f;
							empty.Height = myOwnerControl.Font.GetHeight();
							empty.Width = myButton.Bounds.Width;
							empty.X = myButton.Bounds.Left;
							myGraph.DrawString(myButton.Text, myOwnerControl.Font, SystemBrushes.WindowText, empty);
							break;
						}
						}
					}
				}
				if (myOwnerControl.BorderStyle == BorderStyle.Fixed3D)
				{
					myOwnerControl.DrawButtonBorder(myGraph, Bounds, 1);
				}
				if (myOwnerControl.BorderStyle == BorderStyle.FixedSingle)
				{
					ControlPaint.DrawButton(myGraph, Bounds, ButtonState.Flat);
				}
			}

			public void RefreshButton(Graphics myGraph)
			{
				int num = myOwnerControl.LeftMargin;
				int num2 = intTop + 1;
				int num3 = 0;
				int num4 = intHeight - 2;
				foreach (ZYToolBarButton myButton in myButtons)
				{
					myButton.OwnerToolBar = this;
					if (myButton.Visible)
					{
						switch (myButton.Style)
						{
						case ZYToolBarButtonStyle.Button:
						case ZYToolBarButtonStyle.PushButton:
							if (myButton.AutoSize)
							{
								num3 = 2;
								if (myOwnerControl.ShowIcon && myOwnerControl.ImageList != null && myButton.ImageListIndex >= 0 && myButton.ImageListIndex < myOwnerControl.ImageList.Images.Count)
								{
									myButton.ButtonImage = myOwnerControl.ImageList.Images[myButton.ImageListIndex];
								}
								if (myOwnerControl.ShowIcon && myButton.ButtonImage != null)
								{
									num3 += myButton.ButtonImage.Size.Width + 2;
								}
								if (myOwnerControl.ShowText)
								{
									num3 += (int)myGraph.MeasureString(myButton.Text, myOwnerControl.Font).Width;
									num3 += 3;
								}
								myButton.Width = num3;
							}
							else
							{
								num3 = myButton.Width;
							}
							break;
						case ZYToolBarButtonStyle.DropDownList:
						{
							ComboBox comboBox = myButton.InnerControl as ComboBox;
							if (comboBox == null)
							{
								comboBox = (ComboBox)(myButton.InnerControl = new ComboBox());
								comboBox.SelectedIndexChanged += myOwnerControl.ButtonTextChanged;
							}
							comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
							comboBox.MaxDropDownItems = 30;
							comboBox.Font = myOwnerControl.Font;
							if (myButton.AutoSize)
							{
								int num5 = 100;
								for (int i = 0; i < comboBox.Items.Count; i++)
								{
									SizeF sizeF = myGraph.MeasureString(comboBox.Items[i].ToString(), myOwnerControl.Font);
									if (sizeF.Width + 18f > (float)num5)
									{
										num5 = (int)(sizeF.Width + 18f);
									}
								}
								myButton.Width = num5;
							}
							num3 = myButton.Width;
							break;
						}
						case ZYToolBarButtonStyle.Spliter:
							num3 = 4;
							break;
						case ZYToolBarButtonStyle.TextBox:
							if (!(myButton.InnerControl is TextBox))
							{
								TextBox textBox = new TextBox();
								textBox.Width = 100;
								myButton.InnerControl = textBox;
								textBox.Leave += myOwnerControl.ButtonTextChanged;
							}
							myButton.Width = myButton.InnerControl.Width;
							num3 = myButton.Width;
							break;
						case ZYToolBarButtonStyle.TextPanel:
							if (myButton.AutoSize)
							{
								myButton.Width = (int)myGraph.MeasureString(myButton.Text, myOwnerControl.Font).Width + 3;
							}
							num3 = myButton.Width;
							break;
						case ZYToolBarButtonStyle.CustomControl:
							myButton.AutoSize = false;
							num3 = ((myButton.InnerControl == null) ? myButton.Width : (myButton.InnerControl.Width + 2));
							break;
						}
						if (myButton.InnerControl != null)
						{
							myOwnerControl.Controls.Add(myButton.InnerControl);
							myButton.InnerControl.Bounds = new Rectangle(num + 1, num2 + 1, num3 - 2, num4 - 2);
							myButton.InnerControl.Top += (num4 - myButton.InnerControl.Height) / 2;
							myButton.Text = myButton.Text;
						}
						myButton.Bounds = new Rectangle(num, num2, num3, num4);
						num += num3;
					}
				}
			}
		}

		private ArrayList myBars = new ArrayList();

		private ArrayList myButtons = new ArrayList();

		private ImageList myImageList = new ImageList();

		private ToolTip myTip = new ToolTip();

		private BorderStyle intBorderStyle = BorderStyle.Fixed3D;

		internal ZYToolBarButton CurrentHoverButton = null;

		private bool bolFloatStyle = true;

		private int intLeftMargin = 5;

		private bool bolShowText = true;

		private bool bolShowIcon = true;

		private bool bolBarBorder = true;

		internal EventHandler ButtonTextChanged = null;

		private string strOldButtonsStatus = null;

		public bool BarBorder
		{
			get
			{
				return bolBarBorder;
			}
			set
			{
				bolBarBorder = value;
			}
		}

		public bool ShowIcon
		{
			get
			{
				return bolShowIcon;
			}
			set
			{
				bolShowIcon = value;
			}
		}

		public bool ShowText
		{
			get
			{
				return bolShowText;
			}
			set
			{
				bolShowText = value;
			}
		}

		public BorderStyle BorderStyle
		{
			get
			{
				return intBorderStyle;
			}
			set
			{
				intBorderStyle = value;
			}
		}

		public ArrayList Bars
		{
			get
			{
				return myBars;
			}
			set
			{
				myBars = value;
			}
		}

		public int LeftMargin
		{
			get
			{
				return intLeftMargin;
			}
			set
			{
				intLeftMargin = value;
			}
		}

		public bool FloatStyle
		{
			get
			{
				return bolFloatStyle;
			}
			set
			{
				bolFloatStyle = value;
			}
		}

		public ImageList ImageList
		{
			get
			{
				return myImageList;
			}
			set
			{
				myImageList = value;
			}
		}

		public ArrayList Buttons => myButtons;

		public event PaintButtonHandler OnPaintButton = null;

		public event ButtonClickHandler OnButtonClick = null;

		public event ButtonTextChangedHandler OnButtonTextChanged = null;

		public ZYToolBarGroup()
		{
			ButtonTextChanged = InnerControl_TextChanged;
		}

		public ZYToolBar GetBar(int index)
		{
			if (index >= 0 && index < myBars.Count)
			{
				return (ZYToolBar)myBars[index];
			}
			return null;
		}

		public ZYToolBar GetBar(string strName)
		{
			foreach (ZYToolBar myBar in myBars)
			{
				if (myBar.Name == strName)
				{
					return myBar;
				}
			}
			return null;
		}

		public ZYToolBar AddBar(string strName)
		{
			ZYToolBar zYToolBar = new ZYToolBar();
			myBars.Add(zYToolBar);
			zYToolBar.Name = strName;
			zYToolBar.OwnerControl = this;
			return zYToolBar;
		}

		public void RemoveBar(string strName)
		{
			ZYToolBar bar = GetBar(strName);
			if (bar != null)
			{
				myBars.Remove(bar);
			}
		}

		public void RemoveBar(int index)
		{
			if (index >= 0 && index < myBars.Count)
			{
				myBars.RemoveAt(index);
			}
		}

		public void Clear()
		{
			myBars.Clear();
			myButtons.Clear();
			base.Controls.Clear();
		}

		public string GetButtonsStatus()
		{
			ArrayList allButtons = GetAllButtons();
			StringBuilder stringBuilder = new StringBuilder();
			foreach (ZYToolBarButton item in allButtons)
			{
				stringBuilder.Append(item.Visible ? "1" : "0");
				stringBuilder.Append(item.Pushed ? "1" : "0");
				stringBuilder.Append(item.Enable ? "1" : "0");
				stringBuilder.Append(item.Text);
			}
			return stringBuilder.ToString();
		}

		public void CheckButtonsStatus()
		{
			string buttonsStatus = GetButtonsStatus();
			if (buttonsStatus != strOldButtonsStatus)
			{
				Refresh();
				strOldButtonsStatus = buttonsStatus;
			}
		}

		public ArrayList GetAllButtons()
		{
			ArrayList arrayList = new ArrayList();
			foreach (ZYToolBar myBar in myBars)
			{
				foreach (ZYToolBarButton button in myBar.Buttons)
				{
					arrayList.Add(button);
				}
			}
			return arrayList;
		}

		public ZYToolBarButton GetButton(string Command, bool OnlyVisible)
		{
			foreach (ZYToolBar myBar in myBars)
			{
				foreach (ZYToolBarButton button in myBar.Buttons)
				{
					if (button.Command == Command && (!OnlyVisible || button.Visible))
					{
						return button;
					}
				}
			}
			return null;
		}

		public ZYToolBarButton GetButton(string Command)
		{
			return GetButton(Command, OnlyVisible: true);
		}

		private void InnerControl_TextChanged(object sender, EventArgs e)
		{
			if (sender != null)
			{
				foreach (ZYToolBar myBar in myBars)
				{
					foreach (ZYToolBarButton button in myBar.Buttons)
					{
						if (button.InnerControl == sender)
						{
							if (this.OnButtonTextChanged != null)
							{
								this.OnButtonTextChanged(button.InnerControl.Text, button);
							}
							if (button.Action != null && !button.SettingText)
							{
								button.Action.SetText(button.InnerControl.Text);
								button.Action.UIExecute();
							}
							return;
						}
					}
				}
			}
		}

		protected override void OnResize(EventArgs e)
		{
			foreach (ZYToolBar myBar in myBars)
			{
				myBar.Width = base.ClientSize.Width;
			}
			Refresh();
			base.OnResize(e);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			foreach (ZYToolBar myBar in myBars)
			{
				if (myBar.Visible && myBar.Bounds.IntersectsWith(e.ClipRectangle))
				{
					myBar.DrawToolBar(e.Graphics, e.ClipRectangle);
				}
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			foreach (ZYToolBarButton myButton in myButtons)
			{
				if (myButton.Visible && myButton.Enable && myButton.Bounds.Contains(e.X, e.Y))
				{
					if (myButton != CurrentHoverButton)
					{
						if (CurrentHoverButton != null)
						{
							Invalidate(CurrentHoverButton.Bounds, invalidateChildren: false);
						}
						SetCurrentHoverButton(myButton);
						Invalidate(myButton.Bounds, invalidateChildren: false);
					}
					return;
				}
			}
			if (CurrentHoverButton != null)
			{
				if (base.Capture)
				{
					CurrentHoverButton.Pushed = false;
				}
				Invalidate(CurrentHoverButton.Bounds, invalidateChildren: false);
				SetCurrentHoverButton(null);
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (CurrentHoverButton == null)
			{
				return;
			}
			CurrentHoverButton.Pushed = true;
			Invalidate(CurrentHoverButton.Bounds, invalidateChildren: false);
			Update();
			if (this.OnButtonClick != null)
			{
				this.OnButtonClick(CurrentHoverButton.Command, CurrentHoverButton);
			}
			if (CurrentHoverButton == null)
			{
				return;
			}
			if (CurrentHoverButton.Click != null)
			{
				CurrentHoverButton.Click(CurrentHoverButton.Command, CurrentHoverButton);
			}
			if (CurrentHoverButton == null || CurrentHoverButton.Action == null)
			{
				return;
			}
			if (CurrentHoverButton.Style == ZYToolBarButtonStyle.PushButton)
			{
				CurrentHoverButton.Action.SetText(CurrentHoverButton.Pushed ? "0" : "1");
				CurrentHoverButton.Action.UIExecute();
				int num = CurrentHoverButton.Action.CheckState();
				if (num == -1)
				{
					CurrentHoverButton.Pushed = !CurrentHoverButton.Pushed;
				}
				else
				{
					CurrentHoverButton.Pushed = (CurrentHoverButton.Action.CheckState() == 1);
				}
			}
			else
			{
				CurrentHoverButton.Action.SetText(CurrentHoverButton.Text);
				CurrentHoverButton.Action.UIExecute();
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (CurrentHoverButton != null)
			{
				CurrentHoverButton.Pushed = false;
				Invalidate(CurrentHoverButton.Bounds, invalidateChildren: false);
			}
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			if (CurrentHoverButton != null)
			{
				CurrentHoverButton.Pushed = false;
				Rectangle bounds = CurrentHoverButton.Bounds;
				CurrentHoverButton = null;
				Invalidate(bounds, invalidateChildren: true);
			}
		}

		private void SetCurrentHoverButton(ZYToolBarButton btn)
		{
			if (!(btn?.Visible ?? false))
			{
				myTip.SetToolTip(this, null);
				CurrentHoverButton = null;
				return;
			}
			if (btn.ToolTip == null || btn.ToolTip.Length == 0)
			{
				myTip.SetToolTip(this, btn.Text);
			}
			else
			{
				myTip.SetToolTip(this, btn.ToolTip);
			}
			CurrentHoverButton = btn;
		}

		public void RefreshButton()
		{
			int num = intLeftMargin;
			int num2 = 0;
			int num3 = base.ClientSize.Height - 2;
			if (intBorderStyle != 0)
			{
				num2 = 2;
				num3 = base.ClientSize.Height - 4;
			}
			base.Controls.Clear();
			myButtons.Clear();
			using (Graphics myGraph = CreateGraphics())
			{
				foreach (ZYToolBar myBar in myBars)
				{
					myBar.Left = 0;
					myBar.Top = num2;
					myBar.Width = base.ClientSize.Width;
					if (myBar.Visible)
					{
						myBar.RefreshButton(myGraph);
						myButtons.AddRange(myBar.GetVisibleButtons());
						num2 += myBar.Height;
						myBar.Width = base.ClientSize.Width;
					}
				}
			}
			base.Height = num2 + 2;
		}

		private void DrawButtonBorder(Graphics g, Rectangle rect, int Style)
		{
			if (g == null)
			{
				return;
			}
			rect.Height--;
			rect.Width--;
			switch (Style)
			{
			case 0:
				if (!bolFloatStyle)
				{
					g.DrawLine(SystemPens.ControlLightLight, rect.Left, rect.Top, rect.Right, rect.Top);
					g.DrawLine(SystemPens.ControlLightLight, rect.Left, rect.Top, rect.Left, rect.Bottom);
					g.DrawLine(SystemPens.ControlDark, rect.Right, rect.Top, rect.Right, rect.Bottom);
					g.DrawLine(SystemPens.ControlDark, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
				}
				break;
			case 1:
				g.DrawLine(SystemPens.ControlLightLight, rect.Left, rect.Top, rect.Right, rect.Top);
				g.DrawLine(SystemPens.ControlLightLight, rect.Left, rect.Top, rect.Left, rect.Bottom);
				g.DrawLine(SystemPens.ControlDark, rect.Right, rect.Top, rect.Right, rect.Bottom);
				g.DrawLine(SystemPens.ControlDark, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
				break;
			case 2:
				g.DrawLine(SystemPens.ControlDark, rect.Left, rect.Top, rect.Right, rect.Top);
				g.DrawLine(SystemPens.ControlDark, rect.Left, rect.Top, rect.Left, rect.Bottom);
				g.DrawLine(SystemPens.ControlLightLight, rect.Right, rect.Top, rect.Right, rect.Bottom);
				g.DrawLine(SystemPens.ControlLightLight, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
				break;
			}
		}

		public int FromXML(XmlElement RootElement, string strPicPath)
		{
			ZYToolBarButton zYToolBarButton = null;
			if (strPicPath != null)
			{
				strPicPath = strPicPath.Trim();
				if (!strPicPath.EndsWith("\\"))
				{
					strPicPath += "\\";
				}
			}
			foreach (XmlNode childNode in RootElement.ChildNodes)
			{
				XmlElement xmlElement = childNode as XmlElement;
				if (xmlElement != null)
				{
					ZYToolBar zYToolBar = AddBar(xmlElement.GetAttribute("name"));
					foreach (XmlNode childNode2 in xmlElement.ChildNodes)
					{
						XmlElement xmlElement2 = childNode2 as XmlElement;
						if (xmlElement2 != null)
						{
							switch (xmlElement2.Name)
							{
							case "select":
							{
								zYToolBarButton = zYToolBar.AddButton(null);
								zYToolBarButton.Command = xmlElement2.GetAttribute("command");
								zYToolBarButton.Style = ZYToolBarButtonStyle.DropDownList;
								ComboBox comboBox = (ComboBox)(zYToolBarButton.InnerControl = new ComboBox());
								comboBox.SelectedIndexChanged += ButtonTextChanged;
								foreach (XmlNode childNode3 in xmlElement2.ChildNodes)
								{
									if (childNode3.Name == "option")
									{
										if (childNode3.Attributes["value"] == null)
										{
											comboBox.Items.Add(childNode3.InnerText);
										}
										else if (childNode3.Attributes["value"].Value.ToString() == childNode3.InnerText)
										{
											comboBox.Items.Add(childNode3.InnerText);
										}
										else
										{
											comboBox.Items.Add(childNode3.Attributes["value"].Value.ToString() + "." + childNode3.InnerText);
										}
									}
								}
								break;
							}
							case "textbox":
							{
								if (xmlElement2.HasAttribute("title"))
								{
									zYToolBarButton = zYToolBar.AddButton(xmlElement2.GetAttribute("title"));
									zYToolBarButton.Style = ZYToolBarButtonStyle.TextPanel;
									zYToolBarButton.Command = "title_" + xmlElement2.GetAttribute("command");
								}
								zYToolBarButton = zYToolBar.AddButton(null);
								zYToolBarButton.Command = xmlElement2.GetAttribute("command");
								zYToolBarButton.Style = ZYToolBarButtonStyle.TextBox;
								TextBox textBox = (TextBox)(zYToolBarButton.InnerControl = new TextBox());
								textBox.Leave += ButtonTextChanged;
								break;
							}
							case "text":
								zYToolBarButton = zYToolBar.AddButton(xmlElement2.GetAttribute("text"));
								zYToolBarButton.Style = ZYToolBarButtonStyle.TextPanel;
								break;
							case "spliter":
								zYToolBarButton = zYToolBar.AddButton(null);
								zYToolBarButton.Style = ZYToolBarButtonStyle.Spliter;
								break;
							case "pushbutton":
							case "button":
								zYToolBarButton = zYToolBar.AddButton(xmlElement2.GetAttribute("text"));
								if (xmlElement2.Name == "pushbutton")
								{
									zYToolBarButton.Style = ZYToolBarButtonStyle.PushButton;
								}
								zYToolBarButton.Command = xmlElement2.GetAttribute("command");
								if (xmlElement2.GetAttribute("style") == "spliter")
								{
									zYToolBarButton.Style = ZYToolBarButtonStyle.Spliter;
								}
								if (xmlElement2.HasAttribute("image"))
								{
									string text = Path.Combine(strPicPath, xmlElement2.GetAttribute("image"));
									if (text.StartsWith("http"))
									{
										using (WebClient webClient = new WebClient())
										{
											MemoryStream stream = new MemoryStream(webClient.DownloadData(text));
											zYToolBarButton.ButtonImage = Image.FromStream(stream);
										}
									}
									else if (File.Exists(text))
									{
										zYToolBarButton.ButtonImage = Image.FromFile(text);
									}
								}
								break;
							}
						}
					}
				}
			}
			RefreshButton();
			Refresh();
			return 0;
		}

		protected override void Dispose(bool disposing)
		{
			myImageList.Dispose();
			myTip.Dispose();
			base.Dispose(disposing);
		}
	}
}
