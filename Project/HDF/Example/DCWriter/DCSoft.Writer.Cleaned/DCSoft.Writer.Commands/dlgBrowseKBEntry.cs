using DCSoft.Writer.Data;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       浏览知识库节点的对话框
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class dlgBrowseKBEntry : Form
	{
		private KBLibrary kblibrary_0 = null;

		private string string_0 = null;

		private KBEntry kbentry_0 = null;

		private bool bool_0 = true;

		private GClass306 gclass306_0 = null;

		private IContainer icontainer_0 = null;

		private TreeView tvwKB;

		private Button btnOK;

		private Button btnCancel;

		private TextBox txtSearch;

		private Button btnSearch;

		[CompilerGenerated]
		private static GDelegate17 gdelegate17_0;

		/// <summary>
		///       知识库对象
		///       </summary>
		public KBLibrary KBLibrary
		{
			get
			{
				return kblibrary_0;
			}
			set
			{
				kblibrary_0 = value;
			}
		}

		/// <summary>
		///       当前知识库节点编号
		///       </summary>
		public string SelectedKBID
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
		///       被选择的知识节点对象
		///       </summary>
		public KBEntry SelectedKBEntry
		{
			get
			{
				return kbentry_0;
			}
			set
			{
				kbentry_0 = value;
			}
		}

		/// <summary>
		///       只选择叶子节点
		///       </summary>
		public bool SelectLeafNodeOnly
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
		///       初始化对象
		///       </summary>
		public dlgBrowseKBEntry()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgBrowseKBEntry_Load(object sender, EventArgs e)
		{
			if (KBLibrary != null)
			{
				KBLibrary.Fill(tvwKB);
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (tvwKB.SelectedNode != null && (!SelectLeafNodeOnly || tvwKB.SelectedNode.Nodes.Count == 0))
			{
				KBEntry kBEntry = (KBEntry)tvwKB.SelectedNode.Tag;
				SelectedKBID = kBEntry.ID;
				SelectedKBEntry = kBEntry;
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			if (gclass306_0 == null)
			{
				gclass306_0 = new GClass306(tvwKB);
				gclass306_0.gdelegate17_0 = delegate(object sender, GEventArgs10 e)
				{
					KBEntry kBEntry = (KBEntry)e.method_2().Tag;
					string text = (string)e.method_6();
					if (e.method_4() == 0)
					{
						e.method_9(text == kBEntry.ID);
					}
					else if (e.method_4() == 1)
					{
						e.method_9(kBEntry.Text == text);
					}
					else if (kBEntry.Text != null)
					{
						e.method_9(kBEntry.Text.IndexOf(text) >= 0);
					}
				};
			}
			TreeNode treeNode = null;
			if (string.Compare((string)gclass306_0.method_2(), txtSearch.Text.Trim()) == 0)
			{
				treeNode = gclass306_0.method_6();
			}
			else
			{
				gclass306_0.method_3(txtSearch.Text.Trim());
				gclass306_0.method_9(0);
				treeNode = gclass306_0.method_5(txtSearch.Text.Trim());
			}
			if (treeNode != null)
			{
				tvwKB.SelectedNode = treeNode;
				treeNode.EnsureVisible();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgBrowseKBEntry));
			tvwKB = new System.Windows.Forms.TreeView();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			txtSearch = new System.Windows.Forms.TextBox();
			btnSearch = new System.Windows.Forms.Button();
			SuspendLayout();
			tvwKB.HideSelection = false;
			resources.ApplyResources(tvwKB, "tvwKB");
			tvwKB.Name = "tvwKB";
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			resources.ApplyResources(txtSearch, "txtSearch");
			txtSearch.Name = "txtSearch";
			resources.ApplyResources(btnSearch, "btnSearch");
			btnSearch.Name = "btnSearch";
			btnSearch.UseVisualStyleBackColor = true;
			btnSearch.Click += new System.EventHandler(btnSearch_Click);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(txtSearch);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnSearch);
			base.Controls.Add(btnOK);
			base.Controls.Add(tvwKB);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgBrowseKBEntry";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgBrowseKBEntry_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		[CompilerGenerated]
		private static void smethod_0(object sender, GEventArgs10 e)
		{
			KBEntry kBEntry = (KBEntry)e.method_2().Tag;
			string text = (string)e.method_6();
			if (e.method_4() == 0)
			{
				e.method_9(text == kBEntry.ID);
			}
			else if (e.method_4() == 1)
			{
				e.method_9(kBEntry.Text == text);
			}
			else if (kBEntry.Text != null)
			{
				e.method_9(kBEntry.Text.IndexOf(text) >= 0);
			}
		}
	}
}
