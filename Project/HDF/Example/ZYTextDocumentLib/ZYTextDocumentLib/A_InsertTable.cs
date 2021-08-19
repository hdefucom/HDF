using System.Windows.Forms;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class A_InsertTable : ZYEditorAction
	{
		public override string ActionName()
		{
			return "inserttable";
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public override bool Execute()
		{
			return false;
		}

		public override bool UIExecute()
		{
			string[] array = dlgInputBox2.InputBox2("插入表格", "行数", "列数", "", "", null, null);
			if (array == null)
			{
				return false;
			}
			string[] array2 = array;
			foreach (string strData in array2)
			{
				if (!StringCommon.IsInteger(strData))
				{
					MessageBox.Show("请输入数字");
					return false;
				}
			}
			EMRTable eMRTable = new EMRTable();
			eMRTable.OwnerDocument = myOwnerDocument;
			for (int j = 0; j < int.Parse(array[1]); j++)
			{
				EMRCol eMRCol = new EMRCol();
				eMRCol.OwnerTable = eMRTable;
				eMRTable.Cols.Add(eMRCol);
			}
			for (int j = 0; j < int.Parse(array[0]); j++)
			{
				eMRTable.InsertRow();
			}
			myOwnerDocument._InsertElement(eMRTable);
			return false;
		}
	}
}
