using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       文档统计信息对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgWordCount : Form
	{
		private WordCountResult wordCountResult_0 = null;

		private IContainer icontainer_0 = null;

		private Label label1;

		private Label lblPages;

		private Label label2;

		private Label lblWords;

		private Label label4;

		private Label lblChars;

		private Label label6;

		private Label lblCharsNOWhitespace;

		private Label label8;

		private Label lblParagraphs;

		private Label label10;

		private Label lblLines;

		private Label label12;

		private Label lblImages;

		private Button btnClose;

		/// <summary>
		///       文档统计信息结果
		///       </summary>
		public WordCountResult CountResult
		{
			get
			{
				return wordCountResult_0;
			}
			set
			{
				wordCountResult_0 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgWordCount()
		{
			InitializeComponent();
		}

		private void dlgWordCount_Load(object sender, EventArgs e)
		{
			if (wordCountResult_0 == null)
			{
				wordCountResult_0 = new WordCountResult();
			}
			lblChars.Text = wordCountResult_0.Chars.ToString();
			lblCharsNOWhitespace.Text = wordCountResult_0.CharsNoWhitespace.ToString();
			lblImages.Text = wordCountResult_0.Images.ToString();
			lblLines.Text = wordCountResult_0.Lines.ToString();
			lblPages.Text = wordCountResult_0.Pages.ToString();
			lblParagraphs.Text = wordCountResult_0.Paragraphs.ToString();
			lblWords.Text = wordCountResult_0.Words.ToString();
		}

		private void btnClose_Click(object sender, EventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgWordCount));
			label1 = new System.Windows.Forms.Label();
			lblPages = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			lblWords = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			lblChars = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			lblCharsNOWhitespace = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			lblParagraphs = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			lblLines = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			lblImages = new System.Windows.Forms.Label();
			btnClose = new System.Windows.Forms.Button();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(lblPages, "lblPages");
			lblPages.Name = "lblPages";
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(lblWords, "lblWords");
			lblWords.Name = "lblWords";
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			resources.ApplyResources(lblChars, "lblChars");
			lblChars.Name = "lblChars";
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
			resources.ApplyResources(lblCharsNOWhitespace, "lblCharsNOWhitespace");
			lblCharsNOWhitespace.Name = "lblCharsNOWhitespace";
			resources.ApplyResources(label8, "label8");
			label8.Name = "label8";
			resources.ApplyResources(lblParagraphs, "lblParagraphs");
			lblParagraphs.Name = "lblParagraphs";
			resources.ApplyResources(label10, "label10");
			label10.Name = "label10";
			resources.ApplyResources(lblLines, "lblLines");
			lblLines.Name = "lblLines";
			resources.ApplyResources(label12, "label12");
			label12.Name = "label12";
			resources.ApplyResources(lblImages, "lblImages");
			lblImages.Name = "lblImages";
			resources.ApplyResources(btnClose, "btnClose");
			btnClose.Name = "btnClose";
			btnClose.UseVisualStyleBackColor = true;
			btnClose.Click += new System.EventHandler(btnClose_Click);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(btnClose);
			base.Controls.Add(lblImages);
			base.Controls.Add(lblLines);
			base.Controls.Add(lblParagraphs);
			base.Controls.Add(lblCharsNOWhitespace);
			base.Controls.Add(lblChars);
			base.Controls.Add(lblWords);
			base.Controls.Add(lblPages);
			base.Controls.Add(label12);
			base.Controls.Add(label10);
			base.Controls.Add(label8);
			base.Controls.Add(label6);
			base.Controls.Add(label4);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgWordCount";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgWordCount_Load);
			ResumeLayout(false);
		}
	}
}
