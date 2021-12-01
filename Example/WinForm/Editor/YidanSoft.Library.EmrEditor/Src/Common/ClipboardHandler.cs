using System;

namespace YidanSoft.Library.EmrEditor.Src.Common
{
	/// <summary>
	/// 操作系统剪切板处理模块,提供的方法为静态函数
	/// </summary>
	/// <example>
	/// C#语言中使用该类的例子,从操作系统剪切板获得纯文本数据
	/// // 判断操作系统剪切板是否保存了纯文本数据
	/// if( ClipboardHandler.CanGetText())
	/// {
	///		// 返回获得的纯文本数据
	///		return ClipboardHandler.GetTextFromClipboard();
	/// }
	/// 
	/// 向操作系统剪切板设置纯文本数据
	/// string strText = "要设置的纯文本数据";
	/// ClipboardHandler.SetTextToClipboard( strText );
	/// </example>
	public class ClipboardHandler
	{

		/// <summary>
		/// 是否可以从操作系统剪切板获得文本
		/// </summary>
		/// <returns>true 可以从操作系统剪切板获得文本,false 不可以</returns>
		public static  bool CanGetText() 
		{
			// Clipboard.GetDataObject may throw an exception...
			try 
			{
				System.Windows.Forms.IDataObject data = System.Windows.Forms.Clipboard.GetDataObject();
				return data != null && data.GetDataPresent(System.Windows.Forms.DataFormats.Text);
			} 
			catch (Exception ext) 
			{
                //ZYErrorReport.Instance.DebugPrint("CanGetText:试图获得文本格式的剪切板数据错误:" + ext.Message );
				return false;
			}
		}

		public static bool CanGetData( string strFormat)
		{
			try
			{
				System.Windows.Forms.IDataObject data = System.Windows.Forms.Clipboard.GetDataObject();
				return data != null && data.GetDataPresent( strFormat );
			}
			catch(Exception ext)
			{
                //ZYErrorReport.Instance.DebugPrint("CanGetData:试图获得" + strFormat + "格式的剪切板数据错误:" + ext.Message );
				return false;
			}
		}
//
//		/// <summary>
//		/// 是否可以向操作系统剪切板设置文本
//		/// </summary>
//		/// <returns></returns>
//		public static bool CanSetText()
//		{
//			return true;
//		}

		/// <summary>
		/// 向操作系统剪切板设置文本数据
		/// </summary>
		/// <param name="strText">文本数据</param>
		/// <returns>操作是否成功</returns>
		public static  bool SetTextToClipboard(string strText)
		{
			if (  strText != null && strText.Length > 0 ) 
			{
				try 
				{
					System.Windows.Forms.DataObject dataObject = new System.Windows.Forms.DataObject();
					dataObject.SetData(System.Windows.Forms.DataFormats.UnicodeText  , true, strText );
					System.Windows.Forms.Clipboard.SetDataObject(dataObject, true);
					return true;
				} 
				catch (Exception e) 
				{
					Console.WriteLine("Got exception while Copy text to clipboard : " + e);
				}
			}
			return false;
		}

		/// <summary>
		/// 从操作系统剪切板获得文本
		/// </summary>
		/// <returns>获得的文本,若操作失败则返回空对象</returns>
		public static  string GetTextFromClipboard()
		{
			try
			{
				System.Windows.Forms.IDataObject data = System.Windows.Forms.Clipboard.GetDataObject();
				if( data.GetDataPresent(System.Windows.Forms.DataFormats.UnicodeText))
				{
					string strText = ( string) data.GetData( System.Windows.Forms.DataFormats.UnicodeText);
					return strText;
				}
			}
			catch
			{}
			return null;
		}

		public static object GetDataFromClipboard( string strFormat )
		{
			try
			{
				System.Windows.Forms.IDataObject data = System.Windows.Forms.Clipboard.GetDataObject();
				if( data != null && data.GetDataPresent( strFormat ))
				{
					return data.GetData( strFormat );
				}
			}
			catch(Exception ext)
			{
                //ZYErrorReport.Instance.DebugPrint("GetDataFromClipboard:试图获得" + strFormat + "格式的剪切板数据错误:" + ext.Message );
			}
			return null ;
		}
	}//public class ClipboardHandler
}
