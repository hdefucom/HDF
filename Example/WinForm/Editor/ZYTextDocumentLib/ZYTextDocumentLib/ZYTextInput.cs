using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ZYTextInput : ZYTextBlock
	{
		public class EMRTextInputEnd : ZYTextElement
		{
			internal string LastTitle = null;

			public ZYTextInput OwnerInput
			{
				get
				{
					return (ZYTextInput)myParent;
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
				if (OwnerInput.ChildCount <= 1)
				{
					return OwnerInput.DisplayName;
				}
				return OwnerInput.Unit;
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
				if (LastTitle != null)
				{
					myOwnerDocument.View.DrawSingleLine2(LastTitle, SystemColors.WindowText, RealLeft, RealTop, Width);
				}
				int num = Height / 2;
				return true;
			}

			public override string ToEMRString()
			{
				return "";
			}
		}

		private StringDataFormat myFormat = new StringDataFormat();

		private bool bolValueFormatCheck = true;

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

		public string Source
		{
			get
			{
				return myAttributes.GetString("source");
			}
			set
			{
				myAttributes.SetValue("source", value);
			}
		}

		public string ListSource
		{
			get
			{
				string text = myAttributes.GetString("listsource");
				if (text != null && text.Length != 12)
				{
					text = text.Trim().PadLeft(12, '0');
				}
				return text;
			}
			set
			{
				myAttributes.SetValue("listsource", value);
				myAttributes.SetValue("id", "kb" + value.ToString());
			}
		}

		public string DisplayName
		{
			get
			{
				if (myOwnerDocument.Info.Printing)
				{
					return Unit.Trim();
				}
				string @string = myAttributes.GetString("displayname");
				if (StringCommon.isBlankString(@string))
				{
					@string = base.Name;
					if (StringCommon.isBlankString(@string))
					{
						@string = base.ID;
					}
					return "[" + @string + "]" + Unit.Trim();
				}
				return @string;
			}
			set
			{
				myAttributes.SetValue("displayname", value);
				if (myLastElement is EMRTextInputEnd)
				{
					(myLastElement as EMRTextInputEnd).UpdateTitle();
				}
			}
		}

		public string Unit
		{
			get
			{
				return myAttributes.GetString("unit");
			}
			set
			{
				if (value != null)
				{
					value = value.Trim();
				}
				myAttributes.SetValue("unit", value);
				(myLastElement as EMRTextInputEnd).UpdateTitle();
			}
		}

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

		public override int Width
		{
			get
			{
				return 5;
			}
			set
			{
				intWidth = value;
			}
		}

		public override bool CanBeLineEnd()
		{
			return false;
		}

		public override void UpdateAttrubute()
		{
			base.UpdateAttrubute();
			KB_List kBList = ZYKBBuffer.Instance.GetKBList(ListSource);
			if (kBList != null)
			{
				Unit = kBList.Desc;
			}
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
			return "input";
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
			base.Height = num2;
			base.Width = num;
			return true;
		}

		public override void UpdateBounds()
		{
			base.Width = 5;
			int num = 0;
			foreach (ZYTextElement myChildElement in myChildElements)
			{
				num += myChildElement.Width + myChildElement.WidthFix;
			}
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
				myOwnerDocument.View.DrawLine(SystemColors.ControlDark, vRect.Left, vRect.Bottom - 1, vRect.Right, vRect.Bottom - 1);
			}
			if (myOwnerDocument.Info.FieldUnderLine)
			{
				myOwnerDocument.View.DrawLine(SystemPens.ControlDark, myElement.Bounds.Left, myElement.Bounds.Bottom - 1, myElement.Bounds.Right, myElement.Bounds.Bottom - 1);
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

		private void UpdateID()
		{
			if (StringCommon.isBlankString(base.ID))
			{
				string text = null;
				text = (base.ID = ((!StringCommon.HasContent(ListSource)) ? StringCommon.AllocObjectName() : ("kb" + ListSource.ToString())));
			}
		}

		public override bool ToXML(XmlElement myElement)
		{
			UpdateID();
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
				myElement.SetAttribute("id", base.ID);
				return base.ToXML(myElement);
			case 2:
				myElement.SetAttribute("id", base.ID);
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

		public override int AppendKeyValueList(ArrayList myKeyValues)
		{
			UpdateID();
			myKeyValues.Add(base.ID);
			if (ZYKBBuffer.Instance.Loading)
			{
				myKeyValues.Add(base.Name);
			}
			else
			{
				KB_List kBList = ZYKBBuffer.Instance.GetKBList(ListSource);
				myKeyValues.Add((kBList == null) ? "0" : kBList.Name);
			}
			myKeyValues.Add(ToEMRString());
			return 1;
		}

		public ZYTextInput()
		{
			myLastElement = new EMRTextInputEnd();
			myLastElement.Parent = this;
			myChildElements.Clear();
			AddLastElement();
			myLines.Clear();
			base.LineSpan = -1;
			intLeftMargin = 5;
			base.ID = StringCommon.AllocObjectName();
			bolContainTextOnly = true;
		}
	}
}
