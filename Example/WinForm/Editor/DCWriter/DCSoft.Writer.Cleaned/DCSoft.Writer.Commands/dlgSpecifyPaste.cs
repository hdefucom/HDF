using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       指定粘贴对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgSpecifyPaste : Form
	{
		private IDataObject idataObject_0 = null;

		private XTextDocument xtextDocument_0 = null;

		private WriterControl writerControl_0 = null;

		private string string_0 = null;

		private IContainer icontainer_0 = null;

		private Label lblSource;

		private Label label1;

		private ListBox lstFormat;

		private Button btnOK;

		private Button btnCancel;

		/// <summary>
		///       要粘贴的数据
		///       </summary>
		public IDataObject DataObject
		{
			get
			{
				return idataObject_0;
			}
			set
			{
				idataObject_0 = value;
			}
		}

		/// <summary>
		///       当前处理的文档对象
		///       </summary>
		public XTextDocument Document
		{
			get
			{
				return xtextDocument_0;
			}
			set
			{
				xtextDocument_0 = value;
			}
		}

		/// <summary>
		///       编辑器控件
		///       </summary>
		public WriterControl WriterControl
		{
			get
			{
				return writerControl_0;
			}
			set
			{
				writerControl_0 = value;
			}
		}

		/// <summary>
		///       用户指定的格式
		///       </summary>
		public string ResultFormat
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgSpecifyPaste()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgSpecifyPaste_Load(object sender, EventArgs e)
		{
			if (WriterControl != null)
			{
				Text = WriterControl.DialogTitlePrefix + Text;
			}
			IntPtr clipboardOwner = GClass262.GetClipboardOwner();
			if (clipboardOwner != IntPtr.Zero)
			{
				GClass244 gClass = new GClass244(clipboardOwner);
				if (gClass.Handle != IntPtr.Zero)
				{
					lblSource.Text += gClass.method_3();
				}
			}
			if (idataObject_0 == null)
			{
				idataObject_0 = Clipboard.GetDataObject();
			}
			string[] string_ = DocumentControler.string_1;
			foreach (string text in string_)
			{
				if (!idataObject_0.GetDataPresent(text))
				{
					continue;
				}
				if (Document != null)
				{
					CanInsertObjectEventArgs canInsertObjectEventArgs = new CanInsertObjectEventArgs(Document);
					canInsertObjectEventArgs.SpecifyPosition = -1;
					canInsertObjectEventArgs.DataObject = idataObject_0;
					canInsertObjectEventArgs.SpecifyFormat = text;
					canInsertObjectEventArgs.AccessFlags = DomAccessFlags.Normal;
					WriterControl.OnEventCanInsertObject(canInsertObjectEventArgs);
					if (!canInsertObjectEventArgs.Result)
					{
						continue;
					}
				}
				lstFormat.Items.Add(text);
			}
			lstFormat.Text = ResultFormat;
			if (lstFormat.SelectedIndex < 0 && lstFormat.Items.Count > 0)
			{
				lstFormat.SelectedIndex = 0;
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			string_0 = lstFormat.Text;
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void lstFormat_DoubleClick(object sender, EventArgs e)
		{
			if (lstFormat.SelectedIndex >= 0)
			{
				btnOK_Click(null, null);
			}
		}

		/// <summary>
		///       Clean up any resources being used.
		///       </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		///       Required method for Designer support - do not modify
		///       the contents of this method with the code editor.
		///       </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgSpecifyPaste));
			lblSource = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			lstFormat = new System.Windows.Forms.ListBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			resources.ApplyResources(lblSource, "lblSource");
			lblSource.Name = "lblSource";
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(lstFormat, "lstFormat");
			lstFormat.FormattingEnabled = true;
			lstFormat.Name = "lstFormat";
			lstFormat.DoubleClick += new System.EventHandler(lstFormat_DoubleClick);
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(lstFormat);
			base.Controls.Add(label1);
			base.Controls.Add(lblSource);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgSpecifyPaste";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgSpecifyPaste_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
