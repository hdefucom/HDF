using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    /// <summary>
    /// 电子病历文本文档对象模型常量定义表
    /// </summary>
    /// <remarks>本模块定义了病历文本文档对象模型中使用的大部分字符串常量,
    /// 其中包括各种类型的元素在XML文档中的名称,属性名称
    /// 此外还定义了一些内部的错误信息</remarks>
    public class ZYTextConst
    {
        public static System.Drawing.Color LockedForeColor = System.Drawing.Color.DimGray;

        //-----------------------------------mfb start------------------------------------------------------

        //mfb 2009-4-28 加入,文档根元素(原来是emrtextdoc)
        public const string c_EMRTextDoc = "document";
        public const string c_Body = "body";
        public const string c_BodyText = "text";

        public const string c_Header = "header"; //add by myc 2014-06-24 添加原因：新版页眉二期改版需要
        public const string c_Footer = "footer"; //add by myc 2014-07-07 添加原因：新版页脚需要

        // 段落元素名
        public const string c_P = "p";
        public const string c_PEOF = "eof";

        public const string c_Div = "div";
        public const string c_Span = "span";

        // 字体设置
        public const string c_FontName = "fontname";
        public const string c_FontSize = "fontsize";
        public const string c_FontBold = "fontbold";
        public const string c_FontUnderLine = "fontunderline";
        public const string c_DoubleFontUnderLine = "doublefontunderline"; //mfb 双下划线
        public const string c_FontItalic = "fontitalic";

        public const string c_FontWavyLine = "fontwavyline";    //mfb 波浪线
        public const string c_FontStrikeout = "fontstrikeout";  //mfb 删除线
        public const string c_DoubleFontStrikeout = "doublefontstrikeout"; //mfb 双删除线



        public const string c_Sub = "sub";		// 下标
        public const string c_Sup = "sup";		// 上标
        public const string c_Align = "align";		// 文本对齐
        public const string c_LineHeightMultiple = "lineheightmultiple";// 行高

        public const string c_ForeColor = "forecolor";	// 文本颜色
        public const string c_Backgroundcolor = "backgroundcolor"; //mfb 背景颜色

        public const string c_CircleFont = "circlefont";//圈字 Add by wwj 2012-05-31


        public const string c_Selement = "selement"; //单选,多选,有无选
        public const string c_FTimeElement = "ftimeelement"; //格式化时间
        public const string c_FNumElement = "fnumelement"; //格式化数字
        public const string c_FStrElement = "fstrelement"; //格式化字符串
        public const string c_RoElement = "roelement"; //固定文本
        public const string c_EMRText = "text"; //文本
        public const string c_BtnElement = "btnelement"; //按钮
        public const string c_Helement = "helement"; //录入提示
        public const string c_MensesFormula = "mensesformula"; //月经史公式
        public const string c_ToothCheck = "toothcheck"; //牙齿检查 add by ywk 2012年11月27日14:56:53
        public const string c_HorizontalLine = "horizontalLine"; //水平线
        public const string c_Macro = "macro"; //宏
        public const string c_Replace = "replace"; //可替换项
        public const string c_Template = "template"; //子模板
        public const string c_CheckBox = "checkbox"; //复选框
        public const string c_PageEnd = "pageend"; //分页符
        public const string c_Flag = "flag"; //定位符

        public const string c_Diag = "diag"; //病人诊断-2019.10.10--hdf
        public const string c_Subject = "subject"; //主诉-2020-12-9 09:20:08  xyw
        public const string c_TableSum = "tablesum"; //2021.05.31-hdf

        public const string c_Table = "table"; //表格
        public const string c_Row = "table-row"; //表格行
        public const string c_Column = "table-column"; //表格列
        public const string c_Cell = "table-cell"; //表格单元格
        public const string c_RowSpan = "rowspan";
        public const string c_ColSpan = "colspan";
        public const string c_LookupEditor = "lookupeditor";//数据选择框
        public const string c_DataElementLookupEditor = "dataelementlookupeditor";//数据选择框

        //-------------------------------------mfb end----------------------------------------------------


        public const string c_ClipboardDataFormat = "emrtextdocument2005";

        public const string c_TextFlag = "textflag";
        public const string c_Lock = "lock";
        public const string c_Script = "script";
        public const string c_LineWidth = "linewidth";
        public const string c_HR = "hr";
        public const string c_Format = "format";
        //public const string c_KB		= "kb";




        //public const string[] RegisteXMLName = {"span","div","image","#text" };
        public const string c_ID = "id";
        public const string c_ValueSource = "valuesource";
        public const string c_SaveMode = "savemode";
        public const string c_Input = "input";
        public const string c_Left = "left";
        public const string c_Top = "top";
        public const string c_Width = "width";
        public const string c_Height = "height";
        public const string c_Elements = "elements";
        public const string c_Element = "element";
        public const string c_Creators = "creators";
        public const string c_Creator = "creator";
        //public const string c_CreateTime= "createtime";
        public const string c_Deleter = "deleter";
        public const string c_Name = "name";
        public const string c_DisplayName = "displayname";
        public const string c_KeyField = "keyfield";
        public const string c_SaveList = "savelist";
        public const string c_SaveInFile = "saveinfile";

        public const string c_Deleted = "deleted";
        //public const string c_DeleteTime = "deletetime";

        public const string c_DataSource = "datasource";

        //后置标点和前置标点来源自word选项中的版式
        // 后置标点符号
        public const string c_TailSob = "!),.:;?]}¨·ˇˉ―‖’”…∶、。〃々〉》」』】〕〗！＂＇），．：；？］｀｜｝～￠\"'";

        // 前置标点
        public const string c_BegSob = "([{·‘“〈《「『【〔〖（．［｛￡￥";

        public const string c_Key = "key";


        // 换行元素名
        public const string c_Br = "br";


        // 数据域标记
        public const string c_Source = "source";
        public const string c_Readonly = "readonly";
        public const string c_Checked = "checked";
        public const string c_ListSource = "listsource";
        public const string c_Field = "field";
        public const string c_Unit = "unit";
        //public const string c_UnitSource= "unitsource";

        // 下拉列表标记
        public const string c_Select = "select";
        //public const string c_ListSource= "listsource";
        public const string c_Options = "options";
        public const string c_Option = "option";
        public const string c_Multiple = "multiple";
        public const string c_Value = "value";
        public const string c_Text = "text";
        public const string c_Selected = "selected";
        public const string c_NoSelect = "<未选择>";
        public const string c_KB = "kb";
        public const string c_KeyWord = "keyword";


        // 文档配置节点
        public const string c_DocSetting = "docsetting";

        // 设置变量
        public const string c_SetValue = "setvalue";




        public const string c_Version = "version";
        public const string c_XMLText = "#text";


        public const int c_ComBoxSize = 16;
        public const int c_ExpendBoxSize = 8;

        public const string c_Expended = "expended";
        public const string c_Title = "title";
        public const string c_HideTitle = "hidetitle";
        public const string c_NoContent = "nocontent";
        public const string c_TitleLine = "titleline";
        public const string c_TitleAlign = "titlealign";



        // 图象
        public const string c_Img = "img";
        public const string c_Src = "src";
        public const string c_ImageByUserID = "imgbyuserid";
        // 表格
        //public const string c_Table = "table";
        //public const string c_Tr = "tr";
        //public const string c_Td = "td";
        //public const string c_RowSpan = "rowspan";
        //public const string c_ColSpan = "colspan";


        // 电子病历文本文档编辑控件的命令列表
        public const string c_CmdRefresh = "refresh";
        public const string c_CmdCopy = "copy";
        public const string c_CmdPaste = "paste";
        public const string c_CmdCut = "cut";
        public const string c_CmdDelete = "delete";
        public const string c_CmdSetFont = "setfont";
        public const string c_CmdSetColor = "setcolor";
        public const string c_CmdSetFontSize = "setfontsize";
        public const string c_CmdSetBold = "setbold";
        public const string c_CmdSetItalic = "setitalic";
        public const string c_CmdSetUnderLine = "setunderline";

        public const string c_CmdSetBorder = "setborder";
        public const string c_CmdSetBKColor = "setbkcolor";

        public const string c_Link = "link";
        public const string c_Href = "href";
        public const string c_Type = "type";

        // 定义一些错误文本信息
        public const string ERR_ImgFileNotFined = "未找到图片文件";

        public const string ExpendToolTip = "展开文本块";
        public const string CollapseToolTip = "收缩文本块";

        //public const string c_EMRTextDocument	= "ZYTextDocument";


        //
        //		/// <summary>
        //		/// 根据XML节点创建一个字体对象
        //		/// </summary>
        //		/// <param name="myElement">XML节点</param>
        //		/// <param name="DefaultValue">默认字体</param>
        //		/// <returns>创建的字体对象</returns>
        //		public static System.Drawing.Font  CreateFontFromXML
        //			(System.Xml.XmlElement myElement,
        //			System.Drawing.Font DefaultValue )
        //		{
        //			try
        //			{
        //				System.Drawing.FontStyle intStyle = System.Drawing.FontStyle.Regular ;
        //				if(myElement.HasAttribute(c_FontBold))
        //					intStyle = intStyle | System.Drawing.FontStyle.Bold ;
        //				if(myElement.HasAttribute(c_FontItalic))
        //					intStyle = intStyle | System.Drawing.FontStyle.Italic ;
        //				if(myElement.HasAttribute(c_FontUnderLine))
        //					intStyle = intStyle | System.Drawing.FontStyle.Underline ;
        //				return new System.Drawing.Font
        //					(myElement.GetAttribute(c_FontName),
        //					Convert.ToSingle(myElement.GetAttribute(c_FontSize)),
        //					intStyle);
        //			}
        //			catch
        //			{
        //				return DefaultValue ;
        //			}
        //		}
        //		/// <summary>
        //		/// 将字体设置保存到一个XML节点中
        //		/// </summary>
        //		/// <param name="myFont">字体对象</param>
        //		/// <param name="myElement">XML节点</param>
        //		/// <returns>操作是否成功</returns>
        //		public static bool SaveFontToXML
        //			(System.Drawing.Font myFont , 
        //			System.Xml.XmlElement myElement)
        //		{
        //			if(myFont != null && myElement != null)
        //			{
        //				myElement.SetAttribute(c_FontName , myFont.Name);
        //				myElement.SetAttribute(c_FontSize,myFont.Size.ToString());
        //				if(myFont.Bold)
        //					myElement.SetAttribute(c_FontBold,"1");
        //				if(myFont.Italic)
        //					myElement.SetAttribute(c_FontItalic,"1");
        //				if(myFont.Underline)
        //					myElement.SetAttribute(c_FontUnderLine,"1");
        //				return true;
        //			}
        //			return false;
        //		}

        public static System.Drawing.Image ImageFromURL(string strURL)
        {
            try
            {
                if (strURL != null)
                {
                    strURL = strURL.Trim();
                    if (strURL.ToLower().StartsWith("http://"))
                    {
                        using (System.Net.WebClient myClient = new System.Net.WebClient())
                        {
                            System.IO.Stream myStream = myClient.OpenRead(strURL);
                            if (myStream != null)
                            {
                                System.Drawing.Image myImage = System.Drawing.Image.FromStream(myStream);
                                myStream.Close();
                                return myImage;
                            }
                        }
                    }
                    else
                    {
                        return System.Drawing.Image.FromFile(strURL);
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

    }
}
