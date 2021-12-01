using System.Drawing;
using System.IO;
using System.Net;

namespace ZYTextDocumentLib
{
	public class ZYTextConst
	{
		public const string c_ClipboardDataFormat = "emrtextdocument2005";

		public const string c_TextBox = "textbox";

		public const string c_TextFlag = "textflag";

		public const string c_Lock = "lock";

		public const string c_Script = "script";

		public const string c_LineWidth = "linewidth";

		public const string c_HR = "hr";

		public const string c_Format = "format";

		public const string c_Body = "body";

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

		public const string c_Deleter = "deleter";

		public const string c_Name = "name";

		public const string c_DisplayName = "displayname";

		public const string c_KeyField = "keyfield";

		public const string c_SaveList = "savelist";

		public const string c_SaveInFile = "saveinfile";

		public const string c_Deleted = "deleted";

		public const string c_Span = "span";

		public const string c_DataSource = "datasource";

		public const string c_TailSob = "!),.:;?]}\u00a8·\u02c7\u02c9―‖’”…∶、。〃\u3005〉》」』】〕〗！＂＇），．：；？］\uff40｜｝～￠\"'";

		public const string c_BegSob = "([{·‘“〈《「『【〔〖（．［｛￡￥";

		public const string c_Key = "key";

		public const string c_Div = "div";

		public const string c_Br = "br";

		public const string c_P = "p";

		public const string c_Source = "source";

		public const string c_Readonly = "readonly";

		public const string c_Checked = "checked";

		public const string c_ListSource = "listsource";

		public const string c_Field = "field";

		public const string c_Unit = "unit";

		public const string c_left_border = "leftborder";

		public const string c_top_border = "topborder";

		public const string c_bottom_border = "bottomborder";

		public const string c_right_border = "rightborder";

		public const string c_TextBox_Align = "textalign";

		public const string c_Select = "select";

		public const string c_Options = "options";

		public const string c_Option = "option";

		public const string c_Multiple = "multiple";

		public const string c_Value = "value";

		public const string c_Text = "text";

		public const string c_Selected = "selected";

		public const string c_NoSelect = "<未选择>";

		public const string c_KB = "kb";

		public const string c_KeyWord = "keyword";

		public const string c_IsNeed = "need";

		public const string c_DocSetting = "docsetting";

		public const string c_SetValue = "setvalue";

		public const string c_EMRTextDoc = "emrtextdoc";

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

		public const string c_FontName = "fontname";

		public const string c_FontSize = "fontsize";

		public const string c_FontBold = "fontbold";

		public const string c_FontUnderLine = "fontunderline";

		public const string c_FontItalic = "fontitalic";

		public const string c_Sub = "sub";

		public const string c_Sup = "sup";

		public const string c_Align = "align";

		public const string c_ForeColor = "forecolor";

		public const string c_Img = "img";

		public const string c_Src = "src";

		public const string c_ImgIndex = "imgindex";

		public const string c_ImgFile = "ImgFile";

		public const string c_ImgName = "ImgName";

		public const string c_ImgSourceSrc = "ImgSourceSrc";

		public const string c_Table = "table";

		public const string c_row = "row";

		public const string c_cell = "cell";

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

		public const string ERR_ImgFileNotFined = "未找到图片文件";

		public const string ExpendToolTip = "展开文本块";

		public const string CollapseToolTip = "收缩文本块";

		public static Color LockedForeColor = Color.DimGray;

		public static string c_ContentMark = "contentmark";

		public static Image ImageFromURL(string strURL)
		{
			try
			{
				if (strURL != null)
				{
					strURL = strURL.Trim();
					if (!strURL.ToLower().StartsWith("http://"))
					{
						return Image.FromFile(strURL);
					}
					using (WebClient webClient = new WebClient())
					{
						Stream stream = webClient.OpenRead(strURL);
						if (stream != null)
						{
							Image result = Image.FromStream(stream);
							stream.Close();
							return result;
						}
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
