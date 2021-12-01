using System;

namespace DCSoftDotfuscate
{
	public class GClass275 : GClass274
	{
		private static GClass275 gclass275_0 = null;

		public string Name => method_1("Name");

		public static GClass275 smethod_1()
		{
			if (gclass275_0 == null)
			{
				gclass275_0 = new GClass275();
				gclass275_0.vmethod_1();
			}
			return gclass275_0;
		}

		public override string vmethod_0()
		{
			return "Win32_NetworkAdapter";
		}

		public string method_8()
		{
			return method_1("AdapterType");
		}

		public ushort method_9()
		{
			return method_5("AdapterTypeID");
		}

		public bool method_10()
		{
			return method_2("AutoSense");
		}

		public ushort method_11()
		{
			return method_5("Availability");
		}

		public string method_12()
		{
			return method_1("Caption");
		}

		public uint method_13()
		{
			return method_6("ConfigManagerErrorCode");
		}

		public bool method_14()
		{
			return method_2("ConfigManagerUserConfig");
		}

		public string method_15()
		{
			return method_1("CreationClassName");
		}

		public string method_16()
		{
			return method_1("Description");
		}

		public string method_17()
		{
			return method_1("DeviceID");
		}

		public bool method_18()
		{
			return method_2("ErrorCleared");
		}

		public string method_19()
		{
			return method_1("ErrorDescription");
		}

		public uint method_20()
		{
			return method_6("Index");
		}

		public DateTime method_21()
		{
			return method_7("InstallDate");
		}

		public bool method_22()
		{
			return method_2("Installed");
		}

		public uint method_23()
		{
			return method_6("InterfaceIndex");
		}

		public uint method_24()
		{
			return method_6("LastErrorCode");
		}

		public string method_25()
		{
			return method_1("MACAddress");
		}

		public string method_26()
		{
			return method_1("Manufacturer");
		}

		public uint method_27()
		{
			return method_6("MaxNumberControlled");
		}

		public ulong method_28()
		{
			return method_4("MaxSpeed");
		}

		public string method_29()
		{
			return method_1("NetConnectionID");
		}

		public ushort method_30()
		{
			return method_5("NetConnectionStatus");
		}

		public string method_31()
		{
			return method_1("PermanentAddress");
		}

		public string method_32()
		{
			return method_1("PNPDeviceID");
		}

		public bool method_33()
		{
			return method_2("PowerManagementSupported");
		}

		public string method_34()
		{
			return method_1("ProductName");
		}

		public string method_35()
		{
			return method_1("ServiceName");
		}

		public ulong method_36()
		{
			return method_4("Speed");
		}

		public string method_37()
		{
			return method_1("Status");
		}

		public ushort method_38()
		{
			return method_5("StatusInfo");
		}

		public string method_39()
		{
			return method_1("SystemCreationClassName");
		}

		public string method_40()
		{
			return method_1("SystemName");
		}
	}
}
