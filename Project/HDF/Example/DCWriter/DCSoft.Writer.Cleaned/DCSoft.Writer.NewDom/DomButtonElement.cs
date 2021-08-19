using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.NewDom
{
	/// <summary>
	///       按钮元素
	///       </summary>
	[ComVisible(false)]
	public class DomButtonElement : DomObjectElement
	{
		private string _CommandName = null;

		private string _Text = null;

		private string _ScriptTextForClick = null;

		[DefaultValue(null)]
		[XmlAttribute]
		public string CommandName
		{
			get
			{
				return _CommandName;
			}
			set
			{
				_CommandName = value;
			}
		}

		[DefaultValue(null)]
		[XmlElement]
		public string Text
		{
			get
			{
				return _Text;
			}
			set
			{
				_Text = value;
			}
		}

		[XmlElement]
		[DefaultValue(null)]
		public string ScriptTextForClick
		{
			get
			{
				return _ScriptTextForClick;
			}
			set
			{
				_ScriptTextForClick = value;
			}
		}
	}
}
