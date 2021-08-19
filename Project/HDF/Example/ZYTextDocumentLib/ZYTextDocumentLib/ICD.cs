using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ICD : Form
	{
		private Label label1;

		private Label label2;

		private Button button1;

		private Button button2;

		private Label label3;

		private Label label4;

		private DataGrid dataGrid1;

		private TextBox textBox1;

		public string kblist;

		private Label label5;

		private Label label6;

		private Container components = null;

		public ICD()
		{
			InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			dataGrid1 = new System.Windows.Forms.DataGrid();
			textBox1 = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)dataGrid1).BeginInit();
			SuspendLayout();
			label1.Location = new System.Drawing.Point(16, 32);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(128, 24);
			label1.TabIndex = 0;
			label1.Text = "当前节点对的ICD名称";
			label2.Location = new System.Drawing.Point(16, 112);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(72, 16);
			label2.TabIndex = 1;
			label2.Text = "ICD-10编码";
			button1.Location = new System.Drawing.Point(72, 136);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(56, 24);
			button1.TabIndex = 4;
			button1.Text = "保存";
			button1.Click += new System.EventHandler(button1_Click);
			button2.Location = new System.Drawing.Point(168, 136);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(56, 24);
			button2.TabIndex = 5;
			button2.Text = "取消";
			button2.Click += new System.EventHandler(button2_Click);
			label3.BackColor = System.Drawing.Color.Transparent;
			label3.Font = new System.Drawing.Font("宋体", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			label3.Location = new System.Drawing.Point(40, 56);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(232, 40);
			label3.TabIndex = 6;
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			label4.Location = new System.Drawing.Point(104, 112);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(144, 16);
			label4.TabIndex = 7;
			dataGrid1.AlternatingBackColor = System.Drawing.Color.GhostWhite;
			dataGrid1.BackColor = System.Drawing.Color.GhostWhite;
			dataGrid1.BackgroundColor = System.Drawing.Color.Lavender;
			dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGrid1.CaptionBackColor = System.Drawing.Color.RoyalBlue;
			dataGrid1.CaptionForeColor = System.Drawing.Color.White;
			dataGrid1.DataMember = "";
			dataGrid1.Dock = System.Windows.Forms.DockStyle.Bottom;
			dataGrid1.FlatMode = true;
			dataGrid1.Font = new System.Drawing.Font("Tahoma", 8f);
			dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
			dataGrid1.GridLineColor = System.Drawing.Color.RoyalBlue;
			dataGrid1.HeaderBackColor = System.Drawing.Color.MidnightBlue;
			dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8f, System.Drawing.FontStyle.Bold);
			dataGrid1.HeaderForeColor = System.Drawing.Color.Lavender;
			dataGrid1.LinkColor = System.Drawing.Color.Teal;
			dataGrid1.Location = new System.Drawing.Point(0, 205);
			dataGrid1.Name = "dataGrid1";
			dataGrid1.ParentRowsBackColor = System.Drawing.Color.Lavender;
			dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
			dataGrid1.PreferredColumnWidth = 175;
			dataGrid1.ReadOnly = true;
			dataGrid1.RowHeadersVisible = false;
			dataGrid1.RowHeaderWidth = 0;
			dataGrid1.SelectionBackColor = System.Drawing.Color.Teal;
			dataGrid1.SelectionForeColor = System.Drawing.Color.PaleGreen;
			dataGrid1.Size = new System.Drawing.Size(344, 208);
			dataGrid1.TabIndex = 9;
			dataGrid1.MouseDown += new System.Windows.Forms.MouseEventHandler(dataGrid1_MouseDown);
			textBox1.Location = new System.Drawing.Point(96, 176);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(192, 21);
			textBox1.TabIndex = 10;
			textBox1.Text = "";
			textBox1.TextChanged += new System.EventHandler(textBox1_TextChanged);
			label5.Location = new System.Drawing.Point(48, 8);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(184, 16);
			label5.TabIndex = 11;
			label5.Text = "知识点编号:";
			label6.Location = new System.Drawing.Point(8, 176);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(64, 24);
			label6.TabIndex = 12;
			label6.Text = "拼音代码";
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			base.ClientSize = new System.Drawing.Size(344, 413);
			base.Controls.Add(label6);
			base.Controls.Add(label5);
			base.Controls.Add(textBox1);
			base.Controls.Add(dataGrid1);
			base.Controls.Add(label4);
			base.Controls.Add(label3);
			base.Controls.Add(button2);
			base.Controls.Add(button1);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ICD";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "ICD";
			base.Load += new System.EventHandler(ICD_Load);
			((System.ComponentModel.ISupportInitialize)dataGrid1).EndInit();
			ResumeLayout(false);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			if (textBox1.Text.Trim().Length > 0)
			{
				string text = textBox1.Text;
				ZYDBConnection instance = ZYDBConnection.Instance;
				IDbCommand dbCommand = instance.CreateCommand();
				dbCommand.CommandText = "Select MC as '名称',BM as '编码',(case when len(zjm)>6 then substring(zjm,1,6) else zjm end) as '助记码' From sJBBMML Where LB='D' and (ZJM like '" + text + "%' or MC Like '%" + text + "%') order by ZJM";
				IDataReader dr = dbCommand.ExecuteReader();
				dataGrid1.DataSource = Convertdrtodt(dr);
			}
		}

		public DataTable Convertdrtodt(IDataReader dr)
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "jbbm";
			for (int i = 0; i < dr.FieldCount; i++)
			{
				DataColumn dataColumn = new DataColumn();
				dataColumn.ColumnName = dr.GetName(i);
				dataTable.Columns.Add(dataColumn);
			}
			while (dr.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				for (int i = 0; i < dr.FieldCount; i++)
				{
					dataRow[i] = dr[i].ToString();
				}
				dataTable.Rows.Add(dataRow);
				dataRow = null;
			}
			dr.Close();
			return dataTable;
		}

		private void dataGrid1_MouseDown(object sender, MouseEventArgs e)
		{
			DataGrid.HitTestInfo hitTestInfo = dataGrid1.HitTest(e.X, e.Y);
			if (hitTestInfo.Type == DataGrid.HitTestType.Cell)
			{
				string text = hitTestInfo.ToString();
				int rowIndex = int.Parse(text.Split(',')[1]);
				label3.Text = dataGrid1[rowIndex, 0].ToString();
				label4.Text = dataGrid1[rowIndex, 1].ToString();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (label4.Text != "")
			{
				ZYDBConnection instance = ZYDBConnection.Instance;
				IDbCommand dbCommand = instance.CreateCommand();
				dbCommand.CommandText = "update kb_list set icdbm='" + label4.Text + "' where kb_seq='" + kblist + "'";
				try
				{
					dbCommand.ExecuteNonQuery();
				}
				catch (Exception)
				{
					MessageBox.Show("保存失败");
				}
				finally
				{
					Close();
				}
			}
		}

		private void ICD_Load(object sender, EventArgs e)
		{
			label5.Text += kblist;
			ZYDBConnection instance = ZYDBConnection.Instance;
			IDbCommand dbCommand = instance.CreateCommand();
			dbCommand.CommandText = "Select top 1 MC ,BM  from kb_list,sJBBMML where icdbm=bm and kb_seq='" + kblist + "' and icdbm is not null  ";
			IDataReader dataReader = dbCommand.ExecuteReader();
			if (dataReader.Read())
			{
				label3.Text = dataReader[0].ToString();
				label4.Text = dataReader[1].ToString();
			}
			dataReader.Close();
		}
	}
}
