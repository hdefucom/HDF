#define DEBUG
using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.WinForms.Native;
using DCSoftDotfuscate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.WinForms
{
	/// <summary>
	///       WinForm窗体工具类
	///       </summary>
	[ComVisible(false)]
	public static class WinFormUtils
	{
		private class Class6 : IMessageFilter
		{
			private int int_0 = 0;

			public bool PreFilterMessage(ref Message message_0)
			{
				int_0++;
				if (int_0 > 20)
				{
					return false;
				}
				Debug.WriteLine(message_0.ToString());
				return true;
			}
		}

		[CompilerGenerated]
		private sealed class Class7
		{
			public Control control_0;

			public void method_0(object sender, EventArgs e)
			{
				control_0.Focus();
			}
		}

		public static bool smethod_0()
		{
			Version version = Environment.OSVersion.Version;
			return version.Major >= 6;
		}

		public static void smethod_1()
		{
			GClass380.smethod_4(typeof(WinFormsResources));
		}

		public static bool smethod_2(Control control_0, ControlStyles controlStyles_0, bool bool_0)
		{
			int num = 2;
			if (control_0 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			try
			{
				MethodInfo method = control_0.GetType().GetMethod("SetStyle", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (method != null && method.DeclaringType.Equals(typeof(Control)))
				{
					ParameterInfo[] parameters = method.GetParameters();
					if (parameters != null && parameters.Length == 2 && parameters[0].ParameterType.Equals(typeof(ControlStyles)) && parameters[1].ParameterType.Equals(typeof(bool)))
					{
						method.Invoke(control_0, new object[2]
						{
							controlStyles_0,
							bool_0
						});
						return true;
					}
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			return false;
		}

		public static List<Control> smethod_3(Control control_0)
		{
			int num = 18;
			if (control_0 == null)
			{
				throw new ArgumentNullException("rootControl");
			}
			List<Control> list = new List<Control>();
			smethod_4(control_0, list);
			return list;
		}

		private static void smethod_4(Control control_0, List<Control> list_0)
		{
			foreach (Control control in control_0.Controls)
			{
				if (control != null)
				{
					list_0.Add(control);
					if (control.Controls != null)
					{
						smethod_4(control, list_0);
					}
				}
			}
		}

		public static Rectangle smethod_5(object object_0, object object_1)
		{
			int num = 14;
			Point p;
			if (object_0 is Control)
			{
				Control control = (Control)object_0;
				p = new Point(0, 0);
				p = control.PointToScreen(p);
				return new Rectangle(p.X, p.Y, control.Width, control.Height);
			}
			if (object_0 is ToolStripButton)
			{
				ToolStripButton toolStripButton = (ToolStripButton)object_0;
				Control control = toolStripButton.GetCurrentParent();
				p = new Point(toolStripButton.Bounds.Left, toolStripButton.Bounds.Top);
				p = control.PointToScreen(p);
				return new Rectangle(p.X, p.Y, toolStripButton.Width, toolStripButton.Height);
			}
			if (object_1 != null && object_1.GetType().FullName == "DevExpress.XtraBars.ItemClickEventArgs")
			{
				object propertyValueMultiLayer = ValueTypeHelper.GetPropertyValueMultiLayer(object_1, "Link.ScreenBounds", null, throwExecption: false);
				if (propertyValueMultiLayer is Rectangle)
				{
					return (Rectangle)propertyValueMultiLayer;
				}
			}
			return Rectangle.Empty;
		}

		public static bool smethod_6(object object_0, bool bool_0)
		{
			int num = 14;
			if (object_0 == null)
			{
				return false;
			}
			if (object_0 is Control)
			{
				((Control)object_0).Visible = bool_0;
				return true;
			}
			if (object_0 is ToolStripItem)
			{
				((ToolStripItem)object_0).Visible = bool_0;
				return true;
			}
			if (ValueTypeHelper.SetPropertyValue(object_0, "Visible", bool_0, throwException: false))
			{
				return true;
			}
			return false;
		}

		public static bool smethod_7(object object_0, bool bool_0)
		{
			int num = 8;
			if (object_0 == null)
			{
				return false;
			}
			if (object_0 is Control)
			{
				((Control)object_0).Enabled = bool_0;
				return true;
			}
			if (object_0 is ToolStripItem)
			{
				((ToolStripItem)object_0).Enabled = bool_0;
				return true;
			}
			if (ValueTypeHelper.SetPropertyValue(object_0, "Enabled", bool_0, throwException: false))
			{
				return true;
			}
			return false;
		}

		public static IList smethod_8(object object_0)
		{
			int num = 8;
			if (object_0 == null)
			{
				return null;
			}
			if (object_0 is ComboBox)
			{
				return ((ComboBox)object_0).Items;
			}
			if (object_0 is ToolStripComboBox)
			{
				return ((ToolStripComboBox)object_0).Items;
			}
			if (object_0 is ListBox)
			{
				return ((ListBox)object_0).Items;
			}
			Type type = object_0.GetType();
			while (true)
			{
				if (type != null && !type.Equals(typeof(object)))
				{
					if (type.FullName == "DevExpress.XtraBars.BarEditItem")
					{
						break;
					}
					type = type.BaseType;
					continue;
				}
				return null;
			}
			object propertyValueMultiLayer = ValueTypeHelper.GetPropertyValueMultiLayer(object_0, "Edit.Items", null, throwExecption: false);
			if (propertyValueMultiLayer is IList)
			{
				return (IList)propertyValueMultiLayer;
			}
			return null;
		}

		public static bool smethod_9(IList ilist_0, object object_0)
		{
			int num = 11;
			if (ilist_0 == null)
			{
				return false;
			}
			if (ilist_0.GetType().Name == "ImageComboBoxItemCollection")
			{
				MethodInfo method = ilist_0.GetType().GetMethod("GetItem", BindingFlags.IgnoreCase | BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
				if (method != null)
				{
					Type returnType = method.ReturnType;
					object obj = Activator.CreateInstance(returnType);
					ValueTypeHelper.SetPropertyValue(obj, "Value", object_0, throwException: false);
					ValueTypeHelper.SetPropertyValue(obj, "Description", object_0, throwException: false);
					ilist_0.Add(obj);
					return true;
				}
			}
			ilist_0.Add(object_0);
			return true;
		}

		public static bool smethod_10(object object_0, object object_1)
		{
			int num = 6;
			if (object_0 == null)
			{
				return false;
			}
			if (object_0 is ComboBox)
			{
				((ComboBox)object_0).Items.Add(object_1);
				return true;
			}
			if (object_0 is ToolStripComboBox)
			{
				((ToolStripComboBox)object_0).Items.Add(object_1);
				return true;
			}
			if (object_0 is ListBox)
			{
				((ListBox)object_0).Items.Add(object_1);
				return true;
			}
			Type type = object_0.GetType();
			while (true)
			{
				if (type != null && !type.Equals(typeof(object)))
				{
					if (type.FullName == "DevExpress.XtraBars.BarEditItem")
					{
						break;
					}
					type = type.BaseType;
					continue;
				}
				return false;
			}
			object propertyValue = ValueTypeHelper.GetPropertyValue(object_0, "Edit", throwException: false);
			if (propertyValue != null)
			{
				object propertyValue2 = ValueTypeHelper.GetPropertyValue(propertyValue, "Items", throwException: false);
				if (propertyValue2 is IList)
				{
					((IList)propertyValue2).Add(object_1);
					return true;
				}
			}
			return false;
		}

		public static bool smethod_11(object object_0, object object_1)
		{
			int num = 15;
			if (object_0 == null)
			{
				return false;
			}
			if (object_0 is TextBox)
			{
				((TextBox)object_0).Text = ((object_1 == null) ? "" : object_1.ToString());
				return true;
			}
			if (object_0 is ComboBox)
			{
				if (object_1 is string)
				{
					((ComboBox)object_0).Text = (string)object_1;
				}
				else
				{
					((ComboBox)object_0).SelectedItem = object_1;
				}
				return true;
			}
			if (object_0 is ListBox)
			{
				if (object_1 is string)
				{
					((ListBox)object_0).Text = (string)object_1;
				}
				else
				{
					((ListBox)object_0).SelectedItem = object_1;
				}
				return true;
			}
			if (object_0 is ToolStripTextBox)
			{
				((ToolStripTextBox)object_0).Text = ((object_1 == null) ? "" : object_1.ToString());
				return true;
			}
			if (object_0 is ToolStripComboBox)
			{
				if (object_1 is string)
				{
					((ToolStripComboBox)object_0).Text = (string)object_1;
				}
				else
				{
					((ToolStripComboBox)object_0).SelectedItem = object_1;
				}
				return true;
			}
			Type type = object_0.GetType();
			while (true)
			{
				if (type != null && !type.Equals(typeof(object)))
				{
					if (type.FullName == "DevExpress.XtraBars.BarEditItem")
					{
						break;
					}
					type = type.BaseType;
					continue;
				}
				return false;
			}
			return ValueTypeHelper.SetPropertyValue(object_0, "EditValue", object_1, throwException: false);
		}

		public static object smethod_12(object object_0)
		{
			int num = 4;
			if (object_0 == null)
			{
				return null;
			}
			if (object_0 is TextBox)
			{
				return ((TextBox)object_0).Text;
			}
			if (object_0 is Button)
			{
				return ((Button)object_0).Text;
			}
			if (object_0 is ComboBox)
			{
				ComboBox comboBox = (ComboBox)object_0;
				if (comboBox.SelectedValue != null)
				{
					return comboBox.SelectedValue;
				}
				if (comboBox.SelectedItem != null)
				{
					return comboBox.SelectedItem;
				}
				return comboBox.Text;
			}
			if (object_0 is ToolStripComboBox)
			{
				ToolStripComboBox toolStripComboBox = (ToolStripComboBox)object_0;
				if (toolStripComboBox.SelectedItem != null)
				{
					return toolStripComboBox.SelectedItem;
				}
				return toolStripComboBox.Text;
			}
			if (object_0 is ToolStripTextBox)
			{
				return ((ToolStripTextBox)object_0).Text;
			}
			Type type = object_0.GetType();
			while (true)
			{
				if (type != null && !type.Equals(typeof(object)))
				{
					if (type.FullName == "DevExpress.XtraBars.BarEditItem")
					{
						break;
					}
					type = type.BaseType;
					continue;
				}
				return null;
			}
			return ValueTypeHelper.GetPropertyValue(object_0, "EditValue", throwException: false);
		}

		public static bool smethod_13(object object_0)
		{
			int num = 7;
			if (object_0 == null)
			{
				return false;
			}
			if (object_0 is ToolStripButton)
			{
				ToolStripButton toolStripButton = (ToolStripButton)object_0;
				return toolStripButton.Checked;
			}
			if (object_0 is ToolStripMenuItem)
			{
				ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)object_0;
				return toolStripMenuItem.Checked;
			}
			if (object_0 is CheckBox)
			{
				CheckBox checkBox = (CheckBox)object_0;
				return checkBox.Checked;
			}
			if (object_0 is RadioButton)
			{
				RadioButton radioButton = (RadioButton)object_0;
				return radioButton.Checked;
			}
			if (object_0 is MenuItem)
			{
				return ((MenuItem)object_0).Checked;
			}
			Type type = object_0.GetType();
			object propertyValue;
			while (true)
			{
				if (type != null && !type.Equals(typeof(object)))
				{
					if (type.FullName == "DevExpress.XtraBars.BarBaseButtonItem")
					{
						propertyValue = ValueTypeHelper.GetPropertyValue(object_0, "Down", throwException: false);
						if (propertyValue is bool)
						{
							break;
						}
					}
					type = type.BaseType;
					continue;
				}
				return false;
			}
			return (bool)propertyValue;
		}

		public static bool smethod_14(object object_0, bool bool_0)
		{
			int num = 18;
			if (object_0 == null)
			{
				return false;
			}
			if (object_0 is ToolStripButton)
			{
				ToolStripButton toolStripButton = (ToolStripButton)object_0;
				toolStripButton.Checked = bool_0;
				return true;
			}
			if (object_0 is ToolStripMenuItem)
			{
				ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)object_0;
				toolStripMenuItem.Checked = bool_0;
				return true;
			}
			if (object_0 is CheckBox)
			{
				CheckBox checkBox = (CheckBox)object_0;
				checkBox.Checked = bool_0;
				return true;
			}
			if (object_0 is RadioButton)
			{
				RadioButton radioButton = (RadioButton)object_0;
				radioButton.Checked = bool_0;
				return true;
			}
			if (object_0 is MenuItem)
			{
				((MenuItem)object_0).Checked = bool_0;
				return true;
			}
			Type type = object_0.GetType();
			while (true)
			{
				if (type != null && !type.Equals(typeof(object)))
				{
					if (type.FullName == "DevExpress.XtraBars.BarBaseButtonItem")
					{
						break;
					}
					type = type.BaseType;
					continue;
				}
				return false;
			}
			return ValueTypeHelper.SetPropertyValue(object_0, "Down", bool_0, throwException: false);
		}

		/// <summary>
		///       填充枚举文本到列表控件中
		///       </summary>
		/// <param name="enumType">枚举类型</param>
		/// <param name="ctl">控件</param>
		public static void FillEnumValuesToComboBox(Type enumType, ComboBox comboBox_0)
		{
			int num = 10;
			if (enumType == null)
			{
				throw new ArgumentNullException("enumType");
			}
			if (!enumType.IsEnum)
			{
				throw new ArgumentException(enumType.FullName + "不是枚举类型");
			}
			if (comboBox_0 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			Array values = Enum.GetValues(enumType);
			foreach (object item in values)
			{
				comboBox_0.Items.Add(item);
			}
		}

		/// <summary>
		///       填充枚举文本到列表控件中
		///       </summary>
		/// <param name="enumType">枚举类型</param>
		/// <param name="ctl">控件</param>
		/// <param name="sort">是否排序</param>
		public static void FillEnumValuesToListBox(Type enumType, ListBox listBox_0)
		{
			int num = 5;
			if (enumType == null)
			{
				throw new ArgumentNullException("enumType");
			}
			if (!enumType.IsEnum)
			{
				throw new ArgumentException(enumType.FullName + "不是枚举类型");
			}
			if (listBox_0 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			Array values = Enum.GetValues(enumType);
			foreach (object item in values)
			{
				listBox_0.Items.Add(item);
			}
		}

		/// <summary>
		///       填充枚举文本到列表控件中
		///       </summary>
		/// <param name="enumType">枚举类型</param>
		/// <param name="ctl">控件</param>
		/// <param name="sort">是否排序</param>
		public static void FillEnumNamesToComboBox(Type enumType, ComboBox comboBox_0, bool sort)
		{
			int num = 5;
			if (enumType == null)
			{
				throw new ArgumentNullException("enumType");
			}
			if (!enumType.IsEnum)
			{
				throw new ArgumentException(enumType.FullName + "不是枚举类型");
			}
			if (comboBox_0 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			List<string> list = new List<string>(Enum.GetNames(enumType));
			if (sort)
			{
				list.Sort();
			}
			comboBox_0.Items.AddRange(list.ToArray());
		}

		/// <summary>
		///       填充枚举文本到列表控件中
		///       </summary>
		/// <param name="enumType">枚举类型</param>
		/// <param name="ctl">控件</param>
		/// <param name="sort">是否排序</param>
		public static void FillEnumNamesToListBox(Type enumType, ListBox listBox_0, bool sort)
		{
			int num = 16;
			if (enumType == null)
			{
				throw new ArgumentNullException("enumType");
			}
			if (!enumType.IsEnum)
			{
				throw new ArgumentException(enumType.FullName + "不是枚举类型");
			}
			if (listBox_0 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			List<string> list = new List<string>(Enum.GetNames(enumType));
			if (sort)
			{
				list.Sort();
			}
			listBox_0.Items.AddRange(list.ToArray());
		}

		public static void SetNodesMultiLayerIndexs(TreeNodeCollection rootNodes)
		{
			smethod_15(rootNodes, "");
		}

		private static void smethod_15(TreeNodeCollection treeNodeCollection_0, string string_0)
		{
			int num = 12;
			int num2 = 0;
			foreach (TreeNode item in treeNodeCollection_0)
			{
				num2++;
				string text = string_0 + num2 + ".";
				if (item.Text == null || !item.Text.StartsWith(text))
				{
					item.Text = text + item.Text;
				}
				if (item.Nodes.Count > 0)
				{
					smethod_15(item.Nodes, text);
				}
			}
		}

		public static string smethod_16(Message message_0)
		{
			Msgs msg = (Msgs)message_0.Msg;
			return msg.ToString() + " HWnd:" + message_0.HWnd + " WParam:" + message_0.WParam + "  LParam:" + message_0.LParam;
		}

		/// <summary>
		///       获得被勾选的节点
		///       </summary>
		/// <param name="tvw">
		/// </param>
		/// <returns>
		/// </returns>
		public static List<TreeNode> GetCheckedNodes(TreeView treeView_0)
		{
			int num = 19;
			if (treeView_0 == null)
			{
				throw new ArgumentNullException("tvw");
			}
			List<TreeNode> list = new List<TreeNode>();
			smethod_17(treeView_0.Nodes, list);
			return list;
		}

		private static void smethod_17(TreeNodeCollection treeNodeCollection_0, List<TreeNode> list_0)
		{
			foreach (TreeNode item in treeNodeCollection_0)
			{
				if (item.Checked)
				{
					list_0.Add(item);
				}
				if (item.Nodes != null)
				{
					smethod_17(item.Nodes, list_0);
				}
			}
		}

		/// <summary>
		///       延时让控件获得焦点
		///       </summary>
		/// <param name="ctl">控件</param>
		/// <param name="millisecend">延时的毫秒数</param>
		public static void DelayFocus(Control control_0, int millisecend)
		{
			if (control_0 != null)
			{
				RunOnceDelay(delegate
				{
					control_0.Focus();
				}, millisecend);
			}
		}

		/// <summary>
		///       延时执行一次
		///       </summary>
		/// <param name="callBack">执行的委托对象</param>
		/// <param name="millisecend">延时的毫秒数</param>
		public static void RunOnceDelay(EventHandler callBack, int millisecend)
		{
			int num = 1;
			if (callBack == null)
			{
				throw new ArgumentNullException("callBack");
			}
			Timer timer = new Timer();
			timer.Interval = millisecend;
			timer.Tag = callBack;
			timer.Tick += smethod_18;
			timer.Start();
		}

		private static void smethod_18(object sender, EventArgs e)
		{
			Timer timer = (Timer)sender;
			timer.Stop();
			timer.Dispose();
			(timer.Tag as EventHandler)?.Invoke(null, null);
		}

		/// <summary>
		///       检测指定句柄的控件是否发生了鼠标拖拽操作
		///       </summary>
		/// <param name="hwnd">句柄对象</param>
		/// <returns>是否有拖拽操作</returns>
		public static bool DragDetect(IntPtr hwnd)
		{
			return MouseCapturer.DragDetect(hwnd);
		}

		/// <summary>
		///       从系统剪切板中获得图片数据
		///       </summary>
		/// <returns>
		/// </returns>
		public static XImageValue GetImageFromClipboard()
		{
			int num = 10;
			IDataObject dataObject = Clipboard.GetDataObject();
			GClass335 gClass = new GClass335(dataObject);
			if (gClass.method_4())
			{
				Image image_ = gClass.method_5();
				return new XImageValue(image_);
			}
			if (gClass.method_16())
			{
				string[] array = gClass.method_17();
				string[] array2 = array;
				foreach (string text in array2)
				{
					if (text.EndsWith(".jpg", StringComparison.CurrentCultureIgnoreCase) || text.EndsWith(".jpeg", StringComparison.CurrentCultureIgnoreCase) || text.EndsWith(".png", StringComparison.CurrentCultureIgnoreCase) || text.EndsWith(".gif", StringComparison.CurrentCultureIgnoreCase))
					{
						return new XImageValue(text);
					}
				}
			}
			return null;
		}

		public static GEnum65 GetApplicationStyle(Control control_0)
		{
			int num = 6;
			try
			{
				int num2 = 0;
				Control control = control_0;
				while (true)
				{
					if (control == null)
					{
						if (control_0 != null && control_0.IsHandleCreated)
						{
							for (GClass244 gClass = new GClass244(control_0.Handle); gClass != null; gClass = gClass.method_23())
							{
								string text = gClass.method_2();
								if (text != null && text.IndexOf("Internet Explorer", StringComparison.CurrentCultureIgnoreCase) >= 0)
								{
									return GEnum65.const_2;
								}
							}
						}
						if (num2 == 1)
						{
							return GEnum65.const_3;
						}
						return GEnum65.const_4;
					}
					if (control is Form)
					{
						return GEnum65.const_0;
					}
					if (control.GetType().FullName == "System.Windows.Forms.Integration.WinFormsAdapter")
					{
						break;
					}
					control = control.Parent;
					num2++;
				}
				return GEnum65.const_1;
			}
			catch
			{
				return GEnum65.const_4;
			}
		}
	}
}
