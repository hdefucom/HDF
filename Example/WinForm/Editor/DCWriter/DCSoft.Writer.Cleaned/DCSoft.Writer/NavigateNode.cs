using DCSoft.Common;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace DCSoft.Writer
{
	/// <summary>
	///       导航节点对象
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComDefaultInterface(typeof(INavigateNode))]
	
	[Guid("46A44BC6-CF39-466D-B3EC-90FD812F103C")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	[ComClass("46A44BC6-CF39-466D-B3EC-90FD812F103C", "2B8A0CD5-CF6B-4EEF-BA74-E4C62D39D469")]
	
	public class NavigateNode : INavigateNode
	{
		internal const string CLASSID = "46A44BC6-CF39-466D-B3EC-90FD812F103C";

		internal const string CLASSID_Interface = "2B8A0CD5-CF6B-4EEF-BA74-E4C62D39D469";

		internal string _ID = null;

		private string _Text = null;

		private int _Level = 0;

		private XTextElementList _Elements = new XTextElementList();

		private NavigateNodeList _Nodes = null;

		/// <summary>
		///       节点唯一编号
		///       </summary>
		[XmlAttribute]
		
		public string ID
		{
			get
			{
				if (_Elements != null && _Elements.Count > 0)
				{
					return _Elements[0].ElementInstanceIndex.ToString();
				}
				return _ID;
			}
		}

		/// <summary>
		///       标题
		///       </summary>
		
		[XmlAttribute]
		public string Text
		{
			get
			{
				if (_Text == null && _Elements != null && _Elements.Count > 0)
				{
					StringBuilder stringBuilder = new StringBuilder();
					foreach (XTextElement element in _Elements)
					{
						if (element is XTextCharElement)
						{
							stringBuilder.Append(((XTextCharElement)element).CharValue);
						}
					}
					_Text = stringBuilder.ToString();
				}
				return _Text;
			}
		}

		/// <summary>
		///       层次
		///       </summary>
		
		[XmlAttribute]
		public int Level
		{
			get
			{
				return _Level;
			}
			set
			{
				_Level = value;
			}
		}

		/// <summary>
		///       在文档中的开始位置
		///       </summary>
		[XmlAttribute]
		
		public int Position
		{
			get
			{
				if (_Elements != null && _Elements.Count > 0)
				{
					return _Elements[0].ViewIndex;
				}
				return -1;
			}
		}

		/// <summary>
		///       区域的开始位置元素内容序号
		///       </summary>
		
		[XmlAttribute]
		public int StartContentIndex
		{
			get
			{
				if (_Elements != null && _Elements.Count > 0)
				{
					return _Elements[0].ViewIndex;
				}
				return -1;
			}
		}

		/// <summary>
		///       区域的结束位置元素内容序号
		///       </summary>
		[XmlAttribute]
		
		public int EndContentIndex
		{
			get
			{
				if (_Elements != null && _Elements.Count > 0)
				{
					return _Elements.LastElement.ViewIndex;
				}
				return -1;
			}
		}

		/// <summary>
		///       引用的对象
		///       </summary>
		[XmlIgnore]
		
		public XTextElementList Elements
		{
			get
			{
				return _Elements;
			}
			set
			{
				_Elements = value;
			}
		}

		/// <summary>
		///       子节点列表
		///       </summary>
		
		[XmlArrayItem("Node", typeof(NavigateNode))]
		[DefaultValue(null)]
		public NavigateNodeList Nodes
		{
			get
			{
				if (_Nodes == null)
				{
					_Nodes = new NavigateNodeList();
				}
				return _Nodes;
			}
			set
			{
				_Nodes = value;
			}
		}

		/// <summary>
		///       判断是否存在子节点
		///       </summary>
		[XmlIgnore]
		
		public bool HasChildNode => _Nodes != null && _Nodes.Count > 0;

		/// <summary>
		///       初始化对象
		///       </summary>
		public NavigateNode(string string_0)
		{
			_ID = string_0;
		}

		internal void AppendElement(XTextElement element)
		{
			if (_Elements == null)
			{
				_Elements = new XTextElementList();
			}
			_Elements.Add(element);
			_Text = null;
		}

		/// <summary>
		///       添加子节点
		///       </summary>
		/// <param name="node">子节点对象</param>
		internal void AppendNode(NavigateNode node)
		{
			if (_Nodes == null)
			{
				_Nodes = new NavigateNodeList();
			}
			_Nodes.Add(node);
		}

		public override string ToString()
		{
			return "ID=" + ID + " Level=" + Level + " Position=" + Position + " Text=" + Text;
		}
	}
}
