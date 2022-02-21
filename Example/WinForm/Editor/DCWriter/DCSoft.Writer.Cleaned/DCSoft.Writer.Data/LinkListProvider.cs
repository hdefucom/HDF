using DCSoft.Common;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       联动列表数据提供者
	///       </summary>
	[ComDefaultInterface(typeof(ILinkListProvider))]
	
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	[ComClass("188C7BB8-B137-4F7A-8783-43A7CF0F0379", "6271A999-743F-4068-80B4-E3D48EB288B3")]
	[Guid("188C7BB8-B137-4F7A-8783-43A7CF0F0379")]
	[ComVisible(true)]
	public class LinkListProvider : ILinkListProvider
	{
		internal const string CLASSID = "188C7BB8-B137-4F7A-8783-43A7CF0F0379";

		internal const string CLASSID_Interface = "6271A999-743F-4068-80B4-E3D48EB288B3";

		private string _Name = null;

		private bool _Enabled = true;

		/// <summary>
		///       对象名称
		///       </summary>
		
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name = value;
			}
		}

		/// <summary>
		///       对象是否可用
		///       </summary>
		
		public bool Enabled
		{
			get
			{
				return _Enabled;
			}
			set
			{
				_Enabled = value;
			}
		}

		/// <summary>
		///       获得列表内容
		///       </summary>
		/// <param name="args">事件参数</param>
		
		public virtual void GetListItems(GetLinkListItemsEventArgs args)
		{
		}
	}
}
