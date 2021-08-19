using DCSoft.Common;
using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;

namespace DCSoft.WinForms
{
	/// <summary>
	///       WinForm控件的XML帮助类型
	///       </summary>
	[ComVisible(false)]
	public static class WinFormXMLHelper
	{
		public static void AddXMLDomTree(TreeView treeView_0, XmlNode rootNode, bool includeAttribute, bool includeElement)
		{
			AddXMLDomTreeNode(treeView_0.Nodes, rootNode, includeAttribute, includeElement);
		}

		public static void AddXMLDomTreeNode(TreeNodeCollection nodes, XmlNode rootNode, bool includeAttribute, bool includeElement)
		{
			int num = 12;
			TreeNode treeNode = new TreeNode(rootNode.LocalName);
			treeNode.Tag = rootNode;
			nodes.Add(treeNode);
			if (includeAttribute && rootNode.Attributes != null)
			{
				foreach (XmlAttribute attribute in rootNode.Attributes)
				{
					TreeNode treeNode2 = new TreeNode("@" + attribute.LocalName);
					treeNode2.Tag = attribute;
					treeNode.Nodes.Add(treeNode2);
				}
			}
			if (includeElement && rootNode.ChildNodes != null)
			{
				foreach (XmlNode childNode in rootNode.ChildNodes)
				{
					if (childNode is XmlElement)
					{
						AddXMLDomTreeNode(treeNode.Nodes, childNode, includeAttribute, includeElement);
					}
				}
			}
		}

		public static void ReadTreeViewContentFromXml(TreeView treeView_0, XmlReader reader)
		{
			int num = 3;
			if (treeView_0 == null)
			{
				throw new ArgumentNullException("tvw");
			}
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			XMLSerializeHelper.ReadAllAttributeValue(reader, treeView_0);
			reader.ReadStartElement();
			reader.MoveToContent();
			while (reader.NodeType != XmlNodeType.EndElement)
			{
				if (reader.NodeType == XmlNodeType.Element)
				{
					string localName = reader.LocalName;
					if (localName == "ImageList")
					{
						if (treeView_0.ImageList == null)
						{
							treeView_0.ImageList = new ImageList();
						}
						ReadImageListContentFromXml(treeView_0.ImageList, reader);
					}
					else if (localName == "Nodes")
					{
						ReadTreeNodeListContentFromXml(treeView_0.Nodes, reader);
					}
					else
					{
						XMLSerializeHelper.ReadSinglePropertyValue(reader, treeView_0);
					}
				}
				reader.MoveToContent();
			}
			reader.ReadEndElement();
		}

		public static void ReadTreeNodeListContentFromXml(TreeNodeCollection nodes, XmlReader reader)
		{
			int num = 13;
			reader.ReadStartElement();
			while (reader.NodeType != XmlNodeType.EndElement)
			{
				if (reader.NodeType == XmlNodeType.Element)
				{
					if (reader.LocalName == "Node")
					{
						TreeNode treeNode = new TreeNode();
						nodes.Add(treeNode);
						int depth = reader.Depth;
						XMLSerializeHelper.ReadAllAttributeValue(reader, treeNode);
						reader.ReadStartElement();
						if (reader.Depth <= depth)
						{
							continue;
						}
						while (reader.NodeType != XmlNodeType.EndElement)
						{
							if (reader.NodeType == XmlNodeType.Element)
							{
								if (reader.LocalName == "Nodes")
								{
									ReadTreeNodeListContentFromXml(treeNode.Nodes, reader);
								}
								else
								{
									reader.Read();
								}
							}
							reader.MoveToContent();
						}
						reader.ReadEndElement();
					}
					else
					{
						reader.Read();
					}
				}
				reader.MoveToContent();
			}
			reader.ReadEndElement();
		}

		public static void ReadImageListContentFromXml(ImageList list, XmlReader reader)
		{
			int num = 7;
			XMLSerializeHelper.ReadAllAttributeValue(reader, list);
			reader.ReadStartElement();
			while (reader.NodeType != XmlNodeType.EndElement)
			{
				if (reader.NodeType == XmlNodeType.Element)
				{
					string text = null;
					if (reader.LocalName == "Image")
					{
						text = reader.GetAttribute("Key");
						string text2 = reader.ReadString();
						if (!string.IsNullOrEmpty(text2))
						{
							byte[] buffer = Convert.FromBase64String(text2);
							MemoryStream stream = new MemoryStream(buffer);
							Image image = Image.FromStream(stream);
							list.Images.Add(text, image);
						}
					}
					reader.ReadEndElement();
				}
				reader.MoveToContent();
			}
			reader.ReadEndElement();
		}

		public static void WriteTreeViewContentToXml(TreeView treeView_0, XmlWriter writer)
		{
			int num = 2;
			if (treeView_0 == null)
			{
				throw new ArgumentNullException("tvw");
			}
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			XMLSerializeHelper.WriteAttributeString(writer, treeView_0, "Name");
			XMLSerializeHelper.WriteAttributeString(writer, treeView_0, "BackColor");
			XMLSerializeHelper.WriteAttributeString(writer, treeView_0, "BorderStyle");
			XMLSerializeHelper.WriteAttributeString(writer, treeView_0, "CheckBoxes");
			XMLSerializeHelper.WriteAttributeString(writer, treeView_0, "FullRowSelect");
			XMLSerializeHelper.WriteAttributeString(writer, treeView_0, "HideSelection");
			XMLSerializeHelper.WriteAttributeString(writer, treeView_0, "HotTracking");
			XMLSerializeHelper.WriteAttributeString(writer, treeView_0, "Indent");
			XMLSerializeHelper.WriteAttributeString(writer, treeView_0, "LabelEdit");
			XMLSerializeHelper.WriteAttributeString(writer, treeView_0, "LineColor");
			XMLSerializeHelper.WriteAttributeString(writer, treeView_0, "PathSeparator");
			XMLSerializeHelper.WriteAttributeString(writer, treeView_0, "ShowLines");
			XMLSerializeHelper.WriteAttributeString(writer, treeView_0, "ShowNodeToolTips");
			XMLSerializeHelper.WriteAttributeString(writer, treeView_0, "ShowPlusMinus");
			XMLSerializeHelper.WriteAttributeString(writer, treeView_0, "ShowRootLines");
			if (treeView_0.ImageList != null && treeView_0.ImageList.Images.Count > 0)
			{
				_ = treeView_0.ImageList.Images;
				writer.WriteStartElement("ImageList");
				WriteImageListContentToXml(treeView_0.ImageList, writer);
				writer.WriteEndElement();
			}
			writer.WriteStartElement("Nodes");
			WriteTreeNodeListContentToXml(treeView_0.Nodes, writer);
			writer.WriteEndElement();
		}

		private static void WriteTreeNodeListContentToXml(TreeNodeCollection nodes, XmlWriter writer)
		{
			int num = 10;
			foreach (TreeNode node in nodes)
			{
				writer.WriteStartElement("Node");
				XMLSerializeHelper.WriteAttributeString(writer, node, "Name");
				XMLSerializeHelper.WriteAttributeString(writer, node, "Text");
				XMLSerializeHelper.WriteAttributeString(writer, node, "Tag");
				XMLSerializeHelper.WriteAttributeString(writer, node, "ForeColor");
				XMLSerializeHelper.WriteAttributeString(writer, node, "BackColor");
				XMLSerializeHelper.WriteAttributeString(writer, node, "ImageIndex");
				XMLSerializeHelper.WriteAttributeString(writer, node, "ImageKey");
				XMLSerializeHelper.WriteAttributeString(writer, node, "ToolTipText");
				XMLSerializeHelper.WriteAttributeString(writer, node, "SelectedImageIndex");
				XMLSerializeHelper.WriteAttributeString(writer, node, "SelectedImageKey");
				if (node.NodeFont != null)
				{
					Font nodeFont = node.NodeFont;
					writer.WriteAttributeString("FontName", nodeFont.Name);
					writer.WriteAttributeString("FontSize", nodeFont.Size.ToString());
					writer.WriteAttributeString("FontStyle", nodeFont.Style.ToString());
				}
				if (node.Nodes.Count > 0)
				{
					writer.WriteStartElement("Nodes");
					WriteTreeNodeListContentToXml(node.Nodes, writer);
					writer.WriteEndElement();
				}
				writer.WriteEndElement();
			}
		}

		public static void WriteImageListContentToXml(ImageList imgs, XmlWriter writer)
		{
			int num = 1;
			writer.WriteAttributeString("TransparentColor", ColorTranslator.ToHtml(imgs.TransparentColor));
			StringCollection keys = imgs.Images.Keys;
			for (int i = 0; i < imgs.Images.Count; i++)
			{
				writer.WriteStartElement("Image");
				if (i < keys.Count && !string.IsNullOrEmpty(keys[i]))
				{
					writer.WriteAttributeString("Key", keys[i]);
				}
				Image image = imgs.Images[i];
				if (image != null)
				{
					MemoryStream memoryStream = new MemoryStream();
					image.Save(memoryStream, ImageFormat.Jpeg);
					string text = Convert.ToBase64String(memoryStream.ToArray());
					writer.WriteString(text);
				}
				writer.WriteEndElement();
			}
		}
	}
}
