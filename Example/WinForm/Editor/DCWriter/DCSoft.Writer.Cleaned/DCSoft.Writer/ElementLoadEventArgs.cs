using DCSoft.Common;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档元素加载事件处理
	///       </summary>
	[ClassInterface(ClassInterfaceType.None)]
	
	[ComClass("147E4E00-93F4-4E81-A21E-4503060224C8", "F78AE1CA-23D7-4456-B38A-88F6685D8A41")]
	[ComVisible(true)]
	
	[ComDefaultInterface(typeof(IElementLoadEventArgs))]
	[Guid("147E4E00-93F4-4E81-A21E-4503060224C8")]
	public class ElementLoadEventArgs : ElementEventArgs, IElementLoadEventArgs
	{
		internal new const string CLASSID = "147E4E00-93F4-4E81-A21E-4503060224C8";

		internal new const string CLASSID_Interface = "F78AE1CA-23D7-4456-B38A-88F6685D8A41";

		private string _Format = null;

		private bool _UpdateValueBinding = true;

		private bool _UpdateExpression = true;

		/// <summary>
		///       文件格式
		///       </summary>
		
		public string Format
		{
			get
			{
				return _Format;
			}
			set
			{
				_Format = value;
			}
		}

		/// <summary>
		///       是否更新数据源绑定
		///       </summary>
		
		public bool UpdateValueBinding
		{
			get
			{
				return _UpdateValueBinding;
			}
			set
			{
				_UpdateValueBinding = value;
			}
		}

		/// <summary>
		///       是否更新数据源绑定
		///       </summary>
		
		public bool UpdateExpression
		{
			get
			{
				return _UpdateExpression;
			}
			set
			{
				_UpdateExpression = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="element">文档元素对象</param>
		/// <param name="format">加载文档的文件格式</param>
		
		public ElementLoadEventArgs(XTextElement element, string format)
			: base(element)
		{
			_Format = format;
		}
	}
}
