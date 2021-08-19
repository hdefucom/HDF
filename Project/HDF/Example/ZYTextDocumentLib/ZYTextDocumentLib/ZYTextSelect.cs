using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ZYTextSelect : ZYTextBlock
	{
		private KB_List myOwnerKBList = null;

		private ArrayList myOptions = new ArrayList();

		private bool bolReadonly = false;

		private bool bolPopuping = false;

		private Font myFont = null;

		public KB_List OwnerKBList
		{
			get
			{
				return myOwnerKBList;
			}
			set
			{
				myOwnerKBList = value;
				if (value != null)
				{
					base.Name = value.Name;
					ListSource = value.SEQ;
				}
			}
		}

		public bool SaveList
		{
			get
			{
				return myAttributes.GetBool("savelist");
			}
			set
			{
				myAttributes.SetValue("savelist", value);
			}
		}

		public int Source
		{
			get
			{
				return myAttributes.GetInt32("source");
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
				myAttributes.SetValue("id", "kb" + value);
			}
		}

		public string DisplayName
		{
			get
			{
				string text = myAttributes.GetString("displayname");
				if (StringCommon.isBlankString(text))
				{
					text = "[" + (StringCommon.isBlankString(base.Name) ? base.ID : base.Name) + "]";
				}
				return text;
			}
			set
			{
				myAttributes.SetValue("displayname", value);
			}
		}

		public ArrayList Options => myOptions;

		public bool Multiple
		{
			get
			{
				return myAttributes.GetBool("multiple");
			}
			set
			{
				myAttributes.SetValue("multiple", value);
			}
		}

		public bool IsNeed
		{
			get
			{
				return myAttributes.GetBool("need");
			}
			set
			{
				myAttributes.SetValue("need", value);
			}
		}

		public bool Readonly
		{
			get
			{
				return bolReadonly;
			}
			set
			{
				bolReadonly = value;
			}
		}

		public string Value
		{
			get
			{
				return myAttributes.GetString("value");
			}
			set
			{
				myAttributes.SetValue("value", value);
			}
		}

		public string Text
		{
			get
			{
				return myAttributes.GetString("text");
			}
			set
			{
				myAttributes.SetValue("text", value);
				UpdateText();
			}
		}

		public override bool WholeElement => true;

		public override int Width
		{
			get
			{
				return 3;
			}
			set
			{
				base.Width = value;
			}
		}

		public override int Height
		{
			get
			{
				return myOwnerDocument.DefaultRowHeight;
			}
			set
			{
				base.Height = value;
			}
		}

		public Font Font
		{
			get
			{
				if (myFont == null)
				{
					myFont = myOwnerDocument.View._CreateFont(FontName, FontSize, FontBold, FontItalic, FontUnderLine);
				}
				return myFont;
			}
			set
			{
				FontName = value.Name;
				FontSize = value.Size;
				FontBold = value.Bold;
				FontItalic = value.Italic;
				FontUnderLine = value.Underline;
			}
		}

		public new string FontName
		{
			get
			{
				return myAttributes.GetString("fontname");
			}
			set
			{
				myAttributes.SetValue("fontname", value);
				myFont = null;
			}
		}

		public new float FontSize
		{
			get
			{
				return myAttributes.GetFloat("fontsize");
			}
			set
			{
				myAttributes.SetValue("fontsize", value);
				myFont = null;
			}
		}

		public bool FontBold
		{
			get
			{
				return myAttributes.GetBool("fontbold");
			}
			set
			{
				myAttributes.SetValue("fontbold", value);
				myFont = null;
			}
		}

		public bool FontUnderLine
		{
			get
			{
				return myAttributes.GetBool("fontunderline");
			}
			set
			{
				myAttributes.SetValue("fontunderline", value);
				myFont = null;
			}
		}

		public bool FontItalic
		{
			get
			{
				return myAttributes.GetBool("fontitalic");
			}
			set
			{
				myAttributes.SetValue("fontitalic", value);
				myFont = null;
			}
		}

		public override bool CanBeLineEnd()
		{
			return false;
		}

		public bool HasOptions()
		{
			return myOptions != null && myOptions.Count > 0;
		}

		protected override void AddLastElement()
		{
		}

		protected override bool BeforeInsert(ZYTextElement NewElement)
		{
			return false;
		}

		public override bool isField()
		{
			return true;
		}

		public override string GetXMLName()
		{
			return "select";
		}

		public override void DrawBackGround(ZYTextElement myElement)
		{
			if (bolStandOutBack && !myOwnerDocument.Info.Printing)
			{
				myOwnerDocument.View.FillRectangle(Color.SkyBlue, myElement.Bounds);
			}
			if (myOwnerDocument.Info.FieldUnderLine)
			{
				myOwnerDocument.View.DrawLine(Pens.Blue, myElement.Bounds.Left, myElement.Bounds.Bottom - 3, myElement.Bounds.Right, myElement.Bounds.Bottom - 3);
			}
		}

		public KB_Item AddOption(string strText)
		{
			SaveList = true;
			KB_Item kB_Item = new KB_Item();
			kB_Item.ItemText = strText;
			kB_Item.ItemValue = strText;
			myOptions.Add(kB_Item);
			return kB_Item;
		}

		internal void UpdateText()
		{
			string text = Text;
			if (StringCommon.isBlankString(text))
			{
				text = DisplayName;
			}
			ArrayList c = myOwnerDocument.CreateChars(text, this);
			myChildElements.Clear();
			myChildElements.AddRange(c);
			foreach (ZYTextElement myChildElement in myChildElements)
			{
				myChildElement.CreatorIndex = base.CreatorIndex;
				myChildElement.DeleterIndex = base.DeleterIndex;
			}
			RefreshSize();
			if (!myOwnerDocument.Loading)
			{
				base.RaiseOnChangeEvent();
			}
			myOwnerDocument.ElementsDirty = true;
		}

		public override bool FromXML(XmlElement myElement)
		{
			if (BaseFromXML(myElement))
			{
				if (StringCommon.HasContent(base.ValueSource) && myOwnerDocument.Variables.Contains(base.ValueSource))
				{
					myAttributes.SetValue("text", myOwnerDocument.Variables.GetValue(base.ValueSource));
				}
				UpdateText();
				myOptions.Clear();
				FromListXML(myElement);
				myOwnerKBList = ZYKBBuffer.Instance.GetKBList(ListSource);
				UpdateAttrubute();
				return true;
			}
			return false;
		}

		private void FromListXML(XmlElement myElement)
		{
			if (myElement != null)
			{
				foreach (XmlNode childNode in myElement.ChildNodes)
				{
					XmlElement xmlElement = childNode as XmlElement;
					if (xmlElement != null && xmlElement.Name == "option")
					{
						KB_Item kB_Item = new KB_Item();
						kB_Item.ItemText = xmlElement.GetAttribute("text");
						kB_Item.ItemValue = xmlElement.GetAttribute("value");
						myOptions.Add(kB_Item);
					}
				}
			}
		}

		private void UpdateID()
		{
			if (myOwnerKBList != null)
			{
				ListSource = myOwnerKBList.SEQ;
				base.ID = "";
			}
			if (StringCommon.isBlankString(base.ID))
			{
				string text = null;
				text = (base.ID = ((!StringCommon.HasContent(ListSource)) ? StringCommon.AllocObjectName() : ("kb" + ListSource)));
			}
		}

		public override bool ToXML(XmlElement myElement)
		{
			UpdateID();
			myAttributes.SetValue("value", Value);
			switch (myOwnerDocument.Info.SaveMode)
			{
			case 0:
				myAttributes.ToXML(myElement);
				if (SaveList && myOptions.Count < 100)
				{
					foreach (KB_Item myOption in myOptions)
					{
						XmlElement xmlElement = myElement.OwnerDocument.CreateElement("option");
						myElement.AppendChild(xmlElement);
						xmlElement.SetAttribute("text", myOption.ItemText);
						xmlElement.SetAttribute("value", myOption.ItemValue);
					}
				}
				break;
			case 1:
				myElement.SetAttribute("id", base.ID);
				myElement.SetAttribute("name", base.Name);
				myElement.InnerText = Value;
				break;
			case 2:
				myElement.SetAttribute("id", base.ID);
				myElement.SetAttribute("name", base.Name);
				myElement.InnerText = Value;
				break;
			case 3:
			{
				string value = Value;
				string iD = base.ID;
				if (StringCommon.isBlankString(iD))
				{
					iD = "未命名列表";
				}
				else
				{
					iD = iD.Trim();
					iD = iD.Replace(' ', '_');
				}
				if (StringCommon.HasContent(value))
				{
					string[] array = value.Split("、".ToCharArray());
					string[] array2 = array;
					foreach (string innerText in array2)
					{
						XmlElement xmlElement = myElement.OwnerDocument.CreateElement(iD);
						myElement.ParentNode.InsertAfter(xmlElement, myElement);
						xmlElement.InnerText = innerText;
					}
					myElement.ParentNode.RemoveChild(myElement);
				}
				else
				{
					myElement.InnerText = "";
				}
				break;
			}
			}
			return true;
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
			myKeyValues.Add(Value);
			return 1;
		}

		public override bool HandleMouseDown(int x, int y, MouseButtons Button)
		{
			if (Contains(x, y) && !myOwnerDocument.IsLock(this))
			{
				PopupList();
				return true;
			}
			return false;
		}

		internal EventHandler GetSelectedStateChangedHandler()
		{
			if (Multiple)
			{
				return SelectedStateChanged;
			}
			return null;
		}

		private void SelectedStateChanged(object Sender, EventArgs e)
		{
			if (Multiple)
			{
				SetValue((Sender as ZYPopupList).SelectedObjects, ChangeSelection: false);
			}
		}

		public bool SetValue(object objValue, bool ChangeSelection)
		{
			bool flag = false;
			if (objValue != null)
			{
				string text = Text;
				if (ChangeSelection)
				{
					myOwnerDocument.Content.AutoClearSelection = true;
					myOwnerDocument.Content.MoveSelectStart(this);
				}
				myOwnerDocument.BeginContentChangeLog();
				myOwnerDocument.BeginUpdate();
				if (Multiple)
				{
					ArrayList arrayList = (ArrayList)objValue;
					string text2 = null;
					string text3 = null;
					if (arrayList.Count > 0)
					{
						foreach (KB_Item item in arrayList)
						{
							text2 = ((text2 != null) ? (text2 + "、" + item.ItemText) : item.ItemText);
							text3 = ((text3 != null) ? (text3 + "、" + item.ItemValue) : item.ItemValue);
							if (StringCommon.isBlankString(base.Name))
							{
								base.Name = item.OwnerList.Name;
								ListSource = item.OwnerList.SEQ;
							}
						}
					}
					if (Text != text2)
					{
						Text = text2;
						Value = text3;
						flag = true;
					}
				}
				else
				{
					KB_Item kB_Item = objValue as KB_Item;
					if (kB_Item != null)
					{
						if (kB_Item.isTemplate())
						{
							ET_Document eT_Document = new ET_Document();
							eT_Document.SetKeyWord(kB_Item.ItemValue);
							string text4 = null;
							if (myOwnerDocument.DataSource.DBConn.ReadOneRecord(eT_Document))
							{
								try
								{
									ZYTextContainer zYTextContainer = myOwnerDocument.CreateElementByXML(ZYTextDocument.GetBodyElement(eT_Document.GetDataXML().DocumentElement)) as ZYTextContainer;
									if (zYTextContainer != null)
									{
										zYTextContainer.ClearSaveLog();
										ArrayList arrayList = new ArrayList();
										arrayList.AddRange(zYTextContainer.ChildElements);
										if (arrayList.Count > 0 && arrayList[arrayList.Count - 1] is ZYTextParagraph)
										{
											arrayList.RemoveAt(arrayList.Count - 1);
										}
										myParent.InsertRangeBefore(arrayList, this);
										myParent.RemoveChild(this);
										myOwnerDocument.RefreshSize();
										myOwnerDocument.RefreshElements();
										myOwnerDocument.RefreshLine();
									}
								}
								catch (Exception ex)
								{
									text4 = "导入编号为[" + kB_Item.ItemValue + "]的模板错误!\r\n" + ex.ToString();
								}
							}
							else
							{
								text4 = "不存在编号为[" + kB_Item.ItemValue + "]的模板!";
							}
							if (text4 != null)
							{
								MessageBox.Show(myOwnerDocument.OwnerControl, text4, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
							myOwnerDocument.EndContentChangeLog();
							myOwnerDocument.EndUpdate();
							return false;
						}
						if (StringCommon.isBlankString(base.Name))
						{
							base.Name = kB_Item.OwnerList.Name;
							ListSource = kB_Item.OwnerList.SEQ;
							myOwnerDocument.Modified = true;
						}
						if (Text != kB_Item.ItemText)
						{
							Text = kB_Item.ItemText;
							Value = kB_Item.ItemValue;
							flag = true;
						}
					}
				}
				if (StringCommon.isBlankString(Value))
				{
					Value = Text;
					flag = true;
				}
				if (flag)
				{
					RefreshSize();
					myOwnerDocument.RefreshElements();
					myOwnerDocument.RefreshLine();
					if (Parent is EMRCell)
					{
						(Parent as EMRCell).RefreshLine();
					}
					if (ChangeSelection)
					{
						myOwnerDocument.Content.AutoClearSelection = true;
						myOwnerDocument.Content.MoveSelectStart(Index + 1);
					}
					myOwnerDocument.Refresh();
					myOwnerDocument.Modified = true;
				}
				myOwnerDocument.EndUpdate();
				myOwnerDocument.EndContentChangeLog();
				return true;
			}
			return false;
		}

		public override void ResetViewState()
		{
			if (bolPopuping)
			{
				bolStandOutBack = true;
			}
			else
			{
				base.ResetViewState();
			}
		}

		public bool PopupList()
		{
			if (myParent.Locked || Deleteted)
			{
				return false;
			}
			bolPopuping = true;
			myOwnerDocument.Content.AutoClearSelection = true;
			myOwnerDocument.Content.CurrentElement = this;
			ResetViewState();
			myOwnerDocument.RefreshElement(this);
			object objValue = myOwnerDocument.ShowKBPopupList(this);
			bolPopuping = false;
			myOwnerDocument.RefreshElement(this);
			bool flag = SetValue(objValue, ChangeSelection: true);
			if (flag)
			{
				if (myChildElements.Count > 0)
				{
					myOwnerDocument.Content.CurrentElement = myOwnerDocument.Content.GetNextElement((ZYTextElement)myChildElements[myChildElements.Count - 1]);
				}
				else
				{
					myOwnerDocument.Content.CurrentElement = myOwnerDocument.Content.GetNextElement(this);
				}
			}
			return flag;
		}

		public override bool HandleMouseMove(int x, int y, MouseButtons Button)
		{
			if (Contains(x, y))
			{
				myOwnerDocument.SetCursor(Cursors.Arrow);
				myOwnerDocument.SetToolTip("知识列表 [ " + base.Name + " ] ", -1, Bounds);
				myOwnerDocument.CurrentHoverElement = this;
				return true;
			}
			return false;
		}

		public override string ToEMRString()
		{
			return Text;
		}

		public ZYTextSelect()
		{
			bolChildElementsLocked = true;
		}
	}
}
