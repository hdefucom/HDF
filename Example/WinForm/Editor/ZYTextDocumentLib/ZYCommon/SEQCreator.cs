namespace ZYCommon
{
	public class SEQCreator
	{
		private string strSEQ = null;

		private int intSEQStep = 1;

		private string strSEQChars = "0123456789";

		private int[] intCharIndexs = null;

		private int intFixLength = 0;

		public int FixLength
		{
			get
			{
				return intFixLength;
			}
			set
			{
				intFixLength = value;
				ResetCharIndexs();
			}
		}

		public string SEQ
		{
			get
			{
				return strSEQ;
			}
			set
			{
				strSEQ = value;
				ResetCharIndexs();
			}
		}

		public int SEQStep
		{
			get
			{
				return intSEQStep;
			}
			set
			{
				intSEQStep = value;
			}
		}

		public string SEQChars
		{
			get
			{
				return strSEQChars;
			}
			set
			{
				strSEQChars = value;
				ResetCharIndexs();
			}
		}

		private void ResetCharIndexs()
		{
			if (intFixLength > 0)
			{
				if (strSEQ == null)
				{
					strSEQ = new string(strSEQChars[0], intFixLength);
				}
				else if (strSEQ.Length != intFixLength)
				{
					strSEQ = strSEQ.PadRight(intFixLength, strSEQChars[0]);
				}
			}
			intCharIndexs = new int[strSEQ.Length];
			for (int i = 0; i < strSEQ.Length; i++)
			{
				intCharIndexs[i] = strSEQChars.IndexOf(strSEQ[i]);
			}
		}

		public string Create()
		{
			char[] array = strSEQ.ToCharArray();
			intCharIndexs[intCharIndexs.Length - 1] += intSEQStep;
			int num = intCharIndexs.Length - 1;
			while (num > 0 && intCharIndexs[num] >= strSEQChars.Length)
			{
				intCharIndexs[num] %= strSEQChars.Length;
				if (intCharIndexs[num - 1] >= 0)
				{
					intCharIndexs[num - 1]++;
					num--;
					continue;
				}
				break;
			}
			for (num = intCharIndexs.Length - 1; num > 0; num--)
			{
				if (intCharIndexs[num] >= 0)
				{
					array[num] = strSEQChars[intCharIndexs[num]];
				}
			}
			strSEQ = new string(array);
			if (intFixLength > 0)
			{
				if (strSEQ == null)
				{
					strSEQ = new string(strSEQChars[0], intFixLength);
				}
				else if (strSEQ.Length != intFixLength)
				{
					strSEQ = strSEQ.PadRight(intFixLength, strSEQChars[0]);
				}
			}
			return strSEQ;
		}
	}
}
