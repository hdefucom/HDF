using DCSoft.Common;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       显示内容保护信息的对话框
	///       </summary>
	[ComVisible(false)]
	[DCInternal]
	public class dlgPromptProtectedContent : Form
	{
		private GClass108 gclass108_0 = null;

		private IContainer icontainer_0 = null;

		private Label label1;

		private TextBox txtUnDeleteContent;

		private Button btnOK;

		private CheckBox chkHidden;

		/// <summary>
		///       内容保护信息列表
		///       </summary>
		public GClass108 ContentProtectedInfo
		{
			get
			{
				return gclass108_0;
			}
			set
			{
				gclass108_0 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgPromptProtectedContent()
		{
			InitializeComponent();
		}

		private void dlgPromptProtectedContent_Load(object sender, EventArgs e)
		{
			int num = 14;
			if (gclass108_0 != null && gclass108_0.Count > 0)
			{
				StringBuilder stringBuilder = new StringBuilder();
				ContentProtectedInfo contentProtectedInfo = null;
				foreach (ContentProtectedInfo item in gclass108_0)
				{
					bool flag = false;
					if (contentProtectedInfo == null)
					{
						flag = true;
					}
					else if (!item.Element.GetType().Equals(contentProtectedInfo.Element.GetType()))
					{
						stringBuilder.AppendLine();
						flag = true;
					}
					if (flag)
					{
						stringBuilder.Append(item.Element.DispalyTypeName);
						stringBuilder.Append(":");
					}
					contentProtectedInfo = item;
					if (item.Element is XTextCharElement)
					{
						XTextCharElement xTextCharElement = (XTextCharElement)item.Element;
						stringBuilder.Append(xTextCharElement.CharValue.ToString());
					}
					else
					{
						if (contentProtectedInfo != null && contentProtectedInfo.Element is XTextCharElement)
						{
							stringBuilder.Append("#" + contentProtectedInfo.Message);
						}
						if (item.Element is XTextInputFieldElementBase)
						{
							XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)item.Element;
							stringBuilder.Append(xTextInputFieldElementBase.DisplayName);
							stringBuilder.Append(":");
							stringBuilder.Append(WriterUtils.smethod_33(xTextInputFieldElementBase.Text, 50));
							stringBuilder.Append("#");
							stringBuilder.Append(item.Message);
						}
						else
						{
							stringBuilder.Append(string.Concat(item.Element, "#", item.Message));
						}
					}
					if (stringBuilder.Length > 1000)
					{
						break;
					}
				}
				if (contentProtectedInfo != null && contentProtectedInfo.Element is XTextCharElement)
				{
					stringBuilder.Append("#" + contentProtectedInfo.Message);
				}
				txtUnDeleteContent.Text = stringBuilder.ToString();
				txtUnDeleteContent.SelectionStart = 0;
				txtUnDeleteContent.SelectionLength = 0;
			}
			btnOK.Focus();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (chkHidden.Checked && gclass108_0 != null && gclass108_0.Count > 0)
			{
				XTextDocument ownerDocument = gclass108_0[0].Element.OwnerDocument;
				if (ownerDocument != null)
				{
					ownerDocument.Options.BehaviorOptions.PromptProtectedContent = PromptProtectedContentMode.None;
					if (ownerDocument.EditorControl != null)
					{
						ownerDocument.EditorControl.DocumentOptions.BehaviorOptions.PromptProtectedContent = PromptProtectedContentMode.None;
					}
				}
			}
			Close();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Controls.dlgPromptProtectedContent));
			label1 = new System.Windows.Forms.Label();
			txtUnDeleteContent = new System.Windows.Forms.TextBox();
			btnOK = new System.Windows.Forms.Button();
			chkHidden = new System.Windows.Forms.CheckBox();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			txtUnDeleteContent.BackColor = System.Drawing.SystemColors.ControlLightLight;
			resources.ApplyResources(txtUnDeleteContent, "txtUnDeleteContent");
			txtUnDeleteContent.Name = "txtUnDeleteContent";
			txtUnDeleteContent.ReadOnly = true;
			btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(chkHidden, "chkHidden");
			chkHidden.Name = "chkHidden";
			chkHidden.UseVisualStyleBackColor = true;
			base.AcceptButton = btnOK;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnOK;
			base.Controls.Add(chkHidden);
			base.Controls.Add(btnOK);
			base.Controls.Add(txtUnDeleteContent);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgPromptProtectedContent";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgPromptProtectedContent_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
