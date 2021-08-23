using System;
using YidanSoft.Library.EmrEditor.Src.Common;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
	/// <summary>
	/// ��ʾǩ������ļ���
	/// </summary>
	public class UnderWriteMarkCollection : IXMLSerializable , System.Collections.IEnumerable
	{


		/// <summary>
		/// �ö������ڵ��ĵ�����
		/// </summary>
		public ZYTextDocument OwnerDocument ;
		/// <summary>
		/// �ö������ڵ�Ԫ�ض���
		/// </summary>
		public ZYTextElement  OwnerElement ;

		/// <summary>
		/// �Ƿ��������ǩ��
		/// </summary>
		public bool Enable = true;

		private System.Collections.ArrayList myItems = new System.Collections.ArrayList();

		

//		/// <summary>
//		/// �ö����ڲ����б����
//		/// </summary>
//		public System.Collections.ArrayList Items
//		{
//			get{ return myItems;}
//		}

		
		/// <summary>
		/// �ж�����Ƿ���Ч
		/// </summary>
		/// <param name="Index"></param>
		/// <returns></returns>
		public bool IndexAvailable(int Index)
		{
			return Index >=0 && Index < myItems.Count ;
		}

		/// <summary>
		/// ǩ����¼�ĸ���
		/// </summary>
		public int Count
		{
			get{ return myItems.Count ;}
		}
		/// <summary>
		/// ���ָ����ŵ�ǩ������
		/// </summary>
		public UnderWriteMark this[int index]
		{
			get{ return ( UnderWriteMark ) myItems[index];}
		}
		/// <summary>
		/// ������һ��ǩ������
		/// </summary>
		public UnderWriteMark LastMark
		{
			get{ return ( UnderWriteMark ) myItems[myItems.Count -1 ]; }
		}

		/// <summary>
		/// ������һ��ǩ��ָ������һ��ǩ����
		/// </summary>
		public string LastSenior
		{
			get
			{
				if( myItems.Count > 0 )
				{
					return ( ( UnderWriteMark ) myItems[myItems.Count -1 ] ).Senior ;
				}
				return null;
			}
		}

		/// <summary>
		/// �ж�ָ�����û����Ƿ����ǩ��
		/// </summary>
		/// <param name="strUserName">�û���</param>
		/// <returns>�Ƿ����ǩ��</returns>
		public bool CanMark( string strUserName)
		{
			if( myItems.Count > 0 )
			{
				string ls = this.LastSenior ;
				if( ls == null || ls.Length == 0 )
					return true;
				else
					return ls == strUserName ;
			}
			return true;
		}

		/// <summary>
		/// �½���ǩ������
		/// </summary>
		public UnderWriteMark NewMark = null;

		/// <summary>
		/// ���һ��ǩ��
		/// </summary>
		/// <param name="strUserName">ǩ����</param>
		/// <param name="strSenior">ǩ����ָ������һ��ǩ����</param>
		/// <returns>������ǩ������,��ǩ��ʧ���򷵻ؿ�����</returns>
		public UnderWriteMark AddMark( string strUserName , string strSenior )
		{
			if( myItems.Count > 0 )
			{
				string sn = this.LastSenior ;
				if( sn != null && sn.Length > 0 )
				{
					if( sn != strUserName )
						return null;
				}
			}
			NewMark = new UnderWriteMark();
			NewMark.UserName = strUserName ;
			NewMark.Senior = strSenior ;
			//NewMark.MarkTime = System.DateTime.Now ;
			NewMark.MarkTime = ZYTime.GetServerTime();
			myItems.Add( NewMark );
			if( OwnerDocument != null)
			{
                //NewMark.SaveLogIndex = OwnerDocument.SaveLogs.CurrentIndex ;
                //OwnerDocument.UpdateUserName();
			}
			//
			//				if( OwnerElement != null && OwnerElement is ZYTextContainer)
			//				{
			//					( OwnerElement as ZYTextContainer).UpdateUserLogin();
			//					OwnerElement.OwnerDocument.Refresh();
			//				}
			return NewMark;
		}

		/// <summary>
		/// ɾ�����е�ǩ������
		/// </summary>
		public void Clear()
		{
			myItems.Clear();
		}

		public string[] ToStringArray()
		{
			string[] strItems = new string[ myItems.Count ];
			for(int iCount = 0 ; iCount < myItems.Count ; iCount ++ )
			{
				UnderWriteMark m = ( UnderWriteMark ) myItems[iCount];
				strItems[iCount] = m.DisplayText();
			}
			return strItems ;
		}

		public string GetDisplayText()
		{
			System.Text.StringBuilder myStr = new System.Text.StringBuilder();
			foreach(UnderWriteMark m in myItems)
			{
				if( myStr.Length > 0 )
					myStr.Append("\r\n");
				myStr.Append( m.UserName );
				myStr.Append( " ǩ���� ");
				myStr.Append( m.MarkTime.ToString("yyyy��MM��dd�� HH:mm:ss"));
			}
			if( myItems.Count > 0 )
			{
				if( StringCommon.isBlankString( this.LastMark.Senior) ==false)
					myStr.Append("\r\n ������ָ����[ " + this.LastMark.Senior + " ]ǩ��");
			}
			return myStr.ToString();
		}

		#region IXMLSerializable ��Ա

		public string GetXMLName()
		{
			return "underwritemarks";
		}

		public bool FromXML(System.Xml.XmlElement RootElement)
		{
			this.Clear();
			if( RootElement != null)
			{
				foreach(System.Xml.XmlNode myXMLNode in RootElement.ChildNodes)
				{
					if( myXMLNode is System.Xml.XmlElement)
					{
						UnderWriteMark NewMark = new UnderWriteMark();
						NewMark.FromXML( myXMLNode as System.Xml.XmlElement );
						myItems.Add( NewMark );
					}
				}
				return true;
			}
			return false;
		}

		public bool ToXML(System.Xml.XmlElement RootElement)
		{
			if( RootElement != null)
			{
				foreach(UnderWriteMark mark in myItems)
				{
					System.Xml.XmlElement NewElement = RootElement.OwnerDocument.CreateElement(mark.GetXMLName());
					RootElement.AppendChild( NewElement );
					mark.ToXML( NewElement );
				}
				return true;
			}
			return false;
		}
		#endregion

		#region IEnumerable ��Ա

		public System.Collections.IEnumerator GetEnumerator()
		{
			return new myEnumerator(myItems);
		}

		#endregion

		private class myEnumerator : System.Collections.IEnumerator
		{
			private System.Collections.ArrayList myList ;
			private int index ;
			public myEnumerator( System.Collections.ArrayList lst)
			{
				myList = lst ;
				index = -1 ;
			}
			#region IEnumerator ��Ա

			public void Reset()
			{
				index = -1 ;
			}

			public object Current
			{
				get
				{
					return (UnderWriteMark) myList[index];
				}
			}

			public bool MoveNext()
			{
				index ++ ;
				return index < myList.Count ;
			}

			#endregion
		}

	}// class UnderWriteMarkCollection

	/// <summary>
	/// UnderWriteMark ��ժҪ˵����
	/// </summary>
	public class UnderWriteMark : IXMLSerializable
	{
//		/// <summary>
//		/// �ö������ڵ��ĵ�����
//		/// </summary>
//		public ZYTextDocument OwnerDocument ;
//		/// <summary>
//		/// �ö������ڵ�Ԫ�ض���
//		/// </summary>
//		public ZYTextElement OwnerElement ;
		/// <summary>
		/// ǩ����
		/// </summary>
		public string UserName ;
		/// <summary>
		/// ǩ��ʱ��
		/// </summary>
		public System.DateTime MarkTime ;

		/// <summary>
		/// ǩ��ʱ������־����ı��
		/// </summary>
		public int SaveLogIndex ;

		/// <summary>
		/// ǩ����ָ������һ����Ա
		/// </summary>
		public string Senior;
 
//		public string DisplayDateTime
//		{
//			get{ return dtSaveDateTime.ToString("yyyy��MM��dd�� HH:mm");}
//		}
		public string DisplayText()
		{
			return UserName + " ǩ����" + MarkTime.ToString("yyyy��MM��dd�� HH:mm") ;
		}

		#region IXMLSerializable ��Ա

		public string GetXMLName()
		{
			return "underwritemark";
		}

		public bool FromXML(System.Xml.XmlElement RootElement)
		{
			if( RootElement != null)
			{
				UserName = RootElement.GetAttribute("username");
				//MarkTime = StringCommon.ConvertToDateTime( RootElement.GetAttribute("marktime"),null,System.DateTime.Now);
				MarkTime = StringCommon.ConvertToDateTime( RootElement.GetAttribute("marktime"),null,ZYTime.GetServerTime());
				Senior	= RootElement.GetAttribute("senior");
				SaveLogIndex = StringCommon.ToInt32Value( RootElement.GetAttribute("savelog"),0);
				return true;
			}
			return false;
		}

		public bool ToXML(System.Xml.XmlElement RootElement)
		{
			if( RootElement != null)
			{
				RootElement.SetAttribute("username", UserName);
				RootElement.SetAttribute("marktime", MarkTime.ToString("yyyy-MM-dd HH:mm:ss"));
				RootElement.SetAttribute("senior", Senior);
				RootElement.SetAttribute("savelog",SaveLogIndex.ToString());
				return true;
			}
			return false;
		}

		#endregion
	}
}
