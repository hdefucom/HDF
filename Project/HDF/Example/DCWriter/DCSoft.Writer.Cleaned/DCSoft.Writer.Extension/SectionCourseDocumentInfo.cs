using DCSoft.Common;
using DCSoft.Printing;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Serialization;

namespace DCSoft.Writer.Extension
{
	/// <summary>
	///       病程记录文档信息对象
	///       </summary>
	/// <remarks>
	///       为了处理超长期的病程记录对象，程序需要存储一些缓存信息，
	///       本对象就是这些超长病程记录文档的缓存信息。
	///       对于超长病程记录，必须要首先加载这种文档信息。
	///
	///       本文档信息可以加载和保存到XML字符串中。系统数据库需要加一个
	///       大字段用于存储这个XML字符串。这种XML字符串仅仅是内部使用的
	///       无需查询检索。
	///       </remarks>
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	[ComClass("982C0F4D-D8FC-4DE0-BD53-FBB1078817A6", "82DB5BD1-9921-4810-AFC3-01E9B6472B8F")]
	[ComDefaultInterface(typeof(ISectionCourseDocumentInfo))]
	[Guid("982C0F4D-D8FC-4DE0-BD53-FBB1078817A6")]
	public class SectionCourseDocumentInfo : ISectionCourseDocumentInfo
	{
		internal const string CLASSID = "982C0F4D-D8FC-4DE0-BD53-FBB1078817A6";

		internal const string CLASSID_Interface = "82DB5BD1-9921-4810-AFC3-01E9B6472B8F";

		private XPageSettings _PageSettings = null;

		private float _HeaderHeight = 0f;

		private float _FooterHeight = 0f;

		private float _LastJumpPrintPosition = 0f;

		private List<float> _PageLinePositions = null;

		private SectionCourseFileInfoList _Files = new SectionCourseFileInfoList();

		/// <summary>
		///       页面设置
		///       </summary>
		public XPageSettings PageSettings
		{
			get
			{
				return _PageSettings;
			}
			set
			{
				_PageSettings = value;
			}
		}

		/// <summary>
		///       页眉高度
		///       </summary>
		[DefaultValue(0f)]
		public float HeaderHeight
		{
			get
			{
				return _HeaderHeight;
			}
			set
			{
				_HeaderHeight = value;
			}
		}

		/// <summary>
		///       页脚高度
		///       </summary>
		[DefaultValue(0f)]
		public float FooterHeight
		{
			get
			{
				return _FooterHeight;
			}
			set
			{
				_FooterHeight = value;
			}
		}

		/// <summary>
		///       最后一次续打的位置
		///       </summary>
		[DefaultValue(0f)]
		public float LastJumpPrintPosition
		{
			get
			{
				return _LastJumpPrintPosition;
			}
			set
			{
				_LastJumpPrintPosition = value;
			}
		}

		/// <summary>
		///       分页线位置
		///       </summary>
		[XmlArrayItem("Position", typeof(float))]
		public List<float> PageLinePositions
		{
			get
			{
				return _PageLinePositions;
			}
			set
			{
				_PageLinePositions = value;
			}
		}

		/// <summary>
		///       某次住院的所有的病程记录的信息对象
		///       </summary>
		[XmlArrayItem("File", typeof(SectionCourseFileInfo))]
		public SectionCourseFileInfoList Files
		{
			get
			{
				return _Files;
			}
			set
			{
				_Files = value;
			}
		}

		/// <summary>
		///       保存数据到一个XML字符串中
		///       </summary>
		/// <returns>生成的XML字符串</returns>
		public string SaveToXMLString()
		{
			StringWriter stringWriter = new StringWriter();
			XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
			xmlTextWriter.Formatting = Formatting.None;
			XmlSerializer xmlSerializer = new XmlSerializer(GetType());
			xmlSerializer.Serialize(xmlTextWriter, this);
			xmlTextWriter.Close();
			string xmlText = stringWriter.ToString();
			return XMLHelper.CleanupXMLHeader(xmlText);
		}

		/// <summary>
		///       从一个XML字符串中加载对象数据
		///       </summary>
		/// <param name="xmlText">XML字符串</param>
		public void LoadFromXMLString(string xmlText)
		{
			StringReader stringReader = new StringReader(xmlText);
			XmlSerializer xmlSerializer = new XmlSerializer(GetType());
			SectionCourseDocumentInfo sectionCourseDocumentInfo = (SectionCourseDocumentInfo)xmlSerializer.Deserialize(stringReader);
			stringReader.Close();
			_Files = sectionCourseDocumentInfo._Files;
			_FooterHeight = sectionCourseDocumentInfo._FooterHeight;
			_HeaderHeight = sectionCourseDocumentInfo._HeaderHeight;
			_LastJumpPrintPosition = sectionCourseDocumentInfo._LastJumpPrintPosition;
			_PageLinePositions = sectionCourseDocumentInfo._PageLinePositions;
			_PageSettings = sectionCourseDocumentInfo._PageSettings;
		}
	}
}
