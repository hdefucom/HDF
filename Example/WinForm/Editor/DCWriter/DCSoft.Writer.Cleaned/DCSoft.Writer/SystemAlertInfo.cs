using DCSoft.Common;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       系统警告信息对象
	///       </summary>
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("F282869A-E275-4B5B-9440-2F0B8DFAD6DE", "AE1A9ED0-0194-4A97-A116-5A4A508995DD")]
	[Guid("F282869A-E275-4B5B-9440-2F0B8DFAD6DE")]
	
	[ComDefaultInterface(typeof(ISystemAlertInfo))]
	public class SystemAlertInfo : ISystemAlertInfo
	{
		internal const string CLASSID = "F282869A-E275-4B5B-9440-2F0B8DFAD6DE";

		internal const string CLASSID_Interface = "AE1A9ED0-0194-4A97-A116-5A4A508995DD";

		private string _Message = null;

		/// <summary>
		///       信息内容
		///       </summary>
		public string Message
		{
			get
			{
				return _Message;
			}
			set
			{
				_Message = value;
			}
		}
	}
}
