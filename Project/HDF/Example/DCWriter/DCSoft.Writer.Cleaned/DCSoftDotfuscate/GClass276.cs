using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass276 : GClass274
	{
		private static GClass276 gclass276_0 = null;

		public string Name => method_1("Name");

		public static GClass276 smethod_1()
		{
			if (gclass276_0 == null)
			{
				gclass276_0 = new GClass276();
				gclass276_0.vmethod_1();
			}
			return gclass276_0;
		}

		public override string vmethod_0()
		{
			return "Win32_Processor";
		}

		public ushort method_8()
		{
			return method_5("AddressWidth");
		}

		public ushort method_9()
		{
			return method_5("Architecture");
		}

		public ushort method_10()
		{
			return method_5("Availability");
		}

		public string method_11()
		{
			return method_1("Caption");
		}

		public uint method_12()
		{
			return method_6("ConfigManagerErrorCode");
		}

		public bool method_13()
		{
			return method_2("ConfigManagerUserConfig");
		}

		public ushort method_14()
		{
			return method_5("CpuStatus");
		}

		public string method_15()
		{
			return method_1("CreationClassName");
		}

		public uint method_16()
		{
			return method_5("CurrentClockSpeed");
		}

		public ushort method_17()
		{
			return method_5("CurrentVoltage");
		}

		public ushort method_18()
		{
			return method_5("DataWidth");
		}

		public string method_19()
		{
			return method_1("Description");
		}

		public string method_20()
		{
			return method_1("DeviceID");
		}

		public bool method_21()
		{
			return method_2("ErrorCleared");
		}

		public string method_22()
		{
			return method_1("ErrorDescription");
		}

		public uint method_23()
		{
			return method_5("ExtClock");
		}

		public ushort method_24()
		{
			return method_5("Family");
		}

		public DateTime method_25()
		{
			return method_7("InstallDate");
		}

		public uint method_26()
		{
			return method_6("L2CacheSize");
		}

		public uint method_27()
		{
			return method_6("L2CacheSpeed");
		}

		public uint method_28()
		{
			return method_6("LastErrorCode");
		}

		public ushort method_29()
		{
			return method_5("Level");
		}

		public ushort method_30()
		{
			return method_5("LoadPercentage");
		}

		public string method_31()
		{
			return method_1("Manufacturer");
		}

		public uint method_32()
		{
			return method_5("MaxClockSpeed");
		}

		public string method_33()
		{
			return method_1("OtherFamilyDescription");
		}

		public string method_34()
		{
			return method_1("PNPDeviceID");
		}

		public bool method_35()
		{
			return method_2("PowerManagementSupported");
		}

		public string method_36()
		{
			return method_1("ProcessorId");
		}

		public ushort method_37()
		{
			return method_5("ProcessorType");
		}

		public ushort method_38()
		{
			return method_5("Revision");
		}

		public string method_39()
		{
			return method_1("Role");
		}

		public string method_40()
		{
			return method_1("SocketDesignation");
		}

		public string method_41()
		{
			return method_1("Status");
		}

		public ushort method_42()
		{
			return method_5("StatusInfo");
		}

		public string method_43()
		{
			return method_1("Stepping");
		}

		public string method_44()
		{
			return method_1("SystemCreationClassName");
		}

		public string method_45()
		{
			return method_1("SystemName");
		}

		public string method_46()
		{
			return method_1("UniqueId");
		}

		public ushort method_47()
		{
			return method_5("UpgradeMethod");
		}

		public string method_48()
		{
			return method_1("Version");
		}

		public uint method_49()
		{
			return method_6("VoltageCaps");
		}
	}
}
