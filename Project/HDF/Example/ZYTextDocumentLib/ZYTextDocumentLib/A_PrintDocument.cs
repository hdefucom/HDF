using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Xml;
using XDesignerPrinting;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class A_PrintDocument : ZYEditorAction
	{
		public override string ActionName()
		{
			return "printdocument";
		}

		public override bool Execute()
		{
			string innerText;
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load("c:\\setting.xml");
				innerText = xmlDocument.SelectSingleNode("/settings/printsetting/report/ds[key='defaultPrinter']/value").InnerText;
			}
			catch
			{
				MessageBox.Show("读取默认打印机失败，请联系管理员。");
				return false;
			}
			using (XPrintDocument xPrintDocument = new XPrintDocument())
			{
				bool fieldUnderLine = myOwnerDocument.Info.FieldUnderLine;
				try
				{
					xPrintDocument.Document = myOwnerDocument;
					xPrintDocument.EnableJumpPrint = myOwnerDocument.EnableJumpPrint;
					xPrintDocument.JumpPrintPosition = myOwnerDocument.JumpPrintPosition;
					myOwnerDocument.Pages.PrinterSettings = new PrinterSettings();
					myOwnerDocument.FillMarkImage();
					XPaperSize paperSize = new XPaperSize((PaperKind)Enum.Parse(typeof(PaperKind), ZYPublic.PaperKind), ZYPublic.PaperWidth, ZYPublic.PaperHeight);
					xPrintDocument.Document.Pages.PrinterSettings.PrinterName = innerText;
					xPrintDocument.Document.Pages.PaperSize = paperSize;
					xPrintDocument.Document.Pages.LeftMargin = ZYConfig.ReportPrintLeftMargin;
					xPrintDocument.Document.Pages.RightMargin = ZYConfig.ReportPrintRightMargin;
					myOwnerDocument.Info.FieldUnderLine = false;
					myOwnerDocument.Info.Printing = true;
					if (Param1 == "true")
					{
						xPrintDocument.Print();
					}
					else
					{
						using (PrintDialog printDialog = new PrintDialog())
						{
							for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
							{
								string a = PrinterSettings.InstalledPrinters[i];
								if (a == innerText)
								{
									printDialog.PrinterSettings.PrinterName = innerText;
									break;
								}
							}
							printDialog.AllowSomePages = !xPrintDocument.EnableJumpPrint;
							printDialog.AllowPrintToFile = false;
							printDialog.PrinterSettings.MinimumPage = 1;
							printDialog.PrinterSettings.MaximumPage = myOwnerDocument.Pages.Count;
							printDialog.PrinterSettings.FromPage = 1;
							printDialog.PrinterSettings.ToPage = myOwnerDocument.Pages.Count;
							if (printDialog.ShowDialog() == DialogResult.Cancel)
							{
								return false;
							}
							xPrintDocument.Document.Pages.PrinterSettings.Copies = printDialog.PrinterSettings.Copies;
							xPrintDocument.Document.Pages.PrinterSettings.PrinterName = printDialog.PrinterSettings.PrinterName;
							if (printDialog.PrinterSettings.PrintRange == PrintRange.AllPages)
							{
								xPrintDocument.Print();
							}
							else if (printDialog.PrinterSettings.FromPage >= 1 && printDialog.PrinterSettings.ToPage <= myOwnerDocument.Pages.Count)
							{
								for (int i = printDialog.PrinterSettings.FromPage; i <= printDialog.PrinterSettings.ToPage; i++)
								{
									xPrintDocument.PrintSpecialPage(i - 1);
								}
							}
							else
							{
								MessageBox.Show("页码范围不正确！");
							}
						}
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					myOwnerDocument.Info.FieldUnderLine = fieldUnderLine;
					myOwnerDocument.Info.Printing = false;
				}
			}
			return true;
		}
	}
}
