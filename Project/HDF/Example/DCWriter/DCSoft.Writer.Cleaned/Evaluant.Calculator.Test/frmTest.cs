using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Evaluant.Calculator.Test
{
	[ComVisible(false)]
	public class frmTest : Form
	{
		private IContainer icontainer_0 = null;

		private TextBox txtExpression;

		private Button btnExecute;

		private TextBox txtResult;

		private Button btnExpressionItem;

		protected override void Dispose(bool disposing)
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			txtExpression = new System.Windows.Forms.TextBox();
			btnExecute = new System.Windows.Forms.Button();
			txtResult = new System.Windows.Forms.TextBox();
			btnExpressionItem = new System.Windows.Forms.Button();
			SuspendLayout();
			txtExpression.Location = new System.Drawing.Point(12, 29);
			txtExpression.Name = "txtExpression";
			txtExpression.Size = new System.Drawing.Size(600, 21);
			txtExpression.TabIndex = 0;
			btnExecute.Location = new System.Drawing.Point(12, 56);
			btnExecute.Name = "btnExecute";
			btnExecute.Size = new System.Drawing.Size(75, 23);
			btnExecute.TabIndex = 1;
			btnExecute.Text = "执行";
			btnExecute.UseVisualStyleBackColor = true;
			btnExecute.Click += new System.EventHandler(btnExecute_Click);
			txtResult.Location = new System.Drawing.Point(12, 85);
			txtResult.Name = "txtResult";
			txtResult.Size = new System.Drawing.Size(600, 21);
			txtResult.TabIndex = 2;
			btnExpressionItem.Location = new System.Drawing.Point(12, 124);
			btnExpressionItem.Name = "btnExpressionItem";
			btnExpressionItem.Size = new System.Drawing.Size(75, 23);
			btnExpressionItem.TabIndex = 4;
			btnExpressionItem.Text = "表达式成员";
			btnExpressionItem.UseVisualStyleBackColor = true;
			btnExpressionItem.Click += new System.EventHandler(btnExpressionItem_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(624, 320);
			base.Controls.Add(btnExpressionItem);
			base.Controls.Add(btnExecute);
			base.Controls.Add(txtResult);
			base.Controls.Add(txtExpression);
			base.Name = "frmTest";
			Text = "frmTest";
			ResumeLayout(false);
			PerformLayout();
		}

		public frmTest()
		{
			InitializeComponent();
		}

		private void btnExecute_Click(object sender, EventArgs e)
		{
			int num = 0;
			try
			{
				GClass53 gClass = new GClass53(txtExpression.Text);
				gClass.method_9()["aaa"] = Environment.TickCount;
				gClass.method_9()["bbb"] = DateTime.Now.Second;
				gClass.method_9()["ccc"] = new float[4]
				{
					1f,
					4f,
					6f,
					9f
				};
				txtResult.Text = Convert.ToString(gClass.vmethod_1());
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void btnExpressionItem_Click(object sender, EventArgs e)
		{
			GClass53 gClass = new GClass53(txtExpression.Text);
			List<GClass55> list = gClass.method_1();
			StringBuilder stringBuilder = new StringBuilder();
			foreach (GClass55 item in list)
			{
				stringBuilder.AppendLine(item.ToString());
			}
			MessageBox.Show(stringBuilder.ToString());
		}
	}
}
