using System;
///////////////////////序列化需要的引用
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Drawing;
using YidanSoft.Library.EmrEditor.Src.Win32API;
using System.Windows.Forms;
using YidanSoft.Library.EmrEditor.Src.Gui;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
	/// <summary>
	/// 自然语言电子病历文本文档基本信息及设置
	/// </summary>
	/// <seealso>ZYTextDocumentLib.ZYTextDocument</seealso>
    /// 
    [Serializable]
	public class ZYDocumentInfo
	{
		#region 文档显示样式控制属性群 ************************************************************

		/// <summary>
		/// 对已经签名的数据进行锁定
		/// </summary>
		public bool MarkLock = true;

		/// <summary>
		/// 结构化数据元素是否绘制下划线
		/// </summary>
		public bool FieldUnderLine = true;
		/// <summary>
		/// 对象所属的文档对象
		/// </summary>
		public ZYTextDocument OwnerDocument = null;

		 
		/// <summary>
		/// 自动进行逻辑删除操作
		/// </summary>
		/// <remarks>当设置LogicDelete标志时该设置有效
		/// 若该标志设置为True则当前用户试图删除某些文档内容时,若该文档内容是由当前用户创建的,
		/// 则程序将删除这些内容,否则程序只是将这些内容加上删除标志进行逻辑删除</remarks>
		public bool AutoLogicDelete		= true;
		/// <summary>
		/// 是否启动保存日志功能
		/// </summary>
		public bool EnableSaveLog = true;
		public bool EnableDataSource	= false;
//		/// <summary>
//		/// 保存文档时是否保存历史记录
//		/// </summary>
        public bool SaveHistory = true;
//		/// <summary>
//		/// 保存文档时是否保存签名层次
//		/// </summary>
//		public bool SaveMarkLevel = true;
		/// <summary>
		/// 保存模式 0:保存所有数据到XML文档  1:只保存纯文本数据到XML文档 2:只保存结构化文本数据到XML文档 3:保存为EMR的XML格式
		/// </summary>
		/// <remarks>本属性决定ToXML函数使用的保存模式，目前电子病历文本文档都只保存为XML格式，但保存方式有三种
		/// 0＝保存所有数据到XML文档，此时保存文档对象中所有的信息，这样能程序就可
		///   根据保存的文档而完整的再现文档，包括所有的内容及其格式控制,图片数据也保存在文档中
		///   同时也保存用户对文档的修改痕迹。
		///   此时文档的保存操作最耗时间，生成的文件最大，适用于文档的保存
		/// 1=只保存纯文本数据，此时文档不保存图片数据，不保存文档的样式信息，只保存没有标记为逻辑删除
		///   的纯文本数据和结构化数据，不保存图片数据，此时生成的文件比较小，适合进行快速的文档文本内容处理
		/// 2=只保存纯文本的结构化数据，此时文档只保存结构化的数据，例如文本框和下拉列表，此时生成的
		///   文档最小，结构良好，适于进行针对结构化数据的数据检索处理
		/// 3=保持文档结构化数据为和目前电子病历系统XMLFILERecord表中的电子病历XML文档的病历片断相同格式的XML文件</remarks>
		public int  SaveMode			= 0 ;

		/// <summary>
		/// 是否显示分页符
		/// </summary>
		public bool ShowPageLine		= false;
		/// <summary>
		/// 是否显示段落标记,若不设置该标志则绘制文档时不会绘制段落标记和行标记
		/// </summary>
		public bool ShowParagraphFlag	= true;

		/// <summary>
		/// 保存文档时是否保存预览用的文本
		/// </summary>
		public bool SavePreViewText = false;

		/// <summary>
		/// 显示用户文本层次限制,若小于0则无限制
		/// </summary>
		public int VisibleUserLevel = -1 ;

		/// <summary>
		/// 文档是否处于设计模式
		/// </summary>
		public bool DesignMode = false ;
		/// <summary>
		/// 行间距
		/// </summary>
        //int LineSpacing = 18;
        public int LineSpacing
        {
            get
            {
                if (!Attributes.Contains("linespacing"))
                {
                    //如果不包含，读取注册表默认值
                    //设置默认行距
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
		/// 段落间距
		/// </summary>
        //public int ParagraphSpacing = 18;
        public int ParagraphSpacing
        {
            get
            {
                if (!Attributes.Contains("linespacing"))
                {
                    //如果不包含，读取注册表默认值
                    //设置默认行距
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
		/// 文档是否自动换行
		/// </summary>
		public bool WordWrap = true;

		/// <summary>
		/// 文档是否处于打印中
		/// </summary>
		public bool Printing = false;
		/// <summary>
		/// 用户的删除操作为逻辑删除操作
		/// </summary>
		public bool LogicDelete = false;
        /// <summary>
        /// 是否显示新增或逻辑删除标志
        /// </summary>
        public bool ShowMark = true;

		/// <summary>
		/// 是否显示所有的元素(包括逻辑删除的元素),若该标志设为false则文档不绘制被标记逻辑删除的元素
		/// </summary>
		public bool ShowAll = true;
		/// <summary>
		/// 只显示原始数据
		/// </summary>
		//public bool ShowNative = false;
		/// <summary>
		/// 是否绘制文本块的缩放控制点
		/// </summary>
		public bool ShowExpendHandle = false ;

		/// <summary>
		/// 当文档签名时文本锁定
		/// </summary>
		public bool LockForMark = true;

        /// <summary>
        /// 是否允许执行脚本
        /// </summary>
        //public bool EnableScript = true;

		/// <summary>
		/// 是否显示脚本运行错误
		/// </summary>
		public bool ShowScriptError = true;

		/// <summary>
		/// 是否显示脚本的编译错误
		/// </summary>
		public bool ShowScriptCompileError = true;


		//public bool 

		#endregion 


		#region 文档内容设置属性群 ****************************************************************

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
                    #region mfb (隐藏痕迹) 2009-7-31

                    this.ShowAll = false;
                    this.ShowMark = false;

                    #endregion
                }
                else
                {
                    #region mfb (显示痕迹)2009-7-31

                    this.ShowAll = true;
                    this.ShowMark = true;

                    #endregion
                }

                if (value == DocumentModel.Read || value == DocumentModel.Clear)
                {
                    this.OwnerDocument.OwnerControl.bolLockingUI = true;
                    //this.OwnerDocument.Locked = true;
                    //不显示元素背景色 在textpageviewcontrol.cs ElementBackColor 中实现

                    //需要屏蔽鼠标键盘事件 参考 MessageFilter ，改用bolLockingUI实现

                    //需要不同的的显示状态//如果是阅读或整洁状态，不显示[] {} 在zytextchar RefreshView()方法中实现 
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
		/// 签名个数
		/// </summary>
		public int MarkCount
		{
			get{ return Attributes.GetInt32("markcount");}
			set{ Attributes.SetValue( "markcount" , value);}
		}

		/// <summary>
		/// 文档编号
		/// </summary>
		public string ID
		{
			get{ return Attributes.GetString("id");}
			set{ Attributes.SetValue("id", value);}
		}
		/// <summary>
		/// 文档标题
		/// </summary>
		public string Title
		{
			get{ return Attributes.GetString("title");}
			set{ Attributes.SetValue("title", value);}
		}
        /// <summary>
        /// 文档文件名
        /// </summary>
        public string FileName
        {
            get { return Attributes.GetString("filename"); }
            set { Attributes.SetValue("filename", value); }
        }

		/// <summary>
		/// 文档版本
		/// </summary>
		public string Version
		{
			get{ return Attributes.GetString("version") ;}
			set{ Attributes.SetValue("version", value);}
		}
		/// <summary>
		/// 文档创建者
		/// </summary>
		public string  Creator
		{
			get{ return Attributes.GetString("creator") ;}
			set{ Attributes.SetValue("creator", value);}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public string CreateTime
		{
			get{ return Attributes.GetString("createtime") ;}
			set{ Attributes.SetValue("createtime",value) ;}
		}

		/// <summary>
		/// 最后一次修改者 
		/// </summary>
		public string Modifier
		{
			get{ return Attributes.GetString("modifier");}
			set{ Attributes.SetValue("modifier",value);}
		}
		/// <summary>
		/// 修改时间
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
		/// XML节点名称
		/// </summary>
		/// <returns></returns>
		internal static string GetXMLName()
		{
			return "docsetting";
		}

		/// <summary>
		/// 从XML节点加载对象数据
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
		/// 保存对象数据到XML节点
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
		/// 将对象数据拷贝到另一个文档设置对象中
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
		/// 初始化对象
		/// </summary>
		public ZYDocumentInfo()
		{
            
		}
	}
 
    public enum DocumentModel
    {
        /// <summary>
        /// 模板设计状态
        /// </summary>
        Design,
        /// <summary>
        /// 编辑状态
        /// </summary>
        Edit,
        /// <summary>
        /// 阅读状态
        /// </summary>
        Read,
        /// <summary>
        /// 整洁显示状态
        /// </summary>
        Clear,
        /// <summary>
        /// 测试状态
        /// </summary>
        Test
    }
}
