using System.Xml;

namespace ZYTextDocumentLib
{
	public class A_INSERTXMLCANUNDO : ZYEditorAction
	{
		private string myLastXmlDocStr = "";

		private ZYTextDocument myLastTextDocument = null;

		public override string ActionName()
		{
			return "insertxmlcanundo";
		}

		public override bool Execute()
		{
			string param = Param1;
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.PreserveWhitespace = true;
			myOwnerDocument.ToXMLDocument(xmlDocument);
			myLastXmlDocStr = xmlDocument.OuterXml;
			myLastTextDocument = (ZYTextDocument)myOwnerDocument.Clone();
			xmlDocument.LoadXml(param);
			myOwnerDocument.BeginUpdate();
			myOwnerDocument.FromXMLCanUndo(xmlDocument.DocumentElement);
			myOwnerDocument.RefreshSize();
			myOwnerDocument.Content.MoveSelectStart(0);
			myOwnerDocument.ContentChanged();
			myOwnerDocument.Modified = false;
			myOwnerDocument.EndUpdate();
			myOwnerDocument.Refresh();
			myOwnerDocument.RegisteUndo(this);
			return true;
		}

		public override bool isUndoable()
		{
			return true;
		}

		public override string UndoName()
		{
			return "重新加载xml字符串";
		}

		public override bool Undo()
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(myLastXmlDocStr);
			myOwnerDocument.FromXMLCanUndo(xmlDocument.DocumentElement);
			SetContainerSource();
			myOwnerDocument.RefreshElements();
			myOwnerDocument.RefreshLine();
			myOwnerDocument.UpdateView();
			return true;
		}

		private bool SetContainerSource()
		{
			bool result = true;
			if (myOwnerDocument.UndoList.Count > 0 && myOwnerDocument.UndoList[myOwnerDocument.UndoList.Count - 1] is A_ContentChangeLog)
			{
				bool flag = false;
				for (int i = 0; i < myOwnerDocument.Containters.Count; i++)
				{
					ZYTextContainer zYTextContainer = (ZYTextContainer)myOwnerDocument.Containters[i];
					ZYTextContainer container = ((A_ContentChangeLog)myOwnerDocument.UndoList[myOwnerDocument.UndoList.Count - 1]).Container;
					if (zYTextContainer.ID == container.ID)
					{
						SetDocumentContainerDom(isParentContainer: false);
						zYTextContainer = container;
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					SetDocumentContainerDom(isParentContainer: true);
				}
			}
			return result;
		}

		private void SetDocumentContainerDom(bool isParentContainer)
		{
			if (isParentContainer)
			{
				myOwnerDocument.DocumentElement = ((A_ContentChangeLog)myOwnerDocument.UndoList[myOwnerDocument.UndoList.Count - 1]).Container;
			}
			else
			{
				myOwnerDocument.DocumentElement = ((A_ContentChangeLog)myOwnerDocument.UndoList[myOwnerDocument.UndoList.Count - 1]).Container.OwnerDocument.DocumentElement;
			}
		}

		public override ZYEditorAction Clone()
		{
			A_INSERTXMLCANUNDO a_INSERTXMLCANUNDO = new A_INSERTXMLCANUNDO();
			a_INSERTXMLCANUNDO.BaseCloneFrom(this);
			a_INSERTXMLCANUNDO.myLastXmlDocStr = myLastXmlDocStr;
			a_INSERTXMLCANUNDO.myLastTextDocument = myLastTextDocument;
			return a_INSERTXMLCANUNDO;
		}
	}
}
