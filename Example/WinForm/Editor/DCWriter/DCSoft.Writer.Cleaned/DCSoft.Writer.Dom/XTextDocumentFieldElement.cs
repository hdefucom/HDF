using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档域对象
	///       </summary>
	[Serializable]
	
	[XmlType("DField")]
	
	[DebuggerDisplay("Field")]
	[ComVisible(false)]
	public class XTextDocumentFieldElement : XTextFieldElementBase
	{
		private string string_16 = null;

		private bool bool_17 = false;

		public override string DomDisplayName => "DocumentField:" + base.ID;

		/// <summary>
		///       域编码
		///       </summary>
		[DefaultValue(null)]
		public string Code
		{
			get
			{
				return string_16;
			}
			set
			{
				string_16 = value;
			}
		}

		/// <summary>
		///       自动更新域结果
		///       </summary>
		[DefaultValue(false)]
		public bool AutoUpdateResult
		{
			get
			{
				return bool_17;
			}
			set
			{
				bool_17 = value;
			}
		}

		/// <summary>
		///       文档加载后的事件处理
		///       </summary>
		/// <param name="args">参数</param>
		public override void AfterLoad(ElementLoadEventArgs args)
		{
			if (AutoUpdateResult)
			{
				vmethod_37(bool_18: true);
			}
			base.AfterLoad(args);
		}

		public virtual void vmethod_37(bool bool_18)
		{
			int num = 1;
			XTextDocument ownerDocument = OwnerDocument;
			new XTextElementList();
			string code = Code;
			if (string.Equals(code, "Page", StringComparison.CurrentCultureIgnoreCase))
			{
				XTextPageInfoElement xTextPageInfoElement = new XTextPageInfoElement();
				xTextPageInfoElement.OwnerDocument = OwnerDocument;
				xTextPageInfoElement.Parent = this;
				int int_ = 0;
				if (FirstContentElement != null)
				{
					int_ = FirstContentElementInPublicContent.ViewIndex;
				}
				Elements.Clear();
				Elements.Add(xTextPageInfoElement);
				if (!bool_18)
				{
					XTextDocumentContentElement documentContentElement = base.DocumentContentElement;
					documentContentElement.method_31(int_);
				}
			}
			else if (string.Equals(code, "NumPages", StringComparison.CurrentCultureIgnoreCase))
			{
				string text = null;
				text = ((ownerDocument.Pages != null && ownerDocument.Pages.Count != 0) ? ownerDocument.Pages.Count.ToString() : ownerDocument.Info.NumOfPage.ToString());
				if (bool_18)
				{
					SetInnerTextFast(text);
				}
				else
				{
					SetEditorTextExt(text, DomAccessFlags.None, disablePermissioin: true, updateContent: true);
				}
			}
			if (!bool_18)
			{
				UpdateContentVersion();
			}
		}
	}
}
