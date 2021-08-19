using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace DCSoft.Writer
{
	/// <summary>
	///       DCWriter内部使用。编辑器帮助类，定义了一些常用例程
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[DocumentComment]
	[ComVisible(false)]
	public class WriterUtils
	{
		private static bool bool_0 = false;

		private static bool bool_1 = false;

		private static TypeConverter typeConverter_0 = TypeDescriptor.GetConverter(typeof(Color));

		private static Dictionary<Type, string> dictionary_0 = null;

		private static List<Type> list_0 = new List<Type>();

		private static int int_0 = 0;

		public static Font font_0 = new Font(Control.DefaultFont.Name, 12f);

		/// <summary>
		///       64*64的标志图片
		///       </summary>
		public static Bitmap DCLogon64 => WriterResourcesCore.DCLogon64;

		internal static bool AllowSetRuntimeChar => Class126.smethod_5();

		public static bool CompareDelegateCompatibility(Type handlerType, MethodInfo method)
		{
			return GClass376.smethod_2(handlerType, method);
		}

		public static MethodBase GetCurrentMethodInfo()
		{
			StackTrace stackTrace = new StackTrace();
			if (stackTrace.FrameCount < 2)
			{
				return null;
			}
			return stackTrace.GetFrame(1).GetMethod();
		}

		internal static string smethod_0(string string_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append('D');
			stringBuilder.Append('C');
			stringBuilder.Append('S');
			stringBuilder.Append('o');
			stringBuilder.Append('f');
			stringBuilder.Append('t');
			stringBuilder.Append('.');
			stringBuilder.Append('W');
			stringBuilder.Append('r');
			stringBuilder.Append('i');
			stringBuilder.Append('t');
			stringBuilder.Append('e');
			stringBuilder.Append('r');
			stringBuilder.Append('.');
			stringBuilder.Append('W');
			stringBuilder.Append('r');
			stringBuilder.Append('i');
			stringBuilder.Append('t');
			stringBuilder.Append('e');
			stringBuilder.Append('r');
			stringBuilder.Append('S');
			stringBuilder.Append('t');
			stringBuilder.Append('r');
			stringBuilder.Append('i');
			stringBuilder.Append('n');
			stringBuilder.Append('g');
			stringBuilder.Append('s');
			stringBuilder.Append('C');
			stringBuilder.Append('o');
			stringBuilder.Append('r');
			stringBuilder.Append('e');
			string name = stringBuilder.ToString();
			Type type = typeof(WriterUtils).Assembly.GetType(name, throwOnError: false, ignoreCase: true);
			if (type == null)
			{
				return null;
			}
			PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			int num = 0;
			ResourceManager resourceManager;
			while (true)
			{
				if (num < properties.Length)
				{
					PropertyInfo propertyInfo = properties[num];
					if (propertyInfo.PropertyType.Equals(typeof(ResourceManager)))
					{
						resourceManager = (ResourceManager)propertyInfo.GetValue(null, null);
						if (resourceManager != null)
						{
							break;
						}
					}
					num++;
					continue;
				}
				return null;
			}
			return resourceManager.GetString(string_0);
		}

		public static bool smethod_1(bool bool_2, bool bool_3)
		{
			int num = 14;
			try
			{
				MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
				mD5CryptoServiceProvider.ComputeHash(new byte[6]
				{
					1,
					2,
					3,
					4,
					5,
					6
				});
				mD5CryptoServiceProvider.Clear();
				return true;
			}
			catch (Exception ex)
			{
				if (bool_3 && Environment.UserInteractive)
				{
					MessageBox.Show(null, WriterStringsCore.PromptMD5Enabled + ":\r\n" + ex.Message, WriterStringsCore.SystemAlert, MessageBoxButtons.OK);
				}
				if (bool_2)
				{
					throw new Exception(ex.Message + ":" + WriterStringsCore.PromptMD5Enabled);
				}
				return false;
			}
		}

		/// <summary>
		///       检查操作系统中是否安装了.NET2.0SP2。
		///       </summary>
		public static string CheckNET20SP2(bool throwException)
		{
			smethod_1(throwException, bool_3: true);
			Type typeFromHandle = typeof(UserControl);
			PropertyInfo property = typeFromHandle.GetProperty("CanEnableIme", BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (property == null)
			{
				string requiredNET20SP = WriterStringsCore.RequiredNET20SP2;
				if (throwException)
				{
					if (Environment.UserInteractive)
					{
						using (dlgRequireNET20SP2 dlgRequireNET20SP = new dlgRequireNET20SP2())
						{
							dlgRequireNET20SP.ShowDialog();
						}
					}
					throw new Exception(requiredNET20SP);
				}
				return requiredNET20SP;
			}
			return null;
		}

		private void method_0()
		{
		}

		internal static int smethod_2(XTextElement xtextElement_0, XTextElement xtextElement_1)
		{
			if (xtextElement_0 == xtextElement_1)
			{
				return 0;
			}
			if (xtextElement_0 == null || xtextElement_1 == null)
			{
				return 0;
			}
			if (xtextElement_0.Parent == xtextElement_1)
			{
				return -1;
			}
			if (xtextElement_0 == xtextElement_1.Parent)
			{
				return 1;
			}
			List<XTextElement> list = new List<XTextElement>();
			XTextElement xTextElement;
			for (xTextElement = xtextElement_0; xTextElement != null; xTextElement = xTextElement.Parent)
			{
				list.Add(xTextElement);
			}
			xTextElement = xtextElement_1.Parent;
			XTextElement xTextElement2 = xtextElement_1;
			int num;
			while (true)
			{
				if (xTextElement != null)
				{
					num = list.IndexOf(xTextElement);
					if (num != 0)
					{
						if (num >= 0)
						{
							break;
						}
						xTextElement2 = xTextElement;
						xTextElement = xTextElement.Parent;
						continue;
					}
					return 1;
				}
				return 0;
			}
			int elementIndex = list[num - 1].ElementIndex;
			int elementIndex2 = xTextElement2.ElementIndex;
			return elementIndex - elementIndex2;
		}

		internal static Hashtable smethod_3(object object_0, string string_0)
		{
			int num = 6;
			if (object_0 == null)
			{
				throw new ArgumentNullException("instance");
			}
			Hashtable hashtable = new Hashtable();
			IDList iDList = new IDList(string_0, ',');
			iDList.IgnoreCase = true;
			PropertyInfo[] properties = object_0.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (!iDList.Contains(propertyInfo.Name))
				{
					continue;
				}
				object propertyDefaultValue = ValueTypeHelper.GetPropertyDefaultValue(propertyInfo);
				object value = propertyInfo.GetValue(object_0, null);
				if (propertyDefaultValue != value && value != null)
				{
					string value2 = value.ToString();
					if (value is Color)
					{
						value2 = ColorTranslator.ToHtml((Color)value);
					}
					else if (value is DateTime)
					{
						value2 = ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
					}
					hashtable[propertyInfo.Name] = value2;
				}
			}
			return hashtable;
		}

		internal static int smethod_4(XTextElementList xtextElementList_0, XTextElement xtextElement_0)
		{
			int num = 13;
			if (xtextElementList_0 == null)
			{
				throw new ArgumentNullException("elements");
			}
			if (xtextElement_0 == null)
			{
				throw new ArgumentNullException("element");
			}
			if (xtextElementList_0.SafeGet(xtextElement_0.ContentIndex) == xtextElement_0)
			{
				return xtextElement_0.ContentIndex;
			}
			if (xtextElementList_0.SafeGet(xtextElement_0.PrivateContentIndex) == xtextElement_0)
			{
				return xtextElement_0.PrivateContentIndex;
			}
			return xtextElementList_0.IndexOf(xtextElement_0);
		}

		public static bool smethod_5(XTextElementList xtextElementList_0, int int_1, int int_2)
		{
			int num = 16;
			if (xtextElementList_0 == null || xtextElementList_0.Count == 0)
			{
				return false;
			}
			if (int_1 > int_2)
			{
				throw new ArgumentOutOfRangeException("startIndex>endIndex");
			}
			if (int_1 < 0)
			{
				int_1 = 0;
			}
			if (int_1 >= xtextElementList_0.Count)
			{
				int_1 = xtextElementList_0.Count - 1;
			}
			if (int_2 < 0)
			{
				int_2 = 0;
			}
			if (int_2 >= xtextElementList_0.Count)
			{
				int_2 = xtextElementList_0.Count - 1;
			}
			int num2 = int_1;
			while (true)
			{
				if (num2 <= int_2)
				{
					XTextElement xTextElement = xtextElementList_0[num2];
					if (!(xTextElement is XTextPageBreakElement))
					{
						if (xTextElement is XTextContainerElement && smethod_5(xTextElement.Elements, 0, xTextElement.Elements.Count - 1))
						{
							break;
						}
						num2++;
						continue;
					}
					return true;
				}
				return false;
			}
			return true;
		}

		internal static void smethod_6()
		{
			int num = 16;
			if (bool_1)
			{
				return;
			}
			bool_1 = true;
			Bitmap dCLogon = WriterResourcesCore.DCLogon64;
			dCLogon.MakeTransparent(Color.FromArgb(169, 223, 232));
			GClass445.smethod_3(dCLogon);
			GClass445.smethod_7(64);
			Type type = typeof(WriterUtils).Assembly.GetType("DCSoft.Writer.DCWriterPublish", throwOnError: false);
			if (type == null)
			{
				type = Type.GetType("DCSoft.Writer.DCWriterPublish", throwOnError: false, ignoreCase: true);
			}
			if (type == null)
			{
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				Assembly[] array = assemblies;
				foreach (Assembly assembly in array)
				{
					try
					{
						type = assembly.GetType("DCSoft.Writer.DCWriterPublish", throwOnError: false);
						if (type != null)
						{
							goto IL_00d5;
						}
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.Message);
					}
				}
			}
			goto IL_00d5;
			IL_00d5:
			type?.GetMethod("Start", BindingFlags.Static | BindingFlags.Public)?.Invoke(null, null);
		}

		/// <summary>
		///       填充DOM树
		///       </summary>
		/// <param name="nodes">根节点列表</param>
		/// <param name="elements">文档元素对象列表</param>
		/// <param name="forLineMode">文档行模式</param>
		/// <param name="extMode">精细模式</param>
		[Obsolete("本方法已废除，请使用DCSoft.Writer.Controls.DOMTreeManager")]
		public static void FillDomTreeNode(TreeNodeCollection nodes, XTextElementList elements, bool forLineMode, bool extMode)
		{
			int num = 9;
			StringBuilder stringBuilder = new StringBuilder();
			XTextCharElement xTextCharElement = null;
			foreach (XTextElement element in elements)
			{
				if (!forLineMode)
				{
					if (element is XTextCharElement)
					{
						if (xTextCharElement == null)
						{
							xTextCharElement = (XTextCharElement)element;
						}
						if (stringBuilder.Length == 0 || xTextCharElement.StyleIndex == element.StyleIndex)
						{
							stringBuilder.Append(((XTextCharElement)element).CharValue);
						}
						else
						{
							string text = stringBuilder.ToString();
							if (text.Length > 50)
							{
								text = text.Substring(0, 50);
							}
							TreeNode treeNode = new TreeNode(GClass369.smethod_2(text));
							treeNode.Tag = xTextCharElement;
							nodes.Add(treeNode);
							stringBuilder = new StringBuilder();
							stringBuilder.Append(((XTextCharElement)element).CharValue);
							xTextCharElement = (XTextCharElement)element;
						}
						continue;
					}
					if (stringBuilder.Length > 0)
					{
						TreeNode treeNode = new TreeNode(GClass369.smethod_2(stringBuilder.ToString()));
						treeNode.Tag = xTextCharElement;
						nodes.Add(treeNode);
						stringBuilder = new StringBuilder();
						xTextCharElement = null;
					}
				}
				if (element is XTextCharElement)
				{
					TreeNode treeNode2 = new TreeNode(element.Text);
					treeNode2.Tag = element;
					nodes.Add(treeNode2);
				}
				else if (element is XTextParagraphFlagElement)
				{
					TreeNode treeNode3 = new TreeNode(element.DomDisplayName);
					treeNode3.Tag = element;
					nodes.Add(treeNode3);
				}
				else if (element is XTextButtonElement)
				{
					TreeNode treeNode4 = new TreeNode(element.DomDisplayName);
					treeNode4.Tag = element;
					nodes.Add(treeNode4);
				}
				else if (element is XTextFieldBorderElement)
				{
					XTextFieldBorderElement tag = (XTextFieldBorderElement)element;
					TreeNode treeNode4 = new TreeNode(element.DomDisplayName);
					treeNode4.Tag = tag;
					nodes.Add(treeNode4);
				}
				else
				{
					TreeNode treeNode5 = new TreeNode(element.DomDisplayName);
					treeNode5.Tag = element;
					nodes.Add(treeNode5);
					if (element is XTextTableCellElement)
					{
						XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)element;
						if (xTextTableCellElement.IsOverrided)
						{
							treeNode5.ForeColor = Color.Gray;
						}
					}
					else if (element is XTextTableElement)
					{
						XTextTableElement xTextTableElement = (XTextTableElement)element;
						for (int i = 0; i < xTextTableElement.Columns.Count; i++)
						{
							TreeNode treeNode6 = new TreeNode();
							treeNode6.Text = "Col" + i + " Width:" + xTextTableElement.Columns[i].Width;
							treeNode6.Tag = xTextTableElement.Columns[i];
							treeNode5.Nodes.Add(treeNode6);
						}
					}
					else if (element is XTextInputFieldElement)
					{
						XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)element;
						treeNode5.Text = element.DomDisplayName;
					}
					else if (element is XTextShadowElement)
					{
						XTextElement shadowElement = ((XTextShadowElement)element).ShadowElement;
						TreeNode treeNode7 = new TreeNode(element.DomDisplayName);
						treeNode7.Tag = shadowElement;
						treeNode5.Nodes.Add(treeNode7);
					}
					else if (element is XTextControlHostElement)
					{
						treeNode5.Text = element.DomDisplayName;
					}
					if ((!forLineMode || extMode) && element is XTextContainerElement && element.Elements != null && element.Elements.Count > 0)
					{
						FillDomTreeNode(treeNode5.Nodes, element.Elements, forLineMode, extMode);
					}
					if (element is XTextInputFieldElement)
					{
						XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)element;
						if (xTextInputFieldElement.FieldSettings != null && xTextInputFieldElement.FieldSettings.RuntimeEditStyle == InputFieldEditStyle.DropdownList && xTextInputFieldElement.FieldSettings.ListSource != null && xTextInputFieldElement.FieldSettings.ListSource.Items != null)
						{
							foreach (ListItem item in xTextInputFieldElement.FieldSettings.ListSource.Items)
							{
								string text2 = item.Text;
								if (!string.IsNullOrEmpty(item.TextInList))
								{
									text2 = item.TextInList;
								}
								if (!string.IsNullOrEmpty(item.Value) && item.Value != text2)
								{
									text2 = text2 + "=" + item.Value;
								}
								TreeNode treeNode8 = new TreeNode("->" + text2);
								treeNode8.Tag = item;
								treeNode5.Nodes.Add(treeNode8);
							}
						}
					}
				}
			}
			if (stringBuilder.Length > 0)
			{
				TreeNode treeNode = new TreeNode(GClass369.smethod_2(stringBuilder.ToString()));
				treeNode.Tag = xTextCharElement;
				nodes.Add(treeNode);
				stringBuilder = new StringBuilder();
				xTextCharElement = null;
			}
		}

		internal static bool smethod_7(XTextContainerElement xtextContainerElement_0)
		{
			if (xtextContainerElement_0 == null)
			{
				return false;
			}
			return RemoveLogicDeletedElements(xtextContainerElement_0.Elements);
		}

		public static string smethod_8(IDataObject idataObject_0)
		{
			if (idataObject_0 == null)
			{
				return null;
			}
			if (idataObject_0.GetDataPresent(DataFormats.Text))
			{
				return Convert.ToString(idataObject_0.GetData(DataFormats.Text));
			}
			if (idataObject_0.GetDataPresent(DataFormats.UnicodeText))
			{
				return Convert.ToString(idataObject_0.GetData(DataFormats.UnicodeText));
			}
			if (idataObject_0.GetDataPresent(DataFormats.OemText))
			{
				return Convert.ToString(idataObject_0.GetData(DataFormats.OemText));
			}
			return null;
		}

		public static bool smethod_9(IDataObject idataObject_0)
		{
			int num = 4;
			return idataObject_0?.GetDataPresent("MRID") ?? false;
		}

		public static string smethod_10(XTextElement xtextElement_0)
		{
			int num = 16;
			string text = xtextElement_0.GetType().Name;
			if (!(xtextElement_0 is XTextCharElement) && !(xtextElement_0 is XTextParagraphFlagElement))
			{
				if (!string.IsNullOrEmpty(xtextElement_0.ID))
				{
					text = text + "[" + xtextElement_0.ID + "]";
				}
				else if (xtextElement_0 is XTextInputFieldElementBase)
				{
					string name = ((XTextInputFieldElementBase)xtextElement_0).Name;
					if (!string.IsNullOrEmpty(name))
					{
						text = text + "[" + name + "]";
					}
				}
			}
			return text;
		}

		internal static void smethod_11(XTextElementList xtextElementList_0)
		{
			if (xtextElementList_0 == null || xtextElementList_0.Count == 0)
			{
				return;
			}
			for (int i = 0; i < xtextElementList_0.Count; i++)
			{
				XTextElement xTextElement = xtextElementList_0[i];
				if (xTextElement is XTextInputFieldElement)
				{
					XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)xTextElement;
					xtextElementList_0.RemoveAt(i);
					xtextElementList_0.method_12(i, xTextInputFieldElement.Elements);
				}
				else if (xTextElement is XTextContainerElement)
				{
					smethod_11(xTextElement.Elements);
				}
			}
		}

		public static string smethod_12(IEnumerable ienumerable_0, char char_0)
		{
			if (ienumerable_0 == null)
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (object item in ienumerable_0)
			{
				if (item != null)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(char_0);
					}
					stringBuilder.Append(Convert.ToString(item));
				}
			}
			return stringBuilder.ToString();
		}

		public static int smethod_13(Type type_0, string string_0, string string_1)
		{
			Stream manifestResourceStream = type_0.Assembly.GetManifestResourceStream(string_0);
			int result = 0;
			if (manifestResourceStream != null)
			{
				using (FileStream fileStream = new FileStream(string_1, FileMode.Create, FileAccess.Write))
				{
					byte[] array = new byte[512];
					while (true)
					{
						int num = manifestResourceStream.Read(array, 0, array.Length);
						if (num <= 0)
						{
							break;
						}
						fileStream.Write(array, 0, num);
						string_0 += num;
					}
				}
			}
			return result;
		}

		public static string smethod_14(Color color_0)
		{
			return typeConverter_0.ConvertToString(color_0);
		}

		public static Color smethod_15(string string_0, Color color_0)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				return color_0;
			}
			return (Color)typeConverter_0.ConvertFromString(string_0);
		}

		internal static void smethod_16(Type type_0, string string_0)
		{
			smethod_17(typeof(XTextInputFieldElement));
			dictionary_0[type_0] = string_0;
		}

		internal static string smethod_17(Type type_0)
		{
			if (dictionary_0 == null)
			{
				dictionary_0 = new Dictionary<Type, string>();
				dictionary_0[typeof(XTextBlockElement)] = WriterStringsCore.ElementType_Block;
				dictionary_0[typeof(XTextDocumentBodyElement)] = WriterStringsCore.ElementType_Body;
				dictionary_0[typeof(XTextCharElement)] = WriterStringsCore.ElementType_Char;
				dictionary_0[typeof(XTextCheckBoxElement)] = WriterStringsCore.ElementType_CheckBox;
				dictionary_0[typeof(XTextRadioBoxElement)] = WriterStringsCore.ElementType_RadioBox;
				dictionary_0[typeof(DocumentComment)] = WriterStringsCore.ElementType_Comment;
				dictionary_0[typeof(XTextContentLinkFieldElement)] = WriterStringsCore.ElementType_ContentLink;
				dictionary_0[typeof(XTextControlHostElement)] = WriterStringsCore.ElementType_ControlHost;
				dictionary_0[typeof(XTextDocument)] = WriterStringsCore.ElementType_Document;
				dictionary_0[typeof(XTextDocumentFooterElement)] = WriterStringsCore.ElementType_Header;
				dictionary_0[typeof(XTextHorizontalLineElement)] = WriterStringsCore.ElementType_HL;
				dictionary_0[typeof(XTextImageElement)] = WriterStringsCore.ElementType_Image;
				dictionary_0[typeof(XTextInputFieldElement)] = WriterStringsCore.ElementType_InputField;
				dictionary_0[typeof(XTextLabelElement)] = WriterStringsCore.ElementType_Label;
				dictionary_0[typeof(XTextLineBreakElement)] = WriterStringsCore.ElementType_LineBreak;
				dictionary_0[typeof(XTextPageBreakElement)] = WriterStringsCore.ElementType_PageBreak;
				dictionary_0[typeof(XTextPageInfoElement)] = WriterStringsCore.ElementType_PageInfo;
				dictionary_0[typeof(XTextParagraphFlagElement)] = WriterStringsCore.ElementType_ParagraphFlag;
				dictionary_0[typeof(XTextSignElement)] = WriterStringsCore.ElementType_Sign;
				dictionary_0[typeof(XTextTableElement)] = WriterStringsCore.ElementType_Table;
				dictionary_0[typeof(XTextTableRowElement)] = WriterStringsCore.ElementType_TableRow;
				dictionary_0[typeof(XTextTableCellElement)] = WriterStringsCore.ElementType_TableCell;
				dictionary_0[typeof(XTextTableColumnElement)] = WriterStringsCore.ElementType_TableColumn;
			}
			if (dictionary_0.ContainsKey(type_0))
			{
				return dictionary_0[type_0];
			}
			return type_0.Name;
		}

		public static object smethod_18(object object_0, string string_0, string string_1, bool bool_2)
		{
			int num = 10;
			if (object_0 == null)
			{
				throw new ArgumentNullException("instance");
			}
			if (string.IsNullOrEmpty(string_0))
			{
				throw new ArgumentNullException("methodName");
			}
			NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(string_1);
			MethodInfo[] methods = object_0.GetType().GetMethods();
			int num2 = 0;
			MethodInfo methodInfo;
			ParameterInfo[] parameters;
			int num3;
			while (true)
			{
				if (num2 < methods.Length)
				{
					methodInfo = methods[num2];
					if (string.Compare(methodInfo.Name, string_0, ignoreCase: true) == 0)
					{
						parameters = methodInfo.GetParameters();
						num3 = ((parameters != null) ? parameters.Length : 0);
						if (num3 == nameValueCollection.Count)
						{
							break;
						}
					}
					num2++;
					continue;
				}
				if (bool_2)
				{
					throw new Exception(string.Format(WriterStringsCore.MemberNotFound_Type_Member, object_0.GetType().FullName, string_0));
				}
				return null;
			}
			object[] array = new object[num3];
			for (int i = 0; i < parameters.Length; i++)
			{
				array[i] = ValueTypeHelper.GetDefaultValue(parameters[i].ParameterType);
			}
			foreach (string key in nameValueCollection.Keys)
			{
				for (int i = 0; i < parameters.Length; i++)
				{
					ParameterInfo parameterInfo = parameters[i];
					if (string.Compare(parameterInfo.Name, key, ignoreCase: true) == 0)
					{
						object obj = array[i] = ValueTypeHelper.ConvertTo(nameValueCollection[key], parameterInfo.ParameterType);
					}
				}
			}
			object obj2 = null;
			return (!methodInfo.IsStatic) ? methodInfo.Invoke(object_0, array) : methodInfo.Invoke(null, array);
		}

		internal static bool smethod_19(string string_0)
		{
			int num = 15;
			if (string.IsNullOrEmpty(string_0))
			{
				return false;
			}
			return string.Compare(string_0, "EditComment", ignoreCase: true) == 0 || string.Compare(string_0, "InsertComment", ignoreCase: true) == 0 || string.Compare(string_0, "DeleteAllComment", ignoreCase: true) == 0 || string.Compare(string_0, "DeleteComment", ignoreCase: true) == 0;
		}

		public static void smethod_20(XTextDocument xtextDocument_0, XTextElementList xtextElementList_0, bool bool_2)
		{
			using (DCGraphics dcgraphics_ = xtextDocument_0.CreateDCGraphics())
			{
				DocumentPaintEventArgs documentPaintEventArgs = xtextDocument_0.method_55(dcgraphics_);
				documentPaintEventArgs.RenderMode = DocumentRenderMode.Paint;
				foreach (XTextElement item in xtextElementList_0)
				{
					if (!bool_2 || item.SizeInvalid)
					{
						documentPaintEventArgs.Element = item;
						item.OwnerDocument = xtextDocument_0;
						item.RefreshSize(documentPaintEventArgs);
					}
				}
			}
		}

		internal static ContentLayoutDirectionStyle smethod_21(char char_0, ContentLayoutDirectionStyle contentLayoutDirectionStyle_0)
		{
			if (Class126.smethod_8(char_0))
			{
				return ContentLayoutDirectionStyle.RightToLeft;
			}
			if (char.IsWhiteSpace(char_0))
			{
				return contentLayoutDirectionStyle_0;
			}
			return ContentLayoutDirectionStyle.LeftToRight;
		}

		internal static bool smethod_22(char char_0)
		{
			return Class126.smethod_8(char_0);
		}

		internal static bool smethod_23(XTextElementList xtextElementList_0)
		{
			return Class126.smethod_2(xtextElementList_0);
		}

		internal static bool smethod_24(XTextElementList xtextElementList_0)
		{
			return Class126.smethod_3(xtextElementList_0);
		}

		internal static bool smethod_25()
		{
			return Class126.smethod_0();
		}

		public static bool smethod_26(DateTime dateTime_0)
		{
			return dateTime_0 == GClass117.dateTime_0;
		}

		public static bool smethod_27(XTextElement xtextElement_0, string string_0, object object_0, bool bool_2)
		{
			int num = 9;
			if (xtextElement_0 == null)
			{
				throw new ArgumentNullException("instance");
			}
			XTextDocument ownerDocument = xtextElement_0.OwnerDocument;
			if (ownerDocument == null)
			{
				throw new ArgumentNullException("instance.OwnerDocument");
			}
			if (string.IsNullOrEmpty(string_0))
			{
				throw new ArgumentNullException("propertyName");
			}
			PropertyInfo property = xtextElement_0.GetType().GetProperty(string_0, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
			if (property == null)
			{
				throw new ArgumentOutOfRangeException(xtextElement_0.GetType().Name + "#" + string_0);
			}
			if (!property.CanRead || !property.CanWrite)
			{
				throw new InvalidOperationException(xtextElement_0.GetType().Name + "." + property.Name);
			}
			object obj = ValueTypeHelper.ConvertTo(object_0, property.PropertyType);
			object value = property.GetValue(xtextElement_0, Type.EmptyTypes);
			if (value != obj)
			{
				if (bool_2 && ownerDocument.CanLogUndo)
				{
					ownerDocument.UndoList.AddProperty(string_0, value, obj, xtextElement_0);
				}
				property.SetValue(xtextElement_0, obj, Type.EmptyTypes);
				return true;
			}
			return false;
		}

		/// <summary>
		///       删除被逻辑删除的文档元素对象
		///       </summary>
		/// <param name="elements">文档元素对象列表</param>
		/// <returns>操作是否删除的文档元素对象</returns>
		public static bool RemoveLogicDeletedElements(XTextElementList elements)
		{
			bool result = false;
			for (int num = elements.Count - 1; num >= 0; num--)
			{
				XTextElement xTextElement = elements[num];
				if (!(xTextElement is XTextDocumentContentElement))
				{
					RuntimeDocumentContentStyle runtimeStyle = xTextElement.RuntimeStyle;
					if (runtimeStyle != null && runtimeStyle.DeleterIndex >= 0)
					{
						elements.RemoveAt(num);
						result = true;
						continue;
					}
				}
				if (xTextElement.Elements != null && RemoveLogicDeletedElements(xTextElement.Elements))
				{
					result = true;
				}
			}
			return result;
		}

		internal static void smethod_28(object object_0, XTextElement xtextElement_0, DocumentPaintEventArgs documentPaintEventArgs_0)
		{
			int num = 6;
			if (!xtextElement_0.OwnerDocument.Options.BehaviorOptions.EnableElementEvents)
			{
				return;
			}
			XTextDocument ownerDocument = xtextElement_0.OwnerDocument;
			ElementPaintEventArgs elementPaintEventArgs = new ElementPaintEventArgs(ownerDocument, xtextElement_0, documentPaintEventArgs_0);
			ownerDocument.method_32(elementPaintEventArgs);
			if (elementPaintEventArgs.Cancel)
			{
				documentPaintEventArgs_0.Cancel = true;
				return;
			}
			ElementEventTemplateList events = xtextElement_0.Events;
			if (events != null && events.HasAfterPaint)
			{
				events.OnAfterPaint(object_0, elementPaintEventArgs);
				documentPaintEventArgs_0.Style = elementPaintEventArgs.Style;
				if (elementPaintEventArgs.Cancel)
				{
					documentPaintEventArgs_0.Cancel = true;
				}
			}
			ownerDocument.method_47(xtextElement_0, "DrawContent", new object[2]
			{
				xtextElement_0,
				elementPaintEventArgs
			});
		}

		internal static void smethod_29(object object_0, XTextElement xtextElement_0, DocumentPaintEventArgs documentPaintEventArgs_0)
		{
			if (!xtextElement_0.OwnerDocument.Options.BehaviorOptions.EnableElementEvents)
			{
				return;
			}
			ElementPaintEventArgs elementPaintEventArgs = new ElementPaintEventArgs(xtextElement_0.OwnerDocument, xtextElement_0, documentPaintEventArgs_0);
			documentPaintEventArgs_0.Style = elementPaintEventArgs.Style;
			xtextElement_0.OwnerDocument.method_31(elementPaintEventArgs);
			if (elementPaintEventArgs.Cancel)
			{
				documentPaintEventArgs_0.Cancel = true;
				return;
			}
			ElementEventTemplateList events = xtextElement_0.Events;
			if (events != null && events.HasBeforePaint)
			{
				events.OnBeforePaint(object_0, elementPaintEventArgs);
				if (elementPaintEventArgs.Cancel)
				{
					documentPaintEventArgs_0.Cancel = true;
				}
			}
		}

		public static bool smethod_30(string string_0, XTextElement xtextElement_0)
		{
			return xtextElement_0.ID == string_0;
		}

		/// <summary>
		///       检查枚举值是否在正常范围中
		///       </summary>
		/// <param name="enumValue">枚举值</param>
		/// <returns>是否在正常范围中</returns>
		public static object FixEnumValue(object enumValue)
		{
			int num = 3;
			if (enumValue == null)
			{
				throw new ArgumentNullException("enumValue");
			}
			Type type = enumValue.GetType();
			if (list_0.Contains(type))
			{
				return enumValue;
			}
			if (Enum.IsDefined(type, enumValue))
			{
				return enumValue;
			}
			if (Attribute.GetCustomAttribute(type, typeof(FlagsAttribute), inherit: true) != null)
			{
				list_0.Add(type);
				return enumValue;
			}
			Array values = Enum.GetValues(type);
			if (values != null && values.Length > 0)
			{
				return values.GetValue(0);
			}
			return enumValue;
		}

		public static bool smethod_31(Exception exception_0)
		{
			if (exception_0 is COMException)
			{
				COMException ex = (COMException)exception_0;
				if (ex.ErrorCode == -2147352573)
				{
					return true;
				}
			}
			else if (exception_0 is AccessViolationException)
			{
				return true;
			}
			return false;
		}

		public static XTextDocument smethod_32(XTextDocument xtextDocument_0, XTextElementList xtextElementList_0, bool bool_2)
		{
			if (xtextElementList_0 == null)
			{
				return null;
			}
			XTextDocument xTextDocument = null;
			xTextDocument = ((xtextDocument_0 != null) ? ((XTextDocument)xtextDocument_0.Clone(Deeply: false)) : new XTextDocument());
			xTextDocument.ContentStyles.Styles.Clear();
			xTextDocument.ContentStyles.Default = xtextDocument_0.ContentStyles.Default.Clone();
			xTextDocument.Comments.Clear();
			xTextDocument.UserHistories.Clear();
			if (xTextDocument.UndoList != null)
			{
				xTextDocument.UndoList.Clear();
			}
			if (xtextElementList_0.Count == 0)
			{
				return xTextDocument;
			}
			_ = xTextDocument.Body;
			foreach (XTextElement item in xtextElementList_0)
			{
				if (item is XTextContainerElement)
				{
					((XTextContainerElement)item).FixDomState();
				}
			}
			XTextElementList xTextElementList = xtextElementList_0;
			if (bool_2)
			{
				xTextElementList = xTextElementList.CloneDeeply();
			}
			if (xTextElementList.Count > 0)
			{
				xTextElementList[0].OwnerDocument = xtextDocument_0;
			}
			xTextDocument.ImportElements(xTextElementList);
			xTextDocument.Body.Elements.Clear();
			xTextDocument.Body.Elements.AddRange(xTextElementList);
			xTextDocument.Body.FixElements();
			xTextDocument.method_111();
			xTextDocument.EditorControl = null;
			xTextDocument.DocumentControler = null;
			xTextDocument.HighlightManager = null;
			xTextDocument.CurrentStyleInfo = null;
			xTextDocument.HoverElement = null;
			if (xTextDocument.UndoList != null)
			{
				xTextDocument.EndLogUndo();
				xTextDocument.UndoList.Clear();
			}
			xTextDocument.FixDomState();
			return xTextDocument;
		}

		public static string smethod_33(string string_0, int int_1)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				return "";
			}
			if (string_0.Length > int_1)
			{
				return string_0.Substring(0, int_1);
			}
			return string_0;
		}

		internal static bool smethod_34(WriterDataFormats writerDataFormats_0, WriterDataFormats writerDataFormats_1)
		{
			return (writerDataFormats_0 & writerDataFormats_1) == writerDataFormats_1;
		}

		public static bool smethod_35(int int_1, int int_2)
		{
			return (int_1 & int_2) == int_2;
		}

		public static decimal smethod_36(XTextDocument xtextDocument_0, float float_0)
		{
			int num = 8;
			if (xtextDocument_0 == null)
			{
				throw new ArgumentNullException("document");
			}
			return Convert.ToDecimal((double)GraphicsUnitConvert.Convert(float_0, xtextDocument_0.DocumentGraphicsUnit, GraphicsUnit.Millimeter) / 10.0);
		}

		public static float smethod_37(XTextDocument xtextDocument_0, decimal decimal_0)
		{
			int num = 11;
			if (xtextDocument_0 == null)
			{
				throw new ArgumentNullException("document");
			}
			return (float)GraphicsUnitConvert.Convert(Convert.ToDouble(decimal_0) * 10.0, GraphicsUnit.Millimeter, xtextDocument_0.DocumentGraphicsUnit);
		}

		public static bool smethod_38(object object_0, ref bool bool_2)
		{
			int num = 4;
			if (object_0 == null || DBNull.Value.Equals(object_0))
			{
				return false;
			}
			if (object_0 is bool)
			{
				bool_2 = (bool)object_0;
				return true;
			}
			string text = Convert.ToString(object_0);
			text = text.Trim();
			if (text.Equals("true", StringComparison.CurrentCultureIgnoreCase) || text == "1")
			{
				bool_2 = true;
				return true;
			}
			if (text.Equals("false", StringComparison.CurrentCultureIgnoreCase) || text == "0")
			{
				bool_2 = false;
				return true;
			}
			return false;
		}

		public static object smethod_39(object object_0, object object_1)
		{
			if (object_0 == null || DBNull.Value.Equals(object_0))
			{
				return object_1;
			}
			Type type = object_1.GetType();
			try
			{
				if (type.Equals(object_0.GetType()))
				{
					return object_0;
				}
				if (object_0 is string)
				{
					return Enum.Parse(type, (string)object_0);
				}
				return Enum.ToObject(type, object_0);
			}
			catch
			{
				return object_1;
			}
		}

		public static int smethod_40(object object_0, int int_1)
		{
			if (object_0 == null || DBNull.Value.Equals(object_0))
			{
				return int_1;
			}
			int result = int_1;
			if (object_0 is string)
			{
				if (!int.TryParse((string)object_0, out result))
				{
					return int_1;
				}
			}
			else if (object_0 is int || object_0 is float || object_0 is double || object_0 is long || object_0 is short || object_0 is byte || object_0 is uint)
			{
				result = Convert.ToInt32(object_0);
			}
			return result;
		}

		public static bool smethod_41(object object_0, bool bool_2)
		{
			int num = 16;
			if (object_0 == null || DBNull.Value.Equals(object_0))
			{
				return bool_2;
			}
			if (object_0 is bool)
			{
				return (bool)object_0;
			}
			string text = Convert.ToString(object_0);
			text = text.Trim();
			if (text.Equals("true", StringComparison.CurrentCultureIgnoreCase) || text == "1")
			{
				return true;
			}
			if (text.Equals("false", StringComparison.CurrentCultureIgnoreCase) || text == "0")
			{
				return false;
			}
			return bool_2;
		}

		public static Bitmap smethod_42(int int_1, int int_2, string string_0, Font font_1, Color color_0, Color color_1)
		{
			if (int_1 < 3 || int_2 < 3)
			{
				return null;
			}
			Bitmap bitmap = new Bitmap(int_1, int_2);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.Clear(color_1);
				if (!string.IsNullOrEmpty(string_0))
				{
					using (StringFormat stringFormat = new StringFormat())
					{
						stringFormat.Alignment = StringAlignment.Center;
						stringFormat.LineAlignment = StringAlignment.Center;
						using (SolidBrush brush = new SolidBrush(color_0))
						{
							graphics.DrawString(string_0, font_1, brush, new RectangleF(0f, 0f, int_1, int_2), stringFormat);
						}
					}
				}
			}
			return bitmap;
		}

		public static bool smethod_43(string string_0, string string_1)
		{
			if (string_0 == string_1)
			{
				return true;
			}
			if (string.IsNullOrEmpty(string_0) && string.IsNullOrEmpty(string_1))
			{
				return true;
			}
			return false;
		}

		public static string smethod_44(int int_1)
		{
			return FileHelper.FormatByteSize(int_1);
		}

		/// <summary>
		///       删除元素列表中自动创建的段落标记元素
		///       </summary>
		/// <param name="elements">文档元素列表</param>
		/// <returns>操作是否改变了列表内容</returns>
		public static bool RemoveAutoCreateParagraphFlag(XTextElementList elements)
		{
			if (elements != null && elements.Count > 0 && elements.LastElement is XTextParagraphFlagElement)
			{
				XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)elements.LastElement;
				if (xTextParagraphFlagElement.AutoCreate)
				{
					elements.RemoveAt(elements.Count - 1);
					return true;
				}
			}
			return false;
		}

		internal static byte[] smethod_45(string string_0)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				return null;
			}
			string_0 = string_0.Trim();
			Uri uri = new Uri(string_0);
			if (uri.Scheme == Uri.UriSchemeFile)
			{
				string localPath = uri.LocalPath;
				if (!File.Exists(localPath))
				{
					throw new FileNotFoundException(localPath);
				}
				FileInfo fileInfo = new FileInfo(localPath);
				byte[] array = new byte[fileInfo.Length];
				using (FileStream fileStream = new FileStream(localPath, FileMode.Open, FileAccess.Read))
				{
					fileStream.Read(array, 0, array.Length);
				}
				return array;
			}
			using (WebClient webClient = new WebClient())
			{
				return webClient.DownloadData(string_0);
			}
		}

		internal static XTextInputFieldElementBase smethod_46(XTextElement xtextElement_0)
		{
			while (true)
			{
				if (xtextElement_0 != null)
				{
					if (xtextElement_0 is XTextInputFieldElementBase)
					{
						break;
					}
					xtextElement_0 = xtextElement_0.Parent;
					continue;
				}
				return null;
			}
			return (XTextInputFieldElementBase)xtextElement_0;
		}

		internal static byte[] smethod_47(object object_0)
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			binaryFormatter.Serialize(memoryStream, object_0);
			memoryStream.Close();
			return memoryStream.ToArray();
		}

		internal static object smethod_48(byte[] byte_0)
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			MemoryStream memoryStream = new MemoryStream(byte_0);
			object result = binaryFormatter.Deserialize(memoryStream);
			memoryStream.Close();
			return result;
		}

		public static void smethod_49(XTextElementList xtextElementList_0, ElementEnumerateEventHandler elementEnumerateEventHandler_0)
		{
			int num = 18;
			if (elementEnumerateEventHandler_0 == null)
			{
				throw new ArgumentNullException("handler");
			}
			ElementEnumerateEventArgs elementEnumerateEventArgs = new ElementEnumerateEventArgs();
			smethod_51(xtextElementList_0, elementEnumerateEventHandler_0, elementEnumerateEventArgs, bool_2: true);
			_ = elementEnumerateEventArgs.HandlerCount;
		}

		public static void smethod_50(XTextElementList xtextElementList_0, ElementEnumerateEventHandler elementEnumerateEventHandler_0, bool bool_2)
		{
			int num = 3;
			if (elementEnumerateEventHandler_0 == null)
			{
				throw new ArgumentNullException("handler");
			}
			ElementEnumerateEventArgs elementEnumerateEventArgs = new ElementEnumerateEventArgs();
			float tickCountFloat = CountDown.GetTickCountFloat();
			smethod_51(xtextElementList_0, elementEnumerateEventHandler_0, elementEnumerateEventArgs, bool_2);
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
			_ = elementEnumerateEventArgs.HandlerCount;
		}

		private static void smethod_51(XTextElementList xtextElementList_0, ElementEnumerateEventHandler elementEnumerateEventHandler_0, ElementEnumerateEventArgs elementEnumerateEventArgs_0, bool bool_2)
		{
			foreach (XTextElement item in xtextElementList_0)
			{
				XTextElement xTextElement = elementEnumerateEventArgs_0._Element = item;
				elementEnumerateEventArgs_0.CancelChild = false;
				elementEnumerateEventHandler_0(null, elementEnumerateEventArgs_0);
				elementEnumerateEventArgs_0.IncreaseHandlerCount();
				if (elementEnumerateEventArgs_0.Cancel)
				{
					break;
				}
				if (!elementEnumerateEventArgs_0.CancelChild && bool_2 && xTextElement is XTextContainerElement)
				{
					smethod_51(((XTextContainerElement)xTextElement).Elements, elementEnumerateEventHandler_0, elementEnumerateEventArgs_0, bool_2);
					if (elementEnumerateEventArgs_0.Cancel)
					{
						break;
					}
				}
				elementEnumerateEventArgs_0.CancelChild = false;
			}
		}

		internal static string[] smethod_52(string string_0)
		{
			if (string_0 == null)
			{
				return null;
			}
			ArrayList arrayList = new ArrayList();
			StringReader stringReader = new StringReader(string_0);
			string text = stringReader.ReadLine();
			while (text != null)
			{
				arrayList.Add(text);
				text = stringReader.ReadLine();
				if (text == null)
				{
					break;
				}
			}
			return (string[])arrayList.ToArray(typeof(string));
		}

		internal static float smethod_53(float float_0, float float_1)
		{
			float num = float_1 * (float)(int)Math.Ceiling((double)float_0 / (double)float_1) - float_0;
			if (num == 0f)
			{
				num = float_1;
			}
			return num;
		}

		internal static int smethod_54(Graphics graphics_0)
		{
			int num = 0;
			if (graphics_0 != null)
			{
				int_0 = (int)graphics_0.MeasureString("____", font_0).Width;
			}
			return int_0;
		}

		internal static bool smethod_55(string string_0)
		{
			return string_0 != null && string_0.Length > 0;
		}

		public static XTextContainerElement smethod_56(XTextElement xtextElement_0, XTextElement xtextElement_1)
		{
			int num = 18;
			if (xtextElement_0 == null)
			{
				throw new ArgumentNullException("element1");
			}
			if (xtextElement_1 == null)
			{
				throw new ArgumentNullException("element2");
			}
			if (xtextElement_0.Parent == xtextElement_1.Parent)
			{
				return xtextElement_0.Parent;
			}
			for (XTextElement xTextElement = xtextElement_0; xTextElement != null; xTextElement = xTextElement.Parent)
			{
				XTextElement xTextElement2 = xtextElement_1;
				while (xTextElement2 != null)
				{
					if (xTextElement != xTextElement2)
					{
						xTextElement2 = xTextElement2.Parent;
						continue;
					}
					return xTextElement as XTextContainerElement;
				}
			}
			return null;
		}

		internal static XTextElementList smethod_57(XTextElement xtextElement_0)
		{
			int num = 1;
			if (xtextElement_0 == null)
			{
				throw new ArgumentNullException("element");
			}
			XTextElementList xTextElementList = new XTextElementList();
			for (XTextContainerElement parent = xtextElement_0.Parent; parent != null; parent = parent.Parent)
			{
				if (parent.FirstContentElement != xtextElement_0)
				{
					xTextElementList.Add(parent);
				}
			}
			return xTextElementList;
		}

		internal static XTextElementList smethod_58(XTextElement xtextElement_0)
		{
			int num = 15;
			if (xtextElement_0 == null)
			{
				throw new ArgumentNullException("GetParentList.element");
			}
			XTextElementList xTextElementList = new XTextElementList();
			for (XTextContainerElement parent = xtextElement_0.Parent; parent != null; parent = parent.Parent)
			{
				xTextElementList.AddRaw(parent);
			}
			return xTextElementList;
		}

		internal static XTextElementList smethod_59(XTextElementList xtextElementList_0, bool bool_2, bool bool_3)
		{
			if (xtextElementList_0 == null || xtextElementList_0.Count == 0)
			{
				return null;
			}
			XTextElementList xTextElementList = smethod_61(xtextElementList_0, bool_2, null, bool_3);
			XTextElementList xTextElementList2 = new XTextElementList();
			XTextDocument ownerDocument = xtextElementList_0[0].OwnerDocument;
			XTextParagraphElement xTextParagraphElement = new XTextParagraphElement();
			xTextParagraphElement.TemporaryFlag = true;
			xTextParagraphElement.OwnerDocument = ownerDocument;
			xTextElementList2.Add(xTextParagraphElement);
			foreach (XTextElement item in xTextElementList)
			{
				XTextParagraphElement xTextParagraphElement2 = (XTextParagraphElement)xTextElementList2[xTextElementList2.Count - 1];
				if (item is XTextParagraphFlagElement)
				{
					xTextParagraphElement2.TemporaryFlag = false;
					xTextParagraphElement2.StyleIndex = item.StyleIndex;
					xTextParagraphElement2.Elements.AddRaw(item);
					xTextParagraphElement2 = new XTextParagraphElement();
					xTextParagraphElement2.OwnerDocument = ownerDocument;
					xTextElementList2.Add(xTextParagraphElement2);
				}
				else
				{
					xTextParagraphElement2.Elements.AddRaw(item);
				}
			}
			XTextParagraphElement xTextParagraphElement3 = (XTextParagraphElement)xTextElementList2[xTextElementList2.Count - 1];
			if (xTextParagraphElement3.Elements.Count == 0)
			{
				xTextElementList2.RemoveAt(xTextElementList2.Count - 1);
			}
			return xTextElementList2;
		}

		public static XTextElementList smethod_60(XTextElementList xtextElementList_0, bool bool_2)
		{
			return smethod_61(xtextElementList_0, bool_2, null, bool_3: false);
		}

		public static XTextElementList smethod_61(XTextElementList xtextElementList_0, bool bool_2, GInterface5 ginterface5_0, bool bool_3)
		{
			int num = 15;
			XTextElementList xTextElementList = new XTextElementList();
			if (xtextElementList_0.Count == 0)
			{
				return xTextElementList;
			}
			XTextStringElement xTextStringElement = null;
			_ = xtextElementList_0[0].DocumentContentElement;
			foreach (XTextElement item in xtextElementList_0)
			{
				if ((ginterface5_0 == null || ((item.OwnerLine == null || item.OwnerLine.HtmlVisible) && ((!(item is XTextCharElement) && !(item is XTextParagraphFlagElement) && !(item is XTextObjectElement)) || item.OwnerLine != null))) && (!bool_3 || !item.IsLogicDeleted) && (!bool_2 || item.HasSelection))
				{
					if (item is XTextCharElement)
					{
						XTextCharElement xTextCharElement = (XTextCharElement)item;
						string string_ = xTextCharElement.ToString();
						bool flag = false;
						XTextInputFieldElement xTextInputFieldElement = null;
						if (xTextCharElement.Parent is XTextInputFieldElement)
						{
							flag = ((XTextInputFieldElement)xTextCharElement.Parent).FastIsBackgroundTextElement(xTextCharElement);
						}
						if (ginterface5_0 != null && xTextCharElement.Parent is XTextInputFieldElement)
						{
							XTextInputFieldElement xTextInputFieldElement2 = (XTextInputFieldElement)xTextCharElement.Parent;
							xTextInputFieldElement = xTextInputFieldElement2;
							if (ginterface5_0.imethod_57() && xTextInputFieldElement2.IsEncrypt(xTextCharElement))
							{
								string_ = "*";
							}
							else if (flag)
							{
								switch (ginterface5_0.imethod_55())
								{
								case DCBackgroundTextOutputMode.None:
									string_ = null;
									break;
								case DCBackgroundTextOutputMode.Whitespace:
									string_ = ((xTextCharElement.CharValue <= 'Ā') ? " " : "  ");
									break;
								case DCBackgroundTextOutputMode.Underline:
									string_ = ((xTextCharElement.CharValue <= 'Ā') ? "_" : "__");
									break;
								}
							}
						}
						if (xTextStringElement != null && xTextStringElement.method_27(xTextCharElement) && xTextStringElement.Parent == xTextCharElement.Parent && xTextStringElement.IsBackgroundText == flag)
						{
							xTextStringElement.method_28(xTextCharElement, string_);
						}
						else
						{
							xTextStringElement = new XTextStringElement();
							xTextStringElement.OwnerDocument = xTextCharElement.OwnerDocument;
							xTextStringElement.SetParentRaw(xTextCharElement.Parent);
							if (ginterface5_0 != null && ginterface5_0.imethod_34())
							{
								xTextStringElement.MergeForPrintHtml = true;
							}
							if (flag && xTextInputFieldElement != null)
							{
								xTextStringElement.StyleIndex = xTextInputFieldElement.StyleIndex;
							}
							xTextStringElement.IsBackgroundText = flag;
							xTextElementList.Add(xTextStringElement);
							xTextStringElement.method_28(xTextCharElement, string_);
						}
					}
					else
					{
						xTextStringElement = null;
						xTextElementList.Add(item);
					}
				}
			}
			if (xTextElementList.LastElement is XTextParagraphFlagElement)
			{
				XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)xTextElementList.LastElement;
				if (xTextParagraphFlagElement.AutoCreate)
				{
					xTextElementList.RemoveAt(xTextElementList.Count - 1);
				}
			}
			foreach (XTextElement item2 in xTextElementList)
			{
				if (item2 is XTextStringElement)
				{
					((XTextStringElement)item2).method_26();
				}
			}
			return xTextElementList;
		}

		internal static bool smethod_62(XTextElementList xtextElementList_0, bool bool_2)
		{
			int num = 11;
			if (xtextElementList_0 == null)
			{
				return false;
			}
			if (xtextElementList_0.bool_0)
			{
				return false;
			}
			if (xtextElementList_0.Count == 0)
			{
				return false;
			}
			xtextElementList_0.bool_0 = true;
			bool result = false;
			XTextElementList xTextElementList = new XTextElementList();
			xTextElementList.AddRange(xtextElementList_0);
			foreach (XTextElement item in xTextElementList)
			{
				if (item is XTextStringElement)
				{
					int index = xtextElementList_0.IndexOf(item);
					xtextElementList_0.RemoveAt(index);
					XTextStringElement xTextStringElement = (XTextStringElement)item;
					xTextStringElement.method_8(bool_5: false);
					string text = xTextStringElement.Text;
					if (!string.IsNullOrEmpty(text))
					{
						List<XTextElement> list = new List<XTextElement>();
						string[] array = VariableString.AnalyseVariableString(text, "[%", "%]");
						XTextContainerElement parent = xTextStringElement.Parent;
						XTextDocument ownerDocument = xTextStringElement.OwnerDocument;
						int styleIndex = xTextStringElement.StyleIndex;
						for (int i = 0; i < array.Length; i++)
						{
							string text2 = array[i];
							if (i % 2 != 0)
							{
								if (text2 == "pageindex")
								{
									XTextPageInfoElement xTextPageInfoElement = new XTextPageInfoElement();
									xTextPageInfoElement.ValueType = PageInfoValueType.PageIndex;
									xTextPageInfoElement.method_0(parent, ownerDocument, styleIndex);
									list.Add(xTextPageInfoElement);
									text2 = null;
								}
								else
								{
									text2 = "[%" + text2 + "%]";
								}
							}
							if (!string.IsNullOrEmpty(text2))
							{
								string text3 = text2;
								foreach (char c in text3)
								{
									switch (c)
									{
									case '\r':
									{
										XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
										xTextParagraphFlagElement.method_0(parent, ownerDocument, styleIndex);
										list.Add(xTextParagraphFlagElement);
										break;
									}
									default:
									{
										XTextCharElement xTextCharElement = new XTextCharElement();
										xTextCharElement.method_0(parent, ownerDocument, styleIndex);
										xTextCharElement.CharValue = c;
										list.Add(xTextCharElement);
										break;
									}
									case '\n':
										break;
									}
								}
							}
						}
						if (list.Count > 0)
						{
							xtextElementList_0.method_12(index, list);
						}
						result = true;
					}
				}
				else if (item is XTextContainerElement)
				{
					smethod_62(((XTextContainerElement)item).Elements, bool_2);
				}
			}
			return result;
		}

		internal static XTextElement smethod_63(XTextElement xtextElement_0, XTextElement xtextElement_1)
		{
			int num = 15;
			if (xtextElement_0 == null)
			{
				throw new ArgumentNullException("element1");
			}
			if (xtextElement_1 == null)
			{
				throw new ArgumentNullException("element2");
			}
			if (xtextElement_0 == xtextElement_1)
			{
				return xtextElement_0;
			}
			XTextElementList xTextElementList = new XTextElementList();
			XTextElement xTextElement;
			for (xTextElement = xtextElement_0; xTextElement != null; xTextElement = xTextElement.Parent)
			{
				xTextElementList.Add(xTextElement);
			}
			xTextElement = xtextElement_1;
			while (true)
			{
				if (xTextElement != null)
				{
					if (xTextElementList.Contains(xTextElement))
					{
						break;
					}
					xTextElement = xTextElement.Parent;
					continue;
				}
				return null;
			}
			return xTextElement;
		}

		public static ElementType smethod_64(Type type_0)
		{
			int num = 7;
			if (type_0 == null)
			{
				throw new ArgumentNullException("elementType");
			}
			if (typeof(XTextCharElement).IsAssignableFrom(type_0))
			{
				return ElementType.Text;
			}
			if (typeof(XTextParagraphFlagElement).IsAssignableFrom(type_0))
			{
				return ElementType.ParagraphFlag;
			}
			if (typeof(XTextInputFieldElementBase).IsAssignableFrom(type_0))
			{
				return ElementType.InputField;
			}
			if (typeof(XTextFieldElementBase).IsAssignableFrom(type_0))
			{
				return ElementType.Field;
			}
			if (typeof(XTextImageElement).IsAssignableFrom(type_0))
			{
				return ElementType.Image;
			}
			if (typeof(XTextObjectElement).IsAssignableFrom(type_0))
			{
				return ElementType.Object;
			}
			if (typeof(XTextCheckBoxElementBase).IsAssignableFrom(type_0))
			{
				return ElementType.CheckRadioBox;
			}
			if (typeof(XTextDocument).IsAssignableFrom(type_0))
			{
				return ElementType.Document;
			}
			if (typeof(XTextLineBreakElement).IsAssignableFrom(type_0))
			{
				return ElementType.LineBreak;
			}
			if (typeof(XTextPageBreakElement).IsAssignableFrom(type_0))
			{
				return ElementType.PageBreak;
			}
			if (typeof(XTextTableCellElement).IsAssignableFrom(type_0))
			{
				return ElementType.TableCell;
			}
			if (typeof(XTextTableRowElement).IsAssignableFrom(type_0))
			{
				return ElementType.TableRow;
			}
			if (typeof(XTextTableElement).IsAssignableFrom(type_0))
			{
				return ElementType.Table;
			}
			if (typeof(XTextTableColumnElement).IsAssignableFrom(type_0))
			{
				return ElementType.TableColumn;
			}
			return ElementType.None;
		}

		internal static void smethod_65(GClass519 gclass519_0, Pen pen_0, RectangleF rectangleF_0, bool bool_2, bool bool_3, bool bool_4, bool bool_5)
		{
			if (bool_2 && bool_3 && bool_4 && bool_5)
			{
				gclass519_0.method_46(pen_0, rectangleF_0.Left, rectangleF_0.Top, rectangleF_0.Width, rectangleF_0.Height);
				return;
			}
			if (bool_2)
			{
				gclass519_0.method_56(pen_0, rectangleF_0.Left, rectangleF_0.Bottom, rectangleF_0.Left, rectangleF_0.Top);
			}
			if (bool_3)
			{
				gclass519_0.method_56(pen_0, rectangleF_0.Left, rectangleF_0.Top, rectangleF_0.Right, rectangleF_0.Top);
			}
			if (bool_4)
			{
				gclass519_0.method_56(pen_0, rectangleF_0.Right, rectangleF_0.Top, rectangleF_0.Right, rectangleF_0.Bottom);
			}
			if (bool_5)
			{
				gclass519_0.method_56(pen_0, rectangleF_0.Left, rectangleF_0.Bottom, rectangleF_0.Right, rectangleF_0.Bottom);
			}
		}
	}
}
