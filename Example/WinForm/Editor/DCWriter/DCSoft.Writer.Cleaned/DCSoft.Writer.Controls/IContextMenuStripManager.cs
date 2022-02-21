using DCSoft.Common;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       上下文快捷菜单管理器
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[DocumentComment]
	
	[ComVisible(false)]
	public interface IContextMenuStripManager : IDisposable
	{
		/// <summary>
		///       对象是否可用
		///       </summary>
		bool Enabled
		{
			get;
			set;
		}

		/// <summary>
		///       内部的保存的菜单个数
		///       </summary>
		int Count
		{
			get;
		}

		/// <summary>
		///       默认菜单
		///       </summary>
		ContextMenuStrip DefaultMenu
		{
			get;
			set;
		}

		/// <summary>
		///       单元格菜单
		///       </summary>
		ContextMenuStrip TableCellMenu
		{
			get;
			set;
		}

		/// <summary>
		///       输入域菜单
		///       </summary>
		ContextMenuStrip InputFieldMenu
		{
			get;
			set;
		}

		/// <summary>
		///       图片菜单
		///       </summary>
		ContextMenuStrip ImageMenu
		{
			get;
			set;
		}

		/// <summary>
		///       向文档元素快键菜单添加一个分隔条
		///       </summary>
		/// <param name="elementType">文档元素类型</param>
		/// <returns>分隔条对象</returns>
		ToolStripSeparator AddContextMenuSeparator(Type elementType);

		void ClearContextMenuItems(Type elementType);

		void RemoveContextMenuItem(Type elementType, string name);

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
		ToolStripMenuItem AddContextMenuItem(Type elementType, string name, string commandName, string text, string iconBase64String, EventHandler clickHandler);

		/// <summary>
		///       设置快捷菜单
		///       </summary>
		/// <param name="elementType">文档元素类型</param>
		/// <param name="menu">菜单对象</param>
		void SetMenu(Type elementType, ContextMenuStrip menu);

		/// <summary>
		///       获得指定文档元素类型使用的快捷菜单
		///       </summary>
		/// <param name="elementType">文档元素类型</param>
		/// <returns>获得的快捷菜单</returns>
		ContextMenuStrip GetMenu(Type elementType);

		/// <summary>
		///       创建快捷菜单
		///       </summary>
		/// <param name="commandNamesTexts">命令文本数组，偶数为命令名称，奇数为菜单文本</param>
		/// <returns>创建的快捷菜单对象</returns>
		ContextMenuStrip Build(string[] commandNamesTexts);

		/// <summary>
		///       根据控件状态返回当前快捷菜单
		///       </summary>
		/// <returns>
		/// </returns>
		ContextMenuStrip GetCurrentContextMenu();
	}
}
