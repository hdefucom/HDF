using DCSoft.Writer;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class MyErrorReporter : IErrorReporter
	{
		private string _FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DC2AxNsoOfficeLibErrorLog.txt");

		public void ReportError(IWin32Window parentWindow, string message, string details)
		{
			int num = 11;
			using (StreamWriter streamWriter = new StreamWriter(_FileName, append: true))
			{
				streamWriter.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "|" + message + " " + details);
			}
		}
	}
}
