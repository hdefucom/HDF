using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GetSystemStatusGUI;

public class NetworkForm : Form
{
	private NetworkInfo networkInfo;

	private Chart[] subCharts;

	private Color baseColor = Color.LightCoral;

	private Color chartColor = Color.FromArgb(120, Color.LightCoral);

	private Color borderColor = Color.FromArgb(180, Color.LightCoral);

	private Color lineColor = Color.LightPink;

	private int beginTop;

	private int rows = 1;

	private int columns = 1;

	private const int history_length = 60;

	private const double margin_ratio = 35.0;

	private Form1 mainForm;

	private IContainer components = null;

	private Label label1;

	public NetworkForm(Form1 mainForm)
	{
		InitializeComponent();
		networkInfo = new NetworkInfo();
		if (networkInfo.adapterNum == 0)
		{
			mainForm.DisableChecked("noNetwork");
			Dispose();
		}
		else
		{
			this.mainForm = mainForm;
		}
	}

	private void NetworkForm_Load(object sender, EventArgs e)
	{
		List<int> list = new List<int>();
		for (int i = 0; i < 60; i++)
		{
			list.Add(0);
		}
		beginTop = label1.Location.Y + label1.Size.Height;
		Utility.FactorDecompose(networkInfo.adapterNum, ref columns, ref rows);
		subCharts = new Chart[networkInfo.adapterNum];
		for (int j = 0; j < rows; j++)
		{
			for (int k = 0; k < columns; k++)
			{
				int num = j * columns + k;
				Chart chart = new Chart();
				chart.Palette = ChartColorPalette.None;
				chart.PaletteCustomColors = new Color[1] { chartColor };
				chart.Series.Add(num.ToString());
				chart.Series[0].Points.DataBindY(list);
				chart.Series[0].ChartType = SeriesChartType.SplineArea;
				chart.Series[0].BorderColor = borderColor;
				chart.ChartAreas.Add(num.ToString());
				chart.ChartAreas[0].AxisY.Minimum = 0.0;
				chart.ChartAreas[0].AxisY.Maximum = 100.0;
				chart.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
				chart.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
				chart.ChartAreas[0].AxisY.MajorGrid.LineColor = lineColor;
				chart.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
				chart.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
				chart.ChartAreas[0].AxisX.MajorGrid.LineColor = lineColor;
				chart.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
				chart.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
				chart.ChartAreas[0].AxisX.MinorGrid.LineColor = lineColor;
				chart.ChartAreas[0].AxisX.LineColor = baseColor;
				chart.ChartAreas[0].AxisY.LineColor = baseColor;
				chart.ChartAreas[0].AxisX.LineWidth = 2;
				chart.ChartAreas[0].AxisY.LineWidth = 2;
				chart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
				chart.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
				chart.ChartAreas[0].AxisX2.Enabled = AxisEnabled.True;
				chart.ChartAreas[0].AxisX2.LabelStyle.Enabled = false;
				chart.ChartAreas[0].AxisX2.MajorGrid.Enabled = false;
				chart.ChartAreas[0].AxisX2.MajorTickMark.Enabled = false;
				chart.ChartAreas[0].AxisX2.LineColor = baseColor;
				chart.ChartAreas[0].AxisX2.LineWidth = 2;
				chart.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
				chart.ChartAreas[0].AxisY2.LabelStyle.Enabled = false;
				chart.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
				chart.ChartAreas[0].AxisY2.MajorTickMark.Enabled = false;
				chart.ChartAreas[0].AxisY2.LineColor = baseColor;
				chart.ChartAreas[0].AxisY2.LineWidth = 2;
				chart.Titles.Add(num + "_0");
				chart.Titles[0].Text = networkInfo.getAdapterName(num);
				chart.Titles[0].Alignment = ContentAlignment.MiddleLeft;
				chart.Titles[0].DockedToChartArea = num.ToString();
				chart.Titles[0].IsDockedInsideChartArea = false;
				chart.Titles[0].Font = new Font("微软雅黑", 13f);
				chart.Titles.Add(num + "_1");
				chart.Titles[1].Text = networkInfo.getAdapterModel(num);
				chart.Titles[1].Alignment = ContentAlignment.MiddleLeft;
				chart.Titles[1].DockedToChartArea = num.ToString();
				chart.Titles[1].IsDockedInsideChartArea = false;
				chart.Titles[1].ForeColor = SystemColors.GrayText;
				chart.Titles.Add(num + "_2");
				chart.Titles[2].Text = "Upload 0bps\nDownload 0bps\nLink Speed 10Mbps\nIPv4 Address 127.0.0.1\nIPv6 Address ::1";
				chart.Titles[2].Alignment = ContentAlignment.MiddleLeft;
				chart.Titles[2].DockedToChartArea = num.ToString();
				chart.Titles[2].Docking = Docking.Bottom;
				chart.Titles[2].IsDockedInsideChartArea = false;
				chart.Titles[2].Font = new Font("微软雅黑", 11f);
				subCharts[num] = chart;
				base.Controls.Add(subCharts[num]);
			}
		}
		InitialSize();
		NetworkForm_Resize(null, null);
		new Action(network_load_thread).BeginInvoke(null, null);
	}

	private void NetworkForm_Resize(object sender, EventArgs e)
	{
		int num = (int)Math.Round((double)Math.Min(base.Size.Height, base.Size.Width) / 35.0);
		int num2 = num;
		int num3 = (int)Math.Round((double)num * 1.1);
		int num4 = Math.Max(40, num * 2);
		int num5 = (int)Math.Round((double)(base.Size.Height - beginTop - num4 - (rows + 1) * num2) / (double)rows);
		int num6 = (int)Math.Round((double)(base.Size.Width - num3 - (columns + 1) * num) / (double)columns);
		if (num5 <= 0 || num6 <= 0 || subCharts == null)
		{
			return;
		}
		for (int i = 0; i < rows; i++)
		{
			for (int j = 0; j < columns; j++)
			{
				int num7 = i * columns + j;
				int num8 = (j + 1) * num + j * num6;
				int num9 = beginTop + (i + 1) * num2 + i * num5;
				subCharts[num7].Size = new Size(num6, num5);
				subCharts[num7].Location = new Point(num8, num9);
			}
		}
	}

	private void NetworkForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		e.Cancel = true;
		mainForm.DisableChecked("Network");
	}

	private void InitialSize()
	{
		if (columns > 2)
		{
			base.Width = (int)Math.Round((float)base.Width / 2f * (float)columns * 0.97f);
		}
	}

	private void network_load_thread()
	{
		List<float>[] ys = new List<float>[networkInfo.adapterNum];
		for (int i = 0; i < networkInfo.adapterNum; i++)
		{
			ys[i] = new List<float>();
			for (int j = 0; j < 60; j++)
			{
				ys[i].Add(0f);
			}
		}
		while (!subCharts[0].IsDisposed && !mainForm.IsDisposed)
		{
			float[] send_speed = new float[networkInfo.adapterNum];
			float[] receive_speed = new float[networkInfo.adapterNum];
			for (int k = 0; k < networkInfo.adapterNum; k++)
			{
				networkInfo.SpeedAndLoad(k, out var sendSpeed, out var receiveSpeed, out var adapterLoad);
				ys[k].RemoveAt(0);
				ys[k].Add(adapterLoad);
				send_speed[k] = sendSpeed;
				receive_speed[k] = receiveSpeed;
			}
			Action method = delegate
			{
				for (int l = 0; l < networkInfo.adapterNum; l++)
				{
					subCharts[l].Series[0].Points.DataBindY(ys[l]);
					string empty = string.Empty;
					string text = Utility.FormatSpeedString("Send", send_speed[l], "Receive", receive_speed[l], bps: true);
					string text2 = "Link Speed " + networkInfo.getLinkSpeedString(l);
					string text3 = "IPv4 Address " + networkInfo.getIPv4Address(l);
					string text4 = "IPv6 Address " + networkInfo.getIPv6Address(l);
					empty = text + "\n" + text2 + "\n" + text3 + "\n" + text4;
					subCharts[l].Titles[2].Text = empty;
				}
			};
			try
			{
				Invoke(method);
			}
			catch
			{
				break;
			}
			Thread.Sleep(Global.interval_ms);
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
		this.label1 = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("微软雅黑", 24f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label1.Location = new System.Drawing.Point(33, 38);
		this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(148, 41);
		this.label1.TabIndex = 0;
		this.label1.Text = "Network";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.SystemColors.ControlLightLight;
		base.ClientSize = new System.Drawing.Size(567, 430);
		base.Controls.Add(this.label1);
		base.Margin = new System.Windows.Forms.Padding(2);
		base.Name = "NetworkForm";
		this.Text = "Network";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(NetworkForm_FormClosing);
		base.Load += new System.EventHandler(NetworkForm_Load);
		base.Resize += new System.EventHandler(NetworkForm_Resize);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
