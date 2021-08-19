using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace ZYTextDocumentLib
{
	public class ZYTextKeyWord : ZYTextElement
	{
		private string strErrorMessage = null;

		public string Text
		{
			get
			{
				return myAttributes.GetString("text");
			}
			set
			{
				myAttributes.SetValue("text", value);
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

		public override bool isTextElement()
		{
			return true;
		}

		public override string GetXMLName()
		{
			return "keyword";
		}

		public override bool RefreshSize()
		{
			base.Width = (int)myOwnerDocument.View.MeasureString(Text, null).Width + 2;
			if (base.Width < 20)
			{
				base.Width = 20;
			}
			Height = myOwnerDocument.DefaultRowHeight;
			return true;
		}

		public override void HandleEnter()
		{
			myOwnerDocument.RefreshElement(this);
		}

		public override void HandleLeave()
		{
			myOwnerDocument.RefreshElement(this);
		}

		public override bool RefreshView()
		{
			int realLeft = RealLeft;
			int realTop = RealTop;
			if (!myOwnerDocument.Info.Printing && (myOwnerDocument.Content.isCurrentElement(this) || myOwnerDocument.CurrentHoverElement == this))
			{
				myOwnerDocument.View.FillRectangle((strErrorMessage == null) ? Color.Tomato : SystemColors.Highlight, Bounds);
				myOwnerDocument.View.DrawSingleLine2(Text, Color.Black, realLeft, realTop, Width);
			}
			else
			{
				myOwnerDocument.View.DrawLine(SystemColors.Highlight, Left, Top + Height - 1, Left + Width, Top + Height - 1);
				Color highlightText = SystemColors.HighlightText;
				highlightText = ((!myParent.Locked) ? SystemColors.WindowText : ZYTextConst.LockedForeColor);
				myOwnerDocument.View.DrawSingleLine2(Text, highlightText, realLeft, realTop, Width);
			}
			return true;
		}

		public override bool HandleMouseMove(int x, int y, MouseButtons Button)
		{
			if (Bounds.Contains(x, y))
			{
				myOwnerDocument.SetCursor(Cursors.Arrow);
				myOwnerDocument.SetToolTip("单击引用模板 [ " + Text + " ] " + ((strErrorMessage == null) ? "" : ("\r\n" + strErrorMessage)), 4, Bounds);
				myOwnerDocument.CurrentHoverElement = this;
				return true;
			}
			return false;
		}

		public override bool FromXML(XmlElement myElement)
		{
			if (base.FromXML(myElement))
			{
				GetTemplateRecord();
				return true;
			}
			return false;
		}

		public ET_Document GetTemplateRecord()
		{
			strErrorMessage = null;
			KB_Item templateByID = ZYKBBuffer.Instance.GetTemplateByID(Source);
			if (templateByID == null)
			{
				strErrorMessage = "未找到编号为[ " + Source + " ]的知识项目";
			}
			else
			{
				Text = templateByID.ItemText;
				ET_Document eT_Document = new ET_Document();
				eT_Document.SetKeyWord(templateByID.ItemValue);
				if (myOwnerDocument.DataSource.DBConn.TestRecordExist(eT_Document))
				{
					return eT_Document;
				}
				strErrorMessage = "未找到编号为[ " + templateByID.ItemValue + " ]的模板";
			}
			return null;
		}

		public override bool HandleClick(int x, int y, MouseButtons Button)
		{
			if (myOwnerDocument.IsLock(this))
			{
				return false;
			}
			if (!Deleteted && Bounds.Contains(x, y) && !myParent.Locked)
			{
				ET_Document templateRecord = GetTemplateRecord();
				if (templateRecord != null)
				{
					KB_Item templateByID = ZYKBBuffer.Instance.GetTemplateByID(Source);
					myOwnerDocument.BeginContentChangeLog();
					myOwnerDocument.BeginUpdate();
					if (myOwnerDocument._InsertDocument(templateByID.ItemValue))
					{
						myOwnerDocument.Content.CurrentElement = this;
						myOwnerDocument.Content.DeleteCurrentElement();
					}
					myOwnerDocument.EndContentChangeLog();
					myOwnerDocument.EndUpdate();
					return true;
				}
				MessageBox.Show(myOwnerDocument.OwnerControl, strErrorMessage, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return false;
		}

		public override string ToEMRString()
		{
			return Text;
		}
	}
}
