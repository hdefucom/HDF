using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ZYTextDiv : ZYTextContainer
	{
		private bool bolExpended = true;

		private string strTitle = null;

		private Rectangle BoxRect = Rectangle.Empty;

		private string strToolTip = null;

		public override bool Locked
		{
			get
			{
				if (myOwnerDocument.Loading)
				{
					return false;
				}
				if (myOwnerDocument.Locked)
				{
					return true;
				}
				if (NoContent && !myOwnerDocument.Info.DesignMode)
				{
					return true;
				}
				return false;
			}
			set
			{
				base.Locked = value;
			}
		}

		public bool NoContent
		{
			get
			{
				return myAttributes.GetBool("nocontent");
			}
			set
			{
				myAttributes.SetValue("nocontent", value);
			}
		}

		public override int Left
		{
			get
			{
				return 0;
			}
			set
			{
				if (myParent == null)
				{
					intLeft = value;
				}
				else
				{
					intLeft = 0;
				}
			}
		}

		public bool Expanded
		{
			get
			{
				return bolExpended;
			}
			set
			{
				if (bolExpended != value)
				{
					bolExpended = value;
					if (!bolExpended)
					{
						strTitle = ToEMRString();
					}
				}
			}
		}

		public override int Height
		{
			get
			{
				if (bolExpended)
				{
					return base.Height;
				}
				return myOwnerDocument.DefaultRowHeight;
			}
		}

		public override int Width
		{
			get
			{
				if (myParent == null)
				{
					return myOwnerDocument.Pages.StandardWidth;
				}
				return myParent.Width - Left;
			}
			set
			{
				base.Width = value;
			}
		}

		public static ZYTextDiv GetOwnerDiv(ZYTextElement myElement)
		{
			ZYTextDiv zYTextDiv = null;
			while (myElement != null)
			{
				zYTextDiv = (myElement as ZYTextDiv);
				if (zYTextDiv == null)
				{
					myElement = myElement.Parent;
					continue;
				}
				return zYTextDiv;
			}
			return zYTextDiv;
		}

		public override void GetFinalText(StringBuilder myStr)
		{
			if (!StringCommon.isBlankString(base.Title))
			{
				myStr.Append(base.Title);
				myStr.Append(' ');
			}
			base.GetFinalText(myStr);
		}

		public override string ToEMRString()
		{
			if (!StringCommon.isBlankString(base.Title))
			{
				return base.Title + base.ToEMRString();
			}
			return base.ToEMRString();
		}

		protected override SizeF GetTitleSize()
		{
			string title = base.Title;
			if (base.HideTitle || StringCommon.isBlankString(title))
			{
				return new SizeF(0f, 0f);
			}
			using (Font myFont = new Font(base.FontName, base.FontSize + 2f, FontStyle.Bold))
			{
				SizeF result = myOwnerDocument.View.MeasureString(title, myFont);
				result.Width += 8f;
				if (base.TitleLine)
				{
					result.Width = 0f;
				}
				return result;
			}
		}

		protected SizeF GetRealTitleSize()
		{
			string title = base.Title;
			if (base.HideTitle || StringCommon.isBlankString(title))
			{
				return new SizeF(0f, 0f);
			}
			using (Font myFont = new Font(base.FontName, base.FontSize + 2f, FontStyle.Bold))
			{
				return myOwnerDocument.View.MeasureString(title, myFont);
			}
		}

		public ZYTextDiv()
		{
			base.ID = StringCommon.AllocObjectName();
		}

		public override string GetXMLName()
		{
			return "div";
		}

		public override bool OwnerWholeLine()
		{
			return true;
		}

		public override bool isNewLine()
		{
			return true;
		}

		public override bool isNewParagraph()
		{
			return true;
		}

		public override bool isField()
		{
			return true;
		}

		public override bool isTextElement()
		{
			return !bolExpended;
		}

		public override Rectangle GetContentBounds()
		{
			ResetBoxRect();
			Rectangle result = new Rectangle(RealLeft, RealTop, intClientWidth, Height);
			int num = result.Left - BoxRect.Left;
			result.X -= num;
			result.Width += num;
			return result;
		}

		private void ResetBoxRect()
		{
			BoxRect = myOwnerDocument.View.GetExpendHandleRect(RealLeft, RealTop, myOwnerDocument.DefaultRowHeight);
		}

		public override bool RefreshView()
		{
			int realLeft = RealLeft;
			int realTop = RealTop;
			int y = RealTop;
			if (base.Lines.Count > 0)
			{
				ZYTextLine zYTextLine = base.Lines[0] as ZYTextLine;
				y = ((!(base.TitleSize.Height < (float)zYTextLine.Height)) ? (RealTop + (int)base.FontSize * 2 / 3) : (RealTop + zYTextLine.Height - (int)base.TitleSize.Height));
			}
			ResetBoxRect();
			if (bolExpended)
			{
				base.RefreshView();
				if (!base.HideTitle && !StringCommon.isBlankString(base.Title))
				{
					Font myFont = myOwnerDocument.View._CreateFont(base.FontName, base.FontSize, Bold: true, Italic: false, UnderLine: false);
					int intClientWidth = base.intClientWidth;
					switch (base.TitleAlign)
					{
					case "right":
						myOwnerDocument.View.DrawString(base.Title, myFont, SystemColors.WindowText, (int)((float)intClientWidth - GetRealTitleSize().Width) + realLeft, y);
						break;
					case "center":
						myOwnerDocument.View.DrawString(base.Title, myFont, SystemColors.WindowText, (int)((float)intClientWidth - GetRealTitleSize().Width) / 2 + realLeft, y);
						break;
					case "tab":
						myOwnerDocument.View.DrawString(base.Title, myFont, SystemColors.WindowText, (int)base.indentWidth + realLeft, y);
						break;
					default:
						myOwnerDocument.View.DrawString(base.Title, myFont, SystemColors.WindowText, realLeft, y);
						break;
					}
				}
				if (myOwnerDocument.Info.ShowExpendHandle)
				{
					if (myParent == null)
					{
						myOwnerDocument.View.FillRectangle(Color.Blue, BoxRect);
					}
					else
					{
						myOwnerDocument.View.DrawExpendHandle(realLeft, realTop, myOwnerDocument.DefaultRowHeight, bolExpended: true);
					}
					if (myLines.Count > 1)
					{
						myOwnerDocument.View.DrawLine(SystemColors.Control, realLeft, realTop, realLeft, realTop + Height);
						myOwnerDocument.View.DrawLine(SystemColors.Control, realLeft, realTop + Height, realLeft + 8, realTop + Height);
					}
				}
				else if (myParent != null && myLines.Count > 1 && !myOwnerDocument.Info.Printing)
				{
					Color skyBlue = Color.SkyBlue;
					myOwnerDocument.View.DrawLine(skyBlue, realLeft, realTop, realLeft + 8, realTop);
					myOwnerDocument.View.DrawLine(skyBlue, realLeft, realTop, realLeft, realTop + Height);
					myOwnerDocument.View.DrawLine(skyBlue, realLeft, realTop + Height, realLeft + 8, realTop + Height);
				}
			}
			else
			{
				if (myOwnerDocument.Info.ShowExpendHandle)
				{
					myOwnerDocument.View.DrawExpendHandle(realLeft, realTop, myOwnerDocument.DefaultRowHeight, bolExpended: false);
				}
				SizeF titleSize = GetTitleSize();
				Rectangle vRect = new Rectangle(realLeft + (int)titleSize.Width, realTop, Width - (int)titleSize.Width - 3, (int)myOwnerDocument.View.DefaultFont.GetHeight());
				if (!base.HideTitle && !StringCommon.isBlankString(base.Title))
				{
					Font myFont = myOwnerDocument.View._CreateFont("仿宋_GB2312", 12f, Bold: true, Italic: false, UnderLine: false);
					myOwnerDocument.View.DrawString(base.Title, myFont, myOwnerDocument.isSelected(this) ? SystemColors.HighlightText : SystemColors.WindowText, realLeft, realTop);
				}
				myOwnerDocument.View.DrawFillRectangle(SystemColors.ControlDarkDark, Color.White, vRect);
				myOwnerDocument.View.DrawSingleLine(strTitle, SystemColors.ControlDark, vRect.Left, vRect.Top, vRect.Width);
			}
			return true;
		}

		public override void RefreshLine()
		{
			ResetBoxRect();
			if (bolExpended)
			{
				base.RefreshLine();
			}
			else if (myParent != null)
			{
				strToolTip = base.ToEMRString();
				strTitle = StringCommon.ClearWhiteSpace(strToolTip, 100, bolHtml: true);
				strToolTip = StringCommon.ClearBlankLine(strToolTip);
				strToolTip = strToolTip.Replace("\t", "    ");
				if (strToolTip.Length > 1024)
				{
					strToolTip = strToolTip.Substring(0, 1024);
				}
			}
		}

		public override void AddElementToList(List<ZYTextElement> myList, bool ResetFlag)
		{
			if (bolExpended)
			{
				if (!NoContent || myOwnerDocument.Info.DesignMode)
				{
					base.AddElementToList(myList, ResetFlag);
				}
				else if (myList != null)
				{
					foreach (ZYTextElement myChildElement in myChildElements)
					{
						if (ResetFlag)
						{
							myChildElement.Visible = false;
							myChildElement.Index = -1;
						}
						if (myOwnerDocument.isVisible(myChildElement) && myChildElement is ZYTextDiv)
						{
							myChildElement.Visible = true;
							(myChildElement as ZYTextDiv).AddElementToList(myList, ResetFlag);
						}
					}
				}
			}
			else
			{
				myList.Add(this);
			}
		}

		public override bool HandleClick(int x, int y, MouseButtons Button)
		{
			if (!bolExpended)
			{
				return false;
			}
			return base.HandleClick(x, y, Button);
		}

		public override bool HandleMouseDown(int x, int y, MouseButtons Button)
		{
			if (BoxRect.Contains(x, y) && myParent != null && myLines.Count > 1)
			{
				myOwnerDocument.BeginUpdate();
				bolExpended = !bolExpended;
				RefreshSize();
				myOwnerDocument.RefreshElements();
				myOwnerDocument.RefreshLine();
				myOwnerDocument.Content.AutoClearSelection = true;
				myOwnerDocument.Content.MoveSelectStart((ZYTextElement)(bolExpended ? myChildElements[0] : this));
				myOwnerDocument.EndUpdate();
				myOwnerDocument.Refresh();
				return true;
			}
			if (!bolExpended)
			{
				return false;
			}
			return base.HandleMouseDown(x, y, Button);
		}

		public override bool HandleMouseMove(int x, int y, MouseButtons Button)
		{
			if (myParent != null)
			{
				if (BoxRect.Contains(x, y))
				{
					myOwnerDocument.SetCursor(Cursors.Arrow);
					myOwnerDocument.SetToolTip(bolExpended ? "收缩文本块" : "展开文本块", -1, BoxRect);
					return true;
				}
				if (!bolExpended)
				{
					if (Bounds.Contains(x, y))
					{
						myOwnerDocument.SetToolTip(strToolTip, -1, Bounds);
						return true;
					}
					return false;
				}
			}
			return base.HandleMouseMove(x, y, Button);
		}

		public override string ToString()
		{
			return "ZYTextDiv Name:" + myAttributes.GetString("name") + " Childs:" + myChildElements.Count + " [" + RealLeft + "-:" + RealTop + " " + Width + "-" + Height;
		}
	}
}
