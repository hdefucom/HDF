using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       子文档对象文档节元素类型
	///       </summary>
	/// <remarks>
	///       本类型在文档节(XTextSectionElement)的基础上实现了子文档操作
	///       </remarks>
	[DocumentComment]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IXTextSubDocumentElement))]
	[Guid("4E1D2614-2C87-467C-B5C3-72135EE54ABD")]
	[ClassInterface(ClassInterfaceType.None)]
	[XmlType("XTextSubDocument")]
	[DebuggerDisplay("SubDocument {ID}:{ PreviewString }")]
	[ComClass("4E1D2614-2C87-467C-B5C3-72135EE54ABD", "D5CEBC74-0160-4898-BE6B-24F5F55744A1")]
	
	public sealed class XTextSubDocumentElement : XTextSectionElement, IXTextSubDocumentElement
	{
		internal const string string_18 = "4E1D2614-2C87-467C-B5C3-72135EE54ABD";

		internal const string string_19 = "D5CEBC74-0160-4898-BE6B-24F5F55744A1";

		private string string_20 = null;

		private bool bool_25 = false;

		private int int_13 = -1;

		private float float_10 = 0f;

		private bool bool_26 = false;

		private DocumentInfo documentInfo_0 = null;

		private string string_21 = null;

		private string string_22 = null;

		private bool bool_27 = false;

		private bool bool_28 = false;

		private bool bool_29 = true;

		private bool bool_30 = false;

		private bool bool_31 = false;

		private bool bool_32 = false;

		public override string DomDisplayName => "SubDocument:" + base.ID + " " + FileName;

		/// <summary>
		///       子文档编号，对应生成的文档的document.ID。
		///       </summary>
		
		[DefaultValue(null)]
		[ComVisible(true)]
		[HtmlAttribute]
		public string DocumentID
		{
			get
			{
				return string_20;
			}
			set
			{
				string_20 = value;
			}
		}

		/// <summary>
		///       记录已经打印了。
		///       </summary>
		[HtmlAttribute]
		[DefaultValue(false)]
		[ComVisible(true)]
		
		public bool Printed
		{
			get
			{
				return bool_25;
			}
			set
			{
				bool_25 = value;
			}
		}

		/// <summary>
		///       打印时所在的页码
		///       </summary>
		[HtmlAttribute]
		[DefaultValue(-1)]
		[ComVisible(true)]
		
		public int PrintedPageIndex
		{
			get
			{
				return int_13;
			}
			set
			{
				int_13 = value;
			}
		}

		/// <summary>
		///       打印时元素在页面中的顶端位置
		///       </summary>
		
		[DefaultValue(0f)]
		[ComVisible(true)]
		[HtmlAttribute]
		public float PrintPositionInPage
		{
			get
			{
				return float_10;
			}
			set
			{
				float_10 = value;
			}
		}

		/// <summary>
		///       内容被锁定，不能再次修改,也不能设置可读写操作
		///       </summary>
		
		[DefaultValue(false)]
		[ComVisible(true)]
		[HtmlAttribute]
		public bool Locked
		{
			get
			{
				return bool_26;
			}
			set
			{
				bool_26 = value;
			}
		}

		/// <summary>
		///       文档信息对象
		///       </summary>
		
		[DefaultValue(null)]
		[ComVisible(true)]
		[HtmlAttribute]
		public DocumentInfo DocumentInfo
		{
			get
			{
				if (documentInfo_0 == null)
				{
					documentInfo_0 = new DocumentInfo();
				}
				return documentInfo_0;
			}
			set
			{
				documentInfo_0 = value;
			}
		}

		/// <summary>
		///       文件名
		///       </summary>
		[HtmlAttribute]
		[DefaultValue(null)]
		[ComVisible(true)]
		
		public string FileName
		{
			get
			{
				return string_21;
			}
			set
			{
				string_21 = value;
			}
		}

		/// <summary>
		///       文件格式
		///       </summary>
		
		[DefaultValue(null)]
		[ComVisible(true)]
		[HtmlAttribute]
		public string FileFormat
		{
			get
			{
				return string_22;
			}
			set
			{
				string_22 = value;
			}
		}

		/// <summary>
		///       强制分页
		///       </summary>
		
		[ComVisible(true)]
		[DefaultValue(false)]
		[HtmlAttribute]
		public bool NewPage
		{
			get
			{
				return bool_27;
			}
			set
			{
				bool_27 = value;
			}
		}

		/// <summary>
		///       已经处理的强制分页标记.DCWriter内部使用。
		///       </summary>
		
		internal bool HandledNewPage
		{
			get
			{
				return bool_28;
			}
			set
			{
				bool_28 = value;
			}
		}

		/// <summary>
		///       加载文档时导入权限及用户痕迹信息
		///       </summary>
		
		[ComVisible(true)]
		[DefaultValue(true)]
		[HtmlAttribute]
		public bool ImportUserTrack
		{
			get
			{
				return bool_29;
			}
			set
			{
				bool_29 = value;
			}
		}

		/// <summary>
		///       延迟加载，只有在内容展开时才执行加载
		///       </summary>
		[DefaultValue(false)]
		[HtmlAttribute]
		
		[ComVisible(true)]
		public bool DelayLoadWhenExpand
		{
			get
			{
				return bool_30;
			}
			set
			{
				bool_30 = value;
			}
		}

		/// <summary>
		///       文件内容已经成功的加载了，无需再次加载了。
		///       </summary>
		
		[HtmlAttribute]
		[DefaultValue(false)]
		[ComVisible(true)]
		
		public bool ContentLoaded
		{
			get
			{
				return bool_31;
			}
			set
			{
				bool_31 = value;
			}
		}

		[ComVisible(false)]
		[Browsable(false)]
		public override string HtmlTitle
		{
			get
			{
				if (DocumentInfo != null && !string.IsNullOrEmpty(DocumentInfo.Title))
				{
					return DocumentInfo.Title;
				}
				if (!string.IsNullOrEmpty(base.Title))
				{
					return base.Title;
				}
				if (!string.IsNullOrEmpty(FileName))
				{
					return Path.GetFileNameWithoutExtension(FileName);
				}
				return base.ID;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public XTextSubDocumentElement()
		{
			base.CompressOwnerLineSpacing = true;
			EnablePermission = DCBooleanValue.False;
		}

		/// <summary>
		///       EditorSetState函数的COM包装
		///       </summary>
		/// <param name="readOnly">是否只读</param>
		/// <param name="backgroundColor">新的背景色</param>
		/// <param name="borderColor">新的边框颜色</param>
		/// <returns>操作是否成功</returns>
		/// <remarks>
		///       本函数是EditorSetState()函数的COM接口，可以如下方式调用
		///       <br /> element.EditorSetStateCOM( true, "#0000ff","#ffffff");
		///       </remarks>
		
		[ComVisible(true)]
		public bool EditorSetStateCOM(bool readOnly, string backgroundColor, string borderColor)
		{
			Color backgroundColor2 = XMLSerializeHelper.StringToColor(backgroundColor, Color.Transparent);
			Color borderColor2 = XMLSerializeHelper.StringToColor(borderColor, Color.Transparent);
			return EditorSetState(readOnly, backgroundColor2, borderColor2);
		}

		/// <summary>
		///       设置编辑状态
		///       </summary>
		/// <param name="readOnly">是否只读</param>
		/// <param name="backgroundColor">新的背景色</param>
		/// <param name="borderColor">新的边框颜色</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(true)]
		
		public bool EditorSetState(bool readOnly, Color backgroundColor, Color borderColor)
		{
			if (Locked)
			{
				return false;
			}
			ContentReadonly = ((!readOnly) ? ContentReadonlyState.False : ContentReadonlyState.True);
			Style.BackgroundColor = backgroundColor;
			Style.BorderColor = borderColor;
			Style.BorderWidth = 1f;
			Style.BorderStyle = DashStyle.Solid;
			Style.BorderLeft = true;
			Style.BorderTop = true;
			Style.BorderRight = true;
			Style.BorderBottom = true;
			InvalidateView();
			OwnerDocument.OnSelectionChanged();
			return true;
		}

		protected override void vmethod_45()
		{
			if (DelayLoadWhenExpand && XTextDocument.smethod_13(GEnum6.const_86) && !string.IsNullOrEmpty(FileName) && !ContentLoaded)
			{
				LoadDocumentFromFileName(FileName, FileFormat);
			}
		}

		/// <summary>
		///       保存文档到文件中
		///       </summary>
		/// <param name="fileName">文件名</param>
		/// <param name="format">文件格式</param>
		[ComVisible(true)]
		
		public void SaveDocumentToFileName(string fileName, string format)
		{
			try
			{
				XTextDocument xTextDocument = CreateRecordDocument();
				xTextDocument.EditorControl = OwnerDocument.EditorControl;
				xTextDocument.Save(fileName, format);
			}
			finally
			{
				FixDomState();
			}
		}

		/// <summary>
		///       保存文档到文件流中
		///       </summary>
		/// <param name="stream">文件流</param>
		/// <param name="format">文件格式</param>
		
		public void SaveDocumentToStream(Stream stream, string format)
		{
			try
			{
				XTextDocument xTextDocument = CreateRecordDocument();
				xTextDocument.EditorControl = OwnerDocument.EditorControl;
				xTextDocument.Save(stream, format);
			}
			finally
			{
				FixDomState();
			}
		}

		/// <summary>
		///       保存文档为二进制数据
		///       </summary>
		/// <param name="format">文件格式</param>
		/// <returns>保存的数据</returns>
		
		public byte[] SaveDocumentToBinary(string format)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				SaveDocumentToStream(memoryStream, format);
				return memoryStream.ToArray();
			}
		}

		/// <summary>
		///       保存文档到字符串中
		///       </summary>
		/// <param name="format">文件格式</param>
		/// <returns>生成的字符串</returns>
		[ComVisible(true)]
		
		public string SaveDocumentToString(string format)
		{
			try
			{
				XTextDocument xTextDocument = CreateRecordDocument();
				xTextDocument.EditorControl = OwnerDocument.EditorControl;
				return xTextDocument.SaveToString(format);
			}
			finally
			{
				FixDomState();
			}
		}

		/// <summary>
		///       创建单个病程记录文档对象
		///       </summary>
		/// <returns>创建的文档对象</returns>
		
		[ComVisible(false)]
		public XTextDocument CreateRecordDocument()
		{
			bool enablePermission = OwnerDocument.Options.SecurityOptions.EnablePermission;
			OwnerDocument.Options.SecurityOptions.EnablePermission = (EnablePermission == DCBooleanValue.True);
			XTextDocument xTextDocument = CreateContentDocument(includeThis: false);
			xTextDocument.ID = DocumentID;
			OwnerDocument.Options.SecurityOptions.EnablePermission = enablePermission;
			xTextDocument.Options.SecurityOptions.EnablePermission = true;
			_ = xTextDocument.Body.Elements;
			if (documentInfo_0 != null)
			{
				xTextDocument.Info = documentInfo_0.Clone();
			}
			if (Attributes != null)
			{
				xTextDocument.Attributes = Attributes.Clone();
			}
			xTextDocument.FileName = string_21;
			xTextDocument.FileFormat = FileFormat;
			return xTextDocument;
		}

		
		[ComVisible(true)]
		public void LoadDocumentFromFileName(string fileName, string format)
		{
			try
			{
				method_58();
				XTextDocument xTextDocument = new XTextDocument();
				xTextDocument.xtextElement_1 = this;
				xTextDocument.EditorControl = OwnerDocument.EditorControl;
				xTextDocument.LoadFromFile(fileName, format);
				xTextDocument.EditorControl = null;
				method_57(xTextDocument);
			}
			finally
			{
				method_59();
			}
		}

		
		public void LoadDocumentFromStream(Stream stream, string format)
		{
			try
			{
				method_58();
				XTextDocument xTextDocument = new XTextDocument();
				xTextDocument.xtextElement_1 = this;
				xTextDocument.EditorControl = OwnerDocument.EditorControl;
				xTextDocument.Load(stream, format);
				xTextDocument.EditorControl = null;
				method_57(xTextDocument);
			}
			finally
			{
				method_59();
			}
		}

		
		[ComVisible(true)]
		public void LoadDocumentFromString(string string_23, string format)
		{
			try
			{
				method_58();
				XTextDocument xTextDocument = new XTextDocument();
				xTextDocument.xtextElement_1 = this;
				xTextDocument.EditorControl = OwnerDocument.EditorControl;
				xTextDocument.LoadFromString(string_23, format);
				xTextDocument.EditorControl = null;
				method_57(xTextDocument);
			}
			finally
			{
				method_59();
			}
		}

		private void method_57(XTextDocument xtextDocument_1)
		{
			int num = 19;
			if (xtextDocument_1 == null)
			{
				throw new ArgumentNullException("document");
			}
			ContentLoaded = true;
			base.Title = xtextDocument_1.RuntimeTitle;
			WriterControl editorControl = OwnerDocument.EditorControl;
			documentInfo_0 = xtextDocument_1.Info;
			if (editorControl == null)
			{
			}
			XTextElementList xTextElementList = xtextDocument_1.Body.Elements.Clone();
			xtextDocument_1.Body.Elements.Clear();
			OwnerDocument.ImportElementsSpceifyImportPermssion(xTextElementList, ImportUserTrack, ImportUserTrack);
			Elements.Clear();
			Elements.AddRange(xTextElementList);
			method_56();
			DocumentInfo = xtextDocument_1.Info;
			Attributes = xtextDocument_1.Attributes;
			DocumentID = xtextDocument_1.ID;
			FileFormat = xtextDocument_1.FileFormat;
			FileName = xtextDocument_1.FileName;
			Modified = false;
			FixDomState();
		}

		private void method_58()
		{
			bool_32 = true;
			if (WriterControl != null)
			{
				InvalidateView();
				WriterControl.InnerViewControl.Update();
				WriterControl.InnerViewControl.Cursor = Cursors.WaitCursor;
			}
		}

		private void method_59()
		{
			bool_32 = false;
			if (WriterControl != null)
			{
				InvalidateView();
			}
		}

		protected override GClass2 vmethod_46()
		{
			if (bool_32)
			{
				GClass2 gClass = new GClass2();
				if (!string.IsNullOrEmpty(base.Title))
				{
					gClass.method_1(string.Format(WriterStringsCore.Loading_FileName, base.Title));
				}
				else if (!string.IsNullOrEmpty(FileName))
				{
					gClass.method_1(string.Format(WriterStringsCore.Loading_FileName, FileName));
				}
				else
				{
					gClass.method_1(string.Format(WriterStringsCore.Loading_FileName, ""));
				}
				gClass.method_3(Color.Black);
				return gClass;
			}
			return base.vmethod_46();
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <param name="Deeply">是否深度复制</param>
		/// <returns>复制品</returns>
		public override XTextElement Clone(bool Deeply)
		{
			XTextSubDocumentElement xTextSubDocumentElement = (XTextSubDocumentElement)base.Clone(Deeply);
			if (documentInfo_0 != null)
			{
				xTextSubDocumentElement.documentInfo_0 = documentInfo_0.Clone();
			}
			return xTextSubDocumentElement;
		}

		public override void Dispose()
		{
			base.Dispose();
			string_20 = null;
			documentInfo_0 = null;
			string_21 = null;
		}
	}
}
