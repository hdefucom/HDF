using System;
using System.Diagnostics;
using System.Management;

namespace GetSystemStatusGUI;

public class CPUInfo
{
	private string cpuName;

	private PerformanceCounter pcCpuLoad;

	private PerformanceCounter[] pcCpuCoreLoads;

	public string CpuName => cpuName.Trim();

	public int ProcessorCount { get; } = 0;


	public float CpuLoad => pcCpuLoad.NextValue();

	public CPUInfo()
	{
		ProcessorCount = Environment.ProcessorCount;
		pcCpuLoad = new PerformanceCounter("Processor", "% Processor Time", "_Total");
		pcCpuCoreLoads = new PerformanceCounter[ProcessorCount];
		for (int i = 0; i < ProcessorCount; i++)
		{
			pcCpuCoreLoads[i] = new PerformanceCounter("Processor", "% Processor Time", i.ToString());
		}
		pcCpuLoad.MachineName = ".";
		pcCpuLoad.NextValue();
		for (int j = 0; j < ProcessorCount; j++)
		{
			pcCpuCoreLoads[j].NextValue();
		}
		string text = string.Empty;
		ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select Name from Win32_Processor");
		foreach (ManagementBaseObject item in managementObjectSearcher.Get())
		{
			ManagementObject managementObject = (ManagementObject)item;
			text = managementObject["Name"].ToString();
		}
		cpuName = text;
	}

	public float CpuCoreLoad(int core_num)
	{
		return pcCpuCoreLoads[core_num].NextValue();
	}
}
