#define DEBUG
using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Design
{
	                                                                    /// <summary>
	                                                                    ///       代码帮助树状列表管理器
	                                                                    ///       </summary>
	[ComVisible(false)]
	[DCInternal]
	public class CodeHelpeTreeViewMananger
	{
		private class Class34 : IComparer<MemberInfo>
		{
			public int Compare(MemberInfo memberInfo_0, MemberInfo memberInfo_1)
			{
				int num = method_0(memberInfo_0);
				int num2 = method_0(memberInfo_1);
				if (num == num2)
				{
					return string.Compare(memberInfo_0.Name, memberInfo_1.Name);
				}
				return num - num2;
			}

			private int method_0(MemberInfo memberInfo_0)
			{
				if (memberInfo_0 is ConstructorInfo)
				{
					return 0;
				}
				if (memberInfo_0 is MethodInfo)
				{
					return 1;
				}
				if (memberInfo_0 is PropertyInfo)
				{
					return 2;
				}
				if (memberInfo_0 is EventInfo)
				{
					return 3;
				}
				if (memberInfo_0 is FieldInfo)
				{
					return 4;
				}
				return 0;
			}
		}

		private class Class35 : IComparer<Type>
		{
			public int Compare(Type type_0, Type type_1)
			{
				return string.Compare(type_0.Name, type_1.Name);
			}
		}

		private class Class36 : IComparer<Type>
		{
			public int Compare(Type type_0, Type type_1)
			{
				return string.Compare(type_0.FullName, type_1.FullName);
			}
		}

		private Dictionary<Type, Type> dictionary_0 = new Dictionary<Type, Type>();

		private Dictionary<Type, Type> dictionary_1 = new Dictionary<Type, Type>();

		private List<Type> list_0 = new List<Type>();

		private List<Type> list_1 = new List<Type>();

		private List<Type> list_2 = new List<Type>();

		private List<Type> list_3 = new List<Type>();

		private List<Assembly> list_4 = new List<Assembly>();

		private bool bool_0 = false;

		private bool bool_1 = true;

		private ArrayList arrayList_0 = new ArrayList();

		private bool bool_2 = false;

		private bool bool_3 = false;

		private bool bool_4 = false;

		private Type type_0;

		private Type type_1 = null;

		private readonly object object_0 = new object();

		private StringFormat stringFormat_0 = null;

		private static ImageList imageList_0 = null;

		public static readonly int ImageIndex_Assembly = 0;

		public static readonly int ImageIndex_Namespace = 1;

		public static readonly int ImageIndex_Class = 2;

		public static readonly int ImageIndex_Struct = 3;

		public static readonly int ImageIndex_Interface = 4;

		public static readonly int ImageIndex_Enum = 5;

		public static readonly int ImageIndex_Delegate = 6;

		public static readonly int ImageIndex_Form = 7;

		public static readonly int ImageIndex_Control = 8;

		public static readonly int ImageIndex_WPFElement = 9;

		public static readonly int ImageIndex_Method = 10;

		public static readonly int ImageIndex_Property = 11;

		public static readonly int ImageIndex_Event = 12;

		public static readonly int ImageIndex_Field = 13;

		public static readonly int ImageIndex_EnumItem = 14;

		public static readonly int ImageIndex_Invalidate = 15;

		public static readonly int ImageIndex_GlobalObject = 16;

		                                                                    /// <summary>
		                                                                    ///       显示隐藏的类型
		                                                                    ///       </summary>
		public bool ShowHiddenType
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       显示委托类型
		                                                                    ///       </summary>
		public bool IncludeDelegateType
		{
			get
			{
				return bool_1;
			}
			set
			{
				bool_1 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       显示过期的对象
		                                                                    ///       </summary>
		public bool ShowObsoletedMember
		{
			get
			{
				return bool_2;
			}
			set
			{
				bool_2 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       显示系统级成员
		                                                                    ///       </summary>
		public bool ShowSystemMember
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
		                                                                    ///       只显示本类型声明的成员
		                                                                    ///       </summary>
		public bool ViewDeclaredOnly
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

		private StringFormat DrawNodeStringFormat
		{
			get
			{
				if (stringFormat_0 == null)
				{
					stringFormat_0 = new StringFormat(StringFormat.GenericTypographic);
					stringFormat_0.FormatFlags = StringFormatFlags.NoWrap;
					stringFormat_0.LineAlignment = StringAlignment.Center;
				}
				return stringFormat_0;
			}
		}

		private static ImageList StdImageList
		{
			get
			{
				if (imageList_0 == null)
				{
					imageList_0 = new ImageList();
					List<Bitmap> list = new List<Bitmap>();
					list.Add(CodeHelpViewerResource.Bitmap_0);
					list.Add(CodeHelpViewerResource._namespace);
					list.Add(CodeHelpViewerResource.classpublic);
					list.Add(CodeHelpViewerResource.structpublic);
					list.Add(CodeHelpViewerResource.interfacepublic);
					list.Add(CodeHelpViewerResource.enumpublic);
					list.Add(CodeHelpViewerResource.delegatepublic);
					list.Add(CodeHelpViewerResource.IconForm);
					list.Add(CodeHelpViewerResource.IconControl);
					list.Add(CodeHelpViewerResource.IconWPFElement);
					list.Add(CodeHelpViewerResource.methodpublic);
					list.Add(CodeHelpViewerResource.propertypublic);
					list.Add(CodeHelpViewerResource.eventpublic);
					list.Add(CodeHelpViewerResource.fieldpublic);
					list.Add(CodeHelpViewerResource.enumitem);
					list.Add(CodeHelpViewerResource.Flag_ValueInvalidate);
					list.Add(CodeHelpViewerResource.face);
					foreach (Bitmap item in list)
					{
						item.MakeTransparent(Color.Red);
						imageList_0.Images.Add(item);
					}
				}
				return imageList_0;
			}
		}

		public void AddGlobalObjects(string name, Type objType)
		{
			int num = 2;
			if (name == null || name.Length == 0)
			{
				throw new ArgumentNullException("name");
			}
			if (objType == null)
			{
				throw new ArgumentNullException("objType");
			}
			arrayList_0.Add(name);
			arrayList_0.Add(objType);
		}

		public void LoadData(List<Assembly> asms)
		{
			int num = 10;
			list_1 = new List<Type>();
			list_2 = new List<Type>();
			list_4 = new List<Assembly>();
			Type[] array;
			foreach (Assembly asm in asms)
			{
				if (!list_4.Contains(asm))
				{
					list_4.Add(asm);
					List<string> list = new List<string>();
					Attribute[] customAttributes = Attribute.GetCustomAttributes(asm, typeof(Attribute), inherit: true);
					foreach (Attribute attribute in customAttributes)
					{
						if (attribute.GetType().FullName == "DCSoft.Common.DocumentExcludeNamespaceAttribute")
						{
							list.Add(attribute.ToString());
						}
					}
					list.Add("DCSoftDotfuscate");
					list.Add("AxNsoOfficeLib");
					list.Add("NsoOfficeLib");
					array = method_1(asm.GetTypes());
					foreach (Type type in array)
					{
						if (type.IsPublic && Attribute.GetCustomAttribute(type, typeof(DCPublishAPIAttribute), inherit: true) != null)
						{
							list_1.Add(type);
						}
						if (Attribute.GetCustomAttribute(type, typeof(DCInternalAttribute), inherit: true) != null)
						{
							list_2.Add(type);
						}
					}
				}
			}
			if (arrayList_0 != null)
			{
				foreach (object item in arrayList_0)
				{
					if (item is Type)
					{
						Type type = (Type)item;
						if (!list_1.Contains(type))
						{
							list_1.Add(type);
						}
					}
				}
			}
			array = list_1.ToArray();
			foreach (Type type in array)
			{
				MemberInfo[] members = type.GetMembers(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
				MemberInfo[] array2 = members;
				foreach (MemberInfo memberInfo in array2)
				{
					if (!(memberInfo.Name == "TerminalText"))
					{
					}
					if (!method_6(memberInfo))
					{
						continue;
					}
					if (memberInfo is PropertyInfo)
					{
						PropertyInfo propertyInfo = (PropertyInfo)memberInfo;
						if (!list_1.Contains(propertyInfo.PropertyType))
						{
							list_1.Add(propertyInfo.PropertyType);
						}
					}
					else if (memberInfo is MethodInfo)
					{
						MethodInfo methodInfo = (MethodInfo)memberInfo;
						if (!list_1.Contains(methodInfo.ReturnType))
						{
							list_1.Add(methodInfo.ReturnType);
						}
					}
					else if (memberInfo is FieldInfo)
					{
						FieldInfo fieldInfo = (FieldInfo)memberInfo;
						if (!list_1.Contains(fieldInfo.FieldType))
						{
							list_1.Add(fieldInfo.FieldType);
						}
					}
					else if (memberInfo is EventInfo)
					{
						EventInfo eventInfo = (EventInfo)memberInfo;
						if (!list_1.Contains(eventInfo.EventHandlerType))
						{
							list_1.Add(eventInfo.EventHandlerType);
						}
					}
				}
			}
			for (int num2 = list_1.Count - 1; num2 >= 0; num2--)
			{
				if (Attribute.GetCustomAttribute(list_1[num2], typeof(DCPublishAPIAttribute), inherit: true) == null)
				{
					if (!ShowObsoletedMember && Attribute.GetCustomAttribute(list_1[num2], typeof(ObsoleteAttribute), inherit: true) != null)
					{
						list_2.Add(list_1[num2]);
						list_1.RemoveAt(num2);
					}
					else if (Attribute.GetCustomAttribute(list_1[num2], typeof(DCInternalAttribute), inherit: true) != null)
					{
						list_2.Add(list_1[num2]);
						list_1.RemoveAt(num2);
					}
				}
			}
			list_3 = new List<Type>();
			list_0.Clear();
			dictionary_0.Clear();
			dictionary_1.Clear();
			foreach (Type item2 in list_1)
			{
				if (((ComVisibleAttribute)Attribute.GetCustomAttribute(item2, typeof(ComVisibleAttribute), inherit: true))?.Value ?? true)
				{
					if (item2.IsEnum)
					{
						list_0.Add(item2);
					}
					else
					{
						Type type2 = null;
						ComDefaultInterfaceAttribute comDefaultInterfaceAttribute = (ComDefaultInterfaceAttribute)Attribute.GetCustomAttribute(item2, typeof(ComDefaultInterfaceAttribute), inherit: true);
						if (comDefaultInterfaceAttribute != null)
						{
							type2 = comDefaultInterfaceAttribute.Value;
							if (type2 != null)
							{
								dictionary_0[item2] = type2;
							}
						}
						Type type3 = null;
						ComSourceInterfacesAttribute comSourceInterfacesAttribute = (ComSourceInterfacesAttribute)Attribute.GetCustomAttribute(item2, typeof(ComSourceInterfacesAttribute), inherit: true);
						if (comSourceInterfacesAttribute != null && !string.IsNullOrEmpty(comSourceInterfacesAttribute.Value))
						{
							type3 = item2.Assembly.GetType(comSourceInterfacesAttribute.Value, throwOnError: false, ignoreCase: false);
							if (type3 != null)
							{
								dictionary_1[item2] = type3;
							}
						}
						ComClassAttribute comClassAttribute = (ComClassAttribute)Attribute.GetCustomAttribute(item2, typeof(ComClassAttribute), inherit: true);
						if (comClassAttribute != null)
						{
							if (!string.IsNullOrEmpty(comClassAttribute.EventID) && type3 == null)
							{
								type3 = Type.GetType(comClassAttribute.EventID, throwOnError: false, ignoreCase: false);
							}
							if (!string.IsNullOrEmpty(comClassAttribute.InterfaceID) && type2 == null)
							{
								type2 = Type.GetType(comClassAttribute.InterfaceID, throwOnError: false, ignoreCase: false);
							}
						}
						if (type2 != null || type3 != null)
						{
							if (type2 != null && !list_3.Contains(type2))
							{
								list_3.Add(type2);
							}
							if (type3 != null && !list_3.Contains(type3))
							{
								list_3.Add(type3);
							}
							list_0.Add(item2);
						}
					}
				}
			}
			list_0.Sort(new Class35());
		}

		                                                                    /// <summary>
		                                                                    ///       为COM接口刷新树状列表
		                                                                    ///       </summary>
		                                                                    /// <param name="tvw">
		                                                                    /// </param>
		public void RefreshComTreeView(TreeView treeView_0)
		{
			int num = 9;
			treeView_0.BeginUpdate();
			TreeViewDrawMode drawMode = treeView_0.DrawMode;
			treeView_0.DrawMode = TreeViewDrawMode.Normal;
			treeView_0.ImageList = StdImageList;
			treeView_0.Nodes.Clear();
			foreach (Assembly item in list_4)
			{
				TreeNode treeNode = new TreeNode(item.GetName().Name + ":" + item.Location);
				if (drawMode == TreeViewDrawMode.Normal)
				{
					treeNode.Text = item.GetName().Name;
				}
				treeNode.Tag = item;
				treeNode.ImageIndex = ImageIndex_Assembly;
				treeNode.SelectedImageIndex = ImageIndex_Assembly;
				treeView_0.Nodes.Add(treeNode);
				foreach (Type item2 in list_0)
				{
					if (item2.Assembly == item)
					{
						TreeNode treeNode2 = new TreeNode(item2.Name);
						treeNode2.Name = item2.Name;
						treeNode2.ImageIndex = method_10(item2);
						treeNode2.SelectedImageIndex = treeNode2.ImageIndex;
						treeNode2.Tag = item2;
						treeNode.Nodes.Add(treeNode2);
						if (Attribute.GetCustomAttribute(item2, typeof(GuidAttribute), inherit: false) == null)
						{
							treeNode2.ForeColor = Color.Red;
						}
						method_2(item2, treeNode2, bool_5: true);
					}
				}
				if (treeNode.Nodes.Count == 0)
				{
					treeNode.Remove();
				}
			}
			treeView_0.DrawMode = drawMode;
			if (treeView_0.Nodes.Count > 0)
			{
				treeView_0.Nodes[0].Expand();
			}
			treeView_0.EndUpdate();
		}

		                                                                    /// <summary>
		                                                                    ///       刷新标准树状列表
		                                                                    ///       </summary>
		                                                                    /// <param name="tvw">
		                                                                    /// </param>
		public void RefreshNormalTreeView(TreeView treeView_0)
		{
			int num = 3;
			treeView_0.BeginUpdate();
			TreeViewDrawMode drawMode = treeView_0.DrawMode;
			treeView_0.DrawMode = TreeViewDrawMode.Normal;
			treeView_0.ImageList = StdImageList;
			treeView_0.Nodes.Clear();
			if (arrayList_0 != null)
			{
				for (int i = 0; i < arrayList_0.Count; i += 2)
				{
					string text = (string)arrayList_0[i];
					Type tag = (Type)arrayList_0[i + 1];
					TreeNode treeNode = new TreeNode(text);
					treeNode.Name = text;
					treeNode.Tag = tag;
					treeNode.ImageIndex = ImageIndex_GlobalObject;
					treeNode.SelectedImageIndex = treeNode.ImageIndex;
					treeView_0.Nodes.Add(treeNode);
					method_8(treeNode);
				}
			}
			TreeNode treeNode2 = null;
			foreach (Assembly item in list_4)
			{
				TreeNode treeNode3 = new TreeNode(item.GetName().Name + ":" + item.Location);
				if (drawMode == TreeViewDrawMode.Normal)
				{
					treeNode3.Text = item.GetName().Name;
				}
				treeNode3.ImageIndex = ImageIndex_Assembly;
				treeNode3.SelectedImageIndex = ImageIndex_Assembly;
				treeNode3.Tag = item;
				treeView_0.Nodes.Add(treeNode3);
				if (treeNode2 == null)
				{
					treeNode2 = treeNode3;
				}
				Dictionary<string, List<Type>> dictionary = new Dictionary<string, List<Type>>();
				List<string> list = new List<string>();
				List<Type> list2 = null;
				if (ShowHiddenType)
				{
					list2 = new List<Type>();
					Type[] array = method_1(item.GetTypes());
					foreach (Type tag in array)
					{
						if (tag.IsPublic)
						{
							list2.Add(tag);
						}
					}
				}
				else
				{
					list2 = list_1;
				}
				foreach (Type item2 in list2)
				{
					if (item2.Assembly == item && (item2.IsPublic || item2.IsNestedPublic) && !item2.IsArray && !list_3.Contains(item2) && (IncludeDelegateType || !typeof(Delegate).IsAssignableFrom(item2)))
					{
						string @namespace = item2.Namespace;
						if (!string.IsNullOrEmpty(@namespace))
						{
							List<Type> list3 = null;
							if (dictionary.ContainsKey(@namespace))
							{
								list3 = dictionary[@namespace];
							}
							else
							{
								list3 = (dictionary[@namespace] = new List<Type>());
								list.Add(@namespace);
							}
							list3.Add(item2);
						}
					}
				}
				if (list.Count == 0)
				{
					treeNode3.Remove();
				}
				else
				{
					list.Sort();
					foreach (string item3 in list)
					{
						TreeNode treeNode4 = new TreeNode(item3);
						treeNode4.ImageIndex = ImageIndex_Namespace;
						treeNode4.SelectedImageIndex = ImageIndex_Namespace;
						treeNode3.Nodes.Add(treeNode4);
						List<Type> list3 = dictionary[item3];
						list3.Sort(new Class35());
						foreach (Type item4 in list3)
						{
							TreeNode treeNode5 = new TreeNode(item4.Name);
							treeNode5.Name = item4.Name;
							treeNode5.ImageIndex = method_10(item4);
							treeNode5.SelectedImageIndex = treeNode5.ImageIndex;
							treeNode5.Tag = item4;
							if (ShowHiddenType && !list_1.Contains(item4))
							{
								treeNode5.ForeColor = Color.DarkGray;
							}
							treeNode4.Nodes.Add(treeNode5);
							if (!item4.IsSubclassOf(typeof(Delegate)))
							{
								method_8(treeNode5);
							}
						}
					}
				}
			}
			treeView_0.DrawMode = drawMode;
			treeNode2?.Expand();
			treeView_0.EndUpdate();
		}

		private Type method_0(object object_1)
		{
			int num = 16;
			if (object_1 is Type)
			{
				Type type = (Type)object_1;
				Assembly assembly = type.Assembly;
				Type[] types = assembly.GetTypes();
				foreach (Type type2 in types)
				{
					if (type2.Name == "DCPublishAPIAttribute")
					{
						type_1 = type2;
						break;
					}
				}
				if (type_1 == null)
				{
					Debug.WriteLine("未能找到 DCPublishAPIAttribute 类型 ");
				}
				else
				{
					Debug.WriteLine("找到类型 " + type.FullName);
				}
			}
			return type_1;
		}

		private Type[] method_1(Type[] type_2)
		{
			if (type_2 == null)
			{
				return type_2;
			}
			if (type_2.Length == 0)
			{
				return type_2;
			}
			type_0 = method_0(type_2[0]);
			if (type_0 == null)
			{
				return type_2;
			}
			List<Type> list = new List<Type>();
			foreach (Type type in type_2)
			{
				Attribute customAttribute = Attribute.GetCustomAttribute(type, type_0, inherit: false);
				if (customAttribute != null)
				{
					list.Add(type);
				}
			}
			return list.ToArray();
		}

		                                                                    /// <summary>
		                                                                    ///       刷新命名空间树状列表
		                                                                    ///       </summary>
		                                                                    /// <param name="tvw">
		                                                                    /// </param>
		public void RefreshNamesSpacesTreeView(TreeView treeView_0)
		{
			treeView_0.BeginUpdate();
			TreeViewDrawMode drawMode = treeView_0.DrawMode;
			treeView_0.DrawMode = TreeViewDrawMode.Normal;
			treeView_0.ImageList = StdImageList;
			treeView_0.Nodes.Clear();
			if (arrayList_0 != null)
			{
				for (int i = 0; i < arrayList_0.Count; i += 2)
				{
					string text = (string)arrayList_0[i];
					Type tag = (Type)arrayList_0[i + 1];
					TreeNode treeNode = new TreeNode(text);
					treeNode.Name = text;
					treeNode.Tag = tag;
					treeNode.ImageIndex = ImageIndex_GlobalObject;
					treeNode.SelectedImageIndex = treeNode.ImageIndex;
					treeView_0.Nodes.Add(treeNode);
					method_8(treeNode);
				}
			}
			List<string> list = new List<string>();
			List<Type> list2 = new List<Type>();
			foreach (Assembly item in list_4)
			{
				Type[] array = method_1(item.GetTypes());
				foreach (Type type in array)
				{
					list2.Add(type);
					if (!list.Contains(type.Namespace))
					{
						list.Add(type.Namespace);
					}
				}
			}
			list.Sort();
			foreach (string item2 in list)
			{
				TreeNode treeNode2 = new TreeNode(item2);
				treeNode2.ImageIndex = ImageIndex_Namespace;
				treeNode2.SelectedImageIndex = ImageIndex_Namespace;
				treeView_0.Nodes.Add(treeNode2);
				list2.Sort(new Class35());
				foreach (Type item3 in list2)
				{
					if (item2.Equals(item3.Namespace))
					{
						TreeNode treeNode3 = new TreeNode(item3.Name);
						treeNode3.Name = item3.Name;
						treeNode3.ImageIndex = method_10(item3);
						treeNode3.SelectedImageIndex = treeNode3.ImageIndex;
						treeNode3.Tag = item3;
						if (ShowHiddenType && !list_1.Contains(item3))
						{
							treeNode3.ForeColor = Color.DarkGray;
						}
						treeNode2.Nodes.Add(treeNode3);
						if (!item3.IsSubclassOf(typeof(Delegate)))
						{
							method_8(treeNode3);
						}
					}
				}
			}
			treeView_0.DrawMode = drawMode;
			treeView_0.EndUpdate();
		}

		private void method_2(Type type_2, TreeNode treeNode_0, bool bool_5)
		{
			if (type_2.IsEnum)
			{
				method_3(type_2, treeNode_0);
				return;
			}
			List<MemberInfo> list;
			MemberInfo[] members;
			if (dictionary_0.ContainsKey(type_2))
			{
				Type type = dictionary_0[type_2];
				list = new List<MemberInfo>();
				members = type.GetMembers(BindingFlags.Instance | BindingFlags.Public);
				foreach (MemberInfo memberInfo in members)
				{
					MemberInfo[] member = type_2.GetMember(memberInfo.Name, BindingFlags.Instance | BindingFlags.Public);
					if (member != null && member.Length > 0)
					{
						list.Add(member[0]);
					}
				}
				list.Sort(new Class34());
				method_7(list, treeNode_0, bool_5, bool_6: true);
			}
			if (!dictionary_1.ContainsKey(type_2))
			{
				return;
			}
			Type type2 = dictionary_1[type_2];
			list = new List<MemberInfo>();
			BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public;
			if (ViewDeclaredOnly)
			{
				bindingFlags |= BindingFlags.DeclaredOnly;
			}
			members = type2.GetMembers(BindingFlags.Instance | BindingFlags.Public);
			foreach (MemberInfo memberInfo in members)
			{
				EventInfo @event = type_2.GetEvent(memberInfo.Name, BindingFlags.Instance | BindingFlags.Public);
				if (@event != null)
				{
					list.Add(@event);
				}
			}
			list.Sort(new Class34());
			method_7(list, treeNode_0, bool_5: false, bool_6: true);
		}

		private void method_3(Type type_2, TreeNode treeNode_0)
		{
			int num = 0;
			string[] names = Enum.GetNames(type_2);
			List<string> list = new List<string>(names);
			list.Sort();
			foreach (string item in list)
			{
				TreeNode treeNode = new TreeNode(item);
				treeNode.Text = treeNode.Text + " = " + Convert.ToString(Convert.ToInt32(Enum.Parse(type_2, item)));
				treeNode.Name = item;
				treeNode.ImageIndex = ImageIndex_EnumItem;
				treeNode.SelectedImageIndex = treeNode.ImageIndex;
				treeNode.Tag = type_2;
				treeNode_0.Nodes.Add(treeNode);
			}
		}

		private void method_4(Type type_2, TreeNode treeNode_0, bool bool_5)
		{
			int num = 8;
			if (type_2.IsEnum)
			{
				method_3(type_2, treeNode_0);
				return;
			}
			Type collectionItemType = DesignUtils.GetCollectionItemType(type_2, checkAddMethod: true);
			if (collectionItemType != null)
			{
				TreeNode treeNode = new TreeNode("列表成员类型:" + collectionItemType.Name);
				treeNode.Name = "[0]";
				treeNode.ImageIndex = method_10(collectionItemType);
				treeNode.SelectedImageIndex = treeNode.ImageIndex;
				treeNode.Tag = collectionItemType;
				if (!method_9(collectionItemType))
				{
					method_8(treeNode);
				}
				treeNode_0.Nodes.Add(treeNode);
			}
			List<MemberInfo> list = new List<MemberInfo>();
			BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public;
			if (ViewDeclaredOnly)
			{
				bindingFlags |= BindingFlags.DeclaredOnly;
			}
			MemberInfo[] members = type_2.GetMembers(bindingFlags);
			foreach (MemberInfo memberInfo in members)
			{
				if (memberInfo is MethodInfo && ((MethodInfo)memberInfo).IsSpecialName)
				{
					continue;
				}
				if (!ShowSystemMember)
				{
					Type declaringType = memberInfo.DeclaringType;
					if (declaringType != null && DesignUtils.IsStdAssembly(declaringType.Assembly))
					{
						continue;
					}
				}
				list.Add(memberInfo);
			}
			list.Sort(new Class34());
			method_7(list, treeNode_0, bool_5: true, bool_6: false);
		}

		private bool method_5(ParameterInfo[] parameterInfo_0)
		{
			if (parameterInfo_0 != null && parameterInfo_0.Length > 0)
			{
				foreach (ParameterInfo parameterInfo in parameterInfo_0)
				{
					if (list_2.Contains(parameterInfo.ParameterType))
					{
						return true;
					}
				}
			}
			return false;
		}

		private bool method_6(MemberInfo memberInfo_0)
		{
			EditorBrowsableAttribute editorBrowsableAttribute = (EditorBrowsableAttribute)Attribute.GetCustomAttribute(memberInfo_0, typeof(EditorBrowsableAttribute), inherit: true);
			if (editorBrowsableAttribute != null && (editorBrowsableAttribute.State == EditorBrowsableState.Advanced || editorBrowsableAttribute.State == EditorBrowsableState.Never))
			{
				return false;
			}
			DCPublishAPIAttribute dCPublishAPIAttribute = (DCPublishAPIAttribute)Attribute.GetCustomAttribute(memberInfo_0.DeclaringType, typeof(DCPublishAPIAttribute), inherit: true);
			if (dCPublishAPIAttribute != null && !dCPublishAPIAttribute.ApplyToMembers && Attribute.GetCustomAttribute(memberInfo_0, typeof(DCPublishAPIAttribute), inherit: true) == null)
			{
				return false;
			}
			if (Attribute.GetCustomAttribute(memberInfo_0, typeof(DCInternalAttribute), inherit: true) != null)
			{
				return false;
			}
			if (!ShowObsoletedMember && Attribute.GetCustomAttribute(memberInfo_0, typeof(ObsoleteAttribute), inherit: true) != null)
			{
				return false;
			}
			if (memberInfo_0 is MethodInfo)
			{
				MethodInfo methodInfo = (MethodInfo)memberInfo_0;
				if (methodInfo.IsSpecialName)
				{
					return false;
				}
				if (methodInfo.ReturnType != null && list_2.Contains(methodInfo.ReturnType))
				{
					return false;
				}
				if (method_5(methodInfo.GetParameters()))
				{
					return false;
				}
			}
			else if (memberInfo_0 is PropertyInfo)
			{
				PropertyInfo propertyInfo = (PropertyInfo)memberInfo_0;
				if (list_2.Contains(propertyInfo.PropertyType))
				{
					return false;
				}
				if (method_5(propertyInfo.GetIndexParameters()))
				{
					return false;
				}
			}
			else if (memberInfo_0 is EventInfo)
			{
				EventInfo eventInfo = (EventInfo)memberInfo_0;
				if (list_2.Contains(eventInfo.EventHandlerType))
				{
					return false;
				}
			}
			else if (memberInfo_0 is FieldInfo)
			{
				FieldInfo fieldInfo = (FieldInfo)memberInfo_0;
				if (list_2.Contains(fieldInfo.FieldType))
				{
					return false;
				}
			}
			return true;
		}

		private void method_7(List<MemberInfo> list_5, TreeNode treeNode_0, bool bool_5, bool bool_6)
		{
			int num = 12;
			List<string> list = new List<string>();
			foreach (MemberInfo item in list_5)
			{
				bool flag;
				if ((flag = method_6(item)) || ShowHiddenType)
				{
					Type type = null;
					TreeNode treeNode = null;
					if (type_0 != null)
					{
						Attribute customAttribute = Attribute.GetCustomAttribute(item, type_0, inherit: false);
						if (customAttribute != null)
						{
							if (item is ConstructorInfo)
							{
								ConstructorInfo constructorInfo = (ConstructorInfo)item;
								StringBuilder stringBuilder = new StringBuilder();
								stringBuilder.Append(constructorInfo.Name);
								stringBuilder.Append("(");
								stringBuilder.Append(DesignUtils.GetParameterCSharpString(constructorInfo.GetParameters(), includeTypeName: true));
								stringBuilder.Append(")");
								treeNode = new TreeNode(stringBuilder.ToString());
								treeNode.Name = stringBuilder.ToString();
								treeNode.Tag = item;
								treeNode.ImageIndex = ImageIndex_Method;
								treeNode.SelectedImageIndex = treeNode.ImageIndex;
								treeNode_0.Nodes.Add(treeNode);
							}
							else if (item is MethodInfo)
							{
								MethodInfo methodInfo = (MethodInfo)item;
								if (methodInfo.IsSpecialName)
								{
									continue;
								}
								StringBuilder stringBuilder = new StringBuilder();
								stringBuilder.Append(methodInfo.Name);
								stringBuilder.Append("(");
								stringBuilder.Append(DesignUtils.GetParameterCSharpString(methodInfo.GetParameters(), includeTypeName: true));
								stringBuilder.Append("):");
								stringBuilder.Append(DesignUtils.GetCSharpTypeName(methodInfo.ReturnType));
								treeNode = new TreeNode(stringBuilder.ToString());
								treeNode.Name = stringBuilder.ToString();
								treeNode.Tag = item;
								treeNode.ImageIndex = ImageIndex_Method;
								treeNode.SelectedImageIndex = treeNode.ImageIndex;
								treeNode_0.Nodes.Add(treeNode);
							}
							else if (item is PropertyInfo)
							{
								PropertyInfo propertyInfo = (PropertyInfo)item;
								StringBuilder stringBuilder = new StringBuilder();
								stringBuilder.Append(propertyInfo.Name);
								ParameterInfo[] indexParameters = propertyInfo.GetIndexParameters();
								if (indexParameters != null && indexParameters.Length > 0)
								{
									stringBuilder.Append("[" + DesignUtils.GetParameterCSharpString(indexParameters, includeTypeName: true) + "]");
								}
								stringBuilder.Append(":");
								stringBuilder.Append(DesignUtils.GetCSharpTypeName(propertyInfo.PropertyType));
								treeNode = new TreeNode(stringBuilder.ToString());
								treeNode.Name = item.Name;
								treeNode.Tag = propertyInfo;
								treeNode.ImageIndex = ImageIndex_Property;
								treeNode.SelectedImageIndex = treeNode.ImageIndex;
								treeNode_0.Nodes.Add(treeNode);
								type = propertyInfo.PropertyType;
							}
							else if (item is EventInfo)
							{
								EventInfo eventInfo = (EventInfo)item;
								treeNode = new TreeNode(eventInfo.Name + ":" + DesignUtils.GetCSharpTypeName(eventInfo.EventHandlerType));
								treeNode.Name = item.Name;
								treeNode.Tag = item;
								treeNode.ImageIndex = ImageIndex_Event;
								treeNode.SelectedImageIndex = treeNode.ImageIndex;
								treeNode_0.Nodes.Add(treeNode);
							}
							else if (item is FieldInfo)
							{
								FieldInfo fieldInfo = (FieldInfo)item;
								treeNode = new TreeNode(fieldInfo.Name + ":" + DesignUtils.GetCSharpTypeName(fieldInfo.FieldType));
								treeNode.Name = item.Name;
								treeNode.Tag = fieldInfo;
								treeNode.ImageIndex = ImageIndex_Field;
								treeNode.SelectedImageIndex = treeNode.ImageIndex;
								treeNode_0.Nodes.Add(treeNode);
								type = fieldInfo.FieldType;
							}
						}
					}
					if (treeNode != null)
					{
						if (!flag)
						{
							treeNode.ForeColor = Color.DarkGray;
						}
						if (bool_6)
						{
							if (list.Contains(item.Name))
							{
								treeNode.Text = "[重名]" + treeNode.Text;
								treeNode.ForeColor = Color.Red;
							}
							else
							{
								list.Add(item.Name);
							}
						}
						try
						{
							if (Attribute.GetCustomAttribute(item, typeof(ObsoleteAttribute), inherit: true) != null)
							{
								treeNode.ForeColor = Color.Red;
								treeNode.Text = "[否决]" + treeNode.Text;
							}
							else
							{
								EditorBrowsableAttribute editorBrowsableAttribute = (EditorBrowsableAttribute)Attribute.GetCustomAttribute(item, typeof(EditorBrowsableAttribute), inherit: true);
								if (editorBrowsableAttribute != null && (editorBrowsableAttribute.State == EditorBrowsableState.Never || editorBrowsableAttribute.State == EditorBrowsableState.Advanced))
								{
									treeNode.ForeColor = Color.Gray;
								}
							}
						}
						catch (Exception ex)
						{
							treeNode.ToolTipText = ex.Message;
							treeNode.ImageIndex = ImageIndex_Invalidate;
							treeNode.SelectedImageIndex = treeNode.ImageIndex;
						}
						if (bool_5 && type != null && !method_9(type))
						{
							if (bool_6)
							{
								if (list_0.Contains(type))
								{
									method_8(treeNode);
								}
							}
							else
							{
								method_8(treeNode);
							}
						}
					}
				}
			}
		}

		private void method_8(TreeNode treeNode_0)
		{
			TreeNode treeNode = new TreeNode("Loading...");
			treeNode.Tag = object_0;
			treeNode_0.Nodes.Add(treeNode);
		}

		private bool method_9(Type type_2)
		{
			if (type_2.IsPrimitive || type_2.Equals(typeof(string)) || type_2.Equals(typeof(DateTime)) || type_2.Equals(typeof(decimal)) || type_2.Equals(typeof(void)) || type_2.Equals(typeof(DBNull)) || type_2.Equals(typeof(IntPtr)) || type_2.Equals(typeof(Color)) || type_2.IsSubclassOf(typeof(Delegate)) || type_2.Equals(typeof(object)))
			{
				return true;
			}
			return false;
		}

		private int method_10(Type type_2)
		{
			if (type_2.IsInterface)
			{
				return ImageIndex_Interface;
			}
			if (type_2.IsEnum)
			{
				return ImageIndex_Enum;
			}
			if (type_2.IsValueType)
			{
				return ImageIndex_Struct;
			}
			if (type_2.IsSubclassOf(typeof(Delegate)))
			{
				return ImageIndex_Delegate;
			}
			if (type_2.IsSubclassOf(typeof(Form)))
			{
				return ImageIndex_Form;
			}
			if (type_2.IsSubclassOf(typeof(Control)))
			{
				return ImageIndex_Control;
			}
			return ImageIndex_Class;
		}

		public void tvwNormal_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			TreeNode node = e.Node;
			if (node != null)
			{
				TreeView treeView = (TreeView)sender;
				if (node.FirstNode != null && node.FirstNode.Tag == object_0)
				{
					TreeViewDrawMode drawMode = treeView.DrawMode;
					treeView.DrawMode = TreeViewDrawMode.Normal;
					try
					{
						treeView.Cursor = Cursors.WaitCursor;
						node.Nodes.Clear();
						if (node.Tag is MethodInfo || node.Tag is PropertyInfo || node.Tag is FieldInfo)
						{
							Type type = null;
							if (node.Tag is MethodInfo)
							{
								type = ((MethodInfo)node.Tag).ReturnType;
							}
							else if (node.Tag is PropertyInfo)
							{
								type = ((PropertyInfo)node.Tag).PropertyType;
							}
							else if (node.Tag is FieldInfo)
							{
								type = ((FieldInfo)node.Tag).FieldType;
							}
							if (type != null)
							{
								method_4(type, node, bool_5: true);
							}
						}
						else if (node.Tag is Type)
						{
							Type type_ = (Type)node.Tag;
							method_4(type_, node, bool_5: true);
						}
					}
					finally
					{
						treeView.Cursor = Cursors.Default;
						treeView.DrawMode = drawMode;
					}
				}
			}
		}

		public void tvwCOM_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			if (e.Node == null || e.Node.Tag == null)
			{
				return;
			}
			TreeNode node = e.Node;
			if (node.FirstNode == null || node.FirstNode.Tag != object_0)
			{
				return;
			}
			node.Nodes.Clear();
			if (node.Tag is MethodInfo || node.Tag is PropertyInfo || node.Tag is FieldInfo)
			{
				Type type = null;
				if (node.Tag is MethodInfo)
				{
					type = ((MethodInfo)node.Tag).ReturnType;
				}
				else if (node.Tag is PropertyInfo)
				{
					type = ((PropertyInfo)node.Tag).PropertyType;
				}
				else if (node.Tag is FieldInfo)
				{
					type = ((FieldInfo)node.Tag).FieldType;
				}
				if (type != null)
				{
					method_2(type, node, bool_5: true);
				}
			}
		}

		public void tvwNormal_DrawNode(object sender, DrawTreeNodeEventArgs e)
		{
			int num = 7;
			if ((e.State & TreeNodeStates.Focused) == TreeNodeStates.Focused || (e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected || (e.State & TreeNodeStates.Hot) == TreeNodeStates.Hot)
			{
				e.DrawDefault = true;
				return;
			}
			TreeView treeView = (TreeView)sender;
			TreeNode node = e.Node;
			string text = node.Text;
			int num2 = text.IndexOf(":");
			if (num2 > 0)
			{
				RectangleF rectangleF = e.Bounds;
				if (rectangleF.Bottom < 0f || rectangleF.Height <= 0f)
				{
					e.DrawDefault = true;
					return;
				}
				e.DrawDefault = false;
				Font font = node.NodeFont;
				if (font == null)
				{
					font = treeView.Font;
				}
				string text2 = text.Substring(0, num2);
				SizeF sizeF = e.Graphics.MeasureString(text2, font, 1000, DrawNodeStringFormat);
				Color color = node.ForeColor;
				if (color.IsEmpty)
				{
					color = Color.Black;
				}
				using (SolidBrush brush = new SolidBrush(color))
				{
					e.Graphics.DrawString(text2, font, brush, new RectangleF(rectangleF.Left, rectangleF.Top, sizeF.Width, rectangleF.Height), DrawNodeStringFormat);
				}
				e.Graphics.DrawString(text.Substring(num2, text.Length - num2), font, Brushes.Blue, new RectangleF(rectangleF.Left + sizeF.Width, rectangleF.Top, rectangleF.Width - sizeF.Width, rectangleF.Height), DrawNodeStringFormat);
			}
			else
			{
				e.DrawDefault = true;
			}
		}
	}
}
