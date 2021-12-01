using System.Collections;

namespace ZYTextDocumentLib
{
	public class A_ContentChangeLog : ZYEditorAction
	{
		private class UndoStep
		{
			internal int index;

			internal ZYTextElement Element;

			internal ArrayList Elements;

			internal ZYAttribute Attribute;

			internal object OldValue;

			internal object NewValue;

			internal int Style = 0;
		}

		internal bool CanLog = true;

		internal ZYTextContainer Container = null;

		internal int index = 0;

		public ArrayList myUndoSteps = new ArrayList();

		public string strUndoName = null;

		public void LogAttribute(ZYTextElement vElement, ZYAttribute vAttribute, object NewValue)
		{
			if (CanLog)
			{
				UndoStep undoStep = new UndoStep();
				undoStep.Element = vElement;
				undoStep.Attribute = vAttribute;
				undoStep.OldValue = vAttribute.Value;
				undoStep.NewValue = NewValue;
				undoStep.Style = 4;
				myUndoSteps.Add(undoStep);
			}
		}

		public void LogInsert(int index, ZYTextElement NewElement)
		{
			if (CanLog)
			{
				UndoStep undoStep = new UndoStep();
				undoStep.index = index;
				undoStep.Element = NewElement;
				undoStep.Style = 0;
				myUndoSteps.Add(undoStep);
			}
		}

		public void LogInsertRange(int index, ArrayList myList)
		{
			if (CanLog)
			{
				UndoStep undoStep = new UndoStep();
				undoStep.index = index;
				undoStep.Elements = myList;
				undoStep.Style = 1;
				myUndoSteps.Add(undoStep);
			}
		}

		public void LogAdd(ZYTextElement NewElement)
		{
			if (CanLog)
			{
				UndoStep undoStep = new UndoStep();
				undoStep.Style = 2;
				undoStep.Element = NewElement;
				myUndoSteps.Add(undoStep);
			}
		}

		public void LogAddRang(ArrayList myList)
		{
			if (CanLog)
			{
				UndoStep undoStep = new UndoStep();
				undoStep.Elements = myList;
				undoStep.Style = 5;
				myUndoSteps.Add(undoStep);
			}
		}

		public void LogRemove(int index, ZYTextElement myElement)
		{
			if (CanLog)
			{
				UndoStep undoStep = new UndoStep();
				undoStep.Style = 3;
				undoStep.index = index;
				undoStep.Element = myElement;
				myUndoSteps.Add(undoStep);
			}
		}

		public void LogRemoveRange(int index, ArrayList myList)
		{
			if (CanLog)
			{
				UndoStep undoStep = new UndoStep();
				undoStep.Elements = new ArrayList();
				undoStep.Elements.AddRange(myList);
				undoStep.index = index;
				undoStep.Style = 6;
				myUndoSteps.Add(undoStep);
			}
		}

		public override bool isEnable()
		{
			return myUndoSteps.Count > 0;
		}

		public override bool Redo()
		{
			bool flag = false;
			int num = -1;
			ZYTextElement zYTextElement = null;
			if (myUndoSteps.Count > 0)
			{
				foreach (UndoStep myUndoStep in myUndoSteps)
				{
					switch (myUndoStep.Style)
					{
					case 0:
						flag = true;
						Container.ChildElements.Insert(myUndoStep.index, myUndoStep.Element);
						myUndoStep.Element.OwnerDocument = Container.OwnerDocument;
						myUndoStep.Element.Parent = Container;
						zYTextElement = myUndoStep.Element;
						break;
					case 1:
						flag = true;
						Container.ChildElements.InsertRange(myUndoStep.index, myUndoStep.Elements);
						if (myUndoStep.Elements.Count > 0)
						{
							zYTextElement = (ZYTextElement)myUndoStep.Elements[0];
						}
						break;
					case 5:
						flag = true;
						Container.ChildElements.AddRange(myUndoStep.Elements);
						if (myUndoStep.Elements.Count > 0)
						{
							zYTextElement = (ZYTextElement)myUndoStep.Elements[0];
						}
						break;
					case 6:
						flag = true;
						num = myUndoStep.index;
						Container.ChildElements.RemoveRange(myUndoStep.index, myUndoStep.Elements.Count);
						break;
					case 2:
						flag = true;
						Container.ChildElements.Add(myUndoStep.Element);
						zYTextElement = myUndoStep.Element;
						break;
					case 3:
						flag = true;
						num = myUndoStep.index;
						Container.ChildElements.Remove(myUndoStep.Element);
						break;
					case 4:
						myUndoStep.Attribute.SetValue(myUndoStep.NewValue);
						myUndoStep.Element.RefreshSize();
						zYTextElement = myUndoStep.Element;
						myUndoStep.Element.UpdateAttrubute();
						break;
					}
				}
				if (flag)
				{
					base.OwnerDocument.RefreshElements();
				}
				base.OwnerDocument.RefreshLine();
				base.OwnerDocument.UpdateView();
				if (zYTextElement != null)
				{
					myOwnerDocument.Content.CurrentElement = zYTextElement;
				}
				else if (num >= 0)
				{
					myOwnerDocument.Content.MoveSelectStart(num);
				}
				return true;
			}
			return false;
		}

		public override bool Undo()
		{
			ZYTextElement zYTextElement = null;
			int num = -1;
			bool flag = false;
			if (myUndoSteps.Count > 0)
			{
				for (int num2 = myUndoSteps.Count - 1; num2 >= 0; num2--)
				{
					UndoStep undoStep = (UndoStep)myUndoSteps[num2];
					switch (undoStep.Style)
					{
					case 0:
						flag = true;
						num = undoStep.Element.Index;
						Container.ChildElements.Remove(undoStep.Element);
						break;
					case 5:
						flag = true;
						foreach (ZYTextElement element in undoStep.Elements)
						{
							num = element.Index;
							Container.ChildElements.Remove(element);
						}
						break;
					case 1:
						flag = true;
						foreach (ZYTextElement element2 in undoStep.Elements)
						{
							num = element2.Index;
							Container.ChildElements.Remove(element2);
						}
						break;
					case 2:
						flag = true;
						num = undoStep.Element.Index;
						Container.ChildElements.Remove(undoStep.Element);
						break;
					case 3:
						flag = true;
						Container.ChildElements.Insert(undoStep.index, undoStep.Element);
						zYTextElement = undoStep.Element;
						break;
					case 6:
						flag = true;
						Container.ChildElements.InsertRange(undoStep.index, undoStep.Elements);
						num = undoStep.index;
						break;
					case 4:
						undoStep.Attribute.SetValue(undoStep.OldValue);
						undoStep.Element.UpdateAttrubute();
						undoStep.Element.RefreshSize();
						zYTextElement = undoStep.Element;
						break;
					}
				}
				if (flag)
				{
					myOwnerDocument.RefreshElements();
				}
				myOwnerDocument.RefreshLine();
				myOwnerDocument.UpdateView();
				return true;
			}
			return false;
		}

		public override bool isUndoable()
		{
			return true;
		}

		public override string UndoName()
		{
			return strUndoName;
		}

		public override string ActionName()
		{
			return "log";
		}

		public override ZYEditorAction Clone()
		{
			return this;
		}
	}
}
