using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.WinForms;
using DCSoft.Writer.Commands;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Serialization;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace DCSoft.Writer
{
	/// <summary>
	///       文本编辑器宿主对象
	///       </summary>
	[ComVisible(true)]
	
	[Guid("00012345-6789-ABCD-EF01-234567890074")]
	
	public class WriterAppHost
	{
		private static string string_0;

		private static volatile bool bool_0;

		private static bool bool_1;

		private static volatile bool bool_2;

		private static WriterAppHost writerAppHost_0;

		private ClipboardProvider clipboardProvider_0 = null;

		private bool bool_3 = false;

		private string string_1 = null;

		private WriterCommandContainer writerCommandContainer_0 = new WriterCommandContainer();

		private IServiceContainer iserviceContainer_0 = null;

		private bool bool_4 = true;

		private ContentSerializerList contentSerializerList_0 = new ContentSerializerList();

		private WriterAppHostConfig writerAppHostConfig_0 = new WriterAppHostConfig();

		/// <summary>
		///       授权文件名
		///       </summary>
		
		public static string LicenseFileName
		{
			get
			{
				return XTextDocument.StaticRegisterCodeFileUrl;
			}
			set
			{
				XTextDocument.StaticRegisterCodeFileUrl = value;
			}
		}

		/// <summary>
		///       判断PreloadSystemAsync()启动的后台操作是否完成。
		///       </summary>
		
		public static bool IsPreloadSystemAsyncCompleted => !bool_0;

		/// <summary>
		///       默认对象
		///       </summary>
		
		public static WriterAppHost Default
		{
			get
			{
				lock (typeof(WriterAppHost))
				{
					if (writerAppHost_0 == null)
					{
						writerAppHost_0 = new WriterAppHost();
						ModuleStarter.StartAllModule(writerAppHost_0);
					}
					return writerAppHost_0;
				}
			}
			set
			{
				writerAppHost_0 = value;
			}
		}

		/// <summary>
		///       剪切版功能提供者
		///       </summary>
		
		public ClipboardProvider Clipboard
		{
			get
			{
				if (clipboardProvider_0 == null)
				{
					clipboardProvider_0 = new ClipboardProvider();
				}
				return clipboardProvider_0;
			}
			set
			{
				clipboardProvider_0 = value;
			}
		}

		/// <summary>
		///       取消系统销毁对象.DCWriter内部使用。
		///       </summary>
		[Browsable(false)]
		[ComVisible(false)]
		
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool DisableFinalize
		{
			get
			{
				return bool_3;
			}
			set
			{
				bool_3 = value;
			}
		}

		/// <summary>
		///       联动列表提供者集合
		///       </summary>
		public LinkListProviderList LinkListProviders
		{
			get
			{
				LinkListProviderList linkListProviderList = (LinkListProviderList)Services.GetService(typeof(LinkListProviderList));
				if (linkListProviderList == null)
				{
					linkListProviderList = new LinkListProviderList();
					Services.AddService(typeof(LinkListProviderList), linkListProviderList);
				}
				return linkListProviderList;
			}
		}

		/// <summary>
		///       授权控制器
		///       </summary>
		public DCPermissionControler PermissionControler
		{
			get
			{
				DCPermissionControler dCPermissionControler = (DCPermissionControler)Services.GetService(typeof(DCPermissionControler));
				if (dCPermissionControler == null)
				{
					dCPermissionControler = new DCPermissionControler();
					Services.AddService(typeof(DCPermissionControler), dCPermissionControler);
				}
				return dCPermissionControler;
			}
		}

		/// <summary>
		///       文档元素编辑器对象
		///       </summary>
		public ElementPropertiesEditorContainer ElementEditors
		{
			get
			{
				ElementPropertiesEditorContainer elementPropertiesEditorContainer = (ElementPropertiesEditorContainer)Services.GetService(typeof(ElementPropertiesEditorContainer));
				if (elementPropertiesEditorContainer == null)
				{
					elementPropertiesEditorContainer = new ElementPropertiesEditorContainer();
					Services.AddService(typeof(ElementPropertiesEditorContainer), elementPropertiesEditorContainer);
				}
				return elementPropertiesEditorContainer;
			}
		}

		/// <summary>
		///       时间服务器对象
		///       </summary>
		
		public IDateTimeService DateTimeService => (IDateTimeService)Services.GetService(typeof(IDateTimeService));

		/// <summary>
		///       文档元素属性编辑器容器
		///       </summary>
		[Browsable(false)]
		public ElementPropertiesEditorContainer ElementPropertiesEditors
		{
			get
			{
				ElementPropertiesEditorContainer elementPropertiesEditorContainer = (ElementPropertiesEditorContainer)Services.GetService(typeof(ElementPropertiesEditorContainer));
				if (elementPropertiesEditorContainer == null)
				{
					elementPropertiesEditorContainer = new ElementPropertiesEditorContainer();
					Services.AddService(typeof(ElementPropertiesEditorContainer), elementPropertiesEditorContainer);
				}
				return elementPropertiesEditorContainer;
			}
		}

		/// <summary>
		///       应用程序数据基础路径
		///       </summary>
		public string ApplicationDataBaseUrl
		{
			get
			{
				return string_1;
			}
			set
			{
				string_1 = value;
			}
		}

		/// <summary>
		///       命令容器对象
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public WriterCommandContainer CommandContainer
		{
			get
			{
				if (writerCommandContainer_0 == null)
				{
					writerCommandContainer_0 = new WriterCommandContainer();
				}
				return writerCommandContainer_0;
			}
			set
			{
				writerCommandContainer_0 = value;
			}
		}

		/// <summary>
		///       宿主使用的知识库对象
		///       </summary>
		public KBLibrary KBLibrary
		{
			get
			{
				return (KBLibrary)Services.GetService(typeof(KBLibrary));
			}
			set
			{
				Services.AddService(typeof(KBLibrary), value);
			}
		}

		/// <summary>
		///       知识库提供者对象
		///       </summary>
		public IKBProvider KBProvider
		{
			get
			{
				return (IKBProvider)Services.GetService(typeof(IKBProvider));
			}
			set
			{
				Services.AddService(typeof(IKBProvider), value);
			}
		}

		/// <summary>
		///       宿主使用的UI层工具集,内部会检索Services列表，若没有找到则自动添加默认的UI工具集。
		///       </summary>
		
		public GClass15 Tools
		{
			get
			{
				GClass15 gClass = (GClass15)Services.GetService(typeof(GClass15));
				if (gClass == null)
				{
					gClass = new GClass15();
					Services.AddService(typeof(GClass15), gClass);
				}
				return gClass;
			}
			set
			{
				Services.AddService(typeof(GClass15), value);
			}
		}

		/// <summary>
		///       宿主使用的UI层工具集,内部会检索Services列表，若没有找到则自动添加默认的UI工具集。
		///       </summary>
		
		public DCUITools UITools
		{
			get
			{
				DCUITools dCUITools = (DCUITools)Services.GetService(typeof(DCUITools));
				if (dCUITools == null)
				{
					dCUITools = new DCUITools();
					Services.AddService(typeof(DCUITools), dCUITools);
				}
				return dCUITools;
			}
			set
			{
				if (XTextDocument.smethod_13(GEnum6.const_155))
				{
					Services.AddService(typeof(DCUITools), value);
				}
			}
		}

		/// <summary>
		///       错误信息报告者
		///       </summary>
		public IErrorReporter ErrorReporter
		{
			get
			{
				IErrorReporter errorReporter = (IErrorReporter)Services.GetService(typeof(IErrorReporter));
				if (errorReporter == null)
				{
					errorReporter = new DefaultErrorReporter();
					Services.AddService(typeof(IErrorReporter), errorReporter);
				}
				return errorReporter;
			}
		}

		/// <summary>
		///       服务器对象容器
		///       </summary>
		
		public IServiceContainer Services
		{
			get
			{
				if (iserviceContainer_0 == null)
				{
					iserviceContainer_0 = new DefaultServiceContainer();
				}
				return iserviceContainer_0;
			}
			set
			{
				iserviceContainer_0 = value;
			}
		}

		/// <summary>
		///       系统使用的文件系统列表
		///       </summary>
		
		public FileSystemDictionary FileSystems
		{
			get
			{
				FileSystemDictionary fileSystemDictionary = (FileSystemDictionary)Services.GetService(typeof(FileSystemDictionary));
				if (fileSystemDictionary == null)
				{
					fileSystemDictionary = new FileSystemDictionary();
					Services.AddService(typeof(FileSystemDictionary), fileSystemDictionary);
				}
				return fileSystemDictionary;
			}
			set
			{
				Services.AddService(typeof(FileSystemDictionary), value);
			}
		}

		/// <summary>
		///       数据源绑定路径处理提供者
		///       </summary>
		
		public DataBindingPathProvider DataBindingPathProvider
		{
			get
			{
				DataBindingPathProvider dataBindingPathProvider = (DataBindingPathProvider)Services.GetService(typeof(DataBindingPathProvider));
				if (dataBindingPathProvider == null)
				{
					dataBindingPathProvider = new DataBindingPathProvider();
					Services.AddService(typeof(DataBindingPathProvider), dataBindingPathProvider);
				}
				return dataBindingPathProvider;
			}
		}

		/// <summary>
		///       处于调试模式
		///       </summary>
		public bool DebugMode
		{
			get
			{
				return bool_4;
			}
			set
			{
				bool_4 = value;
			}
		}

		/// <summary>
		///       文档序列号器列表
		///       </summary>
		
		public ContentSerializerList ContentSerializers => contentSerializerList_0;

		/// <summary>
		///       系统默认文件格式名称
		///       </summary>
		public string DefaultFileFormat => ContentSerializers.DefaultSerializer.Name;

		/// <summary>
		///       调试输出对象
		///       </summary>
		public WriterDebugger Debuger
		{
			get
			{
				if (DebugMode)
				{
					return (WriterDebugger)Services.GetService(typeof(WriterDebugger));
				}
				return null;
			}
		}

		/// <summary>
		///       配置信息对象
		///       </summary>
		public WriterAppHostConfig Configs
		{
			get
			{
				return writerAppHostConfig_0;
			}
			set
			{
				writerAppHostConfig_0 = value;
			}
		}

		
		public static string smethod_0()
		{
			return GClass143.smethod_32();
		}

		
		public static void smethod_1()
		{
			XTextDocument.StaticRegisterCode = null;
			string licenseFileName = LicenseFileName;
			XTextDocument.StaticRegisterCodeFileUrl = null;
			if (File.Exists(licenseFileName))
			{
				File.SetAttributes(licenseFileName, FileAttributes.Normal);
				File.Delete(licenseFileName);
			}
		}

		/// <summary>
		///       进行注册
		///       </summary>
		/// <param name="code">注册码</param>
		/// <param name="saveFile">是否保存文件</param>
		/// <returns>注册是否成功</returns>
		public static bool Register(string code, bool saveFile)
		{
			int num = 19;
			XTextDocument.StaticRegisterCode = code;
			if (saveFile)
			{
				string path = XTextDocument.StaticRegisterCodeFileUrl = GClass144.smethod_0("DCSoft.Writer");
				using (StreamWriter streamWriter = new StreamWriter(path, append: false, Encoding.ASCII))
				{
					streamWriter.Write(code);
				}
			}
			return true;
		}

		static WriterAppHost()
		{
			string_0 = "029668050000000000007C3A01001DF83000000044435772697465725B556E72656769737465725D205B2570616765696E646578255D2F5B2570616765636F756E74255D04009F3E76DA";
			bool_0 = false;
			bool_1 = false;
			bool_2 = false;
			writerAppHost_0 = null;
		}

		/// <summary>
		///       异步的预先加载一些系统数据
		///       </summary>
		
		public static void PreloadSystemAsync()
		{
			bool_0 = true;
			ThreadStart start = PreloadSystem;
			Thread thread = new Thread(start);
			thread.Start();
		}

		/// <summary>
		///       异步的预先加载一些系统数据
		///       </summary>
		/// <remarks>使用预先加载一些数据，可以提高今后编辑器的运行速度，特别是第一次打开文件的速度。</remarks>
		
		public static void PreloadSystem()
		{
			int num = 4;
			if (!bool_1)
			{
				bool_1 = true;
				bool_2 = true;
				try
				{
					WriterUtils.smethod_6();
					float tickCountFloat = CountDown.GetTickCountFloat();
					XTextDocument xTextDocument = new XTextDocument();
					Stream manifestResourceStream = typeof(XTextDocument).Assembly.GetManifestResourceStream("DCSoft.Writer.preload.xml");
					if (manifestResourceStream != null)
					{
						xTextDocument.Load(manifestResourceStream, "xml");
						using (DCGraphics dcgraphics_ = xTextDocument.CreateDCGraphics())
						{
							xTextDocument.RefreshSize(dcgraphics_);
							xTextDocument.ExecuteLayout();
							xTextDocument.RefreshPages();
						}
						xTextDocument.SavePageImageToBase64String(0, "png");
						xTextDocument.SaveLongImageToBase64String("png");
						MemoryStream stream = new MemoryStream();
						xTextDocument.Save(stream, "xml");
						using (WriterControl writerControl = new WriterControl())
						{
							writerControl.InnerViewControl.bool_39 = true;
							writerControl.RuleVisible = true;
							writerControl.Width = 1000;
							writerControl.Height = 1000;
							writerControl.Document = xTextDocument;
							writerControl.CreateControl();
							writerControl.RefreshDocument();
							writerControl.Invalidate();
							writerControl.UserLoginByParameter("aaa", "bbb", 1);
							using (Bitmap bitmap = new Bitmap(1000, 1000))
							{
								writerControl.DrawToBitmap(bitmap, new Rectangle(0, 0, 1000, 1000));
							}
						}
						xTextDocument.Dispose();
					}
					GC.Collect();
					tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
				}
				finally
				{
					bool_2 = false;
					bool_0 = false;
				}
			}
			else
			{
				bool_0 = false;
			}
		}

		
		public static void smethod_2()
		{
			lock (typeof(WriterAppHost))
			{
				if (writerAppHost_0 != null)
				{
					writerAppHost_0 = null;
				}
			}
		}

		/// <summary>
		///       注册自定义文档元素类型
		///       </summary>
		/// <param name="elementType">自定义的文档元素对象</param>
		
		public static void RegisterElementType(Type elementType)
		{
			int num = 19;
			if (elementType == null)
			{
				throw new ArgumentNullException("elementType");
			}
			Class109.smethod_1(elementType);
		}

		/// <summary>
		///       注册自定义文档元素类型
		///       </summary>
		/// <param name="elementType">自定义的文档元素对象</param>
		
		public static void RegisterElementType(Type elementType, string typeDisplayName)
		{
			int num = 16;
			if (elementType == null)
			{
				throw new ArgumentNullException("elementType");
			}
			Class109.smethod_1(elementType);
			WriterUtils.smethod_16(elementType, typeDisplayName);
		}

		
		public static Type smethod_3(string string_2)
		{
			Type[] array = Class109.smethod_0();
			int num = 0;
			Type type;
			while (true)
			{
				if (num < array.Length)
				{
					type = array[num];
					if (string.Compare(type.Name, string_2, ignoreCase: true) == 0 || string.Compare(type.FullName, string_2, ignoreCase: true) == 0)
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return type;
		}

		
		public static bool smethod_4(WriterCommandEventArgs writerCommandEventArgs_0, XTextElement xtextElement_0, ElementPropertiesEditMethod elementPropertiesEditMethod_0)
		{
			ElementPropertiesEditor editor = writerCommandEventArgs_0.Host.ElementPropertiesEditors.GetEditor(xtextElement_0.GetType());
			if (editor != null)
			{
				ElementPropertiesEditEventArgs elementPropertiesEditEventArgs = new ElementPropertiesEditEventArgs();
				elementPropertiesEditEventArgs.Document = writerCommandEventArgs_0.Document;
				elementPropertiesEditEventArgs.Host = writerCommandEventArgs_0.Host;
				elementPropertiesEditEventArgs.LogUndo = (elementPropertiesEditMethod_0 == ElementPropertiesEditMethod.Edit);
				elementPropertiesEditEventArgs.ParentWindow = writerCommandEventArgs_0.EditorControl;
				elementPropertiesEditEventArgs.Element = xtextElement_0;
				elementPropertiesEditEventArgs.Method = elementPropertiesEditMethod_0;
				elementPropertiesEditEventArgs.WriterControl = writerCommandEventArgs_0.EditorControl;
				return editor.Edit(elementPropertiesEditEventArgs);
			}
			return false;
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public WriterAppHost()
		{
			Services.AddService(typeof(WriterAppHost), this);
			Services.AddService(typeof(DCPermissionControler), new DCPermissionControler());
			Services.AddService(typeof(WriterDebugger), new WriterDebugger());
		}

		/// <summary>
		///       销毁对象
		///       </summary>
		
		~WriterAppHost()
		{
			if (bool_3)
			{
				GC.SuppressFinalize(this);
				GC.ReRegisterForFinalize(this);
			}
		}

		/// <summary>
		///       检测开始所有功能模块
		///       </summary>
		
		public void CheckStartAllModule()
		{
			if (!ModuleStarter.Started)
			{
				ModuleStarter.StartAllModule(this);
			}
		}

		/// <summary>
		///       创建文档元素属性对象
		///       </summary>
		/// <param name="elementType">文档元素类型</param>
		/// <returns>创建的文档元素属性对象</returns>
		
		public virtual GClass8 CreateProperties(Type elementType)
		{
			GAttribute0 gAttribute = GAttribute0.smethod_0(elementType);
			if (gAttribute != null && gAttribute.method_0() != null)
			{
				return (GClass8)Activator.CreateInstance(gAttribute.method_0());
			}
			return null;
		}

		/// <summary>
		///       添加服务对象
		///       </summary>
		/// <param name="type">
		/// </param>
		/// <param name="instance">
		/// </param>
		
		[Obsolete("仅保留对旧代码的兼容性，不推荐使用，请使用 Services.AddService")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddService(Type type, object instance)
		{
			if (instance == null)
			{
				if (Services.GetService(type) != null)
				{
					Services.RemoveService(type);
				}
			}
			else if (Services.GetService(type) == null)
			{
				Services.AddService(type, instance);
			}
			else
			{
				Services.RemoveService(type);
				Services.AddService(type, instance);
			}
		}
	}
}
