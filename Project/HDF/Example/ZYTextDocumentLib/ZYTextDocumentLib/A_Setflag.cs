using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class A_Setflag : ZYEditorAction
	{
		public override string ActionName()
		{
			return "setflag";
		}

		public override bool Execute()
		{
			try
			{
				List<ZYTextElement> selectElements = myOwnerDocument.Content.GetSelectElements();
				ZYTextElement.FixElementsForParent(selectElements);
				foreach (ZYTextElement item in selectElements)
				{
					if (item is ZYTextSelect)
					{
						return false;
					}
				}
				if (selectElements != null && selectElements.Count > 0)
				{
					string elementsText = ZYTextElement.GetElementsText(selectElements);
					myOwnerDocument._InsertTextFlag(elementsText);
					return true;
				}
			}
			catch (Exception sourceException)
			{
				ZYErrorReport.Instance.SourceException = sourceException;
				ZYErrorReport.Instance.SourceObject = this;
				ZYErrorReport.Instance.UserMessage = "设置数据数据错误";
				ZYErrorReport.Instance.ReportError();
			}
			return false;
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify() && myOwnerDocument.Content.HasSelected();
		}

		public A_Setflag()
		{
			HotKey = (Keys)131149;
		}
	}
}
