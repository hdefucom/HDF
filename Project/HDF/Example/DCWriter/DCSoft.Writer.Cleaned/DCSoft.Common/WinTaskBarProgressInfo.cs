using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       设置WINDOWS任务栏进度的信息对象
	                                                                    ///       </summary>
	[DCPublishAPI]
	[ComVisible(false)]
	public class WinTaskBarProgressInfo : IDisposable
	{
		private delegate void SetProgressValueHandler(IntPtr handle, ulong ulong_0, ulong ulong_1);

		private delegate void SetProgressStateHandler(IntPtr intptr_0, TBPFLAG flag);

		private enum TBPFLAG
		{
			TBPF_NOPROGRESS = 0,
			TBPF_INDETERMINATE = 1,
			TBPF_NORMAL = 2,
			TBPF_ERROR = 4,
			TBPF_PAUSED = 8
		}

		[ComImport]
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[Guid("c43dc798-95d1-4bea-9030-bb99e2983a1a")]
		private interface ITaskbarList4
		{
			[PreserveSig]
			void HrInit();

			[PreserveSig]
			void AddTab(IntPtr hwnd);

			[PreserveSig]
			void DeleteTab(IntPtr hwnd);

			[PreserveSig]
			void ActivateTab(IntPtr hwnd);

			[PreserveSig]
			void SetActiveAlt(IntPtr hwnd);

			[PreserveSig]
			void MarkFullscreenWindow(IntPtr hwnd, [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);

			[PreserveSig]
			void SetProgressValue(IntPtr hwnd, ulong ullCompleted, ulong ullTotal);

			[PreserveSig]
			void SetProgressState(IntPtr hwnd, TBPFLAG tbpFlags);

			[PreserveSig]
			void RegisterTab(IntPtr hwndTab, IntPtr hwndMDI);

			[PreserveSig]
			void UnregisterTab(IntPtr hwndTab);

			[PreserveSig]
			void SetTabOrder(IntPtr hwndTab, IntPtr hwndInsertBefore);

			[PreserveSig]
			void SetTabActive(IntPtr hwndTab, IntPtr hwndMDI, uint dwReserved);

			[PreserveSig]
			void ThumbBarSetImageList(IntPtr hwnd, IntPtr himl);

			[PreserveSig]
			void SetOverlayIcon(IntPtr hwnd, IntPtr hIcon, [MarshalAs(UnmanagedType.LPWStr)] string pszDescription);

			[PreserveSig]
			void SetThumbnailTooltip(IntPtr hwnd, [MarshalAs(UnmanagedType.LPWStr)] string pszTip);
		}

		[ComImport]
		[Guid("56FDF344-FD6D-11d0-958A-006097C9A090")]
		[ClassInterface(ClassInterfaceType.None)]
		private class CTaskbarList
		{
			                                                                    //[MethodImpl(MethodImplOptions.InternalCall)]
			                                                                    //public extern CTaskbarList();
		}

		private static bool _Enabled = true;

		private Control _Control;

		private IntPtr _Handle;

		private ITaskbarList4 _ITaskbar;

		private static readonly bool _IsSupportTaskBarProgress = double.Parse(Environment.OSVersion.Version.Major + "." + Environment.OSVersion.Version.Minor) >= 6.1;

		                                                                    /// <summary>
		                                                                    ///       本对象的功能是否可用
		                                                                    ///       </summary>
		public static bool Enabled
		{
			get
			{
				return _Enabled;
			}
			set
			{
				_Enabled = value;
			}
		}

		private bool RuntimeEnabled => _Enabled && _IsSupportTaskBarProgress;

		private IntPtr Handle
		{
			get
			{
				if (_Control != null && _Control.IsHandleCreated && !_Control.InvokeRequired)
				{
					return _Control.Handle;
				}
				return _Handle;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="ctl">相关的控件对象</param>
		                                                                    /// <param name="supportCrossUIThread">是否支持跨UI线程的操作</param>
		public WinTaskBarProgressInfo(Control control_0, bool supportCrossUIThread = false)
		{
			int num = 5;
			_Control = null;
			_Handle = IntPtr.Zero;
			_ITaskbar = null;
			                                                                    //
			if (!RuntimeEnabled)
			{
				return;
			}
			if (control_0 == null)
			{
				throw new ArgumentNullException("win");
			}
			if (control_0.IsDisposed)
			{
				throw new ObjectDisposedException("ctl");
			}
			_Control = control_0;
			while (control_0 != null)
			{
				if (control_0 is Form)
				{
					Form form = (Form)control_0;
					if (form.ShowInTaskbar)
					{
						_Control = form;
						break;
					}
					control_0 = ((form.Owner == null) ? form.Parent : form.Owner);
				}
				else
				{
					control_0 = control_0.FindForm();
				}
			}
			if (supportCrossUIThread && _Control != null && _Control.IsHandleCreated && !_Control.InvokeRequired)
			{
				_Handle = _Control.Handle;
				_Control = null;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="handle">控件句柄</param>
		public WinTaskBarProgressInfo(IntPtr handle)
		{
			_Control = null;
			_Handle = IntPtr.Zero;
			_ITaskbar = null;
			                                                                    //
			if (RuntimeEnabled)
			{
				_Handle = handle;
			}
		}

		private bool CheckState()
		{
			if (RuntimeEnabled)
			{
				IntPtr handle = Handle;
				if (handle != IntPtr.Zero)
				{
					if (_ITaskbar == null)
					{
						_ITaskbar = (ITaskbarList4)new CTaskbarList();
						_ITaskbar.HrInit();
					}
					return true;
				}
			}
			return false;
		}

		                                                                    /// <summary>
		                                                                    ///       销毁对象
		                                                                    ///       </summary>
		public void Dispose()
		{
			if (_ITaskbar != null)
			{
				lock (_ITaskbar)
				{
					_ITaskbar.SetProgressState(Handle, TBPFLAG.TBPF_NOPROGRESS);
					Marshal.ReleaseComObject(_ITaskbar);
					_ITaskbar = null;
				}
			}
		}

		public bool StartProgress()
		{
			return SetProgressState(TBPFLAG.TBPF_NORMAL);
		}

		public bool SetProgressValue(int Value, int maximum)
		{
			if (CheckState())
			{
				lock (_ITaskbar)
				{
					if (_Control != null && _Control.InvokeRequired)
					{
						_Control.Invoke(new SetProgressValueHandler(_ITaskbar.SetProgressValue), Handle, Value, maximum);
					}
					else
					{
						_ITaskbar.SetProgressValue(Handle, (ulong)Value, (ulong)maximum);
					}
				}
				return true;
			}
			return false;
		}

		public bool EndProgress()
		{
			return SetProgressState(TBPFLAG.TBPF_NOPROGRESS);
		}

		public bool SetError()
		{
			return SetProgressState(TBPFLAG.TBPF_ERROR);
		}

		public bool SetIndeterminate()
		{
			return SetProgressState(TBPFLAG.TBPF_INDETERMINATE);
		}

		public bool SetPause()
		{
			return SetProgressState(TBPFLAG.TBPF_PAUSED);
		}

		private bool SetProgressState(TBPFLAG flag)
		{
			if (CheckState())
			{
				lock (_ITaskbar)
				{
					if (_Control != null && _Control.InvokeRequired)
					{
						_Control.Invoke(new SetProgressStateHandler(_ITaskbar.SetProgressState), Handle, flag);
					}
					else
					{
						_ITaskbar.SetProgressState(Handle, flag);
					}
				}
				return true;
			}
			return false;
		}
	}
}
