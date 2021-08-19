using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ZYTextElement
	{
		public int WidthFix = 0;

		protected int intLeft = 0;

		protected int intTop = 0;

		protected int intWidth = 0;

		protected int intHeight = 0;

		protected bool bolAbsolutePos = false;

		private int intDeleter = -1;

		private int intCreatorIndex = -1;

		protected ZYTextBorder myBorder = null;

		protected ZYAttributeCollection myAttributes = new ZYAttributeCollection();

		protected ZYTextDocument myOwnerDocument = null;

		protected ZYTextContainer myParent = null;

		protected ZYTextLine myOwnerLine = null;

		internal int Index = -1;

		private bool bolVisible = false;

		internal Rectangle myBounds = Rectangle.Empty;

		internal bool Visible
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

		public virtual Rectangle Bounds => myBounds;

		public ZYAttributeCollection Attributes => myAttributes;

		public int DeleterIndex
		{
			get
			{
				return intDeleter;
			}
			set
			{
				intDeleter = value;
				if (value >= 0)
				{
					myAttributes.SetValue("deleter", intDeleter.ToString());
				}
				else
				{
					myAttributes.RemoveAttribute("deleter");
				}
			}
		}

		public int CreatorIndex
		{
			get
			{
				return intCreatorIndex;
			}
			set
			{
				intCreatorIndex = value;
				if (value > 0)
				{
					myAttributes.SetValue("creator", value.ToString());
				}
				else
				{
					myAttributes.RemoveAttribute("creator");
				}
			}
		}

		public virtual bool Deleteted
		{
			get
			{
				return intDeleter >= 0;
			}
			set
			{
				if (value)
				{
					DeleterIndex = myOwnerDocument.SaveLogs.CurrentIndex;
				}
				else
				{
					DeleterIndex = -1;
				}
			}
		}

		public ZYTextBorder Border
		{
			get
			{
				return myBorder;
			}
			set
			{
				myBorder = value;
			}
		}

		public ZYTextLine OwnerLine
		{
			get
			{
				return myOwnerLine;
			}
			set
			{
				myOwnerLine = value;
			}
		}

		public int LineIndex => (myOwnerLine != null) ? myOwnerLine.Index : 0;

		public int RealLineIndex => (myOwnerLine != null) ? myOwnerLine.RealIndex : 0;

		public virtual int RealTop
		{
			get
			{
				if (myOwnerLine == null || bolAbsolutePos)
				{
					return intTop;
				}
				return intTop + myOwnerLine.RealTop;
			}
		}

		public virtual int RealLeft
		{
			get
			{
				if (myOwnerLine == null || bolAbsolutePos)
				{
					return intLeft;
				}
				return intLeft + myOwnerLine.RealLeft;
			}
		}

		public virtual ZYTextContainer Parent
		{
			get
			{
				return myParent;
			}
			set
			{
				myParent = value;
			}
		}

		public bool AbsolutePos
		{
			get
			{
				return bolAbsolutePos;
			}
			set
			{
				bolAbsolutePos = value;
			}
		}

		public virtual int Left
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

		public virtual int Top
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

		public virtual int Width
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

		public virtual int Height
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

		public virtual ZYTextDocument OwnerDocument
		{
			get
			{
				return myOwnerDocument;
			}
			set
			{
				myOwnerDocument = value;
			}
		}

		public virtual int FixPageLinePos(int LinePos)
		{
			int realTop = RealTop;
			if (LinePos > realTop && LinePos < realTop + intHeight)
			{
				return realTop;
			}
			return -1;
		}

		public virtual bool RefreshSize()
		{
			return true;
		}

		public virtual bool RefreshView()
		{
			return true;
		}

		public virtual void HandleEnter()
		{
			if (myParent != null)
			{
				myParent.HandleEnter();
			}
		}

		public virtual void HandleLeave()
		{
			if (myParent != null)
			{
				myParent.HandleLeave();
			}
		}

		public virtual bool HandleSelectedChange()
		{
			return false;
		}

		public virtual bool HandleClick(int x, int y, MouseButtons Button)
		{
			return false;
		}

		public virtual bool HandleDblClick(int x, int y, MouseButtons Button)
		{
			return false;
		}

		public virtual bool HandleMouseMove(int x, int y, MouseButtons Button)
		{
			return false;
		}

		public virtual bool HandleMouseDown(int x, int y, MouseButtons Button)
		{
			return false;
		}

		public virtual bool HandleMouseUp(int x, int y, MouseButtons Button)
		{
			return false;
		}

		public virtual bool isTextElement()
		{
			return true;
		}

		public virtual bool isField()
		{
			return false;
		}

		public virtual string GetXMLName()
		{
			return null;
		}

		public virtual string ToEMRString()
		{
			return "";
		}

		public virtual bool ToXML(XmlElement myElement)
		{
			switch (myOwnerDocument.Info.SaveMode)
			{
			case 0:
				myAttributes.ToXML(myElement);
				break;
			case 1:
				if (isField())
				{
					myElement.SetAttribute("name", myAttributes.GetString("name"));
					if (StringCommon.isBlankString(myAttributes.GetString("id")))
					{
						myAttributes.SetValue("id", StringCommon.AllocObjectName());
					}
					myElement.SetAttribute("id", myAttributes.GetString("id"));
					myElement.InnerText = ToEMRString();
				}
				break;
			case 2:
				if (isField())
				{
					myElement.SetAttribute("name", myAttributes.GetString("name"));
					if (StringCommon.isBlankString(myAttributes.GetString("id")))
					{
						myAttributes.SetValue("id", StringCommon.AllocObjectName());
					}
					myElement.SetAttribute("id", myAttributes.GetString("id"));
					myElement.InnerText = ToEMRString();
				}
				break;
			}
			return true;
		}

		public virtual void UpdateAttrubute()
		{
			intDeleter = StringCommon.ToInt32Value(myAttributes.GetString("deleter"), -1);
			intCreatorIndex = StringCommon.ToInt32Value(myAttributes.GetString("creator"), -1);
		}

		protected bool BaseFromXML(XmlElement myElement)
		{
			if (myElement != null)
			{
				myAttributes.FromXML(myElement);
				myAttributes.RemoveAttribute("createtime");
				myAttributes.RemoveAttribute("deletetime");
				if (myElement.HasAttribute("creator"))
				{
					CreatorIndex = StringCommon.ToInt32Value(myElement.GetAttribute("creator"), 0);
				}
				else
				{
					CreatorIndex = 0;
				}
				if (myElement.HasAttribute("deleter"))
				{
					DeleterIndex = StringCommon.ToInt32Value(myElement.GetAttribute("deleter"), -1);
				}
				else
				{
					DeleterIndex = -1;
				}
				if (myBorder != null)
				{
					myBorder.FromXML(myElement);
				}
				UpdateAttrubute();
				return true;
			}
			return false;
		}

		public virtual bool FromXML(XmlElement myElement)
		{
			return BaseFromXML(myElement);
		}

		public virtual bool isNewLine()
		{
			return false;
		}

		public virtual bool OwnerWholeLine()
		{
			return false;
		}

		public virtual bool isNewParagraph()
		{
			return false;
		}

		public virtual bool CanBeLineHead()
		{
			return true;
		}

		public virtual bool CanBeLineEnd()
		{
			return true;
		}

		public ZYTextElement()
		{
			myAttributes.OwnerElement = this;
		}

		public static bool FixElementsForParent(List<ZYTextElement> myList)
		{
			if (myList != null && myList.Count > 0)
			{
				for (int num = myList.Count - 1; num >= 0; num--)
				{
					if (num >= myList.Count)
					{
						num = myList.Count - 1;
					}
					ZYTextElement zYTextElement = myList[num];
					if (myList.Contains(zYTextElement.Parent))
					{
						myList.Remove(zYTextElement);
					}
				}
				return true;
			}
			return false;
		}

		public static string GetElementsText(IList<ZYTextElement> myList)
		{
			if (myList == null)
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (ZYTextElement my in myList)
			{
				if (my.isTextElement())
				{
					string text = my.ToEMRString();
					if (text != null)
					{
						stringBuilder.Append(text);
					}
				}
			}
			return stringBuilder.ToString();
		}

		public static bool ElementsToXML(List<ZYTextElement> myList, XmlElement RootElement)
		{
			if (myList != null && RootElement != null)
			{
				foreach (ZYTextElement my in myList)
				{
					string xMLName = my.GetXMLName();
					if (xMLName != null && XmlReader.IsName(xMLName))
					{
						XmlElement xmlElement = RootElement.OwnerDocument.CreateElement(xMLName);
						my.ToXML(xmlElement);
						RootElement.AppendChild(xmlElement);
					}
				}
				return true;
			}
			return false;
		}
	}
}
