using System.Collections;
using System.Windows.Forms;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class A_ContentChanged : ZYEditorAction
	{
		public static string AfterInsertCharActionName => "contentchanged";

		public override string ActionName()
		{
			return AfterInsertCharActionName;
		}

		public A_ContentChanged()
		{
			HotKey = (Keys)131153;
		}

		public override bool Execute()
		{
			ZYTextChar zYTextChar = myOwnerDocument.Content.PreElement as ZYTextChar;
			if (zYTextChar == null || zYTextChar.Parent is ZYTextBlock)
			{
				return false;
			}
			if (zYTextChar.Char == '有')
			{
				myOwnerDocument.OwnerControl.StaticToolTip = true;
				myOwnerDocument.OwnerControl.ShowInnerToolTip(2, "按Tab键开始输入症状信息", zYTextChar.RealLeft, zYTextChar.RealTop, zYTextChar.Height);
				Application.DoEvents();
				myOwnerDocument.OwnerControl.UpdateInnerToolTip();
				if (myOwnerDocument.OwnerControl.WaitForKeyDown(9, EatMessage: true) && myOwnerDocument.OwnerControl.InnerToolTipVisible)
				{
					myOwnerDocument.OwnerControl.HideInnerToolTip();
					ArrayList arrayList = new ArrayList();
					arrayList.AddRange(ZYKBBuffer.Instance.RootList.ChildNodes);
					ZYKBBuffer.Instance.OnlyCheckYesNoAttribute = true;
					ArrayList arrayList2 = new ArrayList();
					int num = 0;
					base.OwnerDocument.OwnerControl.InitKBPopupList();
					base.OwnerDocument.OwnerControl.KBPopupList.EnableSearchKBDynamic = false;
					while (true)
					{
						bool flag = true;
						int num2 = -1;
						arrayList2.Clear();
						ZYKBBuffer.Instance.GetKBListsByName("-", arrayList2, bolCompareName: false);
						object obj = base.OwnerDocument.OwnerControl.ShowKBPopupList(myOwnerDocument.Content.CurrentElement, arrayList2, "[正在选取症状]", MultiSelect: false, MustKBItem: false);
						KB_Item kB_Item = obj as KB_Item;
						if (kB_Item != null)
						{
							if (num > 0)
							{
								base.OwnerDocument._InsertChar('、');
							}
							num2 = base.OwnerDocument._InsertKB(kB_Item.OwnerList, kB_Item);
						}
						else
						{
							KB_List kB_List = obj as KB_List;
							if (kB_List != null)
							{
								if (num > 0)
								{
									base.OwnerDocument._InsertChar('、');
								}
								num2 = base.OwnerDocument._InsertKB(kB_List);
							}
						}
						if (num2 != 2)
						{
							break;
						}
						num++;
					}
					base.OwnerDocument.OwnerControl.KBPopupList.EnableSearchKBDynamic = true;
					ZYKBBuffer.Instance.OnlyCheckYesNoAttribute = false;
				}
				myOwnerDocument.OwnerControl.HideInnerToolTip();
				myOwnerDocument.OwnerControl.StaticToolTip = false;
				return true;
			}
			string preWord = myOwnerDocument.Content.GetPreWord(zYTextChar);
			if (StringCommon.HasContent(preWord) && (zYTextChar.Char == ':' || zYTextChar.Char == '：'))
			{
				KB_List kB_List = ZYKBBuffer.Instance.GetKBListByName(preWord, bolMatchAll: false);
				myOwnerDocument.OwnerControl.StaticToolTip = true;
				if (kB_List == null)
				{
					myOwnerDocument.OwnerControl.ShowInnerToolTip(12, "按Tab键添加名称为[" + preWord + "]的输入框", zYTextChar.RealLeft, zYTextChar.RealTop, zYTextChar.Height);
				}
				else
				{
					myOwnerDocument.OwnerControl.ShowInnerToolTip(2, "按Tab键添加名称为[" + kB_List.Name + "]的列表框", zYTextChar.RealLeft, zYTextChar.RealTop, zYTextChar.Height);
				}
				Application.DoEvents();
				myOwnerDocument.OwnerControl.UpdateInnerToolTip();
				if (myOwnerDocument.OwnerControl.WaitForKeyDown(9, EatMessage: true) && myOwnerDocument.OwnerControl.InnerToolTipVisible)
				{
					myOwnerDocument.OwnerControl.HideInnerToolTip();
					if (kB_List == null)
					{
						myOwnerDocument._InsertInput(preWord, preWord);
					}
					else
					{
						ZYTextSelect zYTextSelect = new ZYTextSelect();
						zYTextSelect.OwnerDocument = base.OwnerDocument;
						zYTextSelect.Name = kB_List.Name;
						zYTextSelect.ListSource = kB_List.SEQ;
						zYTextSelect.Text = "[" + kB_List.Name + "]";
						myOwnerDocument.BeginUpdate();
						myOwnerDocument.Content.InsertElement(zYTextSelect);
						myOwnerDocument.EndUpdate();
						zYTextSelect.PopupList();
					}
				}
				myOwnerDocument.OwnerControl.HideInnerToolTip();
				myOwnerDocument.OwnerControl.StaticToolTip = false;
			}
			return true;
		}
	}
}
