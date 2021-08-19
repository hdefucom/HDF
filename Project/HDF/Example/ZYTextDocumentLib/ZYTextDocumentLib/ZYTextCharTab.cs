namespace ZYTextDocumentLib
{
	public class ZYTextCharTab : ZYTextChar
	{
		public void RefreshTabWidth()
		{
			intWidth = myOwnerDocument.View.GetTabWidth(RealLeft);
		}

		public override string ToEMRString()
		{
			return "\t";
		}

		public override string ToString()
		{
			return "ZYTextCharTab";
		}
	}
}
