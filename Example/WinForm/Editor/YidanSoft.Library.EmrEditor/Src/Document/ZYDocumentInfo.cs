using System;
///////////////////////���л���Ҫ������
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Drawing;
using YidanSoft.Library.EmrEditor.Src.Win32API;
using System.Windows.Forms;
using YidanSoft.Library.EmrEditor.Src.Gui;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
	/// <summary>
	/// ��Ȼ���Ե��Ӳ����ı��ĵ�������Ϣ������
	/// </summary>
	/// <seealso>ZYTextDocumentLib.ZYTextDocument</seealso>
    /// 
    [Serializable]
	public class ZYDocumentInfo
	{
		#region �ĵ���ʾ��ʽ��������Ⱥ ************************************************************

		/// <summary>
		/// ���Ѿ�ǩ�������ݽ�������
		/// </summary>
		public bool MarkLock = true;

		/// <summary>
		/// �ṹ������Ԫ���Ƿ�����»���
		/// </summary>
		public bool FieldUnderLine = true;
		/// <summary>
		/// �����������ĵ�����
		/// </summary>
		public ZYTextDocument OwnerDocument = null;

		 
		/// <summary>
		/// �Զ������߼�ɾ������
		/// </summary>
		/// <remarks>������LogicDelete��־ʱ��������Ч
		/// ���ñ�־����ΪTrue��ǰ�û���ͼɾ��ĳЩ�ĵ�����ʱ,�����ĵ��������ɵ�ǰ�û�������,
		/// �����ɾ����Щ����,�������ֻ�ǽ���Щ���ݼ���ɾ����־�����߼�ɾ��</remarks>
		public bool AutoLogicDelete		= true;
		/// <summary>
		/// �Ƿ�����������־����
		/// </summary>
		public bool EnableSaveLog = true;
		public bool EnableDataSource	= false;
//		/// <summary>
//		/// �����ĵ�ʱ�Ƿ񱣴���ʷ��¼
//		/// </summary>
        public bool SaveHistory = true;
//		/// <summary>
//		/// �����ĵ�ʱ�Ƿ񱣴�ǩ�����
//		/// </summary>
//		public bool SaveMarkLevel = true;
		/// <summary>
		/// ����ģʽ 0:�����������ݵ�XML�ĵ�  1:ֻ���洿�ı����ݵ�XML�ĵ� 2:ֻ����ṹ���ı����ݵ�XML�ĵ� 3:����ΪEMR��XML��ʽ
		/// </summary>
		/// <remarks>�����Ծ���ToXML����ʹ�õı���ģʽ��Ŀǰ���Ӳ����ı��ĵ���ֻ����ΪXML��ʽ�������淽ʽ������
		/// 0�������������ݵ�XML�ĵ�����ʱ�����ĵ����������е���Ϣ�������ܳ���Ϳ�
		///   ���ݱ�����ĵ��������������ĵ����������е����ݼ����ʽ����,ͼƬ����Ҳ�������ĵ���
		///   ͬʱҲ�����û����ĵ����޸ĺۼ���
		///   ��ʱ�ĵ��ı���������ʱ�䣬���ɵ��ļ�����������ĵ��ı���
		/// 1=ֻ���洿�ı����ݣ���ʱ�ĵ�������ͼƬ���ݣ��������ĵ�����ʽ��Ϣ��ֻ����û�б��Ϊ�߼�ɾ��
		///   �Ĵ��ı����ݺͽṹ�����ݣ�������ͼƬ���ݣ���ʱ���ɵ��ļ��Ƚ�С���ʺϽ��п��ٵ��ĵ��ı����ݴ���
		/// 2=ֻ���洿�ı��Ľṹ�����ݣ���ʱ�ĵ�ֻ����ṹ�������ݣ������ı���������б���ʱ���ɵ�
		///   �ĵ���С���ṹ���ã����ڽ�����Խṹ�����ݵ����ݼ�������
		/// 3=�����ĵ��ṹ������Ϊ��Ŀǰ���Ӳ���ϵͳXMLFILERecord���еĵ��Ӳ���XML�ĵ��Ĳ���Ƭ����ͬ��ʽ��XML�ļ�</remarks>
		public int  SaveMode			= 0 ;

		/// <summary>
		/// �Ƿ���ʾ��ҳ��
		/// </summary>
		public bool ShowPageLine		= false;
		/// <summary>
		/// �Ƿ���ʾ������,�������øñ�־������ĵ�ʱ������ƶ����Ǻ��б��
		/// </summary>
		public bool ShowParagraphFlag	= true;

		/// <summary>
		/// �����ĵ�ʱ�Ƿ񱣴�Ԥ���õ��ı�
		/// </summary>
		public bool SavePreViewText = false;

		/// <summary>
		/// ��ʾ�û��ı��������,��С��0��������
		/// </summary>
		public int VisibleUserLevel = -1 ;

		/// <summary>
		/// �ĵ��Ƿ������ģʽ
		/// </summary>
		public bool DesignMode = false ;
		/// <summary>
		/// �м��
		/// </summary>
        //int LineSpacing = 18;
        public int LineSpacing
        {
            get
            {
                if (!Attributes.Contains("linespacing"))
                {
                    //�������������ȡע���Ĭ��ֵ
                    //����Ĭ���о�
                    float f = float.Parse(ZYEditorControl.GetDefaultSettings("linespace"));
                    int rowheight = (int)((float)this.OwnerDocument.View.DefaultRowPixelHeight * f);
                    int value = (int)(rowheight * f);

                    Attributes.SetValue("linespacing", value.ToString());

                    //Attributes.SetValue("linespacing", ZYEditorControl.GetDefaultSettings("linespace"));
                }
                return int.Parse(Attributes.GetString("linespacing"));
            }
            set
            {
                Attributes.SetValue("linespacing", value.ToString());
            }
        }
		/// <summary>
		/// ������
		/// </summary>
        //public int ParagraphSpacing = 18;
        public int ParagraphSpacing
        {
            get
            {
                if (!Attributes.Contains("linespacing"))
                {
                    //�������������ȡע���Ĭ��ֵ
                    //����Ĭ���о�
                    float f = float.Parse(ZYEditorControl.GetDefaultSettings("linespace"));
                    int rowheight = (int)((float)this.OwnerDocument.View.DefaultRowPixelHeight * f);
                    int value = (int)(rowheight * f);

                    Attributes.SetValue("linespacing", value.ToString());
                }
                return int.Parse(Attributes.GetString("linespacing"));
            }
            set
            {
                Attributes.SetValue("linespacing", value.ToString());
            }
        }
		
		/// <summary>
		/// �ĵ��Ƿ��Զ�����
		/// </summary>
		public bool WordWrap = true;

		/// <summary>
		/// �ĵ��Ƿ��ڴ�ӡ��
		/// </summary>
		public bool Printing = false;
		/// <summary>
		/// �û���ɾ������Ϊ�߼�ɾ������
		/// </summary>
		public bool LogicDelete = false;
        /// <summary>
        /// �Ƿ���ʾ�������߼�ɾ����־
        /// </summary>
        public bool ShowMark = true;

		/// <summary>
		/// �Ƿ���ʾ���е�Ԫ��(�����߼�ɾ����Ԫ��),���ñ�־��Ϊfalse���ĵ������Ʊ�����߼�ɾ����Ԫ��
		/// </summary>
		public bool ShowAll = true;
		/// <summary>
		/// ֻ��ʾԭʼ����
		/// </summary>
		//public bool ShowNative = false;
		/// <summary>
		/// �Ƿ�����ı�������ſ��Ƶ�
		/// </summary>
		public bool ShowExpendHandle = false ;

		/// <summary>
		/// ���ĵ�ǩ��ʱ�ı�����
		/// </summary>
		public bool LockForMark = true;

        /// <summary>
        /// �Ƿ�����ִ�нű�
        /// </summary>
        //public bool EnableScript = true;

		/// <summary>
		/// �Ƿ���ʾ�ű����д���
		/// </summary>
		public bool ShowScriptError = true;

		/// <summary>
		/// �Ƿ���ʾ�ű��ı������
		/// </summary>
		public bool ShowScriptCompileError = true;


		//public bool 

		#endregion 


		#region �ĵ�������������Ⱥ ****************************************************************

		public ZYAttributeCollection Attributes = new ZYAttributeCollection();


        public DocumentModel DocumentModel
        {
            get { return (DocumentModel)Enum.Parse(typeof(DocumentModel), Attributes.GetString("documentmodel")); }
            set
            {
                Attributes.SetValue("documentmodel", value.ToString());
                if (value == DocumentModel.Design)
                {
                    this.DesignMode = true;
                }

                if (value == DocumentModel.Clear)
                {
                    #region mfb (���غۼ�) 2009-7-31

                    this.ShowAll = false;
                    this.ShowMark = false;

                    #endregion
                }
                else
                {
                    #region mfb (��ʾ�ۼ�)2009-7-31

                    this.ShowAll = true;
                    this.ShowMark = true;

                    #endregion
                }

                if (value == DocumentModel.Read || value == DocumentModel.Clear)
                {
                    this.OwnerDocument.OwnerControl.bolLockingUI = true;
                    //this.OwnerDocument.Locked = true;
                    //����ʾԪ�ر���ɫ ��textpageviewcontrol.cs ElementBackColor ��ʵ��

                    //��Ҫ�����������¼� �ο� MessageFilter ������bolLockingUIʵ��

                    //��Ҫ��ͬ�ĵ���ʾ״̬//������Ķ�������״̬������ʾ[] {} ��zytextchar RefreshView()������ʵ�� 
                }
                else
                {
                    this.OwnerDocument.OwnerControl.bolLockingUI = false;
                    //this.OwnerDocument.Locked = false;
                }

                this.OwnerDocument.OwnerControl.Refresh();
            }
        }

        public string PatientID
        {
            get { return Attributes.GetString("patientid"); }
            set
            {
                Attributes.SetValue("patientid", value.ToString());
            }
        }

		/// <summary>
		/// ǩ������
		/// </summary>
		public int MarkCount
		{
			get{ return Attributes.GetInt32("markcount");}
			set{ Attributes.SetValue( "markcount" , value);}
		}

		/// <summary>
		/// �ĵ����
		/// </summary>
		public string ID
		{
			get{ return Attributes.GetString("id");}
			set{ Attributes.SetValue("id", value);}
		}
		/// <summary>
		/// �ĵ�����
		/// </summary>
		public string Title
		{
			get{ return Attributes.GetString("title");}
			set{ Attributes.SetValue("title", value);}
		}
        /// <summary>
        /// �ĵ��ļ���
        /// </summary>
        public string FileName
        {
            get { return Attributes.GetString("filename"); }
            set { Attributes.SetValue("filename", value); }
        }

		/// <summary>
		/// �ĵ��汾
		/// </summary>
		public string Version
		{
			get{ return Attributes.GetString("version") ;}
			set{ Attributes.SetValue("version", value);}
		}
		/// <summary>
		/// �ĵ�������
		/// </summary>
		public string  Creator
		{
			get{ return Attributes.GetString("creator") ;}
			set{ Attributes.SetValue("creator", value);}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public string CreateTime
		{
			get{ return Attributes.GetString("createtime") ;}
			set{ Attributes.SetValue("createtime",value) ;}
		}

		/// <summary>
		/// ���һ���޸��� 
		/// </summary>
		public string Modifier
		{
			get{ return Attributes.GetString("modifier");}
			set{ Attributes.SetValue("modifier",value);}
		}
		/// <summary>
		/// �޸�ʱ��
		/// </summary>
		public string ModifyTime
		{
			get{ return Attributes.GetString("modifytime") ;}
			set{ Attributes.SetValue("modifytime",value);}
		}

        public string TmpLevel
        {
            get
            {
                return Attributes.GetString("tmplevel");
            }
            set
            {
                Attributes.SetValue("tmplevel", value);
            }
        }


		/// <summary>
		/// XML�ڵ�����
		/// </summary>
		/// <returns></returns>
		internal static string GetXMLName()
		{
			return "docsetting";
		}

		/// <summary>
		/// ��XML�ڵ���ض�������
		/// </summary>
		/// <param name="myElement"></param>
		/// <returns></returns>
		public bool FromXML(System.Xml.XmlElement myElement)
		{
			if( myElement == null)
			{
				Attributes.Clear();
				this.Version  = "1.0";
			}
			else
			{
				Attributes.FromXML( myElement );
			}
			return true;
		}

		/// <summary>
		/// ����������ݵ�XML�ڵ�
		/// </summary>
		/// <param name="myElement"></param>
		/// <returns></returns>
		public bool ToXML(System.Xml.XmlElement myElement)
		{
			if( myElement != null)
			{
				Attributes.ToXML( myElement );
				return true;
			}
			return false;
		}

		#endregion 

		/// <summary>
		/// ���������ݿ�������һ���ĵ����ö�����
		/// </summary>
		/// <param name="myInfo"></param>
		/// <returns></returns>
		public bool CopyTo(ZYDocumentInfo myInfo)
		{
			if( myInfo != null)
			{
				myInfo.OwnerDocument = OwnerDocument ;
				Attributes.CopyTo( myInfo.Attributes );
				myInfo.FieldUnderLine	= FieldUnderLine ;
				myInfo.ShowMark			= ShowMark;
				myInfo.AutoLogicDelete  = AutoLogicDelete ;
				myInfo.EnableDataSource = EnableDataSource ;
				myInfo.SaveMode			= SaveMode ;
				myInfo.ShowPageLine		= ShowPageLine ;
				myInfo.ShowParagraphFlag = ShowParagraphFlag ;
				myInfo.SavePreViewText	= SavePreViewText ;
				myInfo.VisibleUserLevel = VisibleUserLevel;
				myInfo.DesignMode		= DesignMode ;
				myInfo.LineSpacing		= LineSpacing ;
				myInfo.ParagraphSpacing = ParagraphSpacing ;
				myInfo.WordWrap			= WordWrap;
				myInfo.Printing			= Printing ;
				myInfo.LogicDelete		= LogicDelete ;
				myInfo.ShowAll			= ShowAll ;
				myInfo.ShowExpendHandle = ShowExpendHandle ;
                //myInfo.EnableScript		= EnableScript ;
				myInfo.ShowScriptError	= ShowScriptError ;
				return true;
			}
			return false;
		}

		/// <summary>
		/// ��ʼ������
		/// </summary>
		public ZYDocumentInfo()
		{
            
		}
	}
 
    public enum DocumentModel
    {
        /// <summary>
        /// ģ�����״̬
        /// </summary>
        Design,
        /// <summary>
        /// �༭״̬
        /// </summary>
        Edit,
        /// <summary>
        /// �Ķ�״̬
        /// </summary>
        Read,
        /// <summary>
        /// ������ʾ״̬
        /// </summary>
        Clear,
        /// <summary>
        /// ����״̬
        /// </summary>
        Test
    }
}
