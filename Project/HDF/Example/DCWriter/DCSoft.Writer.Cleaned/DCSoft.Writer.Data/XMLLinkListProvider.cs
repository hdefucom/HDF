using DCSoft.Common;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;
using System.Xml;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       基于XML文档的联动列表提供者
	///       </summary>
	/// <remarks>
	///       本提供者对象对XML文件没有太多的要求，
	///       第一层列表的数据就是XML文档唯一的根节点的子节点，
	///       第二层列表的数据就是上级XML节点的子节点。
	///       XML元素名称无所谓，必须有Text属性，Value属性可选。
	///       本提供者输出的列表项目，其Text值就是对应的XML元素的Text属性值，若XML元素有Value属性
	///       则列表项目的Value值就是XML元素的Value属性值；否则为XML元素的Text属性值。
	///       本提供者内部会设置文档元素的LinkListBindingInfo.DataBoundItem为绑定的XML元素对象。
	///       </remarks>
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IXMLLinkListProvider))]
	[DCPublishAPI]
	[Guid("284D3F38-30EA-428B-B310-7E6C46270664")]
	[ComClass("284D3F38-30EA-428B-B310-7E6C46270664", "CEFF447F-988C-437C-BFB3-3E4725D186A1")]
	public class XMLLinkListProvider : LinkListProvider, IXMLLinkListProvider
	{
		internal const string string_0 = "284D3F38-30EA-428B-B310-7E6C46270664";

		internal const string string_1 = "CEFF447F-988C-437C-BFB3-3E4725D186A1";

		private XmlDocument xmlDocument_0 = null;

		/// <summary>
		///       初始化对象
		///       </summary>
		[DCPublishAPI]
		public XMLLinkListProvider()
		{
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="name">提供者名称</param>
		/// <param name="xmlFileName">XML文件名</param>
		[DCPublishAPI]
		public XMLLinkListProvider(string string_2, string string_3)
		{
			base.Name = string_2;
			xmlDocument_0 = new XmlDocument();
			xmlDocument_0.Load(string_3);
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="name">名称</param>
		/// <param name="doc">XML文档对象</param>
		[DCPublishAPI]
		public XMLLinkListProvider(string string_2, XmlDocument xmlDocument_1)
		{
			base.Name = string_2;
			xmlDocument_0 = xmlDocument_1;
		}

		/// <summary>
		///       加载XML文件
		///       </summary>
		/// <param name="fileName">文件名</param>
		[DCPublishAPI]
		public void LoadXMLDocument(string fileName)
		{
			xmlDocument_0 = new XmlDocument();
			xmlDocument_0.Load(fileName);
		}

		/// <summary>
		///       加载XML字符串
		///       </summary>
		/// <param name="xml">XML字符串</param>
		[DCPublishAPI]
		public void LoadXMLString(string string_2)
		{
			xmlDocument_0 = new XmlDocument();
			xmlDocument_0.LoadXml(string_2);
		}

		/// <summary>
		///       获得联动列表项目
		///       </summary>
		/// <param name="args">参数</param>
		[DCPublishAPI]
		public override void GetListItems(GetLinkListItemsEventArgs args)
		{
			int num = 15;
			XmlElement xmlElement = null;
			if (args.CurrentBinding.IsRoot)
			{
				xmlElement = xmlDocument_0.DocumentElement;
				args.CurrentBinding.DataBoundItem = xmlElement;
			}
			else
			{
				XmlElement xmlElement2 = args.ParentBinding.DataBoundItem as XmlElement;
				foreach (XmlNode childNode in xmlElement2.ChildNodes)
				{
					if (childNode is XmlElement)
					{
						XmlElement xmlElement3 = (XmlElement)childNode;
						string text = null;
						text = ((!xmlElement3.HasAttribute("Value")) ? xmlElement3.GetAttribute("Text") : xmlElement3.GetAttribute("Value"));
						if (text == args.ParentValue)
						{
							xmlElement = xmlElement3;
							break;
						}
					}
				}
			}
			args.CurrentBinding.DataBoundItem = xmlElement;
			if (xmlElement != null)
			{
				foreach (XmlNode childNode2 in xmlElement.ChildNodes)
				{
					if (childNode2 is XmlElement)
					{
						XmlElement xmlElement4 = (XmlElement)childNode2;
						ListItem listItem = new ListItem();
						listItem.Text = xmlElement4.GetAttribute("Text");
						if (xmlElement4.HasAttribute("Value"))
						{
							listItem.Value = xmlElement4.GetAttribute("Value");
						}
						else
						{
							listItem.Value = listItem.Text;
						}
						args.Items.Add(listItem);
					}
				}
				args.Handled = true;
			}
		}
	}
}
