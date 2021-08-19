using System;
using System.Windows.Forms;

namespace ZYCommon
{
	public class ClipboardHandler
	{
		public static bool CanGetText()
		{
			try
			{
				return Clipboard.GetDataObject()?.GetDataPresent(DataFormats.Text) ?? false;
			}
			catch (Exception ex)
			{
				ZYErrorReport.Instance.DebugPrint("CanGetText:试图获得文本格式的剪切板数据错误:" + ex.Message);
				return false;
			}
		}

		public static bool CanGetData(string strFormat)
		{
			try
			{
				return Clipboard.GetDataObject()?.GetDataPresent(strFormat) ?? false;
			}
			catch (Exception ex)
			{
				ZYErrorReport.Instance.DebugPrint("CanGetData:试图获得" + strFormat + "格式的剪切板数据错误:" + ex.Message);
				return false;
			}
		}

		public static bool SetTextToClipboard(string strText)
		{
			if (strText != null && strText.Length > 0)
			{
				try
				{
					DataObject dataObject = new DataObject();
					dataObject.SetData(DataFormats.UnicodeText, autoConvert: true, strText);
					Clipboard.SetDataObject(dataObject, copy: true);
					return true;
				}
				catch (Exception arg)
				{
					Console.WriteLine("Got exception while Copy text to clipboard : " + arg);
				}
			}
			return false;
		}

		public static string GetTextFromClipboard()
		{
			try
			{
				IDataObject dataObject = Clipboard.GetDataObject();
				if (dataObject.GetDataPresent(DataFormats.UnicodeText))
				{
					return (string)dataObject.GetData(DataFormats.UnicodeText);
				}
			}
			catch
			{
			}
			return null;
		}

		public static object GetDataFromClipboard(string strFormat)
		{
			try
			{
				IDataObject dataObject = Clipboard.GetDataObject();
				if (dataObject != null && dataObject.GetDataPresent(strFormat))
				{
					return dataObject.GetData(strFormat);
				}
			}
			catch (Exception ex)
			{
				ZYErrorReport.Instance.DebugPrint("GetDataFromClipboard:试图获得" + strFormat + "格式的剪切板数据错误:" + ex.Message);
			}
			return null;
		}
	}
}
