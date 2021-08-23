using System;

namespace YidanSoft.Library.EmrEditor.Src.Common
{
	/// <summary>
	/// ��������ȡֵ�������б����
	/// </summary>
	public class NameValueList
	{
		/// <summary>
		/// ���������б�
		/// </summary>
		private string[] strNames	= new string[16];
		/// <summary>
		/// ���������б�
		/// </summary>
		private string[] strValues	= new string[16];
		//
		//		private bool bolAutoAdd = true;
		//		private bool bolAutoClearBlank = true;
		/// <summary>
		/// ��Ŀ����
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
		/// ����б�
		/// </summary>
		public void Clear()
		{
			//strNames  = new string[16];
			//strValues = new string[16];
			iItemCount = 0 ;
		}

		/// <summary>
		/// �������ݵĸ���
		/// </summary>
		public int Count
		{
			get{ return iItemCount ;}
		}

		/// <summary>
		/// �ж��Ƿ����ָ�����Ƶ�������
		/// </summary>
		/// <param name="strName">ָ����������Ŀ������</param>
		/// <returns>true �б���ڸ����Ƶ���Ŀ, false �����ڸ����Ƶ���Ŀ</returns>
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
		/// �ж�ָ�����Ƶ���Ŀ�Ĵ�0��ʼ�����
		/// </summary>
		/// <param name="strName">��Ŀ������</param>
		/// <returns>���,��û�ҵ��򷵻�-1</returns>
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
		/// ���ָ����ŵ���Ŀ����
		/// </summary>
		/// <param name="index">��0��ʼ�����</param>
		/// <returns>��Ŀ����</returns>
		public string GetName( int index)
		{
			if( index >=0 && index < iItemCount )
				return strNames[index];
			else
				return null;
		}

		/// <summary>
		/// ���ָ����ŵ���Ŀ����ֵ
		/// </summary>
		/// <param name="index">��0��ʼ�����</param>
		/// <returns>��ֵ,�������ڸ���Ŀ�򷵻ؿ�����</returns>
		public string GetValue( int index)
		{
			if( index >=0 && index < iItemCount )
				return strValues[index];
			else
				return null;
		}
		/// <summary>
		/// ���ָ�����Ƶ���Ŀ������
		/// </summary>
		/// <param name="strName">��Ŀ����</param>
		/// <returns>��Ŀ��ֵ,�������ڸ���Ŀ�򷵻ؿ�����</returns>
		public string GetValue( string strName )
		{
			return GetValue( this.IndexOf( strName ));
		}
		/// <summary>
		/// ����ָ�����Ƶ���Ŀ����
		/// </summary>
		/// <param name="strName">��Ŀ����</param>
		/// <param name="strValue">��Ŀ����</param>
		public void SetValue( string strName , string strValue)
		{
			if( strName != null)
			{
				int index = this.IndexOf( strName );
				if( index >=0 )
					strValues[index] = strValue ;
				else
				{
					// ��ǰ�б���������,��Ҫ����һ��
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
					// �����Ԫ��
					strNames [iItemCount] = strName ;
					strValues[iItemCount] = strValue ;
					iItemCount ++;
				}
			}
		}

		/// <summary>
		/// ɾ��ָ�����Ƶ���Ŀ
		/// </summary>
		/// <param name="strName">��Ŀ����</param>
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
		/// ������:������ת��Ϊ�ַ���
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
		/// ������ת��Ϊһ���ַ����������飬�����������ƺ�ֵ�ָ�����
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
		/// ����һ���ַ���������ض������ݣ����ַ��������ǰ����ƺ�ֵ�ָ����У�������Ԫ�ظ���Ϊż����
		/// </summary>
		/// <param name="strData">�ַ�������</param>
		/// <returns>���ص���Ŀ�����������������򷵻�-1</returns>
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
		/// ����������ת��Ϊһ���ַ���
		/// </summary>
		/// <param name="strItemSpliter">��Ŀ��ķָ��ַ���</param>
		/// <param name="strValueSpliter">��Ŀ���ƺ����ݼ�ķָ��ַ���</param>
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
		/// ʹ��Ĭ�ϵı�ǽ�����Ŀ���滻����,��ͷ���Ϊ"[" ,��β���Ϊ"]"
		/// </summary>
		/// <param name="strText"></param>
		/// <returns></returns>
		public string FixVariableString(string strText)
		{
			return FixVariableString( strText ,"[" , "]");
		}

		/// <summary>
		/// ��һ���ַ����е���Ŀ�����滻����Ŀֵ
		/// </summary>
		/// <param name="strText">�������ԭʼ�ַ���</param>
		/// <param name="strHead">��Ŀ���ƵĿ�ͷ����ַ���</param>
		/// <param name="strEnd">��Ŀ���ƵĽ�β����ַ���</param>
		/// <returns>�������ַ���</returns>
		public  string FixVariableString( string strText, string strHead, string strEnd )
		{
			// ��ԭʼ�ַ�����Ч����û���κο��õĲ������˳�����
			if(    strText 			== null 
				|| strHead			== null 
				|| strEnd 			== null 
				|| strHead.Length	== 0 
				|| strEnd.Length	== 0 
				|| strText.Length	== 0 )
				return strText ;
			
			int 	index = strText.IndexOf( strHead );
			// ��ԭʼ�ַ���û�б���������˳�����
			if(index < 0 ) 
				return strText ;
			
			string 	strKey ;
			int 	index2 ;
			int 	LastIndex = 0 ;
			System.Text.StringBuilder myStr = new System.Text.StringBuilder();
			do
			{	
				// ������ "[����]" ��ʽ�����ַ���
				// ��û���ҵ� "[" �� "]"���ַ������˳�ѭ��
				index2 = strText.IndexOf( strEnd ,  index + 1  );
				if(index2 > index)
				{
					// �� "[" ���ź������ "]"��������� "[]"�ַ���
					// �������ҽ���Ա�֤ "[]"�ַ����в������ַ� "["
					int index3 = index ;
					do
					{
						index = index3 ;
						index3 = strText.IndexOf(strHead, index3 + 1 );
					}while( index3 > index && index3 < index2 ) ;
				
					// ����ַ��Լ��ŵ����ַ���,�����ַ���Ϊ������
					// ���ò�������Ч�����������������ֵ
					// ���򲻽��ж���Ĵ���
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
			// ��Ӵ������ʣ����ַ���
			if(LastIndex < strText.Length   )
				myStr.Append( strText.Substring(LastIndex));
			return myStr.ToString();	
		}// End of function : fixVariableString

		public NameValueList()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
	}
}