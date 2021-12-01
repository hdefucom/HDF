namespace DCSoftDotfuscate
{
	internal abstract class Class84
	{
		public string string_0 = "";

		public string string_1 = null;

		public virtual string vmethod_0()
		{
			return null;
		}

		protected bool method_0(string string_2)
		{
			int num = 6;
			int num2 = 0;
			while (true)
			{
				if (num2 < string_2.Length)
				{
					char value = string_2[num2];
					if ("0123456789".IndexOf(value) < 0)
					{
						break;
					}
					num2++;
					continue;
				}
				return true;
			}
			return false;
		}
	}
}
