namespace ZYTextDocumentLib
{
	public class EMRCol
	{
		protected int intLeft = 0;

		protected int intWidth = 100;

		protected EMRTable myOwnerTable = null;

		public int Index => myOwnerTable.Cols.IndexOf(this);

		public int Left
		{
			get
			{
				return intLeft;
			}
			set
			{
				intLeft = value;
			}
		}

		public EMRTable OwnerTable
		{
			get
			{
				return myOwnerTable;
			}
			set
			{
				myOwnerTable = value;
			}
		}

		public int Width
		{
			get
			{
				return intWidth;
			}
			set
			{
				intWidth = value;
			}
		}
	}
}
