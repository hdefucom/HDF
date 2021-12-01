using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using  Open_ICSharpCode_SharpZipLib_Zip ;//ICSharpCode.SharpZipLib.Zip;

namespace DCSoft.Writer.WinFormDemo
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            //获取屏幕的大小，获取用户当前电脑屏幕大小，比如1024*768,获得如下
            //int Height= System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            //int Width= System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            //this.Size = new Size(Width, Height);
        }

        //定义视频列表
        public System.Collections.Generic.Dictionary<string, string> videoKeyValueList = new Dictionary<string, string>();

        public System.Collections.Generic.Dictionary<string, string> AddvideoKeyValueList()
        {
            //20160704整理 by 伍
            videoKeyValueList.Add("ctlTextUseCommand", "01.00常规功能演示.wmv");
            videoKeyValueList.Add("Test.SetStatusStripLayout.ctlTestStatusStrip", "03.01状态设置.wmv");
            videoKeyValueList.Add("Test.FileOperations.ctlTestFileNew", "04.01文件新建.wmv");
            videoKeyValueList.Add("Test.FileOperations.ctlTestFileOpen", "04.02文件打开.wmv");
            videoKeyValueList.Add("Test.FileOperations.ctlTestFileSave", "04.03文件保存.wmv");
            videoKeyValueList.Add("Test.FileOperations.ctlTestFileSaveAs", "04.04文件另存.wmv");
            videoKeyValueList.Add("Test.FileOperations.ctlTestPrintPreview", "04.05打印预览.wmv");
            videoKeyValueList.Add("Test.FileOperations.ctlTestNavigate", "04.06文档导航.wmv");
            videoKeyValueList.Add("Test.FileOperations.ctlAutoSave", "04.07文档自动保存机制.wmv");
            videoKeyValueList.Add("Test.FileOperations.ctlTestFileSystemEvent", "04.08测试文件系统事件.wmv");
            videoKeyValueList.Add("Test.FileOperations.ctlTestFileCommand", "04.09文件命令.wmv");
            videoKeyValueList.Add("Test.FileOperations.ctlTestSearchReplace", "04.10查找替换.wmv");
            videoKeyValueList.Add("Test.FileOperations.ctlTestFileFormat", "04.11文件格式.wmv");
            videoKeyValueList.Add("Test.FileOperations.ctlTestDataFormats", "04.12数据格式.wmv");
            videoKeyValueList.Add("Test.FileOperations.ctlZoom", "04.13缩放视图.wmv");
            videoKeyValueList.Add("Test.FileOperations.ctlFileFormatConvert", "04.14后台文件格式转换.wmv");
            videoKeyValueList.Add("Test.FileOperations.ctlTestMove", "04.15插入点.wmv");
            videoKeyValueList.Add("EMR.ctlPatientsList", "05.01病人基本信息维护.wmv");
            videoKeyValueList.Add("Test.DataSourceOperation.ctlTestValueBinding", "05.02数据源绑定.wmv");
            videoKeyValueList.Add("Test.InputOperation.ctlTestDateTimeService", "06.01服务器时间同步功能.wmv");
            videoKeyValueList.Add("Test.InputOperation.ctlDymaticListItems", "06.02动态加载下拉列表.wmv");
            //6.3自定义数据编辑器控件
            videoKeyValueList.Add("Test.InputOperation.ctlTestAssistInsert", "06.04快捷辅助录入.wmv");
            videoKeyValueList.Add("Test.InputOperation.ctlTestLinkList", "06.05省市县联动.wmv");
            videoKeyValueList.Add("Test.InputOperation.ctlTestCopySource", "06.06输入域内容复制.wmv");
            videoKeyValueList.Add("Test.InputOperation.ctlExpressionFunction", "06.07测试自定义表达式函数.wmv");
            videoKeyValueList.Add("Test.InputOperation.ctlFieldContentEditEvent", "06.08输入域内容修改事件.wmv");
            videoKeyValueList.Add("Test.InputOperation.ctlTestEvent", "06.09控件级事件和文档元素级事件.wmv");
            videoKeyValueList.Add("Test.InputOperation.ctlTestCascade", "06.10级联模板.wmv");
            videoKeyValueList.Add("Test.InputOperation.ctlTestSetSize", "06.11设置元素大小.wmv");
            videoKeyValueList.Add("Test.InputOperation.ctlTestSetInputField", "06.12设置文本域的内容.wmv");
            videoKeyValueList.Add("Test.InputOperation.ctlTestListItems", "06.13列表项目.wmv");
            videoKeyValueList.Add("Test.InputOperation.ctlTestCustomElementValueEditor", "06.14扩展数值编辑器.wmv");
            //6.15元素事件VB脚本
            videoKeyValueList.Add("Test.InputOperation.ctlTestSetVisible", "06.16设置元素可见性.wmv");
            videoKeyValueList.Add("Test.InputOperation.ctlTestEventEditElementValue", "06.17测试编辑元素数据事件.wmv");
            videoKeyValueList.Add("Test.InputOperation.ctlTestInputField", "06.18测试输入域.wmv");
            videoKeyValueList.Add("Test.AccessControl.ctlTextUsePowerCommand", "07.01启用文档内容权限控制.wmv");
            videoKeyValueList.Add("Test.AccessControl.ctlTestCheckMRID", "07.02跨病历复制.wmv");
            videoKeyValueList.Add("Test.AccessControl.ctlTestExcludeKeywords", "07.03违禁关键字.wmv");
            videoKeyValueList.Add("Test.AccessControl.ctlTestUserTrackList", "07.04用户痕迹列表.wmv");
            videoKeyValueList.Add("Test.AccessControl.ctlTestFileLock", "07.05文件内容锁定.wmv");
            videoKeyValueList.Add("Test.AccessControl.ctlContentLock", "07.06基于用户的内容锁定机制.wmv");
            videoKeyValueList.Add("Test.AccessControl.ctlQueryHistoryDisplayText", "07.07自定义修改痕迹提示信息.wmv");
            videoKeyValueList.Add("Test.TableOperation.ctlTestTable", "08.01表格常规功能.wmv");
            videoKeyValueList.Add("Test.TableOperation.ctlTestTable2", "08.02表格其他功能.wmv");
            videoKeyValueList.Add("Test.TableOperation.ctlTestTableData", "08.03表格数据源绑定等操作.wmv");
            videoKeyValueList.Add("Test.TableOperation.ctlGarde", "08.04评分表量表.wmv");
            videoKeyValueList.Add("Test.TableOperation.ctlTestChangeTable", "08.05修改表格内容.wmv");
            videoKeyValueList.Add("Test.TableOperation.ctlTestSetCells", "08.06设置多个单元格的值.wmv");
            videoKeyValueList.Add("Test.ctlTableRowHeightChangedEvent", "08.07表格行高度修改事件.wmv");
            videoKeyValueList.Add("Test.OLEDargAndDrop.ctlTestDrag", "09.01OLE拖拽.wmv");
            videoKeyValueList.Add("Test.OLEDargAndDrop.ctlTestDragDataSource", "09.02拖拽数据源.wmv");
            videoKeyValueList.Add("Test.OLEDargAndDrop.ctlTestInsertObject", "09.03CanInsertObjectInsertObject事件.wmv");
            videoKeyValueList.Add("Test.SectionElement.SubDocumentDelayLoadWhenExpand", "10.01延迟加载内容.wmv");
            videoKeyValueList.Add("Test.CourseRecord.ctlTestSubDocument", "11.05病程记录5.wmv");
            videoKeyValueList.Add("Test.KnowledgeBase.ctlTestLoadKBLibrary", "12.01加载知识库.wmv");
            videoKeyValueList.Add("Test.KnowledgeBase.ctlQueryKBEntries", "12.02自定义查询知识库节点.wmv");
            videoKeyValueList.Add("Test.KnowledgeBase.ctlDBKBLibrary", "12.03基于数据库的知识库.wmv");
            videoKeyValueList.Add("Test.DOMAuxiliaryOperation.ctlTestDocumentGridLine", "13.01文档网格线.wmv");
            videoKeyValueList.Add("Test.DOMAuxiliaryOperation.ctlTestAutoTranslate", "13.02测试字符自动转换.wmv");
            //13.3自定义字符串
            videoKeyValueList.Add("Test.DOMAuxiliaryOperation.ctlFormatListItems", "13.04列表项目格式化输出.wmv");
            //13.5数据过滤器
            //13.6WriterControlExt
            videoKeyValueList.Add("Test.DOMAuxiliaryOperation.ctlTestInjectCommand", "13.07编辑器命令注入.wmv");
            videoKeyValueList.Add("Test.DOMAuxiliaryOperation.ctlTestGlobalEventTemplate", "13.08全局事件模板.wmv");
            videoKeyValueList.Add("Test.DOMAuxiliaryOperation.ctlBuildDom", "13.09操作DOM.wmv");
            videoKeyValueList.Add("Test.DOMAuxiliaryOperation.ctlTestCreateContentDocument", "13.10获得区域内容.wmv");
            //13.11从右到左排版
            videoKeyValueList.Add("Test.DOMAuxiliaryOperation.ctlDomTree", "13.12文档DOM树.wmv");
            //13.13其他测试
            videoKeyValueList.Add("Test.DOMAuxiliaryOperation.ctlCustomHandleError", "13.14自定义处理错误.wmv");
            videoKeyValueList.Add("Test.DOMAuxiliaryOperation.ctlContextMenu", "13.15自定义快捷菜单.wmv");
            videoKeyValueList.Add("Test.DOMAuxiliaryOperation.ctlOutlineTree", "13.16文档大纲结构.wmv");
            videoKeyValueList.Add("Test.DOMAuxiliaryOperation.ctlControlEventMessage", "13.17启用事件消息.wmv");
            videoKeyValueList.Add("Test.DOMAuxiliaryOperation.ctlCustomDrawContent", "13.18自定义绘制文档内容.wmv");
            videoKeyValueList.Add("Test.OtherElementsOperation.ctlTestTemperatureChartElement", "14.01测试体温单.wmv");
            videoKeyValueList.Add("Test.OtherElementsOperation.ctlCustomShapeElement", "14.02自定义绘制图形.wmv");
            //14.3单选框复选框
            //14.4按钮文档元素
            //14.5文件引用块元素
            //14.6插入音频视频
            //14.7承载控件
            //15.1测试AxWriterControl

            return videoKeyValueList;

            /*以下是还未与视频进行对接的节点，有点节点对接的视频需要重做。 by 伍
            videoKeyValueList.Add("Test.InputOperation.ctlCheckBoxImage", "08.单选框，复选框.wmv");
            videoKeyValueList.Add("Test.ViewMode.ctlTestViewMode", "视图设置");
            videoKeyValueList.Add("Test.OtherElementsOperation.ctlTestControlHost", "21.第三方组件.wmv");                
            videoKeyValueList.Add("Test.OtherElementsOperation.ctlMediaElement", "35.插入音视频元素.wmv");                    
            videoKeyValueList.Add("TimeLineTest.ctlTimeLineTimeZone", "时间区域和超链接.wmv");
            videoKeyValueList.Add("Test.InputOperation.ctlTestEventVBScript", "元素事件VB脚本");
            videoKeyValueList.Add("Test.InputOperation.ctlTestAxWriterControl", "测试AxWriterControl");   
            videoKeyValueList.Add("Test.CourseRecord.ctlTestMulCourse", "病程记录");
            videoKeyValueList.Add("Test.CourseRecord.ctlTestMulCourse2", "病程记录2");
            videoKeyValueList.Add("Test.CourseRecord.ctlTestMulCourse3", "病程记录3");
            videoKeyValueList.Add("Test.CourseRecord.ctlTestMulCourse4", "病程记录4");
            videoKeyValueList.Add("Test.DOMAuxiliaryOperation.ctlResourceString", "自定义字符串资源");
            videoKeyValueList.Add("Test.DOMAuxiliaryOperation.ctlFilterValue", "数据过滤器");
            videoKeyValueList.Add("Test.DOMAuxiliaryOperation.ctlTestWriterControlExt", "WriterControlExt");
            videoKeyValueList.Add("Test.DOMAuxiliaryOperation.ctlRigthToLeft", "从右到左排版");
            videoKeyValueList.Add("Test.DOMAuxiliaryOperation.ctlTestOther", "其他测试");
            videoKeyValueList.Add("Test.OtherElementsOperation.ctlTestButtonElement", "按钮文档元素");
            videoKeyValueList.Add("Test.OtherElementsOperation.ctlTestFileBlock", "文件引用块元素");
            videoKeyValueList.Add("TestMDI", "MDI窗体演示");
            videoKeyValueList.Add("demoFile", "演示文档");
            videoKeyValueList.Add("zh-TW", "繁体中文版");
            videoKeyValueList.Add("ar", "维文版");
            videoKeyValueList.Add("TimeLineTest.ctlTimeLineNormal", "常规功能演示");
            videoKeyValueList.Add("TimeLineTest.ctlTimeLineOperRoomFlow", "手术室排程");
            videoKeyValueList.Add("TimeLineTest.ctlFillDynamic", "多线程实时填充");
             */
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //默认打开视频按钮不可用
            this.tsbOpenVideo.Enabled = false;
            this.tsbOpenVideo.Visible = false;
            //初始化视频列表
            // videoKeyValueList
            AddvideoKeyValueList();
            //System.Diagnostics.Trace.Listeners.Clear();
            //System.Diagnostics.Trace.AutoFlush = true;
            //System.Diagnostics.Trace.Listeners.Add(new System.Diagnostics.TextWriterTraceListener("app.log"));
            ////添加启动项目的按钮 
            //Button btnStartProjectFile = new Button();
            //btnStartProjectFile.BringToFront();
            //btnStartProjectFile.Text = "打开解决方案";
            //btnStartProjectFile.Width = 80;
            //btnStartProjectFile.Height = 20;
            //this.Controls.Add(btnStartProjectFile);
            //btnStartProjectFile.BringToFront();
            //btnStartProjectFile.Location = new Point(600, 0);
            //btnStartProjectFile.Click += delegate(object sender1, EventArgs e1) {
            //    string path = Path.Combine(Directory.GetCurrentDirectory(), @"DCSoftDemoCenter\Start.exe");
            //    //System.Diagnostics.Process.Start(path, "编辑器exe");
            //    System.Diagnostics.Process.Start(path, "编辑器源码");
            //    //System.Diagnostics.Process.Start(@"E:\Working\编辑器\WinFormDemo\DCSoft.Writer.WinFormDemo2010.sln"); 
            //};
            ////this.myTabControl.SendToBack();

            using (System.IO.Stream stream = this.GetType().Assembly.GetManifestResourceStream("DCSoft.Writer.WinFormDemo.DemoTreeView.xml"))
            {
                //reader.Read();
                System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(stream);
                while (reader.Read())
                {
                    if (reader.NodeType == System.Xml.XmlNodeType.Element)
                    {
                        break;
                    }
                }
                DCSoft.WinForms.WinFormXMLHelper.ReadTreeViewContentFromXml(this.tvwMenu, reader);
            }
            TreeNode demoNodes = this.tvwMenu.Nodes[0].Nodes["demoFile"];
            #region MyRegion
            //if (demoNodes != null)
            //{
            //    string dir = Path.Combine(Application.StartupPath, "DemoFile2");
            //    List<string> names = new List<string>(Directory.GetFiles(dir, "*.xml"));
            //    names.Sort();
            //    TreeNode nodeMedicalRecordHomePage = new TreeNode("病案首页");
            //    TreeNode nodeNursingRecord = new TreeNode("护理记录");
            //    TreeNode nodeScale = new TreeNode("量表");
            //    TreeNode nodeInspectionReport = new TreeNode("检查报告");
            //    TreeNode nodeCrossIndustry = new TreeNode("跨行业应用");
            //    TreeNode nodeGastroScope = new TreeNode("胃镜报告");
            //    TreeNode nodeHospitalRecords = new TreeNode("入院记录");
            //    TreeNode nodeHospitalMedicalRecords = new TreeNode("住院病历");
            //    TreeNode nodeAssessmentInstrument = new TreeNode("评估文书");
            //    TreeNode nodeDefault = new TreeNode("其他");
            //    TreeNode node = new TreeNode();
            //    foreach (string fileName in names)
            //    {
            //    node = null;
            //    //进行用户案例分类
            //    if (fileName.Contains("病案首页"))
            //    {
            //        node = new TreeNode(Path.GetFileNameWithoutExtension(fileName));
            //        node.Text = "病案首页--" + Path.GetFileNameWithoutExtension(fileName);
            //        node.Name = "Open:" + fileName;
            //        node.ForeColor = Color.Blue;
            //        node.ImageKey = "xml";
            //        node.SelectedImageKey = "xml";
            //        nodeMedicalRecordHomePage.Nodes.Add(node);
            //        continue;
            //    }
            //    if (fileName.Contains("护理记录"))
            //    {
            //        node = new TreeNode(Path.GetFileNameWithoutExtension(fileName));
            //        node.Text = "护理记录--" + Path.GetFileNameWithoutExtension(fileName);
            //        node.Name = "Open:" + fileName;
            //        node.ForeColor = Color.Blue;
            //        node.ImageKey = "xml";
            //        node.SelectedImageKey = "xml";
            //        nodeNursingRecord.Nodes.Add(node);
            //        continue;
            //    }
            //    if (fileName.Contains("量表"))
            //    {
            //        node = new TreeNode(Path.GetFileNameWithoutExtension(fileName));
            //        node.Text = "量表--" + Path.GetFileNameWithoutExtension(fileName);
            //        node.Name = "Open:" + fileName;
            //        node.ForeColor = Color.Blue;
            //        node.ImageKey = "xml";
            //        node.SelectedImageKey = "xml";
            //        nodeScale.Nodes.Add(node);
            //        continue;
            //    }
            //    if (fileName.Contains("税") || fileName.Contains("限速器"))
            //    {
            //        node = new TreeNode(Path.GetFileNameWithoutExtension(fileName));
            //        node.Text = "跨行业应用--" + Path.GetFileNameWithoutExtension(fileName);
            //        node.Name = "Open:" + fileName;
            //        node.ForeColor = Color.Blue;
            //        node.ImageKey = "xml";
            //        node.SelectedImageKey = "xml";
            //        nodeCrossIndustry.Nodes.Add(node);
            //        continue;
            //    }
            //    if (fileName.Contains("报告"))
            //    {
            //        node = new TreeNode(Path.GetFileNameWithoutExtension(fileName));
            //        node.Text = "检查报告--" + Path.GetFileNameWithoutExtension(fileName);
            //        node.Name = "Open:" + fileName;
            //        node.ForeColor = Color.Blue;
            //        node.ImageKey = "xml";
            //        node.SelectedImageKey = "xml";
            //        nodeInspectionReport.Nodes.Add(node);
            //        continue;
            //    }
            //    if (fileName.Contains("胃镜报告"))
            //    {
            //        node = new TreeNode(Path.GetFileNameWithoutExtension(fileName));
            //        node.Text = "胃镜报告--" + Path.GetFileNameWithoutExtension(fileName);
            //        node.Name = "Open:" + fileName;
            //        node.ForeColor = Color.Blue;
            //        node.ImageKey = "xml";
            //        node.SelectedImageKey = "xml";
            //        nodeGastroScope.Nodes.Add(node);
            //        continue;
            //    }
            //    if (fileName.Contains("病历"))
            //    {
            //        node = new TreeNode(Path.GetFileNameWithoutExtension(fileName));
            //        node.Text = "住院病历--" + Path.GetFileNameWithoutExtension(fileName);
            //        node.Name = "Open:" + fileName;
            //        node.ForeColor = Color.Blue;
            //        node.ImageKey = "xml";
            //        node.SelectedImageKey = "xml";
            //        nodeHospitalMedicalRecords.Nodes.Add(node);
            //        continue;
            //    }
            //    if (fileName.Contains("入院记录"))
            //    {
            //        node = new TreeNode(Path.GetFileNameWithoutExtension(fileName));
            //        node.Text = "入院记录--" + Path.GetFileNameWithoutExtension(fileName);
            //        node.Name = "Open:" + fileName;
            //        node.ForeColor = Color.Blue;
            //        node.ImageKey = "xml";
            //        node.SelectedImageKey = "xml";
            //        nodeHospitalRecords.Nodes.Add(node);
            //        continue;
            //    }
            //    if (fileName.Contains("评估"))
            //    {
            //        node = new TreeNode(Path.GetFileNameWithoutExtension(fileName));
            //        node.Text = "评估文书--" + Path.GetFileNameWithoutExtension(fileName);
            //        node.Name = "Open:" + fileName;
            //        node.ForeColor = Color.Blue;
            //        node.ImageKey = "xml";
            //        node.SelectedImageKey = "xml";
            //        nodeAssessmentInstrument.Nodes.Add(node);
            //        continue;
            //    }
            //    node = new TreeNode(Path.GetFileNameWithoutExtension(fileName));
            //    node.Text = "其他--" + Path.GetFileNameWithoutExtension(fileName);
            //    node.Name = "Open:" + fileName;
            //    node.ForeColor = Color.Blue;
            //    node.ImageKey = "xml";
            //    node.SelectedImageKey = "xml";
            //    nodeDefault.Nodes.Add(node);
            //    //switch () 
            //    //{
            //    //    case "病案首页": break;
            //    //    case "": break;
            //    //    case "": break;
            //    //    case "": break;
            //    //    case "": break;
            //    //    case "": break;
            //    //    case "": break;
            //    //    case "": break;
            //    //    case "": break;
            //    //    case "": break;
            //    //}
            //    //TreeNode node2 = new TreeNode(Path.GetFileNameWithoutExtension(fileName));
            //    //node2.Name = "Open:" + fileName;
            //    //node2.ForeColor = Color.Blue;
            //    //node2.ImageKey = "xml";
            //    //node2.SelectedImageKey = "xml";
            //    //demoNodes.Nodes.Add(node2);
            //}
            //TreeNode[] nodeArray = null;
            //if (nodeMedicalRecordHomePage.Nodes.Count > 0)
            //{
            //    //demoNodes.Nodes.Add(nodeMedicalRecordHomePage);
            //    nodeArray = new TreeNode[nodeMedicalRecordHomePage.Nodes.Count];
            //    nodeMedicalRecordHomePage.Nodes.CopyTo(nodeArray, 0);
            //    demoNodes.Nodes.AddRange(nodeArray);
            //    nodeArray = null;
            //}
            //if (nodeNursingRecord.Nodes.Count > 0)
            //{
            //    //demoNodes.Nodes.Add(nodeNursingRecord);
            //    nodeArray = new TreeNode[nodeNursingRecord.Nodes.Count];
            //    nodeNursingRecord.Nodes.CopyTo(nodeArray, 0);
            //    demoNodes.Nodes.AddRange(nodeArray);
            //    nodeArray = null;
            //}
            //if (nodeScale.Nodes.Count > 0)
            //{
            //    //demoNodes.Nodes.Add(nodeScale);
            //    nodeArray = new TreeNode[nodeScale.Nodes.Count];
            //    nodeScale.Nodes.CopyTo(nodeArray, 0);
            //    demoNodes.Nodes.AddRange(nodeArray);
            //    nodeArray = null;
            //}
            //if (nodeInspectionReport.Nodes.Count > 0)
            //{
            //    //demoNodes.Nodes.Add(nodeInspectionReport);
            //    nodeArray = new TreeNode[nodeInspectionReport.Nodes.Count];
            //    nodeInspectionReport.Nodes.CopyTo(nodeArray, 0);
            //    demoNodes.Nodes.AddRange(nodeArray);
            //    nodeArray = null;
            //}
            //if (nodeGastroScope.Nodes.Count > 0)
            //{
            //    //demoNodes.Nodes.Add(nodeGastroScope);
            //    nodeArray = new TreeNode[nodeGastroScope.Nodes.Count];
            //    nodeGastroScope.Nodes.CopyTo(nodeArray, 0);
            //    demoNodes.Nodes.AddRange(nodeArray);
            //    nodeArray = null;
            //}
            //if (nodeHospitalRecords.Nodes.Count > 0)
            //{
            //    //demoNodes.Nodes.Add(nodeHospitalRecords);
            //    nodeArray = new TreeNode[nodeHospitalRecords.Nodes.Count];
            //    nodeHospitalRecords.Nodes.CopyTo(nodeArray, 0);
            //    demoNodes.Nodes.AddRange(nodeArray);
            //    nodeArray = null;
            //}
            //if (nodeHospitalMedicalRecords.Nodes.Count > 0)
            //{
            //    //demoNodes.Nodes.Add(nodeHospitalMedicalRecords);
            //    nodeArray = new TreeNode[nodeHospitalMedicalRecords.Nodes.Count];
            //    nodeHospitalMedicalRecords.Nodes.CopyTo(nodeArray, 0);
            //    demoNodes.Nodes.AddRange(nodeArray);
            //    nodeArray = null;
            //}
            //if (nodeAssessmentInstrument.Nodes.Count > 0)
            //{
            //    //demoNodes.Nodes.Add(nodeAssessmentInstrument);
            //    nodeArray = new TreeNode[nodeAssessmentInstrument.Nodes.Count];
            //    nodeAssessmentInstrument.Nodes.CopyTo(nodeArray, 0);
            //    demoNodes.Nodes.AddRange(nodeArray);
            //    nodeArray = null;
            //}
            //if (nodeCrossIndustry.Nodes.Count > 0)
            //{
            //    //demoNodes.Nodes.Add(nodeCrossIndustry);
            //    nodeArray = new TreeNode[nodeCrossIndustry.Nodes.Count];
            //    nodeCrossIndustry.Nodes.CopyTo(nodeArray, 0);
            //    demoNodes.Nodes.AddRange(nodeArray);
            //    nodeArray = null;
            //}
            //if (nodeDefault.Nodes.Count > 0)
            //{
            //    //demoNodes.Nodes.Add(nodeDefault);
            //    nodeArray = new TreeNode[nodeDefault.Nodes.Count];
            //    nodeDefault.Nodes.CopyTo(nodeArray, 0);
            //    demoNodes.Nodes.AddRange(nodeArray);
            //    nodeArray = null;
            //}
            //} 
            #endregion
            #region 保留
            if (demoNodes != null)
            {
                string dir = Path.Combine(Application.StartupPath, "DemoFile2");
                List<string> names = new List<string>(Directory.GetFiles(dir, "*.xml"));
                names.Sort();
                foreach (string fileName in names)
                {
                    TreeNode node2 = new TreeNode(Path.GetFileNameWithoutExtension(fileName));
                    node2.Name = "Open:" + fileName;
                    node2.ForeColor = Color.Blue;
                    node2.ImageKey = "xml";
                    node2.SelectedImageKey = "xml";
                    demoNodes.Nodes.Add(node2);
                }
            }
            #endregion
            DCSoft.WinForms.WinFormUtils.SetNodesMultiLayerIndexs(this.tvwMenu.Nodes);

            string name = "ctlTextUseCommand";
            RefreshView(name);
            //this.TopMost = true;
            this.tvwMenu.Nodes[0].Expand();

            #region <<解压缩ASPNETDemoLauncher和10.0两个文件>>
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            try
            {
                // byte[] zipfile = (byte[])Properties.Resources._10_0;//.ResourceManager.GetObject("DC10.0");
                string path = Path.Combine(Environment.CurrentDirectory, @"DemoResources\\10.0.zip");
                //File.WriteAllBytes(path, zipfile);//此处path定位到文件名
                if (!System.IO.Directory.Exists(Path.Combine(Environment.CurrentDirectory, @"10.0")))
                {
                    (new FastZip()).ExtractZip(path, Environment.CurrentDirectory, "");//解压  
                }
                //File.Delete(path);

                // byte[] zipfile = (byte[])Properties.Resources.DCSoft_ASPNETDemo;
                path = Path.Combine(Environment.CurrentDirectory, @"DemoResources\\DCSoft.ASPNETDemo.zip");
                //File.WriteAllBytes(path, zipfile);//此处path定位到文件名
                if (!System.IO.Directory.Exists(Path.Combine(Environment.CurrentDirectory, @"DCSoft.ASPNETDemo")))
                {
                    (new FastZip()).ExtractZip(path, Environment.CurrentDirectory, "");//解压  
                    // (new FastZip()).ExtractZip(@"D:\\DCSoft.ASPNETDemo.zip", @"E:\\111", "");//解压  
                }
                //File.Delete(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            #endregion
        }
        private bool f1(string s)
        {
            return true;
        }
        //  /// <summary>
        ///// 解压缩
        ///// </summary>
        ///// <param name="sourceFile">压缩包完整路径地址</param>
        ///// <param name="targetPath">解压路径是哪里</param>
        ///// <returns></returns>
        //public static bool Decompress(string sourceFile, string targetPath)
        //{
        //    if (!File.Exists(sourceFile))
        //    {
        //        throw new FileNotFoundException(string.Format("未能找到文件 '{0}' ", sourceFile));
        //    }
        //    if (!Directory.Exists(targetPath))
        //    {
        //        Directory.CreateDirectory(targetPath);
        //    }
        //    using (var s = new ZipInputStream(File.OpenRead(sourceFile)))
        //    {
        //        ZipEntry theEntry;
        //        while ((theEntry = s.GetNextEntry()) != null)
        //        {
        //            if (theEntry.IsDirectory)
        //            {
        //                continue;
        //            }
        //            string directorName = Path.Combine(targetPath, Path.GetDirectoryName(theEntry.Name));
        //            string fileName = Path.Combine(directorName, Path.GetFileName(theEntry.Name));
        //            if (!Directory.Exists(directorName))
        //            {
        //                Directory.CreateDirectory(directorName);
        //            }
        //            if (!String.IsNullOrEmpty(fileName))
        //            {
        //                using (FileStream streamWriter = File.Create(fileName))
        //                {
        //                    int size = 4096;
        //                    byte[] data = new byte[size];
        //                    while (size > 0)
        //                    {
        //                        streamWriter.Write(data, 0, size);
        //                        size = s.Read(data, 0, data.Length);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return true;
        //}

        public Stream FileToStream(string fileName)
        {
            // 打开文件   
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            // 读取文件的 byte[]   
            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, bytes.Length);
            fileStream.Close();
            // 把 byte[] 转换成 Stream   
            Stream stream = new MemoryStream(bytes);
            return stream;
        }

        private Form _DemoForm = null;

        public Form DemoForm
        {
            get { return _DemoForm; }
            set { _DemoForm = value; }
        }

        private bool bolEnableTreeViewEvent = true;
        /// <summary>
        /// 树节点选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tvwmenu_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        /// <summary>
        /// 双击选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tvwmenu_DoubleClick(object sender, EventArgs e)
        {
            //using (System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(@"E:\Source\DCSoft\08代码\DCSoft\DCSoft.Writer\DCSoft.Writer.Demo\WinFormDemo\DemoTreeView.xml", Encoding.UTF8))
            //{
            //    writer.Formatting = System.Xml.Formatting.Indented;
            //    writer.Indentation = 1;
            //    writer.IndentChar = '\t';
            //    writer.WriteStartDocument();
            //    writer.WriteStartElement("TreeView");
            //    DCSoft.WinForms.WinFormXMLHelper.WriteTreeViewContentToXml(this.tvwMenu, writer);
            //    writer.WriteEndElement();
            //    writer.WriteEndDocument();
            //}
            if (bolEnableTreeViewEvent)
            {
                bolEnableTreeViewEvent = false;
                if (tvwMenu.SelectedNode != null)
                {
                    if (tvwMenu.SelectedNode.Name == "TestMDI")
                    {
                        using (frmMDIParent frm = new frmMDIParent())
                        {
                            frm.ShowDialog(this);
                        }
                    }
                    else if (tvwMenu.SelectedNode.Name == "zh-TW" || tvwMenu.SelectedNode.Name == "ar" || tvwMenu.SelectedNode.Name == "Tibetan")
                    {
                        RunMultiCulre(tvwMenu.SelectedNode.Name);
                    }
                    else if (tvwMenu.SelectedNode.Name != null && tvwMenu.SelectedNode.Name.StartsWith("Open:"))
                    {
                        string fileName = tvwMenu.SelectedNode.Name.Substring(5);
                        ctlTextUseCommand ctl = RefreshView("ctlTextUseCommand") as ctlTextUseCommand;
                        if (ctl != null)
                        {
                            ctl.OpenDocument(fileName);
                        }
                    }
                    else
                    {
                        RefreshView(tvwMenu.SelectedNode.Name);
                    }
                }
                bolEnableTreeViewEvent = true;
            }
        }

        private void RunMultiCulre(string curl)
        {
            string exe = Application.ExecutablePath;
            System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
            info.FileName = exe;
            info.Arguments = "lan=" + curl;
            System.Diagnostics.Process.Start(info);
        }

        private Control RefreshView(string ViewName)
        {
            //根节点的还回
            if (ViewName == null)
            {
                if (tvwMenu.SelectedNode != null)
                {
                    ViewName = tvwMenu.SelectedNode.Name;
                }
            }
            if (string.IsNullOrEmpty(ViewName))
            {
                return null;
            }
            string typeName = this.GetType().Namespace + "." + ViewName;
            if (ViewName == null || ViewName.Trim().Length == 0)
            {
                return null;
            }
            Type ctlType = this.GetType().Assembly.GetType(typeName, false, true);
            if (ctlType == null)
            {
                // 没找到控件类型
                return null;
            }


            myTabControl.SelectedIndex = 0;
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            Control currentControl = null;
            Control NewControl = null;
            foreach (Control ctl in pageDemo.Controls)
            {
                if (ctl.Visible)
                {
                    currentControl = ctl;
                    break;
                }
            }
            foreach (Control ctl in pageDemo.Controls)
            {
                if (ctlType.IsInstanceOfType(ctl))
                {
                    NewControl = ctl;
                    break;
                }
            }

            if (NewControl == null)
            {
                NewControl = (Control)System.Activator.CreateInstance(ctlType);
            }

            if (NewControl != null)
            {
                if (currentControl != NewControl)
                {
                    if (currentControl != null)
                    {
                        currentControl.Visible = false;
                    }
                    if (pageDemo.Controls.Contains(NewControl) == false)
                    {
                        pageDemo.Controls.Add(NewControl);
                    }
                    NewControl.Visible = true;
                    NewControl.Dock = DockStyle.Fill;
                    if (tvwMenu.SelectedNode != null)
                    {
                        pageDemo.Text = "演示：" + tvwMenu.SelectedNode.Text + "|" + ViewName;
                    }
                }

                //----代码路径和样式---
                this.Update();
                string sourceFileName = System.IO.Path.Combine(Application.StartupPath, ViewName.Replace(".", "\\")) + ".cs";

                string sourceCode = null;
                if (System.IO.File.Exists(sourceFileName))
                {
                    using (System.IO.StreamReader reader = new System.IO.StreamReader(sourceFileName, Encoding.Default, true))
                    {
                        sourceCode = reader.ReadToEnd();
                        if (sourceCode != null)
                        {
                            sourceCode = sourceCode.Replace("\t", "    ");
                        }
                    }

                    XtractPro.Text.CSharpSyntaxHighlighter hi =
                        new XtractPro.Text.CSharpSyntaxHighlighter();
                    hi.ShowCollapsibleBlocks = false;
                    hi.ShowComments = true;
                    hi.ShowHyperlinks = true;
                    hi.ShowLineNumbers = true;
                    hi.ShowRtf = true;
                    hi.AddCssSourceCode = true;
                    sourceCode = hi.Process(sourceCode);
                }
                else
                {
                    sourceCode = " can not find file" + sourceFileName;
                }
                myWebBrowser.DocumentText = "<html><body leftmargin=0 topmargin=0>" + sourceCode + "</body></html>";

                //添加应用场景Application scenarios
                #region Application scenarios
                //string scenariosFileName = System.IO.Path.Combine(Application.StartupPath + "\\ApplicationScenarios", ViewName.Replace(".", "\\")) + ".xml";
                string scenariosFileName = System.IO.Path.Combine(Application.StartupPath, ViewName.Replace(".", "\\")) + ".xml";

                string applicationScenarios = null;
                //if (System.IO.File.Exists(scenariosFileName))
                //{
                //    using (System.IO.StreamReader reader = new System.IO.StreamReader(scenariosFileName, Encoding.Default, true))
                //    {
                //        applicationScenarios = reader.ReadToEnd();
                //        if (applicationScenarios != null)
                //        {
                //            applicationScenarios = applicationScenarios.Replace("\t", "    ");
                //        }
                //    }
                //}
                //else
                //{
                //    //applicationScenarios = " can not find file" + scenariosFileName;
                //    applicationScenarios = "该功能即将上线，敬请期待！";
                //    applicationScenarios = @"DemoFile\南京都昌科技ST_会诊记录.xml\DemoFile\南京都昌科技ST_会诊记录.xml";
                //}
                //applicationScenarios = @"南京都昌科技ST_会诊记录.xml";
                //DCSoft.Writer.WinFormDemo.Test.UserControls.ApplicationScenes applicationScene = new Test.UserControls.ApplicationScenes();
                //if (this.pageScene.Controls.ContainsKey("ApplicationScenes") == false)
                //{
                applicationScenarios = ViewName;
                Type ctlType1 = this.GetType().Assembly.GetType("DCSoft.Writer.WinFormDemo.Test.UserControls.ApplicationScenes", false, true);
                if (ctlType1 == null)
                {
                    // 没找到控件类型
                    return null;
                }
                Control currentControl1 = null;
                Control NewControl1 = null;
                foreach (Control ctl in pageScene.Controls)
                {
                    if (ctl.Visible)
                    {
                        currentControl1 = ctl;
                        break;
                    }
                }
                foreach (Control ctl in pageScene.Controls)
                {
                    if (ctlType1.IsInstanceOfType(ctl))
                    {
                        NewControl1 = ctl;
                        break;
                    }
                }

                if (NewControl1 == null)
                {
                    NewControl1 = (Control)System.Activator.CreateInstance(ctlType1, new string[] { applicationScenarios });
                }
                if (currentControl1 != NewControl1)
                {
                    if (currentControl1 != null)
                    {
                        currentControl1.Visible = false;
                    }
                    if (pageScene.Controls.Contains(NewControl1) == false)
                    {
                        pageScene.Controls.Add(NewControl1);
                        NewControl1.Visible = true;
                        NewControl1.Dock = DockStyle.Fill;
                    }

                    //}
                    this.Update();

                    //Type ctlType1 = this.GetType().Assembly.GetType("DCSoft.Writer.WinFormDemo.Test.UserControls.ApplicationScenes", false, true);
                    //if (ctlType1 == null)
                    //{
                    //    // 没找到控件类型
                    //    return null;
                    //}
                    //Control ApplicationScenesControl = (Control)System.Activator.CreateInstance(ctlType1, new string[] { applicationScenarios });
                    ////Control ApplicationScenesControl = (Control)System.Activator.CreateInstance(ctlType1);
                    //this.pageScene.Controls.Add(ApplicationScenesControl);
                    //ApplicationScenesControl.Visible = true;
                    //ApplicationScenesControl.Dock = DockStyle.Fill;
                }
                //this.mySceneWebBrowser.DocumentText = "<html><body leftmargin=0 topmargin=0>" + applicationScenarios + "</body></html>";
                #endregion

                //预留小伍视频Video   
                if (this.videoKeyValueList.ContainsKey(ViewName) == true)
                {
                    this.tsbOpenVideo.Enabled = true;
                    this.tsbOpenVideo.Visible = true;
                }
                else
                {
                    this.tsbOpenVideo.Enabled = false;
                    this.tsbOpenVideo.Visible = true;
                }
            }
            this.Cursor = Cursors.Default;
            return NewControl;
        }

        static string Allpath = Path.Combine(Application.StartupPath, "DCSoft.ApplicationStart.exe");
        private void tsbOpenSln_Click(object sender, EventArgs e)
        {
            if (File.Exists(Allpath))
            {
                System.Diagnostics.Process.Start(Allpath, "DCEditorCode");
            }
            else
            {
                MessageBox.Show("当前路径不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tsbOpenVideo_Click(object sender, EventArgs e)
        {
            string videoName = tvwMenu.SelectedNode.Name;
            if (string.IsNullOrEmpty(videoName) == true || videoKeyValueList == null || videoKeyValueList.Count < 0)
            {
                return;
            }
            if (videoKeyValueList.ContainsKey(videoName))
            {
                videoName = "DCMedia&" + videoKeyValueList[videoName];
                if (File.Exists(Allpath))
                {
                    System.Diagnostics.Process.Start(Allpath, videoName);
                }
                else
                {
                    MessageBox.Show("当前路径不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("未找到" + videoName + "的相应的视频信息", "信息提示：");
            }
        }

        private void tsbReturnMainDestop_Click(object sender, EventArgs e)
        {
            //返回主界面
            //string ss = Application.StartupPath;
            //System.Diagnostics.Trace.WriteLine(ss);
            string path = Directory.GetCurrentDirectory();
        }

        private void tsbTraditionalChineseVersion_Click(object sender, EventArgs e)
        {
            RunMultiCulre("zh-TW");
        }

        private void tsbWeavingVersion_Click(object sender, EventArgs e)
        {
            if (File.Exists(Allpath))
            {
                System.Diagnostics.Process.Start(Allpath, "DCEditorUGSingleAppEXE");
            }
            else
            {
                MessageBox.Show("当前路径不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tsbTibetanEdition_Click(object sender, EventArgs e)
        {
            //启动藏文版界面
            RefreshView("Test.Version.Tibetan");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.IsShowTreeview.Text == "显示")
            {
                this.tvwMenu.Visible = true;
                this.IsShowTreeview.Text = "隐藏";
            }
            else if (this.IsShowTreeview.Text == "隐藏")
            {
                this.tvwMenu.Visible = false;
                this.IsShowTreeview.Text = "显示";
            }
        }
    }
}
