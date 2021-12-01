using System.Collections;
using System.Text;
using System.Windows.Forms;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class A_ConvertTextToSelect : ZYEditorAction
	{
		public KB_List myOwnerKBList = null;

		private int ItemCount = 0;

		public override string ActionName()
		{
			return "converttexttoselect";
		}

		public override bool isEnable()
		{
			if (myOwnerDocument.CanModify() && myOwnerDocument.Content.HasSelectedText())
			{
				return base.isEnable();
			}
			return false;
		}

		private string[] GetItems()
		{
			string selectedText = myOwnerDocument.Content.GetSelectedText();
			if (selectedText != null)
			{
				string[] array = selectedText.Split("、,;，；".ToCharArray());
				ArrayList arrayList = new ArrayList();
				string[] array2 = array;
				foreach (string text in array2)
				{
					if (text.Trim().Length > 0)
					{
						arrayList.Add(text.Trim());
					}
				}
				if (arrayList.Count > 0)
				{
					return (string[])arrayList.ToArray(typeof(string));
				}
			}
			return null;
		}

		public override bool Execute()
		{
			ItemCount = 0;
			if (myOwnerKBList != null && !myOwnerKBList.HasChildren())
			{
				string selectedText = myOwnerDocument.Content.GetSelectedText();
				if (selectedText != null)
				{
					string[] array = selectedText.Split("、,;，；".ToCharArray());
					string[] array2 = array;
					foreach (string text in array2)
					{
						string text2 = text.Trim();
						if (text.Length > 0)
						{
							KB_Item kB_Item = myOwnerKBList.NewItem(text);
							if (kB_Item == null)
							{
								return false;
							}
							kB_Item.ItemValue = text;
							kB_Item.ItemStyle = 0;
							ItemCount++;
						}
					}
					if (ItemCount > 0)
					{
						ZYTextSelect zYTextSelect = new ZYTextSelect();
						zYTextSelect.OwnerKBList = myOwnerKBList;
						zYTextSelect.Text = "[" + myOwnerKBList.Name + "]";
						myOwnerDocument._InsertSelect(zYTextSelect);
						return true;
					}
				}
			}
			return false;
		}

		public override bool UIExecute()
		{
			string[] items = GetItems();
			if (items != null)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("所有选中的文本分析得出以下" + items.Length + "个项目");
				string[] array = items;
				foreach (string str in array)
				{
					stringBuilder.Append("\r\n         " + str);
				}
				stringBuilder.Append("\r\n \r\n请选择确定一个按钮\r\n   [  是  ] 将该列表添加到知识库中\r\n   [  否  ] 不将该列表添加到知识库中,这些项目只能在本列表中使用\r\n   [取消] 取消将文本转换为列表的操作");
				switch (MessageBox.Show(null, stringBuilder.ToString(), "将文本转换为列表", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
				{
				case DialogResult.Yes:
				{
					using (dlgKBPath dlgKBPath = new dlgKBPath())
					{
						if (dlgKBPath.ShowDialog() == DialogResult.OK)
						{
							myOwnerKBList = dlgKBPath.SelectedList;
							array = items;
							foreach (string str in array)
							{
								string text2 = str.Trim();
								if (str.Length > 0)
								{
									KB_Item kB_Item = myOwnerKBList.NewItem(str);
									if (kB_Item == null)
									{
										return false;
									}
									kB_Item.ItemValue = str;
									kB_Item.ItemStyle = 0;
									ItemCount++;
								}
							}
							if (ItemCount > 0)
							{
								ZYTextSelect zYTextSelect = new ZYTextSelect();
								zYTextSelect.OwnerDocument = base.OwnerDocument;
								zYTextSelect.OwnerKBList = myOwnerKBList;
								zYTextSelect.Text = "[" + myOwnerKBList.Name + "]";
								myOwnerDocument._InsertSelect(zYTextSelect);
								return true;
							}
							MessageBox.Show("共添加" + ItemCount + "个列表项目");
						}
					}
					break;
				}
				case DialogResult.No:
				{
					string text = dlgInputBox.InputBox("请输入该列表的名称", "新增列表", StringCommon.AllocObjectName());
					if (!StringCommon.isBlankString(text))
					{
						ZYTextSelect zYTextSelect = new ZYTextSelect();
						array = items;
						foreach (string str in array)
						{
							zYTextSelect.AddOption(str);
						}
						zYTextSelect.Name = text.Trim();
						zYTextSelect.Text = "[" + text.Trim() + "]";
						zYTextSelect.ID = text.Trim();
						zYTextSelect.SaveList = true;
						myOwnerDocument._InsertSelect(zYTextSelect);
					}
					break;
				}
				case DialogResult.Cancel:
					return false;
				}
			}
			return true;
		}
	}
}
