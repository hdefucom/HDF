using System;

namespace YidanSoft.Library.EmrEditor.Src.Common
{
	/// <summary>
	/// ����ϵͳ���а崦��ģ��,�ṩ�ķ���Ϊ��̬����
	/// </summary>
	/// <example>
	/// C#������ʹ�ø��������,�Ӳ���ϵͳ���а��ô��ı�����
	/// // �жϲ���ϵͳ���а��Ƿ񱣴��˴��ı�����
	/// if( ClipboardHandler.CanGetText())
	/// {
	///		// ���ػ�õĴ��ı�����
	///		return ClipboardHandler.GetTextFromClipboard();
	/// }
	/// 
	/// �����ϵͳ���а����ô��ı�����
	/// string strText = "Ҫ���õĴ��ı�����";
	/// ClipboardHandler.SetTextToClipboard( strText );
	/// </example>
	public class ClipboardHandler
	{

		/// <summary>
		/// �Ƿ���ԴӲ���ϵͳ���а����ı�
		/// </summary>
		/// <returns>true ���ԴӲ���ϵͳ���а����ı�,false ������</returns>
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
                //ZYErrorReport.Instance.DebugPrint("CanGetText:��ͼ����ı���ʽ�ļ��а����ݴ���:" + ext.Message );
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
                //ZYErrorReport.Instance.DebugPrint("CanGetData:��ͼ���" + strFormat + "��ʽ�ļ��а����ݴ���:" + ext.Message );
				return false;
			}
		}
//
//		/// <summary>
//		/// �Ƿ���������ϵͳ���а������ı�
//		/// </summary>
//		/// <returns></returns>
//		public static bool CanSetText()
//		{
//			return true;
//		}

		/// <summary>
		/// �����ϵͳ���а������ı�����
		/// </summary>
		/// <param name="strText">�ı�����</param>
		/// <returns>�����Ƿ�ɹ�</returns>
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
		/// �Ӳ���ϵͳ���а����ı�
		/// </summary>
		/// <returns>��õ��ı�,������ʧ���򷵻ؿն���</returns>
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
                //ZYErrorReport.Instance.DebugPrint("GetDataFromClipboard:��ͼ���" + strFormat + "��ʽ�ļ��а����ݴ���:" + ext.Message );
			}
			return null ;
		}
	}//public class ClipboardHandler
}
