using System.Xml;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ZYVBScriptElement : IXMLSerializable
	{
		private bool bolScriptModified = false;

		private ZYTextDocument myOwnerDocument = null;

		private string strRunPWD = null;

		private string strEditPWD = null;

		private string strSourceCode = null;

		private string strSrc = null;

		private bool bolEditPWDChecked = false;

		public bool ScriptModified
		{
			get
			{
				return bolScriptModified;
			}
			set
			{
				bolScriptModified = value;
			}
		}

		public ZYTextDocument OwnerDocument
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

		public string RunPWD
		{
			get
			{
				return strRunPWD;
			}
			set
			{
				if (StringCommon.isBlankString(value))
				{
					strRunPWD = null;
				}
				else
				{
					strRunPWD = StringCommon.GetMD5String(value.Trim());
				}
			}
		}

		public string EditPWD
		{
			get
			{
				return strEditPWD;
			}
			set
			{
				if (StringCommon.isBlankString(value))
				{
					strEditPWD = null;
				}
				else
				{
					strEditPWD = StringCommon.GetMD5String(value.Trim());
				}
			}
		}

		public bool EditPWDChecked => bolEditPWDChecked;

		public string SourceCode
		{
			get
			{
				if (bolEditPWDChecked)
				{
					return strSourceCode;
				}
				return null;
			}
			set
			{
				strSourceCode = value;
				bolScriptModified = true;
			}
		}

		internal string RunTimeSourceCode => ConvertToRunTimeScript(strSourceCode);

		public string Src
		{
			get
			{
				return strSrc;
			}
			set
			{
				strSrc = value;
			}
		}

		public void Clear()
		{
			strRunPWD = null;
			strEditPWD = null;
			strSourceCode = null;
			strSrc = null;
			bolEditPWDChecked = true;
		}

		public bool CheckRunPWD(string strPWD)
		{
			if (StringCommon.isBlankString(strRunPWD) || StringCommon.GetMD5String(strPWD) == strRunPWD)
			{
				return true;
			}
			return false;
		}

		public bool HasRunPWD()
		{
			return StringCommon.HasContent(strRunPWD);
		}

		public bool HasEditPWD()
		{
			return StringCommon.HasContent(strEditPWD);
		}

		public bool CheckEditPWD(string strPWD)
		{
			bolEditPWDChecked = (StringCommon.isBlankString(strEditPWD) || StringCommon.GetMD5String(strPWD) == strEditPWD);
			return bolEditPWDChecked;
		}

		public void AppendSourceCode(string strCode)
		{
			strSourceCode = strSourceCode + "\r\n" + strCode;
			bolScriptModified = true;
		}

		public string ConvertToRunTimeScript(string strText)
		{
			if (StringCommon.isBlankString(strRunPWD))
			{
				if (myOwnerDocument != null)
				{
					strText = myOwnerDocument.Variables.FixVariableString(strText);
				}
				return strText;
			}
			return null;
		}

		public string GetXMLName()
		{
			return "script";
		}

		public bool FromXML(XmlElement RootElement)
		{
			Clear();
			if (RootElement != null)
			{
				strRunPWD = RootElement.GetAttribute("runpwd");
				strEditPWD = RootElement.GetAttribute("editpwd");
				strSrc = RootElement.GetAttribute("src");
				bolEditPWDChecked = StringCommon.isBlankString(strEditPWD);
				if (StringCommon.HasContent(strSrc))
				{
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.Load(strSrc);
					return FromXML(xmlDocument.DocumentElement);
				}
				strSourceCode = RootElement.InnerText;
				return true;
			}
			return false;
		}

		public bool ToXML(XmlElement RootElement)
		{
			if (RootElement != null)
			{
				RootElement.RemoveAll();
				RootElement.SetAttribute("runpwd", strRunPWD);
				RootElement.SetAttribute("editpwd", strEditPWD);
				if (StringCommon.HasContent(strSrc))
				{
					RootElement.SetAttribute("src", strSrc);
				}
				else
				{
					RootElement.AppendChild(RootElement.OwnerDocument.CreateCDataSection(strSourceCode));
				}
				return true;
			}
			return false;
		}
	}
}
