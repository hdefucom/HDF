using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ZYCommon
{
	public class LoadDiagramPic : Form
	{
		private Button cmdCancel;

		private Button cmdOK;

		private PictureBox pictureBox1;

		private ComboBox comboBox1;

		private Label label1;

		private IContainer components = null;

		private bool isInit = false;

		private Dictionary<decimal, byte[]> PicDic = new Dictionary<decimal, byte[]>();

		public decimal CurrrentSelectedImgId = 0m;

		public Image CurrentSelectedImg = null;

		public LoadDiagramPic()
		{
			InitializeComponent();
		}

		public void InitFormData(IDbConnection Conn)
		{
			if (!isInit)
			{
				IDbCommand dbCommand = Conn.CreateCommand();
				dbCommand.CommandText = "SELECT  IMG_ID ,IMG_DATA ,IMG_CLASS ,MEMO FROM ZYRISDB.dbo.DIC_REPORT_DIAGRAM ";
				bool flag = true;
				if (Conn.State == ConnectionState.Open)
				{
					flag = false;
				}
				try
				{
					if (flag)
					{
						Conn.Open();
					}
					IDataReader dataReader = null;
					try
					{
						dataReader = dbCommand.ExecuteReader();
						while (dataReader.Read())
						{
							int num = comboBox1.Items.Add(dataReader["IMG_ID"].ToString() + "," + dataReader["MEMO"].ToString());
							PicDic.Add(Convert.ToDecimal(dataReader["IMG_ID"]), (byte[])dataReader["IMG_DATA"]);
						}
						dataReader.Close();
					}
					catch
					{
						if (!(dataReader?.IsClosed ?? true))
						{
							dataReader.Close();
						}
					}
					isInit = true;
				}
				catch
				{
				}
				finally
				{
					try
					{
						if (flag)
						{
							Conn.Close();
						}
					}
					catch
					{
					}
				}
			}
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
			cmdCancel = new System.Windows.Forms.Button();
			cmdOK = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			comboBox1 = new System.Windows.Forms.ComboBox();
			label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			cmdCancel.Location = new System.Drawing.Point(187, 345);
			cmdCancel.Name = "cmdCancel";
			cmdCancel.Size = new System.Drawing.Size(75, 23);
			cmdCancel.TabIndex = 7;
			cmdCancel.Text = "取消(&C)";
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			cmdOK.Location = new System.Drawing.Point(74, 345);
			cmdOK.Name = "cmdOK";
			cmdOK.Size = new System.Drawing.Size(75, 23);
			cmdOK.TabIndex = 6;
			cmdOK.Text = "确定(&O)";
			cmdOK.Click += new System.EventHandler(cmdOK_Click);
			pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox1.Location = new System.Drawing.Point(17, 32);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(300, 300);
			pictureBox1.TabIndex = 8;
			pictureBox1.TabStop = false;
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new System.Drawing.Point(134, 6);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(121, 20);
			comboBox1.TabIndex = 9;
			comboBox1.SelectedIndexChanged += new System.EventHandler(comboBox1_SelectedIndexChanged);
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(15, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(113, 12);
			label1.TabIndex = 10;
			label1.Text = "请选择示意图图像：";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(335, 379);
			base.Controls.Add(label1);
			base.Controls.Add(comboBox1);
			base.Controls.Add(pictureBox1);
			base.Controls.Add(cmdCancel);
			base.Controls.Add(cmdOK);
			base.Name = "LoadDiagramPic";
			Text = "插入示意图";
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox comboBox = (ComboBox)sender;
			int selectedIndex = comboBox.SelectedIndex;
			string text = comboBox.Items[selectedIndex].ToString();
			string text2 = comboBox.Text;
			string[] array = text.Split(',');
			decimal num = Convert.ToDecimal(array[0]);
			byte[] buffer = PicDic[num];
			MemoryStream memoryStream = new MemoryStream(buffer);
			Image original = Image.FromStream(memoryStream);
			memoryStream.Close();
			Bitmap bitmap = new Bitmap(original, pictureBox1.Width, pictureBox1.Height);
			pictureBox1.Image = bitmap;
			CurrrentSelectedImgId = num;
			CurrentSelectedImg = bitmap;
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			Close();
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			Close();
		}
	}
}
