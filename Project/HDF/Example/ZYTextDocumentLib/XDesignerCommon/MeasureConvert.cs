namespace XDesignerCommon
{
	public sealed class MeasureConvert
	{
		public static double InchToMillimeter(double vValue)
		{
			return vValue * 25.4;
		}

		public static double MillimeterToInch(double vValue)
		{
			return vValue / 25.4;
		}

		public static double DocumentToMillimeter(double vValue)
		{
			return vValue * 0.254 / 3.0;
		}

		public static double MillimeterToDocument(double vValue)
		{
			return vValue * 3.0 / 0.254;
		}

		public static double HundredthsInchToMillimeter(double vValue)
		{
			return vValue * 0.254;
		}

		public static double MillimeterToHundredthsInch(double vValue)
		{
			return vValue / 0.254;
		}

		public static double InchToCentimeter(double vValue)
		{
			return vValue * 2.54;
		}

		public static double FootToInch(double vValue)
		{
			return vValue * 12.0;
		}

		public static double FootToRice(double vValue)
		{
			return vValue * 0.3048;
		}

		private MeasureConvert()
		{
		}
	}
}
