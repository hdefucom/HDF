using DCSoft.Common;
using DCSoft.Design;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       组件类型控制器
	///       </summary>
	[ComVisible(false)]
	
	public class ComponentTypeControler
	{
		private static Dictionary<string, ComponentTypeInfo[]> _buffer = null;

		private ComponentTypeBrowseTypes _BrowseType = ComponentTypeBrowseTypes.ForControlHost;

		/// <summary>
		///       浏览操作类型
		///       </summary>
		public ComponentTypeBrowseTypes BrowseType
		{
			get
			{
				return _BrowseType;
			}
			set
			{
				_BrowseType = value;
			}
		}

		/// <summary>
		///       刷新缓存区
		///       </summary>
		public static void RefreshBuffer()
		{
			_buffer = null;
		}

		private static void CheckBuffer()
		{
			if (_buffer == null)
			{
				_buffer = new Dictionary<string, ComponentTypeInfo[]>();
				ComponentTypeInfoLoader componentTypeInfoLoader = new ComponentTypeInfoLoader();
				componentTypeInfoLoader.SupportedBaseTypes = new Dictionary<Type, Image>();
				componentTypeInfoLoader.SupportedBaseTypes[typeof(Control)] = MakTransparent(WriterResourcesCore.IconControl);
				componentTypeInfoLoader.SupportedBaseTypes[typeof(IDocumentImage)] = MakTransparent(WriterResourcesCore.IconDocumentImage);
				if (GClass129.smethod_1() != null)
				{
					componentTypeInfoLoader.SupportedBaseTypes[GClass129.smethod_1()] = MakTransparent(WriterResourcesCore.IconWPFElement);
				}
				componentTypeInfoLoader.ExcludeBaseTypes = new List<Type>();
				componentTypeInfoLoader.ExcludeBaseTypes.Add(typeof(Form));
				componentTypeInfoLoader.ExcludeBaseTypes.Add(typeof(WriterControl));
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				foreach (Assembly assembly in assemblies)
				{
					ComponentTypeInfo[] value = componentTypeInfoLoader.Load(assembly);
					_buffer[assembly.GetName().Name] = value;
				}
			}
		}

		/// <summary>
		///       加载远程程序集对象
		///       </summary>
		/// <param name="fileName">文件名</param>
		/// <returns>程序集名称</returns>
		public string LoadRemoteAssembly(string fileName)
		{
			ComponentTypeInfoLoader componentTypeInfoLoader = new ComponentTypeInfoLoader();
			ComponentTypeInfo[] value = componentTypeInfoLoader.Load(fileName);
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
			CheckBuffer();
			_buffer[fileNameWithoutExtension] = value;
			return fileNameWithoutExtension;
		}

		/// <summary>
		///       填充树状列表
		///       </summary>
		/// <param name="tvwControl">树状列表控件</param>
		/// <param name="selectedTypeName">选择的类型名称</param>
		public void FillTreeView(TreeView tvwControl, string selectedTypeName)
		{
			int num = 5;
			if (tvwControl == null)
			{
				throw new ArgumentNullException("tvwControl");
			}
			CheckBuffer();
			if (tvwControl.ImageList == null)
			{
				tvwControl.ImageList = new ImageList();
			}
			tvwControl.BeginUpdate();
			try
			{
				tvwControl.Nodes.Clear();
				tvwControl.ImageList.Images.Clear();
				tvwControl.ImageList.TransparentColor = Color.Red;
				tvwControl.ImageList.Images.Add(WriterResourcesCore.IconAssembly);
				foreach (string key in _buffer.Keys)
				{
					AddAssemblyNode(tvwControl, key, selectedTypeName);
				}
			}
			finally
			{
				tvwControl.EndUpdate();
			}
		}

		/// <summary>
		///       判断是否忽略类型
		///       </summary>
		/// <param name="info">
		/// </param>
		/// <returns>
		/// </returns>
		public virtual bool IgnoreType(ComponentTypeInfo info)
		{
			switch (BrowseType)
			{
			default:
				return false;
			}
		}

		/// <summary>
		///       添加程序集节点
		///       </summary>
		/// <param name="tvwControl">树状列表控件</param>
		/// <param name="asmName">程序集名称</param>
		/// <param name="selectedTypeName">选择的类型名称</param>
		/// <returns>添加的节点对象</returns>
		public TreeNode AddAssemblyNode(TreeView tvwControl, string asmName, string selectedTypeName)
		{
			CheckBuffer();
			if (!_buffer.ContainsKey(asmName))
			{
				return null;
			}
			ComponentTypeInfo[] array = _buffer[asmName];
			List<ComponentTypeInfo> list = new List<ComponentTypeInfo>();
			ComponentTypeInfo[] array2 = array;
			foreach (ComponentTypeInfo componentTypeInfo in array2)
			{
				if (!IgnoreType(componentTypeInfo))
				{
					list.Add(componentTypeInfo);
				}
			}
			if (list.Count == 0)
			{
				return null;
			}
			TreeNode treeNode = new TreeNode();
			treeNode.Text = asmName;
			treeNode.ImageIndex = 0;
			treeNode.SelectedImageIndex = 0;
			tvwControl.Nodes.Add(treeNode);
			ImageList imageList = tvwControl.ImageList;
			TreeNode treeNode2 = null;
			foreach (ComponentTypeInfo item in list)
			{
				TreeNode treeNode3 = new TreeNode(item.Name);
				treeNode3.Tag = item;
				if (imageList != null && item.ToolboxImage != null)
				{
					imageList.Images.Add(item.ToolboxImage);
					treeNode3.ImageIndex = imageList.Images.Count - 1;
					treeNode3.SelectedImageIndex = treeNode3.ImageIndex;
				}
				treeNode.Nodes.Add(treeNode3);
				if (!string.IsNullOrEmpty(selectedTypeName) && string.Compare(item.FullName, selectedTypeName, ignoreCase: true) == 0)
				{
					treeNode2 = treeNode3;
					break;
				}
			}
			if (treeNode2 != null)
			{
				tvwControl.SelectedNode = treeNode2;
			}
			return treeNode;
		}

		private static Image MakTransparent(Image image_0)
		{
			if (image_0 is Bitmap)
			{
				Bitmap bitmap = (Bitmap)image_0;
				bitmap = (Bitmap)bitmap.Clone();
				bitmap.MakeTransparent();
				return bitmap;
			}
			return image_0;
		}
	}
}
