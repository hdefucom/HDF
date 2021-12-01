using System;

namespace YidanSoft.Library.EmrEditor.Src.Common
{
	/// <summary>
	/// 按照名称取值的数据列表对象
	/// </summary>
	public class NameValueList
	{
		/// <summary>
		/// 数据名称列表
		/// </summary>
		private string[] strNames	= new string[16];
		/// <summary>
		/// 数据内容列表
		/// </summary>
		private string[] strValues	= new string[16];
		//
		//		private bool bolAutoAdd = true;
		//		private bool bolAutoClearBlank = true;
		/// <summary>
		/// 项目个数
		/// </summary>
		private int  iItemCount = 0 ;

		public string this[int index]
		{
			get{ return strValues[index];}
		}
		public string this[ string strName]
		{
			get{ return this.GetValue( strName);}
		}

		/// <summary>
		/// 清空列表
		/// </summary>
		public void Clear()
		{
			//strNames  = new string[16];
			//strValues = new string[16];
			iItemCount = 0 ;
		}

		/// <summary>
		/// 返回数据的个数
		/// </summary>
		public int Count
		{
			get{ return iItemCount ;}
		}

		/// <summary>
		/// 判断是否存在指定名称的数据项
		/// </summary>
		/// <param name="strName">指定的数据项目的名称</param>
		/// <returns>true 列表存在该名称的项目, false 不存在该名称的项目</returns>
		public bool Contains( string strName )
		{
			for( int iCount = 0 ; iCount < iItemCount ; iCount ++ )
			{
				if( strNames[iCount] == null)
					break;
				if( strNames[iCount].Equals( strName ) )
					return true;
			}
			return false;
		}
		/// <summary>
		/// 判断指定名称的项目的从0开始的序号
		/// </summary>
		/// <param name="strName">项目的名称</param>
		/// <returns>序号,若没找到则返回-1</returns>
		public int IndexOf( string strName)
		{
			if( strName != null)
			{
				for( int iCount = 0 ; iCount < iItemCount ; iCount ++ )
				{
					if( strNames[iCount] == null)
						break;
					if(strName.Equals( strNames[iCount] ) )
						return iCount;
				}
			}
			return -1 ;
		}

		/// <summary>
		/// 获得指定序号的项目名称
		/// </summary>
		/// <param name="index">从0开始的序号</param>
		/// <returns>项目名称</returns>
		public string GetName( int index)
		{
			if( index >=0 && index < iItemCount )
				return strNames[index];
			else
				return null;
		}

		/// <summary>
		/// 获得指定序号的项目的数值
		/// </summary>
		/// <param name="index">从0开始的序号</param>
		/// <returns>数值,若不存在该项目则返回空引用</returns>
		public string GetValue( int index)
		{
			if( index >=0 && index < iItemCount )
				return strValues[index];
			else
				return null;
		}
		/// <summary>
		/// 获得指定名称的项目的数据
		/// </summary>
		/// <param name="strName">项目名称</param>
		/// <returns>项目数值,若不存在该项目则返回空引用</returns>
		public string GetValue( string strName )
		{
			return GetValue( this.IndexOf( strName ));
		}
		/// <summary>
		/// 设置指定名称的项目数据
		/// </summary>
		/// <param name="strName">项目名称</param>
		/// <param name="strValue">项目数据</param>
		public void SetValue( string strName , string strValue)
		{
			if( strName != null)
			{
				int index = this.IndexOf( strName );
				if( index >=0 )
					strValues[index] = strValue ;
				else
				{
					// 当前列表容量不够,需要扩容一半
					if( iItemCount >= strNames.Length-1 )
					{
						string[] strNewNames	= new string[(int)(strNames.Length * 1.5)];
						string[] strNewValues	= new string[strNewNames.Length];
						for(int iCount = 0 ; iCount < iItemCount ; iCount ++ )
						{
							strNewNames[iCount]		= strNames[iCount];
							strNewValues[iCount]	= strValues[iCount];
						}
						strNames	= strNewNames ;
						strValues	= strNewValues ;
					}
					// 添加新元素
					strNames [iItemCount] = strName ;
					strValues[iItemCount] = strValue ;
					iItemCount ++;
				}
			}
		}

		/// <summary>
		/// 删除指定名称的项目
		/// </summary>
		/// <param name="strName">项目名称</param>
		public void Remove( string strName)
		{
			int index = this.IndexOf( strName );
			if( index >=0 )
			{
				for(int iCount = index ; iCount < iItemCount ; iCount ++ )
				{
					strNames[iCount] = strNames[iCount +1];
					strValues[iCount] = strValues[iCount+1];
				}
				strNames[iItemCount-1] = null;
				strValues[iItemCount-1] =null;
				iItemCount -- ;
			}
		}

		/// <summary>
		/// 已重载:将对象转换为字符串
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			System.Text.StringBuilder myStr = new System.Text.StringBuilder();
			myStr.Append("NameValueList(" + iItemCount.ToString() + "):");
			for(int iCount = 0 ; iCount < iItemCount ; iCount ++ )
				myStr.Append( strNames[iCount] + "=" + strValues[iCount] + " " );
			return myStr.ToString();
		}

		/// <summary>
		/// 将对象转换为一个字符串对象数组，该数组中名称和值分隔排列
		/// </summary>
		/// <returns></returns>
		public string[] ToStringArray()
		{
			string[] strOut = new string[ iItemCount * 2 ];
			for(int iCount = 0 ; iCount < iItemCount ; iCount ++ )
			{
				strOut[iCount*2] = strNames[iCount];
				strOut[iCount*2 +1] = strValues[iCount];
			}
			return strOut ;
		}

		/// <summary>
		/// 根据一个字符串数组加载对象数据，该字符串数组是按名称和值分隔排列，且其中元素个数为偶数个
		/// </summary>
		/// <param name="strData">字符串数组</param>
		/// <returns>加载的项目个数，若参数错误则返回-1</returns>
		public int FromStringArray(string[] strData)
		{
			if( strData != null && strData.Length > 0 && strData.Length %2 == 0 )
			{
				iItemCount = strData.Length / 2 ;
				strNames = new string[iItemCount];
				strValues= new string[iItemCount];
				for(int iCount = 0 ; iCount < iItemCount ; iCount ++ )
				{
					strNames[iCount] = (  strData[iCount*2] == null ? "" : strData[iCount*2].Trim());
					strValues[iCount] = strData[iCount*2 +1 ];
				}
				return iItemCount ;
			}
			else
				return -1 ;
		}

		/// <summary>
		/// 将对象数据转换为一个字符串
		/// </summary>
		/// <param name="strItemSpliter">项目间的分隔字符串</param>
		/// <param name="strValueSpliter">项目名称和数据间的分隔字符串</param>
		/// <returns></returns>
		public string ToListString( string strItemSpliter , string strValueSpliter)
		{
			System.Text.StringBuilder myStr = new System.Text.StringBuilder();
			for(int iCount = 0 ; iCount < iItemCount ;iCount ++ )
				if( iCount == 0)
					myStr.Append( strNames[iCount] + strValueSpliter + strValues[iCount]);
				else
					myStr.Append( strItemSpliter + strNames[iCount] + strValueSpliter + strValues[iCount]);
			return myStr.ToString();
		}
		//
		//		public int AppendListString( string strText , string strItemSpliter , string strValueSpliter)
		//		{
		//			if( strText == null || strItemSpliter == null || strValueSpliter == null)
		//				return 0;
		//			int index = strText.IndexOf( strItemSpliter);
		//			int index2 = 0 ;
		//			string strItem = null;
		//			string strName = null;
		//			string strValue = null;
		//			do
		//			{
		//				index2 = strText.IndexOf( strItemSpliter, index );
		//				strItem = strText.Substring( index + strItemSpliter.Length , index2 - index - strItemSpliter.Length);
		//				
		//
		//				
		//			}while(true);
		//
		//		}

		/// <summary>
		/// 使用默认的标记进行项目名替换处理,开头标记为"[" ,结尾标记为"]"
		/// </summary>
		/// <param name="strText"></param>
		/// <returns></returns>
		public string FixVariableString(string strText)
		{
			return FixVariableString( strText ,"[" , "]");
		}

		/// <summary>
		/// 在一个字符串中的项目名称替换成项目值
		/// </summary>
		/// <param name="strText">供处理的原始字符串</param>
		/// <param name="strHead">项目名称的开头标记字符串</param>
		/// <param name="strEnd">项目名称的结尾标记字符串</param>
		/// <returns>处理后的字符串</returns>
		public  string FixVariableString( string strText, string strHead, string strEnd )
		{
			// 若原始字符串无效或者没有任何可用的参数则退出函数
			if(    strText 			== null 
				|| strHead			== null 
				|| strEnd 			== null 
				|| strHead.Length	== 0 
				|| strEnd.Length	== 0 
				|| strText.Length	== 0 )
				return strText ;
			
			int 	index = strText.IndexOf( strHead );
			// 若原始字符串没有变量标记则退出函数
			if(index < 0 ) 
				return strText ;
			
			string 	strKey ;
			int 	index2 ;
			int 	LastIndex = 0 ;
			System.Text.StringBuilder myStr = new System.Text.StringBuilder();
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
					int KeyIndex = this.IndexOf( strKey);
					if( KeyIndex >= 0 )
					{	
						if(LastIndex < index)
						{
							myStr.Append( strText.Substring(LastIndex, index - LastIndex ));
						}
						myStr.Append( strValues[KeyIndex] );
						index = index2 +  strEnd.Length ;
						LastIndex = index ; 
					}
					else
						index = index2 + strEnd.Length ;
				}
				else
				{
					break;
				}
			}while( index >=0 && index < strText.Length );
			// 添加处理过后剩余的字符串
			if(LastIndex < strText.Length   )
				myStr.Append( strText.Substring(LastIndex));
			return myStr.ToString();	
		}// End of function : fixVariableString

		public NameValueList()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
	}
}