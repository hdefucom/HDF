using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.NewDom
{
	[ComVisible(false)]
	public abstract class DomContainerElement : DomElement
	{
		private List<DomElement> _Elements = null;

		/// <summary>
		///       子元素列表
		///       </summary>
		[DefaultValue(null)]
		public virtual List<DomElement> Elements
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

		public DomContainerElement()
		{
		}
	}
}
