using DCSoftDotfuscate;
using System;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.WinForms
{
	/// <summary>
	///       系统硬件信息
	///       </summary>
	[Serializable]
	public class SystemHardwareInfo
	{
		/// <summary>
		///       屏幕信息
		///       </summary>
		[XmlElement("屏幕")]
		public string Screen = null;

		/// <summary>
		///       物理内存
		///       </summary>
		[XmlElement("物理内存")]
		public long TotalPhys = 0L;

		/// <summary>
		///       可用物理内存
		///       </summary>
		[XmlElement("可用物理内存")]
		public long AvailPhys = 0L;

		/// <summary>
		///       CPU信息
		///       </summary>
		public string CPU = null;

		/// <summary>
		///       初始化对象
		///       </summary>
		public SystemHardwareInfo()
		{
			Screen = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width + "*" + System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
			GClass272.smethod_7();
			TotalPhys = GClass272.smethod_1();
			AvailPhys = GClass272.smethod_2();
			CPU = GClass276.smethod_1().Name + " " + GClass276.smethod_1().method_19();
		}
	}
}
