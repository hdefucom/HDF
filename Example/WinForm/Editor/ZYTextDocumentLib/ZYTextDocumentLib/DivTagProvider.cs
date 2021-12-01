using System.Collections;
using System.Drawing;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class DivTagProvider : SmartTagProvider
	{
		public override int ImageIndex => 16;

		public override bool isEnable()
		{
			return Element is ZYTextDiv;
		}

		public override void GetCommands(ArrayList myList)
		{
			ZYTextDiv zYTextDiv = OwnerDocument.Content.CurrentElement.Parent as ZYTextDiv;
			if (zYTextDiv != null)
			{
				myList.Add(new SmartTagItem(this, 1, "标题名称"));
				myList.Add(new SmartTagItem("-"));
				myList.Add(new SmartTagItem(this, 2, zYTextDiv.HideTitle, "隐藏标题"));
				myList.Add(new SmartTagItem(this, 3, zYTextDiv.NoContent, "不允许包含内容"));
				myList.Add(new SmartTagItem(this, 4, zYTextDiv.TitleLine, "标题占据一行"));
				myList.Add(new SmartTagItem(this, 6, zYTextDiv.TitleAlign == "center", "标题居中"));
				myList.Add(new SmartTagItem(this, 7, zYTextDiv.TitleAlign == "tab", "标题缩进"));
				myList.Add(new SmartTagItem(this, 8, zYTextDiv.TitleAlign == "left", "标题左对齐"));
				myList.Add(new SmartTagItem(this, 9, zYTextDiv.TitleAlign == "right", "标题右对齐"));
				if (zYTextDiv.Title != "")
				{
					myList.Add(new SmartTagItem("-"));
					myList.Add(new SmartTagItem(this, 5, "删除【" + zYTextDiv.Title.Replace("：", "") + "】"));
				}
			}
		}

		public override Point GetPos()
		{
			ZYTextDiv zYTextDiv = OwnerDocument.Content.CurrentElement.Parent as ZYTextDiv;
			if (zYTextDiv != null)
			{
				return new Point(0, zYTextDiv.RealTop);
			}
			return Point.Empty;
		}

		public override bool HandleCommand(SmartTagItem item)
		{
			ZYTextDiv zYTextDiv = OwnerDocument.Content.CurrentElement.Parent as ZYTextDiv;
			if (zYTextDiv != null)
			{
				switch (item.ID)
				{
				case 0:
				{
					string text = dlgInputBox.InputBox("输入新的编号", "系统输入", zYTextDiv.ID);
					if (!StringCommon.isBlankString(text))
					{
						zYTextDiv.ID = text;
						OwnerDocument.Modified = true;
						return true;
					}
					break;
				}
				case 1:
				{
					string[] array = dlgInputBox5.InputBox("设置标题", zYTextDiv.Title, zYTextDiv.FontName, zYTextDiv.FontSize.ToString());
					if (array != null && !StringCommon.isBlankString(array[0]))
					{
						zYTextDiv.Title = array[0];
						zYTextDiv.FontName = array[1];
						zYTextDiv.FontSize = int.Parse(array[2]);
						OwnerDocument.Modified = true;
						OwnerDocument.RefreshLine();
						OwnerDocument.UpdateView();
						OwnerDocument.Refresh();
						return true;
					}
					break;
				}
				case 2:
					zYTextDiv.HideTitle = !zYTextDiv.HideTitle;
					OwnerDocument.Modified = true;
					OwnerDocument.RefreshLine();
					OwnerDocument.UpdateView();
					return true;
				case 3:
					zYTextDiv.NoContent = !zYTextDiv.NoContent;
					OwnerDocument.Modified = true;
					return true;
				case 4:
					zYTextDiv.TitleLine = !zYTextDiv.TitleLine;
					if (!zYTextDiv.TitleLine && zYTextDiv.TitleAlign != "tab")
					{
						zYTextDiv.TitleAlign = "left";
					}
					OwnerDocument.RefreshLine();
					OwnerDocument.UpdateView();
					return true;
				case 5:
					if (OwnerDocument.DocumentElement != zYTextDiv)
					{
						zYTextDiv.Parent.RemoveChild(zYTextDiv);
						OwnerDocument.Modified = true;
						OwnerDocument.RefreshElements();
						OwnerDocument.RefreshLine();
						OwnerDocument.UpdateView();
					}
					return true;
				case 6:
					zYTextDiv.TitleLine = true;
					zYTextDiv.TitleAlign = ((zYTextDiv.TitleAlign == "center") ? "left" : "center");
					OwnerDocument.Modified = true;
					OwnerDocument.RefreshLine();
					OwnerDocument.UpdateView();
					OwnerDocument.OwnerControl.Refresh();
					return true;
				case 7:
					zYTextDiv.TitleAlign = ((zYTextDiv.TitleAlign == "tab") ? "left" : "tab");
					OwnerDocument.Modified = true;
					OwnerDocument.RefreshLine();
					OwnerDocument.UpdateView();
					OwnerDocument.OwnerControl.Refresh();
					return true;
				case 8:
					zYTextDiv.TitleAlign = "left";
					OwnerDocument.Modified = true;
					OwnerDocument.RefreshLine();
					OwnerDocument.UpdateView();
					OwnerDocument.OwnerControl.Refresh();
					return true;
				case 9:
					zYTextDiv.TitleLine = true;
					zYTextDiv.TitleAlign = ((zYTextDiv.TitleAlign == "right") ? "left" : "right");
					OwnerDocument.Modified = true;
					OwnerDocument.RefreshLine();
					OwnerDocument.UpdateView();
					OwnerDocument.OwnerControl.Refresh();
					return true;
				}
			}
			return false;
		}
	}
}
