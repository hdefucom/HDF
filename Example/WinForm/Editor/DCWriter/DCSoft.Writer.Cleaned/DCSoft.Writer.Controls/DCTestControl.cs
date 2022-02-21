using DCSoft.Common;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       用于测试的控件
	///       </summary>
	[ComClass("00012345-6789-ABCD-EF01-234567898877", "A32BC359-C7FB-44F8-B3D6-5128FC3CF863", "0E0098EB-FE7B-4849-9FC8-C7CC69F8F18B")]
	[ComVisible(true)]
	[ComSourceInterfaces(typeof(IDCTestControlComEvents))]
	[ComDefaultInterface(typeof(IDCTestControl))]
	[Guid("00012345-6789-ABCD-EF01-234567898877")]
	[ClassInterface(ClassInterfaceType.None)]
	public class DCTestControl : UserControl, IObjectSafety, IDCTestControl
	{
		private const string _IID_IDispatch = "{00020400-0000-0000-C000-000000000046}";

		private const string _IID_IDispatchEx = "{a6ef9860-c720-11d0-9337-00a0c90dcaa9}";

		private const string _IID_IPersistStorage = "{0000010A-0000-0000-C000-000000000046}";

		private const string _IID_IPersistStream = "{00000109-0000-0000-C000-000000000046}";

		private const string _IID_IPersistPropertyBag = "{37D84F60-42CB-11CE-8135-00AA004BB851}";

		private const int INTERFACESAFE_FOR_UNTRUSTED_CALLER = 1;

		private const int INTERFACESAFE_FOR_UNTRUSTED_DATA = 2;

		private const int S_OK = 0;

		private const int E_FAIL = -2147467259;

		private const int E_NOINTERFACE = -2147467262;

		internal const string CLASSID = "00012345-6789-ABCD-EF01-234567898877";

		internal const string CLASSID_Interface = "A32BC359-C7FB-44F8-B3D6-5128FC3CF863";

		internal const string CLASSID_ComEventInterface = "0E0098EB-FE7B-4849-9FC8-C7CC69F8F18B";

		private bool _fSafeForScripting = true;

		private bool _fSafeForInitializing = true;

		/// <summary> 
		///       必需的设计器变量。
		///       </summary>
		private IContainer components = null;

		private Button button1;

		private Button btnVoidEvent;

		private Label label1;

		private Button btnAbout;

		/// <summary>
		///       按钮文本
		///       </summary>
		[ComVisible(true)]
		public string ButtonText
		{
			get
			{
				return button1.Text;
			}
			set
			{
				button1.Text = value;
			}
		}

		public event WriterLinkEventHandler MyLinkEvent = null;

		public event ComVoidHandler MyVoidEvent = null;

		/// <summary>
		///       初始化对象
		///       </summary>
		public DCTestControl()
		{
			InitializeComponent();
			label1.Text = "CLR:" + Environment.Version.ToString();
			base.HandleDestroyed += DCTestControl_HandleDestroyed;
		}

		[ComVisible(true)]
		public void ComDispose()
		{
			dlgAxWriterControlDock.AddControl(this);
		}

		private void DCTestControl_HandleDestroyed(object sender, EventArgs e)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int num = 4;
			if (this.MyLinkEvent != null)
			{
				MessageBox.Show(this, "打开链接");
				WriterLinkEventArgs e2 = new WriterLinkEventArgs(null, null, null, "www.dcwriter.cn", "_blank");
				this.MyLinkEvent(this, e2);
			}
			else
			{
				MessageBox.Show("没有事件");
			}
		}

		[ComRegisterFunction]
		[EditorBrowsable(EditorBrowsableState.Never)]
		private static void Register(Type type_0)
		{
			GClass305.smethod_1(type_0, "1");
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[ComUnregisterFunction]
		private static void Unregister(Type type_0)
		{
			GClass305.smethod_2(type_0);
		}

		/// <summary>
		///       接口实现
		///       </summary>
		/// <param name="riid">
		/// </param>
		/// <param name="pdwSupportedOptions">
		/// </param>
		/// <param name="pdwEnabledOptions">
		/// </param>
		/// <returns>
		/// </returns>
		[ComVisible(true)]
		
		public int GetInterfaceSafetyOptions(ref Guid riid, ref int pdwSupportedOptions, ref int pdwEnabledOptions)
		{
			int num = 15;
			int num2 = -2147467259;
			string text = riid.ToString("B");
			pdwSupportedOptions = 3;
			switch (text)
			{
			case "{0000010A-0000-0000-C000-000000000046}":
			case "{00000109-0000-0000-C000-000000000046}":
			case "{37D84F60-42CB-11CE-8135-00AA004BB851}":
				num2 = 0;
				pdwEnabledOptions = 0;
				if (_fSafeForInitializing)
				{
					pdwEnabledOptions = 2;
				}
				break;
			case "{00020400-0000-0000-C000-000000000046}":
			case "{a6ef9860-c720-11d0-9337-00a0c90dcaa9}":
				num2 = 0;
				pdwEnabledOptions = 0;
				if (_fSafeForScripting)
				{
					pdwEnabledOptions = 1;
				}
				break;
			default:
				num2 = -2147467262;
				pdwEnabledOptions = 3;
				break;
			}
			return num2;
		}

		/// <summary>
		///       接口实现
		///       </summary>
		/// <param name="riid">
		/// </param>
		/// <param name="dwOptionSetMask">
		/// </param>
		/// <param name="dwEnabledOptions">
		/// </param>
		/// <returns>
		/// </returns>
		[ComVisible(true)]
		
		public int SetInterfaceSafetyOptions(ref Guid riid, int dwOptionSetMask, int dwEnabledOptions)
		{
			int num = 15;
			int result = -2147467259;
			switch (riid.ToString("B"))
			{
			case "{0000010A-0000-0000-C000-000000000046}":
			case "{00000109-0000-0000-C000-000000000046}":
			case "{37D84F60-42CB-11CE-8135-00AA004BB851}":
				if ((dwEnabledOptions & dwOptionSetMask) == 2 && _fSafeForInitializing)
				{
					result = 0;
				}
				break;
			case "{00020400-0000-0000-C000-000000000046}":
			case "{a6ef9860-c720-11d0-9337-00a0c90dcaa9}":
				if ((dwEnabledOptions & dwOptionSetMask) == 1 && _fSafeForScripting)
				{
					result = 0;
				}
				break;
			default:
				result = -2147467262;
				break;
			}
			return result;
		}

		private void DCTestControl_Load(object sender, EventArgs e)
		{
		}

		[ComVisible(true)]
		public void SetButtonText(string string_0)
		{
			button1.Text = string_0;
		}

		private void btnVoidEvent_Click(object sender, EventArgs e)
		{
			int num = 5;
			if (this.MyVoidEvent != null)
			{
				MessageBox.Show("准备触发 MyVoidEvent");
				this.MyVoidEvent();
			}
			else
			{
				MessageBox.Show("没有MyVoidEvent");
			}
		}

		private void btnAbout_Click(object sender, EventArgs e)
		{
			using (dlgAbout dlgAbout = new dlgAbout())
			{
				dlgAbout.ShowDialog(this);
			}
		}

		/// <summary> 
		///       清理所有正在使用的资源。
		///       </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			MessageBox.Show("DCTestControl.Dispose");
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
			GC.SuppressFinalize(this);
			GC.KeepAlive(this);
		}

		/// <summary> 
		///       设计器支持所需的方法 - 不要
		///       使用代码编辑器修改此方法的内容。
		///       </summary>
		private void InitializeComponent()
		{
			button1 = new System.Windows.Forms.Button();
			btnVoidEvent = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			btnAbout = new System.Windows.Forms.Button();
			SuspendLayout();
			button1.Location = new System.Drawing.Point(34, 64);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(161, 23);
			button1.TabIndex = 0;
			button1.Text = "button1";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			btnVoidEvent.Location = new System.Drawing.Point(37, 93);
			btnVoidEvent.Name = "btnVoidEvent";
			btnVoidEvent.Size = new System.Drawing.Size(158, 23);
			btnVoidEvent.TabIndex = 1;
			btnVoidEvent.Text = "Void Event";
			btnVoidEvent.UseVisualStyleBackColor = true;
			btnVoidEvent.Click += new System.EventHandler(btnVoidEvent_Click);
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(32, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(41, 12);
			label1.TabIndex = 2;
			label1.Text = "label1";
			btnAbout.Location = new System.Drawing.Point(37, 35);
			btnAbout.Name = "btnAbout";
			btnAbout.Size = new System.Drawing.Size(158, 23);
			btnAbout.TabIndex = 3;
			btnAbout.Text = "关于";
			btnAbout.UseVisualStyleBackColor = true;
			btnAbout.Click += new System.EventHandler(btnAbout_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.Blue;
			base.Controls.Add(btnAbout);
			base.Controls.Add(label1);
			base.Controls.Add(btnVoidEvent);
			base.Controls.Add(button1);
			base.Name = "DCTestControl";
			base.Size = new System.Drawing.Size(261, 152);
			base.Load += new System.EventHandler(DCTestControl_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
