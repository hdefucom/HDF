using System;
using System.Runtime.InteropServices ;
namespace Windows32
{
	/// <summary>
	/// Win32API函数StockObject的封装
	/// </summary>
	public sealed class StockObject
	{
		/// <summary>
		/// White brush.
		/// </summary>
		public static IntPtr WHITE_BRUSH	 { get{ return GetStockObject( _StockObjectType.WHITE_BRUSH	 );}}
		/// <summary>
		/// Light gray brush.
		/// </summary>
		public static IntPtr LTGRAY_BRUSH	 { get{ return GetStockObject( _StockObjectType.LTGRAY_BRUSH	 );}}
		/// <summary>
		/// Gray brush.
		/// </summary>
		public static IntPtr GRAY_BRUSH	 { get{ return GetStockObject( _StockObjectType.GRAY_BRUSH	 );}}
		/// <summary>
		/// Dark gray brush.
		/// </summary>
		public static IntPtr DKGRAY_BRUSH	 { get{ return GetStockObject( _StockObjectType.DKGRAY_BRUSH	 );}}
		/// <summary>
		/// Black brush.
		/// </summary>
		public static IntPtr BLACK_BRUSH	 { get{ return GetStockObject( _StockObjectType.BLACK_BRUSH	 );}}
		/// <summary>
		/// Null brush (equivalent to HOLLOW_BRUSH).
		/// </summary>
		public static IntPtr NULL_BRUSH	 { get{ return GetStockObject( _StockObjectType.NULL_BRUSH	 );}}
		/// <summary>
		/// Hollow brush (equivalent to NULL_BRUSH).
		/// </summary>
		public static IntPtr HOLLOW_BRUSH	 { get{ return GetStockObject( _StockObjectType.HOLLOW_BRUSH	 );}}
		/// <summary>
		/// White pen.
		/// </summary>
		public static IntPtr WHITE_PEN	 { get{ return GetStockObject( _StockObjectType.WHITE_PEN	 );}}
		/// <summary>
		/// Black pen.
		/// </summary>
		public static IntPtr BLACK_PEN	 { get{ return GetStockObject( _StockObjectType.BLACK_PEN	 );}}
		public static IntPtr NULL_PEN	 { get{ return GetStockObject( _StockObjectType.NULL_PEN	 );}}
		/// <summary>
		/// Original equipment manufacturer (OEM) dependent fixed-pitch (monospace) font.
		/// </summary>
		public static IntPtr OEM_FIXED_FONT	 { get{ return GetStockObject( _StockObjectType.OEM_FIXED_FONT	 );}}
		/// <summary>
		/// Windows fixed-pitch (monospace) system font.
		/// </summary>
		public static IntPtr ANSI_FIXED_FONT	 { get{ return GetStockObject( _StockObjectType.ANSI_FIXED_FONT	 );}}
		/// <summary>
		/// Windows variable-pitch (proportional space) system font.
		/// </summary>
		public static IntPtr ANSI_VAR_FONT	 { get{ return GetStockObject( _StockObjectType.ANSI_VAR_FONT	 );}}
		/// <summary>
		/// System font. By default, the system uses the system font to draw menus, dialog box controls, and text. 
		/// Windows 95/98 and Windows NT: The system font is MS Sans Serif. 
		/// Windows 2000/XP: The system font is Tahoma
		/// </summary>
		public static IntPtr SYSTEM_FONT	 { get{ return GetStockObject( _StockObjectType.SYSTEM_FONT	 );}}
		/// <summary>
		/// Windows NT/2000/XP: Device-dependent font.
		/// </summary>
		public static IntPtr DEVICE_DEFAULT_FONT	 { get{ return GetStockObject( _StockObjectType.DEVICE_DEFAULT_FONT	 );}}
		/// <summary>
		/// Default palette. This palette consists of the static colors in the system palette.
		/// </summary>
		public static IntPtr DEFAULT_PALETTE	 { get{ return GetStockObject( _StockObjectType.DEFAULT_PALETTE	 );}}
		/// <summary>
		/// Fixed-pitch (monospace) system font. This stock object is provided only for compatibility with 16-bit Windows versions earlier than 3.0. 
		/// </summary>
		public static IntPtr SYSTEM_FIXED_FONT	 { get{ return GetStockObject( _StockObjectType.SYSTEM_FIXED_FONT	 );}}
		/// <summary>
		/// Default font for user interface objects such as menus and dialog boxes. This is MS Sans Serif. Compare this with SYSTEM_FONT.
		/// </summary>
		public static IntPtr DEFAULT_GUI_FONT	 { get{ return GetStockObject( _StockObjectType.DEFAULT_GUI_FONT	 );}}
		/// <summary>
		/// Windows 2000/XP: Solid color brush. The default color is white. The color can be changed by using the SetDCBrushColor function. For more information, see the Remarks section.
		/// </summary>
		public static IntPtr DC_BRUSH	 { get{ return GetStockObject( _StockObjectType.DC_BRUSH	 );}}
		/// <summary>
		/// Windows 2000/XP: Solid pen color. The default color is white. The color can be changed by using the SetDCPenColor function. For more information, see the Remarks section.
		/// </summary>
		public static IntPtr DC_PEN	 { get{ return GetStockObject( _StockObjectType.DC_PEN	 );}}

		#region 内部代码 **************************************************************************

		private StockObject()
		{
		}

		[DllImport("gdi32")]
		private static extern IntPtr GetStockObject( _StockObjectType fnObject );

		private enum _StockObjectType
		{
			WHITE_BRUSH         = 0 , 
			LTGRAY_BRUSH        = 1 ,
			GRAY_BRUSH          = 2 ,
			DKGRAY_BRUSH        = 3 ,
			BLACK_BRUSH         = 4 ,
			NULL_BRUSH          = 5 ,
			HOLLOW_BRUSH        = 5 ,
			WHITE_PEN           = 6 ,
			BLACK_PEN           = 7 ,
			NULL_PEN            = 8 ,
			OEM_FIXED_FONT      = 10,
			ANSI_FIXED_FONT     = 11,
			ANSI_VAR_FONT       = 12,
			SYSTEM_FONT         = 13,
			DEVICE_DEFAULT_FONT = 14,
			DEFAULT_PALETTE     = 15,
			SYSTEM_FIXED_FONT   = 16,
			DEFAULT_GUI_FONT    = 17,
			DC_BRUSH            = 18,
			DC_PEN              = 19
		}

		#endregion

	}//public sealed class StockObject
}