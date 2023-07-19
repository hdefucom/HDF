using System;
using System.Diagnostics;
using System.Management;

namespace GetSystemStatusGUI;

public class RAMInfo
{
	private long m_PhysicalMemory = 0L;

	private PerformanceCounter pcAvailMemory;

	public long MemoryAvailable => (long)Math.Round(pcAvailMemory.NextValue());

	public long PhysicalMemory => m_PhysicalMemory;

	public RAMInfo()
	{
		pcAvailMemory = new PerformanceCounter("Memory", "Available Bytes");
		ManagementClass managementClass = new ManagementClass("Win32_ComputerSystem");
		ManagementObjectCollection instances = managementClass.GetInstances();
		foreach (ManagementObject item in instances)
		{
			if (item["TotalPhysicalMemory"] != null)
			{
				m_PhysicalMemory = long.Parse(item["TotalPhysicalMemory"].ToString());
			}
		}
	}
}
