using System.Collections;
using System.Drawing;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class InputTagProvider : SmartTagProvider
	{
		public override int ImageIndex => 12;

		public override bool isEnable()
		{
			return Element is ZYTextInput;
		}

		public override Point GetPos()
		{
			ZYTextInput zYTextInput = Element as ZYTextInput;
			if (zYTextInput != null)
			{
				ZYTextElement lastElement = zYTextInput.GetLastElement();
				if (lastElement != null)
				{
					return new Point(lastElement.Bounds.Right + 2, lastElement.Bounds.Bottom + 2);
				}
				return Point.Empty;
			}
			return Point.Empty;
		}

		public override void GetCommands(ArrayList myList)
		{
			ZYTextInput zYTextInput = Element as ZYTextInput;
			myList.Add(new SmartTagItem(this, 0, "更改编号[ " + zYTextInput.ID + " ]为..."));
			myList.Add(new SmartTagItem(this, 1, "更改名称[ " + zYTextInput.Name + " ]为..."));
			myList.Add(new SmartTagItem(this, 7, "更改显示名称[" + zYTextInput.DisplayName + "]为..."));
			KB_List kBList = ZYKBBuffer.Instance.GetKBList(zYTextInput.ListSource);
			if (kBList != null && kBList.HasItems())
			{
				myList.Add(new SmartTagItem("-"));
				myList.Add(new SmartTagItem("--- 使用以下菜单修改文本 ---"));
				string shortCutChars = StringCommon.GetShortCutChars("INF");
				int num = 0;
				string a = zYTextInput.ToEMRString();
				foreach (KB_Item item in kBList.Items)
				{
					myList.Add(new SmartTagItem(this, 3, a == item.ItemText, ((num < shortCutChars.Length) ? ("&" + shortCutChars[num] + "  ") : "") + item.ItemText, item.ItemText));
					if (num++ > 30)
					{
						break;
					}
				}
			}
		}

		public override bool HandleCommand(SmartTagItem item)
		{
			ZYTextInput zYTextInput = Element as ZYTextInput;
			if (zYTextInput != null)
			{
				if (item.ID == 0)
				{
					string text = dlgInputBox.InputBox("请输入新的输入框的名称", "系统提示", zYTextInput.ID);
					if (!StringCommon.isBlankString(text))
					{
						zYTextInput.ID = text.Trim();
						OwnerDocument.Modified = true;
						return true;
					}
				}
				else if (item.ID == 1)
				{
					string text = dlgInputBox.InputBox("请输入新的输入框的名称", "系统提示", zYTextInput.Name);
					if (!StringCommon.isBlankString(text))
					{
						zYTextInput.Name = text.Trim();
						OwnerDocument.Modified = true;
						return true;
					}
				}
				else if (item.ID == 7)
				{
					string text2 = dlgInputBox.InputBox("请输入新的显示名称", "系统输入", zYTextInput.DisplayName);
					if (text2 != null)
					{
						zYTextInput.DisplayName = text2;
						zYTextInput.RefreshSize();
						OwnerDocument.RefreshLine();
						OwnerDocument.UpdateView();
						return true;
					}
				}
			}
			return false;
		}
	}
}
