using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	[DCInternal]
	[ComVisible(false)]
	public class dlgWriterDataFormats : Form
	{
		private WriterDataFormats writerDataFormats_0 = WriterDataFormats.All;

		private IContainer icontainer_0 = null;

		private CheckBox chkAll;

		private GroupBox grpFormat;

		private CheckBox chkText;

		private CheckBox chkRTF;

		private CheckBox chkHTML;

		private CheckBox chkXML;

		private CheckBox chkImage;

		private CheckBox chkCommandName;

		private CheckBox chkFileSource;

		private CheckBox chkKBEntry;

		private Button btnOK;

		private Button btnCancel;

		public WriterDataFormats InputDataFormat
		{
			get
			{
				return writerDataFormats_0;
			}
			set
			{
				writerDataFormats_0 = value;
			}
		}

		public dlgWriterDataFormats()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgWriterDataFormats_Load(object sender, EventArgs e)
		{
			if (InputDataFormat == WriterDataFormats.All)
			{
				chkAll.Checked = true;
				return;
			}
			chkText.Checked = ((InputDataFormat & WriterDataFormats.Text) == WriterDataFormats.Text);
			chkRTF.Checked = ((InputDataFormat & WriterDataFormats.RTF) == WriterDataFormats.RTF);
			chkHTML.Checked = ((InputDataFormat & WriterDataFormats.Html) == WriterDataFormats.Html);
			chkXML.Checked = ((InputDataFormat & WriterDataFormats.XML) == WriterDataFormats.XML);
			chkImage.Checked = ((InputDataFormat & WriterDataFormats.Image) == WriterDataFormats.Image);
			chkCommandName.Checked = ((InputDataFormat & WriterDataFormats.CommandFormat) == WriterDataFormats.CommandFormat);
			chkFileSource.Checked = ((InputDataFormat & WriterDataFormats.FileSource) == WriterDataFormats.FileSource);
			chkKBEntry.Checked = ((InputDataFormat & WriterDataFormats.KBEntry) == WriterDataFormats.KBEntry);
		}

		private void chkAll_CheckedChanged(object sender, EventArgs e)
		{
			grpFormat.Enabled = !chkAll.Checked;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (chkAll.Checked)
			{
				InputDataFormat = WriterDataFormats.All;
			}
			else
			{
				WriterDataFormats writerDataFormats = WriterDataFormats.None;
				if (chkText.Checked)
				{
					writerDataFormats |= WriterDataFormats.Text;
				}
				if (chkHTML.Checked)
				{
					writerDataFormats |= WriterDataFormats.Html;
				}
				if (chkRTF.Checked)
				{
					writerDataFormats |= WriterDataFormats.RTF;
				}
				if (chkXML.Checked)
				{
					writerDataFormats |= WriterDataFormats.XML;
				}
				if (chkImage.Checked)
				{
					writerDataFormats |= WriterDataFormats.Image;
				}
				if (chkCommandName.Checked)
				{
					writerDataFormats |= WriterDataFormats.CommandFormat;
				}
				if (chkFileSource.Checked)
				{
					writerDataFormats |= WriterDataFormats.FileSource;
				}
				if (chkKBEntry.Checked)
				{
					writerDataFormats |= WriterDataFormats.KBEntry;
				}
				InputDataFormat = writerDataFormats;
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
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
			chkAll = new System.Windows.Forms.CheckBox();
			grpFormat = new System.Windows.Forms.GroupBox();
			chkFileSource = new System.Windows.Forms.CheckBox();
			chkKBEntry = new System.Windows.Forms.CheckBox();
			chkCommandName = new System.Windows.Forms.CheckBox();
			chkImage = new System.Windows.Forms.CheckBox();
			chkXML = new System.Windows.Forms.CheckBox();
			chkHTML = new System.Windows.Forms.CheckBox();
			chkRTF = new System.Windows.Forms.CheckBox();
			chkText = new System.Windows.Forms.CheckBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			grpFormat.SuspendLayout();
			SuspendLayout();
			chkAll.AutoSize = true;
			chkAll.Location = new System.Drawing.Point(13, 12);
			chkAll.Name = "chkAll";
			chkAll.Size = new System.Drawing.Size(96, 16);
			chkAll.TabIndex = 0;
			chkAll.Text = "所有数据格式";
			chkAll.UseVisualStyleBackColor = true;
			chkAll.CheckedChanged += new System.EventHandler(chkAll_CheckedChanged);
			grpFormat.Controls.Add(chkFileSource);
			grpFormat.Controls.Add(chkKBEntry);
			grpFormat.Controls.Add(chkCommandName);
			grpFormat.Controls.Add(chkImage);
			grpFormat.Controls.Add(chkXML);
			grpFormat.Controls.Add(chkHTML);
			grpFormat.Controls.Add(chkRTF);
			grpFormat.Controls.Add(chkText);
			grpFormat.Location = new System.Drawing.Point(13, 34);
			grpFormat.Name = "grpFormat";
			grpFormat.Size = new System.Drawing.Size(309, 237);
			grpFormat.TabIndex = 1;
			grpFormat.TabStop = false;
			grpFormat.Text = "特定格式";
			chkFileSource.Location = new System.Drawing.Point(19, 162);
			chkFileSource.Name = "chkFileSource";
			chkFileSource.Size = new System.Drawing.Size(273, 40);
			chkFileSource.TabIndex = 0;
			chkFileSource.Text = "文件名格式（比如从电脑资源管理器里拖拽出来的文件）";
			chkFileSource.UseVisualStyleBackColor = true;
			chkKBEntry.AutoSize = true;
			chkKBEntry.Location = new System.Drawing.Point(19, 208);
			chkKBEntry.Name = "chkKBEntry";
			chkKBEntry.Size = new System.Drawing.Size(84, 16);
			chkKBEntry.TabIndex = 0;
			chkKBEntry.Text = "知识库节点";
			chkKBEntry.UseVisualStyleBackColor = true;
			chkCommandName.AutoSize = true;
			chkCommandName.Location = new System.Drawing.Point(19, 140);
			chkCommandName.Name = "chkCommandName";
			chkCommandName.Size = new System.Drawing.Size(108, 16);
			chkCommandName.TabIndex = 0;
			chkCommandName.Text = "编辑器命令格式";
			chkCommandName.UseVisualStyleBackColor = true;
			chkImage.AutoSize = true;
			chkImage.Location = new System.Drawing.Point(19, 118);
			chkImage.Name = "chkImage";
			chkImage.Size = new System.Drawing.Size(72, 16);
			chkImage.TabIndex = 0;
			chkImage.Text = "图片格式";
			chkImage.UseVisualStyleBackColor = true;
			chkXML.AutoSize = true;
			chkXML.Location = new System.Drawing.Point(19, 96);
			chkXML.Name = "chkXML";
			chkXML.Size = new System.Drawing.Size(120, 16);
			chkXML.TabIndex = 0;
			chkXML.Text = "DCWriter内部格式";
			chkXML.UseVisualStyleBackColor = true;
			chkHTML.AutoSize = true;
			chkHTML.Location = new System.Drawing.Point(19, 74);
			chkHTML.Name = "chkHTML";
			chkHTML.Size = new System.Drawing.Size(72, 16);
			chkHTML.TabIndex = 0;
			chkHTML.Text = "HTML格式";
			chkHTML.UseVisualStyleBackColor = true;
			chkRTF.AutoSize = true;
			chkRTF.Location = new System.Drawing.Point(19, 52);
			chkRTF.Name = "chkRTF";
			chkRTF.Size = new System.Drawing.Size(66, 16);
			chkRTF.TabIndex = 0;
			chkRTF.Text = "RTF格式";
			chkRTF.UseVisualStyleBackColor = true;
			chkText.AutoSize = true;
			chkText.Location = new System.Drawing.Point(19, 30);
			chkText.Name = "chkText";
			chkText.Size = new System.Drawing.Size(84, 16);
			chkText.TabIndex = 0;
			chkText.Text = "纯文本格式";
			chkText.UseVisualStyleBackColor = true;
			btnOK.Location = new System.Drawing.Point(108, 277);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(75, 23);
			btnOK.TabIndex = 2;
			btnOK.Text = "确定(&O)";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			btnCancel.Location = new System.Drawing.Point(205, 277);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(75, 23);
			btnCancel.TabIndex = 2;
			btnCancel.Text = "取消(&C)";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.ClientSize = new System.Drawing.Size(333, 308);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(grpFormat);
			base.Controls.Add(chkAll);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgWriterDataFormats";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "数据格式";
			base.Load += new System.EventHandler(dlgWriterDataFormats_Load);
			grpFormat.ResumeLayout(false);
			grpFormat.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
