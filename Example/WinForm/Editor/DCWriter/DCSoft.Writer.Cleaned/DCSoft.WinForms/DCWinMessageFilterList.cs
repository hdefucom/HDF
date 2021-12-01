using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.WinForms
{
	/// <summary>
	///       消息过滤器列表
	///       </summary>
	[ComVisible(false)]
	public class DCWinMessageFilterList : IMessageFilter
	{
		private List<IMessageFilter> _filters = new List<IMessageFilter>();

		public int Count => _filters.Count;

		/// <summary>
		///       附加消息过滤器，而且不重复添加
		///       </summary>
		/// <param name="filter">过滤器对象</param>
		/// <returns>
		/// </returns>
		public int Attach(IMessageFilter filter)
		{
			int num = 15;
			if (filter == null)
			{
				throw new ArgumentNullException("filter");
			}
			if (filter == this)
			{
				throw new InvalidOperationException("不能添加自己");
			}
			int num2 = _filters.IndexOf(filter);
			if (num2 >= 0)
			{
				return num2;
			}
			_filters.Add(filter);
			return _filters.Count - 1;
		}

		public void Remove(IMessageFilter filter)
		{
			int num = 8;
			if (filter == null)
			{
				throw new ArgumentNullException("filter");
			}
			int num2 = _filters.IndexOf(filter);
			if (num2 >= 0)
			{
				_filters.RemoveAt(num2);
			}
		}

		/// <summary>
		///       过滤消息
		///       </summary>
		/// <param name="m">消息对象</param>
		/// <returns>若处理的消息则返回true，无需后续处理。如果没过滤，则返回false表示需要后续处理。</returns>
		public bool PreFilterMessage(ref Message message_0)
		{
			List<IMessageFilter> list = new List<IMessageFilter>();
			int num = _filters.Count - 1;
			while (true)
			{
				if (num >= 0 && _filters.Count > 0)
				{
					if (num < _filters.Count)
					{
						IMessageFilter messageFilter = _filters[num];
						if (!list.Contains(messageFilter))
						{
							list.Add(messageFilter);
							if (messageFilter.PreFilterMessage(ref message_0))
							{
								break;
							}
						}
					}
					num--;
					continue;
				}
				return false;
			}
			return true;
		}
	}
}
