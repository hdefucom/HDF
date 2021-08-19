using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       内容链接元素编辑对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgContentLinkEditor : Form
	{
		private IContainer icontainer_0 = null;

		private Label label1;

		private TextBox txtFileName;

		private Button btnBrowse;

		private Label label2;

		private CheckBox chkReadonly;

		private Button btnOK;

		private Button btnCancel;

		private CheckBox chkSaveContentToFile;

		private Label label3;

		private ComboBox cboFileSystem;

		private ComboBox cboRange;

		private Label label4;

		private ComboBox cboState;

		private CheckBox chkReplaceMode;

		private ElementPropertiesEditEventArgs elementPropertiesEditEventArgs_0 = null;

		private bool bool_0 = false;

		/// <summary>
		///       参数
		///       </summary>
		public ElementPropertiesEditEventArgs SourceEventArgs
		{
			get
			{
				return elementPropertiesEditEventArgs_0;
			}
			set
			{
				elementPropertiesEditEventArgs_0 = value;
			}
		}

		/// <summary>
		///       数据是否修改标记
		///       </summary>
		public bool Modified
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgContentLinkEditor));
			label1 = new System.Windows.Forms.Label();
			txtFileName = new System.Windows.Forms.TextBox();
			btnBrowse = new System.Windows.Forms.Button();
			label2 = new System.Windows.Forms.Label();
			chkReadonly = new System.Windows.Forms.CheckBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			chkSaveContentToFile = new System.Windows.Forms.CheckBox();
			label3 = new System.Windows.Forms.Label();
			cboFileSystem = new System.Windows.Forms.ComboBox();
			cboRange = new System.Windows.Forms.ComboBox();
			label4 = new System.Windows.Forms.Label();
			cboState = new System.Windows.Forms.ComboBox();
			chkReplaceMode = new System.Windows.Forms.CheckBox();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(txtFileName, "txtFileName");
			txtFileName.Name = "txtFileName";
			resources.ApplyResources(btnBrowse, "btnBrowse");
			btnBrowse.Name = "btnBrowse";
			btnBrowse.UseVisualStyleBackColor = true;
			btnBrowse.Click += new System.EventHandler(btnBrowse_Click);
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(chkReadonly, "chkReadonly");
			chkReadonly.Name = "chkReadonly";
			chkReadonly.UseVisualStyleBackColor = true;
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(chkSaveContentToFile, "chkSaveContentToFile");
			chkSaveContentToFile.Name = "chkSaveContentToFile";
			chkSaveContentToFile.UseVisualStyleBackColor = true;
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			cboFileSystem.FormattingEnabled = true;
			resources.ApplyResources(cboFileSystem, "cboFileSystem");
			cboFileSystem.Name = "cboFileSystem";
			cboFileSystem.SelectedIndexChanged += new System.EventHandler(cboFileSystem_SelectedIndexChanged);
			cboRange.FormattingEnabled = true;
			cboRange.Items.AddRange(new object[4]
			{
				DCSoft.Writer.WriterStrings.Command_AlignBottomCenter,
				resources.GetString("cboRange.Items"),
				resources.GetString("cboRange.Items1"),
				resources.GetString("cboRange.Items2")
			});
			resources.ApplyResources(cboRange, "cboRange");
			cboRange.Name = "cboRange";
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboState.FormattingEnabled = true;
			cboState.Items.AddRange(new object[4]
			{
				resources.GetString("cboState.Items"),
				resources.GetString("cboState.Items1"),
				resources.GetString("cboState.Items2"),
				resources.GetString("cboState.Items3")
			});
			resources.ApplyResources(cboState, "cboState");
			cboState.Name = "cboState";
			resources.ApplyResources(chkReplaceMode, "chkReplaceMode");
			chkReplaceMode.Name = "chkReplaceMode";
			chkReplaceMode.UseVisualStyleBackColor = true;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(cboState);
			base.Controls.Add(cboRange);
			base.Controls.Add(cboFileSystem);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(chkReplaceMode);
			base.Controls.Add(chkSaveContentToFile);
			base.Controls.Add(chkReadonly);
			base.Controls.Add(label4);
			base.Controls.Add(btnBrowse);
			base.Controls.Add(label2);
			base.Controls.Add(txtFileName);
			base.Controls.Add(label3);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgContentLinkEditor";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgContentLinkEditor_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgContentLinkEditor()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgContentLinkEditor_Load(object sender, EventArgs e)
		{
			if (SourceEventArgs != null && SourceEventArgs.WriterControl != null)
			{
				Text = SourceEventArgs.WriterControl.DialogTitlePrefix + Text;
			}
			if (elementPropertiesEditEventArgs_0 != null)
			{
				WriterAppHost host = elementPropertiesEditEventArgs_0.Host;
				if (host != null)
				{
					foreach (string key in host.FileSystems.Keys)
					{
						cboFileSystem.Items.Add(key);
					}
				}
			}
			if (elementPropertiesEditEventArgs_0 != null && elementPropertiesEditEventArgs_0.Element is XTextContentLinkFieldElement)
			{
				XTextContentLinkFieldElement xTextContentLinkFieldElement = (XTextContentLinkFieldElement)elementPropertiesEditEventArgs_0.Element;
				if (xTextContentLinkFieldElement.ContentSource != null)
				{
					cboFileSystem.Text = xTextContentLinkFieldElement.ContentSource.FileSystemName;
					txtFileName.Text = xTextContentLinkFieldElement.ContentSource.FileName;
					cboRange.Text = xTextContentLinkFieldElement.ContentSource.Range;
				}
				cboState.SelectedIndex = (int)xTextContentLinkFieldElement.UpdateState;
				chkReplaceMode.Checked = xTextContentLinkFieldElement.ReplaceUpdateMode;
				chkReadonly.Checked = xTextContentLinkFieldElement.Readonly;
				chkSaveContentToFile.Checked = xTextContentLinkFieldElement.SaveLinkedContent;
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			int num = 17;
			if (elementPropertiesEditEventArgs_0 == null || !(elementPropertiesEditEventArgs_0.Element is XTextContentLinkFieldElement))
			{
				return;
			}
			XTextDocument document = elementPropertiesEditEventArgs_0.Document;
			XTextContentLinkFieldElement xTextContentLinkFieldElement = (XTextContentLinkFieldElement)elementPropertiesEditEventArgs_0.Element;
			bool flag = SourceEventArgs.LogUndo && document.CanLogUndo;
			FileContentSource contentSource = xTextContentLinkFieldElement.ContentSource;
			if (!WriterUtils.smethod_43(contentSource.FileSystemName, cboFileSystem.Text) || !WriterUtils.smethod_43(contentSource.FileName, txtFileName.Text) || !WriterUtils.smethod_43(contentSource.Range, cboRange.Text))
			{
				contentSource = new FileContentSource();
				contentSource.FileSystemName = cboFileSystem.Text.Trim();
				contentSource.FileName = txtFileName.Text.Trim();
				contentSource.Range = cboRange.Text.Trim();
				if (flag)
				{
					document.UndoList.AddProperty("ContentSource", xTextContentLinkFieldElement.ContentSource, contentSource, xTextContentLinkFieldElement);
				}
				xTextContentLinkFieldElement.ContentSource = contentSource;
				Modified = true;
			}
			ContentUpdateState selectedIndex = (ContentUpdateState)cboState.SelectedIndex;
			if (selectedIndex != xTextContentLinkFieldElement.UpdateState)
			{
				if (flag)
				{
					document.UndoList.AddProperty("UpdateState", xTextContentLinkFieldElement.UpdateState, selectedIndex, xTextContentLinkFieldElement);
				}
				xTextContentLinkFieldElement.UpdateState = selectedIndex;
				Modified = true;
			}
			if (chkReadonly.Checked != xTextContentLinkFieldElement.Readonly)
			{
				if (flag)
				{
					document.UndoList.AddProperty("Readonly", xTextContentLinkFieldElement.Readonly, chkReadonly.Checked, xTextContentLinkFieldElement);
				}
				xTextContentLinkFieldElement.Readonly = chkReadonly.Checked;
				Modified = true;
			}
			if (chkSaveContentToFile.Checked != xTextContentLinkFieldElement.SaveLinkedContent)
			{
				if (flag)
				{
					document.UndoList.AddProperty("SaveLinkedContent", xTextContentLinkFieldElement.SaveLinkedContent, chkSaveContentToFile.Checked, xTextContentLinkFieldElement);
				}
				xTextContentLinkFieldElement.SaveLinkedContent = chkSaveContentToFile.Checked;
				Modified = true;
			}
			if (chkReplaceMode.Checked != xTextContentLinkFieldElement.ReplaceUpdateMode)
			{
				if (flag)
				{
					document.UndoList.AddProperty("ReplaceUpdateMode", xTextContentLinkFieldElement.ReplaceUpdateMode, chkReplaceMode.Checked, xTextContentLinkFieldElement);
				}
				xTextContentLinkFieldElement.ReplaceUpdateMode = chkReplaceMode.Checked;
				Modified = true;
			}
			if (SourceEventArgs.Method == ElementPropertiesEditMethod.Edit)
			{
				if (Modified)
				{
					base.DialogResult = DialogResult.OK;
				}
			}
			else
			{
				base.DialogResult = DialogResult.OK;
			}
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			if (SourceEventArgs != null)
			{
				string string_ = null;
				string text = WriterControl.smethod_0(SourceEventArgs.WriterControl, SourceEventArgs.Host, txtFileName.Text, ref string_, cboFileSystem.Text);
				if (text != null)
				{
					txtFileName.Text = text;
				}
			}
		}

		private void cboFileSystem_SelectedIndexChanged(object sender, EventArgs e)
		{
		}
	}
}
