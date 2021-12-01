using DCSoft.Common;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Timers;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       播放器控件
	///       </summary>
	[DCPublishAPI]
	[ComVisible(false)]
	[ToolboxItem(false)]
	public class MediaPlayerControler : UserControl
	{
		private GInterface44 _filterGraph;

		private GInterface38 _basicAudio;

		private GInterface39 _videoWindow;

		private GInterface35 _mediaEvent;

		private GInterface36 _mediaEventEx;

		private GInterface37 _mediaPosition;

		private GInterface34 _mediaControl;

		private GInterface40 _basicVideo;

		private string _currenturl;

		private float _videowidth;

		private float _videoheight;

		private float _videoratio;

		private float _panelwidth;

		private float _panelheight;

		private float _panelratio;

		private System.Timers.Timer _Timer;

		private SetTrackBarPositionDel _Delsetposition;

		private int _volume;

		private int _currentposition;

		private int _mediaduration;

		private PlayStatus _playerstatus;

		private string _url;

		private bool _isloopplay;

		/// <summary>
		///       必需的设计器变量。
		///       </summary>
		private IContainer components = null;

		private TrackBar tbarPosition;

		private Button btnStop;

		private Button btnPlayPause;

		private Panel pnlPlayBoard;

		private TableLayoutPanel pnlController;

		/// <summary>
		///       获取或设置播放器的音量，范围为从0到10，0为静音，10为最大。音量转换仍然需要调整，以后再来改
		///       </summary>
		public int Volume
		{
			get
			{
				return (_volume + 10000) / 1000;
			}
			set
			{
				if (value >= 0 && value <= 10)
				{
					_volume = value * 1000 - 10000;
					if (_basicAudio != null)
					{
						_basicAudio.imethod_0(_volume);
					}
				}
				else if (value < 0)
				{
					Volume = 0;
				}
				else if (value > 10)
				{
					Volume = 10;
				}
			}
		}

		/// <summary>
		///       获取或设置当前位置，不允许设置时长低于50秒的媒体
		///       </summary>
		public int CurrentPosition
		{
			get
			{
				if (_mediaPosition != null)
				{
					return (int)_mediaPosition.imethod_2() * 1000;
				}
				return 0;
			}
			set
			{
				if (_mediaPosition != null && value >= 0 && value <= (int)_mediaPosition.imethod_0() * 1000 && (int)_mediaPosition.imethod_0() >= 50)
				{
					_mediaPosition.imethod_1((double)value / 1000.0);
				}
			}
		}

		/// <summary>
		///       获取当前媒体时长
		///       </summary>
		public int CurrentDuration => _mediaduration;

		/// <summary>
		///       获取播放器的状态
		///       </summary>
		public PlayStatus PlayerStatus => _playerstatus;

		/// <summary>
		///       设置或获取要播放的文件，可以是本机媒体文件的全路径，或为网络媒体的URL
		///       </summary>
		public string Url
		{
			get
			{
				return _url;
			}
			set
			{
				int num = 1;
				if (!string.IsNullOrEmpty(value) && Path.GetExtension(value) == ".wmv")
				{
					_url = value;
					btnPlayPause.Enabled = true;
				}
			}
		}

		/// <summary>
		///       是否显示播放控制面版
		///       </summary>
		public bool IsShowUI
		{
			get
			{
				return pnlController.Visible;
			}
			set
			{
				pnlController.Visible = value;
			}
		}

		/// <summary>
		///       是否循环播放（目前只支持单曲循环）
		///       </summary>
		public bool IsLoopPlay
		{
			get
			{
				return _isloopplay;
			}
			set
			{
				_isloopplay = value;
			}
		}

		/// <summary>
		///       获取或设置控制面板的背景色
		///       </summary>
		public Color ControlPanelColor
		{
			get
			{
				return pnlController.BackColor;
			}
			set
			{
				pnlController.BackColor = value;
			}
		}

		/// <summary>
		///       播放器状态改变事件
		///       </summary>
		public event PlayerStatusChangedEventHandler PlayerStatusChangedEvent;

		public MediaPlayerControler()
		{
			InitializeComponent();
			_Delsetposition = SetTrackBarPositionForDel;
			_volume = 0;
			_playerstatus = PlayStatus.const_0;
			_isloopplay = false;
			_url = (_currenturl = "");
			pnlController.Visible = true;
			pnlController.BackColor = SystemColors.Control;
			Clear();
			_Timer = new System.Timers.Timer();
			_Timer.Interval = 10.0;
			_Timer.Elapsed += _Timer_Elapsed;
			pnlPlayBoard.SizeChanged += pnlPlayBoard_SizeChanged;
			btnStop.Click += btnStop_Click;
			btnPlayPause.Click += btnPlayPause_Click;
			tbarPosition.MouseUp += tbarPosition_MouseUp;
			base.Disposed += MediaPlayerControler_Disposed;
		}

		private void MediaPlayerControler_Disposed(object sender, EventArgs e)
		{
			if (_playerstatus == PlayStatus.const_2 || _playerstatus == PlayStatus.const_3)
			{
				Stop();
			}
			_Timer.Stop();
			_Timer.Close();
		}

		~MediaPlayerControler()
		{
			Dispose(disposing: true);
		}

		/// <summary>
		///       若指定了新的Url，则播放Url指定的媒体文件；若播放器处于暂停状态，则继续播放
		///       </summary>
		public void Play()
		{
			if (_playerstatus == PlayStatus.const_3 && _filterGraph != null && _url == _currenturl && File.Exists(_currenturl))
			{
				_filterGraph.imethod_0();
				_playerstatus = PlayStatus.const_2;
				if (this.PlayerStatusChangedEvent != null)
				{
					this.PlayerStatusChangedEvent(this, _playerstatus);
				}
				_Timer.Start();
				btnPlayPause.Image = WriterResources.pause;
			}
			else if ((_url != _currenturl || _filterGraph == null) && File.Exists(_url))
			{
				PlayNew();
			}
		}

		/// <summary>
		///       暂停播放
		///       </summary>
		public void Pause()
		{
			if (_playerstatus == PlayStatus.const_2 && _filterGraph != null)
			{
				_filterGraph.imethod_1();
				_playerstatus = PlayStatus.const_3;
				if (this.PlayerStatusChangedEvent != null)
				{
					this.PlayerStatusChangedEvent(this, _playerstatus);
				}
				_Timer.Stop();
				btnPlayPause.Image = WriterResources.play;
			}
		}

		/// <summary>
		///       停止播放
		///       </summary>
		public void Stop()
		{
			if ((_playerstatus == PlayStatus.const_2 || _playerstatus == PlayStatus.const_3) && _filterGraph != null)
			{
				_filterGraph.imethod_2();
				Clear();
				_playerstatus = PlayStatus.const_4;
				if (this.PlayerStatusChangedEvent != null)
				{
					this.PlayerStatusChangedEvent(this, _playerstatus);
				}
				_Timer.Stop();
				btnPlayPause.Image = WriterResources.play;
				btnStop.Enabled = false;
				tbarPosition.Value = 0;
				tbarPosition.Enabled = false;
			}
		}

		private void PlayNew()
		{
			Stop();
			try
			{
				_filterGraph = new GClass593();
				_filterGraph.imethod_4(_url);
				_basicAudio = (_filterGraph as GInterface38);
				_basicAudio.imethod_0(_volume);
				_basicVideo = (_filterGraph as GInterface40);
				_videoWindow = (_filterGraph as GInterface39);
				_videoWindow.imethod_22((int)pnlPlayBoard.Handle);
				_videoWindow.imethod_1(1107296256);
			}
			catch
			{
				_videoWindow = null;
			}
			_mediaEvent = (_filterGraph as GInterface35);
			_mediaEventEx = (_filterGraph as GInterface36);
			_mediaEventEx.imethod_12((int)pnlPlayBoard.Handle, 32769, 0);
			_mediaPosition = (_filterGraph as GInterface37);
			_mediaControl = _filterGraph;
			if (_basicVideo != null && _videoWindow != null)
			{
				_videoheight = _basicVideo.imethod_4();
				_videowidth = _basicVideo.imethod_3();
				_videoratio = _videowidth / _videoheight;
			}
			_mediaduration = (int)_mediaPosition.imethod_0() * 1000;
			tbarPosition.Maximum = _mediaduration;
			VideoScale();
			_mediaControl.imethod_0();
			_currenturl = _url;
			_playerstatus = PlayStatus.const_2;
			if (this.PlayerStatusChangedEvent != null)
			{
				this.PlayerStatusChangedEvent(this, _playerstatus);
			}
			_Timer.Start();
			btnPlayPause.Image = WriterResources.pause;
			btnStop.Enabled = true;
			tbarPosition.Enabled = (File.Exists(_url) && _mediaduration >= 50000);
		}

		private void Clear()
		{
			if (_mediaControl != null)
			{
				_mediaControl.imethod_2();
				_mediaControl = null;
			}
			if (_mediaEventEx != null)
			{
				_mediaEventEx.imethod_12(0, 0, 0);
				_mediaEventEx = null;
			}
			if (_videoWindow != null)
			{
				_videoWindow.imethod_12(0);
				_videoWindow.imethod_22(0);
				_videoWindow = null;
			}
			if (_basicAudio != null)
			{
				_basicAudio = null;
			}
			if (_filterGraph != null)
			{
				_filterGraph = null;
			}
			if (_mediaEvent != null)
			{
				_mediaEvent = null;
			}
			if (_mediaPosition != null)
			{
				_mediaPosition = null;
			}
		}

		private void VideoScale()
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			if (_panelheight >= _videoheight && _panelwidth >= _videowidth)
			{
				num = (_panelwidth - _videowidth) / 2f;
				num2 = (_panelheight - _videoheight) / 2f;
				num3 = _videowidth;
				num4 = _videoheight;
			}
			else if (_videoratio >= _panelratio)
			{
				num = 0f;
				num3 = _panelwidth;
				num4 = _panelwidth / _videoratio;
				num2 = (_panelheight - num4) / 2f;
			}
			else
			{
				num2 = 0f;
				num4 = _panelheight;
				num3 = num4 * _videoratio;
				num = (_panelwidth - num3) / 2f;
			}
			if (_videoWindow != null)
			{
				_videoWindow.imethod_32(pnlPlayBoard.ClientRectangle.Left + (int)num, pnlPlayBoard.ClientRectangle.Top + (int)num2, (int)num3, (int)num4);
			}
		}

		private void SetTrackBarPositionForDel(int int_0)
		{
			tbarPosition.Value = int_0;
			if (tbarPosition.Value != tbarPosition.Maximum)
			{
				return;
			}
			_Timer.Stop();
			_filterGraph.imethod_2();
			Clear();
			if (_isloopplay)
			{
				Play();
				return;
			}
			_playerstatus = PlayStatus.const_5;
			if (this.PlayerStatusChangedEvent != null)
			{
				this.PlayerStatusChangedEvent(this, _playerstatus);
			}
			btnPlayPause.Image = WriterResources.play;
			btnStop.Enabled = false;
			tbarPosition.Enabled = false;
			tbarPosition.Value = 0;
		}

		private void tbarPosition_MouseUp(object sender, MouseEventArgs e)
		{
			float num = (float)e.X / (float)tbarPosition.Bounds.Width * (float)CurrentDuration;
			if (_playerstatus == PlayStatus.const_2)
			{
				Pause();
				CurrentPosition = (int)num;
				Play();
			}
			else if (_playerstatus == PlayStatus.const_3)
			{
				CurrentPosition = (int)num;
				tbarPosition.Value = (int)num;
			}
		}

		private void btnPlayPause_Click(object sender, EventArgs e)
		{
			if (_playerstatus == PlayStatus.const_2)
			{
				Pause();
			}
			else
			{
				Play();
			}
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			Stop();
		}

		private void pnlPlayBoard_SizeChanged(object sender, EventArgs e)
		{
			_panelheight = pnlPlayBoard.ClientSize.Height;
			_panelwidth = pnlPlayBoard.ClientSize.Width;
			_panelratio = _panelwidth / _panelheight;
			if (_playerstatus == PlayStatus.const_2 || _playerstatus == PlayStatus.const_3)
			{
				VideoScale();
			}
		}

		private void _Timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			if (base.InvokeRequired)
			{
				try
				{
					Invoke(_Delsetposition, CurrentPosition);
				}
				catch
				{
				}
			}
			else
			{
				SetTrackBarPositionForDel(CurrentPosition);
			}
		}

		/// <summary>
		///       清理所有正在使用的资源。
		///       </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		///       设计器支持所需的方法 - 不要
		///       使用代码编辑器修改此方法的内容。
		///       </summary>
		private void InitializeComponent()
		{
			btnStop = new System.Windows.Forms.Button();
			btnPlayPause = new System.Windows.Forms.Button();
			tbarPosition = new System.Windows.Forms.TrackBar();
			pnlPlayBoard = new System.Windows.Forms.Panel();
			pnlController = new System.Windows.Forms.TableLayoutPanel();
			((System.ComponentModel.ISupportInitialize)tbarPosition).BeginInit();
			pnlController.SuspendLayout();
			SuspendLayout();
			btnStop.Dock = System.Windows.Forms.DockStyle.Fill;
			btnStop.Enabled = false;
			btnStop.Image = DCSoft.Writer.WriterResources.stop;
			btnStop.Location = new System.Drawing.Point(29, 3);
			btnStop.Name = "btnStop";
			btnStop.Size = new System.Drawing.Size(20, 20);
			btnStop.TabIndex = 3;
			btnStop.UseVisualStyleBackColor = true;
			btnPlayPause.Dock = System.Windows.Forms.DockStyle.Fill;
			btnPlayPause.Enabled = false;
			btnPlayPause.Image = DCSoft.Writer.WriterResources.play;
			btnPlayPause.Location = new System.Drawing.Point(3, 3);
			btnPlayPause.Name = "btnPlayPause";
			btnPlayPause.Size = new System.Drawing.Size(20, 20);
			btnPlayPause.TabIndex = 2;
			btnPlayPause.UseVisualStyleBackColor = true;
			tbarPosition.Dock = System.Windows.Forms.DockStyle.Fill;
			tbarPosition.Enabled = false;
			tbarPosition.Location = new System.Drawing.Point(55, 3);
			tbarPosition.Name = "tbarPosition";
			tbarPosition.Size = new System.Drawing.Size(314, 20);
			tbarPosition.TabIndex = 0;
			tbarPosition.TickStyle = System.Windows.Forms.TickStyle.None;
			pnlPlayBoard.Dock = System.Windows.Forms.DockStyle.Fill;
			pnlPlayBoard.Location = new System.Drawing.Point(0, 0);
			pnlPlayBoard.Name = "pnlPlayBoard";
			pnlPlayBoard.Padding = new System.Windows.Forms.Padding(0, 0, 0, 26);
			pnlPlayBoard.Size = new System.Drawing.Size(372, 289);
			pnlPlayBoard.TabIndex = 1;
			pnlController.BackColor = System.Drawing.Color.Black;
			pnlController.ColumnCount = 3;
			pnlController.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26f));
			pnlController.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26f));
			pnlController.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			pnlController.Controls.Add(btnPlayPause, 0, 0);
			pnlController.Controls.Add(tbarPosition, 2, 0);
			pnlController.Controls.Add(btnStop, 1, 0);
			pnlController.Dock = System.Windows.Forms.DockStyle.Bottom;
			pnlController.Location = new System.Drawing.Point(0, 263);
			pnlController.Name = "pnlController";
			pnlController.RowCount = 1;
			pnlController.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			pnlController.Size = new System.Drawing.Size(372, 26);
			pnlController.TabIndex = 4;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.Black;
			base.Controls.Add(pnlController);
			base.Controls.Add(pnlPlayBoard);
			base.Name = "MediaPlayerControler";
			base.Size = new System.Drawing.Size(372, 289);
			((System.ComponentModel.ISupportInitialize)tbarPosition).EndInit();
			pnlController.ResumeLayout(false);
			pnlController.PerformLayout();
			ResumeLayout(false);
		}
	}
}
