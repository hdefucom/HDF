using DCSoft.Writer.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	[ComVisible(false)]
	public class frmGenerateCreateInstanceCode : Form
	{
		private IContainer icontainer_0 = null;

		private CheckedListBox lstTypes;

		private Button btnGenerate;

		private Button btnClose;

		private TextBox txtSource;

		private List<string> list_0 = new List<string>();

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
			lstTypes = new System.Windows.Forms.CheckedListBox();
			btnGenerate = new System.Windows.Forms.Button();
			btnClose = new System.Windows.Forms.Button();
			txtSource = new System.Windows.Forms.TextBox();
			SuspendLayout();
			lstTypes.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			lstTypes.FormattingEnabled = true;
			lstTypes.Location = new System.Drawing.Point(0, 0);
			lstTypes.Name = "lstTypes";
			lstTypes.Size = new System.Drawing.Size(478, 260);
			lstTypes.TabIndex = 1;
			btnGenerate.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			btnGenerate.Location = new System.Drawing.Point(101, 271);
			btnGenerate.Name = "btnGenerate";
			btnGenerate.Size = new System.Drawing.Size(75, 23);
			btnGenerate.TabIndex = 2;
			btnGenerate.Text = "创建代码";
			btnGenerate.UseVisualStyleBackColor = true;
			btnGenerate.Click += new System.EventHandler(btnGenerate_Click);
			btnClose.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			btnClose.Location = new System.Drawing.Point(320, 271);
			btnClose.Name = "btnClose";
			btnClose.Size = new System.Drawing.Size(75, 23);
			btnClose.TabIndex = 3;
			btnClose.Text = "关闭";
			btnClose.UseVisualStyleBackColor = true;
			btnClose.Click += new System.EventHandler(btnClose_Click);
			txtSource.Dock = System.Windows.Forms.DockStyle.Bottom;
			txtSource.Location = new System.Drawing.Point(0, 300);
			txtSource.Multiline = true;
			txtSource.Name = "txtSource";
			txtSource.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			txtSource.Size = new System.Drawing.Size(478, 126);
			txtSource.TabIndex = 4;
			txtSource.WordWrap = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(478, 426);
			base.Controls.Add(txtSource);
			base.Controls.Add(btnClose);
			base.Controls.Add(btnGenerate);
			base.Controls.Add(lstTypes);
			base.MinimizeBox = false;
			base.Name = "frmGenerateCreateInstanceCode";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "创建对象实例代码";
			base.Load += new System.EventHandler(frmGenerateCreateInstanceCode_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		public frmGenerateCreateInstanceCode()
		{
			InitializeComponent();
		}

		private void frmGenerateCreateInstanceCode_Load(object sender, EventArgs e)
		{
			int num = 1;
			Type typeFromHandle = typeof(InstanceFactoryForCOM);
			List<string> list = new List<string>();
			MethodInfo[] methods = typeFromHandle.GetMethods();
			foreach (MethodInfo methodInfo in methods)
			{
				if (methodInfo.DeclaringType == typeFromHandle)
				{
					string fullName = methodInfo.ReturnType.FullName;
					if (!list.Contains(fullName))
					{
						list.Add(fullName);
					}
				}
			}
			List<string> list2 = new List<string>();
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (Assembly assembly in assemblies)
			{
				Type[] types = assembly.GetTypes();
				foreach (Type type in types)
				{
					if (!type.IsClass || type.IsSubclassOf(typeof(Control)) || !type.IsPublic || type.IsAbstract || type.IsNested || type.IsSubclassOf(typeof(Delegate)) || !(((ComVisibleAttribute)Attribute.GetCustomAttribute(type, typeof(ComVisibleAttribute), inherit: true))?.Value ?? false))
					{
						continue;
					}
					string fullName = type.FullName;
					if (fullName.StartsWith("DCSoft."))
					{
						if (type.GetConstructor(Type.EmptyTypes) == null)
						{
							list_0.Add(type.FullName);
						}
						list2.Add(fullName);
					}
				}
			}
			list2.Sort();
			foreach (string item in list2)
			{
				int index = lstTypes.Items.Add(item);
				if (list.Contains(item))
				{
					lstTypes.SetItemChecked(index, value: true);
				}
			}
		}

		private void btnGenerate_Click(object sender, EventArgs e)
		{
			int num = 19;
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = new StringBuilder();
			stringBuilder.AppendLine("#region 创建对象实例");
			stringBuilder2.AppendLine("#region 类型转换");
			foreach (string checkedItem in lstTypes.CheckedItems)
			{
				string text2 = checkedItem;
				int num2 = checkedItem.LastIndexOf('.');
				if (num2 > 0)
				{
					text2 = checkedItem.Substring(num2 + 1);
				}
				if (!list_0.Contains(checkedItem))
				{
					stringBuilder.AppendLine("public " + checkedItem + " Create" + text2 + "()");
					stringBuilder.AppendLine("{");
					stringBuilder.AppendLine("    return new " + checkedItem + "( );");
					stringBuilder.AppendLine("}");
					stringBuilder.AppendLine();
				}
				stringBuilder2.AppendLine("public " + checkedItem + " ConvertTo" + text2 + "( object sourceValue )");
				stringBuilder2.AppendLine("{");
				stringBuilder2.AppendLine("    return sourceValue as " + checkedItem + " ;");
				stringBuilder2.AppendLine("}");
				stringBuilder2.AppendLine();
			}
			stringBuilder.AppendLine("#endregion");
			stringBuilder2.AppendLine("#endregion");
			txtSource.Text = stringBuilder.ToString() + Environment.NewLine + stringBuilder2.ToString();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
