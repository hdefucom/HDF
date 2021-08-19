using DCSoft.Design;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass135
	{
		private bool bool_0;

		private bool bool_1;

		private Dictionary<string, Image> dictionary_0;

		private bool bool_2;

		private GEnum19 genum19_0;

		private GEnum19 genum19_1;

		private GEnum19 genum19_2;

		private GEnum19 genum19_3;

		private bool bool_3;

		private TypeVisiblityFlags typeVisiblityFlags_0;

		public GDelegate8 gdelegate8_0;

		public GDelegate8 gdelegate8_1;

		private static object object_0 = new object();

		private List<string> list_0;

		private List<string> list_1;

		private bool bool_4;

		private Dictionary<Image, int> dictionary_1;

		private TreeView treeView_0;

		private ImageList imageList_0;

		public static string smethod_0(Type type_0)
		{
			return DesignUtils.GetTypeID(type_0);
		}

		public GClass135(TreeView treeView_1)
		{
			int num = 2;
			bool_0 = true;
			bool_1 = false;
			dictionary_0 = new Dictionary<string, Image>();
			bool_2 = false;
			genum19_0 = GEnum19.const_1;
			genum19_1 = GEnum19.const_1;
			genum19_2 = GEnum19.const_1;
			genum19_3 = GEnum19.const_1;
			bool_3 = false;
			typeVisiblityFlags_0 = TypeVisiblityFlags.AllType;
			gdelegate8_0 = null;
			gdelegate8_1 = null;
			list_0 = new List<string>();
			list_1 = new List<string>();
			bool_4 = true;
			dictionary_1 = new Dictionary<Image, int>();
			treeView_0 = null;
			imageList_0 = null;
			
			if (treeView_1 == null)
			{
				throw new ArgumentNullException("tvw");
			}
			treeView_0 = treeView_1;
		}

		private void method_0()
		{
			int num = 11;
			if (imageList_0 == null)
			{
				imageList_0 = smethod_1();
				treeView_0.ImageList = imageList_0;
				treeView_0.AfterExpand += treeView_0_AfterExpand;
				treeView_0.AfterCheck += treeView_0_AfterCheck;
				dictionary_0["System.Windows.Forms.Control,System.Windows.Forms"] = DesignResources.IconControl;
				dictionary_0["System.Windows.Forms.Form,System.Windows.Forms"] = DesignResources.IconForm;
				dictionary_0["System.Windows.UIElement,PresentationCore"] = DesignResources.IconWPFElement;
			}
		}

		public bool method_1()
		{
			return bool_0;
		}

		public void method_2(bool bool_5)
		{
			bool_0 = bool_5;
		}

		public bool method_3()
		{
			return bool_1;
		}

		public void method_4(bool bool_5)
		{
			bool_1 = bool_5;
		}

		private void treeView_0_AfterCheck(object sender, TreeViewEventArgs e)
		{
			if (!bool_1)
			{
				bool_1 = true;
				try
				{
					bool @checked = e.Node.Checked;
					method_5(e.Node, @checked);
					for (TreeNode parent = e.Node.Parent; parent != null; parent = parent.Parent)
					{
						if (parent.Checked != @checked)
						{
							bool flag = true;
							foreach (TreeNode node in parent.Nodes)
							{
								if (node.Checked != @checked)
								{
									parent.Checked = true;
									flag = false;
									break;
								}
							}
							if (flag)
							{
								parent.Checked = @checked;
							}
						}
					}
				}
				finally
				{
					bool_1 = false;
				}
			}
		}

		private void method_5(TreeNode treeNode_0, bool bool_5)
		{
			foreach (TreeNode node in treeNode_0.Nodes)
			{
				if (node.Checked != bool_5)
				{
					node.Checked = bool_5;
				}
				if (node.Nodes.Count > 0)
				{
					method_5(node, bool_5);
				}
			}
		}

		public Dictionary<string, Image> method_6()
		{
			return dictionary_0;
		}

		public bool method_7()
		{
			return bool_2;
		}

		public void method_8(bool bool_5)
		{
			bool_2 = bool_5;
		}

		public GEnum19 method_9()
		{
			return genum19_0;
		}

		public void method_10(GEnum19 genum19_4)
		{
			genum19_0 = genum19_4;
		}

		public GEnum19 method_11()
		{
			return genum19_1;
		}

		public void method_12(GEnum19 genum19_4)
		{
			genum19_1 = genum19_4;
		}

		public GEnum19 method_13()
		{
			return genum19_2;
		}

		public void method_14(GEnum19 genum19_4)
		{
			genum19_2 = genum19_4;
		}

		public GEnum19 method_15()
		{
			return genum19_3;
		}

		public void method_16(GEnum19 genum19_4)
		{
			genum19_3 = genum19_4;
		}

		public bool method_17()
		{
			return bool_3;
		}

		public void method_18(bool bool_5)
		{
			bool_3 = bool_5;
		}

		public TypeVisiblityFlags method_19()
		{
			return typeVisiblityFlags_0;
		}

		public void method_20(TypeVisiblityFlags typeVisiblityFlags_1)
		{
			typeVisiblityFlags_0 = typeVisiblityFlags_1;
		}

		public TreeNode method_21(TreeNodeCollection treeNodeCollection_0, string[] string_0)
		{
			int num = 6;
			if (treeNodeCollection_0 == null)
			{
				throw new ArgumentNullException("rootNodes");
			}
			if (string_0 == null)
			{
				throw new ArgumentNullException("pathItems");
			}
			TreeNodeCollection treeNodeCollection = treeNodeCollection_0;
			TreeNode treeNode = null;
			foreach (string b in string_0)
			{
				foreach (TreeNode item in treeNodeCollection)
				{
					if (item.Text == b)
					{
						treeNode = item;
						item.Expand();
						treeNodeCollection = item.Nodes;
					}
				}
			}
			if (treeNode != null)
			{
				treeNode.TreeView.SelectedNode = treeNode;
			}
			return treeNode;
		}

		public bool method_22(TreeNode treeNode_0)
		{
			int num = 13;
			if (treeNode_0 == null)
			{
				throw new ArgumentNullException("node");
			}
			return treeNode_0.FirstNode != null && treeNode_0.FirstNode.Tag == object_0;
		}

		private void method_23(TreeNode treeNode_0)
		{
			int num = 17;
			treeNode_0.Nodes.Clear();
			if (treeNode_0.Tag is DCAssemblyInfo)
			{
				DCAssemblyInfo dCAssemblyInfo = (DCAssemblyInfo)treeNode_0.Tag;
				foreach (DCTypeInfo type in dCAssemblyInfo.Types)
				{
					if (vmethod_0(type))
					{
						GEventArgs5 gEventArgs = new GEventArgs5(type);
						if (gdelegate8_0 != null)
						{
							gdelegate8_0(this, gEventArgs);
							if (!gEventArgs.method_4())
							{
								continue;
							}
						}
						string text = type.Namespace;
						if (string.IsNullOrEmpty(text))
						{
							text = "-";
						}
						TreeNode treeNode = treeNode_0.LastNode;
						if (treeNode != null && treeNode.Text != text)
						{
							treeNode = null;
							foreach (TreeNode node in treeNode_0.Nodes)
							{
								if (node.Text == text)
								{
									treeNode = node;
									break;
								}
							}
						}
						if (treeNode == null)
						{
							treeNode = new TreeNode(text);
							treeNode.ImageIndex = 1;
							treeNode.SelectedImageIndex = 1;
							treeNode_0.Nodes.Add(treeNode);
						}
						TreeNode treeNode3 = new TreeNode(type.Name);
						method_33(treeNode3, type);
						treeNode.Nodes.Add(treeNode3);
						gEventArgs.method_14(treeNode3);
					}
				}
			}
			else
			{
				if (!(treeNode_0.Tag is DCTypeInfo) && (!(treeNode_0.Tag is DCPropertyInfo) || !method_17()))
				{
					return;
				}
				DCTypeInfo current = null;
				if (treeNode_0.Tag is DCTypeInfo)
				{
					current = (DCTypeInfo)treeNode_0.Tag;
				}
				else
				{
					DCPropertyInfo dCPropertyInfo = (DCPropertyInfo)treeNode_0.Tag;
					current = dCPropertyInfo.PropertyType;
					if (current != null && current.CollectionItemType != null)
					{
						current = current.CollectionItemType;
					}
				}
				treeNode_0.Nodes.Clear();
				if (current != null)
				{
					foreach (DCMemberInfo member in current.Members)
					{
						GEventArgs5 gEventArgs2 = new GEventArgs5(current, member);
						if (gdelegate8_1 != null)
						{
							gdelegate8_1(this, gEventArgs2);
							if (!gEventArgs2.method_4())
							{
								continue;
							}
						}
						if (member is DCFieldInfo && method_15() != 0)
						{
							DCFieldInfo dCFieldInfo = (DCFieldInfo)member;
							string text2 = null;
							switch (method_15())
							{
							case GEnum19.const_1:
								text2 = dCFieldInfo.Name;
								break;
							case GEnum19.const_2:
								text2 = ((!current.IsEnum) ? dCFieldInfo.ToLongString() : (dCFieldInfo.Name + "=" + dCFieldInfo.EnumItemValue));
								break;
							case GEnum19.const_3:
								if (current.IsEnum)
								{
									text2 = dCFieldInfo.Name + "=" + dCFieldInfo.EnumItemValue;
								}
								else
								{
									text2 = dCFieldInfo.ToLongString();
									if (!dCFieldInfo.IsNoSerialized)
									{
										text2 = "[NoSerialized]" + text2;
									}
								}
								break;
							}
							TreeNode treeNode4 = new TreeNode(text2);
							treeNode4.Tag = dCFieldInfo;
							if (dCFieldInfo.IsLiteral)
							{
								treeNode4.ImageIndex = 11;
							}
							else
							{
								treeNode4.ImageIndex = 10;
							}
							treeNode4.SelectedImageIndex = treeNode4.ImageIndex;
							treeNode_0.Nodes.Add(treeNode4);
							gEventArgs2.method_14(treeNode4);
						}
						else if (member is DCPropertyInfo && method_9() != 0)
						{
							DCPropertyInfo dCPropertyInfo2 = (DCPropertyInfo)member;
							string text2 = null;
							switch (method_9())
							{
							case GEnum19.const_1:
								text2 = dCPropertyInfo2.Name;
								break;
							case GEnum19.const_2:
								text2 = dCPropertyInfo2.ToLongString(includeParameter: false, includeParameterName: false);
								break;
							case GEnum19.const_3:
								text2 = dCPropertyInfo2.ToLongString(includeParameter: true, includeParameterName: true);
								break;
							}
							TreeNode treeNode4 = new TreeNode(text2);
							treeNode4.Tag = dCPropertyInfo2;
							treeNode4.ImageIndex = 8;
							treeNode4.SelectedImageIndex = 8;
							gEventArgs2.method_14(treeNode4);
							treeNode_0.Nodes.Add(treeNode4);
							if (method_17() && dCPropertyInfo2.CanRead && !dCPropertyInfo2.HasIndexParameter && dCPropertyInfo2.PropertyType != null)
							{
								TreeNode treeNode5 = new TreeNode(DesignStrings.Loading);
								treeNode5.Tag = object_0;
								treeNode4.Nodes.Add(treeNode5);
							}
						}
						else if (member is DCMethodInfo && method_11() != 0)
						{
							DCMethodInfo dCMethodInfo = (DCMethodInfo)member;
							string text2 = null;
							switch (method_11())
							{
							case GEnum19.const_1:
								text2 = dCMethodInfo.Name;
								break;
							case GEnum19.const_2:
								text2 = dCMethodInfo.ToLongString(includeParameterType: false, includeParamterName: false);
								break;
							case GEnum19.const_3:
								text2 = dCMethodInfo.ToLongString(includeParameterType: true, includeParamterName: true);
								break;
							}
							TreeNode treeNode4 = new TreeNode(text2);
							treeNode4.Tag = member;
							treeNode4.ImageIndex = 7;
							treeNode4.SelectedImageIndex = 7;
							gEventArgs2.method_14(treeNode4);
							treeNode_0.Nodes.Add(treeNode4);
						}
						else if (member is DCEventInfo && method_13() != 0)
						{
							DCEventInfo dCEventInfo = (DCEventInfo)member;
							string text2 = dCEventInfo.Name;
							switch (method_13())
							{
							case GEnum19.const_1:
								text2 = dCEventInfo.Name;
								break;
							case GEnum19.const_2:
								text2 = dCEventInfo.ToLongString();
								break;
							case GEnum19.const_3:
								text2 = dCEventInfo.ToLongString();
								break;
							}
							TreeNode treeNode4 = new TreeNode(member.Name);
							treeNode4.Tag = member;
							treeNode4.ImageIndex = 9;
							treeNode4.SelectedImageIndex = 9;
							gEventArgs2.method_14(treeNode4);
							treeNode_0.Nodes.Add(treeNode4);
						}
					}
				}
			}
		}

		private void treeView_0_AfterExpand(object sender, TreeViewEventArgs e)
		{
			if (method_28() && e.Node != null && e.Node.FirstNode != null && e.Node.FirstNode.Tag == object_0)
			{
				treeView_0.BeginUpdate();
				e.Node.Nodes.Clear();
				method_23(e.Node);
				treeView_0.EndUpdate();
			}
		}

		public List<string> method_24()
		{
			return list_0;
		}

		public void method_25(List<string> list_2)
		{
			list_0 = list_2;
		}

		public List<string> method_26()
		{
			return list_1;
		}

		public void method_27(List<string> list_2)
		{
			list_1 = list_2;
		}

		public virtual bool vmethod_0(DCTypeInfo dctypeInfo_0)
		{
			if (method_19() != TypeVisiblityFlags.AllType)
			{
				TypeVisiblityFlags typeVisiblityFlags = method_19();
				if (dctypeInfo_0.IsEnum)
				{
					if ((typeVisiblityFlags & TypeVisiblityFlags.EnumType) != TypeVisiblityFlags.EnumType)
					{
						return false;
					}
				}
				else if (dctypeInfo_0.IsInterface)
				{
					if ((typeVisiblityFlags & TypeVisiblityFlags.InterfaceType) != TypeVisiblityFlags.InterfaceType)
					{
						return false;
					}
				}
				else if (dctypeInfo_0.IsDelegate)
				{
					if ((typeVisiblityFlags & TypeVisiblityFlags.DelegateType) != TypeVisiblityFlags.DelegateType)
					{
						return false;
					}
				}
				else if (dctypeInfo_0.IsClass)
				{
					if ((typeVisiblityFlags & TypeVisiblityFlags.ClassType) != TypeVisiblityFlags.ClassType)
					{
						return false;
					}
				}
				else if (dctypeInfo_0.IsValueType && (typeVisiblityFlags & TypeVisiblityFlags.StructType) != TypeVisiblityFlags.StructType)
				{
					return false;
				}
			}
			if ((list_1 != null && list_1.Count > 0) || (list_0 != null && list_0.Count > 0))
			{
				DCTypeInfo dCTypeInfo = dctypeInfo_0;
				while (dCTypeInfo != null)
				{
					if (list_0 == null || !list_0.Contains(dCTypeInfo.ID))
					{
						if (list_1 == null || !list_1.Contains(dCTypeInfo.ID))
						{
							dCTypeInfo = dCTypeInfo.BaseType;
							continue;
						}
						return true;
					}
					return false;
				}
			}
			if (dctypeInfo_0.IsArray || !dctypeInfo_0.IsPublic)
			{
				return false;
			}
			return true;
		}

		public bool method_28()
		{
			return bool_4;
		}

		public void method_29(bool bool_5)
		{
			bool_4 = bool_5;
		}

		public void method_30(DCTypeDomDocument dctypeDomDocument_0)
		{
			int num = 6;
			if (dctypeDomDocument_0 == null)
			{
				throw new ArgumentNullException("document");
			}
			method_0();
			foreach (DCAssemblyInfo assembly in dctypeDomDocument_0.Assemblies)
			{
				TreeNode treeNode = new TreeNode(assembly.Name);
				method_32(treeNode, assembly);
				if (treeNode.Nodes.Count > 0)
				{
					treeView_0.Nodes.Add(treeNode);
				}
			}
		}

		public void method_31(DCAssemblyInfo dcassemblyInfo_0)
		{
			int num = 18;
			if (dcassemblyInfo_0 == null)
			{
				throw new ArgumentNullException("asm");
			}
			method_0();
			TreeNode treeNode = new TreeNode(dcassemblyInfo_0.Name);
			method_32(treeNode, dcassemblyInfo_0);
			treeView_0.Nodes.Add(treeNode);
			treeNode.Expand();
		}

		public void method_32(TreeNode treeNode_0, DCAssemblyInfo dcassemblyInfo_0)
		{
			int num = 6;
			if (treeNode_0 == null)
			{
				throw new ArgumentNullException("node");
			}
			if (dcassemblyInfo_0 == null)
			{
				throw new ArgumentNullException("asmInfo");
			}
			method_0();
			treeNode_0.Text = dcassemblyInfo_0.Name;
			treeNode_0.ImageIndex = 0;
			treeNode_0.SelectedImageIndex = 0;
			treeNode_0.Tag = dcassemblyInfo_0;
			treeNode_0.Nodes.Clear();
			if (dcassemblyInfo_0.Types != null && dcassemblyInfo_0.Types.Count > 0)
			{
				if (method_28())
				{
					TreeNode treeNode = new TreeNode(DesignStrings.Loading);
					treeNode.Tag = object_0;
					treeNode_0.Nodes.Add(treeNode);
				}
				else
				{
					method_23(treeNode_0);
				}
			}
		}

		public void method_33(TreeNode treeNode_0, DCTypeInfo dctypeInfo_0)
		{
			int num = 17;
			if (treeNode_0 == null)
			{
				throw new ArgumentNullException("node");
			}
			if (dctypeInfo_0 == null)
			{
				throw new ArgumentNullException("typeInfo");
			}
			method_0();
			treeNode_0.Text = dctypeInfo_0.Name;
			Image image = null;
			if (method_7())
			{
				if (dctypeInfo_0.Image != null)
				{
					image = dctypeInfo_0.Image;
				}
				else if (dictionary_0.Count > 0)
				{
					DCTypeInfo dCTypeInfo = dctypeInfo_0;
					while (dCTypeInfo != null)
					{
						string iD = dCTypeInfo.ID;
						if (!dictionary_0.ContainsKey(iD))
						{
							dCTypeInfo = dCTypeInfo.BaseType;
							continue;
						}
						image = dictionary_0[iD];
						break;
					}
				}
			}
			if (image != null)
			{
				if (!dictionary_1.ContainsKey(image))
				{
					imageList_0.Images.Add(image);
					dictionary_1[image] = imageList_0.Images.Count - 1;
				}
				treeNode_0.ImageIndex = dictionary_1[image];
			}
			else if (dctypeInfo_0.IsEnum)
			{
				treeNode_0.ImageIndex = 5;
			}
			else if (dctypeInfo_0.IsInterface)
			{
				treeNode_0.ImageIndex = 4;
			}
			else if (dctypeInfo_0.IsDelegate)
			{
				treeNode_0.ImageIndex = 6;
			}
			else if (dctypeInfo_0.IsValueType)
			{
				treeNode_0.ImageIndex = 3;
			}
			else
			{
				treeNode_0.ImageIndex = 2;
			}
			treeNode_0.SelectedImageIndex = treeNode_0.ImageIndex;
			treeNode_0.Tag = dctypeInfo_0;
			if (method_1() && dctypeInfo_0.Members != null && dctypeInfo_0.Members.Count > 0)
			{
				if (method_28())
				{
					TreeNode treeNode = new TreeNode(DesignStrings.Loading);
					treeNode.Tag = object_0;
					treeNode_0.Nodes.Add(treeNode);
				}
				else
				{
					method_23(treeNode_0);
				}
			}
		}

		public static ImageList smethod_1()
		{
			ImageList imageList = new ImageList();
			imageList.Images.Add(DesignResources.Bitmap_0);
			imageList.Images.Add(DesignResources._namespace);
			imageList.Images.Add(DesignResources.classpublic);
			imageList.Images.Add(DesignResources.structpublic);
			imageList.Images.Add(DesignResources.interfacepublic);
			imageList.Images.Add(DesignResources.enumpublic);
			imageList.Images.Add(DesignResources.delegatepublic);
			imageList.Images.Add(DesignResources.methodpublic);
			imageList.Images.Add(DesignResources.propertypublic);
			imageList.Images.Add(DesignResources.eventpublic);
			imageList.Images.Add(DesignResources.fieldpublic);
			imageList.Images.Add(DesignResources.constpublic);
			imageList.TransparentColor = Color.Red;
			return imageList;
		}
	}
}
