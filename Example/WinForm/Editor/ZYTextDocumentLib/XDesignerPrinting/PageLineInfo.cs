using System.Drawing;

namespace XDesignerPrinting
{
	public class PageLineInfo
	{
		private int intMinPageHeight = 0;

		private int intPageIndex = 0;

		private int intFirstPos = 0;

		private int intLastPos = 0;

		private int intPos = 0;

		private bool bolModified = false;

		internal int MinPageHeight
		{
			get
			{
				return intMinPageHeight;
			}
			set
			{
				intMinPageHeight = value;
			}
		}

		public int PageIndex => intPageIndex;

		public int FirstPos => intFirstPos;

		public int LastPos => intLastPos;

		public int Pos
		{
			get
			{
				return intPos;
			}
			set
			{
				if (value > intLastPos && value < intPos && (intMinPageHeight <= 0 || value - intLastPos >= intMinPageHeight))
				{
					intPos = value;
					bolModified = true;
				}
			}
		}

		public bool Modified
		{
			get
			{
				return bolModified;
			}
			set
			{
				bolModified = value;
			}
		}

		public PageLineInfo(int vFirstPos, int vLastPos, int vPos, int vPageIndex)
		{
			intFirstPos = vFirstPos;
			intLastPos = vLastPos;
			intPos = vPos;
			intPageIndex = vPageIndex;
		}

		public bool CanSet(int vPos)
		{
			if (vPos > intLastPos && vPos < intPos)
			{
				if (intMinPageHeight > 0 && vPos - intLastPos < intMinPageHeight)
				{
					return false;
				}
				return true;
			}
			return false;
		}

		public bool Match(int Top, int Bottom)
		{
			return intPos >= Top && intPos < Bottom;
		}

		public bool Match(Rectangle rect)
		{
			return intPos >= rect.Top && intPos < rect.Bottom;
		}
	}
}
