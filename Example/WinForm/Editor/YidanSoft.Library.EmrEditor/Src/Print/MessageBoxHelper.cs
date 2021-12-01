using System;

namespace XDesignerGUI
{
	/// <summary>
	/// ϵͳ��Ϣ�����ģ��
	/// </summary>
	public sealed class MessageBoxHelper
	{
		/// <summary>
		/// ���Է���ί������
		/// </summary>
		public delegate string TranslateDelegate( string strText );

		/// <summary>
		/// ���Է���ί�ж���
		/// </summary>
		public static TranslateDelegate TranslateHandler = null;

		private static string Translate( string txt )
		{
			if( TranslateHandler == null )
				return txt ;
			else
				return TranslateHandler( txt );
		}

		private static System.Windows.Forms.DialogResult intLastResult
			= System.Windows.Forms.DialogResult.OK ;
		/// <summary>
		/// �û����е����һ��ѡ����
		/// </summary>
		public static System.Windows.Forms.DialogResult LastResult
		{
			get{ return intLastResult ;}
		}
		private static string strTitle = "ϵͳ��ʾ";
		/// <summary>
		/// ��Ϣ�����
		/// </summary>
		public static string Title
		{
			get{ return strTitle;}
			set{ strTitle = value;}
		}
		private static System.Windows.Forms.IWin32Window myOwnerWindow = null;
		/// <summary>
		/// ���������
		/// </summary>
		public static System.Windows.Forms.IWin32Window OwnerWindow
		{
			get{ return myOwnerWindow ;}
			set{ myOwnerWindow = value;}
		}
		
		/// <summary>
		/// ��ʾ��ͨ�ı���Ϣ
		/// </summary>
		/// <param name="txt">�ı���Ϣ</param>
		public static void Alert( string txt )
		{
			intLastResult = System.Windows.Forms.MessageBox.Show( 
				myOwnerWindow ,
				Translate(txt) ,
				Translate(strTitle) ,
				System.Windows.Forms.MessageBoxButtons.OK , 
				System.Windows.Forms.MessageBoxIcon.Information );
		}

		/// <summary>
		/// ��ʾ��ͨ�ı���Ϣ
		/// </summary>
		/// <param name="txt">�ı���Ϣ</param>
		public static void Alert( System.Windows.Forms.IWin32Window OwnerForm , string txt )
		{
			intLastResult = System.Windows.Forms.MessageBox.Show( 
				OwnerForm ,
				Translate(txt) ,
				Translate(strTitle) ,
				System.Windows.Forms.MessageBoxButtons.OK , 
				System.Windows.Forms.MessageBoxIcon.Information );
		}

		/// <summary>
		/// ��ʾһ�������Ϣ
		/// </summary>
		/// <param name="txt">������Ϣ</param>
		public static void AlertExclamation( string txt )
		{
			intLastResult = System.Windows.Forms.MessageBox.Show(
				myOwnerWindow , 
				Translate(txt) , 
				Translate(strTitle) ,
				System.Windows.Forms.MessageBoxButtons.OK ,
				System.Windows.Forms.MessageBoxIcon.Exclamation );
		}

		/// <summary>
		/// ��ʾһ�������Ϣ
		/// </summary>
		/// <param name="txt">������Ϣ</param>
		public static void AlertExclamation( System.Windows.Forms.IWin32Window OwnerForm , string txt )
		{
			intLastResult = System.Windows.Forms.MessageBox.Show(
				OwnerForm , 
				Translate(txt) , 
				Translate(strTitle) ,
				System.Windows.Forms.MessageBoxButtons.OK ,
				System.Windows.Forms.MessageBoxIcon.Exclamation );
		}

		/// <summary>
		/// ��ʾ���ش�����Ϣ
		/// </summary>
		/// <param name="txt">������Ϣ</param>
		public static void AlertStop( string txt )
		{
			intLastResult = System.Windows.Forms.MessageBox.Show(
				myOwnerWindow , 
				Translate(txt) ,
				Translate(strTitle) , 
				System.Windows.Forms.MessageBoxButtons.OK ,
				System.Windows.Forms.MessageBoxIcon.Stop );
		}
		/// <summary>
		/// ���û�����ѡ��
		/// </summary>
		/// <param name="txt">��ʾ��Ϣ</param>
		/// <returns>�û��Ƿ�ѡ��</returns>
		public static bool ConFirm( string txt )
		{
			intLastResult = System.Windows.Forms.MessageBox.Show( 
				myOwnerWindow ,
				Translate(txt) ,
				Translate(strTitle) ,
				System.Windows.Forms.MessageBoxButtons.YesNo ,
				System.Windows.Forms.MessageBoxIcon.Question ) ;
			return intLastResult == System.Windows.Forms.DialogResult.Yes ;
		}
		/// <summary>
		/// ���û���������
		/// </summary>
		/// <param name="txt">��ʾ��Ϣ</param>
		/// <returns>�û�ѡ��,����Ϊ Yes, No, Cancel </returns>
		public static System.Windows.Forms.DialogResult Question( string txt )
		{
			intLastResult = System.Windows.Forms.MessageBox.Show( 
				myOwnerWindow , 
				Translate(txt) ,
				Translate(strTitle) ,
				System.Windows.Forms.MessageBoxButtons.YesNoCancel , 
				System.Windows.Forms.MessageBoxIcon.Question );
			return intLastResult ;
		}

		/// <summary>
		/// ��ʾ�û��Ƿ�����
		/// </summary>
		/// <param name="txt">��ʾ��Ϣ</param>
		/// <returns>�û��Ƿ�ѡ������</returns>
		public static bool Retry( string txt )
		{
			intLastResult = System.Windows.Forms.MessageBox.Show( 
				myOwnerWindow ,
				Translate(txt) , 
				Translate(strTitle) , 
				System.Windows.Forms.MessageBoxButtons.RetryCancel , 
				System.Windows.Forms.MessageBoxIcon.Question );
			return intLastResult == System.Windows.Forms.DialogResult.Retry ;
		}

		/// <summary>
		/// ��ʾ�û��Ƿ���ֹ����ȡ��
		/// </summary>
		/// <param name="txt">��ʾ��Ϣ</param>
		/// <returns>�û�ѡ��,����Ϊ Abort , Rety , Ignore </returns>
		public static System.Windows.Forms.DialogResult AbortRetryIgnore( string txt )
		{
			intLastResult = System.Windows.Forms.MessageBox.Show(
				myOwnerWindow ,
				Translate(txt) ,
				Translate(strTitle) ,
				System.Windows.Forms.MessageBoxButtons.AbortRetryIgnore ,
				System.Windows.Forms.MessageBoxIcon.Question );
			return intLastResult ;
		}

		/// <summary>
		/// ��ʾ�û���,��,ȡ��
		/// </summary>
		/// <param name="txt">��ʾ��Ϣ</param>
		/// <returns>�û�ѡ��,����Ϊ Yes , No , Cancel</returns>
		public static System.Windows.Forms.DialogResult YesNoCancel( string txt )
		{
			intLastResult = System.Windows.Forms.MessageBox.Show(
				myOwnerWindow ,
				Translate(txt) ,
				Translate(strTitle) ,
				System.Windows.Forms.MessageBoxButtons.YesNoCancel , 
				System.Windows.Forms.MessageBoxIcon.Question );
			return intLastResult ;
		}
		/// <summary>
		/// ���캯��,�����󲻿�ʵ����
		/// </summary>
		private MessageBoxHelper()
		{
		}
	}//public sealed class MessageBoxHelper
}