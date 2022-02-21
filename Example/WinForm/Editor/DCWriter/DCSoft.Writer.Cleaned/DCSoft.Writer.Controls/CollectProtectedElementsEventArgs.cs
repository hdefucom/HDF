using DCSoft.Common;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       收集内容保护信息事件参数
	///       </summary>
	[DocumentComment]
	[ComVisible(true)]
	[ComClass("11FAF693-4282-4EF8-A108-D657B392C6F3", "C663CDE8-C62E-41A5-AAE1-CC7C94816A0B")]
	[Guid("11FAF693-4282-4EF8-A108-D657B392C6F3")]
	[ComDefaultInterface(typeof(ICollectProtectedElementsEventArgs))]
	
	[ClassInterface(ClassInterfaceType.None)]
	public class CollectProtectedElementsEventArgs : WriterEventArgs, ICollectProtectedElementsEventArgs
	{
		internal new const string CLASSID = "11FAF693-4282-4EF8-A108-D657B392C6F3";

		internal new const string CLASSID_Interface = "C663CDE8-C62E-41A5-AAE1-CC7C94816A0B";

		private XTextElementList _RootElements = null;

		private GClass108 _Infos = null;

		private int _LimitedCount = 100;

		/// <summary>
		///       文档元素列表
		///       </summary>
		public XTextElementList RootElements
		{
			get
			{
				if (_RootElements == null)
				{
					_RootElements = new XTextElementList();
				}
				return _RootElements;
			}
		}

		/// <summary>
		///       内容保护信息列表
		///       </summary>
		public GClass108 Infos
		{
			get
			{
				if (_Infos == null)
				{
					_Infos = new GClass108();
				}
				return _Infos;
			}
			set
			{
				_Infos = value;
			}
		}

		/// <summary>
		///       信息个数限制
		///       </summary>
		public int LimitedCount
		{
			get
			{
				return _LimitedCount;
			}
			set
			{
				_LimitedCount = value;
			}
		}

		
		public CollectProtectedElementsEventArgs(WriterControl writerControl_0, XTextDocument document, XTextElementList rootElements, GClass108 infos)
			: base(writerControl_0, document, null)
		{
			_RootElements = rootElements;
			_Infos = infos;
		}
	}
}
