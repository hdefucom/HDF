using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;

namespace DCSoft.WinForms
{
	/// <summary>
	///       选择XML节点的对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgBrowseXmlNode : Form
	{
		private IContainer icontainer_0 = null;

		private ImageList imageList_0;

		private Button btnCancel;

		private TreeView tvwXML;

		private Button btnOK;

		private List<XmlNode> list_0 = new List<XmlNode>();

		private bool bool_0 = true;

		private bool bool_1 = true;

		private List<string> list_1 = null;

		private string string_0 = null;

		private XmlNode xmlNode_0 = null;

		/// <summary>
		///       根xml节点列表
		///       </summary>
		public List<XmlNode> RootXmlNodes
		{
			get
			{
				return list_0;
			}
			set
			{
				list_0 = value;
			}
		}

		/// <summary>
		///       是否显示复选框
		///       </summary>
		public bool ShowCheckBoxes
		{
			get
			{
				return tvwXML.CheckBoxes;
			}
			set
			{
				tvwXML.CheckBoxes = value;
			}
		}

		/// <summary>
		///       显示XML属性
		///       </summary>
		public bool IncludeXmlAttribute
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
		///       显示XML元素
		///       </summary>
		public bool IncludeXmlElement
		{
			get
			{
				return bool_1;
			}
			set
			{
				bool_1 = value;
			}
		}

		/// <summary>
		///       勾选的XMLPath路径
		///       </summary>
		public List<string> CheckedXMLPath => list_1;

		/// <summary>
		///       选择的XPath路径
		///       </summary>
		public string SelectedXPath => string_0;

		/// <summary>
		///       被选择的XML节点对象
		///       </summary>
		public XmlNode SelectedXmlNode => xmlNode_0;

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
			icontainer_0 = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.WinForms.dlgBrowseXmlNode));
			imageList_0 = new System.Windows.Forms.ImageList(icontainer_0);
			btnCancel = new System.Windows.Forms.Button();
			tvwXML = new System.Windows.Forms.TreeView();
			btnOK = new System.Windows.Forms.Button();
			SuspendLayout();
			imageList_0.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
			imageList_0.TransparentColor = System.Drawing.Color.Red;
			imageList_0.Images.SetKeyName(0, "CommandViewXMLSource.bmp");
			btnCancel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			btnCancel.Location = new System.Drawing.Point(410, 356);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(75, 23);
			btnCancel.TabIndex = 2;
			btnCancel.Text = "取消(&C)";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			tvwXML.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			tvwXML.ImageIndex = 0;
			tvwXML.ImageList = imageList_0;
			tvwXML.Location = new System.Drawing.Point(0, 0);
			tvwXML.Name = "tvwXML";
			tvwXML.SelectedImageIndex = 0;
			tvwXML.Size = new System.Drawing.Size(504, 348);
			tvwXML.TabIndex = 0;
			btnOK.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			btnOK.Location = new System.Drawing.Point(291, 356);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(75, 23);
			btnOK.TabIndex = 1;
			btnOK.Text = "确定(&O)";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(506, 391);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(tvwXML);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgBrowseXmlNode";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "选择XML节点";
			base.Load += new System.EventHandler(dlgBrowseXmlNode_Load);
			ResumeLayout(false);
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgBrowseXmlNode()
		{
			InitializeComponent();
			tvwXML.PathSeparator = "/";
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgBrowseXmlNode_Load(object sender, EventArgs e)
		{
			foreach (XmlNode rootXmlNode in RootXmlNodes)
			{
				WinFormXMLHelper.AddXMLDomTreeNode(tvwXML.Nodes, rootXmlNode, IncludeXmlAttribute, IncludeXmlElement);
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (tvwXML.CheckBoxes)
			{
				list_1 = new List<string>();
				List<TreeNode> checkedNodes = WinFormUtils.GetCheckedNodes(tvwXML);
				foreach (TreeNode item in checkedNodes)
				{
					list_1.Add(item.FullPath);
				}
			}
			if (tvwXML.SelectedNode != null)
			{
				xmlNode_0 = (XmlNode)tvwXML.SelectedNode.Tag;
				string_0 = tvwXML.SelectedNode.FullPath;
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
