using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer
{
	/// <summary>
	///       查询辅助录入使用的列表项目事件参数
	///       </summary>
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("9CFCD4DB-9E8E-47D7-A63C-6DD4FE1E52D6", "3009CECC-4947-48D0-81D5-E94E5DDF77C6")]
	
	[DocumentComment]
	[ComDefaultInterface(typeof(IWriterQueryAssistInputItemsEventArgs))]
	[ComVisible(true)]
	[Guid("9CFCD4DB-9E8E-47D7-A63C-6DD4FE1E52D6")]
	public class WriterQueryAssistInputItemsEventArgs : WriterEventArgs, IWriterQueryAssistInputItemsEventArgs
	{
		internal new const string CLASSID = "9CFCD4DB-9E8E-47D7-A63C-6DD4FE1E52D6";

		internal new const string CLASSID_Interface = "3009CECC-4947-48D0-81D5-E94E5DDF77C6";

		[NonSerialized]
		private XTextContainerElement _ContainerElement = null;

		private List<string> _Items = new List<string>();

		private string _PreWord = null;

		private bool _Cancel = false;

		/// <summary>
		///       插入点所在的容器元素
		///       </summary>
		[XmlIgnore]
		
		public XTextContainerElement ContainerElement => _ContainerElement;

		/// <summary>
		///       字符串列表项目
		///       </summary>
		[XmlIgnore]
		[ComVisible(false)]
		
		public List<string> Items
		{
			get
			{
				if (_Items == null)
				{
					_Items = new List<string>();
				}
				return _Items;
			}
			set
			{
				_Items = value;
			}
		}

		/// <summary>
		///       字符串个数
		///       </summary>
		
		[XmlIgnore]
		public int Count => Items.Count;

		/// <summary>
		///       检测用的前置文本
		///       </summary>
		[XmlElement]
		[DefaultValue(null)]
		
		public string PreWord
		{
			get
			{
				return _PreWord;
			}
			set
			{
				_PreWord = value;
			}
		}

		/// <summary>
		///       用户取消操作
		///       </summary>
		[DefaultValue(null)]
		
		[XmlElement]
		public bool Cancel
		{
			get
			{
				return _Cancel;
			}
			set
			{
				_Cancel = value;
			}
		}

		
		public WriterQueryAssistInputItemsEventArgs(WriterControl writerControl_0, XTextDocument document, XTextContainerElement containerElement, string preWord, List<string> items)
			: base(writerControl_0, document, containerElement)
		{
			_ContainerElement = containerElement;
			_PreWord = preWord;
			_Items = items;
			if (_Items == null)
			{
				_Items = new List<string>();
			}
		}

		/// <summary>
		///       获得字符串
		///       </summary>
		/// <param name="index">
		/// </param>
		/// <returns>
		/// </returns>
		
		public string GetItem(int index)
		{
			return Items[index];
		}

		/// <summary>
		///       添加字符串
		///       </summary>
		/// <param name="item">
		/// </param>
		
		public void AddItem(string item)
		{
			Items.Add(item);
		}
	}
}
