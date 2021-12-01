using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using XDesignerCommon;
using XDesignerPrinting;
using ZYCommon;
using ZYTextDocumentLib;

namespace ZYTextDocumentLibPublic
{
	[Guid("8A72520C-8EC1-4B57-BFB2-E1437E8EC42D")]
	public class ZYEditPanel : UserControl, IObjectSafety
	{
		private ZYKBTreeView tvwKB;

		private ZYEditorControl txtEMR;

		private Thread myInitThread = null;

		private string strIECookie = null;

		private string strServerPage = null;

		private string strDocumentID = null;

		private string strUserName = null;

		private PictureBox picDrag;

		private bool bolDraging = false;

		private int intLastX = 0;

		private int intLastY = 0;

		private System.Windows.Forms.Timer myTimer;

		private IContainer components;

		private int intUserLevel = 0;

		public ZYTextDocument Document => txtEMR.EMRDoc;

		public int UserLevel
		{
			get
			{
				return intUserLevel;
			}
			set
			{
				intUserLevel = value;
			}
		}

		public int DocumentWidth => txtEMR.CurrentPage.Width;

		public void GetInterfacceSafyOptions(int riid, out int pdwSupportedOptions, out int pdwEnabledOptions)
		{
			pdwSupportedOptions = 1;
			pdwEnabledOptions = 2;
		}

		public void SetInterfaceSafetyOptions(int riid, int dwOptionsSetMask, int dwEnabledOptions)
		{
		}

		protected override void Dispose(bool disposing)
		{
			if (ZYDBConnection.Instance.Connection is XMLHttpConnection)
			{
				(ZYDBConnection.Instance.Connection as XMLHttpConnection).CancelPostData();
			}
			ZYKBBuffer.Instance.Close();
			ZYErrorReport.Instance.ClearDebugPrint();
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			tvwKB = new ZYTextDocumentLib.ZYKBTreeView();
			txtEMR = new ZYTextDocumentLib.ZYEditorControl();
			picDrag = new System.Windows.Forms.PictureBox();
			myTimer = new System.Windows.Forms.Timer(components);
			SuspendLayout();
			tvwKB.BindControl = null;
			tvwKB.DesignKBMode = false;
			tvwKB.DoubleClickMode = false;
			tvwKB.HideSelection = false;
			tvwKB.Indent = 14;
			tvwKB.ItemHeight = 18;
			tvwKB.KBBuffer = null;
			tvwKB.Location = new System.Drawing.Point(16, 8);
			tvwKB.Name = "tvwKB";
			tvwKB.RootKBList = null;
			tvwKB.SelectedKBList = null;
			tvwKB.ShowKBItem = false;
			tvwKB.ShowNormalKBItem = false;
			tvwKB.ShowSystemKBItem = false;
			tvwKB.ShowTemplateKBItem = false;
			tvwKB.Size = new System.Drawing.Size(128, 232);
			tvwKB.TabIndex = 0;
			txtEMR.AcceptsTab = true;
			txtEMR.AllowDrop = true;
			txtEMR.AutoScroll = true;
			txtEMR.AutoScrollMinSize = new System.Drawing.Size(825, 1154);
			txtEMR.BackColor = System.Drawing.SystemColors.AppWorkspace;
			txtEMR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtEMR.CaptureMouse = false;
			txtEMR.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtEMR.DefaultCursor = System.Windows.Forms.Cursors.Default;
			txtEMR.EnableInsertMode = true;
			txtEMR.ForceShowCaret = false;
			txtEMR.GraphicsUnit = System.Drawing.GraphicsUnit.Document;
			txtEMR.InnerToolTipVisible = false;
			txtEMR.InsertMode = true;
			txtEMR.Location = new System.Drawing.Point(304, 16);
			txtEMR.MouseDragScroll = false;
			txtEMR.MoveCaretWithScroll = true;
			txtEMR.Name = "txtEMR";
			txtEMR.PageBackColor = System.Drawing.Color.White;
			txtEMR.PageIndex = 0;
			txtEMR.PageSpacing = 20;
			txtEMR.RunInIE = false;
			txtEMR.ScrollFlag = false;
			txtEMR.Size = new System.Drawing.Size(280, 328);
			txtEMR.TabIndex = 1;
			txtEMR.UseAbsTransformPoint = false;
			txtEMR.UserLevel = 0;
			txtEMR.ViewAutoScrollMinSize = new System.Drawing.Size(2578, 3606);
			txtEMR.ViewAutoScrollPosition = new System.Drawing.Point(0, 0);
			txtEMR.ViewBounds = new System.Drawing.Rectangle(0, 0, 0, 0);
			txtEMR.ViewMode = XDesignerPrinting.PageViewMode.Page;
			txtEMR.WordWrap = false;
			txtEMR.XZoomRate = 1f;
			txtEMR.YZoomRate = 1f;
			picDrag.Cursor = System.Windows.Forms.Cursors.SizeWE;
			picDrag.Location = new System.Drawing.Point(184, 16);
			picDrag.Name = "picDrag";
			picDrag.Size = new System.Drawing.Size(4, 408);
			picDrag.TabIndex = 2;
			picDrag.TabStop = false;
			picDrag.MouseUp += new System.Windows.Forms.MouseEventHandler(picDrag_MouseUp);
			picDrag.MouseMove += new System.Windows.Forms.MouseEventHandler(picDrag_MouseMove);
			picDrag.MouseDown += new System.Windows.Forms.MouseEventHandler(picDrag_MouseDown);
			myTimer.Enabled = true;
			myTimer.Tick += new System.EventHandler(myTimer_Tick);
			BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			base.Controls.Add(picDrag);
			base.Controls.Add(txtEMR);
			base.Controls.Add(tvwKB);
			base.Name = "ZYEditPanel";
			base.Size = new System.Drawing.Size(600, 464);
			ResumeLayout(false);
		}

		public void ShowKBTreeView()
		{
			tvwKB.Visible = true;
			picDrag.Visible = true;
			OnResize(null);
		}

		public void HideKBTreeView()
		{
			tvwKB.Visible = false;
			picDrag.Visible = false;
			OnResize(null);
		}

		public ZYEditPanel()
		{
			ZYErrorReport.Instance.Clear();
			ZYErrorReport.Instance.ClearDebugPrint();
			ZYErrorReport.Instance.GetDebugPrint = true;
			ZYErrorReport.Instance.SystemName = "众阳文本编辑器网页版";
			ZYErrorReport.Instance.OperatorName = "默认用户";
			ZYErrorReport.Instance.DebugPrint("程序开始运行");
			try
			{
				InitializeComponent();
				ZYKBTreeView.RunInDesigner = false;
				txtEMR.BindKBTreeView(tvwKB);
				tvwKB.KBBuffer = ZYKBBuffer.Instance;
				tvwKB.DesignKBMode = false;
				tvwKB.EnableClickEvent = true;
				base.GotFocus += EMREditPanel_GotFocus;
				ZYKBBuffer.Instance.Connection = txtEMR.EMRDoc.DataSource.DBConn;
				ZYKBBuffer.Instance.Connection.CanUpdate = false;
				ZYKBBuffer.Instance.DesignMode = false;
				ZYKBBuffer.Instance.EnableKBSection = false;
				ZYKBBufferYS.Instance.Connection = txtEMR.EMRDoc.DataSource.DBConn;
				ZYKBBufferYS.Instance.Connection.CanUpdate = false;
				ZYKBBufferYS.Instance.DesignMode = false;
				ZYKBBufferYS.Instance.EnableKBSection = false;
				txtEMR.KBTreeView = tvwKB;
				txtEMR.EMRDoc.Info.DesignMode = false;
				txtEMR.EMRDoc.Info.SavePreViewText = true;
				txtEMR.EMRDoc.Info.ShowAll = false;
				txtEMR.EMRDoc.Info.ShowMark = false;
				txtEMR.EMRDoc.Info.ShowPageLine = false;
				txtEMR.EMRDoc.KBBuffer = ZYKBBuffer.Instance;
				txtEMR.EMRDoc.Info.LogicDelete = false;
				txtEMR.EMRDoc.Info.AutoLogicDelete = true;
				txtEMR.EMRDoc.Info.LockForMark = false;
				txtEMR.EMRDoc.Info.MarkLock = true;
				txtEMR.RunInDesigner = true;
				txtEMR.BorderStyle = BorderStyle.None;
			}
			catch (Exception sourceException)
			{
				ZYErrorReport.Instance.SourceException = sourceException;
				ZYErrorReport.Instance.SourceObject = txtEMR;
				ZYErrorReport.Instance.UserMessage = "加载文本编辑控件错误";
				ZYErrorReport.Instance.ShowErrorDialog();
			}
		}

		private void LoadAllData()
		{
			string ownerSection = ZYKBBuffer.Instance.OwnerSection;
			ZYKBBuffer.Instance.OwnerSection = null;
			ZYKBBuffer.Instance.LoadAllKBList(FixListIndex: true);
			ZYKBBuffer.Instance.OwnerSection = ownerSection;
			ZYKBBuffer.Instance.LoadKBSection();
			GC.Collect();
		}

		private void LoadALLdataYS()
		{
			string ownerSection = ZYKBBufferYS.Instance.OwnerSection;
			ZYKBBufferYS.Instance.OwnerSection = null;
			ZYKBBufferYS.Instance.LoadAllKBList(FixListIndex: true);
			ZYKBBufferYS.Instance.OwnerSection = ownerSection;
			ZYKBBufferYS.Instance.LoadKBSection();
			GC.Collect();
		}

		public bool InitForIE(string strCookie, string strPage, string strID, string vUserName, string strKBListSql, string strKBItemSql, int iUserLevel, string strYSID, string strYSKB, string strYSITEM, string info)
		{
			intUserLevel = iUserLevel;
			ZYKBBuffer.Instance.KeyPreFix = strID;
			ZYKBBuffer.Instance.Custom_KBLIST_SQL = strKBListSql;
			ZYKBBuffer.Instance.Custom_KBITEM_SQL = strKBItemSql;
			ZYKBBufferYS.Instance.KeyPreFix = strYSID;
			ZYKBBufferYS.Instance.Custom_KBLIST_SQL = strYSKB;
			ZYKBBufferYS.Instance.Custom_KBITEM_SQL = strYSITEM;
			string[] array = info.Split('|');
			if (array[0] == "1")
			{
				ZYPublic.StandardMode = true;
			}
			else
			{
				ZYPublic.StandardMode = true;
			}
			if (array.Length > 1)
			{
				ZYPublic.PatientID = array[1];
			}
			if (array.Length > 2 && array[2] != "")
			{
				XmlDocument xmlDocument = new XmlDocument();
				try
				{
					xmlDocument.LoadXml(array[2]);
					ZYPublic.PatientInfo = xmlDocument;
				}
				catch
				{
					MessageBox.Show("加载病人信息失败！");
				}
			}
			if (array.Length > 3)
			{
				if (array[3] == "1")
				{
					ZYPublic.Isoutcopy = true;
				}
				else
				{
					ZYPublic.Isoutcopy = false;
				}
			}
			if (array.Length > 4)
			{
				ZYPublic.ModalityName = array[4];
			}
			ZYErrorReport.Instance.DebugPrint("开始初始化控件");
			ZYErrorReport.Instance.SetAttribute("数据源页面", strPage);
			ZYErrorReport.Instance.SetAttribute("编号", strID);
			ZYErrorReport.Instance.SetAttribute("用户名", vUserName);
			ZYErrorReport.Instance.OperatorName = vUserName;
			try
			{
				if (myInitThread != null)
				{
					myInitThread.Abort();
				}
				tvwKB.Nodes.Clear();
				tvwKB.Nodes.Add("正在加载数据,请稍候...");
				strIECookie = strCookie;
				strServerPage = strPage;
				strDocumentID = strID;
				strUserName = vUserName;
				if (txtEMR.InitForIE(strCookie, strPage, strID, vUserName))
				{
					myInitThread = new Thread(EMRInit);
					myInitThread.IsBackground = true;
					myTimer.Start();
					myInitThread.Start();
				}
				txtEMR.CallOnResize();
				txtEMR.EMRDoc.SaveLogs.CurrentSaveLog.UserName = strUserName;
				txtEMR.EMRDoc.SaveLogs.CurrentSaveLog.Level = intUserLevel;
				txtEMR.EMRDoc.Content.UserLevel = intUserLevel;
				return true;
			}
			catch (Exception)
			{
			}
			return false;
		}

		private void EMRInit()
		{
			try
			{
				if (!ZYKBBuffer.Instance.Loading)
				{
					object[] array = new object[2];
					object[] args = array;
					BeginInvoke(new EventHandler(RefreshKBTreeView), args);
				}
			}
			catch (Exception sourceException)
			{
				ZYErrorReport.Instance.SourceException = sourceException;
				ZYErrorReport.Instance.UserMessage = "加载报告知识库错误";
				ZYErrorReport.Instance.MemberName = "ZYEditPanel.EMRInit";
				ZYErrorReport.Instance.ShowErrorDialog();
			}
		}

		private void OpenDB()
		{
			txtEMR.EMRDoc.DataSource.DBConn.Open();
		}

		public void RefreshKBTreeView(object obj, EventArgs e)
		{
			if (myInitThread != null)
			{
				myInitThread = null;
			}
			LoadAllData();
			tvwKB.RootKBList = ZYKBBuffer.Instance.RootList;
			tvwKB.KBBuffer = ZYKBBuffer.Instance;
			tvwKB.ShowKBItem = true;
			tvwKB.ShowTemplateKBItem = true;
			tvwKB.DesignKBMode = true;
			tvwKB.AllowDrop = true;
			tvwKB.ResetContent();
			tvwKB.EnableClickEvent = true;
			LoadALLdataYS();
		}

		public bool LoadXMLFile(string strURL)
		{
			return txtEMR.LoadXMLFile(strURL);
		}

		public bool LoadBase64XML(string strXML)
		{
			return txtEMR.LoadBase64XML(strXML);
		}

		public bool LoadXML(string strXML)
		{
			if (ZYPublic.PatientInfo != null)
			{
				for (int i = 0; i < ZYPublic.PatientInfo.DocumentElement.ChildNodes.Count; i++)
				{
					strXML = strXML.Replace("#" + ZYPublic.PatientInfo.DocumentElement.ChildNodes[i].Name + "#", ZYPublic.PatientInfo.DocumentElement.ChildNodes[i].InnerText.Trim());
				}
			}
			if (txtEMR.LoadXML(strXML))
			{
				txtEMR.EMRDoc.SaveLogs.CurrentSaveLog.Level = intUserLevel;
				return true;
			}
			return false;
		}

		public string ToBase64XML()
		{
			return txtEMR.ToBase64XML();
		}

		public string ToBase64XML2()
		{
			return txtEMR.ToBase64XML2();
		}

		public string ToBase64EMRXML()
		{
			return txtEMR.ToBase64EMRXML();
		}

		public string ToXMLString()
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.PreserveWhitespace = true;
			txtEMR.EMRDoc.ToXMLDocument(xmlDocument);
			return xmlDocument.DocumentElement.OuterXml;
		}

		public string GetFinalText()
		{
			return txtEMR.GetFinalText();
		}

		public object GetNameValueArray()
		{
			ZYErrorReport.Instance.DebugPrint("试图获得结构化数据");
			string[] elementKeyValueList = txtEMR.EMRDoc.GetElementKeyValueList();
			Collection collection = new Collection();
			if (elementKeyValueList != null && elementKeyValueList.Length > 0)
			{
				ZYErrorReport.Instance.DebugPrint("共获得 " + elementKeyValueList.Length + " 组结构化数据");
				string[] array = elementKeyValueList;
				foreach (string item in array)
				{
					collection.Add(item);
				}
			}
			else
			{
				ZYErrorReport.Instance.DebugPrint("未获得任何结构化数据");
			}
			return collection;
		}

		public bool HandleCommand(string CommandName, string Param1, string Param2, string Param3)
		{
			if (CommandName == "kblist")
			{
				if (tvwKB.Visible)
				{
					tvwKB.Visible = false;
					picDrag.Visible = false;
				}
				else
				{
					tvwKB.Visible = true;
					picDrag.Visible = true;
				}
				OnResize(null);
				return true;
			}
			if (CommandName == "mark")
			{
				txtEMR.EMRDoc._InsertLock();
				txtEMR.Refresh();
				return true;
			}
			return txtEMR.HandleCommand(CommandName, Param1, Param2, Param3);
		}

		public bool HandleCommandNoUI(string CommandName, string Param1, string Param2, string Param3)
		{
			return txtEMR.HandleCommandNoUI(CommandName, Param1, Param2, Param3);
		}

		protected override void OnResize(EventArgs e)
		{
			int height = base.ClientSize.Height;
			if (tvwKB.Visible)
			{
				tvwKB.Bounds = new Rectangle(0, 0, picDrag.Left, height);
				picDrag.Top = 0;
				picDrag.Height = base.ClientSize.Height;
				txtEMR.Bounds = new Rectangle(picDrag.Right, 0, base.ClientSize.Width - picDrag.Right, height);
			}
			else
			{
				txtEMR.Bounds = new Rectangle(0, 0, base.ClientSize.Width, height);
			}
		}

		private void picDrag_MouseDown(object sender, MouseEventArgs e)
		{
			bolDraging = true;
			intLastX = e.X;
			intLastY = e.Y;
			picDrag.Cursor = Cursors.VSplit;
		}

		private void picDrag_MouseMove(object sender, MouseEventArgs e)
		{
			if (bolDraging)
			{
				int num = picDrag.Left + e.X - intLastX;
				if (num < 60)
				{
					num = 60;
				}
				if (num > base.ClientSize.Width - 100)
				{
					num = base.ClientSize.Width - 100;
				}
				if (num < 0)
				{
					num = 0;
				}
				picDrag.Left = num;
				OnResize(null);
			}
		}

		private void picDrag_MouseUp(object sender, MouseEventArgs e)
		{
			bolDraging = false;
			picDrag.Cursor = Cursors.SizeWE;
		}

		protected override bool IsInputKey(Keys keyData)
		{
			return true;
		}

		protected override bool IsInputChar(char charCode)
		{
			return true;
		}

		private void EMREditPanel_GotFocus(object sender, EventArgs e)
		{
			txtEMR.Select();
		}

		private void myTimer_Tick(object sender, EventArgs e)
		{
		}

		public bool LoadHFinfo(string strHead, string strFoot, int intHead, int intFoot)
		{
			Document.HeadHeight = (int)MeasureConvert.MillimeterToDocument(Convert.ToDouble(intHead));
			Document.HeadString = strHead;
			Document.FooterHeight = (int)MeasureConvert.MillimeterToDocument(Convert.ToDouble(intFoot));
			Document.FooterString = strFoot;
			Document.RefreshLine();
			return true;
		}

		public void InsertReportImage(string ImageURL, string ImageInfo)
		{
			string[] array = ImageURL.Split('|');
			string[] array2 = ImageInfo.Split('|');
			for (int i = 0; i < array.Length && array[i] != ""; i++)
			{
				object elementById = Document.GetElementById("reportimage_" + (i + 1));
				if (elementById != null && elementById is ZYTextImage)
				{
					((ZYTextImage)elementById).Src = array[i];
					((ZYTextImage)elementById).Width = 241;
					((ZYTextImage)elementById).Height = 199;
					((ZYTextImage)elementById).LoadImage();
					((ZYTextImage)elementById).CanResize = false;
					((ZYTextImage)elementById).SaveInFile = true;
				}
			}
		}

		public bool InitDbConn(string conn)
		{
			return txtEMR.InitDbConn(conn);
		}

		public bool HandleAutoScrollMove(string scrollType, int moveLength)
		{
			return txtEMR.HandleAutoScrollMove(scrollType, moveLength);
		}
	}
}
