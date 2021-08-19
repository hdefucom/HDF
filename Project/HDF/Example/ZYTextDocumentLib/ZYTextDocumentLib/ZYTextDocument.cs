using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using XDesignerCommon;
using XDesignerGUI;
using XDesignerPrinting;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ZYTextDocument : IDisposable, IPageDocument, ICloneable
	{
		protected const string c_EditorVersion = "1.0";

		private GraphicsUnit intDocumentGraphicsUnit = GraphicsUnit.Document;

		protected PrintPageCollection myPages = new PrintPageCollection();

		private int intPageIndexFix = 1;

		private int intPageIndex = 0;

		protected bool bolEnableJumpPrint = false;

		protected int intJumpPrintPosition = 0;

		public KB_Item OwnerKBItem = null;

		private DocumentView myView = new DocumentView();

		private ZYContent myContent = new ZYContent();

		private ZYEditorControl myOwnerControl = null;

		private ZYTextContainer myDocumentElement = null;

		private List<ZYTextElement> myElements = new List<ZYTextElement>();

		private ZYDataSource myDataSource = new ZYDataSource();

		private ZYTextSaveLogCollection mySaveLogs = new ZYTextSaveLogCollection();

		private ZYDocumentInfo myInfo = new ZYDocumentInfo();

		private List<ZYEditorAction> myActions = new List<ZYEditorAction>();

		protected Cursor myCursor = null;

		protected bool bolLoading = false;

		protected ZYTextElement myCurrentHoverElement = null;

		protected ArrayList myLines = new ArrayList();

		protected NameValueList myVariables = new NameValueList();

		protected ArrayList myContainters = new ArrayList();

		public bool RefreshAllFlag = false;

		protected string[] strHideElementNames = null;

		protected ZYKBBuffer myKBBuffer = null;

		protected PageSettings myPageSettings = new PageSettings();

		public bool ElementsDirty = false;

		private ZYVBScriptEngine myEMRVBEngine;

		protected ZYVBScriptElement myScript = new ZYVBScriptElement();

		private object myAllElement = null;

		protected int intHeadHeight = 0;

		protected int intFooterHeight = 0;

		protected UnderWriteMarkCollection myMarks = new UnderWriteMarkCollection();

		public Hashtable ZYMarkImage;

		protected string strToolTip = null;

		private int ToolTipImageIndex;

		private Rectangle ToolTipBounds;

		private ArrayList myUndoList = new ArrayList();

		private ArrayList myRedoList = new ArrayList();

		protected int intUndoState = 0;

		private A_ContentChangeLog myContentChangeLog = null;

		private int intLogLevel = 0;

		private bool bolLocked = false;

		private int intLockLevel = -1;

		protected string strFooterString = null;

		protected string strHeadString = null;

		private bool bolLastContentChangedFlag = false;

		public GraphicsUnit DocumentGraphicsUnit
		{
			get
			{
				return intDocumentGraphicsUnit;
			}
			set
			{
				intDocumentGraphicsUnit = value;
			}
		}

		public PrintPageCollection Pages
		{
			get
			{
				return myPages;
			}
			set
			{
				myPages = value;
			}
		}

		public int PageIndexFix
		{
			get
			{
				return intPageIndexFix;
			}
			set
			{
				intPageIndexFix = value;
			}
		}

		public int PageIndex
		{
			get
			{
				return intPageIndex;
			}
			set
			{
				intPageIndex = value;
			}
		}

		public bool EnableJumpPrint
		{
			get
			{
				return bolEnableJumpPrint;
			}
			set
			{
				bolEnableJumpPrint = value;
			}
		}

		public int JumpPrintPosition
		{
			get
			{
				return intJumpPrintPosition;
			}
			set
			{
				intJumpPrintPosition = FixPageLine(value);
			}
		}

		public ArrayList Containters => myContainters;

		public ZYVBEventObject EventObj
		{
			get
			{
				if (myInfo.EnableScript && myEMRVBEngine != null)
				{
					return myEMRVBEngine.EventObj;
				}
				return null;
			}
		}

		public object All
		{
			get
			{
				if (myAllElement == null)
				{
					myAllElement = CreateAllObject();
				}
				return myAllElement;
			}
		}

		public ZYVBScriptElement Script => myScript;

		public int HeadHeight
		{
			get
			{
				return intHeadHeight;
			}
			set
			{
				intHeadHeight = value;
			}
		}

		public int FooterHeight
		{
			get
			{
				return intFooterHeight;
			}
			set
			{
				intFooterHeight = value;
			}
		}

		public ZYKBBuffer KBBuffer
		{
			get
			{
				return myKBBuffer;
			}
			set
			{
				myKBBuffer = value;
			}
		}

		public UnderWriteMarkCollection Marks => myMarks;

		public ZYTextSaveLogCollection SaveLogs => mySaveLogs;

		public NameValueList Variables => myVariables;

		public string HideElementNames
		{
			get
			{
				if (strHideElementNames == null)
				{
					return null;
				}
				StringBuilder stringBuilder = new StringBuilder();
				string[] array = strHideElementNames;
				foreach (string text in array)
				{
					if (stringBuilder.Length == 0)
					{
						stringBuilder.Append(text);
					}
					else
					{
						stringBuilder.Append(text + ",");
					}
				}
				return stringBuilder.ToString();
			}
			set
			{
				strHideElementNames = value.Split(",".ToCharArray());
			}
		}

		public ZYTextElement CurrentHoverElement
		{
			get
			{
				return myCurrentHoverElement;
			}
			set
			{
				if (myCurrentHoverElement != value)
				{
					ZYTextElement zYTextElement = myCurrentHoverElement;
					myCurrentHoverElement = value;
					if (zYTextElement != null)
					{
						RefreshElement(zYTextElement);
					}
					if (myCurrentHoverElement != null)
					{
						RefreshElement(myCurrentHoverElement);
					}
				}
			}
		}

		public ArrayList Lines => myLines;

		public bool Loading
		{
			get
			{
				return bolLoading;
			}
			set
			{
				bolLoading = value;
			}
		}

		public ArrayList UndoList => myUndoList;

		public ArrayList RedoList => myRedoList;

		public int UndoState => intUndoState;

		public bool CanContentChangeLog => myContentChangeLog != null && myContentChangeLog.CanLog;

		public A_ContentChangeLog ContentChangeLog => myContentChangeLog;

		public int LockLevel => intLockLevel;

		public bool Locked
		{
			get
			{
				return bolLocked;
			}
			set
			{
				bolLocked = value;
			}
		}

		public List<ZYEditorAction> Actions => myActions;

		public bool Modified
		{
			get
			{
				return myContent.Modified;
			}
			set
			{
				myContent.Modified = value;
			}
		}

		public ZYContent Content
		{
			get
			{
				return myContent;
			}
			set
			{
				myContent = value;
			}
		}

		public bool AutoClearSelection
		{
			get
			{
				return myContent.AutoClearSelection;
			}
			set
			{
				myContent.AutoClearSelection = value;
			}
		}

		public ZYDocumentInfo Info
		{
			get
			{
				return myInfo;
			}
			set
			{
				myInfo = value;
			}
		}

		public int DefaultRowHeight => PixelToDocumentUnit(myView.DefaultRowPixelHeight);

		public DocumentView View
		{
			get
			{
				return myView;
			}
			set
			{
				myView = value;
			}
		}

		public string FooterString
		{
			get
			{
				return strFooterString;
			}
			set
			{
				strFooterString = value;
			}
		}

		public string HeadString
		{
			get
			{
				return strHeadString;
			}
			set
			{
				strHeadString = value;
			}
		}

		public string RuntimeHeadString => ExecuteVariable(strHeadString);

		public string RuntimeFooterString => ExecuteVariable(strFooterString);

		public ZYDataSource DataSource
		{
			get
			{
				return myDataSource;
			}
			set
			{
				myDataSource = value;
			}
		}

		public ZYTextContainer DocumentElement
		{
			get
			{
				return myDocumentElement;
			}
			set
			{
				myDocumentElement = value;
				myElements.Clear();
			}
		}

		public List<ZYTextElement> Elements => myElements;

		public ZYEditorControl OwnerControl
		{
			get
			{
				return myOwnerControl;
			}
			set
			{
				if (myOwnerControl != value)
				{
					myOwnerControl = value;
					if (myOwnerControl != null)
					{
						myOwnerControl.Document = this;
						myView.Graph = myOwnerControl.CreateViewGraphics();
						myOwnerControl.Pages = myPages;
					}
				}
			}
		}

		public event EventHandler OnSelectionChanged = null;

		public event EventHandler OnContentChanged = null;

		public event JumpDivHandler OnJumpDiv = null;

		public bool InitEMRVBEngine()
		{
			return false;
		}

		public bool StartScript()
		{
			if (myInfo.EnableScript && myEMRVBEngine != null)
			{
				myEMRVBEngine.ScriptText = myScript.RunTimeSourceCode;
				myEMRVBEngine.OwnerDocument = this;
				return myEMRVBEngine.StartScript();
			}
			return false;
		}

		public void StopScript()
		{
			if (myEMRVBEngine != null)
			{
				myEMRVBEngine.StopScript();
			}
		}

		public void InitEventObject(ZYVBEventType EventType)
		{
			if (myInfo.EnableScript && myEMRVBEngine != null)
			{
				myEMRVBEngine.EventObj.EventType = EventType;
				if (myOwnerControl != null)
				{
					myOwnerControl.InitEventObject(myEMRVBEngine.EventObj);
				}
			}
		}

		private object CreateAllObject()
		{
			if (myContainters.Count == 0)
			{
				return new object();
			}
			AssemblyName assemblyName = new AssemblyName();
			assemblyName.Name = "RunTimeEMRTextDocumentLib";
			AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
			ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("RunTimeEMRTextModule");
			TypeBuilder typeBuilder = moduleBuilder.DefineType("AllElements", TypeAttributes.Public);
			Hashtable hashtable = new Hashtable();
			foreach (object myContainter in myContainters)
			{
				if (myContainter is ZYTextContainer)
				{
					InnerDefineField(((ZYTextContainer)myContainter).Name, typeBuilder, hashtable, myContainter);
					InnerDefineField(((ZYTextContainer)myContainter).ID, typeBuilder, hashtable, myContainter);
				}
				else if (myContainter is ZYTextObject)
				{
					InnerDefineField(((ZYTextObject)myContainter).ID, typeBuilder, hashtable, myContainter);
				}
			}
			Type type = typeBuilder.CreateType();
			object obj = Activator.CreateInstance(type);
			FieldInfo[] fields = type.GetFields();
			FieldInfo[] array = fields;
			foreach (FieldInfo fieldInfo in array)
			{
				if (hashtable.ContainsKey(fieldInfo.Name))
				{
					type.InvokeMember(fieldInfo.Name, BindingFlags.SetField, null, obj, new object[1]
					{
						hashtable[fieldInfo.Name]
					});
				}
			}
			return obj;
		}

		private void InnerDefineField(string strName, TypeBuilder tb, Hashtable myNames, object obj)
		{
			strName = strName.Trim().ToLower();
			if (StringCommon.HasContent(strName) && !myNames.ContainsKey(strName))
			{
				myNames.Add(strName, obj);
				tb.DefineField(strName, typeof(object), FieldAttributes.Public);
			}
		}

		public object RunEventScript(ZYTextContainer element, string strName)
		{
			if (myInfo.EnableScript && myEMRVBEngine != null && element != null && StringCommon.HasContent(strName))
			{
				strName = strName.Trim();
				MethodInfo scriptMethod = GetScriptMethod(element.Name + "_" + strName);
				if (scriptMethod == null)
				{
					scriptMethod = GetScriptMethod(element.ID + "_" + strName);
				}
				if (scriptMethod == null)
				{
					return null;
				}
				myEMRVBEngine.HasUserInterface = false;
				object result = myEMRVBEngine.InvokeScriptMethod(scriptMethod, null, null);
				if (myEMRVBEngine.HasUserInterface && myOwnerControl != null)
				{
					myOwnerControl.Refresh();
				}
				return result;
			}
			return null;
		}

		public MethodInfo GetScriptMethod(string strMethodName)
		{
			if (myInfo.EnableScript && myEMRVBEngine != null)
			{
				if (myScript.ScriptModified)
				{
					StartScript();
					myScript.ScriptModified = false;
				}
				return myEMRVBEngine.GetScriptMethod(strMethodName);
			}
			return null;
		}

		public object InvokeScriptMethod(string strMethodName, object obj, object[] Parameters)
		{
			if (myInfo.EnableScript && myEMRVBEngine != null)
			{
				if (myScript.ScriptModified)
				{
					StartScript();
					myScript.ScriptModified = false;
				}
				myEMRVBEngine.HasUserInterface = false;
				object result = myEMRVBEngine.InvokeScriptMethod(strMethodName, obj, Parameters);
				if (myEMRVBEngine.HasUserInterface && myOwnerControl != null)
				{
					myOwnerControl.Refresh();
				}
				return result;
			}
			return null;
		}

		public ZYTextElement GetElementByPos(int x, int y)
		{
			return myContent.GetElementAt(x, y);
		}

		public object GetElementById(string strID)
		{
			foreach (object myContainter in myContainters)
			{
				if (myContainter is ZYTextContainer)
				{
					ZYTextContainer zYTextContainer = myContainter as ZYTextContainer;
					if (zYTextContainer.ID == strID || zYTextContainer.Name == strID)
					{
						return zYTextContainer;
					}
				}
				else if (myContainter is ZYTextObject)
				{
					ZYTextObject zYTextObject = myContainter as ZYTextObject;
					if (zYTextObject.ID == strID)
					{
						return zYTextObject;
					}
				}
			}
			return null;
		}

		private void SetContainers(ZYTextContainer c)
		{
			foreach (object childElement in c.ChildElements)
			{
				if (childElement is ZYTextContainer)
				{
					myContainters.Add(childElement);
					SetContainers(childElement as ZYTextContainer);
				}
				if (childElement is ZYTextObject)
				{
					myContainters.Add(childElement);
				}
			}
		}

		public string[] GetElementKeyValueList()
		{
			ArrayList arrayList = new ArrayList();
			foreach (ZYTextElement myContainter in myContainters)
			{
				if (!myContainter.Deleteted && myContainter is ZYTextContainer)
				{
					((ZYTextContainer)myContainter).AppendKeyValueList(arrayList);
				}
			}
			if (arrayList.Count > 0)
			{
				return (string[])arrayList.ToArray(typeof(string));
			}
			return null;
		}

		public string GetValue(string strName)
		{
			return myVariables.GetValue(strName);
		}

		public void SetValue(string strName, string strValue)
		{
			myVariables.SetValue(strName, strValue);
		}

		public string FixValueString(string strText)
		{
			return myVariables.FixVariableString(strText);
		}

		internal void UpdateUserName()
		{
			if (myMarks.CanMark(mySaveLogs.CurrentUserName))
			{
				bolLocked = false;
			}
			else
			{
				bolLocked = myInfo.LockForMark;
			}
			Refresh();
		}

		public int GetMarkLevel(int savelogindex)
		{
			if (savelogindex >= 0 && savelogindex < mySaveLogs.Count)
			{
				return mySaveLogs[savelogindex].Level;
			}
			return 0;
		}

		public void AddLine(ZYTextLine myLine)
		{
			myLines.Add(myLine);
		}

		public void SetToolTip(string strTip, int ImageIndex, Rectangle TipBounds)
		{
			strToolTip = strTip;
			ToolTipImageIndex = ImageIndex;
			ToolTipBounds = TipBounds;
		}

		public void UpdateToolTip()
		{
			if (myOwnerControl != null)
			{
				if (StringCommon.isBlankString(strToolTip))
				{
					myOwnerControl.HideInnerToolTip();
				}
				else
				{
					myOwnerControl.ShowInnerToolTip(ToolTipImageIndex, strToolTip, ToolTipBounds.Left, ToolTipBounds.Top, ToolTipBounds.Height);
				}
			}
		}

		internal void SetCursor(Cursor vCursor)
		{
			myCursor = vCursor;
		}

		private void InitActionList()
		{
			myActions.Clear();
			myActions.Add(new A_BackSpace());
			myActions.Add(new A_Copy());
			myActions.Add(new A_Cut());
			myActions.Add(new A_Delete());
			myActions.Add(new A_DeleteFormat());
			myActions.Add(new A_FontBold());
			myActions.Add(new A_FontItalic());
			myActions.Add(new A_FontUnderline());
			myActions.Add(new A_FontName());
			myActions.Add(new A_FontSize());
			myActions.Add(new A_MoveDown());
			myActions.Add(new A_MoveLeft());
			myActions.Add(new A_MoveRight());
			myActions.Add(new A_MoveUp());
			myActions.Add(new A_PageDown());
			myActions.Add(new A_PageUp());
			myActions.Add(new A_Paste());
			myActions.Add(new A_SetForeColor());
			myActions.Add(new A_SetSub());
			myActions.Add(new A_SetSup());
			myActions.Add(new A_CtlMoveDown());
			myActions.Add(new A_CtlMoveUp());
			myActions.Add(new A_ShiftMoveDown());
			myActions.Add(new A_ShiftMoveLeft());
			myActions.Add(new A_ShiftMoveRight());
			myActions.Add(new A_ShiftMoveUp());
			myActions.Add(new A_ShiftPageDown());
			myActions.Add(new A_ShiftPageUp());
			myActions.Add(new A_MoveHome());
			myActions.Add(new A_ShiftMoveHome());
			myActions.Add(new A_MoveEnd());
			myActions.Add(new A_ShiftMoveEnd());
			myActions.Add(new A_InsertTable());
			myActions.Add(new A_InsertXML());
			myActions.Add(new A_InsertChar());
			myActions.Add(new A_InsertImage());
			myActions.Add(new A_InsertDiv());
			myActions.Add(new A_InsertSelect());
			myActions.Add(new A_InsertMultipleSelect());
			myActions.Add(new A_InsertTemplate());
			myActions.Add(new A_InsertKeyWord());
			myActions.Add(new A_InsertString());
			myActions.Add(new A_InsertDocument());
			myActions.Add(new A_InsertInput());
			myActions.Add(new A_InsertExDataInput());
			myActions.Add(new A_InsertKB());
			myActions.Add(new A_InsertLine());
			myActions.Add(new A_InsertGongshi());
			myActions.Add(new A_SelectAll());
			myActions.Add(new A_SaveAs());
			myActions.Add(new A_SaveFile());
			myActions.Add(new A_SaveImage());
			myActions.Add(new A_Find());
			myActions.Add(new A_Replace());
			myActions.Add(new A_ReplaceAll());
			myActions.Add(new A_Open());
			myActions.Add(new A_LogicDelete());
			myActions.Add(new A_ShowAll());
			myActions.Add(new A_RegisteUser());
			myActions.Add(new A_SetVariable());
			myActions.Add(new A_RemoveVariable());
			myActions.Add(new A_ViewSource());
			myActions.Add(new A_ViewDataSource());
			myActions.Add(new A_ViewStructSource());
			myActions.Add(new A_LockDocument());
			myActions.Add(new A_AlignCenter());
			myActions.Add(new A_AlignLeft());
			myActions.Add(new A_AlignRight());
			myActions.Add(new A_AlignJustify());
			myActions.Add(new A_DocumentTitle());
			myActions.Add(new A_SaveTemplate());
			myActions.Add(new A_NewFile());
			myActions.Add(new A_OpenDBFile());
			myActions.Add(new A_SaveDBFile());
			myActions.Add(new A_FieldName());
			myActions.Add(new A_SetUserLevel());
			myActions.Add(new A_ShowMark());
			myActions.Add(new A_PageViewMode());
			myActions.Add(new A_ShowParagraphFlag());
			myActions.Add(new A_Undo());
			myActions.Add(new A_Redo());
			myActions.Add(new A_ConvertTextToSelect());
			myActions.Add(new A_SetInputFormat());
			myActions.Add(new A_SetMultiSelect());
			myActions.Add(new A_DivProperty());
			myActions.Add(new A_DesignMode());
			myActions.Add(new A_UnderWriteMark());
			myActions.Add(new A_UnderWriteMarkUI());
			myActions.Add(new A_SetBackColor());
			myActions.Add(new A_ClearSaveLog());
			myActions.Add(new A_OwnerSection());
			myActions.Add(new A_SectionSQL());
			myActions.Add(new A_ContentChanged());
			myActions.Add(new A_EditScript());
			myActions.Add(new A_EnableKBSection());
			myActions.Add(new A_ErrorReportURL());
			myActions.Add(new A_RemoveBlankKeyField());
			myActions.Add(new A_SetPageSize());
			myActions.Add(new A_RemoveBlankLine());
			myActions.Add(new A_PageSetting());
			myActions.Add(new A_PrintDocument());
			myActions.Add(new A_EnableJumpPrint());
			myActions.Add(new A_HeadFooter());
			myActions.Add(new A_InsertTextFlag());
			myActions.Add(new A_InsertEMRelement());
			myActions.Add(new A_Setflag());
			myActions.Add(new A_NewFilePacs());
			myActions.Add(new A_InsertDiagramPic());
			myActions.Add(new A_INSERTXMLCANUNDO());
			foreach (ZYEditorAction myAction in myActions)
			{
				myAction.OwnerDocument = this;
			}
		}

		public bool HandleCommnad(string CommandName, string Param1, string Param2, string Param3)
		{
			foreach (ZYEditorAction myAction in myActions)
			{
				if (myAction.ActionName() == CommandName && myAction.isEnable())
				{
					myAction.Param1 = Param1;
					myAction.Param2 = Param2;
					myAction.Param3 = Param3;
					return myAction.UIExecute();
				}
			}
			return false;
		}

		public ZYEditorAction GetActionByName(string strName)
		{
			foreach (ZYEditorAction myAction in myActions)
			{
				if (myAction.ActionName() == strName)
				{
					return myAction;
				}
			}
			return null;
		}

		public void RegisteUndo(ZYEditorAction a)
		{
			if (intUndoState == 0 && a != null && a.isUndoable())
			{
				ZYEditorAction zYEditorAction = a.Clone();
				if (zYEditorAction != null)
				{
					myUndoList.Add(zYEditorAction);
					myRedoList.Clear();
				}
			}
		}

		public void BeginContentChangeLog()
		{
			if (intLogLevel <= 0)
			{
				myContentChangeLog = new A_ContentChangeLog();
				myContentChangeLog.OwnerDocument = this;
				myContentChangeLog.SelectStart = myContent.SelectStart;
				myContentChangeLog.SelectLength = myContent.SelectLength;
			}
			intLogLevel++;
		}

		public void EndContentChangeLog()
		{
			intLogLevel--;
			if (intLogLevel <= 0)
			{
				if (myContentChangeLog != null && myContentChangeLog.isEnable())
				{
					myContentChangeLog.SelectStart2 = myContent.SelectStart;
					myContentChangeLog.SelectLength2 = myContent.SelectLength;
					RegisteUndo(myContentChangeLog);
					myContentChangeLog = null;
				}
				intLogLevel = 0;
			}
		}

		public string[] GetCommandList()
		{
			string[] array = new string[myActions.Count];
			for (int i = 0; i < myActions.Count; i++)
			{
				array[i] = myActions[i].ActionName();
			}
			return array;
		}

		public bool CanModify()
		{
			return !Locked;
		}

		private string ExecuteVariable(string txt)
		{
			VariableString variableString = new VariableString(txt);
			variableString.SetVariable("pageindex", Convert.ToString(intPageIndex + intPageIndexFix));
			variableString.SetVariable("pagecount", myPages.Count.ToString());
			DateTime serverTime = ZYTime.GetServerTime();
			variableString.SetVariable("year", serverTime.Year.ToString());
			variableString.SetVariable("month", serverTime.Month.ToString());
			variableString.SetVariable("dy", serverTime.Day.ToString());
			variableString.SetVariable("hour", serverTime.Hour.ToString());
			variableString.SetVariable("minute", serverTime.Minute.ToString());
			variableString.SetVariable("secend", serverTime.Second.ToString());
			return variableString.Execute();
		}

		public int IndexOf(ZYTextElement myElement)
		{
			return myElements.IndexOf(myElement);
		}

		public int PixelToDocumentUnit(int len)
		{
			return GraphicsUnitConvert.Convert(len, GraphicsUnit.Pixel, intDocumentGraphicsUnit);
		}

		public Size PixelToDocumentUnit(Size size)
		{
			return GraphicsUnitConvert.Convert(size, GraphicsUnit.Pixel, intDocumentGraphicsUnit);
		}

		public Point PixelToDocumentUnit(Point p)
		{
			return GraphicsUnitConvert.Convert(p, GraphicsUnit.Pixel, intDocumentGraphicsUnit);
		}

		public ZYTextDocument()
		{
			myContent.Document = this;
			myContent.Elements = myElements;
			InitActionList();
			myDocumentElement = new ZYTextDiv();
			myDocumentElement.OwnerDocument = this;
			RefreshElements();
			myView.Width = myPages.StandardWidth;
			mySaveLogs.OwnerDocument = this;
			myMarks.OwnerDocument = this;
			myScript.OwnerDocument = this;
		}

		public void Dispose()
		{
			if (myView != null)
			{
				myView.Dispose();
			}
			if (myDataSource != null && myDataSource.DBConn != null)
			{
				myDataSource.DBConn.Dispose();
			}
			if (myEMRVBEngine != null)
			{
				myEMRVBEngine.Close();
			}
			foreach (ZYTextElement myElement in myElements)
			{
				if (myElement is IDisposable)
				{
					(myElement as IDisposable).Dispose();
				}
			}
		}

		public bool isSelected(ZYTextElement myElement)
		{
			if (myInfo.Printing || myElement == null)
			{
				return false;
			}
			if (myContent.isSelected(myElement))
			{
				return true;
			}
			if (myElement.Parent is ZYTextBlock && myContent.isSelected(myElement.Parent))
			{
				return true;
			}
			return false;
		}

		public bool isVisible(ZYTextElement myElement)
		{
			if (myElement.CreatorIndex == -1)
			{
				return true;
			}
			if (myInfo.VisibleUserLevel >= 0)
			{
				if (myElement.CreatorIndex > myInfo.VisibleUserLevel)
				{
					return false;
				}
				if (myElement.DeleterIndex > myInfo.VisibleUserLevel)
				{
					return true;
				}
			}
			else if (myInfo.ShowAll)
			{
				return true;
			}
			return !myElement.Deleteted;
		}

		public void RefreshElements()
		{
			RefreshElements(FixNative: false);
		}

		public void RefreshElements(bool FixNative)
		{
			myElements.Clear();
			if (myDocumentElement != null)
			{
				myDocumentElement.AddElementToList(myElements, ResetFlag: true);
				if (FixNative)
				{
					FixForNative(myElements);
				}
				int num = 0;
				foreach (ZYTextElement myElement in myElements)
				{
					myElement.Visible = true;
					myElement.Index = num;
					num++;
				}
				myContent.AutoClearSelection = true;
				myContent.MoveSelectStart(myContent.SelectStart);
				myContainters.Clear();
				SetContainers(myDocumentElement);
				myAllElement = null;
			}
		}

		private void FixForNative(List<ZYTextElement> elements)
		{
			ZYTextLock zYTextLock = null;
			for (int num = elements.Count - 1; num >= 0; num--)
			{
				ZYTextElement zYTextElement = elements[num];
				if (zYTextElement is ZYTextLock)
				{
					zYTextLock = (ZYTextLock)zYTextElement;
				}
				else if (zYTextLock == null)
				{
					zYTextElement.Visible = true;
				}
				else
				{
					ZYTextSaveLog zYTextSaveLog = mySaveLogs.SafeGet(zYTextElement.CreatorIndex);
					if (zYTextSaveLog != null)
					{
						if (zYTextSaveLog.Level != zYTextLock.Level)
						{
							elements.RemoveAt(num);
						}
					}
					else
					{
						zYTextElement.Visible = true;
					}
				}
			}
		}

		public void EnumElements(EnumElementHandler vHandler)
		{
			if (myDocumentElement != null && vHandler != null)
			{
				myDocumentElement.EnumChildElements(vHandler, bolPreEnum: true);
			}
		}

		public List<ZYTextElement> GetFinalElements()
		{
			List<ZYTextElement> list = new List<ZYTextElement>();
			int visibleUserLevel = myInfo.VisibleUserLevel;
			myInfo.VisibleUserLevel = -1;
			bool showAll = myInfo.ShowAll;
			myInfo.ShowAll = false;
			myDocumentElement.AddElementToList(list, ResetFlag: false);
			myInfo.ShowAll = showAll;
			myInfo.VisibleUserLevel = visibleUserLevel;
			return list;
		}

		public string GetFinalText()
		{
			return ZYTextElement.GetElementsText(GetFinalElements());
		}

		public ZYTextElement GetLastNotDeletedElement(int index)
		{
			if (index < 0 || index >= myElements.Count)
			{
				index = myContent.SelectStart;
			}
			for (int i = index; i < myElements.Count; i++)
			{
				ZYTextElement zYTextElement = myElements[i];
				if (!zYTextElement.Deleteted)
				{
					return zYTextElement;
				}
			}
			return null;
		}

		public int RemoveBlankLine()
		{
			int num = myDocumentElement.RemoveBlankLine();
			if (num > 0)
			{
				Modified = true;
				RefreshElements();
				RefreshLine();
				UpdateView();
			}
			return num;
		}

		public int RemoveBlankKeyField(bool ContentLog)
		{
			int num = myDocumentElement.RemoveBlankKeyField2(ContentLog);
			if (num > 0)
			{
				Modified = true;
				RefreshElements();
				RefreshLine();
				UpdateView();
			}
			return num;
		}

		public virtual ZYTextElement CreateElement(string strName)
		{
			ZYTextElement zYTextElement = null;
			if (strName == null || strName.Trim().Length == 0)
			{
				return null;
			}
			strName = strName.Trim();
			switch (strName)
			{
			case "br":
				zYTextElement = new ZYTextLineEnd();
				break;
			case "p":
				zYTextElement = new ZYTextParagraph();
				break;
			case "body":
				zYTextElement = new ZYTextDiv();
				break;
			case "div":
				zYTextElement = new ZYTextDiv();
				break;
			case "select":
				zYTextElement = new ZYTextSelect();
				break;
			case "img":
				zYTextElement = new ZYTextImage();
				break;
			case "input":
				zYTextElement = new ZYTextInput();
				break;
			case "hr":
				zYTextElement = new ZYTextHRule();
				break;
			case "keyword":
				zYTextElement = new ZYTextKeyWord();
				break;
			case "lock":
				zYTextElement = new ZYTextLock();
				break;
			case "textflag":
				zYTextElement = new ZYTextFlag();
				break;
			case "table":
				zYTextElement = new EMRTable();
				break;
			case "cell":
				zYTextElement = new EMRCell();
				break;
			case "row":
				zYTextElement = new EMRRow();
				break;
			case "textbox":
				zYTextElement = new ZYTextBox();
				break;
			}
			if (zYTextElement != null)
			{
				zYTextElement.OwnerDocument = this;
				zYTextElement.CreatorIndex = mySaveLogs.CurrentIndex;
			}
			return zYTextElement;
		}

		internal bool BeforeInsertElemnt(ZYTextContainer container, ZYTextElement NewElement)
		{
			if (!bolLoading)
			{
				if (myContentChangeLog != null)
				{
					myContentChangeLog.CanLog = false;
				}
				NewElement.DeleterIndex = -1;
				NewElement.CreatorIndex = mySaveLogs.CurrentIndex;
				ZYTextChar zYTextChar = NewElement as ZYTextChar;
				if (zYTextChar != null)
				{
					if (myMarks.Count == 1)
					{
						zYTextChar.ForeColor = Color.DarkBlue;
					}
					if (myMarks.Count >= 2)
					{
						zYTextChar.ForeColor = Color.DarkRed;
					}
				}
				if (myContentChangeLog != null)
				{
					myContentChangeLog.CanLog = true;
				}
			}
			return true;
		}

		public void UpdateCaret()
		{
		}

		public void _Find(string strFind)
		{
			myContent.FindText(strFind);
		}

		public void _Replace(string strFind, string strReplace)
		{
			BeginUpdate();
			BeginContentChangeLog();
			myContent.ReplaceText(strFind, strReplace);
			myContentChangeLog.strUndoName = "替换";
			EndContentChangeLog();
			EndUpdate();
		}

		public void _ReplaceAll(string strFind, string strReplace)
		{
			BeginUpdate();
			BeginContentChangeLog();
			myContent.ReplaceTextAll(strFind, strReplace);
			myContentChangeLog.strUndoName = "替换所有";
			EndContentChangeLog();
			EndUpdate();
		}

		public void _SelectAll()
		{
			myContent.SelectAll();
		}

		public void _PageDown()
		{
			myContent.MoveStep(myOwnerControl.ClientSize.Height);
			UpdateCaret();
		}

		public void _PageUp()
		{
			myContent.MoveStep(-myOwnerControl.ClientSize.Height);
			UpdateCaret();
		}

		public void _MoveHome()
		{
			myContent.MoveHome();
			UpdateCaret();
		}

		public void _MoveEnd()
		{
			myContent.MoveEnd();
			UpdateCaret();
		}

		public void _MoveUp()
		{
			myContent.MoveUpOneLine();
			UpdateCaret();
		}

		public void _MoveDown()
		{
			myContent.MoveDownOneLine();
			UpdateCaret();
		}

		public void _MoveLeft()
		{
			myContent.MoveLeft();
			UpdateCaret();
		}

		public void _MoveRight()
		{
			myContent.MoveRight();
			UpdateCaret();
		}

		public bool _Undo()
		{
			if (intUndoState == 0 && myUndoList.Count > 0)
			{
				intUndoState = 1;
				ZYEditorAction zYEditorAction = (ZYEditorAction)myUndoList[myUndoList.Count - 1];
				myUndoList.RemoveAt(myUndoList.Count - 1);
				if (zYEditorAction.Undo())
				{
					if (zYEditorAction.SelectStart >= 0)
					{
						myContent.SetSelection(zYEditorAction.SelectStart, zYEditorAction.SelectLength);
					}
					myRedoList.Add(zYEditorAction);
					intUndoState = 0;
					return true;
				}
				intUndoState = 0;
			}
			return false;
		}

		public bool _Redo()
		{
			if (intUndoState == 0 && myRedoList.Count > 0)
			{
				intUndoState = 2;
				ZYEditorAction zYEditorAction = (ZYEditorAction)myRedoList[myRedoList.Count - 1];
				myRedoList.RemoveAt(myRedoList.Count - 1);
				zYEditorAction.Redo();
				if (zYEditorAction.SelectStart2 >= 0)
				{
					myContent.SetSelection(zYEditorAction.SelectStart2, zYEditorAction.SelectLength2);
				}
				myUndoList.Add(zYEditorAction);
				intUndoState = 0;
			}
			return true;
		}

		public void _Delete()
		{
			if (Locked)
			{
				return;
			}
			BeginUpdate();
			BeginContentChangeLog();
			if (myContent.HasSelected())
			{
				myContent.DeleteSeleciton();
			}
			else
			{
				int selectStart = myContent.SelectStart;
				int num = myContent.DeleteCurrentElement();
				if (num == 2 && myInfo.ShowAll)
				{
					Content.SetSelection(selectStart + 1, 0);
				}
			}
			myContentChangeLog.strUndoName = "删除元素";
			EndContentChangeLog();
			EndUpdate();
		}

		public void _DeleteFormat()
		{
			if (!Locked)
			{
				BeginUpdate();
				BeginContentChangeLog();
				bool flag = false;
				List<ZYTextElement> selectElements = myContent.GetSelectElements();
				foreach (ZYTextElement item in selectElements)
				{
					ZYTextChar zYTextChar = item as ZYTextChar;
					if (zYTextChar != null)
					{
						zYTextChar.Font = myView.DefaultFont;
						zYTextChar.Sub = false;
						zYTextChar.Sup = false;
						zYTextChar.ForeColor = (Color)ZYAttribute.GetDefaultValue("forecolor");
						flag = true;
						zYTextChar.RefreshSize();
					}
					ZYTextSelect zYTextSelect = item as ZYTextSelect;
					if (zYTextSelect != null)
					{
						zYTextSelect.Value = "";
						zYTextSelect.Text = "[" + zYTextSelect.Name + "]";
						zYTextSelect.RefreshSize();
						flag = true;
					}
				}
				myContentChangeLog.strUndoName = "清除样式";
				if (flag)
				{
					RefreshLine();
				}
				EndContentChangeLog();
				EndUpdate();
				if (flag)
				{
					Refresh();
				}
			}
		}

		private bool CheckKBLoaded()
		{
			if (ZYKBBuffer.Instance.CanReadKB())
			{
				return true;
			}
			MessageBox.Show(myOwnerControl, "系统正在加载或未加载知识库,此时无法调用知识库,请稍候重试!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return false;
		}

		public int _InsertKB(bool OnlyTemplate)
		{
			if (Locked || !CheckKBLoaded())
			{
				return -1;
			}
			bool flag = false;
			bool flag2 = false;
			int result = -1;
			ArrayList arrayList = new ArrayList();
			string text = myContent.GetSelectedText();
			if (StringCommon.isBlankString(text))
			{
				text = myContent.GetPreWord();
			}
			else
			{
				flag = true;
			}
			ZYKBBuffer.Instance.SearchTemplateOnly = OnlyTemplate;
			flag2 = ZYKBBuffer.Instance.GetKBListsByName(text, arrayList, bolCompareName: true);
			object obj = myOwnerControl.ShowKBPopupList(myContent.CurrentElement, arrayList, flag2 ? ("关键字[" + text + "]") : "[报告知识库]", MultiSelect: false, MustKBItem: true);
			KB_Item kB_Item = obj as KB_Item;
			if (kB_Item != null)
			{
				if (flag)
				{
					myContent.DeleteSeleciton();
				}
				result = _InsertKB(kB_Item.OwnerList, kB_Item);
				Modified = true;
				EndUpdate();
				EndContentChangeLog();
			}
			else
			{
				KB_List kB_List = obj as KB_List;
				if (kB_List != null)
				{
					result = _InsertKB(kB_List);
				}
			}
			return result;
		}

		public int _InsertKB(KB_List myList)
		{
			return _InsertKB(myList, null);
		}

		public int _InsertKB(KB_List myList, KB_Item myItem)
		{
			if (Locked || myList == null || !CheckKBLoaded())
			{
				return -1;
			}
			int result = -1;
			if (!myList.HasLaunchSystemItems)
			{
				myList.LaunchSystemItems(myDataSource.DBConn);
			}
			if (myList != null)
			{
				try
				{
					Loading = true;
					myList.RefCount++;
					ZYTextElement currentElement = myContent.CurrentElement;
					if (myItem != null && myItem.isTemplate())
					{
						result = ((!_InsertDocument(myItem.ItemValue)) ? (-1) : 0);
					}
					else if (myList.InputBoxAttribute)
					{
						ZYTextInput zYTextInput = new ZYTextInput();
						zYTextInput.OwnerDocument = this;
						zYTextInput.ListSource = myList.SEQ;
						zYTextInput.Name = myList.Name;
						zYTextInput.Unit = myList.Desc;
						myContent.AutoClearSelection = true;
						BeginContentChangeLog();
						BeginUpdate();
						if (myList.PreAppendNameAttribute)
						{
							myContent.InsertString(myList.Name);
						}
						if (myItem != null)
						{
							zYTextInput.Text = myItem.ItemText;
						}
						myContent.InsertElement(zYTextInput);
						if (myList.AfterAppendNameAttribute)
						{
							myContent.CurrentElement = currentElement;
							myContent.InsertString(myList.Name);
						}
						myContentChangeLog.strUndoName = "插入文本框" + myList.Name;
						EndUpdate();
						myContent.SetSelection(zYTextInput.Index + 1, 0);
						if (myOwnerControl != null)
						{
							myOwnerControl.Focus();
						}
						EndContentChangeLog();
						result = 1;
					}
					else if (myList.HasItems())
					{
						ZYTextSelect zYTextSelect = new ZYTextSelect();
						zYTextSelect.OwnerDocument = this;
						zYTextSelect.Name = myList.Name;
						zYTextSelect.ListSource = myList.SEQ;
						if (myItem == null)
						{
							zYTextSelect.Text = myList.Name;
							zYTextSelect.Value = myList.Name;
						}
						else
						{
							zYTextSelect.Text = myItem.ItemText;
							zYTextSelect.Value = (StringCommon.isBlankString(myItem.ItemValue) ? myItem.ItemText : myItem.ItemText);
						}
						myContent.AutoClearSelection = true;
						BeginContentChangeLog();
						BeginUpdate();
						if (myList.PreAppendNameAttribute)
						{
							myContent.InsertString(myList.Name);
						}
						myContent.InsertElement(zYTextSelect);
						if (myList.AfterAppendNameAttribute)
						{
							myContent.InsertString(myList.Name);
						}
						myContent.CurrentElement = currentElement;
						myContentChangeLog.strUndoName = "插入下拉列表 " + myList.Name;
						EndUpdate();
						if (myOwnerControl != null)
						{
							myOwnerControl.Focus();
						}
						EndContentChangeLog();
						result = ((myItem != null) ? 3 : 2);
					}
				}
				catch (Exception sourceException)
				{
					ZYErrorReport.Instance.SourceException = sourceException;
					ZYErrorReport.Instance.SourceObject = myList;
					ZYErrorReport.Instance.UserMessage = "插入知识点 " + myList.Name + " 错误";
					ZYErrorReport.Instance.SetAttribute("KBItem", (myItem == null) ? "[null]" : myItem.ItemText);
					ZYErrorReport.Instance.MemberName = "Document._InsertKB";
					ZYErrorReport.Instance.ReportError();
				}
				Loading = false;
			}
			return result;
		}

		public ZYTextLock _InsertLock()
		{
			if (Locked)
			{
				return null;
			}
			BeginUpdate();
			BeginContentChangeLog();
			ZYTextLock zYTextLock = new ZYTextLock();
			zYTextLock.UserName = mySaveLogs.CurrentSaveLog.UserName;
			zYTextLock.DateTime = ZYTime.GetServerTime();
			zYTextLock.Level = mySaveLogs.CurrentSaveLog.Level;
			myContent.MoveSelectStart(myContent.Elements.Count - 1);
			myContent.InsertLock(zYTextLock);
			EndContentChangeLog();
			EndUpdate();
			return zYTextLock;
		}

		public ZYTextElement _InsertChar(char vChar)
		{
			ZYTextElement zYTextElement = null;
			if (Locked)
			{
				return null;
			}
			BeginUpdate();
			BeginContentChangeLog();
			if (myContent.HasSelected())
			{
				myContent.DeleteSeleciton();
			}
			else if (!myOwnerControl.InsertMode && vChar != '\r')
			{
				myContent.DeleteCurrentElement();
			}
			if (vChar == '\r')
			{
				if (myOwnerControl.HasShiftPressing())
				{
					ZYTextLineEnd zYTextLineEnd = new ZYTextLineEnd();
					zYTextLineEnd.OwnerDocument = this;
					myContent.InsertElement(zYTextLineEnd);
					myContentChangeLog.strUndoName = "输入软回车";
					zYTextElement = zYTextLineEnd;
				}
				else
				{
					ZYTextParagraph zYTextParagraph = new ZYTextParagraph();
					zYTextParagraph.OwnerDocument = this;
					ZYTextParagraph ownerParagraph = GetOwnerParagraph();
					if (ownerParagraph != null)
					{
						zYTextParagraph.Align = ownerParagraph.Align;
					}
					myContent.InsertElement(zYTextParagraph);
					myContentChangeLog.strUndoName = "输入硬回车";
					zYTextElement = zYTextParagraph;
				}
			}
			else
			{
				myContent.AutoClearSelection = true;
				zYTextElement = myContent.InsertChar(vChar);
				myContentChangeLog.strUndoName = "输入字符 " + vChar;
			}
			EndContentChangeLog();
			EndUpdate();
			return zYTextElement;
		}

		public bool _InsertDocument(string strID)
		{
			ET_Document eT_Document = new ET_Document();
			ZYTextElement currentElement = myContent.CurrentElement;
			if (currentElement != null && eT_Document.SetKeyWord(strID) && myDataSource.DBConn.ReadOneRecord(eT_Document))
			{
				try
				{
					eT_Document.strObjectData = eT_Document.strObjectData.Replace("#sj#", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
					if (ZYPublic.PatientInfo != null)
					{
						for (int i = 0; i < ZYPublic.PatientInfo.DocumentElement.ChildNodes.Count; i++)
						{
							eT_Document.strObjectData = eT_Document.strObjectData.Replace("#" + ZYPublic.PatientInfo.DocumentElement.ChildNodes[i].Name + "#", ZYPublic.PatientInfo.DocumentElement.ChildNodes[i].InnerText.Trim());
						}
					}
					XmlElement documentElement = eT_Document.GetDataXML().DocumentElement;
					XmlElement elementByName = XMLCommon.GetElementByName(documentElement, myScript.GetXMLName(), Deep: false);
					if (elementByName != null)
					{
						myScript.AppendSourceCode(elementByName.InnerText);
					}
					ZYTextContainer zYTextContainer = CreateElementByXML(GetBodyElement(documentElement)) as ZYTextContainer;
					if (zYTextContainer != null)
					{
						zYTextContainer.ClearSaveLog();
						ArrayList arrayList = new ArrayList();
						arrayList.AddRange(zYTextContainer.ChildElements);
						if (arrayList.Count > 0 && arrayList[arrayList.Count - 1] is ZYTextParagraph)
						{
							arrayList.RemoveAt(arrayList.Count - 1);
						}
						BeginContentChangeLog();
						currentElement.Parent.InsertRangeBefore(arrayList, currentElement);
						EndContentChangeLog();
						RefreshSize();
						RefreshElements();
						RefreshLine();
						UpdateView();
						myContent.CurrentElement = currentElement;
						return true;
					}
				}
				catch
				{
				}
			}
			return false;
		}

		public bool _ReplaceXml(string xml)
		{
			ZYTextElement currentElement = myContent.CurrentElement;
			if (currentElement != null)
			{
				try
				{
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.LoadXml(xml);
					XmlElement documentElement = xmlDocument.DocumentElement;
					XmlElement elementByName = XMLCommon.GetElementByName(documentElement, myScript.GetXMLName(), Deep: false);
					if (elementByName != null)
					{
						myScript.AppendSourceCode(elementByName.InnerText);
					}
					ZYTextContainer zYTextContainer = CreateElementByXML(GetBodyElement(documentElement)) as ZYTextContainer;
					if (zYTextContainer != null)
					{
						zYTextContainer.ClearSaveLog();
						ArrayList arrayList = new ArrayList();
						arrayList.AddRange(zYTextContainer.ChildElements);
						if (arrayList.Count > 0 && arrayList[arrayList.Count - 1] is ZYTextParagraph)
						{
							arrayList.RemoveAt(arrayList.Count - 1);
						}
						BeginContentChangeLog();
						DeleteAllElement();
						currentElement.Parent.InsertRangeBefore(arrayList, currentElement);
						EndContentChangeLog();
						RefreshSize();
						RefreshElements();
						RefreshLine();
						UpdateView();
						myContent.CurrentElement = currentElement;
						return true;
					}
				}
				catch
				{
				}
			}
			return true;
		}

		public void _InsertDiv(string strName)
		{
			if (!Locked)
			{
				BeginUpdate();
				BeginContentChangeLog();
				if (myContent.HasSelected())
				{
					myContent.DeleteSeleciton();
				}
				else if (!myOwnerControl.InsertMode)
				{
					myContent.DeleteCurrentElement();
				}
				ZYTextDiv zYTextDiv = new ZYTextDiv();
				zYTextDiv.Name = strName;
				zYTextDiv.Title = strName;
				zYTextDiv.HideTitle = false;
				myContent.AutoClearSelection = true;
				if (!(myContent.PreElement is ZYTextParagraph))
				{
					myContent.InsertElement(new ZYTextParagraph());
				}
				myContent.InsertElement(zYTextDiv);
				myContentChangeLog.strUndoName = "插入文本层";
				myContent.MoveSelectStart(myContent.SelectStart - 1);
				EndContentChangeLog();
				EndUpdate();
			}
		}

		public void _InsertEMRelement(string strXML)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.PreserveWhitespace = true;
			BeginUpdate();
			ClearContent();
			xmlDocument.LoadXml(strXML);
			FromXML(xmlDocument.DocumentElement);
			RefreshSize();
			ContentChanged();
			EndUpdate();
			Modified = false;
			Refresh();
		}

		public void _InsertElement(ZYTextElement NewElement)
		{
			if (!Locked)
			{
				BeginUpdate();
				BeginContentChangeLog();
				if (myContent.HasSelected())
				{
					myContent.DeleteSeleciton();
				}
				else if (!myOwnerControl.InsertMode)
				{
					myContent.DeleteCurrentElement();
				}
				myContent.AutoClearSelection = true;
				myContent.InsertElement(NewElement);
				myContentChangeLog.strUndoName = "插入元素";
				myContent.MoveSelectStart(myContent.SelectStart - 1);
				EndContentChangeLog();
				EndUpdate();
			}
		}

		public ZYTextFlag _InsertTextFlag(string Text)
		{
			if (Locked)
			{
				return null;
			}
			ZYTextFlag zYTextFlag = new ZYTextFlag();
			zYTextFlag.Text = Text;
			_InsertElement(zYTextFlag);
			return zYTextFlag;
		}

		public ZYTextSelect _InsertSelect(string strName, string strList, bool bolMultiple)
		{
			if (Locked)
			{
				return null;
			}
			object obj = myOwnerControl.ShowKBPopupList(myContent.CurrentElement, ZYKBBuffer.Instance.RootList.ChildNodes, "插入下拉列表", bolMultiple, MustKBItem: true);
			if (obj != null)
			{
				BeginContentChangeLog();
				BeginUpdate();
				if (myContent.HasSelected())
				{
					myContent.DeleteSeleciton();
				}
				else if (!myOwnerControl.InsertMode)
				{
					myContent.DeleteCurrentElement();
				}
				ZYTextSelect zYTextSelect = new ZYTextSelect();
				zYTextSelect.Multiple = bolMultiple;
				zYTextSelect.Name = strName;
				myContent.AutoClearSelection = true;
				myContent.InsertElement(zYTextSelect);
				zYTextSelect.SetValue(obj, ChangeSelection: true);
				myContentChangeLog.strUndoName = "插入下拉列表 " + strName;
				EndUpdate();
				EndContentChangeLog();
				return zYTextSelect;
			}
			return null;
		}

		public ZYTextSelect _InsertSelect(ZYTextSelect mySelect)
		{
			if (Locked)
			{
				return null;
			}
			BeginContentChangeLog();
			BeginUpdate();
			if (myContent.HasSelected())
			{
				myContent.DeleteSeleciton();
			}
			else if (!myOwnerControl.InsertMode)
			{
				myContent.DeleteCurrentElement();
			}
			myContent.AutoClearSelection = true;
			myContent.InsertElement(mySelect);
			myContentChangeLog.strUndoName = "插入下拉列表 " + mySelect.Name;
			EndUpdate();
			EndContentChangeLog();
			return mySelect;
		}

		public ZYTextInput _InsertInput(string strID, string strName)
		{
			if (Locked)
			{
				return null;
			}
			BeginUpdate();
			BeginContentChangeLog();
			if (myContent.HasSelected())
			{
				myContent.DeleteSeleciton();
			}
			else if (!myOwnerControl.InsertMode)
			{
				myContent.DeleteCurrentElement();
			}
			ZYTextInput zYTextInput = new ZYTextInput();
			if (strName == null)
			{
				strName = strID;
			}
			zYTextInput.OwnerDocument = this;
			zYTextInput.ID = strID;
			zYTextInput.Name = strName;
			zYTextInput.Text = "";
			myContent.InsertElement(zYTextInput);
			myContentChangeLog.strUndoName = "插入域 " + strName;
			EndContentChangeLog();
			EndUpdate();
			return zYTextInput;
		}

		public void _BackSpace()
		{
			if (Locked)
			{
				return;
			}
			BeginUpdate();
			BeginContentChangeLog();
			if (myContent.HasSelected())
			{
				myContent.DeleteSeleciton();
			}
			else
			{
				int selectStart = myContent.SelectStart;
				int num = myContent.DeletePreElement();
				if (num == 2 && myInfo.ShowAll)
				{
					myContent.SetSelection(selectStart - 1, 0);
				}
			}
			myContentChangeLog.strUndoName = "退格删除";
			EndContentChangeLog();
			EndUpdate();
		}

		public bool _Resize(ZYTextObject myObj, int NewWidth, int NewHeight)
		{
			if (myObj != null && myObj.CanResize && myObj.Width != NewWidth && myObj.Height != NewHeight)
			{
				myObj.Width = NewWidth;
				myObj.Height = NewHeight;
				RefreshLine();
				UpdateView();
				myContent.CurrentSelectElement = myObj;
				return true;
			}
			return false;
		}

		public void _Cut()
		{
			if (!Locked)
			{
				_Copy();
				_Delete();
			}
		}

		public bool _Copy()
		{
			try
			{
				List<ZYTextElement> selectElements = myContent.GetSelectElements();
				ZYTextElement.FixElementsForParent(selectElements);
				if (selectElements != null && selectElements.Count > 0)
				{
					DataObject dataObject = new DataObject();
					dataObject.SetData(DataFormats.UnicodeText, ZYTextElement.GetElementsText(selectElements));
					myInfo.SaveMode = 0;
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.PreserveWhitespace = true;
					xmlDocument.AppendChild(xmlDocument.CreateElement("emrtextdocument2005"));
					if (ZYTextElement.ElementsToXML(selectElements, xmlDocument.DocumentElement))
					{
						if (ZYPublic.PatientID != "")
						{
							XmlElement xmlElement = xmlDocument.CreateElement("PatientID");
							xmlElement.InnerText = ZYPublic.PatientID;
							xmlDocument.DocumentElement.AppendChild(xmlElement);
						}
						string outerXml = xmlDocument.DocumentElement.OuterXml;
						dataObject.SetData("emrtextdocument2005", outerXml);
					}
					Clipboard.SetDataObject(dataObject, copy: true);
					return true;
				}
			}
			catch (Exception sourceException)
			{
				ZYErrorReport.Instance.SourceException = sourceException;
				ZYErrorReport.Instance.SourceObject = this;
				ZYErrorReport.Instance.UserMessage = "复制数据错误";
				ZYErrorReport.Instance.ReportError();
			}
			return false;
		}

		public void _Paste()
		{
			if (!Locked)
			{
				try
				{
					IDataObject dataObject = Clipboard.GetDataObject();
					if (dataObject.GetDataPresent("emrtextdocument2005"))
					{
						XmlDocument xmlDocument = new XmlDocument();
						xmlDocument.PreserveWhitespace = true;
						string xml = (string)dataObject.GetData("emrtextdocument2005");
						xmlDocument.LoadXml(xml);
						ArrayList arrayList = new ArrayList();
						LoadElementsToList(xmlDocument.DocumentElement, arrayList);
						if (arrayList.Count > 0)
						{
							foreach (ZYTextElement item in arrayList)
							{
								if (item is ZYTextContainer)
								{
									(item as ZYTextContainer).ClearSaveLog();
								}
								item.RefreshSize();
							}
							BeginUpdate();
							BeginContentChangeLog();
							if (myContent.HasSelected())
							{
								myContent.DeleteSeleciton();
							}
							myContent.InsertRangeElements(arrayList);
							EndContentChangeLog();
							EndUpdate();
						}
					}
					else
					{
						string textFromClipboard = ClipboardHandler.GetTextFromClipboard();
						if (textFromClipboard != null)
						{
							BeginUpdate();
							BeginContentChangeLog();
							myContent.ReplaceSelection(textFromClipboard);
							myContentChangeLog.strUndoName = "粘贴";
							EndContentChangeLog();
							EndUpdate();
						}
					}
				}
				catch (Exception ex)
				{
					ZYErrorReport.Instance.DebugPrint("试图粘贴数据错误:" + ex.ToString());
				}
			}
		}

		public void SetSelectioinFontName(string NewFontName)
		{
			SetSelectionAttribute(0, NewFontName);
		}

		public void SetSelectionFontSize(int NewSize)
		{
			SetSelectionAttribute(1, NewSize.ToString());
		}

		public void SetSelectionFontBold(bool NewBold)
		{
			SetSelectionAttribute(2, NewBold ? "1" : "0");
		}

		public void SetSelectionFontItalic(bool NewItalic)
		{
			SetSelectionAttribute(3, NewItalic ? "1" : "0");
		}

		public void SetSelectionUnderLine(bool UnderLine)
		{
			SetSelectionAttribute(4, UnderLine ? "1" : "0");
		}

		public void SetSelectionColor(Color NewColor)
		{
			SetSelectionAttribute(5, NewColor.ToArgb().ToString());
		}

		public void SetSelectionSub(bool NewSub)
		{
			SetSelectionAttribute(7, NewSub ? "1" : "0");
		}

		public void SetSelectionSup(bool NewSup)
		{
			SetSelectionAttribute(8, NewSup ? "1" : "0");
		}

		private void SetSelectionAttribute(int index, string strValue)
		{
			bool flag = false;
			if (Locked)
			{
				return;
			}
			List<ZYTextElement> selectElements = myContent.GetSelectElements();
			ZYTextChar zYTextChar = null;
			ZYTextContainer zYTextContainer = null;
			ZYTextFlag zYTextFlag = null;
			ZYTextSelect zYTextSelect = null;
			BeginContentChangeLog();
			for (int i = 0; i < selectElements.Count; i++)
			{
				zYTextChar = (selectElements[i] as ZYTextChar);
				if (zYTextChar != null)
				{
					if (zYTextContainer != null && zYTextContainer != zYTextChar.Parent)
					{
						zYTextContainer.RefreshLine();
					}
					zYTextContainer = zYTextChar.Parent;
					switch (index)
					{
					default:
						return;
					case 0:
						zYTextChar.FontName = strValue;
						break;
					case 1:
						zYTextChar.FontSize = Convert.ToInt32(strValue);
						break;
					case 2:
						zYTextChar.FontBold = strValue.Equals("1");
						break;
					case 3:
						zYTextChar.FontItalic = strValue.Equals("1");
						break;
					case 4:
						zYTextChar.FontUnderLine = strValue.Equals("1");
						break;
					case 5:
						zYTextChar.ForeColor = Color.FromArgb(Convert.ToInt32(strValue));
						break;
					case 7:
						zYTextChar.Sub = strValue.Equals("1");
						break;
					case 8:
						zYTextChar.Sup = strValue.Equals("1");
						break;
					case 6:
						break;
					}
					zYTextChar.RefreshSize();
					flag = true;
					continue;
				}
				zYTextFlag = (selectElements[i] as ZYTextFlag);
				if (zYTextFlag != null)
				{
					if (zYTextContainer != null && zYTextContainer != zYTextFlag.Parent)
					{
						zYTextContainer.RefreshLine();
					}
					zYTextContainer = zYTextFlag.Parent;
					switch (index)
					{
					default:
						return;
					case 0:
						zYTextFlag.FontName = strValue;
						break;
					case 1:
						zYTextFlag.FontSize = Convert.ToInt32(strValue);
						break;
					case 2:
						zYTextFlag.FontBold = strValue.Equals("1");
						break;
					case 3:
						zYTextFlag.FontItalic = strValue.Equals("1");
						break;
					}
					zYTextFlag.RefreshSize();
					flag = true;
				}
				zYTextSelect = (selectElements[i] as ZYTextSelect);
				if (zYTextSelect != null)
				{
					if (zYTextContainer != null && zYTextContainer != zYTextSelect.Parent)
					{
						zYTextContainer.RefreshLine();
					}
					zYTextContainer = zYTextSelect.Parent;
					switch (index)
					{
					default:
						return;
					case 0:
						zYTextSelect.FontName = strValue;
						break;
					case 1:
						zYTextSelect.FontSize = Convert.ToInt32(strValue);
						break;
					case 2:
						zYTextSelect.FontBold = strValue.Equals("1");
						break;
					case 3:
						zYTextSelect.FontItalic = strValue.Equals("1");
						break;
					}
					zYTextSelect.RefreshSize();
					flag = true;
				}
			}
			myContentChangeLog.strUndoName = "设置属性" + strValue;
			EndContentChangeLog();
			if (flag)
			{
				RefreshLine();
				UpdateView();
				Refresh();
			}
		}

		public bool SetAlign(ParagraphAlignConst intAlign)
		{
			if (Locked)
			{
				return false;
			}
			bool flag = false;
			ArrayList selectParagraph = myContent.GetSelectParagraph();
			BeginContentChangeLog();
			foreach (ZYTextParagraph item in selectParagraph)
			{
				if (item.Align != intAlign)
				{
					item.Align = intAlign;
					flag = true;
				}
			}
			myContentChangeLog.strUndoName = "设置对齐方式";
			EndContentChangeLog();
			if (flag)
			{
				RefreshLine();
				UpdateView();
				Refresh();
				myContent.Modified = true;
			}
			return flag;
		}

		public ZYTextParagraph GetOwnerParagraph()
		{
			for (int i = myContent.SelectStart; i < myElements.Count; i++)
			{
				if (myElements[i] is ZYTextParagraph)
				{
					return myElements[i] as ZYTextParagraph;
				}
			}
			return null;
		}

		public bool InsertByXML(string strXML)
		{
			if (Locked)
			{
				return false;
			}
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(strXML);
			ZYTextElement zYTextElement = CreateElementByXML(xmlDocument.DocumentElement);
			if (zYTextElement != null)
			{
				myContent.InsertElement(zYTextElement);
			}
			return true;
		}

		public ZYTextChar CreateChar(char vChar)
		{
			ZYTextChar zYTextChar = ZYTextChar.Create(vChar);
			zYTextChar.OwnerDocument = this;
			zYTextChar.CreatorIndex = mySaveLogs.CurrentIndex;
			zYTextChar.Deleteted = false;
			zYTextChar.Font = myView.DefaultFont;
			zYTextChar.Visible = true;
			return zYTextChar;
		}

		public ZYTextChar CreateChar(char vChar, Font font)
		{
			ZYTextChar zYTextChar = ZYTextChar.Create(vChar);
			zYTextChar.OwnerDocument = this;
			zYTextChar.CreatorIndex = mySaveLogs.CurrentIndex;
			zYTextChar.Deleteted = false;
			zYTextChar.Font = font;
			zYTextChar.Visible = true;
			return zYTextChar;
		}

		public ArrayList CreateChars(string strText, ZYTextContainer vParent)
		{
			ArrayList arrayList = new ArrayList();
			ZYTextChar zYTextChar = null;
			foreach (char c in strText)
			{
				if (c != '\r' || c != '\n')
				{
					zYTextChar = ((!(vParent is ZYTextSelect)) ? CreateChar(c) : CreateChar(c, (vParent as ZYTextSelect).Font));
					if (zYTextChar != null)
					{
						zYTextChar.Parent = vParent;
						arrayList.Add(zYTextChar);
					}
				}
			}
			return arrayList;
		}

		public void ClearContent()
		{
			myMarks.Clear();
			myUndoList.Clear();
			myRedoList.Clear();
			myContentChangeLog = null;
			myInfo.FileName = null;
			foreach (ZYTextElement myElement in myElements)
			{
				if (myElement is IDisposable)
				{
					(myElement as IDisposable).Dispose();
				}
			}
			myDocumentElement = new ZYTextDiv();
			myDocumentElement.OwnerDocument = this;
			mySaveLogs.Clear();
			myDataSource.ClearQueryNames();
			myDataSource.ClearQueryVariables();
			myInfo.Title = "";
			myInfo.ID = "";
			RefreshElements();
			RefreshSize();
			RefreshLine();
			myContent.SetSelection(0, 0);
			Refresh();
		}

		public void ClearContentElementOnly()
		{
			foreach (ZYTextElement myElement in myElements)
			{
				if (myElement is IDisposable)
				{
					(myElement as IDisposable).Dispose();
				}
			}
			myDocumentElement = new ZYTextDiv();
			myDocumentElement.OwnerDocument = this;
			RefreshElements();
			RefreshSize();
			RefreshLine();
		}

		public bool DeleteAllElement()
		{
			bool result = true;
			foreach (ZYTextElement myElement in myElements)
			{
				if (myElement is IDisposable)
				{
					(myElement as IDisposable).Dispose();
				}
			}
			RefreshElements();
			RefreshSize();
			RefreshLine();
			return result;
		}

		public bool FromText(string strText)
		{
			myDocumentElement = new ZYTextDiv();
			myDocumentElement.OwnerDocument = this;
			LoadTextElementsToList(strText, myDocumentElement.ChildElements);
			return true;
		}

		public int LoadTextElementsToList(string strText, ArrayList myList)
		{
			int num = 0;
			if (strText == null || myList == null)
			{
				return -1;
			}
			foreach (char c in strText)
			{
				switch (c)
				{
				case '\n':
					myList.Add(new ZYTextParagraph());
					num++;
					break;
				default:
					myList.Add(CreateChar(c));
					num++;
					break;
				case '\r':
					break;
				}
			}
			return num;
		}

		public bool LoadElementsToList(XmlElement myElement, ArrayList myList)
		{
			ZYTextElement zYTextElement = null;
			foreach (XmlNode childNode in myElement.ChildNodes)
			{
				if (childNode.Name == "#text" || childNode.Name == "span")
				{
					string innerText = childNode.InnerText;
					if (innerText != null && innerText.Length > 0)
					{
						innerText = HttpUtility.HtmlDecode(innerText);
						innerText = innerText.Replace("\r", "");
						innerText = innerText.Replace("\n", "");
						if (innerText.Length > 0)
						{
							ZYTextChar zYTextChar = ZYTextChar.Create(' ');
							myList.Add(zYTextChar);
							if (childNode is XmlElement)
							{
								zYTextChar.FromXML(childNode as XmlElement);
							}
							else
							{
								zYTextChar.Char = innerText[0];
							}
							ZYTextChar zYTextChar2 = null;
							for (int i = 1; i < innerText.Length; i++)
							{
								zYTextChar2 = ZYTextChar.Create(innerText[i]);
								zYTextChar.Attributes.CopyTo(zYTextChar2.Attributes);
								zYTextChar2.UpdateAttrubute();
								zYTextChar2.CreatorIndex = zYTextChar.CreatorIndex;
								zYTextChar2.DeleterIndex = zYTextChar.DeleterIndex;
								myList.Add(zYTextChar2);
							}
						}
					}
				}
				else
				{
					XmlElement xmlElement = childNode as XmlElement;
					if (xmlElement != null)
					{
						zYTextElement = CreateElement(xmlElement.Name);
						if (zYTextElement != null && zYTextElement.FromXML(xmlElement))
						{
							myList.Add(zYTextElement);
						}
					}
				}
			}
			foreach (ZYTextElement my in myList)
			{
				my.OwnerDocument = this;
			}
			return true;
		}

		public bool LoadElementsToList(XmlElement myElement, List<ZYTextElement> myList)
		{
			ZYTextElement zYTextElement = null;
			foreach (XmlNode childNode in myElement.ChildNodes)
			{
				if (childNode.Name == "#text" || childNode.Name == "span")
				{
					string innerText = childNode.InnerText;
					if (innerText != null && innerText.Length > 0)
					{
						innerText = HttpUtility.HtmlDecode(innerText);
						innerText = innerText.Replace("\r", "");
						innerText = innerText.Replace("\n", "");
						if (innerText.Length > 0)
						{
							ZYTextChar zYTextChar = ZYTextChar.Create(' ');
							myList.Add(zYTextChar);
							if (childNode is XmlElement)
							{
								zYTextChar.FromXML(childNode as XmlElement);
							}
							else
							{
								zYTextChar.Char = innerText[0];
							}
							ZYTextChar zYTextChar2 = null;
							for (int i = 1; i < innerText.Length; i++)
							{
								zYTextChar2 = ZYTextChar.Create(innerText[i]);
								zYTextChar.Attributes.CopyTo(zYTextChar2.Attributes);
								zYTextChar2.UpdateAttrubute();
								zYTextChar2.CreatorIndex = zYTextChar.CreatorIndex;
								zYTextChar2.DeleterIndex = zYTextChar.DeleterIndex;
								myList.Add(zYTextChar2);
							}
						}
					}
				}
				else
				{
					XmlElement xmlElement = childNode as XmlElement;
					if (xmlElement != null)
					{
						zYTextElement = CreateElement(xmlElement.Name);
						if (zYTextElement != null && zYTextElement.FromXML(xmlElement))
						{
							myList.Add(zYTextElement);
						}
					}
				}
			}
			foreach (ZYTextElement my in myList)
			{
				my.OwnerDocument = this;
			}
			return true;
		}

		public bool FromXMLFile(string strURL)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.PreserveWhitespace = true;
			xmlDocument.Load(strURL);
			if (FromXML(xmlDocument.DocumentElement))
			{
				myInfo.FileName = strURL;
				return true;
			}
			return false;
		}

		public bool FromXML(XmlElement RootElement)
		{
			bolLoading = true;
			myUndoList.Clear();
			myRedoList.Clear();
			RootElement.OwnerDocument.PreserveWhitespace = true;
			myDataSource.ClearQueryVariables();
			myDataSource.ClearQueryNames();
			mySaveLogs.Clear();
			myMarks.Clear();
			ClearContent();
			myDocumentElement = null;
			if (myInfo.EnableSaveLog)
			{
				myMarks.FromXML(XMLCommon.CreateChildElement(RootElement, myMarks.GetXMLName(), bolCreate: false));
				mySaveLogs.FromXML(XMLCommon.CreateChildElement(RootElement, mySaveLogs.GetXMLName(), bolCreate: false));
			}
			else
			{
				myMarks.FromXML(null);
				mySaveLogs.FromXML(null);
			}
			myInfo.VisibleUserLevel = -1;
			myVariables.Clear();
			XmlElement elementByName = XMLCommon.GetElementByName(RootElement, "values", Deep: false);
			if (elementByName != null)
			{
				foreach (XmlNode childNode in elementByName.ChildNodes)
				{
					XmlElement xmlElement = childNode as XmlElement;
					if (xmlElement != null)
					{
						myVariables.SetValue(xmlElement.GetAttribute("name"), xmlElement.InnerText);
					}
				}
			}
			strHeadString = XMLCommon.GetElementValue(RootElement, "headstring");
			HeadHeight = StringCommon.ToInt32Value(XMLCommon.GetElementValue(RootElement, "headheight"), 0);
			FooterString = XMLCommon.GetElementValue(RootElement, "footerstring");
			FooterHeight = StringCommon.ToInt32Value(XMLCommon.GetElementValue(RootElement, "footerheight"), 0);
			myInfo.FromXML(XMLCommon.GetElementByName(RootElement, ZYDocumentInfo.GetXMLName(), Deep: false));
			myScript.FromXML(XMLCommon.GetElementByName(RootElement, myScript.GetXMLName(), Deep: false));
			myScript.ScriptModified = true;
			InvokeScriptMethod("document_preopen", null, null);
			XmlElement bodyElement = GetBodyElement(RootElement);
			if (bodyElement != null)
			{
				myDocumentElement = (CreateElementByXML(bodyElement) as ZYTextContainer);
				if (myDocumentElement != null)
				{
					myDocumentElement.UpdateUserLogin();
				}
			}
			foreach (XmlNode childNode2 in RootElement.ChildNodes)
			{
				if (childNode2.Name == "div" || childNode2.Name == "body")
				{
					myDocumentElement = (CreateElementByXML(childNode2 as XmlElement) as ZYTextContainer);
					if (myDocumentElement != null)
					{
						myDocumentElement.OwnerDocument = this;
						myDocumentElement.UpdateUserLogin();
						break;
					}
				}
			}
			myContent.SetSelection(0, 0);
			RefreshElements();
			UpdateUserName();
			InvokeScriptMethod("document_open", null, null);
			bolLoading = false;
			Modified = false;
			return true;
		}

		public bool FromXMLCanUndo(XmlElement RootElement)
		{
			bolLoading = true;
			RootElement.OwnerDocument.PreserveWhitespace = true;
			myDataSource.ClearQueryVariables();
			myDataSource.ClearQueryNames();
			myInfo.VisibleUserLevel = -1;
			myVariables.Clear();
			XmlElement elementByName = XMLCommon.GetElementByName(RootElement, "values", Deep: false);
			if (elementByName != null)
			{
				foreach (XmlNode childNode in elementByName.ChildNodes)
				{
					XmlElement xmlElement = childNode as XmlElement;
					if (xmlElement != null)
					{
						myVariables.SetValue(xmlElement.GetAttribute("name"), xmlElement.InnerText);
					}
				}
			}
			strHeadString = XMLCommon.GetElementValue(RootElement, "headstring");
			HeadHeight = StringCommon.ToInt32Value(XMLCommon.GetElementValue(RootElement, "headheight"), 0);
			FooterString = XMLCommon.GetElementValue(RootElement, "footerstring");
			FooterHeight = StringCommon.ToInt32Value(XMLCommon.GetElementValue(RootElement, "footerheight"), 0);
			myInfo.FromXML(XMLCommon.GetElementByName(RootElement, ZYDocumentInfo.GetXMLName(), Deep: false));
			myScript.FromXML(XMLCommon.GetElementByName(RootElement, myScript.GetXMLName(), Deep: false));
			myScript.ScriptModified = true;
			InvokeScriptMethod("document_preopen", null, null);
			XmlElement bodyElement = GetBodyElement(RootElement);
			if (bodyElement != null)
			{
				myDocumentElement = (CreateElementByXML(bodyElement) as ZYTextContainer);
				if (myDocumentElement != null)
				{
					myDocumentElement.UpdateUserLogin();
				}
			}
			foreach (XmlNode childNode2 in RootElement.ChildNodes)
			{
				if (childNode2.Name == "div" || childNode2.Name == "body")
				{
					myDocumentElement = (CreateElementByXML(childNode2 as XmlElement) as ZYTextContainer);
					if (myDocumentElement != null)
					{
						myDocumentElement.OwnerDocument = this;
						myDocumentElement.UpdateUserLogin();
						break;
					}
				}
			}
			myContent.SetSelection(0, 0);
			RefreshElements();
			UpdateUserName();
			InvokeScriptMethod("document_open", null, null);
			bolLoading = false;
			Modified = false;
			return true;
		}

		public static XmlElement GetBodyElement(XmlElement RootElement)
		{
			if (RootElement != null)
			{
				foreach (XmlNode childNode in RootElement.ChildNodes)
				{
					if (childNode.Name == "div" || childNode.Name == "body")
					{
						return (XmlElement)childNode;
					}
				}
			}
			return null;
		}

		internal string GetKBValue(int intKB)
		{
			return null;
		}

		public ZYTextElement CreateElementByXML(XmlElement myElement)
		{
			if (myElement == null)
			{
				return null;
			}
			ZYTextElement zYTextElement = CreateElement(myElement.Name);
			if (zYTextElement != null)
			{
				FillDataSource(myElement);
				zYTextElement.FromXML(myElement);
				zYTextElement.OwnerDocument = this;
				return zYTextElement;
			}
			return null;
		}

		public bool FillDataSource(XmlElement myElement)
		{
			if (!myInfo.EnableDataSource)
			{
				return true;
			}
			myDataSource.ClearQueryNames();
			AddDataSourceQueryName(myElement);
			return true;
		}

		private void FillDataSourceElement(XmlElement myElement, XmlNodeList DataNodeList)
		{
			if (myElement.Name == "select" && myElement.HasAttribute("listsource"))
			{
				string b = myElement.GetAttribute("listsource").Trim();
				foreach (XmlElement DataNode in DataNodeList)
				{
					if (DataNode.GetAttribute("name") == b)
					{
						while (myElement.FirstChild != null)
						{
							myElement.RemoveChild(myElement.FirstChild);
						}
						foreach (XmlNode childNode in DataNode.ChildNodes)
						{
							myElement.AppendChild(myElement.OwnerDocument.ImportNode(childNode, deep: true));
						}
					}
				}
			}
			if ((myElement.Name == "span" || myElement.Name == "select") && myElement.HasAttribute("source"))
			{
				string b = myElement.GetAttribute("source").Trim();
				foreach (XmlElement DataNode2 in DataNodeList)
				{
					if (DataNode2.GetAttribute("name") == b)
					{
						if (myElement.Name == "span")
						{
							myElement.InnerText = DataNode2.InnerText;
						}
						else
						{
							myElement.SetAttribute("value", DataNode2.InnerText);
						}
						return;
					}
				}
			}
			foreach (XmlNode childNode2 in myElement.ChildNodes)
			{
				if (childNode2 is XmlElement)
				{
					FillDataSourceElement((XmlElement)childNode2, DataNodeList);
				}
			}
		}

		private void AddDataSourceQueryName(XmlElement myElement)
		{
			if ((myElement.Name == "span" || myElement.Name == "select") && myElement.HasAttribute("source"))
			{
				string attribute = myElement.GetAttribute("source");
				if (attribute != null && attribute.Trim().Length > 0)
				{
					attribute = attribute.Trim();
					myDataSource.AddQueryName(attribute);
				}
			}
			if (myElement.Name == "select" && myElement.HasAttribute("listsource"))
			{
				string attribute = myElement.GetAttribute("listsource");
				if (attribute != null && attribute.Trim().Length > 0)
				{
					attribute = attribute.Trim();
					myDataSource.AddQueryName(attribute);
				}
			}
			foreach (XmlNode childNode in myElement.ChildNodes)
			{
				if (childNode is XmlElement)
				{
					AddDataSourceQueryName(childNode as XmlElement);
				}
			}
		}

		public static bool isElementXMLName(string strName)
		{
			string[] array = new string[3]
			{
				"span",
				"div",
				"image"
			};
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].Equals(strName))
				{
					return true;
				}
			}
			return false;
		}

		public bool ToXML(XmlElement RootElement)
		{
			if (RootElement != null)
			{
				RootElement.OwnerDocument.PreserveWhitespace = true;
				if (myInfo.SaveMode == 3)
				{
					if (myDocumentElement != null)
					{
						myDocumentElement.ToXML(RootElement);
					}
				}
				else
				{
					RootElement.SetAttribute("version", "1.0");
					RootElement.SetAttribute("checkcount", myMarks.Count.ToString());
					RootElement.SetAttribute("senior", myMarks.LastSenior);
					mySaveLogs.CurrentSaveLog.SaveDateTime = ZYTime.GetServerTime();
					if (myMarks.NewMark != null)
					{
						myMarks.NewMark.MarkTime = mySaveLogs.CurrentSaveLog.SaveDateTime;
					}
					if (myInfo.EnableSaveLog)
					{
						myMarks.ToXML(XMLCommon.CreateChildElement(RootElement, myMarks.GetXMLName(), bolCreate: true));
						mySaveLogs.ToXML(XMLCommon.CreateChildElement(RootElement, mySaveLogs.GetXMLName(), bolCreate: true));
					}
					myInfo.ModifyTime = StringCommon.GetNowString14();
					myInfo.ModifyTime = ZYTime.GetServerTime().ToString("yyyyMMddHHmmss");
					myInfo.Version = "1.0";
					myInfo.Modifier = mySaveLogs.CurrentIndex.ToString();
					XMLCommon.SetElementValue(RootElement, "headstring", HeadString);
					XMLCommon.SetElementValue(RootElement, "headheight", HeadHeight.ToString());
					XMLCommon.SetElementValue(RootElement, "footerstring", FooterString);
					XMLCommon.SetElementValue(RootElement, "footerheight", FooterHeight.ToString());
					myInfo.ToXML(XMLCommon.CreateChildElement(RootElement, ZYDocumentInfo.GetXMLName(), bolCreate: true));
					if (myVariables.Count > 0)
					{
						XmlElement xmlElement = XMLCommon.CreateChildElement(RootElement, "values", bolCreate: true);
						for (int i = 0; i < myVariables.Count; i++)
						{
							XmlElement xmlElement2 = RootElement.OwnerDocument.CreateElement("value");
							xmlElement2.SetAttribute("name", myVariables.GetName(i));
							xmlElement2.InnerText = myVariables.GetValue(i);
							xmlElement.AppendChild(xmlElement2);
						}
					}
					myScript.ToXML(XMLCommon.CreateChildElement(RootElement, myScript.GetXMLName(), bolCreate: true));
					if (myInfo.SaveMode == 0)
					{
						XmlElement xmlElement3 = XMLCommon.CreateChildElement(RootElement, "text", bolCreate: true);
						StringBuilder stringBuilder = new StringBuilder();
						myDocumentElement.GetFinalText(stringBuilder);
						xmlElement3.InnerText = stringBuilder.ToString();
					}
					if (myDocumentElement != null)
					{
						myDocumentElement.ToXML(XMLCommon.CreateChildElement(RootElement, "body", bolCreate: true));
					}
				}
				return true;
			}
			return false;
		}

		public bool ToXMLFile(string strURL)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.AppendChild(xmlDocument.CreateElement("emrtextdoc"));
			if (ToXML(xmlDocument.DocumentElement))
			{
				xmlDocument.PreserveWhitespace = true;
				if (xmlDocument.GetElementsByTagName("headstring").Count > 0)
				{
					xmlDocument.DocumentElement.RemoveChild(xmlDocument.GetElementsByTagName("headstring")[0]);
					xmlDocument.DocumentElement.RemoveChild(xmlDocument.GetElementsByTagName("headheight")[0]);
				}
				if (xmlDocument.GetElementsByTagName("footerstring").Count > 0)
				{
					xmlDocument.DocumentElement.RemoveChild(xmlDocument.GetElementsByTagName("footerstring")[0]);
					xmlDocument.DocumentElement.RemoveChild(xmlDocument.GetElementsByTagName("footerheight")[0]);
				}
				xmlDocument.Save(strURL);
				return true;
			}
			return false;
		}

		public bool ToXMLDocument(XmlDocument myDoc)
		{
			myDoc.PreserveWhitespace = true;
			myDoc.LoadXml("<emrtextdoc/>");
			return ToXML(myDoc.DocumentElement);
		}

		public void HideCaret()
		{
			if (myOwnerControl != null)
			{
				myOwnerControl.HideOwnerCaret();
			}
		}

		public void BeginUpdate()
		{
			if (myOwnerControl != null)
			{
				myOwnerControl.BeginUpdate();
			}
		}

		public void EndUpdate()
		{
			if (myOwnerControl != null)
			{
				if (ElementsDirty)
				{
					RefreshElements();
					RefreshLine();
				}
				myOwnerControl.EndUpdate();
				if (!myOwnerControl.Updating)
				{
					UpdateView();
				}
			}
		}

		public void UpdateView()
		{
			if (UpdateViewNoScroll())
			{
				UpdateTextCaret();
			}
		}

		public void UpdateTextCaret()
		{
			if (myOwnerControl != null)
			{
				myOwnerControl.UpdateTextCaret();
			}
		}

		public bool UpdateViewNoScroll()
		{
			if (myOwnerControl != null && !myOwnerControl.Updating)
			{
				myOwnerControl.UpdatePages();
				myOwnerControl.UpdateInvalidateRect();
				if (RefreshAllFlag)
				{
					myOwnerControl.Refresh();
					RefreshAllFlag = false;
				}
				return true;
			}
			return false;
		}

		public bool isNeedDraw(ZYTextElement myElement)
		{
			if (myElement == null)
			{
				return false;
			}
			return myView.isNeedDraw(myElement.RealLeft, myElement.RealTop, myElement.Width, myElement.Height);
		}

		public bool isNeedDraw(Rectangle myRect)
		{
			return myView.isNeedDraw(myRect);
		}

		public bool isNeedDraw(int vLeft, int vTop, int vWidth, int vHeight)
		{
			return myView.isNeedDraw(vLeft, vTop, vWidth, vHeight);
		}

		public bool RefreshLine()
		{
			myLines.Clear();
			UpdatePageSetting();
			if (myDocumentElement != null)
			{
				myDocumentElement.RefreshLine();
				RefreshPages();
				if (myOwnerControl != null)
				{
					myOwnerControl.UpdatePages();
				}
				ElementsDirty = false;
			}
			return true;
		}

		public void UpdatePageSetting()
		{
			myPages.HeadHeight = HeadHeight;
			myPages.FooterHeight = FooterHeight;
		}

		public void RefreshPages()
		{
			myPages.Clear();
			myPages.DocumentHeight = myDocumentElement.Height;
			myPages.HeadHeight = HeadHeight;
			myPages.FooterHeight = FooterHeight;
			myPages.Top = 0;
			int height = myDocumentElement.Height;
			int vLastPos = myPages.Top;
			myPages.MinPageHeight = 15;
			while (myPages.Height < height)
			{
				PrintPage printPage = myPages.NewPage();
				PageLineInfo pageLineInfo = new PageLineInfo(myPages.Top, vLastPos, printPage.Bottom, myPages.Count);
				pageLineInfo.MinPageHeight = myPages.MinPageHeight;
				FixPageLine(pageLineInfo);
				printPage.Height = pageLineInfo.Pos - printPage.Top;
				if (printPage.Height < myPages.MinPageHeight)
				{
					printPage.Height = myPages.StandardHeight;
				}
				vLastPos = printPage.Bottom;
				myPages.Add(printPage);
				if (ZYConfig.IsFirstPageOnly && !myInfo.DesignMode)
				{
					break;
				}
			}
			if (myPages.Height < height && ZYConfig.IsFirstPageOnly && !myInfo.DesignMode)
			{
			}
			if (myPages.Count > 0)
			{
				myPages.LastPage.Height = myPages.LastPage.Height - (myPages.Height - height);
			}
		}

		internal int FixPageLine(int Pos)
		{
			PageLineInfo pageLineInfo = new PageLineInfo(0, 0, Pos, 0);
			FixPageLine(pageLineInfo);
			return pageLineInfo.Pos;
		}

		public void FixPageLine(PageLineInfo info)
		{
			int pos = info.Pos;
			int num = 10000;
			ZYTextLine zYTextLine = null;
			foreach (ZYTextLine myLine in myLines)
			{
				int realTop = myLine.RealTop;
				if (pos >= realTop && pos - realTop < num && pos < realTop + myLine.FullHeight)
				{
					zYTextLine = myLine;
					num = pos - realTop;
				}
			}
			if (zYTextLine != null)
			{
				info.Pos = zYTextLine.RealTop;
			}
			else
			{
				info.Pos = myDocumentElement.Top + myDocumentElement.Height;
			}
		}

		public bool RefreshSize()
		{
			if (myDocumentElement != null)
			{
				myDocumentElement.Left = 0;
				myDocumentElement.Top = 0;
				myDocumentElement.RefreshSize();
				myDocumentElement.RefreshLine();
				myView.Height = myDocumentElement.Top + myDocumentElement.Height;
			}
			return true;
		}

		private bool DrawAll()
		{
			myDocumentElement.RefreshView();
			return true;
		}

		public void Refresh()
		{
			if (myOwnerControl != null)
			{
				myOwnerControl.Invalidate();
			}
		}

		public void RefreshElement(ZYTextElement myElement)
		{
			if (myOwnerControl != null)
			{
				if (myElement is ZYTextContainer)
				{
					myOwnerControl.AddInvalidateRect((myElement as ZYTextContainer).GetContentBounds());
				}
				else
				{
					myOwnerControl.AddInvalidateRect(myElement.RealLeft, myElement.RealTop, myElement.Width + myElement.WidthFix, myElement.OwnerLine.Height);
				}
				myOwnerControl.UpdateInvalidateRect();
			}
		}

		public Bitmap GetPreViewImage()
		{
			return GetPreViewImage(0, 0);
		}

		public Bitmap GetPreViewImage(int ImgWidth, int ImgHeight)
		{
			bool showParagraphFlag = myInfo.ShowParagraphFlag;
			myInfo.ShowParagraphFlag = false;
			myInfo.Printing = true;
			Bitmap bitmap = myView.GetBitmap(RefreshSize, DrawAll, ImgWidth, ImgHeight);
			myInfo.ShowParagraphFlag = showParagraphFlag;
			myInfo.Printing = false;
			return bitmap;
		}

		public Bitmap GetPreViewImage(int PageIndex)
		{
			DocumentPageDrawer documentPageDrawer = new DocumentPageDrawer();
			documentPageDrawer.Document = this;
			documentPageDrawer.Pages = Pages;
			bool showParagraphFlag = myInfo.ShowParagraphFlag;
			myInfo.ShowParagraphFlag = false;
			myInfo.Printing = true;
			Bitmap pageBmp = documentPageDrawer.GetPageBmp(PageIndex, DrawMargin: false);
			myInfo.ShowParagraphFlag = showParagraphFlag;
			myInfo.Printing = false;
			return pageBmp;
		}

		public int ShowPopupList(int x, int y, int height, object[] items, string strDefaultText)
		{
			if (!CheckKBLoaded())
			{
				return -1;
			}
			return myOwnerControl.ShowPopupList(x, y, height, items, strDefaultText);
		}

		public object ShowKBPopupList(ZYTextElement myElement)
		{
			if (!CheckKBLoaded())
			{
				return null;
			}
			object result = myOwnerControl.ShowKBPopupList(myElement);
			if (myOwnerControl != null)
			{
				myOwnerControl.HidePopupList();
			}
			return result;
		}

		public void DrawNewBackGround(int intLevel, int vLeft, int vTop, int vWidth, int vHeight)
		{
			if (myInfo.ShowMark)
			{
				switch (intLevel)
				{
				case 0:
					myView.FillRectangle(SystemColors.Info, vLeft, vTop, vWidth, vHeight);
					break;
				case 1:
					myView.FillRectangle(SystemColors.Info, vLeft, vTop, vWidth, vHeight);
					myView.DrawLine(SystemColors.Highlight, vLeft, vTop + vHeight - 1, vLeft + vWidth, vTop + vHeight - 1);
					break;
				default:
					myView.FillRectangle(SystemColors.Info, vLeft, vTop, vWidth, vHeight);
					myView.DrawLine(SystemColors.Highlight, vLeft, vTop + vHeight - 1, vLeft + vWidth, vTop + vHeight - 1);
					myView.DrawLine(SystemColors.Highlight, vLeft, vTop + vHeight - 3, vLeft + vWidth, vTop + vHeight - 3);
					break;
				}
			}
		}

		public void DrawDeleteLine(int intLevel, int vLeft, int vTop, int vWidth, int vHeight)
		{
			if (myInfo.ShowMark)
			{
				myView.DrawDeleteLine(vLeft, vTop, vWidth, vHeight, (intLevel <= 1) ? 1 : 2);
			}
		}

		public bool ViewTimer()
		{
			if (bolLastContentChangedFlag)
			{
				bolLastContentChangedFlag = false;
				ZYEditorAction actionByName = GetActionByName("contentchanged");
				if (actionByName != null && actionByName.isEnable())
				{
					actionByName.Execute();
					return true;
				}
			}
			return false;
		}

		public void DrawHead(Graphics g, Rectangle ClipRectangle)
		{
			DrawExtString(RuntimeHeadString, g, ClipRectangle);
		}

		public void DrawFooter(Graphics g, Rectangle ClipRectangle)
		{
			DrawExtString(RuntimeFooterString, g, ClipRectangle);
		}

		private void DrawExtString(string txt, Graphics g, Rectangle ClipRectangle)
		{
			Font defaultFont = Control.DefaultFont;
			if (txt.IndexOf("<") == -1 || txt.IndexOf(">") == -1)
			{
				using (StringFormat stringFormat = new StringFormat())
				{
					stringFormat.Alignment = StringAlignment.Near;
					stringFormat.LineAlignment = StringAlignment.Near;
				}
				return;
			}
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(txt);
			int num = ClipRectangle.Top;
			int left = ClipRectangle.Left;
			using (StringFormat stringFormat = new StringFormat())
			{
				stringFormat.Alignment = StringAlignment.Near;
				stringFormat.LineAlignment = StringAlignment.Center;
				stringFormat.FormatFlags = StringFormatFlags.NoWrap;
				foreach (XmlNode childNode in xmlDocument.DocumentElement.ChildNodes)
				{
					if (childNode is XmlElement)
					{
						XmlElement xmlElement = (XmlElement)childNode;
						string text = defaultFont.Name;
						if (xmlElement.HasAttribute("fontname"))
						{
							text = xmlElement.GetAttribute("fontname");
						}
						int num2 = (int)defaultFont.Size;
						if (xmlElement.HasAttribute("fontsize"))
						{
							num2 = Convert.ToInt32(xmlElement.GetAttribute("fontsize"));
						}
						FontStyle fontStyle = FontStyle.Regular;
						if (xmlElement.HasAttribute("bold"))
						{
							fontStyle |= FontStyle.Bold;
						}
						if (xmlElement.HasAttribute("italic"))
						{
							fontStyle |= FontStyle.Italic;
						}
						if (xmlElement.HasAttribute("underline"))
						{
							fontStyle |= FontStyle.Underline;
						}
						stringFormat.Alignment = StringAlignment.Near;
						if (xmlElement.HasAttribute("left"))
						{
							stringFormat.Alignment = StringAlignment.Near;
						}
						if (xmlElement.HasAttribute("center"))
						{
							stringFormat.Alignment = StringAlignment.Center;
						}
						if (xmlElement.HasAttribute("right"))
						{
							stringFormat.Alignment = StringAlignment.Far;
						}
						switch (xmlElement.Name)
						{
						case "line":
						{
							using (Pen pen = new Pen(Color.Black))
							{
								if (xmlElement.HasAttribute("thick"))
								{
									pen.Width = Convert.ToInt32(xmlElement.GetAttribute("thick"));
								}
								float num4 = g.MeasureString("#", new Font(text, num2, fontStyle), 10000, stringFormat).Height + 10f;
								float num8 = 0f;
								if (num4 > pen.Width)
								{
									num8 = (float)num + (num4 - pen.Width) / 2f;
								}
								else
								{
									num8 = num;
									num4 = pen.Width + 20f;
								}
								g.DrawLine(pen, ClipRectangle.Left, num8, ClipRectangle.Right, num8);
								num += (int)num4;
							}
							break;
						}
						case "text":
						{
							using (Font font3 = new Font(text, num2, fontStyle))
							{
								float num4 = g.MeasureString("#", font3, 10000, stringFormat).Height + 10f;
								RectangleF layoutRectangle2 = new RectangleF(ClipRectangle.Left, num, ClipRectangle.Width, num4);
								if (!(layoutRectangle2.Bottom > (float)ClipRectangle.Bottom))
								{
									string innerText = xmlElement.InnerText;
									if (innerText != null && innerText.Length > 0)
									{
										try
										{
											g.DrawString(innerText, font3, Brushes.Black, layoutRectangle2, stringFormat);
										}
										catch (Exception ex)
										{
											MessageBox.Show("文本行错误：" + ex.Message);
											throw ex;
										}
									}
									num += (int)Math.Ceiling(num4);
								}
							}
							break;
						}
						case "textimg":
						{
							float num3 = ClipRectangle.Left;
							Font font = new Font(text, num2, fontStyle);
							float num4 = g.MeasureString("#", font, 10000, stringFormat).Height + 50f;
							foreach (XmlNode childNode2 in xmlElement.ChildNodes)
							{
								XmlElement xmlElement2 = (XmlElement)childNode2;
								string familyName = text;
								int num5 = num2;
								FontStyle fontStyle2 = fontStyle;
								StringFormat stringFormat2 = (StringFormat)stringFormat.Clone();
								if (xmlElement2.HasAttribute("fontname"))
								{
									familyName = xmlElement2.GetAttribute("fontname");
								}
								if (xmlElement2.HasAttribute("fontsize"))
								{
									num5 = Convert.ToInt32(xmlElement2.GetAttribute("fontsize"));
								}
								if (xmlElement2.HasAttribute("bold"))
								{
									fontStyle2 |= FontStyle.Bold;
								}
								if (xmlElement2.HasAttribute("italic"))
								{
									fontStyle2 |= FontStyle.Italic;
								}
								if (xmlElement2.HasAttribute("underline"))
								{
									fontStyle2 |= FontStyle.Underline;
								}
								if (xmlElement2.HasAttribute("left"))
								{
									stringFormat2.Alignment = StringAlignment.Near;
								}
								if (xmlElement2.HasAttribute("center"))
								{
									stringFormat2.Alignment = StringAlignment.Center;
								}
								if (xmlElement2.HasAttribute("right"))
								{
									stringFormat2.Alignment = StringAlignment.Far;
								}
								Font font2 = new Font(familyName, num5, fontStyle2);
								float num6 = 0f;
								switch (childNode2.Name)
								{
								case "img":
									if (string.IsNullOrEmpty(childNode2.InnerText))
									{
										num6 = g.MeasureString("测试", font2, 10000, stringFormat2).Width;
									}
									else
									{
										Image image = StringCommon.ImageFromBase64String(childNode2.InnerText);
										float num7 = num4 + 50f;
										num6 = (float)image.Width * num7 / (float)image.Height;
										RectangleF destRect = new RectangleF(num3, num, num6, num7);
										g.DrawImage(image, destRect, new RectangleF(0f, 0f, image.Width, image.Height), GraphicsUnit.Pixel);
										image.Dispose();
									}
									break;
								case "text":
								{
									num6 = g.MeasureString(childNode2.InnerText, font2, 10000, stringFormat).Width;
									RectangleF layoutRectangle = new RectangleF(num3, num + 25, num6, num4);
									try
									{
										g.DrawString(childNode2.InnerText, font2, Brushes.Black, layoutRectangle, stringFormat);
									}
									catch (Exception ex)
									{
										MessageBox.Show(" 图文混合行错误：" + ex.Message);
										throw ex;
									}
									break;
								}
								}
								num3 += num6;
							}
							num += (int)Math.Ceiling(num4);
							break;
						}
						}
					}
				}
			}
		}

		public void DrawDocument(Graphics g, Rectangle ClipRectangle)
		{
			myView.ViewRect = ClipRectangle;
			Graphics innerGraph = myView.GetInnerGraph();
			myView.Graph = g;
			InitEventObject(ZYVBEventType.Paint);
			if (myDocumentElement != null)
			{
				myDocumentElement.RefreshView();
			}
			myView.Graph = innerGraph;
		}

		public bool ViewPaint(Graphics g, Rectangle ClipRect)
		{
			myView.ViewRect = ClipRect;
			Graphics innerGraph = myView.GetInnerGraph();
			myView.Graph = g;
			InitEventObject(ZYVBEventType.Paint);
			if (myDocumentElement != null)
			{
				myDocumentElement.RefreshView();
			}
			myView.Graph = innerGraph;
			return true;
		}

		public bool ViewNewChar(char c)
		{
			bool flag = false;
			InitEventObject(ZYVBEventType.KeyPress);
			foreach (ZYEditorAction myAction in myActions)
			{
				if (myAction.isEnable() && !myAction.CanHandleKeyDown() && myAction.TestHotKey((Keys)c, vShift: false, vControl: false, vAlt: false))
				{
					myAction.KeyCode = (Keys)c;
					myAction.ShiftKey = false;
					myAction.ControlKey = false;
					myAction.AltKey = false;
					flag = myAction.Execute();
					break;
				}
			}
			return true;
		}

		public bool ViewKeyDown(Keys KeyCode, bool Alt, bool Control, bool Shift)
		{
			InitEventObject(ZYVBEventType.KeyDown);
			ZYTextElement currentElement = myContent.CurrentElement;
			foreach (ZYEditorAction myAction in myActions)
			{
				if (myAction.isEnable() && myAction.CanHandleKeyDown() && myAction.TestHotKey(KeyCode, Shift, Control, Alt))
				{
					myAction.KeyCode = KeyCode;
					myAction.ShiftKey = Shift;
					myAction.ControlKey = Control;
					myAction.AltKey = Alt;
					myAction.Execute();
					break;
				}
			}
			return true;
		}

		public bool ViewKeyUp(Keys KeyCode, bool Alt, bool Control, bool Shift)
		{
			InitEventObject(ZYVBEventType.KeyUp);
			return true;
		}

		public bool ViewMouseDown(int x, int y, MouseButtons Button)
		{
			InitEventObject(ZYVBEventType.MouseDown);
			if (Button == MouseButtons.Right)
			{
				if (myContent.SelectLength == 0)
				{
					myContent.AutoClearSelection = true;
					myContent.MoveTo(x, y);
				}
				return true;
			}
			if (myDocumentElement != null && Button == MouseButtons.Left && myDocumentElement.HandleMouseDown(x, y, Button))
			{
				myOwnerControl.CaptureMouse = false;
				return true;
			}
			myContent.AutoClearSelection = !myOwnerControl.HasShiftPressing();
			myContent.MoveTo(x, y);
			myOwnerControl.UpdateTextCaret();
			myOwnerControl.UseAbsTransformPoint = true;
			return true;
		}

		public bool ViewMouseMove(int x, int y, MouseButtons Button)
		{
			InitEventObject(ZYVBEventType.MouseMove);
			ToolTipImageIndex = -1;
			if (myOwnerControl.CaptureMouse)
			{
				myContent.AutoClearSelection = false;
				myContent.MoveTo(x, y);
				ZYTextElement currentElement = myContent.CurrentElement;
				myOwnerControl.MoveCaretWithScroll = false;
				myOwnerControl.UpdateTextCaret();
				myOwnerControl.MoveCaretWithScroll = true;
			}
			else
			{
				if (Button != 0)
				{
					return false;
				}
				strToolTip = null;
				ZYTextElement elementAt = myContent.GetElementAt(x, y);
				if (isSelected(elementAt) && !(elementAt is ZYTextObject))
				{
					myCursor = Cursors.Default;
				}
				else
				{
					myCursor = Cursors.IBeam;
					myDocumentElement.HandleMouseMove(x, y, Button);
					if (myOwnerControl != null && !myOwnerControl.StaticToolTip)
					{
						foreach (ZYTextElement myElement in myElements)
						{
							bool flag = false;
							if (myElement.Bounds.Contains(x, y) && myElement is ZYTextLock)
							{
								ZYTextLock zYTextLock = (ZYTextLock)myElement;
								string text = strToolTip = zYTextLock.DateTime.ToString("yyyy年MM月dd日 HH:mm") + " " + zYTextLock.UserName + " 签定";
								myCursor = Cursors.Default;
								break;
							}
							if (myElement.Bounds.Contains(x, y) || (myElement is ZYTextBlock && (myElement as ZYTextContainer).Contains(x, y)))
							{
								if (mySaveLogs.IndexAvailable(myElement.CreatorIndex) && ZYConfig.IsShowSaveLogInsert)
								{
									ZYTextSaveLog zYTextSaveLog = mySaveLogs[myElement.CreatorIndex];
									string text = zYTextSaveLog.DisplayDateTime + " " + zYTextSaveLog.UserName + " 输入";
									strToolTip = ((strToolTip == null) ? text : (strToolTip + "\r\n" + text));
									flag = true;
								}
								if (mySaveLogs.IndexAvailable(myElement.DeleterIndex))
								{
									ZYTextSaveLog zYTextSaveLog = mySaveLogs[myElement.DeleterIndex];
									string text = zYTextSaveLog.DisplayDateTime + " " + zYTextSaveLog.UserName + " 删除";
									strToolTip = ((strToolTip == null) ? text : (strToolTip + "\r\n" + text));
									flag = true;
								}
								if (flag)
								{
									if (myElement is ZYTextObject)
									{
										ToolTipBounds = new Rectangle(myElement.Bounds.Location, new Size(1, 1));
									}
									else if (myElement is ZYTextContainer)
									{
										ToolTipBounds = (myElement as ZYTextContainer).GetContentBounds();
									}
									else
									{
										ToolTipBounds = myElement.Bounds;
									}
								}
								break;
							}
						}
					}
				}
				if (myCurrentHoverElement != null)
				{
					if (myCurrentHoverElement is ZYTextContainer)
					{
						if (!(myCurrentHoverElement as ZYTextContainer).Contains(x, y))
						{
							CurrentHoverElement = null;
						}
					}
					else if (!myCurrentHoverElement.Bounds.Contains(x, y))
					{
						CurrentHoverElement = null;
					}
				}
				if (myOwnerControl != null && !myOwnerControl.StaticToolTip)
				{
					UpdateToolTip();
				}
				myOwnerControl.SetCursor(myCursor);
			}
			return true;
		}

		public bool ViewMouseUp(int x, int y, MouseButtons Button)
		{
			myOwnerControl.UseAbsTransformPoint = false;
			InitEventObject(ZYVBEventType.MouseUp);
			return true;
		}

		public bool ViewMouseClick(int x, int y, MouseButtons Button)
		{
			InitEventObject(ZYVBEventType.Click);
			myDocumentElement.HandleClick(x, y, Button);
			return true;
		}

		public bool ViewMouseDoubleClick(int x, int y, MouseButtons Button)
		{
			InitEventObject(ZYVBEventType.DblClick);
			if (!myDocumentElement.HandleDblClick(x, y, Button) && (myContent.CurrentElement is ZYTextChar || myContent.PreElement is ZYTextChar))
			{
				int num = -1;
				ZYTextContainer parent = myContent.CurrentElement.Parent;
				for (int num2 = (myContent.CurrentElement is ZYTextChar) ? myContent.SelectStart : (myContent.SelectStart - 1); num2 >= 0; num2--)
				{
					ZYTextChar zYTextChar = myElements[num2] as ZYTextChar;
					if (zYTextChar == null || !char.IsLetter(zYTextChar.Char) || zYTextChar.Parent != parent)
					{
						break;
					}
					num = num2;
				}
				if (num >= 0)
				{
					for (int num2 = num; num2 < myElements.Count; num2++)
					{
						ZYTextChar zYTextChar = myElements[num2] as ZYTextChar;
						if (zYTextChar == null || !char.IsLetter(zYTextChar.Char))
						{
							myContent.SetSelection(num2, num - num2);
							break;
						}
					}
				}
			}
			return true;
		}

		public bool ViewMouseLeave()
		{
			InitEventObject(ZYVBEventType.MouseLeave);
			CurrentHoverElement = null;
			return true;
		}

		public void ViewInsertModeChange()
		{
			ZYTextElement currentElement = myContent.CurrentElement;
			myOwnerControl.UpdateTextCaret();
		}

		public bool IsLock(int index)
		{
			if (Locked)
			{
				return true;
			}
			return myContent.IsLock(index);
		}

		public bool IsLock(ZYTextElement element)
		{
			if (Locked)
			{
				return true;
			}
			return myContent.IsLock(element);
		}

		public void ResetNative()
		{
			myInfo.ShowAll = true;
			RefreshElements(FixNative: true);
			RefreshLine();
			myContent.AutoClearSelection = true;
			myContent.MoveSelectStart(0);
			myContainters.Clear();
			SetContainers(myDocumentElement);
			myAllElement = null;
			UpdateView();
		}

		public bool IsLogicDelete(int index)
		{
			if (!myInfo.AutoLogicDelete)
			{
				return false;
			}
			for (int i = index; i < myContent.Elements.Count; i++)
			{
				if (myContent.Elements[i] is ZYTextLock)
				{
					ZYTextLock zYTextLock = (ZYTextLock)myContent.Elements[i];
					if (zYTextLock.Level < mySaveLogs.CurrentSaveLog.Level)
					{
						return true;
					}
				}
			}
			return false;
		}

		public int isDeleteElement(ZYTextElement myElement)
		{
			if (IsLock(myElement))
			{
				return 1;
			}
			InitEventObject(ZYVBEventType.BeforeDelete);
			if (myElement.Parent == null)
			{
				return 1;
			}
			if (myElement == myElement.Parent.vLastElement)
			{
				return 1;
			}
			bool flag = IsLogicDelete(myContent.IndexOf(myElement));
			if (flag && !myElement.Parent.Locked)
			{
				if (flag && myElement.CreatorIndex == mySaveLogs.CurrentIndex)
				{
					return 0;
				}
				myElement.Deleteted = true;
				if (myOwnerControl != null)
				{
					myOwnerControl.AddInvalidateRect(myElement.Bounds);
				}
				return 2;
			}
			return 0;
		}

		public void SelectionChanged(int s1, int e1, int s2, int e2)
		{
			if (myOwnerControl == null)
			{
				return;
			}
			myOwnerControl.HidePopupList();
			ZYTextElement zYTextElement = null;
			if (e1 == 0 && e2 == 0 && s1 != s2 && s1 >= 0 && s1 < myElements.Count && s2 >= 0 && s2 < myElements.Count)
			{
				ZYTextElement myElement = myElements[s1];
				ZYTextElement myElement2 = myElements[s2];
				if (this.OnJumpDiv != null && ZYTextDiv.GetOwnerDiv(myElement) != ZYTextDiv.GetOwnerDiv(myElement2))
				{
					this.OnJumpDiv(ZYTextDiv.GetOwnerDiv(myElement), ZYTextDiv.GetOwnerDiv(myElement2));
				}
			}
			if (s1 != s2)
			{
				for (int i = s1; i <= s2; i++)
				{
					zYTextElement = myElements[i];
					if (zYTextElement is ZYTextBlock)
					{
						myOwnerControl.AddInvalidateRect((zYTextElement as ZYTextBlock).GetContentBounds());
					}
					else if (zYTextElement.OwnerLine != null)
					{
						myOwnerControl.AddInvalidateRect(zYTextElement.RealLeft, zYTextElement.OwnerLine.RealTop, zYTextElement.Width + zYTextElement.WidthFix, zYTextElement.OwnerLine.Height);
					}
				}
			}
			if (e1 != e2)
			{
				for (int i = e1; i <= e2; i++)
				{
					zYTextElement = myElements[i];
					if (zYTextElement is ZYTextBlock)
					{
						myOwnerControl.AddInvalidateRect((zYTextElement as ZYTextBlock).GetContentBounds());
					}
					else if (zYTextElement.OwnerLine != null)
					{
						myOwnerControl.AddInvalidateRect(zYTextElement.RealLeft, zYTextElement.OwnerLine.RealTop, zYTextElement.Width + zYTextElement.WidthFix, zYTextElement.OwnerLine.Height);
					}
				}
			}
			myOwnerControl.UpdateInvalidateRect();
			myOwnerControl.UpdateInvalidateRect();
			myOwnerControl.UpdateTextCaret();
			if (this.OnSelectionChanged != null)
			{
				this.OnSelectionChanged(this, null);
			}
		}

		public void ContentChanged()
		{
			bolLastContentChangedFlag = true;
			Modified = true;
			RefreshElements();
			if (myElements.Count == 0)
			{
				myDocumentElement.ClearChild();
				myDocumentElement.RefreshSize();
				RefreshElements();
			}
			RefreshLine();
			myView.Height = myDocumentElement.Top + myDocumentElement.Height;
			if (this.OnContentChanged != null)
			{
				this.OnContentChanged(this, null);
			}
		}

		public void cleanMarkImage()
		{
			ZYMarkImage = null;
		}

		public bool FillMarkImage()
		{
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				ToXMLDocument(xmlDocument);
				XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("lock");
				string a = "";
				if (elementsByTagName.Count > 0)
				{
					List<string> list = new List<string>();
					for (int i = 0; i < elementsByTagName.Count; i++)
					{
						if (a != ((XmlElement)elementsByTagName[i]).GetAttribute("user"))
						{
							list.Add(((XmlElement)elementsByTagName[i]).GetAttribute("user"));
						}
					}
					string[] array = list.ToArray();
					if (array.Length > 0)
					{
						for (int i = 0; i < array.Length; i++)
						{
							array[i] = "'" + array[i] + "'";
						}
						SqlConnection sqlConnection = (SqlConnection)DataSource.DBConn.Connection;
						SqlCommand sqlCommand = new SqlCommand("Select zgxm,pic from zg where zgxm in(" + string.Join(",", array) + ") ", sqlConnection);
						sqlConnection.Open();
						SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
						ZYMarkImage = new Hashtable();
						while (sqlDataReader.Read())
						{
							if (a != sqlDataReader[0].ToString() && !DBNull.Value.Equals(sqlDataReader[1]))
							{
								byte[] buffer = (byte[])sqlDataReader.GetValue(1);
								MemoryStream memoryStream = new MemoryStream(buffer);
								if (!ZYMarkImage.Contains(sqlDataReader[0].ToString()))
								{
									ZYMarkImage.Add(sqlDataReader[0].ToString(), Image.FromStream(memoryStream));
								}
								a = sqlDataReader[0].ToString();
								memoryStream.Close();
							}
						}
						sqlDataReader.Close();
						sqlCommand.Dispose();
						sqlConnection.Close();
						sqlConnection.Dispose();
					}
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public object Clone()
		{
			ZYTextDocument zYTextDocument = new ZYTextDocument();
			zYTextDocument.myAllElement = myAllElement;
			zYTextDocument.AutoClearSelection = AutoClearSelection;
			zYTextDocument.bolEnableJumpPrint = bolEnableJumpPrint;
			zYTextDocument.bolLastContentChangedFlag = bolLastContentChangedFlag;
			zYTextDocument.bolLoading = bolLoading;
			zYTextDocument.bolLocked = bolLocked;
			zYTextDocument.myContentChangeLog = myContentChangeLog;
			zYTextDocument.ElementsDirty = ElementsDirty;
			zYTextDocument.myInfo = myInfo;
			zYTextDocument.myEMRVBEngine = myEMRVBEngine;
			zYTextDocument.intDocumentGraphicsUnit = intDocumentGraphicsUnit;
			zYTextDocument.FooterHeight = FooterHeight;
			zYTextDocument.FooterString = FooterString;
			zYTextDocument.HeadHeight = HeadHeight;
			zYTextDocument.HeadString = HeadString;
			zYTextDocument.intFooterHeight = intFooterHeight;
			zYTextDocument.intHeadHeight = intHeadHeight;
			zYTextDocument.intJumpPrintPosition = intJumpPrintPosition;
			zYTextDocument.intLockLevel = intLockLevel;
			zYTextDocument.intLogLevel = intLogLevel;
			zYTextDocument.intPageIndex = intPageIndex;
			zYTextDocument.intPageIndexFix = intPageIndexFix;
			zYTextDocument.intUndoState = intUndoState;
			zYTextDocument.myLines.Clear();
			zYTextDocument.myLines.AddRange(myLines);
			zYTextDocument.intLockLevel = intLockLevel;
			zYTextDocument.myMarks = myMarks;
			zYTextDocument.myContainters = myContainters;
			zYTextDocument.myContent = (ZYContent)myContent.Clone();
			zYTextDocument.myContent.Document = zYTextDocument;
			zYTextDocument.myCurrentHoverElement = myCurrentHoverElement;
			zYTextDocument.myCursor = myCursor;
			zYTextDocument.myDataSource = myDataSource;
			zYTextDocument.myDocumentElement = (ZYTextContainer)myDocumentElement.Clone();
			zYTextDocument.myDocumentElement.OwnerDocument = zYTextDocument;
			zYTextDocument.myElements.Clear();
			zYTextDocument.myElements.AddRange(myElements);
			zYTextDocument.myKBBuffer = myKBBuffer;
			zYTextDocument.myOwnerControl = (ZYEditorControl)myOwnerControl.Clone();
			zYTextDocument.myOwnerControl.Document = zYTextDocument;
			zYTextDocument.myOwnerControl.EMRDoc = zYTextDocument;
			zYTextDocument.myPages = myPages;
			zYTextDocument.myPageSettings = myPageSettings;
			zYTextDocument.myRedoList = myRedoList;
			zYTextDocument.mySaveLogs = mySaveLogs;
			zYTextDocument.myScript = myScript;
			zYTextDocument.myUndoList = myUndoList;
			zYTextDocument.myVariables = myVariables;
			zYTextDocument.myView = myView;
			zYTextDocument.OwnerKBItem = OwnerKBItem;
			zYTextDocument.RefreshAllFlag = RefreshAllFlag;
			zYTextDocument.strFooterString = strFooterString;
			zYTextDocument.strHeadString = strHeadString;
			zYTextDocument.strHideElementNames = strHideElementNames;
			zYTextDocument.strToolTip = strToolTip;
			zYTextDocument.ToolTipBounds = ToolTipBounds;
			zYTextDocument.ToolTipImageIndex = ToolTipImageIndex;
			zYTextDocument.ZYMarkImage = ZYMarkImage;
			return zYTextDocument;
		}
	}
}
