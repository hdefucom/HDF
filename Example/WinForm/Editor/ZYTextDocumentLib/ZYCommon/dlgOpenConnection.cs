using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ZYCommon
{
	public class dlgOpenConnection : Form
	{
		private Button cmdOK;

		private Button cmdCancel;

		private Label label1;

		private TextBox txtSQLServer;

		private Label sqlusername;

		private TextBox txtSQLUser;

		private TextBox txtSQLPwd;

		private Label label2;

		private Label label3;

		private TextBox txtSQLDB;

		private Label label4;

		private TextBox txtOracleServer;

		private Label label5;

		private TextBox txtOracleUser;

		private TextBox txtOraclePwd;

		private Label label6;

		private Label label7;

		private TextBox txtAccessFile;

		private Label label8;

		private TextBox txtAccessName;

		private TextBox txtAccessPwd;

		private Label label9;

		private Button cmdBrowse;

		private TextBox txtHTTPUrl;

		private Label label10;

		private TabPage tabMSSQLServer;

		private TabPage tabOracle;

		private TabPage tabAccess;

		private TabPage tabHTTP;

		private TabControl myTab;

		private Label label11;

		private ComboBox cboHistory;

		private TabPage tabOLEDB;

		private Label label12;

		private TextBox txtOLEDB;

		private Container components = null;

		public bool AutoCreateConnection = false;

		public string ConnectionString = null;

		public IDbConnection CreatedConnection = null;

		private ArrayList myHistoryList = new ArrayList();

		public dlgOpenConnection()
		{
			base.DialogResult = DialogResult.Cancel;
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
			myTab = new System.Windows.Forms.TabControl();
			tabMSSQLServer = new System.Windows.Forms.TabPage();
			label3 = new System.Windows.Forms.Label();
			sqlusername = new System.Windows.Forms.Label();
			txtSQLServer = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			txtSQLUser = new System.Windows.Forms.TextBox();
			txtSQLPwd = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			txtSQLDB = new System.Windows.Forms.TextBox();
			tabOracle = new System.Windows.Forms.TabPage();
			label4 = new System.Windows.Forms.Label();
			txtOracleServer = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			txtOracleUser = new System.Windows.Forms.TextBox();
			txtOraclePwd = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			tabAccess = new System.Windows.Forms.TabPage();
			cmdBrowse = new System.Windows.Forms.Button();
			label7 = new System.Windows.Forms.Label();
			txtAccessFile = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			txtAccessName = new System.Windows.Forms.TextBox();
			txtAccessPwd = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			tabHTTP = new System.Windows.Forms.TabPage();
			txtHTTPUrl = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			cmdOK = new System.Windows.Forms.Button();
			cmdCancel = new System.Windows.Forms.Button();
			label11 = new System.Windows.Forms.Label();
			cboHistory = new System.Windows.Forms.ComboBox();
			tabOLEDB = new System.Windows.Forms.TabPage();
			label12 = new System.Windows.Forms.Label();
			txtOLEDB = new System.Windows.Forms.TextBox();
			myTab.SuspendLayout();
			tabMSSQLServer.SuspendLayout();
			tabOracle.SuspendLayout();
			tabAccess.SuspendLayout();
			tabHTTP.SuspendLayout();
			tabOLEDB.SuspendLayout();
			SuspendLayout();
			myTab.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			myTab.Controls.Add(tabMSSQLServer);
			myTab.Controls.Add(tabOracle);
			myTab.Controls.Add(tabAccess);
			myTab.Controls.Add(tabHTTP);
			myTab.Controls.Add(tabOLEDB);
			myTab.Location = new System.Drawing.Point(0, 0);
			myTab.Name = "myTab";
			myTab.SelectedIndex = 0;
			myTab.Size = new System.Drawing.Size(416, 264);
			myTab.TabIndex = 0;
			myTab.SelectedIndexChanged += new System.EventHandler(myTab_SelectedIndexChanged);
			tabMSSQLServer.Controls.Add(label3);
			tabMSSQLServer.Controls.Add(sqlusername);
			tabMSSQLServer.Controls.Add(txtSQLServer);
			tabMSSQLServer.Controls.Add(label1);
			tabMSSQLServer.Controls.Add(txtSQLUser);
			tabMSSQLServer.Controls.Add(txtSQLPwd);
			tabMSSQLServer.Controls.Add(label2);
			tabMSSQLServer.Controls.Add(txtSQLDB);
			tabMSSQLServer.Location = new System.Drawing.Point(4, 21);
			tabMSSQLServer.Name = "tabMSSQLServer";
			tabMSSQLServer.Size = new System.Drawing.Size(408, 239);
			tabMSSQLServer.TabIndex = 0;
			tabMSSQLServer.Text = "MS SQL Server";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(40, 128);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(48, 17);
			label3.TabIndex = 3;
			label3.Text = "数据库:";
			sqlusername.AutoSize = true;
			sqlusername.Location = new System.Drawing.Point(40, 64);
			sqlusername.Name = "sqlusername";
			sqlusername.Size = new System.Drawing.Size(48, 17);
			sqlusername.TabIndex = 2;
			sqlusername.Text = "用户名:";
			txtSQLServer.Location = new System.Drawing.Point(104, 32);
			txtSQLServer.Name = "txtSQLServer";
			txtSQLServer.Size = new System.Drawing.Size(232, 21);
			txtSQLServer.TabIndex = 1;
			txtSQLServer.Text = "";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(40, 40);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(48, 17);
			label1.TabIndex = 0;
			label1.Text = "服务器:";
			txtSQLUser.Location = new System.Drawing.Point(104, 64);
			txtSQLUser.Name = "txtSQLUser";
			txtSQLUser.Size = new System.Drawing.Size(232, 21);
			txtSQLUser.TabIndex = 2;
			txtSQLUser.Text = "";
			txtSQLPwd.Location = new System.Drawing.Point(104, 96);
			txtSQLPwd.Name = "txtSQLPwd";
			txtSQLPwd.PasswordChar = '*';
			txtSQLPwd.Size = new System.Drawing.Size(232, 21);
			txtSQLPwd.TabIndex = 3;
			txtSQLPwd.Text = "";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(40, 96);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(35, 17);
			label2.TabIndex = 2;
			label2.Text = "密码:";
			txtSQLDB.Location = new System.Drawing.Point(104, 128);
			txtSQLDB.Name = "txtSQLDB";
			txtSQLDB.Size = new System.Drawing.Size(232, 21);
			txtSQLDB.TabIndex = 4;
			txtSQLDB.Text = "";
			tabOracle.Controls.Add(label4);
			tabOracle.Controls.Add(txtOracleServer);
			tabOracle.Controls.Add(label5);
			tabOracle.Controls.Add(txtOracleUser);
			tabOracle.Controls.Add(txtOraclePwd);
			tabOracle.Controls.Add(label6);
			tabOracle.Location = new System.Drawing.Point(4, 21);
			tabOracle.Name = "tabOracle";
			tabOracle.Size = new System.Drawing.Size(408, 239);
			tabOracle.TabIndex = 1;
			tabOracle.Text = "Oracle";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(40, 64);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(48, 17);
			label4.TabIndex = 8;
			label4.Text = "用户名:";
			txtOracleServer.Location = new System.Drawing.Point(104, 32);
			txtOracleServer.Name = "txtOracleServer";
			txtOracleServer.Size = new System.Drawing.Size(232, 21);
			txtOracleServer.TabIndex = 5;
			txtOracleServer.Text = "";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(40, 40);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(48, 17);
			label5.TabIndex = 3;
			label5.Text = "服务器:";
			txtOracleUser.Location = new System.Drawing.Point(104, 64);
			txtOracleUser.Name = "txtOracleUser";
			txtOracleUser.Size = new System.Drawing.Size(232, 21);
			txtOracleUser.TabIndex = 6;
			txtOracleUser.Text = "";
			txtOraclePwd.Location = new System.Drawing.Point(104, 96);
			txtOraclePwd.Name = "txtOraclePwd";
			txtOraclePwd.PasswordChar = '*';
			txtOraclePwd.Size = new System.Drawing.Size(232, 21);
			txtOraclePwd.TabIndex = 7;
			txtOraclePwd.Text = "";
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(40, 96);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(35, 17);
			label6.TabIndex = 7;
			label6.Text = "密码:";
			tabAccess.Controls.Add(cmdBrowse);
			tabAccess.Controls.Add(label7);
			tabAccess.Controls.Add(txtAccessFile);
			tabAccess.Controls.Add(label8);
			tabAccess.Controls.Add(txtAccessName);
			tabAccess.Controls.Add(txtAccessPwd);
			tabAccess.Controls.Add(label9);
			tabAccess.Location = new System.Drawing.Point(4, 21);
			tabAccess.Name = "tabAccess";
			tabAccess.Size = new System.Drawing.Size(408, 239);
			tabAccess.TabIndex = 2;
			tabAccess.Text = "MS Access2000";
			cmdBrowse.Location = new System.Drawing.Point(336, 32);
			cmdBrowse.Name = "cmdBrowse";
			cmdBrowse.Size = new System.Drawing.Size(64, 23);
			cmdBrowse.TabIndex = 9;
			cmdBrowse.Text = "浏览(&B)...";
			cmdBrowse.Click += new System.EventHandler(cmdBrowse_Click);
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(40, 64);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(48, 17);
			label7.TabIndex = 14;
			label7.Text = "用户名:";
			txtAccessFile.Location = new System.Drawing.Point(104, 32);
			txtAccessFile.Name = "txtAccessFile";
			txtAccessFile.Size = new System.Drawing.Size(232, 21);
			txtAccessFile.TabIndex = 8;
			txtAccessFile.Text = "";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(40, 40);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(48, 17);
			label8.TabIndex = 9;
			label8.Text = "文件名:";
			txtAccessName.Location = new System.Drawing.Point(104, 64);
			txtAccessName.Name = "txtAccessName";
			txtAccessName.Size = new System.Drawing.Size(232, 21);
			txtAccessName.TabIndex = 10;
			txtAccessName.Text = "";
			txtAccessPwd.Location = new System.Drawing.Point(104, 96);
			txtAccessPwd.Name = "txtAccessPwd";
			txtAccessPwd.PasswordChar = '*';
			txtAccessPwd.Size = new System.Drawing.Size(232, 21);
			txtAccessPwd.TabIndex = 11;
			txtAccessPwd.Text = "";
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(40, 96);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(35, 17);
			label9.TabIndex = 13;
			label9.Text = "密码:";
			tabHTTP.Controls.Add(txtHTTPUrl);
			tabHTTP.Controls.Add(label10);
			tabHTTP.Location = new System.Drawing.Point(4, 21);
			tabHTTP.Name = "tabHTTP";
			tabHTTP.Size = new System.Drawing.Size(408, 239);
			tabHTTP.TabIndex = 3;
			tabHTTP.Text = "HTTPDB";
			txtHTTPUrl.Location = new System.Drawing.Point(104, 32);
			txtHTTPUrl.Name = "txtHTTPUrl";
			txtHTTPUrl.Size = new System.Drawing.Size(232, 21);
			txtHTTPUrl.TabIndex = 12;
			txtHTTPUrl.Text = "http://";
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(40, 40);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(48, 17);
			label10.TabIndex = 13;
			label10.Text = "服务器:";
			cmdOK.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			cmdOK.Location = new System.Drawing.Point(232, 272);
			cmdOK.Name = "cmdOK";
			cmdOK.TabIndex = 13;
			cmdOK.Text = "确定(&O)";
			cmdOK.Click += new System.EventHandler(cmdOK_Click);
			cmdCancel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cmdCancel.Location = new System.Drawing.Point(320, 272);
			cmdCancel.Name = "cmdCancel";
			cmdCancel.TabIndex = 14;
			cmdCancel.Text = "取消(&C)";
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(6, 275);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(60, 17);
			label11.TabIndex = 15;
			label11.Text = "历史记录:";
			cboHistory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboHistory.Location = new System.Drawing.Point(66, 273);
			cboHistory.MaxDropDownItems = 10;
			cboHistory.Name = "cboHistory";
			cboHistory.Size = new System.Drawing.Size(152, 20);
			cboHistory.TabIndex = 16;
			cboHistory.SelectedIndexChanged += new System.EventHandler(cboHistory_SelectedIndexChanged);
			tabOLEDB.Controls.Add(txtOLEDB);
			tabOLEDB.Controls.Add(label12);
			tabOLEDB.Location = new System.Drawing.Point(4, 21);
			tabOLEDB.Name = "tabOLEDB";
			tabOLEDB.Size = new System.Drawing.Size(408, 239);
			tabOLEDB.TabIndex = 4;
			tabOLEDB.Text = "OLEDB数据库";
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(16, 16);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(140, 17);
			label12.TabIndex = 0;
			label12.Text = "OLEDB数据库连接字符串:";
			txtOLEDB.Location = new System.Drawing.Point(16, 40);
			txtOLEDB.Multiline = true;
			txtOLEDB.Name = "txtOLEDB";
			txtOLEDB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			txtOLEDB.Size = new System.Drawing.Size(368, 176);
			txtOLEDB.TabIndex = 1;
			txtOLEDB.Text = "";
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			base.CancelButton = cmdCancel;
			base.ClientSize = new System.Drawing.Size(418, 303);
			base.Controls.Add(cboHistory);
			base.Controls.Add(label11);
			base.Controls.Add(cmdCancel);
			base.Controls.Add(cmdOK);
			base.Controls.Add(myTab);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgOpenConnection";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "打开数据库连接";
			base.Load += new System.EventHandler(dlgOpenConnection_Load);
			myTab.ResumeLayout(false);
			tabMSSQLServer.ResumeLayout(false);
			tabOracle.ResumeLayout(false);
			tabAccess.ResumeLayout(false);
			tabHTTP.ResumeLayout(false);
			tabOLEDB.ResumeLayout(false);
			ResumeLayout(false);
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			if (myTab.SelectedTab == tabMSSQLServer)
			{
				ConnectionString = "Provider=SQLOLEDB.1;Password=" + txtSQLPwd.Text + ";Persist Security Info=True;User ID=" + txtSQLUser.Text + ";Initial Catalog=" + txtSQLDB.Text + ";Data Source=" + txtSQLServer.Text;
				if (AutoCreateConnection)
				{
					CreatedConnection = new OleDbConnection(ConnectionString);
				}
			}
			if (myTab.SelectedTab == tabOracle)
			{
				ConnectionString = "Provider=OraOLEDB.Oracle.1;Password=" + txtOraclePwd.Text + ";Persist Security Info=True;User ID=" + txtOracleUser.Text + ";Data Source=" + txtOracleServer.Text + ";Extended Properties=\"\"";
				if (AutoCreateConnection)
				{
					CreatedConnection = new OleDbConnection(ConnectionString);
				}
			}
			if (myTab.SelectedTab == tabHTTP)
			{
				ConnectionString = txtHTTPUrl.Text;
				if (AutoCreateConnection)
				{
					CreatedConnection = new XMLHttpConnection(ConnectionString);
				}
			}
			if (myTab.SelectedTab == tabAccess)
			{
				ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + txtAccessFile.Text + ";Persist Security Info=False";
				if (AutoCreateConnection)
				{
					CreatedConnection = new OleDbConnection(ConnectionString);
				}
			}
			if (myTab.SelectedTab == tabOLEDB)
			{
				ConnectionString = txtOLEDB.Text;
				if (AutoCreateConnection)
				{
					CreatedConnection = new OleDbConnection(ConnectionString);
				}
			}
			try
			{
				for (int num = myHistoryList.Count - 1; num >= 0; num--)
				{
					if (ConnectionString.Equals(myHistoryList[num]))
					{
						myHistoryList.RemoveAt(num);
					}
				}
				myHistoryList.Insert(0, ConnectionString);
				string path = Application.StartupPath + "\\connhis.txt";
				if (File.Exists(path))
				{
					File.Delete(path);
				}
				StreamWriter streamWriter = new StreamWriter(path);
				for (int num = 0; num < myHistoryList.Count && num < 30; num++)
				{
					streamWriter.WriteLine(StringCommon.ToBase64String((string)myHistoryList[num]));
				}
				streamWriter.Close();
			}
			catch
			{
			}
			Close();
			base.DialogResult = DialogResult.OK;
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void cmdBrowse_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.CheckFileExists = true;
				openFileDialog.ShowReadOnly = false;
				if (txtAccessFile.Text.Trim().Length > 0)
				{
					openFileDialog.FileName = txtAccessFile.Text;
				}
				openFileDialog.Filter = "MDB数据库文件|*.mdb";
				if (openFileDialog.ShowDialog(this) == DialogResult.OK)
				{
					txtAccessFile.Text = openFileDialog.FileName;
				}
			}
		}

		private void InnerSetConnection()
		{
			if (ConnectionString == null)
			{
				return;
			}
			if (ConnectionString.StartsWith("http"))
			{
				myTab.SelectedTab = tabHTTP;
				txtHTTPUrl.Text = ConnectionString;
				return;
			}
			NameValueCollection nameValueCollection = StringCommon.AnalyseNameValueList(ConnectionString, ';', '=', AllowSameName: false);
			if (nameValueCollection == null)
			{
				return;
			}
			string text = nameValueCollection["Provider"];
			if (text != null)
			{
				text = text.ToUpper();
				if (text.IndexOf("SQL") >= 0)
				{
					myTab.SelectedTab = tabMSSQLServer;
					txtSQLDB.Text = nameValueCollection["Initial Catalog"];
					txtSQLPwd.Text = nameValueCollection["Password"];
					txtSQLServer.Text = nameValueCollection["Data Source"];
					txtSQLUser.Text = nameValueCollection["User ID"];
				}
				else if (text.IndexOf("ORACLE") >= 0)
				{
					myTab.SelectedTab = tabOracle;
					txtOraclePwd.Text = nameValueCollection["Password"];
					txtOracleServer.Text = nameValueCollection["Data Source"];
					txtOracleUser.Text = nameValueCollection["User ID"];
				}
				else if (text.IndexOf("JET") >= 0)
				{
					myTab.SelectedTab = tabAccess;
					txtAccessFile.Text = nameValueCollection["Data Source"];
				}
				else
				{
					myTab.SelectedTab = tabOLEDB;
					txtOLEDB.Text = ConnectionString;
				}
			}
		}

		private void dlgOpenConnection_Load(object sender, EventArgs e)
		{
			InnerSetConnection();
			try
			{
				string path = Application.StartupPath + "\\connhis.txt";
				if (File.Exists(path))
				{
					StreamReader streamReader = new StreamReader(path);
					string text = streamReader.ReadLine();
					cboHistory.Items.Clear();
					while (text != null)
					{
						text = text.Trim();
						if (text.Length > 0)
						{
							text = StringCommon.FromBase64String(text);
							NameValueCollection nameValueCollection = StringCommon.AnalyseNameValueList(text, ';', '=', AllowSameName: false);
							if (nameValueCollection["Provider"] != null)
							{
								cboHistory.Items.Add(nameValueCollection["Provider"]);
							}
							else
							{
								cboHistory.Items.Add(text);
							}
							myHistoryList.Add(text);
						}
						text = streamReader.ReadLine();
					}
					streamReader.Close();
				}
			}
			catch
			{
			}
		}

		private void myTab_SelectedIndexChanged(object sender, EventArgs e)
		{
			TextBox textBox = null;
			if (myTab.SelectedTab == tabAccess)
			{
				textBox = txtAccessFile;
			}
			else if (myTab.SelectedTab == tabHTTP)
			{
				textBox = txtHTTPUrl;
			}
			else if (myTab.SelectedTab == tabMSSQLServer)
			{
				textBox = txtSQLServer;
			}
			else if (myTab.SelectedTab == tabOracle)
			{
				textBox = txtOracleServer;
			}
			else if (myTab.SelectedTab == tabOLEDB)
			{
				textBox = txtOLEDB;
			}
			if (textBox != null)
			{
				textBox.Focus();
				textBox.SelectAll();
			}
		}

		private void cboHistory_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboHistory.SelectedIndex >= 0 && cboHistory.SelectedIndex < myHistoryList.Count)
			{
				ConnectionString = (string)myHistoryList[cboHistory.SelectedIndex];
				InnerSetConnection();
			}
		}
	}
}
