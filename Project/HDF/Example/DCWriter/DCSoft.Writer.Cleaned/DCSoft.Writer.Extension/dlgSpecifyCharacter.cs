using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Extension
{
	/// <summary>
	///       特殊字符
	///       </summary>
	[ComVisible(false)]
	public class dlgSpecifyCharacter : Form
	{
		private IContainer icontainer_0 = null;

		private ListBox lstSpecifyCharacter;

		private Button btnOK;

		private Button btnCancel;

		private string string_0 = null;

		/// <summary>
		///       指定的特殊字符
		///       </summary>
		public string SpecifyCharacter
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Extension.dlgSpecifyCharacter));
			lstSpecifyCharacter = new System.Windows.Forms.ListBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			resources.ApplyResources(lstSpecifyCharacter, "lstSpecifyCharacter");
			lstSpecifyCharacter.FormattingEnabled = true;
			lstSpecifyCharacter.Items.AddRange(new object[53]
			{
				resources.GetString("lstSpecifyCharacter.Items"),
				resources.GetString("lstSpecifyCharacter.Items1"),
				resources.GetString("lstSpecifyCharacter.Items2"),
				resources.GetString("lstSpecifyCharacter.Items3"),
				resources.GetString("lstSpecifyCharacter.Items4"),
				resources.GetString("lstSpecifyCharacter.Items5"),
				resources.GetString("lstSpecifyCharacter.Items6"),
				resources.GetString("lstSpecifyCharacter.Items7"),
				resources.GetString("lstSpecifyCharacter.Items8"),
				resources.GetString("lstSpecifyCharacter.Items9"),
				resources.GetString("lstSpecifyCharacter.Items10"),
				resources.GetString("lstSpecifyCharacter.Items11"),
				resources.GetString("lstSpecifyCharacter.Items12"),
				resources.GetString("lstSpecifyCharacter.Items13"),
				resources.GetString("lstSpecifyCharacter.Items14"),
				resources.GetString("lstSpecifyCharacter.Items15"),
				resources.GetString("lstSpecifyCharacter.Items16"),
				resources.GetString("lstSpecifyCharacter.Items17"),
				resources.GetString("lstSpecifyCharacter.Items18"),
				resources.GetString("lstSpecifyCharacter.Items19"),
				resources.GetString("lstSpecifyCharacter.Items20"),
				resources.GetString("lstSpecifyCharacter.Items21"),
				resources.GetString("lstSpecifyCharacter.Items22"),
				resources.GetString("lstSpecifyCharacter.Items23"),
				resources.GetString("lstSpecifyCharacter.Items24"),
				resources.GetString("lstSpecifyCharacter.Items25"),
				resources.GetString("lstSpecifyCharacter.Items26"),
				resources.GetString("lstSpecifyCharacter.Items27"),
				resources.GetString("lstSpecifyCharacter.Items28"),
				resources.GetString("lstSpecifyCharacter.Items29"),
				resources.GetString("lstSpecifyCharacter.Items30"),
				resources.GetString("lstSpecifyCharacter.Items31"),
				resources.GetString("lstSpecifyCharacter.Items32"),
				resources.GetString("lstSpecifyCharacter.Items33"),
				resources.GetString("lstSpecifyCharacter.Items34"),
				resources.GetString("lstSpecifyCharacter.Items35"),
				resources.GetString("lstSpecifyCharacter.Items36"),
				resources.GetString("lstSpecifyCharacter.Items37"),
				resources.GetString("lstSpecifyCharacter.Items38"),
				resources.GetString("lstSpecifyCharacter.Items39"),
				resources.GetString("lstSpecifyCharacter.Items40"),
				resources.GetString("lstSpecifyCharacter.Items41"),
				resources.GetString("lstSpecifyCharacter.Items42"),
				resources.GetString("lstSpecifyCharacter.Items43"),
				resources.GetString("lstSpecifyCharacter.Items44"),
				resources.GetString("lstSpecifyCharacter.Items45"),
				resources.GetString("lstSpecifyCharacter.Items46"),
				resources.GetString("lstSpecifyCharacter.Items47"),
				resources.GetString("lstSpecifyCharacter.Items48"),
				resources.GetString("lstSpecifyCharacter.Items49"),
				resources.GetString("lstSpecifyCharacter.Items50"),
				resources.GetString("lstSpecifyCharacter.Items51"),
				resources.GetString("lstSpecifyCharacter.Items52")
			});
			lstSpecifyCharacter.MultiColumn = true;
			lstSpecifyCharacter.Name = "lstSpecifyCharacter";
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
			base.Controls.Add(lstSpecifyCharacter);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgSpecifyCharacter";
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgSpecifyCharacter_Load);
			ResumeLayout(false);
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgSpecifyCharacter()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgSpecifyCharacter_Load(object sender, EventArgs e)
		{
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			string_0 = lstSpecifyCharacter.Text;
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
