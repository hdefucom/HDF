using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Microsoft.Win32;

namespace GetSystemStatusGUI;

public class NetworkInfo
{
	private NetworkInterface[] allAdapters;

	private List<NetworkInterface> validAdapters;

	private Dictionary<string, PerformanceCounter> pcNetworkReceive;

	private Dictionary<string, PerformanceCounter> pcNetworkSend;

	public int adapterNum => validAdapters.Count;

	public NetworkInfo()
	{
		allAdapters = NetworkInterface.GetAllNetworkInterfaces();
		pcNetworkReceive = new Dictionary<string, PerformanceCounter>();
		pcNetworkSend = new Dictionary<string, PerformanceCounter>();
		NetworkInterface[] array = allAdapters;
		foreach (NetworkInterface networkInterface in array)
		{
			if (Environment.OSVersion.Version.Major == 10)
			{
				pcNetworkReceive.Add(networkInterface.Description, new PerformanceCounter("Network Adapter", "Bytes Received/sec", R(networkInterface.Description), "."));
				pcNetworkSend.Add(networkInterface.Description, new PerformanceCounter("Network Adapter", "Bytes Sent/sec", R(networkInterface.Description), "."));
			}
			else
			{
				pcNetworkReceive.Add(networkInterface.Description, new PerformanceCounter("Network Interface", "Bytes Received/sec", R(networkInterface.Description), "."));
				pcNetworkSend.Add(networkInterface.Description, new PerformanceCounter("Network Interface", "Bytes Sent/sec", R(networkInterface.Description), "."));
			}
		}
		ScreenValidAdapters();
	}

	private void ScreenValidAdapters()
	{
		validAdapters = new List<NetworkInterface>();
		NetworkInterface[] array = allAdapters;
		foreach (NetworkInterface networkInterface in array)
		{
			if (networkInterface.Speed <= 0 || networkInterface.Speed == 1073741824)
			{
				continue;
			}
			string name = "SYSTEM\\CurrentControlSet\\Control\\Network\\{4D36E972-E325-11CE-BFC1-08002BE10318}\\" + networkInterface.Id + "\\Connection";
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(name, writable: false);
			if (registryKey == null)
			{
				continue;
			}
			string text = registryKey.GetValue("PnpInstanceID", "").ToString();
			int num = Convert.ToInt32(registryKey.GetValue("MediaSubType", 0));
			if (text.Length <= 3)
			{
				continue;
			}
			string text2 = text.Substring(0, 3);
			switch (text2)
			{
			default:
				if (num != 2)
				{
					continue;
				}
				break;
			case "PCI":
			case "USB":
			case "BTH":
				break;
			}
			if (num != 1 && text2 != "ROOT")
			{
				validAdapters.Add(networkInterface);
			}
		}
	}

	public string getNetworkInterfaceType(int id)
	{
		return validAdapters[id].NetworkInterfaceType.ToString();
	}

	public string getAdapterName(int id)
	{
		return validAdapters[id].Name;
	}

	public string getAdapterModel(int id)
	{
		return validAdapters[id].Description;
	}

	public string getLinkSpeedString(int id)
	{
		NetworkInterface networkInterface = validAdapters[id];
		long num = networkInterface.Speed / 1000 / 1000;
		string text = "Mbps";
		if (num >= 1000)
		{
			num /= 1000;
			text = "Gbps";
		}
		return num + " " + text;
	}

	public long getLinkSpeed(int id)
	{
		NetworkInterface networkInterface = validAdapters[id];
		return networkInterface.Speed;
	}

	public string getIPv4Address(int id)
	{
		NetworkInterface networkInterface = validAdapters[id];
		IPInterfaceProperties iPProperties = networkInterface.GetIPProperties();
		UnicastIPAddressInformationCollection unicastAddresses = iPProperties.UnicastAddresses;
		string result = "Not Present";
		foreach (UnicastIPAddressInformation item in unicastAddresses)
		{
			if (item.Address.AddressFamily == AddressFamily.InterNetwork)
			{
				result = item.Address.ToString();
			}
		}
		return result;
	}

	public string getIPv6Address(int id)
	{
		NetworkInterface networkInterface = validAdapters[id];
		IPInterfaceProperties iPProperties = networkInterface.GetIPProperties();
		UnicastIPAddressInformationCollection unicastAddresses = iPProperties.UnicastAddresses;
		string result = "Not Present";
		foreach (UnicastIPAddressInformation item in unicastAddresses)
		{
			if (item.Address.AddressFamily == AddressFamily.InterNetworkV6)
			{
				result = item.Address.ToString();
			}
		}
		return result;
	}

	public float ReceiveSpeed(int id)
	{
		return ReceiveSpeed(validAdapters[id].Description);
	}

	public float SendSpeed(int id)
	{
		return SendSpeed(validAdapters[id].Description);
	}

	public float ReceiveSpeed(string AdapterDesc)
	{
		if (!pcNetworkReceive.TryGetValue(AdapterDesc, out var value))
		{
			return -1f;
		}
		return value.NextValue() * 8f;
	}

	public float SendSpeed(string AdapterDesc)
	{
		if (!pcNetworkSend.TryGetValue(AdapterDesc, out var value))
		{
			return -1f;
		}
		return value.NextValue() * 8f;
	}

	public float AdapterLoad(int id)
	{
		float num = SendSpeed(id);
		float num2 = ReceiveSpeed(id);
		long linkSpeed = getLinkSpeed(id);
		return (num + num2) * 100f / (float)linkSpeed;
	}

	public void SpeedAndLoad(int id, out float sendSpeed, out float receiveSpeed, out float adapterLoad)
	{
		float num = SendSpeed(id);
		float num2 = ReceiveSpeed(id);
		long linkSpeed = getLinkSpeed(id);
		float num3 = (num + num2) * 100f / (float)linkSpeed;
		sendSpeed = num;
		receiveSpeed = num2;
		adapterLoad = num3;
	}

	private string R(string str)
	{
		return str.Replace('#', '_').Replace('(', '[').Replace(')', ']')
			.Replace('/', '_');
	}
}
