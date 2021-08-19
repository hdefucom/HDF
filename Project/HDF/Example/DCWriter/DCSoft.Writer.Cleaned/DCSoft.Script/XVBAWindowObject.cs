#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DCSoft.Script
{
	/// <summary>
	///       window global object type use in VB.NET script
	///       </summary>
	[ComVisible(false)]
	public class XVBAWindowObject : IDisposable
	{
		private static XVBAWindowObject myInstance;

		private string _SystemName = "Application";

		private static bool _HasUserInterface;

		protected XVBAEngine myEngine = null;

		protected IWin32Window myParentWindow = null;

		private int intScriptVersionBack = 0;

		private string strTimeoutMethod = null;

		private System.Windows.Forms.Timer myTimer;

		private System.Windows.Forms.Timer myIntervalTimer = null;

		private string strTimerIntervalMethod = null;

		private string strLogFileName = null;

		/// <summary>
		///       error flag for write log file.
		///       </summary>
		private bool bolWriteLogFileError = false;

		/// <summary>
		///       the only instance
		///       </summary>
		public static XVBAWindowObject Instance
		{
			get
			{
				return myInstance;
			}
			set
			{
				myInstance = value;
			}
		}

		/// <summary>
		///       system name
		///       </summary>
		public string systemName
		{
			get
			{
				return _SystemName;
			}
			set
			{
				_SystemName = value;
			}
		}

		/// <summary>
		///       Whether has user interface
		///       </summary>
		public static bool HasUserInterface
		{
			get
			{
				return _HasUserInterface;
			}
			set
			{
				_HasUserInterface = value;
			}
		}

		/// <summary>
		///       Script engine
		///       </summary>
		public XVBAEngine engine
		{
			get
			{
				return myEngine;
			}
			set
			{
				myEngine = value;
			}
		}

		/// <summary>
		///       Parent window
		///       </summary>
		public IWin32Window parentWindow
		{
			get
			{
				return myParentWindow;
			}
			set
			{
				myParentWindow = value;
			}
		}

		/// <summary>
		///       Screen width
		///       </summary>
		public int screenWidth
		{
			get
			{
				if (_HasUserInterface)
				{
					return Screen.PrimaryScreen.Bounds.Width;
				}
				return 0;
			}
		}

		/// <summary>
		///       Screen height
		///       </summary>
		public int screenHeight
		{
			get
			{
				if (_HasUserInterface)
				{
					return Screen.PrimaryScreen.Bounds.Height;
				}
				return 0;
			}
		}

		/// <summary>
		///       title
		///       </summary>
		public string title
		{
			get
			{
				if (!_HasUserInterface)
				{
					return "";
				}
				Form form = myParentWindow as Form;
				if (form == null)
				{
					return "";
				}
				return form.Text;
			}
			set
			{
				if (_HasUserInterface)
				{
					Form form = myParentWindow as Form;
					if (form != null)
					{
						form.Text = value;
					}
				}
			}
		}

		/// <summary>
		///       left position
		///       </summary>
		public int left
		{
			get
			{
				if (!_HasUserInterface)
				{
					return 0;
				}
				return (myParentWindow as Form)?.Left ?? 0;
			}
			set
			{
				if (_HasUserInterface)
				{
					Form form = myParentWindow as Form;
					if (form != null)
					{
						form.Left = value;
					}
				}
			}
		}

		public int Int32_0
		{
			get
			{
				if (!_HasUserInterface)
				{
					return 0;
				}
				return (myParentWindow as Form)?.Top ?? 0;
			}
			set
			{
				if (_HasUserInterface)
				{
					Form form = myParentWindow as Form;
					if (form != null)
					{
						form.Top = value;
					}
				}
			}
		}

		/// <summary>
		///       width
		///       </summary>
		public int width
		{
			get
			{
				if (!_HasUserInterface)
				{
					return 0;
				}
				return (myParentWindow as Form)?.Width ?? 0;
			}
			set
			{
				if (_HasUserInterface)
				{
					Form form = myParentWindow as Form;
					if (form != null)
					{
						form.Width = value;
					}
				}
			}
		}

		/// <summary>
		///       height
		///       </summary>
		public int height
		{
			get
			{
				if (!_HasUserInterface)
				{
					return 0;
				}
				return (myParentWindow as Form)?.Height ?? 0;
			}
			set
			{
				if (_HasUserInterface)
				{
					Form form = myParentWindow as Form;
					if (form != null)
					{
						form.Height = value;
					}
				}
			}
		}

		/// <summary>
		///       log file name , script can use DebugPrintLine() write some text to this file
		///       </summary>
		public string logFileName
		{
			get
			{
				return strLogFileName;
			}
			set
			{
				if (strLogFileName != value)
				{
					strLogFileName = value;
					bolWriteLogFileError = false;
				}
			}
		}

		static XVBAWindowObject()
		{
			myInstance = new XVBAWindowObject();
			_HasUserInterface = true;
			_HasUserInterface = SystemInformation.UserInteractive;
		}

		/// <summary>
		///       initialize instance
		///       </summary>
		/// <param name="win">object bind window</param>
		/// <param name="engine">script engine</param>
		/// <param name="systemName">system name</param>
		public XVBAWindowObject(IWin32Window iwin32Window_0, XVBAEngine engine, string systemName)
		{
			myParentWindow = iwin32Window_0;
			myEngine = engine;
			_SystemName = systemName;
		}

		public XVBAWindowObject()
		{
		}

		/// <summary>
		///       set dely call
		///       </summary>
		/// <param name="MinSecend">delay time span ,in millisecond </param>
		/// <param name="MethodName">method name</param>
		public void setTimeout(int MinSecend, string MethodName)
		{
			if (_HasUserInterface && myEngine != null)
			{
				if (myIntervalTimer != null)
				{
					myIntervalTimer.Stop();
				}
				strTimerIntervalMethod = null;
				if (myTimer == null)
				{
					myTimer = new System.Windows.Forms.Timer();
					myTimer.Tick += myTimer_Tick;
				}
				myTimer.Interval = MinSecend;
				strTimeoutMethod = MethodName;
				intScriptVersionBack = myEngine.ScriptVersion;
				myTimer.Start();
			}
		}

		/// <summary>
		///       Clear delay call
		///       </summary>
		public void clearTimeout()
		{
			if (myTimer != null)
			{
				myTimer.Stop();
			}
			strTimeoutMethod = null;
		}

		private void myTimer_Tick(object sender, EventArgs e)
		{
			myTimer.Stop();
			if (myEngine != null && strTimeoutMethod != null && strTimeoutMethod.Trim().Length > 0 && myEngine.ScriptVersion == intScriptVersionBack)
			{
				string string_ = strTimeoutMethod.Trim();
				strTimeoutMethod = null;
				if (myEngine.method_5(string_))
				{
					myEngine.method_6(string_);
				}
			}
		}

		/// <summary>
		///       set interval call
		///       </summary>
		/// <param name="MinSecend">interval time span, in millisecond</param>
		/// <param name="MethodName">method name</param>
		public void setInterval(int MinSecend, string MethodName)
		{
			if (!_HasUserInterface || MethodName == null || MethodName.Trim().Length == 0 || myEngine == null)
			{
				return;
			}
			if (myTimer != null)
			{
				myTimer.Stop();
			}
			strTimeoutMethod = null;
			if (myEngine.method_5(MethodName.Trim()))
			{
				strTimerIntervalMethod = MethodName.Trim();
				if (myIntervalTimer == null)
				{
					myIntervalTimer = new System.Windows.Forms.Timer();
					myIntervalTimer.Tick += myIntervalTimer_Tick;
				}
				myIntervalTimer.Interval = MinSecend;
				intScriptVersionBack = myEngine.ScriptVersion;
			}
		}

		/// <summary>
		///       clear interval call
		///       </summary>
		public void clearInterval()
		{
			if (myIntervalTimer != null)
			{
				myIntervalTimer.Stop();
			}
			strTimerIntervalMethod = null;
		}

		private void myIntervalTimer_Tick(object sender, EventArgs e)
		{
			if (myIntervalTimer != null)
			{
				strTimerIntervalMethod = strTimerIntervalMethod.Trim();
			}
			if (strTimerIntervalMethod == null || strTimerIntervalMethod.Length == 0 || myEngine == null || !myEngine.method_5(strTimerIntervalMethod) || myEngine.ScriptVersion == intScriptVersionBack)
			{
				if (myIntervalTimer != null)
				{
					myIntervalTimer.Stop();
				}
			}
			else
			{
				myEngine.method_6(strTimerIntervalMethod);
			}
		}

		/// <summary>
		///       convert object to text for dispaly
		///       </summary>
		/// <param name="objData">
		/// </param>
		/// <returns>
		/// </returns>
		protected string GetDisplayText(object objData)
		{
			int num = 16;
			if (objData == null)
			{
				return "[null]";
			}
			return Convert.ToString(objData);
		}

		/// <summary>
		///       show a message box
		///       </summary>
		/// <param name="objText">text</param>
		public void alert(object objText)
		{
			if (_HasUserInterface)
			{
				MessageBox.Show(myParentWindow, GetDisplayText(objText), systemName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		/// <summary>
		///       show a error message box
		///       </summary>
		/// <param name="objText">text</param>
		public void alertError(object objText)
		{
			if (_HasUserInterface)
			{
				MessageBox.Show(myParentWindow, GetDisplayText(objText), systemName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		/// <summary>
		///       show a message box and wait for user's choose
		///       </summary>
		/// <param name="objText">text</param>
		/// <returns>whether user confirm message</returns>
		public bool confirm(object objText)
		{
			if (!_HasUserInterface)
			{
				return false;
			}
			return MessageBox.Show(myParentWindow, GetDisplayText(objText), systemName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
		}

		/// <summary>
		///       show a input text box and wait for user's input
		///       </summary>
		/// <param name="objCaption">title</param>
		/// <param name="objDefault">initialize value</param>
		/// <returns>user's input</returns>
		public string prompt(object objCaption, object objDefault)
		{
			if (!_HasUserInterface)
			{
				return null;
			}
			return dlgInputBox.smethod_0(myParentWindow, GetDisplayText(objCaption), systemName, GetDisplayText(objDefault));
		}

		/// <summary>
		///       display a file dialog and wait for user's selec
		///       </summary>
		/// <param name="objCaption">title</param>
		/// <param name="objFilter">file name filter</param>
		/// <returns>file name which user select , if user cancel then return null</returns>
		public string browseFile(object objCaption, object objFilter)
		{
			if (!_HasUserInterface)
			{
				return null;
			}
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.CheckFileExists = true;
				if (objCaption != null)
				{
					openFileDialog.Title = GetDisplayText(objCaption);
				}
				if (objFilter != null)
				{
					openFileDialog.Filter = GetDisplayText(objFilter);
				}
				if (openFileDialog.ShowDialog(myParentWindow) == DialogResult.OK)
				{
					return openFileDialog.FileName;
				}
			}
			return null;
		}

		/// <summary>
		///       display a folder dialog and wait for user's select.
		///       </summary>
		/// <param name="objCaption">title</param>
		/// <returns>return folder's name which user seleced, if user cancel then return null</returns>
		public string browseFolder(object objCaption)
		{
			if (!_HasUserInterface)
			{
				return null;
			}
			using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
			{
				if (objCaption != null)
				{
					folderBrowserDialog.Description = GetDisplayText(objCaption);
				}
				folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
				if (folderBrowserDialog.ShowDialog(myParentWindow) == DialogResult.OK)
				{
					return folderBrowserDialog.SelectedPath;
				}
				return null;
			}
		}

		/// <summary>
		///       output debug text
		///       </summary>
		/// <param name="objText">text</param>
		public void debugPrintLine(object objText)
		{
			int num = 6;
			string displayText = GetDisplayText(objText);
			Debug.WriteLine("Script:" + displayText);
			if (!bolWriteLogFileError && strLogFileName != null && strLogFileName.Trim().Length > 0)
			{
				try
				{
					string directoryName = Path.GetDirectoryName(strLogFileName);
					if (directoryName != null && Directory.Exists(directoryName))
					{
						using (StreamWriter streamWriter = new StreamWriter(strLogFileName, append: true, Encoding.GetEncoding(936)))
						{
							streamWriter.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ">" + displayText);
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					bolWriteLogFileError = true;
				}
			}
		}

		/// <summary>
		///       sleep 
		///       </summary>
		/// <param name="MilliSecond">time span , millisecond</param>
		public void sleep(int MilliSecond)
		{
			Thread.Sleep(MilliSecond);
		}

		[Browsable(false)]
		public void Dispose()
		{
			if (myTimer != null)
			{
				myTimer.Dispose();
				myTimer = null;
			}
			if (myIntervalTimer != null)
			{
				myIntervalTimer.Dispose();
				myIntervalTimer = null;
			}
		}
	}
}
