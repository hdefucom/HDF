using System;

namespace GetSystemStatusGUI;

public static class Utility
{
	public static void FactorDecompose(int original, ref int bigger, ref int smaller)
	{
		double num = Math.Sqrt(original);
		int num2 = (int)Math.Ceiling(num);
		int num3 = (int)Math.Floor(num);
		while (num2 * num3 != original)
		{
			if (num2 * num3 > original)
			{
				num3--;
			}
			else
			{
				num2++;
			}
		}
		bigger = num2;
		smaller = num3;
	}

	public static string FormatSpeedString(string firstDesc, float firstByte, string secondDesc, float secondByte, bool bps = false)
	{
		string[] array = (bps ? new string[4] { "bps", "Kbps", "Mbps", "Gbps" } : new string[5] { "B/s", "KB/s", "MB/s", "GB/s", "TB/s" });
		string empty = string.Empty;
		empty = empty + firstDesc + " ";
		int num = (int)Math.Max(Math.Floor(Math.Log(firstByte, 1000.0)), 0.0);
		int num2 = (int)Math.Max(Math.Floor(Math.Log(secondByte, 1000.0)), 0.0);
		firstByte /= (float)Math.Pow(1000.0, num);
		secondByte /= (float)Math.Pow(1000.0, num2);
		firstByte = (float)Math.Round(firstByte, 1);
		secondByte = (float)Math.Round(secondByte, 1);
		empty = empty + firstByte + " " + array[num];
		empty = empty + "\n" + secondDesc + " ";
		return empty + secondByte + " " + array[num2];
	}

	public static string FormatSizeString(string desc, long bytes)
	{
		string[] array = new string[5] { "Bytes", "KB", "MB", "GB", "TB" };
		int num = (int)Math.Max(Math.Floor(Math.Log(bytes, 1024.0)), 0.0);
		double num2 = Math.Round((double)bytes / Math.Pow(1024.0, num), 1);
		string text = array[num];
		return desc + ": " + num2 + " " + text + "\n";
	}
}
