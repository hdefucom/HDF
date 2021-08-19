using System.Collections;
using System.Windows.Forms;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class TextFlagProvider : SmartTagProvider
	{
		public override bool isEnable()
		{
			return Element is ZYTextFlag;
		}

		public override void GetCommands(ArrayList myList)
		{
			ZYTextFlag zYTextFlag = Element as ZYTextFlag;
			if (zYTextFlag != null)
			{
				myList.Add(new SmartTagItem(this, 1, "设置文本"));
				myList.Add(new SmartTagItem(this, 2, "设置字体"));
			}
		}

		public override bool HandleCommand(SmartTagItem item)
		{
			ZYTextFlag zYTextFlag = Element as ZYTextFlag;
			if (zYTextFlag != null)
			{
				if (item.ID == 1)
				{
					string text = dlgInputBox.InputBox("请输入文本块的内容", "输入", zYTextFlag.Text);
					if (text != null)
					{
						zYTextFlag.Text = text;
						zYTextFlag.RefreshSize();
						OwnerDocument.RefreshElement(zYTextFlag);
						OwnerDocument.RefreshLine();
						OwnerDocument.Refresh();
						OwnerDocument.Modified = true;
					}
				}
				else if (item.ID == 2)
				{
					using (FontDialog fontDialog = new FontDialog())
					{
						fontDialog.Font = zYTextFlag.Font;
						if (fontDialog.ShowDialog() == DialogResult.OK)
						{
							zYTextFlag.Font = fontDialog.Font;
							zYTextFlag.RefreshSize();
							OwnerDocument.RefreshElement(zYTextFlag);
							OwnerDocument.RefreshLine();
							OwnerDocument.Modified = true;
						}
					}
				}
				return true;
			}
			return false;
		}
	}
}
