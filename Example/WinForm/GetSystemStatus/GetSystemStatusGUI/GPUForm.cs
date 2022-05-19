using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GetSystemStatusGUI;

public class GPUForm : Form
{
	private GPUInfo gpuInfo;

	private Form1 mainForm;

	private readonly int id;

	private Color baseColor = Color.DeepSkyBlue;

	private Color chartColor = Color.FromArgb(120, Color.DeepSkyBlue);

	private Color borderColor = Color.FromArgb(180, Color.DeepSkyBlue);

	private Color lineColor = Color.FromArgb(150, Color.DeepSkyBlue);

	private IContainer components = null;

	private Label label1;

	private Chart chartGPU;

	private Label lblGPUName;

	public List<GPUForm> moreGPUForms { get; private set; }

	public GPUForm(Form1 mainForm, int id = 0)
	{
		InitializeComponent();
		moreGPUForms = new List<GPUForm>();
		gpuInfo = new GPUInfo(id);
		if (gpuInfo.Count == 0)
		{
			mainForm.DisableChecked("noGPU");
			Dispose();
			return;
		}
		this.id = id;
		this.mainForm = mainForm;
		if (id == 0 && gpuInfo.Count > 1)
		{
			for (int i = 1; i < gpuInfo.Count; i++)
			{
				moreGPUForms.Add(new GPUForm(mainForm, i));
				moreGPUForms[i - 1].Show();
			}
		}
	}

	private void GPUForm_Load(object sender, EventArgs e)
	{
		chartGPU.PaletteCustomColors = new Color[1] { chartColor };
		lblGPUName.Text = gpuInfo.getGpuName(id);
		Label label = label1;
		label.Text = label.Text + " " + id;
		Text = Text + " " + id;
		List<string> gPUEngines = gpuInfo.GetGPUEngines(id);
		foreach (string item in gPUEngines)
		{
			chartGPU.Series.Add(item);
			chartGPU.ChartAreas.Add(item);
			chartGPU.Titles.Add(new Title
			{
				Name = item
			});
			chartGPU.Series[item].ChartType = SeriesChartType.SplineArea;
			chartGPU.Series[item].BorderColor = borderColor;
			chartGPU.Series[item].ChartArea = item;
			chartGPU.ChartAreas[item].AxisY.Enabled = AxisEnabled.True;
			chartGPU.ChartAreas[item].AxisX.Enabled = AxisEnabled.True;
			chartGPU.ChartAreas[item].AxisY.Minimum = 0.0;
			chartGPU.ChartAreas[item].AxisY.Maximum = 100.0;
			chartGPU.ChartAreas[item].AxisY.MajorGrid.Enabled = true;
			chartGPU.ChartAreas[item].AxisY.MajorTickMark.Enabled = false;
			chartGPU.ChartAreas[item].AxisY.MajorGrid.LineColor = lineColor;
			chartGPU.ChartAreas[item].AxisY.MinorGrid.Enabled = false;
			chartGPU.ChartAreas[item].AxisX.MajorGrid.Enabled = true;
			chartGPU.ChartAreas[item].AxisX.MajorGrid.LineColor = lineColor;
			chartGPU.ChartAreas[item].AxisX.MajorTickMark.Enabled = false;
			chartGPU.ChartAreas[item].AxisX.MinorGrid.Enabled = false;
			chartGPU.ChartAreas[item].AxisX.MinorGrid.LineColor = lineColor;
			chartGPU.ChartAreas[item].AxisX.LineColor = baseColor;
			chartGPU.ChartAreas[item].AxisY.LineColor = baseColor;
			chartGPU.ChartAreas[item].AxisX.LineWidth = 2;
			chartGPU.ChartAreas[item].AxisY.LineWidth = 2;
			chartGPU.ChartAreas[item].AxisX.LabelStyle.Enabled = false;
			chartGPU.ChartAreas[item].AxisY.LabelStyle.Enabled = false;
			chartGPU.ChartAreas[item].AxisX2.Enabled = AxisEnabled.True;
			chartGPU.ChartAreas[item].AxisX2.LabelStyle.Enabled = false;
			chartGPU.ChartAreas[item].AxisX2.MajorGrid.Enabled = false;
			chartGPU.ChartAreas[item].AxisX2.MajorTickMark.Enabled = false;
			chartGPU.ChartAreas[item].AxisX2.LineColor = baseColor;
			chartGPU.ChartAreas[item].AxisX2.LineWidth = 2;
			chartGPU.ChartAreas[item].AxisY2.Enabled = AxisEnabled.True;
			chartGPU.ChartAreas[item].AxisY2.LabelStyle.Enabled = false;
			chartGPU.ChartAreas[item].AxisY2.MajorGrid.Enabled = false;
			chartGPU.ChartAreas[item].AxisY2.MajorTickMark.Enabled = false;
			chartGPU.ChartAreas[item].AxisY2.LineColor = baseColor;
			chartGPU.ChartAreas[item].AxisY2.LineWidth = 2;
			chartGPU.Titles[item].Text = item;
			chartGPU.Titles[item].Alignment = ContentAlignment.MiddleLeft;
			chartGPU.Titles[item].DockedToChartArea = item;
			chartGPU.Titles[item].IsDockedInsideChartArea = false;
			chartGPU.Titles[item].ForeColor = SystemColors.GrayText;
			chartGPU.Titles[item].Font = new Font(FontFamily.GenericSansSerif, 10f);
		}
		GPUForm_Resize(null, null);
		Thread thread = new Thread(GPUPCThread);
		thread.Start();
	}

	private void GPUPCThread()
	{
		Dictionary<string, List<float>> ys = new Dictionary<string, List<float>>();
		List<string> gPUEngines = gpuInfo.GetGPUEngines(id);
		foreach (string item in gPUEngines)
		{
			List<float> list = new List<float>();
			for (int i = 0; i < Global.history_length; i++)
			{
				list.Add(0f);
			}
			ys.Add(item, list);
		}
		int num = 0;
		while (!chartGPU.IsDisposed && !mainForm.IsDisposed)
		{
			if (num % 15 == 0 && num != 0)
			{
				gpuInfo.RefreshGPUEnginePerfCnt(id);
			}
			Dictionary<string, float> cGpuUti = gpuInfo.GetGPUUtilization(id);
			Action method = delegate
			{
				foreach (KeyValuePair<string, float> item2 in cGpuUti)
				{
					string key = item2.Key;
					float value = item2.Value;
					ys[key].RemoveAt(0);
					ys[key].Add(value);
					chartGPU.Series[key].Points.DataBindY(ys[key]);
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
			num++;
			Thread.Sleep(Global.interval_ms);
		}
	}

	public new void Hide()
	{
		base.Hide();
		foreach (GPUForm moreGPUForm in moreGPUForms)
		{
			moreGPUForm.Hide();
		}
	}

	public new void Dispose()
	{
		if (id == 0)
		{
			foreach (GPUForm moreGPUForm in moreGPUForms)
			{
				moreGPUForm.Dispose();
			}
		}
		base.Dispose();
	}

	private void GPUForm_Resize(object sender, EventArgs e)
	{
		int num = base.Width - (int)((double)chartGPU.Location.X * 2.5);
		int num2 = base.Height - chartGPU.Location.Y - chartGPU.Location.X * 6;
		if (num > 0 && num2 > 0)
		{
			chartGPU.Size = new Size(num, num2);
		}
	}

	private void GPUForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		mainForm.DisableChecked("GPU");
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
		this.chartGPU = new System.Windows.Forms.DataVisualization.Charting.Chart();
		this.lblGPUName = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)this.chartGPU).BeginInit();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("微软雅黑", 24f);
		this.label1.Location = new System.Drawing.Point(31, 34);
		this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(86, 41);
		this.label1.TabIndex = 0;
		this.label1.Text = "GPU";
		this.chartGPU.Location = new System.Drawing.Point(11, 106);
		this.chartGPU.Margin = new System.Windows.Forms.Padding(2);
		this.chartGPU.Name = "chartGPU";
		this.chartGPU.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
		this.chartGPU.Size = new System.Drawing.Size(725, 428);
		this.chartGPU.TabIndex = 1;
		this.chartGPU.Text = "GPUChart";
		this.lblGPUName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.lblGPUName.BackColor = System.Drawing.Color.Transparent;
		this.lblGPUName.Font = new System.Drawing.Font("微软雅黑 Light", 15f);
		this.lblGPUName.Location = new System.Drawing.Point(121, 44);
		this.lblGPUName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.lblGPUName.Name = "lblGPUName";
		this.lblGPUName.Size = new System.Drawing.Size(608, 31);
		this.lblGPUName.TabIndex = 2;
		this.lblGPUName.Text = "GPU Name";
		this.lblGPUName.TextAlign = System.Drawing.ContentAlignment.TopRight;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.SystemColors.ControlLightLight;
		base.ClientSize = new System.Drawing.Size(759, 560);
		base.Controls.Add(this.chartGPU);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.lblGPUName);
		base.Margin = new System.Windows.Forms.Padding(2);
		base.Name = "GPUForm";
		this.Text = "GPU";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(GPUForm_FormClosing);
		base.Load += new System.EventHandler(GPUForm_Load);
		base.Resize += new System.EventHandler(GPUForm_Resize);
		((System.ComponentModel.ISupportInitialize)this.chartGPU).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
