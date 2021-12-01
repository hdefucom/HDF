using DCSoft.Printing;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass157
	{
		private PrintRange printRange_0 = PrintRange.AllPages;

		private DCPrintMode dcprintMode_0 = DCPrintMode.Normal;

		private int int_0 = 0;

		private string string_0 = null;

		private List<int> list_0 = null;

		private int int_1 = 1;

		private bool bool_0 = false;

		private int int_2 = 0;

		private int int_3 = 0;

		private int int_4 = 0;

		private PrintPage printPage_0 = null;

		public PrintRange method_0()
		{
			return printRange_0;
		}

		public void method_1(PrintRange printRange_1)
		{
			printRange_0 = printRange_1;
		}

		public DCPrintMode method_2()
		{
			return dcprintMode_0;
		}

		public void method_3(DCPrintMode dcprintMode_1)
		{
			dcprintMode_0 = dcprintMode_1;
		}

		public int method_4()
		{
			return int_0;
		}

		public void method_5(int int_5)
		{
			int_0 = int_5;
		}

		public string method_6()
		{
			return string_0;
		}

		public void method_7(string string_1)
		{
			string_0 = string_1;
		}

		public List<int> method_8()
		{
			return list_0;
		}

		public void method_9(List<int> list_1)
		{
			list_0 = list_1;
		}

		public int method_10()
		{
			return int_1;
		}

		public void method_11(int int_5)
		{
			int_1 = int_5;
		}

		public bool method_12()
		{
			return bool_0;
		}

		public void method_13(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public int method_14()
		{
			return int_2;
		}

		public void method_15(int int_5)
		{
			int_2 = int_5;
		}

		public int method_16()
		{
			return int_3;
		}

		public void method_17(int int_5)
		{
			int_3 = int_5;
		}

		public int method_18()
		{
			return int_4;
		}

		public void method_19(int int_5)
		{
			int_4 = int_5;
		}

		public PrintPage method_20()
		{
			return printPage_0;
		}

		public void method_21(PrintPage printPage_1)
		{
			printPage_0 = printPage_1;
		}

		private bool method_22(int int_5)
		{
			if (list_0 != null && list_0.Count > 0)
			{
				int num = 0;
				while (true)
				{
					if (num < list_0.Count)
					{
						if (list_0[num] == int_5)
						{
							break;
						}
						num++;
						continue;
					}
					return false;
				}
				return true;
			}
			return true;
		}

		public PrintPageCollection method_23(PrintPageCollection printPageCollection_0)
		{
			if (printPageCollection_0 == null || printPageCollection_0.Count == 0)
			{
				return new PrintPageCollection();
			}
			if (!string.IsNullOrEmpty(method_6()))
			{
				list_0 = new List<int>();
				string[] array = method_6().Split(',');
				foreach (string s in array)
				{
					int result = 0;
					if (int.TryParse(s, out result))
					{
						list_0.Add(result);
					}
				}
			}
			PrintPageCollection printPageCollection = new PrintPageCollection();
			switch (method_0())
			{
			case PrintRange.CurrentPage:
				if (method_20() != null)
				{
					printPageCollection.Add(method_20());
				}
				break;
			case PrintRange.AllPages:
			{
				if (method_2() == DCPrintMode.OddPage)
				{
					for (int j = method_14(); j < printPageCollection_0.Count; j++)
					{
						if (j % 2 == 0 && method_22(j))
						{
							printPageCollection.Add(printPageCollection_0[j]);
						}
					}
					break;
				}
				if (method_2() == DCPrintMode.EvenPage)
				{
					for (int j = method_14(); j < printPageCollection_0.Count; j++)
					{
						if (j % 2 == 1 && method_22(j))
						{
							printPageCollection.Add(printPageCollection_0[j]);
						}
					}
					break;
				}
				if (method_2() == DCPrintMode.ManualDuplex)
				{
					if (method_4() == 1)
					{
						for (int j = method_14(); j < printPageCollection_0.Count; j++)
						{
							if (j % 2 == 0 && method_22(j))
							{
								printPageCollection.Add(printPageCollection_0[j]);
							}
						}
						method_5(2);
					}
					else
					{
						if (method_4() != 2)
						{
							break;
						}
						for (int j = method_14(); j < printPageCollection_0.Count; j++)
						{
							if (j % 2 == 1 && method_22(j))
							{
								printPageCollection.Add(printPageCollection_0[j]);
							}
						}
						method_5(0);
					}
					break;
				}
				if (list_0 != null && list_0.Count > 0)
				{
					for (int j = 0; j < list_0.Count; j++)
					{
						int num4 = list_0[j];
						if (num4 >= 0 && num4 < printPageCollection_0.Count)
						{
							printPageCollection.Add(printPageCollection_0[num4]);
						}
					}
				}
				if (printPageCollection.Count != 0)
				{
					break;
				}
				for (int j = method_14(); j < printPageCollection_0.Count; j++)
				{
					if (method_22(j))
					{
						printPageCollection.Add(printPageCollection_0[j]);
					}
				}
				break;
			}
			case PrintRange.Selection:
			{
				for (int j = method_14(); j < printPageCollection_0.Count; j++)
				{
					if (method_22(j))
					{
						printPageCollection.Add(printPageCollection_0[j]);
					}
				}
				break;
			}
			case PrintRange.SomePages:
			{
				int num = Math.Max(method_14(), method_16() - 1);
				int num2 = printPageCollection_0.Count - 1;
				if (method_18() > 0)
				{
					num2 = Math.Min(printPageCollection_0.Count - 1, method_18() - 1);
				}
				if (method_8() != null && method_8().Count > 0)
				{
					for (int j = 0; j < method_8().Count; j++)
					{
						int num3 = method_8()[j];
						if (num3 >= num && num3 <= num2)
						{
							printPageCollection.Add(printPageCollection_0[num3]);
						}
					}
				}
				else
				{
					for (int j = Math.Max(method_14(), method_16() - 1); j <= num2; j++)
					{
						printPageCollection.Add(printPageCollection_0[j]);
					}
				}
				break;
			}
			}
			if (method_10() > 1 && printPageCollection.Count > 0)
			{
				int num5 = method_10();
				int count = printPageCollection.Count;
				if (method_12())
				{
					for (int j = 1; j < num5; j++)
					{
						for (int k = 0; k < count; k++)
						{
							printPageCollection.Add(printPageCollection[k]);
						}
					}
				}
				else
				{
					for (int j = 0; j < count; j++)
					{
						for (int l = 1; l < num5; l++)
						{
							printPageCollection.Insert(j * num5 + l, printPageCollection[j * num5]);
						}
					}
				}
			}
			return printPageCollection;
		}
	}
}
