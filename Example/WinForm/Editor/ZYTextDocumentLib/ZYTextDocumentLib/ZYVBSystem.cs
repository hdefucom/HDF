using System;
using System.Collections;
using System.Windows.Forms;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ZYVBSystem
	{
		internal ZYVBScriptEngine EMRVBEngine = null;

		private NameValueList myValues = new NameValueList();

		private ZYTextDocument myOwnerDocument = null;

		private string strSystemName = null;

		private Hashtable mySession = new Hashtable();

		public string SystemName => strSystemName;

		public Hashtable Session => mySession;

		public ZYVBSystem(ZYTextDocument myDocument)
		{
			myOwnerDocument = myDocument;
			strSystemName = "报告编辑器";
		}

		public string GetValue(string strName)
		{
			return myValues.GetValue(strName);
		}

		public void SetValue(string strName, string strValue)
		{
			myValues.SetValue(strName, strValue);
		}

		public string FixValueString(string strText)
		{
			return myValues.FixVariableString(strText);
		}

		public string GetDisplayText(object objData)
		{
			if (objData == null)
			{
				return "[null]";
			}
			return Convert.ToString(objData);
		}

		public void Alert(object objText)
		{
			MessageBox.Show(null, GetDisplayText(objText), strSystemName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			if (EMRVBEngine != null)
			{
				EMRVBEngine.HasUserInterface = true;
			}
		}

		public bool ConFirm(object objText)
		{
			if (EMRVBEngine != null)
			{
				EMRVBEngine.HasUserInterface = true;
			}
			return MessageBox.Show(null, GetDisplayText(objText), strSystemName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
		}

		public string Prompt(object objCaption, object objDefault)
		{
			if (EMRVBEngine != null)
			{
				EMRVBEngine.HasUserInterface = true;
			}
			return dlgInputBox.InputBox(strSystemName, GetDisplayText(objCaption), GetDisplayText(objDefault));
		}

		public void DebugPrint(object objText)
		{
			Console.WriteLine(GetDisplayText(objText));
		}
	}
}
