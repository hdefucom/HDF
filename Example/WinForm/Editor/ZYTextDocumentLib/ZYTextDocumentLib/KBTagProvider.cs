using System.Collections;
using System.Drawing;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class KBTagProvider : SmartTagProvider
	{
		public override int ImageIndex => 2;

		public override bool isEnable()
		{
			if (Element == null)
			{
				return false;
			}
			return Element is ZYTextSelect || Element.Parent is ZYTextSelect;
		}

		public override Point GetPos()
		{
			ZYTextSelect zYTextSelect = Element as ZYTextSelect;
			if (zYTextSelect == null)
			{
				zYTextSelect = (Element.Parent as ZYTextSelect);
			}
			if (zYTextSelect == null)
			{
				return Point.Empty;
			}
			if (zYTextSelect.ChildElements.Count == 0)
			{
				return Point.Empty;
			}
			ZYTextElement zYTextElement = (ZYTextElement)zYTextSelect.ChildElements[zYTextSelect.ChildElements.Count - 1];
			return new Point(zYTextElement.RealLeft + zYTextElement.Width, zYTextElement.RealTop + zYTextElement.Height);
		}

		public override void GetCommands(ArrayList myList)
		{
			ZYTextSelect zYTextSelect = Element as ZYTextSelect;
			if (zYTextSelect == null)
			{
				zYTextSelect = (Element.Parent as ZYTextSelect);
			}
			if (zYTextSelect != null)
			{
				myList.Add(new SmartTagItem(this, 3, "设置显示名称 " + zYTextSelect.DisplayName + " 为..."));
				myList.Add(new SmartTagItem(this, 4, "清空内容"));
				myList.Add(new SmartTagItem("-"));
				myList.Add(new SmartTagItem(this, 1, zYTextSelect.Multiple, "多选列表"));
				if (OwnerDocument.Info.DesignMode && ZYPublic.StandardMode)
				{
					myList.Add(new SmartTagItem(this, 9, zYTextSelect.IsNeed, "必须列表"));
				}
			}
		}

		public override bool HandleCommand(SmartTagItem item)
		{
			ZYTextSelect zYTextSelect = Element as ZYTextSelect;
			if (zYTextSelect == null)
			{
				zYTextSelect = (Element.Parent as ZYTextSelect);
			}
			if (zYTextSelect == null)
			{
				return false;
			}
			switch (item.ID)
			{
			case 1:
				if (zYTextSelect != null)
				{
					zYTextSelect.Multiple = !zYTextSelect.Multiple;
					return true;
				}
				break;
			case 3:
			{
				string text = dlgInputBox.InputBox("请输入新的显示名称", "修改显示名称", zYTextSelect.DisplayName);
				if (text != null)
				{
					zYTextSelect.DisplayName = text;
					zYTextSelect.UpdateText();
					zYTextSelect.RefreshSize();
					OwnerDocument.RefreshElements();
					OwnerDocument.RefreshLine();
					OwnerDocument.Refresh();
					OwnerDocument.Modified = true;
				}
				break;
			}
			case 4:
				zYTextSelect.Text = "";
				zYTextSelect.Value = "";
				zYTextSelect.UpdateText();
				zYTextSelect.RefreshSize();
				OwnerDocument.RefreshElements();
				OwnerDocument.RefreshLine();
				OwnerDocument.Refresh();
				OwnerDocument.Modified = true;
				break;
			case 8:
				zYTextSelect.KeyField = !zYTextSelect.KeyField;
				break;
			case 9:
				if (zYTextSelect != null)
				{
					zYTextSelect.IsNeed = !zYTextSelect.IsNeed;
					return true;
				}
				break;
			}
			return false;
		}
	}
}
