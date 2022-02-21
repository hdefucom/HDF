using DCSoft.Common;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       剪切板功能提供者
	///       </summary>
	[ComVisible(false)]
	
	public class ClipboardProvider
	{
		/// <summary>
		///       初始化对象
		///       </summary>
		
		public ClipboardProvider()
		{
		}

		/// <summary>
		///       清空剪切板内容 
		///       </summary>
		
		public virtual void Clear()
		{
			Clipboard.Clear();
		}

		/// <summary>
		///       保存数据到剪切板中
		///       </summary>
		/// <param name="data">
		/// </param>
		/// <param name="copy">
		/// </param>
		
		public virtual void SaveData(IDataObject data, bool copy)
		{
			Clipboard.SetDataObject(data, copy);
		}

		/// <summary>
		///       从剪切板中获得数据对象
		///       </summary>
		/// <returns>
		/// </returns>
		
		public virtual IDataObject GetDataObject(Control sourceControl)
		{
			return Clipboard.GetDataObject();
		}

		/// <summary>
		///       创建一个数据容器对象
		///       </summary>
		/// <returns>
		/// </returns>
		
		public virtual IDataObject CreateDataObject()
		{
			return new DataObject();
		}

		/// <summary>
		///       设置数据标题
		///       </summary>
		/// <param name="data">
		/// </param>
		/// <param name="title">
		/// </param>
		
		public virtual void SetDataTitle(IDataObject data, string title)
		{
		}
	}
}
