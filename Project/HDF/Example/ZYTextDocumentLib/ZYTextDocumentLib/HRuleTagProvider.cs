using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class HRuleTagProvider : SmartTagProvider
	{
		public override int ImageIndex => 19;

		public override bool isEnable()
		{
			return Element is ZYTextHRule;
		}

		public override Point GetPos()
		{
			return new Point(Element.RealLeft, Element.RealTop);
		}

		public override void GetCommands(ArrayList myList)
		{
			ZYTextHRule zYTextHRule = Element as ZYTextHRule;
			if (zYTextHRule != null)
			{
				myList.Add(new SmartTagItem(this, 1, "设置线的粗细"));
				myList.Add(new SmartTagItem(this, 2, "设置颜色"));
			}
		}

		public override bool HandleCommand(SmartTagItem item)
		{
			ZYTextHRule zYTextHRule = Element as ZYTextHRule;
			if (zYTextHRule != null)
			{
				switch (item.ID)
				{
				case 1:
				{
					string strData = dlgInputBox.InputBox("请输入线的粗细,输入的值必须在1到10之间", "系统输入", zYTextHRule.LineHeight.ToString());
					if (StringCommon.IsInteger(strData))
					{
						zYTextHRule.LineHeight = StringCommon.ToInt32Value(strData, zYTextHRule.LineHeight);
						OwnerDocument.RefreshElement(zYTextHRule);
					}
					break;
				}
				case 2:
				{
					using (ColorDialog colorDialog = new ColorDialog())
					{
						colorDialog.Color = zYTextHRule.ForeColor;
						if (colorDialog.ShowDialog(OwnerControl) == DialogResult.OK)
						{
							zYTextHRule.ForeColor = colorDialog.Color;
							OwnerDocument.RefreshElement(zYTextHRule);
							return true;
						}
					}
					break;
				}
				}
			}
			return true;
		}
	}
}
