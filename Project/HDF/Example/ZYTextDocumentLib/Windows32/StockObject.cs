using System;
using System.Runtime.InteropServices;

namespace Windows32
{
	public sealed class StockObject
	{
		private enum _StockObjectType
		{
			WHITE_BRUSH = 0,
			LTGRAY_BRUSH = 1,
			GRAY_BRUSH = 2,
			DKGRAY_BRUSH = 3,
			BLACK_BRUSH = 4,
			NULL_BRUSH = 5,
			HOLLOW_BRUSH = 5,
			WHITE_PEN = 6,
			BLACK_PEN = 7,
			NULL_PEN = 8,
			OEM_FIXED_FONT = 10,
			ANSI_FIXED_FONT = 11,
			ANSI_VAR_FONT = 12,
			SYSTEM_FONT = 13,
			DEVICE_DEFAULT_FONT = 14,
			DEFAULT_PALETTE = 0xF,
			SYSTEM_FIXED_FONT = 0x10,
			DEFAULT_GUI_FONT = 17,
			DC_BRUSH = 18,
			DC_PEN = 19
		}

		public static IntPtr WHITE_BRUSH => GetStockObject(_StockObjectType.WHITE_BRUSH);

		public static IntPtr LTGRAY_BRUSH => GetStockObject(_StockObjectType.LTGRAY_BRUSH);

		public static IntPtr GRAY_BRUSH => GetStockObject(_StockObjectType.GRAY_BRUSH);

		public static IntPtr DKGRAY_BRUSH => GetStockObject(_StockObjectType.DKGRAY_BRUSH);

		public static IntPtr BLACK_BRUSH => GetStockObject(_StockObjectType.BLACK_BRUSH);

		public static IntPtr NULL_BRUSH => GetStockObject(_StockObjectType.NULL_BRUSH);

		public static IntPtr HOLLOW_BRUSH => GetStockObject(_StockObjectType.NULL_BRUSH);

		public static IntPtr WHITE_PEN => GetStockObject(_StockObjectType.WHITE_PEN);

		public static IntPtr BLACK_PEN => GetStockObject(_StockObjectType.BLACK_PEN);

		public static IntPtr NULL_PEN => GetStockObject(_StockObjectType.NULL_PEN);

		public static IntPtr OEM_FIXED_FONT => GetStockObject(_StockObjectType.OEM_FIXED_FONT);

		public static IntPtr ANSI_FIXED_FONT => GetStockObject(_StockObjectType.ANSI_FIXED_FONT);

		public static IntPtr ANSI_VAR_FONT => GetStockObject(_StockObjectType.ANSI_VAR_FONT);

		public static IntPtr SYSTEM_FONT => GetStockObject(_StockObjectType.SYSTEM_FONT);

		public static IntPtr DEVICE_DEFAULT_FONT => GetStockObject(_StockObjectType.DEVICE_DEFAULT_FONT);

		public static IntPtr DEFAULT_PALETTE => GetStockObject(_StockObjectType.DEFAULT_PALETTE);

		public static IntPtr SYSTEM_FIXED_FONT => GetStockObject(_StockObjectType.SYSTEM_FIXED_FONT);

		public static IntPtr DEFAULT_GUI_FONT => GetStockObject(_StockObjectType.DEFAULT_GUI_FONT);

		public static IntPtr DC_BRUSH => GetStockObject(_StockObjectType.DC_BRUSH);

		public static IntPtr DC_PEN => GetStockObject(_StockObjectType.DC_PEN);

		private StockObject()
		{
		}

		[DllImport("gdi32")]
		private static extern IntPtr GetStockObject(_StockObjectType fnObject);
	}
}
