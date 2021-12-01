namespace ZYTextDocumentLib
{
	public class SmartTagItem
	{
		public SmartTagProvider Provider;

		public bool Checked;

		public string Text;

		public int ID = -1;

		public string Data;

		public SmartTagItem(string txt)
		{
			Text = txt;
		}

		public SmartTagItem(SmartTagProvider p, int vID, bool c, string txt, string vData)
		{
			Provider = p;
			ID = vID;
			Checked = c;
			Text = txt;
			Data = vData;
		}

		public SmartTagItem(SmartTagProvider p, int vID, bool c, string txt)
		{
			Provider = p;
			ID = vID;
			Checked = c;
			Text = txt;
		}

		public SmartTagItem(SmartTagProvider p, int vID, string txt)
		{
			Provider = p;
			ID = vID;
			Checked = false;
			Text = txt;
		}
	}
}
