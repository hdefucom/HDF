//
//                       _oo0oo_
//                      o8888888o
//                      88" . "88
//                      (| -_- |)
//                      0\  =  /0
//                    ___/`---'\___
//                  .' \\|     |// '.
//                 / \\|||  :  |||// \
//                / _||||| -:- |||||- \
//               |   | \\\  -  /// |   |
//               | \_|  ''\---/''  |_/ |
//               \  .-\__  '-'  ___/-. /
//             ___'. .'  /--.--\  `. .'___
//          ."" '<  `.___\_<|>_/___.' >' "".
//         | | :  `- \`.;`\ _ /`;.`/ - ` : | |
//         \  \ `_.   \_ __\ /__ _/   .-` /  /
//     =====`-.____`.___ \_____/___.-`___.-'=====
//                       `=---='
//
//
//     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//
//               佛祖保佑         永无BUG
//
//
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Commands;
using DCSoft.Writer.Dom;
using DCSoft.Drawing;
using DCSoft.Writer.Data;
using DCSoft.Writer.Security;
using DCSoft.Common;
using DCSoft.Data;
using DCSoft.Writer.Printing;
using DCSoft.Writer.Extension.Data;
using DCSoft.Writer.Extension;
using DCSoft.Design;
using DCSoft.Writer.WinFormDemo.EMR.Model;

namespace DCSoft.Writer.WinFormDemo.Test.AccessControl
{
    /// <summary>
    /// Demo of DCSoft.Writer
    /// </summary>
    [ToolboxItem ( false )]
    public partial class ctlTextUsePowerCommand: UserControl
    {

        private void mTestSomething_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = this.myEditControl.CurrentInputField;
            if (field != null)
            {
                field.Text = field.Text + " HHHHH";
            }
        }


        public ctlTextUsePowerCommand()
        {
            InitializeComponent();
            
            myEditControl.AllowDragContent = true;
            myEditControl.MoveFocusHotKey = MoveFocusHotKeys.Tab;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.DesignMode == false)
            {
                this.BeginInvoke(new EventHandler(this.mLogin_Click), new object[] { null, null });
                //this.mLogin_Click(null, null);
            }
        }


        private void mLogin_Click(object sender, EventArgs e)
        {
            using (dlgLogin dlg = new dlgLogin())
            {
                if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    myEditControl.UserLoginByParameter(
                        dlg.InputUserInfo.ID,
                        dlg.InputUserInfo.Name,
                        dlg.InputUserInfo.PermissionLevel);

                    //myEditControl.UserLoginByUserLoginInfo( dlg.InputUserInfo , true );
                }
            }
        }
         
        private void frmTextUseCommand_Load(object sender, EventArgs e)
        {
            //this.myEditControl.DocumentControler = new DocumentControlerExt();
             
            //DCSoft.Writer.Controls.TextWindowsFormsEditorHost.PopupFormSizeFix = new System.Drawing.Size(40, 20);
            myEditControl.Font = new Font(System.Windows.Forms.Control.DefaultFont.Name, 12);
            
            // 初始化设置命令执行器
            myEditControl.CommandControler = myCommandControler;
            //myEditControl.CommandControler.UpdateBindingControlStatus();
            myCommandControler.Start();

            // 设置文档处于调试模式
            myEditControl.DocumentOptions.BehaviorOptions.DebugMode = true;
            myEditControl.DocumentOptions.BehaviorOptions.InsertCommentBindingUserTrack = true;
            // 进入留痕显示模式
            myEditControl.ExecuteCommand( "ComplexViewMode" , false  ,true );
            //this.myEditControl_DocumentLoad(null, null);

            string kbFile = System.IO.Path.Combine(
                Application.StartupPath,
                "kblibrary.xml");
            if (System.IO.File.Exists(kbFile))
            {
                // 自动加载默认的知识库
                KBLibrary lib = (KBLibrary)myEditControl.ExecuteCommand(
                    "LoadKBLibrary",
                    false, 
                    kbFile);
                //// 设置加载知识库中模板使用的文件系统
                //myEditControl.AppHost.FileSystems[lib.TemplateFileSystemName]
                //    = EMR.EMRFileSystem.Instance;
            }

            // 注册自定义的输入域下拉列表提供者
            //myEditControl.AppHost.Services.AddService(
            //    typeof(IListItemsProvider),
            //    new EMR.MyListItemsProvider());
            //mDataSourceList_Click(null, null);

            // 执行一次新增文件操作
            myEditControl.ExecuteCommand("FileNew", true, null);

            //dstvControler = new DataSourceTreeViewControler( tvwDataSource );
            //tvwDataSource.MouseDown += dstvControler.HandleTreeViewMouseDown ;
            //string fileName = System.IO.Path.Combine(
            //    Application.StartupPath, 
            //    "DataSourceDescriptor.xml");
            //if (System.IO.File.Exists(fileName))
            //{
            //    dstvControler.LoadFile(fileName);
            //}
        }
        /// <summary>
        /// 数据源树状列表控制器
        /// </summary>
        private DataSourceTreeViewControler dstvControler = null;

        //private void MyFilterData(object sender, FilterValueEventArgs args)
        //{
        //    if (args.Type == InputValueType.Dom)
        //    {
        //        XTextElementList sourceElements = (XTextElementList)args.Value;
        //        foreach (XTextElement element in sourceElements)
        //        {
        //            if (element is XTextCheckBoxElement)
        //            {
        //                ((XTextCheckBoxElement)element).EditorChecked = false;
        //            }
        //            if (element is XTextInputFieldElement)
        //            {
        //                XTextInputFieldElement field = (XTextInputFieldElement)element;
        //                field.EditorTextExt = "aaaaaaaaabbb";
        //                field.InnerValue = null;
        //                DocumentContentStyle style = new DocumentContentStyle();
        //                style.DisableDefaultValue = true;
        //                style.BackgroundColor = Color.Transparent;
        //                style.Color = Color.Blue;
        //                field.EditorSetContentStyle(style, false);
        //            }
        //        }
        //        args.Value = sourceElements;
        //    }
        //}

        /// <summary>
        /// Handle after load document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myEditControl_DocumentLoad(object sender, EventArgs e)
        {
            myEditControl.SetDocumentParameterValue(
                "当前时间", 
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            //if (myEditControl.DocumentOptions.SecurityOptions.EnablePermission)
            //{
            //    // if enable permission 
            //    if (myEditControl.Document != null && _StartOptions.LoginInfo != null)
            //    {
            //        // User logon , add current user info to document.
            //        myEditControl.UserLogin(_StartOptions.LoginInfo , false );
            //    }
            //}
        }
          
        private void menuClose_Click(object sender, EventArgs e)
        {
            //frmTextUseCommand frmText = this.Parent as frmTextUseCommand;
            // frmText.Close();
            this.ParentForm.Close();
            
        }
        //protected override void OnClosing(CancelEventArgs e)
        //{
        //    //base.OnClosing(e);
        //    this.OnClosing(e);
        //}

        private void menuOpenXMLDemo_Click(object sender, EventArgs e)
        {
            HandleCommand(MyCommandNames.OpenXMLDemo);
        }

        private void menuOpenRTFDemo_Click(object sender, EventArgs e)
        {
            HandleCommand(MyCommandNames.OpenNursingRecordDemo);
        }

        private void mOpenFormViewDemo_Click(object sender, EventArgs e)
        {
            HandleCommand(MyCommandNames.OpenFormViewDemo);
        }

        /// <summary>
        /// Current file name.
        /// </summary>
        private string strFileName = null;

        /// <summary>
        /// Handle commands
        /// </summary>
        /// <param name="Command">command name</param>
        public void HandleCommand(string Command)
        {
            if (Command == null)
                return;
            Command = Command.Trim();
            try
            {
                switch (Command)
                {
                    case MyCommandNames.OpenXMLDemo:
                        myEditControl.ExecuteCommand("FormViewMode", false, false);
                        OpenDemoFile("DCSoft.Writer.WinFormDemo.DemoFile.demo.xml", "xml");
                        break;
                    case MyCommandNames.OpenFormViewDemo:
                        if (OpenDemoFile("DCSoft.Writer.WinFormDemo.DemoFile.FormViewModeDemo.xml", "xml"))
                        {
                            myEditControl.ExecuteCommand("FormViewMode", false, true);
                            myEditControl.AutoScrollPosition = new Point(0, 0);
                            myEditControl.UpdateTextCaret();
                        }
                        break;
                    case MyCommandNames.OpenNursingRecordDemo:
                        {
                            if (OpenDemoFile("DCSoft.Writer.WinFormDemo.DemoFile.NursingRecord.xml", "xml"))
                            {
                                myEditControl.ExecuteCommand("FormViewMode", false, false);
                            }
                        }
                        break;

                    default:
#if DEBUG
                        this.Alert("Bad command:" + Command);
#endif
                        break;
                }
            }
            catch (Exception ext)
            {
                this.Alert(ResourceStrings._EXEERR + ext.ToString());
                this.Status = ResourceStrings._EXEERR + ext.Message;
            }
            this.UpdateFormText();
        }

        private bool OpenDemoFile(string resourceName, string format)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            try
            {
                System.IO.Stream stream = this.GetType().Assembly.GetManifestResourceStream(resourceName);
                if (stream != null)
                {
                    using (stream)
                    {
                        FileOpenCommandParameter fcp = new FileOpenCommandParameter();
                        fcp.Format = format;
                        //fcp.FileName = resourceName;
                        fcp.InputStream = stream;
                        bool result = (bool)myEditControl.ExecuteCommand("FileOpen", true, fcp);
                        if (result == false)
                        {
                            this.Status = fcp.Message;
                        }
                        return result;
                    }
                }
                return false;
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        /// <summary>
        /// Show a message box
        /// </summary>
        /// <param name="msg">message text</param>
        private void Alert(string msg)
        {
            MessageBox.Show(this, msg, this.Text);
        }


        /// <summary>
        /// get or set main status text
        /// </summary>
        private string Status
        {
            get { return this.lblStatus.Text; }
            set { this.lblStatus.Text = value; this.Update(); }
        }


        private FlagXTextRangeProvider provider = new FlagXTextRangeProvider();

        /// <summary>
        /// handle element hover event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myEditControl_HoverElementChanged(object sender, EventArgs e)
        {
            provider.Document = myEditControl.Document;
            provider.Prefix = '{';
            provider.Endfix = '}';
            if (myEditControl.HoverElement != null && myEditControl.HoverElement.Parent is XTextInputFieldElement)
            {
                XTextInputFieldElement field = (XTextInputFieldElement)myEditControl.HoverElement.Parent;
                if (field.IsBackgroundTextElement(myEditControl.HoverElement))
                {
                }
            }
            XTextRange range = provider.GetRange(myEditControl.HoverElement);
            if (range != null)
            {
                this.myEditControl.HighlightRange = new HighlightInfo(range);

            }
            else
            {
                this.myEditControl.HighlightRange = null;
            }
        }

        /// <summary>
        /// Handle selection changed event in editor control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myEditControl_SelectionChanged(object sender, EventArgs e)
        {
            //XTextFieldElement field = (XTextFieldElement)myEditControl.Document.CurrentField;
            //field.EditorTextExt = "bbb";
            
            provider.Document = myEditControl.Document;
            provider.Prefix = '{';
            provider.Endfix = '}';
            XTextRange range = provider.GetRange(myEditControl.CurrentElement);
            if (range != null)
            {
                myEditControl.HighlightRange = new HighlightInfo(range);
            }
            else
            {
                myEditControl.HighlightRange = null;
            }


            XTextLine line = myEditControl.Document.CurrentContentElement.CurrentLine;
            if (line != null && line.OwnerPage != null)
            {
                string txt =
                    string.Format(ResourceStrings._LINE,
                    Convert.ToString(line.OwnerPage.PageIndex),
                    Convert.ToString(myEditControl.CurrentLineIndexInPage),
                    Convert.ToString(myEditControl.CurrentColumnIndex));
                if (myEditControl.Selection.Length != 0)
                {
                    txt = txt + string.Format(
                        ResourceStrings._SELECTELEMENTS,
                        Math.Abs(myEditControl.Selection.Length));
                }
                Point p = myEditControl.SelectionStartPosition;
                this.lblPosition.Text = txt + " X:" + p.X + " Y:" + p.Y ;
            }
            UpdateFormText();
             
            SetContextMenu();

            if (this.dstvControler != null)
            {
                this.dstvControler.UpdateCurrentDataSourceNode(myEditControl);
            }
            //this.Text = myEditControl.CaretPosition.ToString();


        }

        /// <summary>
        /// 设置编辑器控件的快捷菜单
        /// </summary>
        private void SetContextMenu()
        {
            if (Math.Abs(myEditControl.Selection.Length) == 1)
            {
                XTextElement element = this.myEditControl.Selection.ContentElements[0];
                if (element is XTextImageElement)
                {
                    this.myEditControl.ContextMenuStrip = this.cmImage;
                    return;
                }
            }
            bool isInCell = false;
            if (myEditControl.Selection.Cells != null && myEditControl.Selection.Cells.Count > 0)
            {
                isInCell = true;
            }
            else
            {
                XTextContainerElement c = null;
                int index = 0;
                myEditControl.Document.Content.GetCurrentPositionInfo(out c, out index);
                if (c is XTextTableCellElement || c.OwnerCell != null)
                {
                    isInCell = true;
                }
            }
            if (isInCell)
            {
                myEditControl.ContextMenuStrip = cmTableCell;
                return;
            }
            myEditControl.ContextMenuStrip = cmEdit;
        }

        private void UpdateFormText()
        {
            string text = "DCSoft.Writer";
            if (string.IsNullOrEmpty(this.myEditControl.Document.Info.Title) == false)
            {
                text = myEditControl.Document.Info.Title + "-" + text;
            }
            else if (string.IsNullOrEmpty(this.myEditControl.Document.FileName) == false)
            {
                text = myEditControl.Document.FileName + " - " + text;
            }
            if (myEditControl.Document.Modified)
            {
                text = text + " *";
            }
            this.Text = text;
        }

        private void frmTextUseCommand_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool b = (bool)myEditControl.ExecuteCommand("FileQueryExit", true, null);
            if (b == false)
            {
                e.Cancel = true;
            }
        }

        private void mTest_Click(object sender, EventArgs e)
        {

        }


        private void mTestInsertField_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = new XTextInputFieldElement();
            field.FieldSettings = new InputFieldSettings();
            field.FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
            //field.InitalizeText = "测试文本ABC";
            field.Name = "COUNTRY";
            field.BackgroundText = "Please select country";
            field.FieldSettings.MultiSelect = false;
            field.Attributes = new XAttributeList();
            field.Attributes.SetValue("Insert time", DateTime.Now.ToLongDateString());
            field.OwnerDocument = myEditControl.Document;
            field.SetInnerTextFast("测试文本ABC");
            XTextInputFieldElement newField = (XTextInputFieldElement)myEditControl.ExecuteCommand("InsertInputField", true, field);
            if (newField != null)
            {
                System.Console.WriteLine(newField.ToString());
            }
        }


        private void mTestInsertMedic_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = new XTextInputFieldElement();
            field.FieldSettings = new InputFieldSettings();
            field.FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
            field.FieldSettings.ListSource = new ListSourceInfo();
            field.FieldSettings.ListSource.SourceName = "DOCEX";
            field.FieldSettings.ListSource.DisplayPath = "Name";
            field.FieldSettings.ListSource.ValuePath = "Name";
            field.FieldSettings.MultiSelect = false;


            field.Attributes = new XAttributeList();
            field.Attributes.SetValue("Insert Time", DateTime.Now.ToLongDateString());
            field.Name = "Docex";
            field.BackgroundText = "药品";

            myEditControl.ExecuteCommand("InsertInputField", true, field);
        }


        private void mTestInsertImage_Click(object sender, EventArgs e)
        {
            System.Drawing.Image img = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "About.jpg"));
            myEditControl.ExecuteCommand("InsertImage", false, img);
        }

        private void mTestInsertString_Click(object sender, EventArgs e)
        {
            myEditControl.ExecuteCommand("InsertString", false, "abc");
        }
         
         
        private void mTestUpdateData_Click(object sender, EventArgs e)
        {
            //XTextInputFieldElement field = (XTextInputFieldElement)myEditControl.GetCurrentElement(typeof(XTextInputFieldElement));
            //field.EditorTextExt = DateTime.Now.ToString();
            //return;
            //XTextElementList xTextElementList =  this.myEditControl.Document.GetSpecifyElements(typeof(XTextInputFieldElement));
            //myEditControl.IsAdministrator = true;
            //foreach (XTextFieldElement xTextInputFieldElement in xTextElementList)
            //{
            //    if (xTextInputFieldElement.Parent is XTextInputFieldElement || xTextInputFieldElement.Parent is XTextCheckBoxElement)
            //    {
            //        myEditControl.ExecuteCommand(StandardCommandNames.DeleteField, false, xTextInputFieldElement);
            //        //xTextInputFieldElement.EditorDelete(true);
            //    }
            //}
            //return;


            using (dlgProperty dlg = new dlgProperty())
            {
                dlg.InstanceToShow = myEditControl.ServerObject;
                dlg.Text = "This is values before update";
                dlg.ShowDialog(this);
                int result = this.myEditControl.WriteDataFromDocumentToDataSource();// .WriteDataSource();
                if (result == 0)
                {
                    MessageBox.Show("No changed");
                }
                else
                {
                    dlg.Text = "This is values after update，modified " + result + " parts";
                    dlg.InstanceToShow = myEditControl.ServerObject;
                    dlg.ShowDialog(this);
                }
            }
        }

private void mXML2RTF_Click(object sender, EventArgs e)
{
    MessageBox.Show(ResourceStrings.PromptXML2RTF);
    string sourceFileName = null;
    string descFileName = null;
    using (OpenFileDialog dlg = new OpenFileDialog())
    {
        dlg.Filter = "XML文件|*.xml";
        dlg.CheckFileExists = true;
        dlg.ShowReadOnly = false;
        dlg.Title = ResourceStrings.SOURCEXMLDLGTITLE;
        if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
        {
            sourceFileName = dlg.FileName;
        }
        else
        {
            return;
        }
    }
    using (SaveFileDialog dlg = new SaveFileDialog())
    {
        dlg.Filter = "RTF文件(*.rtf)|*.rtf";
        dlg.CheckPathExists = true;
        dlg.OverwritePrompt = true;
        if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
        {
            descFileName = dlg.FileName;
        }
        else
        {
            return;
        }
    }

    XTextDocument document = new XTextDocument();
    document.Load(sourceFileName, "xml");
    using (DCGraphics g = document.CreateDCGraphics())
    {
        document.RefreshSize(g);
        document.ExecuteLayout();
        document.RefreshPages();
        document.Save(descFileName, "rtf");
    }
    MessageBox.Show(string.Format(ResourceStrings.SUCCESSXML2RTF_SOURCE_DESC, sourceFileName, descFileName));
}

        /// <summary>
        /// 文档内容发生改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myEditControl_DocumentContentChanged(object sender, EventArgs e)
        {
            //System.Console.WriteLine("");
            //System.Diagnostics.Debug.WriteLine(
            //    System.Environment.TickCount + ":" + myEditControl.DocumentContentVersion);
            //XTextInputFieldElement field = myEditControl.Document.CurrentField as XTextInputFieldElement;

        }

        private void mTestSetInputFieldText_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = (XTextInputFieldElement)myEditControl.GetCurrentElement(
                typeof(XTextInputFieldElement));
            if (field != null)
            {
                // 直接设置文本输入域的内容
                field.EditorTextExt = DateTime.Now.ToString();
            }
        }

        private void mTestInsertCheckBoxList_Click(object sender, EventArgs e)
        {
            myEditControl.ExecuteCommand("InsertCheckBoxList", true, null);

            //myEditControl.Document.GetSpecifyElements(typeof(XTextCheckBoxElement));
        }

        private void mTestSetStyle_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = (XTextInputFieldElement)myEditControl.Document.GetCurrentElement(typeof(XTextInputFieldElement));
            if (field != null)
            {
                using (FontDialog dlg = new FontDialog())
                {
                    dlg.Font = field.RuntimeStyle.Font.Value;
                    dlg.Color = field.RuntimeStyle.Color;
                    dlg.ShowColor = true;
                    if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        DocumentContentStyle newStyle = new DocumentContentStyle();
                        newStyle.DisableDefaultValue = true;
                        newStyle.Font = new XFontValue(dlg.Font);
                        newStyle.Color = dlg.Color;
                        //newStyle.BackgroundColor = Color.Yellow;
                        field.EditorSetContentStyle(newStyle, true);
                        //field.EditorText = "";
                        //field.EditorText = DateTime.Now.ToString();
                    }
                }
            }
        }

        private void mTestChangeEditorTextExt_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = (XTextInputFieldElement)myEditControl.GetCurrentElement(typeof(XTextInputFieldElement));
            if (field != null)
            {
                XTextElementList fields = myEditControl.Document.Fields;
                XTextInputFieldElement nextField = (XTextInputFieldElement)fields.GetNextElement(field);
                if (nextField != null)
                {
                    nextField.EditorTextExt = Guid.NewGuid().ToString();
                }
            }
        }

        private void myEditControl_StatusTextChanged(object sender, EventArgs e)
        {
            lblStatus.Text = myEditControl.StatusText;
            this.statusStrip1.Refresh();
        }

        private void mPermissionConfig_Click(object sender, EventArgs e)
        {
            using (dlgPermissionConfig dlg = new dlgPermissionConfig())
            {
                dlg.Document = this.myEditControl.Document;
                if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    myEditControl.RefreshDocument();
                }
            }
        }


        /// <summary>
        /// 编辑器中执行命令时的错误处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void myEditControl_CommandError(object sender, CommandErrorEventArgs args)
        {
            MessageBox.Show(
                this,
                args.CommandName + "\r\n" + args.Exception.ToString(),
                this.Text,
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);

        }

        private void mTestChangeParagraphFormat_Click(object sender, EventArgs e)
        {
            myEditControl.Document.ContentStyles.Default.SpacingBeforeParagraph = 90f;
            myEditControl.RefreshDocument();
        }
         
         
        private void mInsertXML_Click(object sender, EventArgs e)
        {

            //            XTextElement element = myEditControl.Document.CurrentElement;
            //DocumentContentStyle style = new DocumentContentStyle();
            //style.Bold = true;
            //element.Style = style;
            //myEditControl.RefreshDocument();
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "*.xml|*.xml";
                dlg.CheckFileExists = true;
                if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    using (System.IO.Stream stream = dlg.OpenFile())
                    {
                        myEditControl.ExecuteCommand("InsertXML", false, stream);
                    }
                }
            }
        }

        private void mTestSetDefaultStyle_Click(object sender, EventArgs e)
        {
            myEditControl.ExecuteCommand(
                "SetDefaultStyle",
                false,
                "Align:Center;LineSpacingStyle:SpaceSpecify;LineSpacing:80");
        }

        /// <summary>
        /// 使用本地文件系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mLocalFileSystem_Click(object sender, EventArgs e)
        {
            //mLocalFileSystem.Checked = true;
            //mDBFileSystem.Checked = false;
            //// 更换后台的服务对象
            ////myEditControl.AppHost.SetDataProvider(new DefaultDataProvider());
            //myEditControl.AppHost.FileSystems.Docuemnt = DCSoft.Writer.Data.DefaultFileSystem.Instance;
            //myEditControl.AppHost.FileSystems.Template = DCSoft.Writer.Data.DefaultFileSystem.Instance;
        }

        /// <summary>
        /// 使用数据库文件系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mDBFileSystem_Click(object sender, EventArgs e)
        {
            //mLocalFileSystem.Checked = false;
            //mDBFileSystem.Checked = true;
            //// 更换后台的服务对象

            //DCSoft.Writer.WinFormDemo.EMR.EMRFileSystem p = DCSoft.Writer.WinFormDemo.EMR.EMRFileSystem.Instance;
            ////myEditControl.AppHost.SetDataProvider(p);
            //myEditControl.AppHost.FileSystems.Docuemnt = p;
            //myEditControl.AppHost.FileSystems.Template = p;
        }
         

        ///// <summary>
        ///// 显示和隐藏数据源列表功能
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void mDataSourceList_Click(object sender, EventArgs e)
        //{
        //    bool show = mDataSourceList.Checked;
        //    if (show)
        //    {
                 
        //    }
        //    this.spDataSource.Visible = show;
        //    this.tabDataSource.Visible = show;
        //    if (tabDataSource.Visible)
        //    {
        //        // 设置为设计器使用的文档控制器
        //        myEditControl.DocumentControler = new DocumentControlerExt();
        //    }
        //    else
        //    {
        //        // 设置为普通的文档控制器
        //        myEditControl.DocumentControler = new DocumentControler();
        //    }
        //}
           

        private void mTestLoadKBFromURL_Click(object sender, EventArgs e)
        {
            using (DCSoft.WinForms.Native.dlgInputUrl dlg = new WinForms.Native.dlgInputUrl())
            {
                if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    string url = dlg.InputURL;
                    // 注册自定义的输入域下拉列表提供者
                    //myEditControl.AppHost.Services.AddService(
                    //    typeof(IListItemsProvider),
                    //    new DCSoft.Writer.Data.DefaultListItemsProvider());
                    myEditControl.ExecuteCommand("LoadKBLibrary", false, url);
                }
            }
        }

        private void mLoadXMLDataSource_Click(object sender, EventArgs e)
        {
            string xml = @"
<EMR_Patients>
   <PA_HIS_BEINHOSPITAL_CODE>233854</PA_HIS_BEINHOSPITAL_CODE>
   <PA_ID>00004613</PA_ID>
   <PA_BEINHOSPITAL_GREE>0</PA_BEINHOSPITAL_GREE>
   <PA_OUTPATIENT_CODE />
   <PA_CARDCODE />
   <PA_BEINHOSPITAL_CODE>00233854_0</PA_BEINHOSPITAL_CODE>
   <PA_PIH_PATIENT_SAPCE>神经内科</PA_PIH_PATIENT_SAPCE>
   <PA_CASE_HISTOR_CODE>00233854</PA_CASE_HISTOR_CODE>
   <PA_NAME>种永安</PA_NAME>
   <PA_SEX>男</PA_SEX>
   <PA_PRITHTIME>1940-04-06 00:00:00 </PA_PRITHTIME>
   <PA_HOMEPLACE>陕西扶风</PA_HOMEPLACE>
   <PA_NATION>01</PA_NATION>
   <PA_NATIONALITY>003</PA_NATIONALITY>
   <PA_IDENTITYCARD />
   <PA_WORK_UNIT>扶风县绛帐镇前进村一组</PA_WORK_UNIT>
   <PA_WORKADRESS>扶风县绛帐镇前进村一组</PA_WORKADRESS>
   <PA_W_POSTALCODE>722206</PA_W_POSTALCODE>
   <PA_W_PHONE>5281655</PA_W_PHONE>
   <PA_RPE_ADDRESS>扶风县绛帐镇前进村一组</PA_RPE_ADDRESS>
   <PA_RPE_POSTALCODE>722206</PA_RPE_POSTALCODE>
   <PA_RPE_PHONE>5281655</PA_RPE_PHONE>
   <PA_LINKMAN_NAME>种周强</PA_LINKMAN_NAME>
   <PA_LM_RAPPORT>父子</PA_LM_RAPPORT>
   <PA_LM_ADDRESS>扶风县绛帐镇前进村一组</PA_LM_ADDRESS>
   <PA_LM_PHONE>5281655</PA_LM_PHONE>
   <PA_INSURANCE_CE_CODE />
   <PA_INSURANCE_CE_NAME />
   <PA_INSURANCE_CODE />
   <PA_PERSONNEL_TYPE />
   <PA_PATIENT_SOURCE>门诊</PA_PATIENT_SOURCE>
   <PA_DOCTOR />
   <PA_DIAGNOSE>脑梗死</PA_DIAGNOSE>
   <PA_DIAGNOSE_NURSE />
   <PA_NURCS>一般</PA_NURCS>
   <PA_FASHION>门诊</PA_FASHION>
   <PA_RY_TIME>2010-06-17 08:00:00 </PA_RY_TIME>
   <PA_FORESTALLDIAGNOSE>无</PA_FORESTALLDIAGNOSE>
   <PA_RYKB>05</PA_RYKB>
   <PA_PAYMENT_NURCS>合疗</PA_PAYMENT_NURCS>
   <PA_BINGAN_CODE>00233854</PA_BINGAN_CODE>
   <PA_AMRRIAGE_STATUS>已婚</PA_AMRRIAGE_STATUS>
   <PA_OCCUPATION>02</PA_OCCUPATION>
   <PA_DISPLACE_KB>05</PA_DISPLACE_KB>
   <PA_DISPLACE_BEINHOSPITAL />
   <PA_LEAVEHOSPITAL_BE>05</PA_LEAVEHOSPITAL_BE>
   <PA_LEAVEHOSPITAL_PATIENT>2010-07-10 15:15:19</PA_LEAVEHOSPITAL_PATIENT>
   <PA_LEAVEHOSPITAL_NURCS />
   <PA_PIH_NUMBEROFDAYS />
   <PA_CURE_TYPE />
   <PA_DIAGNOSE_DATE>1901-01-01 00:00:00 </PA_DIAGNOSE_DATE>
   <PA_DIAGNOSE_DR>000036</PA_DIAGNOSE_DR>
   <PA_STATE>正常</PA_STATE>
   <PA_BEINHOSPITAL_BOOKER>000036</PA_BEINHOSPITAL_BOOKER>
   <PA_BEINHOSPITAL_BOOKINTIME>2010-06-17 10:16:16 </PA_BEINHOSPITAL_BOOKINTIME>
   <PA_LEAVEHOSPITAL_BOOKER>000036</PA_LEAVEHOSPITAL_BOOKER>
   <PA_LEAVEHOSPITAL_BOOKINTIME>2010-10-10 15:15:19 </PA_LEAVEHOSPITAL_BOOKINTIME>
   <PA_PYM>ZYA</PA_PYM>
</EMR_Patients>";
            myEditControl.SetDocumentParameterValueXml("EMR_Patients", xml);
            myEditControl.ExecuteCommand(
                "FileOpen",
                false,
                System.IO.Path.Combine(
                    Application.StartupPath,
                    @"EMR\TemplateDocument\InpatientInfo.xml"));
            myEditControl.ExecuteCommand("FormViewMode", false, null);
        }

        private void mGetXMLDataSource_Click(object sender, EventArgs e)
        {
            int result = myEditControl.UpdateDataSourceForView();// .ExecuteCommand("UpdateDataSourceForView", false, null);
            string xml = myEditControl.GetDocumentParameterValueXml("EMR_Patients");
            System.Diagnostics.Debug.WriteLine(xml);
            MessageBox.Show(result.ToString());
        }

        private void myEditControl_AfterExecuteCommand(object sender, WriterCommandEventArgs args)
        {
            //if (args.Name == "LoadKBLibrary")
            //{
            //    tvwKB.KBLibrary = myEditControl.AppHost.KBLibrary;
            //    tvwKB.RefreshView();
            //}
        }

        private void mInsertSimpleList_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = new XTextInputFieldElement();
            field.BackgroundText = "请选择值";
            field.FieldSettings = new InputFieldSettings();
            field.FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
            field.FieldSettings.ListSource = new ListSourceInfo();
            field.FieldSettings.ListSource.RuntimeItems = new ListItemCollection();
            field.FieldSettings.ListSource.RuntimeItems.AddByTextValue("列表项目1", "数值1");
            field.FieldSettings.ListSource.RuntimeItems.AddByTextValue("列表项目2", "数值2");
            field.FieldSettings.ListSource.RuntimeItems.AddByTextValue("列表项目3", "数值3");
            field.FieldSettings.ListSource.RuntimeItems.AddByTextValue("列表项目4", "数值4");
            field.FieldSettings.ListSource.RuntimeItems.AddByTextValue("列表项目5", "数值5");
            myEditControl.ExecuteCommand("InsertInputField", false, field);
        }

        private void mPrintMultiDocument_Click(object sender, EventArgs e)
        {
            using (DCSoft.Writer.Printing.WriterPrintDocument pd = new Printing.WriterPrintDocument())
            {
                while (true)
                {
                    using (OpenFileDialog dlg = new OpenFileDialog())
                    {
                        dlg.Filter = "*.xml|*.xml";
                        dlg.CheckFileExists = true;
                        if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        {
                            XTextDocument doc = new XTextDocument();
                            doc.Load(dlg.FileName, "xml");
                            using (DCGraphics g = doc.CreateDCGraphics())
                            {
                                doc.RefreshSize(g);
                            }
                            doc.ExecuteLayout();
                            doc.RefreshPages();
                            pd.Documents.Add(doc);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (pd.Documents.Count > 0)
                {
                    using (PrintPreviewDialog dlg = new PrintPreviewDialog())
                    {
                        dlg.Document = pd;
                        pd.UpdateDocumentsState();
                        dlg.ShowDialog(this);
                        pd.RestoreDocumentsState();
                    }
                }
            }
        }

        private void mPrintDocumentBackground_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "*.xml|*.xml";
                dlg.CheckFileExists = true;
                if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    // 后台加载文档
                    string fileName = dlg.FileName;
                    XTextDocument document = new XTextDocument();
                    document.Load(fileName, "xml");
                    // 创建后台打印器
                    DocumentPrinter dp = new DocumentPrinter();
                    // 添加要打印的文档，可以添加多个
                    dp.Documents.Add(document);
                    // 准备打印
                    dp.PreparePrintDocument();
                    // 执行后台打印
                    dp.PrintDocument(false);
                }
            }
        }

        private void mDocumentValidate_Click(object sender, EventArgs e)
        {
            ValueValidateResultList list = (ValueValidateResultList)myEditControl.ExecuteCommand("DocumentValueValidate", false, null);
            if (list != null && list.Count > 0)
            {
                // 校验不成功
                StringBuilder str = new StringBuilder();
                foreach (ValueValidateResult item in list)
                {
                    if (str.Length > 0)
                    {
                        str.Append(Environment.NewLine);
                    }
                    str.Append(item.Element.ID + ":" + item.Message);
                }
                MessageBox.Show(str.ToString());
            }
        }

        private void mViewSelectionXML_Click(object sender, EventArgs e)
        {
            string xmlSource = Convert.ToString(
                this.myEditControl.ExecuteCommand("GetSelectionContentText", true, "xml"));
            System.Diagnostics.Debug.WriteLine(xmlSource);
        }

        private void mViewSelectionRTF_Click(object sender, EventArgs e)
        {
            string rtfSource = Convert.ToString(
                this.myEditControl.ExecuteCommand("GetSelectionContentText", true, "rtf"));
            System.Diagnostics.Debug.WriteLine(rtfSource);
        }

        private void mInsertXmlFromClipboard_Click(object sender, EventArgs e)
        {
            string xml = Clipboard.GetText();
            if (string.IsNullOrEmpty(xml) == false)
            {
                myEditControl.ExecuteCommand("InsertXML", false, xml);
            }
        }
         
        #region 数据源树状列表操作相关的代码


        private void myEditControl_EventCanInsertObject(object sender, CanInsertObjectEventArgs args)
        {
            if (this.dstvControler != null)
            {
                this.dstvControler.HandleCanInsertObjectEvent(myEditControl, args);
            }
        }

        private void myEditControl_EventInsertObject(object sender, InsertObjectEventArgs args)
        {
            if (this.dstvControler != null)
            {
                this.dstvControler.HandleInsertObjectEvent(myEditControl, args);
            }
        }
         
         
        #endregion

        private void btnTestGetElementByID_Click(object sender, EventArgs e)
        {
            //string id = DCSoft.WinForms.
        }

        private void mLoadKBFromDB_Click(object sender, EventArgs e)
        {
            myEditControl.ExecuteCommand("LoadKBLibrary", false, null);
            using (IDbConnection conn = Utils.CreateConnection())
            {
                conn.Open();
                KBLibrary lib = new KBLibrary();
                EMR.EMRDataProvider.LoadKBLibrary(conn, lib);
                myEditControl.ExecuteCommand("LoadKBLibrary", false, lib);
            }
        }
    }
}