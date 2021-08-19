using System.Runtime.InteropServices;

namespace DCSoft.Data
{
	                                                                    /// <summary>
	                                                                    ///       多位数据的累计器
	                                                                    ///       </summary>
	[ComVisible(false)]
	public class MultiNumberCounter
	{
		private int[] myMinValue = null;

		private int[] myMaxValue = null;

		private int[] myValue = null;

		public int[] MinValue
		{
			get
			{
				return myMinValue;
			}
			set
			{
				myMinValue = value;
			}
		}

		public int[] MaxValue
		{
			get
			{
				return myMaxValue;
			}
			set
			{
				myMaxValue = value;
			}
		}

		public int Length => myMaxValue.Length;

		public int[] Value
		{
			get
			{
				return myValue;
			}
			set
			{
				myValue = value;
			}
		}

		public int this[int index] => myValue[index];

		public void SetToMaxValue()
		{
			CheckMinValue();
			myValue = (int[])myMaxValue.Clone();
		}

		public void SetToMinValue()
		{
			CheckMinValue();
			myValue = (int[])myMinValue.Clone();
		}

		private void CheckMinValue()
		{
			if (myMinValue == null)
			{
				myMinValue = new int[myMaxValue.Length];
			}
		}

		                                                                    /// <summary>
		                                                                    ///       自减一
		                                                                    ///       </summary>
		                                                                    /// <returns>修改后的数据是否低于最低值</returns>
		public bool Decrement()
		{
			for (int num = myValue.Length - 1; num >= 0; num--)
			{
				myValue[num]--;
				if (myValue[num] >= myMinValue[num] || num == 0)
				{
					break;
				}
				myValue[num] = myMinValue[num];
			}
			return myValue[0] >= myMinValue[0];
		}

		                                                                    /// <summary>
		                                                                    ///       自增一
		                                                                    ///       </summary>
		                                                                    /// <returns>修改后的数据是否高于最大值</returns>
		public bool Increment()
		{
			for (int num = myValue.Length - 1; num >= 0; num--)
			{
				myValue[num]++;
				if (myValue[num] <= myMaxValue[num] || num == 0)
				{
					break;
				}
				myValue[num] = myMaxValue[num];
			}
			return myValue[0] <= myMaxValue[0];
		}
	}
}
