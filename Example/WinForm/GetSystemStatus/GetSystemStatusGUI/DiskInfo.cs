using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;

namespace GetSystemStatusGUI;

public class DiskInfo
{
	private PerformanceCounter[] pcDisksRead;

	private PerformanceCounter[] pcDisksWrite;

	private PerformanceCounter[] pcDisksLoad;

	private PerformanceCounter pcDiskRead;

	private PerformanceCounter pcDiskWrite;

	public int m_DiskNum = 0;

	public List<string> DiskInstanceNames = new List<string>();

	private string[] diskModelCaption;

	public float DiskReadTotal => pcDiskRead.NextValue();

	public float DiskWriteTotal => pcDiskWrite.NextValue();

	public DiskInfo()
	{
		pcDiskRead = new PerformanceCounter("PhysicalDisk", "Disk Read Bytes/sec", "_Total");
		pcDiskWrite = new PerformanceCounter("PhysicalDisk", "Disk Write Bytes/sec", "_Total");
		PerformanceCounterCategory performanceCounterCategory = new PerformanceCounterCategory("PhysicalDisk");
		string[] instanceNames = performanceCounterCategory.GetInstanceNames();
		m_DiskNum = instanceNames.Length - 1;
		string[] array = new string[m_DiskNum];
		string[] array2 = instanceNames;
		foreach (string text in array2)
		{
			string[] array3 = text.Split(' ');
			try
			{
				int num = int.Parse(array3[0]);
				array[num] = text;
			}
			catch
			{
			}
		}
		pcDisksRead = new PerformanceCounter[m_DiskNum];
		pcDisksWrite = new PerformanceCounter[m_DiskNum];
		pcDisksLoad = new PerformanceCounter[m_DiskNum];
		int num2 = 0;
		for (int j = 0; j < array.Length; j++)
		{
			if (array[j] != "_Total")
			{
				pcDisksRead[num2] = new PerformanceCounter("PhysicalDisk", "Disk Read Bytes/sec", array[j]);
				pcDisksWrite[num2] = new PerformanceCounter("PhysicalDisk", "Disk Write Bytes/sec", array[j]);
				pcDisksLoad[num2] = new PerformanceCounter("PhysicalDisk", "% Idle Time", array[j]);
				DiskInstanceNames.Add(array[j]);
				num2++;
			}
		}
		pcDiskRead.MachineName = ".";
		pcDiskRead.NextValue();
		pcDiskWrite.NextValue();
		for (int k = 0; k < m_DiskNum; k++)
		{
			pcDisksRead[k].NextValue();
			pcDisksWrite[k].NextValue();
			pcDisksLoad[k].NextValue();
		}
		diskModelCaption = new string[m_DiskNum];
		ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select * from Win32_DiskDrive");
		foreach (ManagementBaseObject item in managementObjectSearcher.Get())
		{
			ManagementObject managementObject = (ManagementObject)item;
			string text2 = managementObject["DeviceID"].ToString();
			string text3 = managementObject["Model"].ToString();
			int startIndex = text2.IndexOf("\\\\.\\PHYSICALDRIVE") + "\\\\.\\PHYSICALDRIVE".Length;
			string s = text2.Substring(startIndex);
			int num3 = int.Parse(s);
			diskModelCaption[num3] = text3;
		}
	}

	public string DiskModel(int id)
	{
		return diskModelCaption[id];
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
}
