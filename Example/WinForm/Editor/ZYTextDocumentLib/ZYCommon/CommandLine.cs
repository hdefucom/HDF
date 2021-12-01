using System;
using System.Drawing;
using System.IO;
using System.Xml;

namespace ZYCommon
{
	public class CommandLine : NameValueList
	{
		private string strCommandName = null;

		private TextReader myReader = null;

		private TextWriter myWriter = null;

		private XmlTextWriter myXMLWriter = null;

		private string strLastParamName = null;

		private string strParamList = null;

		private string strCommentPreFix = ";";

		private int intCommandIndex = 0;

		private double dblTwipsPerPixelX = 1.0;

		private double dblTwipsPerPixelY = 1.0;

		public double TwipsPerPixelX
		{
			get
			{
				return dblTwipsPerPixelX;
			}
			set
			{
				dblTwipsPerPixelX = value;
			}
		}

		public double TwipsPerPixelY
		{
			get
			{
				return dblTwipsPerPixelY;
			}
			set
			{
				dblTwipsPerPixelY = value;
			}
		}

		public int CommandIndex => intCommandIndex;

		public string LastParamName
		{
			get
			{
				return strLastParamName;
			}
			set
			{
				strLastParamName = value;
			}
		}

		public string CommentPreFix
		{
			get
			{
				return strCommentPreFix;
			}
			set
			{
				if (value == null)
				{
					strCommentPreFix = null;
					return;
				}
				strCommentPreFix = value.Trim();
				if (strCommentPreFix.Length == 0)
				{
					strCommentPreFix = null;
				}
			}
		}

		public string CommandName
		{
			get
			{
				return strCommandName;
			}
			set
			{
				strCommandName = value;
				Clear();
			}
		}

		public TextReader Reader
		{
			get
			{
				return myReader;
			}
			set
			{
				myReader = value;
			}
		}

		public TextWriter Writer
		{
			get
			{
				return myWriter;
			}
			set
			{
				myWriter = value;
				intCommandIndex = 0;
			}
		}

		public XmlTextWriter XMLWriter
		{
			get
			{
				return myXMLWriter;
			}
			set
			{
				myXMLWriter = value;
				intCommandIndex = 0;
			}
		}

		public double XPointToTwips(int XValue)
		{
			return (double)XValue * dblTwipsPerPixelX;
		}

		public double YPointToTwips(int YValue)
		{
			return (double)YValue * dblTwipsPerPixelY;
		}

		public bool CanWrite()
		{
			return myXMLWriter != null || myWriter != null;
		}

		public bool BeginWrite()
		{
			if (!CanWrite())
			{
				return false;
			}
			if (myXMLWriter != null)
			{
				myXMLWriter.WriteStartDocument();
				myXMLWriter.WriteStartElement("cmd");
			}
			return WriteComment("开始记录于" + ZYTime.GetServerTime().ToString("yyyy-MM-dd HH:mm:ss"));
		}

		public bool EndWrite()
		{
			if (!CanWrite())
			{
				return false;
			}
			WriteComment("结束记录于" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
			if (myXMLWriter != null)
			{
				myXMLWriter.WriteEndElement();
				myXMLWriter.WriteEndDocument();
			}
			return true;
		}

		public void SetBoolean(string strName, bool bolValue)
		{
			if (bolValue)
			{
				SetValue(strName, "1");
			}
			else
			{
				SetValue(strName, "0");
			}
		}

		public bool GetBoolean(string strName)
		{
			return GetValue(strName) == "1";
		}

		public void SetBrushIndex(int BrushIndex)
		{
			SetValue("brush", BrushIndex.ToString());
		}

		public void SetPenIndex(int PenIndex)
		{
			SetValue("pen", PenIndex.ToString());
		}

		public void SetFontIndex(int FontIndex)
		{
			SetValue("font", FontIndex.ToString());
		}

		public void SetPoint(Point p)
		{
			SetValue("x", Convert.ToString((double)p.X * dblTwipsPerPixelX));
			SetValue("y", Convert.ToString((double)p.Y * dblTwipsPerPixelY));
		}

		public void SetPoint(int x, int y)
		{
			SetValue("x", Convert.ToString((double)x * dblTwipsPerPixelX));
			SetValue("y", Convert.ToString((double)y * dblTwipsPerPixelY));
		}

		public void SetPoint2(int x, int y)
		{
			SetValue("x2", Convert.ToString((double)x * dblTwipsPerPixelX));
			SetValue("y2", Convert.ToString((double)y * dblTwipsPerPixelY));
		}

		public Point GetPoint()
		{
			try
			{
				return new Point((int)((double)Convert.ToInt32(GetValue("x")) / dblTwipsPerPixelX), (int)((double)Convert.ToInt32(GetValue("y")) / dblTwipsPerPixelY));
			}
			catch
			{
			}
			return Point.Empty;
		}

		public void SetWidth(int vWidth)
		{
			SetValue("width", Convert.ToString((double)vWidth * dblTwipsPerPixelX));
		}

		public int GetWidth()
		{
			return (int)(Convert.ToDouble(GetValue("width")) / dblTwipsPerPixelX);
		}

		public void SetHeight(int vHeight)
		{
			SetValue("height", Convert.ToString((double)vHeight * dblTwipsPerPixelY));
		}

		public int GetHeight()
		{
			return (int)(Convert.ToDouble(GetValue("height")) / dblTwipsPerPixelY);
		}

		public void SetSize(Size vSize)
		{
			SetValue("width", Convert.ToString((double)vSize.Width * dblTwipsPerPixelX));
			SetValue("height", Convert.ToString((double)vSize.Height * dblTwipsPerPixelY));
		}

		public void SetSize(int vWidth, int vHeight)
		{
			SetValue("width", Convert.ToString((double)vWidth * dblTwipsPerPixelX));
			SetValue("height", Convert.ToString((double)vHeight * dblTwipsPerPixelY));
		}

		public Size GetSize()
		{
			try
			{
				return new Size((int)(Convert.ToDouble(GetValue("width")) / dblTwipsPerPixelX), (int)(Convert.ToDouble(GetValue("height")) / dblTwipsPerPixelY));
			}
			catch
			{
			}
			return Size.Empty;
		}

		public void SetRectangle(Rectangle rect)
		{
			SetValue("left", Convert.ToString((double)rect.Left * dblTwipsPerPixelX));
			SetValue("top", Convert.ToString((double)rect.Top * dblTwipsPerPixelY));
			SetValue("width", Convert.ToString((double)rect.Width * dblTwipsPerPixelX));
			SetValue("height", Convert.ToString((double)rect.Height * dblTwipsPerPixelY));
		}

		public void SetRectangle(int x, int y, int width, int height)
		{
			SetValue("left", Convert.ToString((double)x * dblTwipsPerPixelX));
			SetValue("top", Convert.ToString((double)y * dblTwipsPerPixelY));
			SetValue("width", Convert.ToString((double)width * dblTwipsPerPixelX));
			SetValue("height", Convert.ToString((double)height * dblTwipsPerPixelY));
		}

		public Rectangle GetRectangle()
		{
			try
			{
				return new Rectangle((int)(Convert.ToDouble(GetValue("left")) / dblTwipsPerPixelX), (int)(Convert.ToDouble(GetValue("top")) / dblTwipsPerPixelY), (int)(Convert.ToDouble(GetValue("width")) / dblTwipsPerPixelX), (int)(Convert.ToDouble(GetValue("height")) / dblTwipsPerPixelY));
			}
			catch
			{
			}
			return Rectangle.Empty;
		}

		public void SetColor(Color vColor)
		{
			SetValue("c", GetColorString(vColor));
		}

		public void SetColor(string strName, Color vColor)
		{
			SetValue(strName, GetColorString(vColor));
		}

		public static string GetColorString(Color vColor)
		{
			return (vColor.B * 65536 + vColor.G * 256 + vColor.R).ToString("X");
		}

		public Color GetColor(string strName)
		{
			try
			{
				int argb = Convert.ToInt32(GetValue(strName));
				Color baseColor = Color.FromArgb(argb);
				return Color.FromArgb(255, baseColor);
			}
			catch
			{
			}
			return Color.Black;
		}

		public Color GetColor()
		{
			return GetColor("c");
		}

		public bool Write(string strCommand)
		{
			strCommandName = strCommand;
			Clear();
			return Write();
		}

		public bool Write(string strCommand, string strParam, string strValue)
		{
			strCommandName = strCommand;
			Clear();
			SetValue(strParam, strValue);
			return Write();
		}

		public bool Write(string strCommand, string Param1, string Value1, string Param2, string Value2)
		{
			strCommandName = strCommand;
			Clear();
			SetValue(Param1, Value1);
			SetValue(Param2, Value2);
			return Write();
		}

		public bool Write()
		{
			if (!CanWrite() || strCommandName == null)
			{
				return false;
			}
			if (myXMLWriter != null)
			{
				myXMLWriter.WriteStartElement(strCommandName);
				for (int i = 0; i < base.Count; i++)
				{
					myXMLWriter.WriteAttributeString(GetName(i), GetValue(i));
				}
				myXMLWriter.WriteEndElement();
			}
			if (myWriter != null)
			{
				myWriter.WriteLine("");
				myWriter.Write(strCommandName);
				bool flag = false;
				for (int i = 0; i < base.Count; i++)
				{
					if (strLastParamName == null || !strLastParamName.Equals(GetName(i)))
					{
						myWriter.Write(' ');
						myWriter.Write(GetName(i));
						myWriter.Write("=");
						myWriter.Write(GetValue(i));
					}
					else
					{
						flag = true;
					}
				}
				if (flag)
				{
					myWriter.Write(' ');
					myWriter.Write(strLastParamName);
					myWriter.Write('=');
					myWriter.Write(GetValue(strLastParamName));
				}
			}
			strCommandName = null;
			Clear();
			return true;
		}

		public bool WriteComment(string strComment)
		{
			if (!CanWrite())
			{
				return false;
			}
			if (myXMLWriter != null)
			{
				myXMLWriter.WriteComment(strComment);
			}
			if (myWriter != null)
			{
				myWriter.WriteLine("");
				myWriter.Write(strCommentPreFix);
				myWriter.Write(strComment);
			}
			return true;
		}

		public bool ReadNextCommand()
		{
			if (myReader != null)
			{
				string text;
				for (text = myReader.ReadLine(); text != null; text = myReader.ReadLine())
				{
					string text2 = text.Trim();
					if (text2.Length > 0 && (strCommentPreFix == null || !text2.StartsWith(strCommentPreFix)))
					{
						break;
					}
				}
				if (text != null && text.Length > 0)
				{
					strParamList = null;
					strCommandName = null;
					bool flag = false;
					for (int i = 0; i < text.Length; i++)
					{
						if (char.IsWhiteSpace(text[i]))
						{
							if (flag)
							{
								strCommandName = text.Substring(0, i).Trim();
							}
							continue;
						}
						flag = true;
						if (strCommandName != null)
						{
							text = text.Substring(i);
							break;
						}
					}
					if (strCommandName == null)
					{
						strCommandName = text.Trim();
						strParamList = null;
					}
					intCommandIndex++;
					return true;
				}
			}
			return false;
		}

		public void AnlayseParam()
		{
			Clear();
			string[] strData = StringCommon.AnalyseSingleLineParams(strParamList, strLastParamName, AllowSameName: false);
			FromStringArray(strData);
		}
	}
}
