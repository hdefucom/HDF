using System;

namespace XDesignerCommon
{
	/// <summary>
	/// 字符串变量提供者接口
	/// </summary>
	public interface IVariableProvider
	{
		/// <summary>
		/// 判断是否存在指定名称的变量
		/// </summary>
		/// <param name="Name">变量名称</param>
		/// <returns>是否存在指定名称的变量</returns>
		bool Exists( string Name );
		/// <summary>
		/// 获得指定名称的变量值
		/// </summary>
		/// <param name="Name">变量名称</param>
		/// <returns>变量值</returns>
		string Get( string Name );
		/// <summary>
		/// 设置指定名称的变量值
		/// </summary>
		/// <param name="Name">变量名称</param>
		/// <param name="Value">变量值</param>
		void Set( string Name , string Value );
		/// <summary>
		/// 获得所有变量的名称
		/// </summary>
		string[] AllNames
		{
			get;
		}
	}//public interface IVariableProvider

	
	/// <summary>
	/// 使用一个哈希列表来实现的字符串变量提供者对象
	/// </summary>
	public class HashTableVariableProvider : IVariableProvider
	{
		/// <summary>
		/// 初始化对象
		/// </summary>
		public HashTableVariableProvider()
		{
			myValues = new System.Collections.Hashtable();
		}

		/// <summary>
		/// 初始化对象
		/// </summary>
		/// <param name="vars">哈希列表对象</param>
		public HashTableVariableProvider( System.Collections.Hashtable vars )
		{
			myValues = vars ;
		}
		private System.Collections.Hashtable myValues = null;
		/// <summary>
		/// 保存数据的哈希列表
		/// </summary>
		public System.Collections.Hashtable Values
		{
			get{ return myValues ;}
		}
		/// <summary>
		/// 设置变量值
		/// </summary>
		/// <param name="Name">变量名称</param>
		/// <param name="Value">变量值</param>
		public void Set( string Name , string Value )
		{
			myValues[ Name ] = Value ;
		}
		/// <summary>
		/// 判断是否存在指定名称的变量
		/// </summary>
		/// <param name="Name">变量名称</param>
		/// <returns>是否存在指定名称的变量</returns>
		public bool Exists(string Name)
		{
			return myValues.ContainsKey( Name );
		}

		/// <summary>
		/// 获得指定名称的变量值
		/// </summary>
		/// <param name="Name">变量名称</param>
		/// <returns>变量值</returns>
		public string Get(string Name)
		{
			return Convert.ToString( myValues[ Name ] ) ;
		}
		
		/// <summary>
		/// 获得所有变量的名称
		/// </summary>
		public string[] AllNames
		{
			get
			{
				System.Collections.ArrayList list = new System.Collections.ArrayList();
				foreach( object k in myValues.Keys )
				{
					list.Add( Convert.ToString( k ));
				}
				return ( string[] ) list.ToArray( typeof( string ));
			}
		}
	}//public class HashTableVariableProvider : IVariableProvider

	/// <summary>
	/// 使用一个字符串字典来实现的字符串变量提供者对象
	/// </summary>
	public class StringDictionaryVariableProvider : IVariableProvider
	{
		/// <summary>
		/// 初始化对象
		/// </summary>
		public StringDictionaryVariableProvider()
		{
			this.myDictionary = new System.Collections.Specialized.StringDictionary();
		}

		/// <summary>
		/// 初始化对象
		/// </summary>
		/// <param name="dir">字符串字典对象</param>
		public StringDictionaryVariableProvider( System.Collections.Specialized.StringDictionary dir )
		{
			this.myDictionary = dir ;
		}
		private System.Collections.Specialized.StringDictionary myDictionary = null;
		/// <summary>
		/// 字符串字典对象
		/// </summary>
		public System.Collections.Specialized.StringDictionary Dictionary
		{
			get{ return myDictionary ;}
			set{ myDictionary = value;}
		}
		/// <summary>
		/// 设置变量值
		/// </summary>
		/// <param name="Name">变量名称</param>
		/// <param name="Value">变量值</param>
		public void Set( string Name , string Value )
		{
			myDictionary[ Name ] = Value ;
		}
		/// <summary>
		/// 判断是否存在指定名称的变量
		/// </summary>
		/// <param name="Name">变量名称</param>
		/// <returns>是否存在指定名称的变量</returns>
		public bool Exists(string Name)
		{
			return myDictionary.ContainsKey( Name );
		}

		/// <summary>
		/// 获得指定名称的变量值
		/// </summary>
		/// <param name="Name">变量名称</param>
		/// <returns>变量值</returns>
		public string Get(string Name)
		{
			return myDictionary[ Name ] ;
		}
		
		/// <summary>
		/// 获得所有变量的名称
		/// </summary>
		public string[] AllNames
		{
			get
			{
				return null;
			}
		}
	}//public class StringDictionaryVariableProvider : IVariableProvider

	/// <summary>
	/// 内部可嵌入变量域的字符串处理对象
	/// </summary>
	public class VariableString
	{
		/// <summary>
		/// 初始化对象
		/// </summary>
		public VariableString()
		{
		}
		/// <summary>
		/// 初始化对象
		/// </summary>
		/// <param name="txt">字符串数据</param>
		public VariableString( string txt )
		{
			strText = txt ;
		}
		private string strVariablePrefix = "[%" ;
		/// <summary>
		/// 变量域前缀
		/// </summary>
		public string VariablePrefix
		{
			get{ return strVariablePrefix ;}
			set{ strVariablePrefix = value;}
		}
		private string strVariableEndfix = "%]";
		/// <summary>
		/// 变量域后缀
		/// </summary>
		public string VariableEndfix
		{
			get{ return strVariableEndfix ;}
			set{ strVariableEndfix = value;}
		}
		private IVariableProvider myVariables = new HashTableVariableProvider();
		/// <summary>
		/// 变量提供者,默认为一个 HashTableVariableProvider 类型的对象
		/// </summary>
		public IVariableProvider Variables
		{
			get{ return myVariables ;}
			set{ myVariables = value;}
		}
		/// <summary>
		/// 设置变量
		/// </summary>
		/// <param name="strName">变量名称</param>
		/// <param name="strValue">变量值</param>
		public void SetVariable( string strName, string strValue )
		{
			if( myVariables != null )
				myVariables.Set( strName , strValue );
		}
		private string strText = null;
		/// <summary>
		/// 字符串数据
		/// </summary>
		public string Text
		{
			get{ return strText ;}
			set{ strText = value;}
		}
		/// <summary>
		/// 获得字符串中包含的变量名称
		/// </summary>
		/// <returns>变量名称组成的字符串数组</returns>
		public string[] GetVariableNames( )
		{
			string[] strItems = AnalyseVariableString( strText , strVariablePrefix , strVariableEndfix );
			if( strItems != null )
			{
				System.Collections.ArrayList list = new System.Collections.ArrayList();
				for( int iCount = 1 ; iCount < strItems.Length ; iCount += 2 )
				{
					list.Add( strItems[ iCount ] );
				}
				return ( string[] ) list.ToArray( typeof( string ));
			}
			return null;
		}

		/// <summary>
		/// 执行变量
		/// </summary>
		/// <returns>处理后的字符串</returns>
		public string Execute()
		{
			return Execute( this.strText , null );
		}
		/// <summary>
		/// 执行变量
		/// </summary>
		/// <param name="txt">原始字符串</param>
		/// <param name="ParameterValues">保存参数的列表</param>
		/// <returns>处理后的字符串</returns>
		public string Execute( string txt , System.Collections.ArrayList ParameterValues )
		{
			if( this.myVariables == null )
				throw new System.InvalidOperationException("未设置 Variables 属性");

			if( txt == null || txt.Length == 0 )
				return txt ;

			string[] strItems = AnalyseVariableString( txt , strVariablePrefix , strVariableEndfix );
			if( strItems == null )
				return null;
			System.Text.StringBuilder myStr = new System.Text.StringBuilder();
			for( int iCount = 0 ; iCount < strItems.Length ; iCount ++ )
			{
				if( ( iCount % 2 ) == 0 )
					myStr.Append( strItems[ iCount ] );
				else
				{
					string strName = strItems[ iCount ] ;
					bool bolParameter = strName.StartsWith("@");
					if( bolParameter )
					{
						strName = strName.Substring( 1 );
					}
					string strValue = null;
					if( myVariables.Exists( strName ))
						strValue = myVariables.Get( strName );
					else
					{
						strValue = "";
					}
					if( ParameterValues != null && bolParameter )
					{
						ParameterValues.Add( strValue );
						myStr.Append( " ? " );
					}
					else
						myStr.Append( strValue );
				}
			}
			return myStr.ToString();
		}

		/// <summary>
		/// 分析一个字符串,根据开始字符串和结束字符串进行分割,并返回分割生成的字符串数组
		/// 这些字符串数组的偶数号元素为开始字符串和结束字符串间的部分
		/// 例如分析字符串"aaa[bbb]ccc"产生字符串数组"aaa","bbb","ccc"
		/// </summary>
		/// <param name="strText">供分析的字符串</param>
		/// <param name="strHead">开始字符串</param>
		/// <param name="strEnd">结束字符串</param>
		/// <returns>生成的字符串数组</returns>
		private static string[] AnalyseVariableString(
			string strText ,
			string strHead , 
			string strEnd )
		{
			// 若原始字符串无效或者没有任何可用的参数则退出函数
			if(    strText 			== null 
				|| strHead			== null 
				|| strEnd 			== null 
				|| strHead.Length	== 0 
				|| strEnd.Length	== 0 
				|| strText.Length	== 0 )
				return new string[]{ strText };
			
			int 	index = strText.IndexOf( strHead );
			// 若原始字符串没有变量标记则退出函数
			if(index < 0 ) 
				return new string[]{ strText } ;
			
			System.Collections.ArrayList myList = new System.Collections.ArrayList();
			string 	strKey ;
			int 	index2 ;
			int 	LastIndex = 0 ;
			do
			{	
				// 查找有 "[内容]" 样式的子字符串
				// 若没有找到 "[" 和 "]"的字符对则退出循环
				index2 = strText.IndexOf( strEnd ,  index + 1  );
				if(index2 > index)
				{
					// 若 "[" 符号后面出现 "]"符号则存在 "[]"字符对
					// 修正查找结果以保证 "[]"字符对中不出现字符 "["
					int index3 = index ;
					do
					{
						index = index3 ;
						index3 = strText.IndexOf(strHead, index3 + 1 );
					}while( index3 > index && index3 < index2 ) ;
				
					// 获得字符对夹着的子字符串,该子字符串为参数名
					// 若该参数名有效则向输出结果输出参数值
					// 否则不进行额外的处理
					strKey = strText.Substring(index + strHead.Length ,  index2 - index - strHead.Length  );
					if(LastIndex < index)
						myList.Add( strText.Substring(LastIndex, index - LastIndex ));
					else
						myList.Add( "" );
					myList.Add( strKey );
					index = index2 +  strEnd.Length ;
					LastIndex = index ; 
				}
				else
				{
					break;
				}
			}while( index >=0 && index < strText.Length );
			// 添加处理过后剩余的字符串
			if(LastIndex < strText.Length   )
				myList.Add( strText.Substring(LastIndex));
			return (string[])myList.ToArray( typeof( string ));
		}//private static string[] AnalyseVariableString
	}//public class VariableString
}