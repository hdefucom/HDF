using DCSoft.Common;
using DCSoft.Writer;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Script;
using System.Runtime.InteropServices;
using System.Xml;

namespace DCSoftDotfuscate
{
	
	[ComVisible(false)]
	public abstract class GClass30
	{
		public virtual void vmethod_0(XmlWriter xmlWriter_0, XTextElement xtextElement_0)
		{
			int num = 11;
			if (!string.IsNullOrEmpty(xtextElement_0.ID))
			{
				xmlWriter_0.WriteAttributeString("ID", xtextElement_0.ID);
			}
			if (xtextElement_0.StyleIndex >= 0)
			{
				xmlWriter_0.WriteAttributeString("StyleIndex", xtextElement_0.StyleIndex.ToString());
			}
		}

		protected string method_0(XTextElement xtextElement_0)
		{
			return XMLSerializeHelper.GetXmlTypeName(xtextElement_0.GetType());
		}

		protected void method_1(XmlWriter xmlWriter_0, string string_0, XAttributeList xattributeList_0)
		{
			int num = 17;
			if (xattributeList_0 != null && xattributeList_0.Count > 0)
			{
				xmlWriter_0.WriteStartElement(string_0);
				foreach (XAttribute item in xattributeList_0)
				{
					xmlWriter_0.WriteStartElement("Attribue");
					if (!string.IsNullOrEmpty(item.Name))
					{
						xmlWriter_0.WriteAttributeString("Name", item.Name);
					}
					if (!string.IsNullOrEmpty(item.Value))
					{
						xmlWriter_0.WriteString(item.Value);
					}
					xmlWriter_0.WriteEndElement();
				}
				xmlWriter_0.WriteFullEndElement();
			}
		}

		protected void method_2(XmlWriter xmlWriter_0, string string_0, object object_0)
		{
			xmlWriter_0.WriteAttributeString(string_0, XMLSerializeHelper.EnumToString(object_0));
		}

		protected void method_3(XmlWriter xmlWriter_0, string string_0, DataFeedbackInfo dataFeedbackInfo_0)
		{
			int num = 11;
			if (dataFeedbackInfo_0 != null && !dataFeedbackInfo_0.IsEmpty)
			{
				xmlWriter_0.WriteStartElement(string_0);
				if (!string.IsNullOrEmpty(dataFeedbackInfo_0.TableName))
				{
					xmlWriter_0.WriteAttributeString("TableName", dataFeedbackInfo_0.TableName);
				}
				if (!string.IsNullOrEmpty(dataFeedbackInfo_0.FieldName))
				{
					xmlWriter_0.WriteAttributeString("FieldName", dataFeedbackInfo_0.FieldName);
				}
				if (!string.IsNullOrEmpty(dataFeedbackInfo_0.FieldValue))
				{
					xmlWriter_0.WriteAttributeString("FieldValue", dataFeedbackInfo_0.FieldValue);
				}
				if (!string.IsNullOrEmpty(dataFeedbackInfo_0.KeyFieldName))
				{
					xmlWriter_0.WriteAttributeString("KeyFieldName", dataFeedbackInfo_0.KeyFieldName);
				}
				if (!string.IsNullOrEmpty(dataFeedbackInfo_0.KeyFieldValue))
				{
					xmlWriter_0.WriteAttributeString("KeyFieldValue", dataFeedbackInfo_0.KeyFieldValue);
				}
				if (!string.IsNullOrEmpty(dataFeedbackInfo_0.KeyFeildDataSourcePath))
				{
					xmlWriter_0.WriteAttributeString("KeyFeildDataSourcePath", dataFeedbackInfo_0.KeyFeildDataSourcePath);
				}
				xmlWriter_0.WriteEndElement();
			}
		}

		protected void method_4(XmlWriter xmlWriter_0, string string_0, XDataBinding xdataBinding_0)
		{
			int num = 0;
			if (xdataBinding_0 != null && !xdataBinding_0.IsEmptyBinding)
			{
				xmlWriter_0.WriteStartElement(string_0);
				if (xdataBinding_0.AutoUpdate)
				{
					xmlWriter_0.WriteAttributeString("AutoUpdate", "true");
				}
				if (!string.IsNullOrEmpty(xdataBinding_0.BindingPath))
				{
					xmlWriter_0.WriteAttributeString("BindingPath", xdataBinding_0.BindingPath);
				}
				if (!string.IsNullOrEmpty(xdataBinding_0.DataSource))
				{
					xmlWriter_0.WriteAttributeString("DataSource", xdataBinding_0.DataSource);
				}
				if (!xdataBinding_0.Enabled)
				{
					xmlWriter_0.WriteAttributeString("Enabled", "false");
				}
				if (!string.IsNullOrEmpty(xdataBinding_0.FormatString))
				{
					xmlWriter_0.WriteAttributeString("FormatString", xdataBinding_0.FormatString);
				}
				if (xdataBinding_0.ProcessState != 0)
				{
					xmlWriter_0.WriteAttributeString("ProcessState", xdataBinding_0.ProcessState.ToString());
				}
				if (xdataBinding_0.Readonly)
				{
					xmlWriter_0.WriteAttributeString("Readonly", "true");
				}
				if (!string.IsNullOrEmpty(xdataBinding_0.ValueBindingPath))
				{
					xmlWriter_0.WriteAttributeString("ValueBindingPath", xdataBinding_0.ValueBindingPath);
				}
				if (!string.IsNullOrEmpty(xdataBinding_0.WriteTextBindingPath))
				{
					xmlWriter_0.WriteAttributeString("WriteTextBindingPath", xdataBinding_0.WriteTextBindingPath);
				}
				xmlWriter_0.WriteEndElement();
			}
		}

		protected void method_5(XmlWriter xmlWriter_0, string string_0, DCBooleanValue dcbooleanValue_0)
		{
			xmlWriter_0.WriteAttributeString(string_0, dcbooleanValue_0.ToString());
		}

		protected void method_6(XmlWriter xmlWriter_0, string string_0, PropertyExpressionInfoList propertyExpressionInfoList_0)
		{
			int num = 16;
			if (propertyExpressionInfoList_0 != null && propertyExpressionInfoList_0.Count > 0)
			{
				xmlWriter_0.WriteStartElement(string_0);
				foreach (PropertyExpressionInfo item in propertyExpressionInfoList_0)
				{
					xmlWriter_0.WriteStartElement("PropertyExpression");
					if (!string.IsNullOrEmpty(item.Name))
					{
						xmlWriter_0.WriteAttributeString("PropertyName", item.Name);
					}
					if (!item.AllowChainReaction)
					{
						xmlWriter_0.WriteAttributeString("AllowChainReaction", "false");
					}
					if (!string.IsNullOrEmpty(item.Expression))
					{
						method_10(xmlWriter_0, item.Expression);
					}
					xmlWriter_0.WriteEndElement();
				}
				xmlWriter_0.WriteEndElement();
			}
		}

		protected void method_7(XmlWriter xmlWriter_0, string string_0, DomExpressionList domExpressionList_0)
		{
			int num = 5;
			if (domExpressionList_0 != null && domExpressionList_0.Count > 0)
			{
				xmlWriter_0.WriteStartElement(string_0);
				foreach (DomExpression item in domExpressionList_0)
				{
					xmlWriter_0.WriteStartElement("Expression");
					if (!string.IsNullOrEmpty(item.Name))
					{
						xmlWriter_0.WriteAttributeString("Name", item.Name);
					}
					xmlWriter_0.WriteAttributeString("Type", item.Type.ToString());
					if (!string.IsNullOrEmpty(item.Expression))
					{
						method_10(xmlWriter_0, item.Expression);
					}
					xmlWriter_0.WriteEndElement();
				}
				xmlWriter_0.WriteEndElement();
			}
		}

		protected void method_8(XmlWriter xmlWriter_0, string string_0, VBScriptItemList vbscriptItemList_0)
		{
			int num = 17;
			if (vbscriptItemList_0 != null && vbscriptItemList_0.Count > 0)
			{
				xmlWriter_0.WriteStartElement(string_0);
				foreach (VBScriptItem item in vbscriptItemList_0)
				{
					xmlWriter_0.WriteStartElement("ScriptItem");
					xmlWriter_0.WriteAttributeString("Name", item.Name);
					method_10(xmlWriter_0, item.ScriptText);
					xmlWriter_0.WriteEndElement();
				}
				xmlWriter_0.WriteEndElement();
			}
		}

		protected void method_9(XmlWriter xmlWriter_0, string string_0, string string_1)
		{
			if (!string.IsNullOrEmpty(string_1))
			{
				if (method_11(string_1))
				{
					xmlWriter_0.WriteStartElement(string_0);
					xmlWriter_0.WriteCData(string_1);
					xmlWriter_0.WriteEndElement();
				}
				else
				{
					xmlWriter_0.WriteElementString(string_0, string_1);
				}
			}
		}

		protected void method_10(XmlWriter xmlWriter_0, string string_0)
		{
			if (!string.IsNullOrEmpty(string_0))
			{
				if (method_11(string_0))
				{
					xmlWriter_0.WriteCData(string_0);
				}
				else
				{
					xmlWriter_0.WriteString(string_0);
				}
			}
		}

		protected bool method_11(string string_0)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				return false;
			}
			return string_0.IndexOf('>') >= 0 || string_0.IndexOf('<') >= 0;
		}
	}
}
