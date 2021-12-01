using DCSoft.Common;
using DCSoft.Writer.Commands;
using DCSoft.Writer.Dom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       上下文快捷菜单管理器
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[DCPublishAPI]
	[ComVisible(false)]
	[DocumentComment]
	public class ContextMenuStripManager : IContextMenuStripManager
	{
		private WriterControl _Control = null;

		private bool _Enabled = true;

		private Dictionary<Type, ContextMenuStrip> dictionary_0 = new Dictionary<Type, ContextMenuStrip>();

		/// <summary>
		///       编辑器控件对象
		///       </summary>
		public WriterControl Control
		{
			get
			{
				return _Control;
			}
			set
			{
				_Control = value;
			}
		}

		/// <summary>
		///       对象是否可用
		///       </summary>
		public bool Enabled
		{
			get
			{
				return _Enabled;
			}
			set
			{
				_Enabled = value;
			}
		}

		/// <summary>
		///       内部的保存的菜单个数
		///       </summary>
		public int Count => dictionary_0.Count;

		/// <summary>
		///       默认菜单
		///       </summary>
		public ContextMenuStrip DefaultMenu
		{
			get
			{
				return GetMenu(typeof(XTextElement));
			}
			set
			{
				SetMenu(typeof(XTextElement), value);
			}
		}

		/// <summary>
		///       单元格菜单
		///       </summary>
		public ContextMenuStrip TableCellMenu
		{
			get
			{
				return GetMenu(typeof(XTextTableCellElement));
			}
			set
			{
				SetMenu(typeof(XTextTableCellElement), value);
			}
		}

		/// <summary>
		///       输入域菜单
		///       </summary>
		public ContextMenuStrip InputFieldMenu
		{
			get
			{
				return GetMenu(typeof(XTextInputFieldElement));
			}
			set
			{
				SetMenu(typeof(XTextInputFieldElement), value);
			}
		}

		/// <summary>
		///       图片菜单
		///       </summary>
		public ContextMenuStrip ImageMenu
		{
			get
			{
				return GetMenu(typeof(XTextImageElement));
			}
			set
			{
				SetMenu(typeof(XTextImageElement), value);
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public ContextMenuStripManager(WriterControl writerControl_0)
		{
			_Control = writerControl_0;
		}

		/// <summary>
		///       向文档元素快键菜单添加一个分隔条
		///       </summary>
		/// <param name="elementType">文档元素类型</param>
		/// <returns>分隔条对象</returns>
		public ToolStripSeparator AddContextMenuSeparator(Type elementType)
		{
			int num = 15;
			if (elementType == null)
			{
				throw new ArgumentNullException("elementType");
			}
			ContextMenuStrip menuWithCreation = GetMenuWithCreation(elementType);
			ToolStripSeparator toolStripSeparator = new ToolStripSeparator();
			menuWithCreation.Items.Add(toolStripSeparator);
			return toolStripSeparator;
		}

		public void ClearContextMenuItems(Type elementType)
		{
			int num = 15;
			if (elementType == null)
			{
				throw new ArgumentNullException("elementType");
			}
			if (dictionary_0.ContainsKey(elementType))
			{
				ContextMenuStrip contextMenuStrip = dictionary_0[elementType];
				dictionary_0.Remove(elementType);
				contextMenuStrip.Dispose();
			}
		}

		public void RemoveContextMenuItem(Type elementType, string name)
		{
			int num = 1;
			if (elementType == null)
			{
				throw new ArgumentNullException("elementType");
			}
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException("name");
			}
			ContextMenuStrip menuWithCreation = GetMenuWithCreation(elementType);
			foreach (ToolStripMenuItem item in menuWithCreation.Items)
			{
				if (item.Name == name)
				{
					menuWithCreation.Items.Remove(item);
					break;
				}
			}
		}

		/// <summary>
		///       添加快键菜单
		///       </summary>
		/// <param name="elementType">文档元素类型</param>
		/// <param name="name">菜单项目名称</param>
		/// <param name="commandName">编辑器命令名</param>
		/// <param name="text">文本</param>
		/// <param name="iconBase64String">图标</param>
		/// <param name="clickHandler">菜单点击事件处理委托</param>
		/// <returns>生成的菜单项目对象</returns>
		public ToolStripMenuItem AddContextMenuItem(Type elementType, string name, string commandName, string text, string iconBase64String, EventHandler clickHandler)
		{
			int num = 19;
			if (elementType == null)
			{
				throw new ArgumentNullException("elementType");
			}
			ContextMenuStrip menuWithCreation = GetMenuWithCreation(elementType);
			if (string.IsNullOrEmpty(text) || text == "-")
			{
				ToolStripSeparator toolStripSeparator = new ToolStripSeparator();
				toolStripSeparator.Name = name;
				menuWithCreation.Items.Add(toolStripSeparator);
				return null;
			}
			if (string.IsNullOrEmpty(commandName) && clickHandler == null)
			{
				throw new ArgumentNullException("commandName和clickHandler之间必须有一个不为空");
			}
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
			toolStripMenuItem.Text = text;
			toolStripMenuItem.Name = name;
			toolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
			if (!string.IsNullOrEmpty(iconBase64String))
			{
				byte[] buffer = Convert.FromBase64String(iconBase64String);
				MemoryStream stream = new MemoryStream(buffer);
				Image image2 = toolStripMenuItem.Image = Image.FromStream(stream);
			}
			if (clickHandler != null)
			{
				toolStripMenuItem.Click += clickHandler;
			}
			else if (!string.IsNullOrEmpty(commandName))
			{
				Control.CommandControler.SetCommandNameAndBindgEvent(toolStripMenuItem, commandName);
				if (toolStripMenuItem.Image == null)
				{
					WriterCommand commandRaw = Control.CommandControler.CommandContainer.GetCommandRaw(commandName);
					if (commandRaw != null)
					{
						toolStripMenuItem.Image = commandRaw.ToolbarImage;
					}
				}
			}
			menuWithCreation.Items.Add(toolStripMenuItem);
			return toolStripMenuItem;
		}

		private ContextMenuStrip GetMenuWithCreation(Type type_0)
		{
			if (dictionary_0.ContainsKey(type_0))
			{
				return dictionary_0[type_0];
			}
			ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
			dictionary_0[type_0] = contextMenuStrip;
			contextMenuStrip.Opening += menu_Opening;
			return contextMenuStrip;
		}

		private void menu_Opening(object sender, CancelEventArgs e)
		{
			ContextMenuStrip contextMenuStrip = (ContextMenuStrip)sender;
			foreach (ToolStripItem item in contextMenuStrip.Items)
			{
				if (item is ToolStripMenuItem)
				{
					Control.CommandControler.UpdateBindingControlStatus(item);
				}
			}
		}

		/// <summary>
		///       设置快捷菜单
		///       </summary>
		/// <param name="elementType">文档元素类型</param>
		/// <param name="menu">菜单对象</param>
		public void SetMenu(Type elementType, ContextMenuStrip menu)
		{
			int num = 7;
			if (elementType == null)
			{
				throw new ArgumentNullException("elementType");
			}
			if (!typeof(XTextElement).IsAssignableFrom(elementType))
			{
				throw new ArgumentException(elementType.FullName);
			}
			if (dictionary_0.ContainsKey(elementType))
			{
				dictionary_0.Remove(elementType);
			}
			if (menu != null)
			{
				dictionary_0[elementType] = menu;
			}
		}

		/// <summary>
		///       获得指定文档元素类型使用的快捷菜单
		///       </summary>
		/// <param name="elementType">文档元素类型</param>
		/// <returns>获得的快捷菜单</returns>
		[DCInternal]
		public ContextMenuStrip GetMenu(Type elementType)
		{
			int num = 18;
			if (!Enabled)
			{
				return null;
			}
			if (elementType == null)
			{
				throw new ArgumentNullException("elementType");
			}
			if (!typeof(XTextElement).IsAssignableFrom(elementType))
			{
				throw new ArgumentException(elementType.FullName);
			}
			if (dictionary_0.ContainsKey(elementType))
			{
				return dictionary_0[elementType];
			}
			if (dictionary_0.ContainsKey(typeof(XTextElement)))
			{
				return dictionary_0[typeof(XTextElement)];
			}
			return null;
		}

		/// <summary>
		///       创建快捷菜单
		///       </summary>
		/// <param name="commandNamesTexts">命令文本数组，偶数为命令名称，奇数为菜单文本</param>
		/// <returns>创建的快捷菜单对象</returns>
		[DCInternal]
		public ContextMenuStrip Build(string[] commandNamesTexts)
		{
			if (commandNamesTexts != null && commandNamesTexts.Length > 0)
			{
				ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
				for (int i = 0; i < commandNamesTexts.Length - 1; i += 2)
				{
					string text = commandNamesTexts[i];
					string text2 = commandNamesTexts[i + 1];
					WriterCommand commandRaw = Control.AppHost.CommandContainer.GetCommandRaw(text);
					if (commandRaw != null)
					{
						ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
						if (string.IsNullOrEmpty(text2))
						{
							toolStripMenuItem.Text = text;
						}
						else
						{
							toolStripMenuItem.Text = text2;
						}
						if (commandRaw.ToolbarImage != null)
						{
							toolStripMenuItem.Image = commandRaw.ToolbarImage;
						}
						Control.CommandControler.SetCommandName(toolStripMenuItem, text);
						contextMenuStrip.Items.Add(toolStripMenuItem);
					}
					else if (string.IsNullOrEmpty(text))
					{
						contextMenuStrip.Items.Add(new ToolStripSeparator());
					}
				}
				if (contextMenuStrip.Items.Count > 0)
				{
					return contextMenuStrip;
				}
				contextMenuStrip.Dispose();
			}
			return null;
		}

		/// <summary>
		///       根据控件状态返回当前快捷菜单
		///       </summary>
		/// <returns>
		/// </returns>
		[DCInternal]
		public ContextMenuStrip GetCurrentContextMenu()
		{
			if (!Enabled || dictionary_0.Count == 0 || Control == null)
			{
				return null;
			}
			if (Math.Abs(Control.Selection.Length) == 1)
			{
				XTextElement xTextElement = Control.Selection.ContentElements[0];
				if (xTextElement is XTextImageElement)
				{
					return ImageMenu;
				}
			}
			if (Control.Selection.Cells != null && Control.Selection.Cells.Count > 0)
			{
				return TableCellMenu;
			}
			XTextContainerElement container = null;
			int elementIndex = 0;
			Control.Document.Content.GetCurrentPositionInfo(out container, out elementIndex);
			if (container is XTextTableCellElement || container.OwnerCell != null)
			{
				return TableCellMenu;
			}
			for (XTextElement xTextElement2 = container; xTextElement2 != null; xTextElement2 = xTextElement2.Parent)
			{
				foreach (Type key in dictionary_0.Keys)
				{
					if (key.Equals(xTextElement2.GetType()))
					{
						return dictionary_0[key];
					}
				}
			}
			for (XTextElement xTextElement2 = container; xTextElement2 != null; xTextElement2 = xTextElement2.Parent)
			{
				foreach (Type key2 in dictionary_0.Keys)
				{
					if (key2.IsInstanceOfType(xTextElement2))
					{
						return dictionary_0[key2];
					}
				}
			}
			return DefaultMenu;
		}

		/// <summary>
		///       销毁对象
		///       </summary>
		public void Dispose()
		{
			Clear();
		}

		public void Clear()
		{
			foreach (ContextMenuStrip value in dictionary_0.Values)
			{
				value.Dispose();
			}
			dictionary_0.Clear();
		}
	}
}
