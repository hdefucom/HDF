using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ZYTextBox : ZYTextBlock
	{
		public class EMRTextInputEnd : ZYTextElement
		{
			internal string LastTitle = null;

			public ZYTextBox OwnerTextBox
			{
				get
				{
					return (ZYTextBox)myParent;
				}
				set
				{
					myParent = value;
				}
			}

			public override void HandleEnter()
			{
				myOwnerDocument.RefreshElement(myParent);
			}

			public override void HandleLeave()
			{
				myOwnerDocument.RefreshElement(myParent);
			}

			public void UpdateTitle()
			{
				LastTitle = GetTitle();
			}

			public string GetTitle()
			{
				return "";
			}

			public override bool RefreshSize()
			{
				if (LastTitle != null)
				{
					base.Width = 5 + (int)myOwnerDocument.View.MeasureString(LastTitle, null).Width;
				}
				else
				{
					base.Width = 5;
				}
				base.Height = myOwnerDocument.DefaultRowHeight;
				return true;
			}

			public override bool RefreshView()
			{
				return true;
			}

			public override string ToEMRString()
			{
				return "";
			}
		}

		private StringDataFormat myFormat = new StringDataFormat();

		private bool bolValueFormatCheck = true;

		public string Align
		{
			get
			{
				return myAttributes.GetString("textalign");
			}
			set
			{
				myAttributes.SetValue("textalign", value);
			}
		}

		public override int Width
		{
			get
			{
				return 500;
			}
			set
			{
				intWidth = value;
			}
		}

		public bool leftborder
		{
			get
			{
				return myAttributes.GetBool("leftborder");
			}
			set
			{
				myAttributes.SetValue("leftborder", value);
			}
		}

		public bool bottomborder
		{
			get
			{
				return myAttributes.GetBool("bottomborder");
			}
			set
			{
				myAttributes.SetValue("leftborder", value);
			}
		}

		public bool rightborder
		{
			get
			{
				return myAttributes.GetBool("rightborder");
			}
			set
			{
				myAttributes.SetValue("rightborder", value);
			}
		}

		public bool topborder
		{
			get
			{
				return myAttributes.GetBool("topborder");
			}
			set
			{
				myAttributes.SetValue("topborder", value);
			}
		}

		internal EMRTextInputEnd InputEnd => (EMRTextInputEnd)myLastElement;

		public StringDataFormat Format
		{
			get
			{
				return myFormat;
			}
			set
			{
				myFormat = value;
			}
		}

		public override bool EnableTypeSet => true;

		public string Text
		{
			get
			{
				return ToEMRString();
			}
			set
			{
				ArrayList arrayList = new ArrayList();
				arrayList = myOwnerDocument.CreateChars(value, this);
				if (arrayList != null)
				{
					myChildElements.Clear();
					myChildElements.AddRange(arrayList);
					AddLastElement();
					myOwnerDocument.ElementsDirty = true;
					RefreshSize();
					OnChildElementsChange();
				}
			}
		}

		public override bool CanBeLineEnd()
		{
			return false;
		}

		public override void UpdateAttrubute()
		{
		}

		protected override void OnChildElementsChange()
		{
			EMRTextInputEnd eMRTextInputEnd = (EMRTextInputEnd)myLastElement;
			bolValueFormatCheck = TestValueFormat();
			string title = eMRTextInputEnd.GetTitle();
			if (title != eMRTextInputEnd.LastTitle)
			{
				if (StringCommon.isBlankString(title))
				{
					eMRTextInputEnd.LastTitle = null;
				}
				else
				{
					eMRTextInputEnd.LastTitle = title.Trim();
				}
				RefreshSize();
				myOwnerDocument.RefreshElement(this);
			}
			base.RaiseOnChangeEvent();
			myOwnerDocument.ElementsDirty = true;
		}

		public bool TestValueFormat()
		{
			bolValueFormatCheck = myFormat.Test(ToEMRString());
			return bolValueFormatCheck;
		}

		public override string GetXMLName()
		{
			return "textbox";
		}

		public override bool isField()
		{
			return true;
		}

		protected override void AddLastElement()
		{
			if (!myChildElements.Contains(myLastElement))
			{
				myChildElements.Add(myLastElement);
			}
		}

		public override void ResetViewState()
		{
			bolStandOutBack = false;
			if (myOwnerDocument.Content.SelectLength == 0 && (myChildElements.Contains(myOwnerDocument.Content.CurrentElement) || myOwnerDocument.CurrentHoverElement == this))
			{
				bolStandOutBack = true;
			}
		}

		public override bool RefreshSize()
		{
			int num = 0;
			int num2 = 0;
			myLastElement.RefreshSize();
			foreach (ZYTextElement myChildElement in myChildElements)
			{
				if (myChildElement.Visible)
				{
					myChildElement.RefreshSize();
					num += myChildElement.Width;
					if (num2 < myChildElement.Height)
					{
						num2 = myChildElement.Height;
					}
				}
			}
			if (num2 < myOwnerDocument.DefaultRowHeight)
			{
				num2 = myOwnerDocument.DefaultRowHeight;
			}
			if (num < 50)
			{
				num = 50;
			}
			Height = num2;
			Width = 500;
			return true;
		}

		public override void UpdateBounds()
		{
			Width = 500;
		}

		public override bool HandleDblClick(int x, int y, MouseButtons Button)
		{
			if (Contains(x, y))
			{
				if (myChildElements.Count > 1)
				{
					myOwnerDocument.Content.SetSelection(myOwnerDocument.IndexOf((ZYTextElement)myChildElements[0]), myChildElements.Count - 1);
				}
				return true;
			}
			return false;
		}

		public override bool HandleMouseMove(int x, int y, MouseButtons Button)
		{
			if (Contains(x, y))
			{
				string text = "数据域 " + base.ID;
				if (!bolValueFormatCheck)
				{
					text = text + "\r\n该栏目数据" + myFormat.LastTestResult;
				}
				myOwnerDocument.SetToolTip(text, -1, Bounds);
				myOwnerDocument.CurrentHoverElement = this;
				return true;
			}
			return false;
		}

		public override bool HandleClick(int x, int y, MouseButtons Button)
		{
			if (Contains(x, y) && myChildElements.Count == 1)
			{
				myOwnerDocument.Content.AutoClearSelection = true;
				myOwnerDocument.Content.MoveSelectStart(myChildElements[0] as ZYTextElement);
				return true;
			}
			return false;
		}

		public override bool RefreshView()
		{
			return true;
		}

		public override void DrawBackGround(ZYTextElement myElement)
		{
			if (bolStandOutBack && !myOwnerDocument.Info.Printing)
			{
				Rectangle vRect = new Rectangle(myElement.RealLeft, myElement.OwnerLine.RealTop, myElement.Width + myElement.WidthFix, myElement.OwnerLine.Height);
				if (!bolValueFormatCheck)
				{
					myOwnerDocument.View.FillRectangle(Color.Salmon, vRect);
				}
				else
				{
					myOwnerDocument.View.FillRectangle(Color.LightGray, vRect);
				}
			}
			if (bottomborder)
			{
				myOwnerDocument.View.DrawLine(SystemPens.InfoText, myElement.Bounds.Left, myElement.Bounds.Bottom - 1, myElement.Bounds.Right, myElement.Bounds.Bottom - 1);
			}
		}

		public override bool FromXML(XmlElement myElement)
		{
			if (BaseFromXML(myElement))
			{
				myFormat.Clear();
				XmlElement xmlElement = XMLCommon.CreateChildElement(myElement, "format", bolCreate: false);
				if (xmlElement != null)
				{
					myFormat.FromXML(xmlElement);
				}
				myChildElements.Clear();
				string text = null;
				text = ((!StringCommon.HasContent(base.ValueSource) || !myOwnerDocument.Variables.Contains(base.ValueSource)) ? myElement.InnerText : myOwnerDocument.Variables.GetValue(base.ValueSource));
				if (text != null)
				{
					for (int i = 0; i < text.Length; i++)
					{
						if (text[i] != '\r' || text[i] != '\n')
						{
							ZYTextChar zYTextChar = ZYTextChar.Create(text[i]);
							zYTextChar.OwnerDocument = myOwnerDocument;
							zYTextChar.Parent = this;
							myChildElements.Add(zYTextChar);
						}
					}
				}
				AddLastElement();
				TestValueFormat();
				UpdateAttrubute();
				InputEnd.UpdateTitle();
				return true;
			}
			return false;
		}

		public override bool ToXML(XmlElement myElement)
		{
			switch (myOwnerDocument.Info.SaveMode)
			{
			case 0:
				if (myFormat.HasItem())
				{
					XmlElement myElement2 = XMLCommon.CreateChildElement(myElement, "format", bolCreate: true);
					myFormat.ToXML(myElement2);
				}
				myAttributes.ToXML(myElement);
				myElement.InnerText = ToEMRString();
				return true;
			case 1:
				return base.ToXML(myElement);
			case 2:
				myElement.SetAttribute("name", myAttributes.GetString("name"));
				myElement.InnerText = ToEMRString();
				return true;
			case 3:
				myElement.InnerText = ToEMRString();
				return true;
			default:
				return false;
			}
		}

		public ZYTextBox()
		{
			myLastElement = new EMRTextInputEnd();
			myLastElement.Parent = this;
			myChildElements.Clear();
			AddLastElement();
			myLines.Clear();
			base.LineSpan = -1;
			intLeftMargin = 5;
			bolContainTextOnly = true;
		}
	}
}
