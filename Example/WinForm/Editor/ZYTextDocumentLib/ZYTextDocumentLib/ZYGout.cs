using System;
using System.Drawing;
using System.Text;
using System.Xml;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ZYGout
	{
		[STAThread]
		private static void Main(string[] args)
		{
			string text = null;
			string text2 = null;
			string text3 = null;
			string text4 = null;
			string text5 = null;
			XMLHttpConnection connection = null;
			for (int i = 0; i < args.Length; i++)
			{
				Console.WriteLine("解析命令行指令 " + args[i]);
				int num = args[i].IndexOf("=");
				if (num > 0)
				{
					text4 = args[i].Substring(0, num);
					text5 = args[i].Substring(num + 1);
				}
				else
				{
					text4 = args[i];
					text5 = null;
				}
				switch (text4.Trim().ToLower())
				{
				case "sp":
					connection = new XMLHttpConnection(text5);
					break;
				case "src":
					text = text5;
					break;
				case "out":
					text2 = text5;
					break;
				case "width":
					text3 = text5;
					break;
				}
			}
			if (text == null || text2 == null)
			{
				Console.WriteLine("参数不够,程序无法运行!");
				return;
			}
			Console.WriteLine("报告文档定义在 " + text);
			Console.WriteLine("输出文件为" + text2);
			try
			{
				Bitmap bitmap = new Bitmap(100, 100);
				Graphics graph = Graphics.FromImage(bitmap);
				ZYTextDocument zYTextDocument = new ZYTextDocument();
				zYTextDocument.DataSource.DBConn.Connection = connection;
				zYTextDocument.Info.ShowMark = false;
				zYTextDocument.Info.ShowAll = false;
				zYTextDocument.Info.ShowPageLine = false;
				zYTextDocument.Info.ShowParagraphFlag = false;
				zYTextDocument.Info.ShowExpendHandle = false;
				zYTextDocument.Info.LockForMark = false;
				zYTextDocument.Info.Printing = true;
				zYTextDocument.View.Graph = graph;
				if (StringCommon.IsInteger(text3))
				{
					zYTextDocument.Pages.PaperWidth = Convert.ToInt32(text3);
					zYTextDocument.Pages.LeftMargin = 0;
					zYTextDocument.Pages.RightMargin = 0;
				}
				if (zYTextDocument.FromXMLFile(text))
				{
					CommandLine commandLine = new CommandLine();
					commandLine.XMLWriter = new XmlTextWriter(text2, Encoding.GetEncoding(936));
					zYTextDocument.View.CommandOutPut = commandLine;
					commandLine.BeginWrite();
					zYTextDocument.View.WriteCreateCommand();
					Bitmap preViewImage = zYTextDocument.GetPreViewImage(50, 50);
					preViewImage.Dispose();
					foreach (ZYTextLine line in zYTextDocument.Lines)
					{
						commandLine.CommandName = "line";
						commandLine.SetValue("top", line.Top.ToString());
						commandLine.SetValue("height", line.Height.ToString());
						commandLine.Write();
					}
					commandLine.EndWrite();
					commandLine.XMLWriter.Close();
					zYTextDocument.View.CommandOutPut = null;
				}
				zYTextDocument.Dispose();
				bitmap.Dispose();
				Console.WriteLine("操作成功");
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine("系统错误!" + ex.ToString());
			}
		}
	}
}
