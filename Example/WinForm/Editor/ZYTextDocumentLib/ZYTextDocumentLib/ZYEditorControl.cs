using System;
using System.Collections;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using XDesignerCommon;
using XDesignerGUI;
using XDesignerPrinting;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ZYEditorControl : ZYViewControl, ICloneable
	{
		private class ZYActionMenuItem : MenuItem
		{
			private ZYEditorAction myAction = null;

			public ZYEditorAction Action
			{
				get
				{
					return myAction;
				}
				set
				{
					myAction = value;
					UpdateAction();
				}
			}

			public void UpdateAction()
			{
				if (myAction == null)
				{
					base.Text = "-";
					return;
				}
				base.Enabled = myAction.isEnable();
				if (myAction.CheckState() == 1)
				{
					base.Checked = true;
				}
				else
				{
					base.Checked = false;
				}
			}

			public ZYActionMenuItem(ZYEditorAction a, string strText)
			{
				Action = a;
				base.Text = strText;
			}

			protected override void OnClick(EventArgs e)
			{
				if (myAction != null && myAction.isEnable())
				{
					myAction.Param1 = (base.Checked ? "0" : "1");
					myAction.UIExecute();
				}
				else
				{
					base.OnClick(e);
				}
			}
		}

		internal class SmartTagMenuItem : MenuItem
		{
			private SmartTagItem myItem = null;

			public SmartTagItem Item
			{
				set
				{
					if (value != null)
					{
						myItem = value;
						base.Text = value.Text;
						base.Checked = value.Checked;
					}
				}
			}

			protected override void OnClick(EventArgs e)
			{
				if (myItem != null && myItem.Provider != null)
				{
					myItem.Provider.HandleCommand(myItem);
				}
			}

			public SmartTagMenuItem(SmartTagItem vItem)
			{
				Item = vItem;
			}
		}

		protected ZYTextDocument myEMRDoc = null;

		private ImageList myImageList;

		private ContextMenu myPopupMenu;

		public bool RunInDesigner = false;

		public ZYKBTreeView KBTreeView = null;

		private string strKBBufferFile = null;

		protected ZYKBPopupList myKBPopupList = null;

		private string strCurrentID = null;

		private string strCurrentUserName = null;

		private int intUserLevel = 0;

		private int OldImageIndex;

		private string OldToolTip;

		private int OldToolTipX;

		private int OldToolTipY;

		private ArrayList mySmartTagProviderList;

		private ContextMenu myTagMenu;

		public ImageList ImageList => myImageList;

		public ZYTextDocument EMRDoc
		{
			get
			{
				return myEMRDoc;
			}
			set
			{
				myEMRDoc = value;
			}
		}

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

		public ZYKBPopupList KBPopupList => myKBPopupList;

		protected override ImeMode DefaultImeMode
		{
			get
			{
				if (myKBPopupList != null && myKBPopupList.Visible)
				{
					return ImeMode.Off;
				}
				return base.DefaultImeMode;
			}
		}

		public ArrayList SmartTagProviderList => mySmartTagProviderList;

		public event EventHandler ContentChanged;

		public void GetInterfacceSafyOptions(int riid, out int pdwSupportedOptions, out int pdwEnabledOptions)
		{
			pdwSupportedOptions = 1;
			pdwEnabledOptions = 2;
		}

		public void SetInterfaceSafetyOptions(int riid, int dwOptionsSetMask, int dwEnabledOptions)
		{
		}

		public ZYEditorControl()
		{
			SetStyle(ControlStyles.DoubleBuffer, value: true);
			SetStyle(ControlStyles.UserPaint, value: true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			base.GraphicsUnit = GraphicsUnit.Document;
			BackColor = SystemColors.AppWorkspace;
			try
			{
				myImageList = ZYKBTreeView.GetKBImageList();
				myEMRDoc = new ZYTextDocument();
				myEMRDoc.OwnerControl = this;
				myEMRDoc.OnContentChanged += OnContentChanged;
				myDocument = myEMRDoc;
				lblInfo.Font = myEMRDoc.View.DefaultFont;
				ArrayList arrayList = new ArrayList
				{
					new ZYActionMenuItem(myEMRDoc.GetActionByName("undo"), "&U  撤销"),
					new ZYActionMenuItem(myEMRDoc.GetActionByName("redo"), "&R  重复"),
					new ZYActionMenuItem(null, null),
					new ZYActionMenuItem(myEMRDoc.GetActionByName("cut"), "&T  剪切"),
					new ZYActionMenuItem(myEMRDoc.GetActionByName("copy"), "&C  复制"),
					new ZYActionMenuItem(myEMRDoc.GetActionByName("paste"), "&P  粘贴"),
					new ZYActionMenuItem(myEMRDoc.GetActionByName("delete"), "&D  删除"),
					new ZYActionMenuItem(null, null),
					new ZYActionMenuItem(myEMRDoc.GetActionByName("insertimage"), "&I  插入图片"),
					new ZYActionMenuItem(myEMRDoc.GetActionByName("insertgongshi"), "&G  插入公式")
				};
				myPopupMenu = new ContextMenu();
				myPopupMenu.MenuItems.AddRange((MenuItem[])arrayList.ToArray(typeof(MenuItem)));
				ContextMenu = myPopupMenu;
				myPopupMenu.Popup += myPopupMenu_Popup;
				InitSmartTagProvider();
				myEMRDoc.InitEMRVBEngine();
				Cursor = Cursors.IBeam;
				myEMRDoc.RefreshSize();
				myEMRDoc.RefreshLine();
			}
			catch (Exception sourceException)
			{
				ZYErrorReport.Instance.UserMessage = "加载报告编辑器错误";
				ZYErrorReport.Instance.SourceException = sourceException;
				ZYErrorReport.Instance.SourceObject = this;
				ZYErrorReport.Instance.ShowErrorDialog();
			}
		}

		public void BindKBTreeView(ZYKBTreeView tvw)
		{
			if (tvw != null)
			{
				KBTreeView = tvw;
				KBTreeView.DesignKBMode = false;
				KBTreeView.EnableClickEvent = true;
				KBTreeView.DoubleClickMode = true;
				KBTreeView.KBItemClick += KBTreeView_KBItemClick;
				KBTreeView.KBListClick += KBTreeView_KBListClick;
			}
		}

		internal void InitEventObject(ZYVBEventObject myEventObj)
		{
			if (myEventObj != null)
			{
				myEventObj.AltKey = CommonFunction.GetIntAttribute((int)Control.ModifierKeys, 262144);
				myEventObj.CtlKey = CommonFunction.GetIntAttribute((int)Control.ModifierKeys, 17);
				myEventObj.ShiftKey = CommonFunction.GetIntAttribute((int)Control.ModifierKeys, 16);
				myEventObj.ScreenX = Control.MousePosition.X;
				myEventObj.ScreenY = Control.MousePosition.Y;
				myEventObj.MouseButton = (CommonFunction.GetIntAttribute((int)Control.MouseButtons, 1048576) ? 1 : 2);
				myEventObj.ReturnValue = null;
				myEventObj.Cancel = false;
				Point point = PointToClient(Control.MousePosition);
				myEventObj.ClientX = point.X;
				myEventObj.ClientY = point.Y;
				point = ClientPointToView(point.X, point.Y);
				myEventObj.X = point.X;
				myEventObj.Y = point.Y;
				myEventObj.CancelBubble = true;
			}
		}

		private void OnContentChanged(object sender, EventArgs e)
		{
			if (this.ContentChanged != null)
			{
				this.ContentChanged(sender, e);
			}
		}

		public bool LoadXML(string strXML)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.PreserveWhitespace = true;
			myEMRDoc.BeginUpdate();
			myEMRDoc.ClearContent();
			xmlDocument.LoadXml(strXML);
			myEMRDoc.FromXML(xmlDocument.DocumentElement);
			myEMRDoc.RefreshSize();
			myEMRDoc.ContentChanged();
			myEMRDoc.EndUpdate();
			myEMRDoc.Modified = false;
			Refresh();
			return true;
		}

		public bool LoadXMLFile(string strURL)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.PreserveWhitespace = true;
			myEMRDoc.BeginUpdate();
			myEMRDoc.ClearContent();
			xmlDocument.Load(strURL);
			myEMRDoc.FromXML(xmlDocument.DocumentElement);
			myEMRDoc.RefreshSize();
			myEMRDoc.ContentChanged();
			myEMRDoc.EndUpdate();
			myEMRDoc.Modified = false;
			Refresh();
			return true;
		}

		public string ToBase64XML()
		{
			XmlDocument xmlDocument = new XmlDocument();
			myEMRDoc.Info.SaveMode = 0;
			myEMRDoc.ToXMLDocument(xmlDocument);
			string outerXml = xmlDocument.DocumentElement.OuterXml;
			return StringCommon.ToBase64String(outerXml);
		}

		public string ToBase64XML2()
		{
			XmlDocument xmlDocument = new XmlDocument();
			myEMRDoc.Info.SaveMode = 2;
			myEMRDoc.ToXMLDocument(xmlDocument);
			return StringCommon.ToBase64String(XMLCommon.CreateChildElement(xmlDocument.DocumentElement, "body", bolCreate: false).OuterXml);
		}

		public string ToBase64EMRXML()
		{
			XmlDocument xmlDocument = new XmlDocument();
			myEMRDoc.Info.SaveMode = 3;
			myEMRDoc.ToXMLDocument(xmlDocument);
			return StringCommon.ToBase64String(xmlDocument.DocumentElement.OuterXml);
		}

		public bool LoadKBFromBuffer(string strKBBufferFile)
		{
			if (StringCommon.isBlankString(strKBBufferFile))
			{
				strKBBufferFile = Application.StartupPath + "\\kbbuffer.xml";
			}
			try
			{
				if (File.Exists(strKBBufferFile))
				{
					DateTime lastAccessTime = File.GetLastAccessTime(strKBBufferFile);
					if (ZYTime.GetServerTime().Subtract(lastAccessTime).TotalHours < 12.0)
					{
						XmlDocument xmlDocument = new XmlDocument();
						xmlDocument.Load(strKBBufferFile);
						ZYKBBuffer.Instance.LoadAllKBList(xmlDocument.DocumentElement, FixListIndex: false);
						return true;
					}
				}
			}
			catch
			{
			}
			return false;
		}

		public ZYEditorAction GetActionByName(string strName)
		{
			return myEMRDoc.GetActionByName(strName);
		}

		public bool LoadKBFromDataBase()
		{
			strKBBufferFile = Application.StartupPath + "\\kbbuffer.xml";
			ZYKBBuffer.Instance.LoadAllKBList(FixListIndex: false);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml("<kb />");
			xmlDocument.Save(strKBBufferFile);
			return true;
		}

		public bool InitForIE(string strCookie, string strPage, string strID, string strUserName)
		{
			try
			{
				ZYKBBuffer.Instance.Connection = myEMRDoc.DataSource.DBConn;
				bolRunInIE = true;
				strCurrentID = strID;
				strCurrentUserName = strUserName;
				SqlConnection sqlConnection = new SqlConnection();
				sqlConnection.ConnectionString = strPage;
				sqlConnection.Open();
				myEMRDoc.DataSource.DBConn.Connection = sqlConnection;
				myEMRDoc.DataSource.DBConn.AutoOpen = false;
				myEMRDoc.Info.ID = strID;
				myEMRDoc.Info.ShowPageLine = false;
				myEMRDoc.SaveLogs.CurrentUserName = strUserName;
				ZYConfig.InitConfig(myDocument.DataSource.DBConn.Connection);
				ZYConfig.InitModalityConfig(myDocument.DataSource.DBConn.Connection, ZYPublic.ModalityName);
				ZYFont.InitFont(ZYConfig.FontName, ZYConfig.FontSize);
				base.Document.View.DefaultFont = new Font(ZYConfig.FontName, ZYConfig.FontSize, FontStyle.Regular);
				base.Document.Info.LineSpacing = ZYConfig.LineSpacing;
				base.Document.Info.ParagraphSpacing = ZYConfig.ParagraphSpacing;
				Refresh();
				if (ZYConfig.InitPaperSetting(ZYPublic.ModalityName, myDocument.DataSource.DBConn.Connection))
				{
					myDocument.Pages.PageSettings = new XPageSettings();
					myDocument.RefreshLine();
					myDocument.RefreshPages();
					myDocument.OwnerControl.UpdatePages();
					myDocument.Refresh();
				}
				return true;
			}
			catch
			{
			}
			return false;
		}

		public void CallOnResize()
		{
			OnResize(null);
		}

		protected override void OnViewPaint(PaintEventArgs e, SimpleRectangleTransform trans)
		{
			if (!base.Updating)
			{
				myEMRDoc.PageIndex = trans.PageIndex;
				if (trans.Flag2 == 0)
				{
					myEMRDoc.DrawHead(e.Graphics, trans.DescRect);
				}
				else if (trans.Flag2 == 1)
				{
					myEMRDoc.DrawDocument(e.Graphics, e.ClipRectangle);
				}
				else if (trans.Flag2 == 2)
				{
					myEMRDoc.DrawFooter(e.Graphics, trans.DescRect);
				}
			}
		}

		public override void UpdatePages()
		{
			base.UpdatePages();
			foreach (SimpleRectangleTransform item in base.PagesTransform)
			{
				item.Enable = (item.Flag2 == 1);
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (base.DesignMode)
			{
				using (StringFormat stringFormat = new StringFormat())
				{
					e.Graphics.Clear(SystemColors.AppWorkspace);
					stringFormat.Alignment = StringAlignment.Center;
					stringFormat.LineAlignment = StringAlignment.Center;
					e.Graphics.DrawString(base.Name + Environment.NewLine + GetType().Name, Control.DefaultFont, Brushes.Red, new RectangleF(0f, 0f, base.ClientSize.Width, base.ClientSize.Height), stringFormat);
				}
				return;
			}
			base.OnPaint(e);
			if (myEMRDoc.EnableJumpPrint && myEMRDoc.JumpPrintPosition > 0)
			{
				DrawJumpPrintArea(e.Graphics, e.ClipRectangle, myEMRDoc.JumpPrintPosition, Color.FromArgb(90, 0, 0, 255));
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (e.Button == MouseButtons.Right)
			{
				PopupSmartTag(e.X, e.Y);
			}
			if (e.Button != MouseButtons.Left || !myEMRDoc.EnableJumpPrint)
			{
				return;
			}
			int jumpPrintPosition = GetJumpPrintPosition(e.X, e.Y);
			if (jumpPrintPosition >= 0)
			{
				jumpPrintPosition = myEMRDoc.FixPageLine(jumpPrintPosition);
				if (jumpPrintPosition > 0 && myEMRDoc.JumpPrintPosition != jumpPrintPosition)
				{
					myEMRDoc.JumpPrintPosition = jumpPrintPosition;
					Refresh();
				}
			}
		}

		protected override void OnResize(EventArgs e)
		{
			if (!StackTraceHelper.CheckRecursion())
			{
				base.OnResize(e);
				UpdateTextCaret();
			}
		}

		public bool LoadBase64XML(string strXML)
		{
			bool flag = true;
			try
			{
				if (StringCommon.isBlankString(strXML))
				{
					myEMRDoc.ClearContent();
				}
				else
				{
					string strXML2 = StringCommon.FromBase64String(strXML);
					flag = LoadXML(strXML2);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				flag = false;
			}
			if (flag)
			{
				myEMRDoc.Info.ID = strCurrentID;
				myEMRDoc.SaveLogs.CurrentUserName = strCurrentUserName;
				if (myEMRDoc.Marks.Count > 0)
				{
					myEMRDoc.Info.ShowAll = true;
					myEMRDoc.Info.ShowMark = true;
					myEMRDoc.Info.LogicDelete = true;
					myEMRDoc.RefreshElements();
					myEMRDoc.RefreshLine();
					myEMRDoc.UpdateView();
				}
			}
			return flag;
		}

		public string GetFinalText()
		{
			return myEMRDoc.GetFinalText();
		}

		public bool HandleCommandNoUI(string CommandName, string Param1, string Param2, string Param3)
		{
			ZYErrorReport.Instance.DebugPrint("执行HandleCommandNoUI[" + CommandName + "]参数1:" + Param1 + " 参数2:" + Param2 + " 参数3:" + Param3);
			foreach (ZYEditorAction action in myEMRDoc.Actions)
			{
				if (action.ActionName() == CommandName && action.isEnable())
				{
					action.Param1 = Param1;
					action.Param2 = Param2;
					action.Param3 = Param3;
					return action.Execute();
				}
			}
			ZYErrorReport.Instance.DebugPrint("未找到方法[" + CommandName + "]");
			return false;
		}

		public bool HandleCommand(string CommandName, string Param1, string Param2, string Param3)
		{
			ZYErrorReport.Instance.DebugPrint("执行HandleCommand[" + CommandName + "]参数1:" + Param1 + " 参数2:" + Param2 + " 参数3:" + Param3);
			foreach (ZYEditorAction action in myEMRDoc.Actions)
			{
				if (action.ActionName() == CommandName && action.isEnable())
				{
					action.Param1 = Param1;
					action.Param2 = Param2;
					action.Param3 = Param3;
					return action.UIExecute();
				}
			}
			ZYErrorReport.Instance.DebugPrint("未找到方法[" + CommandName + "]");
			return false;
		}

		protected override bool InitPopupList()
		{
			if (myPopupList == null)
			{
				myKBPopupList = new ZYKBPopupList();
				myKBPopupList.Clear();
				myKBPopupList.AutoClose = true;
				myKBPopupList.OwnerEditor = this;
				myPopupList = myKBPopupList;
			}
			return true;
		}

		public void ShowInnerToolTip(int imgIndex, string strText, int x, int y, int height)
		{
			if (imgIndex != OldImageIndex || OldToolTip != strText || OldToolTipX != x || OldToolTipY != y || !lblInfo.Visible)
			{
				OldImageIndex = imgIndex;
				OldToolTip = strText;
				OldToolTipX = x;
				OldToolTipY = y;
				ShowInnerToolTip((imgIndex >= 0 && imgIndex < myImageList.Images.Count) ? myImageList.Images[imgIndex] : null, strText, x, y, height);
			}
		}

		public void InitKBPopupList()
		{
			if (myKBPopupList == null)
			{
				myKBPopupList = new ZYKBPopupList();
				myKBPopupList.AutoClose = true;
				myKBPopupList.OwnerEditor = this;
				myKBPopupList.OwnerDocument = myEMRDoc;
				myKBPopupList.ImageList = myImageList;
				myPopupList = myKBPopupList;
				myKBPopupList.AutoClose = false;
			}
			myKBPopupList.Title = "";
			myKBPopupList.CompositionRect = Rectangle.Empty;
		}

		public object ShowKBPopupList(ZYTextElement myElement, ArrayList myKBList, string strTitle, bool MultiSelect, bool MustKBItem)
		{
			InitKBPopupList();
			SetPopupPos(myElement.RealLeft, myElement.RealTop, myElement.Height);
			myKBPopupList.SetKBList(strTitle, myKBList);
			myKBPopupList.Show();
			Focus();
			myKBPopupList.SelectedIndex = 0;
			myKBPopupList.MultiSelect = false;
			base.ImeMode = ImeMode.Disable;
			object result = null;
			if (MustKBItem)
			{
				result = myKBPopupList.WaitForUserSelectKBItem(MultiSelect);
			}
			else
			{
				if (myKBPopupList.WaitUserSelected())
				{
					result = myKBPopupList.SelectedObject;
				}
				myKBPopupList.CloseList();
			}
			base.ImeMode = ImeMode.On;
			return result;
		}

		public object ShowKBPopupList(ZYTextElement myElement)
		{
			bolCaptureMouse = false;
			bool multiSelect = false;
			InitKBPopupList();
			SetPopupPos(myElement.RealLeft, myElement.RealTop, myElement.Height);
			ZYTextSelect zYTextSelect = myElement as ZYTextSelect;
			if (zYTextSelect == null)
			{
				myKBPopupList.SetKBList((string)null);
			}
			else
			{
				myKBPopupList.FirstKBSEQ = zYTextSelect.ListSource;
				multiSelect = zYTextSelect.Multiple;
				myKBPopupList.MultiSelect = zYTextSelect.Multiple;
				if (zYTextSelect.HasOptions())
				{
					myKBPopupList.SetKBList("", zYTextSelect.Options);
				}
				else if (zYTextSelect.OwnerKBList != null)
				{
					myKBPopupList.SetKBList(zYTextSelect.OwnerKBList);
				}
				else
				{
					myKBPopupList.SetKBList(zYTextSelect.ListSource);
				}
				myKBPopupList.SelectedText = zYTextSelect.Text;
				if (StringCommon.isBlankString(zYTextSelect.Name))
				{
					myKBPopupList.Title = "[知识点]";
				}
				else
				{
					myKBPopupList.Title = "[" + zYTextSelect.Name + "]";
				}
			}
			myKBPopupList.AutoClose = false;
			myKBPopupList.Show();
			Focus();
			base.ImeMode = ImeMode.Disable;
			if (zYTextSelect != null)
			{
				myKBPopupList.SelectedText = zYTextSelect.Text;
				myKBPopupList.SelectedStateChanged = zYTextSelect.GetSelectedStateChangedHandler();
				myKBPopupList.PopupSelection();
			}
			if (FindForm() != null)
			{
				FindForm().Activate();
			}
			object result = null;
			while (myKBPopupList.WaitUserSelected())
			{
				if (myKBPopupList.MultiSelect)
				{
					result = myKBPopupList.SelectedObjects;
					break;
				}
				ZYPopupList.ListItem selectedItem = myKBPopupList.SelectedItem;
				if (selectedItem != null)
				{
					if (!(selectedItem.obj is KB_List))
					{
						result = selectedItem.obj;
						break;
					}
					myKBPopupList.MultiSelect = multiSelect;
					myKBPopupList.SetKBList((selectedItem.obj as KB_List).SEQ);
				}
			}
			if (myKBPopupList != null)
			{
				myKBPopupList.CloseList();
			}
			base.ImeMode = ImeMode.On;
			return result;
		}

		protected override void Dispose(bool disposing)
		{
			try
			{
				if (myTagMenu != null)
				{
					myTagMenu.Dispose();
					myTagMenu = null;
				}
				if (myKBPopupList != null)
				{
					myKBPopupList.Dispose();
					myKBPopupList = null;
				}
				if (myPopupMenu != null)
				{
					myPopupMenu.Dispose();
					myPopupMenu = null;
				}
				if (myImageList != null)
				{
					myImageList.Dispose();
					myImageList = null;
				}
				base.Dispose(disposing);
				if (myEMRDoc != null)
				{
					myEMRDoc.Dispose();
					myEMRDoc = null;
				}
			}
			catch
			{
			}
		}

		private void myPopupMenu_Popup(object sender, EventArgs e)
		{
			foreach (ZYActionMenuItem menuItem in myPopupMenu.MenuItems)
			{
				menuItem.UpdateAction();
			}
		}

		public ZYTextElement GetElementByPos(int x, int y)
		{
			if (myTransform.ContainsSourcePoint(x, y))
			{
				Point point = myTransform.TransformPoint(x, y);
				if (!point.IsEmpty)
				{
					return myEMRDoc.GetElementByPos(point.X, point.Y);
				}
			}
			return null;
		}

		protected override void OnGotFocus(EventArgs e)
		{
			if (Focused)
			{
				bolMoveCaretWithScroll = false;
				UpdateTextCaret();
				bolMoveCaretWithScroll = true;
				base.OnGotFocus(e);
			}
		}

		public void UpdateTextCaret(ZYTextElement myElement)
		{
			if (myElement == null)
			{
				return;
			}
			if (myEMRDoc.Content.LineEndFlag)
			{
				myElement = myEMRDoc.Content.PreElement;
				if (myElement != null)
				{
					MoveTextCaretTo(myElement.Bounds.Right, myElement.Bounds.Bottom, myElement.Height);
				}
			}
			else
			{
				MoveTextCaretTo(myElement.Bounds.Left, myElement.Bounds.Bottom, myElement.Height);
			}
		}

		public void UpdateTextCaret()
		{
			ZYTextElement currentElement = myEMRDoc.Content.CurrentElement;
			if (currentElement == null)
			{
				return;
			}
			if (myEMRDoc.Content.LineEndFlag)
			{
				currentElement = myEMRDoc.Content.PreElement;
				if (currentElement != null)
				{
					MoveTextCaretTo(currentElement.RealLeft + currentElement.Width, currentElement.RealTop + currentElement.Height, currentElement.Height);
				}
			}
			else
			{
				MoveTextCaretTo(currentElement.RealLeft, currentElement.RealTop + currentElement.Height, currentElement.Height);
			}
		}

		protected override bool OnStartDrag(int x, int y)
		{
			return false;
		}

		private bool CanDrag(DragEventArgs drgevent)
		{
			if (drgevent.Data.GetData(typeof(string)) is string)
			{
				return true;
			}
			if (drgevent.Data.GetData(typeof(KB_List)) is KB_List)
			{
				return true;
			}
			if (drgevent.Data.GetData(typeof(KB_Item)) is KB_Item)
			{
				return true;
			}
			if (drgevent.Data.GetData(typeof(ArrayList)) is ArrayList)
			{
				return true;
			}
			return false;
		}

		protected override void OnDragDrop(DragEventArgs drgevent)
		{
			string text = drgevent.Data.GetData(typeof(string)) as string;
			if (!StringCommon.isBlankString(text))
			{
				A_InsertString a_InsertString = new A_InsertString();
				a_InsertString.OwnerDocument = myEMRDoc;
				if (a_InsertString.isEnable())
				{
					a_InsertString.Param1 = text;
					a_InsertString.Execute();
					UpdateTextCaret();
				}
				return;
			}
			KB_List kB_List = drgevent.Data.GetData(typeof(KB_List)) as KB_List;
			if (kB_List != null)
			{
				A_InsertKB a_InsertKB = new A_InsertKB();
				a_InsertKB.OwnerDocument = myEMRDoc;
				if (a_InsertKB.isEnable())
				{
					myEMRDoc._InsertKB(kB_List);
					UpdateTextCaret();
				}
				return;
			}
			KB_Item kB_Item = drgevent.Data.GetData(typeof(KB_Item)) as KB_Item;
			if (kB_Item != null)
			{
				if (kB_Item.isTemplate())
				{
					if (RunInDesigner)
					{
						A_InsertKeyWord a_InsertKeyWord = new A_InsertKeyWord();
						a_InsertKeyWord.OwnerDocument = myEMRDoc;
						a_InsertKeyWord.Param1 = kB_Item.ItemSEQ.ToString();
						if (a_InsertKeyWord.isEnable())
						{
							a_InsertKeyWord.Execute();
						}
					}
					else
					{
						myEMRDoc._InsertDocument(kB_Item.ItemValue);
					}
				}
				else if (myEMRDoc.CanModify())
				{
					ZYTextSelect zYTextSelect = new ZYTextSelect();
					zYTextSelect.OwnerKBList = kB_Item.OwnerList;
					zYTextSelect.Text = kB_Item.ItemText;
					zYTextSelect.Value = kB_Item.ItemValue;
					myEMRDoc._InsertElement(zYTextSelect);
				}
				UpdateTextCaret();
				return;
			}
			ArrayList arrayList = drgevent.Data.GetData(typeof(ArrayList)) as ArrayList;
			if (arrayList != null && myEMRDoc.CanModify())
			{
				for (int i = 0; i < arrayList.Count; i++)
				{
					KB_List kB_List2 = arrayList[i] as KB_List;
					if (kB_List2 != null)
					{
						A_InsertKB a_InsertKB = new A_InsertKB();
						a_InsertKB.OwnerDocument = myEMRDoc;
						if (a_InsertKB.isEnable())
						{
							myEMRDoc._InsertKB(kB_List2);
						}
						UpdateTextCaret();
						return;
					}
					KB_Item kB_Item2 = arrayList[i] as KB_Item;
					if (kB_Item2 == null)
					{
						continue;
					}
					if (kB_Item2.isTemplate())
					{
						if (RunInDesigner)
						{
							A_InsertKeyWord a_InsertKeyWord = new A_InsertKeyWord();
							a_InsertKeyWord.OwnerDocument = myEMRDoc;
							a_InsertKeyWord.Param1 = kB_Item2.ItemSEQ.ToString();
							if (a_InsertKeyWord.isEnable())
							{
								a_InsertKeyWord.Execute();
							}
						}
						else
						{
							myEMRDoc._InsertDocument(kB_Item2.ItemValue);
						}
					}
					else
					{
						ZYTextSelect zYTextSelect = new ZYTextSelect();
						zYTextSelect.OwnerKBList = kB_Item2.OwnerList;
						zYTextSelect.Text = kB_Item2.ItemText;
						zYTextSelect.Value = kB_Item2.ItemValue;
						myEMRDoc._InsertElement(zYTextSelect);
					}
				}
				UpdateTextCaret();
			}
			else
			{
				base.OnDragDrop(drgevent);
			}
		}

		protected override void OnDragEnter(DragEventArgs drgevent)
		{
			if (CanDrag(drgevent))
			{
				drgevent.Effect = DragDropEffects.Copy;
			}
			base.OnDragEnter(drgevent);
		}

		protected override void OnDragOver(DragEventArgs drgevent)
		{
			if (CanDrag(drgevent))
			{
				Point p = new Point(drgevent.X, drgevent.Y);
				p = PointToClient(p);
				base.PagesTransform.UseAbsTransformPoint = true;
				p = ClientPointToView(p.X, p.Y);
				base.PagesTransform.UseAbsTransformPoint = false;
				myEMRDoc.Content.AutoClearSelection = true;
				base.ForceShowCaret = true;
				myEMRDoc.Content.MoveTo(p.X, p.Y);
				base.ForceShowCaret = false;
			}
			base.OnDragOver(drgevent);
		}

		private void InitSmartTagProvider()
		{
			myTagMenu = new ContextMenu();
			mySmartTagProviderList = new ArrayList();
			mySmartTagProviderList.Add(new ImageTagProvider());
			mySmartTagProviderList.Add(new KBTagProvider());
			mySmartTagProviderList.Add(new InputTagProvider());
			mySmartTagProviderList.Add(new DivTagProvider());
			mySmartTagProviderList.Add(new HRuleTagProvider());
			mySmartTagProviderList.Add(new TextFlagProvider());
			mySmartTagProviderList.Add(new TableTagProvider());
			foreach (SmartTagProvider mySmartTagProvider in mySmartTagProviderList)
			{
				mySmartTagProvider.OwnerControl = this;
				mySmartTagProvider.OwnerDocument = myEMRDoc;
			}
		}

		internal SmartTagProvider GetSmartTagProvider(ZYTextElement myElement)
		{
			if (myElement == null)
			{
				return null;
			}
			if (!myEMRDoc.Loading && myElement != null && !myElement.Deleteted && !myElement.Parent.Locked)
			{
				foreach (SmartTagProvider mySmartTagProvider in mySmartTagProviderList)
				{
					mySmartTagProvider.Element = myElement;
					if (mySmartTagProvider.isEnable())
					{
						return mySmartTagProvider;
					}
				}
				if (myElement.Parent != null)
				{
					foreach (SmartTagProvider mySmartTagProvider2 in mySmartTagProviderList)
					{
						mySmartTagProvider2.Element = myElement.Parent;
						if (mySmartTagProvider2.isEnable())
						{
							return mySmartTagProvider2;
						}
					}
				}
			}
			return null;
		}

		private bool PopupSmartTag(int x, int y)
		{
			if (base.ShowingPopupList)
			{
				HidePopupList();
			}
			ZYTextElement zYTextElement = GetElementByPos(x, y);
			ZYTextElement zYTextElement2 = null;
			if (zYTextElement == null)
			{
				return false;
			}
			if (myDocument.IsLock(zYTextElement))
			{
				return false;
			}
			if (!(zYTextElement is ZYTextImage) && !(zYTextElement is ZYTextFlag) && zYTextElement.Parent is EMRCell)
			{
				zYTextElement2 = zYTextElement.Parent;
				zYTextElement = (zYTextElement.Parent.Parent.Parent as EMRTable);
			}
			SmartTagProvider smartTagProvider = GetSmartTagProvider(zYTextElement);
			if (smartTagProvider != null)
			{
				if (smartTagProvider is DivTagProvider)
				{
					ArrayList arrayList = new ArrayList();
					smartTagProvider.GetCommands(arrayList);
					if (arrayList.Count > 0)
					{
						myTagMenu.MenuItems.Clear();
						MenuItem menuItem = new MenuItem("标题设置");
						foreach (SmartTagItem item in arrayList)
						{
							menuItem.MenuItems.Add(new SmartTagMenuItem(item));
						}
						myTagMenu.MenuItems.Add(new ZYActionMenuItem(myEMRDoc.GetActionByName("undo"), "&U  撤销"));
						myTagMenu.MenuItems.Add(new ZYActionMenuItem(myEMRDoc.GetActionByName("redo"), "&R  重复"));
						myTagMenu.MenuItems.Add("-");
						myTagMenu.MenuItems.Add(new ZYActionMenuItem(myEMRDoc.GetActionByName("cut"), "&T  剪切"));
						myTagMenu.MenuItems.Add(new ZYActionMenuItem(myEMRDoc.GetActionByName("copy"), "&C  复制"));
						myTagMenu.MenuItems.Add(new ZYActionMenuItem(myEMRDoc.GetActionByName("paste"), "&P  粘贴"));
						myTagMenu.MenuItems.Add(new ZYActionMenuItem(myEMRDoc.GetActionByName("delete"), "&D  删除"));
						myTagMenu.MenuItems.Add("-");
						if (ZYPublic.StandardMode && myDocument.Info.DesignMode)
						{
							myTagMenu.MenuItems.Add(menuItem);
						}
						myTagMenu.MenuItems.Add(new ZYActionMenuItem(myEMRDoc.GetActionByName("insertimage"), "&I  插入图片"));
						myTagMenu.MenuItems.Add(new ZYActionMenuItem(myEMRDoc.GetActionByName("insertgongshi"), "&G  插入公式"));
						if (ZYPublic.StandardMode && myDocument.Info.DesignMode)
						{
							myTagMenu.MenuItems.Add(new ZYActionMenuItem(myEMRDoc.GetActionByName("setflag"), "&M  设为必须内容(文本块)"));
						}
						myTagMenu.Show(this, new Point(x, y));
						return true;
					}
				}
				else
				{
					ArrayList arrayList = new ArrayList();
					smartTagProvider.GetCommands(arrayList);
					if (arrayList.Count > 0)
					{
						myTagMenu.MenuItems.Clear();
						foreach (SmartTagItem item2 in arrayList)
						{
							myTagMenu.MenuItems.Add(new SmartTagMenuItem(item2));
						}
						if (zYTextElement is EMRTable)
						{
							if (zYTextElement2 != null && myDocument.Info.DesignMode && ZYPublic.StandardMode)
							{
								SmartTagProvider smartTagProvider2 = GetSmartTagProvider(zYTextElement2);
								myTagMenu.MenuItems.Add(new SmartTagMenuItem(new SmartTagItem(smartTagProvider2, 13, "&M 设置单元格的标识")));
							}
							if (ZYPublic.StandardMode && myDocument.Info.DesignMode)
							{
								myTagMenu.MenuItems.Add(new ZYActionMenuItem(myEMRDoc.GetActionByName("setflag"), "&M  设为必须内容(文本块)"));
							}
						}
						myTagMenu.Show(this, new Point(x, y));
						return true;
					}
				}
			}
			return false;
		}

		private void KBTreeView_KBItemClick(TreeNode TreeNode, KB_Item SelectedItem)
		{
			if (SelectedItem.isTemplate())
			{
				myEMRDoc._InsertDocument(SelectedItem.ItemValue);
			}
		}

		private void KBTreeView_KBListClick(TreeNode TreeNode, KB_List SelectedList)
		{
			myEMRDoc._InsertKB(SelectedList);
		}

		public bool InitDbConn(string connStr)
		{
			bool flag = true;
			try
			{
				ZYKBBuffer.Instance.Connection = myEMRDoc.DataSource.DBConn;
				bolRunInIE = true;
				SqlConnection sqlConnection = new SqlConnection();
				sqlConnection.ConnectionString = connStr;
				myEMRDoc.DataSource.DBConn.Connection = sqlConnection;
				myEMRDoc.DataSource.DBConn.AutoOpen = false;
				myEMRDoc.Info.ShowPageLine = false;
				Refresh();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public object Clone()
		{
			ZYEditorControl zYEditorControl = new ZYEditorControl();
			zYEditorControl.bolAcceptsTab = bolAcceptsTab;
			zYEditorControl.bolCaptureMouse = bolCaptureMouse;
			zYEditorControl.bolCaretCreated = bolCaretCreated;
			zYEditorControl.bolEnableInsertMode = bolEnableInsertMode;
			zYEditorControl.bolForceShowCaret = bolForceShowCaret;
			zYEditorControl.bolInsertMode = bolInsertMode;
			zYEditorControl.bolLockingUI = bolLockingUI;
			zYEditorControl.bolMouseDragScroll = bolMouseDragScroll;
			zYEditorControl.bolMoveCaretWithScroll = bolMoveCaretWithScroll;
			zYEditorControl.bolRunInIE = bolRunInIE;
			zYEditorControl.bolScrolling = bolScrolling;
			zYEditorControl.bolWordWrap = bolWordWrap;
			zYEditorControl.EditorFlag = EditorFlag;
			zYEditorControl.fXZoomRate = fXZoomRate;
			zYEditorControl.fYZoomRate = fYZoomRate;
			zYEditorControl.intBorderStyle = intBorderStyle;
			zYEditorControl.intGraphicsUnit = intGraphicsUnit;
			zYEditorControl.intLastMouseDX = intLastMouseDX;
			zYEditorControl.intLastMouseDY = intLastMouseDY;
			zYEditorControl.intLastMouseX = intLastMouseX;
			zYEditorControl.intLastMouseY = intLastMouseY;
			zYEditorControl.intPageBackColor = intPageBackColor;
			zYEditorControl.intPageSpacing = intPageSpacing;
			zYEditorControl.intStartCaptureX = intStartCaptureX;
			zYEditorControl.intStartCaptureY = intStartCaptureY;
			zYEditorControl.intUserLevel = intUserLevel;
			zYEditorControl.intViewMode = intViewMode;
			zYEditorControl.KBTreeView = KBTreeView;
			zYEditorControl.LastMessageTick = LastMessageTick;
			zYEditorControl.lblInfo = lblInfo;
			zYEditorControl.myCaret = myCaret;
			zYEditorControl.myCurrentPage = myCurrentPage;
			zYEditorControl.myDefaultCursor = myDefaultCursor;
			zYEditorControl.myImageList = myImageList;
			zYEditorControl.myInvalidateRect = myInvalidateRect;
			zYEditorControl.myKBPopupList = myKBPopupList;
			zYEditorControl.myMouseDragPoint = myMouseDragPoint;
			zYEditorControl.myPages = myPages;
			zYEditorControl.myPopupList = myPopupList;
			zYEditorControl.myPopupMenu = myPopupMenu;
			zYEditorControl.mySavedScrollPos = mySavedScrollPos;
			zYEditorControl.mySmartTagProviderList = mySmartTagProviderList;
			zYEditorControl.myTagMenu = myTagMenu;
			zYEditorControl.myTimer = myTimer;
			return zYEditorControl;
		}

		public bool HandleAutoScrollMove(string scrollType, int moveLength)
		{
			switch (scrollType)
			{
			case "y":
				SetAutoScrollPosition(new Point(0, moveLength));
				break;
			case "x":
				SetAutoScrollPosition(new Point(moveLength, 0));
				break;
			}
			return true;
		}
	}
}
