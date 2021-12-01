using System;

namespace XDesignerGUI
{
	/// <summary>
	/// 系统消息框帮助模块
	/// </summary>
	public sealed class MessageBoxHelper
	{
		/// <summary>
		/// 语言翻译委托类型
		/// </summary>
		public delegate string TranslateDelegate( string strText );

		/// <summary>
		/// 语言翻译委托对象
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
		/// 用户进行的最后一次选择结果
		/// </summary>
		public static System.Windows.Forms.DialogResult LastResult
		{
			get{ return intLastResult ;}
		}
		private static string strTitle = "系统提示";
		/// <summary>
		/// 消息框标题
		/// </summary>
		public static string Title
		{
			get{ return strTitle;}
			set{ strTitle = value;}
		}
		private static System.Windows.Forms.IWin32Window myOwnerWindow = null;
		/// <summary>
		/// 父窗体对象
		/// </summary>
		public static System.Windows.Forms.IWin32Window OwnerWindow
		{
			get{ return myOwnerWindow ;}
			set{ myOwnerWindow = value;}
		}
		
		/// <summary>
		/// 显示普通文本信息
		/// </summary>
		/// <param name="txt">文本信息</param>
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
		/// 显示普通文本信息
		/// </summary>
		/// <param name="txt">文本信息</param>
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
		/// 显示一般错误信息
		/// </summary>
		/// <param name="txt">错误信息</param>
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
		/// 显示一般错误信息
		/// </summary>
		/// <param name="txt">错误信息</param>
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
		/// 显示严重错误信息
		/// </summary>
		/// <param name="txt">错误信息</param>
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
		/// 让用户进行选择
		/// </summary>
		/// <param name="txt">提示信息</param>
		/// <returns>用户是否选择</returns>
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
		/// 对用户进行提问
		/// </summary>
		/// <param name="txt">提示信息</param>
		/// <returns>用户选择,可能为 Yes, No, Cancel </returns>
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
		/// 提示用户是否重试
		/// </summary>
		/// <param name="txt">提示信息</param>
		/// <returns>用户是否选择重试</returns>
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
		/// 提示用户是否中止忽略取消
		/// </summary>
		/// <param name="txt">提示信息</param>
		/// <returns>用户选择,可以为 Abort , Rety , Ignore </returns>
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
		/// 提示用户是,否,取消
		/// </summary>
		/// <param name="txt">提示信息</param>
		/// <returns>用户选择,可以为 Yes , No , Cancel</returns>
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
		/// 构造函数,本对象不可实例化
		/// </summary>
		private MessageBoxHelper()
		{
		}
	}//public sealed class MessageBoxHelper
}