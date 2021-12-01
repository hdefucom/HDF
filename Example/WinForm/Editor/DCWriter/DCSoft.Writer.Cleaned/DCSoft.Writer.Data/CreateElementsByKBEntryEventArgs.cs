using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       根据知识库创建文档元素事件参数
	///       </summary>
	[DocumentComment]
	[ComDefaultInterface(typeof(ICreateElementsByKBEntryEventArgs))]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("88B73E03-E559-447A-AF8D-1BE9372D250B")]
	[ComClass("88B73E03-E559-447A-AF8D-1BE9372D250B", "C50410E4-125F-4F45-B3E9-83A48DF8B7CF")]
	[ComVisible(true)]
	public class CreateElementsByKBEntryEventArgs : EventArgs, ICreateElementsByKBEntryEventArgs
	{
		internal const string CLASSID = "88B73E03-E559-447A-AF8D-1BE9372D250B";

		internal const string CLASSID_Interface = "C50410E4-125F-4F45-B3E9-83A48DF8B7CF";

		private WriterAppHost _Host = null;

		private XTextDocument _Document = null;

		private XTextElement _Element = null;

		private WriterControl _WriterControl = null;

		private KBEntry _KBEntry = null;

		private InputValueSource _InputSource = InputValueSource.UI;

		private XTextElementList _Result = null;

		private bool _Handled = false;

		/// <summary>
		///       编辑器宿主
		///       </summary>
		public WriterAppHost Host => _Host;

		/// <summary>
		///       文档对象
		///       </summary>
		public XTextDocument Document => _Document;

		public XTextElement Element => _Element;

		/// <summary>
		///       编辑器控件
		///       </summary>
		public WriterControl WriterControl => _WriterControl;

		/// <summary>
		///       知识库节点
		///       </summary>
		public KBEntry KBEntry => _KBEntry;

		/// <summary>
		///       输入来源
		///       </summary>
		public InputValueSource InputSource => _InputSource;

		/// <summary>
		///       结果
		///       </summary>
		public XTextElementList Result
		{
			get
			{
				return _Result;
			}
			set
			{
				_Result = value;
			}
		}

		/// <summary>
		///       事件已经处理了
		///       </summary>
		public bool Handled
		{
			get
			{
				return _Handled;
			}
			set
			{
				_Handled = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="document">文档对象</param>
		/// <param name="entry">知识库节点</param>
		/// <param name="inputSource">输入来源</param>
		[DCInternal]
		public CreateElementsByKBEntryEventArgs(XTextDocument document, KBEntry entry, InputValueSource inputSource)
		{
			_Host = document.AppHost;
			_Document = document;
			_WriterControl = document.EditorControl;
			_KBEntry = entry;
			_InputSource = inputSource;
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="document">文档对象</param>
		/// <param name="entry">知识库节点</param>
		/// <param name="inputSource">输入来源</param>
		public CreateElementsByKBEntryEventArgs(XTextDocument document, KBEntry entry, InputValueSource inputSource, XTextElement element)
		{
			_Host = document.AppHost;
			_Document = document;
			_WriterControl = document.EditorControl;
			_KBEntry = entry;
			_InputSource = inputSource;
			_Element = element;
		}
	}
}
