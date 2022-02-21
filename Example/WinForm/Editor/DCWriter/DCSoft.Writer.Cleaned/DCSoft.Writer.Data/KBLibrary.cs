#define DEBUG
using DCSoft.Common;
using DCSoft.Data;
using DCSoft.Writer.Controls;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       知识库
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	[Guid("00012345-6789-ABCD-EF01-234567890028")]
	[ComDefaultInterface(typeof(IKBLibrary))]
	[ComClass("00012345-6789-ABCD-EF01-234567890028", "5685CEC6-0C2C-40BE-9152-DA6B0CCCA36C")]
	[DocumentComment]
	
	[XmlType]
	public class KBLibrary : IKBLibrary
	{
		private class KBTextComparer : IComparer<KBEntry>
		{
			private bool _compareTextLength = false;

			public KBTextComparer(bool bool_0)
			{
				_compareTextLength = bool_0;
			}

			public int Compare(KBEntry kbentry_0, KBEntry kbentry_1)
			{
				if (_compareTextLength)
				{
					int length = kbentry_0.Text.Length;
					int length2 = kbentry_1.Text.Length;
					if (length != length2)
					{
						return length - length2;
					}
				}
				return string.Compare(kbentry_0.Text, kbentry_1.Text);
			}
		}

		internal const string CLASSID = "00012345-6789-ABCD-EF01-234567890028";

		internal const string CLASSID_Interface = "5685CEC6-0C2C-40BE-9152-DA6B0CCCA36C";

		[NonSerialized]
		private bool _UseLanguage2 = false;

		private string _Title = null;

		private string _TemplateFileSystemName = "template";

		[NonSerialized]
		private IFileSystem _TemplateFileSystem = null;

		/// <summary>
		///       加载节点模板内容委托对象
		///       </summary>
		[NonSerialized]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
		[Browsable(false)]
		public KBEntryLoadTemplateContentEventHandler LoadEntryTemplateContentHandler = null;

		private string _BaseURL = null;

		[NonSerialized]
		private string _RuntimeBaseURL = null;

		private string _ListItemsSourceFormatString = null;

		private string _TemplateSourceFormatString = null;

		private string _TemplateFileFormat = null;

		private string _Version = null;

		private KBEntryList _KBEntries = new KBEntryList();

		private List<KBTemplateDocument> _TemplateDocuments = null;

		/// <summary>
		///       系统中所有的知识库节点列表
		///       </summary>
		[NonSerialized]
		private KBEntryList _AllKBEntries = null;

		/// <summary>
		///       参与搜索的知识库节点列表集合
		///       </summary>
		[NonSerialized]
		private KBEntryList _KBEntriesForSearch = null;

		private static ImageList _StdImageList = null;

		private static Dictionary<string, ListItemCollection> _LoadedListItems = new Dictionary<string, ListItemCollection>();

		/// <summary>
		///       使用第二语言
		///       </summary>
		[Browsable(false)]
		
		[XmlIgnore]
		public bool UseLanguage2
		{
			get
			{
				return _UseLanguage2;
			}
			set
			{
				_UseLanguage2 = value;
			}
		}

		/// <summary>
		///       知识库的标题
		///       </summary>
		[DefaultValue(null)]
		
		public string Title
		{
			get
			{
				return _Title;
			}
			set
			{
				_Title = value;
			}
		}

		/// <summary>
		///       知识库中加载模板使用的文件系统名称
		///       </summary>
		[DefaultValue("template")]
		
		public string TemplateFileSystemName
		{
			get
			{
				return _TemplateFileSystemName;
			}
			set
			{
				_TemplateFileSystemName = value;
			}
		}

		/// <summary>
		///       加载模板使用的虚拟文件系统
		///       </summary>
		[DefaultValue(null)]
		[XmlIgnore]
		[Obsolete("不推荐使用")]
		[Browsable(false)]
		public IFileSystem TemplateFileSystem
		{
			get
			{
				return _TemplateFileSystem;
			}
			set
			{
				_TemplateFileSystem = value;
			}
		}

		/// <summary>
		///       动态下载数据使用的基础路径
		///       </summary>
		
		[Browsable(false)]
		public string BaseURL
		{
			get
			{
				return _BaseURL;
			}
			set
			{
				_BaseURL = value;
			}
		}

		/// <summary>
		///       运行时的基础路径
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public string RuntimeBaseURL
		{
			get
			{
				if (string.IsNullOrEmpty(_BaseURL))
				{
					return _RuntimeBaseURL;
				}
				return _BaseURL;
			}
			set
			{
				_RuntimeBaseURL = value;
			}
		}

		/// <summary>
		///       列表项目来源格式化字符串
		///       </summary>
		[DefaultValue(null)]
		
		public string ListItemsSourceFormatString
		{
			get
			{
				return _ListItemsSourceFormatString;
			}
			set
			{
				_ListItemsSourceFormatString = value;
			}
		}

		/// <summary>
		///       模板来源格式化字符串
		///       </summary>
		
		[DefaultValue(null)]
		public string TemplateSourceFormatString
		{
			get
			{
				return _TemplateSourceFormatString;
			}
			set
			{
				_TemplateSourceFormatString = value;
			}
		}

		/// <summary>
		///       模板文件格式
		///       </summary>
		[DefaultValue(null)]
		public string TemplateFileFormat
		{
			get
			{
				return _TemplateFileFormat;
			}
			set
			{
				_TemplateFileFormat = value;
			}
		}

		/// <summary>
		///       知识库版本号
		///       </summary>
		
		[XmlAttribute]
		[DefaultValue(null)]
		public string Version
		{
			get
			{
				return _Version;
			}
			set
			{
				_Version = value;
			}
		}

		/// <summary>
		///       知识库列表
		///       </summary>
		[DefaultValue(null)]
		
		[XmlArrayItem("Entry", typeof(KBEntry))]
		public virtual KBEntryList KBEntries
		{
			get
			{
				if (_KBEntries == null && DocumentBehaviorOptions.StaticAutoCreateInstanceInProperty)
				{
					_KBEntries = new KBEntryList();
				}
				return _KBEntries;
			}
			set
			{
				_KBEntries = value;
			}
		}

		/// <summary>
		///       模板数据，仅供设计器使用
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlArrayItem("Document", typeof(KBTemplateDocument))]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public List<KBTemplateDocument> TemplateDocuments
		{
			get
			{
				return _TemplateDocuments;
			}
			set
			{
				_TemplateDocuments = value;
			}
		}

		/// <summary>
		///       返回系统中所有的知识库节点列表
		///       </summary>
		[XmlIgnore]
		
		[Browsable(false)]
		public KBEntryList AllKBEntries
		{
			get
			{
				if (_AllKBEntries == null)
				{
					_AllKBEntries = new KBEntryList();
					if (KBEntries != null)
					{
						FillAllKBEntries(KBEntries, _AllKBEntries);
					}
				}
				return _AllKBEntries;
			}
		}

		/// <summary>
		///       标准的图标列表
		///       </summary>
		[XmlIgnore]
		public static ImageList StdImageList
		{
			get
			{
				if (_StdImageList == null)
				{
					_StdImageList = new ImageList();
					_StdImageList.Images.Add(WriterResourcesCore.KBListEntry);
					_StdImageList.Images.Add(WriterResourcesCore.KBTemplate);
					_StdImageList.Images.Add(WriterResourcesCore.KBBlankEntry);
					_StdImageList.Images.Add(WriterResourcesCore.KBListItem);
					_StdImageList.Images.Add(WriterResourcesCore.Bitmap_0);
				}
				return _StdImageList;
			}
		}

		/// <summary>
		///       清除被缓存的节点模板数据
		///       </summary>
		public void ClearBufferedTemplateContent()
		{
			foreach (KBEntry allKBEntry in AllKBEntries)
			{
				allKBEntry.EntryTemplateContent = null;
			}
		}

		/// <summary>
		///       合并基础路径URL
		///       </summary>
		/// <param name="url">URL</param>
		/// <returns>合并后的URL</returns>
		public string CombinRumtimeBaseURL(string string_0)
		{
			return GClass334.smethod_0(RuntimeBaseURL, string_0);
		}

		/// <summary>
		///       修正DOM状态
		///       </summary>
		public void FixDomState()
		{
			if (_KBEntries != null && _KBEntries.Count > 0)
			{
				foreach (KBEntry kBEntry in _KBEntries)
				{
					FixDomState(kBEntry);
				}
			}
		}

		private void FixDomState(KBEntry rootEntry)
		{
			if (rootEntry.SubEntries != null && rootEntry.SubEntries.Count > 0)
			{
				int num = 10;
				foreach (KBEntry subEntry in rootEntry.SubEntries)
				{
					subEntry.Parent = rootEntry;
					subEntry.ParentID = rootEntry.ID;
					subEntry.ListIndex = num;
					num += 10;
					FixDomState(subEntry);
				}
			}
			if (rootEntry.ListItems != null && rootEntry.ListItems.Count > 0)
			{
				int num = 10;
				foreach (ListItem listItem in rootEntry.ListItems)
				{
					listItem.EntryID = rootEntry.ID;
					listItem.ListIndex = num;
					num += 10;
				}
			}
		}

		private void FillAllKBEntries(KBEntryList rootList, KBEntryList result)
		{
			foreach (KBEntry root in rootList)
			{
				result.Add(root);
				if (root.SubEntries != null && root.SubEntries.Count > 0)
				{
					FillAllKBEntries(root.SubEntries, result);
				}
			}
		}

		/// <summary>
		///       更新AllKBEntries属性值
		///       </summary>
		
		public void UpdateAllKBEntries()
		{
			_AllKBEntries = null;
			_KBEntriesForSearch = null;
		}

		/// <summary>
		///       根据拼音码检索知识库
		///       </summary>
		/// <param name="spellCode">拼音码</param>
		/// <returns>检索得到的知识库节点列表</returns>
		
		public KBEntryList SearchKBEntries(string spellCode)
		{
			if (spellCode == null)
			{
				spellCode = "";
			}
			spellCode = spellCode.Trim();
			if (spellCode.Length == 0)
			{
				return KBEntries;
			}
			if (_KBEntriesForSearch == null)
			{
				_KBEntriesForSearch = new KBEntryList();
				foreach (KBEntry allKBEntry in AllKBEntries)
				{
					if (!string.IsNullOrEmpty(allKBEntry.Text) && (allKBEntry.SubEntries == null || allKBEntry.SubEntries.Count <= 0))
					{
						_KBEntriesForSearch.Add(allKBEntry);
					}
				}
				_KBEntriesForSearch.Sort(new KBTextComparer(bool_0: false));
			}
			KBEntryList kBEntryList = new KBEntryList();
			KBEntryList kBEntryList2 = new KBEntryList();
			KBEntryList kBEntryList3 = new KBEntryList();
			foreach (KBEntry item in _KBEntriesForSearch)
			{
				if (item.Text.StartsWith(spellCode))
				{
					kBEntryList.Add(item);
				}
				else if (item.RuntimeSpellCode.StartsWith(spellCode, StringComparison.CurrentCultureIgnoreCase))
				{
					kBEntryList2.Add(item);
				}
				else if (item.RuntimeSpellCode.IndexOf(spellCode, StringComparison.CurrentCultureIgnoreCase) > 0)
				{
					kBEntryList3.Add(item);
				}
				else if (!string.IsNullOrEmpty(item.SpellCode2))
				{
					if (item.SpellCode2.StartsWith(spellCode, StringComparison.CurrentCultureIgnoreCase))
					{
						kBEntryList.Add(item);
					}
					else if (item.SpellCode2.IndexOf(spellCode) > 0)
					{
						kBEntryList2.Add(item);
					}
				}
				else if (!string.IsNullOrEmpty(item.SpellCode3))
				{
					if (item.SpellCode3.StartsWith(spellCode, StringComparison.CurrentCultureIgnoreCase))
					{
						kBEntryList.Add(item);
					}
					else if (item.SpellCode3.IndexOf(spellCode, StringComparison.CurrentCultureIgnoreCase) > 0)
					{
						kBEntryList2.Add(item);
					}
				}
			}
			KBEntryList kBEntryList4 = new KBEntryList();
			kBEntryList4.AddRange(kBEntryList);
			kBEntryList4.AddRange(kBEntryList2);
			kBEntryList4.Sort(new KBTextComparer(bool_0: true));
			if (kBEntryList4.Count > 0 && kBEntryList4.Last != KBEntry.NullKBEntry && kBEntryList3.Count > 0)
			{
				kBEntryList4.Add(KBEntry.NullKBEntry);
			}
			kBEntryList4.AddRange(kBEntryList3);
			return kBEntryList4;
		}

		/// <summary>
		///       查找指定ID号的知识节点
		///       </summary>
		/// <param name="id">ID号</param>
		/// <returns>找到的知识节点对象</returns>
		
		public KBEntry SearchKBEntry(string string_0)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				return null;
			}
			if (KBEntries != null && KBEntries.Count > 0)
			{
				return InnserSearchKBEntry(KBEntries, string_0);
			}
			return null;
		}

		private KBEntry InnserSearchKBEntry(List<KBEntry> entries, string string_0)
		{
			foreach (KBEntry entry in entries)
			{
				if (entry.ID == string_0)
				{
					return entry;
				}
				if (entry.SubEntries != null && entry.SubEntries.Count > 0)
				{
					KBEntry kBEntry = InnserSearchKBEntry(entry.SubEntries, string_0);
					if (kBEntry != null)
					{
						return kBEntry;
					}
				}
			}
			return null;
		}

		/// <summary>
		///       从文件流中加载整个知识库
		///       </summary>
		/// <param name="stream">文件流对象</param>
		/// <returns>操作是否成功</returns>
		
		[ComVisible(false)]
		public virtual bool Load(Stream stream)
		{
			int num = 12;
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(KBLibrary));
			KBLibrary kblibrary_ = (KBLibrary)xmlSerializer.Deserialize(stream);
			CopyContent(kblibrary_);
			SortEntries(KBEntries);
			foreach (KBEntry allKBEntry in AllKBEntries)
			{
				allKBEntry.RecordState = DataRowState.Unchanged;
			}
			return true;
		}

		/// <summary>
		///       从URL地址中加载整个知识库
		///       </summary>
		/// <param name="url">文件URL地址</param>
		/// <returns>操作是否成功</returns>
		
		public virtual bool Load(string string_0)
		{
			int num = 8;
			if (string.IsNullOrEmpty(string_0))
			{
				throw new ArgumentNullException("url");
			}
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(KBLibrary));
			KBLibrary kblibrary_ = null;
			using (UrlStream stream = UrlStream.smethod_0(string_0))
			{
				kblibrary_ = (KBLibrary)xmlSerializer.Deserialize(stream);
			}
			CopyContent(kblibrary_);
			SortEntries(KBEntries);
			foreach (KBEntry allKBEntry in AllKBEntries)
			{
				allKBEntry.RecordState = DataRowState.Unchanged;
			}
			if (string.IsNullOrEmpty(BaseURL))
			{
				_RuntimeBaseURL = GClass334.smethod_1(string_0);
			}
			return true;
		}

		/// <summary>
		///       从文件流中加载整个知识库
		///       </summary>
		/// <param name="reader">文件流对象</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(false)]
		
		public virtual bool Load(TextReader reader)
		{
			int num = 13;
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(KBLibrary));
			KBLibrary kblibrary_ = (KBLibrary)xmlSerializer.Deserialize(reader);
			CopyContent(kblibrary_);
			SortEntries(KBEntries);
			foreach (KBEntry allKBEntry in AllKBEntries)
			{
				allKBEntry.RecordState = DataRowState.Unchanged;
			}
			return true;
		}

		private void SortEntries(KBEntryList entries)
		{
			if (entries != null && entries.Count > 1)
			{
				entries.SortItems();
				foreach (KBEntry entry in entries)
				{
					if (entry.SubEntries != null && entry.SubEntries.Count > 1)
					{
						entry.SubEntries.SortItems();
					}
				}
			}
		}

		private void CopyContent(KBLibrary kblibrary_0)
		{
			UpdateAllKBEntries();
			BaseURL = kblibrary_0.BaseURL;
			Version = kblibrary_0.Version;
			KBEntries = kblibrary_0.KBEntries;
			TemplateFileSystemName = kblibrary_0.TemplateFileSystemName;
			ListItemsSourceFormatString = kblibrary_0.ListItemsSourceFormatString;
			TemplateFileFormat = kblibrary_0.TemplateFileFormat;
			TemplateSourceFormatString = kblibrary_0.TemplateSourceFormatString;
			_TemplateDocuments = kblibrary_0._TemplateDocuments;
			if (KBEntries != null)
			{
				foreach (KBEntry kBEntry in KBEntries)
				{
					UpdateDomState(kBEntry);
				}
			}
		}

		private void UpdateDomState(KBEntry root)
		{
			if (string.IsNullOrEmpty(root.ID))
			{
				root.ID = root.Value;
			}
			if (root.SubEntries != null && root.SubEntries.Count == 0)
			{
				root.SubEntries = null;
			}
			if (root.ListItems != null && root.ListItems.Count == 0)
			{
				root.ListItems = null;
			}
			if (root.SubEntries != null)
			{
				foreach (KBEntry subEntry in root.SubEntries)
				{
					if (string.IsNullOrEmpty(subEntry.ID))
					{
						subEntry.ID = subEntry.Value;
					}
					subEntry.Parent = root;
					if (subEntry.SubEntries != null && subEntry.SubEntries.Count == 0)
					{
						subEntry.SubEntries = null;
					}
					else
					{
						UpdateDomState(subEntry);
					}
					if (subEntry.ListItems != null && subEntry.ListItems.Count == 0)
					{
						subEntry.ListItems = null;
					}
				}
			}
		}

		/// <summary>
		///       保存对象到文件流中
		///       </summary>
		/// <param name="stream">文件流</param>
		/// <returns>操作是否成功</returns>
		
		[ComVisible(false)]
		public virtual bool Save(Stream stream)
		{
			int num = 17;
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(KBLibrary));
			xmlSerializer.Serialize(stream, this);
			return true;
		}

		/// <summary>
		///       保存对象到文件中
		///       </summary>
		/// <param name="fileName">文件名</param>
		/// <returns>操作是否成功</returns>
		
		public virtual bool Save(string fileName)
		{
			int num = 6;
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException("fileName");
			}
			using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
			{
				return Save(stream);
			}
		}

		/// <summary>
		///       保存对象到文件流中
		///       </summary>
		/// <param name="writer">文件流</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(false)]
		
		public virtual bool Save(TextWriter writer)
		{
			int num = 11;
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(KBLibrary));
			xmlSerializer.Serialize(writer, this);
			return true;
		}

		/// <summary>
		///       将知识库信息填充到树状列表中
		///       </summary>
		/// <returns>树状列表控件</returns>
		
		public bool Fill(TreeView treeView_0)
		{
			int num = 15;
			if (treeView_0 == null)
			{
				throw new ArgumentNullException("tvw");
			}
			return Fill(treeView_0, forDesigner: false);
		}

		/// <summary>
		///       将知识库信息填充到树状列表中
		///       </summary>
		/// <returns>树状列表控件</returns>
		
		public bool Fill(TreeView treeView_0, bool forDesigner)
		{
			int num = 7;
			if (treeView_0 == null)
			{
				throw new ArgumentNullException("tvw");
			}
			treeView_0.BeginUpdate();
			treeView_0.Nodes.Clear();
			treeView_0.ImageList = StdImageList;
			if (KBEntries != null)
			{
				FillNodes(KBEntries, treeView_0.Nodes, forDesigner);
			}
			treeView_0.EndUpdate();
			return true;
		}

		/// <summary>
		///       更新树状列表节点
		///       </summary>
		/// <param name="node">节点</param>
		/// <param name="entry">知识库节点</param>
		/// <param name="forDesigner">为设计器执行操作</param>
		public void UpdateTreeNode(TreeNode node, KBEntry entry, bool forDesigner)
		{
			if (UseLanguage2)
			{
				node.Text = entry.Text2;
			}
			else
			{
				node.Text = entry.Text;
			}
			node.Name = entry.ID;
			node.Tag = entry;
			node.ImageIndex = entry.StdImageIndex;
			node.SelectedImageIndex = node.ImageIndex;
			if (!forDesigner)
			{
				return;
			}
			if (!entry.Visible)
			{
				node.ForeColor = Color.DarkGray;
				return;
			}
			switch (entry.RecordState)
			{
			default:
				node.ForeColor = Color.Black;
				break;
			case DataRowState.Modified:
				node.ForeColor = Color.Blue;
				break;
			case DataRowState.Deleted:
				node.ForeColor = Color.Red;
				break;
			case DataRowState.Added:
				node.ForeColor = Color.Blue;
				break;
			}
		}

		private void FillNodes(KBEntryList entries, TreeNodeCollection nodes, bool forDesigner)
		{
			foreach (KBEntry entry in entries)
			{
				TreeNode treeNode = new TreeNode();
				UpdateTreeNode(treeNode, entry, forDesigner);
				if (entry.SubEntries != null && entry.SubEntries.Count > 0 && entry.Style != KBEntryStyle.Template)
				{
					FillNodes(entry.SubEntries, treeNode.Nodes, forDesigner);
				}
				treeNode.SelectedImageIndex = treeNode.ImageIndex;
				nodes.Add(treeNode);
			}
		}

		/// <summary>
		///       对知识节点进行过滤
		///       </summary>
		/// <param name="host">宿主对象</param>
		/// <returns>操作过滤掉的知识节点个数</returns>
		public int Filter(WriterAppHost host)
		{
			int result = 0;
			CurrentUserInfo currentUserInfo = (CurrentUserInfo)host.Services.GetService(typeof(CurrentUserInfo));
			CurrentDepartmentInfo currentDepartmentInfo = (CurrentDepartmentInfo)host.Services.GetService(typeof(CurrentDepartmentInfo));
			if ((currentUserInfo != null || currentDepartmentInfo != null) && KBEntries != null)
			{
				result = FilterEntries(KBEntries, currentUserInfo, currentDepartmentInfo);
			}
			return result;
		}

		/// <summary>
		///       对知识库节点进行过滤
		///       </summary>
		/// <param name="entries">知识节点对象</param>
		/// <param name="usr">当前用户信息</param>
		/// <param name="dep">当前部门信息</param>
		/// <returns>过滤掉的节点个数</returns>
		private int FilterEntries(KBEntryList entries, CurrentUserInfo currentUserInfo_0, CurrentDepartmentInfo currentDepartmentInfo_0)
		{
			int num = 0;
			for (int num2 = entries.Count - 1; num2 >= 0; num2--)
			{
				KBEntry kBEntry = entries[num2];
				if (kBEntry.OwnerLevel == EntryOwnerLevel.User)
				{
					if (currentUserInfo_0 != null && kBEntry.OwnerID != currentUserInfo_0.ID)
					{
						entries.RemoveAt(num2);
						num++;
						continue;
					}
				}
				else if (kBEntry.OwnerLevel == EntryOwnerLevel.Department && currentDepartmentInfo_0 != null && kBEntry.OwnerID != currentDepartmentInfo_0.ID)
				{
					entries.RemoveAt(num2);
					num++;
					continue;
				}
				if (kBEntry.SubEntries != null && kBEntry.SubEntries.Count > 0)
				{
					num += FilterEntries(kBEntry.SubEntries, currentUserInfo_0, currentDepartmentInfo_0);
				}
			}
			return num;
		}

		internal ListItemCollection GetListItemsByListItemsSource(WriterAppHost host, WriterControl writerControl_0, KBEntry entry)
		{
			int num = 9;
			if (entry == null)
			{
				throw new ArgumentNullException("entry");
			}
			string listItemsSource = entry.ListItemsSource;
			if (string.IsNullOrEmpty(listItemsSource))
			{
				return null;
			}
			string string_ = listItemsSource;
			if (!string.IsNullOrEmpty(ListItemsSourceFormatString))
			{
				string_ = string.Format(ListItemsSourceFormatString, listItemsSource);
			}
			string_ = GClass334.smethod_0(RuntimeBaseURL, string_);
			if (string.IsNullOrEmpty(string_))
			{
				return null;
			}
			_ = host.Debuger;
			if (_LoadedListItems.ContainsKey(string_))
			{
				if (host.Debuger != null)
				{
					host.Debuger.WriteLine(string.Format(WriterStringsCore.LoadListItemsFromBuffer_Name_URL, entry.ListItemsSource, string_));
				}
				return _LoadedListItems[string_].Clone();
			}
			XmlDocument xmlDocument = new XmlDocument();
			try
			{
				WriterReadFileContentEventArgs writerReadFileContentEventArgs = new WriterReadFileContentEventArgs(writerControl_0, writerControl_0?.Document, null, string_, null);
				writerReadFileContentEventArgs.AppHost = host;
				byte[] array = WriterControl.ReadFileContent(writerControl_0, writerReadFileContentEventArgs);
				if (array == null || array.Length == 0)
				{
					return null;
				}
				MemoryStream memoryStream = new MemoryStream(array);
				xmlDocument.Load(memoryStream);
				memoryStream.Close();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());
				return null;
			}
			ListItemCollection listItemCollection = new ListItemCollection();
			foreach (XmlNode childNode in xmlDocument.DocumentElement.ChildNodes)
			{
				if (childNode.Name == "Item")
				{
					ListItem listItem = new ListItem();
					foreach (XmlNode childNode2 in childNode.ChildNodes)
					{
						if (childNode2.Name == "Text")
						{
							listItem.Text = childNode2.InnerText;
						}
						else if (childNode2.Name == "Value")
						{
							listItem.Value = childNode2.InnerText;
						}
						else if (childNode2.Name == "TextInList")
						{
							listItem.TextInList = childNode2.InnerText;
						}
					}
					listItemCollection.Add(listItem);
				}
			}
			_LoadedListItems[string_] = listItemCollection.Clone();
			return listItemCollection;
		}
	}
}
