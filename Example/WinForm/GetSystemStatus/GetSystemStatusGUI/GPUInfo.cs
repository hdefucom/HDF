#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;

namespace GetSystemStatusGUI;

public class GPUInfo
{
	private struct PairedNamePcId : IComparable
	{
		public string name { get; }

		public string pcid { get; }

		public PairedNamePcId(string name, string pcid)
		{
			this.name = name;
			this.pcid = pcid;
		}

		public int CompareTo(object obj)
		{
			PairedNamePcId pairedNamePcId = (PairedNamePcId)obj;
			return pcid.CompareTo(pairedNamePcId.pcid);
		}
	}

	private List<PerformanceCounter> pcDedicateGPUMemory;

	private List<PerformanceCounter> pcGPUEngine;

	private List<string> gpu_name;

	private List<PairedNamePcId> pairedNamePcIds;

	public int Count { get; private set; }

	private string getGpuPcId(int id)
	{
		return pairedNamePcIds[id].pcid;
	}

	public string getGpuName(int id)
	{
		return pairedNamePcIds[id].name;
	}

	public GPUInfo(int id = -1)
	{
		string[] instanceNames = new PerformanceCounterCategory("GPU Adapter Memory", "Dedicated Usage")
		{
			MachineName = "."
		}.GetInstanceNames();
		pcDedicateGPUMemory = new List<PerformanceCounter>();
		string[] array = instanceNames;
		foreach (string instanceName in array)
		{
			pcDedicateGPUMemory.Add(new PerformanceCounter("GPU Adapter Memory", "Dedicated Usage", instanceName));
		}
		string[] instanceNames2 = new PerformanceCounterCategory("GPU Engine", "Utilization Percentage")
		{
			MachineName = "."
		}.GetInstanceNames();
		pcGPUEngine = new List<PerformanceCounter>();
		foreach (PerformanceCounter item2 in pcDedicateGPUMemory)
		{
			string text = item2.InstanceName.Split('_')[2];
			item2.NextValue();
			string[] array2 = instanceNames2;
			foreach (string text2 in array2)
			{
				string text3 = text2.Split('_')[4];
				if (text3 == text)
				{
					pcGPUEngine.Add(new PerformanceCounter("GPU Engine", "Utilization Percentage", text2));
				}
			}
		}
		ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * from Win32_VideoController");
		gpu_name = new List<string>();
		foreach (ManagementBaseObject item3 in managementObjectSearcher.Get())
		{
			ManagementObject managementObject = (ManagementObject)item3;
			string item = managementObject["name"].ToString();
			try
			{
				string text4 = managementObject["AdapterRAM"].ToString();
				gpu_name.Add(item);
			}
			catch
			{
			}
		}
		Count = gpu_name.Count;
		FilterValidGPU();
		RemoveUnnecessaryPC(id);
	}

	private void FilterValidGPU()
	{
		List<string> list = new List<string>();
		foreach (PerformanceCounter item in pcDedicateGPUMemory)
		{
			string text = item.InstanceName.Split('_')[2];
			float num = item.NextValue();
			if (num != 0f)
			{
				list.Add(text);
				continue;
			}
			PerformanceCounterCategory performanceCounterCategory = new PerformanceCounterCategory("GPU Local Adapter Memory", "Local Usage");
			performanceCounterCategory.MachineName = ".";
			string[] instanceNames = performanceCounterCategory.GetInstanceNames();
			string[] array = instanceNames;
			foreach (string text2 in array)
			{
				string text3 = text2.Split('_')[2];
				if (text == text3)
				{
					PerformanceCounter performanceCounter = new PerformanceCounter("GPU Local Adapter Memory", "Local Usage", text2);
					performanceCounter.MachineName = ".";
					float num2 = performanceCounter.NextValue();
					Debug.Assert(num2 != 0f);
					if (num2 > 0f && num2 != 8192f)
					{
						list.Add(text);
					}
				}
			}
		}
		Debug.Assert(list.Count == Count);
		Count = Math.Min(list.Count, Count);
		pairedNamePcIds = new List<PairedNamePcId>();
		for (int j = 0; j < Count; j++)
		{
			pairedNamePcIds.Add(new PairedNamePcId(gpu_name[j], list[j]));
		}
		pairedNamePcIds.Sort();
	}

	private void RemoveUnnecessaryPC(int id)
	{
		if (id < 0 || Count == 0)
		{
			return;
		}
		string gpuPcId = getGpuPcId(id);
		for (int num = pcGPUEngine.Count - 1; num >= 0; num--)
		{
			PerformanceCounter performanceCounter = pcGPUEngine[num];
			string[] array = performanceCounter.InstanceName.Split('_');
			string text = array[4];
			if (text != gpuPcId)
			{
				pcGPUEngine.Remove(performanceCounter);
			}
		}
	}

	public long GetGPUDedicatedMemory(int id)
	{
		string gpuPcId = getGpuPcId(id);
		foreach (PerformanceCounter item in pcDedicateGPUMemory)
		{
			string text = item.InstanceName.Split('_')[2];
			if (text == gpuPcId)
			{
				return (long)Math.Round(item.NextValue());
			}
		}
		return 0L;
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

	public Dictionary<string, float> GetGPUUtilization(int id)
	{
		string gpuPcId = getGpuPcId(id);
		try
		{
			Dictionary<string, float> dictionary = new Dictionary<string, float>();
			foreach (PerformanceCounter item in pcGPUEngine)
			{
				string[] array = item.InstanceName.Split('_');
				string text = array[4];
				if (text == gpuPcId)
				{
					string engineString = getEngineString(array);
					if (dictionary.TryGetValue(engineString, out var value))
					{
						value = (dictionary[engineString] = value + item.NextValue());
					}
					else
					{
						dictionary.Add(engineString, item.NextValue());
					}
				}
			}
			return dictionary;
		}
		catch
		{
			RefreshGPUEnginePerfCnt(id);
			return GetGPUUtilization(id);
		}
	}

	public Dictionary<string, Dictionary<string, float>> GetGPUUtilization()
	{
		Dictionary<string, Dictionary<string, float>> dictionary = new Dictionary<string, Dictionary<string, float>>();
		foreach (PerformanceCounter item in pcGPUEngine)
		{
			string[] array = item.InstanceName.Split('_');
			string key = array[4];
			string engineString = getEngineString(array);
			if (dictionary.TryGetValue(key, out var value))
			{
				dictionary.Remove(key);
				if (value.TryGetValue(engineString, out var value2))
				{
					value.Remove(engineString);
					value2 += item.NextValue();
					value.Add(engineString, value2);
				}
				else
				{
					value.Add(engineString, item.NextValue());
				}
				dictionary.Add(key, value);
			}
			else
			{
				value = new Dictionary<string, float>();
				value.Add(engineString, item.NextValue());
				dictionary.Add(key, value);
			}
		}
		return dictionary;
	}

	public List<string> GetGPUEngines(int id)
	{
		string gpuPcId = getGpuPcId(id);
		List<string> list = new List<string>();
		foreach (PerformanceCounter item in pcGPUEngine)
		{
			string[] array = item.InstanceName.Split('_');
			string text = array[4];
			if (text == gpuPcId)
			{
				string engineString = getEngineString(array);
				if (!list.Contains(engineString))
				{
					list.Add(engineString);
				}
			}
		}
		list.Sort();
		return list;
	}

	private string getEngineString(string[] splitInstanceName)
	{
		string text = string.Empty;
		for (int i = 10; i < splitInstanceName.Length; i++)
		{
			text += splitInstanceName[i];
			if (i != splitInstanceName.Length - 1)
			{
				text += " ";
			}
		}
		if (text == string.Empty)
		{
			text = "Engine " + splitInstanceName[8];
		}
		return text;
	}

	public void RefreshGPUEnginePerfCnt()
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

	public void RefreshGPUEnginePerfCnt(int id)
	{
		PerformanceCounterCategory performanceCounterCategory = new PerformanceCounterCategory("GPU Engine", "Utilization Percentage");
		performanceCounterCategory.MachineName = ".";
		string[] instanceNames = performanceCounterCategory.GetInstanceNames();
		pcGPUEngine.Clear();
		string gpuPcId = getGpuPcId(id);
		string[] array = instanceNames;
		foreach (string text in array)
		{
			string text2 = text.Split('_')[4];
			if (text2 == gpuPcId)
			{
				PerformanceCounter performanceCounter = new PerformanceCounter("GPU Engine", "Utilization Percentage", text);
				try
				{
					performanceCounter.NextValue();
					pcGPUEngine.Add(performanceCounter);
				}
				catch
				{
				}
			}
		}
	}
}
