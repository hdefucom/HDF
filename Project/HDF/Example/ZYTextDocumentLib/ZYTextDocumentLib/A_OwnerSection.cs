using ZYCommon;

namespace ZYTextDocumentLib
{
	public class A_OwnerSection : ZYEditorAction
	{
		public override string ActionName()
		{
			return "ownersection";
		}

		public override bool Execute()
		{
			if (StringCommon.isBlankString(Param1))
			{
				Param1 = null;
			}
			else
			{
				Param1 = Param1.Trim();
			}
			if (base.OwnerDocument.KBBuffer != null)
			{
				base.OwnerDocument.KBBuffer.OwnerSection = Param1;
			}
			return true;
		}
	}
}
