using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using System.Net.NetworkInformation;

namespace GetSystemStatusGUI;

public class SystemInfo
{
	private PerformanceCounter pcCpuLoad;

	private PerformanceCounter[] pcCpuCoreLoads;

	private PerformanceCounter[] pcDisksRead;

	private PerformanceCounter[] pcDisksWrite;

	private PerformanceCounter[] pcDisksLoad;

	private PerformanceCounter pcDiskRead;

	private PerformanceCounter pcDiskWrite;

	private long m_PhysicalMemory = 0L;

	private PerformanceCounter pcAvailMemory;

	public int m_DiskNum = 0;

	public List<string> DiskInstanceNames = new List<string>();

	public NetworkInterface[] adapters;

	private Dictionary<string, PerformanceCounter> pcNetworkReceive;

	private Dictionary<string, PerformanceCounter> pcNetworkSend;

	private List<PerformanceCounter> pcDedicateGPUMemory;

	private List<PerformanceCounter> pcGPUEngine;

	public string CpuName { get; }

	public List<int> gpu_memory { get; }

	public List<string> gpu_name { get; }

	public int ProcessorCount { get; } = 0;


	public float CpuLoad => pcCpuLoad.NextValue();

	public float DiskReadTotal => pcDiskRead.NextValue();

	public float DiskWriteTotal => pcDiskWrite.NextValue();

	public long MemoryAvailable => (long)Math.Round(pcAvailMemory.NextValue());

	public long PhysicalMemory => m_PhysicalMemory;

	public List<long> GPUDedicatedMemory
	{
		get
		{
			List<long> list = new List<long>();
			foreach (PerformanceCounter item in pcDedicateGPUMemory)
			{
				list.Add((long)Math.Floor(item.NextValue()));
			}
			list.Remove(0L);
			return list;
		}
	}

	public List<int> GPUUtilization
	{
		get
		{
			List<int> list = new List<int>();
			string text = pcGPUEngine[0].InstanceName.Split('_')[4];
			float num = 0f;
			foreach (PerformanceCounter item in pcGPUEngine)
			{
				string text2 = item.InstanceName.Split('_')[4];
				if (text2 != text)
				{
					list.Add((int)Math.Round(num));
					num = 0f;
				}
				num += item.NextValue();
				text = text2;
			}
			list.Add((int)Math.Round(num));
			return list;
		}
	}

	public SystemInfo()
	{
		ProcessorCount = Environment.ProcessorCount;
		pcCpuLoad = new PerformanceCounter("Processor", "% Processor Time", "_Total");
		pcAvailMemory = new PerformanceCounter("Memory", "Available Bytes");
		pcDiskRead = new PerformanceCounter("PhysicalDisk", "Disk Read Bytes/sec", "_Total");
		pcDiskWrite = new PerformanceCounter("PhysicalDisk", "Disk Write Bytes/sec", "_Total");
		PerformanceCounterCategory performanceCounterCategory = new PerformanceCounterCategory("PhysicalDisk");
		string[] instanceNames = performanceCounterCategory.GetInstanceNames();
		m_DiskNum = instanceNames.Length - 1;
		pcDisksRead = new PerformanceCounter[m_DiskNum];
		pcDisksWrite = new PerformanceCounter[m_DiskNum];
		pcDisksLoad = new PerformanceCounter[m_DiskNum];
		int num = 0;
		for (int i = 0; i < instanceNames.Length; i++)
		{
			if (instanceNames[i] != "_Total")
			{
				pcDisksRead[num] = new PerformanceCounter("PhysicalDisk", "Disk Read Bytes/sec", instanceNames[i]);
				pcDisksWrite[num] = new PerformanceCounter("PhysicalDisk", "Disk Write Bytes/sec", instanceNames[i]);
				pcDisksLoad[num] = new PerformanceCounter("PhysicalDisk", "% Idle Time", instanceNames[i]);
				DiskInstanceNames.Add(instanceNames[i]);
				num++;
			}
		}
		pcCpuCoreLoads = new PerformanceCounter[ProcessorCount];
		for (int j = 0; j < ProcessorCount; j++)
		{
			pcCpuCoreLoads[j] = new PerformanceCounter("Processor", "% Processor Time", j.ToString());
		}
		pcCpuLoad.MachineName = ".";
		pcDiskRead.MachineName = ".";
		pcCpuLoad.NextValue();
		pcDiskRead.NextValue();
		pcDiskWrite.NextValue();
		for (int k = 0; k < ProcessorCount; k++)
		{
			pcCpuCoreLoads[k].NextValue();
		}
		for (int l = 0; l < m_DiskNum; l++)
		{
			pcDisksRead[l].NextValue();
			pcDisksWrite[l].NextValue();
			pcDisksLoad[l].NextValue();
		}
		ManagementClass managementClass = new ManagementClass("Win32_ComputerSystem");
		ManagementObjectCollection instances = managementClass.GetInstances();
		foreach (ManagementObject item2 in instances)
		{
			if (item2["TotalPhysicalMemory"] != null)
			{
				m_PhysicalMemory = long.Parse(item2["TotalPhysicalMemory"].ToString());
			}
		}
		string text = string.Empty;
		ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * from Win32_Processor");
		foreach (ManagementBaseObject item3 in managementObjectSearcher.Get())
		{
			ManagementObject managementObject2 = (ManagementObject)item3;
			text = managementObject2["Name"].ToString();
		}
		CpuName = text;
		adapters = NetworkInterface.GetAllNetworkInterfaces();
		pcNetworkReceive = new Dictionary<string, PerformanceCounter>();
		pcNetworkSend = new Dictionary<string, PerformanceCounter>();
		NetworkInterface[] array = adapters;
		foreach (NetworkInterface networkInterface in array)
		{
			pcNetworkReceive.Add(networkInterface.Description, new PerformanceCounter("Network Adapter", "Bytes Received/sec", R(networkInterface.Description), "."));
			pcNetworkSend.Add(networkInterface.Description, new PerformanceCounter("Network Adapter", "Bytes Sent/sec", R(networkInterface.Description), "."));
		}
		string[] instanceNames2 = new PerformanceCounterCategory("GPU Adapter Memory", "Dedicated Usage")
		{
			MachineName = "."
		}.GetInstanceNames();
		pcDedicateGPUMemory = new List<PerformanceCounter>();
		string[] array2 = instanceNames2;
		foreach (string instanceName in array2)
		{
			pcDedicateGPUMemory.Add(new PerformanceCounter("GPU Adapter Memory", "Dedicated Usage", instanceName));
		}
		string[] instanceNames3 = new PerformanceCounterCategory("GPU Engine", "Utilization Percentage")
		{
			MachineName = "."
		}.GetInstanceNames();
		pcGPUEngine = new List<PerformanceCounter>();
		foreach (PerformanceCounter item4 in pcDedicateGPUMemory)
		{
			string text2 = item4.InstanceName.Split('_')[2];
			item4.NextValue();
			string[] array3 = instanceNames3;
			foreach (string text3 in array3)
			{
				string text4 = text3.Split('_')[4];
				if (text4 == text2)
				{
					pcGPUEngine.Add(new PerformanceCounter("GPU Engine", "Utilization Percentage", text3));
				}
			}
		}
		ManagementObjectSearcher managementObjectSearcher2 = new ManagementObjectSearcher("Select * from Win32_VideoController");
		gpu_name = new List<string>();
		foreach (ManagementBaseObject item5 in managementObjectSearcher2.Get())
		{
			ManagementObject managementObject3 = (ManagementObject)item5;
			string item = managementObject3["name"].ToString();
			try
			{
				string text5 = managementObject3["AdapterRAM"].ToString();
				gpu_name.Add(item);
			}
			catch
			{
			}
		}
	}

	public float CpuCoreLoad(int core_num)
	{
		return pcCpuCoreLoads[core_num].NextValue();
	}

	public float DiskRead(int diskId)
	{
		return pcDisksRead[diskId].NextValue();
	}

	public float DiskWrite(int diskId)
	{
		return pcDisksWrite[diskId].NextValue();
	}

	public float DiskLoad(int diskId)
	{
		return Math.Max(0f, 100f - pcDisksLoad[diskId].NextValue());
	}

	public float ReceiveSpeed(string AdapterDesc)
	{
		if (!pcNetworkReceive.TryGetValue(AdapterDesc, out var value))
		{
			return -1f;
		}
		return value.NextValue();
	}

	public float SendSpeed(string AdapterDesc)
	{
		if (!pcNetworkSend.TryGetValue(AdapterDesc, out var value))
		{
			return -1f;
		}
		return value.NextValue();
	}

	public Dictionary<string, long> GetGPUDedicatedMemory()
	{
		Dictionary<string, long> dictionary = new Dictionary<string, long>();
		foreach (PerformanceCounter item in pcDedicateGPUMemory)
		{
			string key = item.InstanceName.Split('_')[2];
			dictionary.Add(key, (long)Math.Round(item.NextValue()));
		}
		if (false)
		{
			foreach (KeyValuePair<string, long> item2 in dictionary)
			{
				if (item2.Value == 0)
				{
					dictionary.Remove(item2.Key);
					break;
				}
			}
		}
		return dictionary;
	}

	public Dictionary<string, Dictionary<string, float>> GetGPUUtilization()
	{
		Dictionary<string, Dictionary<string, float>> dictionary = new Dictionary<string, Dictionary<string, float>>();
		foreach (PerformanceCounter item in pcGPUEngine)
		{
			string[] array = item.InstanceName.Split('_');
			string key = array[4];
			string text = string.Empty;
			for (int i = 10; i < array.Length; i++)
			{
				text += array[i];
			}
			if (dictionary.TryGetValue(key, out var value))
			{
				dictionary.Remove(key);
				if (value.TryGetValue(text, out var value2))
				{
					value.Remove(text);
					value2 += item.NextValue();
					value.Add(text, value2);
				}
				else
				{
					value.Add(text, item.NextValue());
				}
				dictionary.Add(key, value);
			}
			else
			{
				value = new Dictionary<string, float>();
				value.Add(text, item.NextValue());
				dictionary.Add(key, value);
			}
		}
		return dictionary;
	}

	public void RefreshGPUEnginePerformanceCounter()
	{
		PerformanceCounterCategory performanceCounterCategory = new PerformanceCounterCategory("GPU Engine", "Utilization Percentage");
		performanceCounterCategory.MachineName = ".";
		string[] instanceNames = performanceCounterCategory.GetInstanceNames();
		pcGPUEngine.Clear();
		foreach (PerformanceCounter item in pcDedicateGPUMemory)
		{
			string text = item.InstanceName.Split('_')[2];
			item.NextValue();
			string[] array = instanceNames;
			foreach (string text2 in array)
			{
				string text3 = text2.Split('_')[4];
				if (text3 == text)
				{
					pcGPUEngine.Add(new PerformanceCounter("GPU Engine", "Utilization Percentage", text2));
				}
			}
		}
	}

	private string R(string str)
	{
		return str.Replace('#', '_').Replace('(', '[').Replace(')', ']');
	}
}
