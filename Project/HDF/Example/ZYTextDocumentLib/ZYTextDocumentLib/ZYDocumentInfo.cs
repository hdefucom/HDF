using System.Xml;

namespace ZYTextDocumentLib
{
	public class ZYDocumentInfo
	{
		public bool MarkLock = true;

		public bool FieldUnderLine = true;

		public ZYTextDocument OwnerDocument = null;

		public bool ShowMark = false;

		public bool AutoLogicDelete = true;

		public bool EnableSaveLog = true;

		public bool EnableDataSource = false;

		public int SaveMode = 0;

		public bool ShowPageLine = false;

		public bool ShowParagraphFlag = true;

		public bool SavePreViewText = false;

		public int VisibleUserLevel = -1;

		public bool DesignMode = false;

		public int LineSpacing = 10;

		public int ParagraphSpacing = 15;

		public bool WordWrap = true;

		public bool Printing = false;

		public bool LogicDelete = false;

		public bool ShowAll = false;

		public bool ShowExpendHandle = false;

		public bool LockForMark = true;

		public bool EnableScript = true;

		public bool ShowScriptError = true;

		public bool ShowScriptCompileError = true;

		public ZYAttributeCollection Attributes = new ZYAttributeCollection();

		public int MarkCount
		{
			get
			{
				return Attributes.GetInt32("markcount");
			}
			set
			{
				Attributes.SetValue("markcount", value);
			}
		}

		public string ID
		{
			get
			{
				return Attributes.GetString("id");
			}
			set
			{
				Attributes.SetValue("id", value);
			}
		}

		public string Title
		{
			get
			{
				return Attributes.GetString("title");
			}
			set
			{
				Attributes.SetValue("title", value);
			}
		}

		public string FileName
		{
			get
			{
				return Attributes.GetString("filename");
			}
			set
			{
				Attributes.SetValue("filename", value);
			}
		}

		public string Version
		{
			get
			{
				return Attributes.GetString("version");
			}
			set
			{
				Attributes.SetValue("version", value);
			}
		}

		public string Creator
		{
			get
			{
				return Attributes.GetString("creator");
			}
			set
			{
				Attributes.SetValue("creator", value);
			}
		}

		public string CreateTime
		{
			get
			{
				return Attributes.GetString("createtime");
			}
			set
			{
				Attributes.SetValue("createtime", value);
			}
		}

		public string Modifier
		{
			get
			{
				return Attributes.GetString("modifier");
			}
			set
			{
				Attributes.SetValue("modifier", value);
			}
		}

		public string ModifyTime
		{
			get
			{
				return Attributes.GetString("modifytime");
			}
			set
			{
				Attributes.SetValue("modifytime", value);
			}
		}

		internal static string GetXMLName()
		{
			return "docsetting";
		}

		public bool FromXML(XmlElement myElement)
		{
			if (myElement == null)
			{
				Attributes.Clear();
				Version = "1.0";
			}
			else
			{
				Attributes.FromXML(myElement);
			}
			return true;
		}

		public bool ToXML(XmlElement myElement)
		{
			if (myElement != null)
			{
				Attributes.ToXML(myElement);
				return true;
			}
			return false;
		}

		public bool CopyTo(ZYDocumentInfo myInfo)
		{
			if (myInfo != null)
			{
				myInfo.OwnerDocument = OwnerDocument;
				Attributes.CopyTo(myInfo.Attributes);
				myInfo.FieldUnderLine = FieldUnderLine;
				myInfo.ShowMark = ShowMark;
				myInfo.AutoLogicDelete = AutoLogicDelete;
				myInfo.EnableDataSource = EnableDataSource;
				myInfo.SaveMode = SaveMode;
				myInfo.ShowPageLine = ShowPageLine;
				myInfo.ShowParagraphFlag = ShowParagraphFlag;
				myInfo.SavePreViewText = SavePreViewText;
				myInfo.VisibleUserLevel = VisibleUserLevel;
				myInfo.DesignMode = DesignMode;
				myInfo.LineSpacing = LineSpacing;
				myInfo.ParagraphSpacing = ParagraphSpacing;
				myInfo.WordWrap = WordWrap;
				myInfo.Printing = Printing;
				myInfo.LogicDelete = LogicDelete;
				myInfo.ShowAll = ShowAll;
				myInfo.ShowExpendHandle = ShowExpendHandle;
				myInfo.EnableScript = EnableScript;
				myInfo.ShowScriptError = ShowScriptError;
				return true;
			}
			return false;
		}
	}
}
