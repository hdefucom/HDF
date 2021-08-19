using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       图片元素对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgImageElementEditor : Form
	{
		private ElementPropertiesEditEventArgs elementPropertiesEditEventArgs_0 = null;

		private IContainer icontainer_0 = null;

		private GroupBox groupBox1;

		private GroupBox groupBox2;

		private Panel panel1;

		private TextBox txtTitle;

		private Label label2;

		private TextBox txtID;

		private Label label1;

		private TextBox txtAlt;

		private Label label3;

		private CheckBox chkKeepWidthHeightRate;

		private Button btnBrowseSource;

		private TextBox txtSource;

		private Label label4;

		private CheckBox chkSaveContentInFile;

		private CheckBox chkAdditionShapeFixSize;

		private GControl3 picImage;

		private ToolStrip toolStrip1;

		private Button btnCancel;

		private Button btnOK;

		private ToolStripButton btnClear;

		private ToolStripButton btnLoad;

		private ToolStripButton btnSave;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripButton btnCopy;

		private ToolStripButton btnPaste;

		private Button btnBrowseLink;

		private TextBox txtLink;

		private Label label5;

		private Label label6;

		private ElementEventTemplate elementEventTemplate1;

		private ComboBox cboVAngle;

		private ComboBox cboContentReadonly;

		private Label label21;

		private CheckBox chkSmoothZoom;

		private CheckBox chkEnableRepeatedImage;

		private ComboBox cboZOrderStyle;

		private Label label7;

		private NumericUpDown txtOffsetY;

		private Label label9;

		private NumericUpDown txtOffsetX;

		private Label label8;

		private Label label10;

		private GClass304 btnTransparentColor;

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
		///       初始化对象
		///       </summary>
		public dlgImageElementEditor()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgImageElementEditor_Load(object sender, EventArgs e)
		{
			if (SourceEventArgs != null && SourceEventArgs.WriterControl != null)
			{
				Text = SourceEventArgs.WriterControl.DialogTitlePrefix + Text;
			}
			if (SourceEventArgs != null && SourceEventArgs.Element is XTextImageElement)
			{
				XTextImageElement xTextImageElement = (XTextImageElement)SourceEventArgs.Element;
				txtID.Text = xTextImageElement.ID;
				txtTitle.Text = xTextImageElement.Title;
				txtAlt.Text = xTextImageElement.Alt;
				txtSource.Text = xTextImageElement.Source;
				chkAdditionShapeFixSize.Checked = xTextImageElement.AdditionShapeFixSize;
				chkKeepWidthHeightRate.Checked = xTextImageElement.KeepWidthHeightRate;
				chkSaveContentInFile.Checked = xTextImageElement.SaveContentInFile;
				picImage.method_6(xTextImageElement.Image.Value);
				picImage.Tag = xTextImageElement.Image;
				txtLink.Tag = xTextImageElement.LinkInfo;
				cboContentReadonly.SelectedIndex = (int)xTextImageElement.ContentReadonly;
				cboVAngle.SelectedIndex = (int)xTextImageElement.VAlign;
				chkEnableRepeatedImage.Checked = xTextImageElement.EnableRepeatedImage;
				if (xTextImageElement.LinkInfo != null)
				{
					txtLink.Text = xTextImageElement.LinkInfo.ToString();
				}
				chkSmoothZoom.Checked = xTextImageElement.SmoothZoom;
				cboZOrderStyle.SelectedIndex = (int)xTextImageElement.ZOrderStyle;
				txtOffsetX.Value = (decimal)xTextImageElement.OffsetX;
				txtOffsetY.Value = (decimal)xTextImageElement.OffsetY;
				btnTransparentColor.method_1(xTextImageElement.TransparentColor);
				btnTransparentColor.method_3(bool_2: true);
				cboZOrderStyle_SelectedIndexChanged(null, null);
			}
			method_0();
		}

		private void method_0()
		{
			btnClear.Enabled = (picImage.method_5() != null);
			btnSave.Enabled = (picImage.method_5() != null);
			btnCopy.Enabled = (picImage.method_5() != null);
		}

		private void btnBrowseSource_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = WriterStrings.ImageFileFilter;
				openFileDialog.CheckFileExists = true;
				openFileDialog.ShowReadOnly = false;
				openFileDialog.FileName = txtSource.Text;
				if (openFileDialog.ShowDialog(this) == DialogResult.OK)
				{
					txtSource.Text = openFileDialog.FileName;
					XImageValue xImageValue = new XImageValue(openFileDialog.FileName);
					picImage.Tag = xImageValue;
					picImage.method_6(xImageValue.Value);
					method_0();
				}
			}
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			picImage.method_6(null);
			picImage.Tag = null;
			method_0();
		}

		private void btnLoad_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = WriterStrings.ImageFileFilter;
				openFileDialog.CheckFileExists = true;
				openFileDialog.ShowReadOnly = false;
				if (openFileDialog.ShowDialog(this) == DialogResult.OK)
				{
					XImageValue xImageValue = new XImageValue(openFileDialog.FileName);
					picImage.Tag = xImageValue;
					picImage.method_6(xImageValue.Value);
					method_0();
				}
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (picImage.method_5() != null)
			{
				using (SaveFileDialog saveFileDialog = new SaveFileDialog())
				{
					saveFileDialog.Filter = WriterStrings.ImageFileFilter;
					saveFileDialog.OverwritePrompt = true;
					if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
					{
						XImageValue xImageValue = (XImageValue)picImage.Tag;
						xImageValue.Save(saveFileDialog.FileName);
					}
				}
			}
		}

		private void btnCopy_Click(object sender, EventArgs e)
		{
			if (picImage.method_5() != null)
			{
				Clipboard.SetData(DataFormats.Bitmap, picImage.method_5());
			}
		}

		private void btnPaste_Click(object sender, EventArgs e)
		{
			if (Clipboard.ContainsImage())
			{
				picImage.method_6(Clipboard.GetImage());
				picImage.Tag = new XImageValue(picImage.method_5());
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			int num = 13;
			if (SourceEventArgs == null)
			{
				return;
			}
			XTextDocument document = SourceEventArgs.Document;
			XTextImageElement xTextImageElement = (XTextImageElement)SourceEventArgs.Element;
			xTextImageElement.OwnerDocument = document;
			bool flag = SourceEventArgs.LogUndo && document.CanLogUndo;
			bool flag2 = false;
			string text = txtID.Text.Trim();
			if (text.Length == 0)
			{
				text = null;
			}
			if (text != xTextImageElement.ID)
			{
				if (flag)
				{
					document.UndoList.AddProperty("ID", xTextImageElement.ID, text, xTextImageElement);
				}
				xTextImageElement.ID = text;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			text = txtTitle.Text.Trim();
			if (text.Length == 0)
			{
				text = null;
			}
			if (text != xTextImageElement.Title)
			{
				if (flag)
				{
					document.UndoList.AddProperty("Title", xTextImageElement.Title, text, xTextImageElement);
				}
				xTextImageElement.Title = text;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			text = txtAlt.Text.Trim();
			if (text.Length == 0)
			{
				text = null;
			}
			if (text != xTextImageElement.Alt)
			{
				if (flag)
				{
					document.UndoList.AddProperty("Alt", xTextImageElement.Alt, text, xTextImageElement);
				}
				xTextImageElement.Alt = text;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			HyperlinkInfo hyperlinkInfo = (HyperlinkInfo)txtLink.Tag;
			if (hyperlinkInfo != xTextImageElement.LinkInfo)
			{
				if (flag)
				{
					document.UndoList.AddProperty("LinkInfo", xTextImageElement.LinkInfo, hyperlinkInfo, xTextImageElement);
				}
				xTextImageElement.LinkInfo = hyperlinkInfo;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			if (chkAdditionShapeFixSize.Checked != xTextImageElement.AdditionShapeFixSize)
			{
				if (flag)
				{
					document.UndoList.AddProperty("AdditionShapeFixSize", xTextImageElement.AdditionShapeFixSize, chkAdditionShapeFixSize.Checked, xTextImageElement);
				}
				xTextImageElement.AdditionShapeFixSize = chkAdditionShapeFixSize.Checked;
				SourceEventArgs.SetContentEffect(ContentEffects.Layout);
				flag2 = true;
			}
			VerticalAlignStyle selectedIndex = (VerticalAlignStyle)cboVAngle.SelectedIndex;
			if (selectedIndex != xTextImageElement.VAlign)
			{
				if (flag)
				{
					document.UndoList.AddProperty("VAlign", xTextImageElement.VAlign, selectedIndex, xTextImageElement);
				}
				xTextImageElement.VAlign = selectedIndex;
				SourceEventArgs.SetContentEffect(ContentEffects.Layout);
				flag2 = true;
			}
			ContentReadonlyState selectedIndex2 = (ContentReadonlyState)cboContentReadonly.SelectedIndex;
			if (selectedIndex2 != xTextImageElement.ContentReadonly)
			{
				if (flag)
				{
					document.UndoList.AddProperty("ContentReadonly", xTextImageElement.ContentReadonly, selectedIndex2, xTextImageElement);
				}
				xTextImageElement.ContentReadonly = selectedIndex2;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
				flag2 = true;
			}
			if (chkKeepWidthHeightRate.Checked != xTextImageElement.KeepWidthHeightRate)
			{
				if (flag)
				{
					document.UndoList.AddProperty("KeepWidthHeightRate", xTextImageElement.KeepWidthHeightRate, chkKeepWidthHeightRate.Checked, xTextImageElement);
				}
				xTextImageElement.KeepWidthHeightRate = chkKeepWidthHeightRate.Checked;
				SourceEventArgs.SetContentEffect(ContentEffects.Layout);
				flag2 = true;
			}
			if (chkEnableRepeatedImage.Checked != xTextImageElement.EnableRepeatedImage)
			{
				if (flag)
				{
					document.UndoList.AddProperty("EnableRepeatedImage", xTextImageElement.EnableRepeatedImage, chkEnableRepeatedImage.Checked, xTextImageElement);
				}
				xTextImageElement.EnableRepeatedImage = chkEnableRepeatedImage.Checked;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
				flag2 = true;
			}
			if (chkSaveContentInFile.Checked != xTextImageElement.SaveContentInFile)
			{
				if (flag)
				{
					document.UndoList.AddProperty("SaveContentInFile", xTextImageElement.SaveContentInFile, chkSaveContentInFile.Checked, xTextImageElement);
				}
				xTextImageElement.SaveContentInFile = chkSaveContentInFile.Checked;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
				flag2 = true;
			}
			if (chkSmoothZoom.Checked != xTextImageElement.SmoothZoom)
			{
				if (flag)
				{
					document.UndoList.AddProperty("SmoothZoom", xTextImageElement.SmoothZoom, chkSmoothZoom.Checked, xTextImageElement);
				}
				xTextImageElement.SmoothZoom = chkSmoothZoom.Checked;
				SourceEventArgs.SetContentEffect(ContentEffects.Display);
				flag2 = true;
			}
			Color color = btnTransparentColor.method_0();
			if (color != xTextImageElement.TransparentColor)
			{
				if (flag)
				{
					document.UndoList.AddProperty("TransparentColor", xTextImageElement.TransparentColor, color, xTextImageElement);
				}
				xTextImageElement.TransparentColor = color;
				SourceEventArgs.SetContentEffect(ContentEffects.Display);
				flag2 = true;
			}
			if (picImage.Tag != xTextImageElement.Image)
			{
				XImageValue xImageValue = (XImageValue)picImage.Tag;
				if (xImageValue == null)
				{
					xImageValue = new XImageValue();
				}
				if (flag)
				{
					document.UndoList.AddProperty("Image", xTextImageElement.Image, xImageValue, xTextImageElement);
				}
				xTextImageElement.Image = xImageValue;
				SourceEventArgs.SetContentEffect(ContentEffects.Layout);
				flag2 = true;
			}
			ElementZOrderStyle selectedIndex3 = (ElementZOrderStyle)cboZOrderStyle.SelectedIndex;
			if (selectedIndex3 != xTextImageElement.ZOrderStyle)
			{
				if (flag)
				{
					document.UndoList.AddProperty("ZOrderStyle", xTextImageElement.ZOrderStyle, selectedIndex3, xTextImageElement);
				}
				xTextImageElement.ZOrderStyle = selectedIndex3;
				SourceEventArgs.SetContentEffect(ContentEffects.Layout);
				flag2 = true;
				if (selectedIndex3 == ElementZOrderStyle.InFrontOfText || selectedIndex3 == ElementZOrderStyle.UnderText)
				{
					float num2 = (float)txtOffsetX.Value;
					float num3 = (float)txtOffsetY.Value;
					if (num2 != xTextImageElement.OffsetX)
					{
						if (flag)
						{
							document.UndoList.AddProperty("OffsetX", xTextImageElement.OffsetX, num2, xTextImageElement);
						}
						xTextImageElement.OffsetX = num2;
					}
					if (num3 != xTextImageElement.OffsetY)
					{
						if (flag)
						{
							document.UndoList.AddProperty("OffsetY", xTextImageElement.OffsetY, num3, xTextImageElement);
						}
						xTextImageElement.OffsetY = num3;
					}
				}
			}
			text = txtSource.Text.Trim();
			if (text.Length == 0)
			{
				text = null;
			}
			if (text != xTextImageElement.Source)
			{
				if (flag)
				{
					document.UndoList.AddProperty("Source", xTextImageElement.Source, text, xTextImageElement);
				}
				xTextImageElement.Source = text;
				flag2 = true;
				try
				{
					xTextImageElement.UpdateImageContent();
				}
				catch (Exception ex)
				{
					document.EditorControl.UITools.ShowErrorMessageBox(this, ex.Message);
				}
				SourceEventArgs.SetContentEffect(ContentEffects.Layout);
			}
			if (flag2 && SourceEventArgs.Method == ElementPropertiesEditMethod.Edit && xTextImageElement.Image != null && xTextImageElement.Image.HasContent)
			{
				SizeF sizeF = new SizeF(xTextImageElement.Width, xTextImageElement.Height);
				xTextImageElement.UpdateSize(keepSizePossible: true);
				SizeF sizeF2 = new SizeF(xTextImageElement.Width, xTextImageElement.Height);
				if (flag)
				{
					document.UndoList.AddProperty("Width", sizeF.Width, xTextImageElement.Width, xTextImageElement);
					document.UndoList.AddProperty("Height", sizeF.Height, xTextImageElement.Height, xTextImageElement);
				}
				SourceEventArgs.SetContentEffect(ContentEffects.Layout);
			}
			if (SourceEventArgs.Method == ElementPropertiesEditMethod.Edit)
			{
				if (flag2)
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

		private void btnBrowseLink_Click(object sender, EventArgs e)
		{
			using (dlgHyperlinkInfo dlgHyperlinkInfo = new dlgHyperlinkInfo())
			{
				HyperlinkInfo hyperlinkInfo = (HyperlinkInfo)txtLink.Tag;
				hyperlinkInfo = (dlgHyperlinkInfo.InputInfo = ((hyperlinkInfo != null) ? hyperlinkInfo.method_0() : new HyperlinkInfo()));
				if (dlgHyperlinkInfo.ShowDialog(this) == DialogResult.OK)
				{
					txtLink.Text = dlgHyperlinkInfo.InputInfo.ToString();
					txtLink.Tag = dlgHyperlinkInfo.InputInfo;
				}
			}
		}

		private void cboZOrderStyle_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtOffsetX.Enabled = (cboZOrderStyle.SelectedIndex == 1 || cboZOrderStyle.SelectedIndex == 2);
			txtOffsetY.Enabled = txtOffsetX.Enabled;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgImageElementEditor));
			groupBox1 = new System.Windows.Forms.GroupBox();
			txtOffsetY = new System.Windows.Forms.NumericUpDown();
			label9 = new System.Windows.Forms.Label();
			txtOffsetX = new System.Windows.Forms.NumericUpDown();
			label8 = new System.Windows.Forms.Label();
			chkEnableRepeatedImage = new System.Windows.Forms.CheckBox();
			chkSmoothZoom = new System.Windows.Forms.CheckBox();
			cboContentReadonly = new System.Windows.Forms.ComboBox();
			label21 = new System.Windows.Forms.Label();
			cboZOrderStyle = new System.Windows.Forms.ComboBox();
			label7 = new System.Windows.Forms.Label();
			cboVAngle = new System.Windows.Forms.ComboBox();
			label6 = new System.Windows.Forms.Label();
			btnBrowseLink = new System.Windows.Forms.Button();
			btnBrowseSource = new System.Windows.Forms.Button();
			chkAdditionShapeFixSize = new System.Windows.Forms.CheckBox();
			chkSaveContentInFile = new System.Windows.Forms.CheckBox();
			chkKeepWidthHeightRate = new System.Windows.Forms.CheckBox();
			txtSource = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			txtAlt = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			txtLink = new System.Windows.Forms.TextBox();
			txtTitle = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			txtID = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			groupBox2 = new System.Windows.Forms.GroupBox();
			picImage = new DCSoftDotfuscate.GControl3();
			toolStrip1 = new System.Windows.Forms.ToolStrip();
			btnClear = new System.Windows.Forms.ToolStripButton();
			btnLoad = new System.Windows.Forms.ToolStripButton();
			btnSave = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			btnCopy = new System.Windows.Forms.ToolStripButton();
			btnPaste = new System.Windows.Forms.ToolStripButton();
			panel1 = new System.Windows.Forms.Panel();
			btnCancel = new System.Windows.Forms.Button();
			btnOK = new System.Windows.Forms.Button();
			elementEventTemplate1 = new DCSoft.Writer.ElementEventTemplate();
			label10 = new System.Windows.Forms.Label();
			btnTransparentColor = new DCSoftDotfuscate.GClass304();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)txtOffsetY).BeginInit();
			((System.ComponentModel.ISupportInitialize)txtOffsetX).BeginInit();
			groupBox2.SuspendLayout();
			toolStrip1.SuspendLayout();
			panel1.SuspendLayout();
			SuspendLayout();
			groupBox1.Controls.Add(btnTransparentColor);
			groupBox1.Controls.Add(label10);
			groupBox1.Controls.Add(txtOffsetY);
			groupBox1.Controls.Add(label9);
			groupBox1.Controls.Add(txtOffsetX);
			groupBox1.Controls.Add(label8);
			groupBox1.Controls.Add(chkEnableRepeatedImage);
			groupBox1.Controls.Add(chkSmoothZoom);
			groupBox1.Controls.Add(cboContentReadonly);
			groupBox1.Controls.Add(label21);
			groupBox1.Controls.Add(cboZOrderStyle);
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(cboVAngle);
			groupBox1.Controls.Add(label6);
			groupBox1.Controls.Add(btnBrowseLink);
			groupBox1.Controls.Add(btnBrowseSource);
			groupBox1.Controls.Add(chkAdditionShapeFixSize);
			groupBox1.Controls.Add(chkSaveContentInFile);
			groupBox1.Controls.Add(chkKeepWidthHeightRate);
			groupBox1.Controls.Add(txtSource);
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(txtAlt);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(txtLink);
			groupBox1.Controls.Add(txtTitle);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(txtID);
			groupBox1.Controls.Add(label1);
			resources.ApplyResources(groupBox1, "groupBox1");
			groupBox1.Name = "groupBox1";
			groupBox1.TabStop = false;
			txtOffsetY.DecimalPlaces = 1;
			resources.ApplyResources(txtOffsetY, "txtOffsetY");
			txtOffsetY.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			txtOffsetY.Minimum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				-2147483648
			});
			txtOffsetY.Name = "txtOffsetY";
			resources.ApplyResources(label9, "label9");
			label9.Name = "label9";
			txtOffsetX.DecimalPlaces = 1;
			resources.ApplyResources(txtOffsetX, "txtOffsetX");
			txtOffsetX.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			txtOffsetX.Minimum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				-2147483648
			});
			txtOffsetX.Name = "txtOffsetX";
			resources.ApplyResources(label8, "label8");
			label8.Name = "label8";
			resources.ApplyResources(chkEnableRepeatedImage, "chkEnableRepeatedImage");
			chkEnableRepeatedImage.Name = "chkEnableRepeatedImage";
			chkEnableRepeatedImage.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkSmoothZoom, "chkSmoothZoom");
			chkSmoothZoom.Name = "chkSmoothZoom";
			chkSmoothZoom.UseVisualStyleBackColor = true;
			cboContentReadonly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboContentReadonly.FormattingEnabled = true;
			cboContentReadonly.Items.AddRange(new object[3]
			{
				resources.GetString("cboContentReadonly.Items"),
				resources.GetString("cboContentReadonly.Items1"),
				resources.GetString("cboContentReadonly.Items2")
			});
			resources.ApplyResources(cboContentReadonly, "cboContentReadonly");
			cboContentReadonly.Name = "cboContentReadonly";
			resources.ApplyResources(label21, "label21");
			label21.Name = "label21";
			cboZOrderStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboZOrderStyle.FormattingEnabled = true;
			cboZOrderStyle.Items.AddRange(new object[3]
			{
				resources.GetString("cboZOrderStyle.Items"),
				resources.GetString("cboZOrderStyle.Items1"),
				resources.GetString("cboZOrderStyle.Items2")
			});
			resources.ApplyResources(cboZOrderStyle, "cboZOrderStyle");
			cboZOrderStyle.Name = "cboZOrderStyle";
			cboZOrderStyle.SelectedIndexChanged += new System.EventHandler(cboZOrderStyle_SelectedIndexChanged);
			resources.ApplyResources(label7, "label7");
			label7.Name = "label7";
			cboVAngle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboVAngle.FormattingEnabled = true;
			cboVAngle.Items.AddRange(new object[3]
			{
				resources.GetString("cboVAngle.Items"),
				resources.GetString("cboVAngle.Items1"),
				resources.GetString("cboVAngle.Items2")
			});
			resources.ApplyResources(cboVAngle, "cboVAngle");
			cboVAngle.Name = "cboVAngle";
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
			resources.ApplyResources(btnBrowseLink, "btnBrowseLink");
			btnBrowseLink.Name = "btnBrowseLink";
			btnBrowseLink.UseVisualStyleBackColor = true;
			btnBrowseLink.Click += new System.EventHandler(btnBrowseLink_Click);
			resources.ApplyResources(btnBrowseSource, "btnBrowseSource");
			btnBrowseSource.Name = "btnBrowseSource";
			btnBrowseSource.UseVisualStyleBackColor = true;
			btnBrowseSource.Click += new System.EventHandler(btnBrowseSource_Click);
			resources.ApplyResources(chkAdditionShapeFixSize, "chkAdditionShapeFixSize");
			chkAdditionShapeFixSize.Name = "chkAdditionShapeFixSize";
			chkAdditionShapeFixSize.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkSaveContentInFile, "chkSaveContentInFile");
			chkSaveContentInFile.Name = "chkSaveContentInFile";
			chkSaveContentInFile.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkKeepWidthHeightRate, "chkKeepWidthHeightRate");
			chkKeepWidthHeightRate.Name = "chkKeepWidthHeightRate";
			chkKeepWidthHeightRate.UseVisualStyleBackColor = true;
			resources.ApplyResources(txtSource, "txtSource");
			txtSource.Name = "txtSource";
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			resources.ApplyResources(txtAlt, "txtAlt");
			txtAlt.Name = "txtAlt";
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			resources.ApplyResources(txtLink, "txtLink");
			txtLink.Name = "txtLink";
			txtLink.ReadOnly = true;
			resources.ApplyResources(txtTitle, "txtTitle");
			txtTitle.Name = "txtTitle";
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(txtID, "txtID");
			txtID.Name = "txtID";
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			groupBox2.Controls.Add(picImage);
			groupBox2.Controls.Add(toolStrip1);
			resources.ApplyResources(groupBox2, "groupBox2");
			groupBox2.Name = "groupBox2";
			groupBox2.TabStop = false;
			resources.ApplyResources(picImage, "picImage");
			picImage.BackColor = System.Drawing.SystemColors.AppWorkspace;
			picImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			picImage.Name = "picImage";
			picImage.TabStop = false;
			toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[6]
			{
				btnClear,
				btnLoad,
				btnSave,
				toolStripSeparator1,
				btnCopy,
				btnPaste
			});
			resources.ApplyResources(toolStrip1, "toolStrip1");
			toolStrip1.Name = "toolStrip1";
			resources.ApplyResources(btnClear, "btnClear");
			btnClear.Name = "btnClear";
			btnClear.Click += new System.EventHandler(btnClear_Click);
			resources.ApplyResources(btnLoad, "btnLoad");
			btnLoad.Name = "btnLoad";
			btnLoad.Click += new System.EventHandler(btnLoad_Click);
			resources.ApplyResources(btnSave, "btnSave");
			btnSave.Name = "btnSave";
			btnSave.Click += new System.EventHandler(btnSave_Click);
			toolStripSeparator1.Name = "toolStripSeparator1";
			resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
			resources.ApplyResources(btnCopy, "btnCopy");
			btnCopy.Name = "btnCopy";
			btnCopy.Click += new System.EventHandler(btnCopy_Click);
			resources.ApplyResources(btnPaste, "btnPaste");
			btnPaste.Name = "btnPaste";
			btnPaste.Click += new System.EventHandler(btnPaste_Click);
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(btnOK);
			resources.ApplyResources(panel1, "panel1");
			panel1.Name = "panel1";
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			elementEventTemplate1.Name = "elementEventTemplate1";
			resources.ApplyResources(label10, "label10");
			label10.Name = "label10";
			resources.ApplyResources(btnTransparentColor, "btnTransparentColor");
			btnTransparentColor.Name = "btnTransparentColor";
			btnTransparentColor.UseVisualStyleBackColor = true;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(groupBox2);
			base.Controls.Add(panel1);
			base.Controls.Add(groupBox1);
			base.MinimizeBox = false;
			base.Name = "dlgImageElementEditor";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgImageElementEditor_Load);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)txtOffsetY).EndInit();
			((System.ComponentModel.ISupportInitialize)txtOffsetX).EndInit();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			panel1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
